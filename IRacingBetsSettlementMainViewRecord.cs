using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200270B RID: 9995
[NullableContext(1)]
public interface IRacingBetsSettlementMainViewRecord
{
	// Token: 0x17001946 RID: 6470
	// (get) Token: 0x06013B94 RID: 80788
	// (set) Token: 0x06013B95 RID: 80789
	int SeasonId { get; set; }

	// Token: 0x17001947 RID: 6471
	// (get) Token: 0x06013B96 RID: 80790
	// (set) Token: 0x06013B97 RID: 80791
	List<int> ViewedLegMatchIds { get; set; }
}
