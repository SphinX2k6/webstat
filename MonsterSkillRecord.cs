using System;

// Token: 0x0200211E RID: 8478
public class MonsterSkillRecord
{
	// Token: 0x0601035E RID: 66398 RVA: 0x00474EEE File Offset: 0x004730EE
	public MonsterSkillRecord(int skillId)
	{
		this.skill_id = (long)skillId;
	}

	// Token: 0x04007D0A RID: 32010
	public long skill_id;

	// Token: 0x04007D0B RID: 32011
	public int use_count;

	// Token: 0x04007D0C RID: 32012
	public int hit_count;

	// Token: 0x04007D0D RID: 32013
	public int real_hit_count;

	// Token: 0x04007D0E RID: 32014
	public int damage;

	// Token: 0x04007D0F RID: 32015
	public int counter_attack_times;

	// Token: 0x04007D10 RID: 32016
	public int bullet_rebound_times;

	// Token: 0x04007D11 RID: 32017
	public int dodge_succ_times;
}
