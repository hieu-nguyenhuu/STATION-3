using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;
using MotionAPI;

namespace Interpolate
{
    public partial class Form1 : Form
    {
        UInt32   g_hController;             // �R���g���[���n���h��	
        UInt32   g_hDevice;                 // �f�o�C�X�n���h��
        UInt32[] g_hAxis = new UInt32[3];   // ���n���h��

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
            CMotionAPI.COM_DEVICE   ComDevice;  // ymcOpenController�ݒ�\����
            UInt32                  rc;         // ���[�V����API�߂�l

            //============================================================================ �������e��
            // ymcOpenController�̃p�����[�^��ݒ肵�܂��B
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
            //============================================================================
            rc = CMotionAPI.ymcSetAPITimeoutValue(30000);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error SetAPITimeoutValue \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
        }

        //////////////////////////////////////////////////////////////////////////////
        //	btn_GetAxisHandle_Click
        //		An axial handle is acquired.
        //////////////////////////////////////////////////////////////////////////////
        private void btn_GetAxisHandle_Click(object sender, EventArgs e)
        {
            UInt32  rc;         // ���[�V����API�߂�l
            Int16   i;          // �����C���f�b�N�X
            String  AxisName;   // ������

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
                rc = CMotionAPI.ymcDeclareAxis(1, 0, 3, (UInt16)(i + 1), (UInt16)(i + 1), (UInt16)CMotionAPI.ApiDefs.REAL_AXIS, AxisName, ref g_hAxis[i]); 
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
            rc = CMotionAPI.ymcDeclareDevice((UInt16)spn_Axis.Value, g_hAxis, ref g_hDevice);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcDeclareDevice \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
        }

        //////////////////////////////////////////////////////////////////////////////
        //	btn_ServoON_Click
        //		It ServoON.
        //////////////////////////////////////////////////////////////////////////////
        private void btn_ServoON_Click(object sender, EventArgs e)
        {
            UInt32    rc;    // ���[�V����API�߂�l
        			
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
        }

        //////////////////////////////////////////////////////////////////////////////
        //	btn_ServoOFF_Click
        //		It ServoOFF.
        //////////////////////////////////////////////////////////////////////////////
        private void btn_ServoOFF_Click(object sender, EventArgs e)
        {
            UInt32    rc;    // ���[�V����API�߂�l
        				
            //============================================================================ �������e��
            // �T�[�{OFF�����s���܂��B							
            // �ݒ�ڑ������S�ăT�[�{OFF���܂��B
            //============================================================================
            rc = CMotionAPI.ymcServoControl(g_hDevice, (UInt16)CMotionAPI.ApiDefs.SERVO_OFF, 5000);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcServoControl OFF \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
        }

        //////////////////////////////////////////////////////////////////////////////
        //	btn_InterpolateStart_Click
        //		Interpolate Start
        //////////////////////////////////////////////////////////////////////////////
        private void btn_InterpolateStart_Click(object sender, EventArgs e)
        {
            Thread oThread = new Thread(new ThreadStart(this.InterpolateProc));
            oThread.Start();        
        }

        //////////////////////////////////////////////////////////////////////////////
        //	Thraed Proc
        //		Interpolate Proc
        //////////////////////////////////////////////////////////////////////////////
        private void InterpolateProc()
        {	
            CMotionAPI.COM_DEVICE       ComDevice;                              // ymcOpenController�ݒ�\����
            UInt32                      hController;                            // �R���g���[���n���h��
            UInt32                      hDevice;                                // �f�o�C�X�n���h��
            CMotionAPI.MOTION_DATA      MotionData;                             // MOTION_DATA�\����
            CMotionAPI.POSITION_DATA[]  Pos = new CMotionAPI.POSITION_DATA[3];  // POSITION_DATA�\����
            UInt16                      WaitForCompletion;                      // ���������i�[�ϐ�
            UInt32                      rc;                                     // ���[�V����API�߂�l
            Int16                       i;                                      // �����C���f�b�N�X
            Int32[]                     PosData = new Int32[3];                 // �ڕW�ʒu�i�[�ϐ��i3�����j

            //============================================================================ �������e��
            // �R���g���[���Ƃ̒ʐM���m�����܂��B
            // �X���b�h���ɃR�[������K�v������܂��B
            //============================================================================
            hController = new UInt32();
            ComDevice.ComDeviceType = (UInt16)CMotionAPI.ApiDefs.COMDEVICETYPE_PCI_MODE;
            ComDevice.PortNumber    = 1;
            ComDevice.CpuNumber     = (UInt16)spn_CpuNo.Value;	//cpuno;
            ComDevice.NetworkNumber = 0;
            ComDevice.StationNumber = 0;
            ComDevice.UnitNumber    = 0;
            ComDevice.IPAddress     = "";
            ComDevice.Timeout       = 10000;

            rc = CMotionAPI.ymcOpenController(ref ComDevice, ref hController);
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
            // �O���[�o����`���Ă��鎲�n���h�����g�p���f�o�C�X�n���h�����쐬���܂��B
            // �ȉ��́A�ڑ�������1�f�o�C�X�Ƃ��Đݒ肵�Ă��܂��B
            // �f�o�C�X�n���h���́A�X���b�h���ɕK�v�ɂȂ�܂��B
            //============================================================================
            hDevice = new UInt32();
            rc = CMotionAPI.ymcDeclareDevice((UInt16)spn_Axis.Value, g_hAxis, ref hDevice);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcDeclareDevice \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }
            //============================================================================ �������e��
            // ��ԃp������^��ݒ肵�܂��B
            // ��ʂŐݒ肵���A���x�A�ڕW�ʒu�A�����x�A�����x��ݒ肵�Ă��܂��B
            //============================================================================
            MotionData = new CMotionAPI.MOTION_DATA();
            MotionData.CoordinateSystem    = (Int16)CMotionAPI.ApiDefs.WORK_SYSTEM;     // ���[�N���W�n
            MotionData.MoveType            = (Int16)CMotionAPI.ApiDefs.MTYPE_RELATIVE;  // �����l�w��
            MotionData.VelocityType        = (Int16)CMotionAPI.ApiDefs.VTYPE_UNIT_PAR;  // ���x[�w�ߒP��/sec]
            MotionData.AccDecType          = (Int16)CMotionAPI.ApiDefs.ATYPE_TIME;      // ���萔�w��[ms]
            MotionData.FilterType          = (Int16)CMotionAPI.ApiDefs.FTYPE_S_CURVE;   // �ړ����σt�B���^�i�Ȉ�S���j
            MotionData.DataType            = 0;                                         // �S�p�����[�^���ڎw��
	        MotionData.MaxVelocity         = Int32.Parse( txt_MaxVel.Text );		    // ����ō����x[�w�ߒP��/sec]
            MotionData.Acceleration        = Int32.Parse( txt_Acc.Text );			    // �������萔[ms] 
            MotionData.Deceleration        = Int32.Parse( txt_Dec.Text );			    // �������萔[ms]
            MotionData.FilterTime          = 10;                                        // �t�B���^����[0.1ms]
            MotionData.Velocity            = Int32.Parse(txt_Vel.Text);			        // ���x[�w�ߒP��/sec]
            /* Not Use MotionData.ApproachVelocity = NULL; */
            /* Not Use MotionData.CreepVelocity    = NULL; */
          		
            i = 0;
            PosData[i] = Int32.Parse( txt_A1_Pos.Text);
            i = 1;
            PosData[i] = Int32.Parse( txt_A2_Pos.Text);
            i = 2;
            PosData[i] = Int32.Parse( txt_A3_Pos.Text);

            // �ʒu�f�[�^�ݒ�
            for( i = 0; i < (Int16)spn_Axis.Value; i++)
            {
                Pos[i].DataType = (Int16)CMotionAPI.ApiDefs.DATATYPE_IMMEDIATE;
                Pos[i].PositionData	= PosData[i];
            }
            // ��������
            WaitForCompletion = (UInt16)CMotionAPI.ApiDefs.POSITIONING_COMPLETED;

            rc = CMotionAPI.ymcMoveLinear(hDevice, ref MotionData, Pos, 0, "Start", WaitForCompletion, 0);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcMoveLinear \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }

            //============================================================================ �������e��
            // ���̃X���b�h�ō쐬�����f�o�C�X�n���h�����������܂��B
            //============================================================================
            rc = CMotionAPI.ymcClearDevice(hDevice);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcClearDevice \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }

            //============================================================================ �������e��
            // ���[�V����API�Ƃ̒ʐM��ؒf���܂��B
            //============================================================================
            rc = CMotionAPI.ymcCloseController(hController);
            if(rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcCloseController \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }	
        }

        //////////////////////////////////////////////////////////////////////////////
        //	btn_InterpolateStop_Click	
        //		����~����
        //////////////////////////////////////////////////////////////////////////////
        private void btn_InterpolateStop_Click(object sender, EventArgs e)
        {
            CMotionAPI.MOTION_DATA[]    MotionData = new CMotionAPI.MOTION_DATA[3]; // MOTION_DATA�\���́i3�����j
            UInt16[]                    WaitForCompletion = new UInt16[3];          // ���������i�[�ϐ��i3�����j
            UInt32                      rc;                                         // ���[�V����API�߂�l
            Int16                       i;                                          // �����C���f�b�N�X
        			
            //============================================================================ �������e��
            // ��ʂ̐ڑ����������[�v���A�������K�v�ȃp�����[�^��ݒ肵�܂��B
            // �f�[�^�ݒ��A����~�iymcStopMotion�j�����s���܂��B
            //============================================================================
            for( i = 0; i < (Int16)spn_Axis.Value; i++)
            {
                /* Not Use MotionData[i].CoordinateSystem = NULL; */
                /* Not Use MotionData[i].MoveType         = NULL; */ 
                /* Not Use MotionData[i].VelocityType     = NULL; */
                MotionData[i].AccDecType    = (Int16)CMotionAPI.ApiDefs.ATYPE_TIME; // ���萔�w��[ms]
                /* Not Use MotionData[i].FilterType       = NULL; */
                MotionData[i].DataType      = 0;                            // �S�p�����[�^���ڎw��
                MotionData[i].MaxVelocity   = Int32.Parse(txt_MaxVel.Text); // ����ō����x[�w�ߒP��/sec]
                /* Not Use MotionData[i].Acceleration     = NULL; */
                MotionData[i].Deceleration  = Int32.Parse(txt_Dec.Text);    // �������萔[ms]
                /* Not Use MotionData[i].FilterTime       = NULL; */
                /* Not Use MotionData[i].Velocity         = NULL; */
                /* Not Use MotionData[i].ApproachVelocity = NULL; */
                /* Not Use MotionData[i].CreepVelocity    = NULL; */

                WaitForCompletion[i]        = (UInt16)CMotionAPI.ApiDefs.POSITIONING_COMPLETED;
            }

            rc = CMotionAPI.ymcStopMotion(g_hDevice, MotionData, "Stop", WaitForCompletion, 0);
            if (rc != CMotionAPI.MP_SUCCESS)
            {
                MessageBox.Show(String.Format("Error ymcStopMotion \nErrorCode [ 0x{0} ]",rc.ToString("X")));
                return;
            }			 
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        //    btn_MotionAPI_Close
        //        ���[�V����API�I������
        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_Quit_Click(object sender, EventArgs e)
        {
            UInt32    rc;    // ���[�V����API�߂�l

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