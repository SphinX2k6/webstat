using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001B8D RID: 7053
[NullableContext(1)]
public interface IMapAreaRewardParam
{
	// Token: 0x17001091 RID: 4241
	// (get) Token: 0x0600CD02 RID: 52482
	int InitValue { get; }

	// Token: 0x17001092 RID: 4242
	// (get) Token: 0x0600CD03 RID: 52483
	int MaxValue { get; }

	// Token: 0x17001093 RID: 4243
	// (get) Token: 0x0600CD04 RID: 52484
	List<DailyActivityDefine.IActivityGoalData> RewardDataList { get; }

	// Token: 0x17001094 RID: 4244
	// (get) Token: 0x0600CD05 RID: 52485
	Action GetRewardCallback { get; }
}
