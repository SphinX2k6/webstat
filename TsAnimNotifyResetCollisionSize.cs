using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DE0 RID: 3552
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyResetCollisionSize.TsAnimNotifyResetCollisionSize_C")]
public class TsAnimNotifyResetCollisionSize : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x06005199 RID: 20889 RVA: 0x000BDBA8 File Offset: 0x000BBDA8
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_Notify(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_Notify"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotify.__K2_Notify_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotify.__K2_Notify_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotify.__K2_Notify_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((MeshComp != null) ? MeshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((Animation != null) ? Animation.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0600519A RID: 20890 RVA: 0x000BDC48 File Offset: 0x000BBE48
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation)
	{
		AActor owner = MeshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		(owner as TsBaseCharacter).CharacterActorComponent.ResetCapsuleRadiusAndHeight(false);
		return true;
	}

	// Token: 0x0600519B RID: 20891 RVA: 0x000BDC78 File Offset: 0x000BBE78
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override string GetNotifyName()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetNotifyName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UAnimNotify.__GetNotifyName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UAnimNotify.__GetNotifyName_FunctionParams*)ptr + 15L / (long)sizeof(UAnimNotify.__GetNotifyName_FunctionParams) & -16L);
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

	// Token: 0x0600519C RID: 20892 RVA: 0x000BDCF3 File Offset: 0x000BBEF3
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "恢复默认碰撞大小";
	}

	// Token: 0x0600519D RID: 20893 RVA: 0x000BDCFA File Offset: 0x000BBEFA
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyResetCollisionSize._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyResetCollisionSize.TsAnimNotifyResetCollisionSize_C");
		}
		return TsAnimNotifyResetCollisionSize._ClassPtr;
	}

	// Token: 0x0600519E RID: 20894 RVA: 0x000BDD20 File Offset: 0x000BBF20
	public TsAnimNotifyResetCollisionSize() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyResetCollisionSize.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600519F RID: 20895 RVA: 0x000BDD48 File Offset: 0x000BBF48
	[NullableContext(1)]
	public TsAnimNotifyResetCollisionSize(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyResetCollisionSize.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060051A0 RID: 20896 RVA: 0x000BDD7B File Offset: 0x000BBF7B
	protected TsAnimNotifyResetCollisionSize(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060051A1 RID: 20897 RVA: 0x000BDD84 File Offset: 0x000BBF84
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060051A2 RID: 20898 RVA: 0x000BDDB7 File Offset: 0x000BBFB7
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040017F4 RID: 6132
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyResetCollisionSize.TsAnimNotifyResetCollisionSize_C";

	// Token: 0x040017F5 RID: 6133
	private static IntPtr _ClassPtr;

	// Token: 0x040017F6 RID: 6134
	private static IntPtr _ClassDefaultObjectPtr;
}
