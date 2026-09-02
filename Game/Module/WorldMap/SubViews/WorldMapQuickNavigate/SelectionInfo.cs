using System;

namespace CSharpScript.Game.Module.WorldMap.SubViews.WorldMapQuickNavigate
{
	// Token: 0x02004B74 RID: 19316
	public class SelectionInfo : ISelectionInfo
	{
		// Token: 0x170086C6 RID: 34502
		// (get) Token: 0x0603274F RID: 206671 RVA: 0x00C9F269 File Offset: 0x00C9D469
		// (set) Token: 0x06032750 RID: 206672 RVA: 0x00C9F271 File Offset: 0x00C9D471
		public int FirstIndex { get; set; }

		// Token: 0x170086C7 RID: 34503
		// (get) Token: 0x06032751 RID: 206673 RVA: 0x00C9F27A File Offset: 0x00C9D47A
		// (set) Token: 0x06032752 RID: 206674 RVA: 0x00C9F282 File Offset: 0x00C9D482
		public int SecondIndex { get; set; }

		// Token: 0x170086C8 RID: 34504
		// (get) Token: 0x06032753 RID: 206675 RVA: 0x00C9F28B File Offset: 0x00C9D48B
		// (set) Token: 0x06032754 RID: 206676 RVA: 0x00C9F293 File Offset: 0x00C9D493
		public int CountryId { get; set; }

		// Token: 0x170086C9 RID: 34505
		// (get) Token: 0x06032755 RID: 206677 RVA: 0x00C9F29C File Offset: 0x00C9D49C
		// (set) Token: 0x06032756 RID: 206678 RVA: 0x00C9F2A4 File Offset: 0x00C9D4A4
		public bool ExpandCountry { get; set; }

		// Token: 0x170086CA RID: 34506
		// (get) Token: 0x06032757 RID: 206679 RVA: 0x00C9F2AD File Offset: 0x00C9D4AD
		// (set) Token: 0x06032758 RID: 206680 RVA: 0x00C9F2B5 File Offset: 0x00C9D4B5
		public int StateId { get; set; }

		// Token: 0x170086CB RID: 34507
		// (get) Token: 0x06032759 RID: 206681 RVA: 0x00C9F2BE File Offset: 0x00C9D4BE
		// (set) Token: 0x0603275A RID: 206682 RVA: 0x00C9F2C6 File Offset: 0x00C9D4C6
		public int AreaId { get; set; }
	}
}
