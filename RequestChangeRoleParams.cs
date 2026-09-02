using System;

// Token: 0x02002951 RID: 10577
public class RequestChangeRoleParams : IRequestChangeRoleParams
{
	// Token: 0x17001B94 RID: 7060
	// (get) Token: 0x06015044 RID: 86084 RVA: 0x005CFC0C File Offset: 0x005CDE0C
	// (set) Token: 0x06015045 RID: 86085 RVA: 0x005CFC14 File Offset: 0x005CDE14
	public bool? FilterSameRole { get; set; }

	// Token: 0x17001B95 RID: 7061
	// (get) Token: 0x06015046 RID: 86086 RVA: 0x005CFC1D File Offset: 0x005CDE1D
	// (set) Token: 0x06015047 RID: 86087 RVA: 0x005CFC25 File Offset: 0x005CDE25
	public bool? GoDownWaitSkillEnd { get; set; }

	// Token: 0x17001B96 RID: 7062
	// (get) Token: 0x06015048 RID: 86088 RVA: 0x005CFC2E File Offset: 0x005CDE2E
	// (set) Token: 0x06015049 RID: 86089 RVA: 0x005CFC36 File Offset: 0x005CDE36
	public bool? ForceInheritTransform { get; set; }

	// Token: 0x17001B97 RID: 7063
	// (get) Token: 0x0601504A RID: 86090 RVA: 0x005CFC3F File Offset: 0x005CDE3F
	// (set) Token: 0x0601504B RID: 86091 RVA: 0x005CFC47 File Offset: 0x005CDE47
	public bool? GoBattleInvincible { get; set; }

	// Token: 0x17001B98 RID: 7064
	// (get) Token: 0x0601504C RID: 86092 RVA: 0x005CFC50 File Offset: 0x005CDE50
	// (set) Token: 0x0601504D RID: 86093 RVA: 0x005CFC58 File Offset: 0x005CDE58
	public bool? CanUseGoBattleSkill { get; set; }
}
