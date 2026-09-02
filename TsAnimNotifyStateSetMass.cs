using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D7D RID: 3453
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSetMass.TsAnimNotifyStateSetMass_C")]
public class TsAnimNotifyStateSetMass : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000470 RID: 1136
	// (get) Token: 0x06004B9C RID: 19356 RVA: 0x000A76E7 File Offset: 0x000A58E7
	// (set) Token: 0x06004B9D RID: 19357 RVA: 0x000A76F7 File Offset: 0x000A58F7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float NewMass
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateSetMass.__PropertyOffset_NewMass);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateSetMass.__PropertyOffset_NewMass) = value;
		}
	}

	// Token: 0x17000471 RID: 1137
	// (get) Token: 0x06004B9E RID: 19358 RVA: 0x000A7708 File Offset: 0x000A5908
	// (set) Token: 0x06004B9F RID: 19359 RVA: 0x000A7710 File Offset: 0x000A5910
	private float OldMass { get; set; }

	// Token: 0x06004BA0 RID: 19360 RVA: 0x000A771C File Offset: 0x000A591C
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

	// Token: 0x06004BA1 RID: 19361 RVA: 0x000A77C4 File Offset: 0x000A59C4
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		if (owner is TsBaseCharacter)
		{
			this.OldMass = (owner as TsBaseCharacter).CharacterMovement.Mass;
			(owner as TsBaseCharacter).CharacterMovement.Mass = this.NewMass;
			return true;
		}
		return false;
	}

	// Token: 0x06004BA2 RID: 19362 RVA: 0x000A7810 File Offset: 0x000A5A10
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

	// Token: 0x06004BA3 RID: 19363 RVA: 0x000A78B0 File Offset: 0x000A5AB0
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (owner is TsBaseCharacter)
		{
			(owner as TsBaseCharacter).CharacterMovement.Mass = this.OldMass;
			return true;
		}
		return false;
	}

	// Token: 0x06004BA4 RID: 19364 RVA: 0x000A78E8 File Offset: 0x000A5AE8
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

	// Token: 0x06004BA5 RID: 19365 RVA: 0x000A7963 File Offset: 0x000A5B63
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "设置质量";
	}

	// Token: 0x06004BA6 RID: 19366 RVA: 0x000A796A File Offset: 0x000A5B6A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateSetMass._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSetMass.TsAnimNotifyStateSetMass_C");
		}
		return TsAnimNotifyStateSetMass._ClassPtr;
	}

	// Token: 0x06004BA7 RID: 19367 RVA: 0x000A7990 File Offset: 0x000A5B90
	public TsAnimNotifyStateSetMass() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateSetMass.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004BA8 RID: 19368 RVA: 0x000A79B8 File Offset: 0x000A5BB8
	[NullableContext(1)]
	public TsAnimNotifyStateSetMass(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateSetMass.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004BA9 RID: 19369 RVA: 0x000A79EB File Offset: 0x000A5BEB
	protected TsAnimNotifyStateSetMass(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004BAA RID: 19370 RVA: 0x000A79F4 File Offset: 0x000A5BF4
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004BAB RID: 19371 RVA: 0x000A7A30 File Offset: 0x000A5C30
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004BAC RID: 19372 RVA: 0x000A7A63 File Offset: 0x000A5C63
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400159E RID: 5534
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSetMass.TsAnimNotifyStateSetMass_C";

	// Token: 0x0400159F RID: 5535
	private static IntPtr _ClassPtr;

	// Token: 0x040015A0 RID: 5536
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040015A1 RID: 5537
	private static int __PropertyOffset_NewMass;
}
