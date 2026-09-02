using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F8E RID: 12174
[NullableContext(1)]
[Nullable(0)]
public class LevelBuffBase
{
	// Token: 0x06018D5F RID: 101727 RVA: 0x00708678 File Offset: 0x00706878
	public LevelBuffBase(Entity entity, long buffId, string[] @params, float param1, float param2)
	{
		this.Entity = entity;
		this.BuffId = buffId;
		this.Params = @params;
		this.Param1 = param1;
		this.Param2 = param2;
	}

	// Token: 0x06018D60 RID: 101728 RVA: 0x007086A5 File Offset: 0x007068A5
	public virtual void OnCreated()
	{
	}

	// Token: 0x06018D61 RID: 101729 RVA: 0x007086A7 File Offset: 0x007068A7
	public virtual void OnRemoved(bool bPremature)
	{
	}

	// Token: 0x06018D62 RID: 101730 RVA: 0x007086A9 File Offset: 0x007068A9
	public virtual void OnStackChanged(int newCount, int oldCount, bool bPremature)
	{
	}

	// Token: 0x0400C1E0 RID: 49632
	protected readonly Entity Entity;

	// Token: 0x0400C1E1 RID: 49633
	protected readonly long BuffId;

	// Token: 0x0400C1E2 RID: 49634
	protected readonly string[] Params;

	// Token: 0x0400C1E3 RID: 49635
	protected readonly float Param1;

	// Token: 0x0400C1E4 RID: 49636
	protected readonly float Param2;
}
