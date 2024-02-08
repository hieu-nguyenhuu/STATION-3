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
        UInt32	    g_hController_1 = 0;       // �{�[�h1�@�R���g���[���n���h��	
        UInt32      g_hController_2 = 0;       // �{�[�h2�@�R���g���[���n���h��	
        UInt32[]	g_hAxis_1 = new UInt32[3]; // �{�[�h1�@���n���h��	
        UInt32[]	g_hAxis_2 = new UInt32[3]; // �{�[�h2�@���n���h��
        UInt32      g_hDevice_1 = 0;           // �{�[�h1�@�f�o�C�X�n���h��
        UInt32      g_hDevice_2 = 0;           // �{�[�h2�@�f�o�C�X�n���h��

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
            // ���[�V����API�ϐ���`
            CMotionAPI.COM_DEVICE       ComDevice;                                  // ymcOpenController�ݒ�\����
            CMotionAPI.MOTION_DATA[]    MotionData = new CMotionAPI.MOTION_DATA[3]; // MOTION_DATA�\���́i3�����j
            Int16[]                     Direction = new Int16[3];                   // JOG�����w��i3�����j
            UInt16[]                    Timeout = new UInt16[3];                    // Timeout���ԁi3�����j
            UInt32                      rc;                                         // ���[�V����API�߂�l
            Int16                       i;                                          // �����C���f�b�N�X
            String                      AxisName;                                   // ������
            Int32[]                     VelData = new Int32[3];                     // ���x�i�[�p�ϐ��i3�����j
            Int32[]                     PosData = new Int32[3];                     // �ڕW�ʒu�i�p�[�ϐ��i3�����j
            Int32[]                     AccData = new Int32[3];                     // �����x�i�[�p�ϐ��i3�����j
            Int32[]                     DecData = new Int32[3];                     // �����x�i�[�p�ϐ��i3�����j
            
            //============================================================================ �������e��
            //�@�R���g���[���Ƃ̒ʐM���m�����܂��B
            //�@�X���b�h���ɃR�[������K�v������܂��B
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

            //============================================================================ �������e��
            // ymcOpenController�̃p�����[�^��ݒ肵�܂��B		
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
            //============================================================================ �������e��
            // ���[�V����API�̃^�C���A�E�g��ݒ肵�܂��B			
            // �R���g���[���ُ�ɂ���ʃA�v���P�[�V�����̃t���[�Y��h���܂��B
            // �X���b�h���ɃR�[������K�v������܂��B
            //============================================================================
            rc = CMotionAPI.ymcSetAPITimeoutValue(30000);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error SetAPITimeoutValue \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            //============================================================================ �������e��
            // �^�[�Q�b�g�{�[�h��1�ɐݒ�						
            //============================================================================
            rc = CMotionAPI.ymcSetController(g_hController_1);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcSetController Board 1 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            //============================================================================
            // �R���g���[�����ێ����Ă��鎲�n���h�����������܂��B
            //============================================================================
            rc = CMotionAPI.ymcClearAllAxes();
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ClearAllAxes  Board 1 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;        
            }
            //============================================================================
            // ���n���h���쐬���܂��B
            // �擾�������n���h���́A�v���Z�X�ŃO���[�o���ɂ��邱�Ƃ��ł��܂��B
            // �ȉ��́A��ʂ̐ݒ�ڑ�������ymcDeclareAxis���R�[�����A���n���h�����쐬���܂��B
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
            // �f�o�C�X�n���h�����擾���܂��B					
            //============================================================================
            rc = CMotionAPI.ymcDeclareDevice( (UInt16)spn_Axis_1.Value, g_hAxis_1, ref g_hDevice_1);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcDeclareDevice  Board 1 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            //============================================================================ �������e��
            // �^�[�Q�b�g�{�[�h��2�ɐݒ�
            //============================================================================
            rc = CMotionAPI.ymcSetController(g_hController_2);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcSetController Board 2 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            //============================================================================
            // �R���g���[�����ێ����Ă��鎲�n���h�����������܂��B
            //============================================================================
            rc = CMotionAPI.ymcClearAllAxes();
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcClearAllAxes Board 2 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;        
            }
            //============================================================================
            // ���n���h���쐬���܂��B
            // �擾�������n���h���́A�v���Z�X�ŃO���[�o���ɂ��邱�Ƃ��ł��܂��B
            // �ȉ��́A��ʂ̐ݒ�ڑ�������ymcDeclareAxis���R�[�����A���n���h�����쐬���܂��B
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
            // �f�o�C�X�n���h�����擾���܂��B
            //============================================================================
            rc = CMotionAPI.ymcDeclareDevice((UInt16)spn_Axis_2.Value, g_hAxis_2, ref g_hDevice_2);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcDeclareDevice Board 2 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }						
            //============================================================================ �������e��
            // �^�[�Q�b�g�{�[�h��1�ɐݒ�
            //============================================================================
            rc = CMotionAPI.ymcSetController(g_hController_1);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcSetController Board 1 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            //============================================================================
            // �T�[�{ON�����s���܂��B							
            //============================================================================
            rc = CMotionAPI.ymcServoControl(g_hDevice_1, (UInt16)CMotionAPI.ApiDefs.SERVO_ON, 5000);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcServoControl Board 1 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            //============================================================================ �������e��
            // �^�[�Q�b�g�{�[�h��2�ɐݒ�						
            //============================================================================
            rc = CMotionAPI.ymcSetController(g_hController_2);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcSetController Board 2 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            //============================================================================
            // �T�[�{ON�����s���܂��B							
            //============================================================================
            rc = CMotionAPI.ymcServoControl(g_hDevice_2, (UInt16)CMotionAPI.ApiDefs.SERVO_ON, 5000);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcServoControl Board 2 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            //============================================================================
            // JOG�p�����[�^�ݒ�B								
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
            //============================================================================ �������e��
            // �^�[�Q�b�g�{�[�h��1�ɐݒ�						
            //============================================================================
            rc = CMotionAPI.ymcSetController(g_hController_1);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcSetController Board 1 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            //============================================================================
            // JOG���s�B										
            //============================================================================
            for (i = 0; i < (Int16)spn_Axis_1.Value; i++)
            {
                // ���[�V�����f�[�^�ݒ�
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
            //============================================================================ �������e��
            // �^�[�Q�b�g�{�[�h��2�ɐݒ�
            //============================================================================
            rc = CMotionAPI.ymcSetController(g_hController_2);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcSetController Board 2 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            //============================================================================
            // JOG���s
            //============================================================================
            for (i = 0; i < (Int16)spn_Axis_2.Value; i++)
            {
                // ���[�V�����f�[�^�ݒ�
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
            // ���[�V����API�ϐ���`
            UInt16[]    WaitForCompletion = new UInt16[3];  // ���������i�[�ϐ��i3�����j
            UInt32      rc;                                 // ���[�V����API�߂�l
            Int16       i;                                  // �����C���f�b�N�X

            //============================================================================ �������e��
            // �^�[�Q�b�g�{�[�h��1�ɐݒ�
            //============================================================================
            rc = CMotionAPI.ymcSetController(g_hController_1);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcSetController Board 1 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            
            //============================================================================
            // �����~�����܂��B
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
            // �T�[�{OFF�����s���܂��B
            //============================================================================
            rc = CMotionAPI.ymcServoControl( g_hDevice_1, (UInt16)CMotionAPI.ApiDefs.SERVO_OFF, 5000 );
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcServoControl Board 1 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            
            //============================================================================
            // �f�o�C�X�n���h�����������܂��B
            //============================================================================
            rc = CMotionAPI.ymcClearDevice(g_hDevice_1);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcClearDevice Board 1 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            
            //============================================================================ �������e��
            // �^�[�Q�b�g�{�[�h��2�ɐݒ�
            //============================================================================
            rc = CMotionAPI.ymcSetController(g_hController_2);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcSetController Board 2 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            
            //============================================================================
            // �����~�����܂��B
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
            // �T�[�{OFF�����s���܂��B
            //============================================================================
            rc = CMotionAPI.ymcServoControl( g_hDevice_2, (UInt16)CMotionAPI.ApiDefs.SERVO_OFF, 5000 );
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcServoControl Board 2 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            //============================================================================
            // �f�o�C�X�n���h�����������܂��B
            //============================================================================
            rc = CMotionAPI.ymcClearDevice( g_hDevice_2 );
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcClearDevice Board 2 \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            
            //============================================================================ �������e��
            // ���[�V����API���I�����܂��B
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
        //        ���[�V����API�I������
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_Quit_Click(object sender, EventArgs e)
        {
			Application.Exit();
        }
    }
}