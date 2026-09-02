using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001BFA RID: 7162
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchDefine : IStaticVariableResetter
{
	// Token: 0x0600D086 RID: 53382 RVA: 0x00375E3D File Offset: 0x0037403D
	static FloroRanchDefine()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(FloroRanchDefine.CreateStaticDefaultValue), new Action(FloroRanchDefine.ResetStaticDefaultValue));
	}

	// Token: 0x0600D087 RID: 53383 RVA: 0x00375E5C File Offset: 0x0037405C
	public static void CreateStaticDefaultValue()
	{
		FloroRanchDefine.FloroRanchPopupRewardOffset = Vector.Create(0.0, 0.0, 100.0);
		FloroRanchDefine.FloroRanchRewardPopUpSpeed = Vector.Create(100.0, 100.0, 0.0);
		FloroRanchDefine.FloroRanchRewardRightDirection = Vector.Create(0.0, 1.0, 0.0);
		FloroRanchDefine.FloroRanchRewardLeftDirection = Vector.Create(0.0, -1.0, 0.0);
		FloroRanchDefine.FloroRanchSpeedList = new List<int>
		{
			1,
			3,
			5
		};
		FloroRanchDefine.FloroRanchEndlessSpeedList = new List<int>
		{
			1,
			3,
			5,
			50
		};
		FloroRanchDefine.FloroRanchSpeedTimeMap = new Dictionary<int, ISpeedTime>
		{
			{
				1,
				new SpeedTime
				{
					PopupRewardStayTime = 500f,
					PopupRewardWaitTime = 200f,
					BezierCurveTime = 500f,
					WageSettleWaitTime = 2500f,
					ToyLevelUpPlayRate = 1f
				}
			},
			{
				3,
				new SpeedTime
				{
					PopupRewardStayTime = 1000f,
					PopupRewardWaitTime = 500f,
					BezierCurveTime = 800f,
					WageSettleWaitTime = 3500f,
					ToyLevelUpPlayRate = 1f
				}
			},
			{
				5,
				new SpeedTime
				{
					PopupRewardStayTime = 2000f,
					PopupRewardWaitTime = 1000f,
					BezierCurveTime = 1200f,
					WageSettleWaitTime = 5000f,
					ToyLevelUpPlayRate = 1f
				}
			},
			{
				50,
				new SpeedTime
				{
					PopupRewardStayTime = 2000f,
					PopupRewardWaitTime = 1000f,
					BezierCurveTime = 12000f,
					WageSettleWaitTime = 15000f,
					ToyLevelUpPlayRate = 1f
				}
			}
		};
		FloroRanchDefine.FloroRanchStageTransitionMap = new Dictionary<EFloroRanchStageStateType, List<EFloroRanchStageStateType>>
		{
			{
				EFloroRanchStageStateType.None,
				new List<EFloroRanchStageStateType>
				{
					EFloroRanchStageStateType.GameStart
				}
			},
			{
				EFloroRanchStageStateType.GameStart,
				new List<EFloroRanchStageStateType>
				{
					EFloroRanchStageStateType.DailyInStage,
					EFloroRanchStageStateType.StageSuccess,
					EFloroRanchStageStateType.GameExit
				}
			},
			{
				EFloroRanchStageStateType.DailyInStage,
				new List<EFloroRanchStageStateType>
				{
					EFloroRanchStageStateType.StageFail,
					EFloroRanchStageStateType.StageSuccess,
					EFloroRanchStageStateType.GameExit
				}
			},
			{
				EFloroRanchStageStateType.StageFail,
				new List<EFloroRanchStageStateType>
				{
					EFloroRanchStageStateType.GameExit
				}
			},
			{
				EFloroRanchStageStateType.StageSuccess,
				new List<EFloroRanchStageStateType>
				{
					EFloroRanchStageStateType.DailyInStage,
					EFloroRanchStageStateType.GameExit
				}
			},
			{
				EFloroRanchStageStateType.GameExit,
				new List<EFloroRanchStageStateType>()
			}
		};
		FloroRanchDefine.FloroRanchDifficultyTextId = new Dictionary<EFloroRanchDifficulty, string>
		{
			{
				EFloroRanchDifficulty.Easy,
				"Farm_Difficulty1"
			},
			{
				EFloroRanchDifficulty.Middle,
				"Farm_Difficulty2"
			},
			{
				EFloroRanchDifficulty.Difficult,
				"Farm_Difficulty3"
			}
		};
		FloroRanchDefine.EntityTypePriority = new Dictionary<int, int>
		{
			{
				1,
				1
			},
			{
				2,
				2
			},
			{
				0,
				3
			}
		};
	}

	// Token: 0x0600D088 RID: 53384 RVA: 0x00376142 File Offset: 0x00374342
	public static void ResetStaticDefaultValue()
	{
		FloroRanchDefine.FloroRanchPopupRewardOffset = null;
		FloroRanchDefine.FloroRanchRewardPopUpSpeed = null;
		FloroRanchDefine.FloroRanchRewardRightDirection = null;
		FloroRanchDefine.FloroRanchRewardLeftDirection = null;
		FloroRanchDefine.FloroRanchSpeedList = null;
		FloroRanchDefine.FloroRanchEndlessSpeedList = null;
		FloroRanchDefine.FloroRanchSpeedTimeMap = null;
		FloroRanchDefine.FloroRanchStageTransitionMap = null;
		FloroRanchDefine.FloroRanchDifficultyTextId = null;
		FloroRanchDefine.EntityTypePriority = null;
	}

	// Token: 0x04006319 RID: 25369
	public const float FLORO_RANCH_REWARD_POPUP_TIME = 500f;

	// Token: 0x0400631A RID: 25370
	public const float FLORO_RANCH_REWARD_POPUP_STAY_TIME = 500f;

	// Token: 0x0400631B RID: 25371
	public const float FLORO_RANCH_REWARD_POPUP_STAY_TIME_2 = 1000f;

	// Token: 0x0400631C RID: 25372
	public const float FLORO_RANCH_REWARD_POPUP_STAY_TIME_3 = 2000f;

	// Token: 0x0400631D RID: 25373
	public const float FLORO_RANCH_REWARD_POPUP_STAY_TIME_4 = 2000f;

	// Token: 0x0400631E RID: 25374
	public const float FLORO_RANCH_REWARD_COIN_BEZIER_TIME = 500f;

	// Token: 0x0400631F RID: 25375
	public const float FLORO_RANCH_REWARD_COIN_BEZIER_TIME_2 = 800f;

	// Token: 0x04006320 RID: 25376
	public const float FLORO_RANCH_REWARD_COIN_BEZIER_TIME_3 = 1200f;

	// Token: 0x04006321 RID: 25377
	public const float FLORO_RANCH_REWARD_COIN_BEZIER_TIME_4 = 12000f;

	// Token: 0x04006322 RID: 25378
	public const float FLORO_RANCH_REWARD_COIN_BEZIER_WAIT_TIME = 20f;

	// Token: 0x04006323 RID: 25379
	public const float FLORO_RANCH_CHAT_PANEL_HIDE_DELAY = 3000f;

	// Token: 0x04006324 RID: 25380
	public const float FLORO_RANCH_GAME_PLAY_SPINE_SCALE = 0.53f;

	// Token: 0x04006325 RID: 25381
	public const float FLORO_RANCH_OTHER_VIEW_SPINE_SCALE = 0.96f;

	// Token: 0x04006326 RID: 25382
	public const float FLORO_RANCH_WEEKLY_SPINE_SCALE_FACTOR = 0.255f;

	// Token: 0x04006327 RID: 25383
	public const float FLORO_RANCH_REWARD_POPUP_WAIT_TIME = 200f;

	// Token: 0x04006328 RID: 25384
	public const float FLORO_RANCH_REWARD_POPUP_WAIT_TIME_2 = 500f;

	// Token: 0x04006329 RID: 25385
	public const float FLORO_RANCH_REWARD_POPUP_WAIT_TIME_3 = 1000f;

	// Token: 0x0400632A RID: 25386
	public const float FLORO_RANCH_REWARD_POPUP_WAIT_TIME_4 = 1000f;

	// Token: 0x0400632B RID: 25387
	public static Vector FloroRanchPopupRewardOffset;

	// Token: 0x0400632C RID: 25388
	public static Vector FloroRanchRewardPopUpSpeed;

	// Token: 0x0400632D RID: 25389
	public const float FLORO_RANCH_BEZIER_FACTOR = 0.5f;

	// Token: 0x0400632E RID: 25390
	public const float FLORO_RANCH_BEZIER_CENTER_FACTOR = 0.5f;

	// Token: 0x0400632F RID: 25391
	public static Vector FloroRanchRewardRightDirection;

	// Token: 0x04006330 RID: 25392
	public static Vector FloroRanchRewardLeftDirection;

	// Token: 0x04006331 RID: 25393
	public const float FLORO_RANCH_CARD_SHOW_ANIM_WAIT_TIME = 200f;

	// Token: 0x04006332 RID: 25394
	public const float FLORO_RANCH_CARD_HIDE_ANIM_WAIT_TIME = 200f;

	// Token: 0x04006333 RID: 25395
	public const float FLORO_RANCH_CARD_NORAML_WAIT_ANIM_TIME = 200f;

	// Token: 0x04006334 RID: 25396
	public const float FLORO_RANCH_CARD_MOVE_TIME = 500f;

	// Token: 0x04006335 RID: 25397
	public const float FLORO_RANCH_CARD_EAT_TIME = 1000f;

	// Token: 0x04006336 RID: 25398
	public const float FLORO_RANCH_CARD_BE_EAT_TIME = 1000f;

	// Token: 0x04006337 RID: 25399
	public const float FLORO_RANCH_CARD_SACRIFICE_TIME = 1250f;

	// Token: 0x04006338 RID: 25400
	public const float FLORO_RANCH_CARD_FUSION_HIDE_TIME = 1000f;

	// Token: 0x04006339 RID: 25401
	public const float FLORO_RANCH_CARD_FUSION_SHOW_TIME = 1000f;

	// Token: 0x0400633A RID: 25402
	public const float FLORO_RANCH_CARD_EVOLVE_UP_TIME = 1000f;

	// Token: 0x0400633B RID: 25403
	public const int FLORO_RANCH_CARD_ITEM_MAX_HIERACHY = 99;

	// Token: 0x0400633C RID: 25404
	public const float FLORO_RANCH_DAY_START_TASK_WAIT_TIME = 1000f;

	// Token: 0x0400633D RID: 25405
	public const float FLORO_RANCH_DAY_ACTION_WAIT_TIME = 1000f;

	// Token: 0x0400633E RID: 25406
	public const float FLORO_RANCH_DAY_WAGE_TASK_WAIT_TIME = 2500f;

	// Token: 0x0400633F RID: 25407
	public const float FLORO_RANCH_DAY_WAGE_TASK_WAIT_TIME_2 = 3500f;

	// Token: 0x04006340 RID: 25408
	public const float FLORO_RANCH_DAY_WAGE_TASK_WAIT_TIME_3 = 5000f;

	// Token: 0x04006341 RID: 25409
	public const float FLORO_RANCH_DAY_WAGE_TASK_WAIT_TIME_4 = 15000f;

	// Token: 0x04006342 RID: 25410
	public const int FLORO_RANCH_TERRAIN_ITEM_COUNT = 20;

	// Token: 0x04006343 RID: 25411
	public const int FLORO_RANCH_TERRAIN_TIP_HEIGHT_HIGHER = 380;

	// Token: 0x04006344 RID: 25412
	public const int FLORO_RANCH_TERRAIN_TIP_HEIGHT_SHORT = 240;

	// Token: 0x04006345 RID: 25413
	public const float FLORO_RANCH_CARD_ITEM_ANIM_GAP_TIME = 50f;

	// Token: 0x04006346 RID: 25414
	public const float FLORO_RANCH_TOY_SKILL_ANIM_WAIT_TIME = 200f;

	// Token: 0x04006347 RID: 25415
	public const float FLORO_RANCH_TOY_LEVELUP_PLAY_RATE_DEFAULT = 1f;

	// Token: 0x04006348 RID: 25416
	public const float FLORO_RANCH_TOY_LEVELUP_PLAY_RATE_MID = 1f;

	// Token: 0x04006349 RID: 25417
	public const float FLORO_RANCH_TOY_LEVELUP_PLAY_RATE_HIGH = 1f;

	// Token: 0x0400634A RID: 25418
	public const float FLORO_RANCH_TOY_LEVELUP_PLAY_RATE_MAX = 1f;

	// Token: 0x0400634B RID: 25419
	public const int FLORO_RANCH_POPUP_REWARD_YELLOW_COIN_COUNT = 100;

	// Token: 0x0400634C RID: 25420
	public const int FLORO_RANCH_POPUP_REWARD_RED_COIN_COUNT = 1000;

	// Token: 0x0400634D RID: 25421
	public const int FLORO_RANCH_GAME_PLAY_HELP_ID = 354;

	// Token: 0x0400634E RID: 25422
	public const int FLORO_RANCH_WEEKLY_GAME_PLAY_HELP_ID = 629;

	// Token: 0x0400634F RID: 25423
	public const int FLORO_RANCH_HELP_ID = 347;

	// Token: 0x04006350 RID: 25424
	public const float FLORO_RANCH_CARD_OFFSET_Z = 40f;

	// Token: 0x04006351 RID: 25425
	public const int FLORO_RANCH_DEFAULT_SPEED = 1;

	// Token: 0x04006352 RID: 25426
	public const int FLORO_RANCH_MID_SPEED = 3;

	// Token: 0x04006353 RID: 25427
	public const int FLORO_RANCH_HIGH_SPEED = 5;

	// Token: 0x04006354 RID: 25428
	public const int FLORO_RANCH_MAX_SPEED = 50;

	// Token: 0x04006355 RID: 25429
	public const int FLORO_RANCH_SKIP_SPEED = 99;

	// Token: 0x04006356 RID: 25430
	public static List<int> FloroRanchSpeedList;

	// Token: 0x04006357 RID: 25431
	public static List<int> FloroRanchEndlessSpeedList;

	// Token: 0x04006358 RID: 25432
	public static Dictionary<int, ISpeedTime> FloroRanchSpeedTimeMap;

	// Token: 0x04006359 RID: 25433
	public const string FLORO_RANCH_DEBUG_INFO_ITEM_PATH = "/Game/Aki/UI/UIResources/UiActivity/Prefabs/Activity25/Pasture/UiItem_FloroRanchEntityInfo.UiItem_FloroRanchEntityInfo";

	// Token: 0x0400635A RID: 25434
	public static Dictionary<EFloroRanchStageStateType, List<EFloroRanchStageStateType>> FloroRanchStageTransitionMap;

	// Token: 0x0400635B RID: 25435
	public static Dictionary<EFloroRanchDifficulty, string> FloroRanchDifficultyTextId;

	// Token: 0x0400635C RID: 25436
	public static Dictionary<int, int> EntityTypePriority;
}
