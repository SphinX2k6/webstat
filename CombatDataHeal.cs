using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002ECA RID: 11978
public class CombatDataHeal : CombatDataBase
{
	// Token: 0x06018995 RID: 100757 RVA: 0x006ED8AE File Offset: 0x006EBAAE
	public CombatDataHeal(int attackerId, long healId, int healValue, int skillId, int targetId = 0) : base(attackerId, targetId)
	{
		this.HealId = healId;
		this.HealValue = healValue;
		this.SkillId = skillId;
	}

	// Token: 0x06018996 RID: 100758 RVA: 0x006ED8D0 File Offset: 0x006EBAD0
	[NullableContext(1)]
	public override string ParseToString()
	{
		string[] entityConfigNameAndSkillName = CombatDataBase.GetEntityConfigNameAndSkillName(this.AttackerId, this.HealId, this.SkillId);
		string entityConfigName = CombatDataBase.GetEntityConfigName(this.TargetId);
		BaseAttributeComponent component = Singleton<EntitySystem>.Instance.Get(this.TargetId).GetComponent<BaseAttributeComponent>();
		float currentValue = component.GetCurrentValue(EAttributeType.Life);
		float currentValue2 = component.GetCurrentValue(EAttributeType.LifeMax);
		return StringUtils.Format("<Date>[{0}]</><Atk>{1}</>施放了<Skill>{2}</>使<Victim>{3}</>恢复<NumDmg>{4}</>点生命<Change>{5}</>", new string[]
		{
			this.DateCreate,
			entityConfigNameAndSkillName[0] ?? "",
			entityConfigNameAndSkillName[1] ?? "",
			entityConfigName ?? "",
			this.HealValue.ToString(),
			(currentValue == currentValue2) ? "(满血)" : StringUtils.Format("({0}->{1})", new string[]
			{
				((int)currentValue).ToString(),
				((int)currentValue - this.HealValue).ToString()
			})
		});
	}

	// Token: 0x0400BE60 RID: 48736
	public readonly long HealId;

	// Token: 0x0400BE61 RID: 48737
	public readonly int HealValue;

	// Token: 0x0400BE62 RID: 48738
	public readonly int SkillId;
}
