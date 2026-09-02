using System;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005245 RID: 21061
	public interface IRogueBattleMapRoleGridInfo
	{
		// Token: 0x17008CBD RID: 36029
		// (get) Token: 0x06035EE5 RID: 220901
		// (set) Token: 0x06035EE6 RID: 220902
		int ConfigId { get; set; }

		// Token: 0x17008CBE RID: 36030
		// (get) Token: 0x06035EE7 RID: 220903
		// (set) Token: 0x06035EE8 RID: 220904
		bool IsGain { get; set; }

		// Token: 0x17008CBF RID: 36031
		// (get) Token: 0x06035EE9 RID: 220905
		// (set) Token: 0x06035EEA RID: 220906
		bool NeedLevel { get; set; }
	}
}
