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
        UInt32 g_hController = 0;   // �R���g���[���n���h��	
        UInt32 g_hDevice;			// �f�o�C�X�n���h��

        public Form1()
        {
            InitializeComponent();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////
        //    btn_PosingStart_Click							
        //        �ʒu���ߎ��s�菇							
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_PosingStart_Click(object sender, EventArgs e)
        {
            // ���[�V����API�ϐ���`
            CMotionAPI.COM_DEVICE       ComDevice;                                  // ymcOpenController�ݒ�\����
            UInt32[]                    hAxis = new UInt32[3];                      // ���n���h���i3�����j
            CMotionAPI.MOTION_DATA[]    MotionData = new CMotionAPI.MOTION_DATA[3]; // MOTION_DATA�\���́i3�����j
            CMotionAPI.POSITION_DATA[]  Pos = new CMotionAPI.POSITION_DATA[3];      // POSITION_DATA�\���́i3�����j
            UInt16[]                    WaitForCompletion = new UInt16[3];          // ���������i�[�ϐ��i3�����j
            UInt32                      rc;                                         // ���[�V����API�߂�l
            Int16                       i;                                          // �����C���f�b�N�X
            String                      AxisName;                                   // ������
            Int32[]                     VelData = new Int32[3];                     // ���x�i�[�p�ϐ��i3�����j
            Int32[]                     PosData = new Int32[3];                     // �ڕW�ʒu�i�p�[�ϐ��i3�����j
            Int32[]                     AccData = new Int32[3];                     // �����x�i�[�p�ϐ��i3�����j
            Int32[]                     DecData = new Int32[3];                     // �����x�i�[�p�ϐ��i3�����j
          
            //============================================================================ �������e��
            // �R���g���[���Ƃ̒ʐM���m�����܂��B
            // �X���b�h���ɃR�[������K�v������܂��B
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
            // �R���g���[�����ێ����Ă��鎲�n���h�����������܂��B
            //============================================================================
            rc = CMotionAPI.ymcClearAllAxes();
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ClearAllAxes \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;        
            }
            //============================================================================ �������e��
            // ���n���h���쐬���܂��B
            // �擾�������n���h���́A�v���Z�X�ŃO���[�o���ɂ��邱�Ƃ��ł��܂��B
            // �ȉ��́A��ʂ̐ݒ�ڑ�������ymcDeclareAxis���R�[�����A���n���h�����쐬���܂��B
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
            //============================================================================ �������e��
            // ymcDeclareAxis�Ŏ擾�����A���n���h�����g�p���f�o�C�X�n���h�����쐬���܂��B
            // �ȉ��́A�ڑ�������1�f�o�C�X�Ƃ��Đݒ肵�Ă��܂��B
            // �f�o�C�X�n���h���́A�X���b�h���ɕK�v�ɂȂ�܂��B
            // ���ׁ̈A�����ō쐬�����f�o�C�X�n���h���́A�ʃX���b�h�Ŏg�p���邱�Ƃ͂ł��܂���B
            //============================================================================
            rc = CMotionAPI.ymcDeclareDevice( (UInt16)spn_Axis.Value, hAxis, ref g_hDevice);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcDeclareDevice \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            //============================================================================ �������e��
            // �T�[�{ON�����s���܂��B							
            // �쐬�����f�o�C�X�n���h�����g�p���T�[�{ON���Ă��܂��B
            // �ݒ�ڑ������S�ăT�[�{ON���܂��B
            //============================================================================
            rc = CMotionAPI.ymcServoControl(g_hDevice, (UInt16)CMotionAPI.ApiDefs.SERVO_ON, 5000);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcServoControl ON \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            //============================================================================
            // �ʒu���߂̃p������^��ݒ肵�܂��B
            // ��ʂŐݒ肵���A���x�A�ڕW�ʒu�A�����x�A�����x���o�b�t�@�ɃR�s�[���Ă��܂��B
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
            // ��ʂ̐ڑ����������[�v���A�������K�v�ȃp�����[�^��ݒ肵�܂��B
            // �f�[�^�ݒ��A�ʒu���߁iymcMoveDriverPositioning�j���J�n���܂��B
            //============================================================================
            for( i = 0; i < (short)spn_Axis.Value; i++)
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
            		
                //�@�ʒu�f�[�^�ݒ�
                Pos[i].DataType                 = (UInt16)CMotionAPI.ApiDefs.DATATYPE_IMMEDIATE;
                Pos[i].PositionData             = PosData[i];
            		
                // �����������uCOMMAND_STARTED�i�w�ߊJ�n�j�v�ɂ��邱�Ƃɂ��A
                // �ʒu���ߎw�ߌシ���ɃA�v���P�[�V�����ɐ��䂪�߂�܂��B
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
        //        ����~�菇				
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_PosingStop_Click(object sender, EventArgs e)
        {
            // ���[�V����API�ϐ���`
            CMotionAPI.MOTION_DATA[]    MotionData = new CMotionAPI.MOTION_DATA[3]; // MOTION_DATA�\���́i3�����j
            UInt16[]                    WaitForCompletion = new UInt16[3];          // ���������i�[�ϐ��i3�����j
            UInt32                      rc;                                         // ���[�V����API�߂�l
            Int16                       i;                                          // �����C���f�b�N�X
            Int32[]                     DecData = new Int32[3];                     // ���x�i�[�p�ϐ��i3�����j
        					
            //============================================================================
            // ��ʂŐݒ肵�������x�݂̂��o�b�t�@�Ɋi�[���܂��B
            //============================================================================
            i = 0;
            DecData[i] = Int32.Parse(txt_A1_Dec.Text);
            i = 1;
            DecData[i] = Int32.Parse(txt_A2_Dec.Text);
            i = 2;
            DecData[i] = Int32.Parse(txt_A3_Dec.Text);
        		
            //============================================================================ �������e��
            // ��ʂ̐ڑ����������[�v���A�������K�v�ȃp�����[�^��ݒ肵�܂��B
            // �f�[�^�ݒ��A����~�iymcStopMotion�j�����s���܂��B
            //============================================================================
            for( i = 0; i < (short)spn_Axis.Value; i++)
            {
                /* Not Use MotionData[i].CoordinateSystem    = NULL; */
                /* Not Use MotionData[i].MoveType            = NULL; */
                /* Not Use MotionData[i].VelocityType        = NULL; */
                MotionData[i].AccDecType    = (Int16)CMotionAPI.ApiDefs.ATYPE_TIME;    // ���萔�w��[ms]
                /* Not Use MotionData[i].FilterType          = NULL; */
                MotionData[i].DataType      = 0;             // �S�p�����[�^���ڎw��
                /* Not Use MotionData[i].MaxVelocity         = NULL; */
                /* Not Use MotionData[i].Acceleration        = NULL; */
                MotionData[i].Deceleration  = DecData[i];    // �������萔[ms]
                /* Not Use MotionData[i].FilterTime          = NULL; */
                /* Not Use MotionData[i].Velocity            = NULL; */
                /* Not Use MotionData[i].ApproachVelocity    = NULL; */
                /* Not Use MotionData[i].CreepVelocity       = NULL; */
        				
                // �����������uPOSITIONING_COMPLETED�i�ʒu���ߊ����j�v�ɂ��邱�Ƃɂ��A
                // ����~�����܂ŁA�A�v���P�[�V�����ɂ͐��䂪���ǂ�܂���B
                WaitForCompletion[i]        = (UInt16)CMotionAPI.ApiDefs.POSITIONING_COMPLETED;
            }
            rc = CMotionAPI.ymcStopMotion( g_hDevice, MotionData, "Stop", WaitForCompletion, 0 );
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcStopMotion \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }		
            //============================================================================ �������e��
            // �T�[�{OFF�����s���܂��B							
            // �ʒu���ߊJ�n���ɍ쐬�����f�o�C�X�n���h�����g�p���T�[�{OFF���Ă��܂��B
            // �ݒ�ڑ������S�ăT�[�{OFF���܂��B
            //============================================================================
            rc = CMotionAPI.ymcServoControl(g_hDevice, (UInt16)CMotionAPI.ApiDefs.SERVO_OFF, 5000);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcServoControl OFF \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            //============================================================================ �������e��
            // ���̃X���b�h�ō쐬�����f�o�C�X�n���h�����������܂��B
            //============================================================================
            rc = CMotionAPI.ymcClearDevice( g_hDevice );
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcClearDevice \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            //============================================================================ �������e��
            // ���[�V����API�Ƃ̒ʐM��ؒf���܂��B
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
        //        �A�v���P�[�V�����I��																
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_Quit_Click(object sender, EventArgs e)
        {
			Application.Exit();
        }
    }
}