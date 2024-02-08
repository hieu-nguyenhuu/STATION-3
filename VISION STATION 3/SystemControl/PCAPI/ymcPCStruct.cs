//===========================================================
//
// ymcPCAPI.Dll �p�@�\���̒�`���W���[�� ��ymcPCStruct.cs��
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

        // COM_DEVICE�\����
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct COM_DEVICE
        {
            public UInt16 		ComDeviceType;             	// �ʐM���
            public UInt16 		PortNumber;                	// �|�[�g�ԍ�
            public UInt16 		CpuNumber;                 	// CPU�ԍ�
            public UInt16 		NetworkNumber;				// �l�b�g���[�N�ԍ�
            public UInt16 		StationNumber;             	// �X�e�[�V�����ԍ�
            public UInt16 		UnitNumber;                	// Unit�ԍ�
            public string 		IPAddress;                 	// IP�A�h���X(Ethernet)
            public UInt32 		Timeout;                   	// �ʐM�^�C���A�E�g����
        };

        // IO�ް��\����
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct IO_DATA
        {
            public UInt16     	DeviceType;             	// IO, DirectIO, Variable, Timer, Motion�Ȃǃp�P�b�g�̃A�N�Z�X��ʂɂ�����            
            public UInt16     	DataUnitSize;           	// �P�ʃf�[�^�T�C�Y
            public UInt16     	RackNo;                 	// ���b�N�ԍ�(1,2,...)
            public UInt16     	SlotNo;                 	// �X���b�g�ԍ�(0,1,...)
            public UInt16     	SubslotNo;              	// �T�u�X���b�g�ԍ�(1,2,...)
            public UInt16     	StationNo;              	// �X�e�[�V�����ԍ�(1,2,...)
            public UInt32     	hData;                  	// �f�[�^�n���h��
            public UInt32     	DeviceWordOffset;           // IO,Variable  �I�t�Z�b�g�A�h���X�i���[�h�P�ʁj
            public UInt16     	DeviceBitOffset;          	// �r�b�g�I�t�Z�b�g
            public UInt16     	Reserve;                	// �\��
            public UInt32		DataUnitCount;          	// used for multiple bit quantities or multiple byte arrays, normally 1
        };

        // �|�W�V�����f�[�^�w��\����
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct POSITION_DATA
        {
	        public Int32 		DataType;                   // �f�[�^�^�C�v(0.immediate, 1.�Ԑڎw��)
	        public Int32 		PositionData;               // �ʒu�f�[�^�@�Ԑڎw��̏ꍇ��hGlobalData���i�[
		};
		
        // �M�A��ݒ�Ŏg�p����f�[�^�̍\����
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct GEAR_RATIO_DATA
        {
	        public UInt16    	Master;                     // Gear��(���q)�̎w��
	        public UInt16    	Slave;                      // Gear��(����)�̎w��
		}
		
        // Gear�Ŏg�p���铯���ʒu�f�[�^�̍\����
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct SYNC_DISTANCE
       	{
            public UInt16     	SyncType;                   // �����^�C�v
            public UInt16     	DataType;                   // �}�X�^���ړ������f�[�^�^�C�v
            public UInt32    	DistanceData;               // �}�X�^���ړ�����
		};
		
        // �ʑ��␳�łŎg�p����f�[�^�̍\����
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct POSITION_OFFSET_DATA
       	{
            public UInt32     	ShiftType;                  // ���x�p�^�[���̑I��(TRIANGLE,TRAPEZOIDE)
            public double   	Offset;                     // �ʒu�I�t�Z�b�g�l(UserUnit)
            public double   	Duration;                   // �ʒu�␳����or�ʒu�␳����
        };

        // ���ʃ��[�V�����f�[�^�w��\����
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct MOTION_DATA
       	{
            public Int16 		CoordinateSystem;           // ���W�n�w��
            public Int16 		MoveType;                   // ����^�C�v
            public Int16 		VelocityType;               // ���x�^�C�v
            public Int16 		AccDecType;                 // �����x�^�C�v
            public Int16 		FilterType;                 // �t�B���^�^�C�v
            public Int16 		DataType;                   // �f�[�^�^�C�v�i0:immediate/1:�Ԑڎw��j
            public Int32 		MaxVelocity;                // ����ō����x[�w�ߒP��/sec]
            public Int32 		Acceleration;               // �����x[�w�ߒP��/sec^2]�A�������萔[ms]
            public Int32 		Deceleration;               // �����x[�w�ߒP��/sec^2]�A�������萔[ms]
            public Int32 		FilterTime;                 // �t�B���^����[ms]
            public Int32 		Velocity;                   // ���葬�x[�w�ߒP��/sec]�AOffset���x
            public Int32 		ApproachVelocity;           // �A�v���[�`���x[�w�ߒP��/sec]
            public Int32 		CreepVelocity;              // �N���[�v���x[�w�ߒP��/sec]
        };

        // �J�����_�[�f�[�^�\����
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct CALENDAR_DATA
       	{
            public UInt16    	Year;                     	// �N
            public UInt16    	Month;                    	// ��
            public UInt16    	DayOfWeek;                	// �j��
            public UInt16    	Day;                    	// ��
            public UInt16    	Hour;                     	// ����
            public UInt16    	Minutes;                    // ��
            public UInt16    	Second;                    	// �b
            public UInt16    	Milliseconds;               // �~���b
        };

        // �A���[�����\����
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ALARM_INFO
       	{
		    public UInt32        ErrorCode;					// �G���[�R�[�h
		    public UInt32        ErrorLocation;             // �����ꏊ
		    public UInt32        DetectTask;                // ���o��
		    public UInt32        hDevice;                   // �f�o�C�X�n���h��
		    public UInt32        TaskID;                    // �^�X�NID
            [ MarshalAs(UnmanagedType.ByValTStr, SizeConst=8)]
		    public String        TaskName;                  // �^�X�N����
		    public UInt32        ObjectHandle;              // �I�u�W�F�N�g�n���h��
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=8)]
		    public String        ObjectName;                // �I�u�W�F�N�g����
            public CALENDAR_DATA Calendar;                  // �J�����_
		    public UInt32        hAxis;                     // AXIS�����
		    public UInt32        DetailError;               // �ڍ׃G���[(�C�ӂ̃G���[�R�[�h)
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=32)]
		    public String        Comment;                   // �R�����g
		};                                       

        // 2WORD�f�[�^�w��\����
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DWORD_DATA
       	{
            public Int32    	DataType;                   // �f�[�^�^�C�v(0.immediate, 1.�Ԑڎw��)
            public Int32    	Data;						// �f�[�^�@�Ԑڎw��̏ꍇ��hGlobalData���i�[
        };
        
        // ���W�X�^���\����
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct REGISTER_INFO
       	{
            public UInt32     	hRegisterData;              // ���W�X�^�n���h��
            public UInt32       RegisterDataNumber;         // ���W�X�^��
            public IntPtr    	pRegisterData;              // ���W�X�^�f�[�^�]�������[�N�ւ̃|�C���^
            public UInt32       ReadDataNumber;             // �Ǎ��݃��W�X�^��
        };

        // �g���Ń��W�X�^���\����
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct REGISTER_INFO_EX
        {
            public UInt64       hRegisterDataEx;            // �g���Ń��W�X�^�n���h��
            public UInt32       RegisterDataNumber;         // ���W�X�^��
            public IntPtr       pRegisterData;              // ���W�X�^�f�[�^�]�������[�N�ւ̃|�C���^
            public UInt32       ReadDataNumber;             // �Ǎ��݃��W�X�^��
        };

        // BUSIF�\����
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct BUSIF_INFO
       	{
            public UInt16     	InputDataMaxSize;        	// �ő���̓T�C�Y�ipublic UInt16)
            public UInt16     	InputDataAvailableSize;		// �L�����̓T�C�Y�ipublic UInt16)
            public UInt16     	OutputDataMaxSize;       	// �ő�o�̓T�C�Y�ipublic UInt16�j
            public UInt16     	OutputDataAvailableSize;	// �L���o�̓T�C�Y�ipublic UInt16�j
        };
    }
}