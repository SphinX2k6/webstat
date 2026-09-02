using System;

// Token: 0x0200211C RID: 8476
public class RoleSkillRecord
{
	// Token: 0x0601035A RID: 66394 RVA: 0x00474E7F File Offset: 0x0047307F
	public RoleSkillRecord(int skillId)
	{
		this.skill_id = (long)skillId;
	}

	// Token: 0x04007CFD RID: 31997
	public long skill_id;

	// Token: 0x04007CFE RID: 31998
	public int use_count;

	// Token: 0x04007CFF RID: 31999
	public int hit_count;

	// Token: 0x04007D00 RID: 32000
	public int real_hit_count;

	// Token: 0x04007D01 RID: 32001
	public int damage;

	// Token: 0x04007D02 RID: 32002
	public int skill_type;

	// Token: 0x04007D03 RID: 32003
	public int acc_energy;
}
