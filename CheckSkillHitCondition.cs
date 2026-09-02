using System;

// Token: 0x0200188E RID: 6286
public class CheckSkillHitCondition : IBaseCheckConditionInfo, ICheckSkillHitCondition
{
	// Token: 0x17000EF1 RID: 3825
	// (get) Token: 0x0600B435 RID: 46133 RVA: 0x002FFA0B File Offset: 0x002FDC0B
	// (set) Token: 0x0600B436 RID: 46134 RVA: 0x002FFA13 File Offset: 0x002FDC13
	public long HitSkillId { get; set; }

	// Token: 0x17000EF2 RID: 3826
	// (get) Token: 0x0600B437 RID: 46135 RVA: 0x002FFA1C File Offset: 0x002FDC1C
	// (set) Token: 0x0600B438 RID: 46136 RVA: 0x002FFA24 File Offset: 0x002FDC24
	public long BulletId { get; set; }
}
