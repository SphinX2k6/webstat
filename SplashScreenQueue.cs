using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002A95 RID: 10901
[NullableContext(1)]
[Nullable(0)]
public class SplashScreenQueue
{
	// Token: 0x06015D0B RID: 89355 RVA: 0x0060C71C File Offset: 0x0060A91C
	public unsafe void EnQueue(SplashScreenTask task)
	{
		if (this.CurrentRunningTask != null && this.CurrentRunningTask.SourceModule == task.SourceModule)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.SplashScreenTask;
			ELogAuthor author = ELogAuthor.CXJ;
			string message = "[SplashScreenTask] 任务重复添加";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("TaskSourceModule", task.SourceModule);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Status", task.Status);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		if (this.IsTaskInQueue(task))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.SplashScreenTask;
			ELogAuthor author2 = ELogAuthor.CXJ;
			string message2 = "[SplashScreenTask] 任务重复添加";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("TaskSourceModule", task.SourceModule);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Status", task.Status);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return;
		}
		this.TaskQueue.Add(task);
		Log instance3 = Singleton<Log>.Instance;
		ELogModule module3 = ELogModule.SplashScreenTask;
		ELogAuthor author3 = ELogAuthor.CXJ;
		string message3 = "[SplashScreenTask] 添加任务";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("TaskSourceModule", task.SourceModule);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("Status", task.Status);
		instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
	}

	// Token: 0x06015D0C RID: 89356 RVA: 0x0060C89C File Offset: 0x0060AA9C
	public unsafe void ProcessQueueSingle()
	{
		if (this.IsSplashScreenTaskRunning())
		{
			Singleton<Log>.Instance.Info(ELogModule.SplashScreenTask, ELogAuthor.CXJ, "有其他开屏任务正在进行中", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (this.TaskQueue == null || this.TaskQueue.Count == 0)
		{
			Singleton<Log>.Instance.Info(ELogModule.SplashScreenTask, ELogAuthor.CXJ, "开屏任务队列为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (this.LongTaskMaxNum == null)
		{
			this.LongTaskMaxNum = new int?(ConfigCommonParamById.GetIntConfig("LongTaskMaxNum").GetValueOrDefault(1));
		}
		this.CurrentRunningTask = this.TaskQueue[0];
		this.TaskQueue.RemoveAt(0);
		SplashScreenTask currentRunningTask = this.CurrentRunningTask;
		if (currentRunningTask != null && currentRunningTask.SplashScreenTimeType == ESplashScreenTimeType.Long)
		{
			bool needInLongQueue = this.CurrentRunningTask.NeedInLongQueue;
			if (needInLongQueue)
			{
				int finishedInQueueLongTaskNum = this.FinishedInQueueLongTaskNum;
				int? longTaskMaxNum = this.LongTaskMaxNum;
				if (finishedInQueueLongTaskNum >= longTaskMaxNum.GetValueOrDefault() & longTaskMaxNum != null)
				{
					goto IL_108;
				}
			}
			if (needInLongQueue || !this.IsShowLongTask)
			{
				if (needInLongQueue)
				{
					this.FinishedInQueueLongTaskNum++;
				}
				this.IsShowLongTask = true;
				goto IL_1A3;
			}
			IL_108:
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.SplashScreenTask;
			ELogAuthor author = ELogAuthor.CXJ;
			string message = "[SplashScreenTask] 长任务已达上限，跳过执行";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("TaskSourceModule", this.CurrentRunningTask.SourceModule);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Status", this.CurrentRunningTask.Status);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.CurrentRunningTask = null;
			this.ProcessQueueSingle();
			return;
		}
		IL_1A3:
		if (this.CurrentRunningTask != null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.SplashScreenTask;
			ELogAuthor author2 = ELogAuthor.CXJ;
			string message2 = "[SplashScreenTask] 任务开始执行";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("TaskSourceModule", this.CurrentRunningTask.SourceModule);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Status", this.CurrentRunningTask.Status);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			this.CurrentRunningTask.Run();
		}
	}

	// Token: 0x06015D0D RID: 89357 RVA: 0x0060CAD4 File Offset: 0x0060ACD4
	public unsafe bool FinishTask(ESplashScreenSourceModuleType taskSourceModule = ESplashScreenSourceModuleType.None)
	{
		if (this.CurrentRunningTask == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.SplashScreenTask;
			ELogAuthor author = ELogAuthor.CXJ;
			string message = "[SplashScreenTask] 当前没有正在执行的任务";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("finishTaskSourceModule", taskSourceModule);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		if (taskSourceModule != ESplashScreenSourceModuleType.None && taskSourceModule != this.CurrentRunningTask.SourceModule)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.SplashScreenTask;
			ELogAuthor author2 = ELogAuthor.CXJ;
			string message2 = "[SplashScreenTask] 当前执行任务名称与参数名称不一致，结束任务失败";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("finishTaskSourceModule", taskSourceModule);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item = "curTaskSourceModule";
			SplashScreenTask currentRunningTask = this.CurrentRunningTask;
			ptr = new ValueTuple<string, object>(item, (currentRunningTask != null) ? new ESplashScreenSourceModuleType?(currentRunningTask.SourceModule) : null);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		if (this.CurrentRunningTask != null)
		{
			this.CurrentRunningTask.FinishTask();
			this.CurrentRunningTask = null;
		}
		return true;
	}

	// Token: 0x06015D0E RID: 89358 RVA: 0x0060CBCC File Offset: 0x0060ADCC
	public void ProcessQueue()
	{
		this.TaskQueue.Sort(delegate(SplashScreenTask taskA, SplashScreenTask taskB)
		{
			if (taskA.Type == ESplashScreenType.Other || taskB.Type == ESplashScreenType.Other)
			{
				if (taskA.Type != ESplashScreenType.Other)
				{
					return -1;
				}
				return 1;
			}
			else
			{
				SplashScreen value = ConfigSplashScreenById.GetConfig((int)taskA.SourceModule, true).Value;
				SplashScreen value2 = ConfigSplashScreenById.GetConfig((int)taskB.SourceModule, true).Value;
				if (value.Type != value2.Type)
				{
					if (value.Type != 1)
					{
						return -1;
					}
					return 1;
				}
				else
				{
					if (value.InLongTaskQueue == value2.InLongTaskQueue)
					{
						return value2.Priority - value.Priority;
					}
					if (!value2.InLongTaskQueue)
					{
						return -1;
					}
					return 1;
				}
			}
		});
		this.ProcessQueueSingle();
	}

	// Token: 0x06015D0F RID: 89359 RVA: 0x0060CBFE File Offset: 0x0060ADFE
	public bool IsSplashScreenTaskRunning()
	{
		return this.CurrentRunningTask != null;
	}

	// Token: 0x06015D10 RID: 89360 RVA: 0x0060CC0C File Offset: 0x0060AE0C
	public bool IsTaskInQueue(SplashScreenTask task)
	{
		using (List<SplashScreenTask>.Enumerator enumerator = this.TaskQueue.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.SourceModule == task.SourceModule)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06015D11 RID: 89361 RVA: 0x0060CC6C File Offset: 0x0060AE6C
	public void ClearAllTask()
	{
		if (this.CurrentRunningTask != null)
		{
			this.CurrentRunningTask.FailTask();
			this.CurrentRunningTask = null;
		}
		foreach (SplashScreenTask splashScreenTask in this.TaskQueue)
		{
			splashScreenTask.CancelTask();
		}
		this.TaskQueue = new List<SplashScreenTask>();
	}

	// Token: 0x0400A764 RID: 42852
	public List<SplashScreenTask> TaskQueue = new List<SplashScreenTask>();

	// Token: 0x0400A765 RID: 42853
	[Nullable(2)]
	private SplashScreenTask CurrentRunningTask;

	// Token: 0x0400A766 RID: 42854
	private bool IsShowLongTask;

	// Token: 0x0400A767 RID: 42855
	private int? LongTaskMaxNum;

	// Token: 0x0400A768 RID: 42856
	private int FinishedInQueueLongTaskNum;
}
