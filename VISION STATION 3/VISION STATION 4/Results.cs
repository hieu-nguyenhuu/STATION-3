using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VISION_STATION_4
{
    internal class Results
    {
        public string Barcode { get; set; }
        public string Model { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }

    }
}
