using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001431 RID: 5169
public class MowingTowerLevelRewardData
{
	// Token: 0x040042B2 RID: 17074
	[Nullable(2)]
	public MowingTowerLevelDetailInfo LevelInfo;

	// Token: 0x040042B3 RID: 17075
	[Nullable(1)]
	public List<IActivityRewardData> RewardInfo = new List<IActivityRewardData>();
}
