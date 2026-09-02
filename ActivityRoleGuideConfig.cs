using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001574 RID: 5492
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ActivityRoleGuideConfig : ConfigBase<ActivityRoleGuideConfig>
{
	// Token: 0x06009A2E RID: 39470 RVA: 0x002863BA File Offset: 0x002845BA
	public RoleGuideActivity? GetRoleTrialActivityConfig(int activityId)
	{
		return ConfigRoleGuideActivityById.GetConfig(activityId, true);
	}
}
