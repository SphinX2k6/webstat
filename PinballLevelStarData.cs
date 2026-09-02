using System;
using System.Runtime.CompilerServices;

// Token: 0x020014A8 RID: 5288
[NullableContext(2)]
[Nullable(0)]
public class PinballLevelStarData : IPinballLevelStarData
{
	// Token: 0x17000C54 RID: 3156
	// (get) Token: 0x0600942C RID: 37932 RVA: 0x002703DE File Offset: 0x0026E5DE
	// (set) Token: 0x0600942D RID: 37933 RVA: 0x002703E6 File Offset: 0x0026E5E6
	public int ConditionId { get; set; }

	// Token: 0x17000C55 RID: 3157
	// (get) Token: 0x0600942E RID: 37934 RVA: 0x002703EF File Offset: 0x0026E5EF
	// (set) Token: 0x0600942F RID: 37935 RVA: 0x002703F7 File Offset: 0x0026E5F7
	public bool Passed { get; set; }

	// Token: 0x17000C56 RID: 3158
	// (get) Token: 0x06009430 RID: 37936 RVA: 0x00270400 File Offset: 0x0026E600
	// (set) Token: 0x06009431 RID: 37937 RVA: 0x00270408 File Offset: 0x0026E608
	public string ConfigConditionDesc { get; set; }

	// Token: 0x17000C57 RID: 3159
	// (get) Token: 0x06009432 RID: 37938 RVA: 0x00270411 File Offset: 0x0026E611
	// (set) Token: 0x06009433 RID: 37939 RVA: 0x00270419 File Offset: 0x0026E619
	public int? ConfigTargetValue { get; set; }
}
