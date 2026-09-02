using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x0200523F RID: 21055
	[NullableContext(1)]
	public interface IRogueBattleRoleBondUpdateInfo
	{
		// Token: 0x17008CA7 RID: 36007
		// (get) Token: 0x06035EB6 RID: 220854
		// (set) Token: 0x06035EB7 RID: 220855
		RoleBondInfo OldRoleBondInfo { get; set; }

		// Token: 0x17008CA8 RID: 36008
		// (get) Token: 0x06035EB8 RID: 220856
		// (set) Token: 0x06035EB9 RID: 220857
		RoleBondInfo NewRoleBondInfo { get; set; }

		// Token: 0x17008CA9 RID: 36009
		// (get) Token: 0x06035EBA RID: 220858
		// (set) Token: 0x06035EBB RID: 220859
		int AddStar { get; set; }
	}
}
