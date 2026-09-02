using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D61 RID: 23905
	[NullableContext(2)]
	[Nullable(0)]
	public class FlagChallengeFormationRoleItemData : IFlagChallengeFormationRoleItemData
	{
		// Token: 0x170098A3 RID: 39075
		// (get) Token: 0x0603C3CC RID: 246732 RVA: 0x00F47AA2 File Offset: 0x00F45CA2
		// (set) Token: 0x0603C3CD RID: 246733 RVA: 0x00F47AAA File Offset: 0x00F45CAA
		public int Index { get; set; }

		// Token: 0x170098A4 RID: 39076
		// (get) Token: 0x0603C3CE RID: 246734 RVA: 0x00F47AB3 File Offset: 0x00F45CB3
		// (set) Token: 0x0603C3CF RID: 246735 RVA: 0x00F47ABB File Offset: 0x00F45CBB
		public RoleDataBase RoleData { get; set; }
	}
}
