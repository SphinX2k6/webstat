using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001399 RID: 5017
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ActivityMoonChasingConfig : ConfigBase<ActivityMoonChasingConfig>
{
	// Token: 0x06008A11 RID: 35345 RVA: 0x0024597E File Offset: 0x00243B7E
	public TrackMoonActivity? GetActivityMoonChasingConfig(int activityId)
	{
		return ConfigTrackMoonActivityById.GetConfig(activityId, true);
	}

	// Token: 0x06008A12 RID: 35346 RVA: 0x00245987 File Offset: 0x00243B87
	public IReadOnlyList<TrackMoonActivityReward> GetAllActivityMoonChasingRewardConfig()
	{
		return ConfigTrackMoonActivityRewardAll.GetConfigList(true) ?? new List<TrackMoonActivityReward>();
	}

	// Token: 0x06008A13 RID: 35347 RVA: 0x00245998 File Offset: 0x00243B98
	public TrackMoonActivityReward? GetActivityMoonChasingRewardConfigById(int id)
	{
		return ConfigTrackMoonActivityRewardById.GetConfig(id, true);
	}
}
