using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x02001571 RID: 5489
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ActivityRoleGiveController : ActivityControllerBase<ActivityRoleGiveController>
{
	// Token: 0x06009A14 RID: 39444 RVA: 0x00285956 File Offset: 0x00283B56
	protected override void OnOpenView(ActivityBaseData data)
	{
		throw new NotImplementedException();
	}

	// Token: 0x06009A15 RID: 39445 RVA: 0x0028595D File Offset: 0x00283B5D
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_ActivityRoleXiangliyao";
	}

	// Token: 0x06009A16 RID: 39446 RVA: 0x00285964 File Offset: 0x00283B64
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new ActivitySubViewRoleGive();
	}

	// Token: 0x06009A17 RID: 39447 RVA: 0x0028596B File Offset: 0x00283B6B
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		this.CurrentActivityId = data.Id;
		return new ActivityRoleGiveData();
	}

	// Token: 0x06009A18 RID: 39448 RVA: 0x0028597E File Offset: 0x00283B7E
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x06009A19 RID: 39449 RVA: 0x00285984 File Offset: 0x00283B84
	public void TrackMoonActivityRewardRequest()
	{
		TraceMoonPhaseRewardRequest traceMoonPhaseRewardRequest = TraceMoonPhaseRewardRequest.Create();
		traceMoonPhaseRewardRequest.ActivityId = this.CurrentActivityId;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.MoonChasing;
		ELogAuthor author = ELogAuthor.LPH;
		string message = "TrackMoonActivityRewardRequest";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActivityId:", this.CurrentActivityId);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		Singleton<Net>.Instance.Call<TraceMoonPhaseRewardResponse>(ERequestMessageId.TraceMoonPhaseRewardRequest, traceMoonPhaseRewardRequest, delegate(TraceMoonPhaseRewardResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 29138, null, true, true);
				return;
			}
			ActivityRoleGiveData currentActivityData = this.GetCurrentActivityData();
			if (currentActivityData == null)
			{
				return;
			}
			currentActivityData.IsGetReward = true;
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.CurrentActivityId);
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.MoonChasing;
			ELogAuthor author2 = ELogAuthor.LPH;
			string message2 = "TrackMoonActivityRewardResponse";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("ActivityId:", this.CurrentActivityId);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		}, 0);
	}

	// Token: 0x06009A1A RID: 39450 RVA: 0x002859F4 File Offset: 0x00283BF4
	[NullableContext(2)]
	public ActivityRoleGiveData GetCurrentActivityData()
	{
		ActivityRoleGiveData activityRoleGiveData = ModelBase<ActivityModel>.Instance.GetActivityById(this.CurrentActivityId) as ActivityRoleGiveData;
		if (activityRoleGiveData == null)
		{
			return null;
		}
		return activityRoleGiveData;
	}

	// Token: 0x04004712 RID: 18194
	public int CurrentActivityId;
}
