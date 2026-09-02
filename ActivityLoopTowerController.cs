using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001369 RID: 4969
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ActivityLoopTowerController : ActivityControllerBase<ActivityLoopTowerController>
{
	// Token: 0x0600883B RID: 34875 RVA: 0x0023EF8C File Offset: 0x0023D18C
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x0600883C RID: 34876 RVA: 0x0023EF8F File Offset: 0x0023D18F
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x0600883D RID: 34877 RVA: 0x0023EF91 File Offset: 0x0023D191
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_ActivityLoopTower";
	}

	// Token: 0x0600883E RID: 34878 RVA: 0x0023EF98 File Offset: 0x0023D198
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new ActivitySubViewLoopTower();
	}

	// Token: 0x0600883F RID: 34879 RVA: 0x0023EF9F File Offset: 0x0023D19F
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		return new ActivityLoopTowerData();
	}

	// Token: 0x06008840 RID: 34880 RVA: 0x0023EFA6 File Offset: 0x0023D1A6
	protected override void OnRegisterNetEvent()
	{
	}

	// Token: 0x06008841 RID: 34881 RVA: 0x0023EFA8 File Offset: 0x0023D1A8
	protected override void OnUnRegisterNetEvent()
	{
	}

	// Token: 0x0400400A RID: 16394
	public int CurrentActivityId;
}
