using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001CBC RID: 7356
public class GachaAccumulateGroupData
{
	// Token: 0x040066CA RID: 26314
	public int GroupId;

	// Token: 0x040066CB RID: 26315
	public int CurGachaNum;

	// Token: 0x040066CC RID: 26316
	[Nullable(1)]
	public List<GachaAccumulateRewardData> RewardInfos = new List<GachaAccumulateRewardData>();
}
