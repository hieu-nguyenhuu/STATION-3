using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyModbus;
using System.Windows.Forms;
namespace VISION_STATION_4
{
    public class PLC
    {
        public static ModbusClient controllerMP = new ModbusClient();
        public static void Connect()
        {
            try
            {
                controllerMP.IPAddress = "192.168.1.32";

                //controllerMP.IPAddress = "192.168.1.42";

                controllerMP.Port = 10010;
                controllerMP = new ModbusClient(controllerMP.IPAddress, controllerMP.Port);
                controllerMP.Connect();
            }
            catch (Exception ex)
            {
                Global_Var.PushLog("Error connect to Robot IP 192.168.1.32");
                Global_Var.PushLog("Error:" + ex.ToString());
            }
        }
        public static void Disconnect()
        {
                controllerMP.Disconnect();
        }
        public static bool StateCheck()
        {
            if (controllerMP.Connected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
      
    }
}
