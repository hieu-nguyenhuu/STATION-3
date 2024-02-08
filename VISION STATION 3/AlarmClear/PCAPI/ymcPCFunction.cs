//===========================================================
//
// ymcPCAPI.Dll 用　API宣言モジュール ＜ymcPCFunction.cs＞
//
// バージョン（日付）： Ver.1.0.0.1 (13/07/25)
//
// 備考              ：	C#用
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
        // 逐次／イベント  共通モーションAPI
        //***********************************************************
        //===========================================================
        // デバイス
        //===========================================================
        // 関数名： ymcClearAllAxes (全Axisハンドルを解放) 
        [DllImport(DllName)]
        public static extern UInt32 ymcClearAllAxes();

        // 関数名： ymcDeclareAxis (軸ハンドルの宣言)
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

        // 関数名： ymcClearAxis (軸定義の削除)
        [DllImport(DllName)]
        public static extern UInt32 ymcClearAxis(
            UInt32 hAxis);

        // 関数名： ymcDeclareDevice (デバイスの宣言)
        [DllImport(DllName)]
        public static extern UInt32 ymcDeclareDevice(
            UInt16 AxisNum,
            [In] UInt32[] pAxis,
            ref UInt32 pDevice);

        // 関数名： ymcClearDevice (デバイス削除)
        [DllImport(DllName)]
        public static extern UInt32 ymcClearDevice(
            UInt32 hDevice);

        // 関数名： ymcGetAxisHandle (軸ハンドル情報の取得)
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
        // 単位変換機能
        //===========================================================
        // 関数名： ymcConvertFloat2Fix (浮動小数点→固定小数点変換)
        [DllImport(DllName)]
        public static extern UInt32 ymcConvertFloat2Fix(
            UInt16 digit,
            Double FloatValue,
            ref Int32 pFixValue);

        // 関数名： ymcConvertFix2Float (固定小数点→浮動小数点変換)
        [DllImport(DllName)]
        public static extern UInt32 ymcConvertFix2Float(
            UInt16 digit,
            Int32 FixValue,
            ref Double pFloatValue);

        //===========================================================
        // 軸情報
        //===========================================================
        // 関数名： ymcMoveTorque (トルク指令機能)
        [DllImport(DllName)]
        public static extern UInt32 ymcMoveTorque(
            UInt32 hDevice,
            [In] POSITION_DATA[] pSpeedLimit,
            [In] POSITION_DATA[] pTorqueData,
            UInt32 hMoveIO,
            String pObjectName,
            UInt32 SystemOption);

        //===========================================================
        // パラメータ操作
        //===========================================================
        // 関数名： ymcSetMotionParameterValue (モーションパラメータ設定)
        [DllImport(DllName)]
        public static extern UInt32 ymcSetMotionParameterValue(
            UInt32 hAxis,
            UInt16 ParameterType,
            UInt32 ParameterOffset,
            UInt32 Value);

        // 関数名： ymcGetMotionParameterValue (モーションパラメータ取得)
        [DllImport(DllName)]
        public static extern UInt32 ymcGetMotionParameterValue(
            UInt32 hAxis,
            UInt16 ParameterType,
            UInt32 ParameterOffset,
            ref UInt32 pStoredValue);

        // 関数名： ymcDefinePosition (現在位置設定)
        [DllImport(DllName)]
        public static extern UInt32 ymcDefinePosition(
            UInt32 hDevice,
            [In] POSITION_DATA[] pPos);

        //***********************************************************
        // 逐次実行型モーションAPI
        //***********************************************************
        //===========================================================
        // 位置決め機能
        //===========================================================
        // 関数名： ymcMovePositioning (位置決め：逐次型)
        [DllImport(DllName)]
        public static extern UInt32 ymcMovePositioning(
            UInt32 hDevice,
            [In] MOTION_DATA[] pMotionData,
            [In] POSITION_DATA[] pPos,
            UInt32 hMoveIO,
            String pObjectName,
            UInt16 WaitForCompletion,
            UInt32 SystemOption);

        // 関数名： ymcMoveExternalPositioning (外部位置決め)
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

        // 関数名： ymcMoveIntimePositioning (時間指定機能付き位置決め)
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

        // 関数名： ymcMoveHomePosition (原点復帰)
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

        // 関数名： ymcMoveDriverPositioning (ドライバ位置決め)
        [DllImport(DllName)]
        public static extern UInt32 ymcMoveDriverPositioning(
            UInt32 hDevice,
            [In] MOTION_DATA[] pMotionData,
            [In] POSITION_DATA[] pPos,
            UInt32 hMoveIO,
            String pObjectName,
            [In] UInt16[] pWaitForCompletion,
            UInt32 SystemOption);

        // 関数名： ymcStopMotion (軸実行停止)
        [DllImport(DllName)]
        public static extern UInt32 ymcStopMotion(
            UInt32 hDevice,
            [In] MOTION_DATA[] pMotionData,
            String pObjectName,
            [In] UInt16[] pWaitForCompletion,
            UInt32 SystemOption);

        // 関数名： ymcMoveJOG (定速送り)
        [DllImport(DllName)]
        public static extern UInt32 ymcMoveJOG(
            UInt32 hDevice,
            [In] MOTION_DATA[] pMotionData,
            [In] Int16[] pDirection,
            [In] UInt16[] pTimeout,
            UInt32 hMoveIO,
            String pObjectName,
            UInt32 SystemOption);

        // 関数名： ymcStopJOG (定速送り停止)
        [DllImport(DllName)]
        public static extern UInt32 ymcStopJOG(
            UInt32 hDevice,
            UInt32 hMoveIO,
            String pObjectName,
            [In] UInt16[] pWaitForCompletion,
            UInt32 SystemOption);


        //===========================================================
        // 補間機能
        //===========================================================
        // 関数名： ymcMoveLinear (直線補間)
        [DllImport(DllName)]
        public static extern UInt32 ymcMoveLinear(
            UInt32 hDevice,
            ref MOTION_DATA pMotionData,
            [In] POSITION_DATA[] pPos,
            UInt32 hMoveIO,
            String pObjectName,
            UInt16 WaitForCompletion,
            UInt32 SystemOption);

        // 関数名： ymcMoveCircularRadius (円弧補間(半径指定))
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

        // 関数名： ymcMoveCircularCenter (円弧補間(中心座標指定))
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

        // 関数名： ymcMoveHelicalRadius (ヘリカル補間(半径指定))
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

        //' 関数名： ymcMoveHelicalCenter (ヘリカル補間(中心座標指定))
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
        // 同期機能(GEAR)
        //===========================================================
        // 関数名： ymcEnableGear (ギヤ制御開始)
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

        // 関数名： ymcDisableGear (ギヤ制御停止)
        [DllImport(DllName)]
        public static extern UInt32 ymcDisableGear(
            UInt32 hAxis,
            UInt32 hDevice,
            UInt32 MasterType,
            [In] SYNC_DISTANCE[] pSyncDistance,
            String pObjectName,
            [In] UInt16[] pWaitForCompletion,
            UInt32 SystemOption);

        // 関数名： ymcSetGearRatio (ギヤ比の設定)
        [DllImport(DllName)]
        public static extern UInt32 ymcSetGearRatio(
            UInt32 hDevice,
            [In] GEAR_RATIO_DATA[] pGearRatioData,
            UInt32 SystemOption);

        //===========================================================
        // 補正機能
        //===========================================================
        // 関数名： ymcPositionOffset (位置補正)
        [DllImport(DllName)]
        public static extern UInt32 ymcPositionOffset(
            UInt32 hDevice,
            [In] POSITION_OFFSET_DATA[] pPositionOffsetData,
            String pObjectName,
            [In] UInt16[] pWaitForCompletion,
            UInt32 SystemOption);

        //===========================================================
        // モーション操作
        //===========================================================
        // 関数名： ymcChangeDynamics (モーションデータの変更)
        [DllImport(DllName)]
        public static extern UInt32 ymcChangeDynamics(
            UInt32 hDevice,
            [In] MOTION_DATA[] pMotionData,
            [In] POSITION_DATA[] pPos,
            UInt32 Subject,
            String pObjectName,
            UInt32 SystemOption);

        //===========================================================
        // ドライバ操作
        //===========================================================
        // 関数名： ymcServoControl (サーボ ON or OFF)
        [DllImport(DllName)]
        public static extern UInt32 ymcServoControl(
            UInt32 hDevice,
            UInt16 ControlType,
            UInt16 TimeOut);

        //===========================================================
        // その他
        //===========================================================
        // 関数名： ymcEnableLatch (Latch開始)
        [DllImport(DllName)]
        public static extern UInt32 ymcEnableLatch(
            UInt32 hDevice,
            String pObjectName,
            [In] UInt16[] pWaitForCompletion,
            UInt32 SystemOption);

        //' 関数名： ymcDisableLatch (Latch停止)
        [DllImport(DllName)]
        public static extern UInt32 ymcDisableLatch(
            UInt32 hDevice,
            String pObjectName,
            UInt32 SystemOption);


        //***********************************************************
        // システムAPI
        //***********************************************************
        //===========================================================
        // データ操作
        //===========================================================
        // 関数名： ymcSetIoDataBit (ビット設定)
        [DllImport(DllName)]
        public static extern UInt32 ymcSetIoDataBit(
            ref IO_DATA pIoData,
            UInt32 pStoredBitValue);

        // 関数名： ymcGetIoDataBit (ビット取得)
        [DllImport(DllName)]
        public static extern UInt32 ymcGetIoDataBit(
            ref IO_DATA pIoData,
            ref UInt32 pStoredBitValue);

        // 関数名： ymcSetIoDataValue (データ設定)
        [DllImport(DllName)]
        public static extern UInt32 ymcSetIoDataValue(
            ref IO_DATA pIoData,
            UInt32 Value);

        // 関数名： ymcGetIoDataValue (データ取得)
        [DllImport(DllName)]
        public static extern UInt32 ymcGetIoDataValue(
            ref IO_DATA pIoData,
            ref UInt32 pStoredValue);

        // 関数名： ymcSetRegisterData (レジスタへ値の設定)
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

        // 関数名： ymcSetRegisterDataEx (拡張版レジスタへ値の設定)
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

        // 関数名： ymcGetRegisterData (レジスタからの値読み出し)
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

        // 関数名： ymcGetRegisterDataEx (拡張版レジスタからの値読み出し)
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

        // 関数名： ymcGetRegisterDataHandle (レジスタハンドル取得)
        [DllImport(DllName)]
        public static extern UInt32 ymcGetRegisterDataHandle(
            String pRegisterName,
            ref UInt32 hRegisterData);

        // 関数名： ymcGetRegisterDataHandleEx (拡張版レジスタハンドル取得)
        [DllImport(DllName)]
        public static extern UInt32 ymcGetRegisterDataHandleEx(
            String pRegisterName,
            ref UInt64 hRegisterDataEx);

        // 関数名： ymcSetGroupRegisterData (レジスタへ値の設定(複数))
        [DllImport(DllName)]
        public static extern UInt32 ymcSetGroupRegisterData(
            UInt32 GroupNumber,
            [In] REGISTER_INFO[] pRegisterInfo);

        // 関数名： ymcSetGroupRegisterDataEx (拡張版レジスタへ値の設定(複数))
        [DllImport(DllName)]
        public static extern UInt32 ymcSetGroupRegisterDataEx(
            UInt32 GroupNumber,
            [In] REGISTER_INFO_EX[] pRegisterInfoEx);

        // 関数名： ymcGetGroupRegisterData (レジスタ値の取得（複数）)
        [DllImport(DllName)]
        public static extern UInt32 ymcGetGroupRegisterData(
            UInt32 GroupNumber,
            [In] REGISTER_INFO[] pRegisterInfo);

        // 関数名： ymcGetGroupRegisterDataEx (拡張版レジスタ値の取得（複数）)
        [DllImport(DllName)]
        public static extern UInt32 ymcGetGroupRegisterDataEx(
            UInt32 GroupNumber,
            [In] REGISTER_INFO_EX[] pRegisterInfoEx);

        //===========================================================
        // システム情報
        //==========================================================
        // 関数名： ymcClearAlarm (アラームクリア)
        [DllImport(DllName)]
        public static extern UInt32 ymcClearAlarm(
            UInt32 hAlarm);

        // 関数名： ymcClearServoAlarm (アラームクリア)
        [DllImport(DllName)]
        public static extern UInt32 ymcClearServoAlarm(
            UInt32 hAxis);

        // 関数名： ymcGetAlarm (カレントアラームの取得)
        [DllImport(DllName)]
        public static extern UInt32 ymcGetAlarm(
            UInt32 Number,
            [Out] UInt32[] pAlarm,
            [Out] ALARM_INFO[] pAlarmInfo,
            ref UInt32 pAlarmNumber);

        //============================================================
        // システム操作
        //============================================================
        // 関数名： ymcSetController (対象コントローラの切り替え)
        [DllImport(DllName)]
        public static extern UInt32 ymcSetController(
            UInt32 hController);

        // 関数名： ymcGetController (現対象コントローラハンドルの取得)
        [DllImport(DllName)]
        public static extern UInt32 ymcGetController(
            ref UInt32 hController);

        // 関数名： ymcResetController (対象コントローラのリセット)
        [DllImport(DllName)]
        public static extern UInt32 ymcResetController(
            UInt32 hController);

        // 関数名： ymcGetBusIFData (BusIFデータの取得)
        [DllImport(DllName)]
        public static extern UInt32 ymcGetBusIFData(
            UInt32 Offset,
            UInt32 Size,
            [Out] UInt16[] pBusIFData);

        // 関数名： ymcSetBusIFData (BusIFデータの設定)
        [DllImport(DllName)]
        public static extern UInt32 ymcSetBusIFData(
            UInt32 Offset,
            UInt32 Size,
            [In] UInt16[] pBusIFData);

        // 関数名： ymcGetBusIFInfo (BusIF情報の取得)
        [DllImport(DllName)]
        public static extern UInt32 ymcGetBusIFInfo(
            ref BUSIF_INFO pBusIFInfo);

        //============================================================
        // ComDeviceの宣言・削除
        //============================================================
        // 関数名： ymcOpenController (ComDeviceの宣言)
        [DllImport(DllName)]
        public static extern UInt32 ymcOpenController(
            ref COM_DEVICE pComDevice,
            ref UInt32 hController);

        // 関数名： ymcCloseController (ComDeviceの削除)
        [DllImport(DllName)]
        public static extern UInt32 ymcCloseController(
            UInt32 hController);

        //============================================================
        // カレンダ操作
        //============================================================
        // 関数名： ymcSetCalendar (カレンダの設定)
        [DllImport(DllName)]
        public static extern UInt32 ymcSetCalendar(
            ref CALENDAR_DATA pCalendarData);

        // 関数名： ymcGetCalendar (カレンダの取得)
        [DllImport(DllName)]
        public static extern UInt32 ymcGetCalendar(
            ref CALENDAR_DATA pCalendarData);

        //============================================================
        // ラストエラー
        //============================================================
        // 関数名： ymcGetLastError (ラストエラー読み出し)
        [DllImport(DllName)]
        public static extern UInt32 ymcGetLastError();

        //============================================================
        // タイマー
        //============================================================
        // 関数名： ymcSetAPITimeoutValue   (応答待ち時のタイムアウト)
        [DllImport(DllName)]
        public static extern UInt32 ymcSetAPITimeoutValue(
            UInt32 TimeoutValue);

        //' 関数名： ymcWaitTime (タイムアウト待ち)
        [DllImport(DllName)]
        public static extern UInt32 ymcWaitTime(
            UInt32 WaitTime,
            String pObjectName);

        //===========================================================
        // ロギング
        //===========================================================
        // 関数名： ymcGetLoggingPath (ログファイルのファイルパス取得)
        [DllImport(DllName)]
        public static extern UInt32 ymcGetLoggingPath(
            String pMPLogPathName,
            UInt32 pMPStatus);

        //関数名： ymcGetLoggingFile (ログファイルの格納)
        [DllImport(DllName)]
        public static extern UInt32 ymcGetLoggingFile(
            String pMPLogPathName,
            String pWriteFileName);
    }
}