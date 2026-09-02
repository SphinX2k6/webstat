using System;
using System.Runtime.CompilerServices;

// Token: 0x02002ECE RID: 11982
public class CombatDataKilled : CombatDataBase
{
	// Token: 0x0601899D RID: 100765 RVA: 0x006EDB01 File Offset: 0x006EBD01
	public CombatDataKilled(int attackerId, int targetId) : base(attackerId, targetId)
	{
	}

	// Token: 0x0601899E RID: 100766 RVA: 0x006EDB0C File Offset: 0x006EBD0C
	[NullableContext(1)]
	public override string ParseToString()
	{
		string entityConfigName = CombatDataBase.GetEntityConfigName(this.AttackerId);
		string entityConfigName2 = CombatDataBase.GetEntityConfigName(this.TargetId);
		return StringUtils.Format("<Date>{0}</><Atk>{1}</>消灭了<Victim>{2}</>!", new string[]
		{
			this.DateCreate,
			entityConfigName ?? "",
			entityConfigName2 ?? ""
		});
	}
}
