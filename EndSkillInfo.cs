using System;
using Aki.Protocol;

// Token: 0x02003124 RID: 12580
public class EndSkillInfo
{
	// Token: 0x0601A0C2 RID: 106690 RVA: 0x007A195C File Offset: 0x0079FB5C
	public void Reset()
	{
		this.Reason = EEndSkillReason.Default;
		this.EntityId = 0L;
		this.SkillId = 0;
		this.BulletId = 0L;
	}

	// Token: 0x0400D0E1 RID: 53473
	public EEndSkillReason Reason;

	// Token: 0x0400D0E2 RID: 53474
	public long EntityId;

	// Token: 0x0400D0E3 RID: 53475
	public int SkillId;

	// Token: 0x0400D0E4 RID: 53476
	public long BulletId;
}
