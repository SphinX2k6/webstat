using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005242 RID: 21058
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueBattleTeamRoleGridInfo : IRogueBattleTeamRoleGridInfo
	{
		// Token: 0x17008CB1 RID: 36017
		// (get) Token: 0x06035ECB RID: 220875 RVA: 0x00D91F96 File Offset: 0x00D90196
		// (set) Token: 0x06035ECC RID: 220876 RVA: 0x00D91F9E File Offset: 0x00D9019E
		public RoleDataBase RoleData { get; set; }

		// Token: 0x17008CB2 RID: 36018
		// (get) Token: 0x06035ECD RID: 220877 RVA: 0x00D91FA7 File Offset: 0x00D901A7
		// (set) Token: 0x06035ECE RID: 220878 RVA: 0x00D91FAF File Offset: 0x00D901AF
		public int RoleStarLv { get; set; }

		// Token: 0x17008CB3 RID: 36019
		// (get) Token: 0x06035ECF RID: 220879 RVA: 0x00D91FB8 File Offset: 0x00D901B8
		// (set) Token: 0x06035ED0 RID: 220880 RVA: 0x00D91FC0 File Offset: 0x00D901C0
		public int FormationIndex { get; set; }

		// Token: 0x17008CB4 RID: 36020
		// (get) Token: 0x06035ED1 RID: 220881 RVA: 0x00D91FC9 File Offset: 0x00D901C9
		// (set) Token: 0x06035ED2 RID: 220882 RVA: 0x00D91FD1 File Offset: 0x00D901D1
		public bool IsLinkOn { get; set; }
	}
}
