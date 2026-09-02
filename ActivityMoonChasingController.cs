using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

// Token: 0x0200139A RID: 5018
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ActivityMoonChasingController : ActivityControllerBase<ActivityMoonChasingController>
{
	// Token: 0x06008A15 RID: 35349 RVA: 0x002459AC File Offset: 0x00243BAC
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		foreach (ActivityBaseData activityBaseData in ModelBase<ActivityModel>.Instance.GetActivitiesByType(17))
		{
			ActivityMoonChasingData activityMoonChasingData = activityBaseData as ActivityMoonChasingData;
			EUiViewName[] array;
			if (activityMoonChasingData != null && activityMoonChasingData.ActivityFlowState == EMoonChasingActivityFlow.Activity)
			{
				array = new EUiViewName[]
				{
					EUiViewName.MoonChasingMainView,
					EUiViewName.RewardMainView,
					EUiViewName.MoonChasingHandbookView,
					EUiViewName.BusinessMainView,
					EUiViewName.BusinessHelperView,
					EUiViewName.MoonChasingTaskView
				};
			}
			else
			{
				array = new EUiViewName[]
				{
					EUiViewName.MoonChasingMemoryView,
					EUiViewName.MoonChasingMemoryDetailView,
					EUiViewName.RewardMainView,
					EUiViewName.MoonChasingHandbookView
				};
			}
			foreach (EUiViewName viewName in array)
			{
				if (Singleton<UiManager>.Instance.IsViewOpen(viewName))
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06008A16 RID: 35350 RVA: 0x00245AD4 File Offset: 0x00243CD4
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x06008A17 RID: 35351 RVA: 0x00245AD6 File Offset: 0x00243CD6
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_ActivityMoonChasingMain";
	}

	// Token: 0x06008A18 RID: 35352 RVA: 0x00245ADD File Offset: 0x00243CDD
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new ActivitySubViewMoonChasing();
	}

	// Token: 0x06008A19 RID: 35353 RVA: 0x00245AE4 File Offset: 0x00243CE4
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		if (!this.IsActivityOn)
		{
			this.InitMoonChasingData();
			this.IsActivityOn = true;
		}
		return new ActivityMoonChasingData();
	}

	// Token: 0x06008A1A RID: 35354 RVA: 0x00245B00 File Offset: 0x00243D00
	public override void OnShowActivityFirstUnlockView(ActivityBaseData data)
	{
		ActivityMoonChasingData activityMoonChasingData = data as ActivityMoonChasingData;
		if (activityMoonChasingData != null && activityMoonChasingData.ActivityFlowState == EMoonChasingActivityFlow.Activity)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityUnlockTipMoonChasingView, null, null);
		}
	}

	// Token: 0x06008A1B RID: 35355 RVA: 0x00245B2C File Offset: 0x00243D2C
	public void RefreshActivityRedDot()
	{
		foreach (ActivityBaseData activityBaseData in ModelBase<ActivityModel>.Instance.GetCurrentActivitiesByType(17))
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityBaseData.Id);
		}
	}

	// Token: 0x06008A1C RID: 35356 RVA: 0x00245B94 File Offset: 0x00243D94
	public void TrackMoonActivityTargetRewardRequest(int activityId, int id)
	{
		TrackMoonActivityRewardRequest trackMoonActivityRewardRequest = TrackMoonActivityRewardRequest.Create();
		trackMoonActivityRewardRequest.Id = id;
		trackMoonActivityRewardRequest.ActivityId = activityId;
		Singleton<Net>.Instance.Call<TrackMoonActivityRewardResponse>(ERequestMessageId.TrackMoonActivityRewardRequest, trackMoonActivityRewardRequest, delegate(TrackMoonActivityRewardResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 20666, null, true, true);
				return;
			}
			ActivityMoonChasingData activityMoonChasingData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as ActivityMoonChasingData;
			if (activityMoonChasingData == null)
			{
				return;
			}
			activityMoonChasingData.SetRewardState(id, EActivityTaskState.FinishedAndClaimed);
		}, 0);
	}

	// Token: 0x06008A1D RID: 35357 RVA: 0x00245BF0 File Offset: 0x00243DF0
	public void CheckIsActivityClose()
	{
		using (List<ActivityBaseData>.Enumerator enumerator = ModelBase<ActivityModel>.Instance.GetActivitiesByType(17).GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.CheckIfClose())
				{
					ControllerBase<ActivityController>.Instance.ShowActivityRefreshAndBackToBattleView();
					break;
				}
			}
		}
	}

	// Token: 0x06008A1E RID: 35358 RVA: 0x00245C54 File Offset: 0x00243E54
	private void InitMoonChasingData()
	{
		ControllerBase<MoonChasingController>.Instance.TrackMoonAllDataRequest();
	}

	// Token: 0x040040BF RID: 16575
	private bool IsActivityOn;
}
