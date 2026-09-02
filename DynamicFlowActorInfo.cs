using System;

// Token: 0x02003085 RID: 12421
public class DynamicFlowActorInfo
{
	// Token: 0x060199D2 RID: 104914 RVA: 0x00771D8F File Offset: 0x0076FF8F
	public bool IsValid()
	{
		return this.CreatureId != 0L || this.PbDataId != 0;
	}

	// Token: 0x0400CBD3 RID: 52179
	public long CreatureId;

	// Token: 0x0400CBD4 RID: 52180
	public int PbDataId;
}
