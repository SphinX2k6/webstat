using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D60 RID: 23904
	[NullableContext(2)]
	public interface IFlagChallengeFormationRoleItemData
	{
		// Token: 0x170098A1 RID: 39073
		// (get) Token: 0x0603C3C8 RID: 246728
		// (set) Token: 0x0603C3C9 RID: 246729
		int Index { get; set; }

		// Token: 0x170098A2 RID: 39074
		// (get) Token: 0x0603C3CA RID: 246730
		// (set) Token: 0x0603C3CB RID: 246731
		RoleDataBase RoleData { get; set; }
	}
}
