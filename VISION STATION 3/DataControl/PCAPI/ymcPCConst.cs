//===========================================================
//
// ymcPCAPI.Dll �p�@�萔��`���W���[�� ��ymcPCConst.cs��
//
// �o�[�W�����i���t�j�F Ver.1.0.0.0 (12/02/27)
//
// ���l              �F	C#�p
//
//===========================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace MotionAPI
{
    public partial class CMotionAPI
    {
        //======================================================
        //                                                      
        //  ���[�V����API ��`                                 
        //                                                      
        //======================================================
        public enum ApiDefs : ushort
        {
            REAL_AXIS = 1,                      // ���T�[�{��       			
            VIRTUAL_AXIS = 2,                   // ���z�T�[�{��					
            EXTERNAL_ENCODER = 3,               // �O���G���R�[�_				

            // SpecifyType ���w����@
            PHYSICALAXIS = 1,                   // �������w��                   
            AXISNAME = 2,                       // �����̎w��                   
            LOGICALAXIS = 3,                    // �_�����w��                   

            // ���_���A����
            HMETHOD_DEC1_C = 0,                 //  0: DEC1+C���p���X����       
            HMETHOD_ZERO = 1,                   //  1: ZERO�M������             
            HMETHOD_DEC1_ZERO = 2,              //  2: DEC1+ZERO�M������        
            HMETHOD_C = 3,                      //  3: C���p���X����            
            HMETHOD_DEC2_ZERO = 4,              //  4: DEC2+ZERO�M������        
            HMETHOD_DEC1_L_ZERO = 5,            //  5: DEC1+LMT+ZERO�M������    
            HMETHOD_DEC2_C = 6,                 //  6: DEC2+C���p���X����       
            HMETHOD_DEC1_L_C = 7,               //  7: DEC1+LMT+C���p���X����   
            HMETHOD_C_ONLY = 11,                // 11: C Pulse Only				
            HMETHOD_POT_C = 12,                 // 12: POT & C Pulse			
            HMETHOD_POT_ONLY = 13,              // 13: POT Only					
            HMETHOD_HOMELS_C = 14,              // 14: Home LS C Pulse			
            HMETHOD_HOMELS_ONLY = 15,           // 15: Home LS Only				
            HMETHOD_NOT_C = 16,                 // 16: NOT & C Pulse			
            HMETHOD_NOT_ONLY = 17,              // 17: NOT Only
            HMETHOD_INPUT_C = 18,               // 18: Input & C Pulse			
            HMETHOD_INPUT_ONLY = 19,            // 19: Input Only

            // ����
            DIRECTION_POSITIVE = 0,             // ������						
            DIRECTION_NEGATIVE = 1,             // �t����						

            // ���W�n�w��
            WORK_SYSTEM = 0,                    //  0: ���[�N���W�n Workpiece coordinate system
            MACHINE_SYSTEM = 1,                 //  1: �@�B���W�n   Machine coordinate system

            // ����^�C�v
            MTYPE_RELATIVE = 0,                 //  0: �����l�w��A������/��]������
            MTYPE_ABSOLUTE = 1,                 //  1: ��Έʒu�w��A�������p
            MTYPE_R_SHORTEST = 2,               //  2: ��Έʒu�w��A��]���p�i�߂������ɉ�]�j
            MTYPE_R_POSITIVE = 3,               //  3: ��Έʒu�w��A��]���p�i���]�j
            MTYPE_R_NEGATIVE = 4,               //  4: ��Έʒu�w��A��]���p�i�t�]�j

            // �f�[�^�^�C�v
            DTYPE_IMMEDIATE = 0,                // ���ڎw��
            DTYPE_INDIRECT = 1,                 // �Ԑڎw��
            DTYPE_MAX_VELOCITY = 0x1,           // bit0: MaxVelocity�ɂ��Ă̎w��
            DTYPE_ACCELERATION = 0x2,           // bit1: Acceleration�ɂ��Ă̎w��
            DTYPE_DECELERATION = 0x4,           // bit2: Deceleration�ɂ��Ă̎w��
            DTYPE_FILTER_TIME = 0x8,            // bit3: FilterTime�ɂ��Ă̎w��
            DTYPE_VELOCITY = 0x10,              // bit4: Velocity�ɂ��Ă̎w��
            DTYPE_APPROCH = 0x20,               // bit5: ApproachVelocity�ɂ��Ă̎w��
            DTYPE_CREEP = 0x40,                 // bit6: CreepVelocity�ɂ��Ă̎w��

            // ���葬�x�^�C�v
            VTYPE_UNIT_PAR = 0,                 // ���x[�w�ߒP��/sec]
            VTYPE_PERCENT = 1,                  // ��i���x�́��w��

            // �������^�C�v
            ATYPE_UNIT_PAR = 0,                 // �����x[�w�ߒP��/sec^2]
            ATYPE_TIME = 1,                     // ���萔[ms]
            ATYPE_KEEP = 2,                     // ���݂̐ݒ��ێ�

            // �t�B���^�^�C�v
            FTYPE_S_CURVE = 0,                  //  0: �ړ����σt�B���^�i�Ȉ�S���j
            FTYPE_EXP = 1,                      //  1: �w���t�B���^
            FTYPE_NOTIONG = 2,                  //  2: �t�B���^�Ȃ�
            FTYPE_KEEP = 3,                     //  3: ���݂̐ݒ��ێ�

            // WaitForCompletion �萔��`
            DISTRIBUTION_COMPLETED = 0,         // �����o������
            POSITIONING_COMPLETED = 1,          // �ʒu���ߊ���
            COMMAND_STARTED = 2,                // �w�ߊ���
            LATCH_COMMAND_STARTED = 0,          // ���b�`�w�ߊJ�n
            LATCH_COMPLETED = 1,                // ���b�`����

            // SystemOption �萔��`
            OP_BIT_ALARM_CONTINUE = 0x1,        // bit0: �A���[�����A����Ȏ��̉^�]���p��

            // ChangeDynamics�ύX�̑Ώہi1:�ύX���� / 0:�ύX���Ȃ��j
            SUBJECT_ACC = 0x1,                  // bit0: Acceleration
            SUBJECT_DEC = 0x2,                  // bit1: Deceleration
            SUBJECT_POS = 0x8,                  // bit3: Position
            SUBJECT_VEL = 0x10,                  // bit4: Velocity

            // ServoControlType
            SERVO_OFF = 0x0,                    // �T�[�{OFF
            SERVO_ON = 0x1,                     // �T�[�{ON

            // �f�o�C�X�^�C�v
            DEVICETYPE_IO = 1,                  // I/O
            DEVICETYPE_DIRECTIO = 2,            // �_�C���N�gI/O
            DEVICETYPE_GLOBALDATA = 3,          // �O���[�o���f�[�^
            DEVICETYPE_REGISTER = 4,            // ���W�X�^

            // �P�ʃf�[�^�T�C�Y(�r�b�g��)
            DATAUNITSIZE_BIT = 1,               // 1 bit
            DATAUNITSIZE_BYTE = 8,              // BYTE = 8 bits
            DATAUNITSIZE_WORD = 16,             // WORD = 16 bits
            DATAUNITSIZE_LONG = 32,             // LONG = 32 bits
            DATAUNITSIZE_FLOAT = 32,            // FLOAT= 32 bits
            DATAUNITSIZE_DOUBLE = 64,           // DOUBLE= 64 bits

            // ComDevice�^�C�v
            RS232C_MODE = 1,                    // RS232C
            MODEM_MODE = 2,                     // ���f��
            ETHERNET_MODE = 3,                  // Ethernet
            PCI_MODE = 4,                       // PCI�o�X(910 or 2100)
            CONTROLLER_MODE = 5,                // �R���g���[������

            //�A���[��
            MAX_CURRENT_ALARM = 32,             // ���Ɏ擾�ł���ő�װя��
            MAX_DEVICE_AXIS = 32,               // ���ɒ�`�ł���f�o�C�X�̍ő厲��
            MAX_REGISTER_BLOCK = 499,           // ���ɑ���ł��郌�W�X�^�̍ő�u���b�N��

            // Gear
            MASTER_AXIS_FEEDBACK = 0,           // �t�B�[�h�o�b�N�l
            MASTER_AXIS_COMMAND = 1,            // �w�ߒl

            // Gear �����^�C�v
            SYNCH_DISTANCE = 0,                 // ��������
            SYNCH_TIME = 1,                     // ���ԓ���

            // Gear���߂̑���
            GEAR_ENGAGE_COMPLETED = 0,          // GEAR����J�n�iEngage�����j
            GEAR_COMMAND_STARTED = 1,           // �w�ߊJ�n

            // Gear�X�e�[�^�X�̑���
            GEAR_NOT_ENGAGED = 0,               // GEAR��~��
            GEAR_WAITING_ENGAGED = 1,           // GEAR����҂�
            GEAR_ENGAGED = 2,                   // GEAR���쒆
            GEAR_WAITING_DISENGAGED = 4,        // GEAR��~�҂�


            // CAM���߂̑���
            CAM_ENGAGE_COMPLETED = 0,           // CAM����J�n
            CAM_SHIFT_COMPLETED = 0,            // CAM�ʑ��␳����

            CAM_DISENGAGE_COMPLETED = 0,        // CAM�����~
            CAM_COMMAND_STARTED = 1,            // �w�ߊJ�n

            // Cam�X�e�[�^�X�̑���
            CAM_NOT_ENGAGED = 0,                // CAM��~��
            CAM_WAITING_ENGAGED = 1,            // CAM����҂�
            CAM_ENGAGED = 2,                    // CAM���쒆
            CAM_WAITING_DISENGAGED = 4,         // CAM��~�҂�

            // �V�t�g�^�C�v
            SHIFT_TIME = 0,                     // ���ԂŃV�t�g
            SHIFT_POSITION = 1,                 // �ʒu�ŃV�t�g

            // POSITION���߂̑���
            POSITION_OFFSET_COMPLETED = 0,      // �ʒu�␳����
            POSITION_OFFSET_COMMAND_STARTED = 1,// �w�ߊJ�n

            // �e�[�u���^�C�v
            CAM_TABLE = 2,                      // CAM�e�[�u���̃t�@�C����
            INTERPOLATION_TABLE = 3,            // ��ԃe�[�u���̃t�@�C����
            REGISTERHANDLE = 4,                 // ���W�X�^�n���h��
            USER_FUNCTION = 5,                  // ���[�U�[�֐�
            IK_FUNCTION = 6,                    // IK�֐�

            // ���[�V�����p�����[�^�^�C�v
            SETTING_PARAMETER = 0,              // �ݒ�p�����[�^
            MONITOR_PARAMETER = 1,              // ���j�^�p�����[�^

            // �ő厲��
            MAX_DEVICE_AXIS_NUM = 16,           // �ő�f�o�C�X����

            // �~�ʁE�w���J����Ԃ̉~�ʎ��
            LESS_180DEGREE = 0x1,               // 
            GREATER_180DEGREE = 0x2,            // 

            // ���W�n
            COORDINATE_SYSTEM_DEFAULT = 0,      // 
            COORDINATE_SYSTEM_MACHINE = 1,      // �@�B���W�n
            // ���[�h
            MODE_INCREMENTAL = 0,               // INC
            MODE_ABSOLUTE = 1,                  // ABS

            // ���葬�x�^�C�v
            F_TYPE_COMMAND_UNIT = 0,            // �w�ߒP��/min
            F_TYPE_PARCENT = 1,                 // ���w��

            // �������x�^�C�v
            ACCEL_TYPE_ACCERALATION = 0,        // �����x
            ACCEL_TYPE_TIME_CONSTANT = 1,       // ���萔
            ACCEL_TYPE_NO_SPECIFY = 2,          // �w��Ȃ�

            // UnitType��`
            UNITTYPE_PULSE = 0,                 // �p���X
            UNITTYPE_MM = 1,                    // mm
            UNITTYPE_INCH = 2,                  // inch
            UNITTYPE_DEGREE = 3,                // degree

            // �f�[�^�^�C�v
            DATATYPE_IMMEDIATE = 0,             // ���ڎw��
            DATATYPE_INDIRECT = 1,              // �Ԑڎw��

            // ComDevice���
            COMDEVICETYPE_RS232C_MODE = 1,      // RS232C
            COMDEVICETYPE_MODEM_MODE = 2,       // ���f��
            COMDEVICETYPE_ETHERNET_MODE = 3,    // Ethernet
            COMDEVICETYPE_PCI_MODE = 4,         // PCI�o�X(910 or 2100)
            COMDEVICETYPE_PCIe_MODE = 6,        // PCIExpress�o�X(3100)
            COMDEVICETYPE_CONTROLLER_MODE = 5	// �R���g���[������
        }

        //======================================================
        //                                                      
        //  ���[�V�����ݒ� ��`                                 
        //                                                      
        //======================================================
        public enum ApiDefs_SetPrm
        {
            SER_RUNMOD = 1,                     // OWXX00 : ���샂�[�h�ݒ�
            SER_SVRUNCMD = 2,                   // OWXX01 : �T�[�{�h���C�u�^�]�w�ߐݒ�
            SER_TLIMP = 3,                      // OWXX02 : TORQUE LIMIT PLUS SIDE
            SER_TLIMN = 4,                      // OWXX03 : TORQUE LIMIT MINUS SIDE
            SER_NLIMP = 5,                      // OWXX04 : SPEED LIMIT PLUS SIDE
            SER_NLIMN = 6,                      // OWXX05 : SPEED LIMIT MINUS SIDE
            SER_ABSOFF = 7,                     // OLXX06 : ABS. ORG. OFFSET
            SER_COINDAT = 9,                    // OLXX08 : COIN DATA               
            SER_NAPR = 11,                      // OWXX0A : APROACH SPEED           
            SER_NCLP = 12,                      // OWXX0B : CLEEP SPEED             
            SER_NACC = 13,                      // OWXX0C : ACCELARATING TIME       
            SER_NDCC = 14,                      // OWXX0D : DECREACING TIME         
            SER_PEXT = 15,                      // OWXX0E : POSITION EXTENT         
            SER_EOV = 16,                       // OWXX0F : DEVIATION OVER RANGE    
            SER_KP = 17,                        // OWXX10 : SOFT FEED BACK RATE     
            SER_KF = 18,                        // OWXX11 : SOFT FEED FOWARD RATE   
            SER_XREF = 19,                      // OLXX12 : ABS. POSITION REF       
            SER_NNUM = 21,                      // OWXX14 : AVERAGING TIMES         
            SER_NREF = 22,                      // OWXX15 : SPEED REFERENCE:���x�w�� 
            SER_PHBIAS = 23,                    // OLXX16 : PHASE OFFSET            
            SER_NCOM = 25,                      // OWXX18 : SPEED BIAS REF          
            SER_PV = 26,                        // OWXX19 : PROPORTIONAL_GAIN       
            SER_TI = 27,                        // OWXX1A : TI                      
            SER_TREF = 28,                      // OWXX1B : TORQUE REFERNCE         
            SER_NLIM = 29,                      // OWXX1C : SPEED LIMIT             
            SER_KV = 30,                        // OWXX1D : VELOCITY_GAIN           
            SER_PULBIAS = 31,                   // OLXX1E : PULSE OFFSET            
            SER_MCMDCODE = 33,                  // OWXX20 : ���[�V�����R�}���h�R�[�h 
            SER_MCMDCTRL = 34,                  // OWXX21 : ���[�V�����R�}���h����t���O 
            SER_RV = 35,                        // OLXX22 : �����葬�x�@�@          
            SER_EXMDIST = 37,                   // OLXX24 : �O���ʒu���ߑ��s����    
            SER_STOPDIST = 39,                  // OLXX26 : ��~����        �@�@    
            SER_STEP = 41,                      // OLXX28 : �r�s�d�o�ړ���          
            SER_ZRNDIST = 43,                   // OLXX2A : ���_���A�ŏI���s����    
            SER_OV = 45,                        // OWXX2C : �I�[�o���C�h            
            SER_POSCTRL = 46,                   // OWXX2D : �ʒu�Ǘ�����t���O      
            SER_OFFSET = 47,                    // OLXX2E : ���[�N���W�n�I�t�Z�b�g  
            SER_POSMXTRN = 49,                  // OLXX30 : POSMAX�^�[�����v���Z�b�g�f�[�^ 
            SER_INPWIDTH = 51,                  // OWXX32 : ��Q�C���|�W�V������    
            SER_PSETWIDTH = 52,                 // OWXX33 : ���_�ʒu�o�͕�          
            SER_PSETTIME = 53,                  // OWXX34 : �ʒu���ߊ����`�F�b�N���� 
            SER_YENTCN = 54,                    // OWXX35 : YENET�T�[�{���[�U�萔NO  
            SER_CNDAT = 55,                     // OLXX36 : YENET�T�[�{���[�U�萔�ݒ�l 
            SER_EPOSL = 57,                     // OLXX38 : �d���f���̃G���R�[�_�ʒu�@���� 2W 
            SER_EPOSH = 59,                     // OLXX3A : �d���f���̃G���R�[�_�ʒu�@��� 2W 
            SER_APOSL = 61,                     // OLXX3C : �d���f����PULSE��Έʒu�@ ���� 2W
            SER_APOSH = 63                      // OLXX3E : �d���f����PULSE��Έʒu�@ ��� 2W
        }

        //======================================================
        //                                                      
        //  ���[�V�������j�^ ��`                               
        //                                                      
        //======================================================
        public enum ApiDefs_MonPrm
        {
            SER_RUNSTS = 0,                 	// IWxx00 : �^�]�X�e�[�^�X
            SER_ERNO = 1,                       // IWxx01 : �͈̓I�[�o�[�����p�����[�^No
            SER_WARNING = 2,                    // ILxx02 : ���[�j���O
            SER_ALARM = 4,                      // ILxx04 : �A���[��
            SER_MCMDRCODE = 8,                  // IWxx08 : ���[�V�����R�}���h���X�|���X�R�[�h
            SER_MCMDSTS = 9,                    // IWxx09 : ���[�V�����R�}���h�X�e�[�^�X
            SER_SUBCMD = 10,                    // IWxx0A : �T�u�R�}���h���X�|���X
            SER_SUBSTS = 11,                    // IWxx0B : �T�u�R�}���h�R�}���h�X�e�[�^�X
            SER_POSSTS = 12,                    // IWxx0C : �ʒu�Ǘ��X�e�[�^�X
            SER_TPOS = 14,                      // ILxx0E : �@�B���W�n�ڕW�ʒu(TPOS)
            SER_CPOS = 16,                      // ILxx10 : �@�B���W�n�ʒu�v�Z(CPOS)
            SER_MPOS = 18,                      // ILxx12 : �@�B���W�n�w�߈ʒu(MPOS)
            SER_DPOS = 20,                      // ILxx14 : 32bit���W�n�w�߈ʒu(DPOS)
            SER_APOS = 22,                      // ILxx16 : �@�B���W�n�t�B�[�h�o�b�N�ʒu(APOS)
            SER_LPOS = 24,                      // ILxx18 : �@�B���W�n���b�`�ʒu (LPOS)
            SER_PERR = 26,                      // ILxx1A : �ʒu�΍�
            SER_PDV = 28,                       // ILxx1C : �ڕW�ʒu�����l���j�^
            SER_PMAXTURN = 30,                  // ILxx1E : POSMAX�^�[����
            SER_SPDREF = 32,                    // ILxx20 : ���x�w�ߏo�͒l���j�^
            SER_XREFMON = 34,                   // ILxx22 : �ʒu�w�ߏo�̓��j�^
            SER_YIMON = 36,                     // IWxx24 : �ϕ��l�o�͒l���j�^
            SER_LAGMON = 38,                    // ILxx26 : �ꎟ�x�ꃂ�j�^
            SER_PIMON = 40,                     // ILxx28 : �ʒu���[�v�o�͒l���j�^
            SER_SVSTS = 44,                     // IWxx2C : �T�[�{�h���C�o�X�e�[�^�X�i�@��Ɉˑ��j
            SER_SVALARM = 45,                   // IWxx2D : �T�[�{�h���C�oALARM�R�[�h
            SER_SVIOMON = 46,                   // IWxx2E : �T�[�{�h���C�oI/O���j�^
            SER_MUSRMONSEL = 47,                // IWxx2F : �T�[�{�h���C�o���[�U���j�^���
            SER_USRMON2 = 48,                   // ILxx30 : �T�[�{�h���C�o���[�U���j�^2
            SER_USRMON3 = 50,                   // ILxx32 : �T�[�{�h���C�o���[�U���j�^3
            SER_USRMON4 = 52,                   // ILxx34 : �T�[�{�h���C�o���[�U���j�^4
            SER_MCNNO = 54,                     // IWxx36 : �T�[�{�h���C�o���[�U�萔NO
            SER_MSUBCNNO = 55,                  // IWxx37 : �⏕�T�[�{�h���C�o���[�U�萔NO
            SER_MCNDAT = 56,                    // ILxx38 : �T�[�{�h���C�o���[�U�萔�ǂݏo���f�[�^
            SER_MSUBCNDAT = 58,                 // ILxx3A : �⏕�T�[�{�h���C�o���[�U�萔�ǂݏo���f�[�^
            SER_SANS = 60,                      // IWxx3C : �V���A���R�}���h �A���T���j�^
            SER_MSADR = 61,                     // IWxx3D : �V���A���R�}���h �A�h���X���j�^
            SER_MSDAT = 62,                     // IWxx3E : �V���A���R�}���h �f�[�^���j�^
            SER_MOTERTYPE = 63,                 // IWxx3F : �V���A���R�}���h �f�[�^���j�^
            SER_FSPD = 64,                      // ILxx40 : �t�B�[�h�o�b�N���x �m�w�ߒP��/sec�n�A�m10^n �w�ߒP��/min�n�A�m0.01 ��]
            SER_TRQ = 66,                       // ILxx42 : �g���N�w�߃��j�^    [0.01 ��]  
            SER_ABSREV = 74,                    // ILxx4A : ��Έʒu�ݺ��ނ���M�����ݐω�]��
            SER_IPULSE = 76,                    // ILxx4C : �����C���N�������^���p���X���mpulse�n
            SER_FIXPRMMON = 86,                 // ILxx56 : �Œ�p�����[�^���j�^
            SER_DI = 88,                        // IWxx58 : �ėpDI���j�^
            SER_AI1 = 89,                       // IWxx59 : �ėpAI���j�^        �m0.001 V�n
            SER_AI2 = 90,                       // IWxx5A : �ėpAI���j�^        �m0.001 V�n
            SER_MEPOSML = 94,                   // ILxx5E : �d���f���̴ݺ��ވʒu����2word
            SER_MEPOSMH = 96,                   // ILxx60 : �d���f���̴ݺ��ވʒu���2word
            SER_MAPOSML = 98,                   // ILxx62 : �d���f����PLUSE��Έʒu����2word
            SER_MAPOSMH = 100,                  // ILxx64 : �d���f����PLUSE��Έʒu���2word
            SER_MONSTS = 102,                   // ILxx66 : ���j�^�f�[�^�X�e�[�^�X
            SER_MONDATA = 104                   // ILxx68 : �ǂݏo���f�[�^
        }
    }
}