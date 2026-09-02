using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x0200546A RID: 21610
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaDefine
	{
		// Token: 0x06037174 RID: 225652 RVA: 0x00DFD1B9 File Offset: 0x00DFB3B9
		private static TCardSlotSortFunc CreateElementSortFunc(ECardElement element)
		{
			return delegate(CardSlotSortInfo a, CardSlotSortInfo b)
			{
				if (a.Element != b.Element)
				{
					if (a.Element == (int)element)
					{
						return -1;
					}
					if (b.Element == (int)element)
					{
						return 1;
					}
				}
				return 0;
			};
		}

		// Token: 0x06037176 RID: 225654 RVA: 0x00DFD1DC File Offset: 0x00DFB3DC
		// Note: this type is marked as 'beforefieldinit'.
		static PhantomArenaDefine()
		{
			Dictionary<ECardTabType, ECardElement[]> dictionary = new Dictionary<ECardTabType, ECardElement[]>();
			Dictionary<ECardTabType, ECardElement[]> dictionary2 = dictionary;
			ECardTabType key = ECardTabType.Ice;
			ECardElement[] array = new ECardElement[2];
			array[0] = ECardElement.Ice;
			dictionary2.Add(key, array);
			Dictionary<ECardTabType, ECardElement[]> dictionary3 = dictionary;
			ECardTabType key2 = ECardTabType.Fire;
			ECardElement[] array2 = new ECardElement[2];
			array2[0] = ECardElement.Fire;
			dictionary3.Add(key2, array2);
			Dictionary<ECardTabType, ECardElement[]> dictionary4 = dictionary;
			ECardTabType key3 = ECardTabType.Thunder;
			ECardElement[] array3 = new ECardElement[2];
			array3[0] = ECardElement.Thunder;
			dictionary4.Add(key3, array3);
			Dictionary<ECardTabType, ECardElement[]> dictionary5 = dictionary;
			ECardTabType key4 = ECardTabType.Wind;
			ECardElement[] array4 = new ECardElement[2];
			array4[0] = ECardElement.Wind;
			dictionary5.Add(key4, array4);
			Dictionary<ECardTabType, ECardElement[]> dictionary6 = dictionary;
			ECardTabType key5 = ECardTabType.Light;
			ECardElement[] array5 = new ECardElement[2];
			array5[0] = ECardElement.Light;
			dictionary6.Add(key5, array5);
			Dictionary<ECardTabType, ECardElement[]> dictionary7 = dictionary;
			ECardTabType key6 = ECardTabType.Dark;
			ECardElement[] array6 = new ECardElement[2];
			array6[0] = ECardElement.Dark;
			dictionary7.Add(key6, array6);
			PhantomArenaDefine.cardTabTypeToFilterElementList = dictionary;
			PhantomArenaDefine.cardTabTypeToElementConfigId = new Dictionary<ECardTabType, ECardElement>
			{
				{
					ECardTabType.Ice,
					ECardElement.Ice
				},
				{
					ECardTabType.Fire,
					ECardElement.Fire
				},
				{
					ECardTabType.Thunder,
					ECardElement.Thunder
				},
				{
					ECardTabType.Wind,
					ECardElement.Wind
				},
				{
					ECardTabType.Light,
					ECardElement.Light
				},
				{
					ECardTabType.Dark,
					ECardElement.Dark
				}
			};
			PhantomArenaDefine.cardSlotSortTypeToSortFunc = new Dictionary<ECardSlotSortType, TCardSlotSortFunc>
			{
				{
					ECardSlotSortType.Cost,
					(CardSlotSortInfo a, CardSlotSortInfo b) => b.Cost - a.Cost
				},
				{
					ECardSlotSortType.IceFirst,
					PhantomArenaDefine.CreateElementSortFunc(ECardElement.Ice)
				},
				{
					ECardSlotSortType.FireFirst,
					PhantomArenaDefine.CreateElementSortFunc(ECardElement.Fire)
				},
				{
					ECardSlotSortType.ThunderFirst,
					PhantomArenaDefine.CreateElementSortFunc(ECardElement.Thunder)
				},
				{
					ECardSlotSortType.WindFirst,
					PhantomArenaDefine.CreateElementSortFunc(ECardElement.Wind)
				},
				{
					ECardSlotSortType.LightFirst,
					PhantomArenaDefine.CreateElementSortFunc(ECardElement.Light)
				},
				{
					ECardSlotSortType.DarkFirst,
					PhantomArenaDefine.CreateElementSortFunc(ECardElement.Dark)
				}
			};
			PhantomArenaDefine.cardSlotDefaultSortFunc = delegate(CardSlotSortInfo a, CardSlotSortInfo b)
			{
				if (a.CardType != b.CardType)
				{
					if (a.CardType == ECardType.Field)
					{
						return -1;
					}
					if (b.CardType == ECardType.Field)
					{
						return 1;
					}
					return a.CardType - b.CardType;
				}
				else
				{
					if (a.Cost != b.Cost)
					{
						return b.Cost - a.Cost;
					}
					if (a.Element == b.Element)
					{
						return a.CardId - b.CardId;
					}
					if (a.Element == 0)
					{
						return 1;
					}
					if (b.Element == 0)
					{
						return -1;
					}
					return a.Element - b.Element;
				}
			};
			PhantomArenaDefine.deckCardSlotDefaultSortFunc = delegate(DeckCardSlotInfo a, DeckCardSlotInfo b)
			{
				if (a.CardType != b.CardType)
				{
					if (a.CardType == ECardType.Field)
					{
						return -1;
					}
					if (b.CardType == ECardType.Field)
					{
						return 1;
					}
					return a.CardType - b.CardType;
				}
				else
				{
					if (a.Cost != b.Cost)
					{
						return b.Cost - a.Cost;
					}
					if (a.Element == b.Element)
					{
						return a.CardId - b.CardId;
					}
					if (a.Element == 0)
					{
						return 1;
					}
					if (b.Element == 0)
					{
						return -1;
					}
					return a.Element - b.Element;
				}
			};
			PhantomArenaDefine.deckBuilderCardItemDataSortFunc = delegate(CardInfoBase a, CardInfoBase b)
			{
				if (a.CardType != b.CardType)
				{
					if (a.CardType == ECardType.Field)
					{
						return -1;
					}
					if (b.CardType == ECardType.Field)
					{
						return 1;
					}
					return a.CardType - b.CardType;
				}
				else
				{
					if (a.Cost != b.Cost)
					{
						return b.Cost - a.Cost;
					}
					if (a.Element == b.Element)
					{
						return a.CardId - b.CardId;
					}
					if (a.Element == 0)
					{
						return 1;
					}
					if (b.Element == 0)
					{
						return -1;
					}
					return a.Element - b.Element;
				}
			};
			PhantomArenaDefine.addCardFailedResultToTipTextId = new Dictionary<EAddCardResult, string>
			{
				{
					EAddCardResult.CoreSlotLocked,
					"PhantomBattle_1056"
				},
				{
					EAddCardResult.TotalCoreCardCountLimit,
					"PhantomBattle_1073"
				},
				{
					EAddCardResult.TotalNormalCardCountLimit,
					"PhantomBattle_1074"
				},
				{
					EAddCardResult.TotalFieldCardCountLimit,
					"PhantomBattle_1141"
				},
				{
					EAddCardResult.TotalItemCardCountLimit,
					"PhantomBattle_1142"
				},
				{
					EAddCardResult.ElementLimit,
					"PhantomBattle_1054"
				},
				{
					EAddCardResult.CoreCardSlotLimit,
					"PhantomBattle_1052"
				},
				{
					EAddCardResult.NormalCardSlotLimit,
					"PhantomBattle_1052"
				},
				{
					EAddCardResult.CardMaxLimitByCost3,
					"PhantomBattleGym_cost3_Limit"
				},
				{
					EAddCardResult.CardMaxLimitByCost1,
					"PhantomBattleGym_cost1_Limit"
				}
			};
			PhantomArenaDefine.phantomArenaEntranceShopTabIconMap = new Dictionary<EUiTabViewName, string[]>
			{
				{
					EUiTabViewName.PhantomArenaEntranceTaskTabView,
					new string[]
					{
						"SP_IconOutsideShop1Nor",
						"SP_IconOutsideShop1Sle"
					}
				},
				{
					EUiTabViewName.PhantomArenaEntranceShopTabView,
					new string[]
					{
						"SP_IconOutsideShop2Nor",
						"SP_IconOutsideShop2Sle"
					}
				}
			};
			PhantomArenaDefine.difficultNumTextures = new Dictionary<int, string>
			{
				{
					1,
					"T_ComRomeText_01"
				},
				{
					2,
					"T_ComRomeText_02"
				},
				{
					3,
					"T_ComRomeText_03"
				},
				{
					4,
					"T_ComRomeText_04"
				},
				{
					5,
					"T_ComRomeText_05"
				},
				{
					6,
					"T_ComRomeText_06"
				},
				{
					7,
					"T_ComRomeText_07"
				},
				{
					8,
					"T_ComRomeText_08"
				},
				{
					9,
					"T_ComRomeText_09"
				},
				{
					10,
					"T_ComRomeText_10"
				},
				{
					11,
					"T_ComRomeText_11"
				},
				{
					12,
					"T_ComRomeText_12"
				}
			};
			PhantomArenaDefine.phantomBattleSettleReasonToTextId = new Dictionary<PhantomArenaDefine.EPhantomBattleSettleReason, string>
			{
				{
					PhantomArenaDefine.EPhantomBattleSettleReason.CommonSettle,
					"PhantomBattle_1145"
				},
				{
					PhantomArenaDefine.EPhantomBattleSettleReason.RoundSettle,
					"PhantomBattle_1146"
				},
				{
					PhantomArenaDefine.EPhantomBattleSettleReason.LimitSettle,
					"PhantomBattle_1147"
				}
			};
		}

		// Token: 0x0401FAA9 RID: 129705
		public const int CARD_COUNT_PER_PAGE = 8;

		// Token: 0x0401FAAA RID: 129706
		public const string CARD_ALL_ELEMENT_TAB_ICON_PATH = "/Game/Aki/UI/UIResources/Common/Image/IconElementRound/T_IconElementAll.T_IconElementAll";

		// Token: 0x0401FAAB RID: 129707
		public const string CARD_ALL_ELEMENT_TAB_COLOR = "FFFFFFFF";

		// Token: 0x0401FAAC RID: 129708
		public const string CARD_SLOT_FRAME_NORMAL_ICON_PATH = "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity24/SoundRemnantArena/Outside/SP_IconOutsideTeamListNor.SP_IconOutsideTeamListNor";

		// Token: 0x0401FAAD RID: 129709
		public const string CARD_SLOT_FRAME_GOLD_ICON_PATH = "/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity24/SoundRemnantArena/Outside/SP_IconOutsideTeamListGold.SP_IconOutsideTeamListGold";

		// Token: 0x0401FAAE RID: 129710
		public const string CARD_COST_TEXT_ID = "PhantomBattle_1001";

		// Token: 0x0401FAAF RID: 129711
		public const string CARD_ATTACK_TEXT_ID = "PhantomBattle_1002";

		// Token: 0x0401FAB0 RID: 129712
		public const string CARD_LIFE_TEXT_ID = "PhantomBattle_1003";

		// Token: 0x0401FAB1 RID: 129713
		public const string CARD_CRIT_RATE_TEXT_ID = "PhantomBattle_1004";

		// Token: 0x0401FAB2 RID: 129714
		public const string CARD_CRIT_DAMAGE_TEXT_ID = "PhantomBattle_1005";

		// Token: 0x0401FAB3 RID: 129715
		public const string POINTS_NAME_TEXT = "PhantomBattle_1106";

		// Token: 0x0401FAB4 RID: 129716
		public const string ACTIVITY_SUBVIEW_TEXT_UNLOCK = "PhantomBattle_1103";

		// Token: 0x0401FAB5 RID: 129717
		public const int GYM_MAX_LEVEL = 7;

		// Token: 0x0401FAB6 RID: 129718
		[StaticVariableRuleIgnore]
		public static readonly string[] positionGymLevel = new string[]
		{
			"left",
			"left",
			"middle",
			"middle",
			"right",
			"right",
			"right"
		};

		// Token: 0x0401FAB7 RID: 129719
		public const int REPEAT_GYM_MAX_DIFFICULTY = 2;

		// Token: 0x0401FAB8 RID: 129720
		public const float GYM_INERTIA_TWEEN_TIME = 0.618f;

		// Token: 0x0401FAB9 RID: 129721
		public const int GYM_BG_OFFSET_MAX = 330;

		// Token: 0x0401FABA RID: 129722
		public const int GYM_GYM_OFFSET_MIDDLE = -700;

		// Token: 0x0401FABB RID: 129723
		public const string ENTRANCE_TASK_TEXT_ID = "PhantomBattle_1093";

		// Token: 0x0401FABC RID: 129724
		public const string ENTRANCE_SHOP_TEXT_ID = "PhantomBattle_1094";

		// Token: 0x0401FABD RID: 129725
		public const string ENTRANCE_CARD_TEXT_ID = "PhantomBattle_1095";

		// Token: 0x0401FABE RID: 129726
		public const string ENTRANCE_ROLE_TEXT_ID = "PhantomBattle_1096";

		// Token: 0x0401FABF RID: 129727
		public const string ENTRANCE_COLLECTION_TEXT_ID = "PhantomBattle_1097";

		// Token: 0x0401FAC0 RID: 129728
		public const string ENTRANCE_MAINSHOP_ID = "PhantomBattle_1098";

		// Token: 0x0401FAC1 RID: 129729
		public const string ENTRANCE_LEVEL_COUNT_ID = "PhantomBattle_1025";

		// Token: 0x0401FAC2 RID: 129730
		public const string ENTRANCE_SHOP_COUNT_ID = "PhantomBattle_1100";

		// Token: 0x0401FAC3 RID: 129731
		public const string BVB_SPEEDUP_TIPS = "PhantomBattle_1107";

		// Token: 0x0401FAC4 RID: 129732
		public const string ENTRANCE_GYM_LOCK_TEXT_ID = "PhantomBattleGym_Locked";

		// Token: 0x0401FAC5 RID: 129733
		public const string ENTRANCE_NPC_LOCK_TEXT_ID = "PhantomBattleNpc_Locked";

		// Token: 0x0401FAC6 RID: 129734
		public const string ENTRANCE_MASTER_INFO_EXP_TEXT_ID = "TowerDefence_LV";

		// Token: 0x0401FAC7 RID: 129735
		public const string COLLECT_BADGE_GROUP_TITLE = "PrefabTextItem_3661046131_Text";

		// Token: 0x0401FAC8 RID: 129736
		public const string COLLECT_ELEMENT_PHYSICAL_NAME = "PhantomBattle_1123";

		// Token: 0x0401FAC9 RID: 129737
		public const int HELP_ID_ENTRANCE = 334;

		// Token: 0x0401FACA RID: 129738
		public const int HELP_ID_SHOP = 335;

		// Token: 0x0401FACB RID: 129739
		public const int HELP_ID_COLLECT = 338;

		// Token: 0x0401FACC RID: 129740
		public const int HELP_ID_COLLECT_NEW = 477;

		// Token: 0x0401FACD RID: 129741
		public const int HELP_ID_LEVEL = 341;

		// Token: 0x0401FACE RID: 129742
		public const int INSTANCE_SUCCESS = 3029;

		// Token: 0x0401FACF RID: 129743
		public const int INSTANCE_FAIL = 3030;

		// Token: 0x0401FAD0 RID: 129744
		public const string TEXT_RESULT_LEVEL_SKILL_DESC = "Text_ResultLevelSkillDesc_Text";

		// Token: 0x0401FAD1 RID: 129745
		public const string GYM_BG_LEFT_COLOR = "GymTabViewTextureBgLeftColor";

		// Token: 0x0401FAD2 RID: 129746
		public const string GYM_BG_LEFT_GRAY = "GymTabViewTextureBgLeftGray";

		// Token: 0x0401FAD3 RID: 129747
		public const string GYM_BG_LEFT_WHITE = "GymTabViewTextureBgLeftWhite";

		// Token: 0x0401FAD4 RID: 129748
		public const string GYM_BG_MIDDLE_COLOR = "GymTabViewTextureBgMiddleColor";

		// Token: 0x0401FAD5 RID: 129749
		public const string GYM_BG_MIDDLE_GRAY = "GymTabViewTextureBgMiddleGray";

		// Token: 0x0401FAD6 RID: 129750
		public const string GYM_BG_MIDDLE_WHITE = "GymTabViewTextureBgMiddleWhite";

		// Token: 0x0401FAD7 RID: 129751
		public const string GYM_BG_RIGHT_COLOR = "GymTabViewTextureBgRightColor";

		// Token: 0x0401FAD8 RID: 129752
		public const string GYM_BG_RIGHT_GRAY = "GymTabViewTextureBgRightGray";

		// Token: 0x0401FAD9 RID: 129753
		public const int DECK_ID_NONE = -1;

		// Token: 0x0401FADA RID: 129754
		public const int DECK_ID_EMPTY_TEMP = -100;

		// Token: 0x0401FADB RID: 129755
		public const int SPECIAL_TASK_TABTYPE = 0;

		// Token: 0x0401FADC RID: 129756
		public const string MYSTERY_NPC_HEAD = "MysteryNpcHead";

		// Token: 0x0401FADD RID: 129757
		public const int HAND_PHANTOMARENA_INDEX = -1;

		// Token: 0x0401FADE RID: 129758
		public const int UNVALID_FIGHT_ID = -1;

		// Token: 0x0401FADF RID: 129759
		public const int COST_ONE = 1;

		// Token: 0x0401FAE0 RID: 129760
		public const int COST_THREE = 3;

		// Token: 0x0401FAE1 RID: 129761
		[StaticVariableRuleIgnore]
		public static Dictionary<ECardTabType, ECardElement[]> cardTabTypeToFilterElementList;

		// Token: 0x0401FAE2 RID: 129762
		[StaticVariableRuleIgnore]
		public static Dictionary<ECardTabType, ECardElement> cardTabTypeToElementConfigId;

		// Token: 0x0401FAE3 RID: 129763
		[StaticVariableRuleIgnore]
		public static Dictionary<ECardSlotSortType, TCardSlotSortFunc> cardSlotSortTypeToSortFunc;

		// Token: 0x0401FAE4 RID: 129764
		[StaticVariableRuleIgnore]
		public static TCardSlotSortFunc cardSlotDefaultSortFunc;

		// Token: 0x0401FAE5 RID: 129765
		[StaticVariableRuleIgnore]
		public static TDeckCardSlotSortFunc deckCardSlotDefaultSortFunc;

		// Token: 0x0401FAE6 RID: 129766
		[StaticVariableRuleIgnore]
		public static TDeckBuilderCardItemDataSortFunc deckBuilderCardItemDataSortFunc;

		// Token: 0x0401FAE7 RID: 129767
		[StaticVariableRuleIgnore]
		public static Dictionary<EAddCardResult, string> addCardFailedResultToTipTextId;

		// Token: 0x0401FAE8 RID: 129768
		[StaticVariableRuleIgnore]
		public static Dictionary<EUiTabViewName, string[]> phantomArenaEntranceShopTabIconMap;

		// Token: 0x0401FAE9 RID: 129769
		[StaticVariableRuleIgnore]
		public static Dictionary<int, string> difficultNumTextures;

		// Token: 0x0401FAEA RID: 129770
		[StaticVariableRuleIgnore]
		public static Dictionary<PhantomArenaDefine.EPhantomBattleSettleReason, string> phantomBattleSettleReasonToTextId;

		// Token: 0x0200B405 RID: 46085
		[NullableContext(0)]
		public enum EPhantomBattleSettleReason
		{
			// Token: 0x04037B6F RID: 228207
			CommonSettle,
			// Token: 0x04037B70 RID: 228208
			RoundSettle,
			// Token: 0x04037B71 RID: 228209
			LimitSettle
		}
	}
}
