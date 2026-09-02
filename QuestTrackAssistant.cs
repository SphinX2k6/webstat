using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RecallQuest.Model;
using CSharpScript.Game.Ui;

// Token: 0x02002640 RID: 9792
[NullableContext(1)]
[Nullable(0)]
[Controller(0)]
public class QuestTrackAssistant : ControllerAssistantBase
{
	// Token: 0x060134D1 RID: 79057 RVA: 0x0055E0AD File Offset: 0x0055C2AD
	protected override void OnDestroy()
	{
	}

	// Token: 0x060134D2 RID: 79058 RVA: 0x0055E0AF File Offset: 0x0055C2AF
	public override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<TraceQuestNotify>(ENotifyMessageId.TraceQuestNotify, new Action<TraceQuestNotify, Net.CallbackStatus>(this.OnTraceQuestNotify));
	}

	// Token: 0x060134D3 RID: 79059 RVA: 0x0055E0CD File Offset: 0x0055C2CD
	public override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TraceQuestNotify);
	}

	// Token: 0x060134D4 RID: 79060 RVA: 0x0055E0E0 File Offset: 0x0055C2E0
	public override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<long, int, EBehaviorTreeSuspendType>(EEventName.GeneralLogicTreeSuspend, new Action<long, int, EBehaviorTreeSuspendType>(this.OnGeneralLogicTreeSuspend));
		Singleton<EventSystem>.Instance.Add<int, bool, int>(EEventName.TsNotifyQuestTrackState, new Action<int, bool, int>(this.OnTsNotifyQuestTrackState));
		ControllerBase<InputDistributeController>.Instance.BindAction("任务追踪", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
	}

	// Token: 0x060134D5 RID: 79061 RVA: 0x0055E140 File Offset: 0x0055C340
	public override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove<long, int, EBehaviorTreeSuspendType>(EEventName.GeneralLogicTreeSuspend, new Action<long, int, EBehaviorTreeSuspendType>(this.OnGeneralLogicTreeSuspend));
		Singleton<EventSystem>.Instance.Remove<int, bool, int>(EEventName.TsNotifyQuestTrackState, new Action<int, bool, int>(this.OnTsNotifyQuestTrackState));
		ControllerBase<InputDistributeController>.Instance.UnBindAction("任务追踪", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
	}

	// Token: 0x060134D6 RID: 79062 RVA: 0x0055E1A0 File Offset: 0x0055C3A0
	private void OnTraceQuestNotify(TraceQuestNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		if (notify.QuestId == 0)
		{
			return;
		}
		ModelBase<QuestNewModel>.Instance.SetQuestTrackState(notify.QuestId, true, ESetTrackReason.None);
	}

	// Token: 0x060134D7 RID: 79063 RVA: 0x0055E1C0 File Offset: 0x0055C3C0
	private void OnInputAction(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification _)
	{
		if (actionType != InputDistributeDefine.EActionType.Release)
		{
			return;
		}
		global::Quest curTrackedQuest = ModelBase<QuestNewModel>.Instance.GetCurTrackedQuest();
		BtType p = (curTrackedQuest != null && curTrackedQuest.Type == EQuest.Recall) ? BtType.Recall : BtType.Quest;
		Singleton<EventSystem>.Instance.Emit<BtType, long?>(EEventName.OnLogicTreeTrackUpdate, p, (curTrackedQuest != null) ? curTrackedQuest.TreeId : null);
	}

	// Token: 0x060134D8 RID: 79064 RVA: 0x0055E214 File Offset: 0x0055C414
	public void RefreshCurTrackQuest()
	{
		global::Quest curTrackedQuest = ModelBase<QuestNewModel>.Instance.GetCurTrackedQuest();
		ModelBase<QuestNewModel>.Instance.RefreshResidentQuestMapMark();
		if (curTrackedQuest != null)
		{
			curTrackedQuest.SetTrack(false, ESetTrackReason.None);
		}
		if (curTrackedQuest != null)
		{
			curTrackedQuest.SetTrack(true, ESetTrackReason.None);
		}
		int curShowUpdateTipsQuest = ModelBase<QuestNewModel>.Instance.CurShowUpdateTipsQuest;
		if (curShowUpdateTipsQuest != 0)
		{
			this.TryChangeTrackedQuest(curShowUpdateTipsQuest);
		}
	}

	// Token: 0x060134D9 RID: 79065 RVA: 0x0055E268 File Offset: 0x0055C468
	[NullableContext(2)]
	public ESetTrackResult RequestTrackQuest(int questId, bool bTrack, ERequestTrackOperate operate, ESetTrackReason reason = ESetTrackReason.None, Action finishCallback = null)
	{
		QuestNewModel instance = ModelBase<QuestNewModel>.Instance;
		if (bTrack)
		{
			global::Quest quest = instance.GetQuest(questId);
			if (quest == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Quest;
				ELogAuthor author = ELogAuthor.YSQ;
				string message = "QuestTrackAssistant.RequestTrackQuest:找不到任务";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("任务Id", questId);
				instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				Action finishCallback2 = finishCallback;
				if (finishCallback2 != null)
				{
					finishCallback2();
				}
				return ESetTrackResult.QuestNotExist;
			}
			if (quest.IsSuspend())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("QuestTrackOccupiedTip", Array.Empty<object>());
				Action finishCallback3 = finishCallback;
				if (finishCallback3 != null)
				{
					finishCallback3();
				}
				return ESetTrackResult.QuestIsSuspend;
			}
			if (instance.IsInFocusMode())
			{
				if (!instance.IsInFocusOnQuest(questId))
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("FocusModeCanNotTrackOtherQuest", Array.Empty<object>());
					Action finishCallback4 = finishCallback;
					if (finishCallback4 != null)
					{
						finishCallback4();
					}
					return ESetTrackResult.FocusModeCanNotTrackOtherQuest;
				}
			}
			else if (!quest.CanShowTrackExpression())
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Quest;
				ELogAuthor author2 = ELogAuthor.YSQ;
				string message2 = "QuestTrackAssistant.RequestTrackQuest,任务不可显示追踪表现";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("questId", questId);
				instance3.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				Action finishCallback5 = finishCallback;
				if (finishCallback5 != null)
				{
					finishCallback5();
				}
				return ESetTrackResult.QuestNotCanShowTrackExpression;
			}
		}
		ModelBase<QuestNewModel>.Instance.SetQuestTrackState(questId, bTrack, reason);
		if (!ModelBase<RecallQuestModel>.Instance.IsInRecallInstance())
		{
			TraceQuestRequest traceQuestRequest = TraceQuestRequest.Create();
			traceQuestRequest.QuestId = questId;
			traceQuestRequest.TraceType = (bTrack ? 1 : 2);
			traceQuestRequest.Operate = (int)operate;
			Singleton<Net>.Instance.Call<TraceQuestResponse>(ERequestMessageId.TraceQuestRequest, traceQuestRequest, delegate(TraceQuestResponse response, Net.CallbackStatus _)
			{
				if (response != null && response.ErrorId != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorId, 20341, null, true, true);
				}
				Action finishCallback6 = finishCallback;
				if (finishCallback6 == null)
				{
					return;
				}
				finishCallback6();
			}, 0);
			return ESetTrackResult.Success;
		}
		global::Quest quest2 = ModelBase<QuestNewModel>.Instance.GetQuest(questId);
		if (quest2 == null || quest2.Type != EQuest.Recall)
		{
			return ESetTrackResult.Success;
		}
		TraceRecallQuestRequest traceRecallQuestRequest = TraceRecallQuestRequest.Create();
		traceRecallQuestRequest.RecallQuestId = questId;
		traceRecallQuestRequest.TraceType = (bTrack ? 1 : 2);
		traceRecallQuestRequest.Operate = (int)operate;
		Singleton<Net>.Instance.Call<TraceRecallQuestResponse>(ERequestMessageId.TraceRecallQuestRequest, traceRecallQuestRequest, delegate(TraceRecallQuestResponse response, Net.CallbackStatus _)
		{
			if (response != null && response.ErrorId != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorId, 19059, null, true, true);
				Action finishCallback6 = finishCallback;
				if (finishCallback6 == null)
				{
					return;
				}
				finishCallback6();
			}
		}, 0);
		return ESetTrackResult.Success;
	}

	// Token: 0x060134DA RID: 79066 RVA: 0x0055E44C File Offset: 0x0055C64C
	public bool TryChangeTrackedQuest(int newQuestId)
	{
		QuestNewModel instance = ModelBase<QuestNewModel>.Instance;
		if (instance.IsInFocusMode())
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Quest;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "QuestTrackAssistant.专注模式下不允许切换任务追踪";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("newQuestId", newQuestId);
			instance2.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		global::Quest quest = instance.GetQuest(newQuestId);
		if (quest == null || !quest.IsProgressing)
		{
			return false;
		}
		global::Quest curTrackedQuest = instance.GetCurTrackedQuest();
		if (curTrackedQuest != null && curTrackedQuest.Id == newQuestId)
		{
			return false;
		}
		if (quest.AutoCoverCurTrack)
		{
			this.RequestTrackQuest(newQuestId, true, ERequestTrackOperate.Auto, ESetTrackReason.None, null);
			return true;
		}
		if (curTrackedQuest != null && curTrackedQuest.AutoTrack)
		{
			return false;
		}
		if (!quest.AutoTrack)
		{
			return false;
		}
		this.RequestTrackQuest(newQuestId, true, ERequestTrackOperate.Auto, ESetTrackReason.None, null);
		return true;
	}

	// Token: 0x060134DB RID: 79067 RVA: 0x0055E4FC File Offset: 0x0055C6FC
	public bool TryChangeTrackedQuest2(int? newQuestId)
	{
		QuestNewModel instance = ModelBase<QuestNewModel>.Instance;
		if (instance.IsInFocusMode())
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Quest;
			ELogAuthor author = ELogAuthor.YSQ;
			string message = "QuestTrackAssistant.专注模式下不允许切换任务追踪2";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("newQuestId", newQuestId);
			instance2.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		global::Quest curTrackedQuest = instance.GetCurTrackedQuest();
		if (curTrackedQuest != null && !ModelBase<QuestNewModel>.Instance.CheckQuestFinished(curTrackedQuest.Id))
		{
			return false;
		}
		if (newQuestId != null)
		{
			int? successiveQuestId = instance.GetSuccessiveQuestId(new int?(newQuestId.Value));
			if (successiveQuestId != null)
			{
				this.RequestTrackQuest(successiveQuestId.Value, true, ERequestTrackOperate.Auto, ESetTrackReason.None, null);
				return true;
			}
		}
		int? highestPriorityProcessingQuestId = instance.GetHighestPriorityProcessingQuestId();
		if (highestPriorityProcessingQuestId != null)
		{
			if (newQuestId != null)
			{
				this.RequestTrackQuest(highestPriorityProcessingQuestId.Value, true, ERequestTrackOperate.Auto, ESetTrackReason.None, null);
				return true;
			}
			double player = LocalStorage.GetPlayer<double>(ELocalStoragePlayerKey.AuToTrackQuestTime, 0.0);
			double serverTimeStamp = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
			if (player == 0.0 || serverTimeStamp > player)
			{
				LocalStorage.SetPlayer<double>(ELocalStoragePlayerKey.AuToTrackQuestTime, Singleton<TimeUtil>.Instance.GetNextDayTimeStamp());
				this.RequestTrackQuest(highestPriorityProcessingQuestId.Value, true, ERequestTrackOperate.Auto, ESetTrackReason.None, null);
				return true;
			}
		}
		return false;
	}

	// Token: 0x060134DC RID: 79068 RVA: 0x0055E624 File Offset: 0x0055C824
	private void OnGeneralLogicTreeSuspend(long treeIncId, int nodeId, EBehaviorTreeSuspendType suspendType)
	{
		BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(treeIncId), false);
		BtType btType = ModelBase<RecallQuestModel>.Instance.IsInRecallInstance() ? BtType.Recall : BtType.Quest;
		if (behaviorTree == null || behaviorTree.BtType != btType)
		{
			return;
		}
		global::Quest curTrackedQuest = ModelBase<QuestNewModel>.Instance.GetCurTrackedQuest();
		if (curTrackedQuest != null)
		{
			long? treeId = curTrackedQuest.TreeId;
			if (treeId.GetValueOrDefault() == treeIncId & treeId != null)
			{
				if (suspendType == EBehaviorTreeSuspendType.Occupation)
				{
					this.RequestTrackQuest(curTrackedQuest.Id, false, ERequestTrackOperate.Auto, ESetTrackReason.None, null);
					return;
				}
				if (suspendType != EBehaviorTreeSuspendType.Online)
				{
					return;
				}
				curTrackedQuest.SetTrack(false, ESetTrackReason.None);
				return;
			}
		}
	}

	// Token: 0x060134DD RID: 79069 RVA: 0x0055E6B2 File Offset: 0x0055C8B2
	private void OnTsNotifyQuestTrackState(int questId, bool bTrack, int reason)
	{
		ModelBase<QuestNewModel>.Instance.SetQuestTrackState(questId, bTrack, (ESetTrackReason)reason);
	}
}
