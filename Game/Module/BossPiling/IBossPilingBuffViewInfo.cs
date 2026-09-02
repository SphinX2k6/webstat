using System;

namespace CSharpScript.Game.Module.BossPiling
{
	// Token: 0x02005EE9 RID: 24297
	public interface IBossPilingBuffViewInfo
	{
		// Token: 0x17009A16 RID: 39446
		// (get) Token: 0x0603D0D8 RID: 250072
		// (set) Token: 0x0603D0D9 RID: 250073
		int LevelId { get; set; }

		// Token: 0x17009A17 RID: 39447
		// (get) Token: 0x0603D0DA RID: 250074
		// (set) Token: 0x0603D0DB RID: 250075
		bool InGame { get; set; }
	}
}
