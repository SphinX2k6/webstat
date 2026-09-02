using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DCA RID: 3530
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyEnableEntity.TsAnimNotifyEnableEntity_C")]
public class TsAnimNotifyEnableEntity : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000529 RID: 1321
	// (get) Token: 0x0600506C RID: 20588 RVA: 0x000B99AB File Offset: 0x000B7BAB
	// (set) Token: 0x0600506D RID: 20589 RVA: 0x000B99BB File Offset: 0x000B7BBB
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsEnable
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyEnableEntity.__PropertyOffset_IsEnable) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyEnableEntity.__PropertyOffset_IsEnable) = (value ? 1 : 0);
		}
	}

	// Token: 0x0600506E RID: 20590 RVA: 0x000B99CC File Offset: 0x000B7BCC
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_Notify(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_Notify"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotify.__K2_Notify_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotify.__K2_Notify_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotify.__K2_Notify_FunctionParams) & -16L);
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

	// Token: 0x0600506F RID: 20591 RVA: 0x000B9A6B File Offset: 0x000B7C6B
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		return true;
	}

	// Token: 0x06005070 RID: 20592 RVA: 0x000B9A70 File Offset: 0x000B7C70
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

	// Token: 0x06005071 RID: 20593 RVA: 0x000B9AEB File Offset: 0x000B7CEB
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "启用实体";
	}

	// Token: 0x06005072 RID: 20594 RVA: 0x000B9AF2 File Offset: 0x000B7CF2
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyEnableEntity._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyEnableEntity.TsAnimNotifyEnableEntity_C");
		}
		return TsAnimNotifyEnableEntity._ClassPtr;
	}

	// Token: 0x06005073 RID: 20595 RVA: 0x000B9B18 File Offset: 0x000B7D18
	public TsAnimNotifyEnableEntity() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyEnableEntity.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06005074 RID: 20596 RVA: 0x000B9B40 File Offset: 0x000B7D40
	[NullableContext(1)]
	public TsAnimNotifyEnableEntity(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyEnableEntity.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06005075 RID: 20597 RVA: 0x000B9B73 File Offset: 0x000B7D73
	protected TsAnimNotifyEnableEntity(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06005076 RID: 20598 RVA: 0x000B9B7C File Offset: 0x000B7D7C
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06005077 RID: 20599 RVA: 0x000B9BAF File Offset: 0x000B7DAF
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001785 RID: 6021
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyEnableEntity.TsAnimNotifyEnableEntity_C";

	// Token: 0x04001786 RID: 6022
	private static IntPtr _ClassPtr;

	// Token: 0x04001787 RID: 6023
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001788 RID: 6024
	private static int __PropertyOffset_IsEnable;
}
