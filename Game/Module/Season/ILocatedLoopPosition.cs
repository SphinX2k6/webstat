using System;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Season
{
	// Token: 0x02004FF1 RID: 20465
	internal interface ILocatedLoopPosition
	{
		// Token: 0x17008A9B RID: 35483
		// (get) Token: 0x06034C27 RID: 216103
		// (set) Token: 0x06034C28 RID: 216104
		ESeason Season { get; set; }

		// Token: 0x17008A9C RID: 35484
		// (get) Token: 0x06034C29 RID: 216105
		// (set) Token: 0x06034C2A RID: 216106
		ESeasonLoopPhase Phase { get; set; }
	}
}
