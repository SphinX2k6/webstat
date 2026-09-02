using System;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Season
{
	// Token: 0x02004FF8 RID: 20472
	public interface ISeasonLoopState
	{
		// Token: 0x17008A9F RID: 35487
		// (get) Token: 0x06034C57 RID: 216151
		// (set) Token: 0x06034C58 RID: 216152
		ESeason CurrentSeason { get; set; }

		// Token: 0x17008AA0 RID: 35488
		// (get) Token: 0x06034C59 RID: 216153
		// (set) Token: 0x06034C5A RID: 216154
		ESeasonLoopPhase Phase { get; set; }

		// Token: 0x17008AA1 RID: 35489
		// (get) Token: 0x06034C5B RID: 216155
		// (set) Token: 0x06034C5C RID: 216156
		double PhaseElapsed { get; set; }
	}
}
