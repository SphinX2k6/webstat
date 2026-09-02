using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x020015AA RID: 5546
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ActivitySevenDaySignController : ActivityControllerBase<ActivitySevenDaySignController>
{
	// Token: 0x06009C49 RID: 40009 RVA: 0x0028ECEC File Offset: 0x0028CEEC
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<SignActivitySignStateNotify>(ENotifyMessageId.SignActivitySignStateNotify, new Action<SignActivitySignStateNotify, Net.CallbackStatus>(this.OnSignActivitySignStateNotify));
	}

	// Token: 0x06009C4A RID: 40010 RVA: 0x0028ED0A File Offset: 0x0028CF0A
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SignActivitySignStateNotify);
	}

	// Token: 0x06009C4B RID: 40011 RVA: 0x0028ED1C File Offset: 0x0028CF1C
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x06009C4C RID: 40012 RVA: 0x0028ED20 File Offset: 0x0028CF20
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		ActivitySign? activitySignById = ConfigBase<ActivitySevenDaySignConfig>.Instance.GetActivitySignById(data.Id);
		if (activitySignById == null)
		{
			return "";
		}
		switch (activitySignById.Value.Type)
		{
		case 1:
			return activitySignById.Value.PrefabResource;
		case 2:
			return "UiItem_VersionSignIn";
		case 3:
			return "UiView_NewcomerSignIn";
		default:
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Activity;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "签到活动类型配置错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", activitySignById.Value.Type);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return "";
		}
		}
	}

	// Token: 0x06009C4D RID: 40013 RVA: 0x0028EDD4 File Offset: 0x0028CFD4
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		ActivitySign? activitySignById = ConfigBase<ActivitySevenDaySignConfig>.Instance.GetActivitySignById(data.Id);
		if (activitySignById == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Activity;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "签到活动未查到对应配置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", data.Id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return new ActivitySevenDaySignView();
		}
		switch (activitySignById.Value.Type)
		{
		case 1:
			return new ActivitySevenDaySignView();
		case 2:
			return new ActivitySubViewSevenDayVersionSign();
		case 3:
			return new ActivitySubViewNewcomerSignIn();
		default:
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Activity;
			ELogAuthor author2 = ELogAuthor.YYZ;
			string message2 = "签到活动类型配置错误";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Type", activitySignById.Value.Type);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return new ActivitySevenDaySignView();
		}
		}
	}

	// Token: 0x06009C4E RID: 40014 RVA: 0x0028EEB1 File Offset: 0x0028D0B1
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		return new ActivitySevenDaySignData();
	}

	// Token: 0x06009C4F RID: 40015 RVA: 0x0028EEB8 File Offset: 0x0028D0B8
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x06009C50 RID: 40016 RVA: 0x0028EEBC File Offset: 0x0028D0BC
	private unsafe void OnSignActivitySignStateNotify(SignActivitySignStateNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Activity;
		ELogAuthor author = ELogAuthor.YYZ;
		string message = "[ActivitySevenDaySign][OnNotify]收到签到状态通知";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ActivityId", notify.ActivityId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SignIndex", notify.Index);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("SignState", notify.SignState);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		ActivitySevenDaySignData activitySevenDaySignData = ModelBase<ActivityModel>.Instance.GetActivityById(notify.ActivityId) as ActivitySevenDaySignData;
		if (activitySevenDaySignData != null)
		{
			activitySevenDaySignData.UpdateActivityData(notify);
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityViewRefreshCurrent, notify.ActivityId);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, notify.ActivityId);
	}

	// Token: 0x06009C51 RID: 40017 RVA: 0x0028EFA4 File Offset: 0x0028D1A4
	public void GetRewardByDay(int activityId, int day)
	{
		SignActivityRequest signActivityRequest = SignActivityRequest.Create();
		signActivityRequest.ActivityId = activityId;
		signActivityRequest.Index = day;
		Singleton<Net>.Instance.Call<SignActivityResponse>(ERequestMessageId.SignActivityRequest, signActivityRequest, delegate(SignActivityResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 27535, null, true, true);
				return;
			}
			(ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as ActivitySevenDaySignData).SetRewardToGotState(day);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityId);
		}, 0);
	}

	// Token: 0x06009C52 RID: 40018 RVA: 0x0028F000 File Offset: 0x0028D200
	public void GetActivityFreeDrop(int activityId)
	{
		SignActivityFreeDropRequest signActivityFreeDropRequest = SignActivityFreeDropRequest.Create();
		signActivityFreeDropRequest.ActivityId = activityId;
		Singleton<Net>.Instance.Call<SignActivityFreeDropResponse>(ERequestMessageId.SignActivityFreeDropRequest, signActivityFreeDropRequest, delegate(SignActivityFreeDropResponse response, Net.CallbackStatus _)
		{
			(ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as ActivitySevenDaySignData).SetFreeRewardIsGet(true);
		}, 0);
	}
}
