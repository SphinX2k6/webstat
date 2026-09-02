using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001579 RID: 5497
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class RoleSkinTrialConfig : ConfigBase<RoleSkinTrialConfig>
{
	// Token: 0x06009A50 RID: 39504 RVA: 0x00286C9B File Offset: 0x00284E9B
	public RoleSkinTrialInfo? GetRoleSkinTrialInfoByRoleId(int roleId)
	{
		return ConfigRoleSkinTrialInfoByRoleId.GetConfig(roleId, true);
	}

	// Token: 0x06009A51 RID: 39505 RVA: 0x00286CA4 File Offset: 0x00284EA4
	public RoleSkinTrialInfo? GetRoleSkinTrialInfoById(int id)
	{
		return ConfigRoleSkinTrialInfoById.GetConfig(id, true);
	}

	// Token: 0x06009A52 RID: 39506 RVA: 0x00286CAD File Offset: 0x00284EAD
	public RoleSkinTrialActivity? GetRoleSkinTrialActivityByActivityId(int activityId)
	{
		return ConfigRoleSkinTrialActivityById.GetConfig(activityId, true);
	}

	// Token: 0x06009A53 RID: 39507 RVA: 0x00286CB6 File Offset: 0x00284EB6
	public RoleSkinTrialUiConfig? GetRoleSkinTrialUiConfigById(int id)
	{
		return ConfigRoleSkinTrialUiConfigById.GetConfig(id, true);
	}
}
