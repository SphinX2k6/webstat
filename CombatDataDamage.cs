using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002EC9 RID: 11977
public class CombatDataDamage : CombatDataBase
{
	// Token: 0x06018993 RID: 100755 RVA: 0x006ED7A8 File Offset: 0x006EB9A8
	public CombatDataDamage(int attackerId, long damageId, int damageValue, int skillId, int targetId = 0) : base(attackerId, targetId)
	{
		this.DamageId = damageId;
		this.DamageValue = damageValue;
		this.SkillId = skillId;
	}

	// Token: 0x06018994 RID: 100756 RVA: 0x006ED7CC File Offset: 0x006EB9CC
	[NullableContext(1)]
	public override string ParseToString()
	{
		string[] entityConfigNameAndSkillName = CombatDataBase.GetEntityConfigNameAndSkillName(this.AttackerId, this.DamageId, this.SkillId);
		string entityConfigName = CombatDataBase.GetEntityConfigName(this.TargetId);
		float currentValue = Singleton<EntitySystem>.Instance.Get(this.TargetId).GetComponent<BaseAttributeComponent>().GetCurrentValue(EAttributeType.Life);
		return StringUtils.Format("<Date>[{0}]</><Atk>{1}</>施放了<Skill>{2}</>对<Victim>{3}</>造成<NumDmg>{4}</>点伤害<Change>{5}</>", new string[]
		{
			this.DateCreate,
			entityConfigNameAndSkillName[0] ?? "",
			entityConfigNameAndSkillName[1] ?? "",
			entityConfigName ?? "",
			this.DamageValue.ToString(),
			(currentValue <= 0f) ? "(死亡)" : StringUtils.Format("({0}->{1})", new string[]
			{
				((int)currentValue + this.DamageValue).ToString(),
				((int)currentValue).ToString()
			})
		});
	}

	// Token: 0x0400BE5D RID: 48733
	public readonly long DamageId;

	// Token: 0x0400BE5E RID: 48734
	public readonly int DamageValue;

	// Token: 0x0400BE5F RID: 48735
	public readonly int SkillId;
}
