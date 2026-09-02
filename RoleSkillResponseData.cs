using System;
using System.Runtime.CompilerServices;

// Token: 0x020028C8 RID: 10440
[NullableContext(2)]
[Nullable(0)]
public class RoleSkillResponseData
{
	// Token: 0x06014B6E RID: 84846 RVA: 0x005BC417 File Offset: 0x005BA617
	public void UpdateRoleSkillViewResponse(SkillEffect skillEffectList, SkillEffect nextSkillEffectList, int skillId)
	{
		this.SkillEffectList = skillEffectList;
		this.NextSkillEffectList = nextSkillEffectList;
		this.SkillId = skillId;
	}

	// Token: 0x06014B6F RID: 84847 RVA: 0x005BC42E File Offset: 0x005BA62E
	public int GetSkillId()
	{
		return this.SkillId;
	}

	// Token: 0x06014B70 RID: 84848 RVA: 0x005BC436 File Offset: 0x005BA636
	public SkillEffect GetSkillEffect()
	{
		return this.SkillEffectList;
	}

	// Token: 0x06014B71 RID: 84849 RVA: 0x005BC43E File Offset: 0x005BA63E
	public SkillEffect GetNextLevelSkillEffect()
	{
		return this.NextSkillEffectList;
	}

	// Token: 0x04009FAD RID: 40877
	private SkillEffect SkillEffectList;

	// Token: 0x04009FAE RID: 40878
	private SkillEffect NextSkillEffectList;

	// Token: 0x04009FAF RID: 40879
	private int SkillId;
}
