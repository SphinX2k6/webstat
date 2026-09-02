using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D79 RID: 3449
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSetCollisionLv.TsAnimNotifyStateSetCollisionLv_C")]
public class TsAnimNotifyStateSetCollisionLv : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000468 RID: 1128
	// (get) Token: 0x06004B58 RID: 19288 RVA: 0x000A66D7 File Offset: 0x000A48D7
	// (set) Token: 0x06004B59 RID: 19289 RVA: 0x000A66E7 File Offset: 0x000A48E7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int HitPriority
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateSetCollisionLv.__PropertyOffset_HitPriority);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateSetCollisionLv.__PropertyOffset_HitPriority) = value;
		}
	}

	// Token: 0x06004B5A RID: 19290 RVA: 0x000A66F8 File Offset: 0x000A48F8
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

	// Token: 0x06004B5B RID: 19291 RVA: 0x000A67A0 File Offset: 0x000A49A0
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		if (owner is TsBaseCharacter)
		{
			(owner as TsBaseCharacter).CharacterMovement.HitPriority = this.HitPriority;
			this.HitPriority = 0;
			return true;
		}
		return false;
	}

	// Token: 0x06004B5C RID: 19292 RVA: 0x000A67DC File Offset: 0x000A49DC
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

	// Token: 0x06004B5D RID: 19293 RVA: 0x000A687C File Offset: 0x000A4A7C
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (owner is TsBaseCharacter)
		{
			(owner as TsBaseCharacter).CharacterMovement.HitPriority = this.HitPriority;
			return true;
		}
		return false;
	}

	// Token: 0x06004B5E RID: 19294 RVA: 0x000A68B1 File Offset: 0x000A4AB1
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateSetCollisionLv._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSetCollisionLv.TsAnimNotifyStateSetCollisionLv_C");
		}
		return TsAnimNotifyStateSetCollisionLv._ClassPtr;
	}

	// Token: 0x06004B5F RID: 19295 RVA: 0x000A68D8 File Offset: 0x000A4AD8
	public TsAnimNotifyStateSetCollisionLv() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateSetCollisionLv.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004B60 RID: 19296 RVA: 0x000A6900 File Offset: 0x000A4B00
	[NullableContext(1)]
	public TsAnimNotifyStateSetCollisionLv(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateSetCollisionLv.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004B61 RID: 19297 RVA: 0x000A6933 File Offset: 0x000A4B33
	protected TsAnimNotifyStateSetCollisionLv(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004B62 RID: 19298 RVA: 0x000A693C File Offset: 0x000A4B3C
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004B63 RID: 19299 RVA: 0x000A6978 File Offset: 0x000A4B78
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04001586 RID: 5510
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSetCollisionLv.TsAnimNotifyStateSetCollisionLv_C";

	// Token: 0x04001587 RID: 5511
	private static IntPtr _ClassPtr;

	// Token: 0x04001588 RID: 5512
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001589 RID: 5513
	private static int __PropertyOffset_HitPriority;
}
