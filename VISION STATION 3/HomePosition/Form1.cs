using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using MotionAPI;

namespace HomePosition
{
    public partial class Form1 : Form
    {
        UInt32		g_hController;				// コントローラハンドル				
        UInt32[]    g_hDevice = new UInt32[2];  // デバイスハンドル

        public Form1()
        {
            InitializeComponent();
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////
        //	HomePosition
        //		HomePosition Proc.
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void HomePosition(Int16 arg_AxisNo, UInt16 arg_HomeMethod, UInt16 arg_Direction, Int32 arg_Velocity, Int32 arg_Approach, Int32 arg_Creep, Int32 arg_Position)
        {
            CMotionAPI.MOTION_DATA[]    MotionData = new CMotionAPI.MOTION_DATA[1]; // MOTION_DATA構造体
            CMotionAPI.POSITION_DATA[]  Pos = new CMotionAPI.POSITION_DATA[1];      // POSITION_DATA構造体
            UInt16[]                    HomeMethod = new UInt16[1];                 // 原点復帰方式
            UInt16[]                    Direction = new UInt16[1];                  // 移動方向
            UInt16[]                    WaitForCompletion = new UInt16[1];          // 完了属性格納変数
            UInt32                      rc;                                         // モーションAPI戻り値

            //============================================================================ 処理内容へ
            // サーボONを実行します。
            //============================================================================
            rc = CMotionAPI.ymcServoControl( g_hDevice[arg_AxisNo - 1], (UInt16)CMotionAPI.ApiDefs.SERVO_ON, 5000);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcServoControl \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }

            //============================================================================ 処理内容へ
            // 原点復帰を実行します。
            //============================================================================
            // 原点復帰方式 == C相パルス方式
            if (arg_HomeMethod == (UInt16)CMotionAPI.ApiDefs.HMETHOD_C)     
            {
                // モーションデータ設定    C相パルス方式時
                /* Not Use MotionData[0].CoordinateSystem = NULL; */
                /* Not Use MotionData[0].MoveType         = NULL; */
                MotionData[0].VelocityType     = (Int16)CMotionAPI.ApiDefs.VTYPE_UNIT_PAR;    // 速度[指令単位/sec]
                MotionData[0].AccDecType = (Int16)CMotionAPI.ApiDefs.ATYPE_TIME;        // 時定数指定[ms]
                /* Not Use MotionData[0].FilterType       = NULL; */
                MotionData[0].DataType = 0;                 // 全パラメータ直接指定
                /* MotionData[0].MaxVelocity              = NULL; */
                MotionData[0].Acceleration = 100;               // 加速時定数[ms] 
                MotionData[0].Deceleration = 100;               // 減速時定数[ms]
                /* Not Use MotionData[0].FilterTime       = NULL; */
                /* Not Use MotionData[0].Velocity         = NULL; */
                MotionData[0].ApproachVelocity = arg_Approach;     // アプローチ速度[指令単位/sec]
                MotionData[0].CreepVelocity = arg_Creep;        // クリープ速度[指令単位/sec]
            }
            // 原点復帰方式 == INPUT & C相パルス方式 
            else if (arg_HomeMethod == (UInt16)CMotionAPI.ApiDefs.HMETHOD_INPUT_C)
            {
                // モーションデータ設定    INPUT ＆ C相パルス方式時
                /* Not Use MotionData[0].CoordinateSystem = NULL; */
                /* Not Use MotionData[0].MoveType         = NULL; */
                MotionData[0].VelocityType = (Int16)CMotionAPI.ApiDefs.VTYPE_UNIT_PAR;    // 速度[指令単位/sec]
                MotionData[0].AccDecType = (Int16)CMotionAPI.ApiDefs.ATYPE_TIME;        // 時定数指定[ms]
                /* Not Use MotionData[0].FilterType       = NULL; */
                MotionData[0].DataType = 0;                 // 全パラメータ直接指定
                /* MotionData[0].MaxVelocity              = NULL; */
                MotionData[0].Acceleration = 100;               // 加速時定数[ms] 
                MotionData[0].Deceleration = 100;               // 減速時定数[ms]
                /* Not Use MotionData[0].FilterTime       = NULL; */
                MotionData[0].Velocity = arg_Velocity;      // 速度[指令単位/sec]
                MotionData[0].ApproachVelocity = arg_Approach;      // アプローチ速度[指令単位/sec]
                MotionData[0].CreepVelocity = arg_Creep;         // クリープ速度[指令単位/sec]
            }
            // 位置データ設定
            Pos[0].DataType = (UInt16)CMotionAPI.ApiDefs.DATATYPE_IMMEDIATE;
            Pos[0].PositionData = arg_Position;

            // 原点復帰方式
            HomeMethod[0] = arg_HomeMethod;

            // 移動方向
            Direction[0] = arg_Direction;

            // 完了属性を「COMMAND_STARTED（指令開始）」にすることにより、
            // 位置決め指令後すぐにアプリケーションに制御が戻ります。
            WaitForCompletion[0] = (UInt16)CMotionAPI.ApiDefs.COMMAND_STARTED;

            rc = CMotionAPI.ymcMoveHomePosition( g_hDevice[arg_AxisNo - 1], MotionData, Pos, HomeMethod, Direction, 0, "Start", WaitForCompletion, 0);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcMoveHomePositioning \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }									
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        //	btn_Open_Click	
        //		MotionAPI Open
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_Open_Click(object sender, EventArgs e)
        {
            CMotionAPI.COM_DEVICE   ComDevice;              // ymcOpenController設定構造体
            String                  AxisName;               // 軸名称
            UInt32[]                hAxis = new UInt32[2];  // 軸ハンドル（3軸分）
            UInt32[]                lhAxis = new UInt32[1]; // 軸ハンドル（3軸分）
            UInt32 rc;                     // モーションAPI戻り値
            Int16                   i;                      // 軸数インデックス

            //============================================================================ 処理内容へ
            //　ymcOpenControllerのパラメータを設定します。		
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
            //　モーションAPIのタイムアウトを設定します。		
            //============================================================================
            rc = CMotionAPI.ymcSetAPITimeoutValue(30000);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error SetAPITimeoutValue \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }

            //============================================================================ 処理内容へ
            // コントローラが保持している軸ハンドルを消去します。
            //============================================================================
            rc = CMotionAPI.ymcClearAllAxes();
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ClearAllAxes \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }
            //============================================================================ 処理内容へ
            // 軸ハンドル作成します。
            // 取得した軸ハンドルは、プロセスでグローバルにすることができます。
            // 以下は、画面の設定接続軸数分ymcDeclareAxisをコールし、軸ハンドルを作成します。
            //============================================================================
            for (i = 0; i < 2; i++)
            {
                AxisName = "Axis-" + (i + 1);
                rc = CMotionAPI.ymcDeclareAxis(1, 0, 3, (UInt16)(i + 1), (UInt16)(i + 1), (UInt16)CMotionAPI.ApiDefs.REAL_AXIS, AxisName, ref hAxis[i]);
                if (rc != CMotionAPI.MP_SUCCESS)
                {
                    MessageBox.Show(String.Format("Error ymcDeclareAxis \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                    return;
                }
            }

	        //============================================================================ 処理内容へ
            // デバイスハンドルを取得します。
            //============================================================================
            for( i=0; i<2; i++ )
            {
                lhAxis[0] = hAxis[i];
                rc = CMotionAPI.ymcDeclareDevice(1, lhAxis, ref g_hDevice[i]);
                if (rc != CMotionAPI.MP_SUCCESS)
                {
                    MessageBox.Show(String.Format("Error ymcDeclareDevice \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                    return;
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        //	btn_A1_Start_Click
        //		Axis 1  HomePosition Proc.
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_A1_Start_Click(object sender, EventArgs e)
        {
            UInt16 HomeMethod;
            UInt16 Direction;
        			
            //============================================================================
            // 原点復帰方式設定
            //============================================================================
            if( rdo_A1_C.Checked == true )
            {
                HomeMethod = (UInt16)CMotionAPI.ApiDefs.HMETHOD_C;
            }
            else
            {
                HomeMethod = (UInt16)CMotionAPI.ApiDefs.HMETHOD_INPUT_C;
            }			
            //============================================================================
            // 方向設定
            //============================================================================
            if( cmb_A1_Direction.SelectedIndex == 0 )
            {
                Direction = (UInt16)CMotionAPI.ApiDefs.DIRECTION_POSITIVE;
            }
            else
            {
                Direction = (UInt16)CMotionAPI.ApiDefs.DIRECTION_NEGATIVE;
            }
            HomePosition( 1, 
		                  HomeMethod, Direction,
				          Int32.Parse(txt_A1_Vel.Text),
				          Int32.Parse(txt_A1_Approach.Text),
				          Int32.Parse(txt_A1_Creep.Text),
				          Int32.Parse(txt_A1_Pos.Text)
				        );
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        //	btn_A2_Start_Click
        //		Axis 2  HomePosition Proc.
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_A2_Start_Click(object sender, EventArgs e)
        {
            UInt16 HomeMethod;
            UInt16 Direction;

            //============================================================================
            // 原点復帰方式設定
            //============================================================================
            if (rdo_A2_C.Checked == true)
            {
                HomeMethod = (UInt16)CMotionAPI.ApiDefs.HMETHOD_C;
            }
            else
            {
                HomeMethod = (UInt16)CMotionAPI.ApiDefs.HMETHOD_INPUT_C;
            }
            //============================================================================
            // 方向設定
            //============================================================================
            if( cmb_A2_Direction.SelectedIndex == 0 )
            {
                Direction = (UInt16)CMotionAPI.ApiDefs.DIRECTION_POSITIVE;
            }
            else
            {
                Direction = (UInt16)CMotionAPI.ApiDefs.DIRECTION_NEGATIVE;
            }
            HomePosition( 2, 
		                  HomeMethod, Direction,
		                  Int32.Parse(txt_A2_Vel.Text),
				          Int32.Parse(txt_A2_Approach.Text),
				          Int32.Parse(txt_A2_Creep.Text),
				          Int32.Parse(txt_A2_Pos.Text)
				        );
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        //    btn_MotionAPI_Close
        //        モーションAPI終了処理
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_Quit_Click(object sender, EventArgs e)
        {
            UInt32  rc;    // モーションAPI戻り値
            Int16   i;     // 軸数インデックス

            //============================================================================ 処理内容へ
            // サーボOFFを実行します。							
            // 通信確立処理時に作成したデバイスハンドルを使用しサーボOFFしています。
            //============================================================================
            for( i=0; i<2; i++ )
            {
                rc = CMotionAPI.ymcServoControl(g_hDevice[i], (UInt16)CMotionAPI.ApiDefs.SERVO_OFF, 5000);
                if (rc != CMotionAPI.MP_SUCCESS)
                {
                    MessageBox.Show(String.Format("Error ymcServoControl OFF \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                    return;
                }
	        }
            //============================================================================ 処理内容へ
            // このスレッドで作成したデバイスハンドルを消去します。
            //============================================================================
            for( i=0; i<2; i++ )
            {
                rc = CMotionAPI.ymcClearDevice( g_hDevice[i]);
                if (rc != CMotionAPI.MP_SUCCESS)
                {
                    MessageBox.Show(String.Format("Error ymcClearDevice \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                    return;
                }
            }

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

        //////////////////////////////////////////////////////////////////////////////////////////////////
        //	rdo_A1_OBON_CheckedChanged 
        //		MBxx05B == ON
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void rdo_A1_OBON_CheckedChanged(object sender, EventArgs e)
        {
            UInt32 hAxis;    // 軸ハンドル
            UInt32 rc;       // モーションAPI戻り値
        				
            //============================================================================
            // 軸ハンドルを取得します。
            //============================================================================
            hAxis = new UInt32();
            rc = CMotionAPI.ymcGetAxisHandle((UInt16)CMotionAPI.ApiDefs.PHYSICALAXIS, 1, 0, 3, 1, 0, "", ref hAxis);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
	            MessageBox.Show(String.Format("Error ymcGetAxisHandle \nErrorCode [ 0x{0} ]",rc.ToString("X")));
	            return;
            }

            //============================================================================
            // OBxx05BをONします。
            //============================================================================
            rc = CMotionAPI.ymcSetMotionParameterValue(hAxis, (UInt16)CMotionAPI.ApiDefs.SETTING_PARAMETER, 5, 0x0800);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
	            MessageBox.Show(String.Format("Error ymcSetMotionParameterValue \nErrorCode [ 0x{0} ]",rc.ToString("X")));
	            return;
            }     
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        //	rdo_A1_OBOFF_CheckedChanged 
        //		MBxx05B == OFF
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void rdo_A1_OBOFF_CheckedChanged(object sender, EventArgs e)
        {
            UInt32 hAxis;    // 軸ハンドル
            UInt32 rc;       // モーションAPI戻り値

            //============================================================================ 処理内容へ
            // 軸ハンドルを取得します。
            //============================================================================
            hAxis = new UInt32();
            rc = CMotionAPI.ymcGetAxisHandle((UInt16)CMotionAPI.ApiDefs.PHYSICALAXIS, 1, 0, 3, 2, 0, "", ref hAxis);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcGetAxisHandle \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }

            //============================================================================ 処理内容へ
            // OBxx05BをOFFします。
            //============================================================================
            rc = CMotionAPI.ymcSetMotionParameterValue(hAxis, (UInt16)CMotionAPI.ApiDefs.SETTING_PARAMETER, 5, 0x0000);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcSetMotionParameterValue \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }			 			         
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        //	rdo_A2_OBON_CheckedChanged 
        //		MBxx05B == ON
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void rdo_A2_OBON_CheckedChanged(object sender, EventArgs e)
        {
            UInt32 hAxis;    // 軸ハンドル
            UInt32 rc;       // モーションAPI戻り値

            //============================================================================ 処理内容へ
            // 軸ハンドルを取得します。
            //============================================================================
            hAxis = new UInt32();
            rc = CMotionAPI.ymcGetAxisHandle((UInt16)CMotionAPI.ApiDefs.PHYSICALAXIS, 1, 0, 3, 2, 0, "", ref hAxis);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcGetAxisHandle \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }

            //============================================================================ 処理内容へ
            // OBxx05BをONします。
            //============================================================================
            rc = CMotionAPI.ymcSetMotionParameterValue(hAxis, (UInt16)CMotionAPI.ApiDefs.SETTING_PARAMETER, 5, 0x0800);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcSetMotionParameterValue \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }			         
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        //	rdo_A2_OBOFF_CheckedChanged 
        //		MBxx05B == OFF
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void rdo_A2_OBOFF_CheckedChanged(object sender, EventArgs e)
        {
            UInt32 hAxis;    // 軸ハンドル
            UInt32 rc;       // モーションAPI戻り値

            //============================================================================ 処理内容へ
            // 軸ハンドルを取得します。
            //============================================================================
            hAxis = new UInt32();
            rc = CMotionAPI.ymcGetAxisHandle((UInt16)CMotionAPI.ApiDefs.PHYSICALAXIS, 1, 0, 3, 2, 0, "", ref hAxis);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcGetAxisHandle \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }

            //============================================================================ 処理内容へ
            // OBxx05BをOFFします。
            //============================================================================
            rc = CMotionAPI.ymcSetMotionParameterValue(hAxis, (UInt16)CMotionAPI.ApiDefs.SETTING_PARAMETER, 5, 0x0000);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcSetMotionParameterValue \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }			 			         
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        //	Form1_Load 
        //		
        //////////////////////////////////////////////////////////////////////////////////////////////////        
        private void Form1_Load(object sender, EventArgs e)
        {
            //============================================================================
            // 画面コントロール初期設定
            //============================================================================
	        txt_A1_Vel.Enabled = false;
	        txt_A2_Vel.Enabled = false;        
        }

		//////////////////////////////////////////////////////////////////////////////////////////////////
		//	rdo_A1_C_CheckedChanged 
		//		画面制御
		//////////////////////////////////////////////////////////////////////////////////////////////////
		private void rdo_A1_C_CheckedChanged(object sender, EventArgs e)
		{			
		    txt_A1_Vel.Enabled = false;
		    grp_A1_OB.Enabled = false;
		    cmb_A1_Direction.Enabled = true;
		}

		//////////////////////////////////////////////////////////////////////////////////////////////////
		//	rdo_A1_INPUT_C_CheckedChanged 
		//		画面制御
		//////////////////////////////////////////////////////////////////////////////////////////////////
        private void rdo_A1_INPUT_C_CheckedChanged(object sender, EventArgs e)
		{
		    cmb_A1_Direction.Enabled = false;
		    txt_A1_Vel.Enabled = true;
		    grp_A1_OB.Enabled = true;
		}

		//////////////////////////////////////////////////////////////////////////////////////////////////
		//	rdo_A2_C_CheckedChanged 
		//		画面制御
		//////////////////////////////////////////////////////////////////////////////////////////////////
        private void rdo_A2_C_CheckedChanged(object sender, EventArgs e)
		{
		    txt_A2_Vel.Enabled = false;
		    grp_A2_OB.Enabled = false;
		    cmb_A2_Direction.Enabled = true;
		}

		//////////////////////////////////////////////////////////////////////////////////////////////////
		//	rdo_A2_INPUT_C_CheckedChanged 
		//		画面制御
		//////////////////////////////////////////////////////////////////////////////////////////////////
        private void rdo_A2_INPUT_C_CheckedChanged(object sender, EventArgs e)
		{
		    cmb_A2_Direction.Enabled = false;
		    txt_A2_Vel.Enabled = true;
		    grp_A2_OB.Enabled = true;
		}
    }
}