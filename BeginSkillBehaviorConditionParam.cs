using System;
using System.Runtime.CompilerServices;

// Token: 0x02003131 RID: 12593
[NullableContext(2)]
[Nullable(0)]
public class BeginSkillBehaviorConditionParam : IBeginSkillBehaviorConditionParam
{
	// Token: 0x17002367 RID: 9063
	// (get) Token: 0x0601A14C RID: 106828 RVA: 0x007A6BB8 File Offset: 0x007A4DB8
	// (set) Token: 0x0601A14D RID: 106829 RVA: 0x007A6BC0 File Offset: 0x007A4DC0
	[Nullable(1)]
	public Entity Entity { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x17002368 RID: 9064
	// (get) Token: 0x0601A14E RID: 106830 RVA: 0x007A6BC9 File Offset: 0x007A4DC9
	// (set) Token: 0x0601A14F RID: 106831 RVA: 0x007A6BD1 File Offset: 0x007A4DD1
	public BaseSkillComponent SkillComponent { get; set; }

	// Token: 0x17002369 RID: 9065
	// (get) Token: 0x0601A150 RID: 106832 RVA: 0x007A6BDA File Offset: 0x007A4DDA
	// (set) Token: 0x0601A151 RID: 106833 RVA: 0x007A6BE2 File Offset: 0x007A4DE2
	public Skill Skill { get; set; }
}
