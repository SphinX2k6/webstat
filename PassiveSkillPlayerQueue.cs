using System;
using System.Runtime.CompilerServices;

// Token: 0x02002FBF RID: 12223
[NullableContext(1)]
[Nullable(0)]
public class PassiveSkillPlayerQueue
{
	// Token: 0x06018ED0 RID: 102096 RVA: 0x00710166 File Offset: 0x0070E366
	public bool DoActionCheckCd(TPassiveSkillQueueCallback func)
	{
		if (this.NextActionTimer != null)
		{
			this.ActionQueue.Push(func);
			return false;
		}
		this.DoAction(func);
		return true;
	}

	// Token: 0x06018ED1 RID: 102097 RVA: 0x00710186 File Offset: 0x0070E386
	private void ClearTimer()
	{
		if (this.NextActionTimer == null)
		{
			return;
		}
		if (TimerSystem.Instance.Has(this.NextActionTimer))
		{
			TimerSystem.Instance.Remove(this.NextActionTimer);
		}
		this.NextActionTimer = null;
	}

	// Token: 0x06018ED2 RID: 102098 RVA: 0x007101BC File Offset: 0x0070E3BC
	private void DoNextAction(float _)
	{
		this.ClearTimer();
		if (this.ActionQueue.Size == 0)
		{
			return;
		}
		TPassiveSkillQueueCallback tpassiveSkillQueueCallback = this.ActionQueue.Pop();
		if (tpassiveSkillQueueCallback != null)
		{
			this.DoAction(tpassiveSkillQueueCallback);
		}
	}

	// Token: 0x06018ED3 RID: 102099 RVA: 0x007101F4 File Offset: 0x0070E3F4
	private void DoAction(TPassiveSkillQueueCallback func)
	{
		this.ClearTimer();
		int num = func();
		if (num > 20)
		{
			this.NextActionTimer = TimerSystem.Instance.Delay(new TTimerAction(this.DoNextAction), (float)num, null, null, true, 1f);
			return;
		}
		this.NextActionTimer = TimerSystem.Instance.Next(new TTimerAction(this.DoNextAction), null, null);
	}

	// Token: 0x06018ED4 RID: 102100 RVA: 0x00710258 File Offset: 0x0070E458
	public void Clear()
	{
		this.ClearTimer();
		this.ActionQueue.Clear();
	}

	// Token: 0x0400C2D7 RID: 49879
	private readonly Queue<TPassiveSkillQueueCallback> ActionQueue = new Queue<TPassiveSkillQueueCallback>(4);

	// Token: 0x0400C2D8 RID: 49880
	[Nullable(2)]
	private TimerHandle NextActionTimer;
}
