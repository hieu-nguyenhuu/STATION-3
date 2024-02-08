using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

using Sentech.GenApiDotNET;
using Sentech.StApiDotNET;

namespace VISION_STATION_4
{
	public partial class StPictureBox : PictureBox
	{
		public StPictureBox()
		{
			InitializeComponent();

			timer.Interval = RefreshInterval;
			timer.Start();
		}

		int m_RefreshInterval = 330;  //33msec
		public int RefreshInterval
		{
			get { return m_RefreshInterval; }
			set { m_RefreshInterval = value; }
		}

		protected CImageData m_CImageData = new CImageData();
		protected CStImageBuffer[] m_aImageBuffer = new CStImageBuffer[3];
		CBufferIndex m_BufferIndex = new CBufferIndex();

		class CBufferIndex : IDisposable
		{
			Mutex m_Mutex = null;
			int m_nUsingBufferIndex = -1;
			int m_nLatestBufferIndex = -1;

			public CBufferIndex()
			{
				m_Mutex = new Mutex();
			}

			public int GetLatestBufferIndex(out bool isUpdated)
			{
				isUpdated = false;

				m_Mutex.WaitOne();
				if (m_nUsingBufferIndex != m_nLatestBufferIndex)
				{
					isUpdated = true;
					m_nUsingBufferIndex = m_nLatestBufferIndex;
				}
				m_Mutex.ReleaseMutex();

				return (m_nUsingBufferIndex);
			}

			public int GetBlankBufferIndex()
			{
				int index = 0;

				m_Mutex.WaitOne();
				while ((m_nUsingBufferIndex == index) || (m_nLatestBufferIndex == index))
				{
					++index;
				}
				m_Mutex.ReleaseMutex();

				return (index);
			}

			public void SetLatestBufferIndex(int index)
			{
				m_Mutex.WaitOne();
				m_nLatestBufferIndex = index;
				m_Mutex.ReleaseMutex();
			}

			public void Dispose()
			{
				if (m_Mutex != null)
				{
					m_Mutex.Close();
					m_Mutex = null;
				}
			}
		}

		public void SetLatestImage(IStImage stImage)
		{
			int index = m_BufferIndex.GetBlankBufferIndex();

			if (m_aImageBuffer[index] == null)
			{
				m_aImageBuffer[index] = CStApiDotNet.CreateStImageBuffer();
			}
			m_aImageBuffer[index].CopyImage(stImage);
			m_BufferIndex.SetLatestBufferIndex(index);
		}

		protected IStImage GetLatestImage(out bool isUpdated)
		{
			int index = m_BufferIndex.GetLatestBufferIndex(out isUpdated);
			if (index < 0) return (null);
			return (m_aImageBuffer[index].GetIStImage());
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			bool isUpdated;
			IStImage stImage = GetLatestImage(out isUpdated);

			if (isUpdated)
			{
				this.Image = m_CImageData.CreateBitmap(stImage);
			}
		}
	}

	public class CImageData : IDisposable
	{
		Bitmap m_Bitmap = null;
		CStPixelFormatConverter m_Converter = null;

		public Bitmap CreateBitmap(IStImage stImage)
		{
			if (m_Converter == null)
			{
				m_Converter = new CStPixelFormatConverter();
			}

			bool isColor = CStApiDotNet.GetIStPixelFormatInfo(stImage.ImagePixelFormat).IsColor;

			if (isColor)
			{
				// Convert the image data to BGR8 format.
				m_Converter.DestinationPixelFormat = eStPixelFormatNamingConvention.BGR8;
			}
			else
			{
				// Convert the image data to Mono8 format.
				m_Converter.DestinationPixelFormat = eStPixelFormatNamingConvention.Mono8;
			}

			if (m_Bitmap != null)
			{
				if ((m_Bitmap.Width != (int)stImage.ImageWidth) || (m_Bitmap.Height != (int)stImage.ImageHeight))
				{
					m_Bitmap.Dispose();
					m_Bitmap = null;
				}
			}

			if (m_Bitmap == null)
			{
				if (isColor)
				{
					m_Bitmap = new Bitmap((int)stImage.ImageWidth, (int)stImage.ImageHeight, PixelFormat.Format24bppRgb);
				}
				else
				{
					m_Bitmap = new Bitmap((int)stImage.ImageWidth, (int)stImage.ImageHeight, PixelFormat.Format8bppIndexed);
					ColorPalette palette = m_Bitmap.Palette;
					for (int i = 0; i < 256; ++i) palette.Entries[i] = Color.FromArgb(i, i, i);
					m_Bitmap.Palette = palette;
				}
			}

			using (CStImageBuffer imageBuffer = CStApiDotNet.CreateStImageBuffer())
			{
				m_Converter.Convert(stImage, imageBuffer);

				// Lock the bits of the bitmap.
				BitmapData bmpData = m_Bitmap.LockBits(new Rectangle(0, 0, m_Bitmap.Width, m_Bitmap.Height), ImageLockMode.WriteOnly, m_Bitmap.PixelFormat);

				// Place the pointer to the buffer of the bitmap.
				IntPtr ptrBmp = bmpData.Scan0;
				byte[] imageData = imageBuffer.GetIStImage().GetByteArray();
				Marshal.Copy(imageData, 0, ptrBmp, imageData.Length);
				m_Bitmap.UnlockBits(bmpData);
			}

			return m_Bitmap;
		}

		public void Dispose()
		{
			if (m_Bitmap != null)
			{
				m_Bitmap.Dispose();
				m_Bitmap = null;
			}

			if (m_Converter != null)
			{
				m_Converter.Dispose();
				m_Converter = null;
			}
		}
	}
}
