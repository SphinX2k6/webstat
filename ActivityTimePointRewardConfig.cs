using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020015CF RID: 5583
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ActivityTimePointRewardConfig : ConfigBase<ActivityTimePointRewardConfig>
{
	// Token: 0x06009D2B RID: 40235 RVA: 0x0029262D File Offset: 0x0029082D
	public TimePointRewardActivity? GetTimePointRewardById(int id)
	{
		return ConfigTimePointRewardActivityById.GetConfig(id, true);
	}

	// Token: 0x06009D2C RID: 40236 RVA: 0x00292636 File Offset: 0x00290836
	public TimePointRewardConfig? GetConfigByActivityId(int actId)
	{
		return ConfigTimePointRewardConfigByActivityId.GetConfig(actId, true);
	}

	// Token: 0x06009D2D RID: 40237 RVA: 0x0029263F File Offset: 0x0029083F
	public IReadOnlyList<TimePointRewardActivity> GetTimePointRewardListByActivityId(int actId)
	{
		return ConfigTimePointRewardActivityByActivityId.GetConfigList(actId, true);
	}
}
