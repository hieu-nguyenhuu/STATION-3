using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Drawing;
using ZXing;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Security.Policy;
namespace VISION_STATION_4
{
    public class ImageProcessing
    {
        static OpenCvSharp.Point[] Vertex = new OpenCvSharp.Point[4];
        static int CenterX;
        static int CenterY;
        
        static Mat[] LineContour;
        public static Mat GetMat(System.Drawing.Image Image)
        {
            Bitmap bitmap = (Bitmap)Image;
            Mat PictureBoxImage = BitmapConverter.ToMat(bitmap);
            return PictureBoxImage;
        }
        #region Contour Detection
        public static Mat Resize(Mat mat, double k)
        {
            Cv2.Resize(mat, mat, new OpenCvSharp.Size(0, 0), k, k);
            return mat;
        }
        //static void DrawCoordinateAxis(Mat image, OpenCvSharp.Point center, int axisLength)
        //{
        //    // Vẽ trục tọa độ x (màu đỏ)
        //    Cv2.Line(image, center, new OpenCvSharp.Point(center.X + axisLength, center.Y), Scalar.Red, 10);

        //    // Vẽ mũi tên cho trục tọa độ x
        //    Cv2.Line(image, new OpenCvSharp.Point(center.X + axisLength, center.Y), new OpenCvSharp.Point(center.X + axisLength - 5, center.Y - 3), Scalar.Red, 10);
        //    Cv2.Line(image, new OpenCvSharp.Point(center.X + axisLength, center.Y), new OpenCvSharp.Point(center.X + axisLength - 5, center.Y + 3), Scalar.Red, 10);

        //    // Vẽ trục tọa độ y (màu xanh lá cây)
        //    Cv2.Line(image, center, new OpenCvSharp.Point(center.X, center.Y + axisLength), Scalar.Red, 10);

        //    // Vẽ mũi tên cho trục tọa độ y
        //    Cv2.Line(image, new OpenCvSharp.Point(center.X, center.Y + axisLength), new OpenCvSharp.Point(center.X - 3, center.Y + axisLength - 5), Scalar.Red, 10);
        //    Cv2.Line(image, new OpenCvSharp.Point(center.X, center.Y + axisLength), new OpenCvSharp.Point(center.X + 3, center.Y + axisLength - 5), Scalar.Red, 10);
        //}
        public static Mat[] ContourDetect(Mat Image, int MinArea, int MaxArea)
        {
            Mat CloneImage = Image.Clone();
            Cv2.CvtColor(CloneImage, CloneImage, ColorConversionCodes.BGR2GRAY);
            Mat BlurImage = CloneImage.GaussianBlur(new OpenCvSharp.Size(3, 3), 0);
            double MaxVal = 255;
            double Thresh = 40;
            Mat Convert_Image = new Mat();
            Cv2.Threshold(BlurImage, Convert_Image, Thresh, MaxVal, ThresholdTypes.Binary);
            Mat[] contours;
            Mat hierarchy = new Mat();
            Cv2.FindContours(Convert_Image, out contours, hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxSimple);
            foreach (var contour in contours)
            {
                double area = Cv2.ContourArea(contour);
                Console.WriteLine($"{area}");
                //if (area > 360000 && area < 400000)
                //{
                //    Image.DrawContours(contours: new Mat[] { contour }, -1, Scalar.Red, 8);
                //    Cv2.ImShow("1", Image);
                //}
            }
            Mat[] filteredContours = Array.FindAll(contours, c => (Cv2.ContourArea(c) > MinArea && Cv2.ContourArea(c) < MaxArea));
            //Cv2.ImShow("abc", Convert_Image);

            //////////////////////////////////////////////////////////////
            //Rect boundingBox = Cv2.BoundingRect(filteredContours[0]);
            //RotatedRect rotatedRect = Cv2.MinAreaRect(filteredContours[0]);
            //double angle = rotatedRect.Angle;
            //Display the coordinates of the bounding box

            //double[] center = new double[2];
            //Global_Var.centerX = (boundingBox.Left + boundingBox.Right) / 2;
            //Global_Var.centerY = (boundingBox.Top + boundingBox.Bottom) / 2;
            //Global_Var.Data_X = -(Global_Var.centerX - Global_Var.MasterPointX) * Global_Var.pixel_mm_ratio; //toa do x -> mm, 1px = 0.0855 mm
            //Global_Var.Data_Y = -(Global_Var.centerY - Global_Var.MasterPointY) * Global_Var.pixel_mm_ratio; //toa do y -> mm
            //Cv2.Circle(Image, new OpenCvSharp.Point(Global_Var.centerX, Global_Var.centerY), 8, Scalar.Red, -1);
            //Cv2.Circle(Image, new OpenCvSharp.Point(370, 400), 15, Scalar.Red, -1);
            //DrawCoordinateAxis(Image, new OpenCvSharp.Point(370, 400), 1000);
            //string text = $"({Global_Var.Data_X}, {Global_Var.Data_Y})";
            //string text2 = $" (0, 0)";
            //string x = "X (mm)";
            //string y = "Y (mm)";
            //Cv2.PutText(Image, text, new OpenCvSharp.Point(1100, 650), HersheyFonts.HersheyComplex, 1, Scalar.Red, 3);
            //Cv2.PutText(Image, text2, new OpenCvSharp.Point(188, 400), HersheyFonts.HersheyComplex, 1.5, Scalar.White, 3);
            //Cv2.PutText(Image, x, new OpenCvSharp.Point(1369, 383), HersheyFonts.HersheyComplex, 2, Scalar.Red, 3);
            //Cv2.PutText(Image, y, new OpenCvSharp.Point(100, 1435), HersheyFonts.HersheyComplex, 2, Scalar.Green, 3);
            //Mat image1 = Image.Clone();
            //image1 = Resize(Image, 0.4);
            //Cv2.ImShow("a", image1);
            //Mat image2 = CloneImage.Clone();
            //image2 = Resize(image2, 0.4);
            //Cv2.ImShow("b", image2);
            //Mat image3 = Convert_Image.Clone();
            //image3 = Resize(image3, 0.4);
            //Cv2.ImShow("c", image3);
            ////////////////////////////////////////////////////////////////////////////

            return filteredContours;
        }
        #endregion
        #region DetectWorkpiece

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public static Mat Objectdetect(Mat Image, double angle, double X, double Y)
        {
            Mat rotationMatrix = new Mat();
            if (angle > 45)
            {
                rotationMatrix = Cv2.GetRotationMatrix2D(new Point2f((float)X, (float)Y), -(90 - angle), 1.0);
            }
            else
            {
                rotationMatrix = Cv2.GetRotationMatrix2D(new Point2f((float)X, (float)Y), angle, 1.0);
            }
            Mat rotatedImage = new Mat();
            // Xoay ảnh
            Cv2.WarpAffine(Global_Var.MatRef, rotatedImage, rotationMatrix, Global_Var.MatRef.Size());
           // Cv2.ImShow("rotateimage", rotatedImage);
            Global_Var.Rotate = rotatedImage;
            return rotatedImage;
        }
        public static bool RectangleDetect(Mat Image)
        {
            Mat ImageClone = Image.Clone();
            Rect LeftRect = new Rect(new OpenCvSharp.Point(0, 0), new OpenCvSharp.Size(943, 1536));
            Mat LeftMat = new Mat(ImageClone, LeftRect);

            Rect RightRect = new Rect(new OpenCvSharp.Point(1514, 0), new OpenCvSharp.Size(534, 1536));
            Mat RightMat = new Mat(ImageClone, RightRect);
            LeftMat.SetTo(Scalar.Black);
            RightMat.SetTo(Scalar.Black);

            Mat[] contours = ContourDetect(ImageClone, 300000, 450000);

            if (contours.Count() > 0)
            {
                Rect boundingBox = Cv2.BoundingRect(contours[0]);
                RotatedRect rotatedRect = Cv2.MinAreaRect(contours[0]);
                double angle = rotatedRect.Angle;


                //double[] center = new double[2];
                Global_Var.centerX = (boundingBox.Left + boundingBox.Right) / 2;
                Global_Var.centerY = (boundingBox.Top + boundingBox.Bottom) / 2;
                //Console.WriteLine($"center: ( {Global_Var.centerX}, {Global_Var.centerY})");


                Global_Var.Data_X = (Global_Var.MasterPointX - Global_Var.centerX) * Global_Var.pixel_mm_ratio * 100; //toa do x -> mm, 1px = 0.0855 mm
                Global_Var.Data_Y = (Global_Var.MasterPointY - Global_Var.centerY) * Global_Var.pixel_mm_ratio * 100; //toa do y -> mm
                Console.WriteLine($"(X,Y): {Global_Var.Data_X}, {Global_Var.Data_Y}");
                Mat rotateImage = Objectdetect(Image, angle, Global_Var.centerX, Global_Var.centerY);


                Rect rectType2 = new Rect(boundingBox.Left+10, boundingBox.Top+10, (boundingBox.Right - boundingBox.Left)-10, (boundingBox.Bottom - boundingBox.Top)-10);
                Global_Var.Object = new Mat(rotateImage, rectType2);
                //Mat Clone = new Mat();
                //Cv2.Resize(Global_Var.Object, Clone, 0.5);
                Cv2.ImShow("Object", Global_Var.Object);

                return true;
            }
            else
                return false;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        #endregion
        #region QR
        public static string QRReader(Bitmap bitmap)
        {
            BarcodeReader barcodeReader = new BarcodeReader();
            var result = barcodeReader.Decode(bitmap);
            string qrCodeContent = null;
            if (result != null)
            {
                qrCodeContent = result.Text;
            }
            else
                qrCodeContent = null;
            return qrCodeContent;
        }
        #endregion      
     
        #region screw check

        public static Mat ImageRoi(Mat Image, OpenCvSharp.Point StartPoint, OpenCvSharp.Size Size)
        {
            Rect RoiRect = new Rect(StartPoint, Size);
            Mat ROI = new Mat(Image, RoiRect);
            Mat GrayMat = ROI.CvtColor(ColorConversionCodes.BGR2GRAY);
            return GrayMat;
        }
        public static int LightPixelCheck(Mat Image, int MinVal, int MaxVal)
        {
            double MaxThresh = 255;
            double Thresh = 90;
            Mat Convert_Image = new Mat();
            //Mat Convert_Image1 = new Mat();
            //Mat GrayMat = Global_Var.Object.CvtColor(ColorConversionCodes.BGR2GRAY);
            Cv2.Threshold(Image, Convert_Image, Thresh, MaxThresh, ThresholdTypes.Binary);
            //Cv2.Threshold(GrayMat, Convert_Image1, Thresh, MaxThresh, ThresholdTypes.Binary);
            //Cv2.ImShow("Convert_Image1", Convert_Image1);
            /*Thresh = 140 for screw and Thresh = 100 for Stamp*/
            int a = Cv2.CountNonZero(Convert_Image);
            Console.WriteLine($"a: {a}");
            if (a > MinVal && a < MaxVal)
            {
                return 1; // screw area 
            }
            else
                return 0; // not screw area
        }
        public static int[] checkscrew1(Mat image)
        {
            
            int[] Check = new int[4];
            Mat matRoi1 = ImageRoi(image, new OpenCvSharp.Point(Global_Var.centerX - 21, Global_Var.centerY - 412), new OpenCvSharp.Size(34, 34));
            Mat matRoi2 = ImageRoi(image, new OpenCvSharp.Point(Global_Var.centerX + 159, Global_Var.centerY - 20), new OpenCvSharp.Size(34, 34));
            Mat matRoi3 = ImageRoi(image, new OpenCvSharp.Point(Global_Var.centerX - 20, Global_Var.centerY + 379), new OpenCvSharp.Size(34, 34));
            Mat matRoi4 = ImageRoi(image, new OpenCvSharp.Point(Global_Var.centerX - 198, Global_Var.centerY - 20), new OpenCvSharp.Size(34, 34));

            //Cv2.ImShow("matRoi1", matRoi1);
            //Cv2.ImShow("matRoi2", matRoi2);
            //Cv2.ImShow("matRoi3", matRoi3);
            //Cv2.ImShow("matRoi4", matRoi4);

            Check[0] = LightPixelCheck(matRoi1, 120, 1000);
            Check[1] = LightPixelCheck(matRoi2, 150, 1000);
            Check[2] = LightPixelCheck(matRoi3, 150, 1050);
            Check[3] = LightPixelCheck(matRoi4, 150, 1050);
            return Check;
        }
        public static int[] checkscrew2(Mat image)
        {
            
            int[] Check = new int[4];
            Mat matRoi1 = ImageRoi(image, new OpenCvSharp.Point(Global_Var.centerX - 185, Global_Var.centerY - 398), new OpenCvSharp.Size(34, 34));
            Mat matRoi2 = ImageRoi(image, new OpenCvSharp.Point(Global_Var.centerX + 144, Global_Var.centerY - 398), new OpenCvSharp.Size(34, 34));
            Mat matRoi3 = ImageRoi(image, new OpenCvSharp.Point(Global_Var.centerX + 146, Global_Var.centerY + 366), new OpenCvSharp.Size(34, 34));
            Mat matRoi4 = ImageRoi(image, new OpenCvSharp.Point(Global_Var.centerX - 185, Global_Var.centerY + 366), new OpenCvSharp.Size(34, 34));

            //Cv2.ImShow("matRoi1", matRoi1);
            //Cv2.ImShow("matRoi2", matRoi2);
            //Cv2.ImShow("matRoi3", matRoi3);
            //Cv2.ImShow("matRoi4", matRoi4);

            Check[0] = LightPixelCheck(matRoi1, 150, 1050);
            Check[1] = LightPixelCheck(matRoi2, 150, 1000);
            Check[2] = LightPixelCheck(matRoi3, 150, 1000);
            Check[3] = LightPixelCheck(matRoi4, 150, 1100);
            return Check;
        }

        public static int count_screw(Mat image, int[] check)
        {
            int count = 0;
            if (Global_Var.type == 1)
            {
                check = checkscrew1(image);
            }
            else
            {
                check = checkscrew2(image);
            }
            for (int i = 0; i < 4; i++)
            {
                if (check[i] == 1)
                {
                    count++;
                }
            }
            Console.WriteLine($"count {count}");
            return count;
        }
        #endregion
        #region Line Check
        

        #endregion
      
        #region Image drawing
        public static Mat ImageDrawing(Mat Image, Mat[] contours)
        {
            Image.Polylines(new OpenCvSharp.Point[][] { Vertex }, isClosed: true, color: Scalar.Red, thickness: 5);
            Cv2.Circle(Image, CenterX, CenterY, 8, Scalar.Red, -1);

            return Image;
        }
        #endregion
    }
}


