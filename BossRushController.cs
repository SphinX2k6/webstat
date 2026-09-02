using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.BossRush;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001273 RID: 4723
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class BossRushController : ActivityControllerBase<BossRushController>
{
	// Token: 0x06007E1A RID: 32282 RVA: 0x00214AA1 File Offset: 0x00212CA1
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x06007E1B RID: 32283 RVA: 0x00214AA3 File Offset: 0x00212CA3
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_ActivityBossrush";
	}

	// Token: 0x06007E1C RID: 32284 RVA: 0x00214AAA File Offset: 0x00212CAA
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new BossRushSubView();
	}

	// Token: 0x06007E1D RID: 32285 RVA: 0x00214AB1 File Offset: 0x00212CB1
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		return new BossRushData();
	}

	// Token: 0x06007E1E RID: 32286 RVA: 0x00214AB8 File Offset: 0x00212CB8
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x06007E1F RID: 32287 RVA: 0x00214ABC File Offset: 0x00212CBC
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<BossRushResultNotify>(ENotifyMessageId.BossRushResultNotify, new Action<BossRushResultNotify, Net.CallbackStatus>(this.OnChallengeEndNotify));
		Singleton<Net>.Instance.Register<BossRushLevelInfoNotify>(ENotifyMessageId.BossRushLevelInfoNotify, new Action<BossRushLevelInfoNotify, Net.CallbackStatus>(this.OnBossRushLevelInfoNotify));
		Singleton<Net>.Instance.Register<BossRushFailResultNotify>(ENotifyMessageId.BossRushFailResultNotify, new Action<BossRushFailResultNotify, Net.CallbackStatus>(this.OnBossRushFailNotify));
		Singleton<Net>.Instance.Register<BossRushTaskUpdateNotify>(ENotifyMessageId.BossRushTaskUpdateNotify, new Action<BossRushTaskUpdateNotify, Net.CallbackStatus>(this.OnBossRushTaskUpdateNotify));
		Singleton<Net>.Instance.Register<BossRushSelectBuffNotify>(ENotifyMessageId.BossRushSelectBuffNotify, new Action<BossRushSelectBuffNotify, Net.CallbackStatus>(this.OnBossRushSelectBuffNotify));
	}

	// Token: 0x06007E20 RID: 32288 RVA: 0x00214B58 File Offset: 0x00212D58
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BossRushResultNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BossRushLevelInfoNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BossRushFailResultNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BossRushTaskUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BossRushSelectBuffNotify);
	}

	// Token: 0x06007E21 RID: 32289 RVA: 0x00214BB5 File Offset: 0x00212DB5
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.LeaveInstanceDungeonConfirm, new Action(this.OnLeaveInstanceDungeonConfirm));
		Singleton<EventSystem>.Instance.Add<Aki.Protocol.ErrorCode>(EEventName.EnterInstanceDungeonFail, new Action<Aki.Protocol.ErrorCode>(this.EnterInstanceDungeonFail));
	}

	// Token: 0x06007E22 RID: 32290 RVA: 0x00214BEF File Offset: 0x00212DEF
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.LeaveInstanceDungeonConfirm, new Action(this.OnLeaveInstanceDungeonConfirm));
		Singleton<EventSystem>.Instance.Remove(EEventName.EnterInstanceDungeonFail, new Action<Aki.Protocol.ErrorCode>(this.EnterInstanceDungeonFail));
	}

	// Token: 0x06007E23 RID: 32291 RVA: 0x00214C2C File Offset: 0x00212E2C
	private void OnLeaveInstanceDungeonConfirm()
	{
		int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
		InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
		if (config != null && config.Value.InstSubType == 20)
		{
			ControllerBase<BossRushController>.Instance.RequestSettlement();
		}
	}

	// Token: 0x06007E24 RID: 32292 RVA: 0x00214C76 File Offset: 0x00212E76
	private void EnterInstanceDungeonFail(Aki.Protocol.ErrorCode errorCode)
	{
		if (errorCode == Aki.Protocol.ErrorCode.BossRushActivityBuffSelectionEmpty)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.BossRushBuffTabChange, 0);
		}
		if (errorCode == Aki.Protocol.ErrorCode.BossRushBuffCountLimit)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.BossRushBuffTabChange, 1);
		}
	}

	// Token: 0x06007E25 RID: 32293 RVA: 0x00214CAC File Offset: 0x00212EAC
	private void CheckIfNewBossRushOpen()
	{
		foreach (int id in ModelBase<BossRushModel>.Instance.CurrentOpenBossRushActivityIds)
		{
			BossRushData bossRushData = ModelBase<ActivityModel>.Instance.GetActivityById(id) as BossRushData;
			if (bossRushData != null)
			{
				bossRushData.CheckIfNewBossRushOpen();
			}
		}
	}

	// Token: 0x06007E26 RID: 32294 RVA: 0x00214D18 File Offset: 0x00212F18
	private void OnBossRushLevelInfoNotify(BossRushLevelInfoNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		BossRushData bossRushData = ModelBase<ActivityModel>.Instance.GetActivityById(notify.ActivityId) as BossRushData;
		if (bossRushData == null)
		{
			return;
		}
		bossRushData.PhraseLevelInfo(notify.UnlockedBuffIndices.ToArray<int>(), notify.BossRushLevelInfo.ToArray<BossRushLevelData>());
		bossRushData.PhraseRewardInfo(notify.BossRushScoreScoreRewardInfo.ToArray<BossRushScoreRewardData>());
		bossRushData.CheckIfNewBossRushOpen();
		Singleton<EventSystem>.Instance.Emit(EEventName.BossRushDataUpdate);
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.ActivityRewardPopUpView))
		{
			Singleton<EventSystem>.Instance.Emit<IActivityRewardViewData>(EEventName.RefreshCommonActivityRewardPopUpView, bossRushData.GetRewardViewData());
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.BossRefreshBossRushRewardRedDot, notify.ActivityId);
	}

	// Token: 0x06007E27 RID: 32295 RVA: 0x00214DC0 File Offset: 0x00212FC0
	private void OnBossRushSelectBuffNotify(BossRushSelectBuffNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		BossRushData bossRushData = ModelBase<ActivityModel>.Instance.GetActivityById(notify.ActivityId) as BossRushData;
		if (bossRushData == null)
		{
			return;
		}
		bossRushData.SetInsSelectedBuffIdMap(notify.InstId, notify.SelectBuffIndices.ToArray<int>());
	}

	// Token: 0x06007E28 RID: 32296 RVA: 0x00214E00 File Offset: 0x00213000
	public int GetBossRushSelectedBuffId(int instanceId)
	{
		foreach (ActivityBaseData activityBaseData in ModelBase<ActivityModel>.Instance.GetAllActivityMap().Values)
		{
			BossRushData bossRushData = activityBaseData as BossRushData;
			if (bossRushData != null && bossRushData.GetBossRushLevelDetailInfoById(instanceId) != null)
			{
				int[] insSelectedBuffId = bossRushData.GetInsSelectedBuffId(instanceId);
				if (insSelectedBuffId.Length != 0)
				{
					return insSelectedBuffId[0];
				}
			}
		}
		return 0;
	}

	// Token: 0x06007E29 RID: 32297 RVA: 0x00214E7C File Offset: 0x0021307C
	private void OnBossRushTaskUpdateNotify(BossRushTaskUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		List<int> list = new List<int>();
		foreach (ActivityTask activityTask in notify.ActivityTasks)
		{
			int activityId = ConfigBase<BossRushConfig>.Instance.GetBossRushTaskConfig(activityTask.Id).ActivityId;
			BossRushData bossRushData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as BossRushData;
			if (bossRushData != null)
			{
				bossRushData.RefreshSingleTaskData(activityTask);
				if (!list.Contains(activityId))
				{
					list.Add(activityId);
				}
			}
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.BossRushTaskStateChanged);
		Singleton<EventSystem>.Instance.Emit(EEventName.BossRefreshBossRushReward);
		foreach (int p in list)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.BossRefreshBossRushRewardRedDot, p);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, p);
		}
	}

	// Token: 0x06007E2A RID: 32298 RVA: 0x00214F90 File Offset: 0x00213190
	private void OnBossRushFailNotify(BossRushFailResultNotify _1, [Nullable(2)] Net.CallbackStatus _2)
	{
		List<IRewardExploreConfirmButton> list = new List<IRewardExploreConfirmButton>();
		Action<int> onClickedCallback = delegate(int _)
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon();
		};
		list.Add(new RewardExploreConfirmButtonData
		{
			ButtonTextId = "BossRushFailLeave",
			DescriptionTextId = null,
			IsTimeDownCloseView = false,
			IsClickedCloseView = true,
			OnClickedCallback = onClickedCallback
		});
		ModelBase<ItemRewardModel>.Instance.ClearCurrentRewardData();
		RewardData<IExploreRewardInfo> rewardData = ModelBase<ItemRewardModel>.Instance.RefreshExploreRewardDataFromConfig(3015, false, null, null, null, list, null, null, null, null, null, null, null, null, null, null);
		ControllerBase<ItemRewardController>.Instance.Open<IExploreRewardInfo>(rewardData, null);
	}

	// Token: 0x06007E2B RID: 32299 RVA: 0x0021503C File Offset: 0x0021323C
	private unsafe void OnChallengeEndNotify(BossRushResultNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		this.CheckIfNewBossRushOpen();
		bool flag = true;
		RewardData<IExploreRewardInfo> rewardData = this.CreateExploreData(flag ? 3016 : 3015, flag, null, notify);
		ReachTargetData reachTargetData = new ReachTargetData();
		List<IRewardExploreTargetReached> list = new List<IRewardExploreTargetReached>();
		RewardExploreTargetReachedData rewardExploreTargetReachedData = new RewardExploreTargetReachedData();
		int num = 1;
		List<string> list2 = new List<string>(num);
		CollectionsMarshal.SetCount<string>(list2, num);
		Span<string> span = CollectionsMarshal.AsSpan<string>(list2);
		int num2 = 0;
		*span[num2] = notify.KilMonsterScore.ToString();
		rewardExploreTargetReachedData.Target = list2;
		rewardExploreTargetReachedData.DescriptionTextId = "BossRushMonsterScoreTips";
		rewardExploreTargetReachedData.IsReached = false;
		RewardExploreTargetReachedData item = rewardExploreTargetReachedData;
		list.Add(item);
		RewardExploreTargetReachedData rewardExploreTargetReachedData2 = new RewardExploreTargetReachedData();
		num2 = 1;
		List<string> list3 = new List<string>(num2);
		CollectionsMarshal.SetCount<string>(list3, num2);
		span = CollectionsMarshal.AsSpan<string>(list3);
		num = 0;
		*span[num] = notify.TimerScore.ToString();
		rewardExploreTargetReachedData2.Target = list3;
		rewardExploreTargetReachedData2.DescriptionTextId = "BossRushTimeScoreTips";
		rewardExploreTargetReachedData2.IsReached = false;
		RewardExploreTargetReachedData item2 = rewardExploreTargetReachedData2;
		list.Add(item2);
		RewardExploreTargetReachedData rewardExploreTargetReachedData3 = new RewardExploreTargetReachedData();
		num = 1;
		List<string> list4 = new List<string>(num);
		CollectionsMarshal.SetCount<string>(list4, num);
		span = CollectionsMarshal.AsSpan<string>(list4);
		num2 = 0;
		*span[num2] = notify.TechnicalScore.ToString();
		rewardExploreTargetReachedData3.Target = list4;
		rewardExploreTargetReachedData3.DescriptionTextId = "BossRushTechScoreTips";
		rewardExploreTargetReachedData3.IsReached = false;
		RewardExploreTargetReachedData item3 = rewardExploreTargetReachedData3;
		list.Add(item3);
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew("Text_Second_Text", null);
		RewardExploreTargetReachedData rewardExploreTargetReachedData4 = new RewardExploreTargetReachedData();
		num2 = 1;
		List<string> list5 = new List<string>(num2);
		CollectionsMarshal.SetCount<string>(list5, num2);
		span = CollectionsMarshal.AsSpan<string>(list5);
		num = 0;
		*span[num] = notify.LeftTime.ToString() + localTextNew;
		rewardExploreTargetReachedData4.Target = list5;
		rewardExploreTargetReachedData4.DescriptionTextId = "BossRushLeftTimeTips";
		rewardExploreTargetReachedData4.IsReached = false;
		RewardExploreTargetReachedData item4 = rewardExploreTargetReachedData4;
		list.Add(item4);
		reachTargetData.TargetReached = list;
		int num3 = notify.KilMonsterScore + notify.TimerScore + notify.TechnicalScore;
		bool ifNewRecord = num3 > notify.HighScore;
		reachTargetData.IfNewRecord = ifNewRecord;
		reachTargetData.FullScore = num3;
		rewardData.SetScoreReached(reachTargetData);
		ControllerBase<ItemRewardController>.Instance.Open<IExploreRewardInfo>(rewardData, null);
		ControllerBase<TowerController>.Instance.ClearAllHatredInTower();
	}

	// Token: 0x06007E2C RID: 32300 RVA: 0x00215254 File Offset: 0x00213454
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	private unsafe RewardData<IExploreRewardInfo> CreateExploreData(int configId, bool isSuccess, [Nullable(2)] Action onCloseCallback, BossRushResultNotify notify)
	{
		List<IRewardExploreConfirmButton> list = new List<IRewardExploreConfirmButton>();
		List<IRewardExploreConfirmButton> list2 = list;
		RewardExploreConfirmButtonData rewardExploreConfirmButtonData = new RewardExploreConfirmButtonData();
		rewardExploreConfirmButtonData.ButtonTextId = "Text_ButtonTextConfirmResult_Text";
		rewardExploreConfirmButtonData.DescriptionTextId = null;
		rewardExploreConfirmButtonData.IsTimeDownCloseView = true;
		rewardExploreConfirmButtonData.IsClickedCloseView = false;
		rewardExploreConfirmButtonData.OnClickedCallback = delegate(int _)
		{
			ControllerBase<BossRushController>.Instance.OpenDefaultBossRushView();
		};
		list2.Add(rewardExploreConfirmButtonData);
		bool flag = notify.HighScore > 0;
		List<IRewardExploreConfirmButton> list3 = list;
		RewardExploreConfirmButtonData rewardExploreConfirmButtonData2 = new RewardExploreConfirmButtonData();
		rewardExploreConfirmButtonData2.ButtonTextId = "Text_ButtonTextChallengeOneMore_Text";
		rewardExploreConfirmButtonData2.DescriptionTextId = (flag ? "BossRushCurrentHighScore" : null);
		int num = 1;
		List<object> list4 = new List<object>(num);
		CollectionsMarshal.SetCount<object>(list4, num);
		Span<object> span = CollectionsMarshal.AsSpan<object>(list4);
		int index = 0;
		*span[index] = notify.HighScore;
		rewardExploreConfirmButtonData2.DescriptionArgs = list4;
		rewardExploreConfirmButtonData2.IsTimeDownCloseView = false;
		rewardExploreConfirmButtonData2.IsClickedCloseView = false;
		rewardExploreConfirmButtonData2.OnClickedCallback = delegate(int _)
		{
			BossRushData bossRushData = ModelBase<ActivityModel>.Instance.GetActivityById(notify.ActivityId) as BossRushData;
			if (bossRushData == null)
			{
				return;
			}
			BossRushLevelDetailInfo bossRushLevelDetailInfoById = bossRushData.GetBossRushLevelDetailInfoById(notify.InstId);
			if (bossRushLevelDetailInfoById == null)
			{
				return;
			}
			ControllerBase<BossRushController>.Instance.RequestStartBossRushByTeamData(bossRushLevelDetailInfoById.ConvertToTeamInfo());
		};
		list3.Add(rewardExploreConfirmButtonData2);
		ModelBase<ItemRewardModel>.Instance.ClearCurrentRewardData();
		return ModelBase<ItemRewardModel>.Instance.RefreshExploreRewardDataFromConfig(configId, isSuccess, null, null, null, list, null, null, onCloseCallback, null, null, null, null, null, null, null);
	}

	// Token: 0x06007E2D RID: 32301 RVA: 0x0021538C File Offset: 0x0021358C
	public void RequestStartBossRushByTeamData(BossRushTeamInfo data)
	{
		List<BuffSelection> list = new List<BuffSelection>();
		foreach (BossRushBuffInfo bossRushBuffInfo in data.GetPrepareSelectBuff())
		{
			BuffSelection buffSelection = BuffSelection.Create();
			buffSelection.BuffId = bossRushBuffInfo.BuffId;
			buffSelection.Slot = bossRushBuffInfo.Slot;
			buffSelection.BuffSelectionStatus = bossRushBuffInfo.State;
			list.Add(buffSelection);
		}
		List<int> list2 = new List<int>();
		foreach (BossRushBuffInfo bossRushBuffInfo2 in data.GetPrepareSelectScoreBuff())
		{
			if (bossRushBuffInfo2.BuffId > 0)
			{
				list2.Add(bossRushBuffInfo2.BuffId);
			}
		}
		List<int> list3 = new List<int>();
		foreach (int item in data.GetCurrentTeamMembers())
		{
			list3.Add(item);
		}
		int activityId = data.ActivityId;
		ControllerBase<BossRushController>.Instance.RequestStartBossRush(activityId, data.GetCurrentSelectLevel().GetInstanceDungeonId(), list.ToArray(), list2.ToArray(), list3.ToArray());
	}

	// Token: 0x06007E2E RID: 32302 RVA: 0x002154D4 File Offset: 0x002136D4
	public void RequestBossRushTaskReward(int activityId)
	{
		BossRushBatchClaimRewardRequest bossRushBatchClaimRewardRequest = BossRushBatchClaimRewardRequest.Create();
		bossRushBatchClaimRewardRequest.ActivityId = activityId;
		BossRushData bossRushData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as BossRushData;
		if (bossRushData == null)
		{
			return;
		}
		bossRushBatchClaimRewardRequest.TaskRewardIds.AddRange(bossRushData.GetFinishAndUnclaimedTaskList());
		Singleton<Net>.Instance.Call<BossRushBatchClaimRewardResponse>(ERequestMessageId.BossRushBatchClaimRewardRequest, bossRushBatchClaimRewardRequest, delegate(BossRushBatchClaimRewardResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 28698, null, true, true);
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.BossRefreshBossRushRewardRedDot, activityId);
			Singleton<EventSystem>.Instance.Emit(EEventName.BossRefreshBossRushReward);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityId);
		}, 0);
	}

	// Token: 0x06007E2F RID: 32303 RVA: 0x00215548 File Offset: 0x00213748
	public void RequestStartBossRush(int id, int instanceDungeonId, BuffSelection[] buff, int[] scoreBuff, int[] role)
	{
		if (this.LastRequestBossRushTime != 0f && Singleton<Time>.Instance.Now - (double)this.LastRequestBossRushTime <= 1000.0)
		{
			return;
		}
		this.LastRequestBossRushTime = (float)Singleton<Time>.Instance.Now;
		List<BuffSelection> list = new List<BuffSelection>();
		List<BossRushBuffInfo> currentSelectBuff = ModelBase<BossRushModel>.Instance.GetBossRushTeamInfoByActivityId(id).GetCurrentSelectBuff();
		foreach (BuffSelection buffSelection in buff)
		{
			if (buffSelection.BuffSelectionStatus != BossRushBuffSelectionStatus.BuffEmpty)
			{
				list.Add(buffSelection);
			}
			else
			{
				BuffSelection buffSelection2 = BuffSelection.Create();
				buffSelection2.BuffId = buffSelection.BuffId;
				buffSelection2.Slot = buffSelection.Slot;
				buffSelection2.BuffSelectionStatus = ((buffSelection.BuffId == 0) ? BossRushBuffSelectionStatus.BuffEmpty : BossRushBuffSelectionStatus.BuffSelected);
				list.Add(buffSelection2);
			}
		}
		foreach (BossRushBuffInfo bossRushBuffInfo in currentSelectBuff)
		{
			if (bossRushBuffInfo.State == BossRushBuffSelectionStatus.BuffInactive)
			{
				BuffSelection buffSelection3 = BuffSelection.Create();
				buffSelection3.BuffId = bossRushBuffInfo.BuffId;
				buffSelection3.Slot = bossRushBuffInfo.Slot;
				buffSelection3.BuffSelectionStatus = BossRushBuffSelectionStatus.BuffInactive;
				list.Add(buffSelection3);
			}
		}
		BossRushActivity? bossRushByActivityIdAndInstanceId = ConfigBase<BossRushConfig>.Instance.GetBossRushByActivityIdAndInstanceId(id, instanceDungeonId);
		BossRushCtx bossRushCtx = BossRushCtx.Create();
		bossRushCtx.ActivityId = id;
		bossRushCtx.Id = ((bossRushByActivityIdAndInstanceId != null) ? bossRushByActivityIdAndInstanceId.GetValueOrDefault().Id : 0);
		bossRushCtx.BuffSelections.AddRange(list);
		bossRushCtx.ScoreBuff.AddRange(scoreBuff);
		ModelBase<InstanceDungeonModel>.Instance.InstanceEnterContentText.BossRushCtx = bossRushCtx;
		ControllerBase<InstanceDungeonController>.Instance.PrewarTeamFightRequest(instanceDungeonId, role.ToList<int>(), 0, 0, null, null);
	}

	// Token: 0x06007E30 RID: 32304 RVA: 0x0021570C File Offset: 0x0021390C
	public void RequestSettlement()
	{
		BossRushSettlementRequest message = BossRushSettlementRequest.Create();
		Singleton<Net>.Instance.Call<BossRushSettlementResponse>(ERequestMessageId.BossRushSettlementRequest, message, delegate(BossRushSettlementResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 15622, null, true, true);
			}
		}, 0);
	}

	// Token: 0x06007E31 RID: 32305 RVA: 0x00215750 File Offset: 0x00213950
	public void RequestGetBossRushReward(int activityId, int rewardId, BossRushRewardType type)
	{
		BossRushClaimRewardRequest bossRushClaimRewardRequest = BossRushClaimRewardRequest.Create();
		bossRushClaimRewardRequest.ActivityId = activityId;
		bossRushClaimRewardRequest.RewardId = rewardId;
		bossRushClaimRewardRequest.RewardType = type;
		Singleton<Net>.Instance.Call<BossRushClaimRewardResponse>(ERequestMessageId.BossRushClaimRewardRequest, bossRushClaimRewardRequest, delegate(BossRushClaimRewardResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 18379, null, true, true);
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.BossRefreshBossRushRewardRedDot, activityId);
			Singleton<EventSystem>.Instance.Emit(EEventName.BossRefreshBossRushReward);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityId);
		}, 0);
	}

	// Token: 0x06007E32 RID: 32306 RVA: 0x002157A8 File Offset: 0x002139A8
	public void RequestGetBossRushLevelReward(int activityId, int configId, int levelId, int index)
	{
		BossRushLevelScoreRewardRequest bossRushLevelScoreRewardRequest = BossRushLevelScoreRewardRequest.Create();
		bossRushLevelScoreRewardRequest.BossRushActivityId = configId;
		bossRushLevelScoreRewardRequest.Index = index;
		Singleton<Net>.Instance.Call<BossRushLevelScoreRewardResponse>(ERequestMessageId.BossRushLevelScoreRewardRequest, bossRushLevelScoreRewardRequest, delegate(BossRushLevelScoreRewardResponse response, Net.CallbackStatus _)
		{
			if (response.Error != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.Error, 18379, null, true, true);
			}
			BossRushData bossRushData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as BossRushData;
			if (bossRushData == null)
			{
				return;
			}
			bossRushData.SetRewardStateClaimed(levelId, index);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.BossRefreshBossRushRewardRedDot, activityId);
			Singleton<EventSystem>.Instance.Emit(EEventName.BossRefreshBossRushReward);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityId);
		}, 0);
	}

	// Token: 0x06007E33 RID: 32307 RVA: 0x00215808 File Offset: 0x00213A08
	[NullableContext(0)]
	public UniTask<bool> OpenDefaultBossRushView()
	{
		BossRushController.<OpenDefaultBossRushView>d__27 <OpenDefaultBossRushView>d__;
		<OpenDefaultBossRushView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<OpenDefaultBossRushView>d__.<>1__state = -1;
		<OpenDefaultBossRushView>d__.<>t__builder.Start<BossRushController.<OpenDefaultBossRushView>d__27>(ref <OpenDefaultBossRushView>d__);
		return <OpenDefaultBossRushView>d__.<>t__builder.Task;
	}

	// Token: 0x06007E34 RID: 32308 RVA: 0x00215844 File Offset: 0x00213A44
	[NullableContext(0)]
	public UniTask<bool> OpenBossRushView(int activityId)
	{
		BossRushController.<OpenBossRushView>d__28 <OpenBossRushView>d__;
		<OpenBossRushView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<OpenBossRushView>d__.activityId = activityId;
		<OpenBossRushView>d__.<>1__state = -1;
		<OpenBossRushView>d__.<>t__builder.Start<BossRushController.<OpenBossRushView>d__28>(ref <OpenBossRushView>d__);
		return <OpenBossRushView>d__.<>t__builder.Task;
	}

	// Token: 0x06007E35 RID: 32309 RVA: 0x00215888 File Offset: 0x00213A88
	[NullableContext(0)]
	public UniTask<bool> RefreshBossRushBuffInGame()
	{
		BossRushController.<RefreshBossRushBuffInGame>d__29 <RefreshBossRushBuffInGame>d__;
		<RefreshBossRushBuffInGame>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RefreshBossRushBuffInGame>d__.<>1__state = -1;
		<RefreshBossRushBuffInGame>d__.<>t__builder.Start<BossRushController.<RefreshBossRushBuffInGame>d__29>(ref <RefreshBossRushBuffInGame>d__);
		return <RefreshBossRushBuffInGame>d__.<>t__builder.Task;
	}

	// Token: 0x06007E36 RID: 32310 RVA: 0x002158C4 File Offset: 0x00213AC4
	[NullableContext(0)]
	public UniTask<bool> RequestBossRushChooseBuffInGame(int index)
	{
		BossRushController.<RequestBossRushChooseBuffInGame>d__30 <RequestBossRushChooseBuffInGame>d__;
		<RequestBossRushChooseBuffInGame>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestBossRushChooseBuffInGame>d__.index = index;
		<RequestBossRushChooseBuffInGame>d__.<>1__state = -1;
		<RequestBossRushChooseBuffInGame>d__.<>t__builder.Start<BossRushController.<RequestBossRushChooseBuffInGame>d__30>(ref <RequestBossRushChooseBuffInGame>d__);
		return <RequestBossRushChooseBuffInGame>d__.<>t__builder.Task;
	}

	// Token: 0x04003C83 RID: 15491
	private const int SENDCD = 1000;

	// Token: 0x04003C84 RID: 15492
	private float LastRequestBossRushTime;
}
