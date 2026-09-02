using System;
using System.Runtime.CompilerServices;

// Token: 0x020023F9 RID: 9209
[NullableContext(1)]
public interface IWeekCostData
{
	// Token: 0x17001676 RID: 5750
	// (get) Token: 0x06011D28 RID: 73000
	// (set) Token: 0x06011D29 RID: 73001
	string Tips { get; set; }

	// Token: 0x17001677 RID: 5751
	// (get) Token: 0x06011D2A RID: 73002
	// (set) Token: 0x06011D2B RID: 73003
	int ItemId { get; set; }

	// Token: 0x17001678 RID: 5752
	// (get) Token: 0x06011D2C RID: 73004
	// (set) Token: 0x06011D2D RID: 73005
	int Count { get; set; }
}
