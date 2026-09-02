using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02002ABE RID: 10942
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class SurvivorsActivityController : ActivityControllerBase<SurvivorsActivityController>
{
	// Token: 0x06015E38 RID: 89656 RVA: 0x006143FA File Offset: 0x006125FA
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x06015E39 RID: 89657 RVA: 0x006143FC File Offset: 0x006125FC
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_SurvivorsActivity";
	}

	// Token: 0x06015E3A RID: 89658 RVA: 0x00614403 File Offset: 0x00612603
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new SurvivorsActivitySubView();
	}

	// Token: 0x06015E3B RID: 89659 RVA: 0x0061440A File Offset: 0x0061260A
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		return new global::SurvivorsActivityData();
	}

	// Token: 0x06015E3C RID: 89660 RVA: 0x00614414 File Offset: 0x00612614
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<SurvivorsHandBooskUnlockNotify>(ENotifyMessageId.SurvivorsHandBooskUnlockNotify, new Action<SurvivorsHandBooskUnlockNotify, Net.CallbackStatus>(this.OnSurvivorsHandBookUnlockNotify));
		Singleton<Net>.Instance.Register<SurvivorsTaskDataUpdateNotify>(ENotifyMessageId.SurvivorsTaskDataUpdateNotify, new Action<SurvivorsTaskDataUpdateNotify, Net.CallbackStatus>(this.OnSurvivorsTaskDataUpdateNotify));
		Singleton<Net>.Instance.Register<SurvivorsChallengeInfoUpdateNotify>(ENotifyMessageId.SurvivorsChallengeInfoUpdateNotify, new Action<SurvivorsChallengeInfoUpdateNotify, Net.CallbackStatus>(this.OnSurvivorsChallengeInfoUpdateNotify));
		Singleton<Net>.Instance.Register<SurvivorsTalentUnlockNotify>(ENotifyMessageId.SurvivorsTalentUnlockNotify, new Action<SurvivorsTalentUnlockNotify, Net.CallbackStatus>(this.OnSurvivorsTalentUnlockNotify));
	}

	// Token: 0x06015E3D RID: 89661 RVA: 0x00614494 File Offset: 0x00612694
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SurvivorsHandBooskUnlockNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SurvivorsTaskDataUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SurvivorsChallengeInfoUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SurvivorsTalentUnlockNotify);
	}

	// Token: 0x06015E3E RID: 89662 RVA: 0x006144E1 File Offset: 0x006126E1
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
		Singleton<EventSystem>.Instance.Add(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestStateChange));
	}

	// Token: 0x06015E3F RID: 89663 RVA: 0x0061451B File Offset: 0x0061271B
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestStateChange));
	}

	// Token: 0x06015E40 RID: 89664 RVA: 0x00614558 File Offset: 0x00612758
	private void OnSurvivorsHandBookUnlockNotify(SurvivorsHandBooskUnlockNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		global::SurvivorsActivityData activityData = ModelBase<SurvivorsRogueModel>.Instance.ActivityData;
		if (activityData == null)
		{
			return;
		}
		foreach (int key in notify.UnlockRoleHandBooks)
		{
			activityData.RoleMap[key] = true;
		}
		foreach (int key2 in notify.UnlockWeaponHandBooks)
		{
			activityData.WeaponMap[key2] = true;
		}
		foreach (int key3 in notify.UnlockItemHandBooks)
		{
			activityData.ItemMap[key3] = true;
		}
	}

	// Token: 0x06015E41 RID: 89665 RVA: 0x00614640 File Offset: 0x00612840
	private void OnSurvivorsTaskDataUpdateNotify(SurvivorsTaskDataUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		global::SurvivorsActivityData activityData = ModelBase<SurvivorsRogueModel>.Instance.ActivityData;
		if (activityData == null)
		{
			return;
		}
		if (notify.ActivityTaskData != null)
		{
			foreach (ActivityTask task in notify.ActivityTaskData.ActivityTasks)
			{
				activityData.RefreshRewardTaskData(task);
			}
		}
		if (activityData.GetRewardRedDotState())
		{
			activityData.RefreshActivityRedDot();
		}
	}

	// Token: 0x06015E42 RID: 89666 RVA: 0x006146B8 File Offset: 0x006128B8
	private void OnSurvivorsChallengeInfoUpdateNotify(SurvivorsChallengeInfoUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		global::SurvivorsActivityData activityData = ModelBase<SurvivorsRogueModel>.Instance.ActivityData;
		if (activityData == null)
		{
			return;
		}
		foreach (SurvivorsChallengeInfo survivorsChallengeInfo in notify.SurvivorsChallengeInfos)
		{
			activityData.LevelMap[survivorsChallengeInfo.LevelId] = survivorsChallengeInfo;
		}
		activityData.RefreshActivityRedDot();
	}

	// Token: 0x06015E43 RID: 89667 RVA: 0x00614728 File Offset: 0x00612928
	private void OnSurvivorsTalentUnlockNotify(SurvivorsTalentUnlockNotify data, [Nullable(2)] Net.CallbackStatus status)
	{
		global::SurvivorsActivityData activityData = ModelBase<SurvivorsRogueModel>.Instance.ActivityData;
		if (activityData == null)
		{
			return;
		}
		activityData.RefreshTalentTreeNode(data.SkillId, 0);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.SurvivorsRogueTalentNodeUpdate, data.SkillId);
	}

	// Token: 0x06015E44 RID: 89668 RVA: 0x00614768 File Offset: 0x00612968
	private void OnQuestStateChange(int questId, QuestState state, EQuestStatusUpdateReason reason)
	{
		global::SurvivorsActivityData activityData = ModelBase<SurvivorsRogueModel>.Instance.ActivityData;
		if (activityData == null)
		{
			return;
		}
		activityData.OnQuestStateChange(questId, state);
	}

	// Token: 0x06015E45 RID: 89669 RVA: 0x0061478C File Offset: 0x0061298C
	public void RequestGetRewardTask(int[] taskIdList)
	{
		SurvivorsNormalAwardRequest survivorsNormalAwardRequest = SurvivorsNormalAwardRequest.Create();
		survivorsNormalAwardRequest.Configs.Add(taskIdList);
		Singleton<Net>.Instance.Call<SurvivorsNormalAwardResponse>(ERequestMessageId.SurvivorsNormalAwardRequest, survivorsNormalAwardRequest, delegate(SurvivorsNormalAwardResponse response, Net.CallbackStatus status)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.SurvivorsNormalAwardResponse, null, true, true);
				return;
			}
			global::SurvivorsActivityData activityData = ModelBase<SurvivorsRogueModel>.Instance.ActivityData;
			if (activityData == null)
			{
				return;
			}
			foreach (int rewardTaskDataDone in taskIdList)
			{
				activityData.SetRewardTaskDataDone(rewardTaskDataDone);
			}
			activityData.RefreshActivityRedDot();
		}, 0);
	}

	// Token: 0x06015E46 RID: 89670 RVA: 0x006147DC File Offset: 0x006129DC
	public void RequestGetRewardScore(int[] scoreIdList)
	{
		SurvivorsScoreAwardRequest survivorsScoreAwardRequest = SurvivorsScoreAwardRequest.Create();
		survivorsScoreAwardRequest.Configs.Add(scoreIdList);
		Singleton<Net>.Instance.Call<SurvivorsScoreAwardResponse>(ERequestMessageId.SurvivorsScoreAwardRequest, survivorsScoreAwardRequest, delegate(SurvivorsScoreAwardResponse response, Net.CallbackStatus status)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.SurvivorsScoreAwardResponse, null, true, true);
				return;
			}
			global::SurvivorsActivityData activityData = ModelBase<SurvivorsRogueModel>.Instance.ActivityData;
			if (activityData == null)
			{
				return;
			}
			foreach (int milestoneRewardId in scoreIdList)
			{
				activityData.RefreshGotMilestoneReward(milestoneRewardId);
			}
			activityData.RefreshActivityRedDot();
		}, 0);
	}

	// Token: 0x06015E47 RID: 89671 RVA: 0x0061482C File Offset: 0x00612A2C
	public void SurvivorsTalentLevelUpRequest(int nodeId, Action callback)
	{
		SurvivorsTalentLevelUpRequest survivorsTalentLevelUpRequest = Aki.Protocol.SurvivorsTalentLevelUpRequest.Create();
		survivorsTalentLevelUpRequest.SkillId = nodeId;
		Singleton<Net>.Instance.Call<SurvivorsTalentLevelUpResponse>(ERequestMessageId.SurvivorsTalentLevelUpRequest, survivorsTalentLevelUpRequest, delegate(SurvivorsTalentLevelUpResponse response, Net.CallbackStatus status)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.SurvivorsTalentLevelUpResponse, null, true, true);
				return;
			}
			global::SurvivorsActivityData activityData = ModelBase<SurvivorsRogueModel>.Instance.ActivityData;
			if (activityData == null)
			{
				return;
			}
			activityData.RefreshTalentTreeNode(nodeId, response.Level);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.SurvivorsRogueTalentNodeUpdate, nodeId);
			callback();
		}, 0);
	}

	// Token: 0x06015E48 RID: 89672 RVA: 0x0061487C File Offset: 0x00612A7C
	public void CheckIsActivityClose()
	{
		global::SurvivorsActivityData activityData = ModelBase<SurvivorsRogueModel>.Instance.ActivityData;
		if (activityData == null)
		{
			return;
		}
		if (activityData.CheckIfClose())
		{
			ControllerBase<ActivityController>.Instance.ShowActivityRefreshAndBackToBattleView();
		}
	}

	// Token: 0x06015E49 RID: 89673 RVA: 0x006148AC File Offset: 0x00612AAC
	private void OnCommonItemCountAnyChange(int configId, int count)
	{
		SurvivorsActivityConfig? rogueActivityConfig = ModelBase<SurvivorsRogueModel>.Instance.GetRogueActivityConfig();
		if (rogueActivityConfig == null)
		{
			return;
		}
		if (configId != rogueActivityConfig.Value.ScoreItemId)
		{
			return;
		}
		ModelBase<SurvivorsRogueModel>.Instance.ActivityData.RefreshActivityRedDot();
	}

	// Token: 0x06015E4A RID: 89674 RVA: 0x006148F0 File Offset: 0x00612AF0
	[NullableContext(0)]
	protected override UniTask<bool> OnOpenSubView(EUiViewName viewName, int activityId = 0)
	{
		SurvivorsActivityController.<OnOpenSubView>d__18 <OnOpenSubView>d__;
		<OnOpenSubView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<OnOpenSubView>d__.viewName = viewName;
		<OnOpenSubView>d__.<>1__state = -1;
		<OnOpenSubView>d__.<>t__builder.Start<SurvivorsActivityController.<OnOpenSubView>d__18>(ref <OnOpenSubView>d__);
		return <OnOpenSubView>d__.<>t__builder.Task;
	}

	// Token: 0x06015E4B RID: 89675 RVA: 0x00614934 File Offset: 0x00612B34
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		if (ModelBase<SurvivorsRogueModel>.Instance.ActivityData == null)
		{
			return false;
		}
		foreach (EUiViewName viewName in new EUiViewName[]
		{
			EUiViewName.SurvivorsRogueMainView,
			EUiViewName.SurvivorsTeamEditView,
			EUiViewName.SurvivorsRogueSettleExternalView,
			EUiViewName.SurvivorsTalentTreeView,
			EUiViewName.SurvivorsHandbookView
		})
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(viewName))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06015E4C RID: 89676 RVA: 0x006149B8 File Offset: 0x00612BB8
	public override void OnShowActivityFirstUnlockView(ActivityBaseData data)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SurvivorsRogueActivityUnlockView, null, null);
	}
}
