using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

// Token: 0x020032C2 RID: 12994
public class AssetElementBundleBase
{
	// Token: 0x1700251F RID: 9503
	// (get) Token: 0x0601B3C4 RID: 111556 RVA: 0x0082ECFE File Offset: 0x0082CEFE
	// (set) Token: 0x0601B3C5 RID: 111557 RVA: 0x0082ED06 File Offset: 0x0082CF06
	public ELoadResultType LoadState
	{
		get
		{
			return this.LoadStateInternal;
		}
		set
		{
			this.LoadStateInternal = value;
		}
	}

	// Token: 0x0601B3C6 RID: 111558 RVA: 0x0082ED0F File Offset: 0x0082CF0F
	[NullableContext(1)]
	public void AddCallback(Action<ELoadResultType> callback)
	{
		if (callback == null)
		{
			return;
		}
		if (this.Callbacks == null)
		{
			this.Callbacks = new List<Action<ELoadResultType>>();
		}
		this.Callbacks.Add(callback);
	}

	// Token: 0x0601B3C7 RID: 111559 RVA: 0x0082ED34 File Offset: 0x0082CF34
	public void DoCallback(ELoadResultType result)
	{
		if (this.Callbacks == null || this.Callbacks.Count == 0)
		{
			return;
		}
		foreach (Action<ELoadResultType> action in this.Callbacks)
		{
			action(result);
		}
		this.Callbacks = null;
	}

	// Token: 0x0601B3C8 RID: 111560 RVA: 0x0082EDA4 File Offset: 0x0082CFA4
	public void ClearCallback()
	{
		this.Callbacks = null;
	}

	// Token: 0x0601B3C9 RID: 111561 RVA: 0x0082EDAD File Offset: 0x0082CFAD
	public virtual void Clear()
	{
		if (this.Callbacks != null)
		{
			this.DoCallback(ELoadResultType.Destroy);
		}
		this.Callbacks = null;
		this.IsDestroy = true;
	}

	// Token: 0x0601B3CA RID: 111562 RVA: 0x0082EDCC File Offset: 0x0082CFCC
	public virtual void PrintDebugInfo()
	{
	}

	// Token: 0x0400DE00 RID: 56832
	public UniTask<ELoadResultType>? Promise;

	// Token: 0x0400DE01 RID: 56833
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<Action<ELoadResultType>> Callbacks;

	// Token: 0x0400DE02 RID: 56834
	public ResourceSystem.EResourceLoadPriority LoadPriority = ResourceSystem.EResourceLoadPriority.Default;

	// Token: 0x0400DE03 RID: 56835
	protected ELoadResultType LoadStateInternal;

	// Token: 0x0400DE04 RID: 56836
	public bool IsDestroy;
}
