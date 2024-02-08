using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using OpenCvSharp;
namespace VISION_STATION_4
{
    public delegate Image DlGetPicture();
    class Global_Var
    {
        public static Bitmap picRef;
        public static Action<string> PushLog;
        public static Mat MatRef;
        public static Mat Rotate;
        public static Mat Object;
        public static int MasterPointX = 1545;
        public static int MasterPointY = 925;
        public static int count = 0;
        public static int type = 0;
        public static bool NG = false;
        public static bool OK = false;
        public static double pixel_mm_ratio = 0.1142;
        public static double Data_X = 0;
        public static double Data_Y = 0;
        public static double centerX = 0;
        public static double centerY = 0;
    }
}
