//===========================================================
//
// ymcPCAPI.Dll 用　構造体定義モジュール ＜ymcPCStruct.cs＞
//
// バージョン（日付）： Ver.1.0.0.0 (12/02/27)
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

        // COM_DEVICE構造体
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct COM_DEVICE
        {
            public UInt16 		ComDeviceType;             	// 通信種別
            public UInt16 		PortNumber;                	// ポート番号
            public UInt16 		CpuNumber;                 	// CPU番号
            public UInt16 		NetworkNumber;				// ネットワーク番号
            public UInt16 		StationNumber;             	// ステーション番号
            public UInt16 		UnitNumber;                	// Unit番号
            public string 		IPAddress;                 	// IPアドレス(Ethernet)
            public UInt32 		Timeout;                   	// 通信タイムアウト時間
        };

        // IOﾃﾞｰﾀ構造体
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct IO_DATA
        {
            public UInt16     	DeviceType;             	// IO, DirectIO, Variable, Timer, Motionなどパケットのアクセス種別にあたる            
            public UInt16     	DataUnitSize;           	// 単位データサイズ
            public UInt16     	RackNo;                 	// ラック番号(1,2,...)
            public UInt16     	SlotNo;                 	// スロット番号(0,1,...)
            public UInt16     	SubslotNo;              	// サブスロット番号(1,2,...)
            public UInt16     	StationNo;              	// ステーション番号(1,2,...)
            public UInt32     	hData;                  	// データハンドル
            public UInt32     	DeviceWordOffset;           // IO,Variable  オフセットアドレス（ワード単位）
            public UInt16     	DeviceBitOffset;          	// ビットオフセット
            public UInt16     	Reserve;                	// 予備
            public UInt32		DataUnitCount;          	// used for multiple bit quantities or multiple byte arrays, normally 1
        };

        // ポジションデータ指定構造体
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct POSITION_DATA
        {
	        public Int32 		DataType;                   // データタイプ(0.immediate, 1.間接指定)
	        public Int32 		PositionData;               // 位置データ　間接指定の場合はhGlobalDataを格納
		};
		
        // ギア比設定で使用するデータの構造体
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct GEAR_RATIO_DATA
        {
	        public UInt16    	Master;                     // Gear比(分子)の指定
	        public UInt16    	Slave;                      // Gear比(分母)の指定
		}
		
        // Gearで使用する同期位置データの構造体
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct SYNC_DISTANCE
       	{
            public UInt16     	SyncType;                   // 同期タイプ
            public UInt16     	DataType;                   // マスタ軸移動距離データタイプ
            public UInt32    	DistanceData;               // マスタ軸移動距離
		};
		
        // 位相補正でで使用するデータの構造体
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct POSITION_OFFSET_DATA
       	{
            public UInt32     	ShiftType;                  // 速度パターンの選択(TRIANGLE,TRAPEZOIDE)
            public double   	Offset;                     // 位置オフセット値(UserUnit)
            public double   	Duration;                   // 位置補正時間or位置補正距離
        };

        // 共通モーションデータ指定構造体
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct MOTION_DATA
       	{
            public Int16 		CoordinateSystem;           // 座標系指定
            public Int16 		MoveType;                   // 動作タイプ
            public Int16 		VelocityType;               // 速度タイプ
            public Int16 		AccDecType;                 // 加速度タイプ
            public Int16 		FilterType;                 // フィルタタイプ
            public Int16 		DataType;                   // データタイプ（0:immediate/1:間接指定）
            public Int32 		MaxVelocity;                // 送り最高速度[指令単位/sec]
            public Int32 		Acceleration;               // 加速度[指令単位/sec^2]、加速時定数[ms]
            public Int32 		Deceleration;               // 減速度[指令単位/sec^2]、減速時定数[ms]
            public Int32 		FilterTime;                 // フィルタ時間[ms]
            public Int32 		Velocity;                   // 送り速度[指令単位/sec]、Offset速度
            public Int32 		ApproachVelocity;           // アプローチ速度[指令単位/sec]
            public Int32 		CreepVelocity;              // クリープ速度[指令単位/sec]
        };

        // カレンダーデータ構造体
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct CALENDAR_DATA
       	{
            public UInt16    	Year;                     	// 年
            public UInt16    	Month;                    	// 月
            public UInt16    	DayOfWeek;                	// 曜日
            public UInt16    	Day;                    	// 日
            public UInt16    	Hour;                     	// 時間
            public UInt16    	Minutes;                    // 分
            public UInt16    	Second;                    	// 秒
            public UInt16    	Milliseconds;               // ミリ秒
        };

        // アラーム情報構造体
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ALARM_INFO
       	{
		    public UInt32        ErrorCode;					// エラーコード
		    public UInt32        ErrorLocation;             // 発生場所
		    public UInt32        DetectTask;                // 検出者
		    public UInt32        hDevice;                   // デバイスハンドル
		    public UInt32        TaskID;                    // タスクID
            [ MarshalAs(UnmanagedType.ByValTStr, SizeConst=8)]
		    public String        TaskName;                  // タスク名称
		    public UInt32        ObjectHandle;              // オブジェクトハンドル
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=8)]
		    public String        ObjectName;                // オブジェクト名称
            public CALENDAR_DATA Calendar;                  // カレンダ
		    public UInt32        hAxis;                     // AXISﾊﾝﾄﾞﾙ
		    public UInt32        DetailError;               // 詳細エラー(任意のエラーコード)
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=32)]
		    public String        Comment;                   // コメント
		};                                       

        // 2WORDデータ指定構造体
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DWORD_DATA
       	{
            public Int32    	DataType;                   // データタイプ(0.immediate, 1.間接指定)
            public Int32    	Data;						// データ　間接指定の場合はhGlobalDataを格納
        };
        
        // レジスタ情報構造体
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct REGISTER_INFO
       	{
            public UInt32     	hRegisterData;              // レジスタハンドル
            public UInt32       RegisterDataNumber;         // レジスタ数
            public IntPtr    	pRegisterData;              // レジスタデータ転送元ワークへのポインタ
            public UInt32       ReadDataNumber;             // 読込みレジスタ数
        };

        // 拡張版レジスタ情報構造体
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct REGISTER_INFO_EX
        {
            public UInt64       hRegisterDataEx;            // 拡張版レジスタハンドル
            public UInt32       RegisterDataNumber;         // レジスタ数
            public IntPtr       pRegisterData;              // レジスタデータ転送元ワークへのポインタ
            public UInt32       ReadDataNumber;             // 読込みレジスタ数
        };

        // BUSIF構造体
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct BUSIF_INFO
       	{
            public UInt16     	InputDataMaxSize;        	// 最大入力サイズ（public UInt16)
            public UInt16     	InputDataAvailableSize;		// 有効入力サイズ（public UInt16)
            public UInt16     	OutputDataMaxSize;       	// 最大出力サイズ（public UInt16）
            public UInt16     	OutputDataAvailableSize;	// 有効出力サイズ（public UInt16）
        };
    }
}