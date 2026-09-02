using System;

// Token: 0x02002B73 RID: 11123
public class WeaponEvolveData : IWeaponEvolveData
{
	// Token: 0x17001CD7 RID: 7383
	// (get) Token: 0x06016271 RID: 90737 RVA: 0x00625925 File Offset: 0x00623B25
	// (set) Token: 0x06016272 RID: 90738 RVA: 0x0062592D File Offset: 0x00623B2D
	public int EvolveId { get; set; }

	// Token: 0x17001CD8 RID: 7384
	// (get) Token: 0x06016273 RID: 90739 RVA: 0x00625936 File Offset: 0x00623B36
	// (set) Token: 0x06016274 RID: 90740 RVA: 0x0062593E File Offset: 0x00623B3E
	public bool IsUnlock { get; set; }

	// Token: 0x17001CD9 RID: 7385
	// (get) Token: 0x06016275 RID: 90741 RVA: 0x00625947 File Offset: 0x00623B47
	// (set) Token: 0x06016276 RID: 90742 RVA: 0x0062594F File Offset: 0x00623B4F
	public bool ShowLine { get; set; }
}
