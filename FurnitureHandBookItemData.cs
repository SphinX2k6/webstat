using System;
using Aki.Config;

// Token: 0x02001095 RID: 4245
public class FurnitureHandBookItemData : IFurnitureHandBookItemData
{
	// Token: 0x170008FF RID: 2303
	// (get) Token: 0x06006EB6 RID: 28342 RVA: 0x001CCE98 File Offset: 0x001CB098
	// (set) Token: 0x06006EB7 RID: 28343 RVA: 0x001CCEA0 File Offset: 0x001CB0A0
	public Furniture FurnitureConfig { get; set; }

	// Token: 0x17000900 RID: 2304
	// (get) Token: 0x06006EB8 RID: 28344 RVA: 0x001CCEA9 File Offset: 0x001CB0A9
	// (set) Token: 0x06006EB9 RID: 28345 RVA: 0x001CCEB1 File Offset: 0x001CB0B1
	public bool IsLock { get; set; }

	// Token: 0x17000901 RID: 2305
	// (get) Token: 0x06006EBA RID: 28346 RVA: 0x001CCEBA File Offset: 0x001CB0BA
	// (set) Token: 0x06006EBB RID: 28347 RVA: 0x001CCEC2 File Offset: 0x001CB0C2
	public bool RedDotVisible { get; set; }
}
