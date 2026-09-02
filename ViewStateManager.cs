using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020013B5 RID: 5045
[NullableContext(1)]
[Nullable(0)]
internal class ViewStateManager
{
	// Token: 0x06008B34 RID: 35636 RVA: 0x0024AB7D File Offset: 0x00248D7D
	public ViewStateManager()
	{
		this.CurrentStateInternal = EBusinessSkipDefine.MainView;
		this.PushStateStack.Push(this.CurrentStateInternal);
	}

	// Token: 0x06008B35 RID: 35637 RVA: 0x0024ABB4 File Offset: 0x00248DB4
	[NullableContext(2)]
	public void RegisterViewState(EBusinessSkipDefine state, Action exitFunc, Delegate enterFunc)
	{
		ViewStateData value = new ViewStateData(state, exitFunc, enterFunc);
		this.StateMap[state] = value;
	}

	// Token: 0x06008B36 RID: 35638 RVA: 0x0024ABD8 File Offset: 0x00248DD8
	public void SwitchToState(EBusinessSkipDefine state, params object[] params_)
	{
		this.PushStateStack.Push(state);
		ViewStateData viewStateData;
		if (this.StateMap.TryGetValue(this.CurrentStateInternal, out viewStateData))
		{
			Action exitFunc = viewStateData.ExitFunc;
			if (exitFunc != null)
			{
				exitFunc();
			}
		}
		this.CurrentStateInternal = state;
		ViewStateData viewStateData2;
		if (this.StateMap.TryGetValue(this.CurrentStateInternal, out viewStateData2))
		{
			viewStateData2.Params = params_;
			Action<object[]> action = viewStateData2.EnterFunc as Action<object[]>;
			if (action != null)
			{
				action(params_);
				return;
			}
			Action action2 = viewStateData2.EnterFunc as Action;
			if (action2 != null)
			{
				action2();
			}
		}
	}

	// Token: 0x06008B37 RID: 35639 RVA: 0x0024AC68 File Offset: 0x00248E68
	public void BackToState(EBusinessSkipDefine state)
	{
		if (this.CurrentStateInternal == state)
		{
			return;
		}
		while (this.PushStateStack.Peek() != state)
		{
			EBusinessSkipDefine key = this.PushStateStack.Pop();
			ViewStateData viewStateData;
			if (this.StateMap.TryGetValue(key, out viewStateData))
			{
				Action exitFunc = viewStateData.ExitFunc;
				if (exitFunc != null)
				{
					exitFunc();
				}
			}
		}
		this.CurrentStateInternal = state;
		ViewStateData viewStateData2;
		if (this.StateMap.TryGetValue(this.CurrentStateInternal, out viewStateData2))
		{
			Action<object[]> action = viewStateData2.EnterFunc as Action<object[]>;
			if (action != null)
			{
				action(viewStateData2.Params);
				return;
			}
			Action action2 = viewStateData2.EnterFunc as Action;
			if (action2 != null)
			{
				action2();
			}
		}
	}

	// Token: 0x06008B38 RID: 35640 RVA: 0x0024AD0C File Offset: 0x00248F0C
	public void BackToLastState()
	{
		EBusinessSkipDefine key = this.PushStateStack.Pop();
		ViewStateData viewStateData;
		if (this.StateMap.TryGetValue(key, out viewStateData))
		{
			Action exitFunc = viewStateData.ExitFunc;
			if (exitFunc != null)
			{
				exitFunc();
			}
		}
		this.CurrentStateInternal = this.PushStateStack.Peek();
		ViewStateData viewStateData2;
		if (this.StateMap.TryGetValue(this.CurrentStateInternal, out viewStateData2))
		{
			Action<object[]> action = viewStateData2.EnterFunc as Action<object[]>;
			if (action != null)
			{
				action(viewStateData2.Params);
				return;
			}
			Action action2 = viewStateData2.EnterFunc as Action;
			if (action2 != null)
			{
				action2();
			}
		}
	}

	// Token: 0x17000BCE RID: 3022
	// (get) Token: 0x06008B39 RID: 35641 RVA: 0x0024ADA0 File Offset: 0x00248FA0
	public EBusinessSkipDefine CurrentState
	{
		get
		{
			return this.CurrentStateInternal;
		}
	}

	// Token: 0x0400410A RID: 16650
	private readonly global::Stack<EBusinessSkipDefine> PushStateStack = new global::Stack<EBusinessSkipDefine>();

	// Token: 0x0400410B RID: 16651
	private EBusinessSkipDefine CurrentStateInternal;

	// Token: 0x0400410C RID: 16652
	private readonly Dictionary<EBusinessSkipDefine, ViewStateData> StateMap = new Dictionary<EBusinessSkipDefine, ViewStateData>();
}
