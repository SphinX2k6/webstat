using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020025D5 RID: 9685
[NullableContext(1)]
public interface IPositionData
{
	// Token: 0x170017BC RID: 6076
	// (get) Token: 0x06012EF6 RID: 77558
	// (set) Token: 0x06012EF7 RID: 77559
	string Id { get; set; }

	// Token: 0x170017BD RID: 6077
	// (get) Token: 0x06012EF8 RID: 77560
	// (set) Token: 0x06012EF9 RID: 77561
	FVector2D Vector { get; set; }

	// Token: 0x170017BE RID: 6078
	// (get) Token: 0x06012EFA RID: 77562
	// (set) Token: 0x06012EFB RID: 77563
	bool NotShow { get; set; }

	// Token: 0x170017BF RID: 6079
	// (get) Token: 0x06012EFC RID: 77564
	// (set) Token: 0x06012EFD RID: 77565
	bool IsOptional { get; set; }

	// Token: 0x170017C0 RID: 6080
	// (get) Token: 0x06012EFE RID: 77566
	// (set) Token: 0x06012EFF RID: 77567
	bool IsOptionalFinished { get; set; }
}
