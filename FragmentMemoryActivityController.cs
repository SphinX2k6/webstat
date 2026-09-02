using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001C7E RID: 7294
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class FragmentMemoryActivityController : ActivityControllerBase<FragmentMemoryActivityController>
{
	// Token: 0x0600D521 RID: 54561 RVA: 0x0038E108 File Offset: 0x0038C308
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x0600D522 RID: 54562 RVA: 0x0038E10A File Offset: 0x0038C30A
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_ActivityProcessMemory";
	}

	// Token: 0x0600D523 RID: 54563 RVA: 0x0038E111 File Offset: 0x0038C311
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new FragmentMemorySubView();
	}

	// Token: 0x0600D524 RID: 54564 RVA: 0x0038E118 File Offset: 0x0038C318
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		return new FragmentMemoryActivityData();
	}

	// Token: 0x0600D525 RID: 54565 RVA: 0x0038E11F File Offset: 0x0038C31F
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}
}
