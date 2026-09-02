using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x020015B5 RID: 5557
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ActivityShipTowerController : ActivityControllerBase<ActivityShipTowerController>
{
	// Token: 0x06009C8E RID: 40078 RVA: 0x00290499 File Offset: 0x0028E699
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x06009C8F RID: 40079 RVA: 0x0029049C File Offset: 0x0028E69C
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x06009C90 RID: 40080 RVA: 0x0029049E File Offset: 0x0028E69E
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_ActivityMowingTower2";
	}

	// Token: 0x06009C91 RID: 40081 RVA: 0x002904A5 File Offset: 0x0028E6A5
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new ActivitySubViewShipTower();
	}

	// Token: 0x06009C92 RID: 40082 RVA: 0x002904AC File Offset: 0x0028E6AC
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		this.Data = new ActivityShipTowerData();
		return this.Data;
	}

	// Token: 0x06009C93 RID: 40083 RVA: 0x002904BF File Offset: 0x0028E6BF
	protected override void OnRegisterNetEvent()
	{
	}

	// Token: 0x06009C94 RID: 40084 RVA: 0x002904C1 File Offset: 0x0028E6C1
	protected override void OnUnRegisterNetEvent()
	{
	}

	// Token: 0x06009C95 RID: 40085 RVA: 0x002904C3 File Offset: 0x0028E6C3
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OpenActivityViewShipTower, new Action(this.OpenMainView));
	}

	// Token: 0x06009C96 RID: 40086 RVA: 0x002904E1 File Offset: 0x0028E6E1
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OpenActivityViewShipTower, new Action(this.OpenMainView));
	}

	// Token: 0x06009C97 RID: 40087 RVA: 0x002904FF File Offset: 0x0028E6FF
	private void OpenMainView()
	{
		ActivityController instance = ControllerBase<ActivityController>.Instance;
		ActivityShipTowerData data = this.Data;
		instance.OpenActivityById((data != null) ? data.Id : 0, EActivityViewOpenType.Other, null, null);
	}

	// Token: 0x06009C98 RID: 40088 RVA: 0x00290524 File Offset: 0x0028E724
	public static void RefreshActivityRedDot()
	{
		foreach (ActivityBaseData activityBaseData in ModelBase<ActivityModel>.Instance.GetCurrentActivitiesByType(ActivityType.SlashAndTowerLevelPlay))
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityBaseData.Id);
		}
	}

	// Token: 0x04004803 RID: 18435
	[Nullable(2)]
	public ActivityShipTowerData Data;
}
