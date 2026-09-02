using System;
using System.Runtime.CompilerServices;

// Token: 0x0200318C RID: 12684
public abstract class PerformAction
{
	// Token: 0x0601A4D7 RID: 107735 RVA: 0x007BF15B File Offset: 0x007BD35B
	[NullableContext(1)]
	public virtual void Register(Entity entity)
	{
		this.Entity = entity;
	}

	// Token: 0x0601A4D8 RID: 107736 RVA: 0x007BF164 File Offset: 0x007BD364
	public virtual void UnRegister()
	{
		this.Entity = null;
	}

	// Token: 0x0601A4D9 RID: 107737 RVA: 0x007BF16D File Offset: 0x007BD36D
	public virtual void Begin()
	{
	}

	// Token: 0x0601A4DA RID: 107738 RVA: 0x007BF16F File Offset: 0x007BD36F
	public virtual void Tick(double delta)
	{
	}

	// Token: 0x0601A4DB RID: 107739 RVA: 0x007BF171 File Offset: 0x007BD371
	public virtual void End()
	{
	}

	// Token: 0x0400D405 RID: 54277
	public EPerformActionType Type;

	// Token: 0x0400D406 RID: 54278
	[Nullable(2)]
	public Entity Entity;
}
