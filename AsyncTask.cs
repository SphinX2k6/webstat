using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020034C5 RID: 13509
public class AsyncTask : TaskBase
{
	// Token: 0x0601C8DA RID: 116954 RVA: 0x0088FB47 File Offset: 0x0088DD47
	[NullableContext(2)]
	public AsyncTask([Nullable(1)] string name, [Nullable(new byte[]
	{
		1,
		0
	})] Func<UniTask<bool>> runHandle, Func<bool> initHandle = null, Action<bool> finishedCallback = null, TaskInterruptOptions interruptOptions = null) : base(name, initHandle, finishedCallback, interruptOptions)
	{
		this.RunHandle = runHandle;
	}

	// Token: 0x0601C8DB RID: 116955 RVA: 0x0088FB5C File Offset: 0x0088DD5C
	protected override UniTask<bool> OnRun()
	{
		AsyncTask.<OnRun>d__2 <OnRun>d__;
		<OnRun>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<OnRun>d__.<>4__this = this;
		<OnRun>d__.<>1__state = -1;
		<OnRun>d__.<>t__builder.Start<AsyncTask.<OnRun>d__2>(ref <OnRun>d__);
		return <OnRun>d__.<>t__builder.Task;
	}

	// Token: 0x0400E601 RID: 58881
	[Nullable(new byte[]
	{
		1,
		0
	})]
	private readonly Func<UniTask<bool>> RunHandle;
}
