using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using FilterDefine;

namespace CSharpScript.Game.Module.Inventory
{
	// Token: 0x02005B86 RID: 23430
	[NullableContext(1)]
	[Nullable(0)]
	public class InventoryDefine
	{
		// Token: 0x0402162C RID: 136748
		public const int CONFIG_ID = 1;

		// Token: 0x0402162D RID: 136749
		public const int LEVEL = 2;

		// Token: 0x0402162E RID: 136750
		public const int QUALITY_ID = 3;

		// Token: 0x0402162F RID: 136751
		public const int COUNT = 4;

		// Token: 0x04021630 RID: 136752
		public const int SORT_INDEX = 5;

		// Token: 0x04021631 RID: 136753
		public const int UNIQUE_ID = 6;

		// Token: 0x04021632 RID: 136754
		public const int COMMON_COIN = 2;

		// Token: 0x04021633 RID: 136755
		public const int ADVANCED_COIN = 3;

		// Token: 0x04021634 RID: 136756
		public const int WAVEPLATE_COIN = 5;

		// Token: 0x04021635 RID: 136757
		public const int WAVEPLATE_CRYSTAL_COIN = 6;

		// Token: 0x04021636 RID: 136758
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<FilterDefine.EFilterType, InventoryDefine.ESettingGridType> recFilterRuleToGirdType = new Dictionary<FilterDefine.EFilterType, InventoryDefine.ESettingGridType>
		{
			{
				FilterDefine.EFilterType.VisionDestroyQuality,
				InventoryDefine.ESettingGridType.Small
			},
			{
				FilterDefine.EFilterType.PhantomManageCost,
				InventoryDefine.ESettingGridType.Small
			},
			{
				FilterDefine.EFilterType.VisionDestroyFetterGroup,
				InventoryDefine.ESettingGridType.Big
			},
			{
				FilterDefine.EFilterType.PhantomManageFirstMainProp,
				InventoryDefine.ESettingGridType.Big
			}
		};

		// Token: 0x04021637 RID: 136759
		[StaticVariableRuleIgnore]
		public static readonly int[] weaponIdRange = new int[]
		{
			20000000,
			29999999
		};

		// Token: 0x04021638 RID: 136760
		[StaticVariableRuleIgnore]
		public static readonly int[] phantomIdRange = new int[]
		{
			60000000,
			60999999
		};

		// Token: 0x04021639 RID: 136761
		[StaticVariableRuleIgnore]
		public static readonly int[] phantomSpecificIdRange = new int[]
		{
			69000000,
			69999999
		};

		// Token: 0x0402163A RID: 136762
		[StaticVariableRuleIgnore]
		public static readonly int[] roleIdRange = new int[]
		{
			1000,
			2999
		};

		// Token: 0x0402163B RID: 136763
		[StaticVariableRuleIgnore]
		public static readonly int[] virtualIdRange = new int[]
		{
			1,
			999
		};

		// Token: 0x0402163C RID: 136764
		[StaticVariableRuleIgnore]
		public static readonly int[] cardIdRange = new int[]
		{
			80060000,
			80069999
		};

		// Token: 0x0402163D RID: 136765
		[StaticVariableRuleIgnore]
		public static readonly int[] previewItemIdRange = new int[]
		{
			30000,
			39999
		};

		// Token: 0x0402163E RID: 136766
		[StaticVariableRuleIgnore]
		public static readonly int[] rogueCurrencyIdRange = new int[]
		{
			80100000,
			80100099
		};

		// Token: 0x0402163F RID: 136767
		[StaticVariableRuleIgnore]
		public static readonly int[] rogueResCurrencyIdRange = new int[]
		{
			80100100,
			80109999
		};

		// Token: 0x04021640 RID: 136768
		[StaticVariableRuleIgnore]
		public static readonly int[] weaponSkinIdRange = new int[]
		{
			80080000,
			80089999
		};

		// Token: 0x04021641 RID: 136769
		[StaticVariableRuleIgnore]
		public static readonly int[] PhoneChatDialogItemRange = new int[]
		{
			80810000,
			80819999
		};

		// Token: 0x04021642 RID: 136770
		[StaticVariableRuleIgnore]
		public static readonly int[] PhoneChatBackGroundItemRange = new int[]
		{
			80820000,
			80829999
		};

		// Token: 0x04021643 RID: 136771
		[StaticVariableRuleIgnore]
		public static readonly int[] roleSkinIdRange = new int[]
		{
			81000000,
			81999999
		};

		// Token: 0x04021644 RID: 136772
		[StaticVariableRuleIgnore]
		public static readonly int[] playerHeadRange = new int[]
		{
			82000000,
			82999999
		};

		// Token: 0x04021645 RID: 136773
		[StaticVariableRuleIgnore]
		public static readonly int[] playerTitleRange = new int[]
		{
			82000000,
			82999999
		};

		// Token: 0x04021646 RID: 136774
		[StaticVariableRuleIgnore]
		public static readonly int[] DangoAbyssItemRange = new int[]
		{
			83000000,
			83999999
		};

		// Token: 0x04021647 RID: 136775
		[StaticVariableRuleIgnore]
		public static readonly int[] flySkinIdRange = new int[]
		{
			84000000,
			84999999
		};

		// Token: 0x04021648 RID: 136776
		[StaticVariableRuleIgnore]
		public static readonly int[] calabashSkinIdRange = new int[]
		{
			86000000,
			86099999
		};

		// Token: 0x04021649 RID: 136777
		[StaticVariableRuleIgnore]
		public static readonly int[] InfrastructureItemRange = new int[]
		{
			86100000,
			86199999
		};

		// Token: 0x0402164A RID: 136778
		[StaticVariableRuleIgnore]
		public static readonly int[] PhantomArenaCardItemRange = new int[]
		{
			700000,
			750000
		};

		// Token: 0x0402164B RID: 136779
		[StaticVariableRuleIgnore]
		public static readonly int[] PhantomArenaBadgeItemRange = new int[]
		{
			75001,
			80000
		};

		// Token: 0x0402164C RID: 136780
		[StaticVariableRuleIgnore]
		public static readonly int[] HonamiStoryItemRange = new int[]
		{
			87000000,
			87999999
		};

		// Token: 0x0402164D RID: 136781
		[StaticVariableRuleIgnore]
		public static readonly int[] HonamiStoryWeaponRange = new int[]
		{
			88000000,
			88999999
		};

		// Token: 0x0402164E RID: 136782
		[StaticVariableRuleIgnore]
		public static readonly int[] MotorFrameItemRange = new int[]
		{
			89400000,
			89499999
		};

		// Token: 0x0402164F RID: 136783
		[StaticVariableRuleIgnore]
		public static readonly int[] MotorStickerItemRange = new int[]
		{
			89100000,
			89199999
		};

		// Token: 0x04021650 RID: 136784
		[StaticVariableRuleIgnore]
		public static readonly int[] MotorDecorationItemRange = new int[]
		{
			89300000,
			89399999
		};

		// Token: 0x04021651 RID: 136785
		[StaticVariableRuleIgnore]
		public static readonly int[] MotorSkinItemRange = new int[]
		{
			89200000,
			89299999
		};

		// Token: 0x04021652 RID: 136786
		[StaticVariableRuleIgnore]
		public static readonly int[] FurnitureItemRange = new int[]
		{
			80830001,
			80839999
		};

		// Token: 0x04021653 RID: 136787
		[StaticVariableRuleIgnore]
		public static readonly int[] OrnamentItemRange = new int[]
		{
			80870001,
			80879999
		};

		// Token: 0x04021654 RID: 136788
		[StaticVariableRuleIgnore]
		public static readonly int[] PinballRoleItemRange = new int[]
		{
			80850001,
			80859999
		};

		// Token: 0x04021655 RID: 136789
		[StaticVariableRuleIgnore]
		public static readonly int[] PinballWeaponItemRange = new int[]
		{
			80860001,
			80869999
		};

		// Token: 0x04021656 RID: 136790
		[StaticVariableRuleIgnore]
		public static readonly int[] roverRogueCurrencyIdRange = new int[]
		{
			89000000,
			89000099
		};

		// Token: 0x04021657 RID: 136791
		public const int MANAGE_CONFIG_FUNCTION_ID = 10096;

		// Token: 0x04021658 RID: 136792
		public const int MANAGE_CONFIG_HELP_ID = 356;

		// Token: 0x04021659 RID: 136793
		public const string EMPTY_CONFIG_TEXT_ID = "PhantomProject_EmptyProject";

		// Token: 0x0402165A RID: 136794
		public const string EMPTY_RULE_TEXT_ID = "PhantomProject_EmptyChose";

		// Token: 0x0402165B RID: 136795
		public const string EMPTY_CHECK_TEXT_ID = "PhantomProject_Tips02";

		// Token: 0x0402165C RID: 136796
		public const int MANAGE_CONFIG_MAX_COUNT = 10;

		// Token: 0x0200BB91 RID: 48017
		[NullableContext(0)]
		public enum EItemMainTypeId
		{
			// Token: 0x04039DDB RID: 237019
			Virtual,
			// Token: 0x04039DDC RID: 237020
			Common,
			// Token: 0x04039DDD RID: 237021
			Weapon,
			// Token: 0x04039DDE RID: 237022
			Phantom,
			// Token: 0x04039DDF RID: 237023
			Collection,
			// Token: 0x04039DE0 RID: 237024
			Material,
			// Token: 0x04039DE1 RID: 237025
			Mission,
			// Token: 0x04039DE2 RID: 237026
			Special,
			// Token: 0x04039DE3 RID: 237027
			Card,
			// Token: 0x04039DE4 RID: 237028
			DangoPluginItem,
			// Token: 0x04039DE5 RID: 237029
			PinballWeapon
		}

		// Token: 0x0200BB92 RID: 48018
		[NullableContext(0)]
		public enum EItemType
		{
			// Token: 0x04039DE7 RID: 237031
			Virtual,
			// Token: 0x04039DE8 RID: 237032
			Common,
			// Token: 0x04039DE9 RID: 237033
			Weapon,
			// Token: 0x04039DEA RID: 237034
			WeaponMaterial = 4,
			// Token: 0x04039DEB RID: 237035
			Task = 7,
			// Token: 0x04039DEC RID: 237036
			Phantom = 9,
			// Token: 0x04039DED RID: 237037
			Gift = 11,
			// Token: 0x04039DEE RID: 237038
			SpecialItem = 13,
			// Token: 0x04039DEF RID: 237039
			Card,
			// Token: 0x04039DF0 RID: 237040
			RogueCurrency,
			// Token: 0x04039DF1 RID: 237041
			WeaponSkin = 18,
			// Token: 0x04039DF2 RID: 237042
			RoleSkin,
			// Token: 0x04039DF3 RID: 237043
			RecallActivityScore,
			// Token: 0x04039DF4 RID: 237044
			PlayerHead,
			// Token: 0x04039DF5 RID: 237045
			PlayerTitle,
			// Token: 0x04039DF6 RID: 237046
			FlySkin = 24,
			// Token: 0x04039DF7 RID: 237047
			HonamiStoryItem = 28,
			// Token: 0x04039DF8 RID: 237048
			HonamiStoryWeapon,
			// Token: 0x04039DF9 RID: 237049
			MotorSticker,
			// Token: 0x04039DFA RID: 237050
			MotorDecoration,
			// Token: 0x04039DFB RID: 237051
			MotorFrame,
			// Token: 0x04039DFC RID: 237052
			MotorSkin,
			// Token: 0x04039DFD RID: 237053
			Ornament = 35,
			// Token: 0x04039DFE RID: 237054
			PinballWeapon,
			// Token: 0x04039DFF RID: 237055
			PinballRole,
			// Token: 0x04039E00 RID: 237056
			CookMenu = 60000,
			// Token: 0x04039E01 RID: 237057
			CookFood,
			// Token: 0x04039E02 RID: 237058
			ForgingFormula,
			// Token: 0x04039E03 RID: 237059
			ComposeFormula,
			// Token: 0x04039E04 RID: 237060
			Phonograph,
			// Token: 0x04039E05 RID: 237061
			ShipTowerBuff,
			// Token: 0x04039E06 RID: 237062
			AbyssItem,
			// Token: 0x04039E07 RID: 237063
			BirthdayItem,
			// Token: 0x04039E08 RID: 237064
			PayShopCoupon,
			// Token: 0x04039E09 RID: 237065
			PhantomArenaCard,
			// Token: 0x04039E0A RID: 237066
			PhantomArenaBadge,
			// Token: 0x04039E0B RID: 237067
			CalabashSkin = 60015,
			// Token: 0x04039E0C RID: 237068
			InfrastructureItem,
			// Token: 0x04039E0D RID: 237069
			PhoneChatDialog,
			// Token: 0x04039E0E RID: 237070
			PhoneChatBackGround,
			// Token: 0x04039E0F RID: 237071
			Furniture
		}

		// Token: 0x0200BB93 RID: 48019
		[NullableContext(0)]
		public enum EItemInfoDisplayType
		{
			// Token: 0x04039E11 RID: 237073
			StackCount,
			// Token: 0x04039E12 RID: 237074
			Level
		}

		// Token: 0x0200BB94 RID: 48020
		[NullableContext(0)]
		public enum EItemDataFunctionType
		{
			// Token: 0x04039E14 RID: 237076
			Lock,
			// Token: 0x04039E15 RID: 237077
			Deprecate
		}

		// Token: 0x0200BB95 RID: 48021
		[NullableContext(0)]
		public enum EItemDataType
		{
			// Token: 0x04039E17 RID: 237079
			CommonItem,
			// Token: 0x04039E18 RID: 237080
			RoleItem,
			// Token: 0x04039E19 RID: 237081
			WeaponItem,
			// Token: 0x04039E1A RID: 237082
			PhantomItem,
			// Token: 0x04039E1B RID: 237083
			PhantomCustomize,
			// Token: 0x04039E1C RID: 237084
			VirtualItem,
			// Token: 0x04039E1D RID: 237085
			CardItem,
			// Token: 0x04039E1E RID: 237086
			PreviewItem,
			// Token: 0x04039E1F RID: 237087
			RogueCurrency,
			// Token: 0x04039E20 RID: 237088
			RogueResCurrency,
			// Token: 0x04039E21 RID: 237089
			WeaponSkinItem,
			// Token: 0x04039E22 RID: 237090
			RoleSkinItem,
			// Token: 0x04039E23 RID: 237091
			PlayerHeadItem,
			// Token: 0x04039E24 RID: 237092
			DangoAbyssItem,
			// Token: 0x04039E25 RID: 237093
			FlySkinItem,
			// Token: 0x04039E26 RID: 237094
			PhantomArenaCard,
			// Token: 0x04039E27 RID: 237095
			PhantomArenaBadge,
			// Token: 0x04039E28 RID: 237096
			HonamiStoryItem,
			// Token: 0x04039E29 RID: 237097
			CalabashSkinItem,
			// Token: 0x04039E2A RID: 237098
			HonamiStoryWeapon,
			// Token: 0x04039E2B RID: 237099
			InfrastructureItem,
			// Token: 0x04039E2C RID: 237100
			MotorStickerItem,
			// Token: 0x04039E2D RID: 237101
			PhoneChatDialog,
			// Token: 0x04039E2E RID: 237102
			PhoneChatBackGround,
			// Token: 0x04039E2F RID: 237103
			FurnitureItem,
			// Token: 0x04039E30 RID: 237104
			MotorFrameItem,
			// Token: 0x04039E31 RID: 237105
			MotorDecorationItem,
			// Token: 0x04039E32 RID: 237106
			MotorSkinItem,
			// Token: 0x04039E33 RID: 237107
			OrnamentItem,
			// Token: 0x04039E34 RID: 237108
			PinballRoleItem,
			// Token: 0x04039E35 RID: 237109
			PinballWeaponItem,
			// Token: 0x04039E36 RID: 237110
			RoverRogueCurrency
		}

		// Token: 0x0200BB96 RID: 48022
		public interface IItemViewDataInfo
		{
			// Token: 0x1700A996 RID: 43414
			// (get) Token: 0x0604DA47 RID: 318023
			// (set) Token: 0x0604DA48 RID: 318024
			int ConfigId { get; set; }

			// Token: 0x1700A997 RID: 43415
			// (get) Token: 0x0604DA49 RID: 318025
			// (set) Token: 0x0604DA4A RID: 318026
			int Count { get; set; }

			// Token: 0x1700A998 RID: 43416
			// (get) Token: 0x0604DA4B RID: 318027
			// (set) Token: 0x0604DA4C RID: 318028
			int StackId { get; set; }

			// Token: 0x1700A999 RID: 43417
			// (get) Token: 0x0604DA4D RID: 318029
			// (set) Token: 0x0604DA4E RID: 318030
			int QualityId { get; set; }

			// Token: 0x1700A99A RID: 43418
			// (get) Token: 0x0604DA4F RID: 318031
			// (set) Token: 0x0604DA50 RID: 318032
			bool IsLock { get; set; }

			// Token: 0x1700A99B RID: 43419
			// (get) Token: 0x0604DA51 RID: 318033
			// (set) Token: 0x0604DA52 RID: 318034
			bool IsDeprecate { get; set; }

			// Token: 0x1700A99C RID: 43420
			// (get) Token: 0x0604DA53 RID: 318035
			// (set) Token: 0x0604DA54 RID: 318036
			bool IsNewItem { get; set; }

			// Token: 0x1700A99D RID: 43421
			// (get) Token: 0x0604DA55 RID: 318037
			// (set) Token: 0x0604DA56 RID: 318038
			InventoryDefine.EItemDataType ItemDataType { get; set; }

			// Token: 0x1700A99E RID: 43422
			// (get) Token: 0x0604DA57 RID: 318039
			// (set) Token: 0x0604DA58 RID: 318040
			ItemDataBase ItemDataBase { get; set; }

			// Token: 0x1700A99F RID: 43423
			// (get) Token: 0x0604DA59 RID: 318041
			// (set) Token: 0x0604DA5A RID: 318042
			bool HasRedDot { get; set; }

			// Token: 0x1700A9A0 RID: 43424
			// (get) Token: 0x0604DA5B RID: 318043
			// (set) Token: 0x0604DA5C RID: 318044
			ItemViewDefine.EItemOperationMode ItemOperationMode { get; set; }

			// Token: 0x1700A9A1 RID: 43425
			// (get) Token: 0x0604DA5D RID: 318045
			// (set) Token: 0x0604DA5E RID: 318046
			bool IsSelectOn { get; set; }

			// Token: 0x1700A9A2 RID: 43426
			// (get) Token: 0x0604DA5F RID: 318047
			// (set) Token: 0x0604DA60 RID: 318048
			int SelectOnNum { get; set; }
		}

		// Token: 0x0200BB97 RID: 48023
		[Nullable(0)]
		public class ItemViewDataInfo : InventoryDefine.IItemViewDataInfo
		{
			// Token: 0x0604DA61 RID: 318049 RVA: 0x0157368C File Offset: 0x0157188C
			public ItemViewDataInfo(int configId, int count, int stackId, int qualityId, bool isLock, bool isDeprecate, bool isNewItem, InventoryDefine.EItemDataType itemDataType, ItemDataBase itemDataBase, bool hasRedDot, ItemViewDefine.EItemOperationMode itemOperationMode, bool isSelectOn, int selectOnNum)
			{
			}

			// Token: 0x1700A9A3 RID: 43427
			// (get) Token: 0x0604DA62 RID: 318050 RVA: 0x01573704 File Offset: 0x01571904
			// (set) Token: 0x0604DA63 RID: 318051 RVA: 0x0157370C File Offset: 0x0157190C
			public int ConfigId { get; set; } = configId;

			// Token: 0x1700A9A4 RID: 43428
			// (get) Token: 0x0604DA64 RID: 318052 RVA: 0x01573715 File Offset: 0x01571915
			// (set) Token: 0x0604DA65 RID: 318053 RVA: 0x0157371D File Offset: 0x0157191D
			public int Count { get; set; } = count;

			// Token: 0x1700A9A5 RID: 43429
			// (get) Token: 0x0604DA66 RID: 318054 RVA: 0x01573726 File Offset: 0x01571926
			// (set) Token: 0x0604DA67 RID: 318055 RVA: 0x0157372E File Offset: 0x0157192E
			public int StackId { get; set; } = stackId;

			// Token: 0x1700A9A6 RID: 43430
			// (get) Token: 0x0604DA68 RID: 318056 RVA: 0x01573737 File Offset: 0x01571937
			// (set) Token: 0x0604DA69 RID: 318057 RVA: 0x0157373F File Offset: 0x0157193F
			public int QualityId { get; set; } = qualityId;

			// Token: 0x1700A9A7 RID: 43431
			// (get) Token: 0x0604DA6A RID: 318058 RVA: 0x01573748 File Offset: 0x01571948
			// (set) Token: 0x0604DA6B RID: 318059 RVA: 0x01573750 File Offset: 0x01571950
			public bool IsLock { get; set; } = isLock;

			// Token: 0x1700A9A8 RID: 43432
			// (get) Token: 0x0604DA6C RID: 318060 RVA: 0x01573759 File Offset: 0x01571959
			// (set) Token: 0x0604DA6D RID: 318061 RVA: 0x01573761 File Offset: 0x01571961
			public bool IsDeprecate { get; set; } = isDeprecate;

			// Token: 0x1700A9A9 RID: 43433
			// (get) Token: 0x0604DA6E RID: 318062 RVA: 0x0157376A File Offset: 0x0157196A
			// (set) Token: 0x0604DA6F RID: 318063 RVA: 0x01573772 File Offset: 0x01571972
			public bool IsNewItem { get; set; } = isNewItem;

			// Token: 0x1700A9AA RID: 43434
			// (get) Token: 0x0604DA70 RID: 318064 RVA: 0x0157377B File Offset: 0x0157197B
			// (set) Token: 0x0604DA71 RID: 318065 RVA: 0x01573783 File Offset: 0x01571983
			public InventoryDefine.EItemDataType ItemDataType { get; set; } = itemDataType;

			// Token: 0x1700A9AB RID: 43435
			// (get) Token: 0x0604DA72 RID: 318066 RVA: 0x0157378C File Offset: 0x0157198C
			// (set) Token: 0x0604DA73 RID: 318067 RVA: 0x01573794 File Offset: 0x01571994
			public ItemDataBase ItemDataBase { get; set; } = itemDataBase;

			// Token: 0x1700A9AC RID: 43436
			// (get) Token: 0x0604DA74 RID: 318068 RVA: 0x0157379D File Offset: 0x0157199D
			// (set) Token: 0x0604DA75 RID: 318069 RVA: 0x015737A5 File Offset: 0x015719A5
			public bool HasRedDot { get; set; } = hasRedDot;

			// Token: 0x1700A9AD RID: 43437
			// (get) Token: 0x0604DA76 RID: 318070 RVA: 0x015737AE File Offset: 0x015719AE
			// (set) Token: 0x0604DA77 RID: 318071 RVA: 0x015737B6 File Offset: 0x015719B6
			public ItemViewDefine.EItemOperationMode ItemOperationMode { get; set; } = itemOperationMode;

			// Token: 0x1700A9AE RID: 43438
			// (get) Token: 0x0604DA78 RID: 318072 RVA: 0x015737BF File Offset: 0x015719BF
			// (set) Token: 0x0604DA79 RID: 318073 RVA: 0x015737C7 File Offset: 0x015719C7
			public bool IsSelectOn { get; set; } = isSelectOn;

			// Token: 0x1700A9AF RID: 43439
			// (get) Token: 0x0604DA7A RID: 318074 RVA: 0x015737D0 File Offset: 0x015719D0
			// (set) Token: 0x0604DA7B RID: 318075 RVA: 0x015737D8 File Offset: 0x015719D8
			public int SelectOnNum { get; set; } = selectOnNum;
		}

		// Token: 0x0200BB98 RID: 48024
		public interface IPublicItemConfig
		{
			// Token: 0x1700A9B0 RID: 43440
			// (get) Token: 0x0604DA7C RID: 318076
			// (set) Token: 0x0604DA7D RID: 318077
			int TypeDescription { get; set; }

			// Token: 0x1700A9B1 RID: 43441
			// (get) Token: 0x0604DA7E RID: 318078
			// (set) Token: 0x0604DA7F RID: 318079
			int AttributesDescription { get; set; }

			// Token: 0x1700A9B2 RID: 43442
			// (get) Token: 0x0604DA80 RID: 318080
			// (set) Token: 0x0604DA81 RID: 318081
			int BgDescription { get; set; }

			// Token: 0x1700A9B3 RID: 43443
			// (get) Token: 0x0604DA82 RID: 318082
			// (set) Token: 0x0604DA83 RID: 318083
			string Icon { get; set; }

			// Token: 0x1700A9B4 RID: 43444
			// (get) Token: 0x0604DA84 RID: 318084
			// (set) Token: 0x0604DA85 RID: 318085
			int QualityId { get; set; }

			// Token: 0x1700A9B5 RID: 43445
			// (get) Token: 0x0604DA86 RID: 318086
			// (set) Token: 0x0604DA87 RID: 318087
			int MaxCapcity { get; set; }

			// Token: 0x1700A9B6 RID: 43446
			// (get) Token: 0x0604DA88 RID: 318088
			// (set) Token: 0x0604DA89 RID: 318089
			int[] ItemAccess { get; set; }

			// Token: 0x1700A9B7 RID: 43447
			// (get) Token: 0x0604DA8A RID: 318090
			// (set) Token: 0x0604DA8B RID: 318091
			string Mesh { get; set; }
		}

		// Token: 0x0200BB99 RID: 48025
		public interface IGetItemData
		{
			// Token: 0x1700A9B8 RID: 43448
			// (get) Token: 0x0604DA8C RID: 318092
			// (set) Token: 0x0604DA8D RID: 318093
			int ItemId { get; set; }

			// Token: 0x1700A9B9 RID: 43449
			// (get) Token: 0x0604DA8E RID: 318094
			// (set) Token: 0x0604DA8F RID: 318095
			int IncId { get; set; }
		}

		// Token: 0x0200BB9A RID: 48026
		[NullableContext(0)]
		public class GetItemData : InventoryDefine.IGetItemData
		{
			// Token: 0x0604DA90 RID: 318096 RVA: 0x015737E1 File Offset: 0x015719E1
			public GetItemData(int itemId, int incId)
			{
			}

			// Token: 0x1700A9BA RID: 43450
			// (get) Token: 0x0604DA91 RID: 318097 RVA: 0x015737F7 File Offset: 0x015719F7
			// (set) Token: 0x0604DA92 RID: 318098 RVA: 0x015737FF File Offset: 0x015719FF
			public int ItemId { get; set; } = itemId;

			// Token: 0x1700A9BB RID: 43451
			// (get) Token: 0x0604DA93 RID: 318099 RVA: 0x01573808 File Offset: 0x01571A08
			// (set) Token: 0x0604DA94 RID: 318100 RVA: 0x01573810 File Offset: 0x01571A10
			public int IncId { get; set; } = incId;
		}

		// Token: 0x0200BB9B RID: 48027
		[NullableContext(0)]
		public enum EUseType
		{
			// Token: 0x04039E47 RID: 237127
			OpenGiftPack = 2,
			// Token: 0x04039E48 RID: 237128
			AddTeamExpAuto,
			// Token: 0x04039E49 RID: 237129
			OpenGiftPackAuto,
			// Token: 0x04039E4A RID: 237130
			AddRoleAuto,
			// Token: 0x04039E4B RID: 237131
			CostItem,
			// Token: 0x04039E4C RID: 237132
			AddVisionSkillAuto = 8,
			// Token: 0x04039E4D RID: 237133
			AddEnergy,
			// Token: 0x04039E4E RID: 237134
			AddPropRewardAuto,
			// Token: 0x04039E4F RID: 237135
			AddRoleFavorAuto,
			// Token: 0x04039E50 RID: 237136
			ForInfoDisplay
		}

		// Token: 0x0200BB9C RID: 48028
		[NullableContext(0)]
		public enum EShowType
		{
			// Token: 0x04039E52 RID: 237138
			Exp = 1,
			// Token: 0x04039E53 RID: 237139
			NormalCoin,
			// Token: 0x04039E54 RID: 237140
			SeniorCoin,
			// Token: 0x04039E55 RID: 237141
			SuperCoin,
			// Token: 0x04039E56 RID: 237142
			Power,
			// Token: 0x04039E57 RID: 237143
			CultivateMaterial,
			// Token: 0x04039E58 RID: 237144
			RoleBreachMaterial,
			// Token: 0x04039E59 RID: 237145
			SkillUpgradeMaterial,
			// Token: 0x04039E5A RID: 237146
			Material,
			// Token: 0x04039E5B RID: 237147
			Consumable,
			// Token: 0x04039E5C RID: 237148
			RoleExpMaterial,
			// Token: 0x04039E5D RID: 237149
			WeaponExpMaterial,
			// Token: 0x04039E5E RID: 237150
			WeaponBreachMaterial,
			// Token: 0x04039E5F RID: 237151
			ResonanceAmplificationMaterial,
			// Token: 0x04039E60 RID: 237152
			ExchangeCoin,
			// Token: 0x04039E61 RID: 237153
			PropBag,
			// Token: 0x04039E62 RID: 237154
			TuningProve,
			// Token: 0x04039E63 RID: 237155
			TuningExchangeCoin,
			// Token: 0x04039E64 RID: 237156
			MonthlyTicket,
			// Token: 0x04039E65 RID: 237157
			Supply,
			// Token: 0x04039E66 RID: 237158
			TaskItem,
			// Token: 0x04039E67 RID: 237159
			PhantomExpMaterial,
			// Token: 0x04039E68 RID: 237160
			CookFinishedProduct,
			// Token: 0x04039E69 RID: 237161
			CookMenu,
			// Token: 0x04039E6A RID: 237162
			MachiningProduct,
			// Token: 0x04039E6B RID: 237163
			CookMaterial,
			// Token: 0x04039E6C RID: 237164
			Favorability,
			// Token: 0x04039E6D RID: 237165
			PowerPrestige,
			// Token: 0x04039E6E RID: 237166
			Fragment,
			// Token: 0x04039E6F RID: 237167
			RoleCallback,
			// Token: 0x04039E70 RID: 237168
			CookSell,
			// Token: 0x04039E71 RID: 237169
			ChangeStar,
			// Token: 0x04039E72 RID: 237170
			LevelItem,
			// Token: 0x04039E73 RID: 237171
			ForgingMenu,
			// Token: 0x04039E74 RID: 237172
			ComposeMenu,
			// Token: 0x04039E75 RID: 237173
			ComposeProduct,
			// Token: 0x04039E76 RID: 237174
			ComposeStructure,
			// Token: 0x04039E77 RID: 237175
			ComposeStructureProduct,
			// Token: 0x04039E78 RID: 237176
			RandomPhantomItem = 41,
			// Token: 0x04039E79 RID: 237177
			Modifier = 54,
			// Token: 0x04039E7A RID: 237178
			ModifierSub = 58,
			// Token: 0x04039E7B RID: 237179
			ResonantSelectItem = 62
		}

		// Token: 0x0200BB9D RID: 48029
		[NullableContext(0)]
		public enum ERedDotDisableRule
		{
			// Token: 0x04039E7D RID: 237181
			None,
			// Token: 0x04039E7E RID: 237182
			AfterSelect,
			// Token: 0x04039E7F RID: 237183
			AfterUse,
			// Token: 0x04039E80 RID: 237184
			ServerFirstSelect
		}

		// Token: 0x0200BB9E RID: 48030
		[NullableContext(0)]
		public enum EQuality
		{
			// Token: 0x04039E82 RID: 237186
			White = 1,
			// Token: 0x04039E83 RID: 237187
			Green,
			// Token: 0x04039E84 RID: 237188
			Blue,
			// Token: 0x04039E85 RID: 237189
			Purple,
			// Token: 0x04039E86 RID: 237190
			Orange
		}

		// Token: 0x0200BB9F RID: 48031
		[NullableContext(0)]
		public enum EItemDataFunctionValue
		{
			// Token: 0x04039E88 RID: 237192
			Default,
			// Token: 0x04039E89 RID: 237193
			Lock,
			// Token: 0x04039E8A RID: 237194
			Deprecate
		}

		// Token: 0x0200BBA0 RID: 48032
		public interface IManageConfigTypeItemData
		{
			// Token: 0x1700A9BC RID: 43452
			// (get) Token: 0x0604DA95 RID: 318101
			// (set) Token: 0x0604DA96 RID: 318102
			PhantomSettingType Type { get; set; }

			// Token: 0x1700A9BD RID: 43453
			// (get) Token: 0x0604DA97 RID: 318103
			// (set) Token: 0x0604DA98 RID: 318104
			string Name { get; set; }
		}

		// Token: 0x0200BBA1 RID: 48033
		[Nullable(0)]
		public class ManageConfigTypeItemData : InventoryDefine.IManageConfigTypeItemData
		{
			// Token: 0x1700A9BE RID: 43454
			// (get) Token: 0x0604DA99 RID: 318105 RVA: 0x01573819 File Offset: 0x01571A19
			// (set) Token: 0x0604DA9A RID: 318106 RVA: 0x01573821 File Offset: 0x01571A21
			public PhantomSettingType Type { get; set; } = PhantomSettingType.AutoDisuse;

			// Token: 0x1700A9BF RID: 43455
			// (get) Token: 0x0604DA9B RID: 318107 RVA: 0x0157382A File Offset: 0x01571A2A
			// (set) Token: 0x0604DA9C RID: 318108 RVA: 0x01573832 File Offset: 0x01571A32
			public string Name { get; set; } = "";
		}

		// Token: 0x0200BBA2 RID: 48034
		[NullableContext(0)]
		public enum ESettingGridType
		{
			// Token: 0x04039E8E RID: 237198
			Small = 1,
			// Token: 0x04039E8F RID: 237199
			Big
		}

		// Token: 0x0200BBA3 RID: 48035
		public interface IManageConfigTitleItemData
		{
			// Token: 0x1700A9C0 RID: 43456
			// (get) Token: 0x0604DA9E RID: 318110
			// (set) Token: 0x0604DA9F RID: 318111
			int FilterId { get; set; }

			// Token: 0x1700A9C1 RID: 43457
			// (get) Token: 0x0604DAA0 RID: 318112
			// (set) Token: 0x0604DAA1 RID: 318113
			int FilterRuleId { get; set; }
		}

		// Token: 0x0200BBA4 RID: 48036
		[NullableContext(0)]
		public class ManageConfigTitleItemData : InventoryDefine.IManageConfigTitleItemData
		{
			// Token: 0x1700A9C2 RID: 43458
			// (get) Token: 0x0604DAA2 RID: 318114 RVA: 0x01573855 File Offset: 0x01571A55
			// (set) Token: 0x0604DAA3 RID: 318115 RVA: 0x0157385D File Offset: 0x01571A5D
			public int FilterId { get; set; }

			// Token: 0x1700A9C3 RID: 43459
			// (get) Token: 0x0604DAA4 RID: 318116 RVA: 0x01573866 File Offset: 0x01571A66
			// (set) Token: 0x0604DAA5 RID: 318117 RVA: 0x0157386E File Offset: 0x01571A6E
			public int FilterRuleId { get; set; }
		}

		// Token: 0x0200BBA5 RID: 48037
		public interface IManageConfigSettingGridData
		{
			// Token: 0x1700A9C4 RID: 43460
			// (get) Token: 0x0604DAA7 RID: 318119
			// (set) Token: 0x0604DAA8 RID: 318120
			bool IsFirst { get; set; }

			// Token: 0x1700A9C5 RID: 43461
			// (get) Token: 0x0604DAA9 RID: 318121
			// (set) Token: 0x0604DAAA RID: 318122
			bool IsEmpty { get; set; }

			// Token: 0x1700A9C6 RID: 43462
			// (get) Token: 0x0604DAAB RID: 318123
			// (set) Token: 0x0604DAAC RID: 318124
			bool IsAdd { get; set; }

			// Token: 0x1700A9C7 RID: 43463
			// (get) Token: 0x0604DAAD RID: 318125
			// (set) Token: 0x0604DAAE RID: 318126
			bool IsSelect { get; set; }

			// Token: 0x1700A9C8 RID: 43464
			// (get) Token: 0x0604DAAF RID: 318127
			// (set) Token: 0x0604DAB0 RID: 318128
			bool IsEditing { get; set; }

			// Token: 0x1700A9C9 RID: 43465
			// (get) Token: 0x0604DAB1 RID: 318129
			// (set) Token: 0x0604DAB2 RID: 318130
			int RuleId { get; set; }

			// Token: 0x1700A9CA RID: 43466
			// (get) Token: 0x0604DAB3 RID: 318131
			// (set) Token: 0x0604DAB4 RID: 318132
			int Value { get; set; }
		}

		// Token: 0x0200BBA6 RID: 48038
		[NullableContext(0)]
		public class ManageConfigSettingGridData : InventoryDefine.IManageConfigSettingGridData
		{
			// Token: 0x1700A9CB RID: 43467
			// (get) Token: 0x0604DAB5 RID: 318133 RVA: 0x0157387F File Offset: 0x01571A7F
			// (set) Token: 0x0604DAB6 RID: 318134 RVA: 0x01573887 File Offset: 0x01571A87
			public bool IsFirst { get; set; }

			// Token: 0x1700A9CC RID: 43468
			// (get) Token: 0x0604DAB7 RID: 318135 RVA: 0x01573890 File Offset: 0x01571A90
			// (set) Token: 0x0604DAB8 RID: 318136 RVA: 0x01573898 File Offset: 0x01571A98
			public bool IsEmpty { get; set; }

			// Token: 0x1700A9CD RID: 43469
			// (get) Token: 0x0604DAB9 RID: 318137 RVA: 0x015738A1 File Offset: 0x01571AA1
			// (set) Token: 0x0604DABA RID: 318138 RVA: 0x015738A9 File Offset: 0x01571AA9
			public bool IsAdd { get; set; }

			// Token: 0x1700A9CE RID: 43470
			// (get) Token: 0x0604DABB RID: 318139 RVA: 0x015738B2 File Offset: 0x01571AB2
			// (set) Token: 0x0604DABC RID: 318140 RVA: 0x015738BA File Offset: 0x01571ABA
			public bool IsSelect { get; set; }

			// Token: 0x1700A9CF RID: 43471
			// (get) Token: 0x0604DABD RID: 318141 RVA: 0x015738C3 File Offset: 0x01571AC3
			// (set) Token: 0x0604DABE RID: 318142 RVA: 0x015738CB File Offset: 0x01571ACB
			public bool IsEditing { get; set; }

			// Token: 0x1700A9D0 RID: 43472
			// (get) Token: 0x0604DABF RID: 318143 RVA: 0x015738D4 File Offset: 0x01571AD4
			// (set) Token: 0x0604DAC0 RID: 318144 RVA: 0x015738DC File Offset: 0x01571ADC
			public int RuleId { get; set; }

			// Token: 0x1700A9D1 RID: 43473
			// (get) Token: 0x0604DAC1 RID: 318145 RVA: 0x015738E5 File Offset: 0x01571AE5
			// (set) Token: 0x0604DAC2 RID: 318146 RVA: 0x015738ED File Offset: 0x01571AED
			public int Value { get; set; }
		}

		// Token: 0x0200BBA7 RID: 48039
		public interface ISelectViewData
		{
			// Token: 0x1700A9D2 RID: 43474
			// (get) Token: 0x0604DAC4 RID: 318148
			// (set) Token: 0x0604DAC5 RID: 318149
			string GridType { get; set; }

			// Token: 0x1700A9D3 RID: 43475
			// (get) Token: 0x0604DAC6 RID: 318150
			// (set) Token: 0x0604DAC7 RID: 318151
			int FilterId { get; set; }

			// Token: 0x1700A9D4 RID: 43476
			// (get) Token: 0x0604DAC8 RID: 318152
			// (set) Token: 0x0604DAC9 RID: 318153
			int[] RuleIdList { get; set; }

			// Token: 0x1700A9D5 RID: 43477
			// (get) Token: 0x0604DACA RID: 318154
			// (set) Token: 0x0604DACB RID: 318155
			Dictionary<int, int[]> ValueMap { get; set; }

			// Token: 0x1700A9D6 RID: 43478
			// (get) Token: 0x0604DACC RID: 318156
			// (set) Token: 0x0604DACD RID: 318157
			Action<Dictionary<int, int[]>> CallbackConfirm { get; set; }
		}

		// Token: 0x0200BBA8 RID: 48040
		[Nullable(0)]
		public class SelectViewData : InventoryDefine.ISelectViewData
		{
			// Token: 0x1700A9D7 RID: 43479
			// (get) Token: 0x0604DACE RID: 318158 RVA: 0x015738FE File Offset: 0x01571AFE
			// (set) Token: 0x0604DACF RID: 318159 RVA: 0x01573906 File Offset: 0x01571B06
			public string GridType { get; set; } = "";

			// Token: 0x1700A9D8 RID: 43480
			// (get) Token: 0x0604DAD0 RID: 318160 RVA: 0x0157390F File Offset: 0x01571B0F
			// (set) Token: 0x0604DAD1 RID: 318161 RVA: 0x01573917 File Offset: 0x01571B17
			public int FilterId { get; set; }

			// Token: 0x1700A9D9 RID: 43481
			// (get) Token: 0x0604DAD2 RID: 318162 RVA: 0x01573920 File Offset: 0x01571B20
			// (set) Token: 0x0604DAD3 RID: 318163 RVA: 0x01573928 File Offset: 0x01571B28
			public int[] RuleIdList { get; set; } = Array.Empty<int>();

			// Token: 0x1700A9DA RID: 43482
			// (get) Token: 0x0604DAD4 RID: 318164 RVA: 0x01573931 File Offset: 0x01571B31
			// (set) Token: 0x0604DAD5 RID: 318165 RVA: 0x01573939 File Offset: 0x01571B39
			public Dictionary<int, int[]> ValueMap { get; set; } = new Dictionary<int, int[]>();

			// Token: 0x1700A9DB RID: 43483
			// (get) Token: 0x0604DAD6 RID: 318166 RVA: 0x01573942 File Offset: 0x01571B42
			// (set) Token: 0x0604DAD7 RID: 318167 RVA: 0x0157394A File Offset: 0x01571B4A
			public Action<Dictionary<int, int[]>> CallbackConfirm { get; set; }
		}

		// Token: 0x0200BBA9 RID: 48041
		public interface ISelectGroupData
		{
			// Token: 0x1700A9DC RID: 43484
			// (get) Token: 0x0604DAD9 RID: 318169
			// (set) Token: 0x0604DADA RID: 318170
			int FilterId { get; set; }

			// Token: 0x1700A9DD RID: 43485
			// (get) Token: 0x0604DADB RID: 318171
			// (set) Token: 0x0604DADC RID: 318172
			int FilterRuleId { get; set; }

			// Token: 0x1700A9DE RID: 43486
			// (get) Token: 0x0604DADD RID: 318173
			// (set) Token: 0x0604DADE RID: 318174
			bool HasSelectAll { get; set; }

			// Token: 0x1700A9DF RID: 43487
			// (get) Token: 0x0604DADF RID: 318175
			// (set) Token: 0x0604DAE0 RID: 318176
			bool NeedChangeColor { get; set; }

			// Token: 0x1700A9E0 RID: 43488
			// (get) Token: 0x0604DAE1 RID: 318177
			// (set) Token: 0x0604DAE2 RID: 318178
			int[] ValueList { get; set; }
		}

		// Token: 0x0200BBAA RID: 48042
		[Nullable(0)]
		public class SelectGroupData : InventoryDefine.ISelectGroupData
		{
			// Token: 0x1700A9E1 RID: 43489
			// (get) Token: 0x0604DAE3 RID: 318179 RVA: 0x0157397C File Offset: 0x01571B7C
			// (set) Token: 0x0604DAE4 RID: 318180 RVA: 0x01573984 File Offset: 0x01571B84
			public int FilterId { get; set; }

			// Token: 0x1700A9E2 RID: 43490
			// (get) Token: 0x0604DAE5 RID: 318181 RVA: 0x0157398D File Offset: 0x01571B8D
			// (set) Token: 0x0604DAE6 RID: 318182 RVA: 0x01573995 File Offset: 0x01571B95
			public int FilterRuleId { get; set; }

			// Token: 0x1700A9E3 RID: 43491
			// (get) Token: 0x0604DAE7 RID: 318183 RVA: 0x0157399E File Offset: 0x01571B9E
			// (set) Token: 0x0604DAE8 RID: 318184 RVA: 0x015739A6 File Offset: 0x01571BA6
			public bool HasSelectAll { get; set; }

			// Token: 0x1700A9E4 RID: 43492
			// (get) Token: 0x0604DAE9 RID: 318185 RVA: 0x015739AF File Offset: 0x01571BAF
			// (set) Token: 0x0604DAEA RID: 318186 RVA: 0x015739B7 File Offset: 0x01571BB7
			public bool NeedChangeColor { get; set; }

			// Token: 0x1700A9E5 RID: 43493
			// (get) Token: 0x0604DAEB RID: 318187 RVA: 0x015739C0 File Offset: 0x01571BC0
			// (set) Token: 0x0604DAEC RID: 318188 RVA: 0x015739C8 File Offset: 0x01571BC8
			public int[] ValueList { get; set; } = Array.Empty<int>();
		}

		// Token: 0x0200BBAB RID: 48043
		[NullableContext(2)]
		public interface ISelectItemData
		{
			// Token: 0x1700A9E6 RID: 43494
			// (get) Token: 0x0604DAEE RID: 318190
			// (set) Token: 0x0604DAEF RID: 318191
			bool IsShowIcon { get; set; }

			// Token: 0x1700A9E7 RID: 43495
			// (get) Token: 0x0604DAF0 RID: 318192
			// (set) Token: 0x0604DAF1 RID: 318193
			bool NeedChangeColor { get; set; }

			// Token: 0x1700A9E8 RID: 43496
			// (get) Token: 0x0604DAF2 RID: 318194
			// (set) Token: 0x0604DAF3 RID: 318195
			int FilterId { get; set; }

			// Token: 0x1700A9E9 RID: 43497
			// (get) Token: 0x0604DAF4 RID: 318196
			// (set) Token: 0x0604DAF5 RID: 318197
			int FilterRuleId { get; set; }

			// Token: 0x1700A9EA RID: 43498
			// (get) Token: 0x0604DAF6 RID: 318198
			// (set) Token: 0x0604DAF7 RID: 318199
			int Value { get; set; }

			// Token: 0x1700A9EB RID: 43499
			// (get) Token: 0x0604DAF8 RID: 318200
			// (set) Token: 0x0604DAF9 RID: 318201
			string IconPath { get; set; }

			// Token: 0x1700A9EC RID: 43500
			// (get) Token: 0x0604DAFA RID: 318202
			// (set) Token: 0x0604DAFB RID: 318203
			string Name { get; set; }
		}

		// Token: 0x0200BBAC RID: 48044
		[NullableContext(2)]
		[Nullable(0)]
		public class SelectItemData : InventoryDefine.ISelectItemData
		{
			// Token: 0x1700A9ED RID: 43501
			// (get) Token: 0x0604DAFC RID: 318204 RVA: 0x015739E4 File Offset: 0x01571BE4
			// (set) Token: 0x0604DAFD RID: 318205 RVA: 0x015739EC File Offset: 0x01571BEC
			public bool IsShowIcon { get; set; }

			// Token: 0x1700A9EE RID: 43502
			// (get) Token: 0x0604DAFE RID: 318206 RVA: 0x015739F5 File Offset: 0x01571BF5
			// (set) Token: 0x0604DAFF RID: 318207 RVA: 0x015739FD File Offset: 0x01571BFD
			public bool NeedChangeColor { get; set; }

			// Token: 0x1700A9EF RID: 43503
			// (get) Token: 0x0604DB00 RID: 318208 RVA: 0x01573A06 File Offset: 0x01571C06
			// (set) Token: 0x0604DB01 RID: 318209 RVA: 0x01573A0E File Offset: 0x01571C0E
			public int FilterId { get; set; }

			// Token: 0x1700A9F0 RID: 43504
			// (get) Token: 0x0604DB02 RID: 318210 RVA: 0x01573A17 File Offset: 0x01571C17
			// (set) Token: 0x0604DB03 RID: 318211 RVA: 0x01573A1F File Offset: 0x01571C1F
			public int FilterRuleId { get; set; }

			// Token: 0x1700A9F1 RID: 43505
			// (get) Token: 0x0604DB04 RID: 318212 RVA: 0x01573A28 File Offset: 0x01571C28
			// (set) Token: 0x0604DB05 RID: 318213 RVA: 0x01573A30 File Offset: 0x01571C30
			public int Value { get; set; }

			// Token: 0x1700A9F2 RID: 43506
			// (get) Token: 0x0604DB06 RID: 318214 RVA: 0x01573A39 File Offset: 0x01571C39
			// (set) Token: 0x0604DB07 RID: 318215 RVA: 0x01573A41 File Offset: 0x01571C41
			public string IconPath { get; set; }

			// Token: 0x1700A9F3 RID: 43507
			// (get) Token: 0x0604DB08 RID: 318216 RVA: 0x01573A4A File Offset: 0x01571C4A
			// (set) Token: 0x0604DB09 RID: 318217 RVA: 0x01573A52 File Offset: 0x01571C52
			public string Name { get; set; }
		}
	}
}
