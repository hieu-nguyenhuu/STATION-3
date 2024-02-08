using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sentech.StApiDotNET;
using OpenCvSharp;
using Sentech.GenApiDotNET;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;
using OpenCvSharp.Extensions;
using Point = OpenCvSharp.Point;
using System.Collections.Specialized;
using System.Collections;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace VISION_STATION_4
{

    public partial class frmMain1 : Form
    {

        // static DataSet dsconfig = new DataSet();
        public frmMain1()
        {
            InitializeComponent();
            Global_Var.PushLog += UpdateListbox;
        }
        /*Camera API defination*/
        CStApiAutoInit api = null;
        CStSystem system = null;
        CStDevice device = null;
        CStDataStream m_DataStream;
        const int DeviceSelectionWnd_Width = 960;
        const int DeviceSelectionWnd_Height = 720;
        const int delta = 20;
        /**/
        Results results = new Results();
        /*State defination*/
        bool isOnline;
        bool isProduct;
        bool isStart;
        int TotalProduct = 0;
        int OKProduct = 0;
        int NGProduct = 0;
        /*Image Process defination*/
        static int[] OffsetXType1 = new int[4];
        static int[] OffsetYType1 = new int[4];
        static int[] OffsetXType2 = new int[4];
        static int[] OffsetYType2 = new int[4];
        static int[] MinVal = new int[4];
        static int[] MaxVal = new int[4];
        private Bitmap Picshow;
        private void Form1_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;
            StartCamera();
            PLC.Connect();
            if (PLC.StateCheck())
            {
                isOnline = true;
                timerRunProgram.Enabled = true;
            }
        }
        #region Camera 
        CStDevice CreateStDevice()
        {
            CStDevice device = null;
            IStInterface iInterface = null;
            IStDeviceInfo deviceInfo = null;

            using (CStDeviceSelectionWnd wnd = new CStDeviceSelectionWnd())
            {
                wnd.SetPosition(Left + delta, Top + delta, DeviceSelectionWnd_Width, DeviceSelectionWnd_Height);
                wnd.RegisterTargetIStSystem(system);

                wnd.Show(eStWindowMode.Modal);
                wnd.GetSelectedDeviceInfo(out iInterface, out deviceInfo);
            }

            if (deviceInfo != null)
            {
                eDeviceAccessFlags deviceAccessFlags = eDeviceAccessFlags.CONTROL;
                if (deviceInfo.AccessStatus == eDeviceAccessStatus.READONLY)
                {
                    deviceAccessFlags = eDeviceAccessFlags.READONLY;
                }

                //Device Create
                device = iInterface.CreateStDevice(deviceInfo.ID, deviceAccessFlags);
            }

            return device;
        }
        bool isStopped = true;
        private void StartCamera()
        {
            try
            {
                // Initialize StApi before using.				
                api = new CStApiAutoInit();
                UpdateListbox("Create a system object for device scan and connection");
                // Create a system object for device scan and connection.
                system = new CStSystem();
                UpdateListbox("Create a camera device object and connect to first detected device");
                // Create a camera device object and connect to first detected device.
                //device = system.CreateFirstStDevice();
                // device = system. CreateStDevice(deviceInfo.ID, deviceAccessFlags);
                device = CreateStDevice();
                if (device != null)
                {
                    isStopped = false;

                    m_DataStream = device.CreateStDataStream(0);

                    m_DataStream.RegisterCallbackMethod(OnCallback);

                    // Start the image acquisition of the host (local machine) side.
                    m_DataStream.StartAcquisition();
                    // Start the image acquisition of the camera side.
                    device.AcquisitionStart();
                    UpdateListbox("Device=" + device.GetIStDeviceInfo().DisplayName);
                    UpdateListbox("Start the image acquisition of the host (local machine) side");
                    UpdateListbox("Start the image acquisition of the camera side.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        void DestroyCamera()
        {
            // Destroy the camera object.
            try
            {
                if (m_DataStream != null)
                {
                    m_DataStream.Dispose();
                    m_DataStream = null;
                }
                if (device != null)
                {
                    device.Dispose();
                    device = null;
                }
                if (system != null)
                {
                    system.Dispose();
                    system = null;
                }
                if (api != null)
                {
                    api.Dispose();
                    api = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        void StopCamera()
        {
            try
            {
                isStopped = true;
                // Stop the image acquisition of the camera side.
                device.AcquisitionStop();
                // Stop the image acquisition of the host side.
                m_DataStream.StopAcquisition();

                // The camera stopped grabbing. Enable the grab buttons. Disable the stop button.
                m_DataStream.Dispose();
                m_DataStream = null;
                Thread.Sleep(500);
                DestroyCamera();
                Thread.Sleep(500);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        void OnCallback(IStCallbackParamBase paramBase, object[] param)
        {
            // Check callback type. Only NewBuffer event is handled in here.
            if (paramBase.CallbackType == eStCallbackType.TL_DataStreamNewBuffer)
            {
                // In case of receiving a NewBuffer events:
                // Convert received callback parameter into IStCallbackParamGenTLEventNewBuffer for acquiring additional information.
                IStCallbackParamGenTLEventNewBuffer callbackParam = paramBase as IStCallbackParamGenTLEventNewBuffer;
                try
                {
                    // Get the IStDataStream interface object from the received callback parameter.
                    IStDataStream dataStream = callbackParam.GetIStDataStream();
                    // Retrieve the buffer of image data for that callback indicated there is a buffer received.
                    using (CStStreamBuffer streamBuffer = dataStream.RetrieveBuffer(0))
                    {
                        // Check if the acquired data contains image data.
                        if (streamBuffer.GetIStStreamBufferInfo().IsImagePresent)
                        {
                            stPictureBox1.SetLatestImage(streamBuffer.GetIStImage());
                            Global_Var.picRef = (Bitmap)stPictureBox1.Image;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // If any exception occurred, display the description of the error here.
                    MessageBox.Show("An exception occurred. \r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
        #region Timer
        private void timer_UI_Tick(object sender, EventArgs e)
        {
            StateStep.Text = G7_Step.ToString();
            StateOnline.BackColor = isOnline ? Color.Green : Color.Red;
            StatePLC.BackColor = PLC.StateCheck() ? Color.Green : Color.Red;
            btSTART.BackColor = isStart ? Color.Green : Color.Red;
        }
        #endregion
        #region Delegate UI
        public delegate void UpdateListBox(string s);
        public void UpdateListbox(string s)
        {
            if (listBox1.InvokeRequired)
            {
                listBox1.Invoke(new UpdateListBox(UpdateListbox), s);

            }
            else
                listBox1.Items.Insert(0, DateTime.Now.ToString("[MM-dd HH:mm:ss:fff]") + " : " + s);
        }
        #endregion
        #region  Desgin girdView
        #endregion
        #region View Info  Product
        public delegate void ViewInfoModel(string s);
        public void ViewInfoModels(string s)
        {
            if (lblModel.InvokeRequired)
            {
                lblModel.Invoke(new ViewInfoModel(ViewInfoModels), s);
            }
            else
            {
                lblModel.Text = s;
            }
        }
        public delegate void ViewInfoWork(string s);
        public void ViewInfoWorks(string s)
        {
            if (lblModel.InvokeRequired)
            {
                lblModel.Invoke(new ViewInfoWork(ViewInfoWorks), s);
            }
            else
            {
                lblWord.Text = s.Contains("-") ? s.Replace("-", "") : s;
            }
        }
        #endregion
        #region Communication
        /*communication param*/
        int G7_Step = 0;
        bool[] isEdgeStep = new bool[100];
        //int Data_MP_OffsetX;
        //int Data_MP_OffsetY;
        /**/
        private void timerRunProgram_Tick(object sender, EventArgs e)
        {
            try
            {
                var MParrInput = PLC.controllerMP.ReadCoils(528, 1);
                var start = PLC.controllerMP.ReadCoils(483, 1);
                var reset = PLC.controllerMP.ReadCoils(224, 1);
                //UpdateListbox("Receive Trigger");
                if (start[0])
                {
                    isStart = true;
                }
                else if (reset[0])
                {

                    isStart = false;
                    G7_Step = 0;

                }
                if (isStart)
                {
                    if (G7_Step == 0)
                    {
                        if (MParrInput[0])
                        {

                            if (!isEdgeStep[0])
                            {

                                /*chụp 528
                                 * ok  530
                                 * ng  531
                                 * x    130
                                 * y    131
                                 * screw 38
                                */
                                //UpdateListbox("Wait the first trigger bit");

                                isEdgeStep[0] = true;
                                G7_Step = 1;
                                UpdateListbox("Receive the trigger bit");
                            }
                            //isEdgeStep[0] = false ;
                        }
                        isEdgeStep[0] = false;
                    }
                    if (G7_Step == 1)
                    {
                        if (!isEdgeStep[1])
                        {
                            isEdgeStep[1] = true;
                            /*Image processing*/
                            UpdateListbox("Step1: Vision processing image");
                            results.TimeStart = DateTime.Now;
                            ImageChecking();
                            UpdateInfo();
                            UpdateDataGridView();
                            G7_Step = 2;

                        }
                        isEdgeStep[1] = false;
                    }
                    if (G7_Step == 2)
                    {
                        if (!isEdgeStep[2])
                        {
                            isEdgeStep[2] = true;
                            PLC.controllerMP.WriteSingleCoil(529, true);
                            UpdateListbox("Step2: Complete vision processing image");
                        }
                        if (!MParrInput[0])
                        {
                            G7_Step = 0;
                            isEdgeStep[2] = false;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                UpdateListbox("Modbus time out");
            }
          
        }

        #endregion
        #region QR
        string QRcontent;
        private int QRprocessing()
        {
            QRcontent = ImageProcessing.QRReader(Global_Var.picRef);
            if (QRcontent != null)
            {
                char[] charArray = QRcontent.ToCharArray();
                if (charArray[0] == '1')
                {
                    return 1;
                }
                else if (charArray[0] == '2')
                {
                    return 2;
                }
                else
                    return 0;
            }
            else
                return 0;
        }
        #endregion

        #region ImageProcessing
        private Image getPic()
        {
            return stPictureBox1.Image;
        }
        private void ImageChecking()
        {
            
            Global_Var.picRef = (Bitmap)getPic();
            Global_Var.MatRef = ImageProcessing.GetMat(Global_Var.picRef);
            Global_Var.type = QRprocessing();
            bool check = ImageProcessing.RectangleDetect(Global_Var.MatRef);
            if (check) 
            { 
                isProduct = true;
                TotalProduct++;
            }
            else
            { 
                isProduct = false; 
            }
            if (isProduct) 
            {
                
                if (Global_Var.type == 1) //type`1
                {
                    PLC.controllerMP.WriteSingleRegister(130, (int)Global_Var.Data_X);
                    PLC.controllerMP.WriteSingleRegister(131, (int)Global_Var.Data_Y);
                    UpdateListbox("Type 1");
                    lblSN.Text = "GDA-883299-" + "A";
                    ViewInfoModels("23FASF2-276-" + Global_Var.type.ToString());
                    ViewInfoWorks("201357");
                    int[] Check = ImageProcessing.checkscrew1(Global_Var.Rotate);
                    Global_Var.count = ImageProcessing.count_screw(Global_Var.Rotate, Check);
                    PLC.controllerMP.WriteSingleRegister(38, Global_Var.count);
                    label6.Text = Global_Var.count.ToString();
                    if (Global_Var.count == 4)
                    {

                        lblTest.Text = "OK";
                        lblTest.ForeColor = Color.Green;
                        PLC.controllerMP.WriteSingleCoil(530, true);
         
                        UpdateListbox("Transfer the complete bit");
                        OKProduct++;
                    }
                    else
                    {

                        lblTest.Text = "NG";
                        lblTest.ForeColor = Color.Red;
                        PLC.controllerMP.WriteSingleCoil(531, true);
                        UpdateListbox("Transfer the complete bit");
                        NGProduct++;
                    }
                }
                else if (Global_Var.type == 2)
                {
                    PLC.controllerMP.WriteSingleRegister(130, (int)Global_Var.Data_X);
                    PLC.controllerMP.WriteSingleRegister(131, (int)Global_Var.Data_Y);
                    UpdateListbox("Type2"); //type`2

                    lblSN.Text = "GDA-883299-" + "B";
                    ViewInfoModels("23FASF2-276-" + Global_Var.type.ToString());
                    ViewInfoWorks("102468");
                    Picshow = BitmapConverter.ToBitmap(Global_Var.MatRef);

                    int[] Check = ImageProcessing.checkscrew2(Global_Var.Rotate);
                    Global_Var.count = ImageProcessing.count_screw(Global_Var.Rotate, Check);
                    PLC.controllerMP.WriteSingleRegister(36, Global_Var.count);
                    label6.Text = Global_Var.count.ToString();

                  
                    if (Global_Var.count == 4)
                    {
                        lblTest.Text = "OK";
                        lblTest.ForeColor = Color.Green;
                        PLC.controllerMP.WriteSingleCoil(530, true);
                        OKProduct++;
                        UpdateListbox("Transfer the complete bit");
                        
                    }
                    else
                    {
                        lblTest.Text = "NG";
                        lblTest.ForeColor = Color.Red;
                        PLC.controllerMP.WriteSingleCoil(531, true);
                        UpdateListbox("Transfer the complete bit");
                        NGProduct++;
                    }
                }
                else
                {
                    lblTest.Text = "NG";
                    lblTest.ForeColor = Color.Red;
                    PLC.controllerMP.WriteSingleCoil(531, true);
                    UpdateListbox("Code reader: No READ");
                    UpdateListbox("Transfer the complete bit");
                    NGProduct++;
                }
            }
        }
        #endregion

        public void ResetInfo()
        {
            lblSN.Text = "None";
            lblModel.Text = "None";
            lblWord.Text = "None";
            NGProduct = 0;
            OKProduct = 0;
            TotalProduct = 0;
            lblNG.Text = "0";
            lblOK.Text = "0";
            lblTotal.Text = "0";
        }
        public void UpdateInfo()
        {
            TotalProduct = NGProduct + OKProduct;
            lblNG.Text = NGProduct.ToString();
            lblOK.Text = OKProduct.ToString();
            lblTotal.Text = TotalProduct.ToString();
        }
        #region Update datagridview
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
        void LoadFont()
        {
            //dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            //dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray;
            //dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            //dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            //dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            //dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //this.dataMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;

            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataMain.DefaultCellStyle = dataGridViewCellStyle2;

            //dataGridViewCellStyle3.BackColor = System.Drawing.Color.Black;
            //dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            //this.dataMain.RowsDefaultCellStyle = dataGridViewCellStyle3;
        }
        public void UpdateDataGridView()
        {
            LoadFont();
            string Type;
            if (Global_Var.type != 0)
            {
                Type = "TYPE" + Global_Var.type.ToString();
            }
            else
                Type = "NO READ";
            results.Barcode = Type;
            results.TimeEnd = DateTime.Now;
            results.Model = lblModel.Text;
            results.Status = lblTest.Text;
            dataMain.Rows.Add(results.Barcode, results.Model, results.TimeStart, results.TimeEnd, results.Status );
        }
        #endregion
        #region event
        private void frmMain1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCamera();
            PLC.Disconnect();
        }
        private void btSTART_Click(object sender, EventArgs e)
        {
            //isStart = true;
            //ImageChecking();

        }
        private void btnResetCycle_Click(object sender, EventArgs e)
        {
            G7_Step = 0;
            isStart = false;
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetInfo();
        }
        #endregion

        private void StateStep_Click(object sender, EventArgs e)
        {
            ImageChecking();
        }

    }
}
