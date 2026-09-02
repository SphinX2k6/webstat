using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020015E9 RID: 5609
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ActivityTurntableConfig : ConfigBase<ActivityTurntableConfig>
{
	// Token: 0x06009E11 RID: 40465 RVA: 0x00296215 File Offset: 0x00294415
	public IReadOnlyList<TurntableAwards> GetTurntableAwardsByActivityId(int activityId)
	{
		return ConfigTurntableAwardsByActivityId.GetConfigList(activityId, true) ?? Array.Empty<TurntableAwards>();
	}

	// Token: 0x06009E12 RID: 40466 RVA: 0x00296227 File Offset: 0x00294427
	public TurntableInfo? GetTurntableInfoByActivityId(int activityId)
	{
		return ConfigTurntableInfoById.GetConfig(activityId, true);
	}

	// Token: 0x06009E13 RID: 40467 RVA: 0x00296230 File Offset: 0x00294430
	public IReadOnlyList<TurntableActivity> GetTurntableActivityByActivityId(int activityId)
	{
		return ConfigTurntableActivityByActivityId.GetConfigList(activityId, true) ?? Array.Empty<TurntableActivity>();
	}

	// Token: 0x06009E14 RID: 40468 RVA: 0x00296242 File Offset: 0x00294442
	public TurntableTask? GetTurntableTaskByTaskId(int taskId)
	{
		return ConfigTurntableTaskByTaskId.GetConfig(taskId, true);
	}
}
