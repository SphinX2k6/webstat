using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Utils;
using UnrealEngine;

// Token: 0x02002C90 RID: 11408
[NullableContext(1)]
[Nullable(0)]
public class UiModelRenderingMaterialComponent : UiModelComponentBase
{
	// Token: 0x17001E2D RID: 7725
	// (get) Token: 0x06016E59 RID: 93785 RVA: 0x00659610 File Offset: 0x00657810
	private int MaterialId
	{
		get
		{
			int num = this.StartIndex + 1;
			this.StartIndex = num;
			return num;
		}
	}

	// Token: 0x06016E5A RID: 93786 RVA: 0x0065962E File Offset: 0x0065782E
	protected override void OnInit()
	{
		this.ActorComponent = base.Owner.CheckGetComponent<UiModelActorComponent>();
		this.UiModelDataComponent = base.Owner.CheckGetComponent<UiModelDataComponent>();
	}

	// Token: 0x06016E5B RID: 93787 RVA: 0x00659652 File Offset: 0x00657852
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.AddWithTarget(base.Owner, EEventName.OnUiModelLoadComplete, new Action(this.OnModelLoadComplete));
	}

	// Token: 0x06016E5C RID: 93788 RVA: 0x00659678 File Offset: 0x00657878
	protected override void OnEnd()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Owner, EEventName.OnUiModelLoadComplete, new Action(this.OnModelLoadComplete));
		foreach (IMaterialHandle materialHandle in this.MaterialMap.Values)
		{
			int handleId = materialHandle.HandleId;
			if (handleId != 0 && handleId != -1)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(handleId);
			}
		}
		this.MaterialMap.Clear();
		CharRenderingComponent charRenderingComponent = this.ActorComponent.CharRenderingComponent;
		if (charRenderingComponent == null)
		{
			return;
		}
		charRenderingComponent.ResetAllRenderingState();
	}

	// Token: 0x06016E5D RID: 93789 RVA: 0x00659724 File Offset: 0x00657924
	public int SetRenderingMaterial(string effectId)
	{
		int materialId = this.MaterialId;
		MaterialHandle value = new MaterialHandle
		{
			EffectId = effectId,
			HandleId = -1,
			RenderingId = -1
		};
		this.MaterialMap[materialId] = value;
		this.MaterialToAdd.Add(materialId);
		this.Execute();
		return materialId;
	}

	// Token: 0x06016E5E RID: 93790 RVA: 0x00659774 File Offset: 0x00657974
	public int AddRenderingMaterialByPath(string path)
	{
		int materialId = this.MaterialId;
		MaterialHandle value = new MaterialHandle
		{
			EffectPath = path,
			HandleId = -1,
			RenderingId = -1
		};
		this.MaterialMap[materialId] = value;
		this.MaterialToAdd.Add(materialId);
		this.Execute();
		return materialId;
	}

	// Token: 0x06016E5F RID: 93791 RVA: 0x006597C4 File Offset: 0x006579C4
	public int AddRenderingMaterialByData(PD_CharacterControllerData_C data)
	{
		int materialId = this.MaterialId;
		MaterialHandle value = new MaterialHandle
		{
			MaterialAssetData = data,
			HandleId = -1,
			RenderingId = -1
		};
		this.MaterialMap[materialId] = value;
		this.MaterialToAdd.Add(materialId);
		this.Execute();
		return materialId;
	}

	// Token: 0x06016E60 RID: 93792 RVA: 0x00659814 File Offset: 0x00657A14
	public int AddRenderingMaterialWithAnimObject(PD_CharacterControllerData_C data, USkeletalMeshComponent meshComp)
	{
		int materialId = this.MaterialId;
		MaterialHandle value = new MaterialHandle
		{
			MaterialAssetData = data,
			HandleId = -1,
			RenderingId = -1,
			WithAnimObject = new bool?(true),
			AnimMeshComp = meshComp
		};
		this.MaterialMap[materialId] = value;
		this.MaterialToAdd.Add(materialId);
		this.Execute();
		return materialId;
	}

	// Token: 0x06016E61 RID: 93793 RVA: 0x00659878 File Offset: 0x00657A78
	public int AddRenderingMaterialGroup(PD_CharacterControllerDataGroup_C data)
	{
		int materialId = this.MaterialId;
		MaterialHandle value = new MaterialHandle
		{
			MaterialAssetData = data,
			HandleId = -1,
			RenderingId = -1,
			IsGroup = new bool?(true)
		};
		this.MaterialMap[materialId] = value;
		this.MaterialToAdd.Add(materialId);
		this.Execute();
		return materialId;
	}

	// Token: 0x06016E62 RID: 93794 RVA: 0x006598D4 File Offset: 0x00657AD4
	private void Execute()
	{
		UiModelDataComponent uiModelDataComponent = this.UiModelDataComponent;
		if (uiModelDataComponent != null && uiModelDataComponent.GetModelLoadState() == EUiModelLoadState.LoadComplete)
		{
			foreach (int materialId in this.MaterialToAdd)
			{
				this.AddRenderingMaterialById(materialId);
			}
			this.MaterialToAdd.Clear();
		}
	}

	// Token: 0x06016E63 RID: 93795 RVA: 0x0065994C File Offset: 0x00657B4C
	private void AddRenderingMaterialById(int materialId)
	{
		UiModelRenderingMaterialComponent.<>c__DisplayClass16_0 CS$<>8__locals1 = new UiModelRenderingMaterialComponent.<>c__DisplayClass16_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.materialId = materialId;
		CS$<>8__locals1.materialHandle = this.MaterialMap[CS$<>8__locals1.materialId];
		CS$<>8__locals1.charRenderingComp = this.ActorComponent.CharRenderingComponent;
		if (!string.IsNullOrEmpty(CS$<>8__locals1.materialHandle.EffectId) || !string.IsNullOrEmpty(CS$<>8__locals1.materialHandle.EffectPath))
		{
			string text = (!string.IsNullOrEmpty(CS$<>8__locals1.materialHandle.EffectId)) ? EffectUtil.GetEffectPath(CS$<>8__locals1.materialHandle.EffectId) : CS$<>8__locals1.materialHandle.EffectPath;
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			CS$<>8__locals1.materialHandle.HandleId = Singleton<ResourceSystem>.Instance.LoadAsync<UObject>(text, new Action<UObject, string>(CS$<>8__locals1.<AddRenderingMaterialById>g__CallBack|0), 100, "Ui.UiSceneModel");
		}
		if (CS$<>8__locals1.materialHandle.MaterialAssetData != null)
		{
			if (CS$<>8__locals1.materialHandle.WithAnimObject.GetValueOrDefault())
			{
				CS$<>8__locals1.materialHandle.RenderingId = (int)CS$<>8__locals1.charRenderingComp.AddMaterialControllerDataWithAnimObject(CS$<>8__locals1.materialHandle.MaterialAssetData, CS$<>8__locals1.materialHandle.AnimMeshComp, null);
				base.Owner.OnRenderingMaterialAdd(CS$<>8__locals1.materialId, CS$<>8__locals1.materialHandle.MaterialAssetData, false, true);
				return;
			}
			if (CS$<>8__locals1.materialHandle.IsGroup.GetValueOrDefault())
			{
				CS$<>8__locals1.materialHandle.RenderingId = CS$<>8__locals1.charRenderingComp.AddMaterialControllerDataGroup(CS$<>8__locals1.materialHandle.MaterialAssetData);
				base.Owner.OnRenderingMaterialAdd(CS$<>8__locals1.materialId, CS$<>8__locals1.materialHandle.MaterialAssetData, true, false);
				return;
			}
			CS$<>8__locals1.materialHandle.RenderingId = CS$<>8__locals1.charRenderingComp.AddMaterialControllerData(CS$<>8__locals1.materialHandle.MaterialAssetData);
			base.Owner.OnRenderingMaterialAdd(CS$<>8__locals1.materialId, CS$<>8__locals1.materialHandle.MaterialAssetData, false, false);
		}
	}

	// Token: 0x06016E64 RID: 93796 RVA: 0x00659B24 File Offset: 0x00657D24
	public void RemoveRenderingMaterial(int materialId)
	{
		IMaterialHandle materialHandle;
		if (this.MaterialMap.TryGetValue(materialId, out materialHandle))
		{
			bool? isGroup = materialHandle.IsGroup;
			int handleId = materialHandle.HandleId;
			if (handleId != 0 && handleId != -1)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(handleId);
			}
			int renderingId = materialHandle.RenderingId;
			if (renderingId != 0 && renderingId != -1)
			{
				if (isGroup.GetValueOrDefault())
				{
					this.ActorComponent.CharRenderingComponent.RemoveMaterialControllerDataGroup(renderingId);
				}
				else
				{
					this.ActorComponent.CharRenderingComponent.RemoveMaterialControllerData(renderingId);
				}
				base.Owner.OnRenderingMaterialRemove(materialId, isGroup.GetValueOrDefault(), false);
			}
			else
			{
				this.MaterialToAdd.Remove(materialId);
			}
			this.MaterialMap.Remove(materialId);
		}
	}

	// Token: 0x06016E65 RID: 93797 RVA: 0x00659BD0 File Offset: 0x00657DD0
	public void RemoveRenderingMaterialWithEnding(int materialId)
	{
		IMaterialHandle materialHandle;
		if (this.MaterialMap.TryGetValue(materialId, out materialHandle))
		{
			bool? isGroup = materialHandle.IsGroup;
			int handleId = materialHandle.HandleId;
			if (handleId != 0 && handleId != -1)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(handleId);
			}
			int renderingId = materialHandle.RenderingId;
			CharRenderingComponent charRenderingComponent = this.ActorComponent.CharRenderingComponent;
			if (renderingId != 0 && renderingId != -1)
			{
				if (isGroup.GetValueOrDefault())
				{
					charRenderingComponent.RemoveMaterialControllerDataGroupWithEnding(renderingId);
				}
				else
				{
					charRenderingComponent.RemoveMaterialControllerDataWithEnding(renderingId);
				}
				base.Owner.OnRenderingMaterialRemove(materialId, isGroup.GetValueOrDefault(), true);
			}
			this.MaterialMap.Remove(materialId);
		}
	}

	// Token: 0x06016E66 RID: 93798 RVA: 0x00659C64 File Offset: 0x00657E64
	public void OnModelLoadComplete()
	{
		this.Execute();
	}

	// Token: 0x0400B098 RID: 45208
	[Nullable(2)]
	public UiModelActorComponent ActorComponent;

	// Token: 0x0400B099 RID: 45209
	[Nullable(2)]
	public UiModelDataComponent UiModelDataComponent;

	// Token: 0x0400B09A RID: 45210
	private readonly Dictionary<int, IMaterialHandle> MaterialMap = new Dictionary<int, IMaterialHandle>();

	// Token: 0x0400B09B RID: 45211
	private int StartIndex;

	// Token: 0x0400B09C RID: 45212
	private readonly HashSet<int> MaterialToAdd = new HashSet<int>();
}
