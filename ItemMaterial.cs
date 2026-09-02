using System;

// Token: 0x020027E9 RID: 10217
public class ItemMaterial : IItemMaterial
{
	// Token: 0x170019BB RID: 6587
	// (get) Token: 0x060142D2 RID: 82642 RVA: 0x005A0AE2 File Offset: 0x0059ECE2
	// (set) Token: 0x060142D3 RID: 82643 RVA: 0x005A0AEA File Offset: 0x0059ECEA
	public int ItemId { get; set; }

	// Token: 0x170019BC RID: 6588
	// (get) Token: 0x060142D4 RID: 82644 RVA: 0x005A0AF3 File Offset: 0x0059ECF3
	// (set) Token: 0x060142D5 RID: 82645 RVA: 0x005A0AFB File Offset: 0x0059ECFB
	public int RequiredCount { get; set; }
}
