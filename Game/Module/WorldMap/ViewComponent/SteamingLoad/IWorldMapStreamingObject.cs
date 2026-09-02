using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WorldMap.ViewComponent.SteamingLoad
{
	// Token: 0x02004B55 RID: 19285
	[NullableContext(1)]
	public interface IWorldMapStreamingObject
	{
		// Token: 0x17008699 RID: 34457
		// (get) Token: 0x06032615 RID: 206357
		// (set) Token: 0x06032616 RID: 206358
		bool IsStreaming { get; set; }

		// Token: 0x1700869A RID: 34458
		// (get) Token: 0x06032617 RID: 206359
		// (set) Token: 0x06032618 RID: 206360
		bool IsVisible { get; set; }

		// Token: 0x06032619 RID: 206361
		void OnLoad();

		// Token: 0x0603261A RID: 206362
		void OnUnload();

		// Token: 0x0603261B RID: 206363
		Vector2D GetPreloadThreshold();

		// Token: 0x0603261C RID: 206364
		Vector GetUiPosition();
	}
}
