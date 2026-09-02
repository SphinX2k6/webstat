using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x0200114D RID: 4429
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ActivityRecommendConfig : ConfigBase<ActivityRecommendConfig>
{
	// Token: 0x060074BE RID: 29886 RVA: 0x001E9FD5 File Offset: 0x001E81D5
	public ActivityRecommend? GetRecommend(int id)
	{
		return ConfigActivityRecommendById.GetConfig(id, true);
	}

	// Token: 0x060074BF RID: 29887 RVA: 0x001E9FE0 File Offset: 0x001E81E0
	public List<ActivityRecommend> GetRecommendByType(EActivityRecommendType type)
	{
		IEnumerable<ActivityRecommend> enumerable = ConfigActivityRecommendAll.GetConfigList(true) ?? new List<ActivityRecommend>();
		List<ActivityRecommend> list = new List<ActivityRecommend>();
		foreach (ActivityRecommend item in enumerable)
		{
			if (item.Type == (int)type)
			{
				list.Add(item);
			}
		}
		return list;
	}

	// Token: 0x060074C0 RID: 29888 RVA: 0x001EA048 File Offset: 0x001E8248
	public IReadOnlyList<ActivityRecommend> GetRecommendListByGroup(int groupId)
	{
		return ConfigActivityRecommendByActivityGroup.GetConfigList(groupId, true) ?? new List<ActivityRecommend>();
	}

	// Token: 0x060074C1 RID: 29889 RVA: 0x001EA05C File Offset: 0x001E825C
	public int GetCurrentGroupId()
	{
		if (ConfigActivityRecommendCurrentById.GetConfig(1, true) == null)
		{
			return 0;
		}
		ActivityRecommendCurrent? activityRecommendCurrent;
		return activityRecommendCurrent.GetValueOrDefault().ActivityGroup;
	}

	// Token: 0x060074C2 RID: 29890 RVA: 0x001EA08B File Offset: 0x001E828B
	public ActivityRecommendCurrent? GetCurrentRecord(int id)
	{
		return ConfigActivityRecommendCurrentById.GetConfig(id, true);
	}
}
