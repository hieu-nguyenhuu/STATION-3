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
        UInt32		g_hController;				// �R���g���[���n���h��				
        UInt32[]    g_hDevice = new UInt32[2];  // �f�o�C�X�n���h��

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
            CMotionAPI.MOTION_DATA[]    MotionData = new CMotionAPI.MOTION_DATA[1]; // MOTION_DATA�\����
            CMotionAPI.POSITION_DATA[]  Pos = new CMotionAPI.POSITION_DATA[1];      // POSITION_DATA�\����
            UInt16[]                    HomeMethod = new UInt16[1];                 // ���_���A����
            UInt16[]                    Direction = new UInt16[1];                  // �ړ�����
            UInt16[]                    WaitForCompletion = new UInt16[1];          // ���������i�[�ϐ�
            UInt32                      rc;                                         // ���[�V����API�߂�l

            //============================================================================ �������e��
            // �T�[�{ON�����s���܂��B
            //============================================================================
            rc = CMotionAPI.ymcServoControl( g_hDevice[arg_AxisNo - 1], (UInt16)CMotionAPI.ApiDefs.SERVO_ON, 5000);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcServoControl \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }

            //============================================================================ �������e��
            // ���_���A�����s���܂��B
            //============================================================================
            // ���_���A���� == C���p���X����
            if (arg_HomeMethod == (UInt16)CMotionAPI.ApiDefs.HMETHOD_C)     
            {
                // ���[�V�����f�[�^�ݒ�    C���p���X������
                /* Not Use MotionData[0].CoordinateSystem = NULL; */
                /* Not Use MotionData[0].MoveType         = NULL; */
                MotionData[0].VelocityType     = (Int16)CMotionAPI.ApiDefs.VTYPE_UNIT_PAR;    // ���x[�w�ߒP��/sec]
                MotionData[0].AccDecType = (Int16)CMotionAPI.ApiDefs.ATYPE_TIME;        // ���萔�w��[ms]
                /* Not Use MotionData[0].FilterType       = NULL; */
                MotionData[0].DataType = 0;                 // �S�p�����[�^���ڎw��
                /* MotionData[0].MaxVelocity              = NULL; */
                MotionData[0].Acceleration = 100;               // �������萔[ms] 
                MotionData[0].Deceleration = 100;               // �������萔[ms]
                /* Not Use MotionData[0].FilterTime       = NULL; */
                /* Not Use MotionData[0].Velocity         = NULL; */
                MotionData[0].ApproachVelocity = arg_Approach;     // �A�v���[�`���x[�w�ߒP��/sec]
                MotionData[0].CreepVelocity = arg_Creep;        // �N���[�v���x[�w�ߒP��/sec]
            }
            // ���_���A���� == INPUT & C���p���X���� 
            else if (arg_HomeMethod == (UInt16)CMotionAPI.ApiDefs.HMETHOD_INPUT_C)
            {
                // ���[�V�����f�[�^�ݒ�    INPUT �� C���p���X������
                /* Not Use MotionData[0].CoordinateSystem = NULL; */
                /* Not Use MotionData[0].MoveType         = NULL; */
                MotionData[0].VelocityType = (Int16)CMotionAPI.ApiDefs.VTYPE_UNIT_PAR;    // ���x[�w�ߒP��/sec]
                MotionData[0].AccDecType = (Int16)CMotionAPI.ApiDefs.ATYPE_TIME;        // ���萔�w��[ms]
                /* Not Use MotionData[0].FilterType       = NULL; */
                MotionData[0].DataType = 0;                 // �S�p�����[�^���ڎw��
                /* MotionData[0].MaxVelocity              = NULL; */
                MotionData[0].Acceleration = 100;               // �������萔[ms] 
                MotionData[0].Deceleration = 100;               // �������萔[ms]
                /* Not Use MotionData[0].FilterTime       = NULL; */
                MotionData[0].Velocity = arg_Velocity;      // ���x[�w�ߒP��/sec]
                MotionData[0].ApproachVelocity = arg_Approach;      // �A�v���[�`���x[�w�ߒP��/sec]
                MotionData[0].CreepVelocity = arg_Creep;         // �N���[�v���x[�w�ߒP��/sec]
            }
            // �ʒu�f�[�^�ݒ�
            Pos[0].DataType = (UInt16)CMotionAPI.ApiDefs.DATATYPE_IMMEDIATE;
            Pos[0].PositionData = arg_Position;

            // ���_���A����
            HomeMethod[0] = arg_HomeMethod;

            // �ړ�����
            Direction[0] = arg_Direction;

            // �����������uCOMMAND_STARTED�i�w�ߊJ�n�j�v�ɂ��邱�Ƃɂ��A
            // �ʒu���ߎw�ߌシ���ɃA�v���P�[�V�����ɐ��䂪�߂�܂��B
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
            CMotionAPI.COM_DEVICE   ComDevice;              // ymcOpenController�ݒ�\����
            String                  AxisName;               // ������
            UInt32[]                hAxis = new UInt32[2];  // ���n���h���i3�����j
            UInt32[]                lhAxis = new UInt32[1]; // ���n���h���i3�����j
            UInt32 rc;                     // ���[�V����API�߂�l
            Int16                   i;                      // �����C���f�b�N�X

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
                MessageBox.Show(String.Format("Error SetAPITimeoutValue \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }

            //============================================================================ �������e��
            // �R���g���[�����ێ����Ă��鎲�n���h�����������܂��B
            //============================================================================
            rc = CMotionAPI.ymcClearAllAxes();
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ClearAllAxes \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }
            //============================================================================ �������e��
            // ���n���h���쐬���܂��B
            // �擾�������n���h���́A�v���Z�X�ŃO���[�o���ɂ��邱�Ƃ��ł��܂��B
            // �ȉ��́A��ʂ̐ݒ�ڑ�������ymcDeclareAxis���R�[�����A���n���h�����쐬���܂��B
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

	        //============================================================================ �������e��
            // �f�o�C�X�n���h�����擾���܂��B
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
            // ���_���A�����ݒ�
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
            // �����ݒ�
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
            // ���_���A�����ݒ�
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
            // �����ݒ�
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
        //        ���[�V����API�I������
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_Quit_Click(object sender, EventArgs e)
        {
            UInt32  rc;    // ���[�V����API�߂�l
            Int16   i;     // �����C���f�b�N�X

            //============================================================================ �������e��
            // �T�[�{OFF�����s���܂��B							
            // �ʐM�m���������ɍ쐬�����f�o�C�X�n���h�����g�p���T�[�{OFF���Ă��܂��B
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
            //============================================================================ �������e��
            // ���̃X���b�h�ō쐬�����f�o�C�X�n���h�����������܂��B
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

        //////////////////////////////////////////////////////////////////////////////////////////////////
        //	rdo_A1_OBON_CheckedChanged 
        //		MBxx05B == ON
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void rdo_A1_OBON_CheckedChanged(object sender, EventArgs e)
        {
            UInt32 hAxis;    // ���n���h��
            UInt32 rc;       // ���[�V����API�߂�l
        				
            //============================================================================
            // ���n���h�����擾���܂��B
            //============================================================================
            hAxis = new UInt32();
            rc = CMotionAPI.ymcGetAxisHandle((UInt16)CMotionAPI.ApiDefs.PHYSICALAXIS, 1, 0, 3, 1, 0, "", ref hAxis);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
	            MessageBox.Show(String.Format("Error ymcGetAxisHandle \nErrorCode [ 0x{0} ]",rc.ToString("X")));
	            return;
            }

            //============================================================================
            // OBxx05B��ON���܂��B
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
            UInt32 hAxis;    // ���n���h��
            UInt32 rc;       // ���[�V����API�߂�l

            //============================================================================ �������e��
            // ���n���h�����擾���܂��B
            //============================================================================
            hAxis = new UInt32();
            rc = CMotionAPI.ymcGetAxisHandle((UInt16)CMotionAPI.ApiDefs.PHYSICALAXIS, 1, 0, 3, 2, 0, "", ref hAxis);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcGetAxisHandle \nErrorCode [ 0x{0} ]", rc.ToString("X")));
                return;
            }

            //============================================================================ �������e��
            // OBxx05B��OFF���܂��B
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
            UInt32 hAxis;    // ���n���h��
            UInt32 rc;       // ���[�V����API�߂�l

            //============================================================================ �������e��
            // ���n���h�����擾���܂��B
            //============================================================================
            hAxis = new UInt32();
            rc = CMotionAPI.ymcGetAxisHandle((UInt16)CMotionAPI.ApiDefs.PHYSICALAXIS, 1, 0, 3, 2, 0, "", ref hAxis);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcGetAxisHandle \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }

            //============================================================================ �������e��
            // OBxx05B��ON���܂��B
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
            UInt32 hAxis;    // ���n���h��
            UInt32 rc;       // ���[�V����API�߂�l

            //============================================================================ �������e��
            // ���n���h�����擾���܂��B
            //============================================================================
            hAxis = new UInt32();
            rc = CMotionAPI.ymcGetAxisHandle((UInt16)CMotionAPI.ApiDefs.PHYSICALAXIS, 1, 0, 3, 2, 0, "", ref hAxis);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcGetAxisHandle \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }

            //============================================================================ �������e��
            // OBxx05B��OFF���܂��B
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
            // ��ʃR���g���[�������ݒ�
            //============================================================================
	        txt_A1_Vel.Enabled = false;
	        txt_A2_Vel.Enabled = false;        
        }

		//////////////////////////////////////////////////////////////////////////////////////////////////
		//	rdo_A1_C_CheckedChanged 
		//		��ʐ���
		//////////////////////////////////////////////////////////////////////////////////////////////////
		private void rdo_A1_C_CheckedChanged(object sender, EventArgs e)
		{			
		    txt_A1_Vel.Enabled = false;
		    grp_A1_OB.Enabled = false;
		    cmb_A1_Direction.Enabled = true;
		}

		//////////////////////////////////////////////////////////////////////////////////////////////////
		//	rdo_A1_INPUT_C_CheckedChanged 
		//		��ʐ���
		//////////////////////////////////////////////////////////////////////////////////////////////////
        private void rdo_A1_INPUT_C_CheckedChanged(object sender, EventArgs e)
		{
		    cmb_A1_Direction.Enabled = false;
		    txt_A1_Vel.Enabled = true;
		    grp_A1_OB.Enabled = true;
		}

		//////////////////////////////////////////////////////////////////////////////////////////////////
		//	rdo_A2_C_CheckedChanged 
		//		��ʐ���
		//////////////////////////////////////////////////////////////////////////////////////////////////
        private void rdo_A2_C_CheckedChanged(object sender, EventArgs e)
		{
		    txt_A2_Vel.Enabled = false;
		    grp_A2_OB.Enabled = false;
		    cmb_A2_Direction.Enabled = true;
		}

		//////////////////////////////////////////////////////////////////////////////////////////////////
		//	rdo_A2_INPUT_C_CheckedChanged 
		//		��ʐ���
		//////////////////////////////////////////////////////////////////////////////////////////////////
        private void rdo_A2_INPUT_C_CheckedChanged(object sender, EventArgs e)
		{
		    cmb_A2_Direction.Enabled = false;
		    txt_A2_Vel.Enabled = true;
		    grp_A2_OB.Enabled = true;
		}
    }
}