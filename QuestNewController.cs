using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.Scene;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.LevelLoading;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Module.QuestNew.Controller;
using CSharpScript.Game.Module.RecallQuest;
using CSharpScript.Game.Module.RecallQuest.Model;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Render.Effect.PostProcess;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.DiffPatch.Update;
using CSharpScript.Launcher.Update;

// Token: 0x0200263F RID: 9791
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[TickController(0)]
public class QuestNewController : ControllerWithAssistantBase<QuestNewController>
{
	// Token: 0x170017EC RID: 6124
	// (get) Token: 0x06013484 RID: 78980 RVA: 0x0055C585 File Offset: 0x0055A785
	// (set) Token: 0x06013485 RID: 78981 RVA: 0x0055C58D File Offset: 0x0055A78D
	private QuestRedDotNotify CachedRedDotNotify { get; set; }

	// Token: 0x170017ED RID: 6125
	// (get) Token: 0x06013486 RID: 78982 RVA: 0x0055C596 File Offset: 0x0055A796
	// (set) Token: 0x06013487 RID: 78983 RVA: 0x0055C59E File Offset: 0x0055A79E
	public long QuestRangeFailWarningTreeId { get; set; }

	// Token: 0x170017EE RID: 6126
	// (get) Token: 0x06013488 RID: 78984 RVA: 0x0055C5A7 File Offset: 0x0055A7A7
	// (set) Token: 0x06013489 RID: 78985 RVA: 0x0055C5AF File Offset: 0x0055A7AF
	private bool IsHidingQuestRangeFailWarning { get; set; }

	// Token: 0x170017EF RID: 6127
	// (get) Token: 0x0601348A RID: 78986 RVA: 0x0055C5B8 File Offset: 0x0055A7B8
	// (set) Token: 0x0601348B RID: 78987 RVA: 0x0055C5C0 File Offset: 0x0055A7C0
	private float HidingQuestRangeFialWarningTime { get; set; }

	// Token: 0x170017F0 RID: 6128
	// (get) Token: 0x0601348C RID: 78988 RVA: 0x0055C5C9 File Offset: 0x0055A7C9
	// (set) Token: 0x0601348D RID: 78989 RVA: 0x0055C5D1 File Offset: 0x0055A7D1
	private bool IsShowingQuestRangeFailWarning { get; set; }

	// Token: 0x170017F1 RID: 6129
	// (get) Token: 0x0601348E RID: 78990 RVA: 0x0055C5DA File Offset: 0x0055A7DA
	// (set) Token: 0x0601348F RID: 78991 RVA: 0x0055C5E2 File Offset: 0x0055A7E2
	private float ShowQuestRangeFialWarningTime { get; set; }

	// Token: 0x170017F2 RID: 6130
	// (get) Token: 0x06013490 RID: 78992 RVA: 0x0055C5EB File Offset: 0x0055A7EB
	// (set) Token: 0x06013491 RID: 78993 RVA: 0x0055C5F3 File Offset: 0x0055A7F3
	private bool IsShowQuestRangeFailWarning { get; set; }

	// Token: 0x170017F3 RID: 6131
	// (get) Token: 0x06013492 RID: 78994 RVA: 0x0055C5FC File Offset: 0x0055A7FC
	// (set) Token: 0x06013493 RID: 78995 RVA: 0x0055C604 File Offset: 0x0055A804
	private float StartShowQuestRangeFialWarningTime { get; set; }

	// Token: 0x170017F4 RID: 6132
	// (get) Token: 0x06013494 RID: 78996 RVA: 0x0055C60D File Offset: 0x0055A80D
	// (set) Token: 0x06013495 RID: 78997 RVA: 0x0055C615 File Offset: 0x0055A815
	[Nullable(2)]
	private TimerHandle DelayTimerHandle { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x170017F5 RID: 6133
	// (get) Token: 0x06013496 RID: 78998 RVA: 0x0055C61E File Offset: 0x0055A81E
	// (set) Token: 0x06013497 RID: 78999 RVA: 0x0055C626 File Offset: 0x0055A826
	private int? VideoResourceDownloadTriggerId { get; set; }

	// Token: 0x170017F6 RID: 6134
	// (get) Token: 0x06013498 RID: 79000 RVA: 0x0055C62F File Offset: 0x0055A82F
	// (set) Token: 0x06013499 RID: 79001 RVA: 0x0055C637 File Offset: 0x0055A837
	private bool? IsReportDownloadNotEnoughSpace { get; set; }

	// Token: 0x0601349A RID: 79002 RVA: 0x0055C640 File Offset: 0x0055A840
	protected override void OnRegisterNetEvent()
	{
		base.OnRegisterNetEvent();
		Singleton<Net>.Instance.Register<QuestListNotify>(ENotifyMessageId.QuestListNotify, new Action<QuestListNotify, Net.CallbackStatus>(this.OnQuestListNotify));
		Singleton<Net>.Instance.Register<QuestReadyListNotify>(ENotifyMessageId.QuestReadyListNotify, new Action<QuestReadyListNotify, Net.CallbackStatus>(this.OnQuestReadyListNotify));
		Singleton<Net>.Instance.Register<QuestShowListNotify>(ENotifyMessageId.QuestShowListNotify, new Action<QuestShowListNotify, Net.CallbackStatus>(this.OnQuestShowListNotify));
		Singleton<Net>.Instance.Register<QuestStateUpdateNotify>(ENotifyMessageId.QuestStateUpdateNotify, new Action<QuestStateUpdateNotify, Net.CallbackStatus>(this.QuestStateUpdateNotify));
		Singleton<Net>.Instance.Register<QuestFinishListNotify>(ENotifyMessageId.QuestFinishListNotify, new Action<QuestFinishListNotify, Net.CallbackStatus>(this.OnQuestFinishListNotify));
		Singleton<Net>.Instance.Register<QuestRedDotNotify>(ENotifyMessageId.QuestRedDotNotify, new Action<QuestRedDotNotify, Net.CallbackStatus>(this.OnQuestRedDotNotify));
		Singleton<Net>.Instance.Register<BtRangeFailWarningNotify>(ENotifyMessageId.BtRangeFailWarningNotify, new Action<BtRangeFailWarningNotify, Net.CallbackStatus>(this.OnBtRangeFailWarningNotify));
		Singleton<Net>.Instance.Register<BtCancelRangeFailWarningNotify>(ENotifyMessageId.BtCancelRangeFailWarningNotify, new Action<BtCancelRangeFailWarningNotify, Net.CallbackStatus>(this.OnBtCancelRangeFailWarningNotify));
		Singleton<Net>.Instance.Register<QuestGiveUpNotify>(ENotifyMessageId.QuestGiveUpNotify, new Action<QuestGiveUpNotify, Net.CallbackStatus>(this.OnQuestGiveUpNotify));
		Singleton<Net>.Instance.Register<WaitQuestConfirmResourceNotify>(ENotifyMessageId.WaitQuestConfirmResourceNotify, new Action<WaitQuestConfirmResourceNotify, Net.CallbackStatus>(this.OnWaitQuestConfirmResourceNotify));
		Singleton<Net>.Instance.Register<StartSetQuestFocusNotify>(ENotifyMessageId.StartSetQuestFocusNotify, new Action<StartSetQuestFocusNotify, Net.CallbackStatus>(this.OnStartSetQuestFocusNotify));
		Singleton<Net>.Instance.Register<QuestFocusInfoNotify>(ENotifyMessageId.QuestFocusInfoNotify, new Action<QuestFocusInfoNotify, Net.CallbackStatus>(this.OnQuestFocusInfoNotify));
		Singleton<Net>.Instance.Register<QuestLockInfoNotify>(ENotifyMessageId.QuestLockInfoNotify, new Action<QuestLockInfoNotify, Net.CallbackStatus>(this.OnQuestLockInfoNotify));
		Singleton<Net>.Instance.Register<InteractQuestSuspendEntityNotify>(ENotifyMessageId.InteractQuestSuspendEntityNotify, new Action<InteractQuestSuspendEntityNotify, Net.CallbackStatus>(this.OnInteractQuestSuspendEntityNotify));
		Singleton<Net>.Instance.Register<ResetQuestFocusModeNotify>(ENotifyMessageId.ResetQuestFocusModeNotify, new Action<ResetQuestFocusModeNotify, Net.CallbackStatus>(this.OnResetQuestFocusModeNotify));
	}

	// Token: 0x0601349B RID: 79003 RVA: 0x0055C7F8 File Offset: 0x0055A9F8
	protected override void OnUnRegisterNetEvent()
	{
		base.OnUnRegisterNetEvent();
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.QuestListNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.QuestReadyListNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.QuestShowListNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.QuestStateUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.QuestFinishListNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BtRangeFailWarningNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BtCancelRangeFailWarningNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.QuestGiveUpNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.WaitQuestConfirmResourceNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.StartSetQuestFocusNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.QuestFocusInfoNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.QuestLockInfoNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.InteractQuestSuspendEntityNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ResetQuestFocusModeNotify);
	}

	// Token: 0x0601349C RID: 79004 RVA: 0x0055C8EB File Offset: 0x0055AAEB
	protected override bool OnInit()
	{
		base.InitTickOptimize(30, -1);
		return base.OnInit();
	}

	// Token: 0x0601349D RID: 79005 RVA: 0x0055C8FC File Offset: 0x0055AAFC
	protected override void OnAddEvents()
	{
		base.OnAddEvents();
		Singleton<EventSystem>.Instance.Add(EEventName.GeneralLogicTreeWakeUp, new Action(this.OnGeneralLogicTreeWakeUp));
		Singleton<EventSystem>.Instance.Add<int, QuestState, EQuestStatusUpdateReason>(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestStateChange));
		Singleton<EventSystem>.Instance.Add<int?, int>(EEventName.ChangeArea, new Action<int?, int>(this.AreaChanged));
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Add(EEventName.TsWorldDone, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Add<PlotResultInfo>(EEventName.PlotNetworkEnd, new Action<PlotResultInfo>(this.OnPlotSequenceEnd));
		Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.QuestView, new Func<EUiViewName, object, bool>(this.CanOpenView), "QuestNewController.CanOpenView");
		Singleton<VideoUpdateManager>.Instance.GetVideoUpdater(EVideoResSizeType.FemalePrepare).SetDownloadFinishCallBack(new Action<EVideoResSizeType>(this.OnQuestVideoResourceDownloadFinish));
		Singleton<VideoUpdateManager>.Instance.GetVideoUpdater(EVideoResSizeType.MalePrepare).SetDownloadFinishCallBack(new Action<EVideoResSizeType>(this.OnQuestVideoResourceDownloadFinish));
	}

	// Token: 0x0601349E RID: 79006 RVA: 0x0055CA10 File Offset: 0x0055AC10
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.GeneralLogicTreeWakeUp, new Action(this.OnGeneralLogicTreeWakeUp));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestStateChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.ChangeArea, new Action<int?, int>(this.AreaChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Remove(EEventName.TsWorldDone, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Remove(EEventName.PlotNetworkEnd, new Action<PlotResultInfo>(this.OnPlotSequenceEnd));
		Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.QuestView, new Func<EUiViewName, object, bool>(this.CanOpenView));
		base.OnRemoveEvents();
	}

	// Token: 0x0601349F RID: 79007 RVA: 0x0055CAE8 File Offset: 0x0055ACE8
	protected override void OnTick(float delta)
	{
		if (!ModelBase<GeneralLogicTreeModel>.Instance.IsWakeUp)
		{
			return;
		}
		GuideLineAssistant assistant = this.GetAssistant<GuideLineAssistant>(QuestNewController.EAssistantType.GuideLine);
		if (assistant != null)
		{
			assistant.Tick(delta);
		}
		GuideEffectAssistant assistant2 = this.GetAssistant<GuideEffectAssistant>(QuestNewController.EAssistantType.GuideEffect);
		if (assistant2 != null)
		{
			assistant2.UpdateQuestGuideEffect(delta);
		}
		if (this.IsHidingQuestRangeFailWarning)
		{
			this.HidingQuestRangeFialWarningTime += delta;
			double num = Singleton<MathUtils>.Instance.SafeDivide((double)(this.ShowQuestRangeFailWarningTime - this.HidingQuestRangeFialWarningTime), (double)this.ShowQuestRangeFailWarningTime);
			num = Singleton<MathUtils>.Instance.Clamp(num, 0.0, 1.0);
			Singleton<SceneEffectStateManager>.Instance.SetSceneEffectState(ESceneEffectStateType.AirWall, (float)num);
			if (this.HidingQuestRangeFialWarningTime > this.ShowQuestRangeFailWarningTime)
			{
				Singleton<SceneEffectStateManager>.Instance.SetSceneEffectState(ESceneEffectStateType.AirWall, 0f);
				this.IsHidingQuestRangeFailWarning = false;
			}
		}
		if (this.IsShowingQuestRangeFailWarning)
		{
			this.ShowQuestRangeFialWarningTime += delta;
			double num2 = Singleton<MathUtils>.Instance.SafeDivide((double)this.ShowQuestRangeFialWarningTime, (double)this.ShowQuestRangeFailWarningTime);
			num2 = Singleton<MathUtils>.Instance.Clamp(num2, 0.0, 1.0);
			Singleton<SceneEffectStateManager>.Instance.SetSceneEffectState(ESceneEffectStateType.AirWall, (float)num2);
			if (this.ShowQuestRangeFialWarningTime > this.ShowQuestRangeFailWarningTime)
			{
				Singleton<SceneEffectStateManager>.Instance.SetSceneEffectState(ESceneEffectStateType.AirWall, 1f);
				this.IsShowingQuestRangeFailWarning = false;
			}
		}
		if (this.IsShowQuestRangeFailWarning)
		{
			this.StartShowQuestRangeFialWarningTime += delta;
			int valueOrDefault = ConfigCommonParamById.GetIntConfig("CloseQuestRangeFailWarningTime").GetValueOrDefault(30000);
			if (this.StartShowQuestRangeFialWarningTime > (float)valueOrDefault)
			{
				this.HideCancelRangeFailWaringEffect();
			}
		}
	}

	// Token: 0x060134A0 RID: 79008 RVA: 0x0055CC6C File Offset: 0x0055AE6C
	protected override void RegisterAssistant()
	{
		base.AddAssistant(0, new GuideLineAssistant(new <>z__ReadOnlyArray<BtType>(new BtType[]
		{
			BtType.Quest,
			BtType.Recall
		})));
		base.AddAssistant(1, new QuestTrackAssistant());
		base.AddAssistant(2, new GuideEffectAssistant());
		base.AddAssistant(3, new DailyQuestAssistant());
	}

	// Token: 0x060134A1 RID: 79009 RVA: 0x0055CCBC File Offset: 0x0055AEBC
	private T GetAssistant<T>(QuestNewController.EAssistantType type) where T : class
	{
		ControllerAssistantBase controllerAssistantBase;
		if (!this.Assistants.TryGetValue((int)type, out controllerAssistantBase))
		{
			return default(T);
		}
		return controllerAssistantBase as T;
	}

	// Token: 0x060134A2 RID: 79010 RVA: 0x0055CCEE File Offset: 0x0055AEEE
	public void AddQuestTraceEffect(int questId, float showTime, int splineEntityId)
	{
		GuideEffectAssistant assistant = this.GetAssistant<GuideEffectAssistant>(QuestNewController.EAssistantType.GuideEffect);
		if (assistant == null)
		{
			return;
		}
		assistant.AddQuestTraceEffect(questId, showTime, splineEntityId);
	}

	// Token: 0x060134A3 RID: 79011 RVA: 0x0055CD04 File Offset: 0x0055AF04
	public void RemoveQuestTraceEffect(int questId, int splineEntityId)
	{
		GuideEffectAssistant assistant = this.GetAssistant<GuideEffectAssistant>(QuestNewController.EAssistantType.GuideEffect);
		if (assistant == null)
		{
			return;
		}
		assistant.RemoveQuestTraceEffect(questId, splineEntityId);
	}

	// Token: 0x060134A4 RID: 79012 RVA: 0x0055CD19 File Offset: 0x0055AF19
	public void ClearQuestTraceEffect(int questId)
	{
		GuideEffectAssistant assistant = this.GetAssistant<GuideEffectAssistant>(QuestNewController.EAssistantType.GuideEffect);
		if (assistant == null)
		{
			return;
		}
		assistant.ClearQuestTraceEffect(questId);
	}

	// Token: 0x060134A5 RID: 79013 RVA: 0x0055CD30 File Offset: 0x0055AF30
	private void OnGeneralLogicTreeWakeUp()
	{
		QuestTrackAssistant assistant = this.GetAssistant<QuestTrackAssistant>(QuestNewController.EAssistantType.Track);
		if (assistant != null)
		{
			assistant.RefreshCurTrackQuest();
		}
		DailyQuestAssistant assistant2 = this.GetAssistant<DailyQuestAssistant>(QuestNewController.EAssistantType.DailyQuest);
		if (assistant2 != null)
		{
			assistant2.CreateMarksOnWakeUp();
		}
		if (this.CachedRedDotNotify != null)
		{
			this.OnQuestRedDotNotify(this.CachedRedDotNotify, null);
			this.CachedRedDotNotify = null;
		}
	}

	// Token: 0x060134A6 RID: 79014 RVA: 0x0055CD80 File Offset: 0x0055AF80
	[NullableContext(2)]
	private void OnQuestListNotify(QuestListNotify notify, Net.CallbackStatus status)
	{
		List<QuestListItem> list = new List<QuestListItem>();
		foreach (QuestInfo questInfo in notify.Quests)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Quest;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "上线下发进行中的任务";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("任务id", questInfo.QuestId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			list.Add(new QuestListItem
			{
				QuestId = questInfo.QuestId,
				State = questInfo.Status,
				UpdateReason = EQuestStatusUpdateReason.ReLogin
			});
		}
		QuestNewController.HandleQuestListNotify(list);
	}

	// Token: 0x060134A7 RID: 79015 RVA: 0x0055CE2C File Offset: 0x0055B02C
	private void OnQuestReadyListNotify(QuestReadyListNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		int mapTrackQuestId = this.GetMapTrackQuestId();
		QuestNewModel instance = ModelBase<QuestNewModel>.Instance;
		foreach (int num in notify.QuestId)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Quest;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "下发可接任务";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("任务id", num);
			instance2.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (instance.GetQuest(num) == null)
			{
				IQuest questConfig = instance.GetQuestConfig(num);
				if (questConfig != null)
				{
					IAddInteractOption addInteractOption = questConfig.AddInteractOption;
					if (addInteractOption != null)
					{
						if (mapTrackQuestId == num)
						{
							global::Quest quest = instance.AddQuest(num);
							if (quest != null)
							{
								quest.UpdateState(QuestState.Ready, EQuestStatusUpdateReason.ReLogin);
							}
						}
						else
						{
							int entityAreaId = ModelBase<WorldMapModel>.Instance.GetEntityAreaId(addInteractOption.EntityId, null);
							int levelOneAreaId = ConfigBase<AreaConfig>.Instance.GetLevelOneAreaId(entityAreaId);
							int currentAreaId = ModelBase<AreaModel>.Instance.GetCurrentAreaId(null);
							int levelOneAreaId2 = ConfigBase<AreaConfig>.Instance.GetLevelOneAreaId(currentAreaId);
							if (levelOneAreaId == 0 || levelOneAreaId2 == 0 || levelOneAreaId == levelOneAreaId2)
							{
								global::Quest quest2 = instance.AddQuest(num);
								if (quest2 != null)
								{
									quest2.UpdateState(QuestState.Ready, EQuestStatusUpdateReason.ReLogin);
								}
							}
							else
							{
								instance.AddCanAcceptQuest(num);
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x060134A8 RID: 79016 RVA: 0x0055CF88 File Offset: 0x0055B188
	private void OnWorldDone()
	{
		this.AreaChanged(null, 0);
	}

	// Token: 0x060134A9 RID: 79017 RVA: 0x0055CFA8 File Offset: 0x0055B1A8
	private void AreaChanged(int? preAreaId, int curAreaId)
	{
		int currentAreaId = ModelBase<AreaModel>.Instance.GetCurrentAreaId(null);
		int levelOneAreaId = ConfigBase<AreaConfig>.Instance.GetLevelOneAreaId(currentAreaId);
		if (levelOneAreaId == 0)
		{
			return;
		}
		int mapTrackQuestId = this.GetMapTrackQuestId();
		QuestNewModel instance = ModelBase<QuestNewModel>.Instance;
		foreach (KeyValuePair<int, bool> keyValuePair in instance.GetCanAcceptQuest())
		{
			int num;
			bool flag;
			keyValuePair.Deconstruct(out num, out flag);
			int num2 = num;
			if (flag)
			{
				IQuest questConfig = instance.GetQuestConfig(num2);
				if (questConfig != null)
				{
					IAddInteractOption addInteractOption = questConfig.AddInteractOption;
					if (addInteractOption != null)
					{
						int entityAreaId = ModelBase<WorldMapModel>.Instance.GetEntityAreaId(addInteractOption.EntityId, new int?(questConfig.DungeonId));
						if (ConfigBase<AreaConfig>.Instance.GetLevelOneAreaId(entityAreaId) == levelOneAreaId || mapTrackQuestId == num2)
						{
							if (instance.GetQuest(num2) == null)
							{
								global::Quest quest = instance.AddQuest(num2);
								if (quest != null)
								{
									quest.UpdateState(QuestState.Ready, EQuestStatusUpdateReason.ReLogin);
								}
							}
						}
						else
						{
							instance.RemoveQuest(num2);
						}
					}
				}
			}
		}
	}

	// Token: 0x060134AA RID: 79018 RVA: 0x0055D0B8 File Offset: 0x0055B2B8
	private int GetMapTrackQuestId()
	{
		int result = 0;
		TrackMapMarkParams curTrackMark = ModelBase<MapModel>.Instance.GetCurTrackMark();
		if (curTrackMark != null)
		{
			QuestMarkCreateInfo questMarkCreateInfo = ModelBase<MapModel>.Instance.GetMark(curTrackMark.MarkType, curTrackMark.MarkId) as QuestMarkCreateInfo;
			if (questMarkCreateInfo != null)
			{
				result = (int)questMarkCreateInfo.TreeId;
			}
		}
		return result;
	}

	// Token: 0x060134AB RID: 79019 RVA: 0x0055D100 File Offset: 0x0055B300
	private void OnQuestShowListNotify(QuestShowListNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		foreach (KeyValuePair<int, bool> keyValuePair in ModelBase<QuestNewModel>.Instance.GetPreShowQuests())
		{
			int num;
			bool flag;
			keyValuePair.Deconstruct(out num, out flag);
			int num2 = num;
			if (!notify.QuestId.Contains(num2))
			{
				ModelBase<QuestNewModel>.Instance.RemovePreShowQuest(num2);
			}
		}
		foreach (int num3 in notify.QuestId)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Quest;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "下发提前显示的任务";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("任务id", num3);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			ModelBase<QuestNewModel>.Instance.AddPreShowQuest(num3);
		}
	}

	// Token: 0x060134AC RID: 79020 RVA: 0x0055D1EC File Offset: 0x0055B3EC
	private void OnQuestFinishListNotify(QuestFinishListNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		FinishListNotifyData finishListNotifyData = new FinishListNotifyData();
		finishListNotifyData.QuestIds = notify.QuestId.ToList<int>();
		finishListNotifyData.EmitEventName = EEventName.OnQuestFinishListNotify;
		finishListNotifyData.TryChangeTrackedQuest = delegate()
		{
			ControllerBase<QuestNewController>.Instance.TryChangeTrackedQuest2(null);
		};
		QuestNewController.HandleFinishListNotify(finishListNotifyData);
	}

	// Token: 0x060134AD RID: 79021 RVA: 0x0055D244 File Offset: 0x0055B444
	private void QuestStateUpdateNotify(QuestStateUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		QuestNewController.HandleQuestStateUpdate(new QuestStateUpdateData
		{
			QuestId = notify.QuestId,
			State = notify.State,
			UpdateReason = EQuestStatusUpdateReason.NotifyChange
		});
	}

	// Token: 0x060134AE RID: 79022 RVA: 0x0055D26F File Offset: 0x0055B46F
	[NullableContext(2)]
	public ESetTrackResult RequestTrackQuest(int questId, bool bTrack, ERequestTrackOperate operate, ESetTrackReason reason = ESetTrackReason.None, Action finishCallback = null)
	{
		QuestTrackAssistant assistant = this.GetAssistant<QuestTrackAssistant>(QuestNewController.EAssistantType.Track);
		if (assistant == null)
		{
			return ESetTrackResult.QuestNotExist;
		}
		return assistant.RequestTrackQuest(questId, bTrack, operate, reason, finishCallback);
	}

	// Token: 0x060134AF RID: 79023 RVA: 0x0055D28C File Offset: 0x0055B48C
	public void TryTrackAndOpenWorldMap(int questId)
	{
		QuestNewController.<>c__DisplayClass67_0 CS$<>8__locals1 = new QuestNewController.<>c__DisplayClass67_0();
		CS$<>8__locals1.questId = questId;
		if (!ModelBase<QuestNewModel>.Instance.IsTrackingQuest(CS$<>8__locals1.questId))
		{
			this.RequestTrackQuest(CS$<>8__locals1.questId, true, ERequestTrackOperate.Auto, ESetTrackReason.None, new Action(CS$<>8__locals1.<TryTrackAndOpenWorldMap>g__OpenWorldMapView|0));
			return;
		}
		CS$<>8__locals1.<TryTrackAndOpenWorldMap>g__OpenWorldMapView|0();
	}

	// Token: 0x060134B0 RID: 79024 RVA: 0x0055D2DB File Offset: 0x0055B4DB
	public bool TryChangeTrackedQuest(int newQuestId)
	{
		QuestTrackAssistant assistant = ControllerBase<QuestNewController>.Instance.GetAssistant<QuestTrackAssistant>(QuestNewController.EAssistantType.Track);
		return assistant != null && assistant.TryChangeTrackedQuest(newQuestId);
	}

	// Token: 0x060134B1 RID: 79025 RVA: 0x0055D2F4 File Offset: 0x0055B4F4
	public bool TryChangeTrackedQuest2(int? newQuestId)
	{
		QuestTrackAssistant assistant = ControllerBase<QuestNewController>.Instance.GetAssistant<QuestTrackAssistant>(QuestNewController.EAssistantType.Track);
		return assistant != null && assistant.TryChangeTrackedQuest2(newQuestId);
	}

	// Token: 0x060134B2 RID: 79026 RVA: 0x0055D30D File Offset: 0x0055B50D
	private bool CanOpenView(EUiViewName viewName, object o)
	{
		return ModelBase<FunctionModel>.Instance.IsOpen(10004);
	}

	// Token: 0x060134B3 RID: 79027 RVA: 0x0055D320 File Offset: 0x0055B520
	private void OnQuestStateChange(int questId, QuestState state, EQuestStatusUpdateReason reason)
	{
		global::Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(questId);
		if (quest == null)
		{
			return;
		}
		QuestType? questTypeConfig = ConfigBase<QuestNewConfig>.Instance.GetQuestTypeConfig((int)quest.Type);
		if (questTypeConfig == null || !questTypeConfig.Value.NeedRedDot || reason != EQuestStatusUpdateReason.NotifyChange)
		{
			return;
		}
		if (state == QuestState.Progress)
		{
			this.RedDotRequest(questId, EQuestRedDotOperate.Add);
			return;
		}
		if (state - QuestState.Finish > 1)
		{
			return;
		}
		this.RedDotRequest(questId, EQuestRedDotOperate.Delete);
	}

	// Token: 0x060134B4 RID: 79028 RVA: 0x0055D38C File Offset: 0x0055B58C
	private void OnQuestRedDotNotify(QuestRedDotNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		if (!ModelBase<GeneralLogicTreeModel>.Instance.IsWakeUp)
		{
			this.CachedRedDotNotify = notify;
			return;
		}
		foreach (int questId in notify.QuestId)
		{
			ModelBase<QuestNewModel>.Instance.SetQuestRedDot(questId, true);
		}
	}

	// Token: 0x060134B5 RID: 79029 RVA: 0x0055D3F4 File Offset: 0x0055B5F4
	private void OnBtRangeFailWarningNotify(BtRangeFailWarningNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		this.QuestRangeFailWarningTreeId = Singleton<MathUtils>.Instance.LongToBigInt(notify.TreeIncId);
		this.IsHidingQuestRangeFailWarning = false;
		this.IsShowingQuestRangeFailWarning = true;
		this.IsShowQuestRangeFailWarning = true;
		this.ShowQuestRangeFialWarningTime = 0f;
		this.StartShowQuestRangeFialWarningTime = 0f;
		EUiViewName? viewNameByPromptId = ControllerBase<GenericPromptController>.Instance.GetViewNameByPromptId("QuestRangeFailWarning");
		if (viewNameByPromptId != null && !Singleton<UiManager>.Instance.IsViewOpen(viewNameByPromptId.Value))
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("QuestRangeFailWarning", Array.Empty<object>());
		}
	}

	// Token: 0x060134B6 RID: 79030 RVA: 0x0055D482 File Offset: 0x0055B682
	private void OnQuestGiveUpNotify(QuestGiveUpNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		QuestNewController.HandleGiveUpNotify(notify.QuestId, notify.TreeIncId, notify.FlowIncIds, delegate(int questId)
		{
			QuestReadyForGiveUpRequest questReadyForGiveUpRequest = new QuestReadyForGiveUpRequest();
			questReadyForGiveUpRequest.QuestId = questId;
			Singleton<Net>.Instance.Call<QuestReadyForGiveUpResponse>(ERequestMessageId.QuestReadyForGiveUpRequest, questReadyForGiveUpRequest, delegate(QuestReadyForGiveUpResponse response, Net.CallbackStatus _)
			{
				if (response != null && response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 19852, null, true, true);
				}
			}, 0);
		}, "任务结束打断剧情");
	}

	// Token: 0x060134B7 RID: 79031 RVA: 0x0055D4C0 File Offset: 0x0055B6C0
	private void OnPlotSequenceEnd(PlotResultInfo plotResultInfo)
	{
		if (ModelBase<QuestNewModel>.Instance.IsServerNotifyEnd)
		{
			ModelBase<QuestNewModel>.Instance.IsServerNotifyEnd = false;
			if (ModelBase<RecallQuestModel>.Instance.IsInRecallInstance())
			{
				RecallQuestReadyForGiveUpRequest message = new RecallQuestReadyForGiveUpRequest
				{
					RecallQuestId = ModelBase<QuestNewModel>.Instance.ServerNotifyEndQuestId
				};
				Singleton<Net>.Instance.Call<RecallQuestReadyForGiveUpResponse>(ERequestMessageId.RecallQuestReadyForGiveUpRequest, message, delegate(RecallQuestReadyForGiveUpResponse response, Net.CallbackStatus _)
				{
					if (response != null && response.ErrorId != Aki.Protocol.ErrorCode.Success)
					{
						ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorId, 23868, null, true, true);
					}
				}, 0);
				return;
			}
			QuestReadyForGiveUpRequest message2 = new QuestReadyForGiveUpRequest
			{
				QuestId = ModelBase<QuestNewModel>.Instance.ServerNotifyEndQuestId
			};
			Singleton<Net>.Instance.Call<QuestReadyForGiveUpResponse>(ERequestMessageId.QuestReadyForGiveUpRequest, message2, delegate(QuestReadyForGiveUpResponse response, Net.CallbackStatus _)
			{
				if (response != null && response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 19852, null, true, true);
				}
			}, 0);
		}
	}

	// Token: 0x060134B8 RID: 79032 RVA: 0x0055D580 File Offset: 0x0055B780
	private void OnBtCancelRangeFailWarningNotify(BtCancelRangeFailWarningNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		if (this.IsShowQuestRangeFailWarning)
		{
			this.HideCancelRangeFailWaringEffect();
		}
	}

	// Token: 0x060134B9 RID: 79033 RVA: 0x0055D590 File Offset: 0x0055B790
	public void HideCancelRangeFailWaringEffect()
	{
		this.IsHidingQuestRangeFailWarning = true;
		this.IsShowingQuestRangeFailWarning = false;
		this.HidingQuestRangeFialWarningTime = 0f;
		this.QuestRangeFailWarningTreeId = 0L;
		this.IsShowQuestRangeFailWarning = false;
	}

	// Token: 0x060134BA RID: 79034 RVA: 0x0055D5BC File Offset: 0x0055B7BC
	public void RedDotRequest(int questId, EQuestRedDotOperate operate)
	{
		QuestRedDotRequest questRedDotRequest = QuestRedDotRequest.Create();
		questRedDotRequest.QuestId = questId;
		questRedDotRequest.Operate = (int)operate;
		Singleton<Net>.Instance.Call<QuestRedDotResponse>(ERequestMessageId.QuestRedDotRequest, questRedDotRequest, delegate(QuestRedDotResponse response, Net.CallbackStatus _)
		{
			if (response != null && response.ErrorId != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorId, 24256, null, true, true);
			}
			ModelBase<QuestNewModel>.Instance.SetQuestRedDot(questId, operate == EQuestRedDotOperate.Add);
		}, 0);
	}

	// Token: 0x060134BB RID: 79035 RVA: 0x0055D618 File Offset: 0x0055B818
	public bool IsTrackPositionOutFailRange(global::Vector position)
	{
		global::Quest curTrackedQuest = ModelBase<QuestNewModel>.Instance.GetCurTrackedQuest();
		if (curTrackedQuest == null || curTrackedQuest.TreeId == null)
		{
			return false;
		}
		BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(curTrackedQuest.TreeId.Value), false);
		if (behaviorTree == null)
		{
			return false;
		}
		QuestFailedBehaviorNode processingFailedNode = behaviorTree.GetProcessingFailedNode();
		return processingFailedNode != null && !processingFailedNode.NeedRequiresSecondConfirmation && processingFailedNode.IsOutFailRange(position);
	}

	// Token: 0x060134BC RID: 79036 RVA: 0x0055D684 File Offset: 0x0055B884
	private void OnWaitQuestConfirmResourceNotify(WaitQuestConfirmResourceNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		QuestNewModel instance = ModelBase<QuestNewModel>.Instance;
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module = ELogModule.QuestResource;
		ELogAuthor author = ELogAuthor.ZWY;
		string message = "WaitQuestConfirmResource";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("LackResourceQuestIds", string.Join<int>(",", notify.LackResourceQuestIds));
		instance2.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (!instance.QuestVideoResourceDownloadFinished)
		{
			instance.IsLackQuestVideoResource = (notify.LackResourceQuestIds.Count != 0);
		}
	}

	// Token: 0x060134BD RID: 79037 RVA: 0x0055D6E9 File Offset: 0x0055B8E9
	public void SetVideoResourceDownloadTriggerId(int questId)
	{
		this.VideoResourceDownloadTriggerId = new int?(questId);
	}

	// Token: 0x060134BE RID: 79038 RVA: 0x0055D6F7 File Offset: 0x0055B8F7
	public void SetIsReportDownloadNotEnoughSpace(bool result)
	{
		this.IsReportDownloadNotEnoughSpace = new bool?(result);
	}

	// Token: 0x060134BF RID: 79039 RVA: 0x0055D708 File Offset: 0x0055B908
	private void OnQuestVideoResourceDownloadFinish(EVideoResSizeType resType)
	{
		EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
		if (playerGender != EPlayerGender.Female)
		{
			if (playerGender == EPlayerGender.Male && resType == EVideoResSizeType.MalePrepare)
			{
				ModelBase<QuestNewModel>.Instance.IsLackQuestVideoResource = false;
				ModelBase<QuestNewModel>.Instance.QuestVideoResourceDownloadFinished = true;
				Singleton<EventSystem>.Instance.Emit(EEventName.UpdateQuestListAndDetails);
			}
		}
		else if (resType == EVideoResSizeType.FemalePrepare)
		{
			ModelBase<QuestNewModel>.Instance.IsLackQuestVideoResource = false;
			ModelBase<QuestNewModel>.Instance.QuestVideoResourceDownloadFinished = true;
			Singleton<EventSystem>.Instance.Emit(EEventName.UpdateQuestListAndDetails);
		}
		if (resType == EVideoResSizeType.MalePrepare || resType == EVideoResSizeType.FemalePrepare)
		{
			DownloadVideoResLogData downloadVideoResLogData = new DownloadVideoResLogData();
			downloadVideoResLogData.i_task_id = this.VideoResourceDownloadTriggerId.GetValueOrDefault();
			downloadVideoResLogData.b_if_storage_alert = this.IsReportDownloadNotEnoughSpace.GetValueOrDefault();
			downloadVideoResLogData.i_role_id = ((playerGender == EPlayerGender.Female) ? 2 : 1);
			if (resType == EVideoResSizeType.FemalePrepare)
			{
				downloadVideoResLogData.i_resource_type = 2;
				ValueTuple<double, double, double, bool> reportLogData = Singleton<VideoUpdateManager>.Instance.GetVideoUpdater(EVideoResSizeType.FemalePrepare).GetReportLogData();
				double item = reportLogData.Item1;
				double item2 = reportLogData.Item2;
				double item3 = reportLogData.Item3;
				bool item4 = reportLogData.Item4;
				downloadVideoResLogData.i_peak_speed = (int)item;
				downloadVideoResLogData.i_resource_size = item2;
				downloadVideoResLogData.i_download_time = (int)item3;
				downloadVideoResLogData.b_if_storage_alert = item4;
				downloadVideoResLogData.i_download_status = 1;
			}
			else
			{
				downloadVideoResLogData.i_resource_type = 1;
				ValueTuple<double, double, double, bool> reportLogData2 = Singleton<VideoUpdateManager>.Instance.GetVideoUpdater(EVideoResSizeType.MalePrepare).GetReportLogData();
				double item5 = reportLogData2.Item1;
				double item6 = reportLogData2.Item2;
				double item7 = reportLogData2.Item3;
				bool item8 = reportLogData2.Item4;
				downloadVideoResLogData.i_peak_speed = (int)item5;
				downloadVideoResLogData.i_resource_size = item6;
				downloadVideoResLogData.i_download_time = (int)item7;
				downloadVideoResLogData.b_if_storage_alert = item8;
				downloadVideoResLogData.i_download_status = 1;
			}
			ControllerBase<LogReportController>.Instance.LogReport(downloadVideoResLogData);
		}
	}

	// Token: 0x060134C0 RID: 79040 RVA: 0x0055D894 File Offset: 0x0055BA94
	public void ConfirmQuestResourceRequest(int questId, Action callback = null)
	{
		ConfirmQuestResourceRequest confirmQuestResourceRequest = Aki.Protocol.ConfirmQuestResourceRequest.Create();
		confirmQuestResourceRequest.QuestIds.Add(questId);
		Singleton<Net>.Instance.Call<ConfirmQuestResourceResponse>(ERequestMessageId.ConfirmQuestResourceRequest, confirmQuestResourceRequest, delegate(ConfirmQuestResourceResponse response, Net.CallbackStatus _)
		{
			if (response != null)
			{
				if (response.ErrorId != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorId, 26227, null, true, true);
				}
				ModelBase<QuestNewModel>.Instance.RemoveLackResourceQuest(questId);
				Action callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2();
			}
		}, 0);
	}

	// Token: 0x060134C1 RID: 79041 RVA: 0x0055D8EC File Offset: 0x0055BAEC
	public void RequestSetQuestFocusMode(int questId, Action<bool> callback = null)
	{
		SetQuestFocusModeRequest setQuestFocusModeRequest = SetQuestFocusModeRequest.Create();
		setQuestFocusModeRequest.QuestId = questId;
		Singleton<Net>.Instance.Call<SetQuestFocusModeResponse>(ERequestMessageId.SetQuestFocusModeRequest, setQuestFocusModeRequest, delegate(SetQuestFocusModeResponse response, Net.CallbackStatus _)
		{
			if (response != null)
			{
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					if (response.ErrorCode == Aki.Protocol.ErrorCode.ErrForcedOccupationResource || response.ErrorCode == Aki.Protocol.ErrorCode.InstanceCannotSetQuestFocus || response.ErrorCode == Aki.Protocol.ErrorCode.InstanceCannotCancelQuestFocus || response.ErrorCode == Aki.Protocol.ErrorCode.DisabledFocusMode)
					{
						string textByErrorId = ConfigBase<ErrorCodeConfig>.Instance.GetTextByErrorId(response.ErrorCode);
						ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(textByErrorId);
					}
					else
					{
						ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 20414, null, true, true);
					}
				}
				Action<bool> callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2(false);
			}
		}, 0);
	}

	// Token: 0x060134C2 RID: 79042 RVA: 0x0055D930 File Offset: 0x0055BB30
	public void RequestCancelQuestFocusMode(int questId, Action callback)
	{
		CancelQuestFocusModeRequest cancelQuestFocusModeRequest = CancelQuestFocusModeRequest.Create();
		cancelQuestFocusModeRequest.QuestId = questId;
		Singleton<Net>.Instance.Call<CancelQuestFocusModeResponse>(ERequestMessageId.CancelQuestFocusModeRequest, cancelQuestFocusModeRequest, delegate(CancelQuestFocusModeResponse response, Net.CallbackStatus _)
		{
			if (response != null)
			{
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 15535, null, true, true);
				}
				Action callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2();
			}
		}, 0);
	}

	// Token: 0x060134C3 RID: 79043 RVA: 0x0055D974 File Offset: 0x0055BB74
	public void RequestSetFocusModeDeterCondition(bool deterCond)
	{
		SetFocusModeDeterCondRequest setFocusModeDeterCondRequest = SetFocusModeDeterCondRequest.Create();
		setFocusModeDeterCondRequest.DeterCond = deterCond;
		Singleton<Net>.Instance.Call<SetFocusModeDeterCondResponse>(ERequestMessageId.SetFocusModeDeterCondRequest, setFocusModeDeterCondRequest, delegate(SetFocusModeDeterCondResponse response, Net.CallbackStatus _)
		{
			if (response != null && response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 27817, null, true, true);
			}
		}, 0);
	}

	// Token: 0x060134C4 RID: 79044 RVA: 0x0055D9C0 File Offset: 0x0055BBC0
	public void RequestAcceptFocusWaitQuest(int questId, Action callback)
	{
		AcceptFocusWaitQuestRequest acceptFocusWaitQuestRequest = AcceptFocusWaitQuestRequest.Create();
		acceptFocusWaitQuestRequest.QuestId = questId;
		Singleton<Net>.Instance.Call<AcceptFocusWaitQuestResponse>(ERequestMessageId.AcceptFocusWaitQuestRequest, acceptFocusWaitQuestRequest, delegate(AcceptFocusWaitQuestResponse response, Net.CallbackStatus _)
		{
			if (response != null)
			{
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 27817, null, true, true);
				}
				ModelBase<QuestNewModel>.Instance.RemovePendingAcceptQuestOnFocusMode(questId);
				if (callback != null)
				{
					Action callback2 = callback;
					if (callback2 == null)
					{
						return;
					}
					callback2();
				}
			}
		}, 0);
	}

	// Token: 0x060134C5 RID: 79045 RVA: 0x0055DA10 File Offset: 0x0055BC10
	private void OnStartSetQuestFocusNotify(StartSetQuestFocusNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		ModelBase<QuestNewModel>.Instance.SetFocusQuestId(notify.FocusQuestId);
		if (notify.Reason == QuestFocusReason.Inherit)
		{
			return;
		}
		ControllerBase<LevelLoadingController>.Instance.OpenLoading<ELoadingPerform>(ELoadingReason.QuestFocusMode, ELoadingPerform.VideoCenter, null, null, new object[]
		{
			"Task_Focus_EnterFocusMode"
		});
		this.DelayTimerHandle = TimerSystem.Instance.Delay(delegate(float _)
		{
			ControllerBase<LevelLoadingController>.Instance.CloseLoading(ELoadingReason.QuestFocusMode, null, null, null);
		}, 5000f, null, null, true, 1f);
	}

	// Token: 0x060134C6 RID: 79046 RVA: 0x0055DA94 File Offset: 0x0055BC94
	private void OnQuestFocusInfoNotify(QuestFocusInfoNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		ModelBase<QuestNewModel>.Instance.SetFocusQuestId(notify.FocusQuestId);
		if (TimerSystem.Instance.Has(this.DelayTimerHandle))
		{
			TimerSystem.Instance.Remove(this.DelayTimerHandle);
		}
		this.DelayTimerHandle = TimerSystem.Instance.Delay(delegate(float _)
		{
			ControllerBase<LevelLoadingController>.Instance.CloseLoading(ELoadingReason.QuestFocusMode, null, null, null);
			if (notify.FocusQuestId != 0)
			{
				this.RequestTrackQuest(notify.FocusQuestId, true, ERequestTrackOperate.Auto, ESetTrackReason.None, null);
			}
			if (TimerSystem.Instance.Has(this.DelayTimerHandle))
			{
				TimerSystem.Instance.Remove(this.DelayTimerHandle);
			}
		}, 2000f, null, null, true, 1f);
	}

	// Token: 0x060134C7 RID: 79047 RVA: 0x0055DB18 File Offset: 0x0055BD18
	private void OnQuestLockInfoNotify(QuestLockInfoNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		QuestNewModel instance = ModelBase<QuestNewModel>.Instance;
		foreach (int questId in instance.GetAllLockQuests())
		{
			instance.LockQuestSuspendByOnline(questId, false);
		}
		foreach (QuestLockInfo lockInfo in notify.QuestLockInfos)
		{
			instance.AddQuestLockInfo(lockInfo);
		}
	}

	// Token: 0x060134C8 RID: 79048 RVA: 0x0055DBB0 File Offset: 0x0055BDB0
	private void OnInteractQuestSuspendEntityNotify(InteractQuestSuspendEntityNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		global::Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(notify.QuestId);
		if (quest == null)
		{
			return;
		}
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew("Text_TaskSuspendedInteractionDisabled_Text", null);
		string item = ((localTextNew != null) ? localTextNew.Replace("{0}", quest.Name) : null) ?? "Text_TaskSuspendedInteractionDisabled_Text";
		ControllerBase<GenericPromptController>.Instance.ShowPromptByItsType<object>(EPromptSubViewType.FloatLinePrompt, null, null, new <>z__ReadOnlySingleElementList<object>(item), null, null, null, null, null, false, null);
	}

	// Token: 0x060134C9 RID: 79049 RVA: 0x0055DC2C File Offset: 0x0055BE2C
	private void OnResetQuestFocusModeNotify(ResetQuestFocusModeNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		ResetQuestFocusModeReason reason = notify.Reason;
		string text;
		if (reason != ResetQuestFocusModeReason.EnterSealedArea)
		{
			if (reason == ResetQuestFocusModeReason.ForceOccupyFail)
			{
				text = "Task_Focus_Tips04";
			}
			else
			{
				text = null;
			}
		}
		else
		{
			text = "Task_Focus_Tips03";
		}
		string text2 = text;
		if (text2 == null)
		{
			return;
		}
		string item = ConfigMultiTextLang.GetLocalTextNew(text2, null) ?? text2;
		ControllerBase<GenericPromptController>.Instance.ShowPromptByItsType<object>(EPromptSubViewType.FloatLinePrompt, null, null, new <>z__ReadOnlySingleElementList<object>(item), null, null, null, null, null, false, null);
	}

	// Token: 0x060134CA RID: 79050 RVA: 0x0055DC9C File Offset: 0x0055BE9C
	public static void HandleGiveUpNotify(int questId, long treeIncId, IReadOnlyList<long> flowIncIds, Action<int> sendReadyForGiveUpRequest, string reason)
	{
		long value = Singleton<MathUtils>.Instance.LongToBigInt(treeIncId);
		BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(value), false);
		if (behaviorTree != null)
		{
			behaviorTree.StopCurrentActions();
		}
		bool flag = false;
		long flowIncId = ControllerBase<FlowController>.Instance.GetFlowIncId();
		foreach (long num in flowIncIds)
		{
			if (flowIncId == num)
			{
				flag = true;
				break;
			}
		}
		if (ModelBase<PlotModel>.Instance.IsInPlot && flag)
		{
			ControllerBase<FlowController>.Instance.FinishFlow(reason, null, false);
			ModelBase<QuestNewModel>.Instance.IsServerNotifyEnd = true;
			ModelBase<QuestNewModel>.Instance.ServerNotifyEndQuestId = questId;
			return;
		}
		sendReadyForGiveUpRequest(questId);
	}

	// Token: 0x060134CB RID: 79051 RVA: 0x0055DD64 File Offset: 0x0055BF64
	public static void HandleQuestListNotify(IReadOnlyList<QuestListItem> items)
	{
		foreach (QuestListItem questListItem in items)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Quest;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "上线下发任务";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("任务id", questListItem.QuestId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			global::Quest quest = ModelBase<QuestNewModel>.Instance.AddQuest(questListItem.QuestId);
			if (quest != null)
			{
				quest.UpdateState(questListItem.State, questListItem.UpdateReason);
			}
		}
	}

	// Token: 0x060134CC RID: 79052 RVA: 0x0055DDFC File Offset: 0x0055BFFC
	public unsafe static void HandleQuestStateUpdate(QuestStateUpdateData data)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Quest;
		ELogAuthor author = ELogAuthor.YSQ;
		string message = "任务状态更新";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("任务Id", data.QuestId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("StateId", data.State);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		switch (data.State)
		{
		case QuestState.InActive:
		case QuestState.Ready:
		case QuestState.Progress:
		{
			global::Quest quest = ModelBase<QuestNewModel>.Instance.AddQuest(data.QuestId);
			if (quest == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Quest;
				ELogAuthor author2 = ELogAuthor.YSQ;
				string message2 = "任务状态更新时：任务不存在";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("任务Id", data.QuestId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("StateId", data.State);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			}
			else
			{
				quest.UpdateState(data.State, data.UpdateReason);
			}
			break;
		}
		case QuestState.Finish:
		{
			ModelBase<QuestNewModel>.Instance.AddFinishedQuest(data.QuestId);
			global::Quest quest2 = ModelBase<QuestNewModel>.Instance.GetQuest(data.QuestId);
			if (quest2 != null)
			{
				quest2.UpdateState(data.State, data.UpdateReason);
			}
			break;
		}
		case QuestState.Delete:
		{
			global::Quest quest3 = ModelBase<QuestNewModel>.Instance.GetQuest(data.QuestId);
			ModelBase<QuestNewModel>.Instance.RemoveQuest(data.QuestId);
			if (quest3 != null)
			{
				quest3.UpdateState(data.State, data.UpdateReason);
			}
			break;
		}
		}
		Action onAfterUpdate = data.OnAfterUpdate;
		if (onAfterUpdate == null)
		{
			return;
		}
		onAfterUpdate();
	}

	// Token: 0x060134CD RID: 79053 RVA: 0x0055DFAC File Offset: 0x0055C1AC
	public static void HandleFinishListNotify(FinishListNotifyData data)
	{
		foreach (int questId in data.QuestIds)
		{
			ModelBase<QuestNewModel>.Instance.AddFinishedQuest(questId);
		}
		Singleton<EventSystem>.Instance.Emit(data.EmitEventName);
		Action tryChangeTrackedQuest = data.TryChangeTrackedQuest;
		if (tryChangeTrackedQuest == null)
		{
			return;
		}
		tryChangeTrackedQuest();
	}

	// Token: 0x060134CE RID: 79054 RVA: 0x0055E024 File Offset: 0x0055C224
	public static void NotifyTraceQuestFromServer(int questId)
	{
		if (questId == 0)
		{
			return;
		}
		ModelBase<QuestNewModel>.Instance.SetQuestTrackState(questId, true, ESetTrackReason.None);
	}

	// Token: 0x060134CF RID: 79055 RVA: 0x0055E038 File Offset: 0x0055C238
	public void RequestQuestNpcMoveOver(long creatureDataId)
	{
		if (ModelBase<RecallQuestModel>.Instance.IsInRecallInstance())
		{
			ControllerBase<RecallQuestController>.Instance.RequestRecallQuestNpcMoveOver(creatureDataId);
			return;
		}
		QuestNpcMoveOverRequest questNpcMoveOverRequest = QuestNpcMoveOverRequest.Create();
		questNpcMoveOverRequest.EntityId = creatureDataId;
		Singleton<Net>.Instance.Call<QuestNpcMoveOverResponse>(ERequestMessageId.QuestNpcMoveOverRequest, questNpcMoveOverRequest, delegate(QuestNpcMoveOverResponse response, Net.CallbackStatus _)
		{
			if (response != null && response.ErrorId != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorId, 17144, null, true, true);
			}
		}, 0);
	}

	// Token: 0x040096A7 RID: 38567
	private readonly float ShowQuestRangeFailWarningTime = 300f;

	// Token: 0x040096AB RID: 38571
	private const string TIPS_NAME = "QuestRangeFailWarning";

	// Token: 0x020089E8 RID: 35304
	[NullableContext(0)]
	private enum EAssistantType
	{
		// Token: 0x0402E862 RID: 190562
		GuideLine,
		// Token: 0x0402E863 RID: 190563
		Track,
		// Token: 0x0402E864 RID: 190564
		GuideEffect,
		// Token: 0x0402E865 RID: 190565
		DailyQuest
	}
}
