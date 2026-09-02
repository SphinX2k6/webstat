using System;

// Token: 0x02001496 RID: 5270
public class PinballLockedRoleData : PinballRoleDataBase
{
	// Token: 0x0600937A RID: 37754 RVA: 0x0026EE2F File Offset: 0x0026D02F
	public PinballLockedRoleData(int id) : base(id)
	{
	}

	// Token: 0x0600937B RID: 37755 RVA: 0x0026EE38 File Offset: 0x0026D038
	public override bool IsLocked()
	{
		return true;
	}
}
