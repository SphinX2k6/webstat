using System;
using System.Runtime.CompilerServices;

// Token: 0x020032C3 RID: 12995
[NullableContext(2)]
[Nullable(0)]
public class PbEntityAssetElement : AssetElementBundleBase
{
	// Token: 0x0601B3CC RID: 111564 RVA: 0x0082EDDE File Offset: 0x0082CFDE
	public PbEntityAssetElement(int pbDataId)
	{
		this.PbDataId = new int?(pbDataId);
		this.LoadPriority = ResourceSystem.EResourceLoadPriority.Preload;
		this.MainAsset = new PbPreloadAssetElement(pbDataId);
		this.FightAssetManager = new FightAssetManager(this);
	}

	// Token: 0x17002520 RID: 9504
	// (get) Token: 0x0601B3CD RID: 111565 RVA: 0x0082EE17 File Offset: 0x0082D017
	// (set) Token: 0x0601B3CE RID: 111566 RVA: 0x0082EE1F File Offset: 0x0082D01F
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

	// Token: 0x17002521 RID: 9505
	// (get) Token: 0x0601B3CF RID: 111567 RVA: 0x0082EE28 File Offset: 0x0082D028
	// (set) Token: 0x0601B3D0 RID: 111568 RVA: 0x0082EE30 File Offset: 0x0082D030
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

	// Token: 0x17002522 RID: 9506
	// (get) Token: 0x0601B3D1 RID: 111569 RVA: 0x0082EE39 File Offset: 0x0082D039
	private int HolderEntityId
	{
		get
		{
			return -this.PbDataId.GetValueOrDefault();
		}
	}

	// Token: 0x0601B3D2 RID: 111570 RVA: 0x0082EE48 File Offset: 0x0082D048
	public override void Clear()
	{
		base.Clear();
		ModelBase<PreloadModelNew>.Instance.HoldPreloadObject.RemoveEntityAssets(this.HolderEntityId);
		this.FightAssetManager.Clear();
		this.BlueprintClassPathInternal = null;
		this.CollectMinorAssetInternal = false;
		if (this.Callbacks != null)
		{
			base.DoCallback(ELoadResultType.Destroy);
		}
		this.Callbacks = null;
		this.IsDestroy = true;
	}

	// Token: 0x0400DE05 RID: 56837
	public int? PbDataId;

	// Token: 0x0400DE06 RID: 56838
	public PbPreloadAssetElement MainAsset;

	// Token: 0x0400DE07 RID: 56839
	[Nullable(1)]
	public FightAssetManager FightAssetManager;

	// Token: 0x0400DE08 RID: 56840
	private bool CollectMinorAssetInternal;

	// Token: 0x0400DE09 RID: 56841
	private string BlueprintClassPathInternal;
}
