using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02002C51 RID: 11345
[NullableContext(1)]
[Nullable(0)]
public class LoadAsyncPromise<[Nullable(0)] T> where T : UObject
{
	// Token: 0x06016BE8 RID: 93160 RVA: 0x0064F70A File Offset: 0x0064D90A
	public LoadAsyncPromise(string path, ResourceSystem.EResourceLoadPriority priority = ResourceSystem.EResourceLoadPriority.Default)
	{
		this.CustomPromiseObject = new CustomPromise<T>();
		this.LoadAsync(path, priority);
	}

	// Token: 0x17001DD2 RID: 7634
	// (get) Token: 0x06016BE9 RID: 93161 RVA: 0x0064F72C File Offset: 0x0064D92C
	public CustomPromise<T> CustomPromise
	{
		get
		{
			return this.CustomPromiseObject;
		}
	}

	// Token: 0x17001DD3 RID: 7635
	// (get) Token: 0x06016BEA RID: 93162 RVA: 0x0064F734 File Offset: 0x0064D934
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
			return this.CustomPromise.Promise;
		}
	}

	// Token: 0x17001DD4 RID: 7636
	// (get) Token: 0x06016BEB RID: 93163 RVA: 0x0064F741 File Offset: 0x0064D941
	public int HandleId
	{
		get
		{
			return this.HandleIdInternal;
		}
	}

	// Token: 0x06016BEC RID: 93164 RVA: 0x0064F749 File Offset: 0x0064D949
	private void LoadAsync(string path, ResourceSystem.EResourceLoadPriority priority = ResourceSystem.EResourceLoadPriority.Default)
	{
		this.HandleIdInternal = Singleton<ResourceSystem>.Instance.LoadAsync<T>(path2, delegate(T asset, string path)
		{
			this.CustomPromise.SetResult(asset);
		}, (int)priority, "Ui.LoadAsync");
	}

	// Token: 0x06016BED RID: 93165 RVA: 0x0064F770 File Offset: 0x0064D970
	public void CancelAsyncLoad()
	{
		if (this.HandleId != -1)
		{
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.HandleId);
			this.HandleIdInternal = -1;
			this.CustomPromiseObject.SetResult(default(T));
		}
	}

	// Token: 0x0400AF4A RID: 44874
	private int HandleIdInternal = -1;

	// Token: 0x0400AF4B RID: 44875
	private readonly CustomPromise<T> CustomPromiseObject;
}
