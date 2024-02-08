using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using MotionAPI;

namespace AlarmClear
{
    public partial class Form1 : Form
    {
        UInt32 g_hController;   // コントローラハンドル	
        UInt32 g_hDevice;       // ハンドルハンドル	

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
            UInt32 rc;
            CMotionAPI.COM_DEVICE ComDevice;

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
                MessageBox.Show(String.Format("Error ymcSetAPITimeoutValue \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }	 	 
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        //    btn_MotionAPI_Close
        //        モーションAPI終了処理
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_MotionAPI_Close_Click(object sender, EventArgs e)
        {
	        UInt32    rc;

	        //============================================================================ 処理内容へ
	        // モーションAPIを終了します。
	        //============================================================================
            rc = CMotionAPI.ymcCloseController(g_hController);
            if (rc != CMotionAPI.MP_SUCCESS)
	        {
		        MessageBox.Show(String.Format("Error ymcCloseController \nErrorCode [ 0x{0} ]",rc.ToString("X")));
		        return;
	        }		 		

        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        //    btn_AlmGenerate_Click
        //        未接続の軸ハンドルを取得し、コントローラのエラーを生成
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_AlmGenerate_Click(object sender, EventArgs e)
        {
	        UInt32[]    hAxis = new UInt32[10];     // 軸ハンドル
	        UInt16      i;                          // 軸数インデックス

	        //============================================================================
	        // 軸ハンドルを取得します。&　エラー生成
	        //============================================================================
	        for( i = 0; i < 10; i++)
	        {
                CMotionAPI.ymcGetAxisHandle((UInt16)CMotionAPI.ApiDefs.PHYSICALAXIS, 1, 0, 3, (UInt16)(i + 1), 0, "", ref hAxis[i]); 
	        }		 
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        //    btn_AlmDsp_Click
        //        コントローラのアラーム情報を取得し、画面に表示
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_AlmDsp_Click(object sender, EventArgs e)
        {
	        UInt32			        rc;	
	        UInt32[]		        Alarm = new UInt32[(UInt32)CMotionAPI.ApiDefs.MAX_CURRENT_ALARM];
            CMotionAPI.ALARM_INFO[] AlarmInfo = new CMotionAPI.ALARM_INFO[ (UInt32)CMotionAPI.ApiDefs.MAX_CURRENT_ALARM ];
	        UInt32			        AlarmNumber;
	        UInt32			        i;
            String[]                RowData = new String[5];

	        AlarmNumber = 0;

	        //============================================================================ 処理内容へ
	        // アラーム情報を全て取得
	        //============================================================================
	        rc = CMotionAPI.ymcGetAlarm( 0, Alarm, AlarmInfo, ref AlarmNumber);
	        if(rc != CMotionAPI.MP_SUCCESS)
	        {
		        MessageBox.Show(String.Format("Error ymcGetAlarm \nErrorCode [ 0x{0} ]",rc.ToString("X")));
		        return;
	        }

	        //============================================================================
	        // 取得したアラーム情報を表示
	        //============================================================================.
            dataGridView1.Rows.Clear();
            for( i = 0; i<AlarmNumber; i++ )
            { 
                RowData[0] = "0x" + AlarmInfo[i].ErrorCode.ToString("X");
                RowData[1] = "0x" + AlarmInfo[i].hDevice.ToString("X");
                RowData[2] = "0x" + AlarmInfo[i].hAxis.ToString("X");
                RowData[3] = AlarmInfo[i].Calendar.Month + "." + AlarmInfo[i].Calendar.Day + "." + AlarmInfo[i].Calendar.Year;
                RowData[4] = AlarmInfo[i].Calendar.Hour + ":" + AlarmInfo[i].Calendar.Minutes + ":" + AlarmInfo[i].Calendar.Milliseconds;
                dataGridView1.Rows.Add(RowData);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        //    btn_AlmClear_Click
        //        コントローラのアラームを全てクリア
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_AlmClear_Click(object sender, EventArgs e)
        {
	        UInt32	    rc;	

	        //============================================================================ 処理内容へ
	        // コントローラのアラームを全てクリア
	        //============================================================================
            rc = CMotionAPI.ymcClearAlarm(0);
            if (rc != CMotionAPI.MP_SUCCESS)
	        {
		        MessageBox.Show(String.Format("Error ymcClearAlarm \nErrorCode [ 0x{0} ]",rc.ToString("X")));
		        return;
	        }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        //    btn_SvAlmGenerate_Click
        //        サーボコントローラのアラーム生成	
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_SvAlmGenerate_Click(object sender, EventArgs e)
        {
	        UInt32[]    hAxis =new UInt32[3];   // 軸ハンドル（3軸分）
	        UInt32      rc;                     // モーションAPI戻り値
	        UInt16      i;                      // 軸数インデックス
	        String      AxisName;               // 軸名称

	        //============================================================================
	        // コントローラが保持している軸ハンドルを消去します。
	        //============================================================================
            rc = CMotionAPI.ymcClearAllAxes();
            if (rc != CMotionAPI.MP_SUCCESS)
	        {
		        MessageBox.Show(String.Format("Error ymcClearAllAxes \nErrorCode [ 0x{0} ]",rc.ToString("X")));
		        return;        
	        }
	        //============================================================================
	        // 軸ハンドル作成します。
	        // 取得した軸ハンドルは、プロセスでグローバルにすることができます。
	        // 以下は、画面の設定接続軸数分ymcDeclareAxisをコールし、軸ハンドルを作成します。
	        //============================================================================
            for (i = 0; i < (short)spn_Axis.Value; i++)
            {
                AxisName = "Axis-" + (i + 1);
                rc = CMotionAPI.ymcDeclareAxis(1, 0, 3, (UInt16)(i + 1), (UInt16)(i + 1), (UInt16)CMotionAPI.ApiDefs.REAL_AXIS, AxisName, ref hAxis[i]);
                if (rc != CMotionAPI.MP_SUCCESS)
                {
                    MessageBox.Show(String.Format("Error ymcDeclareAxis \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                    return;
                }
            }
	        //============================================================================
	        // デバイスハンドルを取得します。
	        //============================================================================
            rc = CMotionAPI.ymcDeclareDevice((UInt16)spn_Axis.Value, hAxis, ref g_hDevice);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcDeclareDevice \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }
	        //============================================================================
	        // サーボONを実行します。
	        //============================================================================
            rc = CMotionAPI.ymcServoControl(g_hDevice, (UInt16)CMotionAPI.ApiDefs.SERVO_ON, 5000);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcServoControl ON \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }
	        //============================================================================
	        // サーボOFFを実行します。
	        //============================================================================
            rc = CMotionAPI.ymcServoControl(g_hDevice, (UInt16)CMotionAPI.ApiDefs.SERVO_OFF, 5000);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcServoControl OFF \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }
	        MessageBox.Show("サーボのメカトロリンクケーブルを抜き差ししてください。");

        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        //    btn_SvAlmClear_Click
        //        サーボコントローラのアラームクリア
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_SvAlmClear_Click(object sender, EventArgs e)
        {
	        UInt32      rc;                     // モーションAPI戻り値
	        UInt32[]    hAxis =new UInt32[3];   // 軸ハンドル（3軸分）
	        UInt16      i;                      // 軸数インデックス
            
            //============================================================================ 処理内容へ
            // 軸ハンドルを取得します。
            //============================================================================
            for (i = 0; i < (UInt16)spn_Axis.Value; i++)
            {
                rc = CMotionAPI.ymcGetAxisHandle((UInt16)CMotionAPI.ApiDefs.PHYSICALAXIS, 1, 0, 3, (UInt16)(i + 1), 0, "", ref hAxis[i]);
                if (rc != CMotionAPI.MP_SUCCESS)
                {
                    MessageBox.Show(String.Format("Error ymcGetAxisHandle \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                    return;
                }
            }
            //============================================================================ 処理内容へ
            // サーボコントローラのアラームクリア
            //============================================================================
            for( i = 0; i < (short)spn_Axis.Value; i++)
            {
                rc = CMotionAPI.ymcClearServoAlarm( hAxis[i]);
                if (rc != CMotionAPI.MP_SUCCESS)
                {
                    MessageBox.Show(String.Format("Error ymcClearServoAlarm \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                    return;
                }		 			 
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        //    btn_MotionAPI_Close
        //        モーションAPI終了処理
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_End_Click(object sender, EventArgs e)
        {
            UInt32 rc;

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