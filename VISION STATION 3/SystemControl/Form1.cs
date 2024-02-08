using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using MotionAPI;

namespace SystemControl
{
    public partial class Form1 : Form
    {
        UInt32	    g_hController_1 = 0;       // ボード1　コントローラハンドル	
        UInt32      g_hController_2 = 0;       // ボード2　コントローラハンドル	
        UInt32[]	g_hAxis_1 = new UInt32[3]; // ボード1　軸ハンドル	
        UInt32[]	g_hAxis_2 = new UInt32[3]; // ボード2　軸ハンドル
        UInt32      g_hDevice_1 = 0;           // ボード1　デバイスハンドル
        UInt32      g_hDevice_2 = 0;           // ボード2　デバイスハンドル

        public Form1()
        {
            InitializeComponent();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        //    btn_JOGStart_Click	
        //        JOG Start
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_PosingStart_Click(object sender, EventArgs e)
        {
            // モーションAPI変数定義
            CMotionAPI.COM_DEVICE       ComDevice;                                  // ymcOpenController設定構造体
            CMotionAPI.MOTION_DATA[]    MotionData = new CMotionAPI.MOTION_DATA[3]; // MOTION_DATA構造体（3軸分）
            Int16[]                     Direction = new Int16[3];                   // JOG方向指定（3軸分）
            UInt16[]                    Timeout = new UInt16[3];                    // Timeout時間（3軸分）
            UInt32                      rc;                                         // モーションAPI戻り値
            Int16                       i;                                          // 軸数インデックス
            String                      AxisName;                                   // 軸名称
            Int32[]                     VelData = new Int32[3];                     // 速度格納用変数（3軸分）
            Int32[]                     PosData = new Int32[3];                     // 目標位置格用納変数（3軸分）
            Int32[]                     AccData = new Int32[3];                     // 加速度格納用変数（3軸分）
            Int32[]                     DecData = new Int32[3];                     // 減速度格納用変数（3軸分）
            
            //============================================================================ 処理内容へ
            //　コントローラとの通信を確立します。
            //　スレッド毎にコールする必要があります。
            //============================================================================
            ComDevice.ComDeviceType = (UInt16)CMotionAPI.ApiDefs.COMDEVICETYPE_PCI_MODE;
            ComDevice.PortNumber    = 1;
            ComDevice.CpuNumber     = (UInt16)spn_CpuNo_1.Value;	//cpuno;
            ComDevice.NetworkNumber = 0;
            ComDevice.StationNumber = 0;
            ComDevice.UnitNumber    = 0;
            ComDevice.IPAddress     = null;
            ComDevice.Timeout       = 10000;

            rc = CMotionAPI.ymcOpenController( ref ComDevice, ref g_hController_1);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcOpenController Board 1 \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }

            //============================================================================ 処理内容へ
            // ymcOpenControllerのパラメータを設定します。		
            //============================================================================
            ComDevice.ComDeviceType = (UInt16)CMotionAPI.ApiDefs.COMDEVICETYPE_PCI_MODE;
            ComDevice.PortNumber    = 1;
            ComDevice.CpuNumber     = (UInt16)spn_CpuNo_2.Value;	//cpuno;
            ComDevice.NetworkNumber = 0;
            ComDevice.StationNumber = 0;
            ComDevice.UnitNumber    = 0;
            ComDevice.IPAddress     = "";
            ComDevice.Timeout       = 10000;

            rc = CMotionAPI.ymcOpenController(ref ComDevice, ref g_hController_2);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcOpenController Board 2 \nErrorCode [ 0x{0} ]", rc.ToString("X")));
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
            // ターゲットボードを1に設定						
            //============================================================================
            rc = CMotionAPI.ymcSetController(g_hController_1);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcSetController Board 1 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            //============================================================================
            // コントローラが保持している軸ハンドルを消去します。
            //============================================================================
            rc = CMotionAPI.ymcClearAllAxes();
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ClearAllAxes  Board 1 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;        
            }
            //============================================================================
            // 軸ハンドル作成します。
            // 取得した軸ハンドルは、プロセスでグローバルにすることができます。
            // 以下は、画面の設定接続軸数分ymcDeclareAxisをコールし、軸ハンドルを作成します。
            //============================================================================
            for (i = 0; i < (Int16)spn_Axis_1.Value; i++)
            {
                AxisName = "Axis-" + (i + 1);
                rc = CMotionAPI.ymcDeclareAxis(1, 0, 3, (UInt16)(i + 1), (UInt16)(i + 1), (UInt16)CMotionAPI.ApiDefs.REAL_AXIS, AxisName, ref g_hAxis_1[i]); 
                if(rc != CMotionAPI.MP_SUCCESS)
                {
                    MessageBox.Show(String.Format("Error ymcDeclareAxis Board 1  \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                    return;
                }
            }
            //============================================================================
            // デバイスハンドルを取得します。					
            //============================================================================
            rc = CMotionAPI.ymcDeclareDevice( (UInt16)spn_Axis_1.Value, g_hAxis_1, ref g_hDevice_1);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcDeclareDevice  Board 1 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            //============================================================================ 処理内容へ
            // ターゲットボードを2に設定
            //============================================================================
            rc = CMotionAPI.ymcSetController(g_hController_2);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcSetController Board 2 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            //============================================================================
            // コントローラが保持している軸ハンドルを消去します。
            //============================================================================
            rc = CMotionAPI.ymcClearAllAxes();
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcClearAllAxes Board 2 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;        
            }
            //============================================================================
            // 軸ハンドル作成します。
            // 取得した軸ハンドルは、プロセスでグローバルにすることができます。
            // 以下は、画面の設定接続軸数分ymcDeclareAxisをコールし、軸ハンドルを作成します。
            //============================================================================
            for (i = 0; i < (Int16)spn_Axis_2.Value; i++)
            {
                AxisName = "Axis-" + (i + 1);
                rc = CMotionAPI.ymcDeclareAxis(1, 0, 3, (UInt16)(i + 1), (UInt16)(i + 1), (UInt16)CMotionAPI.ApiDefs.REAL_AXIS, AxisName, ref g_hAxis_2[i]); 
                if(rc != CMotionAPI.MP_SUCCESS)
                {
                    MessageBox.Show(String.Format("Error ymcDeclareAxis Board 2 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                    return;
                }
            }
            //============================================================================
            // デバイスハンドルを取得します。
            //============================================================================
            rc = CMotionAPI.ymcDeclareDevice((UInt16)spn_Axis_2.Value, g_hAxis_2, ref g_hDevice_2);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcDeclareDevice Board 2 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }						
            //============================================================================ 処理内容へ
            // ターゲットボードを1に設定
            //============================================================================
            rc = CMotionAPI.ymcSetController(g_hController_1);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcSetController Board 1 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            //============================================================================
            // サーボONを実行します。							
            //============================================================================
            rc = CMotionAPI.ymcServoControl(g_hDevice_1, (UInt16)CMotionAPI.ApiDefs.SERVO_ON, 5000);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcServoControl Board 1 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            //============================================================================ 処理内容へ
            // ターゲットボードを2に設定						
            //============================================================================
            rc = CMotionAPI.ymcSetController(g_hController_2);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcSetController Board 2 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            //============================================================================
            // サーボONを実行します。							
            //============================================================================
            rc = CMotionAPI.ymcServoControl(g_hDevice_2, (UInt16)CMotionAPI.ApiDefs.SERVO_ON, 5000);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcServoControl Board 2 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            //============================================================================
            // JOGパラメータ設定。								
            //============================================================================
            i = 0;
	        VelData[i] = Int32.Parse(txt_A1_Vel.Text);
            AccData[i] = Int32.Parse(txt_A1_Acc.Text);
            DecData[i] = Int32.Parse(txt_A1_Dec.Text);
            PosData[i] = Int32.Parse(txt_A1_Pos.Text);
            i = 1;
            VelData[i] = Int32.Parse(txt_A2_Vel.Text);			
            AccData[i] = Int32.Parse(txt_A2_Acc.Text);
            DecData[i] = Int32.Parse(txt_A2_Dec.Text);
            PosData[i] = Int32.Parse(txt_A2_Pos.Text);
            i = 2;
            VelData[i] = Int32.Parse(txt_A3_Vel.Text);			
            AccData[i] = Int32.Parse(txt_A3_Acc.Text);
            DecData[i] = Int32.Parse(txt_A3_Dec.Text);
            PosData[i] = Int32.Parse(txt_A3_Pos.Text);
            //============================================================================ 処理内容へ
            // ターゲットボードを1に設定						
            //============================================================================
            rc = CMotionAPI.ymcSetController(g_hController_1);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcSetController Board 1 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            //============================================================================
            // JOG実行。										
            //============================================================================
            for (i = 0; i < (Int16)spn_Axis_1.Value; i++)
            {
                // モーションデータ設定
                MotionData[i].CoordinateSystem  = (Int16)CMotionAPI.ApiDefs.WORK_SYSTEM;
                MotionData[i].MoveType          = (Int16)CMotionAPI.ApiDefs.MTYPE_RELATIVE;
                MotionData[i].VelocityType      = (Int16)CMotionAPI.ApiDefs.VTYPE_UNIT_PAR;
                MotionData[i].AccDecType        = (Int16)CMotionAPI.ApiDefs.ATYPE_TIME;
                MotionData[i].FilterType        = (Int16)CMotionAPI.ApiDefs.FTYPE_S_CURVE;				
                MotionData[i].DataType          = 0;
                /* Not Use MotionData[i].MaxVelocity      = NULL; */
                MotionData[i].Acceleration      = AccData[i];
                MotionData[i].Deceleration      = DecData[i];
                MotionData[i].FilterTime        = 10;
                MotionData[i].Velocity          = VelData[i];					
                /* Not Use MotionData[i].ApproachVelocity = NULL; */	
                /* Not Use MotionData[i].CreepVelocity    = NULL; */	
                Direction[i]                   = (Int16)CMotionAPI.ApiDefs.DIRECTION_POSITIVE;		
                Timeout[i]                     = 0;		
            }   
            rc = CMotionAPI.ymcMoveJOG( g_hDevice_1, MotionData, Direction, Timeout, 0, "Start", 0);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcMoveJOG Board 1 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            //============================================================================ 処理内容へ
            // ターゲットボードを2に設定
            //============================================================================
            rc = CMotionAPI.ymcSetController(g_hController_2);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcSetController Board 2 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            //============================================================================
            // JOG実行
            //============================================================================
            for (i = 0; i < (Int16)spn_Axis_2.Value; i++)
            {
                // モーションデータ設定
                MotionData[i].CoordinateSystem  = (Int16)CMotionAPI.ApiDefs.WORK_SYSTEM;
                MotionData[i].MoveType          = (Int16)CMotionAPI.ApiDefs.MTYPE_RELATIVE;
                MotionData[i].VelocityType      = (Int16)CMotionAPI.ApiDefs.VTYPE_UNIT_PAR;
                MotionData[i].AccDecType        = (Int16)CMotionAPI.ApiDefs.ATYPE_TIME;
                MotionData[i].FilterType        = (Int16)CMotionAPI.ApiDefs.FTYPE_S_CURVE;				
                MotionData[i].DataType          = 0;
                /* Not Use MotionData[i].MaxVelocity      = NULL; */
                MotionData[i].Acceleration      = AccData[i];
                MotionData[i].Deceleration      = DecData[i];
                MotionData[i].FilterTime        = 10;
                MotionData[i].Velocity          = VelData[i];					
                /* Not Use MotionData[i].ApproachVelocity = NULL; */	
                /* Not Use MotionData[i].CreepVelocity    = NULL; */	
                Direction[i]                   = (Int16)CMotionAPI.ApiDefs.DIRECTION_POSITIVE;		
                Timeout[i]                     = 0;		
            }
            rc = CMotionAPI.ymcMoveJOG( g_hDevice_2, MotionData, Direction, Timeout, 0, "Start", 0);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcMoveJOG Board 2 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        //    btn_JOGStop_Click	
        //        JOG Stop
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_PosingStop_Click(object sender, EventArgs e)
        {
            // モーションAPI変数定義
            UInt16[]    WaitForCompletion = new UInt16[3];  // 完了属性格納変数（3軸分）
            UInt32      rc;                                 // モーションAPI戻り値
            Int16       i;                                  // 軸数インデックス

            //============================================================================ 処理内容へ
            // ターゲットボードを1に設定
            //============================================================================
            rc = CMotionAPI.ymcSetController(g_hController_1);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcSetController Board 1 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            
            //============================================================================
            // 軸を停止させます。
            //============================================================================
            for (i = 0; i < (Int16)spn_Axis_1.Value; i++)
            {
                WaitForCompletion[i] = (UInt16)CMotionAPI.ApiDefs.POSITIONING_COMPLETED;
            }
            rc = CMotionAPI.ymcStopJOG( g_hDevice_1, 0, "Stop", WaitForCompletion, 0);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcStopJOG Board 1 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }			 
            
            //============================================================================
            // サーボOFFを実行します。
            //============================================================================
            rc = CMotionAPI.ymcServoControl( g_hDevice_1, (UInt16)CMotionAPI.ApiDefs.SERVO_OFF, 5000 );
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcServoControl Board 1 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            
            //============================================================================
            // デバイスハンドルを消去します。
            //============================================================================
            rc = CMotionAPI.ymcClearDevice(g_hDevice_1);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcClearDevice Board 1 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            
            //============================================================================ 処理内容へ
            // ターゲットボードを2に設定
            //============================================================================
            rc = CMotionAPI.ymcSetController(g_hController_2);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcSetController Board 2 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            
            //============================================================================
            // 軸を停止させます。
            //============================================================================
            for( i = 0; i < (Int16)spn_Axis_2.Value; i++)
            {
                WaitForCompletion[i] = (UInt16)CMotionAPI.ApiDefs.POSITIONING_COMPLETED;
            }
            rc = CMotionAPI.ymcStopJOG( g_hDevice_2, 0, "Stop", WaitForCompletion, 0);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcStopJOG Board 2 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }			 
            
            //============================================================================
            // サーボOFFを実行します。
            //============================================================================
            rc = CMotionAPI.ymcServoControl( g_hDevice_2, (UInt16)CMotionAPI.ApiDefs.SERVO_OFF, 5000 );
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcServoControl Board 2 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            //============================================================================
            // デバイスハンドルを消去します。
            //============================================================================
            rc = CMotionAPI.ymcClearDevice( g_hDevice_2 );
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcClearDevice Board 2 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            
            //============================================================================ 処理内容へ
            // モーションAPIを終了します。
            //============================================================================
            rc = CMotionAPI.ymcCloseController( g_hController_2);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcCloseController Board 2 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }				
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        //    btn_Quit_Click
        //        モーションAPI終了処理
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_Quit_Click(object sender, EventArgs e)
        {
			Application.Exit();
        }
    }
}