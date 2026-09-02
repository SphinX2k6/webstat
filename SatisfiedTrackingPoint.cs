using System;
using System.Runtime.CompilerServices;

// Token: 0x020025B4 RID: 9652
[NullableContext(1)]
[Nullable(0)]
public class SatisfiedTrackingPoint : ISatisfiedTrackingPoint
{
	// Token: 0x1700179C RID: 6044
	// (get) Token: 0x06012D61 RID: 77153 RVA: 0x00534EF8 File Offset: 0x005330F8
	// (set) Token: 0x06012D62 RID: 77154 RVA: 0x00534F00 File Offset: 0x00533100
	public Vector Position { get; set; }

	// Token: 0x1700179D RID: 6045
	// (get) Token: 0x06012D63 RID: 77155 RVA: 0x00534F09 File Offset: 0x00533109
	// (set) Token: 0x06012D64 RID: 77156 RVA: 0x00534F11 File Offset: 0x00533111
	public bool IsOptional { get; set; }

	// Token: 0x1700179E RID: 6046
	// (get) Token: 0x06012D65 RID: 77157 RVA: 0x00534F1A File Offset: 0x0053311A
	// (set) Token: 0x06012D66 RID: 77158 RVA: 0x00534F22 File Offset: 0x00533122
	public string Id { get; set; }
}
