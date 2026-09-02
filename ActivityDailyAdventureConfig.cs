using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020012C2 RID: 4802
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ActivityDailyAdventureConfig : ConfigBase<ActivityDailyAdventureConfig>
{
	// Token: 0x060080F5 RID: 33013 RVA: 0x002214C0 File Offset: 0x0021F6C0
	public DailyAdventureActivity? GetActivityDailyAdventureConfig(int activityId)
	{
		return ConfigDailyAdventureActivityByActivityId.GetConfig(activityId, true);
	}

	// Token: 0x060080F6 RID: 33014 RVA: 0x002214C9 File Offset: 0x0021F6C9
	public DailyAdventureTask? GetDailyAdventureTaskConfig(int taskId)
	{
		return ConfigDailyAdventureTaskByTaskId.GetConfig(taskId, true);
	}

	// Token: 0x060080F7 RID: 33015 RVA: 0x002214D2 File Offset: 0x0021F6D2
	public DailyAdventurePoint? GetDailyAdventurePointConfig(int id)
	{
		return ConfigDailyAdventurePointById.GetConfig(id, true);
	}
}
