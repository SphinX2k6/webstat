using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x0200117A RID: 4474
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ActivityConfig : ConfigBase<ActivityConfig>
{
	// Token: 0x060075C1 RID: 30145 RVA: 0x001ED275 File Offset: 0x001EB475
	public Activity? GetActivityConfig(int id)
	{
		return ConfigActivityById.GetConfig(id, true);
	}

	// Token: 0x060075C2 RID: 30146 RVA: 0x001ED27E File Offset: 0x001EB47E
	public ActivityFilter? GetActivityFilter(int id)
	{
		return ConfigActivityFilterById.GetConfig(id, true);
	}

	// Token: 0x060075C3 RID: 30147 RVA: 0x001ED287 File Offset: 0x001EB487
	public IReadOnlyList<ActivityFilter> GetAllActivityFilter()
	{
		return ConfigActivityFilterAll.GetConfigList(true);
	}

	// Token: 0x060075C4 RID: 30148 RVA: 0x001ED28F File Offset: 0x001EB48F
	public IReadOnlyList<ActivityPermanentFilter> GetAllActivityPermanentFilter()
	{
		return ConfigActivityPermanentFilterAll.GetConfigList(true);
	}

	// Token: 0x060075C5 RID: 30149 RVA: 0x001ED297 File Offset: 0x001EB497
	public ActivityTitleTags? GetActivityTitleTags(int id)
	{
		return ConfigActivityTitleTagsById.GetConfig(id, true);
	}

	// Token: 0x060075C6 RID: 30150 RVA: 0x001ED2A0 File Offset: 0x001EB4A0
	public ActivityTimeShow? GetActivityTimeShow(int id)
	{
		return ConfigActivityTimeShowById.GetConfig(id, true);
	}

	// Token: 0x060075C7 RID: 30151 RVA: 0x001ED2A9 File Offset: 0x001EB4A9
	public IReadOnlyList<ActivitySplitPak> GetActivitySplitPakAll()
	{
		return ConfigActivitySplitPakAll.GetConfigList(true);
	}

	// Token: 0x060075C8 RID: 30152 RVA: 0x001ED2B4 File Offset: 0x001EB4B4
	[NullableContext(1)]
	public Dictionary<int, string> GetActivityTypeStringMap()
	{
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		IReadOnlyList<ActivitySplitPak> configList = ConfigActivitySplitPakAll.GetConfigList(true);
		if (configList != null)
		{
			foreach (ActivitySplitPak activitySplitPak in configList)
			{
				if (activitySplitPak.ActivityTypeString != null)
				{
					dictionary[activitySplitPak.ActivityType] = activitySplitPak.ActivityTypeString;
				}
			}
		}
		return dictionary;
	}
}
