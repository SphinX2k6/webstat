using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x020011A3 RID: 4515
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ArtemisActivityController : ActivityControllerBase<ArtemisActivityController>
{
	// Token: 0x060076BD RID: 30397 RVA: 0x001F146D File Offset: 0x001EF66D
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<ArtemisNodeUpdateNotify>(ENotifyMessageId.ArtemisNodeUpdateNotify, new Action<ArtemisNodeUpdateNotify, Net.CallbackStatus>(this.OnArtemisNodeUpdateResponse));
	}

	// Token: 0x060076BE RID: 30398 RVA: 0x001F148B File Offset: 0x001EF68B
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ArtemisNodeUpdateNotify);
	}

	// Token: 0x060076BF RID: 30399 RVA: 0x001F149D File Offset: 0x001EF69D
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x060076C0 RID: 30400 RVA: 0x001F149F File Offset: 0x001EF69F
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_AimisActivityMain";
	}

	// Token: 0x060076C1 RID: 30401 RVA: 0x001F14A6 File Offset: 0x001EF6A6
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new ArtemisSubView();
	}

	// Token: 0x060076C2 RID: 30402 RVA: 0x001F14AD File Offset: 0x001EF6AD
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		return new ArtemisActivityData();
	}

	// Token: 0x060076C3 RID: 30403 RVA: 0x001F14B4 File Offset: 0x001EF6B4
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x060076C4 RID: 30404 RVA: 0x001F14B8 File Offset: 0x001EF6B8
	[NullableContext(2)]
	private void OnArtemisNodeUpdateResponse(ArtemisNodeUpdateNotify response, Net.CallbackStatus status)
	{
		if (response == null)
		{
			return;
		}
		ActivityModel instance = ModelBase<ActivityModel>.Instance;
		ArtemisActivityData artemisActivityData = ((instance != null) ? instance.GetActivityById(response.ActivityId) : null) as ArtemisActivityData;
		if (artemisActivityData != null)
		{
			artemisActivityData.SetUnlockIndex(response.UnlockIndex);
		}
		if (artemisActivityData != null)
		{
			artemisActivityData.SetRewardedIndex(response.RewardedIndex);
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, response.ActivityId);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnArtemisStateRefresh);
	}

	// Token: 0x060076C5 RID: 30405 RVA: 0x001F1530 File Offset: 0x001EF730
	public void RequestArtemisStatus(ArtemisActivityData data, int day, [Nullable(2)] Action<bool> callBack = null)
	{
		ArtemisNodeUpdateRequest artemisNodeUpdateRequest = ArtemisNodeUpdateRequest.Create();
		artemisNodeUpdateRequest.ActivityId = data.GetCacheActivityId;
		artemisNodeUpdateRequest.Index = day;
		Singleton<Net>.Instance.Call<ArtemisNodeUpdateResponse>(ERequestMessageId.ArtemisNodeUpdateRequest, artemisNodeUpdateRequest, delegate(ArtemisNodeUpdateResponse response, Net.CallbackStatus _)
		{
			if (callBack != null)
			{
				callBack(response == null || response.Error > ErrorCode.Success);
			}
			if (response != null)
			{
				if (response.Error == ErrorCode.Success)
				{
					ArtemisActivityData data2 = data;
					if (data2 != null)
					{
						data2.SetRewardedIndex(day);
					}
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, data.GetCacheActivityId);
					Singleton<EventSystem>.Instance.Emit(EEventName.OnArtemisStateRefresh);
					return;
				}
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.Error, 23183, null, true, true);
			}
		}, 0);
	}

	// Token: 0x04003970 RID: 14704
	public int CurrentDayIndex;
}
