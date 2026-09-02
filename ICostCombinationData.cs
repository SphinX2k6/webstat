using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020024A3 RID: 9379
[NullableContext(1)]
public interface ICostCombinationData
{
	// Token: 0x170016EF RID: 5871
	// (get) Token: 0x06012322 RID: 74530
	// (set) Token: 0x06012323 RID: 74531
	int CostId { get; set; }

	// Token: 0x170016F0 RID: 5872
	// (get) Token: 0x06012324 RID: 74532
	// (set) Token: 0x06012325 RID: 74533
	List<int> Costs { get; set; }

	// Token: 0x170016F1 RID: 5873
	// (get) Token: 0x06012326 RID: 74534
	// (set) Token: 0x06012327 RID: 74535
	int Usage { get; set; }
}
