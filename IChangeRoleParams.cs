using System;

// Token: 0x02002963 RID: 10595
public interface IChangeRoleParams
{
	// Token: 0x17001BB3 RID: 7091
	// (get) Token: 0x060150E5 RID: 86245
	// (set) Token: 0x060150E6 RID: 86246
	bool? UseGoBattleSkill { get; set; }

	// Token: 0x17001BB4 RID: 7092
	// (get) Token: 0x060150E7 RID: 86247
	// (set) Token: 0x060150E8 RID: 86248
	double? CoolDown { get; set; }

	// Token: 0x17001BB5 RID: 7093
	// (get) Token: 0x060150E9 RID: 86249
	// (set) Token: 0x060150EA RID: 86250
	bool? GoDownWaitSkillEnd { get; set; }

	// Token: 0x17001BB6 RID: 7094
	// (get) Token: 0x060150EB RID: 86251
	// (set) Token: 0x060150EC RID: 86252
	bool? AllowRefreshTransform { get; set; }

	// Token: 0x17001BB7 RID: 7095
	// (get) Token: 0x060150ED RID: 86253
	// (set) Token: 0x060150EE RID: 86254
	bool? ForceInheritTransform { get; set; }

	// Token: 0x17001BB8 RID: 7096
	// (get) Token: 0x060150EF RID: 86255
	// (set) Token: 0x060150F0 RID: 86256
	bool? ForceChangeRole { get; set; }
}
