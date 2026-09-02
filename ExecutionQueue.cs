using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02000036 RID: 54
[NullableContext(1)]
[Nullable(0)]
public class ExecutionQueue
{
	// Token: 0x060000EC RID: 236 RVA: 0x00007214 File Offset: 0x00005414
	public int Enqueue(Func<int, UniTask> task)
	{
		ExecutionQueue.<>c__DisplayClass5_0 CS$<>8__locals1 = new ExecutionQueue.<>c__DisplayClass5_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.task = task;
		ExecutionQueue.<>c__DisplayClass5_0 CS$<>8__locals2 = CS$<>8__locals1;
		int handle = this.Handle;
		this.Handle = handle + 1;
		CS$<>8__locals2.handle = handle;
		this.Pending.Add(CS$<>8__locals1.handle);
		this.TaskQueue.Add(delegate
		{
			ExecutionQueue.<>c__DisplayClass5_0.<<Enqueue>b__0>d <<Enqueue>b__0>d;
			<<Enqueue>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<Enqueue>b__0>d.<>4__this = CS$<>8__locals1;
			<<Enqueue>b__0>d.<>1__state = -1;
			<<Enqueue>b__0>d.<>t__builder.Start<ExecutionQueue.<>c__DisplayClass5_0.<<Enqueue>b__0>d>(ref <<Enqueue>b__0>d);
			return <<Enqueue>b__0>d.<>t__builder.Task;
		});
		if (!this.Executing)
		{
			this.Execute().Forget();
		}
		return CS$<>8__locals1.handle;
	}

	// Token: 0x060000ED RID: 237 RVA: 0x0000728E File Offset: 0x0000548E
	public bool Cancel(int handle)
	{
		return this.Pending.Remove(handle);
	}

	// Token: 0x060000EE RID: 238 RVA: 0x0000729C File Offset: 0x0000549C
	private UniTask Execute()
	{
		ExecutionQueue.<Execute>d__7 <Execute>d__;
		<Execute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Execute>d__.<>4__this = this;
		<Execute>d__.<>1__state = -1;
		<Execute>d__.<>t__builder.Start<ExecutionQueue.<Execute>d__7>(ref <Execute>d__);
		return <Execute>d__.<>t__builder.Task;
	}

	// Token: 0x040000C1 RID: 193
	private const bool EXECUTION_QUEUE_ENABLE = true;

	// Token: 0x040000C2 RID: 194
	private int Handle;

	// Token: 0x040000C3 RID: 195
	private bool Executing;

	// Token: 0x040000C4 RID: 196
	private HashSet<int> Pending = new HashSet<int>();

	// Token: 0x040000C5 RID: 197
	private List<Func<UniTask>> TaskQueue = new List<Func<UniTask>>();
}
