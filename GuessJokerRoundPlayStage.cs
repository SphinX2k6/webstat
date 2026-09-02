using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x02001101 RID: 4353
[NullableContext(1)]
[Nullable(0)]
public class GuessJokerRoundPlayStage : GuessJokerStageBase
{
	// Token: 0x06007148 RID: 29000 RVA: 0x001D9BEB File Offset: 0x001D7DEB
	public GuessJokerRoundPlayStage(GuessJokerStageFsm stageFsm) : base(stageFsm)
	{
	}

	// Token: 0x06007149 RID: 29001 RVA: 0x001D9BFF File Offset: 0x001D7DFF
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.GuessJokerCardUpdateTaskData, new Action(this.OnGuessJokerCardUpdateTaskData));
	}

	// Token: 0x0600714A RID: 29002 RVA: 0x001D9C1D File Offset: 0x001D7E1D
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.GuessJokerCardUpdateTaskData, new Action(this.OnGuessJokerCardUpdateTaskData));
	}

	// Token: 0x0600714B RID: 29003 RVA: 0x001D9C3C File Offset: 0x001D7E3C
	protected override void OnEnter()
	{
		Singleton<Log>.Instance.Info(ELogModule.GuessJokerCard, ELogAuthor.LRC, "RoundPlay Stage OnEnter", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.InitTaskList();
		this.TryExecuteTask();
	}

	// Token: 0x0600714C RID: 29004 RVA: 0x001D9C74 File Offset: 0x001D7E74
	protected override void OnTick(float deltaTime)
	{
		if (this.CurrentTask != null)
		{
			this.CurrentTask.Tick(deltaTime);
			if (this.CurrentTask.IsFinished())
			{
				this.TaskList.RemoveAt(0);
				this.CurrentTask = null;
				this.TryExecuteTask();
			}
		}
	}

	// Token: 0x0600714D RID: 29005 RVA: 0x001D9CB0 File Offset: 0x001D7EB0
	private void InitTaskList()
	{
		this.UpdateTaskList();
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.GuessJokerCard;
		ELogAuthor author = ELogAuthor.LRC;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 1);
		defaultInterpolatedStringHandler.AppendLiteral("RoundPlay Stage InitTaskList: ");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.TaskList.Count);
		instance.Info(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x0600714E RID: 29006 RVA: 0x001D9D0C File Offset: 0x001D7F0C
	private void UpdateTaskList()
	{
		List<JokerGuessOp> taskDataList = ModelBase<GuessJokerGamePlayModel>.Instance.GetTaskDataList();
		for (int i = 0; i < taskDataList.Count; i++)
		{
			JokerGuessOp taskData = taskDataList[i];
			GuessJokerTaskBase guessJokerTaskBase = this.CreateTaskData(taskData);
			if (guessJokerTaskBase != null)
			{
				this.TaskList.Add(guessJokerTaskBase);
			}
		}
	}

	// Token: 0x0600714F RID: 29007 RVA: 0x001D9D54 File Offset: 0x001D7F54
	private void OnGuessJokerCardUpdateTaskData()
	{
		this.UpdateTaskList();
		this.TryExecuteTask();
	}

	// Token: 0x06007150 RID: 29008 RVA: 0x001D9D64 File Offset: 0x001D7F64
	private void TryExecuteTask()
	{
		if (this.CurrentTask != null)
		{
			return;
		}
		if (this.TaskList.Count == 0)
		{
			return;
		}
		this.CurrentTask = this.TaskList[0];
		this.CurrentTask.Execute();
		List<string> list = new List<string>();
		for (int i = 0; i < this.TaskList.Count; i++)
		{
			list.Add(this.TaskList[i].GetType().Name);
		}
		Singleton<Log>.Instance.Info(ELogModule.GuessJokerCard, ELogAuthor.LRC, "猜鬼牌待执行Task列表: " + string.Join(", ", list), default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x06007151 RID: 29009 RVA: 0x001D9E0C File Offset: 0x001D800C
	[return: Nullable(2)]
	public GuessJokerTaskBase CreateTaskData(JokerGuessOp taskData)
	{
		GuessJokerTaskBase result = null;
		switch (taskData.OpType)
		{
		case JokerActionType.EnterNewRound:
			result = new GuessJokerRoundStartTask(taskData.NewRoundAction);
			break;
		case JokerActionType.DrawCard:
			result = this.ExecuteDrawTaskData(taskData.DrawAction);
			break;
		case JokerActionType.PlayCard:
			result = this.ExecutePlayCardTaskData(taskData.PlayAction);
			break;
		case JokerActionType.TriggerSkill:
			result = this.ExecuteTriggerSkillTaskData(taskData.SkillTriggerAction);
			break;
		case JokerActionType.ExecSkill:
			result = new GuessJokerSkillExecuteTask(taskData.SkillExecAction);
			break;
		case JokerActionType.SettleResult:
			result = new GuessJokerSettleTask(taskData.Winner);
			break;
		case JokerActionType.HealthHpRefresh:
			result = new GuessJokerUpdateHpTask(taskData.HpRefreshAction);
			break;
		case JokerActionType.DisPlayCard:
			result = new GuessJokerAiCheckCardTask(taskData.DisPlayAction);
			break;
		}
		return result;
	}

	// Token: 0x06007152 RID: 29010 RVA: 0x001D9EBC File Offset: 0x001D80BC
	private GuessJokerTaskBase ExecuteDrawTaskData(JokerGuessDrawCardAction taskData)
	{
		GuessJokerTaskBase result;
		if (GuessJokerUtils.ServerPlayerTransToClient(taskData.Drawer) == EGuessJokerPlayerType.Me)
		{
			result = new GuessJokerPlayerDrawCardTask();
		}
		else
		{
			result = new GuessJokerAiDrawCardTask(taskData);
		}
		return result;
	}

	// Token: 0x06007153 RID: 29011 RVA: 0x001D9EE8 File Offset: 0x001D80E8
	private GuessJokerTaskBase ExecutePlayCardTaskData(JokerGuessPlayCardAction taskData)
	{
		GuessJokerTaskBase result;
		if (GuessJokerUtils.ServerPlayerTransToClient(taskData.PlayActor) == EGuessJokerPlayerType.Me)
		{
			result = new GuessJokerPlayerPlayCardTask();
		}
		else
		{
			result = new GuessJokerAiPlayCardTask(taskData);
		}
		return result;
	}

	// Token: 0x06007154 RID: 29012 RVA: 0x001D9F14 File Offset: 0x001D8114
	private GuessJokerTaskBase ExecuteTriggerSkillTaskData(JokerGuessSkillTriggerAction taskData)
	{
		GuessJokerTaskBase result;
		if (GuessJokerUtils.ServerPlayerTransToClient(taskData.Owner) == EGuessJokerPlayerType.Me)
		{
			result = new GuessJokerPlayerSkillTriggerTask(taskData);
		}
		else
		{
			result = new GuessJokerAiSkillTriggerTask(taskData);
		}
		return result;
	}

	// Token: 0x04003674 RID: 13940
	protected List<GuessJokerTaskBase> TaskList = new List<GuessJokerTaskBase>();

	// Token: 0x04003675 RID: 13941
	[Nullable(2)]
	protected GuessJokerTaskBase CurrentTask;
}
