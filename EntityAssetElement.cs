using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.Fight;
using Cysharp.Threading.Tasks;

// Token: 0x020032B6 RID: 12982
[NullableContext(2)]
[Nullable(0)]
public class EntityAssetElement
{
	// Token: 0x0601B361 RID: 111457 RVA: 0x0082D64C File Offset: 0x0082B84C
	[NullableContext(1)]
	public EntityAssetElement(EntityHandle handle)
	{
		this.MainAsset = new AssetElement(this);
		this.FightAssetManager = new FightAssetManager(this);
		this.EntityHandle = handle;
		this.CreatureDataComponent = handle.Entity.GetComponent<CreatureDataComponent>();
		if (ModelBase<PreloadModelNew>.Instance.LoadingNeedWaitEntitySet.Contains(handle.Id))
		{
			this.LoadPriority = ResourceSystem.EResourceLoadPriority.Preload;
		}
		else if (this.CreatureDataComponent.IsRole())
		{
			this.LoadPriority = ResourceSystem.EResourceLoadPriority.Preload;
		}
		handle.Priority = (ResourceSystem.EResourceLoadPriority)Math.Max((int)this.LoadPriority, (int)handle.Priority);
	}

	// Token: 0x1700250F RID: 9487
	// (get) Token: 0x0601B362 RID: 111458 RVA: 0x0082D6F4 File Offset: 0x0082B8F4
	// (set) Token: 0x0601B363 RID: 111459 RVA: 0x0082D6FC File Offset: 0x0082B8FC
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

	// Token: 0x17002510 RID: 9488
	// (get) Token: 0x0601B364 RID: 111460 RVA: 0x0082D705 File Offset: 0x0082B905
	// (set) Token: 0x0601B365 RID: 111461 RVA: 0x0082D70D File Offset: 0x0082B90D
	public bool CollectMinorAsset
	{
		get
		{
			return this.CollectMinorAssetInternal;
		}
		set
		{
			this.CollectMinorAssetInternal = value;
		}
	}

	// Token: 0x17002511 RID: 9489
	// (get) Token: 0x0601B366 RID: 111462 RVA: 0x0082D716 File Offset: 0x0082B916
	public Entity Entity
	{
		get
		{
			EntityHandle entityHandle = this.EntityHandle;
			if (entityHandle == null)
			{
				return null;
			}
			return entityHandle.Entity;
		}
	}

	// Token: 0x17002512 RID: 9490
	// (get) Token: 0x0601B367 RID: 111463 RVA: 0x0082D729 File Offset: 0x0082B929
	// (set) Token: 0x0601B368 RID: 111464 RVA: 0x0082D731 File Offset: 0x0082B931
	public string BlueprintClassPath
	{
		get
		{
			return this.BlueprintClassPathInternal;
		}
		set
		{
			this.BlueprintClassPathInternal = value;
		}
	}

	// Token: 0x0601B369 RID: 111465 RVA: 0x0082D73C File Offset: 0x0082B93C
	[NullableContext(1)]
	public void SetCharacterLoadTypes(IReadOnlyList<ECharacterLoadType> loadTypes)
	{
		bool flag = this.CharacterLoadTypeList.Count == loadTypes.Count;
		if (flag)
		{
			for (int i = 0; i < loadTypes.Count; i++)
			{
				if (this.CharacterLoadTypeList[i] != (int)loadTypes[i])
				{
					flag = false;
					break;
				}
			}
		}
		if (flag)
		{
			return;
		}
		this.CharacterLoadTypeList.Clear();
		foreach (ECharacterLoadType item in loadTypes)
		{
			this.CharacterLoadTypeList.Add((int)item);
		}
		this.FightAssetManager.SkillAssetManager.ResetForLoadTypeChange();
	}

	// Token: 0x0601B36A RID: 111466 RVA: 0x0082D7EC File Offset: 0x0082B9EC
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

	// Token: 0x0601B36B RID: 111467 RVA: 0x0082D814 File Offset: 0x0082BA14
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

	// Token: 0x0601B36C RID: 111468 RVA: 0x0082D884 File Offset: 0x0082BA84
	public void ClearCallback()
	{
		this.Callbacks = null;
	}

	// Token: 0x0601B36D RID: 111469 RVA: 0x0082D890 File Offset: 0x0082BA90
	public void Clear()
	{
		ModelBase<PreloadModelNew>.Instance.HoldPreloadObject.RemoveEntityAssets(this.Entity.Id);
		this.FightAssetManager.Clear();
		this.BlueprintClassPathInternal = null;
		this.EntityHandle = null;
		this.CreatureDataComponent = null;
		this.CharacterLoadTypeList.Clear();
		this.CollectMinorAssetInternal = false;
		if (this.Callbacks != null)
		{
			this.DoCallback(ELoadResultType.Destroy);
		}
		this.Callbacks = null;
		this.IsDestroy = true;
	}

	// Token: 0x0601B36E RID: 111470 RVA: 0x0082D907 File Offset: 0x0082BB07
	public void PrintDebugInfo()
	{
	}

	// Token: 0x0400DDC0 RID: 56768
	[Nullable(0)]
	public UniTask<ELoadResultType>? Promise;

	// Token: 0x0400DDC1 RID: 56769
	[Nullable(1)]
	public AssetElement MainAsset;

	// Token: 0x0400DDC2 RID: 56770
	[Nullable(1)]
	public FightAssetManager FightAssetManager;

	// Token: 0x0400DDC3 RID: 56771
	public EntityHandle EntityHandle;

	// Token: 0x0400DDC4 RID: 56772
	public CreatureDataComponent CreatureDataComponent;

	// Token: 0x0400DDC5 RID: 56773
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<Action<ELoadResultType>> Callbacks;

	// Token: 0x0400DDC6 RID: 56774
	public readonly ResourceSystem.EResourceLoadPriority LoadPriority = ResourceSystem.EResourceLoadPriority.Default;

	// Token: 0x0400DDC7 RID: 56775
	public bool HasMorphAssets;

	// Token: 0x0400DDC8 RID: 56776
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public HashSet<string> MorphAssetsPaths;

	// Token: 0x0400DDC9 RID: 56777
	[Nullable(1)]
	public List<int> CharacterLoadTypeList = new List<int>();

	// Token: 0x0400DDCA RID: 56778
	private ELoadResultType LoadStateInternal;

	// Token: 0x0400DDCB RID: 56779
	private bool CollectMinorAssetInternal;

	// Token: 0x0400DDCC RID: 56780
	private string BlueprintClassPathInternal;

	// Token: 0x0400DDCD RID: 56781
	public bool IsDestroy;
}
