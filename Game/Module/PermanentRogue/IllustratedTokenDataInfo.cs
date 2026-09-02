using System;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x02005658 RID: 22104
	public class IllustratedTokenDataInfo : IIllustratedTokenDataInfo
	{
		// Token: 0x1700908C RID: 37004
		// (get) Token: 0x060385CA RID: 230858 RVA: 0x00E45AA2 File Offset: 0x00E43CA2
		// (set) Token: 0x060385CB RID: 230859 RVA: 0x00E45AAA File Offset: 0x00E43CAA
		public int ConfigId { get; set; }

		// Token: 0x1700908D RID: 37005
		// (get) Token: 0x060385CC RID: 230860 RVA: 0x00E45AB3 File Offset: 0x00E43CB3
		// (set) Token: 0x060385CD RID: 230861 RVA: 0x00E45ABB File Offset: 0x00E43CBB
		public int CollectionIndex { get; set; }

		// Token: 0x1700908E RID: 37006
		// (get) Token: 0x060385CE RID: 230862 RVA: 0x00E45AC4 File Offset: 0x00E43CC4
		// (set) Token: 0x060385CF RID: 230863 RVA: 0x00E45ACC File Offset: 0x00E43CCC
		public bool IsLock { get; set; }

		// Token: 0x1700908F RID: 37007
		// (get) Token: 0x060385D0 RID: 230864 RVA: 0x00E45AD5 File Offset: 0x00E43CD5
		// (set) Token: 0x060385D1 RID: 230865 RVA: 0x00E45ADD File Offset: 0x00E43CDD
		public bool HasRedDot { get; set; }

		// Token: 0x17009090 RID: 37008
		// (get) Token: 0x060385D2 RID: 230866 RVA: 0x00E45AE6 File Offset: 0x00E43CE6
		// (set) Token: 0x060385D3 RID: 230867 RVA: 0x00E45AEE File Offset: 0x00E43CEE
		public bool IsSelectOn { get; set; }
	}
}
