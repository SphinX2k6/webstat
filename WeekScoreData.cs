using System;
using System.Runtime.CompilerServices;

// Token: 0x020023FE RID: 9214
[NullableContext(1)]
[Nullable(0)]
public class WeekScoreData : IWeekScoreData
{
	// Token: 0x17001683 RID: 5763
	// (get) Token: 0x06011D44 RID: 73028 RVA: 0x004E744A File Offset: 0x004E564A
	// (set) Token: 0x06011D45 RID: 73029 RVA: 0x004E7452 File Offset: 0x004E5652
	public string Tips { get; set; }

	// Token: 0x17001684 RID: 5764
	// (get) Token: 0x06011D46 RID: 73030 RVA: 0x004E745B File Offset: 0x004E565B
	// (set) Token: 0x06011D47 RID: 73031 RVA: 0x004E7463 File Offset: 0x004E5663
	public string IconPath { get; set; }

	// Token: 0x17001685 RID: 5765
	// (get) Token: 0x06011D48 RID: 73032 RVA: 0x004E746C File Offset: 0x004E566C
	// (set) Token: 0x06011D49 RID: 73033 RVA: 0x004E7474 File Offset: 0x004E5674
	public int Count { get; set; }
}
