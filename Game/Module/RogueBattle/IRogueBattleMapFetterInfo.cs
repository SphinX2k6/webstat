using System;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x0200524B RID: 21067
	public interface IRogueBattleMapFetterInfo
	{
		// Token: 0x17008CCD RID: 36045
		// (get) Token: 0x06035F08 RID: 220936
		// (set) Token: 0x06035F09 RID: 220937
		int ConfigId { get; set; }

		// Token: 0x17008CCE RID: 36046
		// (get) Token: 0x06035F0A RID: 220938
		// (set) Token: 0x06035F0B RID: 220939
		int Level { get; set; }

		// Token: 0x17008CCF RID: 36047
		// (get) Token: 0x06035F0C RID: 220940
		// (set) Token: 0x06035F0D RID: 220941
		bool IsReached { get; set; }
	}
}
