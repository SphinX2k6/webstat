using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020020C1 RID: 8385
[NullableContext(1)]
[Nullable(0)]
public class NightmareKillInfo
{
	// Token: 0x0601003F RID: 65599 RVA: 0x00466545 File Offset: 0x00464745
	public NightmareKillInfo()
	{
	}

	// Token: 0x06010040 RID: 65600 RVA: 0x00466558 File Offset: 0x00464758
	public NightmareKillInfo(bool enable, int currentKillCount, int currentIntervalIndex, List<int> intervalKillNumber)
	{
		this.Enable = enable;
		this.CurrentKillCount = currentKillCount;
		this.CurrentIntervalIndex = currentIntervalIndex;
		this.IntervalKillNumber = intervalKillNumber;
	}

	// Token: 0x04007AD6 RID: 31446
	public bool Enable;

	// Token: 0x04007AD7 RID: 31447
	public int CurrentKillCount;

	// Token: 0x04007AD8 RID: 31448
	public int CurrentIntervalIndex;

	// Token: 0x04007AD9 RID: 31449
	public List<int> IntervalKillNumber = new List<int>();
}
