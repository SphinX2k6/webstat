using System;

// Token: 0x020027B6 RID: 10166
public class SkillNodeDataInfo
{
	// Token: 0x17001981 RID: 6529
	// (get) Token: 0x0601419E RID: 82334 RVA: 0x0059DAC5 File Offset: 0x0059BCC5
	// (set) Token: 0x0601419F RID: 82335 RVA: 0x0059DACD File Offset: 0x0059BCCD
	public int SkillNodeId { get; set; }

	// Token: 0x17001982 RID: 6530
	// (get) Token: 0x060141A0 RID: 82336 RVA: 0x0059DAD6 File Offset: 0x0059BCD6
	// (set) Token: 0x060141A1 RID: 82337 RVA: 0x0059DADE File Offset: 0x0059BCDE
	public bool IsActive { get; set; }

	// Token: 0x17001983 RID: 6531
	// (get) Token: 0x060141A2 RID: 82338 RVA: 0x0059DAE7 File Offset: 0x0059BCE7
	// (set) Token: 0x060141A3 RID: 82339 RVA: 0x0059DAEF File Offset: 0x0059BCEF
	public int SkillId { get; set; }

	// Token: 0x060141A4 RID: 82340 RVA: 0x0059DAF8 File Offset: 0x0059BCF8
	public SkillNodeDataInfo(int skillNodeId, bool isActive, int skillId)
	{
		this.SkillNodeId = skillNodeId;
		this.IsActive = isActive;
		this.SkillId = skillId;
	}
}
