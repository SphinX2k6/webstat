using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001295 RID: 4757
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class CiacconaActivityController : ActivityControllerBase<CiacconaActivityController>
{
	// Token: 0x06007F60 RID: 32608 RVA: 0x0021A958 File Offset: 0x00218B58
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x06007F61 RID: 32609 RVA: 0x0021A95B File Offset: 0x00218B5B
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x06007F62 RID: 32610 RVA: 0x0021A95D File Offset: 0x00218B5D
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_ActivityXiaMain";
	}

	// Token: 0x06007F63 RID: 32611 RVA: 0x0021A964 File Offset: 0x00218B64
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new CiacconaActivitySubView();
	}

	// Token: 0x06007F64 RID: 32612 RVA: 0x0021A96B File Offset: 0x00218B6B
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		return new CiacconaActivityData();
	}
}
