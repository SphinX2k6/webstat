using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x0200140E RID: 5134
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class MoonChasingRewardConfig : ConfigBase<MoonChasingRewardConfig>
{
	// Token: 0x06008E4F RID: 36431 RVA: 0x00256364 File Offset: 0x00254564
	public IReadOnlyList<TrackMoonTargetType> GetAllRewardTargetTypeList()
	{
		return ConfigTrackMoonTargetTypeAll.GetConfigList(true);
	}

	// Token: 0x06008E50 RID: 36432 RVA: 0x0025636C File Offset: 0x0025456C
	public TrackMoonTarget GetRewardTargetById(int id)
	{
		return ConfigTrackMoonTargetById.GetConfig(id, true).Value;
	}
}
