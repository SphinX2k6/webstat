using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020025D6 RID: 9686
[NullableContext(1)]
[Nullable(0)]
public class PositionData : IPositionData
{
	// Token: 0x170017C1 RID: 6081
	// (get) Token: 0x06012F00 RID: 77568 RVA: 0x0053CCC3 File Offset: 0x0053AEC3
	// (set) Token: 0x06012F01 RID: 77569 RVA: 0x0053CCCB File Offset: 0x0053AECB
	public string Id { get; set; } = "";

	// Token: 0x170017C2 RID: 6082
	// (get) Token: 0x06012F02 RID: 77570 RVA: 0x0053CCD4 File Offset: 0x0053AED4
	// (set) Token: 0x06012F03 RID: 77571 RVA: 0x0053CCDC File Offset: 0x0053AEDC
	public FVector2D Vector { get; set; } = new FVector2D(0f, 0f);

	// Token: 0x170017C3 RID: 6083
	// (get) Token: 0x06012F04 RID: 77572 RVA: 0x0053CCE5 File Offset: 0x0053AEE5
	// (set) Token: 0x06012F05 RID: 77573 RVA: 0x0053CCED File Offset: 0x0053AEED
	public bool NotShow { get; set; }

	// Token: 0x170017C4 RID: 6084
	// (get) Token: 0x06012F06 RID: 77574 RVA: 0x0053CCF6 File Offset: 0x0053AEF6
	// (set) Token: 0x06012F07 RID: 77575 RVA: 0x0053CCFE File Offset: 0x0053AEFE
	public bool IsOptional { get; set; }

	// Token: 0x170017C5 RID: 6085
	// (get) Token: 0x06012F08 RID: 77576 RVA: 0x0053CD07 File Offset: 0x0053AF07
	// (set) Token: 0x06012F09 RID: 77577 RVA: 0x0053CD0F File Offset: 0x0053AF0F
	public bool IsOptionalFinished { get; set; }
}
