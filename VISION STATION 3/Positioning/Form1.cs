using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using MotionAPI;

namespace Positioning
{
    public partial class Form1 : Form
    {
        UInt32 g_hController = 0;   // コントローラハンドル	
        UInt32 g_hDevice;			// デバイスハンドル

        public Form1()
        {
            InitializeComponent();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////
        //    btn_PosingStart_Click							
        //        位置決め実行手順							
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_PosingStart_Click(object sender, EventArgs e)
        {
            // モーションAPI変数定義
            CMotionAPI.COM_DEVICE       ComDevice;                                  // ymcOpenController設定構造体
            UInt32[]                    hAxis = new UInt32[3];                      // 軸ハンドル（3軸分）
            CMotionAPI.MOTION_DATA[]    MotionData = new CMotionAPI.MOTION_DATA[3]; // MOTION_DATA構造体（3軸分）
            CMotionAPI.POSITION_DATA[]  Pos = new CMotionAPI.POSITION_DATA[3];      // POSITION_DATA構造体（3軸分）
            UInt16[]                    WaitForCompletion = new UInt16[3];          // 完了属性格納変数（3軸分）
            UInt32                      rc;                                         // モーションAPI戻り値
            Int16                       i;                                          // 軸数インデックス
            String                      AxisName;                                   // 軸名称
            Int32[]                     VelData = new Int32[3];                     // 速度格納用変数（3軸分）
            Int32[]                     PosData = new Int32[3];                     // 目標位置格用納変数（3軸分）
            Int32[]                     AccData = new Int32[3];                     // 加速度格納用変数（3軸分）
            Int32[]                     DecData = new Int32[3];                     // 減速度格納用変数（3軸分）
          
            //============================================================================ 処理内容へ
            // コントローラとの通信を確立します。
            // スレッド毎にコールする必要があります。
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
                rc = CMotionAPI.ymcDeclareAxis(1, 0, 3, (UInt16)(i + 1), (UInt16)(i + 1), (UInt16)CMotionAPI.ApiDefs.REAL_AXIS, AxisName, ref hAxis[i]); 
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
            rc = CMotionAPI.ymcDeclareDevice( (UInt16)spn_Axis.Value, hAxis, ref g_hDevice);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcDeclareDevice \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
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
            //============================================================================
            // 位置決めのパラメｰタを設定します。
            // 画面で設定した、速度、目標位置、加速度、減速度をバッファにコピーしています。
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
            // 画面の接続軸数分ループし、軸数分必要なパラメータを設定します。
            // データ設定後、位置決め（ymcMoveDriverPositioning）を開始します。
            //============================================================================
            for( i = 0; i < (short)spn_Axis.Value; i++)
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
            		
                //　位置データ設定
                Pos[i].DataType                 = (UInt16)CMotionAPI.ApiDefs.DATATYPE_IMMEDIATE;
                Pos[i].PositionData             = PosData[i];
            		
                // 完了属性を「COMMAND_STARTED（指令開始）」にすることにより、
                // 位置決め指令後すぐにアプリケーションに制御が戻ります。
                WaitForCompletion[i]            = (UInt16)CMotionAPI.ApiDefs.COMMAND_STARTED;
            }
            rc = CMotionAPI.ymcMoveDriverPositioning(g_hDevice, MotionData, Pos, 0, "Start", WaitForCompletion, 0);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcMoveDriverPositioning \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }									
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        //    btn_PosingStop_Click			
        //        軸停止手順				
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_PosingStop_Click(object sender, EventArgs e)
        {
            // モーションAPI変数定義
            CMotionAPI.MOTION_DATA[]    MotionData = new CMotionAPI.MOTION_DATA[3]; // MOTION_DATA構造体（3軸分）
            UInt16[]                    WaitForCompletion = new UInt16[3];          // 完了属性格納変数（3軸分）
            UInt32                      rc;                                         // モーションAPI戻り値
            Int16                       i;                                          // 軸数インデックス
            Int32[]                     DecData = new Int32[3];                     // 速度格納用変数（3軸分）
        					
            //============================================================================
            // 画面で設定した減速度のみをバッファに格納します。
            //============================================================================
            i = 0;
            DecData[i] = Int32.Parse(txt_A1_Dec.Text);
            i = 1;
            DecData[i] = Int32.Parse(txt_A2_Dec.Text);
            i = 2;
            DecData[i] = Int32.Parse(txt_A3_Dec.Text);
        		
            //============================================================================ 処理内容へ
            // 画面の接続軸数分ループし、軸数分必要なパラメータを設定します。
            // データ設定後、軸停止（ymcStopMotion）を実行します。
            //============================================================================
            for( i = 0; i < (short)spn_Axis.Value; i++)
            {
                /* Not Use MotionData[i].CoordinateSystem    = NULL; */
                /* Not Use MotionData[i].MoveType            = NULL; */
                /* Not Use MotionData[i].VelocityType        = NULL; */
                MotionData[i].AccDecType    = (Int16)CMotionAPI.ApiDefs.ATYPE_TIME;    // 時定数指定[ms]
                /* Not Use MotionData[i].FilterType          = NULL; */
                MotionData[i].DataType      = 0;             // 全パラメータ直接指定
                /* Not Use MotionData[i].MaxVelocity         = NULL; */
                /* Not Use MotionData[i].Acceleration        = NULL; */
                MotionData[i].Deceleration  = DecData[i];    // 減速時定数[ms]
                /* Not Use MotionData[i].FilterTime          = NULL; */
                /* Not Use MotionData[i].Velocity            = NULL; */
                /* Not Use MotionData[i].ApproachVelocity    = NULL; */
                /* Not Use MotionData[i].CreepVelocity       = NULL; */
        				
                // 完了属性を「POSITIONING_COMPLETED（位置決め完了）」にすることにより、
                // 軸停止完了まで、アプリケーションには制御がもどりません。
                WaitForCompletion[i]        = (UInt16)CMotionAPI.ApiDefs.POSITIONING_COMPLETED;
            }
            rc = CMotionAPI.ymcStopMotion( g_hDevice, MotionData, "Stop", WaitForCompletion, 0 );
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcStopMotion \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }		
            //============================================================================ 処理内容へ
            // サーボOFFを実行します。							
            // 位置決め開始時に作成したデバイスハンドルを使用しサーボOFFしています。
            // 設定接続軸が全てサーボOFFします。
            //============================================================================
            rc = CMotionAPI.ymcServoControl(g_hDevice, (UInt16)CMotionAPI.ApiDefs.SERVO_OFF, 5000);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcServoControl OFF \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            //============================================================================ 処理内容へ
            // このスレッドで作成したデバイスハンドルを消去します。
            //============================================================================
            rc = CMotionAPI.ymcClearDevice( g_hDevice );
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcClearDevice \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            //============================================================================ 処理内容へ
            // モーションAPIとの通信を切断します。
            //============================================================================
            rc = CMotionAPI.ymcCloseController( g_hController);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcCloseController \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }				
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        //    btn_Quit_Click																			
        //        アプリケーション終了																
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_Quit_Click(object sender, EventArgs e)
        {
			Application.Exit();
        }
    }
}