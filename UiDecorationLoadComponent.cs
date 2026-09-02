using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Entity.Struct;
using UnrealEngine;

// Token: 0x02002C72 RID: 11378
[NullableContext(1)]
[Nullable(0)]
public class UiDecorationLoadComponent : UiModelComponentBase
{
	// Token: 0x06016D18 RID: 93464 RVA: 0x00654D8D File Offset: 0x00652F8D
	protected override void OnInit()
	{
		this.UiModelActorComponent = base.Owner.CheckGetComponent<UiModelActorComponent>();
		this.UiModelDataComponent = base.Owner.CheckGetComponent<UiModelDataComponent>();
	}

	// Token: 0x06016D19 RID: 93465 RVA: 0x00654DB1 File Offset: 0x00652FB1
	protected override void OnEnd()
	{
		this.CancelLoad();
		this.DestroyLoadMesh();
	}

	// Token: 0x06016D1A RID: 93466 RVA: 0x00654DBF File Offset: 0x00652FBF
	protected SDecorationConfig GetDecorationConfig(int configId)
	{
		return DataTableUtil.GetDataTableRowFromName<SDecorationConfig>(EDataTable.DecorationConfig, configId.ToString());
	}

	// Token: 0x06016D1B RID: 93467 RVA: 0x00654DCF File Offset: 0x00652FCF
	protected string GetMainMeshPath()
	{
		return this.GetDecorationConfig(this.UiModelDataComponent.ModelConfigId).SkeletalMesh.ToAssetPathName();
	}

	// Token: 0x06016D1C RID: 93468 RVA: 0x00654DEC File Offset: 0x00652FEC
	protected string GetAnimClassPath()
	{
		return this.GetDecorationConfig(this.UiModelDataComponent.ModelConfigId).AnimBlueprint.ToAssetPathName();
	}

	// Token: 0x06016D1D RID: 93469 RVA: 0x00654E09 File Offset: 0x00653009
	protected string GetUiAnimClassPath()
	{
		return this.GetDecorationConfig(this.UiModelDataComponent.ModelConfigId).UIAnimBlueprint.ToAssetPathName();
	}

	// Token: 0x06016D1E RID: 93470 RVA: 0x00654E26 File Offset: 0x00653026
	public bool IsSetMasterFollow()
	{
		return this.GetDecorationConfig(this.UiModelDataComponent.ModelConfigId).SetMasterFollow;
	}

	// Token: 0x06016D1F RID: 93471 RVA: 0x00654E3E File Offset: 0x0065303E
	public FName GetAttachSocketName(int? index = null)
	{
		return this.GetDecorationConfig(this.UiModelDataComponent.ModelConfigId).AttachSocket.Get(index.GetValueOrDefault());
	}

	// Token: 0x06016D20 RID: 93472 RVA: 0x00654E62 File Offset: 0x00653062
	public FTransform GetAttachTransform(int? index = null)
	{
		return this.GetDecorationConfig(this.UiModelDataComponent.ModelConfigId).AttachTrans.Get(index.GetValueOrDefault());
	}

	// Token: 0x06016D21 RID: 93473 RVA: 0x00654E86 File Offset: 0x00653086
	public string GetSubMeshName()
	{
		return this.GetDecorationConfig(this.UiModelDataComponent.ModelConfigId).SubMeshName;
	}

	// Token: 0x06016D22 RID: 93474 RVA: 0x00654E9E File Offset: 0x0065309E
	[NullableContext(2)]
	public UiModelActorComponent GetAttachActorComponent()
	{
		return this.UiAttachActorComponent;
	}

	// Token: 0x06016D23 RID: 93475 RVA: 0x00654EA6 File Offset: 0x006530A6
	public void SetAttachActorComponent(UiModelActorComponent actorComponent)
	{
		this.UiAttachActorComponent = actorComponent;
	}

	// Token: 0x06016D24 RID: 93476 RVA: 0x00654EAF File Offset: 0x006530AF
	[NullableContext(2)]
	public void LoadModelByModelId(int modelId, int partIndex, bool waitMeshStreaming = false, Action loadFinishCallBack = null, [Nullable(new byte[]
	{
		2,
		1
	})] List<string> extraResourceList = null, bool skipAttachOnLoadComplete = false)
	{
		int modelConfigId = this.UiModelDataComponent.ModelConfigId;
		this.SkipAttachOnLoadComplete = skipAttachOnLoadComplete;
		this.UiModelDataComponent.ModelConfigId = modelId;
		this.PartIndex = partIndex;
		this.LoadFinishCallBack = loadFinishCallBack;
		this.LoadModel(waitMeshStreaming, extraResourceList, 0);
	}

	// Token: 0x06016D25 RID: 93477 RVA: 0x00654EEC File Offset: 0x006530EC
	protected void LoadModel(bool waitMeshStreaming, [Nullable(new byte[]
	{
		2,
		1
	})] List<string> extraResourceList = null, int levelOfDetail = 0)
	{
		UiModelDataComponent uiModelDataComponent = this.UiModelDataComponent;
		if (uiModelDataComponent != null && uiModelDataComponent.GetModelLoadState() == EUiModelLoadState.IsLoading)
		{
			this.CancelLoad();
			Singleton<Log>.Instance.Warn(ELogModule.Character, ELogAuthor.LZK, "取消上一个模型加载", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		UiModelDataComponent uiModelDataComponent2 = this.UiModelDataComponent;
		if (uiModelDataComponent2 != null)
		{
			uiModelDataComponent2.ClearLoadingVisible();
		}
		if (waitMeshStreaming)
		{
			UiModelDataComponent uiModelDataComponent3 = this.UiModelDataComponent;
			if (uiModelDataComponent3 != null)
			{
				uiModelDataComponent3.SetVisible(false);
			}
		}
		UiModelDataComponent uiModelDataComponent4 = this.UiModelDataComponent;
		if (uiModelDataComponent4 != null)
		{
			uiModelDataComponent4.SetModelLoadState(EUiModelLoadState.IsLoading);
		}
		string animInstanceClassPath = this.GetUiAnimClassPath();
		if (StringUtils.IsEmpty(animInstanceClassPath))
		{
			animInstanceClassPath = this.GetAnimClassPath();
		}
		if (!StringUtils.IsEmpty(animInstanceClassPath))
		{
			this.LoadAnimClassHandle = Singleton<ResourceSystem>.Instance.LoadAsync<UClass>(animInstanceClassPath, delegate([Nullable(2)] UClass asset, string _)
			{
				this.LoadAnimClassHandle = -1;
				this.OnPostLoadAnimClass(asset, animInstanceClassPath, waitMeshStreaming, extraResourceList, levelOfDetail);
			}, 100, "Ui.UiSceneModel");
			return;
		}
		this.OnPostLoadAnimClass(null, animInstanceClassPath, waitMeshStreaming, extraResourceList, levelOfDetail);
	}

	// Token: 0x06016D26 RID: 93478 RVA: 0x00655010 File Offset: 0x00653210
	protected void OnPostLoadAnimClass([Nullable(2)] UClass asset, string path, bool waitMeshStreaming, [Nullable(new byte[]
	{
		2,
		1
	})] List<string> extraResourceList = null, int levelOfDetail = 0)
	{
		string mainMeshPath = this.GetMainMeshPath();
		List<string> list = new List<string>();
		if (mainMeshPath != null && !StringUtils.IsEmpty(mainMeshPath))
		{
			list.Add(mainMeshPath);
		}
		Singleton<UiModelUtil>.Instance.CheckPathListAndAdd(list, extraResourceList);
		Action <>9__1;
		this.LoadHandleId = Singleton<UiModelResourcesManager>.Instance.LoadUiModelResources(list, delegate(EUiRoleLoadResult result, [Nullable(new byte[]
		{
			2,
			1,
			1
		})] Dictionary<string, UObject> resultMap)
		{
			this.DestroyLoadMesh();
			this.ResourceLoadCache = resultMap;
			TArray<USkeletalMesh> tarray = new TArray<USkeletalMesh>();
			USkeletalMesh uskeletalMesh = this.GetLoadedResource(mainMeshPath) as USkeletalMesh;
			tarray.Add(uskeletalMesh);
			UiModelActorComponent uiModelActorComponent = this.UiModelActorComponent;
			if (uiModelActorComponent != null)
			{
				uiModelActorComponent.ChangeMesh(uskeletalMesh, asset, null, null, levelOfDetail);
			}
			if (!waitMeshStreaming)
			{
				this.FinishLoad();
				this.MeshArray.Empty(true);
				return;
			}
			MeshStreamTaskContext meshStreamTaskContext = new MeshStreamTaskContext();
			meshStreamTaskContext.SkeletalMeshes = tarray;
			MeshStreamTaskContext meshStreamTaskContext2 = meshStreamTaskContext;
			Action onTaskFinish;
			if ((onTaskFinish = <>9__1) == null)
			{
				onTaskFinish = (<>9__1 = delegate()
				{
					this.FinishLoad();
					UiModelDataComponent uiModelDataComponent = this.UiModelDataComponent;
					bool valueOrDefault = ((uiModelDataComponent != null) ? uiModelDataComponent.GetLoadingVisible() : null).GetValueOrDefault(true);
					UiModelDataComponent uiModelDataComponent2 = this.UiModelDataComponent;
					if (uiModelDataComponent2 != null)
					{
						uiModelDataComponent2.SetVisible(valueOrDefault);
					}
					UiModelDataComponent uiModelDataComponent3 = this.UiModelDataComponent;
					if (uiModelDataComponent3 == null)
					{
						return;
					}
					uiModelDataComponent3.ClearLoadingVisible();
				});
			}
			meshStreamTaskContext2.OnTaskFinish = onTaskFinish;
			this.MeshStreamTaskId = ControllerBase<MeshStreamController>.Instance.AddMeshStreamTask(meshStreamTaskContext);
		});
	}

	// Token: 0x06016D27 RID: 93479 RVA: 0x006550A0 File Offset: 0x006532A0
	protected void FinishLoad()
	{
		UiModelDataComponent uiModelDataComponent = this.UiModelDataComponent;
		if (uiModelDataComponent != null)
		{
			int modelConfigId = uiModelDataComponent.ModelConfigId;
		}
		UiModelDataComponent uiModelDataComponent2 = this.UiModelDataComponent;
		if (uiModelDataComponent2 != null)
		{
			uiModelDataComponent2.SetModelLoadState(EUiModelLoadState.LoadComplete);
		}
		UiModelDataComponent uiModelDataComponent3 = this.UiModelDataComponent;
		float ditherEffect = (uiModelDataComponent3 != null) ? uiModelDataComponent3.GetDitherEffectValue() : 1f;
		UiModelDataComponent uiModelDataComponent4 = this.UiModelDataComponent;
		if (uiModelDataComponent4 != null)
		{
			uiModelDataComponent4.SetDitherEffect(ditherEffect);
		}
		if (!this.SkipAttachOnLoadComplete)
		{
			this.AttachToTarget();
		}
		Action loadFinishCallBack = this.LoadFinishCallBack;
		if (loadFinishCallBack == null)
		{
			return;
		}
		loadFinishCallBack();
	}

	// Token: 0x06016D28 RID: 93480 RVA: 0x00655118 File Offset: 0x00653318
	public void AttachToTarget()
	{
		UiModelDataComponent uiModelDataComponent = this.UiModelDataComponent;
		if (uiModelDataComponent != null)
		{
			int modelConfigId = uiModelDataComponent.ModelConfigId;
		}
		UiModelActorComponent uiAttachActorComponent = this.UiAttachActorComponent;
		USkeletalMeshComponent uskeletalMeshComponent = (uiAttachActorComponent != null) ? uiAttachActorComponent.MainMeshComponent : null;
		if (uskeletalMeshComponent == null)
		{
			return;
		}
		UiModelActorComponent uiModelActorComponent = this.UiModelActorComponent;
		USkeletalMeshComponent uskeletalMeshComponent2 = (uiModelActorComponent != null) ? uiModelActorComponent.MainMeshComponent : null;
		if (this.IsSetMasterFollow())
		{
			uskeletalMeshComponent.IsValid();
			USkeletalMesh skeletalMesh = uskeletalMeshComponent.SkeletalMesh;
			if (uskeletalMeshComponent2 != null)
			{
				uskeletalMeshComponent2.IsValid();
			}
			if (uskeletalMeshComponent2 != null)
			{
				USkeletalMesh skeletalMesh2 = uskeletalMeshComponent2.SkeletalMesh;
			}
			if (uskeletalMeshComponent2 != null)
			{
				uskeletalMeshComponent2.SetMasterPoseComponent(uskeletalMeshComponent, true);
			}
			this.UiModelActorComponent.Actor.K2_AttachToComponent(uskeletalMeshComponent, FName.NAME_None, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, false, true);
			return;
		}
		FName attachSocketName = this.GetAttachSocketName(new int?(this.PartIndex));
		this.UiModelActorComponent.Actor.K2_AttachToComponent(uskeletalMeshComponent, attachSocketName, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, EAttachmentRule.SnapToTarget, false, true);
		FHitResult fhitResult = new FHitResult();
		AActor actor = this.UiModelActorComponent.Actor;
		FTransform attachTransform = this.GetAttachTransform(new int?(this.PartIndex));
		actor.K2_SetActorRelativeTransform(attachTransform, false, ref fhitResult, false);
	}

	// Token: 0x06016D29 RID: 93481 RVA: 0x0065520C File Offset: 0x0065340C
	private USkeletalMeshComponent GetSubMeshComponent(USkeletalMeshComponent parentMesh, string mesh)
	{
		if (parentMesh.GetOwner() == null || string.IsNullOrEmpty(mesh))
		{
			return parentMesh;
		}
		TArray<USceneComponent> tarray = new TArray<USceneComponent>();
		parentMesh.GetChildrenComponents(true, ref tarray);
		for (int i = 0; i < tarray.Count; i++)
		{
			USceneComponent usceneComponent = tarray[i];
			USkeletalMeshComponent uskeletalMeshComponent = usceneComponent as USkeletalMeshComponent;
			if (uskeletalMeshComponent != null && usceneComponent.GetName() == mesh)
			{
				return uskeletalMeshComponent;
			}
		}
		return parentMesh;
	}

	// Token: 0x06016D2A RID: 93482 RVA: 0x00655270 File Offset: 0x00653470
	public void CancelLoad()
	{
		UiModelDataComponent uiModelDataComponent = this.UiModelDataComponent;
		if (uiModelDataComponent != null && uiModelDataComponent.GetModelLoadState() == EUiModelLoadState.IsLoading)
		{
			Singleton<UiModelResourcesManager>.Instance.CancelUiModelResourceLoad(this.LoadHandleId);
			this.LoadHandleId = Singleton<UiModelResourcesManager>.Instance.InvalidValue;
			this.DestroyLoadMesh();
			if (this.LoadAnimClassHandle != -1)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.LoadAnimClassHandle);
				this.LoadAnimClassHandle = -1;
			}
		}
		this.ResourceLoadCache = null;
		this.SkipAttachOnLoadComplete = false;
		UiModelDataComponent uiModelDataComponent2 = this.UiModelDataComponent;
		if (uiModelDataComponent2 == null)
		{
			return;
		}
		uiModelDataComponent2.SetModelLoadState(EUiModelLoadState.None);
	}

	// Token: 0x06016D2B RID: 93483 RVA: 0x006552F9 File Offset: 0x006534F9
	[return: Nullable(2)]
	public UObject GetLoadedResource(string path)
	{
		if (this.ResourceLoadCache != null)
		{
			return this.ResourceLoadCache.GetValueOrDefault(path);
		}
		return null;
	}

	// Token: 0x06016D2C RID: 93484 RVA: 0x00655311 File Offset: 0x00653511
	protected void DestroyLoadMesh()
	{
		if (this.MeshStreamTaskId != -1)
		{
			ControllerBase<MeshStreamController>.Instance.RemoveMeshStreamTask(this.MeshStreamTaskId);
			this.MeshStreamTaskId = -1;
		}
	}

	// Token: 0x0400AFEE RID: 45038
	[Nullable(2)]
	protected UiModelActorComponent UiModelActorComponent;

	// Token: 0x0400AFEF RID: 45039
	[Nullable(2)]
	protected UiModelDataComponent UiModelDataComponent;

	// Token: 0x0400AFF0 RID: 45040
	[Nullable(2)]
	protected UiModelActorComponent UiAttachActorComponent;

	// Token: 0x0400AFF1 RID: 45041
	private int LoadAnimClassHandle = -1;

	// Token: 0x0400AFF2 RID: 45042
	protected int LoadHandleId = Singleton<UiModelResourcesManager>.Instance.InvalidValue;

	// Token: 0x0400AFF3 RID: 45043
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected Dictionary<string, UObject> ResourceLoadCache;

	// Token: 0x0400AFF4 RID: 45044
	protected TArray<USkeletalMesh> MeshArray = new TArray<USkeletalMesh>();

	// Token: 0x0400AFF5 RID: 45045
	protected int MeshStreamTaskId = -1;

	// Token: 0x0400AFF6 RID: 45046
	protected int PartIndex;

	// Token: 0x0400AFF7 RID: 45047
	[Nullable(2)]
	protected Action LoadFinishCallBack;

	// Token: 0x0400AFF8 RID: 45048
	protected bool SkipAttachOnLoadComplete;
}
