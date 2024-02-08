//===========================================================
//
// ymcPCAPI.Dll �p�@API�錾���W���[�� ��ymcPCFunction.cs��
//
// �o�[�W�����i���t�j�F Ver.1.0.0.1 (13/07/25)
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

#if WIN32
        const string DllName = "ymcPCAPI.dll";
#elif WIN64
        const string DllName = "ymcPCAPI_x64.dll";
#else
        
#endif

        /////////////////////////////////////////////////////////////
        // ymcPCAPI Declare List
        /////////////////////////////////////////////////////////////

        //***********************************************************
        // �����^�C�x���g  ���ʃ��[�V����API
        //***********************************************************
        //===========================================================
        // �f�o�C�X
        //===========================================================
        // �֐����F ymcClearAllAxes (�SAxis�n���h�������) 
        [DllImport(DllName)]
        public static extern UInt32 ymcClearAllAxes();

        // �֐����F ymcDeclareAxis (���n���h���̐錾)
        [DllImport(DllName)]
        public static extern UInt32 ymcDeclareAxis(
            UInt16 RackNo,
            UInt16 SlotNo,
            UInt16 SubslotNo,
            UInt16 AxisNo,
            UInt16 LogicalAxisNo,
            UInt16 AxisType,
            String pAxisName,
            ref UInt32 phAxis);

        // �֐����F ymcClearAxis (����`�̍폜)
        [DllImport(DllName)]
        public static extern UInt32 ymcClearAxis(
            UInt32 hAxis);

        // �֐����F ymcDeclareDevice (�f�o�C�X�̐錾)
        [DllImport(DllName)]
        public static extern UInt32 ymcDeclareDevice(
            UInt16 AxisNum,
            [In] UInt32[] pAxis,
            ref UInt32 pDevice);

        // �֐����F ymcClearDevice (�f�o�C�X�폜)
        [DllImport(DllName)]
        public static extern UInt32 ymcClearDevice(
            UInt32 hDevice);

        // �֐����F ymcGetAxisHandle (���n���h�����̎擾)
        [DllImport(DllName)]
        public static extern UInt32 ymcGetAxisHandle(
            UInt16 SpecifyType,
            UInt16 RackNo,
            UInt16 SlotNo,
            UInt16 SubslotNo,
            UInt16 AxisNo,
            UInt16 LogicalAxisNo,
            String pAxisName,
            ref UInt32 pAxis);

        //===========================================================
        // �P�ʕϊ��@�\
        //===========================================================
        // �֐����F ymcConvertFloat2Fix (���������_���Œ菬���_�ϊ�)
        [DllImport(DllName)]
        public static extern UInt32 ymcConvertFloat2Fix(
            UInt16 digit,
            Double FloatValue,
            ref Int32 pFixValue);

        // �֐����F ymcConvertFix2Float (�Œ菬���_�����������_�ϊ�)
        [DllImport(DllName)]
        public static extern UInt32 ymcConvertFix2Float(
            UInt16 digit,
            Int32 FixValue,
            ref Double pFloatValue);

        //===========================================================
        // �����
        //===========================================================
        // �֐����F ymcMoveTorque (�g���N�w�ߋ@�\)
        [DllImport(DllName)]
        public static extern UInt32 ymcMoveTorque(
            UInt32 hDevice,
            [In] POSITION_DATA[] pSpeedLimit,
            [In] POSITION_DATA[] pTorqueData,
            UInt32 hMoveIO,
            String pObjectName,
            UInt32 SystemOption);

        //===========================================================
        // �p�����[�^����
        //===========================================================
        // �֐����F ymcSetMotionParameterValue (���[�V�����p�����[�^�ݒ�)
        [DllImport(DllName)]
        public static extern UInt32 ymcSetMotionParameterValue(
            UInt32 hAxis,
            UInt16 ParameterType,
            UInt32 ParameterOffset,
            UInt32 Value);

        // �֐����F ymcGetMotionParameterValue (���[�V�����p�����[�^�擾)
        [DllImport(DllName)]
        public static extern UInt32 ymcGetMotionParameterValue(
            UInt32 hAxis,
            UInt16 ParameterType,
            UInt32 ParameterOffset,
            ref UInt32 pStoredValue);

        // �֐����F ymcDefinePosition (���݈ʒu�ݒ�)
        [DllImport(DllName)]
        public static extern UInt32 ymcDefinePosition(
            UInt32 hDevice,
            [In] POSITION_DATA[] pPos);

        //***********************************************************
        // �������s�^���[�V����API
        //***********************************************************
        //===========================================================
        // �ʒu���ߋ@�\
        //===========================================================
        // �֐����F ymcMovePositioning (�ʒu���߁F�����^)
        [DllImport(DllName)]
        public static extern UInt32 ymcMovePositioning(
            UInt32 hDevice,
            [In] MOTION_DATA[] pMotionData,
            [In] POSITION_DATA[] pPos,
            UInt32 hMoveIO,
            String pObjectName,
            UInt16 WaitForCompletion,
            UInt32 SystemOption);

        // �֐����F ymcMoveExternalPositioning (�O���ʒu����)
        [DllImport(DllName)]
        public static extern UInt32 ymcMoveExternalPositioning(
            UInt32 hDevice,
            [In] MOTION_DATA[] pMotionData,
            [In] POSITION_DATA[] pPositionData,
            [In] POSITION_DATA[] pMaxLatchPos,
            [In] POSITION_DATA[] pMinLatchPos,
            [In] POSITION_DATA[] pDistance,
            UInt32 hMoveIO,
            String pObjectName,
            [In] UInt16[] pWaitForCompletion,
            UInt32 SystemOption);

        // �֐����F ymcMoveIntimePositioning (���Ԏw��@�\�t���ʒu����)
        [DllImport(DllName)]
        public static extern UInt32 ymcMoveIntimePositioning(
            UInt32 hDevice,
            [In] MOTION_DATA[] pMotionData,
            [In] POSITION_DATA[] pPos,
            [In] DWORD_DATA[] pPositioningTime,
            UInt32 hMoveIO,
            String pObjectName,
            UInt16 WaitForCompletion,
            UInt32 SystemOption);

        // �֐����F ymcMoveHomePosition (���_���A)
        [DllImport(DllName)]
        public static extern UInt32 ymcMoveHomePosition(
            UInt32 hDevice,
            [In] MOTION_DATA[] pMotionData,
            [In] POSITION_DATA[] pOffsetPosition,
            [In] UInt16[] pHomingMethod,
            [In] UInt16[] pDirection,
            UInt32 hMoveIO,
            String pObjectName,
            [In] UInt16[] pWaitForCompletion,
            UInt32 SystemOption);

        // �֐����F ymcMoveDriverPositioning (�h���C�o�ʒu����)
        [DllImport(DllName)]
        public static extern UInt32 ymcMoveDriverPositioning(
            UInt32 hDevice,
            [In] MOTION_DATA[] pMotionData,
            [In] POSITION_DATA[] pPos,
            UInt32 hMoveIO,
            String pObjectName,
            [In] UInt16[] pWaitForCompletion,
            UInt32 SystemOption);

        // �֐����F ymcStopMotion (�����s��~)
        [DllImport(DllName)]
        public static extern UInt32 ymcStopMotion(
            UInt32 hDevice,
            [In] MOTION_DATA[] pMotionData,
            String pObjectName,
            [In] UInt16[] pWaitForCompletion,
            UInt32 SystemOption);

        // �֐����F ymcMoveJOG (�葬����)
        [DllImport(DllName)]
        public static extern UInt32 ymcMoveJOG(
            UInt32 hDevice,
            [In] MOTION_DATA[] pMotionData,
            [In] Int16[] pDirection,
            [In] UInt16[] pTimeout,
            UInt32 hMoveIO,
            String pObjectName,
            UInt32 SystemOption);

        // �֐����F ymcStopJOG (�葬�����~)
        [DllImport(DllName)]
        public static extern UInt32 ymcStopJOG(
            UInt32 hDevice,
            UInt32 hMoveIO,
            String pObjectName,
            [In] UInt16[] pWaitForCompletion,
            UInt32 SystemOption);


        //===========================================================
        // ��ԋ@�\
        //===========================================================
        // �֐����F ymcMoveLinear (�������)
        [DllImport(DllName)]
        public static extern UInt32 ymcMoveLinear(
            UInt32 hDevice,
            ref MOTION_DATA pMotionData,
            [In] POSITION_DATA[] pPos,
            UInt32 hMoveIO,
            String pObjectName,
            UInt16 WaitForCompletion,
            UInt32 SystemOption);

        // �֐����F ymcMoveCircularRadius (�~�ʕ��(���a�w��))
        [DllImport(DllName)]
        public static extern UInt32 ymcMoveCircularRadius(
            UInt32 hDevice,
            ref MOTION_DATA pMotionData,
            [In] POSITION_DATA[] pEndPoint,
            ref DWORD_DATA pRadius,
            ref DWORD_DATA pTurnNumber,
            UInt16 Direction,
            UInt16 AngleType,
            UInt32 hMoveIO,
            String pObjectName,
            UInt16 WaitForCompletion,
            UInt32 SystemOption);

        // �֐����F ymcMoveCircularCenter (�~�ʕ��(���S���W�w��))
        [DllImport(DllName)]
        public static extern UInt32 ymcMoveCircularCenter(
            UInt32 hDevice,
            ref MOTION_DATA pMotionData,
            [In] POSITION_DATA[] pEndPoint,
            [In] POSITION_DATA[] pCenter,
            ref DWORD_DATA pTurnNumber,
            UInt16 Direction,
            UInt32 hMoveIO,
            String pObjectName,
            UInt16 WaitForCompletion,
            UInt32 SystemOption);

        // �֐����F ymcMoveHelicalRadius (�w���J�����(���a�w��))
        [DllImport(DllName)]
        public static extern UInt32 ymcMoveHelicalRadius(
            UInt32 hDevice,
            ref MOTION_DATA pMotionData,
            [In] POSITION_DATA[] pEndPoint,
            ref DWORD_DATA pRadius,
            ref DWORD_DATA pTurnNumber,
            UInt16 Direction,
            UInt16 AngleType,
            UInt32 hMoveIO,
            String pObjectName,
            UInt16 WaitForCompletion,
            UInt32 SystemOption);

        //' �֐����F ymcMoveHelicalCenter (�w���J�����(���S���W�w��))
        [DllImport(DllName)]
        public static extern UInt32 ymcMoveHelicalCenter(
            UInt32 hDevice,
            ref MOTION_DATA pMotionData,
            [In] POSITION_DATA[] pEndPoint,
            [In] POSITION_DATA[] pCenter,
            ref DWORD_DATA pTurnNumber,
            UInt16 Direction,
            UInt32 hMoveIO,
            String pObjectName,
            UInt16 WaitForCompletion,
            UInt32 SystemOption);

        //===========================================================
        // �����@�\(GEAR)
        //===========================================================
        // �֐����F ymcEnableGear (�M������J�n)
        [DllImport(DllName)]
        public static extern UInt32 ymcEnableGear(
            UInt32 hAxis,
            UInt32 hDevice,
            UInt32 MasterType,
            [In] SYNC_DISTANCE[] pSyncDistance,
            [In] UInt32[] pStatus,
            String pObjectName,
            [In] UInt16[] pWaitForCompletion,
            UInt32 SystemOption);

        // �֐����F ymcDisableGear (�M�������~)
        [DllImport(DllName)]
        public static extern UInt32 ymcDisableGear(
            UInt32 hAxis,
            UInt32 hDevice,
            UInt32 MasterType,
            [In] SYNC_DISTANCE[] pSyncDistance,
            String pObjectName,
            [In] UInt16[] pWaitForCompletion,
            UInt32 SystemOption);

        // �֐����F ymcSetGearRatio (�M����̐ݒ�)
        [DllImport(DllName)]
        public static extern UInt32 ymcSetGearRatio(
            UInt32 hDevice,
            [In] GEAR_RATIO_DATA[] pGearRatioData,
            UInt32 SystemOption);

        //===========================================================
        // �␳�@�\
        //===========================================================
        // �֐����F ymcPositionOffset (�ʒu�␳)
        [DllImport(DllName)]
        public static extern UInt32 ymcPositionOffset(
            UInt32 hDevice,
            [In] POSITION_OFFSET_DATA[] pPositionOffsetData,
            String pObjectName,
            [In] UInt16[] pWaitForCompletion,
            UInt32 SystemOption);

        //===========================================================
        // ���[�V��������
        //===========================================================
        // �֐����F ymcChangeDynamics (���[�V�����f�[�^�̕ύX)
        [DllImport(DllName)]
        public static extern UInt32 ymcChangeDynamics(
            UInt32 hDevice,
            [In] MOTION_DATA[] pMotionData,
            [In] POSITION_DATA[] pPos,
            UInt32 Subject,
            String pObjectName,
            UInt32 SystemOption);

        //===========================================================
        // �h���C�o����
        //===========================================================
        // �֐����F ymcServoControl (�T�[�{ ON or OFF)
        [DllImport(DllName)]
        public static extern UInt32 ymcServoControl(
            UInt32 hDevice,
            UInt16 ControlType,
            UInt16 TimeOut);

        //===========================================================
        // ���̑�
        //===========================================================
        // �֐����F ymcEnableLatch (Latch�J�n)
        [DllImport(DllName)]
        public static extern UInt32 ymcEnableLatch(
            UInt32 hDevice,
            String pObjectName,
            [In] UInt16[] pWaitForCompletion,
            UInt32 SystemOption);

        //' �֐����F ymcDisableLatch (Latch��~)
        [DllImport(DllName)]
        public static extern UInt32 ymcDisableLatch(
            UInt32 hDevice,
            String pObjectName,
            UInt32 SystemOption);


        //***********************************************************
        // �V�X�e��API
        //***********************************************************
        //===========================================================
        // �f�[�^����
        //===========================================================
        // �֐����F ymcSetIoDataBit (�r�b�g�ݒ�)
        [DllImport(DllName)]
        public static extern UInt32 ymcSetIoDataBit(
            ref IO_DATA pIoData,
            UInt32 pStoredBitValue);

        // �֐����F ymcGetIoDataBit (�r�b�g�擾)
        [DllImport(DllName)]
        public static extern UInt32 ymcGetIoDataBit(
            ref IO_DATA pIoData,
            ref UInt32 pStoredBitValue);

        // �֐����F ymcSetIoDataValue (�f�[�^�ݒ�)
        [DllImport(DllName)]
        public static extern UInt32 ymcSetIoDataValue(
            ref IO_DATA pIoData,
            UInt32 Value);

        // �֐����F ymcGetIoDataValue (�f�[�^�擾)
        [DllImport(DllName)]
        public static extern UInt32 ymcGetIoDataValue(
            ref IO_DATA pIoData,
            ref UInt32 pStoredValue);

        // �֐����F ymcSetRegisterData (���W�X�^�֒l�̐ݒ�)
        [DllImport(DllName)]
        public static extern UInt32 ymcSetRegisterData(
            UInt32 hRegisterData,
            UInt32 RegisterDataNumber,
            [In] Int16[] pRegisterData);
        [DllImport(DllName)]
        public static extern UInt32 ymcSetRegisterData(
            UInt32 hRegisterData,
            UInt32 RegisterDataNumber,
            [In] UInt16[] pRegisterData);
        [DllImport(DllName)]
        public static extern UInt32 ymcSetRegisterData(
            UInt32 hRegisterData,
            UInt32 RegisterDataNumber,
            [In] Int32[] pRegisterData);
        [DllImport(DllName)]
        public static extern UInt32 ymcSetRegisterData(
            UInt32 hRegisterData,
            UInt32 RegisterDataNumber,
            [In] UInt32[] pRegisterData);

        // �֐����F ymcSetRegisterDataEx (�g���Ń��W�X�^�֒l�̐ݒ�)
        [DllImport(DllName)]
        public static extern UInt32 ymcSetRegisterDataEx(
            UInt64 hRegisterDataEx,
            UInt32 RegisterDataNumber,
            [In] Int16[] pRegisterData);
        [DllImport(DllName)]
        public static extern UInt32 ymcSetRegisterDataEx(
            UInt64 hRegisterDataEx,
            UInt32 RegisterDataNumber,
            [In] UInt16[] pRegisterData);
        [DllImport(DllName)]
        public static extern UInt32 ymcSetRegisterDataEx(
            UInt64 hRegisterDataEx,
            UInt32 RegisterDataNumber,
            [In] Int32[] pRegisterData);
        [DllImport(DllName)]
        public static extern UInt32 ymcSetRegisterDataEx(
            UInt64 hRegisterDataEx,
            UInt32 RegisterDataNumber,
            [In] UInt32[] pRegisterData);

        // �֐����F ymcGetRegisterData (���W�X�^����̒l�ǂݏo��)
        [DllImport(DllName)]
        public static extern UInt32 ymcGetRegisterData(
            UInt32 hRegisterData,
            UInt32 RegisterDataNumber,
            [In] Int16[] pRegisterData,
            ref UInt32 pReadDataNumber);
        [DllImport(DllName)]
        public static extern UInt32 ymcGetRegisterData(
            UInt32 hRegisterData,
            UInt32 RegisterDataNumber,
            [In] UInt16[] pRegisterData,
            ref UInt32 pReadDataNumber);
        [DllImport(DllName)]
        public static extern UInt32 ymcGetRegisterData(
            UInt32 hRegisterData,
            UInt32 RegisterDataNumber,
            [In] Int32[] pRegisterData,
            ref UInt32 pReadDataNumber);
        [DllImport(DllName)]
        public static extern UInt32 ymcGetRegisterData(
            UInt32 hRegisterData,
            UInt32 RegisterDataNumber,
            [In] UInt32[] pRegisterData,
            ref UInt32 pReadDataNumber);

        // �֐����F ymcGetRegisterDataEx (�g���Ń��W�X�^����̒l�ǂݏo��)
        [DllImport(DllName)]
        public static extern UInt32 ymcGetRegisterDataEx(
            UInt64 hRegisterDataEx,
            UInt32 RegisterDataNumber,
            [In] Int16[] pRegisterData,
            ref UInt32 pReadDataNumber);
        [DllImport(DllName)]
        public static extern UInt32 ymcGetRegisterDataEx(
            UInt64 hRegisterDataEx,
            UInt32 RegisterDataNumber,
            [In] UInt16[] pRegisterData,
            ref UInt32 pReadDataNumber);
        [DllImport(DllName)]
        public static extern UInt32 ymcGetRegisterDataEx(
            UInt64 hRegisterDataEx,
            UInt32 RegisterDataNumber,
            [In] Int32[] pRegisterData,
            ref UInt32 pReadDataNumber);
        [DllImport(DllName)]
        public static extern UInt32 ymcGetRegisterDataEx(
            UInt64 hRegisterDataEx,
            UInt32 RegisterDataNumber,
            [In] UInt32[] pRegisterData,
            ref UInt32 pReadDataNumber);

        // �֐����F ymcGetRegisterDataHandle (���W�X�^�n���h���擾)
        [DllImport(DllName)]
        public static extern UInt32 ymcGetRegisterDataHandle(
            String pRegisterName,
            ref UInt32 hRegisterData);

        // �֐����F ymcGetRegisterDataHandleEx (�g���Ń��W�X�^�n���h���擾)
        [DllImport(DllName)]
        public static extern UInt32 ymcGetRegisterDataHandleEx(
            String pRegisterName,
            ref UInt64 hRegisterDataEx);

        // �֐����F ymcSetGroupRegisterData (���W�X�^�֒l�̐ݒ�(����))
        [DllImport(DllName)]
        public static extern UInt32 ymcSetGroupRegisterData(
            UInt32 GroupNumber,
            [In] REGISTER_INFO[] pRegisterInfo);

        // �֐����F ymcSetGroupRegisterDataEx (�g���Ń��W�X�^�֒l�̐ݒ�(����))
        [DllImport(DllName)]
        public static extern UInt32 ymcSetGroupRegisterDataEx(
            UInt32 GroupNumber,
            [In] REGISTER_INFO_EX[] pRegisterInfoEx);

        // �֐����F ymcGetGroupRegisterData (���W�X�^�l�̎擾�i�����j)
        [DllImport(DllName)]
        public static extern UInt32 ymcGetGroupRegisterData(
            UInt32 GroupNumber,
            [In] REGISTER_INFO[] pRegisterInfo);

        // �֐����F ymcGetGroupRegisterDataEx (�g���Ń��W�X�^�l�̎擾�i�����j)
        [DllImport(DllName)]
        public static extern UInt32 ymcGetGroupRegisterDataEx(
            UInt32 GroupNumber,
            [In] REGISTER_INFO_EX[] pRegisterInfoEx);

        //===========================================================
        // �V�X�e�����
        //==========================================================
        // �֐����F ymcClearAlarm (�A���[���N���A)
        [DllImport(DllName)]
        public static extern UInt32 ymcClearAlarm(
            UInt32 hAlarm);

        // �֐����F ymcClearServoAlarm (�A���[���N���A)
        [DllImport(DllName)]
        public static extern UInt32 ymcClearServoAlarm(
            UInt32 hAxis);

        // �֐����F ymcGetAlarm (�J�����g�A���[���̎擾)
        [DllImport(DllName)]
        public static extern UInt32 ymcGetAlarm(
            UInt32 Number,
            [Out] UInt32[] pAlarm,
            [Out] ALARM_INFO[] pAlarmInfo,
            ref UInt32 pAlarmNumber);

        //============================================================
        // �V�X�e������
        //============================================================
        // �֐����F ymcSetController (�ΏۃR���g���[���̐؂�ւ�)
        [DllImport(DllName)]
        public static extern UInt32 ymcSetController(
            UInt32 hController);

        // �֐����F ymcGetController (���ΏۃR���g���[���n���h���̎擾)
        [DllImport(DllName)]
        public static extern UInt32 ymcGetController(
            ref UInt32 hController);

        // �֐����F ymcResetController (�ΏۃR���g���[���̃��Z�b�g)
        [DllImport(DllName)]
        public static extern UInt32 ymcResetController(
            UInt32 hController);

        // �֐����F ymcGetBusIFData (BusIF�f�[�^�̎擾)
        [DllImport(DllName)]
        public static extern UInt32 ymcGetBusIFData(
            UInt32 Offset,
            UInt32 Size,
            [Out] UInt16[] pBusIFData);

        // �֐����F ymcSetBusIFData (BusIF�f�[�^�̐ݒ�)
        [DllImport(DllName)]
        public static extern UInt32 ymcSetBusIFData(
            UInt32 Offset,
            UInt32 Size,
            [In] UInt16[] pBusIFData);

        // �֐����F ymcGetBusIFInfo (BusIF���̎擾)
        [DllImport(DllName)]
        public static extern UInt32 ymcGetBusIFInfo(
            ref BUSIF_INFO pBusIFInfo);

        //============================================================
        // ComDevice�̐錾�E�폜
        //============================================================
        // �֐����F ymcOpenController (ComDevice�̐錾)
        [DllImport(DllName)]
        public static extern UInt32 ymcOpenController(
            ref COM_DEVICE pComDevice,
            ref UInt32 hController);

        // �֐����F ymcCloseController (ComDevice�̍폜)
        [DllImport(DllName)]
        public static extern UInt32 ymcCloseController(
            UInt32 hController);

        //============================================================
        // �J�����_����
        //============================================================
        // �֐����F ymcSetCalendar (�J�����_�̐ݒ�)
        [DllImport(DllName)]
        public static extern UInt32 ymcSetCalendar(
            ref CALENDAR_DATA pCalendarData);

        // �֐����F ymcGetCalendar (�J�����_�̎擾)
        [DllImport(DllName)]
        public static extern UInt32 ymcGetCalendar(
            ref CALENDAR_DATA pCalendarData);

        //============================================================
        // ���X�g�G���[
        //============================================================
        // �֐����F ymcGetLastError (���X�g�G���[�ǂݏo��)
        [DllImport(DllName)]
        public static extern UInt32 ymcGetLastError();

        //============================================================
        // �^�C�}�[
        //============================================================
        // �֐����F ymcSetAPITimeoutValue   (�����҂����̃^�C���A�E�g)
        [DllImport(DllName)]
        public static extern UInt32 ymcSetAPITimeoutValue(
            UInt32 TimeoutValue);

        //' �֐����F ymcWaitTime (�^�C���A�E�g�҂�)
        [DllImport(DllName)]
        public static extern UInt32 ymcWaitTime(
            UInt32 WaitTime,
            String pObjectName);

        //===========================================================
        // ���M���O
        //===========================================================
        // �֐����F ymcGetLoggingPath (���O�t�@�C���̃t�@�C���p�X�擾)
        [DllImport(DllName)]
        public static extern UInt32 ymcGetLoggingPath(
            String pMPLogPathName,
            UInt32 pMPStatus);

        //�֐����F ymcGetLoggingFile (���O�t�@�C���̊i�[)
        [DllImport(DllName)]
        public static extern UInt32 ymcGetLoggingFile(
            String pMPLogPathName,
            String pWriteFileName);
    }
}