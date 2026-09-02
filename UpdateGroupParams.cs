using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200295E RID: 10590
[NullableContext(1)]
[Nullable(0)]
public class UpdateGroupParams : IUpdateGroupParams
{
	// Token: 0x17001BA1 RID: 7073
	// (get) Token: 0x060150BE RID: 86206 RVA: 0x005D2F94 File Offset: 0x005D1194
	// (set) Token: 0x060150BF RID: 86207 RVA: 0x005D2F9C File Offset: 0x005D119C
	public ETeamGroupType GroupType { get; set; }

	// Token: 0x17001BA2 RID: 7074
	// (get) Token: 0x060150C0 RID: 86208 RVA: 0x005D2FA5 File Offset: 0x005D11A5
	// (set) Token: 0x060150C1 RID: 86209 RVA: 0x005D2FAD File Offset: 0x005D11AD
	public IList<SceneTeamRole> GroupRoleList { get; set; }

	// Token: 0x17001BA3 RID: 7075
	// (get) Token: 0x060150C2 RID: 86210 RVA: 0x005D2FB6 File Offset: 0x005D11B6
	// (set) Token: 0x060150C3 RID: 86211 RVA: 0x005D2FBE File Offset: 0x005D11BE
	public int CurrentRoleId { get; set; }

	// Token: 0x17001BA4 RID: 7076
	// (get) Token: 0x060150C4 RID: 86212 RVA: 0x005D2FC7 File Offset: 0x005D11C7
	// (set) Token: 0x060150C5 RID: 86213 RVA: 0x005D2FCF File Offset: 0x005D11CF
	public ETeamLivingState? LivingState { get; set; }

	// Token: 0x17001BA5 RID: 7077
	// (get) Token: 0x060150C6 RID: 86214 RVA: 0x005D2FD8 File Offset: 0x005D11D8
	// (set) Token: 0x060150C7 RID: 86215 RVA: 0x005D2FE0 File Offset: 0x005D11E0
	public bool? IsFixedLocation { get; set; }

	// Token: 0x17001BA6 RID: 7078
	// (get) Token: 0x060150C8 RID: 86216 RVA: 0x005D2FE9 File Offset: 0x005D11E9
	// (set) Token: 0x060150C9 RID: 86217 RVA: 0x005D2FF1 File Offset: 0x005D11F1
	public bool? ReplaceAllRole { get; set; }
}
