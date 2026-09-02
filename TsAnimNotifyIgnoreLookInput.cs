using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DD4 RID: 3540
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyIgnoreLookInput.TsAnimNotifyIgnoreLookInput_C")]
public class TsAnimNotifyIgnoreLookInput : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000538 RID: 1336
	// (get) Token: 0x060050F2 RID: 20722 RVA: 0x000BB6BB File Offset: 0x000B98BB
	// (set) Token: 0x060050F3 RID: 20723 RVA: 0x000BB6CB File Offset: 0x000B98CB
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool bIgnoreLookInput
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyIgnoreLookInput.__PropertyOffset_bIgnoreLookInput) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyIgnoreLookInput.__PropertyOffset_bIgnoreLookInput) = (value ? 1 : 0);
		}
	}

	// Token: 0x060050F4 RID: 20724 RVA: 0x000BB6DC File Offset: 0x000B98DC
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

	// Token: 0x060050F5 RID: 20725 RVA: 0x000BB77C File Offset: 0x000B997C
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsCharacterController characterController = Global.CharacterController;
		if (characterController != null && characterController.IsValid() && characterController.IsLookInputIgnored() != this.bIgnoreLookInput)
		{
			characterController.SetIgnoreLookInput(this.bIgnoreLookInput);
		}
		return true;
	}

	// Token: 0x060050F6 RID: 20726 RVA: 0x000BB7B8 File Offset: 0x000B99B8
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

	// Token: 0x060050F7 RID: 20727 RVA: 0x000BB833 File Offset: 0x000B9A33
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "设置禁用镜头输入";
	}

	// Token: 0x060050F8 RID: 20728 RVA: 0x000BB83A File Offset: 0x000B9A3A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyIgnoreLookInput._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyIgnoreLookInput.TsAnimNotifyIgnoreLookInput_C");
		}
		return TsAnimNotifyIgnoreLookInput._ClassPtr;
	}

	// Token: 0x060050F9 RID: 20729 RVA: 0x000BB860 File Offset: 0x000B9A60
	public TsAnimNotifyIgnoreLookInput() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyIgnoreLookInput.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060050FA RID: 20730 RVA: 0x000BB888 File Offset: 0x000B9A88
	[NullableContext(1)]
	public TsAnimNotifyIgnoreLookInput(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyIgnoreLookInput.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060050FB RID: 20731 RVA: 0x000BB8BB File Offset: 0x000B9ABB
	protected TsAnimNotifyIgnoreLookInput(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060050FC RID: 20732 RVA: 0x000BB8C4 File Offset: 0x000B9AC4
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060050FD RID: 20733 RVA: 0x000BB8F7 File Offset: 0x000B9AF7
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040017B6 RID: 6070
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyIgnoreLookInput.TsAnimNotifyIgnoreLookInput_C";

	// Token: 0x040017B7 RID: 6071
	private static IntPtr _ClassPtr;

	// Token: 0x040017B8 RID: 6072
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040017B9 RID: 6073
	private static int __PropertyOffset_bIgnoreLookInput;
}
