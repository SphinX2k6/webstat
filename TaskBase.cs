using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020034D2 RID: 13522
public abstract class TaskBase
{
	// Token: 0x0601C90A RID: 117002 RVA: 0x0088FD54 File Offset: 0x0088DF54
	[NullableContext(2)]
	public TaskBase([Nullable(1)] string name, Func<bool> initHandle = null, Action<bool> finishedCallback = null, TaskInterruptOptions interruptOptions = null)
	{
		this.Name = name;
		this.InitHandle = initHandle;
		this.FinishedCallback = finishedCallback;
		this.InterruptOptions = (interruptOptions ?? new TaskInterruptOptions(ETaskPriority.Normal, false, null));
		this.TaskPromise = new UniTaskCompletionSource<bool>();
	}

	// Token: 0x170026D1 RID: 9937
	// (get) Token: 0x0601C90B RID: 117003 RVA: 0x0088FDA6 File Offset: 0x0088DFA6
	[Nullable(1)]
	public string Name { [NullableContext(1)] get; }

	// Token: 0x0601C90C RID: 117004 RVA: 0x0088FDAE File Offset: 0x0088DFAE
	[NullableContext(2)]
	public void SetLogPrefix(string logPrefix = null)
	{
		this.LogPrefix = logPrefix;
	}

	// Token: 0x170026D2 RID: 9938
	// (get) Token: 0x0601C90D RID: 117005 RVA: 0x0088FDB7 File Offset: 0x0088DFB7
	public ETaskPriority InterruptPriority
	{
		get
		{
			return this.InterruptOptions.Priority;
		}
	}

	// Token: 0x170026D3 RID: 9939
	// (get) Token: 0x0601C90E RID: 117006 RVA: 0x0088FDC4 File Offset: 0x0088DFC4
	public bool Interruptible
	{
		get
		{
			return this.InterruptOptions.Interruptible;
		}
	}

	// Token: 0x0601C90F RID: 117007 RVA: 0x0088FDD4 File Offset: 0x0088DFD4
	public void RequestInterrupt()
	{
		if (this.Interrupted)
		{
			return;
		}
		this.Interrupted = true;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.World;
		ELogAuthor author = ELogAuthor.ZYL;
		string message = "TaskBase:请求打断";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Name", this.Name);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.OnInterrupt();
	}

	// Token: 0x0601C910 RID: 117008 RVA: 0x0088FE24 File Offset: 0x0088E024
	protected virtual void OnInterrupt()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.World;
		ELogAuthor author = ELogAuthor.ZYL;
		string message = "TaskBase:执行打断收尾";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Name", this.Name);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		Action onInterrupt = this.InterruptOptions.OnInterrupt;
		if (onInterrupt == null)
		{
			return;
		}
		onInterrupt();
	}

	// Token: 0x0601C911 RID: 117009 RVA: 0x0088FE72 File Offset: 0x0088E072
	public bool Init()
	{
		return (this.InitHandle == null || this.InitHandle()) && this.OnInit();
	}

	// Token: 0x170026D4 RID: 9940
	// (get) Token: 0x0601C912 RID: 117010 RVA: 0x0088FE91 File Offset: 0x0088E091
	public UniTask<bool> Promise
	{
		get
		{
			return this.TaskPromise.Task;
		}
	}

	// Token: 0x0601C913 RID: 117011 RVA: 0x0088FEA0 File Offset: 0x0088E0A0
	public UniTask<bool> Run()
	{
		TaskBase.<Run>d__20 <Run>d__;
		<Run>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<Run>d__.<>4__this = this;
		<Run>d__.<>1__state = -1;
		<Run>d__.<>t__builder.Start<TaskBase.<Run>d__20>(ref <Run>d__);
		return <Run>d__.<>t__builder.Task;
	}

	// Token: 0x0601C914 RID: 117012
	protected abstract UniTask<bool> OnRun();

	// Token: 0x0601C915 RID: 117013 RVA: 0x0088FEE3 File Offset: 0x0088E0E3
	protected virtual bool OnInit()
	{
		return true;
	}

	// Token: 0x0601C916 RID: 117014 RVA: 0x0088FEE6 File Offset: 0x0088E0E6
	protected virtual void OnExit()
	{
	}

	// Token: 0x0400E617 RID: 58903
	[Nullable(1)]
	protected readonly TaskInterruptOptions InterruptOptions;

	// Token: 0x0400E618 RID: 58904
	public bool Interrupted;

	// Token: 0x0400E619 RID: 58905
	[Nullable(2)]
	protected string LogPrefix = "";

	// Token: 0x0400E61A RID: 58906
	[Nullable(2)]
	protected Func<bool> InitHandle;

	// Token: 0x0400E61B RID: 58907
	[Nullable(2)]
	protected Action<bool> FinishedCallback;

	// Token: 0x0400E61C RID: 58908
	[Nullable(1)]
	private readonly UniTaskCompletionSource<bool> TaskPromise;
}
