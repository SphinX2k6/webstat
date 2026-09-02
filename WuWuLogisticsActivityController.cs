using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

// Token: 0x0200170D RID: 5901
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class WuWuLogisticsActivityController : ActivityControllerBase<WuWuLogisticsActivityController>
{
	// Token: 0x0600A405 RID: 41989 RVA: 0x002B5BD4 File Offset: 0x002B3DD4
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<WuWuTaskUpdateNotify>(ENotifyMessageId.WuWuTaskUpdateNotify, new Action<WuWuTaskUpdateNotify, Net.CallbackStatus>(this.OnWuWuTaskUpdateNotify));
		Singleton<Net>.Instance.Register<ThemeCeleWuWuTaskNotify>(ENotifyMessageId.ThemeCeleWuWuTaskNotify, new Action<ThemeCeleWuWuTaskNotify, Net.CallbackStatus>(this.OnThemeCeleWuWuTaskNotify));
	}

	// Token: 0x0600A406 RID: 41990 RVA: 0x002B5C0E File Offset: 0x002B3E0E
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.WuWuTaskUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ThemeCeleWuWuTaskNotify);
	}

	// Token: 0x0600A407 RID: 41991 RVA: 0x002B5C30 File Offset: 0x002B3E30
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.CrossDay, new Action(this.OnUpdatePackData));
	}

	// Token: 0x0600A408 RID: 41992 RVA: 0x002B5C4E File Offset: 0x002B3E4E
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.CrossDay, new Action(this.OnUpdatePackData));
	}

	// Token: 0x0600A409 RID: 41993 RVA: 0x002B5C6C File Offset: 0x002B3E6C
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x0600A40A RID: 41994 RVA: 0x002B5C6E File Offset: 0x002B3E6E
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_WuwuLogisticsActivityMain";
	}

	// Token: 0x0600A40B RID: 41995 RVA: 0x002B5C75 File Offset: 0x002B3E75
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new WuWuLogisticsActivitySubView();
	}

	// Token: 0x0600A40C RID: 41996 RVA: 0x002B5C7C File Offset: 0x002B3E7C
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		this.ActivityId = data.Id;
		return new WuWuLogisticsActivityData();
	}

	// Token: 0x0600A40D RID: 41997 RVA: 0x002B5C8F File Offset: 0x002B3E8F
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x0600A40E RID: 41998 RVA: 0x002B5C92 File Offset: 0x002B3E92
	[NullableContext(2)]
	public WuWuLogisticsActivityData GetActivityData()
	{
		return ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityId) as WuWuLogisticsActivityData;
	}

	// Token: 0x0600A40F RID: 41999 RVA: 0x002B5CAC File Offset: 0x002B3EAC
	private void OnWuWuTaskUpdateNotify(WuWuTaskUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		if (notify == null || notify.Task == null)
		{
			return;
		}
		WuWuLogisticsActivityData activityData = this.GetActivityData();
		if (activityData == null)
		{
			return;
		}
		activityData.UpdateTaskData(notify.Task, 0);
		Singleton<EventSystem>.Instance.Emit(EEventName.WuWuLogisticsTaskUpdate);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityId);
	}

	// Token: 0x0600A410 RID: 42000 RVA: 0x002B5D04 File Offset: 0x002B3F04
	private void OnThemeCeleWuWuTaskNotify(ThemeCeleWuWuTaskNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		if (notify == null || notify.Task == null)
		{
			return;
		}
		WuWuLogisticsActivityData activityData = this.GetActivityData();
		if (activityData == null)
		{
			return;
		}
		activityData.UpdateTaskData(notify.Task, 0);
		Singleton<EventSystem>.Instance.Emit(EEventName.WuWuLogisticsTaskUpdate);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityId);
	}

	// Token: 0x0600A411 RID: 42001 RVA: 0x002B5D5C File Offset: 0x002B3F5C
	private void OnUpdatePackData()
	{
		WuWuLogisticsActivityData activityData = this.GetActivityData();
		if (activityData == null)
		{
			return;
		}
		if (activityData.HasFirstUnlockPack())
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.WuWuLogisticsMissionView))
			{
				activityData.SetFirstOpenFalse();
				return;
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityId);
		}
	}

	// Token: 0x0600A412 RID: 42002 RVA: 0x002B5DAC File Offset: 0x002B3FAC
	public void RequestTaskReward(List<int> taskIds)
	{
		WuWuTaskRewardRequest wuWuTaskRewardRequest = new WuWuTaskRewardRequest();
		foreach (int item in taskIds)
		{
			wuWuTaskRewardRequest.Ids.Add(item);
		}
		Singleton<Net>.Instance.Call<WuWuTaskRewardResponse>(ERequestMessageId.WuWuTaskRewardRequest, wuWuTaskRewardRequest, delegate(WuWuTaskRewardResponse response, Net.CallbackStatus status)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 18695, null, true, true);
				return;
			}
			WuWuLogisticsActivityData activityData = this.GetActivityData();
			if (activityData != null)
			{
				foreach (int taskId in taskIds)
				{
					WuWuTaskData taskById = activityData.GetTaskById(taskId);
					if (taskById != null)
					{
						taskById.State = EWuWuTaskState.Taken;
					}
				}
				Singleton<EventSystem>.Instance.Emit(EEventName.WuWuLogisticsTaskUpdate);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityId);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityViewRefreshCurrent, this.ActivityId);
			}
		}, 0);
	}

	// Token: 0x0600A413 RID: 42003 RVA: 0x002B5E3C File Offset: 0x002B403C
	public void RequestTaskPackageReward(int wrapId)
	{
		WuWuPackageRewardRequest wuWuPackageRewardRequest = new WuWuPackageRewardRequest();
		wuWuPackageRewardRequest.WrapId = wrapId;
		Singleton<Net>.Instance.Call<WuWuPackageRewardResponse>(ERequestMessageId.WuWuPackageRewardRequest, wuWuPackageRewardRequest, delegate(WuWuPackageRewardResponse response, Net.CallbackStatus status)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 25338, null, true, true);
				return;
			}
			WuWuLogisticsActivityData wuWuLogisticsActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityId) as WuWuLogisticsActivityData;
			if (wuWuLogisticsActivityData != null)
			{
				WuWuTaskPackData taskPackById = wuWuLogisticsActivityData.GetTaskPackById(wrapId);
				if (taskPackById != null)
				{
					taskPackById.HadReward = true;
				}
				Singleton<EventSystem>.Instance.Emit(EEventName.WuWuLogisticsTaskUpdate);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityId);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityViewRefreshCurrent, this.ActivityId);
			}
		}, 0);
	}

	// Token: 0x04004DDC RID: 19932
	public int ActivityId;
}
