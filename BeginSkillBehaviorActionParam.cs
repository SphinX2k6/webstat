using System;
using System.Runtime.CompilerServices;

// Token: 0x02003132 RID: 12594
[NullableContext(1)]
[Nullable(0)]
public class BeginSkillBehaviorActionParam : IBeginSkillBehaviorActionParam
{
	// Token: 0x1700236A RID: 9066
	// (get) Token: 0x0601A153 RID: 106835 RVA: 0x007A6BF3 File Offset: 0x007A4DF3
	// (set) Token: 0x0601A154 RID: 106836 RVA: 0x007A6BFB File Offset: 0x007A4DFB
	public Entity Entity { get; set; }

	// Token: 0x1700236B RID: 9067
	// (get) Token: 0x0601A155 RID: 106837 RVA: 0x007A6C04 File Offset: 0x007A4E04
	// (set) Token: 0x0601A156 RID: 106838 RVA: 0x007A6C0C File Offset: 0x007A4E0C
	public BaseSkillComponent SkillComponent { get; set; }

	// Token: 0x1700236C RID: 9068
	// (get) Token: 0x0601A157 RID: 106839 RVA: 0x007A6C15 File Offset: 0x007A4E15
	// (set) Token: 0x0601A158 RID: 106840 RVA: 0x007A6C1D File Offset: 0x007A4E1D
	public Skill Skill { get; set; }
}
