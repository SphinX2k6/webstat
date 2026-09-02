using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020034D7 RID: 13527
[Nullable(new byte[]
{
	0,
	1
})]
public class TaskSystem : Singleton<TaskSystem>
{
	// Token: 0x170026DA RID: 9946
	// (get) Token: 0x0601C932 RID: 117042 RVA: 0x00890BB4 File Offset: 0x0088EDB4
	public UniTask<bool>? Promise
	{
		get
		{
			CustomPromise<bool> runPromise = this.RunPromise;
			if (runPromise == null)
			{
				return null;
			}
			return new UniTask<bool>?(runPromise.Promise);
		}
	}

	// Token: 0x0601C933 RID: 117043 RVA: 0x00890BDF File Offset: 0x0088EDDF
	public bool Initialize()
	{
		this.InitState = true;
		return true;
	}

	// Token: 0x0601C934 RID: 117044 RVA: 0x00890BEC File Offset: 0x0088EDEC
	public UniTask<bool> Run()
	{
		TaskSystem.<Run>d__13 <Run>d__;
		<Run>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<Run>d__.<>4__this = this;
		<Run>d__.<>1__state = -1;
		<Run>d__.<>t__builder.Start<TaskSystem.<Run>d__13>(ref <Run>d__);
		return <Run>d__.<>t__builder.Task;
	}

	// Token: 0x0601C935 RID: 117045 RVA: 0x00890C30 File Offset: 0x0088EE30
	[NullableContext(1)]
	public unsafe void AddTask(TaskBase task)
	{
		if (!this.InitState)
		{
			return;
		}
		if (!task.Init())
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.World;
			ELogAuthor author = ELogAuthor.ZYL;
			string message = "TaskSystem:Task初始化失败,不入队";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Name", task.Name);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.IncomingQueue.Push(task);
		this.IncreaseQueuedCount(task.InterruptPriority);
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.World;
		ELogAuthor author2 = ELogAuthor.LFJW;
		string message2 = "TaskSystem:入队Task";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Name", task.Name);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("InterruptPriority", task.InterruptPriority);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("剩余Task个数", this.QueuedSize);
		instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
	}

	// Token: 0x0601C936 RID: 117046 RVA: 0x00890D18 File Offset: 0x0088EF18
	public void Clear()
	{
		Singleton<Log>.Instance.Info(ELogModule.World, ELogAuthor.ZYL, "TaskSystem:Clear", default(ReadOnlySpan<ValueTuple<string, object>>));
		this.InitState = false;
		this.ClearInternal();
	}

	// Token: 0x0601C937 RID: 117047 RVA: 0x00890D50 File Offset: 0x0088EF50
	private void ClearInternal()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.World;
		ELogAuthor author = ELogAuthor.ZYL;
		string message = "TaskSystem:清理内部状态";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("剩余Task个数", this.QueuedSize);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.IncomingQueue.Clear();
		this.DrainBuffer.Clear();
		this.QueuedTaskCountsByInterruptPriority.Clear();
		this.CurrentTask = null;
		this.SelfFeedStreak = 0;
		this.HasLoadingTask = false;
		this.Running = false;
	}

	// Token: 0x170026DB RID: 9947
	// (get) Token: 0x0601C938 RID: 117048 RVA: 0x00890DCC File Offset: 0x0088EFCC
	private int HighestQueuedInterruptPriority
	{
		get
		{
			for (ETaskPriority etaskPriority = ETaskPriority.High; etaskPriority >= ETaskPriority.Normal; etaskPriority--)
			{
				int num;
				if ((this.QueuedTaskCountsByInterruptPriority.TryGetValue(etaskPriority, out num) ? num : 0) > 0)
				{
					return (int)etaskPriority;
				}
			}
			return -1;
		}
	}

	// Token: 0x0601C939 RID: 117049 RVA: 0x00890E00 File Offset: 0x0088F000
	private void IncreaseQueuedCount(ETaskPriority priority)
	{
		int num2;
		int num = this.QueuedTaskCountsByInterruptPriority.TryGetValue(priority, out num2) ? num2 : 0;
		this.QueuedTaskCountsByInterruptPriority[priority] = num + 1;
	}

	// Token: 0x0601C93A RID: 117050 RVA: 0x00890E34 File Offset: 0x0088F034
	private void DecreaseQueuedCount(ETaskPriority priority)
	{
		int num2;
		int num = (this.QueuedTaskCountsByInterruptPriority.TryGetValue(priority, out num2) ? num2 : 0) - 1;
		this.QueuedTaskCountsByInterruptPriority[priority] = ((num > 0) ? num : 0);
	}

	// Token: 0x0601C93B RID: 117051 RVA: 0x00890E6C File Offset: 0x0088F06C
	private unsafe void TryInterruptCurrent()
	{
		TaskBase currentTask = this.CurrentTask;
		if (currentTask != null && currentTask.Interruptible && this.HighestQueuedInterruptPriority > (int)currentTask.InterruptPriority)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.World;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "TaskSystem:打断Task";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Name", currentTask.Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("当前优先级", currentTask.InterruptPriority);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("最高等待优先级", this.HighestQueuedInterruptPriority);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			currentTask.RequestInterrupt();
		}
	}

	// Token: 0x0601C93C RID: 117052 RVA: 0x00890F2C File Offset: 0x0088F12C
	private void SwapBuffers()
	{
		Queue<TaskBase> drainBuffer = this.DrainBuffer;
		this.DrainBuffer = this.IncomingQueue;
		this.IncomingQueue = drainBuffer;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.World;
		ELogAuthor author = ELogAuthor.ZYL;
		string message = "TaskSystem:交换缓冲区,开始本轮排空";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("本轮任务数", this.DrainBuffer.Size);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x170026DC RID: 9948
	// (get) Token: 0x0601C93D RID: 117053 RVA: 0x00890F89 File Offset: 0x0088F189
	private int QueuedSize
	{
		get
		{
			return this.IncomingQueue.Size + this.DrainBuffer.Size;
		}
	}

	// Token: 0x0601C93E RID: 117054 RVA: 0x00890FA4 File Offset: 0x0088F1A4
	private UniTask YieldFrame()
	{
		TaskSystem.<YieldFrame>d__25 <YieldFrame>d__;
		<YieldFrame>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<YieldFrame>d__.<>1__state = -1;
		<YieldFrame>d__.<>t__builder.Start<TaskSystem.<YieldFrame>d__25>(ref <YieldFrame>d__);
		return <YieldFrame>d__.<>t__builder.Task;
	}

	// Token: 0x0601C93F RID: 117055 RVA: 0x00890FE0 File Offset: 0x0088F1E0
	private UniTask<bool> RunInternal()
	{
		TaskSystem.<RunInternal>d__26 <RunInternal>d__;
		<RunInternal>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RunInternal>d__.<>4__this = this;
		<RunInternal>d__.<>1__state = -1;
		<RunInternal>d__.<>t__builder.Start<TaskSystem.<RunInternal>d__26>(ref <RunInternal>d__);
		return <RunInternal>d__.<>t__builder.Task;
	}

	// Token: 0x0400E629 RID: 58921
	private const int SELF_FEED_STREAK_THRESHOLD = 100;

	// Token: 0x0400E62A RID: 58922
	[Nullable(1)]
	private Queue<TaskBase> IncomingQueue = new Queue<TaskBase>(4);

	// Token: 0x0400E62B RID: 58923
	[Nullable(1)]
	private Queue<TaskBase> DrainBuffer = new Queue<TaskBase>(4);

	// Token: 0x0400E62C RID: 58924
	[Nullable(2)]
	private TaskBase CurrentTask;

	// Token: 0x0400E62D RID: 58925
	[Nullable(1)]
	private readonly Dictionary<ETaskPriority, int> QueuedTaskCountsByInterruptPriority = new Dictionary<ETaskPriority, int>();

	// Token: 0x0400E62E RID: 58926
	private int SelfFeedStreak;

	// Token: 0x0400E62F RID: 58927
	public bool HasLoadingTask;

	// Token: 0x0400E630 RID: 58928
	public bool Running;

	// Token: 0x0400E631 RID: 58929
	[Nullable(2)]
	private CustomPromise<bool> RunPromise;

	// Token: 0x0400E632 RID: 58930
	private bool InitState;
}
