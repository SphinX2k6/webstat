using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Cysharp.Threading.Tasks;

// Token: 0x02000038 RID: 56
public class AkiUniTask
{
	// Token: 0x060000F0 RID: 240 RVA: 0x00007300 File Offset: 0x00005500
	public UniTask GetTask()
	{
		UniTaskCompletionSource uniTaskCompletionSource = new UniTaskCompletionSource();
		this.Tasks.Add(uniTaskCompletionSource);
		return uniTaskCompletionSource.Task;
	}

	// Token: 0x060000F1 RID: 241 RVA: 0x00007328 File Offset: 0x00005528
	public void TrySetResult()
	{
		foreach (UniTaskCompletionSource uniTaskCompletionSource in this.Tasks)
		{
			uniTaskCompletionSource.TrySetResult();
		}
	}

	// Token: 0x060000F2 RID: 242 RVA: 0x0000737C File Offset: 0x0000557C
	public void TrySetCanceled()
	{
		foreach (UniTaskCompletionSource uniTaskCompletionSource in this.Tasks)
		{
			uniTaskCompletionSource.TrySetCanceled(default(CancellationToken));
		}
	}

	// Token: 0x040000C9 RID: 201
	[Nullable(1)]
	private readonly List<UniTaskCompletionSource> Tasks = new List<UniTaskCompletionSource>();
}
