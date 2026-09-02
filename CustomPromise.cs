using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

// Token: 0x0200003A RID: 58
public class CustomPromise
{
	// Token: 0x17000009 RID: 9
	// (get) Token: 0x060000F8 RID: 248 RVA: 0x000074D8 File Offset: 0x000056D8
	public UniTask Promise
	{
		get
		{
			if (this.HasResult)
			{
				return UniTask.CompletedTask;
			}
			return this.Tcs.GetTask();
		}
	}

	// Token: 0x060000F9 RID: 249 RVA: 0x000074F3 File Offset: 0x000056F3
	public void SetResult()
	{
		if (this.State != EPromiseState.Pending)
		{
			return;
		}
		this.HasResult = true;
		this.State = EPromiseState.Fulfilled;
		this.Tcs.TrySetResult();
	}

	// Token: 0x1700000A RID: 10
	// (get) Token: 0x060000FA RID: 250 RVA: 0x00007517 File Offset: 0x00005717
	public bool IsFulfilled
	{
		get
		{
			return this.State == EPromiseState.Fulfilled;
		}
	}

	// Token: 0x1700000B RID: 11
	// (get) Token: 0x060000FB RID: 251 RVA: 0x00007522 File Offset: 0x00005722
	public bool IsPending
	{
		get
		{
			return this.State == EPromiseState.Pending;
		}
	}

	// Token: 0x040000CB RID: 203
	[Nullable(1)]
	private readonly AkiUniTask Tcs = new AkiUniTask();

	// Token: 0x040000CC RID: 204
	private EPromiseState State;

	// Token: 0x040000CD RID: 205
	private bool HasResult;
}
