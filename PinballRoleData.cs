using System;

// Token: 0x02001498 RID: 5272
public class PinballRoleData : PinballRoleDataBase
{
	// Token: 0x06009381 RID: 37761 RVA: 0x0026F089 File Offset: 0x0026D289
	public PinballRoleData(int id) : base(id)
	{
	}

	// Token: 0x06009382 RID: 37762 RVA: 0x0026F092 File Offset: 0x0026D292
	public override bool IsLocked()
	{
		return false;
	}
}
