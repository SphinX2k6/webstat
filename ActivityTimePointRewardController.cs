using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x020015D0 RID: 5584
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ActivityTimePointRewardController : ActivityControllerBase<ActivityTimePointRewardController>
{
	// Token: 0x06009D2F RID: 40239 RVA: 0x00292650 File Offset: 0x00290850
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x06009D30 RID: 40240 RVA: 0x00292654 File Offset: 0x00290854
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		if (data.Id == 102000001)
		{
			return "UiItem_ActivityTimePointReward";
		}
		if (data.Id == 102000002)
		{
			return "UiItem_WelfareInfoA";
		}
		if (data.Id == 102000004)
		{
			return "UiItem_WelfareBgC";
		}
		if (data.Id == 102000005)
		{
			return "UiItem_WelfareInfoB";
		}
		return "UiItem_ActivityTimePointReward";
	}

	// Token: 0x06009D31 RID: 40241 RVA: 0x002926B4 File Offset: 0x002908B4
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		if (data.Id == 102000001)
		{
			return new ActivitySubViewTimePointReward();
		}
		if (data.Id == 102000002)
		{
			return new CelebrationAwardSubView();
		}
		if (data.Id == 102000004)
		{
			return new MoonCelebrationAwardSubView();
		}
		if (data.Id == 102000005)
		{
			return new AnniversaryCelebrationAwardSubView();
		}
		return new ActivitySubViewTimePointReward();
	}

	// Token: 0x06009D32 RID: 40242 RVA: 0x00292712 File Offset: 0x00290912
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		return new ActivityTimePointRewardData();
	}

	// Token: 0x06009D33 RID: 40243 RVA: 0x00292719 File Offset: 0x00290919
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x06009D34 RID: 40244 RVA: 0x0029271C File Offset: 0x0029091C
	public void GetRewardById(int activityId, int id)
	{
		TimePointActivityRewardRequest timePointActivityRewardRequest = TimePointActivityRewardRequest.Create();
		timePointActivityRewardRequest.Id = id;
		Singleton<Net>.Instance.Call<TimePointActivityRewardResponse>(ERequestMessageId.TimePointActivityRewardRequest, timePointActivityRewardRequest, delegate(TimePointActivityRewardResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 24738, null, true, true);
				return;
			}
			(ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as ActivityTimePointRewardData).SetRewardToGotState(id);
		}, 0);
	}

	// Token: 0x04004864 RID: 18532
	public const int TIME_AWARD_SEASON1_ACTIVITY_ID = 102000001;

	// Token: 0x04004865 RID: 18533
	public const int TIME_AWARD_SEASON2_ACTIVITY_ID = 102000002;

	// Token: 0x04004866 RID: 18534
	public const int TIME_AWARD_SEASON4_ACTIVITY_ID = 102000004;

	// Token: 0x04004867 RID: 18535
	public const int TIME_AWARD_2026_SEASON2_ACTIVITY_ID = 102000005;
}
