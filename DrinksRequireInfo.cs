using System;

// Token: 0x02000FFC RID: 4092
public class DrinksRequireInfo : IDrinksRequireInfo
{
	// Token: 0x17000836 RID: 2102
	// (get) Token: 0x06006A2D RID: 27181 RVA: 0x001BB960 File Offset: 0x001B9B60
	// (set) Token: 0x06006A2E RID: 27182 RVA: 0x001BB968 File Offset: 0x001B9B68
	public int RequireId { get; set; }

	// Token: 0x17000837 RID: 2103
	// (get) Token: 0x06006A2F RID: 27183 RVA: 0x001BB971 File Offset: 0x001B9B71
	// (set) Token: 0x06006A30 RID: 27184 RVA: 0x001BB979 File Offset: 0x001B9B79
	public EDrinksRequireType Type { get; set; }

	// Token: 0x17000838 RID: 2104
	// (get) Token: 0x06006A31 RID: 27185 RVA: 0x001BB982 File Offset: 0x001B9B82
	// (set) Token: 0x06006A32 RID: 27186 RVA: 0x001BB98A File Offset: 0x001B9B8A
	public int? FlavorRangeId { get; set; }

	// Token: 0x17000839 RID: 2105
	// (get) Token: 0x06006A33 RID: 27187 RVA: 0x001BB993 File Offset: 0x001B9B93
	// (set) Token: 0x06006A34 RID: 27188 RVA: 0x001BB99B File Offset: 0x001B9B9B
	public bool Completed { get; set; }
}
