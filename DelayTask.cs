using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020034C6 RID: 13510
public class DelayTask : TaskBase
{
	// Token: 0x0601C8DC RID: 116956 RVA: 0x0088FB9F File Offset: 0x0088DD9F
	[NullableContext(2)]
	public DelayTask([Nullable(1)] string name, Func<bool> runHandle = null, Func<bool> initHandle = null, int delay = 1000, Action<bool> finishedCallback = null) : base(name, initHandle, finishedCallback, null)
	{
		this.RunHandle = runHandle;
		this.DelayTime = Math.Max(delay, 20);
	}

	// Token: 0x0601C8DD RID: 116957 RVA: 0x0088FBD0 File Offset: 0x0088DDD0
	protected override UniTask<bool> OnRun()
	{
		DelayTask.<OnRun>d__5 <OnRun>d__;
		<OnRun>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<OnRun>d__.<>4__this = this;
		<OnRun>d__.<>1__state = -1;
		<OnRun>d__.<>t__builder.Start<DelayTask.<OnRun>d__5>(ref <OnRun>d__);
		return <OnRun>d__.<>t__builder.Task;
	}

	// Token: 0x0400E602 RID: 58882
	private const int DEFAULT_DELAY_TIME = 1000;

	// Token: 0x0400E603 RID: 58883
	[Nullable(2)]
	private readonly Func<bool> RunHandle;

	// Token: 0x0400E604 RID: 58884
	private readonly int DelayTime;

	// Token: 0x0400E605 RID: 58885
	[Nullable(1)]
	private readonly UniTaskCompletionSource<bool> DelayPromise = new UniTaskCompletionSource<bool>();
}
