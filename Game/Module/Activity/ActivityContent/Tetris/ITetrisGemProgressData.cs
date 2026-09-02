using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062A1 RID: 25249
	public interface ITetrisGemProgressData
	{
		// Token: 0x17009C73 RID: 40051
		// (get) Token: 0x0603F8AD RID: 260269
		// (set) Token: 0x0603F8AE RID: 260270
		int GemId { get; set; }

		// Token: 0x17009C74 RID: 40052
		// (get) Token: 0x0603F8AF RID: 260271
		// (set) Token: 0x0603F8B0 RID: 260272
		int CurrentGemCount { get; set; }

		// Token: 0x17009C75 RID: 40053
		// (get) Token: 0x0603F8B1 RID: 260273
		// (set) Token: 0x0603F8B2 RID: 260274
		int TargetGemCount { get; set; }
	}
}
