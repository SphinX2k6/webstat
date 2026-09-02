using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

// Token: 0x0200003B RID: 59
[NullableContext(1)]
[Nullable(0)]
public class CustomPromise<[Nullable(2)] T>
{
	// Token: 0x1700000C RID: 12
	// (get) Token: 0x060000FD RID: 253 RVA: 0x00007540 File Offset: 0x00005740
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public UniTask<T> Promise
	{
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		get
		{
			if (this.HasResult)
			{
				return UniTask.FromResult<T>(this.Result);
			}
			return this.Tcs.GetTask();
		}
	}

	// Token: 0x060000FE RID: 254 RVA: 0x00007561 File Offset: 0x00005761
	public void SetResult(T value)
	{
		if (this.State != EPromiseState.Pending)
		{
			return;
		}
		this.HasResult = true;
		this.Result = value;
		this.State = EPromiseState.Fulfilled;
		this.Tcs.TrySetResult(value);
	}

	// Token: 0x1700000D RID: 13
	// (get) Token: 0x060000FF RID: 255 RVA: 0x0000758D File Offset: 0x0000578D
	public bool IsFulfilled
	{
		get
		{
			return this.State == EPromiseState.Fulfilled;
		}
	}

	// Token: 0x1700000E RID: 14
	// (get) Token: 0x06000100 RID: 256 RVA: 0x00007598 File Offset: 0x00005798
	public bool IsPending
	{
		get
		{
			return this.State == EPromiseState.Pending;
		}
	}

	// Token: 0x040000CE RID: 206
	private readonly AkiUniTask<T> Tcs = new AkiUniTask<T>();

	// Token: 0x040000CF RID: 207
	private EPromiseState State;

	// Token: 0x040000D0 RID: 208
	private bool HasResult;

	// Token: 0x040000D1 RID: 209
	private T Result;
}
