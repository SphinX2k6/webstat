using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.HonamiStory
{
	// Token: 0x02005C71 RID: 23665
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class HonamiStoryDefine : Singleton<HonamiStoryDefine>
	{
		// Token: 0x04021999 RID: 137625
		public const int HONAMI_GRID_ITEM_WIDTH = 86;

		// Token: 0x0402199A RID: 137626
		public const int HONAMI_GRID_ITEM_HEIGHT = 86;

		// Token: 0x0402199B RID: 137627
		public const int HONAMI_GRID_ITEM_WIDTH_MOBILE = 134;

		// Token: 0x0402199C RID: 137628
		public const int HONAMI_GRID_ITEM_HEIGHT_MOBILE = 134;

		// Token: 0x0402199D RID: 137629
		public const int HONAMI_GRID_ITEM_HORIZONTAL_INTERVAL = 2;

		// Token: 0x0402199E RID: 137630
		public const int HONAMI_GRID_ITEM_VERTICAL_INTERVAL = 2;

		// Token: 0x0402199F RID: 137631
		public const int HONAMI_GRID_ITEM_HORIZONTAL_INTERVAL_MOBILE = 2;

		// Token: 0x040219A0 RID: 137632
		public const int HONAMI_GRID_ITEM_VERTICAL_INTERVAL_MOBILE = 2;

		// Token: 0x040219A1 RID: 137633
		public const int HONAMI_ROLE_TEAM_COUNT = 3;

		// Token: 0x040219A2 RID: 137634
		public const int HONAMI_ROLE_SLOT_OFFSET = 100;

		// Token: 0x040219A3 RID: 137635
		public const int HONAMI_ROLE_SLOT_MAX = 6;

		// Token: 0x040219A4 RID: 137636
		public const int HONAMI_DUNGEON_DEFAULT_AREA_ID = 1;

		// Token: 0x040219A5 RID: 137637
		public const int HONAMI_ROLE_VIRTUAL_SCORE = 100;

		// Token: 0x040219A6 RID: 137638
		public const string HONAMI_EMPTY_GRID_BG = "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity28/HonamiStory/HonamiStoryBackpack/SP_GridEmpty.SP_GridEmpty";

		// Token: 0x040219A7 RID: 137639
		public const string HONAMI_MASCOT_EMPTY_PATH = "/Game/Aki/UI/UIResources/UiActivity/Image/Activity28/HonamiStory/HonamiStoryHead/T_HonamiStoryHeadBEmpty.T_HonamiStoryHeadBEmpty";

		// Token: 0x040219A8 RID: 137640
		public const string HONAMI_MASCOT_EMPTY_BIG_PATH = "/Game/Aki/UI/UIResources/UiActivity/Image/Activity28/HonamiStory/HonamiStoryHead/T_HonamiStoryHeadAEmpty.T_HonamiStoryHeadAEmpty";

		// Token: 0x040219A9 RID: 137641
		public const int HONAMI_DUNGEON_ENTRANCE_ID = 1521;

		// Token: 0x040219AA RID: 137642
		public const float HONAMI_ENABLE_ALPHA = 1f;

		// Token: 0x040219AB RID: 137643
		public const float HONAMI_DISABLE_ALPHA = 0.4f;

		// Token: 0x040219AC RID: 137644
		public const int HONAMI_BAKCPACK_CLICK_CD = 300;

		// Token: 0x040219AD RID: 137645
		public const int HONAMI_DUNGEON_ID = 8760;

		// Token: 0x040219AE RID: 137646
		public const int HONAMI_MAIN_QUEST_ID = 880000044;

		// Token: 0x040219AF RID: 137647
		public const int HONAMI_MAX_SHOW_REVENUE = 99999999;

		// Token: 0x040219B0 RID: 137648
		public const string RICHTXT_QUEST = "<color=#b3dffa>{0}</color>";

		// Token: 0x040219B1 RID: 137649
		public readonly Dictionary<EHonamiStoryItemType, string> honamiItemTypeMap = new Dictionary<EHonamiStoryItemType, string>
		{
			{
				EHonamiStoryItemType.Plugin,
				"HonamiStory_ItemType_Plugin"
			},
			{
				EHonamiStoryItemType.Normal,
				"HonamiStory_ItemType_Normal"
			}
		};

		// Token: 0x040219B2 RID: 137650
		public readonly Dictionary<EHonamiStoryBackpackType, EHonamiStoryBackpack> HonamiBackpackTypeMap = new Dictionary<EHonamiStoryBackpackType, EHonamiStoryBackpack>
		{
			{
				EHonamiStoryBackpackType.Inventory,
				EHonamiStoryBackpack.Inventory
			},
			{
				EHonamiStoryBackpackType.Backpack,
				EHonamiStoryBackpack.Backpack
			},
			{
				EHonamiStoryBackpackType.PickUpBox,
				EHonamiStoryBackpack.PickUpBox
			},
			{
				EHonamiStoryBackpackType.Player,
				EHonamiStoryBackpack.Player
			}
		};

		// Token: 0x040219B3 RID: 137651
		public readonly Dictionary<EHonamiStoryCollectState, string> collectStateToScoreRewardMap = new Dictionary<EHonamiStoryCollectState, string>
		{
			{
				EHonamiStoryCollectState.Unfinished,
				"SP_HonamiStoryScoreReward_Unfinished"
			},
			{
				EHonamiStoryCollectState.Finished,
				"SP_HonamiStoryScoreReward_Finished"
			},
			{
				EHonamiStoryCollectState.GotReward,
				"SP_HonamiStoryScoreReward_GotReward"
			}
		};

		// Token: 0x040219B4 RID: 137652
		public readonly Dictionary<EHonamiStoryCollectState, string> honamiCollectStateMap = new Dictionary<EHonamiStoryCollectState, string>
		{
			{
				EHonamiStoryCollectState.Unfinished,
				"HonamiStory_Collect_Unfinished"
			},
			{
				EHonamiStoryCollectState.Finished,
				"HonamiStory_Collect_Finished"
			},
			{
				EHonamiStoryCollectState.GotReward,
				"HonamiStory_Collect_GotReward"
			}
		};

		// Token: 0x040219B5 RID: 137653
		public readonly Dictionary<EHonamiStoryWeaponType, string> honamiWeaponTypeMap = new Dictionary<EHonamiStoryWeaponType, string>
		{
			{
				EHonamiStoryWeaponType.Attack,
				"HonamiStory_Weapon_Type_1"
			},
			{
				EHonamiStoryWeaponType.Explore,
				"HonamiStory_Weapon_Type_2"
			},
			{
				EHonamiStoryWeaponType.Support,
				"HonamiStory_Weapon_Type_3"
			}
		};

		// Token: 0x040219B6 RID: 137654
		public const int HONAMI_HELP_MAIN = 431;

		// Token: 0x040219B7 RID: 137655
		public const int HONAMI_HELP_BACKPACK = 434;

		// Token: 0x040219B8 RID: 137656
		public const int HONAMI_HELP_WEAPONSELECT = 436;

		// Token: 0x040219B9 RID: 137657
		public const int HONAMI_HELP_READYGO = 437;

		// Token: 0x040219BA RID: 137658
		public const int HONAMI_HELP_TALENT = 439;

		// Token: 0x040219BB RID: 137659
		public const int HONAMI_HELP_WANTED = 440;

		// Token: 0x040219BC RID: 137660
		public const int HONAMI_HELP_SHOP = 441;

		// Token: 0x040219BD RID: 137661
		public const int HONAMI_HELP_COLLECT = 442;
	}
}
