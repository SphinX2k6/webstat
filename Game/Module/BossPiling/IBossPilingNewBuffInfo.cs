using System;

namespace CSharpScript.Game.Module.BossPiling
{
	// Token: 0x02005EEF RID: 24303
	public interface IBossPilingNewBuffInfo
	{
		// Token: 0x17009A22 RID: 39458
		// (get) Token: 0x0603D0F3 RID: 250099
		// (set) Token: 0x0603D0F4 RID: 250100
		int BuffId { get; set; }

		// Token: 0x17009A23 RID: 39459
		// (get) Token: 0x0603D0F5 RID: 250101
		// (set) Token: 0x0603D0F6 RID: 250102
		int OldValue { get; set; }

		// Token: 0x17009A24 RID: 39460
		// (get) Token: 0x0603D0F7 RID: 250103
		// (set) Token: 0x0603D0F8 RID: 250104
		int NewValue { get; set; }

		// Token: 0x17009A25 RID: 39461
		// (get) Token: 0x0603D0F9 RID: 250105
		// (set) Token: 0x0603D0FA RID: 250106
		bool NeedAccelerate { get; set; }
	}
}
