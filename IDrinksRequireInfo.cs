using System;

// Token: 0x02000FFB RID: 4091
public interface IDrinksRequireInfo
{
	// Token: 0x17000832 RID: 2098
	// (get) Token: 0x06006A25 RID: 27173
	// (set) Token: 0x06006A26 RID: 27174
	int RequireId { get; set; }

	// Token: 0x17000833 RID: 2099
	// (get) Token: 0x06006A27 RID: 27175
	// (set) Token: 0x06006A28 RID: 27176
	EDrinksRequireType Type { get; set; }

	// Token: 0x17000834 RID: 2100
	// (get) Token: 0x06006A29 RID: 27177
	// (set) Token: 0x06006A2A RID: 27178
	int? FlavorRangeId { get; set; }

	// Token: 0x17000835 RID: 2101
	// (get) Token: 0x06006A2B RID: 27179
	// (set) Token: 0x06006A2C RID: 27180
	bool Completed { get; set; }
}
