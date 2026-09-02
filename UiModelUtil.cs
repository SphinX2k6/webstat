using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using AkiClient.Game.Aki.Data.Entity.Struct;
using CSharpScript.Game;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using CSharpScript.Game.Utils;
using UnrealEngine;
using UnrealEngine.Extension;

// Token: 0x02002CBE RID: 11454
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class UiModelUtil : Singleton<UiModelUtil>
{
	// Token: 0x06016FBD RID: 94141 RVA: 0x0065EF20 File Offset: 0x0065D120
	public void PlayEffectOnRootByPath(UiModelBase model, string effectPath)
	{
		UiModelEffectComponent uiModelEffectComponent = model.CheckGetComponent<UiModelEffectComponent>();
		UiModelActorComponent uiModelActorComponent = model.CheckGetComponent<UiModelActorComponent>();
		USkeletalMeshComponent uskeletalMeshComponent = (uiModelActorComponent != null) ? uiModelActorComponent.MainMeshComponent : null;
		if (uskeletalMeshComponent == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Character, ELogAuthor.LZK, "MainMeshComponent为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (uiModelEffectComponent != null)
		{
			uiModelEffectComponent.PlayEffectOnRoot(effectPath, uskeletalMeshComponent, Singleton<CharacterNameDefines>.Instance.ROOT, true);
		}
	}

	// Token: 0x06016FBE RID: 94142 RVA: 0x0065EF80 File Offset: 0x0065D180
	public void PlayEffectOnRoot(UiModelBase model, string effectId)
	{
		string effectPath = EffectUtil.GetEffectPath(effectId);
		this.PlayEffectOnRootByPath(model, effectPath);
	}

	// Token: 0x06016FBF RID: 94143 RVA: 0x0065EF9C File Offset: 0x0065D19C
	public void PlayEffectOnRootWithCallback(UiModelBase model, string effectId, Action<int> callback)
	{
		UiModelEffectComponent uiModelEffectComponent = model.CheckGetComponent<UiModelEffectComponent>();
		UiModelActorComponent uiModelActorComponent = model.CheckGetComponent<UiModelActorComponent>();
		string effectPath = EffectUtil.GetEffectPath(effectId);
		USkeletalMeshComponent uskeletalMeshComponent = (uiModelActorComponent != null) ? uiModelActorComponent.MainMeshComponent : null;
		if (uskeletalMeshComponent == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Character, ELogAuthor.LZK, "MainMeshComponent为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (uiModelEffectComponent == null)
		{
			return;
		}
		int id = uiModelEffectComponent.PlayEffectByPath(effectPath, uskeletalMeshComponent, Singleton<CharacterNameDefines>.Instance.ROOT, true, false, global::Vector.ZeroVectorDouble, Rotator.ZeroRotator, global::Vector.OneVectorDouble, true, null, null);
		Singleton<EffectSystem>.Instance.AddFinishCallback(id, callback);
	}

	// Token: 0x06016FC0 RID: 94144 RVA: 0x0065F024 File Offset: 0x0065D224
	public void PlayEffectAtRootComponentByPath(UiModelBase model, string effectPath)
	{
		UiModelEffectComponent uiModelEffectComponent = model.CheckGetComponent<UiModelEffectComponent>();
		UiModelActorComponent uiModelActorComponent = model.CheckGetComponent<UiModelActorComponent>();
		USceneComponent usceneComponent;
		if (uiModelActorComponent == null)
		{
			usceneComponent = null;
		}
		else
		{
			AActor actor = uiModelActorComponent.Actor;
			usceneComponent = ((actor != null) ? actor.RootComponent : null);
		}
		USceneComponent usceneComponent2 = usceneComponent;
		if (usceneComponent2 == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Character, ELogAuthor.LZK, "Actor为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (uiModelEffectComponent != null)
		{
			uiModelEffectComponent.PlayEffectOnRoot(effectPath, usceneComponent2, FNameUtil.EMPTY, true);
		}
	}

	// Token: 0x06016FC1 RID: 94145 RVA: 0x0065F088 File Offset: 0x0065D288
	public void PlayEffectAtRootComponent(UiModelBase model, string effectId)
	{
		string effectPath = EffectUtil.GetEffectPath(effectId);
		this.PlayEffectAtRootComponentByPath(model, effectPath);
	}

	// Token: 0x06016FC2 RID: 94146 RVA: 0x0065F0A4 File Offset: 0x0065D2A4
	public int SetRenderingMaterial(UiModelBase model, string materialId)
	{
		UiModelRenderingMaterialComponent uiModelRenderingMaterialComponent = model.CheckGetComponent<UiModelRenderingMaterialComponent>();
		if (uiModelRenderingMaterialComponent == null)
		{
			return 0;
		}
		return uiModelRenderingMaterialComponent.SetRenderingMaterial(materialId);
	}

	// Token: 0x06016FC3 RID: 94147 RVA: 0x0065F0B8 File Offset: 0x0065D2B8
	public void RemoveRenderingMaterial(UiModelBase model, int materialHandleId)
	{
		UiModelRenderingMaterialComponent uiModelRenderingMaterialComponent = model.CheckGetComponent<UiModelRenderingMaterialComponent>();
		if (uiModelRenderingMaterialComponent == null)
		{
			return;
		}
		uiModelRenderingMaterialComponent.RemoveRenderingMaterial(materialHandleId);
	}

	// Token: 0x06016FC4 RID: 94148 RVA: 0x0065F0CB File Offset: 0x0065D2CB
	public bool SetVisible(UiModelBase model, bool visible)
	{
		UiModelDataComponent uiModelDataComponent = model.CheckGetComponent<UiModelDataComponent>();
		return uiModelDataComponent != null && uiModelDataComponent.SetVisible(visible);
	}

	// Token: 0x06016FC5 RID: 94149 RVA: 0x0065F0DF File Offset: 0x0065D2DF
	public void SetWeaponLevelMaterialBreachLevel(UiModelBase model, int breachLevel)
	{
		UiWeaponLevelMaterialComponent uiWeaponLevelMaterialComponent = model.CheckGetComponent<UiWeaponLevelMaterialComponent>();
		if (uiWeaponLevelMaterialComponent == null)
		{
			return;
		}
		uiWeaponLevelMaterialComponent.SetBreachLevel(breachLevel);
	}

	// Token: 0x06016FC6 RID: 94150 RVA: 0x0065F0F2 File Offset: 0x0065D2F2
	public void TryApplyWeaponLevelMaterial(UiModelBase model)
	{
		UiWeaponLevelMaterialComponent uiWeaponLevelMaterialComponent = model.CheckGetComponent<UiWeaponLevelMaterialComponent>();
		if (uiWeaponLevelMaterialComponent == null)
		{
			return;
		}
		uiWeaponLevelMaterialComponent.TryApply();
	}

	// Token: 0x06016FC7 RID: 94151 RVA: 0x0065F104 File Offset: 0x0065D304
	public FVector2D GetActorLguiPos(AActor actor, global::Vector offset = null)
	{
		if (offset == null)
		{
			offset = global::Vector.ZeroVectorProxy;
		}
		FVectorDouble fvectorDouble = actor.D_K2_GetActorLocation();
		FVectorDouble fvectorDouble2 = offset.ToUeVector(false);
		FVectorDouble fvectorDouble3 = fvectorDouble + fvectorDouble2;
		ULGUICanvasScaler canvasScaler = Singleton<UiLayer>.Instance.UiRootItem.GetCanvasScaler();
		FVector2D fvector2D = default(FVector2D);
		UGameplayStatics.D_ProjectWorldToScreen(Global.CharacterController, fvectorDouble3, ref fvector2D, true);
		FVector2D fvector2D2 = canvasScaler.ConvertPositionFromViewportToLGUICanvas(fvector2D);
		Vector2D viewportSize = LGuiExtension.GetViewportSize();
		viewportSize.Set((double)fvector2D2.X - viewportSize.X / 2.0, (double)fvector2D2.Y - viewportSize.Y / 2.0);
		return viewportSize.ToUeVector2D(false);
	}

	// Token: 0x06016FC8 RID: 94152 RVA: 0x0065F1A8 File Offset: 0x0065D3A8
	public void SetTransformByTag(UiModelBase model, string tag)
	{
		UiModelActorComponent uiModelActorComponent = model.CheckGetComponent<UiModelActorComponent>();
		if (uiModelActorComponent == null)
		{
			return;
		}
		uiModelActorComponent.SetTransformByTag("MonsterCase");
	}

	// Token: 0x06016FC9 RID: 94153 RVA: 0x0065F1BF File Offset: 0x0065D3BF
	public void SelectDangoActor(TsUiSceneDangoActor actor, bool isSelect)
	{
		UiDangoMaterialChangeComponent uiDangoMaterialChangeComponent = actor.Model.CheckGetComponent<UiDangoMaterialChangeComponent>();
		if (uiDangoMaterialChangeComponent == null)
		{
			return;
		}
		uiDangoMaterialChangeComponent.ReplaceSelectMaterial(isSelect);
	}

	// Token: 0x06016FCA RID: 94154 RVA: 0x0065F1D8 File Offset: 0x0065D3D8
	public void DangoFadeIn(TsUiSceneDangoActor actor, ERoleFadeCurveDefine? curveId, Action fadeFinishCallBack = null)
	{
		if (curveId == null)
		{
			curveId = new ERoleFadeCurveDefine?(ERoleFadeCurveDefine.RoleFadeInCurve);
		}
		UiModelFadeComponent uiModelFadeComponent = actor.Model.CheckGetComponent<UiModelFadeComponent>();
		int valueOrDefault = ConfigCommonParamById.GetIntConfig("RoleFadeInDuration").GetValueOrDefault();
		if (uiModelFadeComponent == null)
		{
			return;
		}
		float startValue = 1f;
		float endValue = 0f;
		float duration = (float)valueOrDefault;
		ERoleFadeCurveDefine? eroleFadeCurveDefine = curveId;
		uiModelFadeComponent.Fade(startValue, endValue, duration, (eroleFadeCurveDefine != null) ? eroleFadeCurveDefine.GetValueOrDefault() : null, fadeFinishCallBack);
	}

	// Token: 0x06016FCB RID: 94155 RVA: 0x0065F254 File Offset: 0x0065D454
	public void DangoFadeOut(TsUiSceneDangoActor roleActor, ERoleFadeCurveDefine? curveId, Action fadeFinishCallBack = null)
	{
		if (curveId == null)
		{
			curveId = new ERoleFadeCurveDefine?(ERoleFadeCurveDefine.RoleFadeOutCurve);
		}
		UiModelFadeComponent uiModelFadeComponent = roleActor.Model.CheckGetComponent<UiModelFadeComponent>();
		int valueOrDefault = ConfigCommonParamById.GetIntConfig("RoleFadeOutDuration").GetValueOrDefault();
		if (uiModelFadeComponent == null)
		{
			return;
		}
		float startValue = 0f;
		float endValue = 1f;
		float duration = (float)valueOrDefault;
		ERoleFadeCurveDefine? eroleFadeCurveDefine = curveId;
		uiModelFadeComponent.Fade(startValue, endValue, duration, (eroleFadeCurveDefine != null) ? eroleFadeCurveDefine.GetValueOrDefault() : null, fadeFinishCallBack);
	}

	// Token: 0x06016FCC RID: 94156 RVA: 0x0065F2D0 File Offset: 0x0065D4D0
	public void ModelFadeIn(UiModelBase model, ERoleFadeCurveDefine? curveId, Action fadeFinishCallBack = null)
	{
		if (curveId == null)
		{
			curveId = new ERoleFadeCurveDefine?(ERoleFadeCurveDefine.RoleFadeInCurve);
		}
		if (model == null)
		{
			return;
		}
		UiModelFadeComponent uiModelFadeComponent = model.CheckGetComponent<UiModelFadeComponent>();
		int valueOrDefault = ConfigCommonParamById.GetIntConfig("RoleFadeInDuration").GetValueOrDefault();
		if (uiModelFadeComponent == null)
		{
			return;
		}
		float startValue = 1f;
		float endValue = 0f;
		float duration = (float)valueOrDefault;
		ERoleFadeCurveDefine? eroleFadeCurveDefine = curveId;
		uiModelFadeComponent.Fade(startValue, endValue, duration, (eroleFadeCurveDefine != null) ? eroleFadeCurveDefine.GetValueOrDefault() : null, fadeFinishCallBack);
	}

	// Token: 0x06016FCD RID: 94157 RVA: 0x0065F348 File Offset: 0x0065D548
	public void ModelFadeOut(UiModelBase model, ERoleFadeCurveDefine? curveId, Action fadeFinishCallBack = null)
	{
		if (curveId == null)
		{
			curveId = new ERoleFadeCurveDefine?(ERoleFadeCurveDefine.RoleFadeOutCurve);
		}
		if (model == null)
		{
			return;
		}
		UiModelFadeComponent uiModelFadeComponent = model.CheckGetComponent<UiModelFadeComponent>();
		int valueOrDefault = ConfigCommonParamById.GetIntConfig("RoleFadeOutDuration").GetValueOrDefault();
		if (uiModelFadeComponent == null)
		{
			return;
		}
		float startValue = 0f;
		float endValue = 1f;
		float duration = (float)valueOrDefault;
		ERoleFadeCurveDefine? eroleFadeCurveDefine = curveId;
		uiModelFadeComponent.Fade(startValue, endValue, duration, (eroleFadeCurveDefine != null) ? eroleFadeCurveDefine.GetValueOrDefault() : null, fadeFinishCallBack);
	}

	// Token: 0x06016FCE RID: 94158 RVA: 0x0065F3C0 File Offset: 0x0065D5C0
	public void SetDitherEffect(UiModelBase model, float value)
	{
		UiModelDataComponent uiModelDataComponent = model.CheckGetComponent<UiModelDataComponent>();
		if (uiModelDataComponent == null)
		{
			return;
		}
		uiModelDataComponent.SetDitherEffect(value);
	}

	// Token: 0x06016FCF RID: 94159 RVA: 0x0065F3D3 File Offset: 0x0065D5D3
	public void StopFade(UiModelBase model)
	{
		UiModelFadeComponent uiModelFadeComponent = model.CheckGetComponent<UiModelFadeComponent>();
		if (uiModelFadeComponent == null)
		{
			return;
		}
		uiModelFadeComponent.StopFade();
	}

	// Token: 0x06016FD0 RID: 94160 RVA: 0x0065F3E8 File Offset: 0x0065D5E8
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public Dictionary<EUiModelMorphType, IUiMorphId> GetRoleMorphConfigMap(int roleConfigId, int roleSkinId)
	{
		List<RoleMorph> roleMorphConfigList = ConfigBase<RoleConfig>.Instance.GetRoleMorphConfigList(roleConfigId, roleSkinId);
		if (roleMorphConfigList == null || roleMorphConfigList.Count == 0)
		{
			return null;
		}
		Dictionary<EUiModelMorphType, IUiMorphId> dictionary = new Dictionary<EUiModelMorphType, IUiMorphId>();
		foreach (RoleMorph roleMorph in roleMorphConfigList)
		{
			if (roleMorph.Morph != 0 && roleMorph.UiMeshId != 0)
			{
				SModelConfig modelConfig = ModelUtil.GetModelConfig(roleMorph.UiMeshId);
				string mainMeshPath = modelConfig.网格体.ToAssetPathName();
				string uiScenePerformanceABP = roleMorph.UiScenePerformanceABP;
				List<string> childMeshPathList = this.GetChildMeshPathList(roleMorph.UiMeshId);
				UiMorphId value = new UiMorphId
				{
					MainMeshPath = mainMeshPath,
					AnimPath = uiScenePerformanceABP,
					ChildMeshPathList = childMeshPathList,
					DecorationMeshConfigArray = modelConfig.UiModelDecorationArray,
					RoleBody = roleMorph.RoleBody
				};
				dictionary[(EUiModelMorphType)roleMorph.Morph] = value;
			}
		}
		if (dictionary.Count > 0)
		{
			EUiModelMorphType key = EUiModelMorphType.默认形态;
			RoleSkinData roleSkinData = ModelBase<RoleSkinModel>.Instance.GetRoleSkinData(roleSkinId);
			if (roleSkinData != null)
			{
				int uiMeshId = roleSkinData.GetUiMeshId();
				SModelConfig modelConfig2 = ModelUtil.GetModelConfig(uiMeshId);
				string mainMeshPath2 = modelConfig2.网格体.ToAssetPathName();
				string uiScenePerformanceABP2 = roleSkinData.GetRoleSkinConfig().UiScenePerformanceABP;
				List<string> childMeshPathList2 = this.GetChildMeshPathList(uiMeshId);
				UiMorphId value2 = new UiMorphId
				{
					MainMeshPath = mainMeshPath2,
					AnimPath = uiScenePerformanceABP2,
					ChildMeshPathList = childMeshPathList2,
					RoleBody = roleSkinData.GetRoleSkinConfig().RoleBody,
					DecorationMeshConfigArray = modelConfig2.UiModelDecorationArray
				};
				dictionary[key] = value2;
			}
		}
		return dictionary;
	}

	// Token: 0x06016FD1 RID: 94161 RVA: 0x0065F594 File Offset: 0x0065D794
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	private List<string> GetChildMeshPathList(int modelId)
	{
		TArray<TSoftObjectPtr<USkeletalMesh>> 子网格体 = ModelUtil.GetModelConfig(modelId).子网格体;
		if (子网格体 != null)
		{
			int num = 子网格体.Num();
			if (num > 0)
			{
				List<string> list = new List<string>(num);
				for (int i = 0; i < num; i++)
				{
					list[i] = 子网格体.Get(i).ToAssetPathName();
				}
				return list;
			}
		}
		return null;
	}

	// Token: 0x06016FD2 RID: 94162 RVA: 0x0065F5E4 File Offset: 0x0065D7E4
	public void CheckPathListAndAdd(List<string> pathList, [Nullable(new byte[]
	{
		2,
		1
	})] List<string> checkPathList)
	{
		if (checkPathList != null && checkPathList.Count > 0)
		{
			foreach (string text in checkPathList)
			{
				if (!StringUtils.IsEmpty(text))
				{
					pathList.Add(text);
				}
			}
		}
	}

	// Token: 0x06016FD3 RID: 94163 RVA: 0x0065F648 File Offset: 0x0065D848
	public void PlayRoleMontage(UiModelBase model, EPerformanceRoleState roleState, bool reLoop = false, bool reLoopFromLoopToStart = false, bool waitLaseStateEnd = false)
	{
		UiRoleStateMachineComponent uiRoleStateMachineComponent = model.CheckGetComponent<UiRoleStateMachineComponent>();
		if (uiRoleStateMachineComponent == null)
		{
			return;
		}
		uiRoleStateMachineComponent.SetState(roleState, reLoop, reLoopFromLoopToStart, waitLaseStateEnd);
	}

	// Token: 0x06016FD4 RID: 94164 RVA: 0x0065F660 File Offset: 0x0065D860
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public List<T> GetSelfAndOwnerComponents<[Nullable(0)] T>(AActor outer, bool includeOwner = false) where T : UiModelComponentBase
	{
		List<T> list = new List<T>();
		T uiModelComponent = this.GetUiModelComponent<T>(outer);
		if (uiModelComponent != null)
		{
			list.Add(uiModelComponent);
		}
		if (!includeOwner)
		{
			return list;
		}
		AActor attachRootParentActor = outer.GetAttachRootParentActor();
		if (attachRootParentActor != null && attachRootParentActor.IsValid())
		{
			T uiModelComponent2 = this.GetUiModelComponent<T>(attachRootParentActor);
			if (uiModelComponent2 != null)
			{
				list.Add(uiModelComponent2);
			}
		}
		return list;
	}

	// Token: 0x06016FD5 RID: 94165 RVA: 0x0065F6BC File Offset: 0x0065D8BC
	[return: Nullable(2)]
	public T GetUiModelComponent<[Nullable(0)] T>(AActor outer) where T : UiModelComponentBase
	{
		TsUiSceneRoleActor tsUiSceneRoleActor = outer as TsUiSceneRoleActor;
		if (tsUiSceneRoleActor != null)
		{
			UiModelBase model = tsUiSceneRoleActor.Model;
			if (model == null)
			{
				return default(T);
			}
			return model.CheckGetComponent<T>();
		}
		else
		{
			TsSkeletalObserver tsSkeletalObserver = outer as TsSkeletalObserver;
			if (tsSkeletalObserver == null)
			{
				return default(T);
			}
			UiModelBase model2 = tsSkeletalObserver.Model;
			if (model2 == null)
			{
				return default(T);
			}
			return model2.GetComponent<T>();
		}
	}

	// Token: 0x06016FD6 RID: 94166 RVA: 0x0065F71A File Offset: 0x0065D91A
	public static void RefreshRoleOrnaments(UiModelBase model, [Nullable(new byte[]
	{
		2,
		1
	})] OrnamentModelContext[] contexts = null, bool forceRefresh = false)
	{
		UiRoleOrnamentComponent uiRoleOrnamentComponent = model.CheckGetComponent<UiRoleOrnamentComponent>();
		if (uiRoleOrnamentComponent == null)
		{
			return;
		}
		uiRoleOrnamentComponent.RefreshModels(contexts, forceRefresh);
	}

	// Token: 0x06016FD7 RID: 94167 RVA: 0x0065F730 File Offset: 0x0065D930
	public static void LoadRoleModelWithOrnaments(UiModelBase model, int roleId, int roleSkinId, [Nullable(new byte[]
	{
		2,
		1
	})] OrnamentModelContext[] ornamentContexts = null, bool waitMeshStreaming = false, [Nullable(2)] Action callback = null)
	{
		UiRoleOrnamentComponent uiRoleOrnamentComponent = model.CheckGetComponent<UiRoleOrnamentComponent>();
		if (ornamentContexts != null && uiRoleOrnamentComponent != null)
		{
			uiRoleOrnamentComponent.SetPendingContexts(ornamentContexts);
		}
		UiRoleLoadComponent uiRoleLoadComponent = model.CheckGetComponent<UiRoleLoadComponent>();
		if (uiRoleLoadComponent != null)
		{
			uiRoleLoadComponent.LoadModelByRoleDataId(roleId, roleSkinId, waitMeshStreaming, callback);
		}
		if (uiRoleOrnamentComponent != null && uiRoleOrnamentComponent.HasPendingContexts())
		{
			uiRoleOrnamentComponent.RefreshModels(uiRoleOrnamentComponent.ConsumePendingContexts(), false);
		}
	}

	// Token: 0x06016FD8 RID: 94168 RVA: 0x0065F780 File Offset: 0x0065D980
	public static OrnamentModelContext BuildOrnamentModelContext(int skinId, int ornamentId)
	{
		Ornament value = ConfigBase<RoleConfig>.Instance.GetOrnamentConfig(ornamentId).Value;
		int skinOrnamentModelId = RoleUtils.GetSkinOrnamentModelId(skinId, ornamentId);
		List<long> list = new List<long>();
		for (int i = 0; i < value.OrnamentUiBuffLength; i++)
		{
			list.Add(value.OrnamentUiBuff(i));
		}
		return new OrnamentModelContext
		{
			ModelId = skinOrnamentModelId,
			HideInUi = value.HideInUi,
			OrnamentUiBuff = list
		};
	}

	// Token: 0x06016FD9 RID: 94169 RVA: 0x0065F7F4 File Offset: 0x0065D9F4
	public static List<OrnamentModelContext> GetSkinWearingOrnamentContexts(int roleId, int skinId)
	{
		List<int> roleSkinAllWearingOrnaments = ModelBase<RoleOrnamentModel>.Instance.GetRoleSkinAllWearingOrnaments(roleId, skinId);
		if (roleSkinAllWearingOrnaments.Count == 0)
		{
			return new List<OrnamentModelContext>();
		}
		List<OrnamentModelContext> list = new List<OrnamentModelContext>();
		foreach (int ornamentId in roleSkinAllWearingOrnaments)
		{
			list.Add(UiModelUtil.BuildOrnamentModelContext(skinId, ornamentId));
		}
		return list;
	}
}
