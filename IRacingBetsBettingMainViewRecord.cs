using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200270D RID: 9997
[NullableContext(1)]
public interface IRacingBetsBettingMainViewRecord
{
	// Token: 0x1700194A RID: 6474
	// (get) Token: 0x06013B9D RID: 80797
	// (set) Token: 0x06013B9E RID: 80798
	int SeasonId { get; set; }

	// Token: 0x1700194B RID: 6475
	// (get) Token: 0x06013B9F RID: 80799
	// (set) Token: 0x06013BA0 RID: 80800
	List<int> EnteredLegMatchIds { get; set; }
}
