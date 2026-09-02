using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Reward;

// Token: 0x02001449 RID: 5193
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ActivityNewbieCourseV2Config : ConfigBase<ActivityNewbieCourseV2Config>
{
	// Token: 0x0600908F RID: 37007 RVA: 0x0026010C File Offset: 0x0025E30C
	public IReadOnlyList<NewbieCourseV2> GetConfigList(int activityId = 0)
	{
		IReadOnlyList<NewbieCourseV2> configList = ConfigNewbieCourseV2All.GetConfigList(true);
		List<NewbieCourseV2> list = ((configList != null) ? configList.ToList<NewbieCourseV2>() : null) ?? new List<NewbieCourseV2>();
		if (activityId > 0)
		{
			List<NewbieCourseV2> list2 = (from config in list
			where config.ActivityId == activityId
			select config).ToList<NewbieCourseV2>();
			list = ((list2.Count > 0) ? list2 : list);
		}
		return (from config in list
		orderby config.TargetLevel, config.Id
		select config).ToList<NewbieCourseV2>();
	}

	// Token: 0x06009090 RID: 37008 RVA: 0x002601C0 File Offset: 0x0025E3C0
	public ItemData[] GetRewardList(int dropId)
	{
		DropPackage? dropPackage;
		Dictionary<int, int> dictionary = (ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(dropId) != null) ? dropPackage.GetValueOrDefault().DropPreview() : null;
		List<ItemData> list = new List<ItemData>();
		if (dictionary == null)
		{
			return list.ToArray();
		}
		foreach (KeyValuePair<int, int> keyValuePair in dictionary)
		{
			ItemData item = new ItemData
			{
				ItemId = keyValuePair.Key,
				Count = keyValuePair.Value
			};
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x06009091 RID: 37009 RVA: 0x00260270 File Offset: 0x0025E470
	public int[] GetWeaponPreviewIdsForActivity(int activityId)
	{
		List<int> list = new List<int>();
		foreach (NewbieCourseV2 config in this.GetConfigList(activityId))
		{
			foreach (int item in ActivityNewbieCourseV2Config.ReadWeaponPreviewList(config))
			{
				list.Add(item);
			}
		}
		return list.ToArray();
	}

	// Token: 0x06009092 RID: 37010 RVA: 0x00260300 File Offset: 0x0025E500
	private static IEnumerable<int> ReadWeaponPreviewList(NewbieCourseV2 config)
	{
		ActivityNewbieCourseV2Config.<ReadWeaponPreviewList>d__3 <ReadWeaponPreviewList>d__ = new ActivityNewbieCourseV2Config.<ReadWeaponPreviewList>d__3(-2);
		<ReadWeaponPreviewList>d__.<>3__config = config;
		return <ReadWeaponPreviewList>d__;
	}
}
