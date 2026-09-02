using System;

// Token: 0x0200188D RID: 6285
public interface ICheckSkillHitCondition : IBaseCheckConditionInfo
{
	// Token: 0x17000EEF RID: 3823
	// (get) Token: 0x0600B431 RID: 46129
	// (set) Token: 0x0600B432 RID: 46130
	long HitSkillId { get; set; }

	// Token: 0x17000EF0 RID: 3824
	// (get) Token: 0x0600B433 RID: 46131
	// (set) Token: 0x0600B434 RID: 46132
	long BulletId { get; set; }
}
