using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001A94 RID: 6804
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class DailyActivityConfig : ConfigBase<DailyActivityConfig>
{
	// Token: 0x0600C2E6 RID: 49894 RVA: 0x00335CA5 File Offset: 0x00333EA5
	[NullableContext(2)]
	public IReadOnlyList<Liveness> GetAllActivityGoalData()
	{
		return ConfigLivenessAll.GetConfigList(true);
	}

	// Token: 0x0600C2E7 RID: 49895 RVA: 0x00335CB0 File Offset: 0x00333EB0
	public LivenessTask? GetActivityTaskConfigById(int taskId)
	{
		return new LivenessTask?(ConfigLivenessTaskByTaskId.GetConfig(taskId, true).Value);
	}

	// Token: 0x0600C2E8 RID: 49896 RVA: 0x00335CD4 File Offset: 0x00333ED4
	public Dictionary<int, int> GetDropShowInfo(int id)
	{
		return ConfigDropPackageById.GetConfig(id, true).Value.DropPreview();
	}
}
