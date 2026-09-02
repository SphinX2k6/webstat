using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Effect;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D85 RID: 3461
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateShowUiCalabashEffect.TsAnimNotifyStateShowUiCalabashEffect_C")]
public class TsAnimNotifyStateShowUiCalabashEffect : UKuroEffectMakerANS, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000483 RID: 1155
	// (get) Token: 0x06004C1F RID: 19487 RVA: 0x000A946B File Offset: 0x000A766B
	// (set) Token: 0x06004C20 RID: 19488 RVA: 0x000A947B File Offset: 0x000A767B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool PlayOnEnd
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateShowUiCalabashEffect.__PropertyOffset_PlayOnEnd) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateShowUiCalabashEffect.__PropertyOffset_PlayOnEnd) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000484 RID: 1156
	// (get) Token: 0x06004C21 RID: 19489 RVA: 0x000A948C File Offset: 0x000A768C
	// (set) Token: 0x06004C22 RID: 19490 RVA: 0x000A94A0 File Offset: 0x000A76A0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FName EffectSlotName
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateShowUiCalabashEffect.__PropertyOffset_EffectSlotName);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateShowUiCalabashEffect.__PropertyOffset_EffectSlotName) = value;
		}
	}

	// Token: 0x06004C23 RID: 19491 RVA: 0x000A94B5 File Offset: 0x000A76B5
	private void Init()
	{
		if (this.IsInited)
		{
			return;
		}
		this.ParamsMap = new Dictionary<USkeletalMeshComponent, AnimNotifyStateUiEffectParams>();
		this.IsInited = true;
	}

	// Token: 0x06004C24 RID: 19492 RVA: 0x000A94D4 File Offset: 0x000A76D4
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyBegin(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyBegin"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
			ptr2->TotalDuration = totalDuration;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004C25 RID: 19493 RVA: 0x000A957C File Offset: 0x000A777C
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		if (!meshComp.IsVisible())
		{
			return false;
		}
		this.Init();
		AActor owner = meshComp.GetOwner();
		if (owner is TsUiSceneRoleActor)
		{
			if ((owner as TsUiSceneRoleActor).Model == null)
			{
				return false;
			}
			UiRoleHuluComponent uiRoleHuluComponent = (owner as TsUiSceneRoleActor).Model.CheckGetComponent<UiRoleHuluComponent>();
			if (uiRoleHuluComponent == null)
			{
				return false;
			}
			UiModelBase model = uiRoleHuluComponent.GetHuluHandle().Model;
			if (model == null)
			{
				return false;
			}
			UiHuluSkinDataComponent uiHuluSkinDataComponent = model.CheckGetComponent<UiHuluSkinDataComponent>();
			if (uiHuluSkinDataComponent == null)
			{
				return false;
			}
			UiModelBase model2 = (owner as TsUiSceneRoleActor).Model;
			UiModelAnsControllerComponent uiModelAnsControllerComponent = (model2 != null) ? model2.CheckGetComponent<UiModelAnsControllerComponent>() : null;
			if (uiModelAnsControllerComponent == null)
			{
				return false;
			}
			AActor owner2 = meshComp.GetOwner();
			SkeletalMeshEffectContext skeletalMeshEffectContext = new SkeletalMeshEffectContext(null, null, false);
			skeletalMeshEffectContext.SkeletalMeshComp = meshComp;
			skeletalMeshEffectContext.SourceObject = owner2;
			skeletalMeshEffectContext.CreateFromType = EEffectCreateFromType.An;
			skeletalMeshEffectContext.AnsSlotName = new FName?(this.EffectSlotName);
			FVectorDouble fvectorDouble = UKismetMathLibrary.Conv_VectorToVectorDouble(base.Location);
			string effectPath = uiHuluSkinDataComponent.EffectPath;
			FName socketName = base.SocketName;
			bool attached = base.Attached;
			bool attachLocationOnly = base.AttachLocationOnly;
			FVectorDouble location = fvectorDouble;
			FRotator rotation = base.Rotation;
			FVector scale = base.Scale;
			UiEffectAnsContext uiEffectAnsContext = new UiEffectAnsContext(effectPath, meshComp, socketName, attached, attachLocationOnly, location, rotation, new FVectorDouble(ref scale), this.PlayOnEnd, true, skeletalMeshEffectContext, TsAnimNotifyStateShowUiCalabashEffect.NameNone, delegate(USkeletalMeshComponent mesh, int handle)
			{
				if (!Singleton<EffectSystem>.Instance.IsValid(handle))
				{
					return;
				}
				if (!this.ParamsMap.ContainsKey(mesh))
				{
					return;
				}
				this.ParamsMap[mesh].EffectHandle = new int?(handle);
			});
			uiModelAnsControllerComponent.AddAns<UiEffectAnsContext>("UiEffectAnsContext", uiEffectAnsContext);
			this.ParamsMap[meshComp] = new AnimNotifyStateUiEffectParams(null, uiEffectAnsContext, false);
		}
		return false;
	}

	// Token: 0x06004C26 RID: 19494 RVA: 0x000A96E0 File Offset: 0x000A78E0
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyTick(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyTick"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
			ptr2->FrameDeltaTime = frameDeltaTime;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004C27 RID: 19495 RVA: 0x000A9788 File Offset: 0x000A7988
	[NullableContext(2)]
	protected virtual bool K2_NotifyTick_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float frameDeltaTime)
	{
		AnimNotifyStateUiEffectParams animNotifyStateUiEffectParams;
		if (!this.ParamsMap.TryGetValue(meshComp, out animNotifyStateUiEffectParams))
		{
			return false;
		}
		int? effectHandle = animNotifyStateUiEffectParams.EffectHandle;
		if (effectHandle == null || !Singleton<EffectSystem>.Instance.IsValid(effectHandle.Value))
		{
			return false;
		}
		if (base.Attached && base.AttachLocationOnly && base.SocketName != TsAnimNotifyStateShowUiCalabashEffect.NameNone)
		{
			OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(effectHandle.Value);
			FTransformDouble ftransformDouble = meshComp.D_GetSocketTransform(base.SocketName, ERelativeTransformSpace.RTS_World);
			FVectorDouble fvectorDouble = UKismetMathLibrary.Conv_VectorToVectorDouble(base.Location);
			FHitResult fhitResult = new FHitResult();
			FVectorDouble fvectorDouble2 = ftransformDouble.TransformPosition(fvectorDouble);
			effectActor.D_K2_SetActorLocation(fvectorDouble2, false, ref fhitResult, false);
		}
		return true;
	}

	// Token: 0x06004C28 RID: 19496 RVA: 0x000A9838 File Offset: 0x000A7A38
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyEnd(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyEnd"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004C29 RID: 19497 RVA: 0x000A98D8 File Offset: 0x000A7AD8
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsUiSceneRoleActor))
		{
			return false;
		}
		if (!this.ParamsMap.ContainsKey(meshComp))
		{
			Singleton<Log>.Instance.Error(ELogModule.RenderEffect, ELogAuthor.LZK, "AnimNotifyStateEffect未成对，UiEffectAnsContext为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		AnimNotifyStateUiEffectParams animNotifyStateUiEffectParams = this.ParamsMap[meshComp];
		if (animNotifyStateUiEffectParams == null || animNotifyStateUiEffectParams.UiEffectAnsContext == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.RenderEffect, ELogAuthor.LZK, "AnimNotifyStateEffect未成对，UiEffectAnsContext为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		if ((owner as TsUiSceneRoleActor).Model != null)
		{
			(owner as TsUiSceneRoleActor).Model.CheckGetComponent<UiModelAnsControllerComponent>().ReduceAns<UiEffectAnsContext>("UiEffectAnsContext", animNotifyStateUiEffectParams.UiEffectAnsContext);
			this.ParamsMap.Remove(meshComp);
			return true;
		}
		return false;
	}

	// Token: 0x06004C2A RID: 19498 RVA: 0x000A9998 File Offset: 0x000A7B98
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override string GetNotifyName()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetNotifyName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UAnimNotifyState.__GetNotifyName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UAnimNotifyState.__GetNotifyName_FunctionParams*)ptr + 15L / (long)sizeof(UAnimNotifyState.__GetNotifyName_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		string result = FString.ToString((void*)(&ptr2->__Result));
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return result;
	}

	// Token: 0x06004C2B RID: 19499 RVA: 0x000A9A13 File Offset: 0x000A7C13
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "Ui界面葫芦显示特效";
	}

	// Token: 0x06004C2C RID: 19500 RVA: 0x000A9A1A File Offset: 0x000A7C1A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateShowUiCalabashEffect._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateShowUiCalabashEffect.TsAnimNotifyStateShowUiCalabashEffect_C");
		}
		return TsAnimNotifyStateShowUiCalabashEffect._ClassPtr;
	}

	// Token: 0x06004C2D RID: 19501 RVA: 0x000A9A40 File Offset: 0x000A7C40
	public TsAnimNotifyStateShowUiCalabashEffect() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateShowUiCalabashEffect.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004C2E RID: 19502 RVA: 0x000A9A68 File Offset: 0x000A7C68
	[NullableContext(1)]
	public TsAnimNotifyStateShowUiCalabashEffect(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateShowUiCalabashEffect.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004C2F RID: 19503 RVA: 0x000A9A9B File Offset: 0x000A7C9B
	protected TsAnimNotifyStateShowUiCalabashEffect(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004C30 RID: 19504 RVA: 0x000A9AB0 File Offset: 0x000A7CB0
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004C31 RID: 19505 RVA: 0x000A9AEC File Offset: 0x000A7CEC
	protected unsafe virtual void __CPPCALL_K2_NotifyTick_Implementation(UKuroAnimNotifyState.__K2_NotifyTick_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyTick_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->FrameDeltaTime);
	}

	// Token: 0x06004C32 RID: 19506 RVA: 0x000A9B28 File Offset: 0x000A7D28
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004C33 RID: 19507 RVA: 0x000A9B5B File Offset: 0x000A7D5B
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040015C9 RID: 5577
	[Nullable(1)]
	private Dictionary<USkeletalMeshComponent, AnimNotifyStateUiEffectParams> ParamsMap = new Dictionary<USkeletalMeshComponent, AnimNotifyStateUiEffectParams>();

	// Token: 0x040015CA RID: 5578
	private bool IsInited;

	// Token: 0x040015CB RID: 5579
	[StaticVariableRuleIgnore]
	private static readonly FName NameNone = new FName("None");

	// Token: 0x040015CC RID: 5580
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateShowUiCalabashEffect.TsAnimNotifyStateShowUiCalabashEffect_C";

	// Token: 0x040015CD RID: 5581
	private static IntPtr _ClassPtr;

	// Token: 0x040015CE RID: 5582
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040015CF RID: 5583
	private static int __PropertyOffset_PlayOnEnd;

	// Token: 0x040015D0 RID: 5584
	private static int __PropertyOffset_EffectSlotName;
}
