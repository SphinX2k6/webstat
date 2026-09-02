using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020010FA RID: 4346
[NullableContext(1)]
[Nullable(0)]
public abstract class GuessJokerFsmBase<[Nullable(2)] TType, [Nullable(0)] TState> where TState : GuessJokerStageBase
{
	// Token: 0x06007128 RID: 28968 RVA: 0x001D96D2 File Offset: 0x001D78D2
	public void Init()
	{
		this.InitStateInstance();
	}

	// Token: 0x06007129 RID: 28969 RVA: 0x001D96DA File Offset: 0x001D78DA
	public void Tick(float deltaTime)
	{
		if (this.CurrentState != null)
		{
			this.CurrentState.Tick(deltaTime);
		}
	}

	// Token: 0x0600712A RID: 28970 RVA: 0x001D96FC File Offset: 0x001D78FC
	protected void RegisterState(TType type, TState state)
	{
		if (this.StateMap.ContainsKey(type))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GuessJokerCard;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "GuessJokerFsmBase 注册状态失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("stateType", type);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.StateMap[type] = state;
	}

	// Token: 0x0600712B RID: 28971 RVA: 0x001D9754 File Offset: 0x001D7954
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

	// Token: 0x0600712C RID: 28972 RVA: 0x001D97C0 File Offset: 0x001D79C0
	[return: Nullable(2)]
	private TState GetStateInstance(TType stateType)
	{
		TState result;
		if (!this.StateMap.TryGetValue(stateType, out result))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GuessJokerCard;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "GuessJokerFsmBase 获取状态实例失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("stateType", stateType);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return default(TState);
		}
		return result;
	}

	// Token: 0x0600712D RID: 28973 RVA: 0x001D9817 File Offset: 0x001D7A17
	public TType GetCurrentStateType()
	{
		return this.CurrentStateType;
	}

	// Token: 0x0600712E RID: 28974 RVA: 0x001D981F File Offset: 0x001D7A1F
	[NullableContext(2)]
	public TState GetCurrentState()
	{
		return this.CurrentState;
	}

	// Token: 0x0600712F RID: 28975
	protected abstract void InitStateInstance();

	// Token: 0x06007130 RID: 28976
	protected abstract bool CheckCanChangeState(TType curStateType, TType nextStateType);

	// Token: 0x0400366F RID: 13935
	[Nullable(2)]
	protected TState CurrentState;

	// Token: 0x04003670 RID: 13936
	protected TType CurrentStateType;

	// Token: 0x04003671 RID: 13937
	protected Dictionary<TType, TState> StateMap = new Dictionary<TType, TState>();
}
