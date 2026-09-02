using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02001186 RID: 4486
[NullableContext(1)]
[Nullable(0)]
[StaticVariableRuleIgnore]
public class AdvanceNoticeDefine
{
	// Token: 0x04003933 RID: 14643
	public static Dictionary<int, string> advanceNoticeGridToPrefab = new Dictionary<int, string>
	{
		{
			3,
			"Pnl3xGrid"
		},
		{
			4,
			"Pnl4xGrid"
		},
		{
			5,
			"Pnl5xGrid"
		},
		{
			6,
			"Pnl6xGrid"
		},
		{
			7,
			"Pnl7xGrid"
		},
		{
			8,
			"Pnl8xGrid"
		}
	};

	// Token: 0x04003934 RID: 14644
	public static Dictionary<EAdvanceNoticeTabType, EUiTabViewName> advanceNoticeTabTypeToTabViewName = new Dictionary<EAdvanceNoticeTabType, EUiTabViewName>
	{
		{
			EAdvanceNoticeTabType.NewRole,
			EUiTabViewName.AdvanceNoticeNewRoleTabView
		},
		{
			EAdvanceNoticeTabType.NewJourney,
			EUiTabViewName.AdvanceNoticeNewJourneyTabView
		},
		{
			EAdvanceNoticeTabType.NewArea,
			EUiTabViewName.AdvanceNoticeNewAreaTabView
		},
		{
			EAdvanceNoticeTabType.NewSkin,
			EUiTabViewName.AdvanceNoticeNewSkinTabView
		},
		{
			EAdvanceNoticeTabType.NewEnemy,
			EUiTabViewName.AdvanceNoticeNewEnemyTabView
		},
		{
			EAdvanceNoticeTabType.NewActivity,
			EUiTabViewName.AdvanceNoticeNewActivityTabView
		},
		{
			EAdvanceNoticeTabType.NewSystemOptimize,
			EUiTabViewName.AdvanceNoticeNewSystemOptimizeTabView
		}
	};

	// Token: 0x04003935 RID: 14645
	public static Dictionary<int, string> starToWeaponGachaBgResourceId = new Dictionary<int, string>
	{
		{
			4,
			"SP_GachaWeaponBg_Purple"
		},
		{
			5,
			"SP_GachaWeaponBg"
		}
	};

	// Token: 0x04003936 RID: 14646
	public static string[] advanceNoticeDateTextList = new string[]
	{
		"Advertising_OpenTimeText_1",
		"Advertising_OpenTimeText_2",
		"Advertising_OpenTimeText_3",
		"Advertising_OpenTimeText_4",
		"Advertising_OpenTimeText_5",
		"Advertising_OpenTimeText_6",
		"Advertising_OpenTimeText_7",
		"Advertising_OpenTimeText_8",
		"Advertising_OpenTimeText_9",
		"Advertising_OpenTimeText_10",
		"Advertising_OpenTimeText_11",
		"Advertising_OpenTimeText_12"
	};
}
