using System;

// Token: 0x02000BAE RID: 2990
public abstract class ConfigGenericBase : IConfigBase
{
	// Token: 0x06003086 RID: 12422 RVA: 0x0001AA8E File Offset: 0x00018C8E
	public bool Init()
	{
		return this.OnInit();
	}

	// Token: 0x06003087 RID: 12423 RVA: 0x0001AA96 File Offset: 0x00018C96
	public bool Clear()
	{
		return this.OnClear();
	}

	// Token: 0x06003088 RID: 12424 RVA: 0x0001AA9E File Offset: 0x00018C9E
	protected virtual bool OnInit()
	{
		return true;
	}

	// Token: 0x06003089 RID: 12425 RVA: 0x0001AAA1 File Offset: 0x00018CA1
	protected virtual bool OnClear()
	{
		return true;
	}
}
