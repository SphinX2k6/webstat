using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020013ED RID: 5101
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class MoonChasingHandbookConfig : ConfigBase<MoonChasingHandbookConfig>
{
	// Token: 0x06008D6C RID: 36204 RVA: 0x0025317C File Offset: 0x0025137C
	public TrackMoonHandbookReward? GetHandbookRewardById(int rewardId)
	{
		return ConfigTrackMoonHandbookRewardById.GetConfig(rewardId, true);
	}

	// Token: 0x06008D6D RID: 36205 RVA: 0x00253185 File Offset: 0x00251385
	public IReadOnlyList<TrackMoonHandbookReward> GetHandbookRewardList()
	{
		return ConfigTrackMoonHandbookRewardAll.GetConfigList(true) ?? new List<TrackMoonHandbookReward>();
	}
}
