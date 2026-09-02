using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200295D RID: 10589
[NullableContext(1)]
public interface IUpdateGroupParams
{
	// Token: 0x17001B9B RID: 7067
	// (get) Token: 0x060150B2 RID: 86194
	// (set) Token: 0x060150B3 RID: 86195
	ETeamGroupType GroupType { get; set; }

	// Token: 0x17001B9C RID: 7068
	// (get) Token: 0x060150B4 RID: 86196
	// (set) Token: 0x060150B5 RID: 86197
	IList<SceneTeamRole> GroupRoleList { get; set; }

	// Token: 0x17001B9D RID: 7069
	// (get) Token: 0x060150B6 RID: 86198
	// (set) Token: 0x060150B7 RID: 86199
	int CurrentRoleId { get; set; }

	// Token: 0x17001B9E RID: 7070
	// (get) Token: 0x060150B8 RID: 86200
	// (set) Token: 0x060150B9 RID: 86201
	ETeamLivingState? LivingState { get; set; }

	// Token: 0x17001B9F RID: 7071
	// (get) Token: 0x060150BA RID: 86202
	// (set) Token: 0x060150BB RID: 86203
	bool? IsFixedLocation { get; set; }

	// Token: 0x17001BA0 RID: 7072
	// (get) Token: 0x060150BC RID: 86204
	// (set) Token: 0x060150BD RID: 86205
	bool? ReplaceAllRole { get; set; }
}
