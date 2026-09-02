using System;
using System.Runtime.CompilerServices;

// Token: 0x020025B3 RID: 9651
[NullableContext(1)]
public interface ISatisfiedTrackingPoint
{
	// Token: 0x17001799 RID: 6041
	// (get) Token: 0x06012D5B RID: 77147
	// (set) Token: 0x06012D5C RID: 77148
	Vector Position { get; set; }

	// Token: 0x1700179A RID: 6042
	// (get) Token: 0x06012D5D RID: 77149
	// (set) Token: 0x06012D5E RID: 77150
	bool IsOptional { get; set; }

	// Token: 0x1700179B RID: 6043
	// (get) Token: 0x06012D5F RID: 77151
	// (set) Token: 0x06012D60 RID: 77152
	string Id { get; set; }
}
