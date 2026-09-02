using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EAB RID: 20139
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefenceDefine : IStaticVariableResetter
	{
		// Token: 0x0603407B RID: 213115 RVA: 0x00D045FA File Offset: 0x00D027FA
		static TowerDefenceDefine()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(TowerDefenceDefine.CreateStaticDefaultValue), new Action(TowerDefenceDefine.ResetStaticDefaultValue));
		}

		// Token: 0x0603407C RID: 213116 RVA: 0x00D0461C File Offset: 0x00D0281C
		public static void CreateStaticDefaultValue()
		{
			TowerDefenceDefine.entranceSet = new HashSet<int>
			{
				8170,
				8180,
				8610
			};
			TowerDefenceDefine.tabText = new Dictionary<TowerDefenceDefine.ETabType, string>
			{
				{
					TowerDefenceDefine.ETabType.Single,
					"OnlineGymnasium_SingleListName"
				},
				{
					TowerDefenceDefine.ETabType.Online,
					"OnlineGymnasium_OnlineListName"
				}
			};
			TowerDefenceDefine.inBattleQualitySpriteKey = new Dictionary<InventoryDefine.EQuality, string>
			{
				{
					InventoryDefine.EQuality.White,
					"SP_VisionlQualityA"
				},
				{
					InventoryDefine.EQuality.Green,
					"SP_VisionlQualityB"
				},
				{
					InventoryDefine.EQuality.Blue,
					"SP_VisionlQualityC"
				},
				{
					InventoryDefine.EQuality.Purple,
					"SP_VisionlQualityD"
				},
				{
					InventoryDefine.EQuality.Orange,
					"SP_VisionlQualityE"
				}
			};
		}

		// Token: 0x0603407D RID: 213117 RVA: 0x00D046BF File Offset: 0x00D028BF
		public static void ResetStaticDefaultValue()
		{
			TowerDefenceDefine.entranceSet = null;
			TowerDefenceDefine.tabText = null;
			TowerDefenceDefine.inBattleQualitySpriteKey = null;
		}

		// Token: 0x0401E114 RID: 123156
		public const int DEFAULT_ID = 0;

		// Token: 0x0401E115 RID: 123157
		public const int NIL_PHANTOM_ID = -1;

		// Token: 0x0401E116 RID: 123158
		public const int INSTANCE_SUCCESS = 3018;

		// Token: 0x0401E117 RID: 123159
		public const int INSTANCE_FAIL = 3017;

		// Token: 0x0401E118 RID: 123160
		public const string EXIT_POPUP_TITLE = "TowerDefence_ExitTitle";

		// Token: 0x0401E119 RID: 123161
		public const string EXIT_POPUP_CONTENT = "TowerDefence_ExitContent";

		// Token: 0x0401E11A RID: 123162
		public const string EXIT_POPUP_TIPS_SINGLE = "TowerDefence_ExitTipsSingle";

		// Token: 0x0401E11B RID: 123163
		public const string EXIT_POPUP_TIPS_MULTI = "TowerDefence_ExitTipsMulti";

		// Token: 0x0401E11C RID: 123164
		public const string SETTLE_TEXT_EXIT_BTN = "Text_ButtonTextExit_Text";

		// Token: 0x0401E11D RID: 123165
		public const string SETTLE_TEXT_RESTART_BTN = "Text_ChallengeAgain_Text";

		// Token: 0x0401E11E RID: 123166
		public const string SETTLE_TEXT_TITLE_WIN = "Text_ChallengeSuccess_Text";

		// Token: 0x0401E11F RID: 123167
		public const string SETTLE_TEXT_TITLE_LOSE = "TowerDefenceSettlement01";

		// Token: 0x0401E120 RID: 123168
		public const string SETTLE_TEXT_HIGHEST_TIME = "TowerDefenceBestTime";

		// Token: 0x0401E121 RID: 123169
		public const string SETTLE_TEXT_HIGHEST_SCORE = "TowerDefence_GPint";

		// Token: 0x0401E122 RID: 123170
		public const string SETTLE_TEXT_RECORD_TITLE_CHALLENGE = "PrefabTextItem_3771425333_Text";

		// Token: 0x0401E123 RID: 123171
		public const string SETTLE_TEXT_RECORD_TITLE_CHALLENGE_LOSE = "TowerDefencelose";

		// Token: 0x0401E124 RID: 123172
		public const string SETTLE_TEXT_RECORD_TITLE_NORMAL = "PrefabTextItem_1350027209_Text";

		// Token: 0x0401E125 RID: 123173
		public const string LEVEL_TEXT_DIFFICULTY_NORMAL = "TowerDefence_DifficultyNormal";

		// Token: 0x0401E126 RID: 123174
		public const string LEVEL_TEXT_DIFFICULTY_HARD = "TowerDefence_DifficultyHard";

		// Token: 0x0401E127 RID: 123175
		public const string LEVEL_TEXT_SUB_LEVEL_LOCKED = "TowerDefence_SubLevelLocked";

		// Token: 0x0401E128 RID: 123176
		public const string LEVEL_TEXT_SUB_LEVEL_UNPASSED = "TowerDefence_SubLevelUnpassed";

		// Token: 0x0401E129 RID: 123177
		public const string LEVEL_TEXT_SUB_LEVEL_PASSED = "TowerDefence_SubLevelPassed";

		// Token: 0x0401E12A RID: 123178
		public const string LEVEL_TEXT_LEVEL_LOCKED_TIP = "TowerDefence_LevelLocked";

		// Token: 0x0401E12B RID: 123179
		public const string LEVEL_TEXT_PRE_NORMAL_UNPASSED = "OnlineGymnasium_LevelRst";

		// Token: 0x0401E12C RID: 123180
		public const string LEVEL_TEXT_BOSS_RUSH_LOCKED = "TowerDefence_Lcok_TipsText";

		// Token: 0x0401E12D RID: 123181
		public const string LEVEL_TEXT_COUNT_DOWN_WRAP = "ActivityMowing_UnlockCondition";

		// Token: 0x0401E12E RID: 123182
		public const string IN_BATTLE_SKILL_TITLE_BG_CURRENT = "T_LordGymTitleBgB";

		// Token: 0x0401E12F RID: 123183
		public const string IN_BATTLE_SKILL_TITLE_BG_NORMAL = "T_LordGymTitleBgA";

		// Token: 0x0401E130 RID: 123184
		public static HashSet<int> entranceSet;

		// Token: 0x0401E131 RID: 123185
		public static Dictionary<TowerDefenceDefine.ETabType, string> tabText;

		// Token: 0x0401E132 RID: 123186
		public static Dictionary<InventoryDefine.EQuality, string> inBattleQualitySpriteKey;

		// Token: 0x0200AE60 RID: 44640
		[NullableContext(0)]
		public enum EActivityType
		{
			// Token: 0x04036232 RID: 221746
			Defense = 1,
			// Token: 0x04036233 RID: 221747
			Attack
		}

		// Token: 0x0200AE61 RID: 44641
		[NullableContext(0)]
		public enum ETabType
		{
			// Token: 0x04036235 RID: 221749
			Single,
			// Token: 0x04036236 RID: 221750
			Online
		}
	}
}
