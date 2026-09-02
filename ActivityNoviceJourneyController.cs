using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x02001487 RID: 5255
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ActivityNoviceJourneyController : ActivityControllerBase<ActivityNoviceJourneyController>
{
	// Token: 0x06009309 RID: 37641 RVA: 0x0026CFA4 File Offset: 0x0026B1A4
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<int, int, int, int, int, int, int>(EEventName.OnPlayerLevelChanged, new Action<int, int, int, int, int, int, int>(this.OnPlayerLevelChanged));
	}

	// Token: 0x0600930A RID: 37642 RVA: 0x0026CFC2 File Offset: 0x0026B1C2
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove<int, int, int, int, int, int, int>(EEventName.OnPlayerLevelChanged, new Action<int, int, int, int, int, int, int>(this.OnPlayerLevelChanged));
	}

	// Token: 0x0600930B RID: 37643 RVA: 0x0026CFE0 File Offset: 0x0026B1E0
	private void OnPlayerLevelChanged(int i, int i1, int arg3, int arg4, int arg5, int arg6, int arg7)
	{
		if (this.DataId != 0)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.DataId);
		}
	}

	// Token: 0x0600930C RID: 37644 RVA: 0x0026D000 File Offset: 0x0026B200
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<NewBieCourseRewardNotify>(ENotifyMessageId.NewBieCourseRewardNotify, new Action<NewBieCourseRewardNotify, Net.CallbackStatus>(this.OnNewBieCourseRewardNotify));
	}

	// Token: 0x0600930D RID: 37645 RVA: 0x0026D01E File Offset: 0x0026B21E
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.NewBieCourseRewardNotify);
	}

	// Token: 0x0600930E RID: 37646 RVA: 0x0026D030 File Offset: 0x0026B230
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x0600930F RID: 37647 RVA: 0x0026D032 File Offset: 0x0026B232
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_ActivityRoleLevel";
	}

	// Token: 0x06009310 RID: 37648 RVA: 0x0026D039 File Offset: 0x0026B239
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new ActivitySubViewNoviceJourney();
	}

	// Token: 0x06009311 RID: 37649 RVA: 0x0026D040 File Offset: 0x0026B240
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		this.DataId = data.Id;
		return new ActivityNoviceJourneyData();
	}

	// Token: 0x06009312 RID: 37650 RVA: 0x0026D053 File Offset: 0x0026B253
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x06009313 RID: 37651 RVA: 0x0026D056 File Offset: 0x0026B256
	private void OnNewBieCourseRewardNotify(NewBieCourseRewardNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		ActivityNoviceJourneyData activityNoviceJourneyData = ModelBase<ActivityModel>.Instance.GetActivityById(this.DataId) as ActivityNoviceJourneyData;
		if (activityNoviceJourneyData == null)
		{
			return;
		}
		activityNoviceJourneyData.SetReceiveData(notify.HadTakeReward.ToArray<int>());
	}

	// Token: 0x06009314 RID: 37652 RVA: 0x0026D084 File Offset: 0x0026B284
	public void RequestReward(int level)
	{
		NewBieCourseRewardRequest newBieCourseRewardRequest = NewBieCourseRewardRequest.Create();
		newBieCourseRewardRequest.Level = level;
		Singleton<Net>.Instance.Call<NewBieCourseRewardResponse>(ERequestMessageId.NewBieCourseRewardRequest, newBieCourseRewardRequest, delegate(NewBieCourseRewardResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 26855, null, true, true);
				return;
			}
			ActivityNoviceJourneyData activityNoviceJourneyData = ModelBase<ActivityModel>.Instance.GetActivityById(this.DataId) as ActivityNoviceJourneyData;
			if (activityNoviceJourneyData != null)
			{
				activityNoviceJourneyData.AddReceivedData(level);
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.DataId);
		}, 0);
	}

	// Token: 0x04004417 RID: 17431
	private int DataId;
}
