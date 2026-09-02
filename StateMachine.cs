using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02000C23 RID: 3107
public class StateMachine<[Nullable(1)] TObject, TState> where TObject : class where TState : struct, Enum
{
	// Token: 0x170000EA RID: 234
	// (get) Token: 0x060035A4 RID: 13732 RVA: 0x00032114 File Offset: 0x00030314
	public TState? CurrentState
	{
		get
		{
			return new TState?((this.CurrentNode != null) ? this.CurrentNode.State : default(TState));
		}
	}

	// Token: 0x060035A5 RID: 13733 RVA: 0x00032144 File Offset: 0x00030344
	[NullableContext(1)]
	public StateMachine(TObject owner, [Nullable(new byte[]
	{
		2,
		0,
		0
	})] Action<TState, TState> onSwitchState = null)
	{
		this.Owner = owner;
		this.OnSwitchState = onSwitchState;
	}

	// Token: 0x060035A6 RID: 13734 RVA: 0x00032168 File Offset: 0x00030368
	public bool Start(TState state)
	{
		if (this.CurrentNode != null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.StateMachine;
			ELogAuthor author = ELogAuthor.HCS;
			string message = "状态机重复启动";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("state", state);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		this.CurrentNode = this.GetState(state);
		if (this.CurrentNode == null)
		{
			return false;
		}
		this.CurrentNode.Start();
		if (this.OnSwitchState != null)
		{
			this.OnSwitchState(state, state);
		}
		return true;
	}

	// Token: 0x060035A7 RID: 13735 RVA: 0x000321E4 File Offset: 0x000303E4
	public void Destroy()
	{
		foreach (StateBase<TObject, TState> stateBase in this.StateMap.Values)
		{
			stateBase.Destroy();
		}
	}

	// Token: 0x060035A8 RID: 13736 RVA: 0x0003223C File Offset: 0x0003043C
	public bool Switch(TState state)
	{
		if (this.CurrentNode == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.StateMachine;
			ELogAuthor author = ELogAuthor.HCS;
			string message = "状态机没有开始";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("state", state);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		StateBase<TObject, TState> state2 = this.GetState(state);
		if (state2 == null)
		{
			return false;
		}
		if (EqualityComparer<TState>.Default.Equals(state, this.CurrentNode.State))
		{
			if (!this.CurrentNode.CanReEnter())
			{
				return false;
			}
			this.CurrentNode.ReEnter();
			return true;
		}
		else
		{
			TState state3 = this.CurrentNode.State;
			if (!state2.CanChangeFrom(state3))
			{
				return false;
			}
			this.CurrentNode.Exit(state);
			this.CurrentNode = state2;
			this.CurrentNode.Enter(state3);
			if (this.OnSwitchState != null)
			{
				this.OnSwitchState(state3, state);
			}
			return true;
		}
	}

	// Token: 0x060035A9 RID: 13737 RVA: 0x0003230C File Offset: 0x0003050C
	public void Update(float delta)
	{
		if (this.CurrentNode != null)
		{
			this.CurrentNode.Update(delta);
		}
	}

	// Token: 0x060035AA RID: 13738 RVA: 0x00032324 File Offset: 0x00030524
	public void AddState<T>(TState state, [Nullable(2)] IEntityArgs args = null) where T : StateBase<TObject, TState>
	{
		if (this.StateMap.ContainsKey(state))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.StateMachine;
			ELogAuthor author = ELogAuthor.HCS;
			string message = "状态重复添加";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("state", state);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		T t = Activator.CreateInstance(typeof(T), new object[]
		{
			this.Owner,
			state,
			this
		}) as T;
		this.StateMap[state] = t;
		t.Create(args);
	}

	// Token: 0x060035AB RID: 13739 RVA: 0x000323C8 File Offset: 0x000305C8
	[return: Nullable(new byte[]
	{
		2,
		1,
		0
	})]
	public StateBase<TObject, TState> GetState(TState state)
	{
		StateBase<TObject, TState> result;
		if (this.StateMap.TryGetValue(state, out result))
		{
			return result;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.StateMachine;
		ELogAuthor author = ELogAuthor.HCS;
		string message = "状态不存在";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("state", state);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x04000680 RID: 1664
	[Nullable(1)]
	public readonly TObject Owner;

	// Token: 0x04000681 RID: 1665
	[Nullable(new byte[]
	{
		1,
		0,
		1,
		1,
		0
	})]
	private readonly Dictionary<TState, StateBase<TObject, TState>> StateMap = new Dictionary<TState, StateBase<TObject, TState>>();

	// Token: 0x04000682 RID: 1666
	[Nullable(new byte[]
	{
		2,
		1,
		0
	})]
	private StateBase<TObject, TState> CurrentNode;

	// Token: 0x04000683 RID: 1667
	[Nullable(new byte[]
	{
		2,
		0,
		0
	})]
	private readonly Action<TState, TState> OnSwitchState;

	// Token: 0x04000684 RID: 1668
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static readonly Stat Stat0 = Stat.Create("StateMachine.Stat0", "", "");

	// Token: 0x04000685 RID: 1669
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static readonly Stat Stat1 = Stat.Create("StateMachine.Stat1", "", "");

	// Token: 0x04000686 RID: 1670
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static readonly Stat Stat2 = Stat.Create("StateMachine.Stat2", "", "");

	// Token: 0x04000687 RID: 1671
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static readonly Stat Stat3 = Stat.Create("StateMachine.Stat3", "", "");
}
