using System;
using System.Runtime.CompilerServices;

// Token: 0x02002ECC RID: 11980
public class CombatDataBuffAdded : CombatDataBase
{
	// Token: 0x06018999 RID: 100761 RVA: 0x006EDA2A File Offset: 0x006EBC2A
	public CombatDataBuffAdded(int attackerId, long buffId, int targetId = 0) : base(attackerId, targetId)
	{
		this.BuffId = buffId;
	}

	// Token: 0x0601899A RID: 100762 RVA: 0x006EDA3C File Offset: 0x006EBC3C
	[NullableContext(1)]
	public override string ParseToString()
	{
		string entityConfigName = CombatDataBase.GetEntityConfigName(this.AttackerId);
		string entityConfigName2 = CombatDataBase.GetEntityConfigName(this.TargetId);
		return StringUtils.Format("<Date>{0}</><Victim>{1}</>获得了<Atk>{2}</>添加的Buff<NumDmg>{3}</>", new string[]
		{
			this.DateCreate,
			entityConfigName2 ?? "",
			entityConfigName ?? "",
			this.BuffId.ToString()
		});
	}

	// Token: 0x0400BE64 RID: 48740
	public readonly long BuffId;
}
