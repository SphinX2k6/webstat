using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x0200157D RID: 5501
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ActivityRoleTrialConfig : ConfigBase<ActivityRoleTrialConfig>
{
	// Token: 0x06009A7E RID: 39550 RVA: 0x002874F3 File Offset: 0x002856F3
	public RoleTrialActivity? GetRoleTrialActivityConfig(int activityId)
	{
		return ConfigRoleTrialActivityById.GetConfig(activityId, true);
	}

	// Token: 0x06009A7F RID: 39551 RVA: 0x002874FC File Offset: 0x002856FC
	public RoleTrialInfo? GetRoleTrialInfoConfigByRoleId(int id)
	{
		return ConfigRoleTrialInfoById.GetConfig(id, true);
	}

	// Token: 0x06009A80 RID: 39552 RVA: 0x00287505 File Offset: 0x00285705
	public RoleTrialRoleConfig? GetRoleTrialRoleConfigByRoleId(int roleId)
	{
		return ConfigRoleTrialRoleConfigByRoleId.GetConfig(roleId, true);
	}

	// Token: 0x06009A81 RID: 39553 RVA: 0x0028750E File Offset: 0x0028570E
	public RoleTrialUiConfig? GetRoleTrialUiConfigById(int configId)
	{
		return ConfigRoleTrialUiConfigById.GetConfig(configId, true);
	}
}
