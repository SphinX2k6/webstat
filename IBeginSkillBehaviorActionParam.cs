using System;
using System.Runtime.CompilerServices;

// Token: 0x02003130 RID: 12592
[NullableContext(1)]
public interface IBeginSkillBehaviorActionParam
{
	// Token: 0x17002364 RID: 9060
	// (get) Token: 0x0601A146 RID: 106822
	// (set) Token: 0x0601A147 RID: 106823
	Entity Entity { get; set; }

	// Token: 0x17002365 RID: 9061
	// (get) Token: 0x0601A148 RID: 106824
	// (set) Token: 0x0601A149 RID: 106825
	BaseSkillComponent SkillComponent { get; set; }

	// Token: 0x17002366 RID: 9062
	// (get) Token: 0x0601A14A RID: 106826
	// (set) Token: 0x0601A14B RID: 106827
	Skill Skill { get; set; }
}
