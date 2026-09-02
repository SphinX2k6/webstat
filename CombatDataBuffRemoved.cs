using System;
using System.Runtime.CompilerServices;

// Token: 0x02002ECD RID: 11981
public class CombatDataBuffRemoved : CombatDataBase
{
	// Token: 0x0601899B RID: 100763 RVA: 0x006EDAA2 File Offset: 0x006EBCA2
	public CombatDataBuffRemoved(int attackerId, long buffId, int targetId = 0) : base(attackerId, targetId)
	{
		this.BuffId = buffId;
	}

	// Token: 0x0601899C RID: 100764 RVA: 0x006EDAB4 File Offset: 0x006EBCB4
	[NullableContext(1)]
	public override string ParseToString()
	{
		string entityConfigName = CombatDataBase.GetEntityConfigName(this.TargetId);
		return StringUtils.Format("<Date>{0}</><Victim>{1}</>失去了Buff<NumDmg>{2}</>", new string[]
		{
			this.DateCreate,
			entityConfigName ?? "",
			this.BuffId.ToString()
		});
	}

	// Token: 0x0400BE65 RID: 48741
	public readonly long BuffId;
}
