using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001711 RID: 5905
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class WuWuLogisticsConfig : ConfigBase<WuWuLogisticsConfig>
{
	// Token: 0x0600A43C RID: 42044 RVA: 0x002B6D85 File Offset: 0x002B4F85
	public IReadOnlyList<WuWuLogisticsDesc> GetDescListByGroupId(int groupId)
	{
		return ConfigWuWuLogisticsDescByGroupId.GetConfigList(groupId, true);
	}

	// Token: 0x0600A43D RID: 42045 RVA: 0x002B6D8E File Offset: 0x002B4F8E
	public WuWuLogisticsDesc? GetDescById(int id)
	{
		return ConfigWuWuLogisticsDescById.GetConfig(id, true);
	}

	// Token: 0x0600A43E RID: 42046 RVA: 0x002B6D97 File Offset: 0x002B4F97
	public WuWuTaskPackage? GetTaskPackageById(int id)
	{
		return ConfigWuWuTaskPackageById.GetConfig(id, true);
	}

	// Token: 0x0600A43F RID: 42047 RVA: 0x002B6DA0 File Offset: 0x002B4FA0
	public IReadOnlyList<WuWuTaskPackage> GetAllTaskPackage()
	{
		return ConfigWuWuTaskPackageAll.GetConfigList(true);
	}

	// Token: 0x0600A440 RID: 42048 RVA: 0x002B6DA8 File Offset: 0x002B4FA8
	public WuWuWeekTask? GetWeekTaskById(int id)
	{
		return ConfigWuWuWeekTaskById.GetConfig(id, true);
	}

	// Token: 0x0600A441 RID: 42049 RVA: 0x002B6DB1 File Offset: 0x002B4FB1
	public IReadOnlyList<WuWuWeekTask> GetWeekTaskByWrapId(int wrapId)
	{
		return ConfigWuWuWeekTaskByWrapId.GetConfigList(wrapId, true);
	}
}
