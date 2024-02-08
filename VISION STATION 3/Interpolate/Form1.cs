using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;
using MotionAPI;

namespace Interpolate
{
    public partial class Form1 : Form
    {
        UInt32   g_hController;             // コントローラハンドル	
        UInt32   g_hDevice;                 // デバイスハンドル
        UInt32[] g_hAxis = new UInt32[3];   // 軸ハンドル

        public Form1()
        {
            InitializeComponent();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        //    btn_MotionAPI_Open
        //        モーションAPI初期処理
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_MotionAPI_Open_Click(object sender, EventArgs e)
        {
            CMotionAPI.COM_DEVICE   ComDevice;  // ymcOpenController設定構造体
            UInt32                  rc;         // モーションAPI戻り値

            //============================================================================ 処理内容へ
            // ymcOpenControllerのパラメータを設定します。
            //============================================================================
            ComDevice.ComDeviceType = (UInt16)CMotionAPI.ApiDefs.COMDEVICETYPE_PCI_MODE;
            ComDevice.PortNumber    = 1;
            ComDevice.CpuNumber     = (UInt16)spn_CpuNo.Value;	//cpuno;
            ComDevice.NetworkNumber = 0;
            ComDevice.StationNumber = 0;
            ComDevice.UnitNumber    = 0;
            ComDevice.IPAddress     = null;
            ComDevice.Timeout       = 10000;

            rc = CMotionAPI.ymcOpenController(ref ComDevice, ref g_hController);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcOpenController Board 1 \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }

            //============================================================================ 処理内容へ
            // モーションAPIのタイムアウトを設定します。
            //============================================================================
            rc = CMotionAPI.ymcSetAPITimeoutValue(30000);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error SetAPITimeoutValue \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
        }

        //////////////////////////////////////////////////////////////////////////////
        //	btn_GetAxisHandle_Click
        //		An axial handle is acquired.
        //////////////////////////////////////////////////////////////////////////////
        private void btn_GetAxisHandle_Click(object sender, EventArgs e)
        {
            UInt32  rc;         // モーションAPI戻り値
            Int16   i;          // 軸数インデックス
            String  AxisName;   // 軸名称

            //============================================================================ 処理内容へ
            // コントローラが保持している軸ハンドルを消去します。
            //============================================================================
            rc = CMotionAPI.ymcClearAllAxes();
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ClearAllAxes \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;        
            }
            //============================================================================ 処理内容へ
            // 軸ハンドル作成します。
            // 取得した軸ハンドルは、プロセスでグローバルにすることができます。
            // 以下は、画面の設定接続軸数分ymcDeclareAxisをコールし、軸ハンドルを作成します。
            //============================================================================
            for( i = 0; i < (Int16)spn_Axis.Value; i++)
            {
                AxisName = "Axis-" + (i + 1);
                rc = CMotionAPI.ymcDeclareAxis(1, 0, 3, (UInt16)(i + 1), (UInt16)(i + 1), (UInt16)CMotionAPI.ApiDefs.REAL_AXIS, AxisName, ref g_hAxis[i]); 
                if(rc != CMotionAPI.MP_SUCCESS)
                {
                    MessageBox.Show(String.Format("Error ymcDeclareAxis \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                    return;
                }
            }
            //============================================================================ 処理内容へ
            // ymcDeclareAxisで取得した、軸ハンドルを使用しデバイスハンドルを作成します。
            // 以下は、接続軸数を1デバイスとして設定しています。
            // デバイスハンドルは、スレッド毎に必要になります。
            // その為、ここで作成したデバイスハンドルは、別スレッドで使用することはできません。
            //============================================================================
            rc = CMotionAPI.ymcDeclareDevice((UInt16)spn_Axis.Value, g_hAxis, ref g_hDevice);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcDeclareDevice \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
        }

        //////////////////////////////////////////////////////////////////////////////
        //	btn_ServoON_Click
        //		It ServoON.
        //////////////////////////////////////////////////////////////////////////////
        private void btn_ServoON_Click(object sender, EventArgs e)
        {
            UInt32    rc;    // モーションAPI戻り値
        			
            //============================================================================ 処理内容へ
            // サーボONを実行します。							
            // 作成したデバイスハンドルを使用しサーボONしています。
            // 設定接続軸が全てサーボONします。
            //============================================================================
            rc = CMotionAPI.ymcServoControl(g_hDevice, (UInt16)CMotionAPI.ApiDefs.SERVO_ON, 5000);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcServoControl ON \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
        }

        //////////////////////////////////////////////////////////////////////////////
        //	btn_ServoOFF_Click
        //		It ServoOFF.
        //////////////////////////////////////////////////////////////////////////////
        private void btn_ServoOFF_Click(object sender, EventArgs e)
        {
            UInt32    rc;    // モーションAPI戻り値
        				
            //============================================================================ 処理内容へ
            // サーボOFFを実行します。							
            // 設定接続軸が全てサーボOFFします。
            //============================================================================
            rc = CMotionAPI.ymcServoControl(g_hDevice, (UInt16)CMotionAPI.ApiDefs.SERVO_OFF, 5000);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcServoControl OFF \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
        }

        //////////////////////////////////////////////////////////////////////////////
        //	btn_InterpolateStart_Click
        //		Interpolate Start
        //////////////////////////////////////////////////////////////////////////////
        private void btn_InterpolateStart_Click(object sender, EventArgs e)
        {
            Thread oThread = new Thread(new ThreadStart(this.InterpolateProc));
            oThread.Start();        
        }

        //////////////////////////////////////////////////////////////////////////////
        //	Thraed Proc
        //		Interpolate Proc
        //////////////////////////////////////////////////////////////////////////////
        private void InterpolateProc()
        {	
            CMotionAPI.COM_DEVICE       ComDevice;                              // ymcOpenController設定構造体
            UInt32                      hController;                            // コントローラハンドル
            UInt32                      hDevice;                                // デバイスハンドル
            CMotionAPI.MOTION_DATA      MotionData;                             // MOTION_DATA構造体
            CMotionAPI.POSITION_DATA[]  Pos = new CMotionAPI.POSITION_DATA[3];  // POSITION_DATA構造体
            UInt16                      WaitForCompletion;                      // 完了属性格納変数
            UInt32                      rc;                                     // モーションAPI戻り値
            Int16                       i;                                      // 軸数インデックス
            Int32[]                     PosData = new Int32[3];                 // 目標位置格納変数（3軸分）

            //============================================================================ 処理内容へ
            // コントローラとの通信を確立します。
            // スレッド毎にコールする必要があります。
            //============================================================================
            hController = new UInt32();
            ComDevice.ComDeviceType = (UInt16)CMotionAPI.ApiDefs.COMDEVICETYPE_PCI_MODE;
            ComDevice.PortNumber    = 1;
            ComDevice.CpuNumber     = (UInt16)spn_CpuNo.Value;	//cpuno;
            ComDevice.NetworkNumber = 0;
            ComDevice.StationNumber = 0;
            ComDevice.UnitNumber    = 0;
            ComDevice.IPAddress     = "";
            ComDevice.Timeout       = 10000;

            rc = CMotionAPI.ymcOpenController(ref ComDevice, ref hController);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcOpenController Board 1 \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }

            //============================================================================ 処理内容へ
            // モーションAPIのタイムアウトを設定します。			
            // コントローラ異常による上位アプリケーションのフリーズを防ぎます。
            // スレッド毎にコールする必要があります。
            //============================================================================
            rc = CMotionAPI.ymcSetAPITimeoutValue(30000);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error SetAPITimeoutValue \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            //============================================================================ 処理内容へ
            // グローバル定義してある軸ハンドルを使用しデバイスハンドルを作成します。
            // 以下は、接続軸数を1デバイスとして設定しています。
            // デバイスハンドルは、スレッド毎に必要になります。
            //============================================================================
            hDevice = new UInt32();
            rc = CMotionAPI.ymcDeclareDevice((UInt16)spn_Axis.Value, g_hAxis, ref hDevice);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcDeclareDevice \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            //============================================================================ 処理内容へ
            // 補間パラメｰタを設定します。
            // 画面で設定した、速度、目標位置、加速度、減速度を設定しています。
            //============================================================================
            MotionData = new CMotionAPI.MOTION_DATA();
            MotionData.CoordinateSystem    = (Int16)CMotionAPI.ApiDefs.WORK_SYSTEM;     // ワーク座標系
            MotionData.MoveType            = (Int16)CMotionAPI.ApiDefs.MTYPE_RELATIVE;  // 増分値指定
            MotionData.VelocityType        = (Int16)CMotionAPI.ApiDefs.VTYPE_UNIT_PAR;  // 速度[指令単位/sec]
            MotionData.AccDecType          = (Int16)CMotionAPI.ApiDefs.ATYPE_TIME;      // 時定数指定[ms]
            MotionData.FilterType          = (Int16)CMotionAPI.ApiDefs.FTYPE_S_CURVE;   // 移動平均フィルタ（簡易S字）
            MotionData.DataType            = 0;                                         // 全パラメータ直接指定
	        MotionData.MaxVelocity         = Int32.Parse( txt_MaxVel.Text );		    // 送り最高速度[指令単位/sec]
            MotionData.Acceleration        = Int32.Parse( txt_Acc.Text );			    // 加速時定数[ms] 
            MotionData.Deceleration        = Int32.Parse( txt_Dec.Text );			    // 減速時定数[ms]
            MotionData.FilterTime          = 10;                                        // フィルタ時間[0.1ms]
            MotionData.Velocity            = Int32.Parse(txt_Vel.Text);			        // 速度[指令単位/sec]
            /* Not Use MotionData.ApproachVelocity = NULL; */
            /* Not Use MotionData.CreepVelocity    = NULL; */
          		
            i = 0;
            PosData[i] = Int32.Parse( txt_A1_Pos.Text);
            i = 1;
            PosData[i] = Int32.Parse( txt_A2_Pos.Text);
            i = 2;
            PosData[i] = Int32.Parse( txt_A3_Pos.Text);

            // 位置データ設定
            for( i = 0; i < (Int16)spn_Axis.Value; i++)
            {
                Pos[i].DataType = (Int16)CMotionAPI.ApiDefs.DATATYPE_IMMEDIATE;
                Pos[i].PositionData	= PosData[i];
            }
            // 完了属性
            WaitForCompletion = (UInt16)CMotionAPI.ApiDefs.POSITIONING_COMPLETED;

            rc = CMotionAPI.ymcMoveLinear(hDevice, ref MotionData, Pos, 0, "Start", WaitForCompletion, 0);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcMoveLinear \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }

            //============================================================================ 処理内容へ
            // このスレッドで作成したデバイスハンドルを消去します。
            //============================================================================
            rc = CMotionAPI.ymcClearDevice(hDevice);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcClearDevice \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }

            //============================================================================ 処理内容へ
            // モーションAPIとの通信を切断します。
            //============================================================================
            rc = CMotionAPI.ymcCloseController(hController);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcCloseController \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }	
        }

        //////////////////////////////////////////////////////////////////////////////
        //	btn_InterpolateStop_Click	
        //		軸停止処理
        //////////////////////////////////////////////////////////////////////////////
        private void btn_InterpolateStop_Click(object sender, EventArgs e)
        {
            CMotionAPI.MOTION_DATA[]    MotionData = new CMotionAPI.MOTION_DATA[3]; // MOTION_DATA構造体（3軸分）
            UInt16[]                    WaitForCompletion = new UInt16[3];          // 完了属性格納変数（3軸分）
            UInt32                      rc;                                         // モーションAPI戻り値
            Int16                       i;                                          // 軸数インデックス
        			
            //============================================================================ 処理内容へ
            // 画面の接続軸数分ループし、軸数分必要なパラメータを設定します。
            // データ設定後、軸停止（ymcStopMotion）を実行します。
            //============================================================================
            for( i = 0; i < (Int16)spn_Axis.Value; i++)
            {
                /* Not Use MotionData[i].CoordinateSystem = NULL; */
                /* Not Use MotionData[i].MoveType         = NULL; */ 
                /* Not Use MotionData[i].VelocityType     = NULL; */
                MotionData[i].AccDecType    = (Int16)CMotionAPI.ApiDefs.ATYPE_TIME; // 時定数指定[ms]
                /* Not Use MotionData[i].FilterType       = NULL; */
                MotionData[i].DataType      = 0;                            // 全パラメータ直接指定
                MotionData[i].MaxVelocity   = Int32.Parse(txt_MaxVel.Text); // 送り最高速度[指令単位/sec]
                /* Not Use MotionData[i].Acceleration     = NULL; */
                MotionData[i].Deceleration  = Int32.Parse(txt_Dec.Text);    // 減速時定数[ms]
                /* Not Use MotionData[i].FilterTime       = NULL; */
                /* Not Use MotionData[i].Velocity         = NULL; */
                /* Not Use MotionData[i].ApproachVelocity = NULL; */
                /* Not Use MotionData[i].CreepVelocity    = NULL; */

                WaitForCompletion[i]        = (UInt16)CMotionAPI.ApiDefs.POSITIONING_COMPLETED;
            }

            rc = CMotionAPI.ymcStopMotion(g_hDevice, MotionData, "Stop", WaitForCompletion, 0);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcStopMotion \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }			 
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        //    btn_MotionAPI_Close
        //        モーションAPI終了処理
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_Quit_Click(object sender, EventArgs e)
        {
            UInt32    rc;    // モーションAPI戻り値

            //============================================================================ 処理内容へ
            // モーションAPIを終了します。
            //============================================================================
            rc = CMotionAPI.ymcCloseController(g_hController);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcCloseController \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }		 

            //============================================================================
            // アプリケーション終了。
            //============================================================================
            Application.Exit();
        }
    }
}