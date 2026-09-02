using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Cysharp.Threading.Tasks;

// Token: 0x02000039 RID: 57
[NullableContext(1)]
[Nullable(0)]
public class AkiUniTask<[Nullable(2)] T>
{
	// Token: 0x060000F4 RID: 244 RVA: 0x000073EC File Offset: 0x000055EC
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public UniTask<T> GetTask()
	{
		UniTaskCompletionSource<T> uniTaskCompletionSource = new UniTaskCompletionSource<T>();
		this.Tasks.Add(uniTaskCompletionSource);
		return uniTaskCompletionSource.Task;
	}

	// Token: 0x060000F5 RID: 245 RVA: 0x00007414 File Offset: 0x00005614
	public void TrySetResult(T result)
	{
		foreach (UniTaskCompletionSource<T> uniTaskCompletionSource in this.Tasks)
		{
			uniTaskCompletionSource.TrySetResult(result);
		}
	}

	// Token: 0x060000F6 RID: 246 RVA: 0x00007468 File Offset: 0x00005668
	public void TrySetCanceled()
	{
		foreach (UniTaskCompletionSource<T> uniTaskCompletionSource in this.Tasks)
		{
			uniTaskCompletionSource.TrySetCanceled(default(CancellationToken));
		}
	}

	// Token: 0x040000CA RID: 202
	private readonly List<UniTaskCompletionSource<T>> Tasks = new List<UniTaskCompletionSource<T>>(1);
}
