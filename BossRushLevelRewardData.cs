using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001275 RID: 4725
public class BossRushLevelRewardData
{
	// Token: 0x04003C90 RID: 15504
	[Nullable(2)]
	public BossRushLevelDetailInfo LevelInfo;

	// Token: 0x04003C91 RID: 15505
	[Nullable(1)]
	public List<IActivityRewardData> RewardInfo = new List<IActivityRewardData>();
}
