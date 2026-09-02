using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x0200144A RID: 5194
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ActivityNewbieCourseV2Controller : ActivityControllerBase<ActivityNewbieCourseV2Controller>
{
	// Token: 0x06009094 RID: 37012 RVA: 0x00260318 File Offset: 0x0025E518
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<int, int, int, int, int, int, int>(EEventName.OnPlayerLevelChanged, new Action<int, int, int, int, int, int, int>(this.OnPlayerLevelChanged));
	}

	// Token: 0x06009095 RID: 37013 RVA: 0x00260336 File Offset: 0x0025E536
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove<int, int, int, int, int, int, int>(EEventName.OnPlayerLevelChanged, new Action<int, int, int, int, int, int, int>(this.OnPlayerLevelChanged));
	}

	// Token: 0x06009096 RID: 37014 RVA: 0x00260354 File Offset: 0x0025E554
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<NewbieCourseV2RewardNotify>(ENotifyMessageId.NewbieCourseV2RewardNotify, new Action<NewbieCourseV2RewardNotify, Net.CallbackStatus>(this.OnRewardNotify));
	}

	// Token: 0x06009097 RID: 37015 RVA: 0x00260372 File Offset: 0x0025E572
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.NewbieCourseV2RewardNotify);
	}

	// Token: 0x06009098 RID: 37016 RVA: 0x00260384 File Offset: 0x0025E584
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x06009099 RID: 37017 RVA: 0x00260386 File Offset: 0x0025E586
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_NewcomerSynesthesiaLevelMain";
	}

	// Token: 0x0600909A RID: 37018 RVA: 0x0026038D File Offset: 0x0025E58D
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new ActivitySubViewNewbieCourseV2();
	}

	// Token: 0x0600909B RID: 37019 RVA: 0x00260394 File Offset: 0x0025E594
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		this.DataId = data.Id;
		return new ActivityNewbieCourseV2Data();
	}

	// Token: 0x0600909C RID: 37020 RVA: 0x002603A7 File Offset: 0x0025E5A7
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x0600909D RID: 37021 RVA: 0x002603AA File Offset: 0x0025E5AA
	protected override bool OnClear()
	{
		this.DataId = 0;
		return true;
	}

	// Token: 0x0600909E RID: 37022 RVA: 0x002603B4 File Offset: 0x0025E5B4
	public void RequestRewards(IReadOnlyList<int> targetLevels, int? activityId = null)
	{
		int dataId = activityId ?? this.DataId;
		if (targetLevels == null || targetLevels.Count <= 0 || dataId == 0)
		{
			return;
		}
		NewbieCourseV2RewardRequest newbieCourseV2RewardRequest = NewbieCourseV2RewardRequest.Create();
		newbieCourseV2RewardRequest.ActivityId = dataId;
		foreach (int item in targetLevels)
		{
			newbieCourseV2RewardRequest.Level.Add(item);
		}
		Singleton<Net>.Instance.Call<NewbieCourseV2RewardResponse>(ERequestMessageId.NewbieCourseV2RewardRequest, newbieCourseV2RewardRequest, delegate(NewbieCourseV2RewardResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			Aki.Protocol.ErrorCode errorCode = ActivityNewbieCourseV2Controller.ReadResponseErrorCode(response);
			if (errorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(errorCode, 20963, null, true, true);
				return;
			}
			ActivityNewbieCourseV2Data activityNewbieCourseV2Data = ModelBase<ActivityModel>.Instance.GetActivityById(dataId) as ActivityNewbieCourseV2Data;
			if (activityNewbieCourseV2Data == null || activityNewbieCourseV2Data.Type != ActivityType.NewbieCourseV2)
			{
				return;
			}
			foreach (int level in targetLevels)
			{
				activityNewbieCourseV2Data.AddReceivedData(level);
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, dataId);
		}, 0);
	}

	// Token: 0x0600909F RID: 37023 RVA: 0x00260484 File Offset: 0x0025E684
	public void RequestReward(int targetLevel, int? activityId = null)
	{
		this.RequestRewards(new <>z__ReadOnlySingleElementList<int>(targetLevel), activityId);
	}

	// Token: 0x060090A0 RID: 37024 RVA: 0x00260494 File Offset: 0x0025E694
	public void RequestAllClaimableRewards(int? activityId = null)
	{
		int num = activityId ?? this.DataId;
		if (num == 0)
		{
			return;
		}
		ActivityNewbieCourseV2Data activityNewbieCourseV2Data = ModelBase<ActivityModel>.Instance.GetActivityById(num) as ActivityNewbieCourseV2Data;
		if (activityNewbieCourseV2Data == null || activityNewbieCourseV2Data.Type != ActivityType.NewbieCourseV2)
		{
			return;
		}
		List<int> list = new List<int>();
		foreach (NewbieCourseV2 newbieCourseV in ConfigBase<ActivityNewbieCourseV2Config>.Instance.GetConfigList(num))
		{
			if (activityNewbieCourseV2Data.GetRewardState(newbieCourseV.TargetLevel) == ENewbieCourseV2ItemState.CanReceive)
			{
				list.Add(newbieCourseV.TargetLevel);
			}
		}
		this.RequestRewards(list, new int?(num));
	}

	// Token: 0x060090A1 RID: 37025 RVA: 0x00260554 File Offset: 0x0025E754
	private static Aki.Protocol.ErrorCode ReadResponseErrorCode(NewbieCourseV2RewardResponse response)
	{
		Type type = response.GetType();
		foreach (string name in new string[]
		{
			"ErrorCode",
			"Error",
			"Code"
		})
		{
			PropertyInfo property = type.GetProperty(name);
			if (!(property == null))
			{
				object value = property.GetValue(response);
				if (value is Aki.Protocol.ErrorCode)
				{
					return (Aki.Protocol.ErrorCode)value;
				}
				if (value is int)
				{
					return (Aki.Protocol.ErrorCode)((int)value);
				}
			}
		}
		return Aki.Protocol.ErrorCode.UnKnownError;
	}

	// Token: 0x060090A2 RID: 37026 RVA: 0x002605E4 File Offset: 0x0025E7E4
	private void OnPlayerLevelChanged(int lastLevel, int currentLevel, int currentExp, int lastExp, int addExp, int currentMaxExp, int lastMaxExp)
	{
		if (this.DataId == 0)
		{
			return;
		}
		ActivityBaseData activityById = ModelBase<ActivityModel>.Instance.GetActivityById(this.DataId);
		if (activityById == null || activityById.Type != ActivityType.NewbieCourseV2)
		{
			return;
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.DataId);
	}

	// Token: 0x060090A3 RID: 37027 RVA: 0x00260630 File Offset: 0x0025E830
	private void OnRewardNotify(NewbieCourseV2RewardNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		if (notify.ActivityId != this.DataId)
		{
			return;
		}
		ActivityNewbieCourseV2Data activityNewbieCourseV2Data = ModelBase<ActivityModel>.Instance.GetActivityById(this.DataId) as ActivityNewbieCourseV2Data;
		if (activityNewbieCourseV2Data == null || activityNewbieCourseV2Data.Type != ActivityType.NewbieCourseV2)
		{
			return;
		}
		activityNewbieCourseV2Data.SetReceiveData(notify.HadTakeReward.ToArray<int>());
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.DataId);
	}

	// Token: 0x0400431B RID: 17179
	private int DataId;
}
