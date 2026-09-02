using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Effect;
using CSharpScript.Game.NewWorld.Character.Common.Component;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02003403 RID: 13315
[UClass("/Game/Aki/TypeScript/Game/Render/Effect/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Render/Effect/AnimNotify/AnimNotifyStateGhost.AnimNotifyStateGhost_C")]
public class AnimNotifyStateGhost : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700259A RID: 9626
	// (get) Token: 0x0601BCB5 RID: 113845 RVA: 0x0084A918 File Offset: 0x00848B18
	// (set) Token: 0x0601BCB6 RID: 113846 RVA: 0x0084A951 File Offset: 0x00848B51
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	public TSoftObjectPtr<UEffectModelBase> EffectDataAssetRef
	{
		[NullableContext(1)]
		get
		{
			base.FastCheckIsValid();
			TSoftObjectPtr<UEffectModelBase> result;
			if ((result = this._EffectDataAssetRef) == null)
			{
				result = (this._EffectDataAssetRef = new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)AnimNotifyStateGhost.__PropertyOffset_EffectDataAssetRef, this));
			}
			return result;
		}
		[NullableContext(1)]
		set
		{
			FSoftObjectPtr.NativeCopy((value != null) ? value.NativePtr : IntPtr.Zero, base.NativePtr + (IntPtr)AnimNotifyStateGhost.__PropertyOffset_EffectDataAssetRef, 1);
		}
	}

	// Token: 0x1700259B RID: 9627
	// (get) Token: 0x0601BCB7 RID: 113847 RVA: 0x0084A976 File Offset: 0x00848B76
	// (set) Token: 0x0601BCB8 RID: 113848 RVA: 0x0084A986 File Offset: 0x00848B86
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float SpawnRate
	{
		get
		{
			return *(base.NativePtr + (IntPtr)AnimNotifyStateGhost.__PropertyOffset_SpawnRate);
		}
		set
		{
			*(base.NativePtr + (IntPtr)AnimNotifyStateGhost.__PropertyOffset_SpawnRate) = value;
		}
	}

	// Token: 0x1700259C RID: 9628
	// (get) Token: 0x0601BCB9 RID: 113849 RVA: 0x0084A997 File Offset: 0x00848B97
	// (set) Token: 0x0601BCBA RID: 113850 RVA: 0x0084A9A7 File Offset: 0x00848BA7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool UseSpawnRate
	{
		get
		{
			return *(base.NativePtr + (IntPtr)AnimNotifyStateGhost.__PropertyOffset_UseSpawnRate) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)AnimNotifyStateGhost.__PropertyOffset_UseSpawnRate) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700259D RID: 9629
	// (get) Token: 0x0601BCBB RID: 113851 RVA: 0x0084A9B8 File Offset: 0x00848BB8
	// (set) Token: 0x0601BCBC RID: 113852 RVA: 0x0084A9C8 File Offset: 0x00848BC8
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float SpawnInterval
	{
		get
		{
			return *(base.NativePtr + (IntPtr)AnimNotifyStateGhost.__PropertyOffset_SpawnInterval);
		}
		set
		{
			*(base.NativePtr + (IntPtr)AnimNotifyStateGhost.__PropertyOffset_SpawnInterval) = value;
		}
	}

	// Token: 0x1700259E RID: 9630
	// (get) Token: 0x0601BCBD RID: 113853 RVA: 0x0084A9D9 File Offset: 0x00848BD9
	// (set) Token: 0x0601BCBE RID: 113854 RVA: 0x0084A9E9 File Offset: 0x00848BE9
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float GhostLifeTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)AnimNotifyStateGhost.__PropertyOffset_GhostLifeTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)AnimNotifyStateGhost.__PropertyOffset_GhostLifeTime) = value;
		}
	}

	// Token: 0x1700259F RID: 9631
	// (get) Token: 0x0601BCBF RID: 113855 RVA: 0x0084A9FA File Offset: 0x00848BFA
	// (set) Token: 0x0601BCC0 RID: 113856 RVA: 0x0084AA0A File Offset: 0x00848C0A
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool UseBaseColorTex
	{
		get
		{
			return *(base.NativePtr + (IntPtr)AnimNotifyStateGhost.__PropertyOffset_UseBaseColorTex) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)AnimNotifyStateGhost.__PropertyOffset_UseBaseColorTex) = (value ? 1 : 0);
		}
	}

	// Token: 0x0601BCC1 RID: 113857 RVA: 0x0084AA1C File Offset: 0x00848C1C
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

	// Token: 0x0601BCC2 RID: 113858 RVA: 0x0084AA97 File Offset: 0x00848C97
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "角色残影";
	}

	// Token: 0x0601BCC3 RID: 113859 RVA: 0x0084AAA0 File Offset: 0x00848CA0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_ValidateAssets()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_ValidateAssets"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_ValidateAssets_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_ValidateAssets_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_ValidateAssets_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601BCC4 RID: 113860 RVA: 0x0084AB15 File Offset: 0x00848D15
	protected virtual bool K2_ValidateAssets_Implementation()
	{
		return true;
	}

	// Token: 0x0601BCC5 RID: 113861 RVA: 0x0084AB18 File Offset: 0x00848D18
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

	// Token: 0x0601BCC6 RID: 113862 RVA: 0x0084ABC0 File Offset: 0x00848DC0
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		if (this.EffectHandleMap == null)
		{
			this.EffectHandleMap = new Dictionary<USkeletalMeshComponent, int>();
		}
		Singleton<EffectSystem>.Instance.InitializeWithPreview(false);
		AActor owner = meshComp.GetOwner();
		EffectRuntimeGhostEffectContext effectRuntimeGhostEffectContext = new EffectRuntimeGhostEffectContext(null, null, false);
		string text = this.EffectDataAssetRef.ToAssetPathName();
		TsBaseCharacter tsBaseCharacter = owner as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			effectRuntimeGhostEffectContext.EntityId = new int?(tsBaseCharacter.GetEntityIdNoBlueprint());
			CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
			text = (((characterActorComponent != null) ? characterActorComponent.GetReplaceEffect(text) : null) ?? text);
		}
		else
		{
			TsBaseVehicle tsBaseVehicle = owner as TsBaseVehicle;
			if (tsBaseVehicle != null)
			{
				effectRuntimeGhostEffectContext.EntityId = new int?(tsBaseVehicle.GetEntityIdNoBlueprint());
				VehicleActorComponent vehicleActorComponent = tsBaseVehicle.VehicleActorComponent;
				text = (((vehicleActorComponent != null) ? vehicleActorComponent.GetReplaceEffect(text) : null) ?? text);
			}
		}
		effectRuntimeGhostEffectContext.SkeletalMeshComp = meshComp;
		effectRuntimeGhostEffectContext.SpawnRate = this.SpawnRate;
		effectRuntimeGhostEffectContext.UseSpawnRate = this.UseSpawnRate;
		effectRuntimeGhostEffectContext.SpawnInterval = this.SpawnInterval;
		effectRuntimeGhostEffectContext.GhostLifeTime = this.GhostLifeTime;
		effectRuntimeGhostEffectContext.UseBaseColorTex = this.UseBaseColorTex;
		effectRuntimeGhostEffectContext.SourceObject = owner;
		int? num = null;
		EffectSystem instance = Singleton<EffectSystem>.Instance;
		UObject worldContext = owner;
		FRotator frotator = new FRotator();
		FVectorDouble fvectorDouble = owner.D_K2_GetActorLocation();
		FVectorDouble fvectorDouble2 = new FVectorDouble(1.0, 1.0, 1.0);
		FVector fvector = fvectorDouble2;
		FTransformDouble? ftransformDouble = new FTransformDouble?(new FTransformDouble(ref frotator, ref fvectorDouble, ref fvector));
		num = new int?(instance.SpawnEffect(worldContext, ftransformDouble, text, "[AnimNotifyStateGhost.K2_NotifyBegin]", effectRuntimeGhostEffectContext, EEffectType.Fight, null, null, null, false, false));
		TsBaseCharacter tsBaseCharacter2 = owner as TsBaseCharacter;
		if (tsBaseCharacter2 != null)
		{
			CharacterActorComponent characterActorComponent2 = tsBaseCharacter2.CharacterActorComponent;
			CharacterSelfCenterComponent characterSelfCenterComponent;
			if (characterActorComponent2 == null)
			{
				characterSelfCenterComponent = null;
			}
			else
			{
				Entity entity = characterActorComponent2.Entity;
				characterSelfCenterComponent = ((entity != null) ? entity.GetComponent<CharacterSelfCenterComponent>() : null);
			}
			CharacterSelfCenterComponent characterSelfCenterComponent2 = characterSelfCenterComponent;
			if (characterSelfCenterComponent2 != null && characterSelfCenterComponent2.Valid)
			{
				characterSelfCenterComponent2.AddEffect(num.Value);
			}
		}
		if (num != null && Singleton<EffectSystem>.Instance.IsValid(num.Value))
		{
			Singleton<EffectSystem>.Instance.SetEffectNotRecord(num.Value, true);
			this.EffectHandleMap[meshComp] = num.Value;
		}
		return false;
	}

	// Token: 0x0601BCC7 RID: 113863 RVA: 0x0084ADC8 File Offset: 0x00848FC8
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

	// Token: 0x0601BCC8 RID: 113864 RVA: 0x0084AE68 File Offset: 0x00849068
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		if (this.EffectHandleMap == null || !this.EffectHandleMap.ContainsKey(meshComp))
		{
			return true;
		}
		int num = this.EffectHandleMap[meshComp];
		if (num != 0 && Singleton<EffectSystem>.Instance.IsValid(num))
		{
			Singleton<EffectSystem>.Instance.StopEffectById(num, "[AnimNotifyStateGhost.K2_NotifyEnd]", false, null);
		}
		this.EffectHandleMap.Remove(meshComp);
		return true;
	}

	// Token: 0x0601BCC9 RID: 113865 RVA: 0x0084AED3 File Offset: 0x008490D3
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (AnimNotifyStateGhost._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Render/Effect/AnimNotify/AnimNotifyStateGhost.AnimNotifyStateGhost_C");
		}
		return AnimNotifyStateGhost._ClassPtr;
	}

	// Token: 0x0601BCCA RID: 113866 RVA: 0x0084AEF8 File Offset: 0x008490F8
	public AnimNotifyStateGhost() : this(BuiltinUtils.AllocNativeUObject(AnimNotifyStateGhost.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601BCCB RID: 113867 RVA: 0x0084AF20 File Offset: 0x00849120
	[NullableContext(1)]
	public AnimNotifyStateGhost(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(AnimNotifyStateGhost.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601BCCC RID: 113868 RVA: 0x0084AF53 File Offset: 0x00849153
	protected AnimNotifyStateGhost(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601BCCD RID: 113869 RVA: 0x0084AF5C File Offset: 0x0084915C
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0601BCCE RID: 113870 RVA: 0x0084AF70 File Offset: 0x00849170
	protected unsafe virtual void __CPPCALL_K2_ValidateAssets_Implementation(UKuroAnimNotifyState.__K2_ValidateAssets_FunctionParams* __Params)
	{
		__Params->__Result = this.K2_ValidateAssets_Implementation();
	}

	// Token: 0x0601BCCF RID: 113871 RVA: 0x0084AF80 File Offset: 0x00849180
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x0601BCD0 RID: 113872 RVA: 0x0084AFBC File Offset: 0x008491BC
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0400E06E RID: 57454
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected Dictionary<USkeletalMeshComponent, int> EffectHandleMap;

	// Token: 0x0400E06F RID: 57455
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Render/Effect/AnimNotify/AnimNotifyStateGhost.AnimNotifyStateGhost_C";

	// Token: 0x0400E070 RID: 57456
	private static IntPtr _ClassPtr;

	// Token: 0x0400E071 RID: 57457
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400E072 RID: 57458
	private static int __PropertyOffset_EffectDataAssetRef;

	// Token: 0x0400E073 RID: 57459
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TSoftObjectPtr<UEffectModelBase> _EffectDataAssetRef;

	// Token: 0x0400E074 RID: 57460
	private static int __PropertyOffset_SpawnRate;

	// Token: 0x0400E075 RID: 57461
	private static int __PropertyOffset_UseSpawnRate;

	// Token: 0x0400E076 RID: 57462
	private static int __PropertyOffset_SpawnInterval;

	// Token: 0x0400E077 RID: 57463
	private static int __PropertyOffset_GhostLifeTime;

	// Token: 0x0400E078 RID: 57464
	private static int __PropertyOffset_UseBaseColorTex;
}
