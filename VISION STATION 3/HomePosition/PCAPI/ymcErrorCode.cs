//===========================================================
//
// ymcPCAPI.Dll 用　エラーコード定数定義モジュール ＜ymcErrorCode.cs＞
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
    public const UInt32 MP_SUCCESS                          = 0x00000000;	/*	API関数 正常終了									*/
																		    /*	API function normal completion						*/
    public const UInt32 MP_FAIL 							= 0x4000FFFF;   /*	API関数 異常終了									*/
																		    /*	API function erroneous completion					*/
    public const UInt32 WDT_OVER_ERR 						= 0x81000001;   /*														*/
																		    /*														*/
    public const UInt32 MANUAL_RESET_ERR 					= 0x82000020;   /*	Manual reset error									*/
																			/*														*/
    public const UInt32 TLB_MLTHIT_ERR 						= 0x82000140;   /*	TLB multi hit error									*/
																		    /*														*/
    public const UInt32 UBRK_ERR 							= 0x820001E0;   /*	User break execution error							*/
																		    /*														*/
    public const UInt32 ADR_RD_ERR 							= 0x820000E0;   /*	Address read error error							*/
																			/*														*/
    public const UInt32 TLB_MIS_RD_ERR 						= 0x82000040;   /*	TLB read mis error									*/
																		    /*														*/
    public const UInt32 TLB_PROTECTION_RD_ERR 				= 0x820000A0;   /*	TLB protection read vaiolation error				*/
																		    /*														*/
    public const UInt32 GENERAL_INVALID_INS_ERR 			= 0x82000180;   /*	General invalid instruction error					*/
																		    /*														*/
    public const UInt32 SLOT_ERR 							= 0x820001A0;   /*	Slot invalid instruction error						*/
																		    /*														*/
    public const UInt32 GENERAL_FPU_DISABLE_ERR 			= 0x82000800;   /*	General FPU disable error							*/
																		    /*														*/
    public const UInt32 SLOT_FPU_ERR 						= 0x82000820;   /*	Slot FPU exception error							*/
																		    /*														*/
    public const UInt32 ADR_WR_ERR 							= 0x82000100;   /*	Data address write error error						*/
																			/*														*/
    public const UInt32 TLB_MIS_WR_ERR 						= 0x82000060;   /*	TLB write mis error									*/
																		    /*														*/
    public const UInt32 TLB_PROTECTION_WR_ERR 				= 0x820000C0;   /*	TLB protection write vaiolation error				*/
																		    /*														*/
    public const UInt32 FPU_EXP_ERR 						= 0x82000120;   /*	FPU exception error									*/
																		    /*														*/
    public const UInt32 INITIAL_PAGE_EXP_ERR 				= 0x82000080;   /*	Initial page write exception error					*/
																		    /*														*/
    public const UInt32 ROM_ERR 							= 0x81000041;   /*	ROM  error											*/
																		    /*														*/
    public const UInt32 RAM_ERR 							= 0x81000042;   /*	RAM  error											*/
																		    /*														*/
    public const UInt32 MPU_ERR 							= 0x81000043;   /*	CPU  error											*/
																		    /*														*/
    public const UInt32 FPU_ERR 							= 0x81000044;   /*	FPU  error											*/
																		    /*														*/
    public const UInt32 CERF_ERR 							= 0x81000049;   /*	CERF error											*/
																		    /*														*/
    public const UInt32 EXIO_ERR 							= 0x81000050;   /*	EXIO error											*/
																		    /*														*/
    public const UInt32 BUSIF_ERR 							= 0x8100005F;   /*	Common RAM error for OEM							*/
																		    /*														*/
    public const UInt32 ALM_NO_ALM 							= 0x00000000;   /*	アラームなし状態																					*/
																		    /*	No alarm																							*/
    public const UInt32 ALM_MK_DEBUG 						= 0x67050300;   /*	軽故障	デバッグ用アラームコード																	*/
																		    /*	Minor failure: Alarm code for debugging																*/
    public const UInt32 ALM_MK_ROUND_ERR 					= 0x67050301;   /*	軽故障	半径指定で1周円エラー																		*/
																		    /*	Minor failure: Improper specification of one cycle at radius specification							*/
    public const UInt32 ALM_MK_FSPEED_OVER 					= 0x67050302;   /*	軽故障	送り速度オーバー																			*/
																		    /*	Minor failure: Feeding speed exceeded																*/
    public const UInt32 ALM_MK_FSPEED_NOSPEC 				= 0x67050303;   /*	軽故障	送り速度指定無し																			*/
																		    /*	Minor failure: Feeding speed not specified															*/
    public const UInt32 ALM_MK_PRM_OVER 					= 0x67050304;   /*	軽故障	加減速パラメータの変換後の値が範囲外														*/
																		    /*	Minor failure: Value after conversion of acceleration or deceleration parameter is out of range.	*/
    public const UInt32 ALM_MK_ARCLEN_OVER 					= 0x67050305;   /*	軽故障	弧の長さがLONG_MAXを超えた																	*/
																		    /*	Minor failure: Arc length exceeds LONG_MAX.															*/
    public const UInt32 ALM_MK_VERT_NOSPEC 					= 0x67050306;   /*	軽故障	平面指定の縦軸指定無し																		*/
																		    /*	Minor failure: Vertical axis by plane specification not specified									*/
    public const UInt32 ALM_MK_HORZ_NOSPEC 					= 0x67050307;   /*	軽故障	平面指定の横軸指定無し																		*/
																		    /*	Minor failure: Horizontal axis by plane specification not specified									*/
    public const UInt32 ALM_MK_TURN_OVER 					= 0x67050308;   /*	軽故障	ターン数指定オーバー																		*/
																		    /*	Minor failure: Specified number of turns exceeded													*/
    public const UInt32 ALM_MK_RADIUS_OVER 					= 0x67050309;   /*	軽故障	半径がLONG_MAXを超えた																		*/
																		    /*	Minor failure: Radius exceeds LONG_MAX.																*/
    public const UInt32 ALM_MK_CENTER_ERR 					= 0x6705030A;   /*	軽故障	中心点指定エラー																			*/
																		    /*	Minor failure: Illegal center point specification													*/
    public const UInt32 ALM_MK_BLOCK_OVER 					= 0x6705030B;   /*	軽故障	直線補間block移動量オーバー																	*/
																		    /*	Minor failure: Linear interpolation block moving amount exceeded									*/
    public const UInt32 ALM_MK_MAXF_NOSPEC 					= 0x6705030C;   /*	軽故障	maxf未定義																					*/
																		    /*	Minor failure: maxf not defined																		*/
    public const UInt32 ALM_MK_TDATA_ERR 					= 0x6705030D;   /*	軽故障	アドレスTデータエラー																		*/
																		    /*	Minor failure: Address T data error																	*/
    public const UInt32 ALM_MK_REG_ERR 						= 0x6705030E;   /*	軽故障	REGデータエラー PP異常																		*/
																		    /*	Minor failure: REG data error and PP fault															*/
    public const UInt32 ALM_MK_COMMAND_CODE_ERR 			= 0x6705030F;   /*	軽故障	コマンド範囲外																				*/
																		    /*	Minor failure: Out-of-range command																	*/
    public const UInt32 ALM_MK_AXIS_CONFLICT 				= 0x67050310;   /*	軽故障	論理軸使用禁止中																			*/
																		    /*	Minor failure: Use of logical axis being prohibited													*/
    public const UInt32 ALM_MK_POSMAX_OVER 					= 0x67050311;   /*	軽故障	無限長軸、MVMまたはABSの座標指定がPOSMAXを超えた											*/
																		    /*	Minor failure: Infinite length axis, MVM or ABS coordinate designation exceeds POSMAX.				*/
    public const UInt32 ALM_MK_DIST_OVER 					= 0x67050312;   /*	軽故障	軸の移動距離が(LONG_MIN,LONG_MAX)以外														*/
																		    /*	Minor failure: Axis moving distance is other than (LONG_MIN, LONG_MAX).								*/
    public const UInt32 ALM_MK_MODE_ERR 					= 0x67050313;   /*	軽故障	制御モード不正																				*/
																		    /*	Minor failure: Illegal control mode																	*/
    public const UInt32 ALM_MK_CMD_CONFLICT 				= 0x67050314;   /*	軽故障	モーションコマンド重複指令																	*/
																		    /*	Minor failure: Motion command overlapping instruction												*/
    public const UInt32 ALM_MK_RCMD_CONFLICT 				= 0x67050315;   /*	軽故障	モーションレスポンスコマンド重複指令														*/
																		    /*	Minor failure: Motion response command overlapping instruction										*/
    public const UInt32 ALM_MK_CMD_MODE_ERR 				= 0x67050316;   /*	軽故障	モーションコマンドモード不正																*/
																		    /*	Minor failure: Illegal motion command mode															*/
    public const UInt32 ALM_MK_CMD_NOT_ALLOW 				= 0x67050317;   /*	軽故障	コマンドはこのモジュールでは実行できない													*/
																		    /*	Minor failure: Command cannot be executed ih this Module.											*/
    public const UInt32 ALM_MK_CMD_DEN_FAIL 				= 0x67050318;   /*	軽故障	払い出し完了状態でない																		*/
																		    /*	Minor failure: Distribution is not completed.														*/
    public const UInt32 ALM_MK_H_MOVE_ERR 					= 0x67050319;   /*	軽故障	hMove不正																					*/
																		    /*	Minor failure: Illegal hMove																		*/
    public const UInt32 ALM_MK_MOVE_NOT_SUPPORT 			= 0x6705031A;   /*	軽故障	未サポートのMoveの定義																		*/
																		    /*	Minor failure: Non-supported Move defined															*/
    public const UInt32 ALM_MK_EVENT_NOT_SUPPORT 			= 0x6705031B;   /*	軽故障	未サポートのMove Eventの定義																*/
																		    /*	Minor failure: Non-supported Move Event defined														*/
    public const UInt32 ALM_MK_ACTION_NOT_SUPPORT 			= 0x6705031C;   /*	軽故障	未サポートのMove Actionの定義																*/
																		    /*	Minor failure: Non-supported Move Action defined													*/
    public const UInt32 ALM_MK_MOVE_TYPE_ERR 				= 0x6705031D;   /*	軽故障	MoveType指定エラー																			*/
																		    /*	Minor failure: MoveType specification error															*/
    public const UInt32 ALM_MK_VTYPE_ERR 					= 0x6705031E;   /*	軽故障	VelocityType指定エラー																		*/
																		    /*	Minor failure: VelocityType specification error														*/
    public const UInt32 ALM_MK_ATYPE_ERR 					= 0x6705031F;   /*	軽故障	AccelerationType指定エラー																	*/
																		    /*	Minor failure: AccelerationType specification error													*/
    public const UInt32 ALM_MK_HOMING_METHOD_ERR 			= 0x67050320;   /*	軽故障	homing_method指定エラー																		*/
																		    /*	Minor failure: Homing_method specification error													*/
    public const UInt32 ALM_MK_ACC_ERR 						= 0x67050321;   /*	軽故障	加速度設定エラー																			*/
																		    /*	Minor failure: Acceleration setting error															*/
    public const UInt32 ALM_MK_DEC_ERR 						= 0x67050322;   /*	軽故障	減速度設定エラー																			*/
																		    /*	Minor failure: Deceleration setting error															*/
    public const UInt32 ALM_MK_POS_TYPE_ERR 				= 0x67050323;   /*	軽故障	位置指令タイプエラー																		*/
																		    /*	Minor failure: Position reference type error														*/
    public const UInt32 ALM_MK_INVALID_EVENT_ERR 			= 0x67050324;   /*	軽故障	不正EVENTタイプエラー																		*/
																		    /*	Minor failure: Illegal EVENT type																	*/
    public const UInt32 ALM_MK_INVALID_ACTION_ERR 			= 0x67050325;   /*	軽故障	不正ACTIONタイプエラー																		*/
																		    /*	Minor failure: Illegal ACTION type																	*/
    public const UInt32 ALM_MK_MOVE_NOT_ACTIVE 				= 0x67050326;   /*	軽故障	未実行のMoveに対するAction																	*/
																		    /*	Minor failure: Action for Move that has not been executed											*/
    public const UInt32 ALM_MK_MOVELIST_NOT_ACTIVE 			= 0x67050327;   /*	軽故障	未実行のMoveListに対するAction																*/
																		    /*	Minor failure: Action for MoveList that has not been executed										*/
    public const UInt32 ALM_MK_TBL_INVALID_DATA 			= 0x67050328;   /*	軽故障	テーブルデータ不正エラー																	*/
																		    /*	Minor failure: Illegal table data																	*/
    public const UInt32 ALM_MK_TBL_INVALID_SEG_NUM 			= 0x67050329;   /*	軽故障	テーブル補間 実行セグメント数不正															*/
																		    /*	Minor failure: Illegal number of table interpolation execution segments								*/
    public const UInt32 ALM_MK_TBL_INVALID_AXIS_NUM 		= 0x6705032A;   /*	軽故障	テーブル補間 軸数指定エラー																	*/
																		    /*	Minor failure: Illegal number of table interpolation axes specified									*/
    public const UInt32 ALM_MK_TBL_INVALID_ST_SEG 			= 0x6705032B;   /*	軽故障	テーブル補間 開始セグメントNo不正															*/
																		    /*	Minor failure: Illegal table interpolation starting segment number									*/
    public const UInt32 ALM_MK_STBL_INVALID_EXE 			= 0x6705032C;   /*	軽故障	Static tableテーブル ファイル書き込み中の実行エラー											*/
																		    /*	Minor failure: Execution error during Static table file being written								*/
    public const UInt32 ALM_MK_DTBL_DUPLICATE_EXE 			= 0x6705032D;   /*	軽故障	Dynamic tableテーブル ２重実行エラー														*/
																		    /*	Minor failure: Dynamic table duplicated execution error												*/
    public const UInt32 ALM_MK_LATCH_CONFLICT 				= 0x6705032E;   /*	軽故障	LATCH要求重複指令エラー																		*/
																		    /*	Minor failure: LATCH request overlapping instruction error											*/
    public const UInt32 ALM_MK_INVALID_AXISTYPE 			= 0x6705032F;   /*	軽故障	軸タイプ（有限長軸/無限長軸）不正															*/
																		    /*	Minor failure: Illegal axis type (finite length axis/inifinite length axis)							*/
    public const UInt32 ALM_MK_NOT_SVCRDY 					= 0x67050330;   /*	軽故障	モーションドライバ運転準備未完状態でのMoveオブジェクト実行									*/
																		    /*	Minor failure: Move object executed when Motion Driver operation is not ready						*/
    public const UInt32 ALM_MK_NOT_SVCRUN 					= 0x67050331;   /*	軽故障	サーボ電源未完状態でのMoveオブジェクト実行													*/
																		    /*	Minor failure: Move object executed at servo OFF													*/
    public const UInt32 ALM_MK_MDALARM 						= 0x67050332;   /*	軽故障	モーションドライバアラーム状態でのMoveオブジェクト実行										*/
																		    /*	Minor failure: Move object executed at occurrence of Motion Driver alarm							*/
    public const UInt32 ALM_MK_SUPERPOSE_MASTER_ERR 		= 0x67050333;   /*	軽故障	払い出し合成オブジェクトマスタ軸条件エラー													*/
																		    /*	Minor failure: Distribution synthetic object master axis condition error							*/
    public const UInt32 ALM_MK_SUPERPOSE_SLAVE_ERR 			= 0x67050334;   /*	軽故障	払い出し合成オブジェクトスレーブ軸条件エラー												*/
																		    /*	Minor failure: Distribution synthetic object slave axis condition error								*/
    public const UInt32 ALM_MK_MDWARNING 					= 0x57050335;   /*	ﾜｰﾆﾝｸﾞ	モーションドライバワーニング																*/
																		    /*	Warning: Motion Driver warning																		*/
    public const UInt32 ALM_MK_MDWARNING_POSERR 			= 0x57050336;   /*	ﾜｰﾆﾝｸﾞ	モーションドライバ偏差ワーニング															*/
																		    /*	Warning: Motion Driver deviation warning															*/
    public const UInt32 ALM_MK_NOT_INFINITE_ABS 			= 0x67050337;   /*	軽故障	指定された軸はABS無限長軸として使用可能ではない												*/
																		    /*	Minor failure: Specified axis cannot be used as ABS infinite length axis.							*/
    public const UInt32 ALM_MK_INVALID_LOGICAL_NUM 			= 0x67050338;   /*	軽故障	不正な論理軸番号が指定された																*/
																		    /*	Minor failure: Illegal logical axis number has been specified.										*/
    public const UInt32 ALM_MK_MAX_VELOCITY_ERR 			= 0x67050339;   /*	軽故障	最高速度設定エラー																			*/
																		    /*	Minor failure: Maximum speed setting error															*/
    public const UInt32 ALM_MK_VELOCITY_ERR 				= 0x6705033A;   /*	軽故障	速度設定エラー																				*/
																		    /*	Minor failure: Speed setting error																	*/
    public const UInt32 ALM_MK_APPROACH_ERR 				= 0x6705033B;   /*	軽故障	アプローチ速度設定エラー																	*/
																		    /*	Minor failure: Approach speed setting error															*/
    public const UInt32 ALM_MK_CREEP_ERR 					= 0x6705033C;   /*	軽故障	クリープ速度設定エラー																		*/
																		    /*	Minor failure: Creep speed setting error															*/
    public const UInt32 ALM_MK_OS_ERR_MBOX1 				= 0x83050340;   /*	重故障	メイルボックス生成エラー（モーションカーネル Moveオブジェクト実行要求用メイルボックス）		*/
																		    /*	Major failure: Mail box creation error (mail box for request for Motion Kernel Move object execution)*/
    public const UInt32 ALM_MK_OS_ERR_MBOX2 				= 0x83050341;   /*	重故障	メイルボックス生成エラー（モーションカーネル アクション実行要求用メイルボックス）			*/
																		    /*	Major failure: Mail box creation error (mail box for request for Motion Kernel action execution)	*/
    public const UInt32 ALM_MK_OS_ERR_SEND_MSG1 			= 0x83050342;   /*	重故障	OSレベルでのメッセージ送信異常（MK→EM：イベント検出通知）									*/
																		    /*	Major failure: Message sending error at OS level (MK to EM: Notification of event detection)		*/
    public const UInt32 ALM_MK_OS_ERR_SEND_MSG2 			= 0x83050343;   /*	重故障	OSレベルでのメッセージ送信異常（MK→MM：Move完了メッセージ）								*/
																		    /*	Major failure: Message sending error at OS level (MK to MM: Move completion message)				*/
    public const UInt32 ALM_MK_OS_ERR_SEND_MSG3 			= 0x83050344;   /*	重故障	OSレベルでのメッセージ送信異常（EM→MM：Aciton通知）										*/
																		    /*	Major failure: Message sending error at OS level (EM to MM: Notification of Action)					*/
    public const UInt32 ALM_MK_OS_ERR_SEND_MSG4 			= 0x83050345;   /*	重故障	OSレベルでのメッセージ送信異常（その他）													*/
																		    /*	Major failure: Message sending error at OS level (Others)											*/
    public const UInt32 ALM_MK_ACTION_ERR1 					= 0x53050346;   /*	ﾜｰﾆﾝｸﾞ	不正応答メッセージ受信（アクション実行完了通知の応答待ち状態へのアクション実行要求）		*/
																		    /*	Warning: Illegal response message received (action execution request to waiting status for response of notification of action execution completion)	*/
    public const UInt32 ALM_MK_ACTION_ERR2 					= 0x53050347;   /*	ﾜｰﾆﾝｸﾞ	不正応答メッセージ受信（現在実行中のMoveオブジェクトへのアクションではない）				*/
																		    /*	Warning: Illegal response message received(not an action for Move object currently executed)		*/
    public const UInt32 ALM_MK_ACTION_ERR3 					= 0x53050348;   /*	ﾜｰﾆﾝｸﾞ	不正応答メッセージ受信（現在実行中のMoveLISTオブジェクトへのアクションではない）			*/
																		    /*	Warning: Illegal response message received (not an action for MoveLIST object currently executed)	*/
    public const UInt32 ALM_MK_RCV_INV_MSG1 				= 0x53050349;   /*	ﾜｰﾆﾝｸﾞ	不正指令メッセージ受信（MOVEオブジェクトハンドルではない）									*/
																		    /*	Warning: Illegal command message received (not a MOVE object handle)								*/
    public const UInt32 ALM_MK_RCV_INV_MSG2 				= 0x5305034A;   /*	ﾜｰﾆﾝｸﾞ	不正指令メッセージ受信（モーションマネージャ以外からの指令）								*/
																		    /*	Warning: Illegal command message received (command from other than Motion Manager)					*/
    public const UInt32 ALM_MK_RCV_INV_MSG3 				= 0x5305034B;   /*	ﾜｰﾆﾝｸﾞ	不正指令メッセージ受信（指令メッセージではない）											*/
																		    /*	Warning: Illegal command message received (not a command message)									*/
    public const UInt32 ALM_MK_RCV_INV_MSG4 				= 0x5305034C;   /*	ﾜｰﾆﾝｸﾞ	不正指令メッセージ受信（指令／応答以外のメッセージ）										*/
																		    /*	Warning: Illegal command message received (message other than command/response)						*/
    public const UInt32 ALM_MK_RCV_INV_MSG5 				= 0x5305034D;   /*	ﾜｰﾆﾝｸﾞ	不正指令メッセージ受信（イベントマネージャ以外からの指令メッセージ）						*/
																		    /*	Warning: Illegal command message received (command message from other than Event Manager)			*/
    public const UInt32 ALM_MK_RCV_INV_MSG6 				= 0x5305034E;   /*	ﾜｰﾆﾝｸﾞ	不正指令メッセージ受信（アクション実行要求ではない指令メッセージ）							*/
																		    /*	Warning: Illegal command message received (command message other than request for action execution)	*/
    public const UInt32 ALM_MK_RCV_INV_MSG7 				= 0x5305034F;   /*	ﾜｰﾆﾝｸﾞ	不正応答メッセージ受信（イベントマネージャ以外からの応答メッセージ）						*/
																		    /*	Warning: Illegal response message received (response message from other than Event Manager)			*/
    public const UInt32 ALM_MK_RCV_INV_MSG8 				= 0x53050350;   /*	ﾜｰﾆﾝｸﾞ	不正応答メッセージ受信（イベント通知完了応答/アクション完了通知応答以外の応答メッセージ）	*/
																		    /*	Warning: Illegal response message received (response message other than event notification completion/action completion notification)	*/
    public const UInt32 ALM_MK_AXIS_HANDLE_ERROR 			= 0x67050360;   /*	軽故障	軸ハンドル番号が異常																		*/
																		    /*	Minor failure: Axis handle number is incorrect.														*/
    public const UInt32 ALM_MK_SLAVE_USED_AS_MASTER 		= 0x67050361;   /*	軽故障	スレーブ軸をマスタ軸として使用しようとした													*/
																		    /*	Minor failure: An attempt was made to use a slave axis as a master axis.							*/
    public const UInt32 ALM_MK_MASTER_USED_AS_SLAVE 		= 0x67050362;   /*	軽故障	マスタ軸をスレーブ軸として使用しようとした													*/
																		    /*	Minor failure: An attempt was made to use a master axis as a slave axis.							*/
    public const UInt32 ALM_MK_SLAVE_HAS_2_MASTERS 			= 0x67050363;   /*	軽故障	同じスレーブ軸に２つ以上のマスタ軸を指定した												*/
																		    /*	Minor failure: More than two master axes were specified for the same slave axis.					*/
    public const UInt32 ALM_MK_SLAVE_HAS_NOT_WORK 			= 0x67050364;   /*	軽故障	スレーブ軸のワークメモリが確保できない														*/
																		    /*	Minor failure: Work axis cannot be assured for a slave axis.										*/
    public const UInt32 ALM_MK_PARAM_OUT_OF_RANGE 			= 0x67050365;   /*	軽故障	パラメータは範囲外																			*/
																		    /*	Minor failure: Parameter is out of range.															*/
    public const UInt32 ALM_MK_NNUM_MAX_OVER 				= 0x67050366;   /*	軽故障	平均化回数最大値オーバー																	*/
																		    /*	Minor failure: Maximum number of averaging times exceeded											*/
    public const UInt32 ALM_MK_FGNTBL_INVALID 				= 0x67050367;   /*	軽故障	FGN テーブルの内容が不正																	*/
																		    /*	Minor failure: Contents of the FGN table are illegal.												*/
    public const UInt32 ALM_MK_PARAM_OVERFLOW 				= 0x67050368;   /*	軽故障	設定値はオーバーフロー																		*/
																		    /*	Minor failure: Set value overflows.																	*/
    public const UInt32 ALM_MK_ALREADY_COMMANDED 			= 0x67050369;   /*	軽故障	CAM または GEAR はすでに実行中																*/
																		    /*	Minor failure: CAM or GEAR has already been under execution.										*/
    public const UInt32 ALM_MK_MULTIPLE_SHIFTS 				= 0x6705036A;   /*	軽故障	Position Offset/Cam Shift 実行中に Position Offset/Cam Shift を実行した						*/
																		    /*	Minor failure: Position Offset/Cam Shift was executed during execution of Position Offset/Cam Shift.*/
    public const UInt32 ALM_MK_CAMTBL_INVALID 				= 0x6705036B;   /*	軽故障	CAM テーブルが不正（アドレス、内容など）													*/
																		    /*	Minor failure: CAM table is illegal (address, contents, etc.).										*/
    public const UInt32 ALM_MK_ABORTED_BY_STOPMTN 			= 0x6705036C;   /*	軽故障	STOP MOTION 等によって CAM/GEAR 動作がアボートされた										*/
																		    /*	Minor failure: CAM/GEAR is aborted by STOP MOTION, etc.												*/
    public const UInt32 ALM_MK_HMETHOD_INVALID 				= 0x6705036D;   /*	軽故障	未サポートの原点復帰方式																	*/
																		    /*	Minor failure: Non-supported zero point return method												*/
    public const UInt32 ALM_MK_MASTER_INVALID 				= 0x6705036E;   /*	軽故障	マスタ軸がモニタ用として指定されていない													*/
																		    /*	Minor failure: Master axis is not specified for monitoring.											*/
    public const UInt32 ALM_MK_DATA_HANDLE_INVALID 			= 0x6705036F;   /*	軽故障	レジスタ／グローバルデータハンドルが不正													*/
																		    /*	Minor failure: Register/global data handle is illegal.												*/
    public const UInt32 ALM_MK_UNKNOWN_CAM_GEAR_ERR 		= 0x67050370;   /*	軽故障	CAM/GEAR 関連の不明なエラー																	*/
																		    /*	Minor failure: Unclear error related to CAM/GEAR													*/
    public const UInt32 ALM_MK_REG_SIZE_INVALID 			= 0x67050371;   /*	軽故障	レジスタハンドルのサイズが不正																*/
																		    /*	Minor failure: Register handle size is illegal.														*/
    public const UInt32 ALM_MK_ACTION_HANDLE_ERROR 			= 0x67050372;   /*	軽故障	アクションハンドルが不正																	*/
																		    /*	Minor failure: Action handle is illegal.															*/
    public const UInt32 ALM_MM_OS_ERR_MBOX1 				= 0x83040380;   /*	重故障	メイルボックス生成エラー（モーションマネージャ 起動用メイルボックス）						*/
																		    /*	Major failure: Mail box creation error (mail box to start up Motion Manager)						*/
    public const UInt32 ALM_MM_OS_ERR_SEND_MSG1 			= 0x83040381;   /*	重故障	OSレベルでのメッセージ送信異常（モーションマネージャ→モーションカーネル）					*/
																		    /*	Major failure: Message sending error at OS level (Motion Manager to Motion Kernel)					*/
    public const UInt32 ALM_MM_OS_ERR_SEND_MSG2 			= 0x83040382;   /*	重故障	OSレベルでのメッセージ送信異常（モーションマネージャ→イベントマネージャ）					*/
																		    /*	Major failure: Message sending error at OS level (Motion Manager to Event Manager)					*/
    public const UInt32 ALM_MM_OS_ERR_RCV_MSG1 				= 0x83040383;   /*	重故障	OSレベルでのメッセージ受信異常																*/
																		    /*	Major failure: Message receiving error at OS level													*/
    public const UInt32 ALM_MM_MK_BUSY 						= 0x67040384;   /*	軽故障	モーションカーネルが全て使用中																*/
																		    /*	Minor failure: All Motion Kernels are in use.														*/
    public const UInt32 ALM_MM_RCV_INV_MSG1 				= 0x53040385;   /*	ﾜｰﾆﾝｸﾞ	不正指令メッセージ受信（ハンドル不正１：hMOVEではない）										*/
																		    /*	Warning: Illegal command message received (illegal handle 1: Not hMOVE.)							*/
    public const UInt32 ALM_MM_RCV_INV_MSG2 				= 0x53040386;   /*	ﾜｰﾆﾝｸﾞ	不正指令メッセージ受信（ハンドル不正２：hMOVEが存在しない）									*/
																		    /*	Warning: Illegal command message received (illegal handle 2: hMOVE does not exist.)					*/
    public const UInt32 ALM_MM_RCV_INV_MSG3 				= 0x53040387;   /*	ﾜｰﾆﾝｸﾞ	不正指令メッセージ受信（スタートアクション実行要求ではない）								*/
																		    /*	Warning: Illegal command message received (Not request for start action execution)					*/
    public const UInt32 ALM_MM_RCV_INV_MSG4 				= 0x53040388;   /*	ﾜｰﾆﾝｸﾞ	不正応答メッセージ受信（イベント通知完了応答以外の応答メッセージ）							*/
																		    /*	Warning: Illegal response message received (response message other than event notification completion)	*/
    public const UInt32 ALM_MM_RCV_INV_MSG5 				= 0x53040389;   /*	ﾜｰﾆﾝｸﾞ	不正応答メッセージ受信（アクション完了応答メッセージでその他のメッセージを受信）			*/
																		    /*	Warning: Illegal response message received (Other messages received with action completion response message)	*/
    public const UInt32 ALM_IM_DEVICEID_ERR 				= 0x53060480;   /*	DeviceID異常またはそのDeviceが未サポート			*/
																		    /*	DeviceID error or non-supported Device				*/
    public const UInt32 ALM_IM_REGHANDLE_ERR 				= 0x53060481;   /*	レジスタハンドル異常								*/
																		    /*	Register handle error								*/
    public const UInt32 ALM_IM_GLOBALHANDLE_ERR 			= 0x53060482;   /*	グローバルデータハンドル異常						*/
																		    /*	Global data handle error							*/
    public const UInt32 ALM_IM_DEVICETYPE_ERR 				= 0x53060483;   /*	データタイプが未サポート							*/
																		    /*	Non-supported data type								*/
    public const UInt32 ALM_IM_OFFSET_ERR 					= 0x53060484;   /*	オフセット値異常									*/
																		    /*	Incorrect offset value								*/
    public const UInt32 AM_ER_UNDEF_COMMAND 				= 0x57020501;   /*	コマンドコード不正									*/
																		    /*	Illegal command code								*/
    public const UInt32 AM_ER_UNDEF_CMNDTYPE 				= 0x57020502;   /*	コマンド種別不正									*/
																		    /*	Illegal command type								*/
    public const UInt32 AM_ER_UNDEF_OBJTYPE 				= 0x57020503;   /*	オブジェクトタイプ不正								*/
																		    /*	Illegal object type									*/
    public const UInt32 AM_ER_UNDEF_HANDLETYPE 				= 0x57020504;   /*	ハンドル種別不正									*/
																		    /*	Illegal handle type									*/
    public const UInt32 AM_ER_UNDEF_PKTDAT 					= 0x57020505;   /*	パケットデータ不正									*/
																		    /*	Illegal packet data									*/
    public const UInt32 AM_ER_UNDEF_AXIS 					= 0x57020506;   /*	軸未定義											*/
																		    /*	axis not defined									*/
    public const UInt32 AM_ER_MSGBUF_GET_FAULT 				= 0x57020510;   /*	メッセージバッファ管理テーブル取得失敗				*/
																		    /*	Acquisition failure of  message buffer managed table*/
    public const UInt32 AM_ER_ACTSIZE_GET_FAULT 			= 0x57020511;   /*	ACTサイズ取得失敗									*/
																		    /*	Acquisition failure of ACT size						*/
    public const UInt32 AM_ER_APIBUF_GET_FAULT 				= 0x57020512;   /*	APIバッファ管理テーブル取得失敗						*/
																		    /*	Acquisition failure of API buffer managed table		*/
    public const UInt32 AM_ER_MOVEOBJ_GET_FAULT 			= 0x57020513;   /*	MOVEオブジェクト管理テーブル取得失敗				*/
																		    /*	Acquisition failure of MOVE object managed table	*/
    public const UInt32 AM_ER_EVTTBL_GET_FAULT 				= 0x57020514;   /*	イベント管理テーブル取得失敗						*/
																		    /*	Acquisition failure of event managed table			*/
    public const UInt32 AM_ER_ACTTBL_GET_FAULT 				= 0x57020515;   /*	アクション管理テーブル取得失敗						*/
																		    /*	Acquisition failure of Action managed table			*/
    public const UInt32 AM_ER_1BY1APIBUF_GET_FAULT 			= 0x57020516;   /*	逐次実行型API管理テーブル取得失敗					*/
																		    /*	Acquisition failure of Sequence managed table		*/
    public const UInt32 AM_ER_AXSTBL_GET_FAULT 				= 0x57020517;   /*	AXISハンドル管理テーブル獲得失敗					*/
																		    /*	Acquisition failure of AXIS handle managed table	*/
    public const UInt32 AM_ER_SUPERPOSEOBJ_GET_FAULT 		= 0x57020518;   /*	払い出し合成オブジェクト管理テーブル獲得失敗		*/
																		    /*	Acquisition failure of Distribution synthetic object managed table	*/
    public const UInt32 AM_ER_SUPERPOSEOBJ_CLEAR_FAULT 		= 0x57020519;   /*	払い出し合成オブジェクト削除失敗					*/
																		    /*	Deletion failure of Distribution synthetic object	*/
    public const UInt32 AM_ER_AXIS_IN_USE 					= 0x5702051A;   /*	軸使用中											*/
																		    /*	axis in use											*/
    public const UInt32 AM_ER_HASHTBL_GET_FAULT 			= 0x5702051B;   /*	軸名称管理用ハッシュテーブル取得失敗				*/
																		    /*	Hash table acquisition failure for axial name management	*/
    public const UInt32 AM_ER_UNMATCH_OBJHNDL 				= 0x57020530;   /*	MOVEオブジェクトハンドル不一致						*/
																		    /*	MOVE object handle mismatched 						*/
    public const UInt32 AM_ER_UNMATCH_OBJECT 				= 0x57020531;   /*	オブジェクト不一致									*/
																		    /*	Object mismatched									*/
    public const UInt32 AM_ER_UNMATCH_APIBUF 				= 0x57020532;   /*	APIバッファ不一致									*/
																		    /*	API buffer mismatched								*/
    public const UInt32 AM_ER_UNMATCH_MSGBUF 				= 0x57020533;   /*	メッセージバッファ不一致							*/
																		    /*	Message buffer mismatched							*/
    public const UInt32 AM_ER_UNMATCH_ACTBUF 				= 0x57020534;   /*	アクション実行管理バッファ不一致					*/
																		    /*	Action execution management buffer mismatched		*/
    public const UInt32 AM_ER_UNMATH_SEQUENCE 				= 0x57020535;   /*	シーケンス番号不一致								*/
																		    /*	Sequence number mismatched							*/
    public const UInt32 AM_ER_UNMATCH_1BY1APIBUF 			= 0x57020536;   /*	逐次実行型API管理テーブル不一致						*/
																		    /*	Sequential API management table mismatched			*/
    public const UInt32 AM_ER_UNMATCH_MOVEOBJTABLE 			= 0x57020537;   /*	MOVEオブジェクト管理テーブル不一致					*/
																		    /*	MOVE object management table mismatched				*/
    public const UInt32 AM_ER_UNMATCH_MOVELISTTABLE 		= 0x57020538;   /*	MOVE LIST管理テーブル不一致							*/
																		    /*	MOVE LIST management table mismatched				*/
    public const UInt32 AM_ER_UNMATCH_MOVELIST_OBJECT 		= 0x57020539;   /*	MOVE LISTオブジェクト不一致							*/
																		    /*	MOVE LIST object mismatched							*/
    public const UInt32 AM_ER_UNMATCH_MOVELIST_OBJHNDL 		= 0x5702053A;   /*	MOVE LISTオブジェクトハンドル不一致					*/
																		    /*	MOVE LIST object handle mismatched					*/
    public const UInt32 AM_ER_UNGET_MOVEOBJTABLE 			= 0x57020550;   /*	MOVEオブジェクト管理テーブル未確保					*/
																		    /*	MOVE object management table not assured			*/
    public const UInt32 AM_ER_UNGET_MOVELISTTABLE 			= 0x57020551;   /*	MOVE LISTオブジェクト管理テーブル未確保				*/
																		    /*	MOVE LIST object management table not assured		*/
    public const UInt32 AM_ER_UNGET_1BY1APIBUFTABLE 		= 0x57020552;   /*	逐次実行型API管理テーブル未確保						*/
																		    /*	Sequential API management table not assured			*/
    public const UInt32 AM_ER_NOEMPTYTBL_ERROR 				= 0x57020560;   /*	補間テーブルに空きテーブルなし						*/
																		    /*	No unused table among interpolation tables			*/
    public const UInt32 AM_ER_NOTGETSEM_ERROR 				= 0x57020561;   /*	AM-MK セマフォ取得失敗 (Dynamic)					*/
																		    /*	Failure to get AM-MK semaphore  (Dynamic)			*/
    public const UInt32 AM_ER_NOTGETTBLADD_ERROR 			= 0x57020562;   /*	補間テーブルアドレス取得失敗						*/
																		    /*	Failure to get interpolation table address			*/
    public const UInt32 AM_ER_NOTWRTTBL_ERROR 				= 0x57020563;   /*	実行時テーブル書き込み失敗 (Static)					*/
																		    /*	Failure to write in table at execution (Static)		*/
    public const UInt32 AM_ER_TBLINDEX_ERROR 				= 0x57020564;   /*	Indexの設定異常 (Static)							*/
																		    /*	Index setting error (Static)						*/
    public const UInt32 AM_ER_ILLTBLTYPE_ERROR 				= 0x57020565;   /*	無効なテーブルタイプの指定							*/
																		    /*	Invalid table type specified						*/
    public const UInt32 AM_ER_UNSUPORTED_EVENT 				= 0x57020570;   /*	イベント非サポート or 引数エラー					*/
																		    /*	Event not supported or argument error				*/
    public const UInt32 AM_ER_WRONG_SEQUENCE 				= 0x57020571;   /*	シーケンス異常										*/
																		    /*	Sequence error										*/
    public const UInt32 AM_ER_MOVEOBJ_BUSY 					= 0x57020572;   /*	MOVEオブジェクト実行中								*/
																		    /*	MOVE object under execution							*/
    public const UInt32 AM_ER_MOVELIST_BUSY 				= 0x57020573;   /*	MOVE LIST実行中										*/
																		    /*	MOVE LIST under execution							*/
    public const UInt32 AM_ER_MOVELIST_ADD_FAULT 			= 0x57020574;   /*	MOVE OBJ登録不能									*/
																		    /*	MOVE OBJ cannot be registered.						*/
    public const UInt32 AM_ER_CONFLICT_PHI_AXS 				= 0x57020575;   /*	物理軸重複											*/
																		    /*	Physical axes overlapped							*/
    public const UInt32 AM_ER_CONFLICT_LOG_AXS 				= 0x57020576;   /*	論理軸重複											*/
																		    /*	Logic axes overlapped								*/
    public const UInt32 AM_ER_PKTSTS_ERROR 					= 0x57020577;   /*	受信パケットのステータス異常						*/
																		    /*	Receiving packet status error						*/
    public const UInt32 AM_ER_CONFLICT_NAME 				= 0x57020578;   /*	軸名称重複											*/
																		    /*	Axis name overlapped								*/
    public const UInt32 AM_ER_ILLEGAL_NAME 					= 0x57020579;   /*	軸名称不正											*/
																		    /*	Incorrect axis name									*/
    public const UInt32 AM_ER_SEMAPHORE_ERROR 				= 0x5702057A;   /*	ホストPC割り込み時 セマフォ異常						*/
																		    /*	Incorrect semaphore at host PC interruption			*/
    public const UInt32 AM_ER_LOG_AXS_OVER 					= 0x5702057B;   /*	論理軸番号範囲オーバ								*/
																		    /*	Logical axis number exceeded						*/
    public const UInt32 IM_STATION_ERR 						= 0x55060B00;   /*	ﾜｰﾆﾝｸﾞ	リンク伝送ステーションエラー				*/
																		    /*	Warning: Link communication station error			*/
    public const UInt32 IM_IO_ERR 							= 0x55060B01;   /*	ﾜｰﾆﾝｸﾞ	ＩＯエラー									*/
																		    /*	Warning: I/O error									*/
    public const UInt32 MP_FILE_ERR_GENERAL 				= 0x53168001;   /*	一般的なエラー										*/
																		    /*	General error. 										*/
    public const UInt32 MP_FILE_ERR_NOT_SUPPORTED 			= 0x53168002;   /*	指定した機能がサポートされていない					*/
																		    /*	Feature not supported. 								*/
    public const UInt32 MP_FILE_ERR_INVALID_ARGUMENT 		= 0x53168003;   /*	引数が不正											*/
																		    /*	Invalid argument 									*/
    public const UInt32 MP_FILE_ERR_INVALID_HANDLE 			= 0x53168004;   /*	ハンドルが不正										*/
																		    /*	Invalid handle 										*/
    public const UInt32 MP_FILE_ERR_NO_FILE 				= 0x53168064;   /*	指定したファイルまたはディレクトリが存在しない		*/
																		    /*	No such file (or directory). 						*/
    public const UInt32 MP_FILE_ERR_INVALID_PATH 			= 0x53168065;   /*	パスが異常											*/
																		    /*	Invalid path. 										*/
    public const UInt32 MP_FILE_ERR_EOF 					= 0x53168066;   /*	ファイルの最後に達した(EOF)							*/
																		    /*	End of file detected. 								*/
    public const UInt32 MP_FILE_ERR_PERMISSION_DENIED 		= 0x53168067;   /*	ファイル保護違反									*/
																		    /*	Not arrowed to access the file.						*/
    public const UInt32 MP_FILE_ERR_TOO_MANY_FILES 			= 0x53168068;   /*	同時に開けるファイル数の限界に達した				*/
																		    /*	Too many files opened. 								*/
    public const UInt32 MP_FILE_ERR_FILE_BUSY 				= 0x53168069;   /*	ファイルは使用中									*/
																		    /*	File is in use. 									*/
    public const UInt32 MP_FILE_ERR_TIMEOUT 				= 0x5316806A;   /*	タイムアウトが生じた								*/
																		    /*	Timeout occured. 									*/
    public const UInt32 MP_FILE_ERR_BAD_FS 					= 0x531680C8;   /*	論理ファイルシステムが異常							*/
																		    /*	Invalid or unexepected logical filesystem.          */
    public const UInt32 MP_FILE_ERR_FILESYSTEM_FULL 		= 0x531680C9;   /*	論理ファイルシステムがフル							*/
																		    /*	LFS (ie the media) is full.							*/
    public const UInt32 MP_FILE_ERR_INVALID_LFM 			= 0x531680CA;   /*	指定した論理ファイルシステムモジュールが不正		*/
																		    /*	Invalid LFM specified. 								*/
    public const UInt32 MP_FILE_ERR_TOO_MANY_LFM 			= 0x531680CB;   /*	登録可能な論理ファイルシステムモジュール数の限界	*/
																		    /*	LFM table is full. 									*/
    public const UInt32 MP_FILE_ERR_INVALID_PDM 			= 0x5316812C;   /*	指定した物理記憶デバイスドラバモジュールが不正		*/
																		    /*	Invalid PDM specified. 								*/
    public const UInt32 MP_FILE_ERR_INVALID_MEDIA 			= 0x5316812D;   /*	指定したメディアが不正								*/
																		    /*	Invalid media specified. 							*/
    public const UInt32 MP_FILE_ERR_TOO_MANY_PDM 			= 0x5316812E;   /*	登録可能な物理記憶デバイスドラバモジュール数の限界	*/
																		    /*	Too many PDM. 										*/
    public const UInt32 MP_FILE_ERR_TOO_MANY_MEDIA 			= 0x5316812F;   /*	登録可能なメディア数の限界に達した					*/
																		    /*	Too many media. 									*/
    public const UInt32 MP_FILE_ERR_WRITE_PROTECTED 		= 0x53168130;   /*	メディアが書き込み禁止である						*/
																		    /*	Write protected media. 								*/
    public const UInt32 MP_FILE_ERR_INVALID_DEVICE 			= 0x53168190;   /*	指定したデバイスが不正								*/
																		    /*	Invalid device specified. 							*/
    public const UInt32 MP_FILE_ERR_DEVICE_IO 				= 0x53168191;   /*	デバイスI/Oエラー									*/
																		    /*	Error occured in accessing the device. 				*/
    public const UInt32 MP_FILE_ERR_DEVICE_BUSY 			= 0x53168192;   /*	デバイスが使用中									*/
																		    /*	Device is in use. 									*/
    public const UInt32 MP_FILE_ERR_NO_CARD 				= 0x5316A711;   /*	CFカード未装着										*/
																		    /*	CF CARD not mounted.								*/
    public const UInt32 MP_FILE_ERR_CARD_POWER 				= 0x5316A712;   /*	CFカードの電源がOFF状態								*/
																		    /*	CF CARD Power-OFF.									*/
    public const UInt32 MP_CARD_SYSTEM_ERR 					= 0x53178FFF;   /*	カードシステムエラー								*/
																		    /*	Card System Error.									*/
    public const UInt32 ERROR_CODE_GET_DIREC_OFFSET 		= 0x83001A01;   /*	ディレクトリ領域のオフセットが獲得できない			*/
																		    /*	Directory area offset cannot be got.				*/
    public const UInt32 ERROR_CODE_GET_DIREC_INFO 			= 0x83001A02;   /*	ディレクトリ情報の取得エラー						*/
																		    /*	Directory area offset cannot be got.				*/
    public const UInt32 ERROR_CODE_FUNC_TABLE 				= 0x83001A03;   /*	システムコール関数テーブルの取得エラー				*/
																		    /*	Failure to get directory information				*/
    public const UInt32 ERROR_CODE_SLEEP_TASK 				= 0x83001A04;   /*	スリープエラー										*/
																		    /*	Failure to get system call function table			*/
    public const UInt32 ERROR_CODE_DEVICE_HANDLE_FULL 		= 0x43001A41;   /*	デバイスハンドルが最大数を超えた					*/
																		    /*	Sleep error											*/
    public const UInt32 ERROR_CODE_ALLOC_MEMORY 			= 0x43001A42;   /*	領域確保失敗										*/
																		    /*	Number of device handles exceeds the maximum value.	*/
    public const UInt32 ERROR_CODE_BUFCOPY 					= 0x43001A43;   /*	MemoryCopy(),name_copy()のエラー					*/
																		    /*	Failure to get the area.							*/
    public const UInt32 ERROR_CODE_GET_COMMEM_OFFSET 		= 0x43001A44;   /*	共有メモリオフセット値の取得エラー					*/
																		    /*	MemoryCopy(),name_copy() error						*/
    public const UInt32 ERROR_CODE_CREATE_SEMPH 			= 0x43001A45;   /*	セマフォ作成エラー									*/
																		    /*	Failure to get common memory offset value			*/
    public const UInt32 ERROR_CODE_DELETE_SEMPH 			= 0x43001A46;   /*	セマフォ削除エラー									*/
																		    /*	Semaphore creation error							*/
    public const UInt32 ERROR_CODE_LOCK_SEMPH 				= 0x43001A47;   /*	セマフォロック時のエラー							*/
																		    /*	Semaphore deletion error							*/
    public const UInt32 ERROR_CODE_UNLOCK_SEMPH 			= 0x43001A48;   /*	セマフォロック解除時のエラー						*/
																		    /*	Error at semaphore lock								*/
    public const UInt32 ERROR_CODE_PACKETSIZE_OVER 			= 0x43001A49;   /*	パケットサイズのオーバー							*/
																		    /*	Error at semaphore release							*/
    public const UInt32 ERROR_CODE_UNREADY                  = 0x43001A4A;   /*  コントローラ初期化中エラー                          */
                                                            	  	    	/*  Error when controller is being initialized          */
    public const UInt32 ERROR_CODE_CPUSTOP                  = 0x43001A4B;   /*  ＣＰＵストップ中エラー                              */
                                                            	  			/*  Error when CPU is stopping                          */
    public const UInt32 ERROR_CODE_CNTRNO                   = 0x470B1A81;   /*	CPU番号不正											*/
																			/*	CPU number is illegal								*/
    public const UInt32 ERROR_CODE_SELECTION 				= 0x470B1A82;   /*	選択値(0or1)が不正									*/
																		    /*	Device number										*/
    public const UInt32 ERROR_CODE_LENGTH 					= 0x470B1A83;   /*	データ長											*/
																		    /*	Illegal selected value (0 or 1)						*/
    public const UInt32 ERROR_CODE_OFFSET 					= 0x470B1A84;   /*	オフセット値										*/
																		    /*	Data length											*/
    public const UInt32 ERROR_CODE_DATACOUNT 				= 0x470B1A85;   /*	データ数											*/
																		    /*	Offset value										*/
    public const UInt32 ERROR_CODE_DATREAD 					= 0x46001A86;   /*	共有メモリからの読み出し失敗						*/
																		    /*	Number of data items								*/
    public const UInt32 ERROR_CODE_DATWRITE 				= 0x46001A87;   /*	共有メモリへの書き込み失敗							*/
																		    /*	Failure to read out from common memory				*/
    public const UInt32 ERROR_CODE_BITWRITE 				= 0x46001A88;   /*	共有メモリへのビットデータ書き込み失敗				*/
																		    /*	Failure to write in to common memory				*/
    public const UInt32 ERROR_CODE_DEVCNTR 					= 0x46001A89;   /*	DeviceIoControl()がエラー終了						*/
																		    /*	Failure to write in bit data to common memory		*/
    public const UInt32 ERROR_CODE_NOTINIT 					= 0x460F1A8A;   /*	ドライバ初期化エラー								*/
																		    /*	DeviceIoControl() completed erroneously.			*/
    public const UInt32 ERROR_CODE_SEMPHLOCK 				= 0x41001A8B;   /*	パケット送信セマフォロック							*/
																		    /*	Driver initialization error							*/
    public const UInt32 ERROR_CODE_SEMPHUNLOCK 				= 0x41001A8C;   /*	パケット受信セマフォアンロック						*/
																		    /*	Packet sending semaphore locked						*/
    public const UInt32 ERROR_CODE_DRV_PROC 				= 0x460F1A8D;   /*	ドライバの処理がエラー終了							*/
																		    /*	Packet receiving semaphore not locked				*/
    public const UInt32 ERROR_CODE_GET_DRIVER_HANDLE 		= 0x460F1A8E;   /*	ドライバファイルのハンドル取得エラー				*/
																		    /*	Driver processing completed erroneously.			*/
    public const UInt32 ERROR_CODE_SEND_MSG 				= 0x450E1AC1;   /*	メッセージ送信エラー								*/
																		    /*	Failure to get driver file handle					*/
    public const UInt32 ERROR_CODE_RECV_MSG 				= 0x450E1AC2;   /*	メッセージ受信エラー								*/
																		    /*	Message sending error								*/
    public const UInt32 ERROR_CODE_INVALID_RESPONSE 		= 0x450E1AC3;   /*	受信パケットが不正									*/
																		    /*	Message receiving error								*/
    public const UInt32 ERROR_CODE_INVALID_ID 				= 0x450E1AC4;   /*	受信パケットのIDが不正								*/
																		    /*	Receiving packet illegal							*/
    public const UInt32 ERROR_CODE_INVALID_STATUS 			= 0x450E1AC5;   /*	受信パケットのステータスが不正						*/
																		    /*	Receiving packet ID illegal							*/
    public const UInt32 ERROR_CODE_INVALID_CMDCODE 			= 0x450E1AC6;   /*	受信パケットのコマンドコードが不正					*/
																		    /*	Receiving packet status illegal						*/
    public const UInt32 ERROR_CODE_INVALID_SEQNO 			= 0x450E1AC7;   /*	受信パケットのシーケンス番号が不正					*/
																		    /*	Receiving packet command code illegal				*/
    public const UInt32 ERROR_CODE_SEND_RETRY_OVER 			= 0x450E1AC8;   /*	リトライ回数を超えた（パケット送信）				*/
																		    /*	Receiving packet sequence number illegal			*/
    public const UInt32 ERROR_CODE_RECV_RETRY_OVER 			= 0x450E1AC9;   /*	リトライ回数を超えた（パケット受信）				*/
																		    /*	Number of retries exceeded (packet sending)			*/
    public const UInt32 ERROR_CODE_RESPONSE_TIMEOUT 		= 0x450E1ACA;   /*	応答待ちタイムアウトエラー							*/
																		    /*	Number of retries exceeded (packet receiving)		*/
    public const UInt32 ERROR_CODE_WAIT_FOR_EVENT 			= 0x450E1ACB;   /*	イベント待ちエラー									*/
																		    /*	Response waiting timeout error						*/
    public const UInt32 ERROR_CODE_EVENT_OPEN 				= 0x450E1ACC;   /*	イベントオープン失敗								*/
																		    /*	Event waiting error									*/
    public const UInt32 ERROR_CODE_EVENT_RESET 				= 0x450E1ACD;   /*	イベントリセット失敗								*/
																		    /*	Failure to open event								*/
    public const UInt32 ERROR_CODE_EVENT_READY 				= 0x450E1ACE;   /*	イベント待ち準備失敗								*/
																		    /*	Failure to reset event								*/
    public const UInt32 ERROR_CODE_PROCESSNUM 				= 0x43001B01;   /*	プロセス数 超過										*/
																		    /*	Failure to prepare for waiting for event			*/
    public const UInt32 ERROR_CODE_GET_PROC_INFO 			= 0x43001B02;   /*	プロセス情報の取得									*/
																		    /*	Number of processes exceeded						*/
    public const UInt32 ERROR_CODE_THREADNUM 				= 0x43001B03;   /*	スレッド数 超過										*/
																		    /*	Process information getting error					*/
    public const UInt32 ERROR_CODE_GET_THRD_INFO 			= 0x43001B04;   /*	スレッド情報の取得									*/
																		    /*	Number of threads exceeded							*/
    public const UInt32 ERROR_CODE_CREATE_MBOX 				= 0x43001B05;   /*	メールボックスの生成エラー							*/
																		    /*	Thread information getting error					*/
    public const UInt32 ERROR_CODE_DELETE_MBOX 				= 0x43001B06;   /*	メールボックスの削除エラー							*/
																		    /*	Mail box creation error								*/
    public const UInt32 ERROR_CODE_GET_TASKID 				= 0x83001B07;   /*	タスクID取得エラー									*/
																		    /*	Mail box deletion error								*/
    public const UInt32 ERROR_CODE_NO_THREADINFO 			= 0x43001B08;   /*	指定されたスレッド情報が存在しない					*/
																		    /*	Failure to get task ID								*/
    public const UInt32 ERROR_CODE_COM_INITIALIZE 			= 0x43001B09;   /*	COMの初期化エラー									*/
																		    /*	Specified thread information does not exist.		*/
    public const UInt32 ERROR_CODE_COMDEVICENUM 			= 0x430F1B41;   /*	ComDevice数 超過									*/
																		    /*	COM initialization error							*/
    public const UInt32 ERROR_CODE_GET_COM_DEVICE_HANDLE 	= 0x430F1B42;   /*	ComDevice情報構造体の取得エラー						*/
																		    /*	Number of ComDevice exceeded						*/
    public const UInt32 ERROR_CODE_COM_DEVICE_FULL 			= 0x430F1B43;   /*	ComDeviceが最大数を超えた							*/
																		    /*	Failure to get ComDevice information structure		*/
    public const UInt32 ERROR_CODE_CREATE_PANELOBJ 			= 0x430F1B44;   /*	パネルコマンドオブジェクト生成失敗					*/
																		    /*	ComDevice exceeds the maximum number.				*/
    public const UInt32 ERROR_CODE_OPEN_PANELOBJ 			= 0x430F1B45;   /*	パネルコマンドオブジェクトオープン失敗				*/
																		    /*	Failure to create panel command object				*/
    public const UInt32 ERROR_CODE_CLOSE_PANELOBJ 			= 0x430F1B46;   /*	パネルコマンドオブジェクトクローズ失敗				*/
																		    /*	Failure to open panel command object				*/
    public const UInt32 ERROR_CODE_PROC_PANELOBJ 			= 0x430F1B47;   /*	パネルコマンドオブジェクト処理失敗					*/
																		    /*	Failure to close panel command object				*/
    public const UInt32 ERROR_CODE_CREATE_CNTROBJ 			= 0x430F1B48;   /*	パネルコマンドオブジェクト生成失敗					*/
																		    /*	Failure to process panel command object				*/
    public const UInt32 ERROR_CODE_OPEN_CNTROBJ 			= 0x430F1B49;   /*	パネルコマンドオブジェクトオープン失敗				*/
																		    /*	Failure to create panel command object				*/
    public const UInt32 ERROR_CODE_CLOSE_CNTROBJ 			= 0x430F1B4A;   /*	パネルコマンドオブジェクトクローズ失敗				*/
																		    /*	Failure to open panel command object				*/
    public const UInt32 ERROR_CODE_PROC_CNTROBJ 			= 0x430F1B4B;   /*	パネルコマンドオブジェクト処理失敗					*/
																		    /*	Failure to close panel command object				*/
    public const UInt32 ERROR_CODE_CREATE_COMDEV_MUTEX 		= 0x430F1B4C;   /*	ComDeviceテーブルのMutex作成失敗					*/
																		    /*	Failure to process panel command object				*/
    public const UInt32 ERROR_CODE_CREATE_COMDEV_MAPFILE 	= 0x430F1B4D;   /*	ComDeviceテーブル用のMapFile作成失敗				*/
																		    /*	Failure to create Mutex for ComDevice table			*/
    public const UInt32 ERROR_CODE_OPEN_COMDEV_MAPFILE 		= 0x430F1B4E;   /*	ComDeviceテーブル用のMapFileオープン失敗			*/
																		    /*	Failure to create MapFile for ComDevice table		*/
    public const UInt32 ERROR_CODE_NOT_OBJECT_TYPE 			= 0x430F1B4F;   /*	オブジェクト種別のエラー							*/
																		    /*	Failure to open MapFile for ComDevice table			*/
    public const UInt32 ERROR_CODE_COM_NOT_OPENED 			= 0x430F1B50;   /*	未オープン											*/
																		    /*	Object type error									*/
    public const UInt32 ERROR_CODE_PNLCMD_CPU_CONTROL 		= 0x43081B80;   /*	CPUコントロールのエラー								*/
																		    /*	Not opened											*/
    public const UInt32 ERROR_CODE_PNLCMD_SFILE_READ 		= 0x43081B81;   /*	ソースファイル読み出し失敗							*/
																		    /*	CPU control error									*/
    public const UInt32 ERROR_CODE_PNLCMD_SFILE_WRITE 		= 0x43081B82;   /*	ソースファイル書き込み失敗							*/
																		    /*	Failure to read out source file						*/
    public const UInt32 ERROR_CODE_PNLCMD_REGISTER_READ 	= 0x43081B83;   /*	レジスタ読み出し失敗								*/
																		    /*	Failure to write in source file						*/
    public const UInt32 ERROR_CODE_PNLCMD_REGISTER_WRITE 	= 0x43081B84;   /*	レジスタ書き込み失敗								*/
																		    /*	Failure to read out register						*/
    public const UInt32 ERROR_CODE_PNLCMD_API_SEND 			= 0x43081B85;   /*	API Sendコマンド失敗								*/
																		    /*	Failure to write in register						*/
    public const UInt32 ERROR_CODE_PNLCMD_API_RECV 			= 0x43081B86;   /*	API Recvコマンド失敗								*/
																		    /*	API Send command error								*/
    public const UInt32 ERROR_CODE_PNLCMD_NO_RESPONSE 		= 0x43081B87;   /*	API Recvで応答パケットがまだない					*/
																		    /*	API Recv command error								*/
    public const UInt32 ERROR_CODE_PNLCMD_PACKET_READ 		= 0x43081B88;   /*	パケット・リード失敗								*/
																		    /*	No response packet is received at API Recv.			*/
    public const UInt32 ERROR_CODE_PNLCMD_PACKET_WRITE 		= 0x43081B89;   /*	パケット・ライト失敗								*/
																		    /*	Failure to read packet								*/
    public const UInt32 ERROR_CODE_PNLCMD_STATUS_READ 		= 0x43081B8A;   /*	ステータスリード失敗								*/
																		    /*	Failure to write packet								*/
    public const UInt32 ERROR_CODE_NOT_CONTROLLER_RDY 		= 0x440D1BA0;   /*	コントローラ運転準備未完							*/
																		    /*														*/
    public const UInt32 ERROR_CODE_DOUBLE_CMD      			= 0x440D1BA1;   /*	モーションコマンド重複指令							*/
																		    /*														*/
    public const UInt32 ERROR_CODE_DOUBLE_RCMD      		= 0x440D1BA2;   /*	モーションレスポンスコマンド重複指令				*/
																		    /*														*/
    public const UInt32 ERROR_CODE_FILE_NOT_OPENED 			= 0x43001BC1;   /*	ファイルがオープンされていない						*/
																		    /*	Failure to read status								*/
    public const UInt32 ERROR_CODE_OPENFILE_NUM 			= 0x43001BC2;   /*	オープンファイル数 超過								*/
																		    /*	File is not opened.									*/
    public const UInt32 MP_CTRL_SYS_ERROR					= 0x4308106f;   /*	システムエラー										*/
																		    /*														*/
    public const UInt32 MP_CTRL_PARAM_ERR					= 0x43081092;   /*	不正なパラメータ指定								*/
																		    /*														*/
	public const UInt32 MP_CTRL_FILE_NOT_FOUND				= 0x43081094;   /*	存在しないプログラムが指定された					*/
																		    /*														*/
    public const UInt32 MP_NOTMOVEHANDLE 					= 0x470B1100;   /*	未定義のMoveハンドル								*/
																		    /*	Undefined Move handle								*/
    public const UInt32 MP_NOTTIMERHANDLE 					= 0x470B1101;   /*	未定義のタイマハンドル								*/
																		    /*	Undefined timer handle								*/
    public const UInt32 MP_NOTINTERRUPT 					= 0x470B1102;   /*	未定義の仮想割り込み番号							*/
																		    /*	Undefined virtual interruption number				*/
    public const UInt32 MP_NOTEVENTHANDLE 					= 0x470B1103;   /*	未定義のイベントハンドル							*/
																		    /*	Undefined event handle								*/
    public const UInt32 MP_NOTMESSAGEHANDLE 				= 0x470B1104;   /*	未定義のメッセージハンドル							*/
																		    /*	Undefined message handle							*/
    public const UInt32 MP_NOTUSERFUNCTIONHANDLE 			= 0x470B1105;   /*	未定義のユーザ関数のハンドル						*/
																		    /*	Undefined user function handle						*/
    public const UInt32 MP_NOTACTIONHANDLE 					= 0x470B1106;   /*	未定義のアクションハンドル							*/
																		    /*	Undefined action handle								*/
    public const UInt32 MP_NOTSUBSCRIBEHANDLE 				= 0x470B1107;   /*	未定義のSubscribeハンドル							*/
																		    /*	Undefined Subscribe handle							*/
    public const UInt32 MP_NOTDEVICEHANDLE 					= 0x470B1108;   /*	未定義のデバイスハンドル							*/
																		    /*	Undefined device handle								*/
    public const UInt32 MP_NOTAXISHANDLE 					= 0x470B1109;   /*	未定義の軸ハンドル									*/
																		    /*	Undefined axis handle								*/
    public const UInt32 MP_NOTMOVELISTHANDLE 				= 0x470B110A;   /*	未定義のMoveListハンドル							*/
																		    /*	Undefined MoveList handle							*/
    public const UInt32 MP_NOTTRACEHANDLE 					= 0x470B110B;   /*	未定義のTraceハンドル								*/
																		    /*	Undefined Trace handle								*/
    public const UInt32 MP_NOTGLOBALDATAHANDLE 				= 0x470B110C;   /*	未定義のグローバルデータハンドル					*/
																		    /*	Undefined global data handle						*/
    public const UInt32 MP_NOTSUPERPOSEHANDLE 				= 0x470B110D;   /*	未定義のグローバルデータハンドル					*/
																		    /*	Undefined Superpose handle							*/
    public const UInt32 MP_NOTCONTROLLERHANDLE 				= 0x470B110E;   /*	未定義のコントローラハンドル						*/
																		    /*	Undefined Controller handle							*/
    public const UInt32 MP_NOTFILEHANDLE 					= 0x470B110F;   /*	未定義のファイルハンドル							*/
																		    /*	Undefined file handle								*/
    public const UInt32 MP_NOTREGISTERDATAHANDLE 			= 0x470B1110;   /*	レジスタハンドルの未定義							*/
																		    /*	Undefined register handle							*/
    public const UInt32 MP_NOTALARMHANDLE 					= 0x470B1111;   /*	アラームハンドルの未定義							*/
																		    /*	Undefined alarm handle								*/
    public const UInt32 MP_NOTCAMHANDLE 					= 0x470B1112;   /*	CAMハンドルの未定義									*/
																		    /*	Undefined CAM handle								*/
    public const UInt32 MP_NOTHANDLE 						= 0x470B11FF;   /*	未定義のハンドル									*/
																		    /*	Undefined handle									*/
    public const UInt32 MP_NOTEVENTTYPE 					= 0x470B1200;   /*	未定義のイベントタイプ								*/
																		    /*	Undefined event type								*/
    public const UInt32 MP_NOTDEVICETYPE 					= 0x470B1201;   /*	未定義のデバイスタイプ								*/
																		    /*	Undefined device type								*/
    public const UInt32 MP_NOTDATAUNITSIZE 					= 0x4B0B1202;   /*	未定義の単位データサイズ							*/
																		    /*	Undefined unit data size							*/
    public const UInt32 MP_NOTDEVICE 						= 0x470B1203;   /*	未定義のデバイス									*/
																		    /*	Undefined device									*/
    public const UInt32 MP_NOTACTIONTYPE 					= 0x470B1204;   /*	未定義のアクションタイプ							*/
																		    /*	Undefined action type								*/
    public const UInt32 MP_NOTPARAMNAME 					= 0x4B0B1205;   /*	未定義のパラメータ名								*/
																		    /*	Undefined parameter name							*/
    public const UInt32 MP_NOTDATATYPE 						= 0x470B1206;   /*	未定義のデータタイプ								*/
																		    /*	Undefined data type									*/
    public const UInt32 MP_NOTBUFFERTYPE 					= 0x470B1207;   /*	未定義のバッファタイプ								*/
																		    /*	Undefined buffer type								*/
    public const UInt32 MP_NOTMOVETYPE 						= 0x4B0B1208;   /*	未定義のMoveタイプ									*/
																		    /*	Undefined Move type									*/
    public const UInt32 MP_NOTANGLETYPE 					= 0x470B1209;   /*	未定義のAngleタイプ									*/
																		    /*	Undefined Angle type								*/
    public const UInt32 MP_NOTDIRECTION 					= 0x4B0B120A;   /*	未定義の回転方向									*/
																		    /*	Undefined rotating direction						*/
    public const UInt32 MP_NOTAXISTYPE 						= 0x4B0B120B;   /*	未定義の軸タイプ									*/
																		    /*	Undefined axis type									*/
    public const UInt32 MP_NOTUNITTYPE 						= 0x4B0B120C;   /*	未定義の単位タイプ									*/
																		    /*	Undefined unit type									*/
    public const UInt32 MP_NOTCOMDEVICETYPE 				= 0x470B120D;   /*	未定義のComDevice種別								*/
																		    /*	Undefined ComDevice type							*/
    public const UInt32 MP_NOTCONTROLTYPE 					= 0x470B120E;   /*	未定義のControl種別									*/
																		    /*	Undefined Control type								*/
    public const UInt32 MP_NOTFILETYPE 						= 0x4B0B120F;   /*	未定義のファイル種別								*/
																		    /*	Undefined file type									*/
    public const UInt32 MP_NOTSEMAPHORETYPE 				= 0x470B1210;   /*	未定義のセマフォタイプ								*/
																		    /*	Undefined semaphore type							*/
    public const UInt32 MP_NOTSYSTEMOPTION 					= 0x470B1211;   /*	未定義のSystemOption								*/
																		    /*	Undefined system option								*/
    public const UInt32 MP_TIMEOUT_ERR 						= 0x470B1212;   /*	タイムアウト エラー									*/
																		    /*	Timeout error										*/
    public const UInt32 MP_TIMEOUT 							= 0x470B1213;   /*	タイムアウト										*/
																		    /*	Timeout												*/
    public const UInt32 MP_NOTSUBSCRIBETYPE 				= 0x470B1214;   /*	未定義のSubscribeタイプ								*/
																		    /*	Undefined scan type									*/
    public const UInt32 MP_NOTSCANTYPE 						= 0x4B0B1214;   /*	未定義のスキャンタイプ								*/
																		    /*	Undefined scan type									*/
    public const UInt32 MP_DEVICEOFFSETOVER 				= 0x470B1300;   /*	範囲外のデバイスオフセット							*/
																		    /*	Out-of-range device offset							*/
    public const UInt32 MP_DEVICEBITOFFSETOVER 				= 0x470B1301;   /*	範囲外のビットオフセット							*/
																		    /*	Out-of-range bit offset								*/
    public const UInt32 MP_UNITCOUNTOVER 					= 0x4B0B1302;   /*	範囲外の個数										*/
																		    /*	Out-of-range quantity								*/
    public const UInt32 MP_COMPAREVALUEOVER 				= 0x4B0B1303;   /*	範囲外の比較値										*/
																		    /*	Out-of-range compared value							*/
    public const UInt32 MP_FCOMPAREVALUEOVER 				= 0x4B0B1304;   /*	範囲外の浮動小数点比較値							*/
																		    /*	Out-of-range floating-point compared value			*/
    public const UInt32 MP_EVENTCOUNTOVER 					= 0x470B1305;   /*	範囲外の仮想割り込み番号							*/
																		    /*	Out-of-range virtual interruption number			*/
    public const UInt32 MP_VALUEOVER 						= 0x470B1306;   /*	範囲外の値											*/
																		    /*	Out-of-range value									*/
    public const UInt32 MP_FVALUEOVER 						= 0x470B1307;   /*	範囲外の浮動小数値									*/
																		    /*	Out-of-range floating point							*/
    public const UInt32 MP_PSTOREDVALUEOVER 				= 0x470B1308;   /*	範囲外の格納場所のポインタ							*/
																		    /*	Out-of-range storage position pointer				*/
    public const UInt32 MP_PSTOREDFVALUEOVER 				= 0x470B1309;   /*	範囲外の格納場所のポインタ(浮動小数点値)			*/
																		    /*	Out-of-range storage position pointer (floating decimal point value)	*/
    public const UInt32 MP_SIZEOVER 						= 0x470B130A;   /*	範囲外のサイズ										*/
																		    /*	Out-of-range size									*/
    public const UInt32 MP_RECEIVETIMEROVER 				= 0x470B1310;   /*	範囲外の受信待ち時間値								*/
																		    /*	Out-of-range waiting time value for receiving		*/
    public const UInt32 MP_RECNUMOVER 						= 0x470B1311;   /*	範囲外のレコード数(MoveList)						*/
																		    /*	Out-of-range number of records (MoveList)			*/
    public const UInt32 MP_PARAMOVER 						= 0x4B0B1312;   /*	範囲外のパラメータ									*/
																		    /*	Out-of-range parameter								*/
    public const UInt32 MP_FRAMEOVER 						= 0x470B1313;   /*	範囲外のパラメータ									*/
																		    /*	Out-of-range number of frames						*/
    public const UInt32 MP_RADIUSOVER 						= 0x4B0B1314;   /*	範囲外の半径										*/
																		    /*	Out-of-range radius									*/
    public const UInt32 MP_CONTROLLERNOOVER 				= 0x470B1315;   /*	範囲外の機器番号									*/
																		    /*	Out-of-range device number							*/
    public const UInt32 MP_AXISNUMOVER 						= 0x4B0B1316;   /*	範囲外の軸数										*/
																		    /*	Out-of-range number of axes							*/
    public const UInt32 MP_DIGITOVER 						= 0x4B0B1317;   /*	範囲外の桁数										*/
																		    /*	Out-of-range number of digits						*/
    public const UInt32 MP_CALENDARVALUEOVER 				= 0x4B0B1318;   /*	範囲外のカレンダデータ								*/
																		    /*	Out-of-range calendar data							*/
    public const UInt32 MP_OFFSETOVER 						= 0x470B1319;   /*	範囲外のオフセット									*/
																		    /*	Out-of-range offset									*/
    public const UInt32 MP_NUMBEROVER 						= 0x470B131A;   /*	範囲外のレジスタの設定個数が指定された				*/
																		    /*	Out-of-range number of registers has been specified.*/
    public const UInt32 MP_RACKOVER 						= 0x470B131B;   /*	範囲外のラック番号が指定された						*/
																		    /*	Out-of-range rack number has been specified.		*/
    public const UInt32 MP_SLOTOVER 						= 0x470B131C;   /*	範囲外のラック番号が指定された						*/
																		    /*	Out-of-range slot number has been specified.		*/
    public const UInt32 MP_FIXVALUEOVER 					= 0x470B131D;   /*	固定小数点型のデータが範囲外となった				*/
																		    /*	Fixed decimal point type data has been out of range.*/
	public const UInt32 MP_REGISTERINFOROVER 				= 0x470B131E;    /*	範囲外のレジスタ情報の個数が指定された				*/
    																		/* Out-of-range number of register infomation has been specified.*/
    public const UInt32 PC_MEMORY_ERR 						= 0x430B1400;   /*	パソコンメモリ不足									*/
																		    /*	PC memory shortage									*/
    public const UInt32 MP_NOCOMMUDEVICETYPE 				= 0x470B1500;   /*	通信デバイスタイプの指定エラー						*/
																		    /*	Communication device type specification error		*/
    public const UInt32 MP_NOTPROTOCOLTYPE 					= 0x470B1501;   /*	無効なプロトコルタイプ								*/
																			/*	Invalid protocol type								*/
    public const UInt32 MP_NOTFUNCMODE 						= 0x470B1502;   /*	無効な機能モード									*/
																			/*	Invalid function mode								*/
    public const UInt32 MP_MYADDROVER 						= 0x470B1503;   /*	範囲外の自局アドレスが設定された					*/
																			/*	Out-of-range local station address has been set.	*/
    public const UInt32 MP_NOTPORTTYPE 						= 0x470B1504;   /*	無効なポートタイプ									*/
																			/*	Invalid port type									*/
    public const UInt32 MP_NOTPROTMODE 						= 0x470B1505;   /*	無効なプロトコルモード								*/
																			/*	Invalid protocol mode								*/
    public const UInt32 MP_NOTCHARSIZE 						= 0x470B1506;   /*	無効なキャラクタビット長							*/
																		    /*	Invalid character bit length						*/
    public const UInt32 MP_NOTPARITYBIT 					= 0x470B1507;   /*	無効なパリティビット								*/
																		    /*	Invalid parity bit									*/
    public const UInt32 MP_NOTSTOPBIT 						= 0x470B1508;   /*	無効なストップビット								*/
																		    /*	Invalid stop bit									*/
    public const UInt32 MP_NOTBAUDRAT 						= 0x470B1509;   /*	無効な伝送速度										*/
																		    /*	Invalid transmission speed							*/
    public const UInt32 MP_TRANSDELAYOVER 					= 0x470B1510;   /*	範囲外の送信遅延が指定された						*/
																		    /*	Out-of-range sending delay has been specified.		*/
    public const UInt32 MP_PEERADDROVER 					= 0x470B1511;   /*	範囲外の相手先アドレスが指定された					*/
																		    /*	Out-of-range remote station address has been specified.	*/
    public const UInt32 MP_SUBNETMASKOVER 					= 0x470B1512;   /*	範囲外のサブネットマスクが指定された				*/
																		    /*	Out-of-range subnet mask has been specified.		*/
    public const UInt32 MP_GWADDROVER 						= 0x470B1513;   /*	範囲外のGWアドレスが指定された						*/
																		    /*	Out-of-range GW address has been specified.			*/
    public const UInt32 MP_DIAGPORTOVER 					= 0x470B1514;   /*	範囲外の診断ポートが指定された						*/
																		    /*	Out-of-range diagnostic port has been specified.	*/
    public const UInt32 MP_PROCRETRYOVER 					= 0x470B1515;   /*	範囲外の有手順リトライ回数が指定された				*/
																		    /*	Out-of-range number of retries has been specified.	*/
    public const UInt32 MP_TCPZEROWINOVER 					= 0x470B1516;   /*	範囲外のTCPゼロウィンドウタイマ						*/
																		    /*	Out-of-range TCP zero window timer					*/
    public const UInt32 MP_TCPRETRYOVER 					= 0x470B1517;   /*	範囲外のTCP再送タイマ値								*/
																		    /*	Out-of-range TCP resending timer value				*/
    public const UInt32 MP_TCPFINOVER 						= 0x470B1518;   /*	範囲外の終了タイマ値								*/
																		    /*	Out-of-range completion timer value					*/
    public const UInt32 MP_IPASSEMBLEOVER 					= 0x470B1519;   /*	範囲外のIP組み込みタイマ値							*/
																		    /*	Out-of-range IP incorporating timer value			*/
    public const UInt32 MP_MAXPKTLENOVER 					= 0x470B1520;   /*	範囲外の最大パケット長								*/
																		    /*	Out-of-range maximum packet length					*/
    public const UInt32 MP_PEERPORTOVER 					= 0x470B1521;   /*	範囲外の相手先ポート								*/
																		    /*	Out-of-range remote station port					*/
    public const UInt32 MP_MYPORTOVER 						= 0x470B1522;   /*	範囲外の自局ポート									*/
																		    /*	Out-of-range local station port						*/
    public const UInt32 MP_NOTTRANSPROT 					= 0x470B1523;   /*	無効なトランスポート層プロトコル					*/
																		    /*	Invalid transport layer protocol					*/
    public const UInt32 MP_NOTAPPROT 						= 0x470B1524;   /*	無効なアプリケーション層プロトコル					*/
																		    /*	Invalid application layer protocol					*/
    public const UInt32 MP_NOTCODETYPE 						= 0x470B1525;   /*	無効なコードタイプ									*/
																		    /*	Invalid code type									*/
    public const UInt32 MP_CYCTIMOVER 						= 0x470B1526;   /*	範囲外の通信周期が指定された						*/
																		    /*	Out-of-range communication cycle has been specified.*/
    public const UInt32 MP_NOTIOMAPCOM 						= 0x470B1527;   /*	無効な入出力コマンド								*/
																		    /*	Invalid I/O commands								*/
    public const UInt32 MP_NOTIOTYPE 						= 0x470B1528;   /*	無効なI/Oタイプ指定									*/
																		    /*	Invalid I/O type specification						*/
    public const UInt32 MP_IOOFFSETOVER 					= 0x470B1529;   /*	範囲外のI/Oオフセットが割り付けられた				*/
																		    /*	Out-of-range I/O offset has been allocated.			*/
    public const UInt32 MP_IOSIZEOVER 						= 0x470B1530;   /*	範囲外のI/Oサイズが割り付けられた(個別)				*/
																		    /*	Out-of-range I/O size has been allocated (individualy).	*/
    public const UInt32 MP_TIOSIZEOVER 						= 0x470B1531;   /*	範囲外のI/Oサイズが割り付けられた(合計)				*/
																		    /*	Out-of-range I/O size has been allocated (total).	*/
    public const UInt32 MP_MEMORY_ERR 						= 0x470B1532;   /*	コントローラメモリ不足								*/
    																	    /*	Controller memory shortage							*/
    public const UInt32 MP_NOTPTR 							= 0x470B1533;   /*	無効なポインタ (通信デバイス指定構造体/デバイス固有情報/対象通信デバイスハンドルへのポインタ異常)													*/
																	 		/*	Invalid pointer (communication device specification structure/device inherent information/pointer error to objective communication device handle)	*/
    public const UInt32 MP_TABLEOVER 						= 0x43001800;   /*	イベント検出テーブルリソースが取得できない			*/
																	 	   	/*	Event detection table resource cannot be got.		*/
    public const UInt32 MP_ALARM 							= 0x43001801;   /*	アラーム発生										*/
																	    	/*	Alarm has occurred.									*/
    public const UInt32 MP_MEMORYOVER 						= 0x43001802;   /*	メモリリソースが獲得できない						*/
																	    	/*	Memory resource cannot be got.						*/
    public const UInt32 MP_EXEC_ERR 						= 0x470B1803;   /*	アラーム発生										*/
																	    	/*	System execution error								*/
    public const UInt32 MP_NOTLOGICALAXIS 					= 0x470B1804;   /*	アラーム発生										*/
																	    	/*	Logical axis number error							*/
    public const UInt32 MP_NOTSUPPORTED 					= 0x470B1805;   /*	未サポート											*/
																		    /*	Not supported										*/
    public const UInt32 MP_ILLTEXT 							= 0x470B1806;   /*	有効範囲外の長さの文字列入力						*/
																	    	/*	Out-of-range length of character string was input.	*/
    public const UInt32 MP_NOFILENAME 						= 0x470B1807;   /*	ファイル名が未設定									*/
																	    	/*	File name has not been set.							*/
    public const UInt32 MP_NOTREGSTERNAME 					= 0x470B1808;   /*	指定されたレジスターデータ名がない					*/
																	    	/*	Specified register data name cannot be found.		*/
    public const UInt32 MP_FILEALREADYOPEN 					= 0x4B0B1809;   /*	同じファイルが既にオープンされている				*/
																	    	/*	The same file has already been opened.				*/
    public const UInt32 MP_NOFILEPACKET 					= 0x470B180A;   /*	指定されたソースファイルパケットがない				*/
																	    	/*	Specified source file packet cannot be found.		*/
    public const UInt32 MP_NOTFILEPACKETSIZE 				= 0x470B180B;   /*	ソースファイルパケットのサイズが違う				*/
																	    	/*	Source file packet size is incorrect.				*/
    public const UInt32 MP_NOTUSERFUNCTION 					= 0x4B0B180C;   /*	指定されたユーザ関数が存在しない					*/
																	    	/*	Specified user funtion does not exist.				*/
    public const UInt32 MP_NOTPARAMETERTYPE 				= 0x4B0B180D;   /*	指定されたユーザ関数が存在しない					*/
																	    	/*	Specified parameter type does not exist.			*/
    public const UInt32 MP_ILLREGHANDLETYPE 				= 0x470B180E;   /*	異常なレジスタハンドル種別の指定					*/
																	    	/*	Erroneous register handle type specified.			*/
    public const UInt32 MP_ILLREGTYPE 						= 0x470B1810;   /*	異常なレジスタ種別の指定							*/
																	    	/*	Erroneous register type specified.					*/
    public const UInt32 MP_ILLREGSIZE 						= 0x470B1811;   /*	異常なレジスタサイズの指定(WORD以外)				*/
																	    	/*	Erroneous register size specified.(other than WORD)	*/
    public const UInt32 MP_REGNUMOVER 						= 0x470B1812;   /*	レジスタ有効範囲外									*/
																	    	/*	Out-of-range register								*/
    public const UInt32 MP_RELEASEWAIT 						= 0x470B1813;   /*	待ち状態解除										*/
																	    	/*	Waiting status released								*/
    public const UInt32 MP_PRIORITYOVER 					= 0x470B1814;   /*	設定できないPriority								*/
																	    	/*	Priority that can not be set						*/
    public const UInt32 MP_NOTCHANGEPRIORITY 				= 0x470B1815;   /*	待ち状態解除										*/
																	    	/*	Priority that cannot be changed						*/
    public const UInt32 MP_SEMAPHOREOVER 					= 0x470B1816;   /*	セマホ定義オーバー									*/
																	    	/*	Semaphore definition over							*/
    public const UInt32 MP_NOTSEMAPHOREHANDLE 				= 0x470B1817;   /*	未定義のセマホハンドル指定							*/
																	    	/*	Undefined semaphore handle specification			*/
    public const UInt32 MP_SEMAPHORELOCKED 					= 0x470B1818;   /*	指定セマホハンドルロック中							*/
																		    /*	Specified semaphore handle being locked				*/
    public const UInt32 MP_CONTINUE_RELEASEWAIT 			= 0x470B1819;   /*	ymcContinueWaitForCompletion中の待ち状態解除		*/
																	    	/*	Waiting status released during ymcContinueWaitForCompletion	*/
    public const UInt32 MP_NOTTABLENAME 					= 0x4B0B1820;   /*	未定義のTable名称									*/
																	    	/*	Undefined Table name								*/
    public const UInt32 MP_ILLTABLETYPE 					= 0x470B1821;   /*	不正なTableType										*/
																	    	/*	Illegal Table Type									*/
    public const UInt32 MP_TIMEOUTVALUEOVER 				= 0x470B1822;   /*	範囲外のタイムアウト値が指定された					*/
																	    	/*	Out-of-range timeout value has been specified		*/
    public const UInt32 MP_OTHER_ERR 						= 0x470B19FF;   /*	その他のエラー										*/
																			/*	Other errors										*/	
}
}