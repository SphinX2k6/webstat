using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

// Token: 0x0200349B RID: 13467
public class GameModePromise
{
	// Token: 0x1700266F RID: 9839
	// (get) Token: 0x0601C6B0 RID: 116400 RVA: 0x008843D7 File Offset: 0x008825D7
	public UniTask<bool> Promise
	{
		get
		{
			if (this.HasResult)
			{
				return UniTask.FromResult<bool>(this.Result);
			}
			return this.promiseSource.GetTask();
		}
	}

	// Token: 0x0601C6B1 RID: 116401 RVA: 0x008843F8 File Offset: 0x008825F8
	public void SetResult(bool value)
	{
		this.HasResult = true;
		this.Result = value;
		if (GlobalData.Networking() && !Singleton<Net>.Instance.IsServerConnected())
		{
			Singleton<Log>.Instance.Error(ELogModule.World, ELogAuthor.LFJW, "账号已经登出", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.promiseSource.TrySetCanceled();
			return;
		}
		this.promiseSource.TrySetResult(value);
	}

	// Token: 0x0400E491 RID: 58513
	[Nullable(1)]
	private readonly AkiUniTask<bool> promiseSource = new AkiUniTask<bool>();

	// Token: 0x0400E492 RID: 58514
	private bool HasResult;

	// Token: 0x0400E493 RID: 58515
	private bool Result;
}
