using System;

namespace CSharpScript.Game.Module.MovieMode
{
	// Token: 0x020056EF RID: 22255
	public interface IUiLayerSafeZone
	{
		// Token: 0x1700910A RID: 37130
		// (get) Token: 0x06038A27 RID: 231975
		// (set) Token: 0x06038A28 RID: 231976
		float StretchLeft { get; set; }

		// Token: 0x1700910B RID: 37131
		// (get) Token: 0x06038A29 RID: 231977
		// (set) Token: 0x06038A2A RID: 231978
		float StretchRight { get; set; }

		// Token: 0x1700910C RID: 37132
		// (get) Token: 0x06038A2B RID: 231979
		// (set) Token: 0x06038A2C RID: 231980
		float StretchTop { get; set; }

		// Token: 0x1700910D RID: 37133
		// (get) Token: 0x06038A2D RID: 231981
		// (set) Token: 0x06038A2E RID: 231982
		float StretchBottom { get; set; }
	}
}
