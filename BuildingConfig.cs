using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x0200139F RID: 5023
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class BuildingConfig : ConfigBase<BuildingConfig>
{
	// Token: 0x06008A4A RID: 35402 RVA: 0x00246A10 File Offset: 0x00244C10
	public IReadOnlyList<Building> GetBuildingAll()
	{
		IReadOnlyList<Building> configList = ConfigBuildingAll.GetConfigList(true);
		return configList ?? new List<Building>();
	}

	// Token: 0x06008A4B RID: 35403 RVA: 0x00246A30 File Offset: 0x00244C30
	public Building GetBuildingById(int id)
	{
		return ConfigBuildingById.GetConfig(id, true).GetValueOrDefault();
	}

	// Token: 0x06008A4C RID: 35404 RVA: 0x00246A4C File Offset: 0x00244C4C
	public BuildingUpGradeCurve GetBuildingUpGradeCurveByGroupIdAndLevel(int groupId, int level)
	{
		return ConfigBuildingUpGradeCurveByGroupIdAndLevel.GetConfig(groupId, level, true).GetValueOrDefault();
	}

	// Token: 0x06008A4D RID: 35405 RVA: 0x00246A6C File Offset: 0x00244C6C
	public IReadOnlyList<BuildingUpGradeCurve> GetBuildingUpGradeCurveByGroupId(int groupId)
	{
		IReadOnlyList<BuildingUpGradeCurve> configList = ConfigBuildingUpGradeCurveByGroupId.GetConfigList(groupId, true);
		return configList ?? new List<BuildingUpGradeCurve>();
	}
}
