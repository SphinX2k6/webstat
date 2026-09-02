using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x0200117B RID: 4475
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ActivityLinkageController : ActivityControllerBase<ActivityLinkageController>
{
	// Token: 0x060075CA RID: 30154 RVA: 0x001ED32C File Offset: 0x001EB52C
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x060075CB RID: 30155 RVA: 0x001ED32E File Offset: 0x001EB52E
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x060075CC RID: 30156 RVA: 0x001ED331 File Offset: 0x001EB531
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_LinkageMain";
	}

	// Token: 0x060075CD RID: 30157 RVA: 0x001ED338 File Offset: 0x001EB538
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new ActivityLinkageSubView();
	}

	// Token: 0x060075CE RID: 30158 RVA: 0x001ED33F File Offset: 0x001EB53F
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		this.ActivityId = data.Id;
		return new global::ActivityLinkageData();
	}

	// Token: 0x060075CF RID: 30159 RVA: 0x001ED352 File Offset: 0x001EB552
	public global::ActivityLinkageData GetActivityLinkageData()
	{
		ActivityModel instance = ModelBase<ActivityModel>.Instance;
		return ((instance != null) ? instance.GetActivityById(this.ActivityId) : null) as global::ActivityLinkageData;
	}

	// Token: 0x060075D0 RID: 30160 RVA: 0x001ED370 File Offset: 0x001EB570
	public void RequestReward(int tabId)
	{
		LinkageRewardRequest linkageRewardRequest = LinkageRewardRequest.Create();
		linkageRewardRequest.ActivityId = this.ActivityId;
		linkageRewardRequest.ActivityPageId = tabId;
		Singleton<Net>.Instance.Call<LinkageRewardResponse>(ERequestMessageId.LinkageRewardRequest, linkageRewardRequest, delegate(LinkageRewardResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 25812, null, true, true);
				return;
			}
			global::ActivityLinkageData activityLinkageData = this.GetActivityLinkageData();
			if (activityLinkageData == null)
			{
				return;
			}
			activityLinkageData.ReceiveReward(tabId);
		}, 0);
	}

	// Token: 0x04003910 RID: 14608
	private int ActivityId;
}
