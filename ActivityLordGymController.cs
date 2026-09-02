using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x0200136C RID: 4972
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ActivityLordGymController : ActivityControllerBase<ActivityLordGymController>
{
	// Token: 0x06008856 RID: 34902 RVA: 0x0023F5E9 File Offset: 0x0023D7E9
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x06008857 RID: 34903 RVA: 0x0023F5EC File Offset: 0x0023D7EC
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x06008858 RID: 34904 RVA: 0x0023F5EE File Offset: 0x0023D7EE
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_LordGym35Main";
	}

	// Token: 0x06008859 RID: 34905 RVA: 0x0023F5F5 File Offset: 0x0023D7F5
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new LordGymThird5ActivitySubView();
	}

	// Token: 0x0600885A RID: 34906 RVA: 0x0023F5FC File Offset: 0x0023D7FC
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		return new LordGymActivityData();
	}

	// Token: 0x0600885B RID: 34907 RVA: 0x0023F604 File Offset: 0x0023D804
	public LordGymActivityData GetCurrentActivityData()
	{
		List<ActivityBaseData> currentActivitiesByType = ModelBase<ActivityModel>.Instance.GetCurrentActivitiesByType(ActivityType.NewLordGym);
		LordGymActivityData result = null;
		if (currentActivitiesByType != null)
		{
			foreach (ActivityBaseData activityBaseData in currentActivitiesByType)
			{
				result = (activityBaseData as LordGymActivityData);
			}
		}
		return result;
	}
}
