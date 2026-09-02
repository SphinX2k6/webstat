using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Data.Entity.Struct;
using CSharpScript.Game.Module.RoleUi;
using UnrealEngine;

// Token: 0x02002CA5 RID: 11429
[NullableContext(2)]
[Nullable(0)]
public class UiFormationRoleLoadComponent : UiModelLoadComponent
{
	// Token: 0x06016EF3 RID: 93939 RVA: 0x0065B6A2 File Offset: 0x006598A2
	protected override void OnInit()
	{
		base.OnInit();
		this.UiRoleDataComponent = base.Owner.CheckGetComponent<UiRoleDataComponent>();
		this.UiFormationRoleDataComponent = base.Owner.CheckGetComponent<UiFormationRoleDataComponent>();
	}

	// Token: 0x06016EF4 RID: 93940 RVA: 0x0065B6CC File Offset: 0x006598CC
	protected override void OnEnd()
	{
		if (this.MeshStreamTaskId != -1)
		{
			ControllerBase<MeshStreamController>.Instance.RemoveMeshStreamTask(this.MeshStreamTaskId);
			this.MeshStreamTaskId = -1;
		}
		base.OnEnd();
	}

	// Token: 0x06016EF5 RID: 93941 RVA: 0x0065B6F4 File Offset: 0x006598F4
	public void LoadModelByRoleDataId(int roleDataId, int roleSkinId, bool waitMeshStreaming = false, Action loadFinishCallBack = null)
	{
		if (roleDataId == this.UiRoleDataComponent.RoleDataId)
		{
			UiRoleDataComponent uiRoleDataComponent = this.UiRoleDataComponent;
			int? num = (uiRoleDataComponent != null) ? new int?(uiRoleDataComponent.RoleSkinId) : null;
			if (roleSkinId == num.GetValueOrDefault() & num != null)
			{
				return;
			}
		}
		this.UiRoleDataComponent.SetRoleDataId(roleDataId, roleSkinId);
		this.LoadFinishCallBack = loadFinishCallBack;
		this.LoadModel(waitMeshStreaming, null, 0);
	}

	// Token: 0x06016EF6 RID: 93942 RVA: 0x0065B762 File Offset: 0x00659962
	public void LoadModelByRoleConfigId(int roleConfigId, int skinId, bool waitMeshStreaming = false, Action loadFinishCallBack = null)
	{
		if (roleConfigId == this.UiRoleDataComponent.RoleConfigId)
		{
			return;
		}
		this.UiRoleDataComponent.SetRoleConfigId(roleConfigId, skinId);
		this.LoadFinishCallBack = loadFinishCallBack;
		this.LoadModel(waitMeshStreaming, null, 0);
	}

	// Token: 0x06016EF7 RID: 93943 RVA: 0x0065B794 File Offset: 0x00659994
	[NullableContext(1)]
	protected override string GetAnimClassPath()
	{
		if (this.UiRoleDataComponent.RoleSkinId <= 0)
		{
			return ConfigBase<RoleConfig>.Instance.GetRoleConfig(this.UiRoleDataComponent.RoleConfigId).Value.UiScenePerformanceABP;
		}
		return ModelBase<RoleSkinModel>.Instance.GetRoleSkinData(this.UiRoleDataComponent.RoleSkinId).GetRoleSkinConfig().UiScenePerformanceABP;
	}

	// Token: 0x06016EF8 RID: 93944 RVA: 0x0065B7F8 File Offset: 0x006599F8
	[NullableContext(1)]
	protected string GetStandAnimPath()
	{
		Motion? performanceMotionConfigByPosition = ConfigBase<MotionConfig>.Instance.GetPerformanceMotionConfigByPosition(this.UiRoleDataComponent.RoleSkinId, this.UiFormationRoleDataComponent.Position);
		if (performanceMotionConfigByPosition != null)
		{
			return performanceMotionConfigByPosition.Value.AniMontage;
		}
		return string.Empty;
	}

	// Token: 0x06016EF9 RID: 93945 RVA: 0x0065B844 File Offset: 0x00659A44
	protected new void LoadModel(bool waitMeshStreaming, [Nullable(new byte[]
	{
		2,
		1
	})] List<string> extraResourceList = null, int levelOfDetail = 0)
	{
		UiModelDataComponent uiModelDataComponent = this.UiModelDataComponent;
		if (uiModelDataComponent != null && uiModelDataComponent.GetModelLoadState() == EUiModelLoadState.IsLoading)
		{
			base.CancelLoad();
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
		string mainMeshPath = base.GetMainMeshPath();
		List<string> childMeshPathList = base.GetChildMeshPathList();
		List<string> decorationMeshPathList = base.GetDecorationMeshPathList();
		string standAnimPath = this.GetStandAnimPath();
		List<string> list = new List<string>();
		if (!string.IsNullOrEmpty(mainMeshPath))
		{
			list.Add(mainMeshPath);
		}
		Singleton<UiModelUtil>.Instance.CheckPathListAndAdd(list, childMeshPathList);
		Singleton<UiModelUtil>.Instance.CheckPathListAndAdd(list, extraResourceList);
		Singleton<UiModelUtil>.Instance.CheckPathListAndAdd(list, decorationMeshPathList);
		if (!string.IsNullOrEmpty(standAnimPath))
		{
			list.Add(standAnimPath);
		}
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
			List<USkeletalMesh> list2 = null;
			if (childMeshPathList != null)
			{
				list2 = new List<USkeletalMesh>();
				foreach (string path in childMeshPathList)
				{
					USkeletalMesh uskeletalMesh2 = this.GetLoadedResource(path) as USkeletalMesh;
					list2.Add(uskeletalMesh2);
					tarray.Add(uskeletalMesh2);
				}
			}
			TArray<SModelDecorationConfig> modelDecorationArray = this.GetModelDecorationArray();
			List<UiModelDecorationParam> modelMeshDecorationList = this.GetModelMeshDecorationList(modelDecorationArray);
			foreach (UiModelDecorationParam uiModelDecorationParam in modelMeshDecorationList)
			{
				tarray.Add(uiModelDecorationParam.SkeletalMesh);
			}
			UiModelActorComponent uiModelActorComponent = this.UiModelActorComponent;
			if (uiModelActorComponent != null)
			{
				uiModelActorComponent.ChangeMesh(uskeletalMesh, null, list2, modelMeshDecorationList, levelOfDetail);
			}
			UAnimationAsset uanimationAsset = this.GetLoadedResource(standAnimPath) as UAnimationAsset;
			if (uanimationAsset != null)
			{
				UiModelActorComponent uiModelActorComponent2 = this.UiModelActorComponent;
				if (((uiModelActorComponent2 != null) ? uiModelActorComponent2.MainMeshComponent : null) != null)
				{
					this.UiModelActorComponent.MainMeshComponent.SetAnimation(uanimationAsset);
					this.UiModelActorComponent.MainMeshComponent.SetAnimationMode(EAnimationMode.AnimationSingleNode);
				}
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
					UiModelDataComponent uiModelDataComponent5 = this.UiModelDataComponent;
					bool valueOrDefault = ((uiModelDataComponent5 != null) ? uiModelDataComponent5.GetLoadingVisible() : null).GetValueOrDefault(true);
					UiModelDataComponent uiModelDataComponent6 = this.UiModelDataComponent;
					if (uiModelDataComponent6 != null)
					{
						uiModelDataComponent6.SetVisible(valueOrDefault);
					}
					UiModelDataComponent uiModelDataComponent7 = this.UiModelDataComponent;
					if (uiModelDataComponent7 == null)
					{
						return;
					}
					uiModelDataComponent7.ClearLoadingVisible();
				});
			}
			meshStreamTaskContext2.OnTaskFinish = onTaskFinish;
			this.MeshStreamTaskId = ControllerBase<MeshStreamController>.Instance.AddMeshStreamTask(meshStreamTaskContext);
		});
	}

	// Token: 0x0400B0E5 RID: 45285
	private UiFormationRoleDataComponent UiFormationRoleDataComponent;

	// Token: 0x0400B0E6 RID: 45286
	private UiRoleDataComponent UiRoleDataComponent;

	// Token: 0x0400B0E7 RID: 45287
	private int MeshStreamTaskId = -1;
}
