using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x0200629B RID: 25243
	public interface IRoundConfig
	{
		// Token: 0x17009C5B RID: 40027
		// (get) Token: 0x0603F87A RID: 260218
		// (set) Token: 0x0603F87B RID: 260219
		int Id { get; set; }

		// Token: 0x17009C5C RID: 40028
		// (get) Token: 0x0603F87C RID: 260220
		// (set) Token: 0x0603F87D RID: 260221
		int LevelId { get; set; }

		// Token: 0x17009C5D RID: 40029
		// (get) Token: 0x0603F87E RID: 260222
		// (set) Token: 0x0603F87F RID: 260223
		int Round { get; set; }

		// Token: 0x17009C5E RID: 40030
		// (get) Token: 0x0603F880 RID: 260224
		// (set) Token: 0x0603F881 RID: 260225
		int ShapeId { get; set; }

		// Token: 0x17009C5F RID: 40031
		// (get) Token: 0x0603F882 RID: 260226
		// (set) Token: 0x0603F883 RID: 260227
		int Color { get; set; }

		// Token: 0x17009C60 RID: 40032
		// (get) Token: 0x0603F884 RID: 260228
		// (set) Token: 0x0603F885 RID: 260229
		int Gem { get; set; }

		// Token: 0x17009C61 RID: 40033
		// (get) Token: 0x0603F886 RID: 260230
		// (set) Token: 0x0603F887 RID: 260231
		int GemFill { get; set; }
	}
}
