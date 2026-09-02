using System;
using System.Runtime.CompilerServices;

// Token: 0x02002ECB RID: 11979
public class CombatDataSkill : CombatDataBase
{
	// Token: 0x06018997 RID: 100759 RVA: 0x006ED9B8 File Offset: 0x006EBBB8
	public CombatDataSkill(int attackerId, int skillId, int targetId = 0) : base(attackerId, targetId)
	{
		this.SkillId = skillId;
	}

	// Token: 0x06018998 RID: 100760 RVA: 0x006ED9CC File Offset: 0x006EBBCC
	[NullableContext(1)]
	public override string ParseToString()
	{
		string entityConfigName = CombatDataBase.GetEntityConfigName(this.AttackerId);
		string skillConfigName = CombatDataBase.GetSkillConfigName(this.AttackerId, this.SkillId);
		return StringUtils.Format("<Date>[{0}]</><Atk>{1}</>施放了技能<Skill>{2}</>。", new string[]
		{
			this.DateCreate,
			entityConfigName ?? "",
			skillConfigName ?? ""
		});
	}

	// Token: 0x0400BE63 RID: 48739
	public readonly int SkillId;
}
