using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005252 RID: 21074
	[NullableContext(1)]
	public interface IRogueBattleMapGridEffectInfo
	{
		// Token: 0x17008CE1 RID: 36065
		// (get) Token: 0x06035F33 RID: 220979
		// (set) Token: 0x06035F34 RID: 220980
		string TagKey { get; set; }

		// Token: 0x17008CE2 RID: 36066
		// (get) Token: 0x06035F35 RID: 220981
		// (set) Token: 0x06035F36 RID: 220982
		int Count { get; set; }

		// Token: 0x17008CE3 RID: 36067
		// (get) Token: 0x06035F37 RID: 220983
		// (set) Token: 0x06035F38 RID: 220984
		bool IsRatio { get; set; }

		// Token: 0x17008CE4 RID: 36068
		// (get) Token: 0x06035F39 RID: 220985
		// (set) Token: 0x06035F3A RID: 220986
		string Icon { get; set; }
	}
}
