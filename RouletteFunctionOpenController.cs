using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.SpringManor;
using CSharpScript.Game.Module.MapRogue;
using CSharpScript.Game.Module.Roguelike;
using CSharpScript.Game.Ui;

// Token: 0x0200292E RID: 10542
public class RouletteFunctionOpenController : IStaticVariableResetter
{
	// Token: 0x06014EEA RID: 85738 RVA: 0x005CB12C File Offset: 0x005C932C
	static RouletteFunctionOpenController()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(RouletteFunctionOpenController.CreateStaticDefaultValue), new Action(RouletteFunctionOpenController.ResetStaticDefaultValue));
	}

	// Token: 0x06014EEB RID: 85739 RVA: 0x005CB14C File Offset: 0x005C934C
	public static void OpenRelateView(ERouletteFuncId rouletteFuncId)
	{
		Action action;
		if (RouletteFunctionOpenController.RouletteFunctionOpenMap.TryGetValue(rouletteFuncId, out action))
		{
			action();
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Functional;
		ELogAuthor author = ELogAuthor.YYZ;
		string message = "[FunctionRoulette] 查找不到对应FuncId打开界面的实现方式,请在RouletteFunctionOpenController中注册";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("功能ID", rouletteFuncId);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06014EEC RID: 85740 RVA: 0x005CB19B File Offset: 0x005C939B
	private static void OpenWeeklyRogueInfoView()
	{
		if (ModelBase<WeeklyRogueModel>.Instance.CheckIsInWeeklyRogue())
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.WeeklyRogueInfo, null, null);
		}
	}

	// Token: 0x06014EED RID: 85741 RVA: 0x005CB1BA File Offset: 0x005C93BA
	private static void OpenRogueResSummaryView()
	{
		if (ControllerBase<MapRogueController>.Instance.CheckInMapRogueInstance())
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueBattleSummary, null, null);
		}
	}

	// Token: 0x06014EEE RID: 85742 RVA: 0x005CB1D9 File Offset: 0x005C93D9
	private static void OpenSurvivorsInfoView()
	{
		if (ControllerBase<SurvivorsRogueController>.Instance.CheckInSurvivorsRogueInstance())
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.SurvivorsTabMainView, null, null);
		}
	}

	// Token: 0x06014EEF RID: 85743 RVA: 0x005CB1F8 File Offset: 0x005C93F8
	private static void OpenHonamiStoryQuestView()
	{
		if (HonamiStoryUtil.CheckInHonamiStoryAreaDungeon())
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.HonamiStoryQuestView, null, null);
		}
	}

	// Token: 0x06014EF0 RID: 85744 RVA: 0x005CB212 File Offset: 0x005C9412
	private static void OpenSpringManorAtmosphereView()
	{
		if (!ModelBase<SpringManorModel>.Instance.CheckInInstance())
		{
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SpringManorAtmosphereLevelView, null, null);
	}

	// Token: 0x06014EF1 RID: 85745 RVA: 0x005CB232 File Offset: 0x005C9432
	private static void OpenSpringManorQuestView()
	{
		if (!ModelBase<SpringManorModel>.Instance.CheckInInstance())
		{
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SpringManorQuestView, null, null);
	}

	// Token: 0x06014EF2 RID: 85746 RVA: 0x005CB252 File Offset: 0x005C9452
	private static void OpenSpringManorRoleSwitchView()
	{
		if (!ModelBase<SpringManorModel>.Instance.CheckInInstance())
		{
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SpringManorRoleSwitchView, null, null);
	}

	// Token: 0x06014EF3 RID: 85747 RVA: 0x005CB272 File Offset: 0x005C9472
	private static void OpenRoguelikeInfoView()
	{
		if (!ModelBase<RoguelikeModel>.Instance.CheckInRoguelike())
		{
			return;
		}
		ControllerBase<RoguelikeController>.Instance.OpenRogueInfoView(null, true, true, ERogueInfoViewPage.Overview);
	}

	// Token: 0x06014EF4 RID: 85748 RVA: 0x005CB290 File Offset: 0x005C9490
	public static void CreateStaticDefaultValue()
	{
		Dictionary<ERouletteFuncId, Action> dictionary = new Dictionary<ERouletteFuncId, Action>();
		ERouletteFuncId key = ERouletteFuncId.WeeklyRogueInfo;
		Action value;
		if ((value = RouletteFunctionOpenController.<>O.<0>__OpenWeeklyRogueInfoView) == null)
		{
			value = (RouletteFunctionOpenController.<>O.<0>__OpenWeeklyRogueInfoView = new Action(RouletteFunctionOpenController.OpenWeeklyRogueInfoView));
		}
		dictionary.Add(key, value);
		ERouletteFuncId key2 = ERouletteFuncId.RogueResBattleSummaryInfo;
		Action value2;
		if ((value2 = RouletteFunctionOpenController.<>O.<1>__OpenRogueResSummaryView) == null)
		{
			value2 = (RouletteFunctionOpenController.<>O.<1>__OpenRogueResSummaryView = new Action(RouletteFunctionOpenController.OpenRogueResSummaryView));
		}
		dictionary.Add(key2, value2);
		ERouletteFuncId key3 = ERouletteFuncId.SurvivorsInfo;
		Action value3;
		if ((value3 = RouletteFunctionOpenController.<>O.<2>__OpenSurvivorsInfoView) == null)
		{
			value3 = (RouletteFunctionOpenController.<>O.<2>__OpenSurvivorsInfoView = new Action(RouletteFunctionOpenController.OpenSurvivorsInfoView));
		}
		dictionary.Add(key3, value3);
		ERouletteFuncId key4 = ERouletteFuncId.HonamiStoryQuest;
		Action value4;
		if ((value4 = RouletteFunctionOpenController.<>O.<3>__OpenHonamiStoryQuestView) == null)
		{
			value4 = (RouletteFunctionOpenController.<>O.<3>__OpenHonamiStoryQuestView = new Action(RouletteFunctionOpenController.OpenHonamiStoryQuestView));
		}
		dictionary.Add(key4, value4);
		ERouletteFuncId key5 = ERouletteFuncId.SpringManorAtmosphere;
		Action value5;
		if ((value5 = RouletteFunctionOpenController.<>O.<4>__OpenSpringManorAtmosphereView) == null)
		{
			value5 = (RouletteFunctionOpenController.<>O.<4>__OpenSpringManorAtmosphereView = new Action(RouletteFunctionOpenController.OpenSpringManorAtmosphereView));
		}
		dictionary.Add(key5, value5);
		ERouletteFuncId key6 = ERouletteFuncId.SpringManorQuest;
		Action value6;
		if ((value6 = RouletteFunctionOpenController.<>O.<5>__OpenSpringManorQuestView) == null)
		{
			value6 = (RouletteFunctionOpenController.<>O.<5>__OpenSpringManorQuestView = new Action(RouletteFunctionOpenController.OpenSpringManorQuestView));
		}
		dictionary.Add(key6, value6);
		ERouletteFuncId key7 = ERouletteFuncId.SpringManorRoleSwitch;
		Action value7;
		if ((value7 = RouletteFunctionOpenController.<>O.<6>__OpenSpringManorRoleSwitchView) == null)
		{
			value7 = (RouletteFunctionOpenController.<>O.<6>__OpenSpringManorRoleSwitchView = new Action(RouletteFunctionOpenController.OpenSpringManorRoleSwitchView));
		}
		dictionary.Add(key7, value7);
		ERouletteFuncId key8 = ERouletteFuncId.RoguelikeInfo;
		Action value8;
		if ((value8 = RouletteFunctionOpenController.<>O.<7>__OpenRoguelikeInfoView) == null)
		{
			value8 = (RouletteFunctionOpenController.<>O.<7>__OpenRoguelikeInfoView = new Action(RouletteFunctionOpenController.OpenRoguelikeInfoView));
		}
		dictionary.Add(key8, value8);
		RouletteFunctionOpenController.RouletteFunctionOpenMap = dictionary;
	}

	// Token: 0x06014EF5 RID: 85749 RVA: 0x005CB3D7 File Offset: 0x005C95D7
	public static void ResetStaticDefaultValue()
	{
		RouletteFunctionOpenController.RouletteFunctionOpenMap = null;
	}

	// Token: 0x0400A13E RID: 41278
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static Dictionary<ERouletteFuncId, Action> RouletteFunctionOpenMap;

	// Token: 0x02008C5B RID: 35931
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x0402F44A RID: 193610
		public static Action <0>__OpenWeeklyRogueInfoView;

		// Token: 0x0402F44B RID: 193611
		public static Action <1>__OpenRogueResSummaryView;

		// Token: 0x0402F44C RID: 193612
		public static Action <2>__OpenSurvivorsInfoView;

		// Token: 0x0402F44D RID: 193613
		public static Action <3>__OpenHonamiStoryQuestView;

		// Token: 0x0402F44E RID: 193614
		public static Action <4>__OpenSpringManorAtmosphereView;

		// Token: 0x0402F44F RID: 193615
		public static Action <5>__OpenSpringManorQuestView;

		// Token: 0x0402F450 RID: 193616
		public static Action <6>__OpenSpringManorRoleSwitchView;

		// Token: 0x0402F451 RID: 193617
		public static Action <7>__OpenRoguelikeInfoView;
	}
}
