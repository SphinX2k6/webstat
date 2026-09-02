using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002EC1 RID: 11969
public class PassiveSkillData
{
	// Token: 0x0400BE31 RID: 48689
	public long SkillId;

	// Token: 0x0400BE32 RID: 48690
	public int TriggerHandle;

	// Token: 0x0400BE33 RID: 48691
	[Nullable(1)]
	public List<SkillActionData> Actions = new List<SkillActionData>();

	// Token: 0x0400BE34 RID: 48692
	[Nullable(2)]
	public string TargetKey;

	// Token: 0x0400BE35 RID: 48693
	public long? CombatMessageId;
}
