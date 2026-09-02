using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001F78 RID: 8056
[NullableContext(1)]
public interface IHonamiStorySettleFailViewParams
{
	// Token: 0x1700126D RID: 4717
	// (get) Token: 0x0600F177 RID: 61815
	List<IHonamiStorySettleItemParams> DisplayItems { get; }

	// Token: 0x1700126E RID: 4718
	// (get) Token: 0x0600F178 RID: 61816
	int TotalReward { get; }

	// Token: 0x1700126F RID: 4719
	// (get) Token: 0x0600F179 RID: 61817
	bool IsNewRecord { get; }

	// Token: 0x17001270 RID: 4720
	// (get) Token: 0x0600F17A RID: 61818
	int FailAddProportion { get; }
}
