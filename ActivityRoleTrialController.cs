using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.CyberPunk;
using CSharpScript.Game.Module.Activity.ActivityContent.RoleTrial;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.ItemReward;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x0200157E RID: 5502
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ActivityRoleTrialController : ActivityControllerBase<ActivityRoleTrialController>
{
	// Token: 0x06009A83 RID: 39555 RVA: 0x0028751F File Offset: 0x0028571F
	protected override bool OnClear()
	{
		this.ClearAllRefreshTimer();
		return base.OnClear();
	}

	// Token: 0x06009A84 RID: 39556 RVA: 0x0028752D File Offset: 0x0028572D
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<RoleTrialSettleNotify>(ENotifyMessageId.RoleTrialSettleNotify, new Action<RoleTrialSettleNotify, Net.CallbackStatus>(this.OnRoleTrialSettleNotify));
	}

	// Token: 0x06009A85 RID: 39557 RVA: 0x0028754B File Offset: 0x0028574B
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoleTrialSettleNotify);
	}

	// Token: 0x06009A86 RID: 39558 RVA: 0x00287560 File Offset: 0x00285760
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RoleSystemChangeRole, new Action<int>(this.OnRoleSystemChangeRole));
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Add(EEventName.CrossDayZone, new Action(this.OnCrossDayZone));
	}

	// Token: 0x06009A87 RID: 39559 RVA: 0x002875C4 File Offset: 0x002857C4
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RoleSystemChangeRole, new Action<int>(this.OnRoleSystemChangeRole));
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Remove(EEventName.CrossDayZone, new Action(this.OnCrossDayZone));
	}

	// Token: 0x06009A88 RID: 39560 RVA: 0x00287628 File Offset: 0x00285828
	private void OnRoleSystemChangeRole(int trialRoleId)
	{
		if (trialRoleId.Equals(0))
		{
			return;
		}
		foreach (int id in this.CurrentActivityIdList)
		{
			ActivityRoleTrialData activityRoleTrialData = ModelBase<ActivityModel>.Instance.GetActivityById(id) as ActivityRoleTrialData;
			if (activityRoleTrialData != null && activityRoleTrialData.IsRolePreviewOn())
			{
				int num;
				activityRoleTrialData.TrialToIdMap.TryGetValue(trialRoleId, out num);
				if (num != 0)
				{
					activityRoleTrialData.CurrentRoleId = num;
				}
			}
		}
	}

	// Token: 0x06009A89 RID: 39561 RVA: 0x002876B4 File Offset: 0x002858B4
	private void OnWorldDone()
	{
		foreach (int num in this.CurrentActivityIdList)
		{
			ActivityRoleTrialData activityRoleTrialData = ModelBase<ActivityModel>.Instance.GetActivityById(num) as ActivityRoleTrialData;
			if (activityRoleTrialData != null && activityRoleTrialData.IsRoleInstanceOn() && !ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				IReadOnlyList<EdgeRunnerTrial> trialRoleListByTrialActivityId = ConfigBase<CyberPunkConfig>.Instance.GetTrialRoleListByTrialActivityId(num);
				if (trialRoleListByTrialActivityId == null || trialRoleListByTrialActivityId.Count <= 0)
				{
					ControllerBase<ActivityController>.Instance.OpenActivityById(num, EActivityViewOpenType.Other, null, null);
					break;
				}
			}
		}
	}

	// Token: 0x06009A8A RID: 39562 RVA: 0x00287754 File Offset: 0x00285954
	private void OnCrossDayZone()
	{
		foreach (int id in this.CurrentActivityIdList)
		{
			ActivityRoleTrialData activityRoleTrialData = ModelBase<ActivityModel>.Instance.GetActivityById(id) as ActivityRoleTrialData;
			if (activityRoleTrialData != null)
			{
				this.TryRefreshIsNewMap(activityRoleTrialData);
			}
		}
	}

	// Token: 0x06009A8B RID: 39563 RVA: 0x002877BC File Offset: 0x002859BC
	public void TryRefreshIsNewMap(ActivityRoleTrialData data)
	{
		this.ClearSingleRefreshTimer(data.Id);
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		double nearestTime = double.MaxValue;
		foreach (Tuple<double, double> tuple in data.RoleBeginEndTimeMap.Values)
		{
			double item = tuple.Item1;
			double item2 = tuple.Item2;
			double num = 0.0;
			if (serverTime < item)
			{
				num = item;
			}
			else if (serverTime < item2)
			{
				num = item2;
			}
			if (Math.Floor(serverTime / (double)Singleton<TimeUtil>.Instance.OneDaySeconds) == Math.Floor(num / (double)Singleton<TimeUtil>.Instance.OneDaySeconds) && num < nearestTime)
			{
				nearestTime = num;
			}
		}
		if (nearestTime < 9.223372036854776E+18)
		{
			this.RefreshTimerHandle[data.Id] = TimerSystem.RealTimeInstance.Forever(delegate(float _)
			{
				this.OnTimerRefresh(data, nearestTime);
			}, (float)Singleton<TimeUtil>.Instance.InverseMillisecond, 1f, null, null, true);
		}
	}

	// Token: 0x06009A8C RID: 39564 RVA: 0x00287908 File Offset: 0x00285B08
	private void OnTimerRefresh(ActivityRoleTrialData data, double refreshTime)
	{
		if (Singleton<TimeUtil>.Instance.GetServerTime() >= refreshTime)
		{
			data.RefreshExData();
			data.RefreshIsNewMap();
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnTrialRoleDataChanged, data.Id);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, data.Id);
			this.ClearSingleRefreshTimer(data.Id);
			this.TryRefreshIsNewMap(data);
		}
	}

	// Token: 0x06009A8D RID: 39565 RVA: 0x00287970 File Offset: 0x00285B70
	private void ClearSingleRefreshTimer(int activityId)
	{
		TimerHandle timerHandle;
		if (this.RefreshTimerHandle.Count > 0 && this.RefreshTimerHandle.TryGetValue(activityId, out timerHandle) && timerHandle != null && TimerSystem.RealTimeInstance.Has(timerHandle))
		{
			timerHandle.Remove();
			this.RefreshTimerHandle.Remove(activityId);
		}
	}

	// Token: 0x06009A8E RID: 39566 RVA: 0x002879C0 File Offset: 0x00285BC0
	private void ClearAllRefreshTimer()
	{
		if (this.RefreshTimerHandle.Count > 0)
		{
			foreach (TimerHandle timerHandle in this.RefreshTimerHandle.Values)
			{
				if (timerHandle != null && TimerSystem.RealTimeInstance.Has(timerHandle))
				{
					timerHandle.Remove();
				}
			}
			this.RefreshTimerHandle.Clear();
		}
	}

	// Token: 0x06009A8F RID: 39567 RVA: 0x00287A44 File Offset: 0x00285C44
	public List<ActivityRoleTrialData> GetCurrentActivityDataList()
	{
		return ModelBase<ActivityModel>.Instance.GetCurrentActivitiesByType(8).Cast<ActivityRoleTrialData>().ToList<ActivityRoleTrialData>();
	}

	// Token: 0x06009A90 RID: 39568 RVA: 0x00287A5B File Offset: 0x00285C5B
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_ActivityRoleTrial";
	}

	// Token: 0x06009A91 RID: 39569 RVA: 0x00287A62 File Offset: 0x00285C62
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new ActivitySubViewRoleTrial();
	}

	// Token: 0x06009A92 RID: 39570 RVA: 0x00287A69 File Offset: 0x00285C69
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		return new ActivityRoleTrialData();
	}

	// Token: 0x06009A93 RID: 39571 RVA: 0x00287A70 File Offset: 0x00285C70
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x06009A94 RID: 39572 RVA: 0x00287A72 File Offset: 0x00285C72
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x06009A95 RID: 39573 RVA: 0x00287A78 File Offset: 0x00285C78
	private void OnRoleTrialSettleNotify(RoleTrialSettleNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		if (notify.ErrorCode > Aki.Protocol.ErrorCode.Success)
		{
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(notify.ErrorCode, 17105, null, true, true);
			Action<int> onClickedCallback = delegate(int _)
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon().Forget<bool>();
			};
			RewardExploreConfirmButtonData item = new RewardExploreConfirmButtonData
			{
				ButtonTextId = "ConfirmBox_250_ButtonText_0",
				DescriptionTextId = null,
				IsTimeDownCloseView = false,
				IsClickedCloseView = true,
				OnClickedCallback = onClickedCallback
			};
			ControllerBase<ItemRewardController>.Instance.OpenExploreRewardView(3014, false, null, null, null, new List<IRewardExploreConfirmButton>
			{
				item
			}, null, null, null, null, null, null, null, null, null, null, null);
			return;
		}
	}

	// Token: 0x06009A96 RID: 39574 RVA: 0x00287B34 File Offset: 0x00285D34
	public void RequestRoleInstanceReward(int roleId, int activityId)
	{
		TrialRoleRewardRequest trialRoleRewardRequest = TrialRoleRewardRequest.Create();
		trialRoleRewardRequest.RoleId = roleId;
		Singleton<Net>.Instance.Call<TrialRoleRewardResponse>(ERequestMessageId.TrialRoleRewardRequest, trialRoleRewardRequest, delegate(TrialRoleRewardResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 20930, null, true, true);
			}
			ActivityRoleTrialData activityRoleTrialData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as ActivityRoleTrialData;
			if (activityRoleTrialData == null)
			{
				return;
			}
			activityRoleTrialData.SetRewardStateByRoleId(roleId, ERoleTrialRewardState.FinishedAndClaimed);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Activity;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "[角色试用活动]试用副本奖励领取成功";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("RoleId", roleId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityId);
		}, 0);
	}

	// Token: 0x06009A97 RID: 39575 RVA: 0x00287B84 File Offset: 0x00285D84
	[NullableContext(0)]
	public UniTask<bool> EnterRoleTrialDungeonDirectly(int instanceId, int activityId, int roleId)
	{
		ActivityRoleTrialController.<EnterRoleTrialDungeonDirectly>d__22 <EnterRoleTrialDungeonDirectly>d__;
		<EnterRoleTrialDungeonDirectly>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<EnterRoleTrialDungeonDirectly>d__.instanceId = instanceId;
		<EnterRoleTrialDungeonDirectly>d__.activityId = activityId;
		<EnterRoleTrialDungeonDirectly>d__.roleId = roleId;
		<EnterRoleTrialDungeonDirectly>d__.<>1__state = -1;
		<EnterRoleTrialDungeonDirectly>d__.<>t__builder.Start<ActivityRoleTrialController.<EnterRoleTrialDungeonDirectly>d__22>(ref <EnterRoleTrialDungeonDirectly>d__);
		return <EnterRoleTrialDungeonDirectly>d__.<>t__builder.Task;
	}

	// Token: 0x06009A98 RID: 39576 RVA: 0x00287BD8 File Offset: 0x00285DD8
	public void PushRoleIntroductionViewDone()
	{
		RoleTrialUiEndPush message = RoleTrialUiEndPush.Create();
		Singleton<Net>.Instance.Send(EPushMessageId.RoleTrialUiEndPush, message);
	}

	// Token: 0x0400472D RID: 18221
	[Nullable(new byte[]
	{
		1,
		2
	})]
	private readonly Dictionary<int, TimerHandle> RefreshTimerHandle = new Dictionary<int, TimerHandle>();

	// Token: 0x0400472E RID: 18222
	public List<int> CurrentActivityIdList = new List<int>();
}
