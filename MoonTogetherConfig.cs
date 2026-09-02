using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002A04 RID: 10756
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class MoonTogetherConfig : ConfigBase<MoonTogetherConfig>
{
	// Token: 0x0601575D RID: 87901 RVA: 0x005F2ED6 File Offset: 0x005F10D6
	public IReadOnlyList<MotorRoleCategory> GetRoleAreaList()
	{
		return ConfigMotorRoleCategoryAll.GetConfigList(true);
	}

	// Token: 0x0601575E RID: 87902 RVA: 0x005F2EDE File Offset: 0x005F10DE
	public MotorRoleCategory? GetRoleAreaById(int areaId)
	{
		return ConfigMotorRoleCategoryById.GetConfig(areaId, true);
	}

	// Token: 0x0601575F RID: 87903 RVA: 0x005F2EE7 File Offset: 0x005F10E7
	public VehicleRidingRoles? GetVehicleRidingRolesById(int roleId)
	{
		return ConfigVehicleRidingRolesById.GetConfig(roleId, true);
	}
}
