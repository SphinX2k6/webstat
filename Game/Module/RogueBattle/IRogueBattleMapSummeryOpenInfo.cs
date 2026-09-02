using System;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005254 RID: 21076
	public interface IRogueBattleMapSummeryOpenInfo
	{
		// Token: 0x17008CE9 RID: 36073
		// (get) Token: 0x06035F44 RID: 220996
		// (set) Token: 0x06035F45 RID: 220997
		EUiTabViewName TabName { get; set; }

		// Token: 0x17008CEA RID: 36074
		// (get) Token: 0x06035F46 RID: 220998
		// (set) Token: 0x06035F47 RID: 220999
		int? FetterId { get; set; }
	}
}
