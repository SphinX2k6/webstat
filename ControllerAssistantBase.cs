using System;

// Token: 0x02001DD2 RID: 7634
public abstract class ControllerAssistantBase
{
	// Token: 0x0600E1FC RID: 57852 RVA: 0x003CE27E File Offset: 0x003CC47E
	public void Init()
	{
		this.OnInit();
	}

	// Token: 0x0600E1FD RID: 57853 RVA: 0x003CE286 File Offset: 0x003CC486
	protected virtual void OnInit()
	{
	}

	// Token: 0x0600E1FE RID: 57854 RVA: 0x003CE288 File Offset: 0x003CC488
	public virtual void OnRegisterNetEvent()
	{
	}

	// Token: 0x0600E1FF RID: 57855 RVA: 0x003CE28A File Offset: 0x003CC48A
	public virtual void OnUnRegisterNetEvent()
	{
	}

	// Token: 0x0600E200 RID: 57856 RVA: 0x003CE28C File Offset: 0x003CC48C
	public virtual void OnAddEvents()
	{
	}

	// Token: 0x0600E201 RID: 57857 RVA: 0x003CE28E File Offset: 0x003CC48E
	public virtual void OnRemoveEvents()
	{
	}

	// Token: 0x0600E202 RID: 57858 RVA: 0x003CE290 File Offset: 0x003CC490
	public void Destroy()
	{
		this.OnDestroy();
	}

	// Token: 0x0600E203 RID: 57859
	protected abstract void OnDestroy();
}
