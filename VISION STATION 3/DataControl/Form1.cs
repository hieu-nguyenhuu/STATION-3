using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using MotionAPI;

namespace DataControl
{

   public partial class Form1 : Form
   {
        UInt32 g_hController = 0;    // コントローラハンドル	

        public Form1()
        {
            InitializeComponent();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////
        //	btn_Open_Click	
        //		MotionAPI Open
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_Open_Click(object sender, EventArgs e)
        {
		    UInt32         rc;
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
            ComDevice.IPAddress     = "";
		    ComDevice.Timeout       = 10000;

            rc = CMotionAPI.ymcOpenController(ref ComDevice, ref g_hController);
            if (rc != CMotionAPI.MP_SUCCESS)
		    {
			    MessageBox.Show(String.Format("Error ymcOpenController Board 1 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
			    return;
		    }

		    //============================================================================ 処理内容へ
		    //　モーションAPIのタイムアウトを設定します。		
		    //============================================================================
            rc = CMotionAPI.ymcSetAPITimeoutValue(30000);
            if (rc != CMotionAPI.MP_SUCCESS)
		    {
                MessageBox.Show(String.Format("Error ymcSetAPITimeoutValue \nErrorCode [ 0x{0} ]",rc.ToString("X")));
			    return;
		    }	 

        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        //       btn_Write_Click	
        //               レジスタ書込み処理
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void Btn_Write_Click(object sender, EventArgs e)
        {
		    // モーションAPI変数定義
		    UInt32      hRegister_ML;                   // レジスタデータハンドル　MLレジスタ用
            UInt32      hRegister_MB;                   // レジスタデータハンドル　MBレジスタ用
            UInt32      hRegister_OW;                   // レジスタデータハンドル　OWレジスタ用
            UInt32      hRegister_OB;                   // レジスタデータハンドル　OBレジスタ用
		    String      cRegisterName_ML;               // MLレジスタ名格納変数
            String      cRegisterName_MB;               // MBレジスタ名格納変数
            String      cRegisterName_OW;               // OWレジスタ名格納変数
            String      cRegisterName_OB;               // OBレジスタ名格納変数
		    UInt32      RegisterDataNumber;             // 読込みレジスタ数
            UInt16[]    Reg_ShortData = new UInt16[3];  // W or B サイズレジスタデータ格納変数
		    UInt32[]    Reg_LongData = new UInt32[3];   // Lサイズレジスタデータ格納変数
            UInt32      rc;                             // モーションAPI戻り値

            hRegister_ML = 0x00000000;
            hRegister_MB = 0x00000000;
            hRegister_OW = 0x00000000;
            hRegister_OB = 0x00000000;
            //============================================================================
		    // レジスタ名取得
		    //============================================================================
		    // ML Register
            cRegisterName_ML = "ML" + txt_W_ML_Name.Text;

            // MB Register
            cRegisterName_MB = "MB" + txt_W_MB_Name.Text;

            // OW Register
            cRegisterName_OW = "OW" + txt_W_OW_Name.Text;

            // OB Register
            cRegisterName_OB = "OB" + txt_W_OB_Name.Text;

		    //============================================================================ 処理内容へ
		    // レジスタデータハンドルを取得します。	
		    // 取得したレジスタ番号は他スレッドでも使用可能です。
		    //============================================================================
		    // ML Register
		    rc = CMotionAPI.ymcGetRegisterDataHandle( cRegisterName_ML, ref hRegister_ML);
            if (rc != CMotionAPI.MP_SUCCESS)
		    {
			    MessageBox.Show(String.Format("Error ymcGetRegisterDataHandle ML \nErrorCode [ 0x{0} ]",rc.ToString("X")));
			    return;
		    }
            // MB Register
            rc = CMotionAPI.ymcGetRegisterDataHandle(cRegisterName_MB, ref hRegister_MB);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcGetRegisterDataHandle  MB \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }
            // OW Register
            rc = CMotionAPI.ymcGetRegisterDataHandle(cRegisterName_OW, ref hRegister_OW);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcGetRegisterDataHandle  OW \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }
            // OB Register
            rc = CMotionAPI.ymcGetRegisterDataHandle(cRegisterName_OB, ref hRegister_OB);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcGetRegisterDataHandle  OB \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }	 

		    //============================================================================ 処理内容へ
		    // 設定レジスタへ設定データを書込みます。
		    //============================================================================
		    //　ML Register
		    Reg_LongData[0] = UInt32.Parse(txt_ML_Data1.Text);
            Reg_LongData[1] = UInt32.Parse(txt_ML_Data2.Text);
            Reg_LongData[2] = UInt32.Parse(txt_ML_Data3.Text);
		    RegisterDataNumber = 3;
		    rc = CMotionAPI.ymcSetRegisterData( hRegister_ML, RegisterDataNumber, Reg_LongData);
            if (rc != CMotionAPI.MP_SUCCESS)
		    {
			    MessageBox.Show(String.Format("Error ymcSetRegisterData ML \nErrorCode [ 0x{0} ]",rc.ToString("X")));
			    return;
		    }
            // MB Register
            Reg_ShortData[0] = UInt16.Parse(txt_MB_Data1.Text);				
            RegisterDataNumber = 1;
            rc = CMotionAPI.ymcSetRegisterData(hRegister_MB, RegisterDataNumber, Reg_ShortData);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcSetRegisterData MB \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }				
            // OW Register
            Reg_ShortData[0] = UInt16.Parse(txt_OW_Data1.Text);
            Reg_ShortData[1] = UInt16.Parse(txt_OW_Data2.Text);
            Reg_ShortData[2] = UInt16.Parse(txt_OW_Data3.Text);				
            RegisterDataNumber = 3;
            rc = CMotionAPI.ymcSetRegisterData(hRegister_OW, RegisterDataNumber, Reg_ShortData);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcSetRegisterData OW \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }				
            // OB Register
            Reg_ShortData[0] = UInt16.Parse(txt_OB_Data1.Text);				
            RegisterDataNumber = 1;
            rc = CMotionAPI.ymcSetRegisterData(hRegister_OB, RegisterDataNumber, Reg_ShortData);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcSetRegisterData OB \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        //       btn_Read_Click	
        //               レジスタ読込み処理
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_Read_Click(object sender, EventArgs e)
        {
		    // モーションAPI変数定義
		    UInt32      hRegister_ML;                   // レジスタデータハンドル　MLレジスタ用
            UInt32      hRegister_MB;                   // レジスタデータハンドル　MBレジスタ用
            UInt32      hRegister_OW;                   // レジスタデータハンドル　OWレジスタ用
            UInt32      hRegister_OB;                   // レジスタデータハンドル　OBレジスタ用
		    String      cRegisterName_ML;               // MLレジスタ名格納変数
            String      cRegisterName_MB;               // MBレジスタ名格納変数
            String      cRegisterName_OW;               // OWレジスタ名格納変数
            String      cRegisterName_OB;               // OBレジスタ名格納変数
		    UInt32      RegisterDataNumber;             // 読込みレジスタ数
		    UInt32      ReadDataNumber;                 // 取得済みレジスタ数
            UInt16[]    Reg_ShortData = new UInt16[3];  // W or B サイズレジスタデータ格納変数
		    UInt32[]    Reg_LongData = new UInt32[3];   // Lサイズレジスタデータ格納変数
            UInt32      rc;                             // モーションAPI戻り値

            hRegister_ML = 0x00000000;
            hRegister_MB = 0x00000000;
            hRegister_OW = 0x00000000;
            hRegister_OB = 0x00000000;
            ReadDataNumber = 00000000;
            //============================================================================
		    // レジスタ名取得
		    //============================================================================
		    // ML Register
            cRegisterName_ML = "ML" + txt_R_ML_Name.Text;

            // MB Register
            cRegisterName_MB = "MB" + txt_R_MB_Name.Text;

            // OW Register
            cRegisterName_OW = "OW" + txt_R_OW_Name.Text;

            // OB Register
            cRegisterName_OB = "OB" + txt_R_OB_Name.Text;

		    //============================================================================ 処理内容へ
		    // レジスタデータハンドルを取得します。	
		    // 取得したレジスタ番号は他スレッドでも使用可能です。
		    //============================================================================
		    // ML Register
		    rc = CMotionAPI.ymcGetRegisterDataHandle( cRegisterName_ML, ref hRegister_ML);
            if (rc != CMotionAPI.MP_SUCCESS)
		    {
			    MessageBox.Show(String.Format("Error ymcGetRegisterDataHandle ML \nErrorCode [ 0x{0} ]",rc.ToString("X")));
			    return;
		    }
            // MB Register
            rc = CMotionAPI.ymcGetRegisterDataHandle(cRegisterName_MB, ref hRegister_MB);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcGetRegisterDataHandle  MB \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }
            // OW Register
            rc = CMotionAPI.ymcGetRegisterDataHandle(cRegisterName_OW, ref hRegister_OW);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcGetRegisterDataHandle  OW \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }
            // OB Register
            rc = CMotionAPI.ymcGetRegisterDataHandle(cRegisterName_OB, ref hRegister_OB);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcGetRegisterDataHandle  OB \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }	 
    	    
		    //============================================================================ 処理内容へ
		    // 設定レジスタを読込み、読込みデータを画面に表示します。
		    //============================================================================
            RegisterDataNumber = 3;
            rc = CMotionAPI.ymcGetRegisterData(hRegister_ML, RegisterDataNumber, Reg_LongData, ref ReadDataNumber);
		    if(rc != CMotionAPI.MP_SUCCESS)
		    {
                MessageBox.Show(String.Format("Error ymcGetRegisterData ML \nErrorCode [ 0x{0} ]", rc.ToString("X")));
			    return;
		    }
            lbl_ML_Data1.Text = Reg_LongData[0].ToString();
            lbl_ML_Data2.Text = Reg_LongData[1].ToString();
            lbl_ML_Data3.Text = Reg_LongData[2].ToString();
    	    		
		    // MB Register
            RegisterDataNumber = 1;
            rc = CMotionAPI.ymcGetRegisterData(hRegister_MB, RegisterDataNumber, Reg_ShortData, ref ReadDataNumber);
		    if(rc != CMotionAPI.MP_SUCCESS)
		    {
			    MessageBox.Show(String.Format("Error ymcGetRegisterData MB \nErrorCode [ 0x{0} ]",rc.ToString("X")));
			    return;
		    }
            lbl_MB_Data1.Text = Reg_ShortData[0].ToString();
    	    
		    // OW Register
            RegisterDataNumber = 3;
            rc = CMotionAPI.ymcGetRegisterData(hRegister_OW, RegisterDataNumber, Reg_ShortData, ref ReadDataNumber);
		    if(rc != CMotionAPI.MP_SUCCESS)
		    {
			    MessageBox.Show(String.Format("Error ymcGetRegisterData OW \nErrorCode [ 0x{0} ]",rc.ToString("X")));
			    return;
		    }
            lbl_OW_Data1.Text = Reg_ShortData[0].ToString();
            lbl_OW_Data2.Text = Reg_ShortData[1].ToString();
            lbl_OW_Data3.Text = Reg_ShortData[2].ToString();
    	    
		    // OB Register
            RegisterDataNumber = 1;
            rc = CMotionAPI.ymcGetRegisterData(hRegister_OB, RegisterDataNumber, Reg_ShortData, ref ReadDataNumber);
		    if(rc != CMotionAPI.MP_SUCCESS)
		    {
			    MessageBox.Show(String.Format("Error ymcGetRegisterData OB \nErrorCode [ 0x{0} ]",rc.ToString("X")));
			    return;
		    }
            lbl_OB_Data1.Text = Reg_ShortData[0].ToString();

        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        //    btn_MotionAPI_Close
        //        モーションAPI終了処理
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_End_Click(object sender, EventArgs e)
        {
		    UInt32	rc;

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