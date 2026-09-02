using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001C1D RID: 7197
public abstract class FloroRanchFsmBase<TType, TState> where TType : struct where TState : FloroRanchStateBase
{
	// Token: 0x0600D140 RID: 53568 RVA: 0x00378C57 File Offset: 0x00376E57
	public void Init()
	{
		this.InitStateInstance();
	}

	// Token: 0x0600D141 RID: 53569 RVA: 0x00378C5F File Offset: 0x00376E5F
	public void Tick(float deltaTime)
	{
		if (this.CurrentState != null)
		{
			this.CurrentState.Tick(deltaTime);
		}
	}

	// Token: 0x0600D142 RID: 53570 RVA: 0x00378C80 File Offset: 0x00376E80
	protected void RegisterState(TType type, [Nullable(1)] TState state)
	{
		if (this.StateMap.ContainsKey(type))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanchGamePlay;
			ELogAuthor author = ELogAuthor.BB;
			string message = "FloroRanchFsmBase 注册状态失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("stateType", type);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.StateMap.Add(type, state);
	}

	// Token: 0x0600D143 RID: 53571 RVA: 0x00378CD8 File Offset: 0x00376ED8
	public void ChangeState(TType stateType)
	{
		if (!this.CheckCanChangeState(this.CurrentStateType, stateType))
		{
			return;
		}
		TState stateInstance = this.GetStateInstance(stateType);
		if (stateInstance == null)
		{
			return;
		}
		if (this.CurrentState != null)
		{
			this.CurrentState.Exit();
		}
		this.CurrentStateType = stateType;
		this.CurrentState = stateInstance;
		this.CurrentState.Enter();
	}

	// Token: 0x0600D144 RID: 53572 RVA: 0x00378D44 File Offset: 0x00376F44
	[return: Nullable(2)]
	private TState GetStateInstance(TType stateType)
	{
		if (!this.StateMap.ContainsKey(stateType))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanchGamePlay;
			ELogAuthor author = ELogAuthor.BB;
			string message = "FloroRanchStageFsm 获取状态实例失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("stateType", stateType);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return default(TState);
		}
		return this.StateMap[stateType];
	}

	// Token: 0x0600D145 RID: 53573 RVA: 0x00378DA4 File Offset: 0x00376FA4
	public TType GetCurrentStateType()
	{
		return this.CurrentStateType;
	}

	// Token: 0x0600D146 RID: 53574 RVA: 0x00378DAC File Offset: 0x00376FAC
	[NullableContext(2)]
	public TState GetCurrentState()
	{
		return this.CurrentState;
	}

	// Token: 0x0600D147 RID: 53575
	protected abstract void InitStateInstance();

	// Token: 0x0600D148 RID: 53576
	protected abstract bool CheckCanChangeState(TType curStateType, TType nextStateType);

	// Token: 0x040063EF RID: 25583
	[Nullable(2)]
	protected TState CurrentState;

	// Token: 0x040063F0 RID: 25584
	protected TType CurrentStateType;

	// Token: 0x040063F1 RID: 25585
	[Nullable(new byte[]
	{
		1,
		0,
		1
	})]
	protected Dictionary<TType, TState> StateMap = new Dictionary<TType, TState>();
}
