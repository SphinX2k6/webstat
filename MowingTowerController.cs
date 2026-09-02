using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x0200142E RID: 5166
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class MowingTowerController : ActivityControllerBase<MowingTowerController>
{
	// Token: 0x06008FA5 RID: 36773 RVA: 0x0025B5C2 File Offset: 0x002597C2
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x06008FA6 RID: 36774 RVA: 0x0025B5C4 File Offset: 0x002597C4
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_ActivityMowingTower";
	}

	// Token: 0x06008FA7 RID: 36775 RVA: 0x0025B5CB File Offset: 0x002597CB
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new MowingTowerSubView();
	}

	// Token: 0x06008FA8 RID: 36776 RVA: 0x0025B5D2 File Offset: 0x002597D2
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		return new MowingTowerData();
	}

	// Token: 0x06008FA9 RID: 36777 RVA: 0x0025B5D9 File Offset: 0x002597D9
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x06008FAA RID: 36778 RVA: 0x0025B5DC File Offset: 0x002597DC
	protected override bool OnInit()
	{
		Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.MowingTowerMainView, new Func<EUiViewName, object, bool>(this.CheckCanOpen), "MowingTowerController.CheckCanOpen");
		return true;
	}

	// Token: 0x06008FAB RID: 36779 RVA: 0x0025B5FF File Offset: 0x002597FF
	protected override bool OnClear()
	{
		Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.MowingTowerMainView, new Func<EUiViewName, object, bool>(this.CheckCanOpen));
		return true;
	}

	// Token: 0x06008FAC RID: 36780 RVA: 0x0025B620 File Offset: 0x00259820
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<MowTowerResultNotify>(ENotifyMessageId.MowTowerResultNotify, new Action<MowTowerResultNotify, Net.CallbackStatus>(this.OnChallengeEndNotify));
		Singleton<Net>.Instance.Register<MowTowerLevelsInfoUpdateNotify>(ENotifyMessageId.MowTowerLevelsInfoUpdateNotify, new Action<MowTowerLevelsInfoUpdateNotify, Net.CallbackStatus>(this.OnMowingTowerLevelInfoNotify));
		Singleton<Net>.Instance.Register<MowTowerFirstScoreNotify>(ENotifyMessageId.MowTowerFirstScoreNotify, new Action<MowTowerFirstScoreNotify, Net.CallbackStatus>(this.OnMowTowerFirstScoreNotify));
	}

	// Token: 0x06008FAD RID: 36781 RVA: 0x0025B681 File Offset: 0x00259881
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MowTowerResultNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MowTowerLevelsInfoUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MowTowerFirstScoreNotify);
	}

	// Token: 0x06008FAE RID: 36782 RVA: 0x0025B6B3 File Offset: 0x002598B3
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.LeaveInstanceDungeonConfirm, new Action(this.OnLeaveInstanceDungeonConfirm));
	}

	// Token: 0x06008FAF RID: 36783 RVA: 0x0025B6D1 File Offset: 0x002598D1
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.LeaveInstanceDungeonConfirm, new Action(this.OnLeaveInstanceDungeonConfirm));
	}

	// Token: 0x06008FB0 RID: 36784 RVA: 0x0025B6F0 File Offset: 0x002598F0
	private void OnLeaveInstanceDungeonConfirm()
	{
		int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
		InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
		if (config != null && config.Value.InstSubType == 24)
		{
			ControllerBase<MowingTowerController>.Instance.RequestSettlement();
		}
	}

	// Token: 0x06008FB1 RID: 36785 RVA: 0x0025B73C File Offset: 0x0025993C
	private void OnMowingTowerLevelInfoNotify(MowTowerLevelsInfoUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		int activityId = ConfigBase<MowingTowerConfig>.Instance.GetBossMowingTowerConfigById(notify.MowTowerLevelsInfos[0].LevelsId).Value.ActivityId;
		MowingTowerData mowingTowerData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as MowingTowerData;
		if (mowingTowerData != null)
		{
			mowingTowerData.PhraseLevelInfo(notify.MowTowerLevelsInfos.ToList<MowTowerLevelsInfo>());
			mowingTowerData.PhraseRewardInfo(notify.MowTowerLevelsInfos.ToList<MowTowerLevelsInfo>());
			mowingTowerData.CheckIfNewMowingTowerOpen();
			Singleton<EventSystem>.Instance.Emit(EEventName.RefreshMowingTowerData);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshMowingTowerRewardRedDot, activityId);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityId);
		}
	}

	// Token: 0x06008FB2 RID: 36786 RVA: 0x0025B7E3 File Offset: 0x002599E3
	protected void OnMowTowerFirstScoreNotify(MowTowerFirstScoreNotify _1, [Nullable(2)] Net.CallbackStatus _2)
	{
	}

	// Token: 0x06008FB3 RID: 36787 RVA: 0x0025B7E8 File Offset: 0x002599E8
	private void OnChallengeEndNotify(MowTowerResultNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		bool isSuccess = true;
		RewardData<IExploreRewardInfo> rewardData = this.CreateExploreData(3016, isSuccess, null, notify);
		MowTowerLevelsRe? mowTowerLevelsRe;
		bool? flag = (ConfigBase<MowingTowerConfig>.Instance.GetBossMowingTowerConfigById(notify.LevelsId) != null) ? new bool?(mowTowerLevelsRe.GetValueOrDefault().IsInfinite) : null;
		List<IRewardExploreScoreBelongHalfAreaItem> list = new List<IRewardExploreScoreBelongHalfAreaItem>();
		RewardExploreScoreBelongHalfAreaItem item = new RewardExploreScoreBelongHalfAreaItem
		{
			Target = notify.FirstKilMonsterScore.ToString(),
			DescriptionTextId = "BossRushMonsterScoreTips",
			Belong = ETeamBelong.FirstPart
		};
		list.Add(item);
		bool? flag3;
		bool? flag2 = flag3 = flag;
		bool flag4 = false;
		if (flag3.GetValueOrDefault() == flag4 & flag3 != null)
		{
			RewardExploreScoreBelongHalfAreaItem item2 = new RewardExploreScoreBelongHalfAreaItem
			{
				Target = notify.FirstTimerScore.ToString(),
				DescriptionTextId = "BossRushTimeScoreTips",
				Belong = ETeamBelong.FirstPart
			};
			list.Add(item2);
		}
		RewardExploreScoreBelongHalfAreaItem item3 = new RewardExploreScoreBelongHalfAreaItem
		{
			Target = notify.SecondKilMonsterScore.ToString(),
			DescriptionTextId = "BossRushMonsterScoreTips",
			Belong = ETeamBelong.LowPart
		};
		list.Add(item3);
		flag3 = flag2;
		flag4 = false;
		if (flag3.GetValueOrDefault() == flag4 & flag3 != null)
		{
			RewardExploreScoreBelongHalfAreaItem item4 = new RewardExploreScoreBelongHalfAreaItem
			{
				Target = notify.SecondTimerScore.ToString(),
				DescriptionTextId = "BossRushTimeScoreTips",
				Belong = ETeamBelong.LowPart
			};
			list.Add(item4);
		}
		int num = notify.FirstKilMonsterScore + notify.FirstTimerScore + notify.SecondKilMonsterScore + notify.SecondTimerScore;
		bool ifNewRecord = num > notify.HighScore;
		RewardExploreScoreBelongHalfArea halfAreaData = new RewardExploreScoreBelongHalfArea
		{
			ItemList = list,
			IfNewRecord = ifNewRecord,
			FullScore = num
		};
		rewardData.SetHalfAreaData(halfAreaData);
		ControllerBase<ItemRewardController>.Instance.Open<IExploreRewardInfo>(rewardData, null);
	}

	// Token: 0x06008FB4 RID: 36788 RVA: 0x0025B9B0 File Offset: 0x00259BB0
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	private RewardData<IExploreRewardInfo> CreateExploreData(int configId, bool isSuccess, Action onCloseCallback, MowTowerResultNotify notify)
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
			ControllerBase<MowingTowerController>.Instance.OpenDefaultMowingTowerView().ContinueWith(delegate(bool isSuccess)
			{
				if (!isSuccess)
				{
					ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon();
				}
			});
		};
		list2.Add(rewardExploreConfirmButtonData);
		bool flag = notify.HighScore > 0;
		list.Add(new RewardExploreConfirmButtonData
		{
			ButtonTextId = "Text_ButtonTextChallengeOneMore_Text",
			DescriptionTextId = (flag ? "BossRushCurrentHighScore" : null),
			DescriptionArgs = new List<object>
			{
				notify.HighScore
			},
			IsTimeDownCloseView = false,
			IsClickedCloseView = false,
			OnClickedCallback = delegate(int _)
			{
				int activityId = ConfigBase<MowingTowerConfig>.Instance.GetBossMowingTowerConfigById(notify.LevelsId).Value.ActivityId;
				MowingTowerData mowingTowerData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as MowingTowerData;
				if (mowingTowerData == null)
				{
					return;
				}
				MowingTowerLevelDetailInfo mowingTowerLevelDetailInfoById = mowingTowerData.GetMowingTowerLevelDetailInfoById(notify.LevelsId);
				if (mowingTowerLevelDetailInfoById == null)
				{
					return;
				}
				ControllerBase<MowingTowerController>.Instance.RequestStartMowingTowerByTeamData(mowingTowerLevelDetailInfoById.ConvertToTeamInfo());
			}
		});
		ModelBase<ItemRewardModel>.Instance.ClearCurrentRewardData();
		return ModelBase<ItemRewardModel>.Instance.RefreshExploreRewardDataFromConfig(configId, isSuccess, null, null, null, list, null, null, onCloseCallback, null, null, null, null, null, null, null);
	}

	// Token: 0x06008FB5 RID: 36789 RVA: 0x0025BACC File Offset: 0x00259CCC
	public void RequestStartMowingTowerByTeamData(MowingTowerTeamInfo data)
	{
		List<BuffSelection> list = new List<BuffSelection>();
		foreach (MowingTowerBuffInfo mowingTowerBuffInfo in data.GetPrepareSelectBuff())
		{
			BuffSelection buffSelection = BuffSelection.Create();
			buffSelection.BuffId = mowingTowerBuffInfo.BuffId;
			buffSelection.Slot = mowingTowerBuffInfo.Slot;
			list.Add(buffSelection);
		}
		ValueTuple<List<int>, List<int>> currentTeamMembers = data.GetCurrentTeamMembers();
		int[] firstPartRole = currentTeamMembers.Item1.ToArray();
		int[] lowPartRole = currentTeamMembers.Item2.ToArray();
		int activityId = data.ActivityId;
		ControllerBase<MowingTowerController>.Instance.RequestStartMowingTower(activityId, data.GetCurrentSelectLevel().GetInstanceDungeonId(), data.GetCurrentSelectLevel().GetId(), list.ToArray(), firstPartRole, lowPartRole);
	}

	// Token: 0x06008FB6 RID: 36790 RVA: 0x0025BB98 File Offset: 0x00259D98
	public void RequestStartMowingTower(int id, int instanceDungeonId, int configId, BuffSelection[] buff, int[] firstPartRole, int[] lowPartRole)
	{
		if (this.LastRequestMowingTowerTime != 0f && Singleton<Time>.Instance.Now - (double)this.LastRequestMowingTowerTime <= 1000.0)
		{
			return;
		}
		this.LastRequestMowingTowerTime = (float)Singleton<Time>.Instance.Now;
		List<int> list = new List<int>();
		foreach (BuffSelection buffSelection in buff)
		{
			if (buffSelection.BuffId == 0)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ErrorCode_2500057_Text", Array.Empty<object>());
				return;
			}
			list.Add(buffSelection.BuffId);
		}
		List<int> list2 = new List<int>();
		foreach (int num in lowPartRole)
		{
			if (num != 0)
			{
				list2.Add(num);
			}
		}
		MowTowerCtx mowTowerCtx = MowTowerCtx.Create();
		mowTowerCtx.SelectBuff.AddRange(list);
		mowTowerCtx.LevelsId = configId;
		mowTowerCtx.SecondRoles.AddRange(list2);
		ModelBase<InstanceDungeonModel>.Instance.InstanceEnterContentText.MowTowerCtx = mowTowerCtx;
		ControllerBase<InstanceDungeonController>.Instance.PrewarTeamFightRequest(instanceDungeonId, firstPartRole.ToList<int>(), 0, 0, null, null);
	}

	// Token: 0x06008FB7 RID: 36791 RVA: 0x0025BCAC File Offset: 0x00259EAC
	public void RequestSettlement()
	{
		MowTowerSettlementRequest message = MowTowerSettlementRequest.Create();
		Singleton<Net>.Instance.Call<MowTowerSettlementResponse>(ERequestMessageId.MowTowerSettlementRequest, message, delegate(MowTowerSettlementResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 20601, null, true, true);
			}
		}, 0);
	}

	// Token: 0x06008FB8 RID: 36792 RVA: 0x0025BCEF File Offset: 0x00259EEF
	public bool CheckCanOpen(EUiViewName _, object _1)
	{
		GameModeModel instance = ModelBase<GameModeModel>.Instance;
		if (instance != null && instance.IsMulti)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("MowingTowerMultiTips", Array.Empty<object>());
			return false;
		}
		return true;
	}

	// Token: 0x06008FB9 RID: 36793 RVA: 0x0025BD1C File Offset: 0x00259F1C
	public void RequestGetMowingTowerLevelReward(int activityId, int configId, int levelId, int index)
	{
		MowTowerLevelsRewardRequest mowTowerLevelsRewardRequest = MowTowerLevelsRewardRequest.Create();
		mowTowerLevelsRewardRequest.RewardId = configId;
		Singleton<Net>.Instance.Call<MowTowerLevelsRewardResponse>(ERequestMessageId.MowTowerLevelsRewardRequest, mowTowerLevelsRewardRequest, delegate(MowTowerLevelsRewardResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 20367, null, true, true);
			}
			MowingTowerData mowingTowerData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as MowingTowerData;
			if (mowingTowerData != null)
			{
				mowingTowerData.SetRewardStateClaimed(levelId, index);
				Singleton<EventSystem>.Instance.Emit(EEventName.RefreshMowingTowerReward);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshMowingTowerRewardRedDot, activityId);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityId);
			}
		}, 0);
	}

	// Token: 0x06008FBA RID: 36794 RVA: 0x0025BD70 File Offset: 0x00259F70
	[NullableContext(0)]
	public UniTask<bool> OpenDefaultMowingTowerView()
	{
		MowingTowerController.<OpenDefaultMowingTowerView>d__24 <OpenDefaultMowingTowerView>d__;
		<OpenDefaultMowingTowerView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<OpenDefaultMowingTowerView>d__.<>1__state = -1;
		<OpenDefaultMowingTowerView>d__.<>t__builder.Start<MowingTowerController.<OpenDefaultMowingTowerView>d__24>(ref <OpenDefaultMowingTowerView>d__);
		return <OpenDefaultMowingTowerView>d__.<>t__builder.Task;
	}

	// Token: 0x06008FBB RID: 36795 RVA: 0x0025BDAC File Offset: 0x00259FAC
	[NullableContext(0)]
	public UniTask<bool> OpenMowingTowerView(int activityId)
	{
		MowingTowerController.<OpenMowingTowerView>d__25 <OpenMowingTowerView>d__;
		<OpenMowingTowerView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<OpenMowingTowerView>d__.activityId = activityId;
		<OpenMowingTowerView>d__.<>1__state = -1;
		<OpenMowingTowerView>d__.<>t__builder.Start<MowingTowerController.<OpenMowingTowerView>d__25>(ref <OpenMowingTowerView>d__);
		return <OpenMowingTowerView>d__.<>t__builder.Task;
	}

	// Token: 0x040042A4 RID: 17060
	private const int SENDCD = 1000;

	// Token: 0x040042A5 RID: 17061
	private const string BUFF_IS_NOT_VAILD = "ErrorCode_2500057_Text";

	// Token: 0x040042A6 RID: 17062
	private float LastRequestMowingTowerTime;
}
