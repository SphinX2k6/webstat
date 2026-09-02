using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020017E5 RID: 6117
[NullableContext(1)]
[Nullable(0)]
public class CalabashDefine : IStaticVariableResetter
{
	// Token: 0x0600AD9E RID: 44446 RVA: 0x002E324E File Offset: 0x002E144E
	static CalabashDefine()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(CalabashDefine.CreateStaticDefaultValue), new Action(CalabashDefine.ResetStaticDefaultValue));
	}

	// Token: 0x0600AD9F RID: 44447 RVA: 0x002E3270 File Offset: 0x002E1470
	public static void CreateStaticDefaultValue()
	{
		CalabashDefine.visionRecoveryTabViewTypeName = new Dictionary<EVisionRecoveryTabViewType, string>
		{
			{
				EVisionRecoveryTabViewType.NormalFusion,
				"PhantomRecycle_RandomModel"
			},
			{
				EVisionRecoveryTabViewType.DirectionalFusion,
				"PhantomRecycle_AimModel"
			}
		};
		CalabashDefine.visionRefineCostMap = new Dictionary<EVisionRefineCostType, string>
		{
			{
				EVisionRefineCostType.Cost4,
				"Cost4"
			},
			{
				EVisionRefineCostType.Cost3,
				"Cost3"
			},
			{
				EVisionRefineCostType.Cost1,
				"Cost1"
			}
		};
		CalabashDefine.visionRefineRefineMap = new Dictionary<EVisionRefineRefineType, string>
		{
			{
				EVisionRefineRefineType.Main,
				"PrefabTextItem_PhantomMainAttribute_Text"
			},
			{
				EVisionRefineRefineType.Sub,
				"PrefabTextItem_PhantomSubAttribute_Text"
			}
		};
	}

	// Token: 0x0600ADA0 RID: 44448 RVA: 0x002E32EF File Offset: 0x002E14EF
	public static void ResetStaticDefaultValue()
	{
		CalabashDefine.visionRecoveryTabViewTypeName = null;
		CalabashDefine.visionRefineCostMap = null;
		CalabashDefine.visionRefineRefineMap = null;
	}

	// Token: 0x0400521E RID: 21022
	public const int VISION_RECOVERY_SLOT_MAX_NUM = 5;

	// Token: 0x0400521F RID: 21023
	public const int VISION_RECOVERY_SORT_GROUP_ID = 31;

	// Token: 0x04005220 RID: 21024
	public const int VISION_RECOVERT_FILTER_UNDEPERCATE = 0;

	// Token: 0x04005221 RID: 21025
	public const int VISION_RECOVERT_FILTER_DEPERCATE = 1;

	// Token: 0x04005222 RID: 21026
	public const int VISION_RECOVERT_FILTER_LOCK = 2;

	// Token: 0x04005223 RID: 21027
	public const int VISION_REFINE_FILTER_QUALITY = 5;

	// Token: 0x04005224 RID: 21028
	public const int CALABASH_SPECIALUI_LEVEL = 26;

	// Token: 0x04005225 RID: 21029
	public const int VISION_GOLD_QUALITY = 5;

	// Token: 0x04005226 RID: 21030
	public const string VISION_REFINE_TAB_COST1_TEXT_ID = "Cost1";

	// Token: 0x04005227 RID: 21031
	public const string VISION_REFINE_TAB_COST3_TEXT_ID = "Cost3";

	// Token: 0x04005228 RID: 21032
	public const string VISION_REFINE_TAB_COST4_TEXT_ID = "Cost4";

	// Token: 0x04005229 RID: 21033
	public const string VISION_REFINE_TAB_MAIN_TEXT_ID = "PrefabTextItem_PhantomMainAttribute_Text";

	// Token: 0x0400522A RID: 21034
	public const string VISION_REFINE_TAB_SUB_TEXT_ID = "PrefabTextItem_PhantomSubAttribute_Text";

	// Token: 0x0400522B RID: 21035
	public const string VISION_REFINE_SELECTED_TEXT_ID = "Text_ItemRecycleChosenTotal_text";

	// Token: 0x0400522C RID: 21036
	public const string VISION_REFINE_UNSELECTED_TEXT_ID = "ErrorCode_200347_Text";

	// Token: 0x0400522D RID: 21037
	public const string VISION_REFINE_DIRECT_VALUE_TEXT_ID = "RogueInfoViewShopPrice";

	// Token: 0x0400522E RID: 21038
	public const string VISION_REFINE_PERCENTAGE_TEXT_ID = "Text_ExplorationDegree_Text";

	// Token: 0x0400522F RID: 21039
	public const string VISION_REFINE_NON_UPGRADE_TEXT_ID = "Text_VisionRefineSubAttriLocked_Text";

	// Token: 0x04005230 RID: 21040
	public const string VISION_REFINE_CAN_REFINE_WITH_NUMBER_TEXT_ID = "Text_VisionRefine_CanRefineWithNumber_Text";

	// Token: 0x04005231 RID: 21041
	public const string VISION_REFINE_MAIN_INVALID_REASON_TEXT_ID = "Text_VisionRefineMain_InvalidReason_Text";

	// Token: 0x04005232 RID: 21042
	public const string VISION_REFINE_SUB_INVALID_REASON_TEXT_ID = "Text_VisionRefineSub_InvalidReason_Text";

	// Token: 0x04005233 RID: 21043
	public const string VISION_REFINE_ATTRIBUTE_PANEL_TITLE_TEXT_ID = "Text_VisionRefineAttributePanelTitle_Text";

	// Token: 0x04005234 RID: 21044
	public const string VISION_REFINE_NO_NEED_CONFIRM_BOX_TEXT_ID = "Text_PlotSkipConfirmToggle_Text";

	// Token: 0x04005235 RID: 21045
	public const string VISION_REFINE_SUB_ONLY_FULL_LEVEL_TIP_TEXT_ID = "Text_VisionRefineSub_InvalidTips_Text";

	// Token: 0x04005236 RID: 21046
	public const string VISION_REFINE_ONLY_FIVE_STAR_TIP_TEXT_ID = "VisionRefineChooseCheck";

	// Token: 0x04005237 RID: 21047
	public const string VISION_REFINE_CHOOSE_LIST_IS_FULL_TIP_TEXT_ID = "Text_VisionRefineChooseListFull_Text";

	// Token: 0x04005238 RID: 21048
	public const string VISION_REFINE_SUB_LOCK_ALL_TIP_TEXT_ID = "Text_VisionRefineSubLockAll_Text";

	// Token: 0x04005239 RID: 21049
	public const string VISION_REFINE_CHOSEN_LACK_TIP_TEXT_ID = "PrefabTextItem_PhantomRefineLackTip_Text";

	// Token: 0x0400523A RID: 21050
	public const string VISION_REFINE_MATERIAL_LACK_TIP_TEXT_ID = "PrefabTextItem_PhantomRefineMaterialLackTip_Text";

	// Token: 0x0400523B RID: 21051
	public const string VISION_REFINE_FUNCTION_NOT_OPEN_TIP_TEXT_ID = "Text_UnlockNotice_Text";

	// Token: 0x0400523C RID: 21052
	public const string VISION_REFINE_MAIN_NOT_CHOOSE_ATTRIBUTE_TIP_TEXT_ID = "PrefabTextItem_PhantomRefineAttributeLackTip_Text";

	// Token: 0x0400523D RID: 21053
	public const string VISION_REFINE_MAIN_NON_VALID_TIP_TEXT_ID = "Text_VisionRefineMain_BlockedTips_Text";

	// Token: 0x0400523E RID: 21054
	public const string HAVE_AVAILABLE_ATTR_TEXT_ID = "Text_Refresh_HaveAvailableAttr";

	// Token: 0x0400523F RID: 21055
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public static Dictionary<EVisionRecoveryTabViewType, string> visionRecoveryTabViewTypeName;

	// Token: 0x04005240 RID: 21056
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public static Dictionary<EVisionRefineCostType, string> visionRefineCostMap;

	// Token: 0x04005241 RID: 21057
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public static Dictionary<EVisionRefineRefineType, string> visionRefineRefineMap;
}
