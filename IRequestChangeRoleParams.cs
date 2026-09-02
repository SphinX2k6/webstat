using System;

// Token: 0x02002950 RID: 10576
public interface IRequestChangeRoleParams
{
	// Token: 0x17001B8F RID: 7055
	// (get) Token: 0x0601503A RID: 86074
	// (set) Token: 0x0601503B RID: 86075
	bool? FilterSameRole { get; set; }

	// Token: 0x17001B90 RID: 7056
	// (get) Token: 0x0601503C RID: 86076
	// (set) Token: 0x0601503D RID: 86077
	bool? GoDownWaitSkillEnd { get; set; }

	// Token: 0x17001B91 RID: 7057
	// (get) Token: 0x0601503E RID: 86078
	// (set) Token: 0x0601503F RID: 86079
	bool? ForceInheritTransform { get; set; }

	// Token: 0x17001B92 RID: 7058
	// (get) Token: 0x06015040 RID: 86080
	// (set) Token: 0x06015041 RID: 86081
	bool? GoBattleInvincible { get; set; }

	// Token: 0x17001B93 RID: 7059
	// (get) Token: 0x06015042 RID: 86082
	// (set) Token: 0x06015043 RID: 86083
	bool? CanUseGoBattleSkill { get; set; }
}
