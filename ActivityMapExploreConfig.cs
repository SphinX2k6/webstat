using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001375 RID: 4981
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ActivityMapExploreConfig : ConfigBase<ActivityMapExploreConfig>
{
	// Token: 0x06008885 RID: 34949 RVA: 0x0024011A File Offset: 0x0023E31A
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x06008886 RID: 34950 RVA: 0x0024011D File Offset: 0x0023E31D
	protected override bool OnClear()
	{
		return true;
	}

	// Token: 0x06008887 RID: 34951 RVA: 0x00240120 File Offset: 0x0023E320
	public IReadOnlyList<ExploreActivityTask> GetExploreTaskList(int activityId)
	{
		IReadOnlyList<ExploreActivityTask> configList = ConfigExploreActivityTaskByActivityId.GetConfigList(activityId, true);
		return configList ?? new List<ExploreActivityTask>();
	}

	// Token: 0x06008888 RID: 34952 RVA: 0x0024013F File Offset: 0x0023E33F
	public ExploreActivity? GetActivityInfo(int activityId)
	{
		return ConfigExploreActivityById.GetConfig(activityId, true);
	}
}
