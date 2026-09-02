using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020010EC RID: 4332
[NullableContext(1)]
[Nullable(0)]
public class GuessJokerPlotActionRunner
{
	// Token: 0x060070DB RID: 28891 RVA: 0x001D7570 File Offset: 0x001D5770
	public void PushPlotActions(IReadOnlyList<GuessJokerPlotAction> actions)
	{
		for (int i = 0; i < actions.Count; i++)
		{
			this.PushPlotAction(actions[i]);
		}
	}

	// Token: 0x060070DC RID: 28892 RVA: 0x001D759C File Offset: 0x001D579C
	private void PushPlotAction(GuessJokerPlotAction action)
	{
		EGuessJokerPlotTiming timing = action.Timing;
		if (this.CurrentAction != null && this.CurrentAction.CanHardCut && action.CanHardCut)
		{
			Singleton<Log>.Instance.Warn(ELogModule.GuessJokerCard, ELogAuthor.LRC, string.Format("猜鬼牌剧情 - PlotActionRunner.PushPlotAction.硬切：打断当前plot {0}，执行新plot {1}", this.CurrentAction.PlotId, action.PlotId), default(ReadOnlySpan<ValueTuple<string, object>>));
			this.InterruptCurrentAction();
			this.CurrentAction = action;
			this.CurrentAction.Start();
			return;
		}
		bool flag = this.IsPlotInQueue(timing, action.PlayerType);
		bool flag2 = this.IsPlotExecuting(timing, action.PlayerType);
		bool flag3 = this.IsPlotInCd(timing, action.PlayerType);
		if (flag || flag2 || flag3)
		{
			return;
		}
		this.ActionEnqueueTimeMap[action] = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
		this.Queue.Add(action);
	}

	// Token: 0x060070DD RID: 28893 RVA: 0x001D767C File Offset: 0x001D587C
	private void InterruptCurrentAction()
	{
		if (this.CurrentAction == null)
		{
			return;
		}
		GuessJokerPlotAction currentAction = this.CurrentAction;
		EGuessJokerPlotTiming timing = currentAction.Timing;
		EGuessJokerPlayerType playerType = currentAction.PlayerType;
		string timingKey = this.GetTimingKey(timing, playerType);
		this.ExecutingTimings.Remove(timingKey);
		this.CurrentActionCdUpdated = false;
		this.ActionEnqueueTimeMap.Remove(currentAction);
		this.OnActionDone(currentAction);
		currentAction.Finish();
		this.CurrentAction = null;
	}

	// Token: 0x060070DE RID: 28894 RVA: 0x001D76E8 File Offset: 0x001D58E8
	private bool IsPlotInQueue(EGuessJokerPlotTiming timing, EGuessJokerPlayerType playerType)
	{
		for (int i = 0; i < this.Queue.Count; i++)
		{
			GuessJokerPlotAction guessJokerPlotAction = this.Queue[i];
			if (guessJokerPlotAction != null && !guessJokerPlotAction.IsDone() && guessJokerPlotAction.Timing == timing && guessJokerPlotAction.PlayerType == playerType)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060070DF RID: 28895 RVA: 0x001D7738 File Offset: 0x001D5938
	private string GetTimingKey(EGuessJokerPlotTiming timing, EGuessJokerPlayerType playerType)
	{
		return string.Format("{0}_{1}", timing, playerType);
	}

	// Token: 0x060070E0 RID: 28896 RVA: 0x001D7750 File Offset: 0x001D5950
	private bool IsPlotExecuting(EGuessJokerPlotTiming timing, EGuessJokerPlayerType playerType)
	{
		string timingKey = this.GetTimingKey(timing, playerType);
		return this.ExecutingTimings.Contains(timingKey);
	}

	// Token: 0x060070E1 RID: 28897 RVA: 0x001D7774 File Offset: 0x001D5974
	private bool IsPlotInCd(EGuessJokerPlotTiming timing, EGuessJokerPlayerType playerType)
	{
		string timingKey = this.GetTimingKey(timing, playerType);
		long num;
		return this.PlotCdMap.TryGetValue(timingKey, out num) && DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() < num;
	}

	// Token: 0x060070E2 RID: 28898 RVA: 0x001D77AC File Offset: 0x001D59AC
	private void UpdateCd(GuessJokerPlotAction action, EGuessJokerPlotTiming timing)
	{
		float cd = action.Cd;
		if (cd > 0f)
		{
			string timingKey = this.GetTimingKey(timing, action.PlayerType);
			this.PlotCdMap[timingKey] = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + (long)cd;
		}
	}

	// Token: 0x060070E3 RID: 28899 RVA: 0x001D77F4 File Offset: 0x001D59F4
	public void Tick(float delta)
	{
		if (this.CurrentAction == null && this.Queue.Count > 0)
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
			GuessJokerPlotAction currentAction = this.CurrentAction;
			EGuessJokerPlotTiming timing = currentAction.Timing;
			EGuessJokerPlayerType playerType = currentAction.PlayerType;
			string timingKey = this.GetTimingKey(timing, playerType);
			if (!this.ExecutingTimings.Contains(timingKey))
			{
				this.ExecutingTimings.Add(timingKey);
			}
			if (!this.CurrentActionCdUpdated && !currentAction.IsInDelay)
			{
				this.UpdateCd(currentAction, timing);
				this.CurrentActionCdUpdated = true;
			}
			if (this.CurrentAction.IsDone())
			{
				this.OnActionDone(this.CurrentAction);
				this.CurrentAction.Finish();
				this.CurrentAction = null;
			}
		}
	}

	// Token: 0x060070E4 RID: 28900 RVA: 0x001D78D0 File Offset: 0x001D5AD0
	[NullableContext(2)]
	protected GuessJokerPlotAction GetNextAction()
	{
		GuessJokerPlotAction result = null;
		while (this.Queue.Count > 0)
		{
			GuessJokerPlotAction guessJokerPlotAction = this.Queue[0];
			this.Queue.RemoveAt(0);
			if (guessJokerPlotAction == null)
			{
				break;
			}
			long num;
			if (!this.ActionEnqueueTimeMap.TryGetValue(guessJokerPlotAction, out num))
			{
				result = guessJokerPlotAction;
				break;
			}
			this.ActionEnqueueTimeMap.Remove(guessJokerPlotAction);
			float waitDeleteTime = guessJokerPlotAction.WaitDeleteTime;
			if (waitDeleteTime <= 0f)
			{
				result = guessJokerPlotAction;
				break;
			}
			if ((float)(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - num) < waitDeleteTime)
			{
				result = guessJokerPlotAction;
				break;
			}
		}
		return result;
	}

	// Token: 0x060070E5 RID: 28901 RVA: 0x001D7958 File Offset: 0x001D5B58
	protected void OnActionDone(GuessJokerPlotAction action)
	{
		EGuessJokerPlotTiming timing = action.Timing;
		EGuessJokerPlayerType playerType = action.PlayerType;
		string timingKey = this.GetTimingKey(timing, playerType);
		this.ExecutingTimings.Remove(timingKey);
		this.CurrentActionCdUpdated = false;
	}

	// Token: 0x060070E6 RID: 28902 RVA: 0x001D7990 File Offset: 0x001D5B90
	public void Destroy()
	{
		if (this.CurrentAction != null)
		{
			this.CurrentAction.Finish();
			this.CurrentAction = null;
		}
		this.PlotCdMap.Clear();
		this.ExecutingTimings.Clear();
		this.CurrentActionCdUpdated = false;
		this.Queue.Clear();
	}

	// Token: 0x04003648 RID: 13896
	protected readonly List<GuessJokerPlotAction> Queue = new List<GuessJokerPlotAction>();

	// Token: 0x04003649 RID: 13897
	[Nullable(2)]
	protected GuessJokerPlotAction CurrentAction;

	// Token: 0x0400364A RID: 13898
	private readonly Dictionary<string, long> PlotCdMap = new Dictionary<string, long>();

	// Token: 0x0400364B RID: 13899
	private readonly HashSet<string> ExecutingTimings = new HashSet<string>();

	// Token: 0x0400364C RID: 13900
	private bool CurrentActionCdUpdated;

	// Token: 0x0400364D RID: 13901
	private readonly Dictionary<GuessJokerPlotAction, long> ActionEnqueueTimeMap = new Dictionary<GuessJokerPlotAction, long>();
}
