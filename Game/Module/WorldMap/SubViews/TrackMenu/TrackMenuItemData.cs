using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Marks.MarkItem;

namespace CSharpScript.Game.Module.WorldMap.SubViews.TrackMenu
{
	// Token: 0x02004B81 RID: 19329
	[NullableContext(1)]
	[Nullable(0)]
	public class TrackMenuItemData : ITrackMenuItemData
	{
		// Token: 0x170086D1 RID: 34513
		// (get) Token: 0x060327BE RID: 206782 RVA: 0x00CA1643 File Offset: 0x00C9F843
		// (set) Token: 0x060327BF RID: 206783 RVA: 0x00CA164B File Offset: 0x00C9F84B
		public string Icon { get; set; }

		// Token: 0x170086D2 RID: 34514
		// (get) Token: 0x060327C0 RID: 206784 RVA: 0x00CA1654 File Offset: 0x00C9F854
		// (set) Token: 0x060327C1 RID: 206785 RVA: 0x00CA165C File Offset: 0x00C9F85C
		public string Title { get; set; }

		// Token: 0x170086D3 RID: 34515
		// (get) Token: 0x060327C2 RID: 206786 RVA: 0x00CA1665 File Offset: 0x00C9F865
		// (set) Token: 0x060327C3 RID: 206787 RVA: 0x00CA166D File Offset: 0x00C9F86D
		public string StateIcon { get; set; }

		// Token: 0x170086D4 RID: 34516
		// (get) Token: 0x060327C4 RID: 206788 RVA: 0x00CA1676 File Offset: 0x00C9F876
		// (set) Token: 0x060327C5 RID: 206789 RVA: 0x00CA167E File Offset: 0x00C9F87E
		public bool IsPlayerSelf { get; set; }

		// Token: 0x170086D5 RID: 34517
		// (get) Token: 0x060327C6 RID: 206790 RVA: 0x00CA1687 File Offset: 0x00C9F887
		// (set) Token: 0x060327C7 RID: 206791 RVA: 0x00CA168F File Offset: 0x00C9F88F
		public MarkItem MarkItem { get; set; }
	}
}
