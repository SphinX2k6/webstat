using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Reward;

// Token: 0x02001486 RID: 5254
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ActivityNoviceJourneyConfig : ConfigBase<ActivityNoviceJourneyConfig>
{
	// Token: 0x06009306 RID: 37638 RVA: 0x0026CEE1 File Offset: 0x0026B0E1
	[NullableContext(2)]
	public NewbieCourse[] GetNoticeJourneyConfigList()
	{
		return ConfigNewbieCourseAll.GetConfigList(true).ToArray<NewbieCourse>();
	}

	// Token: 0x06009307 RID: 37639 RVA: 0x0026CEF0 File Offset: 0x0026B0F0
	public IItemData[] GetRewardList(int dropId)
	{
		DropPackage? dropPackage;
		Dictionary<int, int> dictionary = (ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(dropId) != null) ? dropPackage.GetValueOrDefault().DropPreview() : null;
		List<IItemData> list = new List<IItemData>();
		if (dictionary != null)
		{
			foreach (KeyValuePair<int, int> keyValuePair in dictionary)
			{
				ItemData item = new ItemData
				{
					ItemId = keyValuePair.Key,
					Count = keyValuePair.Value
				};
				list.Add(item);
			}
		}
		return list.ToArray();
	}
}
