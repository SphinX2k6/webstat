using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001F7E RID: 8062
[NullableContext(1)]
public interface IHonamiStorySettleSuccessViewParams
{
	// Token: 0x17001279 RID: 4729
	// (get) Token: 0x0600F198 RID: 61848
	List<IHonamiStorySettleItemParams> DisplayItems { get; }

	// Token: 0x1700127A RID: 4730
	// (get) Token: 0x0600F199 RID: 61849
	int TotalReward { get; }

	// Token: 0x1700127B RID: 4731
	// (get) Token: 0x0600F19A RID: 61850
	bool IsNewRecord { get; }
}
