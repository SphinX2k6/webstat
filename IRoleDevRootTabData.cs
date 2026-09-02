using System;
using System.Runtime.CompilerServices;

// Token: 0x020027E6 RID: 10214
[NullableContext(1)]
public interface IRoleDevRootTabData
{
	// Token: 0x170019B1 RID: 6577
	// (get) Token: 0x060142BD RID: 82621
	// (set) Token: 0x060142BE RID: 82622
	ERoleDevTabType TabIndex { get; set; }

	// Token: 0x170019B2 RID: 6578
	// (get) Token: 0x060142BF RID: 82623
	// (set) Token: 0x060142C0 RID: 82624
	string TabName { get; set; }

	// Token: 0x170019B3 RID: 6579
	// (get) Token: 0x060142C1 RID: 82625
	// (set) Token: 0x060142C2 RID: 82626
	bool TabIsUpgrade { get; set; }

	// Token: 0x170019B4 RID: 6580
	// (get) Token: 0x060142C3 RID: 82627
	// (set) Token: 0x060142C4 RID: 82628
	bool TabIsFinish { get; set; }
}
