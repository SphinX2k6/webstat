using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002B92 RID: 11154
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsLevelInfo : ISurvivorsLevelInfo
{
	// Token: 0x17001CFA RID: 7418
	// (get) Token: 0x06016378 RID: 91000 RVA: 0x00629698 File Offset: 0x00627898
	// (set) Token: 0x06016379 RID: 91001 RVA: 0x006296A0 File Offset: 0x006278A0
	public int LevelId { get; set; }

	// Token: 0x17001CFB RID: 7419
	// (get) Token: 0x0601637A RID: 91002 RVA: 0x006296A9 File Offset: 0x006278A9
	// (set) Token: 0x0601637B RID: 91003 RVA: 0x006296B1 File Offset: 0x006278B1
	public long OpenTime { get; set; }

	// Token: 0x17001CFC RID: 7420
	// (get) Token: 0x0601637C RID: 91004 RVA: 0x006296BA File Offset: 0x006278BA
	// (set) Token: 0x0601637D RID: 91005 RVA: 0x006296C2 File Offset: 0x006278C2
	public bool IsEndlessMode { get; set; }

	// Token: 0x17001CFD RID: 7421
	// (get) Token: 0x0601637E RID: 91006 RVA: 0x006296CB File Offset: 0x006278CB
	// (set) Token: 0x0601637F RID: 91007 RVA: 0x006296D3 File Offset: 0x006278D3
	public ModeInfo Info { get; set; }
}
