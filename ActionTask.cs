using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020034C4 RID: 13508
public class ActionTask : TaskBase
{
	// Token: 0x0601C8D8 RID: 116952 RVA: 0x0088FAED File Offset: 0x0088DCED
	[NullableContext(1)]
	public ActionTask(string name, Func<bool> runHandle, [Nullable(2)] Func<bool> initHandle = null, [Nullable(2)] Action<bool> finishedCallback = null) : base(name, initHandle, finishedCallback, null)
	{
		this.RunHandle = runHandle;
	}

	// Token: 0x0601C8D9 RID: 116953 RVA: 0x0088FB04 File Offset: 0x0088DD04
	protected override UniTask<bool> OnRun()
	{
		ActionTask.<OnRun>d__2 <OnRun>d__;
		<OnRun>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<OnRun>d__.<>4__this = this;
		<OnRun>d__.<>1__state = -1;
		<OnRun>d__.<>t__builder.Start<ActionTask.<OnRun>d__2>(ref <OnRun>d__);
		return <OnRun>d__.<>t__builder.Task;
	}

	// Token: 0x0400E600 RID: 58880
	[Nullable(1)]
	private readonly Func<bool> RunHandle;
}
