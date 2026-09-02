using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x02001422 RID: 5154
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ActivityMotorGiftController : ActivityControllerBase<ActivityMotorGiftController>
{
	// Token: 0x06008EEE RID: 36590 RVA: 0x0025857F File Offset: 0x0025677F
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDiyFullOutlookUpdate, new Action(this.OnMotorOutlookUpdate));
	}

	// Token: 0x06008EEF RID: 36591 RVA: 0x0025859D File Offset: 0x0025679D
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDiyFullOutlookUpdate, new Action(this.OnMotorOutlookUpdate));
	}

	// Token: 0x06008EF0 RID: 36592 RVA: 0x002585BC File Offset: 0x002567BC
	private void OnMotorOutlookUpdate()
	{
		List<ActivityBaseData> currentActivitiesByType = ModelBase<ActivityModel>.Instance.GetCurrentActivitiesByType(ActivityType.PurePreviewActivity);
		if (currentActivitiesByType == null || currentActivitiesByType.Count == 0)
		{
			return;
		}
		foreach (ActivityBaseData activityBaseData in currentActivitiesByType)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityViewRefreshCurrent, activityBaseData.Id);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityBaseData.Id);
		}
	}

	// Token: 0x06008EF1 RID: 36593 RVA: 0x00258648 File Offset: 0x00256848
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x06008EF2 RID: 36594 RVA: 0x0025864A File Offset: 0x0025684A
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_ActivityMotoSkinMain";
	}

	// Token: 0x06008EF3 RID: 36595 RVA: 0x00258651 File Offset: 0x00256851
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new ActivityMotorGiftSubView();
	}

	// Token: 0x06008EF4 RID: 36596 RVA: 0x00258658 File Offset: 0x00256858
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		return new ActivityMotorGiftData();
	}

	// Token: 0x06008EF5 RID: 36597 RVA: 0x0025865F File Offset: 0x0025685F
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}
}
