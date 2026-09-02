using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D5C RID: 3420
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateModifyMeshLocation.TsAnimNotifyStateModifyMeshLocation_C")]
public class TsAnimNotifyStateModifyMeshLocation : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170003FD RID: 1021
	// (get) Token: 0x0600490B RID: 18699 RVA: 0x0009C2F7 File Offset: 0x0009A4F7
	// (set) Token: 0x0600490C RID: 18700 RVA: 0x0009C30B File Offset: 0x0009A50B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector RelativeLocation
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateModifyMeshLocation.__PropertyOffset_RelativeLocation);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateModifyMeshLocation.__PropertyOffset_RelativeLocation) = value;
		}
	}

	// Token: 0x0600490D RID: 18701 RVA: 0x0009C320 File Offset: 0x0009A520
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

	// Token: 0x0600490E RID: 18702 RVA: 0x0009C3C8 File Offset: 0x0009A5C8
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		Entity entityNoBlueprint = ((TsBaseCharacter)owner).GetEntityNoBlueprint();
		CharacterAnimationComponent characterAnimationComponent = (entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<CharacterAnimationComponent>() : null;
		if (characterAnimationComponent != null && characterAnimationComponent.Valid)
		{
			TsBaseCharacter actor = characterAnimationComponent.Actor;
			if (((actor != null) ? actor.Mesh : null) != null && characterAnimationComponent.Actor.Mesh.IsValid())
			{
				Vector commonTempVector = Singleton<MathUtils>.Instance.CommonTempVector;
				FVector relativeLocation = this.RelativeLocation;
				commonTempVector.FromUeVector(relativeLocation);
				characterAnimationComponent.AddModelLocation(Singleton<MathUtils>.Instance.CommonTempVector);
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600490F RID: 18703 RVA: 0x0009C45C File Offset: 0x0009A65C
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

	// Token: 0x06004910 RID: 18704 RVA: 0x0009C4FC File Offset: 0x0009A6FC
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		Entity entityNoBlueprint = ((TsBaseCharacter)owner).GetEntityNoBlueprint();
		CharacterAnimationComponent characterAnimationComponent = (entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<CharacterAnimationComponent>() : null;
		if (characterAnimationComponent != null && characterAnimationComponent.Valid)
		{
			TsBaseCharacter actor = characterAnimationComponent.Actor;
			if (((actor != null) ? actor.Mesh : null) != null && characterAnimationComponent.Actor.Mesh.IsValid())
			{
				Vector commonTempVector = Singleton<MathUtils>.Instance.CommonTempVector;
				FVector relativeLocation = this.RelativeLocation;
				commonTempVector.FromUeVector(relativeLocation);
				Singleton<MathUtils>.Instance.CommonTempVector.UnaryNegation(Singleton<MathUtils>.Instance.CommonTempVector);
				characterAnimationComponent.AddModelLocation(Singleton<MathUtils>.Instance.CommonTempVector);
				return true;
			}
		}
		return false;
	}

	// Token: 0x06004911 RID: 18705 RVA: 0x0009C5A8 File Offset: 0x0009A7A8
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

	// Token: 0x06004912 RID: 18706 RVA: 0x0009C623 File Offset: 0x0009A823
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "调整Mesh相对位置";
	}

	// Token: 0x06004913 RID: 18707 RVA: 0x0009C62A File Offset: 0x0009A82A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateModifyMeshLocation._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateModifyMeshLocation.TsAnimNotifyStateModifyMeshLocation_C");
		}
		return TsAnimNotifyStateModifyMeshLocation._ClassPtr;
	}

	// Token: 0x06004914 RID: 18708 RVA: 0x0009C650 File Offset: 0x0009A850
	public TsAnimNotifyStateModifyMeshLocation() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateModifyMeshLocation.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004915 RID: 18709 RVA: 0x0009C678 File Offset: 0x0009A878
	[NullableContext(1)]
	public TsAnimNotifyStateModifyMeshLocation(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateModifyMeshLocation.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004916 RID: 18710 RVA: 0x0009C6AB File Offset: 0x0009A8AB
	protected TsAnimNotifyStateModifyMeshLocation(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004917 RID: 18711 RVA: 0x0009C6B4 File Offset: 0x0009A8B4
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004918 RID: 18712 RVA: 0x0009C6F0 File Offset: 0x0009A8F0
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004919 RID: 18713 RVA: 0x0009C723 File Offset: 0x0009A923
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001475 RID: 5237
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateModifyMeshLocation.TsAnimNotifyStateModifyMeshLocation_C";

	// Token: 0x04001476 RID: 5238
	private static IntPtr _ClassPtr;

	// Token: 0x04001477 RID: 5239
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001478 RID: 5240
	private static int __PropertyOffset_RelativeLocation;
}
