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
        UInt32 g_hController = 0;    // �R���g���[���n���h��	

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

            //============================================================================ �������e��
		    //�@ymcOpenController�̃p�����[�^��ݒ肵�܂��B		
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

		    //============================================================================ �������e��
		    //�@���[�V����API�̃^�C���A�E�g��ݒ肵�܂��B		
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
        //               ���W�X�^�����ݏ���
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void Btn_Write_Click(object sender, EventArgs e)
        {
		    // ���[�V����API�ϐ���`
		    UInt32      hRegister_ML;                   // ���W�X�^�f�[�^�n���h���@ML���W�X�^�p
            UInt32      hRegister_MB;                   // ���W�X�^�f�[�^�n���h���@MB���W�X�^�p
            UInt32      hRegister_OW;                   // ���W�X�^�f�[�^�n���h���@OW���W�X�^�p
            UInt32      hRegister_OB;                   // ���W�X�^�f�[�^�n���h���@OB���W�X�^�p
		    String      cRegisterName_ML;               // ML���W�X�^���i�[�ϐ�
            String      cRegisterName_MB;               // MB���W�X�^���i�[�ϐ�
            String      cRegisterName_OW;               // OW���W�X�^���i�[�ϐ�
            String      cRegisterName_OB;               // OB���W�X�^���i�[�ϐ�
		    UInt32      RegisterDataNumber;             // �Ǎ��݃��W�X�^��
            UInt16[]    Reg_ShortData = new UInt16[3];  // W or B �T�C�Y���W�X�^�f�[�^�i�[�ϐ�
		    UInt32[]    Reg_LongData = new UInt32[3];   // L�T�C�Y���W�X�^�f�[�^�i�[�ϐ�
            UInt32      rc;                             // ���[�V����API�߂�l

            hRegister_ML = 0x00000000;
            hRegister_MB = 0x00000000;
            hRegister_OW = 0x00000000;
            hRegister_OB = 0x00000000;
            //============================================================================
		    // ���W�X�^���擾
		    //============================================================================
		    // ML Register
            cRegisterName_ML = "ML" + txt_W_ML_Name.Text;

            // MB Register
            cRegisterName_MB = "MB" + txt_W_MB_Name.Text;

            // OW Register
            cRegisterName_OW = "OW" + txt_W_OW_Name.Text;

            // OB Register
            cRegisterName_OB = "OB" + txt_W_OB_Name.Text;

		    //============================================================================ �������e��
		    // ���W�X�^�f�[�^�n���h�����擾���܂��B	
		    // �擾�������W�X�^�ԍ��͑��X���b�h�ł��g�p�\�ł��B
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

		    //============================================================================ �������e��
		    // �ݒ背�W�X�^�֐ݒ�f�[�^�������݂܂��B
		    //============================================================================
		    //�@ML Register
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
        //               ���W�X�^�Ǎ��ݏ���
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_Read_Click(object sender, EventArgs e)
        {
		    // ���[�V����API�ϐ���`
		    UInt32      hRegister_ML;                   // ���W�X�^�f�[�^�n���h���@ML���W�X�^�p
            UInt32      hRegister_MB;                   // ���W�X�^�f�[�^�n���h���@MB���W�X�^�p
            UInt32      hRegister_OW;                   // ���W�X�^�f�[�^�n���h���@OW���W�X�^�p
            UInt32      hRegister_OB;                   // ���W�X�^�f�[�^�n���h���@OB���W�X�^�p
		    String      cRegisterName_ML;               // ML���W�X�^���i�[�ϐ�
            String      cRegisterName_MB;               // MB���W�X�^���i�[�ϐ�
            String      cRegisterName_OW;               // OW���W�X�^���i�[�ϐ�
            String      cRegisterName_OB;               // OB���W�X�^���i�[�ϐ�
		    UInt32      RegisterDataNumber;             // �Ǎ��݃��W�X�^��
		    UInt32      ReadDataNumber;                 // �擾�ς݃��W�X�^��
            UInt16[]    Reg_ShortData = new UInt16[3];  // W or B �T�C�Y���W�X�^�f�[�^�i�[�ϐ�
		    UInt32[]    Reg_LongData = new UInt32[3];   // L�T�C�Y���W�X�^�f�[�^�i�[�ϐ�
            UInt32      rc;                             // ���[�V����API�߂�l

            hRegister_ML = 0x00000000;
            hRegister_MB = 0x00000000;
            hRegister_OW = 0x00000000;
            hRegister_OB = 0x00000000;
            ReadDataNumber = 00000000;
            //============================================================================
		    // ���W�X�^���擾
		    //============================================================================
		    // ML Register
            cRegisterName_ML = "ML" + txt_R_ML_Name.Text;

            // MB Register
            cRegisterName_MB = "MB" + txt_R_MB_Name.Text;

            // OW Register
            cRegisterName_OW = "OW" + txt_R_OW_Name.Text;

            // OB Register
            cRegisterName_OB = "OB" + txt_R_OB_Name.Text;

		    //============================================================================ �������e��
		    // ���W�X�^�f�[�^�n���h�����擾���܂��B	
		    // �擾�������W�X�^�ԍ��͑��X���b�h�ł��g�p�\�ł��B
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
    	    
		    //============================================================================ �������e��
		    // �ݒ背�W�X�^��Ǎ��݁A�Ǎ��݃f�[�^����ʂɕ\�����܂��B
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
        //        ���[�V����API�I������
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_End_Click(object sender, EventArgs e)
        {
		    UInt32	rc;

		    //============================================================================ �������e��
		    // ���[�V����API���I�����܂��B
		    //============================================================================
            rc = CMotionAPI.ymcCloseController(g_hController);
            if (rc != CMotionAPI.MP_SUCCESS)
		    {
			    MessageBox.Show(String.Format("Error ymcCloseController \nErrorCode [ 0x{0} ]",rc.ToString("X")));
			    return;
		    }

		    //============================================================================
		    // �A�v���P�[�V�����I���B
		    //============================================================================
		    Application.Exit();
        }
    }
}