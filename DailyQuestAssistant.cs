using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;

// Token: 0x0200263B RID: 9787
[NullableContext(1)]
[Nullable(0)]
public class DailyQuestAssistant : ControllerAssistantBase
{
	// Token: 0x06013447 RID: 78919 RVA: 0x0055A88D File Offset: 0x00558A8D
	protected override void OnDestroy()
	{
	}

	// Token: 0x06013448 RID: 78920 RVA: 0x0055A890 File Offset: 0x00558A90
	public override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDoneAndCloseLoading));
		Singleton<EventSystem>.Instance.Add(EEventName.OnEnterDailyQuestNotifyRange, new Action<int, int, EEnterDailyQuestRangeParam>(this.OnEnterDailyQuestRange));
		Singleton<EventSystem>.Instance.Add(EEventName.OnAddNewQuest, new Action<TQuest>(this.OnAddNewQuest));
		Singleton<EventSystem>.Instance.Add<int, QuestState, EQuestStatusUpdateReason>(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestStateChange));
	}

	// Token: 0x06013449 RID: 78921 RVA: 0x0055A910 File Offset: 0x00558B10
	public override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDoneAndCloseLoading));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnEnterDailyQuestNotifyRange, new Action<int, int, EEnterDailyQuestRangeParam>(this.OnEnterDailyQuestRange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAddNewQuest, new Action<TQuest>(this.OnAddNewQuest));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestStateChange));
	}

	// Token: 0x0601344A RID: 78922 RVA: 0x0055A990 File Offset: 0x00558B90
	private void OnWorldDoneAndCloseLoading()
	{
		if (!ModelBase<LoginModel>.Instance.GetTodayFirstTimeLogin() || this.WorldDoneOnce)
		{
			return;
		}
		this.WorldDoneOnce = true;
		foreach (int pbDataId in ModelBase<DailyTaskModel>.Instance.GetDailyTaskCorrelativeEntities())
		{
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(pbDataId);
			if (this.DetectPlayerDistanceSquared(entityByPbDataId))
			{
				return;
			}
		}
		foreach (DailyQuest dailyQuest in ModelBase<DailyTaskModel>.Instance.GetAllDailyQuest().Values)
		{
			BehaviorNodeBase currentActiveChildQuestNode = dailyQuest.GetCurrentActiveChildQuestNode();
			if (currentActiveChildQuestNode != null)
			{
				ModelBase<GeneralLogicTreeModel>.Instance.SaveUpdateInfo(dailyQuest.TreeId.GetValueOrDefault(), currentActiveChildQuestNode.NodeId);
			}
		}
	}

	// Token: 0x0601344B RID: 78923 RVA: 0x0055AA8C File Offset: 0x00558C8C
	private void OnEnterDailyQuestRange(int questId, int nodeId, EEnterDailyQuestRangeParam type)
	{
		global::Quest quest = ModelBase<QuestNewModel>.Instance.GetQuest(questId);
		if (quest != null && quest.Type == EQuest.Daily)
		{
			DailyQuest dailyQuest = quest as DailyQuest;
			if (dailyQuest != null)
			{
				if (dailyQuest.OnlineType == EQuestOnlineType.SingleHangUpOnline && ModelBase<GameModeModel>.Instance.IsMulti)
				{
					return;
				}
				if (type == EEnterDailyQuestRangeParam.Enter)
				{
					if (dailyQuest.IsRangeTrack(nodeId))
					{
						dailyQuest.StartTextExpress(ETreeTextExpressReason.InRange);
					}
					else
					{
						this.TryShowQuestUpdateTips(dailyQuest);
					}
					this.TryShowDailyQuestPrompt(dailyQuest);
					dailyQuest.TriggerQuestTips = true;
					return;
				}
				if (type != EEnterDailyQuestRangeParam.Leave)
				{
					return;
				}
				if (dailyQuest.IsRangeTrack(nodeId))
				{
					dailyQuest.EndTextExpress(ETreeTextExpressReason.InRange);
				}
				return;
			}
		}
	}

	// Token: 0x0601344C RID: 78924 RVA: 0x0055AB11 File Offset: 0x00558D11
	private void OnAddNewQuest(TQuest quest)
	{
		if (quest.Type != EQuest.Daily)
		{
			return;
		}
		ModelBase<DailyTaskModel>.Instance.AddDailyQuest(quest as DailyQuest);
	}

	// Token: 0x0601344D RID: 78925 RVA: 0x0055AB2D File Offset: 0x00558D2D
	private void OnQuestStateChange(int questId, QuestState state, EQuestStatusUpdateReason _)
	{
		if (state - QuestState.Finish <= 1)
		{
			ModelBase<DailyTaskModel>.Instance.RemoveDailyQuest(questId);
		}
	}

	// Token: 0x0601344E RID: 78926 RVA: 0x0055AB40 File Offset: 0x00558D40
	private bool DetectPlayerDistanceSquared(EntityHandle handle)
	{
		if (handle == null)
		{
			return false;
		}
		BaseActorComponent component = handle.Entity.GetComponent<BaseActorComponent>();
		if (component == null)
		{
			return false;
		}
		double num = global::Vector.Distance(component.ActorLocationProxy, Singleton<GeneralLogicTreeUtil>.Instance.GetPlayerLocation());
		int? intConfig = ConfigCommonParamById.GetIntConfig("dailyquest_trackinfo_mini");
		double? num2 = (intConfig != null) ? new double?((double)intConfig.GetValueOrDefault()) : null;
		return num < num2.GetValueOrDefault() & num2 != null;
	}

	// Token: 0x0601344F RID: 78927 RVA: 0x0055ABB8 File Offset: 0x00558DB8
	private void TryShowDailyQuestPrompt(DailyQuest quest)
	{
		if (quest == null || quest.Type != EQuest.Daily || quest.TriggerQuestTips)
		{
			return;
		}
		string questName = ModelBase<QuestNewModel>.Instance.GetQuestName(quest.Id);
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(ConfigBase<TextConfig>.Instance.GetTextContentIdById("TriggerMission"), null);
		ControllerBase<GenericPromptController>.Instance.ShowPromptByItsType<object>(EPromptSubViewType.TaskBeginPrompt, null, null, new <>z__ReadOnlySingleElementList<object>(questName), new <>z__ReadOnlySingleElementList<object>(localTextNew), null, null, null, null, false, null);
	}

	// Token: 0x06013450 RID: 78928 RVA: 0x0055AC30 File Offset: 0x00558E30
	private void TryShowQuestUpdateTips(DailyQuest quest)
	{
		if (quest == null || quest.Type != EQuest.Daily || quest.TriggerQuestTips)
		{
			return;
		}
		ModelBase<GeneralLogicTreeModel>.Instance.SaveUpdateInfo(quest.TreeId.GetValueOrDefault(), quest.GetCurrentActiveChildQuestNode().NodeId);
	}

	// Token: 0x06013451 RID: 78929 RVA: 0x0055AC78 File Offset: 0x00558E78
	public void CreateMarksOnWakeUp()
	{
		Dictionary<int, DailyQuest> allDailyQuest = ModelBase<DailyTaskModel>.Instance.GetAllDailyQuest();
		if (allDailyQuest == null)
		{
			return;
		}
		foreach (DailyQuest dailyQuest in allDailyQuest.Values)
		{
			dailyQuest.CreateMapMarks();
		}
	}

	// Token: 0x04009679 RID: 38521
	private bool WorldDoneOnce;
}
