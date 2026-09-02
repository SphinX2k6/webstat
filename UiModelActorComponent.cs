using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.Tuanzi;
using AkiClient.Game.Aki.Character.Role.Common;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using CSharpScript.Core.Common;
using UnrealEngine;

// Token: 0x02002C73 RID: 11379
[NullableContext(1)]
[Nullable(0)]
public class UiModelActorComponent : UiModelComponentBase, IUiModelVisible, IUiModelSetDitherEffect
{
	// Token: 0x06016D2E RID: 93486 RVA: 0x00655364 File Offset: 0x00653564
	protected override void OnInit()
	{
		this.ModelDataComponent = base.Owner.CheckGetComponent<UiModelDataComponent>();
		this.EffectComponent = base.Owner.GetComponent<UiModelEffectComponent>();
		EUiModelActorType? modelActorType = this.ModelDataComponent.ModelActorType;
		if (modelActorType != null)
		{
			EUiModelActorType valueOrDefault = modelActorType.GetValueOrDefault();
			if (valueOrDefault <= EUiModelActorType.TsSkeletalObserver)
			{
				this.CharRenderingComponent = this.CreateUiModelCharRenderingComponent(ECharacterRenderingType.UI);
				return;
			}
			if (valueOrDefault != EUiModelActorType.TsUiSceneDangoActor)
			{
				return;
			}
			this.CharRenderingComponent = this.CreateUiModelCharRenderingComponent(ECharacterRenderingType.Default);
		}
	}

	// Token: 0x06016D2F RID: 93487 RVA: 0x006553D4 File Offset: 0x006535D4
	protected override void OnStart()
	{
	}

	// Token: 0x06016D30 RID: 93488 RVA: 0x006553D6 File Offset: 0x006535D6
	protected override void OnEnd()
	{
	}

	// Token: 0x06016D31 RID: 93489 RVA: 0x006553D8 File Offset: 0x006535D8
	public void OnModelVisibleChange(bool visible)
	{
		if (this.MainMeshComponent != null)
		{
			this.SetMeshComponentEnable(this.MainMeshComponent, visible);
			if (!visible)
			{
				UKuroAnimLibrary.EndAnimNotifyStates(this.MainMeshComponent.GetAnimInstance());
			}
		}
		if (this.ChildMeshComponentList != null && this.ChildMeshComponentList.Count > 0)
		{
			foreach (USkeletalMeshComponent meshComp in this.ChildMeshComponentList)
			{
				this.SetMeshComponentEnable(meshComp, visible);
			}
		}
		if (this.DecorationMeshComponentList != null && this.DecorationMeshComponentList.Count > 0)
		{
			foreach (USkeletalMeshComponent meshComp2 in this.DecorationMeshComponentList)
			{
				this.SetMeshComponentEnable(meshComp2, visible);
			}
		}
	}

	// Token: 0x06016D32 RID: 93490 RVA: 0x006554C4 File Offset: 0x006536C4
	public void OnModelDitherEffectChange(float value)
	{
		CharRenderingComponent charRenderingComponent = this.CharRenderingComponent;
		if (charRenderingComponent == null)
		{
			return;
		}
		charRenderingComponent.SetDitherEffect(value, ECharacterDitherType.UnDefined);
	}

	// Token: 0x06016D33 RID: 93491 RVA: 0x006554D8 File Offset: 0x006536D8
	private USkeletalMeshComponent CreateUiModelSkeletalMeshComponent(FTransform? transform = null)
	{
		AActor actor = this.Actor;
		TSubclassOf<UActorComponent> @class = USkeletalMeshComponent.StaticClass();
		bool bManualAttachment = false;
		FTransform ftransform = transform ?? Singleton<MathUtils>.Instance.DefaultTransform;
		USkeletalMeshComponent uskeletalMeshComponent = actor.AddComponentByClass(@class, bManualAttachment, ftransform, false, default(FName)) as USkeletalMeshComponent;
		uskeletalMeshComponent.KuroMaterialControllerUpdateGroupMode = EKuroMaterialControllerUpdateGroupMode.CharMesh;
		uskeletalMeshComponent.SetTickableWhenPaused(true);
		this.SetMeshComponentEnable(uskeletalMeshComponent, this.ModelDataComponent.GetVisible());
		if (Singleton<Info>.Instance.IsPlayInEditor)
		{
			ULGUIBPLibrary.AddInstanceComponent(this.Actor, uskeletalMeshComponent);
		}
		return uskeletalMeshComponent;
	}

	// Token: 0x06016D34 RID: 93492 RVA: 0x00655568 File Offset: 0x00653768
	private CharRenderingComponent CreateUiModelCharRenderingComponent(ECharacterRenderingType renderType)
	{
		CharRenderingComponent charRenderingComponent = this.Actor.AddComponentByClass(CharRenderingComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName)) as CharRenderingComponent;
		charRenderingComponent.Init(renderType);
		charRenderingComponent.SetTickableWhenPaused(true);
		return charRenderingComponent;
	}

	// Token: 0x06016D35 RID: 93493 RVA: 0x006555B4 File Offset: 0x006537B4
	private void InitCharRenderingComponent()
	{
		EUiModelType? modelType = this.ModelDataComponent.ModelType;
		if (modelType != null)
		{
			switch (modelType.GetValueOrDefault())
			{
			case EUiModelType.Role:
				this.CharRenderingComponent.AddComponent("CharacterMesh0", this.MainMeshComponent);
				return;
			case EUiModelType.Weapon:
				this.CharRenderingComponent.AddComponent("WeaponCase0", this.MainMeshComponent);
				return;
			case EUiModelType.Vision:
				this.CharRenderingComponent.AddComponent("CharacterMesh0", this.MainMeshComponent);
				return;
			case EUiModelType.Hulu:
				this.CharRenderingComponent.AddComponent("HuluCase", this.MainMeshComponent);
				return;
			case EUiModelType.Dango:
				this.CharRenderingComponent.AddComponent("CharacterMesh0", this.MainMeshComponent);
				return;
			case EUiModelType.Glider:
				this.CharRenderingComponent.AddComponentByCase(ECharacterControllerCaseType.OtherCase0, this.MainMeshComponent);
				return;
			case EUiModelType.Motor:
				this.CharRenderingComponent.AddComponent("CharacterMesh0", this.MainMeshComponent);
				return;
			case EUiModelType.MotorDecoration:
				this.CharRenderingComponent.AddComponent("CharacterMesh0", this.MainMeshComponent);
				return;
			case EUiModelType.RoleOrnament:
				this.CharRenderingComponent.AddComponent("OtherCase0", this.MainMeshComponent);
				break;
			case EUiModelType.MotorSoarWing:
				this.CharRenderingComponent.AddComponent("CharacterMesh0", this.MainMeshComponent);
				return;
			default:
				return;
			}
		}
	}

	// Token: 0x06016D36 RID: 93494 RVA: 0x006556F4 File Offset: 0x006538F4
	public void ChangeMesh(USkeletalMesh newMesh, [Nullable(2)] UClass newAnimClass = null, [Nullable(new byte[]
	{
		2,
		1
	})] List<USkeletalMesh> childMeshList = null, [Nullable(new byte[]
	{
		2,
		1
	})] List<UiModelDecorationParam> decorationMeshParamList = null, int levelOfDetail = 0)
	{
		EUiModelType? modelType = this.ModelDataComponent.ModelType;
		if (modelType != null)
		{
			switch (modelType.GetValueOrDefault())
			{
			case EUiModelType.Role:
				this.ChangeRoleMainMesh(newMesh, newAnimClass, childMeshList, decorationMeshParamList, levelOfDetail);
				return;
			case EUiModelType.Weapon:
			case EUiModelType.Hulu:
			case EUiModelType.Dango:
			case EUiModelType.Glider:
			case EUiModelType.MotorDecoration:
			case EUiModelType.RoleOrnament:
			case EUiModelType.MotorSoarWing:
				this.ChangeMainMeshCommon(newMesh, newAnimClass, null, decorationMeshParamList, levelOfDetail);
				return;
			case EUiModelType.Vision:
				this.ChangeMainMeshCommon(newMesh, newAnimClass, childMeshList, decorationMeshParamList, levelOfDetail);
				return;
			case EUiModelType.Motor:
				this.ChangeMainMeshCommon(newMesh, null, null, decorationMeshParamList, levelOfDetail);
				break;
			default:
				return;
			}
		}
	}

	// Token: 0x06016D37 RID: 93495 RVA: 0x00655784 File Offset: 0x00653984
	private void ChangeMainMeshCommon(USkeletalMesh newMesh, [Nullable(2)] UClass newAnimClass = null, [Nullable(new byte[]
	{
		2,
		1
	})] List<USkeletalMesh> childMeshList = null, [Nullable(new byte[]
	{
		2,
		1
	})] List<UiModelDecorationParam> decorationMeshParamList = null, int levelOfDetail = 0)
	{
		CharRenderingComponent charRenderingComponent = this.CharRenderingComponent;
		if (charRenderingComponent != null)
		{
			charRenderingComponent.ResetAllRenderingState();
		}
		this.DestroyChildMeshComponent();
		this.DestroyDecorationMeshComponent();
		UiModelEffectComponent effectComponent = this.EffectComponent;
		if (effectComponent != null)
		{
			effectComponent.DestroyAllEffect();
		}
		USkeletalMeshComponent mainMeshComponent = this.MainMeshComponent;
		UAnimInstance uanimInstance = (mainMeshComponent != null) ? mainMeshComponent.GetAnimInstance() : null;
		if (uanimInstance != null)
		{
			UKuroAnimLibrary.EndAnimNotifyStates(uanimInstance);
		}
		USkeletalMeshComponent uskeletalMeshComponent = this.CreateUiModelSkeletalMeshComponent(null);
		this.RefreshMeshAndSetLod(uskeletalMeshComponent, newMesh, levelOfDetail);
		if (newAnimClass != null && uskeletalMeshComponent != null)
		{
			uskeletalMeshComponent.SetAnimClass(newAnimClass.ClassStackOnlyPtr);
		}
		this.MainMeshComponent = uskeletalMeshComponent;
		if (mainMeshComponent != null)
		{
			this.DestroyMeshComponent(mainMeshComponent);
		}
		if (childMeshList != null && childMeshList.Count > 0)
		{
			foreach (USkeletalMesh newMesh2 in childMeshList)
			{
				this.AddChildMeshComponent(newMesh2);
			}
		}
		if (decorationMeshParamList != null && decorationMeshParamList.Count > 0)
		{
			foreach (UiModelDecorationParam decorationMeshParamList2 in decorationMeshParamList)
			{
				this.AddDecorationMeshComponent(decorationMeshParamList2);
			}
		}
		this.InitCharRenderingComponent();
	}

	// Token: 0x06016D38 RID: 93496 RVA: 0x006558C0 File Offset: 0x00653AC0
	public void ChangeRoleMainMeshAnimation(UAnimationAsset animation)
	{
		USkeletalMeshComponent mainMeshComponent = this.MainMeshComponent;
		if (mainMeshComponent != null)
		{
			mainMeshComponent.PlayAnimation(animation, true);
		}
		USkeletalMeshComponent mainMeshComponent2 = this.MainMeshComponent;
		if (mainMeshComponent2 == null)
		{
			return;
		}
		mainMeshComponent2.SetAnimationMode(EAnimationMode.AnimationSingleNode);
	}

	// Token: 0x06016D39 RID: 93497 RVA: 0x006558E6 File Offset: 0x00653AE6
	private void RefreshMeshAndSetLod(USkeletalMeshComponent skeletalComponent, USkeletalMesh mesh, int levelOfDetail = 0)
	{
		skeletalComponent.SetSkeletalMesh(mesh, true);
		skeletalComponent.SetForcedLOD(levelOfDetail);
	}

	// Token: 0x06016D3A RID: 93498 RVA: 0x006558F8 File Offset: 0x00653AF8
	private void ChangeRoleMainMesh(USkeletalMesh newMesh, [Nullable(2)] UClass newAnimClass = null, [Nullable(new byte[]
	{
		2,
		1
	})] List<USkeletalMesh> childMeshList = null, [Nullable(new byte[]
	{
		2,
		1
	})] List<UiModelDecorationParam> decorationMeshParamList = null, int levelOfDetail = 0)
	{
		UiModelDataComponent modelDataComponent = this.ModelDataComponent;
		bool flag;
		if (modelDataComponent == null)
		{
			flag = true;
		}
		else
		{
			EUiModelActorType? modelActorType = modelDataComponent.ModelActorType;
			EUiModelActorType euiModelActorType = EUiModelActorType.TsUiSceneRoleActor;
			flag = !(modelActorType.GetValueOrDefault() == euiModelActorType & modelActorType != null);
		}
		if (flag)
		{
			Singleton<Log>.Instance.Error(ELogModule.Character, ELogAuthor.LZK, "actor类型必须为TsUiSceneRoleActor", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.CharRenderingComponent.ResetAllRenderingState();
		this.DestroyChildMeshComponent();
		this.DestroyDecorationMeshComponent();
		UiModelEffectComponent effectComponent = this.EffectComponent;
		if (effectComponent != null)
		{
			effectComponent.DestroyAllEffect();
		}
		USkeletalMeshComponent mainMeshComponent = this.MainMeshComponent;
		ABP_PerformanceRole_C abp_PerformanceRole_C = null;
		if (mainMeshComponent != null && mainMeshComponent.GetAnimationMode() == 0)
		{
			abp_PerformanceRole_C = this.GetAnimInstanceFromSkeletalMesh(mainMeshComponent);
			if (abp_PerformanceRole_C != null)
			{
				UKuroAnimLibrary.EndAnimNotifyStates(abp_PerformanceRole_C);
			}
		}
		USkeletalMeshComponent uskeletalMeshComponent = this.CreateUiModelSkeletalMeshComponent(null);
		this.RefreshMeshAndSetLod(uskeletalMeshComponent, newMesh, levelOfDetail);
		if (newAnimClass != null)
		{
			if (uskeletalMeshComponent != null)
			{
				uskeletalMeshComponent.SetAnimClass(newAnimClass.ClassStackOnlyPtr);
			}
			ABP_PerformanceRole_C animInstanceFromSkeletalMesh = this.GetAnimInstanceFromSkeletalMesh(uskeletalMeshComponent);
			if (abp_PerformanceRole_C != null)
			{
				bool flag2 = false;
				TEnumAsByte<EPerformanceRoleState> stateInternal = abp_PerformanceRole_C.StateInternal;
				if ((stateInternal >= 13 && stateInternal <= 15) || stateInternal == 7)
				{
					flag2 = true;
				}
				if (flag2 && animInstanceFromSkeletalMesh != null)
				{
					animInstanceFromSkeletalMesh.SyncAnimInstance(abp_PerformanceRole_C);
				}
			}
		}
		this.MainMeshComponent = uskeletalMeshComponent;
		if (mainMeshComponent != null)
		{
			this.DestroyMeshComponent(mainMeshComponent);
		}
		if (childMeshList != null && childMeshList.Count > 0)
		{
			foreach (USkeletalMesh newMesh2 in childMeshList)
			{
				this.AddChildMeshComponent(newMesh2);
			}
		}
		if (decorationMeshParamList != null && decorationMeshParamList.Count > 0)
		{
			foreach (UiModelDecorationParam decorationMeshParamList2 in decorationMeshParamList)
			{
				this.AddDecorationMeshComponent(decorationMeshParamList2);
			}
		}
		this.InitCharRenderingComponent();
		this.ApplyToonCustomStencilAfterSetup();
	}

	// Token: 0x06016D3B RID: 93499 RVA: 0x00655AD8 File Offset: 0x00653CD8
	private void ApplyToonCustomStencilAfterSetup()
	{
		if (this.ModelDataComponent != null && this.ModelDataComponent.ModelConfigId > 0)
		{
			EUiModelType? modelType = this.ModelDataComponent.ModelType;
			EUiModelType euiModelType = EUiModelType.Role;
			if (modelType.GetValueOrDefault() == euiModelType & modelType != null)
			{
				int toonCustomStencilValue = ModelUtil.GetModelConfig(this.ModelDataComponent.ModelConfigId).ToonCustomStencilValue;
				USkeletalMeshComponent mainMeshComponent = this.MainMeshComponent;
				if (mainMeshComponent != null)
				{
					mainMeshComponent.SetToonCustomStencilValue(toonCustomStencilValue);
				}
				if (this.ChildMeshComponentList != null)
				{
					foreach (USkeletalMeshComponent uskeletalMeshComponent in this.ChildMeshComponentList)
					{
						uskeletalMeshComponent.SetToonCustomStencilValue(toonCustomStencilValue);
					}
				}
				return;
			}
		}
	}

	// Token: 0x06016D3C RID: 93500 RVA: 0x00655B94 File Offset: 0x00653D94
	private USkeletalMeshComponent AddChildMeshComponent(USkeletalMesh newMesh)
	{
		if (this.ChildMeshComponentList == null)
		{
			this.ChildMeshComponentList = new List<USkeletalMeshComponent>();
		}
		USkeletalMeshComponent uskeletalMeshComponent = this.CreateUiModelSkeletalMeshComponent(null);
		this.RefreshMeshAndSetLod(uskeletalMeshComponent, newMesh, 0);
		uskeletalMeshComponent.SetMasterPoseComponent(this.MainMeshComponent, false);
		this.ChildMeshComponentList.Add(uskeletalMeshComponent);
		int value = this.ChildMeshComponentList.Count - 1;
		CharRenderingComponent charRenderingComponent = this.CharRenderingComponent;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
		defaultInterpolatedStringHandler.AppendLiteral("OtherCase");
		defaultInterpolatedStringHandler.AppendFormatted<int>(value);
		charRenderingComponent.AddComponent(defaultInterpolatedStringHandler.ToStringAndClear(), uskeletalMeshComponent);
		return uskeletalMeshComponent;
	}

	// Token: 0x06016D3D RID: 93501 RVA: 0x00655C28 File Offset: 0x00653E28
	private void AddDecorationMeshComponent(IUiModelDecorationParam decorationMeshParamList)
	{
		if (this.DecorationMeshComponentList == null)
		{
			this.DecorationMeshComponentList = new List<USkeletalMeshComponent>();
		}
		USkeletalMeshComponent uskeletalMeshComponent = this.CreateUiModelSkeletalMeshComponent(new FTransform?(decorationMeshParamList.Transform));
		this.RefreshMeshAndSetLod(uskeletalMeshComponent, decorationMeshParamList.SkeletalMesh, 0);
		uskeletalMeshComponent.K2_AttachToComponent(this.MainMeshComponent, FNameUtil.GetDynamicFName(decorationMeshParamList.SocketName).Value, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, false, true);
		this.CharRenderingComponent.AddComponentByCase(ECharacterControllerCaseType.OtherCase0, uskeletalMeshComponent);
		this.DecorationMeshComponentList.Add(uskeletalMeshComponent);
	}

	// Token: 0x06016D3E RID: 93502 RVA: 0x00655CA8 File Offset: 0x00653EA8
	private void DestroyChildMeshComponent()
	{
		if (this.ChildMeshComponentList == null)
		{
			return;
		}
		for (int i = 0; i < this.ChildMeshComponentList.Count; i++)
		{
			USkeletalMeshComponent uskeletalMeshComponent = this.ChildMeshComponentList[i];
			CharRenderingComponent charRenderingComponent = this.CharRenderingComponent;
			if (charRenderingComponent != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
				defaultInterpolatedStringHandler.AppendLiteral("OtherCase");
				defaultInterpolatedStringHandler.AppendFormatted<int>(i);
				charRenderingComponent.RemoveComponent(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			uskeletalMeshComponent.SetMasterPoseComponent(null, false);
			this.DestroyMeshComponent(uskeletalMeshComponent);
		}
		this.ChildMeshComponentList.Clear();
	}

	// Token: 0x06016D3F RID: 93503 RVA: 0x00655D34 File Offset: 0x00653F34
	private void DestroyDecorationMeshComponent()
	{
		if (this.DecorationMeshComponentList == null)
		{
			return;
		}
		CharRenderingComponent charRenderingComponent = this.CharRenderingComponent;
		if (charRenderingComponent != null)
		{
			charRenderingComponent.RemoveComponentByCase(ECharacterControllerCaseType.OtherCase0);
		}
		foreach (USkeletalMeshComponent meshComp in this.DecorationMeshComponentList)
		{
			this.DestroyMeshComponent(meshComp);
		}
		this.DecorationMeshComponentList.Clear();
	}

	// Token: 0x06016D40 RID: 93504 RVA: 0x00655DB0 File Offset: 0x00653FB0
	private void DestroyMeshComponent(USkeletalMeshComponent meshComp)
	{
		meshComp.K2_DestroyComponent(this.Actor);
		if (Singleton<Info>.Instance.IsPlayInEditor)
		{
			ULGUIBPLibrary.RemoveInstanceComponent(this.Actor, meshComp);
		}
	}

	// Token: 0x06016D41 RID: 93505 RVA: 0x00655DD8 File Offset: 0x00653FD8
	public void SetTransformByTag(string tag)
	{
		AActor actorWithTag = UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName(tag).Value, ECollectActorType.UI);
		if (actorWithTag == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiSceneRoleActor;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "查找不到标签对象";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("标签Tag", tag);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		FHitResult fhitResult = new FHitResult();
		AActor actor = this.Actor;
		FTransformDouble ftransformDouble = actorWithTag.D_GetTransform();
		actor.D_K2_SetActorTransform(ftransformDouble, false, ref fhitResult, false);
	}

	// Token: 0x06016D42 RID: 93506 RVA: 0x00655E48 File Offset: 0x00654048
	public void SetAllMeshComponentRelativeTransform(FTransform newTransform, bool bSweep, ref FHitResult sweepHitResult, bool bTeleport = false)
	{
		USkeletalMeshComponent mainMeshComponent = this.MainMeshComponent;
		if (mainMeshComponent != null)
		{
			mainMeshComponent.K2_SetRelativeTransform(newTransform, bSweep, ref sweepHitResult, bTeleport);
		}
		if (this.ChildMeshComponentList == null || this.ChildMeshComponentList.Count == 0)
		{
			return;
		}
		foreach (USkeletalMeshComponent uskeletalMeshComponent in this.ChildMeshComponentList)
		{
			uskeletalMeshComponent.K2_SetRelativeTransform(newTransform, bSweep, ref sweepHitResult, bTeleport);
		}
	}

	// Token: 0x06016D43 RID: 93507 RVA: 0x00655ECC File Offset: 0x006540CC
	[return: Nullable(2)]
	public ABP_PerformanceRole_C GetAnimInstanceFromSkeletalMesh(USkeletalMeshComponent meshComponent)
	{
		UAnimInstance animInstance = meshComponent.GetAnimInstance();
		if (animInstance == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiComponent;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "Ui场景以下网格体AnimInstance获取失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Mesh:", meshComponent.SkeletalMesh);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		UAnimInstance linkedAnimGraphInstanceByTag = animInstance.GetLinkedAnimGraphInstanceByTag(Singleton<CharacterNameDefines>.Instance.ABP_BASE);
		if (linkedAnimGraphInstanceByTag == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.UiComponent;
			ELogAuthor author2 = ELogAuthor.LZK;
			string message2 = "Ui场景以下网格体动画状态机ABP_Performance_{角色}_PC需要重新生成";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Mesh:", meshComponent.SkeletalMesh);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return null;
		}
		if (this.BaseInstance == null)
		{
			this.BaseInstance = Singleton<ResourceSystem>.Instance.GetLoadedAsset<UClass>("/Game/Aki/Character/Role/Common/ABP_PerformanceRole.ABP_PerformanceRole_C");
			if (this.BaseInstance == null)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.UiComponent;
				ELogAuthor author3 = ELogAuthor.LZK;
				string message3 = "Ui场景 基本路径网格体动画蓝图错误";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("现错误Path:", "/Game/Aki/Character/Role/Common/ABP_PerformanceRole.ABP_PerformanceRole_C");
				instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				return null;
			}
		}
		if (linkedAnimGraphInstanceByTag.IsA(this.BaseInstance.ClassStackOnlyPtr))
		{
			return linkedAnimGraphInstanceByTag as ABP_PerformanceRole_C;
		}
		return null;
	}

	// Token: 0x06016D44 RID: 93508 RVA: 0x00655FC0 File Offset: 0x006541C0
	[NullableContext(2)]
	private void SetMeshComponentEnable(USkeletalMeshComponent meshComp, bool enable)
	{
		meshComp.SetHiddenInGame(!enable, false);
		meshComp.SetComponentTickEnabled(enable);
	}

	// Token: 0x06016D45 RID: 93509 RVA: 0x00655FD4 File Offset: 0x006541D4
	[NullableContext(2)]
	public AActor GetActor()
	{
		return this.Actor;
	}

	// Token: 0x06016D46 RID: 93510 RVA: 0x00655FDC File Offset: 0x006541DC
	[return: Nullable(2)]
	public ABP_TuanziNPC_C GetDangoAnimInstanceFromSkeletalMesh(USkeletalMeshComponent meshComponent)
	{
		UAnimInstance animInstance = meshComponent.GetAnimInstance();
		if (animInstance == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiComponent;
			ELogAuthor author = ELogAuthor.BB;
			string message = "Ui团子获取网格体AnimInstance失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Mesh:", meshComponent.SkeletalMesh);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return animInstance as ABP_TuanziNPC_C;
	}

	// Token: 0x0400AFF9 RID: 45049
	[Nullable(2)]
	public AActor Actor;

	// Token: 0x0400AFFA RID: 45050
	[Nullable(2)]
	public USkeletalMeshComponent MainMeshComponent;

	// Token: 0x0400AFFB RID: 45051
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<USkeletalMeshComponent> ChildMeshComponentList;

	// Token: 0x0400AFFC RID: 45052
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<USkeletalMeshComponent> DecorationMeshComponentList;

	// Token: 0x0400AFFD RID: 45053
	[Nullable(2)]
	public CharRenderingComponent CharRenderingComponent;

	// Token: 0x0400AFFE RID: 45054
	[Nullable(2)]
	private UiModelDataComponent ModelDataComponent;

	// Token: 0x0400AFFF RID: 45055
	[Nullable(2)]
	private UiModelEffectComponent EffectComponent;

	// Token: 0x0400B000 RID: 45056
	[Nullable(2)]
	private UClass BaseInstance;
}
