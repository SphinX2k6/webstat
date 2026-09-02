using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x0200680B RID: 26635
	[NullableContext(1)]
	[Nullable(0)]
	public class FishingDefine : IStaticVariableResetter
	{
		// Token: 0x06042646 RID: 271942 RVA: 0x01104873 File Offset: 0x01102A73
		static FishingDefine()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(FishingDefine.CreateStaticDefaultValue), new Action(FishingDefine.ResetStaticDefaultValue));
		}

		// Token: 0x06042647 RID: 271943 RVA: 0x011048A4 File Offset: 0x01102AA4
		public static void CreateStaticDefaultValue()
		{
			FishingDefine.fishingQualityColor = new Dictionary<int, string>
			{
				{
					0,
					"FFFFFFFF"
				},
				{
					1,
					"ffffff00"
				},
				{
					2,
					"C788E9FF"
				},
				{
					3,
					"7BCDF5FF"
				},
				{
					4,
					"7BCDF5FF"
				}
			};
			FishingDefine.fishingStateText = new Dictionary<int, string>
			{
				{
					1,
					"FishingReceiving"
				},
				{
					2,
					"FishingFinishing"
				},
				{
					0,
					"FishingReceiving"
				},
				{
					3,
					"FishingDoing"
				}
			};
			FishingDefine.fishingStateColorText = new Dictionary<int, string>
			{
				{
					1,
					"#59B4D3"
				},
				{
					2,
					"#5CC35E"
				},
				{
					0,
					"#59B4D3"
				},
				{
					3,
					"#FFFFFF"
				}
			};
			FishingDefine.fishingSelectStateColorText = new Dictionary<int, string>
			{
				{
					1,
					"#59B4D3"
				},
				{
					2,
					"#5CC35E"
				},
				{
					0,
					"#59B4D3"
				},
				{
					3,
					"#5B544A"
				}
			};
			FishingDefine.fishingQuestPoolColorText = new Dictionary<int, string>
			{
				{
					1,
					"#A69B62"
				},
				{
					2,
					"#6EA079"
				},
				{
					3,
					"#A69B62"
				},
				{
					4,
					"#5F89A1"
				},
				{
					5,
					"#6EA079"
				}
			};
			FishingDefine.fishingEntrustTypeText = new Dictionary<int, string>
			{
				{
					0,
					"FishingTagFishing"
				},
				{
					1,
					"FishingTagMaterial"
				},
				{
					2,
					"FishingTagDeliver"
				}
			};
			FishingDefine.fishingItemTypeText = new Dictionary<int, string>
			{
				{
					3,
					"Fishing_FishingKing"
				},
				{
					4,
					"Fishing_FishingMaterial"
				},
				{
					1,
					"Fishing_FishingNormal"
				},
				{
					2,
					"Fishing_FishingVariation"
				}
			};
			FishingDefine.fishingItemTimeText = new Dictionary<int, string>
			{
				{
					2,
					"Fishing_OnlyDay"
				},
				{
					3,
					"Fishing_OnlyNight"
				},
				{
					1,
					"Fishing_WholeDay"
				}
			};
			FishingDefine.fishingNodeTypeText = new Dictionary<int, string>
			{
				{
					1,
					"Fishing_TechType1"
				},
				{
					2,
					"Fishing_TechType2"
				},
				{
					3,
					"Fishing_TechType3"
				}
			};
			List<int> collection = new List<int>
			{
				71510101,
				71510102,
				71510103,
				71510201,
				71510202,
				71510203
			};
			FishingDefine.fishingItemList = new List<int>
			{
				38,
				37,
				29,
				30,
				31,
				27
			};
			FishingDefine.fishingItemList.AddRange(collection);
			FishingDefine.fishingEffectList = new List<int>
			{
				880700303,
				880700310,
				880700305,
				880700307
			};
		}

		// Token: 0x06042648 RID: 271944 RVA: 0x01104B74 File Offset: 0x01102D74
		public static void ResetStaticDefaultValue()
		{
			FishingDefine.fishingQualityColor = null;
			FishingDefine.fishingStateText = null;
			FishingDefine.fishingStateColorText = null;
			FishingDefine.fishingSelectStateColorText = null;
			FishingDefine.fishingQuestPoolColorText = null;
			FishingDefine.fishingEntrustTypeText = null;
			FishingDefine.fishingItemTypeText = null;
			FishingDefine.fishingItemTimeText = null;
			FishingDefine.fishingNodeTypeText = null;
			FishingDefine.fishingItemList = null;
			FishingDefine.fishingEffectList = null;
		}

		// Token: 0x04024F43 RID: 151363
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public static Dictionary<int, string> fishingQualityColor;

		// Token: 0x04024F44 RID: 151364
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public static Dictionary<int, string> fishingStateText;

		// Token: 0x04024F45 RID: 151365
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public static Dictionary<int, string> fishingStateColorText;

		// Token: 0x04024F46 RID: 151366
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public static Dictionary<int, string> fishingSelectStateColorText;

		// Token: 0x04024F47 RID: 151367
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public static Dictionary<int, string> fishingQuestPoolColorText;

		// Token: 0x04024F48 RID: 151368
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public static Dictionary<int, string> fishingEntrustTypeText;

		// Token: 0x04024F49 RID: 151369
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public static Dictionary<int, string> fishingItemTypeText;

		// Token: 0x04024F4A RID: 151370
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public static Dictionary<int, string> fishingItemTimeText;

		// Token: 0x04024F4B RID: 151371
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public static Dictionary<int, string> fishingNodeTypeText;

		// Token: 0x04024F4C RID: 151372
		[Nullable(2)]
		public static List<int> fishingItemList;

		// Token: 0x04024F4D RID: 151373
		[Nullable(2)]
		public static List<int> fishingEffectList;

		// Token: 0x04024F4E RID: 151374
		public const int UNVALID_ITEM_BLOCK_ID = -1;

		// Token: 0x04024F4F RID: 151375
		public const int BACKPACK_ROW_COUNT = 7;

		// Token: 0x04024F50 RID: 151376
		public const int BACKPACK_COL_COUNT = 8;

		// Token: 0x04024F51 RID: 151377
		public const int INTERACT_ROW_COUNT = 3;

		// Token: 0x04024F52 RID: 151378
		public const int INTERACT_COL_COUNT = 6;

		// Token: 0x04024F53 RID: 151379
		public const string EMPTY_SPRITE = "SP_GridEmpty";

		// Token: 0x04024F54 RID: 151380
		public const string DISABLE_SPRITE = "SP_GridSellDisable";

		// Token: 0x04024F55 RID: 151381
		public const string PREVIEW_SPRITE = "SP_GridFinsh";

		// Token: 0x04024F56 RID: 151382
		public const string SINGLE_OCCUPANCY_SPRITE = "SP_GridReplace";

		// Token: 0x04024F57 RID: 151383
		public const string MULTI_OCCUPANCY_SPRITE = "SP_GridError";

		// Token: 0x04024F58 RID: 151384
		public const string PROHIBIT_SPRITE = "SP_GridError";

		// Token: 0x04024F59 RID: 151385
		public const string FINISH_SPRITE = "SP_GridQuality";

		// Token: 0x04024F5A RID: 151386
		public const string OUTLINE_SPRITE = "SP_GridFinsh";

		// Token: 0x04024F5B RID: 151387
		public const string PREVIEW_ERROR_SPRITE = "SP_GridError";

		// Token: 0x04024F5C RID: 151388
		public const string PREVIEW_OCCUPANCY_SPRITE = "SP_GridReplace";

		// Token: 0x04024F5D RID: 151389
		public const string PREVIEW_MATCH_SPRITE = "SP_GridFinsh";

		// Token: 0x04024F5E RID: 151390
		public const string MATCH_SPRITE = "SP_GridFinsh";

		// Token: 0x04024F5F RID: 151391
		public const int FISHING_CURRENCY_ITEMID = 27;

		// Token: 0x04024F60 RID: 151392
		public const int FISHING_ENTRUST_ITEMID = 28;

		// Token: 0x04024F61 RID: 151393
		public const int FISHING_TECH_SHOW_ITEM_ONE = 38;

		// Token: 0x04024F62 RID: 151394
		public const int FISHING_TECH_SHOW_ITEM_TWO = 37;

		// Token: 0x04024F63 RID: 151395
		public const int FISHING_TECH_SHOW_ITEM_THREE = 29;

		// Token: 0x04024F64 RID: 151396
		public const int FISHING_TECH_SHOW_ITEM_FOUR = 30;

		// Token: 0x04024F65 RID: 151397
		public const int FISHING_TECH_SHOW_ITEM_FIVE = 31;

		// Token: 0x04024F66 RID: 151398
		public const int FISHING_DELEGATE_CURRENCY_ITEMID = 8;

		// Token: 0x04024F67 RID: 151399
		public const int BOMB_ITEMID = 32;

		// Token: 0x04024F68 RID: 151400
		public const int BAIT_ITEMID = 33;

		// Token: 0x04024F69 RID: 151401
		public const string SILVER_CUP_ICON = "T_IconCupSilver";

		// Token: 0x04024F6A RID: 151402
		public const string GOLD_CUP_ICON = "T_IconCupGold";

		// Token: 0x04024F6B RID: 151403
		public const string TIPS_ICON = "T_TipsWorldNavigation";

		// Token: 0x04024F6C RID: 151404
		public const int SAILING_TIME_HELP_ID = 185;

		// Token: 0x04024F6D RID: 151405
		public const int SAILING_DURABILITY_HELP_ID = 186;

		// Token: 0x04024F6E RID: 151406
		public const int SAILING_REPUTATION_HELP_ID = 188;

		// Token: 0x04024F6F RID: 151407
		public const int SAILING_QUEST_HELP_ID = 191;

		// Token: 0x04024F70 RID: 151408
		public const int SAILING_DAY_TIME = 18000;

		// Token: 0x04024F71 RID: 151409
		public const int SAILING_NIGHT_TIME = 68400;

		// Token: 0x04024F72 RID: 151410
		public const int FISHING_TECH_FIRST_NODE_AREA = 0;

		// Token: 0x04024F73 RID: 151411
		public const int FISHING_TECH_BEHIND_NODE_AREA = 3;

		// Token: 0x04024F74 RID: 151412
		public const int FISHING_TECH_LAST_NODE_AREA = 4;

		// Token: 0x04024F75 RID: 151413
		public const int PHOEBE_ID = 1506;

		// Token: 0x04024F76 RID: 151414
		public const int PLAYER_TECH_TYPE = 4;

		// Token: 0x04024F77 RID: 151415
		public const int PHOEBE_TECH_TYPE = 5;

		// Token: 0x04024F78 RID: 151416
		public const string FISHING_FEMALE_TEXTURE = "T_NavigationRoleFemale";

		// Token: 0x04024F79 RID: 151417
		public const string FISHING_MALE_TEXTURE = "T_NavigationRoleMale";

		// Token: 0x04024F7A RID: 151418
		public const string FISHING_PHOEBE_TEXTURE = "T_NavigationRoleFeibi";

		// Token: 0x04024F7B RID: 151419
		public const string FISHING_FEMALE_ICON_SPRITE = "SP_RoleFemale";

		// Token: 0x04024F7C RID: 151420
		public const string FISHING_MALE_ICON_SPRITE = "SP_RoleMale";

		// Token: 0x04024F7D RID: 151421
		public const string FISHING_PHOEBE_ICON_SPRITE = "SP_RoleFeibi";

		// Token: 0x04024F7E RID: 151422
		public const int QUEST_ROW_COUNT = 3;

		// Token: 0x04024F7F RID: 151423
		public const int QUEST_COL_COUNT = 5;

		// Token: 0x04024F80 RID: 151424
		public const int FISHING_POINT_MARK_ID = 9;

		// Token: 0x04024F81 RID: 151425
		public const int FISHING_POINT_QUEST_MARK_ID = 20;

		// Token: 0x04024F82 RID: 151426
		public const int FISHING_QUICK_SAIL_POOL = 3;

		// Token: 0x04024F83 RID: 151427
		public const int FISHING_SIZE_TYPE = 3;

		// Token: 0x04024F84 RID: 151428
		public const int CAGE_LIST_HELPID = 193;

		// Token: 0x04024F85 RID: 151429
		public const int TRAWL_LIST_HELPID = 194;

		// Token: 0x04024F86 RID: 151430
		public const int TRAWL_TECH_TYPE = 12;

		// Token: 0x04024F87 RID: 151431
		public const int FISHING_CAGE_TECH = 6;

		// Token: 0x04024F88 RID: 151432
		public static readonly FName materialProgressName = new FName("Progress");

		// Token: 0x04024F89 RID: 151433
		public const string FISHING_FEMALE_TECH_AUDIO = "play_vo_nvzhu_sys_fishing_techupgrade0";

		// Token: 0x04024F8A RID: 151434
		public const string FISHING_MALE_TECH_AUDIO = "play_vo_nanzhu_sys_fishing_techupgrade0";

		// Token: 0x04024F8B RID: 151435
		public const string FISHING_PHOEBE_TECH_AUDIO = "play_vo_feibi_sys_fishing_techupgrade0";

		// Token: 0x04024F8C RID: 151436
		public const int FISHING_TECH_AUDIO_SIZE = 3;

		// Token: 0x04024F8D RID: 151437
		public const string FISHING_TECH_MATERIAL_NOT_ENOUGHT = "<color=#c25757>{0}</color>";

		// Token: 0x04024F8E RID: 151438
		public const string FISHING_TECH_MATERIAL_ENOUGHT = "<color=#81764c>{0}</color>";

		// Token: 0x04024F8F RID: 151439
		public const string FISHING_TECH_MATERIAL_WHITE_ENOUGHT = "<color=#ffffff>{0}</color>";

		// Token: 0x04024F90 RID: 151440
		public const string FISHING_SKILL_BOMB_NOT_ENOUGH = "Fishing_SkillTip1";

		// Token: 0x04024F91 RID: 151441
		public const string FISHING_SKILL_IN_CD = "Fishing_SkillTip2";

		// Token: 0x04024F92 RID: 151442
		public const string FISHING_SKILL_BAIT_NOT_ENOUGH = "Fishing_SkillTip3";

		// Token: 0x04024F93 RID: 151443
		public const string FISHING_SKILL_BAIT_SUCCESS = "Fishing_SkillTip4";

		// Token: 0x04024F94 RID: 151444
		public const string FISHING_SKILL_BOMB_SUCCESS = "Fishing_SkillTip5";

		// Token: 0x04024F95 RID: 151445
		public const string FISHING_SKILL_BAIT_LIMIT = "Fishing_SkillTip6";

		// Token: 0x04024F96 RID: 151446
		public const int FISHING_NORMAL_ENTRUST_POOL = 4;

		// Token: 0x04024F97 RID: 151447
		public const int FISHING_HIGHT_VALUE_ENTRUST_POOL = 2;

		// Token: 0x04024F98 RID: 151448
		public const string FISHING_GLODEN_TEXTURE = "/Game/Aki/UI/UIResources/UiActivity/Image/Navigation/T_IconCupGold.T_IconCupGold";

		// Token: 0x04024F99 RID: 151449
		public const string FISHING_SILVER_TEXTURE = "/Game/Aki/UI/UIResources/UiActivity/Image/Navigation/T_IconCupSilver.T_IconCupSilver";
	}
}
