using System;

// Token: 0x02000FC0 RID: 4032
public interface IAttributeData
{
	// Token: 0x17000815 RID: 2069
	// (get) Token: 0x06006757 RID: 26455
	// (set) Token: 0x06006758 RID: 26456
	float Max { get; set; }

	// Token: 0x17000816 RID: 2070
	// (get) Token: 0x06006759 RID: 26457
	// (set) Token: 0x0600675A RID: 26458
	float BaseMax { get; set; }

	// Token: 0x17000817 RID: 2071
	// (get) Token: 0x0600675B RID: 26459
	// (set) Token: 0x0600675C RID: 26460
	float Value { get; set; }

	// Token: 0x17000818 RID: 2072
	// (get) Token: 0x0600675D RID: 26461
	// (set) Token: 0x0600675E RID: 26462
	float Speed { get; set; }

	// Token: 0x17000819 RID: 2073
	// (get) Token: 0x0600675F RID: 26463
	// (set) Token: 0x06006760 RID: 26464
	float BaseSpeed { get; set; }

	// Token: 0x1700081A RID: 2074
	// (get) Token: 0x06006761 RID: 26465
	// (set) Token: 0x06006762 RID: 26466
	double Timestamp { get; set; }
}
