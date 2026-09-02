using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001575 RID: 5493
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ActivityRoleGuideController : ActivityControllerBase<ActivityRoleGuideController>
{
	// Token: 0x06009A30 RID: 39472 RVA: 0x002863CB File Offset: 0x002845CB
	protected override void OnAddEvents()
	{
	}

	// Token: 0x06009A31 RID: 39473 RVA: 0x002863CD File Offset: 0x002845CD
	protected override void OnRemoveEvents()
	{
	}

	// Token: 0x06009A32 RID: 39474 RVA: 0x002863CF File Offset: 0x002845CF
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_ActivityRoleGuide";
	}

	// Token: 0x06009A33 RID: 39475 RVA: 0x002863D6 File Offset: 0x002845D6
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new ActivitySubViewRoleGuide();
	}

	// Token: 0x06009A34 RID: 39476 RVA: 0x002863DD File Offset: 0x002845DD
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		this.CurrentActivityId = data.Id;
		return new ActivityRoleGuideData();
	}

	// Token: 0x06009A35 RID: 39477 RVA: 0x002863F0 File Offset: 0x002845F0
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x06009A36 RID: 39478 RVA: 0x002863F2 File Offset: 0x002845F2
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x0400471A RID: 18202
	public int CurrentActivityId;
}
