using System;
using System.Runtime.CompilerServices;

// Token: 0x0200312F RID: 12591
[NullableContext(2)]
public interface IBeginSkillBehaviorConditionParam
{
	// Token: 0x17002361 RID: 9057
	// (get) Token: 0x0601A140 RID: 106816
	// (set) Token: 0x0601A141 RID: 106817
	[Nullable(1)]
	Entity Entity { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x17002362 RID: 9058
	// (get) Token: 0x0601A142 RID: 106818
	// (set) Token: 0x0601A143 RID: 106819
	BaseSkillComponent SkillComponent { get; set; }

	// Token: 0x17002363 RID: 9059
	// (get) Token: 0x0601A144 RID: 106820
	// (set) Token: 0x0601A145 RID: 106821
	Skill Skill { get; set; }
}
