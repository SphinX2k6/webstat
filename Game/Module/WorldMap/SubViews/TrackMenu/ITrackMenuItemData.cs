using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Marks.MarkItem;

namespace CSharpScript.Game.Module.WorldMap.SubViews.TrackMenu
{
	// Token: 0x02004B80 RID: 19328
	[NullableContext(1)]
	public interface ITrackMenuItemData
	{
		// Token: 0x170086CC RID: 34508
		// (get) Token: 0x060327B4 RID: 206772
		// (set) Token: 0x060327B5 RID: 206773
		string Icon { get; set; }

		// Token: 0x170086CD RID: 34509
		// (get) Token: 0x060327B6 RID: 206774
		// (set) Token: 0x060327B7 RID: 206775
		string Title { get; set; }

		// Token: 0x170086CE RID: 34510
		// (get) Token: 0x060327B8 RID: 206776
		// (set) Token: 0x060327B9 RID: 206777
		string StateIcon { get; set; }

		// Token: 0x170086CF RID: 34511
		// (get) Token: 0x060327BA RID: 206778
		// (set) Token: 0x060327BB RID: 206779
		bool IsPlayerSelf { get; set; }

		// Token: 0x170086D0 RID: 34512
		// (get) Token: 0x060327BC RID: 206780
		// (set) Token: 0x060327BD RID: 206781
		MarkItem MarkItem { get; set; }
	}
}
