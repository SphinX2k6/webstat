using System;

// Token: 0x02000FC1 RID: 4033
public class AttributeData : IAttributeData
{
	// Token: 0x1700081B RID: 2075
	// (get) Token: 0x06006763 RID: 26467 RVA: 0x001AFCD2 File Offset: 0x001ADED2
	// (set) Token: 0x06006764 RID: 26468 RVA: 0x001AFCDA File Offset: 0x001ADEDA
	public float Max { get; set; }

	// Token: 0x1700081C RID: 2076
	// (get) Token: 0x06006765 RID: 26469 RVA: 0x001AFCE3 File Offset: 0x001ADEE3
	// (set) Token: 0x06006766 RID: 26470 RVA: 0x001AFCEB File Offset: 0x001ADEEB
	public float BaseMax { get; set; }

	// Token: 0x1700081D RID: 2077
	// (get) Token: 0x06006767 RID: 26471 RVA: 0x001AFCF4 File Offset: 0x001ADEF4
	// (set) Token: 0x06006768 RID: 26472 RVA: 0x001AFCFC File Offset: 0x001ADEFC
	public float Value { get; set; }

	// Token: 0x1700081E RID: 2078
	// (get) Token: 0x06006769 RID: 26473 RVA: 0x001AFD05 File Offset: 0x001ADF05
	// (set) Token: 0x0600676A RID: 26474 RVA: 0x001AFD0D File Offset: 0x001ADF0D
	public float Speed { get; set; }

	// Token: 0x1700081F RID: 2079
	// (get) Token: 0x0600676B RID: 26475 RVA: 0x001AFD16 File Offset: 0x001ADF16
	// (set) Token: 0x0600676C RID: 26476 RVA: 0x001AFD1E File Offset: 0x001ADF1E
	public float BaseSpeed { get; set; }

	// Token: 0x17000820 RID: 2080
	// (get) Token: 0x0600676D RID: 26477 RVA: 0x001AFD27 File Offset: 0x001ADF27
	// (set) Token: 0x0600676E RID: 26478 RVA: 0x001AFD2F File Offset: 0x001ADF2F
	public double Timestamp { get; set; }
}
