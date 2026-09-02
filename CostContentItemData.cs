using System;

// Token: 0x02002884 RID: 10372
public class CostContentItemData : ICostContentItemData
{
	// Token: 0x17001AC6 RID: 6854
	// (get) Token: 0x06014877 RID: 84087 RVA: 0x005B1D98 File Offset: 0x005AFF98
	// (set) Token: 0x06014878 RID: 84088 RVA: 0x005B1DA0 File Offset: 0x005AFFA0
	public int CostNum { get; set; }

	// Token: 0x17001AC7 RID: 6855
	// (get) Token: 0x06014879 RID: 84089 RVA: 0x005B1DA9 File Offset: 0x005AFFA9
	// (set) Token: 0x0601487A RID: 84090 RVA: 0x005B1DB1 File Offset: 0x005AFFB1
	public EItemId CostType { get; set; }
}
