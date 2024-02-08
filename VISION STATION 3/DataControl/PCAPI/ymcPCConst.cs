//===========================================================
//
// ymcPCAPI.Dll 用　定数定義モジュール ＜ymcPCConst.cs＞
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
        //======================================================
        //                                                      
        //  モーションAPI 定義                                 
        //                                                      
        //======================================================
        public enum ApiDefs : ushort
        {
            REAL_AXIS = 1,                      // 実サーボ軸       			
            VIRTUAL_AXIS = 2,                   // 仮想サーボ軸					
            EXTERNAL_ENCODER = 3,               // 外部エンコーダ				

            // SpecifyType 軸指定方法
            PHYSICALAXIS = 1,                   // 物理軸指定                   
            AXISNAME = 2,                       // 軸名称指定                   
            LOGICALAXIS = 3,                    // 論理軸指定                   

            // 原点復帰方式
            HMETHOD_DEC1_C = 0,                 //  0: DEC1+C相パルス方式       
            HMETHOD_ZERO = 1,                   //  1: ZERO信号方式             
            HMETHOD_DEC1_ZERO = 2,              //  2: DEC1+ZERO信号方式        
            HMETHOD_C = 3,                      //  3: C相パルス方式            
            HMETHOD_DEC2_ZERO = 4,              //  4: DEC2+ZERO信号方式        
            HMETHOD_DEC1_L_ZERO = 5,            //  5: DEC1+LMT+ZERO信号方式    
            HMETHOD_DEC2_C = 6,                 //  6: DEC2+C相パルス方式       
            HMETHOD_DEC1_L_C = 7,               //  7: DEC1+LMT+C相パルス方式   
            HMETHOD_C_ONLY = 11,                // 11: C Pulse Only				
            HMETHOD_POT_C = 12,                 // 12: POT & C Pulse			
            HMETHOD_POT_ONLY = 13,              // 13: POT Only					
            HMETHOD_HOMELS_C = 14,              // 14: Home LS C Pulse			
            HMETHOD_HOMELS_ONLY = 15,           // 15: Home LS Only				
            HMETHOD_NOT_C = 16,                 // 16: NOT & C Pulse			
            HMETHOD_NOT_ONLY = 17,              // 17: NOT Only
            HMETHOD_INPUT_C = 18,               // 18: Input & C Pulse			
            HMETHOD_INPUT_ONLY = 19,            // 19: Input Only

            // 方向
            DIRECTION_POSITIVE = 0,             // 正方向						
            DIRECTION_NEGATIVE = 1,             // 逆方向						

            // 座標系指定
            WORK_SYSTEM = 0,                    //  0: ワーク座標系 Workpiece coordinate system
            MACHINE_SYSTEM = 1,                 //  1: 機械座標系   Machine coordinate system

            // 動作タイプ
            MTYPE_RELATIVE = 0,                 //  0: 増分値指定、直線軸/回転軸共通
            MTYPE_ABSOLUTE = 1,                 //  1: 絶対位置指定、直線軸用
            MTYPE_R_SHORTEST = 2,               //  2: 絶対位置指定、回転軸用（近い方向に回転）
            MTYPE_R_POSITIVE = 3,               //  3: 絶対位置指定、回転軸用（正転）
            MTYPE_R_NEGATIVE = 4,               //  4: 絶対位置指定、回転軸用（逆転）

            // データタイプ
            DTYPE_IMMEDIATE = 0,                // 直接指定
            DTYPE_INDIRECT = 1,                 // 間接指定
            DTYPE_MAX_VELOCITY = 0x1,           // bit0: MaxVelocityについての指定
            DTYPE_ACCELERATION = 0x2,           // bit1: Accelerationについての指定
            DTYPE_DECELERATION = 0x4,           // bit2: Decelerationについての指定
            DTYPE_FILTER_TIME = 0x8,            // bit3: FilterTimeについての指定
            DTYPE_VELOCITY = 0x10,              // bit4: Velocityについての指定
            DTYPE_APPROCH = 0x20,               // bit5: ApproachVelocityについての指定
            DTYPE_CREEP = 0x40,                 // bit6: CreepVelocityについての指定

            // 送り速度タイプ
            VTYPE_UNIT_PAR = 0,                 // 速度[指令単位/sec]
            VTYPE_PERCENT = 1,                  // 定格速度の％指定

            // 加減速タイプ
            ATYPE_UNIT_PAR = 0,                 // 加速度[指令単位/sec^2]
            ATYPE_TIME = 1,                     // 時定数[ms]
            ATYPE_KEEP = 2,                     // 現在の設定を保持

            // フィルタタイプ
            FTYPE_S_CURVE = 0,                  //  0: 移動平均フィルタ（簡易S字）
            FTYPE_EXP = 1,                      //  1: 指数フィルタ
            FTYPE_NOTIONG = 2,                  //  2: フィルタなし
            FTYPE_KEEP = 3,                     //  3: 現在の設定を保持

            // WaitForCompletion 定数定義
            DISTRIBUTION_COMPLETED = 0,         // 払い出し完了
            POSITIONING_COMPLETED = 1,          // 位置決め完了
            COMMAND_STARTED = 2,                // 指令完了
            LATCH_COMMAND_STARTED = 0,          // ラッチ指令開始
            LATCH_COMPLETED = 1,                // ラッチ完了

            // SystemOption 定数定義
            OP_BIT_ALARM_CONTINUE = 0x1,        // bit0: アラーム時、正常な軸の運転を継続

            // ChangeDynamics変更の対象（1:変更する / 0:変更しない）
            SUBJECT_ACC = 0x1,                  // bit0: Acceleration
            SUBJECT_DEC = 0x2,                  // bit1: Deceleration
            SUBJECT_POS = 0x8,                  // bit3: Position
            SUBJECT_VEL = 0x10,                  // bit4: Velocity

            // ServoControlType
            SERVO_OFF = 0x0,                    // サーボOFF
            SERVO_ON = 0x1,                     // サーボON

            // デバイスタイプ
            DEVICETYPE_IO = 1,                  // I/O
            DEVICETYPE_DIRECTIO = 2,            // ダイレクトI/O
            DEVICETYPE_GLOBALDATA = 3,          // グローバルデータ
            DEVICETYPE_REGISTER = 4,            // レジスタ

            // 単位データサイズ(ビット数)
            DATAUNITSIZE_BIT = 1,               // 1 bit
            DATAUNITSIZE_BYTE = 8,              // BYTE = 8 bits
            DATAUNITSIZE_WORD = 16,             // WORD = 16 bits
            DATAUNITSIZE_LONG = 32,             // LONG = 32 bits
            DATAUNITSIZE_FLOAT = 32,            // FLOAT= 32 bits
            DATAUNITSIZE_DOUBLE = 64,           // DOUBLE= 64 bits

            // ComDeviceタイプ
            RS232C_MODE = 1,                    // RS232C
            MODEM_MODE = 2,                     // モデム
            ETHERNET_MODE = 3,                  // Ethernet
            PCI_MODE = 4,                       // PCIバス(910 or 2100)
            CONTROLLER_MODE = 5,                // コントローラ内部

            //アラーム
            MAX_CURRENT_ALARM = 32,             // 一回に取得できる最大ｱﾗｰﾑ情報数
            MAX_DEVICE_AXIS = 32,               // 一回に定義できるデバイスの最大軸数
            MAX_REGISTER_BLOCK = 499,           // 一回に操作できるレジスタの最大ブロック数

            // Gear
            MASTER_AXIS_FEEDBACK = 0,           // フィードバック値
            MASTER_AXIS_COMMAND = 1,            // 指令値

            // Gear 同期タイプ
            SYNCH_DISTANCE = 0,                 // 距離同期
            SYNCH_TIME = 1,                     // 時間同期

            // Gear命令の属性
            GEAR_ENGAGE_COMPLETED = 0,          // GEAR制御開始（Engage完了）
            GEAR_COMMAND_STARTED = 1,           // 指令開始

            // Gearステータスの属性
            GEAR_NOT_ENGAGED = 0,               // GEAR停止中
            GEAR_WAITING_ENGAGED = 1,           // GEAR動作待ち
            GEAR_ENGAGED = 2,                   // GEAR動作中
            GEAR_WAITING_DISENGAGED = 4,        // GEAR停止待ち


            // CAM命令の属性
            CAM_ENGAGE_COMPLETED = 0,           // CAM制御開始
            CAM_SHIFT_COMPLETED = 0,            // CAM位相補正完了

            CAM_DISENGAGE_COMPLETED = 0,        // CAM制御停止
            CAM_COMMAND_STARTED = 1,            // 指令開始

            // Camステータスの属性
            CAM_NOT_ENGAGED = 0,                // CAM停止中
            CAM_WAITING_ENGAGED = 1,            // CAM動作待ち
            CAM_ENGAGED = 2,                    // CAM動作中
            CAM_WAITING_DISENGAGED = 4,         // CAM停止待ち

            // シフトタイプ
            SHIFT_TIME = 0,                     // 時間でシフト
            SHIFT_POSITION = 1,                 // 位置でシフト

            // POSITION命令の属性
            POSITION_OFFSET_COMPLETED = 0,      // 位置補正完了
            POSITION_OFFSET_COMMAND_STARTED = 1,// 指令開始

            // テーブルタイプ
            CAM_TABLE = 2,                      // CAMテーブルのファイル名
            INTERPOLATION_TABLE = 3,            // 補間テーブルのファイル名
            REGISTERHANDLE = 4,                 // レジスタハンドル
            USER_FUNCTION = 5,                  // ユーザー関数
            IK_FUNCTION = 6,                    // IK関数

            // モーションパラメータタイプ
            SETTING_PARAMETER = 0,              // 設定パラメータ
            MONITOR_PARAMETER = 1,              // モニタパラメータ

            // 最大軸数
            MAX_DEVICE_AXIS_NUM = 16,           // 最大デバイス軸数

            // 円弧・ヘリカル補間の円弧種別
            LESS_180DEGREE = 0x1,               // 
            GREATER_180DEGREE = 0x2,            // 

            // 座標系
            COORDINATE_SYSTEM_DEFAULT = 0,      // 
            COORDINATE_SYSTEM_MACHINE = 1,      // 機械座標系
            // モード
            MODE_INCREMENTAL = 0,               // INC
            MODE_ABSOLUTE = 1,                  // ABS

            // 送り速度タイプ
            F_TYPE_COMMAND_UNIT = 0,            // 指令単位/min
            F_TYPE_PARCENT = 1,                 // ％指定

            // 加減速度タイプ
            ACCEL_TYPE_ACCERALATION = 0,        // 加速度
            ACCEL_TYPE_TIME_CONSTANT = 1,       // 時定数
            ACCEL_TYPE_NO_SPECIFY = 2,          // 指定なし

            // UnitType定義
            UNITTYPE_PULSE = 0,                 // パルス
            UNITTYPE_MM = 1,                    // mm
            UNITTYPE_INCH = 2,                  // inch
            UNITTYPE_DEGREE = 3,                // degree

            // データタイプ
            DATATYPE_IMMEDIATE = 0,             // 直接指定
            DATATYPE_INDIRECT = 1,              // 間接指定

            // ComDevice種別
            COMDEVICETYPE_RS232C_MODE = 1,      // RS232C
            COMDEVICETYPE_MODEM_MODE = 2,       // モデム
            COMDEVICETYPE_ETHERNET_MODE = 3,    // Ethernet
            COMDEVICETYPE_PCI_MODE = 4,         // PCIバス(910 or 2100)
            COMDEVICETYPE_PCIe_MODE = 6,        // PCIExpressバス(3100)
            COMDEVICETYPE_CONTROLLER_MODE = 5	// コントローラ内部
        }

        //======================================================
        //                                                      
        //  モーション設定 定義                                 
        //                                                      
        //======================================================
        public enum ApiDefs_SetPrm
        {
            SER_RUNMOD = 1,                     // OWXX00 : 動作モード設定
            SER_SVRUNCMD = 2,                   // OWXX01 : サーボドライブ運転指令設定
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
            SER_NREF = 22,                      // OWXX15 : SPEED REFERENCE:速度指令 
            SER_PHBIAS = 23,                    // OLXX16 : PHASE OFFSET            
            SER_NCOM = 25,                      // OWXX18 : SPEED BIAS REF          
            SER_PV = 26,                        // OWXX19 : PROPORTIONAL_GAIN       
            SER_TI = 27,                        // OWXX1A : TI                      
            SER_TREF = 28,                      // OWXX1B : TORQUE REFERNCE         
            SER_NLIM = 29,                      // OWXX1C : SPEED LIMIT             
            SER_KV = 30,                        // OWXX1D : VELOCITY_GAIN           
            SER_PULBIAS = 31,                   // OLXX1E : PULSE OFFSET            
            SER_MCMDCODE = 33,                  // OWXX20 : モーションコマンドコード 
            SER_MCMDCTRL = 34,                  // OWXX21 : モーションコマンド制御フラグ 
            SER_RV = 35,                        // OLXX22 : 早送り速度　　          
            SER_EXMDIST = 37,                   // OLXX24 : 外部位置決め走行距離    
            SER_STOPDIST = 39,                  // OLXX26 : 停止距離        　　    
            SER_STEP = 41,                      // OLXX28 : ＳＴＥＰ移動量          
            SER_ZRNDIST = 43,                   // OLXX2A : 原点復帰最終走行距離    
            SER_OV = 45,                        // OWXX2C : オーバライド            
            SER_POSCTRL = 46,                   // OWXX2D : 位置管理制御フラグ      
            SER_OFFSET = 47,                    // OLXX2E : ワーク座標系オフセット  
            SER_POSMXTRN = 49,                  // OLXX30 : POSMAXターン数プリセットデータ 
            SER_INPWIDTH = 51,                  // OWXX32 : 第２インポジション幅    
            SER_PSETWIDTH = 52,                 // OWXX33 : 原点位置出力幅          
            SER_PSETTIME = 53,                  // OWXX34 : 位置決め完了チェック時間 
            SER_YENTCN = 54,                    // OWXX35 : YENETサーボユーザ定数NO  
            SER_CNDAT = 55,                     // OLXX36 : YENETサーボユーザ定数設定値 
            SER_EPOSL = 57,                     // OLXX38 : 電源断時のエンコーダ位置　下位 2W 
            SER_EPOSH = 59,                     // OLXX3A : 電源断時のエンコーダ位置　上位 2W 
            SER_APOSL = 61,                     // OLXX3C : 電源断時のPULSE絶対位置　 下位 2W
            SER_APOSH = 63                      // OLXX3E : 電源断時のPULSE絶対位置　 上位 2W
        }

        //======================================================
        //                                                      
        //  モーションモニタ 定義                               
        //                                                      
        //======================================================
        public enum ApiDefs_MonPrm
        {
            SER_RUNSTS = 0,                 	// IWxx00 : 運転ステータス
            SER_ERNO = 1,                       // IWxx01 : 範囲オーバー発生パラメータNo
            SER_WARNING = 2,                    // ILxx02 : ワーニング
            SER_ALARM = 4,                      // ILxx04 : アラーム
            SER_MCMDRCODE = 8,                  // IWxx08 : モーションコマンドレスポンスコード
            SER_MCMDSTS = 9,                    // IWxx09 : モーションコマンドステータス
            SER_SUBCMD = 10,                    // IWxx0A : サブコマンドレスポンス
            SER_SUBSTS = 11,                    // IWxx0B : サブコマンドコマンドステータス
            SER_POSSTS = 12,                    // IWxx0C : 位置管理ステータス
            SER_TPOS = 14,                      // ILxx0E : 機械座標系目標位置(TPOS)
            SER_CPOS = 16,                      // ILxx10 : 機械座標系位置計算(CPOS)
            SER_MPOS = 18,                      // ILxx12 : 機械座標系指令位置(MPOS)
            SER_DPOS = 20,                      // ILxx14 : 32bit座標系指令位置(DPOS)
            SER_APOS = 22,                      // ILxx16 : 機械座標系フィードバック位置(APOS)
            SER_LPOS = 24,                      // ILxx18 : 機械座標系ラッチ位置 (LPOS)
            SER_PERR = 26,                      // ILxx1A : 位置偏差
            SER_PDV = 28,                       // ILxx1C : 目標位置増分値モニタ
            SER_PMAXTURN = 30,                  // ILxx1E : POSMAXターン数
            SER_SPDREF = 32,                    // ILxx20 : 速度指令出力値モニタ
            SER_XREFMON = 34,                   // ILxx22 : 位置指令出力モニタ
            SER_YIMON = 36,                     // IWxx24 : 積分値出力値モニタ
            SER_LAGMON = 38,                    // ILxx26 : 一次遅れモニタ
            SER_PIMON = 40,                     // ILxx28 : 位置ループ出力値モニタ
            SER_SVSTS = 44,                     // IWxx2C : サーボドライバステータス（機種に依存）
            SER_SVALARM = 45,                   // IWxx2D : サーボドライバALARMコード
            SER_SVIOMON = 46,                   // IWxx2E : サーボドライバI/Oモニタ
            SER_MUSRMONSEL = 47,                // IWxx2F : サーボドライバユーザモニタ情報
            SER_USRMON2 = 48,                   // ILxx30 : サーボドライバユーザモニタ2
            SER_USRMON3 = 50,                   // ILxx32 : サーボドライバユーザモニタ3
            SER_USRMON4 = 52,                   // ILxx34 : サーボドライバユーザモニタ4
            SER_MCNNO = 54,                     // IWxx36 : サーボドライバユーザ定数NO
            SER_MSUBCNNO = 55,                  // IWxx37 : 補助サーボドライバユーザ定数NO
            SER_MCNDAT = 56,                    // ILxx38 : サーボドライバユーザ定数読み出しデータ
            SER_MSUBCNDAT = 58,                 // ILxx3A : 補助サーボドライバユーザ定数読み出しデータ
            SER_SANS = 60,                      // IWxx3C : シリアルコマンド アンサモニタ
            SER_MSADR = 61,                     // IWxx3D : シリアルコマンド アドレスモニタ
            SER_MSDAT = 62,                     // IWxx3E : シリアルコマンド データモニタ
            SER_MOTERTYPE = 63,                 // IWxx3F : シリアルコマンド データモニタ
            SER_FSPD = 64,                      // ILxx40 : フィードバック速度 ［指令単位/sec］、［10^n 指令単位/min］、［0.01 ％]
            SER_TRQ = 66,                       // ILxx42 : トルク指令モニタ    [0.01 ％]  
            SER_ABSREV = 74,                    // ILxx4A : 絶対位置ｴﾝｺｰﾀﾞより受信した累積回転数
            SER_IPULSE = 76,                    // ILxx4C : 初期インクレメンタルパルス数［pulse］
            SER_FIXPRMMON = 86,                 // ILxx56 : 固定パラメータモニタ
            SER_DI = 88,                        // IWxx58 : 汎用DIモニタ
            SER_AI1 = 89,                       // IWxx59 : 汎用AIモニタ        ［0.001 V］
            SER_AI2 = 90,                       // IWxx5A : 汎用AIモニタ        ［0.001 V］
            SER_MEPOSML = 94,                   // ILxx5E : 電源断時のｴﾝｺｰﾀﾞ位置下位2word
            SER_MEPOSMH = 96,                   // ILxx60 : 電源断時のｴﾝｺｰﾀﾞ位置上位2word
            SER_MAPOSML = 98,                   // ILxx62 : 電源断時のPLUSE絶対位置下位2word
            SER_MAPOSMH = 100,                  // ILxx64 : 電源断時のPLUSE絶対位置上位2word
            SER_MONSTS = 102,                   // ILxx66 : モニタデータステータス
            SER_MONDATA = 104                   // ILxx68 : 読み出しデータ
        }
    }
}