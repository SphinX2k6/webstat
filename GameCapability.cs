using System;

// Token: 0x02000E3A RID: 3642
public class GameCapability : IGameCapability
{
	// Token: 0x06005729 RID: 22313 RVA: 0x00105407 File Offset: 0x00103607
	public virtual bool ShouldActivate()
	{
		return false;
	}

	// Token: 0x0600572A RID: 22314 RVA: 0x0010540A File Offset: 0x0010360A
	public virtual void Activate()
	{
	}

	// Token: 0x0600572B RID: 22315 RVA: 0x0010540C File Offset: 0x0010360C
	public virtual void OnActivated()
	{
	}

	// Token: 0x0600572C RID: 22316 RVA: 0x0010540E File Offset: 0x0010360E
	public virtual bool ShouldDeactivate()
	{
		return false;
	}

	// Token: 0x0600572D RID: 22317 RVA: 0x00105411 File Offset: 0x00103611
	public virtual void Deactivate()
	{
	}

	// Token: 0x0600572E RID: 22318 RVA: 0x00105413 File Offset: 0x00103613
	public virtual bool? ShouldTickActive()
	{
		return new bool?(false);
	}

	// Token: 0x0600572F RID: 22319 RVA: 0x0010541B File Offset: 0x0010361B
	public virtual void OnDeactivated()
	{
	}

	// Token: 0x06005730 RID: 22320 RVA: 0x0010541D File Offset: 0x0010361D
	public virtual void TickActive(float deltaTime)
	{
	}
}
