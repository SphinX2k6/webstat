using System;

namespace CSharpScript.Game.Module.WorldMap.SubViews.WorldMapQuickNavigate
{
	// Token: 0x02004B73 RID: 19315
	public interface ISelectionInfo
	{
		// Token: 0x170086C0 RID: 34496
		// (get) Token: 0x06032743 RID: 206659
		// (set) Token: 0x06032744 RID: 206660
		int FirstIndex { get; set; }

		// Token: 0x170086C1 RID: 34497
		// (get) Token: 0x06032745 RID: 206661
		// (set) Token: 0x06032746 RID: 206662
		int SecondIndex { get; set; }

		// Token: 0x170086C2 RID: 34498
		// (get) Token: 0x06032747 RID: 206663
		// (set) Token: 0x06032748 RID: 206664
		int CountryId { get; set; }

		// Token: 0x170086C3 RID: 34499
		// (get) Token: 0x06032749 RID: 206665
		// (set) Token: 0x0603274A RID: 206666
		bool ExpandCountry { get; set; }

		// Token: 0x170086C4 RID: 34500
		// (get) Token: 0x0603274B RID: 206667
		// (set) Token: 0x0603274C RID: 206668
		int StateId { get; set; }

		// Token: 0x170086C5 RID: 34501
		// (get) Token: 0x0603274D RID: 206669
		// (set) Token: 0x0603274E RID: 206670
		int AreaId { get; set; }
	}
}
