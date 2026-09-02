using System;
using System.Runtime.CompilerServices;

// Token: 0x02001C1E RID: 7198
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchStateBase
{
	// Token: 0x0600D14A RID: 53578 RVA: 0x00378DC7 File Offset: 0x00376FC7
	public FloroRanchStateBase(FloroRanchStageFsm stageFsm)
	{
		this.StageFsm = stageFsm;
	}

	// Token: 0x0600D14B RID: 53579 RVA: 0x00378DD6 File Offset: 0x00376FD6
	public void Create()
	{
		this.OnCreate();
	}

	// Token: 0x0600D14C RID: 53580 RVA: 0x00378DDE File Offset: 0x00376FDE
	public void Enter()
	{
		this.IsActive = true;
		this.OnEnter();
		this.OnAddEventListener();
	}

	// Token: 0x0600D14D RID: 53581 RVA: 0x00378DF3 File Offset: 0x00376FF3
	public void Tick(float deltaTime)
	{
		if (!this.IsActive)
		{
			return;
		}
		this.OnTick(deltaTime);
	}

	// Token: 0x0600D14E RID: 53582 RVA: 0x00378E05 File Offset: 0x00377005
	public void Exit()
	{
		this.OnRemoveEventListener();
		this.OnExit();
		this.IsActive = false;
	}

	// Token: 0x0600D14F RID: 53583 RVA: 0x00378E1A File Offset: 0x0037701A
	protected virtual void OnCreate()
	{
	}

	// Token: 0x0600D150 RID: 53584 RVA: 0x00378E1C File Offset: 0x0037701C
	protected virtual void OnEnter()
	{
	}

	// Token: 0x0600D151 RID: 53585 RVA: 0x00378E1E File Offset: 0x0037701E
	protected virtual void OnAddEventListener()
	{
	}

	// Token: 0x0600D152 RID: 53586 RVA: 0x00378E20 File Offset: 0x00377020
	protected virtual void OnTick(float deltaTime)
	{
	}

	// Token: 0x0600D153 RID: 53587 RVA: 0x00378E22 File Offset: 0x00377022
	protected virtual void OnRemoveEventListener()
	{
	}

	// Token: 0x0600D154 RID: 53588 RVA: 0x00378E24 File Offset: 0x00377024
	protected virtual void OnExit()
	{
	}

	// Token: 0x0600D155 RID: 53589 RVA: 0x00378E26 File Offset: 0x00377026
	public void ForceExit()
	{
		this.IsForceExit = true;
		this.AutoExitAfterEnter = true;
	}

	// Token: 0x040063F2 RID: 25586
	protected bool IsActive;

	// Token: 0x040063F3 RID: 25587
	protected bool AutoExitAfterEnter;

	// Token: 0x040063F4 RID: 25588
	protected bool IsForceExit;

	// Token: 0x040063F5 RID: 25589
	protected FloroRanchStageFsm StageFsm;
}
