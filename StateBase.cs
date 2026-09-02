using System;
using System.Runtime.CompilerServices;

// Token: 0x02000C22 RID: 3106
public abstract class StateBase<[Nullable(1)] TObject, TState> where TObject : class where TState : struct, Enum
{
	// Token: 0x06003592 RID: 13714 RVA: 0x0003208C File Offset: 0x0003028C
	public StateBase([Nullable(1)] TObject owner, TState state, [Nullable(new byte[]
	{
		2,
		1,
		0
	})] StateMachine<TObject, TState> stateMachine)
	{
		this.Owner = owner;
		this.State = state;
		this.StateMachine = stateMachine;
	}

	// Token: 0x06003593 RID: 13715 RVA: 0x000320A9 File Offset: 0x000302A9
	[return: Nullable(new byte[]
	{
		2,
		1,
		0
	})]
	public StateBase<TObject, TState> GetState(TState state)
	{
		StateMachine<TObject, TState> stateMachine = this.StateMachine;
		if (stateMachine == null)
		{
			return null;
		}
		return stateMachine.GetState(state);
	}

	// Token: 0x06003594 RID: 13716 RVA: 0x000320BD File Offset: 0x000302BD
	[NullableContext(2)]
	public void Create(IEntityArgs args = null)
	{
		this.OnCreate(args);
	}

	// Token: 0x06003595 RID: 13717 RVA: 0x000320C6 File Offset: 0x000302C6
	public void Start()
	{
		this.OnStart();
	}

	// Token: 0x06003596 RID: 13718 RVA: 0x000320CE File Offset: 0x000302CE
	public void Update(float delta)
	{
		this.OnUpdate(delta);
	}

	// Token: 0x06003597 RID: 13719 RVA: 0x000320D7 File Offset: 0x000302D7
	public void Enter(TState lastState)
	{
		this.OnEnter(new TState?(lastState));
	}

	// Token: 0x06003598 RID: 13720 RVA: 0x000320E5 File Offset: 0x000302E5
	public void ReEnter()
	{
		this.OnReEnter();
	}

	// Token: 0x06003599 RID: 13721 RVA: 0x000320ED File Offset: 0x000302ED
	public void Exit(TState nextState)
	{
		this.OnExit(nextState);
	}

	// Token: 0x0600359A RID: 13722 RVA: 0x000320F6 File Offset: 0x000302F6
	public void Destroy()
	{
		this.OnDestroy();
	}

	// Token: 0x0600359B RID: 13723 RVA: 0x000320FE File Offset: 0x000302FE
	public virtual bool CanReEnter()
	{
		return false;
	}

	// Token: 0x0600359C RID: 13724 RVA: 0x00032101 File Offset: 0x00030301
	public virtual bool CanChangeFrom(TState fromState)
	{
		return true;
	}

	// Token: 0x0600359D RID: 13725 RVA: 0x00032104 File Offset: 0x00030304
	[NullableContext(2)]
	protected virtual void OnCreate(IEntityArgs args = null)
	{
	}

	// Token: 0x0600359E RID: 13726 RVA: 0x00032106 File Offset: 0x00030306
	protected virtual void OnStart()
	{
	}

	// Token: 0x0600359F RID: 13727 RVA: 0x00032108 File Offset: 0x00030308
	protected virtual void OnUpdate(float delta)
	{
	}

	// Token: 0x060035A0 RID: 13728 RVA: 0x0003210A File Offset: 0x0003030A
	protected virtual void OnEnter(TState? lastState)
	{
	}

	// Token: 0x060035A1 RID: 13729 RVA: 0x0003210C File Offset: 0x0003030C
	protected virtual void OnReEnter()
	{
	}

	// Token: 0x060035A2 RID: 13730 RVA: 0x0003210E File Offset: 0x0003030E
	protected virtual void OnExit(TState nextState)
	{
	}

	// Token: 0x060035A3 RID: 13731 RVA: 0x00032110 File Offset: 0x00030310
	protected virtual void OnDestroy()
	{
	}

	// Token: 0x0400067D RID: 1661
	[Nullable(1)]
	public readonly TObject Owner;

	// Token: 0x0400067E RID: 1662
	public readonly TState State;

	// Token: 0x0400067F RID: 1663
	[Nullable(new byte[]
	{
		2,
		1,
		0
	})]
	protected StateMachine<TObject, TState> StateMachine;
}
