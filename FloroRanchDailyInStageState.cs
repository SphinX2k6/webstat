using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x02001C1F RID: 7199
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchDailyInStageState : FloroRanchStateBase
{
	// Token: 0x0600D156 RID: 53590 RVA: 0x00378E36 File Offset: 0x00377036
	public FloroRanchDailyInStageState(FloroRanchStageFsm stageFsm) : base(stageFsm)
	{
	}

	// Token: 0x0600D157 RID: 53591 RVA: 0x00378E4C File Offset: 0x0037704C
	protected override void OnEnter()
	{
		List<FloroRanchPlayTask> dailyTaskList = ModelBase<FloroRanchGamePlayModel>.Instance.GetDailyTaskList();
		this.UpdateTaskList(dailyTaskList);
		this.TryExecuteTask();
	}

	// Token: 0x0600D158 RID: 53592 RVA: 0x00378E71 File Offset: 0x00377071
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<FloroRanchPlayTask>>(EEventName.OnFloroRanchNextDayTaskRefresh, new Action<IReadOnlyList<FloroRanchPlayTask>>(this.OnFloroRanchNextDayTaskRefresh));
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<FloroRanchPlayTask>>(EEventName.OnFloroRanchInsertTask, new Action<IReadOnlyList<FloroRanchPlayTask>>(this.OnFloroRanchInsertTask));
	}

	// Token: 0x0600D159 RID: 53593 RVA: 0x00378EAC File Offset: 0x003770AC
	private void UpdateTaskList(IReadOnlyList<FloroRanchPlayTask> taskList)
	{
		foreach (FloroRanchPlayTask taskData in taskList)
		{
			FloroRanchDailyTaskBase item = this.CreateTask(taskData);
			this.TaskList.Add(item);
		}
	}

	// Token: 0x0600D15A RID: 53594 RVA: 0x00378F04 File Offset: 0x00377104
	private void InsertTaskList(IReadOnlyList<FloroRanchPlayTask> taskList)
	{
		List<FloroRanchDailyTaskBase> list = new List<FloroRanchDailyTaskBase>();
		foreach (FloroRanchPlayTask taskData in taskList)
		{
			FloroRanchDailyTaskBase item = this.CreateTask(taskData);
			list.Add(item);
		}
		list.Reverse();
		foreach (FloroRanchDailyTaskBase item2 in list)
		{
			this.TaskList.Insert(0, item2);
		}
		if (list.Count > 0)
		{
			if (this.CurrentTask != null && !this.CurrentTask.IsPause)
			{
				this.CurrentTask.Pause();
			}
			this.CurrentTask = null;
		}
	}

	// Token: 0x0600D15B RID: 53595 RVA: 0x00378FD8 File Offset: 0x003771D8
	private void TryExecuteTask()
	{
		if (!this.IsActive)
		{
			return;
		}
		if (this.CurrentTask != null)
		{
			return;
		}
		int count = this.TaskList.Count;
		this.CurrentTask = ((count > 0) ? this.TaskList[0] : null);
		if (this.CurrentTask == null)
		{
			this.OnDayAllTaskFinish();
			return;
		}
		if (this.CurrentTask.IsPause)
		{
			this.CurrentTask.Resume();
			return;
		}
		if (!this.CurrentTask.IsExecuting)
		{
			this.CurrentTask.Execute();
		}
	}

	// Token: 0x0600D15C RID: 53596 RVA: 0x0037905C File Offset: 0x0037725C
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnFloroRanchNextDayTaskRefresh, new Action<IReadOnlyList<FloroRanchPlayTask>>(this.OnFloroRanchNextDayTaskRefresh));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnFloroRanchInsertTask, new Action<IReadOnlyList<FloroRanchPlayTask>>(this.OnFloroRanchInsertTask));
	}

	// Token: 0x0600D15D RID: 53597 RVA: 0x00379096 File Offset: 0x00377296
	protected override void OnExit()
	{
		if (this.CurrentTask != null)
		{
			this.CurrentTask.ForceFinish();
			this.CurrentTask = null;
		}
	}

	// Token: 0x0600D15E RID: 53598 RVA: 0x003790B4 File Offset: 0x003772B4
	private void OnTaskFinish(int taskId, Action preExcuteNextCallback)
	{
		if (this.CurrentTask == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanchGamePlay, ELogAuthor.LRC, "OnTaskFinish 当前任务不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (this.CurrentTask.TaskId != taskId)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanchGamePlay, ELogAuthor.LRC, "OnTaskFinish 任务id不匹配", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.TaskList.RemoveAt(0);
		this.CurrentTask = null;
		if (preExcuteNextCallback != null)
		{
			preExcuteNextCallback();
		}
		this.TryExecuteTask();
	}

	// Token: 0x0600D15F RID: 53599 RVA: 0x00379139 File Offset: 0x00377339
	private void OnFloroRanchNextDayTaskRefresh(IReadOnlyList<FloroRanchPlayTask> taskList)
	{
		this.UpdateTaskList(taskList);
		this.TryExecuteTask();
	}

	// Token: 0x0600D160 RID: 53600 RVA: 0x00379148 File Offset: 0x00377348
	private void OnFloroRanchInsertTask(IReadOnlyList<FloroRanchPlayTask> taskList)
	{
		this.InsertTaskList(taskList);
		this.TryExecuteTask();
	}

	// Token: 0x0600D161 RID: 53601 RVA: 0x00379157 File Offset: 0x00377357
	private void OnDayAllTaskFinish()
	{
		FloroRanchEntityActionSystem.DayEnd();
	}

	// Token: 0x0600D162 RID: 53602 RVA: 0x00379160 File Offset: 0x00377360
	private FloroRanchDailyTaskBase CreateTask(FloroRanchPlayTask taskData)
	{
		FloroRanchDailyTaskBase floroRanchDailyTaskBase;
		switch (taskData.TaskType)
		{
		case FloroRanchPlayTaskType.DayStart:
			floroRanchDailyTaskBase = new FloroRanchDayStartTask(taskData.DayStart);
			break;
		case FloroRanchPlayTaskType.DaySettleActions:
			floroRanchDailyTaskBase = new FloroRanchDayActionSettleTask(taskData.UnitActions);
			break;
		case FloroRanchPlayTaskType.Event:
			floroRanchDailyTaskBase = new FloroRanchRandomEventTask(taskData.FloroRanchPlayEvent);
			break;
		case FloroRanchPlayTaskType.Shop:
			floroRanchDailyTaskBase = new FloroRanchShopTask(taskData.Shop);
			break;
		case FloroRanchPlayTaskType.Gacha:
			floroRanchDailyTaskBase = new FloroRanchGachaTask(taskData.Gacha);
			break;
		case FloroRanchPlayTaskType.StageStart:
			floroRanchDailyTaskBase = new FloroRanchStageStartTask(taskData.StageStart);
			break;
		case FloroRanchPlayTaskType.StageEnd:
			floroRanchDailyTaskBase = new FloroRanchStageEndTask(taskData.StageEnd);
			break;
		case FloroRanchPlayTaskType.WageSettleTask:
			floroRanchDailyTaskBase = new FloroRanchDaySalarySettleTask(taskData.WageSettleTask);
			break;
		default:
			floroRanchDailyTaskBase = new FloroRanchDailyTaskBase();
			break;
		}
		floroRanchDailyTaskBase.BindCompleteCallBack(new Action<int, Action>(this.OnTaskFinish));
		return floroRanchDailyTaskBase;
	}

	// Token: 0x0600D163 RID: 53603 RVA: 0x00379227 File Offset: 0x00377427
	public bool IsExecutingTask()
	{
		return this.CurrentTask != null;
	}

	// Token: 0x040063F6 RID: 25590
	private readonly List<FloroRanchDailyTaskBase> TaskList = new List<FloroRanchDailyTaskBase>();

	// Token: 0x040063F7 RID: 25591
	[Nullable(2)]
	private FloroRanchDailyTaskBase CurrentTask;
}
