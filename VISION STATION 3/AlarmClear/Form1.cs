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
        UInt32 g_hController;   // �R���g���[���n���h��	
        UInt32 g_hDevice;       // �n���h���n���h��	

        public Form1()
        {
            InitializeComponent();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        //    btn_MotionAPI_Open
        //        ���[�V����API��������
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_MotionAPI_Open_Click(object sender, EventArgs e)
        {
            UInt32 rc;
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
            ComDevice.IPAddress     = null;
            ComDevice.Timeout       = 10000;

            rc = CMotionAPI.ymcOpenController(ref ComDevice, ref g_hController);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcOpenController Board 1 \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }

            //============================================================================ �������e��
            //�@���[�V����API�̃^�C���A�E�g��ݒ肵�܂��B		
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
        //        ���[�V����API�I������
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_MotionAPI_Close_Click(object sender, EventArgs e)
        {
	        UInt32    rc;

	        //============================================================================ �������e��
	        // ���[�V����API���I�����܂��B
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
        //        ���ڑ��̎��n���h�����擾���A�R���g���[���̃G���[�𐶐�
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_AlmGenerate_Click(object sender, EventArgs e)
        {
	        UInt32[]    hAxis = new UInt32[10];     // ���n���h��
	        UInt16      i;                          // �����C���f�b�N�X

	        //============================================================================
	        // ���n���h�����擾���܂��B&�@�G���[����
	        //============================================================================
	        for( i = 0; i < 10; i++)
	        {
                CMotionAPI.ymcGetAxisHandle((UInt16)CMotionAPI.ApiDefs.PHYSICALAXIS, 1, 0, 3, (UInt16)(i + 1), 0, "", ref hAxis[i]); 
	        }		 
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        //    btn_AlmDsp_Click
        //        �R���g���[���̃A���[�������擾���A��ʂɕ\��
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

	        //============================================================================ �������e��
	        // �A���[������S�Ď擾
	        //============================================================================
	        rc = CMotionAPI.ymcGetAlarm( 0, Alarm, AlarmInfo, ref AlarmNumber);
	        if(rc != CMotionAPI.MP_SUCCESS)
	        {
		        MessageBox.Show(String.Format("Error ymcGetAlarm \nErrorCode [ 0x{0} ]",rc.ToString("X")));
		        return;
	        }

	        //============================================================================
	        // �擾�����A���[������\��
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
        //        �R���g���[���̃A���[����S�ăN���A
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_AlmClear_Click(object sender, EventArgs e)
        {
	        UInt32	    rc;	

	        //============================================================================ �������e��
	        // �R���g���[���̃A���[����S�ăN���A
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
        //        �T�[�{�R���g���[���̃A���[������	
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_SvAlmGenerate_Click(object sender, EventArgs e)
        {
	        UInt32[]    hAxis =new UInt32[3];   // ���n���h���i3�����j
	        UInt32      rc;                     // ���[�V����API�߂�l
	        UInt16      i;                      // �����C���f�b�N�X
	        String      AxisName;               // ������

	        //============================================================================
	        // �R���g���[�����ێ����Ă��鎲�n���h�����������܂��B
	        //============================================================================
            rc = CMotionAPI.ymcClearAllAxes();
            if (rc != CMotionAPI.MP_SUCCESS)
	        {
		        MessageBox.Show(String.Format("Error ymcClearAllAxes \nErrorCode [ 0x{0} ]",rc.ToString("X")));
		        return;        
	        }
	        //============================================================================
	        // ���n���h���쐬���܂��B
	        // �擾�������n���h���́A�v���Z�X�ŃO���[�o���ɂ��邱�Ƃ��ł��܂��B
	        // �ȉ��́A��ʂ̐ݒ�ڑ�������ymcDeclareAxis���R�[�����A���n���h�����쐬���܂��B
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
	        // �f�o�C�X�n���h�����擾���܂��B
	        //============================================================================
            rc = CMotionAPI.ymcDeclareDevice((UInt16)spn_Axis.Value, hAxis, ref g_hDevice);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcDeclareDevice \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }
	        //============================================================================
	        // �T�[�{ON�����s���܂��B
	        //============================================================================
            rc = CMotionAPI.ymcServoControl(g_hDevice, (UInt16)CMotionAPI.ApiDefs.SERVO_ON, 5000);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcServoControl ON \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }
	        //============================================================================
	        // �T�[�{OFF�����s���܂��B
	        //============================================================================
            rc = CMotionAPI.ymcServoControl(g_hDevice, (UInt16)CMotionAPI.ApiDefs.SERVO_OFF, 5000);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcServoControl OFF \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }
	        MessageBox.Show("�T�[�{�̃��J�g�������N�P�[�u���𔲂��������Ă��������B");

        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        //    btn_SvAlmClear_Click
        //        �T�[�{�R���g���[���̃A���[���N���A
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_SvAlmClear_Click(object sender, EventArgs e)
        {
	        UInt32      rc;                     // ���[�V����API�߂�l
	        UInt32[]    hAxis =new UInt32[3];   // ���n���h���i3�����j
	        UInt16      i;                      // �����C���f�b�N�X
            
            //============================================================================ �������e��
            // ���n���h�����擾���܂��B
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
            //============================================================================ �������e��
            // �T�[�{�R���g���[���̃A���[���N���A
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
        //        ���[�V����API�I������
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_End_Click(object sender, EventArgs e)
        {
            UInt32 rc;

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