using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

// Token: 0x020032BA RID: 12986
[NullableContext(1)]
[Nullable(0)]
public class ModelAssetElement
{
	// Token: 0x17002517 RID: 9495
	// (get) Token: 0x0601B385 RID: 111493 RVA: 0x0082DD7D File Offset: 0x0082BF7D
	// (set) Token: 0x0601B386 RID: 111494 RVA: 0x0082DD85 File Offset: 0x0082BF85
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

	// Token: 0x17002518 RID: 9496
	// (get) Token: 0x0601B387 RID: 111495 RVA: 0x0082DD8E File Offset: 0x0082BF8E
	// (set) Token: 0x0601B388 RID: 111496 RVA: 0x0082DD96 File Offset: 0x0082BF96
	[Nullable(2)]
	public string BlueprintClassPath
	{
		[NullableContext(2)]
		get
		{
			return this.BlueprintClassPathInternal;
		}
		[NullableContext(2)]
		set
		{
			this.BlueprintClassPathInternal = value;
		}
	}

	// Token: 0x0601B389 RID: 111497 RVA: 0x0082DD9F File Offset: 0x0082BF9F
	public ModelAssetElement()
	{
		this.SkillAssetManager = new ModelAssetSkillManager(this);
		this.BulletAssetManager = new ModelAssetBulletManager(this);
	}

	// Token: 0x0601B38A RID: 111498 RVA: 0x0082DDD3 File Offset: 0x0082BFD3
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

	// Token: 0x0601B38B RID: 111499 RVA: 0x0082DDF8 File Offset: 0x0082BFF8
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

	// Token: 0x0601B38C RID: 111500 RVA: 0x0082DE68 File Offset: 0x0082C068
	public void ClearCallback()
	{
		this.Callbacks = null;
	}

	// Token: 0x0601B38D RID: 111501 RVA: 0x0082DE71 File Offset: 0x0082C071
	public void Clear()
	{
		this.IsDestroy = true;
		if (this.Callbacks != null)
		{
			this.DoCallback(ELoadResultType.Destroy);
		}
		this.SkillAssetManager.Clear();
		this.BulletAssetManager.Clear();
		this.Callbacks = null;
	}

	// Token: 0x0601B38E RID: 111502 RVA: 0x0082DEA6 File Offset: 0x0082C0A6
	public void PrintDebugInfo()
	{
	}

	// Token: 0x0400DDDD RID: 56797
	[Nullable(0)]
	public UniTask<ELoadResultType>? Promise;

	// Token: 0x0400DDDE RID: 56798
	public AssetElement MainAsset = new AssetElement(null);

	// Token: 0x0400DDDF RID: 56799
	public ModelAssetSkillManager SkillAssetManager;

	// Token: 0x0400DDE0 RID: 56800
	public ModelAssetBulletManager BulletAssetManager;

	// Token: 0x0400DDE1 RID: 56801
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<Action<ELoadResultType>> Callbacks;

	// Token: 0x0400DDE2 RID: 56802
	public bool IsDestroy;

	// Token: 0x0400DDE3 RID: 56803
	public readonly ResourceSystem.EResourceLoadPriority LoadPriority = ResourceSystem.EResourceLoadPriority.Preload;

	// Token: 0x0400DDE4 RID: 56804
	private ELoadResultType LoadStateInternal;

	// Token: 0x0400DDE5 RID: 56805
	[Nullable(2)]
	private string BlueprintClassPathInternal;
}
