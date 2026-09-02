using System;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200513A RID: 20794
	public interface IBossChallengeStateVisibility
	{
		// Token: 0x17008C71 RID: 35953
		// (get) Token: 0x0603587F RID: 219263
		// (set) Token: 0x06035880 RID: 219264
		bool ShowUnlock { get; set; }

		// Token: 0x17008C72 RID: 35954
		// (get) Token: 0x06035881 RID: 219265
		// (set) Token: 0x06035882 RID: 219266
		bool ShowEmptyIcon { get; set; }

		// Token: 0x17008C73 RID: 35955
		// (get) Token: 0x06035883 RID: 219267
		// (set) Token: 0x06035884 RID: 219268
		bool ShowFinished { get; set; }
	}
}
