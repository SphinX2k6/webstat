using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x020015D9 RID: 5593
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ActivityTowerGuideController : ActivityControllerBase<ActivityTowerGuideController>
{
	// Token: 0x06009D69 RID: 40297 RVA: 0x00293970 File Offset: 0x00291B70
	public void SetCurrentActivityId(int id)
	{
		this.CurrentActivityId = id;
	}

	// Token: 0x06009D6A RID: 40298 RVA: 0x00293979 File Offset: 0x00291B79
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x06009D6B RID: 40299 RVA: 0x0029397C File Offset: 0x00291B7C
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x06009D6C RID: 40300 RVA: 0x0029397E File Offset: 0x00291B7E
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_TowerGuide";
	}

	// Token: 0x06009D6D RID: 40301 RVA: 0x00293985 File Offset: 0x00291B85
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new ActivitySubViewTowerGuide();
	}

	// Token: 0x06009D6E RID: 40302 RVA: 0x0029398C File Offset: 0x00291B8C
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		return new ActivityTowerGuideData();
	}

	// Token: 0x06009D6F RID: 40303 RVA: 0x00293993 File Offset: 0x00291B93
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnTowerRecordUpdate, new Action<int, int>(this.OnTowerRecordChange));
	}

	// Token: 0x06009D70 RID: 40304 RVA: 0x002939B1 File Offset: 0x00291BB1
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnTowerRecordUpdate, new Action<int, int>(this.OnTowerRecordChange));
	}

	// Token: 0x06009D71 RID: 40305 RVA: 0x002939CF File Offset: 0x00291BCF
	[NullableContext(2)]
	private ActivityTowerGuideData GetTowerGuideData()
	{
		return ModelBase<ActivityModel>.Instance.GetActivityById(this.CurrentActivityId) as ActivityTowerGuideData;
	}

	// Token: 0x06009D72 RID: 40306 RVA: 0x002939E8 File Offset: 0x00291BE8
	private void OnTowerRecordChange(int towerId, int difficultId)
	{
		ActivityTowerGuideData towerGuideData = this.GetTowerGuideData();
		if (towerGuideData == null)
		{
			return;
		}
		towerGuideData.RefreshRewardState((ETowerDifficultId)difficultId);
	}

	// Token: 0x06009D73 RID: 40307 RVA: 0x00293A08 File Offset: 0x00291C08
	public void RequestTowerReward(ETowerDifficultId id)
	{
		TowerGuideActivityRewardRequest towerGuideActivityRewardRequest = TowerGuideActivityRewardRequest.Create();
		towerGuideActivityRewardRequest.TowerGuideId = (int)id;
		Singleton<Net>.Instance.Call<TowerGuideActivityRewardResponse>(ERequestMessageId.TowerGuideActivityRewardRequest, towerGuideActivityRewardRequest, delegate(TowerGuideActivityRewardResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 15652, null, true, true);
				return;
			}
			this.RequestTowerRewardInfo();
		}, 0);
	}

	// Token: 0x06009D74 RID: 40308 RVA: 0x00293A40 File Offset: 0x00291C40
	public void RequestTowerRewardInfo()
	{
		TowerGuideActivityInfoRequest message = TowerGuideActivityInfoRequest.Create();
		Singleton<Net>.Instance.Call<TowerGuideActivityInfoResponse>(ERequestMessageId.TowerGuideActivityInfoRequest, message, delegate(TowerGuideActivityInfoResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			ActivityTowerGuideData towerGuideData = this.GetTowerGuideData();
			if (towerGuideData == null)
			{
				return;
			}
			foreach (int id in response.TowerGuideId)
			{
				towerGuideData.SetRewardClaimed(id, true);
			}
		}, 0);
	}

	// Token: 0x0400487F RID: 18559
	public int CurrentActivityId;
}
