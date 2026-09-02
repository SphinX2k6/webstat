using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005241 RID: 21057
	[NullableContext(1)]
	public interface IRogueBattleTeamRoleGridInfo
	{
		// Token: 0x17008CAD RID: 36013
		// (get) Token: 0x06035EC3 RID: 220867
		// (set) Token: 0x06035EC4 RID: 220868
		RoleDataBase RoleData { get; set; }

		// Token: 0x17008CAE RID: 36014
		// (get) Token: 0x06035EC5 RID: 220869
		// (set) Token: 0x06035EC6 RID: 220870
		int RoleStarLv { get; set; }

		// Token: 0x17008CAF RID: 36015
		// (get) Token: 0x06035EC7 RID: 220871
		// (set) Token: 0x06035EC8 RID: 220872
		int FormationIndex { get; set; }

		// Token: 0x17008CB0 RID: 36016
		// (get) Token: 0x06035EC9 RID: 220873
		// (set) Token: 0x06035ECA RID: 220874
		bool IsLinkOn { get; set; }
	}
}
