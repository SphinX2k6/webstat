using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x020012C3 RID: 4803
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ActivityDailyAdventureController : ActivityControllerBase<ActivityDailyAdventureController>
{
	// Token: 0x060080F9 RID: 33017 RVA: 0x002214E3 File Offset: 0x0021F6E3
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x060080FA RID: 33018 RVA: 0x002214E6 File Offset: 0x0021F6E6
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x060080FB RID: 33019 RVA: 0x002214E8 File Offset: 0x0021F6E8
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_ActivityDailyAdventure";
	}

	// Token: 0x060080FC RID: 33020 RVA: 0x002214EF File Offset: 0x0021F6EF
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new ActivitySubViewDailyAdventure();
	}

	// Token: 0x060080FD RID: 33021 RVA: 0x002214F6 File Offset: 0x0021F6F6
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		this.CurrentActivityId = data.Id;
		return new ActivityDailyAdventureData();
	}

	// Token: 0x060080FE RID: 33022 RVA: 0x00221509 File Offset: 0x0021F709
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
	}

	// Token: 0x060080FF RID: 33023 RVA: 0x00221527 File Offset: 0x0021F727
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
	}

	// Token: 0x06008100 RID: 33024 RVA: 0x00221545 File Offset: 0x0021F745
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<DailyAdventureTaskUpdateNotify>(ENotifyMessageId.DailyAdventureTaskUpdateNotify, new Action<DailyAdventureTaskUpdateNotify, Net.CallbackStatus>(this.OnDailyAdventureTaskUpdateNotify));
	}

	// Token: 0x06008101 RID: 33025 RVA: 0x00221563 File Offset: 0x0021F763
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.DailyAdventureTaskUpdateNotify);
	}

	// Token: 0x06008102 RID: 33026 RVA: 0x00221575 File Offset: 0x0021F775
	[NullableContext(2)]
	protected ActivityDailyAdventureData GetDailyAdventureData()
	{
		return ModelBase<ActivityModel>.Instance.GetActivityById(this.CurrentActivityId) as ActivityDailyAdventureData;
	}

	// Token: 0x06008103 RID: 33027 RVA: 0x0022158C File Offset: 0x0021F78C
	public int GetDefaultMapMarkId()
	{
		ActivityDailyAdventureData dailyAdventureData = this.GetDailyAdventureData();
		if (dailyAdventureData == null)
		{
			return 0;
		}
		return dailyAdventureData.GetDefaultMapMarkId();
	}

	// Token: 0x06008104 RID: 33028 RVA: 0x002215AC File Offset: 0x0021F7AC
	private void OnCommonItemCountAnyChange(int configId, int count)
	{
		if (configId != 13)
		{
			return;
		}
		ActivityDailyAdventureData dailyAdventureData = this.GetDailyAdventureData();
		if (dailyAdventureData == null)
		{
			return;
		}
		dailyAdventureData.SetProgressPoint(count);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, dailyAdventureData.Id);
	}

	// Token: 0x06008105 RID: 33029 RVA: 0x002215E8 File Offset: 0x0021F7E8
	private void OnDailyAdventureTaskUpdateNotify(DailyAdventureTaskUpdateNotify message, [Nullable(2)] Net.CallbackStatus _)
	{
		ActivityDailyAdventureData dailyAdventureData = this.GetDailyAdventureData();
		if (dailyAdventureData == null)
		{
			return;
		}
		foreach (DailyAdventureActivityTask dailyAdventureActivityTask in message.DailyAdventureActivityTasks)
		{
			dailyAdventureData.SetTaskInfo(dailyAdventureActivityTask.Id, new ERewardState?(ActivityDailyAdventureDefine.RewardStateResolver[dailyAdventureActivityTask.Status]), new int?(dailyAdventureActivityTask.Current));
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, dailyAdventureData.Id);
	}

	// Token: 0x06008106 RID: 33030 RVA: 0x0022167C File Offset: 0x0021F87C
	public void RequestTaskReward(int id)
	{
		DailyAdventureTaskRewardRequest dailyAdventureTaskRewardRequest = DailyAdventureTaskRewardRequest.Create();
		dailyAdventureTaskRewardRequest.Id = id;
		Singleton<Net>.Instance.Call<DailyAdventureTaskRewardResponse>(ERequestMessageId.DailyAdventureTaskRewardRequest, dailyAdventureTaskRewardRequest, delegate(DailyAdventureTaskRewardResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 17294, null, true, true);
				return;
			}
			ActivityDailyAdventureData dailyAdventureData = this.GetDailyAdventureData();
			if (dailyAdventureData == null)
			{
				return;
			}
			dailyAdventureData.SetTaskInfo(id, new ERewardState?(ERewardState.FinishedAndClaimed), null);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, dailyAdventureData.Id);
		}, 0);
	}

	// Token: 0x06008107 RID: 33031 RVA: 0x002216CC File Offset: 0x0021F8CC
	public void RequestPointReward(int id)
	{
		DailyAdventurePtRewardRequest dailyAdventurePtRewardRequest = DailyAdventurePtRewardRequest.Create();
		dailyAdventurePtRewardRequest.Id = id;
		Singleton<Net>.Instance.Call<DailyAdventurePtRewardResponse>(ERequestMessageId.DailyAdventurePtRewardRequest, dailyAdventurePtRewardRequest, delegate(DailyAdventurePtRewardResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 21140, null, true, true);
				return;
			}
			ActivityDailyAdventureData dailyAdventureData = this.GetDailyAdventureData();
			if (dailyAdventureData == null)
			{
				return;
			}
			dailyAdventureData.SetPointReward(id, true);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, dailyAdventureData.Id);
		}, 0);
	}

	// Token: 0x04003D98 RID: 15768
	public int CurrentActivityId;
}
