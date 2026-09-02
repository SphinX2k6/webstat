using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

// Token: 0x02001264 RID: 4708
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ActivityBlackCoastController : ActivityControllerBase<ActivityBlackCoastController>
{
	// Token: 0x06007D77 RID: 32119 RVA: 0x00211A70 File Offset: 0x0020FC70
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<BlackCoastThemeStageUpdateNotify>(ENotifyMessageId.BlackCoastThemeStageUpdateNotify, new Action<BlackCoastThemeStageUpdateNotify, Net.CallbackStatus>(this.StageUpdate));
	}

	// Token: 0x06007D78 RID: 32120 RVA: 0x00211A8E File Offset: 0x0020FC8E
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BlackCoastThemeStageUpdateNotify);
	}

	// Token: 0x06007D79 RID: 32121 RVA: 0x00211AA0 File Offset: 0x0020FCA0
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
	}

	// Token: 0x06007D7A RID: 32122 RVA: 0x00211ABE File Offset: 0x0020FCBE
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
	}

	// Token: 0x06007D7B RID: 32123 RVA: 0x00211ADC File Offset: 0x0020FCDC
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		foreach (EUiViewName viewName in new EUiViewName[]
		{
			EUiViewName.BlackCoastActivityMainView,
			EUiViewName.BlackCoastActivityTaskView
		})
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(viewName))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06007D7C RID: 32124 RVA: 0x00211B2E File Offset: 0x0020FD2E
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x06007D7D RID: 32125 RVA: 0x00211B30 File Offset: 0x0020FD30
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_ActivityBlackCoast";
	}

	// Token: 0x06007D7E RID: 32126 RVA: 0x00211B37 File Offset: 0x0020FD37
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new ActivitySubViewBlackCoast();
	}

	// Token: 0x06007D7F RID: 32127 RVA: 0x00211B40 File Offset: 0x0020FD40
	private void OnCommonItemCountAnyChange(int configId, int count)
	{
		List<ActivityBaseData> activityDataList = this.GetActivityDataList();
		if (activityDataList.Count == 0)
		{
			return;
		}
		foreach (ActivityBaseData activityBaseData in activityDataList)
		{
			if ((activityBaseData as ActivityBlackCoastData).GetProgressItemId == configId)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityBaseData.Id);
			}
		}
	}

	// Token: 0x06007D80 RID: 32128 RVA: 0x00211BBC File Offset: 0x0020FDBC
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		return new ActivityBlackCoastData();
	}

	// Token: 0x06007D81 RID: 32129 RVA: 0x00211BC3 File Offset: 0x0020FDC3
	public override void OnShowActivityFirstUnlockView(ActivityBaseData data)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityUnlockTipBlackCoastView, null, null);
	}

	// Token: 0x06007D82 RID: 32130 RVA: 0x00211BD6 File Offset: 0x0020FDD6
	private List<ActivityBaseData> GetActivityDataList()
	{
		return ModelBase<ActivityModel>.Instance.GetCurrentActivitiesByType(25);
	}

	// Token: 0x06007D83 RID: 32131 RVA: 0x00211BE4 File Offset: 0x0020FDE4
	private void StageUpdate(BlackCoastThemeStageUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		foreach (ActivityBaseData activityBaseData in this.GetActivityDataList())
		{
			(activityBaseData as ActivityBlackCoastData).StageUpdate(notify.Stages.ToArray<BlackCoastThemeStageInfo>());
		}
	}

	// Token: 0x06007D84 RID: 32132 RVA: 0x00211C44 File Offset: 0x0020FE44
	public void RequestDataProgressReward(int activityId, int[] ids)
	{
		BlackCoastThemeActiveRewardRequest blackCoastThemeActiveRewardRequest = BlackCoastThemeActiveRewardRequest.Create();
		blackCoastThemeActiveRewardRequest.ActivityId = activityId;
		blackCoastThemeActiveRewardRequest.ActiveRewardIds.AddRange(ids);
		Singleton<Net>.Instance.Call<BlackCoastThemeActiveRewardResponse>(ERequestMessageId.BlackCoastThemeActiveRewardRequest, blackCoastThemeActiveRewardRequest, delegate(BlackCoastThemeActiveRewardResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.Error != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.Error, 18472, null, true, true);
				return;
			}
			foreach (ActivityBaseData activityBaseData in this.GetActivityDataList())
			{
				(activityBaseData as ActivityBlackCoastData).SetProgressRewardDataGot(response.ActiveRewardedIds.ToArray<int>());
			}
		}, 0);
	}

	// Token: 0x06007D85 RID: 32133 RVA: 0x00211C88 File Offset: 0x0020FE88
	public void RequestTaskReward(int stageId, int taskId)
	{
		BlackCoastThemeTaskRewardRequest blackCoastThemeTaskRewardRequest = BlackCoastThemeTaskRewardRequest.Create();
		blackCoastThemeTaskRewardRequest.TaskId = taskId;
		Singleton<Net>.Instance.Call<BlackCoastThemeTaskRewardResponse>(ERequestMessageId.BlackCoastThemeTaskRewardRequest, blackCoastThemeTaskRewardRequest, delegate(BlackCoastThemeTaskRewardResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.Error != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.Error, 27979, null, true, true);
				return;
			}
			foreach (ActivityBaseData activityBaseData in this.GetActivityDataList())
			{
				(activityBaseData as ActivityBlackCoastData).SetTaskRewardGot(stageId, taskId);
			}
		}, 0);
	}
}
