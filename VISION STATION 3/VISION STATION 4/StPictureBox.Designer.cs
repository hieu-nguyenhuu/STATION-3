namespace VISION_STATION_4
{
    partial class StPictureBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            timer.Stop();

            for (int i = 0; i < m_aImageBuffer.Length; ++i)
            {
                if (m_aImageBuffer[i] != null)
                {
                    m_aImageBuffer[i].Dispose();
                    m_aImageBuffer[i] = null;
                }
            }

            if (m_CImageData != null)
            {
                m_CImageData.Dispose();
                m_CImageData = null;
            }

            if (m_BufferIndex != null)
            {
                m_BufferIndex.Dispose();
                m_BufferIndex = null;
            }

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 33;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // StPictureBox
            // 
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer;
    }
}
