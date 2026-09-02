using System;
using System.Runtime.CompilerServices;

// Token: 0x02002ECF RID: 11983
public class CombatDataRevive : CombatDataBase
{
	// Token: 0x0601899F RID: 100767 RVA: 0x006EDB64 File Offset: 0x006EBD64
	public CombatDataRevive(int attackerId) : base(attackerId, 0)
	{
	}

	// Token: 0x060189A0 RID: 100768 RVA: 0x006EDB70 File Offset: 0x006EBD70
	[NullableContext(1)]
	public override string ParseToString()
	{
		string entityConfigName = CombatDataBase.GetEntityConfigName(this.AttackerId);
		return StringUtils.Format("<Date>{0}</><Atk>{1}</>复活", new string[]
		{
			this.DateCreate,
			entityConfigName ?? ""
		});
	}
}
