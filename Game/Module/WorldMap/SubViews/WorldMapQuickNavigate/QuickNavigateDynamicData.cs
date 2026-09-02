using System;

namespace CSharpScript.Game.Module.WorldMap.SubViews.WorldMapQuickNavigate
{
	// Token: 0x02004B6A RID: 19306
	public class QuickNavigateDynamicData
	{
		// Token: 0x170086B7 RID: 34487
		// (get) Token: 0x06032710 RID: 206608 RVA: 0x00C9E7CC File Offset: 0x00C9C9CC
		// (set) Token: 0x06032711 RID: 206609 RVA: 0x00C9E7D4 File Offset: 0x00C9C9D4
		public EQuickNavigateItemType ItemType { get; set; }

		// Token: 0x170086B8 RID: 34488
		// (get) Token: 0x06032712 RID: 206610 RVA: 0x00C9E7DD File Offset: 0x00C9C9DD
		// (set) Token: 0x06032713 RID: 206611 RVA: 0x00C9E7E5 File Offset: 0x00C9C9E5
		public int CountryId { get; set; }

		// Token: 0x170086B9 RID: 34489
		// (get) Token: 0x06032714 RID: 206612 RVA: 0x00C9E7EE File Offset: 0x00C9C9EE
		// (set) Token: 0x06032715 RID: 206613 RVA: 0x00C9E7F6 File Offset: 0x00C9C9F6
		public int StateId { get; set; }

		// Token: 0x170086BA RID: 34490
		// (get) Token: 0x06032716 RID: 206614 RVA: 0x00C9E7FF File Offset: 0x00C9C9FF
		// (set) Token: 0x06032717 RID: 206615 RVA: 0x00C9E807 File Offset: 0x00C9CA07
		public int AreaId { get; set; }

		// Token: 0x170086BB RID: 34491
		// (get) Token: 0x06032718 RID: 206616 RVA: 0x00C9E810 File Offset: 0x00C9CA10
		// (set) Token: 0x06032719 RID: 206617 RVA: 0x00C9E818 File Offset: 0x00C9CA18
		public int Index { get; set; }

		// Token: 0x170086BC RID: 34492
		// (get) Token: 0x0603271A RID: 206618 RVA: 0x00C9E821 File Offset: 0x00C9CA21
		// (set) Token: 0x0603271B RID: 206619 RVA: 0x00C9E829 File Offset: 0x00C9CA29
		public bool IsSelected { get; set; }

		// Token: 0x170086BD RID: 34493
		// (get) Token: 0x0603271C RID: 206620 RVA: 0x00C9E832 File Offset: 0x00C9CA32
		// (set) Token: 0x0603271D RID: 206621 RVA: 0x00C9E83A File Offset: 0x00C9CA3A
		public ERefreshNavigateType RefreshType { get; set; }

		// Token: 0x170086BE RID: 34494
		// (get) Token: 0x0603271E RID: 206622 RVA: 0x00C9E843 File Offset: 0x00C9CA43
		// (set) Token: 0x0603271F RID: 206623 RVA: 0x00C9E84B File Offset: 0x00C9CA4B
		public bool HasState { get; set; } = true;

		// Token: 0x170086BF RID: 34495
		// (get) Token: 0x06032720 RID: 206624 RVA: 0x00C9E854 File Offset: 0x00C9CA54
		// (set) Token: 0x06032721 RID: 206625 RVA: 0x00C9E85C File Offset: 0x00C9CA5C
		public bool IsExpand { get; set; }
	}
}
