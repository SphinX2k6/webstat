using System;
using System.Runtime.CompilerServices;

// Token: 0x020012E8 RID: 4840
[NullableContext(1)]
public interface IDangoMonopolyRoundBuffData
{
	// Token: 0x17000AFB RID: 2811
	// (get) Token: 0x06008310 RID: 33552
	int DangoId { get; }

	// Token: 0x17000AFC RID: 2812
	// (get) Token: 0x06008311 RID: 33553
	int PropertyId { get; }

	// Token: 0x17000AFD RID: 2813
	// (get) Token: 0x06008312 RID: 33554
	int GridId { get; }

	// Token: 0x17000AFE RID: 2814
	// (get) Token: 0x06008313 RID: 33555
	bool IsActive { get; }

	// Token: 0x17000AFF RID: 2815
	// (get) Token: 0x06008314 RID: 33556
	string DangoIcon { get; }

	// Token: 0x17000B00 RID: 2816
	// (get) Token: 0x06008315 RID: 33557
	string DangoName { get; }

	// Token: 0x17000B01 RID: 2817
	// (get) Token: 0x06008316 RID: 33558
	string PropertyDesc { get; }

	// Token: 0x17000B02 RID: 2818
	// (get) Token: 0x06008317 RID: 33559
	string PropertyTitle { get; }
}
