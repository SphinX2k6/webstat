using System;

// Token: 0x02000BB9 RID: 3001
public abstract class SingletonGenericBase
{
	// Token: 0x060030D8 RID: 12504 RVA: 0x0001AF6A File Offset: 0x0001916A
	protected virtual bool OnInit()
	{
		return true;
	}

	// Token: 0x060030D9 RID: 12505 RVA: 0x0001AF6D File Offset: 0x0001916D
	protected virtual bool OnClear()
	{
		return true;
	}
}
