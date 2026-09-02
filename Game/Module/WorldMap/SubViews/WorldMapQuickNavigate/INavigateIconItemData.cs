using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Marks.MarkItem;

namespace CSharpScript.Game.Module.WorldMap.SubViews.WorldMapQuickNavigate
{
	// Token: 0x02004B64 RID: 19300
	[NullableContext(2)]
	public interface INavigateIconItemData
	{
		// Token: 0x170086AD RID: 34477
		// (get) Token: 0x060326F7 RID: 206583
		// (set) Token: 0x060326F8 RID: 206584
		int Id { get; set; }

		// Token: 0x170086AE RID: 34478
		// (get) Token: 0x060326F9 RID: 206585
		// (set) Token: 0x060326FA RID: 206586
		string IconId { get; set; }

		// Token: 0x170086AF RID: 34479
		// (get) Token: 0x060326FB RID: 206587
		// (set) Token: 0x060326FC RID: 206588
		string IconPath { get; set; }

		// Token: 0x170086B0 RID: 34480
		// (get) Token: 0x060326FD RID: 206589
		// (set) Token: 0x060326FE RID: 206590
		[Nullable(new byte[]
		{
			1,
			2
		})]
		Action<int, MarkItem> ClickCallback { [return: Nullable(new byte[]
		{
			1,
			2
		})] get; [param: Nullable(new byte[]
		{
			1,
			2
		})] set; }

		// Token: 0x170086B1 RID: 34481
		// (get) Token: 0x060326FF RID: 206591
		// (set) Token: 0x06032700 RID: 206592
		MarkItem MarkItem { get; set; }
	}
}
