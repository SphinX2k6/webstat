using System;
using System.Runtime.CompilerServices;

// Token: 0x020023FD RID: 9213
[NullableContext(1)]
public interface IWeekScoreData
{
	// Token: 0x17001680 RID: 5760
	// (get) Token: 0x06011D3E RID: 73022
	// (set) Token: 0x06011D3F RID: 73023
	string Tips { get; set; }

	// Token: 0x17001681 RID: 5761
	// (get) Token: 0x06011D40 RID: 73024
	// (set) Token: 0x06011D41 RID: 73025
	string IconPath { get; set; }

	// Token: 0x17001682 RID: 5762
	// (get) Token: 0x06011D42 RID: 73026
	// (set) Token: 0x06011D43 RID: 73027
	int Count { get; set; }
}
