using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Plot;
using UnrealEngine;

// Token: 0x02000E6C RID: 3692
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[StaticVariableRuleIgnore]
public class CrashCollectionController : ControllerBase<CrashCollectionController>
{
	// Token: 0x060059B1 RID: 22961 RVA: 0x0010C124 File Offset: 0x0010A324
	[NullableContext(2)]
	private static Stat CreateOriginIsFightDebugStat()
	{
		if (!Stat.Enable)
		{
			return null;
		}
		if (!ControllerBase<FormationDataController>.Instance.GlobalIsInFight)
		{
			return CrashCollectionController.IsOriginFightFalseDebugStat;
		}
		return CrashCollectionController.IsOriginFightTrueDebugStat;
	}

	// Token: 0x060059B2 RID: 22962 RVA: 0x0010C146 File Offset: 0x0010A346
	[NullableContext(2)]
	private static Stat CreateGameBudgetIsFightDebugStat()
	{
		if (!Stat.Enable)
		{
			return null;
		}
		if (!Singleton<GameBudgetInterfaceController>.Instance.IsInFight)
		{
			return CrashCollectionController.IsGameBudgetFightFalseDebugStat;
		}
		return CrashCollectionController.IsGameBudgetFightTrueDebugStat;
	}

	// Token: 0x060059B3 RID: 22963 RVA: 0x0010C168 File Offset: 0x0010A368
	[NullableContext(2)]
	private static Stat CreateOriginIsCutsceneDebugStat()
	{
		if (!Stat.Enable)
		{
			return null;
		}
		if (!ModelBase<PlotModel>.Instance.IsInPlot)
		{
			return CrashCollectionController.IsOriginCutsceneFalseDebugStat;
		}
		return CrashCollectionController.IsOriginCutsceneTrueDebugStat;
	}

	// Token: 0x060059B4 RID: 22964 RVA: 0x0010C18A File Offset: 0x0010A38A
	[NullableContext(2)]
	private static Stat CreateGameBudgetIsCutsceneDebugStat()
	{
		if (!Stat.Enable)
		{
			return null;
		}
		if (!Singleton<GameBudgetInterfaceController>.Instance.IsInPlot)
		{
			return CrashCollectionController.IsGameBudgetCutsceneFalseDebugStat;
		}
		return CrashCollectionController.IsGameBudgetCutsceneTrueDebugStat;
	}

	// Token: 0x060059B5 RID: 22965 RVA: 0x0010C1AC File Offset: 0x0010A3AC
	[NullableContext(2)]
	private static Stat CreateQualityLevelDebugStat(EGameQualitySettingLevel level)
	{
		bool enable = Stat.Enable;
		return null;
	}

	// Token: 0x060059B6 RID: 22966 RVA: 0x0010C1B5 File Offset: 0x0010A3B5
	[NullableContext(2)]
	private static Stat CreateLoadModeDebugStat()
	{
		if (!Stat.Enable)
		{
			return null;
		}
		if (!Singleton<LoadModeManager>.Instance.IsLoadModeInGameOrForceInGame())
		{
			return CrashCollectionController.LoadModeInLoadingDebugStat;
		}
		return CrashCollectionController.LoadModeInGameDebugStat;
	}

	// Token: 0x060059B7 RID: 22967 RVA: 0x0010C1D7 File Offset: 0x0010A3D7
	protected override bool OnInit()
	{
		CrashCollectionController.OnAddEvents();
		return base.OnInit();
	}

	// Token: 0x060059B8 RID: 22968 RVA: 0x0010C1E4 File Offset: 0x0010A3E4
	protected override bool OnClear()
	{
		CrashCollectionController.OnRemoveEvents();
		return base.OnClear();
	}

	// Token: 0x060059B9 RID: 22969 RVA: 0x0010C1F4 File Offset: 0x0010A3F4
	private static void OnAddEvents()
	{
		EventSystem instance = Singleton<EventSystem>.Instance;
		EEventName name = EEventName.TodTimeChange;
		Action handle;
		if ((handle = CrashCollectionController.<>O.<0>__OnTodTimeChange) == null)
		{
			handle = (CrashCollectionController.<>O.<0>__OnTodTimeChange = new Action(CrashCollectionController.OnTodTimeChange));
		}
		instance.Add(name, handle);
		EventSystem instance2 = Singleton<EventSystem>.Instance;
		EEventName name2 = EEventName.LoginSuccess;
		Action<string> handle2;
		if ((handle2 = CrashCollectionController.<>O.<1>__OnLoginSuccess) == null)
		{
			handle2 = (CrashCollectionController.<>O.<1>__OnLoginSuccess = new Action<string>(CrashCollectionController.OnLoginSuccess));
		}
		instance2.Add(name2, handle2);
		EventSystem instance3 = Singleton<EventSystem>.Instance;
		EEventName name3 = EEventName.ReConnectSuccess;
		Action handle3;
		if ((handle3 = CrashCollectionController.<>O.<2>__ReConnectSuccess) == null)
		{
			handle3 = (CrashCollectionController.<>O.<2>__ReConnectSuccess = new Action(CrashCollectionController.ReConnectSuccess));
		}
		instance3.Add(name3, handle3);
		EventSystem instance4 = Singleton<EventSystem>.Instance;
		EEventName name4 = EEventName.OnAddNewQuest;
		Action<TQuest> handle4;
		if ((handle4 = CrashCollectionController.<>O.<3>__OnAddNewQuest) == null)
		{
			handle4 = (CrashCollectionController.<>O.<3>__OnAddNewQuest = new Action<TQuest>(CrashCollectionController.OnAddNewQuest));
		}
		instance4.Add(name4, handle4);
		EventSystem instance5 = Singleton<EventSystem>.Instance;
		EEventName name5 = EEventName.OnQuestStateChange;
		Action<int, QuestState, EQuestStatusUpdateReason> handle5;
		if ((handle5 = CrashCollectionController.<>O.<4>__OnQuestStateChange) == null)
		{
			handle5 = (CrashCollectionController.<>O.<4>__OnQuestStateChange = new Action<int, QuestState, EQuestStatusUpdateReason>(CrashCollectionController.OnQuestStateChange));
		}
		instance5.Add(name5, handle5);
		EventSystem instance6 = Singleton<EventSystem>.Instance;
		EEventName name6 = EEventName.OnChangeRole;
		Action<EntityHandle, EntityHandle> handle6;
		if ((handle6 = CrashCollectionController.<>O.<5>__OnChangeRole) == null)
		{
			handle6 = (CrashCollectionController.<>O.<5>__OnChangeRole = new Action<EntityHandle, EntityHandle>(CrashCollectionController.OnChangeRole));
		}
		instance6.Add(name6, handle6);
		EventSystem instance7 = Singleton<EventSystem>.Instance;
		EEventName name7 = EEventName.SetImageQualityWithValue;
		Action<int> handle7;
		if ((handle7 = CrashCollectionController.<>O.<6>__GatherQualityLevel) == null)
		{
			handle7 = (CrashCollectionController.<>O.<6>__GatherQualityLevel = new Action<int>(CrashCollectionController.GatherQualityLevel));
		}
		instance7.Add(name7, handle7);
		EventSystem instance8 = Singleton<EventSystem>.Instance;
		EEventName name8 = EEventName.SetRayTracingWithValue;
		Action<int> handle8;
		if ((handle8 = CrashCollectionController.<>O.<7>__GatherRayTracing) == null)
		{
			handle8 = (CrashCollectionController.<>O.<7>__GatherRayTracing = new Action<int>(CrashCollectionController.GatherRayTracing));
		}
		instance8.Add(name8, handle8);
		EventSystem instance9 = Singleton<EventSystem>.Instance;
		EEventName name9 = EEventName.SetDLSSFGWithValue;
		Action<int> handle9;
		if ((handle9 = CrashCollectionController.<>O.<8>__GatherDlssFg) == null)
		{
			handle9 = (CrashCollectionController.<>O.<8>__GatherDlssFg = new Action<int>(CrashCollectionController.GatherDlssFg));
		}
		instance9.Add(name9, handle9);
	}

	// Token: 0x060059BA RID: 22970 RVA: 0x0010C384 File Offset: 0x0010A584
	private static void OnRemoveEvents()
	{
		EventSystem instance = Singleton<EventSystem>.Instance;
		EEventName name = EEventName.TodTimeChange;
		Action handle;
		if ((handle = CrashCollectionController.<>O.<0>__OnTodTimeChange) == null)
		{
			handle = (CrashCollectionController.<>O.<0>__OnTodTimeChange = new Action(CrashCollectionController.OnTodTimeChange));
		}
		instance.Remove(name, handle);
		EventSystem instance2 = Singleton<EventSystem>.Instance;
		EEventName name2 = EEventName.LoginSuccess;
		Action<string> handle2;
		if ((handle2 = CrashCollectionController.<>O.<1>__OnLoginSuccess) == null)
		{
			handle2 = (CrashCollectionController.<>O.<1>__OnLoginSuccess = new Action<string>(CrashCollectionController.OnLoginSuccess));
		}
		instance2.Remove(name2, handle2);
		EventSystem instance3 = Singleton<EventSystem>.Instance;
		EEventName name3 = EEventName.ReConnectSuccess;
		Action handle3;
		if ((handle3 = CrashCollectionController.<>O.<2>__ReConnectSuccess) == null)
		{
			handle3 = (CrashCollectionController.<>O.<2>__ReConnectSuccess = new Action(CrashCollectionController.ReConnectSuccess));
		}
		instance3.Remove(name3, handle3);
		EventSystem instance4 = Singleton<EventSystem>.Instance;
		EEventName name4 = EEventName.OnAddNewQuest;
		Action<TQuest> handle4;
		if ((handle4 = CrashCollectionController.<>O.<3>__OnAddNewQuest) == null)
		{
			handle4 = (CrashCollectionController.<>O.<3>__OnAddNewQuest = new Action<TQuest>(CrashCollectionController.OnAddNewQuest));
		}
		instance4.Remove(name4, handle4);
		EventSystem instance5 = Singleton<EventSystem>.Instance;
		EEventName name5 = EEventName.OnQuestStateChange;
		Action<int, QuestState, EQuestStatusUpdateReason> handle5;
		if ((handle5 = CrashCollectionController.<>O.<4>__OnQuestStateChange) == null)
		{
			handle5 = (CrashCollectionController.<>O.<4>__OnQuestStateChange = new Action<int, QuestState, EQuestStatusUpdateReason>(CrashCollectionController.OnQuestStateChange));
		}
		instance5.Remove(name5, handle5);
		EventSystem instance6 = Singleton<EventSystem>.Instance;
		EEventName name6 = EEventName.OnChangeRole;
		Action<EntityHandle, EntityHandle> handle6;
		if ((handle6 = CrashCollectionController.<>O.<5>__OnChangeRole) == null)
		{
			handle6 = (CrashCollectionController.<>O.<5>__OnChangeRole = new Action<EntityHandle, EntityHandle>(CrashCollectionController.OnChangeRole));
		}
		instance6.Remove(name6, handle6);
		EventSystem instance7 = Singleton<EventSystem>.Instance;
		EEventName name7 = EEventName.SetImageQualityWithValue;
		Action<int> handle7;
		if ((handle7 = CrashCollectionController.<>O.<6>__GatherQualityLevel) == null)
		{
			handle7 = (CrashCollectionController.<>O.<6>__GatherQualityLevel = new Action<int>(CrashCollectionController.GatherQualityLevel));
		}
		instance7.Remove(name7, handle7);
		EventSystem instance8 = Singleton<EventSystem>.Instance;
		EEventName name8 = EEventName.SetRayTracingWithValue;
		Action<int> handle8;
		if ((handle8 = CrashCollectionController.<>O.<7>__GatherRayTracing) == null)
		{
			handle8 = (CrashCollectionController.<>O.<7>__GatherRayTracing = new Action<int>(CrashCollectionController.GatherRayTracing));
		}
		instance8.Remove(name8, handle8);
		EventSystem instance9 = Singleton<EventSystem>.Instance;
		EEventName name9 = EEventName.SetDLSSFGWithValue;
		Action<int> handle9;
		if ((handle9 = CrashCollectionController.<>O.<8>__GatherDlssFg) == null)
		{
			handle9 = (CrashCollectionController.<>O.<8>__GatherDlssFg = new Action<int>(CrashCollectionController.GatherDlssFg));
		}
		instance9.Remove(name9, handle9);
	}

	// Token: 0x060059BB RID: 22971 RVA: 0x0010C511 File Offset: 0x0010A711
	protected override void OnTick(float delta)
	{
		CrashCollectionController.GatherCrashInfo();
	}

	// Token: 0x060059BC RID: 22972 RVA: 0x0010C518 File Offset: 0x0010A718
	private static void OnTodTimeChange()
	{
		CrashCollectionController.GatherTODInfo();
	}

	// Token: 0x060059BD RID: 22973 RVA: 0x0010C51F File Offset: 0x0010A71F
	private static void GatherCrashInfo()
	{
		CrashCollectionController.CreateOriginIsFightDebugStat();
		CrashCollectionController.CreateGameBudgetIsFightDebugStat();
		CrashCollectionController.CreateOriginIsCutsceneDebugStat();
		CrashCollectionController.CreateGameBudgetIsCutsceneDebugStat();
		CrashCollectionController.CreateLoadModeDebugStat();
	}

	// Token: 0x060059BE RID: 22974 RVA: 0x0010C53F File Offset: 0x0010A73F
	private static void GatherTODInfo()
	{
		TimeOfDayModel instance = ModelBase<TimeOfDayModel>.Instance;
	}

	// Token: 0x060059BF RID: 22975 RVA: 0x0010C548 File Offset: 0x0010A748
	private static void GatherQualityLevel(int settingLevel)
	{
		EGameQualitySettingLevel gameQualitySettingLevel = Singleton<GameSettingsDeviceRender>.Instance.GameQualitySettingLevel;
		if (settingLevel != (int)gameQualitySettingLevel)
		{
			Singleton<Log>.Instance.Info(ELogModule.Game, ELogAuthor.WLJ, "CrashSight GatherQualityLevel", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		CrashCollectionController.CreateQualityLevelDebugStat(gameQualitySettingLevel);
	}

	// Token: 0x060059C0 RID: 22976 RVA: 0x0010C588 File Offset: 0x0010A788
	private static void GatherRayTracing(int rayTracing)
	{
		Singleton<Log>.Instance.Info(ELogModule.Game, ELogAuthor.WLJ, "CrashSight GatherRayTracing", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x060059C1 RID: 22977 RVA: 0x0010C5B4 File Offset: 0x0010A7B4
	private static void GatherDlssFg(int dlssFg)
	{
		Singleton<Log>.Instance.Info(ELogModule.Game, ELogAuthor.WLJ, "CrashSight GatherDlssFg", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x060059C2 RID: 22978 RVA: 0x0010C5E0 File Offset: 0x0010A7E0
	private static void OnAddNewQuest(TQuest tQuest)
	{
		global::Quest quest = (global::Quest)tQuest;
		if (quest.Type != EQuest.Main)
		{
			return;
		}
		if (!quest.IsProgressing)
		{
			return;
		}
		if (CrashCollectionController.ProcessingQuestIds.Contains(quest.Id))
		{
			return;
		}
		CrashCollectionController.ProcessingQuestIds.Add(quest.Id);
		CrashCollectionController.CollectionQuest();
	}

	// Token: 0x060059C3 RID: 22979 RVA: 0x0010C62F File Offset: 0x0010A82F
	private static void OnChangeRole(EntityHandle newEntity, EntityHandle oldEntity)
	{
		ModelBase<SceneTeamModel>.Instance.GetCurrentEntity.Entity.GetComponent<CharacterActorComponent>();
	}

	// Token: 0x060059C4 RID: 22980 RVA: 0x0010C648 File Offset: 0x0010A848
	private static void OnQuestStateChange(int questId, QuestState state, EQuestStatusUpdateReason reason)
	{
		global::Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(questId);
		if (quest == null || quest.Type != EQuest.Main)
		{
			return;
		}
		if (state == QuestState.Progress)
		{
			if (!CrashCollectionController.ProcessingQuestIds.Contains(questId))
			{
				CrashCollectionController.ProcessingQuestIds.Add(questId);
				CrashCollectionController.CollectionQuest();
				return;
			}
		}
		else
		{
			int num = CrashCollectionController.ProcessingQuestIds.IndexOf(questId);
			if (num > -1)
			{
				CrashCollectionController.ProcessingQuestIds.RemoveAt(num);
				CrashCollectionController.CollectionQuest();
			}
		}
	}

	// Token: 0x060059C5 RID: 22981 RVA: 0x0010C6B0 File Offset: 0x0010A8B0
	private static void CollectionQuest()
	{
	}

	// Token: 0x060059C6 RID: 22982 RVA: 0x0010C6B2 File Offset: 0x0010A8B2
	private static void OnLoginSuccess(string account)
	{
		CrashCollectionController.GatherGateWayInfo();
	}

	// Token: 0x060059C7 RID: 22983 RVA: 0x0010C6B9 File Offset: 0x0010A8B9
	private static void ReConnectSuccess()
	{
		CrashCollectionController.GatherGateWayInfo();
	}

	// Token: 0x060059C8 RID: 22984 RVA: 0x0010C6C0 File Offset: 0x0010A8C0
	private static void GatherGateWayInfo()
	{
	}

	// Token: 0x060059C9 RID: 22985 RVA: 0x0010C6C2 File Offset: 0x0010A8C2
	public static void RecordHttpInfo(string info)
	{
	}

	// Token: 0x04002980 RID: 10624
	private static readonly Stat Stat = Stat.Create("CrashCollectionController.GatherCrashInfo", "", "");

	// Token: 0x04002981 RID: 10625
	private static readonly Stat QualityStat = Stat.Create("CrashCollectionController.GatherQualityLevel", "", "");

	// Token: 0x04002982 RID: 10626
	private static readonly Stat QuestStat = Stat.Create("CrashCollectionController.GatherQuestInfo", "", "");

	// Token: 0x04002983 RID: 10627
	private static readonly Stat TodStat = Stat.Create("CrashCollectionController.GatherTODInfo", "", "");

	// Token: 0x04002984 RID: 10628
	private static readonly Stat GateWayStat = Stat.Create("CrashCollectionController.GatherGateWayInfo", "", "");

	// Token: 0x04002985 RID: 10629
	private static readonly Stat HttpInfoStat = Stat.Create("CrashCollectionController.RecordHttpInfo", "", "");

	// Token: 0x04002986 RID: 10630
	private static readonly FName TODTimeName = FNameUtil.GetCheckDynamicFName("TODTime");

	// Token: 0x04002987 RID: 10631
	private static readonly FName QualityLevelName = FNameUtil.GetCheckDynamicFName("QualityLevel");

	// Token: 0x04002988 RID: 10632
	private static readonly string RayTracingName = "RayTracing";

	// Token: 0x04002989 RID: 10633
	private static readonly string DlssFgName = "DlssFG";

	// Token: 0x0400298A RID: 10634
	private static readonly FName QuestIdsName = FNameUtil.GetCheckDynamicFName("QuestIds");

	// Token: 0x0400298B RID: 10635
	private static readonly FName GateWayName = FNameUtil.GetCheckDynamicFName("GateWay");

	// Token: 0x0400298C RID: 10636
	private static readonly FName HttpInfoName = FNameUtil.GetCheckDynamicFName("HttpInfo");

	// Token: 0x0400298D RID: 10637
	private static readonly Stat IsOriginFightTrueDebugStat = Stat.Create("Origin IsFight: True", "", "");

	// Token: 0x0400298E RID: 10638
	private static readonly Stat IsOriginFightFalseDebugStat = Stat.Create("Origin IsFight: False", "", "");

	// Token: 0x0400298F RID: 10639
	private static readonly Stat IsOriginCutsceneTrueDebugStat = Stat.Create("Origin IsCutscene: True", "", "");

	// Token: 0x04002990 RID: 10640
	private static readonly Stat IsOriginCutsceneFalseDebugStat = Stat.Create("Origin IsCutscene: False", "", "");

	// Token: 0x04002991 RID: 10641
	private static readonly Stat IsGameBudgetFightTrueDebugStat = Stat.Create("GameBudget IsFight: True", "", "");

	// Token: 0x04002992 RID: 10642
	private static readonly Stat IsGameBudgetFightFalseDebugStat = Stat.Create("GameBudget IsFight: False", "", "");

	// Token: 0x04002993 RID: 10643
	private static readonly Stat IsGameBudgetCutsceneTrueDebugStat = Stat.Create("GameBudget IsCutscene: True", "", "");

	// Token: 0x04002994 RID: 10644
	private static readonly Stat IsGameBudgetCutsceneFalseDebugStat = Stat.Create("GameBudget IsCutscene: False", "", "");

	// Token: 0x04002995 RID: 10645
	private static readonly Stat LoadModeInGameDebugStat = Stat.Create("LoadModel: InGame", "", "");

	// Token: 0x04002996 RID: 10646
	private static readonly Stat LoadModeInLoadingDebugStat = Stat.Create("LoadModel: InLoading", "", "");

	// Token: 0x04002997 RID: 10647
	private static readonly List<int> ProcessingQuestIds = new List<int>();

	// Token: 0x020072A6 RID: 29350
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x04027C01 RID: 162817
		[Nullable(0)]
		public static Action <0>__OnTodTimeChange;

		// Token: 0x04027C02 RID: 162818
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Action<string> <1>__OnLoginSuccess;

		// Token: 0x04027C03 RID: 162819
		[Nullable(0)]
		public static Action <2>__ReConnectSuccess;

		// Token: 0x04027C04 RID: 162820
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Action<TQuest> <3>__OnAddNewQuest;

		// Token: 0x04027C05 RID: 162821
		[Nullable(0)]
		public static Action<int, QuestState, EQuestStatusUpdateReason> <4>__OnQuestStateChange;

		// Token: 0x04027C06 RID: 162822
		[Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public static Action<EntityHandle, EntityHandle> <5>__OnChangeRole;

		// Token: 0x04027C07 RID: 162823
		[Nullable(0)]
		public static Action<int> <6>__GatherQualityLevel;

		// Token: 0x04027C08 RID: 162824
		[Nullable(0)]
		public static Action<int> <7>__GatherRayTracing;

		// Token: 0x04027C09 RID: 162825
		[Nullable(0)]
		public static Action<int> <8>__GatherDlssFg;
	}
}
