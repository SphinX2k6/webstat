using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020010E7 RID: 4327
[NullableContext(1)]
[Nullable(0)]
public class GuessJokerActionRunner<[Nullable(0)] T> where T : GuessJokerActionBase
{
	// Token: 0x060070AD RID: 28845 RVA: 0x001D6D09 File Offset: 0x001D4F09
	public void PushAction(T action)
	{
		this.Queue.Add(action);
	}

	// Token: 0x060070AE RID: 28846 RVA: 0x001D6D18 File Offset: 0x001D4F18
	public void PushActions(IReadOnlyList<T> actions)
	{
		foreach (T item in actions)
		{
			this.Queue.Add(item);
		}
	}

	// Token: 0x060070AF RID: 28847 RVA: 0x001D6D68 File Offset: 0x001D4F68
	public void Tick(float delta)
	{
		if (this.CurrentAction == null)
		{
			this.CurrentAction = this.GetNextAction();
			if (this.CurrentAction != null)
			{
				this.CurrentAction.Start();
			}
		}
		if (this.CurrentAction != null)
		{
			this.CurrentAction.Tick(delta);
			if (this.CurrentAction.IsDone())
			{
				this.OnActionDone(this.CurrentAction);
				this.CurrentAction.Finish();
				this.CurrentAction = default(T);
			}
		}
		this.OnTick(delta);
	}

	// Token: 0x060070B0 RID: 28848 RVA: 0x001D6E0A File Offset: 0x001D500A
	public void Destroy()
	{
		this.OnDestroy();
		if (this.CurrentAction != null)
		{
			this.CurrentAction.Finish();
		}
		this.Queue.Clear();
		this.CurrentAction = default(T);
	}

	// Token: 0x060070B1 RID: 28849 RVA: 0x001D6E48 File Offset: 0x001D5048
	[NullableContext(2)]
	protected T GetNextAction()
	{
		if (this.Queue.Count == 0)
		{
			return default(T);
		}
		T result = this.Queue[0];
		this.Queue.RemoveAt(0);
		return result;
	}

	// Token: 0x060070B2 RID: 28850 RVA: 0x001D6E84 File Offset: 0x001D5084
	protected virtual void OnTick(float delta)
	{
	}

	// Token: 0x060070B3 RID: 28851 RVA: 0x001D6E86 File Offset: 0x001D5086
	protected virtual void OnActionDone(T action)
	{
	}

	// Token: 0x060070B4 RID: 28852 RVA: 0x001D6E88 File Offset: 0x001D5088
	protected virtual void OnDestroy()
	{
	}

	// Token: 0x04003633 RID: 13875
	protected readonly List<T> Queue = new List<T>();

	// Token: 0x04003634 RID: 13876
	[Nullable(2)]
	protected T CurrentAction;
}
