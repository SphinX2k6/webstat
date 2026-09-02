using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Marks.MarkItem;

namespace CSharpScript.Game.Module.WorldMap.SubViews.WorldMapQuickNavigate
{
	// Token: 0x02004B65 RID: 19301
	[NullableContext(2)]
	[Nullable(0)]
	public class NavigateIconItemData : INavigateIconItemData
	{
		// Token: 0x170086B2 RID: 34482
		// (get) Token: 0x06032701 RID: 206593 RVA: 0x00C9E63E File Offset: 0x00C9C83E
		// (set) Token: 0x06032702 RID: 206594 RVA: 0x00C9E646 File Offset: 0x00C9C846
		public int Id { get; set; }

		// Token: 0x170086B3 RID: 34483
		// (get) Token: 0x06032703 RID: 206595 RVA: 0x00C9E64F File Offset: 0x00C9C84F
		// (set) Token: 0x06032704 RID: 206596 RVA: 0x00C9E657 File Offset: 0x00C9C857
		public string IconId { get; set; }

		// Token: 0x170086B4 RID: 34484
		// (get) Token: 0x06032705 RID: 206597 RVA: 0x00C9E660 File Offset: 0x00C9C860
		// (set) Token: 0x06032706 RID: 206598 RVA: 0x00C9E668 File Offset: 0x00C9C868
		public string IconPath { get; set; }

		// Token: 0x170086B5 RID: 34485
		// (get) Token: 0x06032707 RID: 206599 RVA: 0x00C9E671 File Offset: 0x00C9C871
		// (set) Token: 0x06032708 RID: 206600 RVA: 0x00C9E679 File Offset: 0x00C9C879
		[Nullable(new byte[]
		{
			1,
			2
		})]
		public Action<int, MarkItem> ClickCallback { [return: Nullable(new byte[]
		{
			1,
			2
		})] get; [param: Nullable(new byte[]
		{
			1,
			2
		})] set; }

		// Token: 0x170086B6 RID: 34486
		// (get) Token: 0x06032709 RID: 206601 RVA: 0x00C9E682 File Offset: 0x00C9C882
		// (set) Token: 0x0603270A RID: 206602 RVA: 0x00C9E68A File Offset: 0x00C9C88A
		public MarkItem MarkItem { get; set; }
	}
}
