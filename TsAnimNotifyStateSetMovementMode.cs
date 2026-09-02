using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D7E RID: 3454
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSetMovementMode.TsAnimNotifyStateSetMovementMode_C")]
public class TsAnimNotifyStateSetMovementMode : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000472 RID: 1138
	// (get) Token: 0x06004BAD RID: 19373 RVA: 0x000A7A77 File Offset: 0x000A5C77
	// (set) Token: 0x06004BAE RID: 19374 RVA: 0x000A7A8B File Offset: 0x000A5C8B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe TEnumAsByte<EMovementMode> EnterMode
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateSetMovementMode.__PropertyOffset_EnterMode);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateSetMovementMode.__PropertyOffset_EnterMode) = value;
		}
	}

	// Token: 0x17000473 RID: 1139
	// (get) Token: 0x06004BAF RID: 19375 RVA: 0x000A7AA0 File Offset: 0x000A5CA0
	// (set) Token: 0x06004BB0 RID: 19376 RVA: 0x000A7AB0 File Offset: 0x000A5CB0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float EnterCustomMode
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateSetMovementMode.__PropertyOffset_EnterCustomMode);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateSetMovementMode.__PropertyOffset_EnterCustomMode) = value;
		}
	}

	// Token: 0x17000474 RID: 1140
	// (get) Token: 0x06004BB1 RID: 19377 RVA: 0x000A7AC1 File Offset: 0x000A5CC1
	// (set) Token: 0x06004BB2 RID: 19378 RVA: 0x000A7AD5 File Offset: 0x000A5CD5
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe TEnumAsByte<EMovementMode> LeaveMode
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateSetMovementMode.__PropertyOffset_LeaveMode);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateSetMovementMode.__PropertyOffset_LeaveMode) = value;
		}
	}

	// Token: 0x17000475 RID: 1141
	// (get) Token: 0x06004BB3 RID: 19379 RVA: 0x000A7AEA File Offset: 0x000A5CEA
	// (set) Token: 0x06004BB4 RID: 19380 RVA: 0x000A7AFA File Offset: 0x000A5CFA
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int LeaveCustomMode
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateSetMovementMode.__PropertyOffset_LeaveCustomMode);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateSetMovementMode.__PropertyOffset_LeaveCustomMode) = value;
		}
	}

	// Token: 0x06004BB5 RID: 19381 RVA: 0x000A7B0C File Offset: 0x000A5D0C
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

	// Token: 0x06004BB6 RID: 19382 RVA: 0x000A7BB4 File Offset: 0x000A5DB4
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		ACharacter acharacter = meshComp.GetOwner() as ACharacter;
		if (acharacter == null)
		{
			return false;
		}
		acharacter.CharacterMovement.SetMovementMode(this.EnterMode, (byte)this.EnterCustomMode);
		return true;
	}

	// Token: 0x06004BB7 RID: 19383 RVA: 0x000A7BF0 File Offset: 0x000A5DF0
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

	// Token: 0x06004BB8 RID: 19384 RVA: 0x000A7C90 File Offset: 0x000A5E90
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		ACharacter acharacter = meshComp.GetOwner() as ACharacter;
		if (acharacter == null)
		{
			return false;
		}
		if (acharacter.CharacterMovement.MovementMode != this.EnterMode || (this.EnterMode == EMovementMode.MOVE_Custom && (int)acharacter.CharacterMovement.CustomMovementMode != this.LeaveCustomMode))
		{
			return false;
		}
		acharacter.CharacterMovement.SetMovementMode(this.LeaveMode, (byte)this.LeaveCustomMode);
		return true;
	}

	// Token: 0x06004BB9 RID: 19385 RVA: 0x000A7D0C File Offset: 0x000A5F0C
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

	// Token: 0x06004BBA RID: 19386 RVA: 0x000A7D87 File Offset: 0x000A5F87
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "设置移动模式";
	}

	// Token: 0x06004BBB RID: 19387 RVA: 0x000A7D8E File Offset: 0x000A5F8E
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateSetMovementMode._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSetMovementMode.TsAnimNotifyStateSetMovementMode_C");
		}
		return TsAnimNotifyStateSetMovementMode._ClassPtr;
	}

	// Token: 0x06004BBC RID: 19388 RVA: 0x000A7DB4 File Offset: 0x000A5FB4
	public TsAnimNotifyStateSetMovementMode() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateSetMovementMode.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004BBD RID: 19389 RVA: 0x000A7DDC File Offset: 0x000A5FDC
	[NullableContext(1)]
	public TsAnimNotifyStateSetMovementMode(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateSetMovementMode.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004BBE RID: 19390 RVA: 0x000A7E0F File Offset: 0x000A600F
	protected TsAnimNotifyStateSetMovementMode(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004BBF RID: 19391 RVA: 0x000A7E18 File Offset: 0x000A6018
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004BC0 RID: 19392 RVA: 0x000A7E54 File Offset: 0x000A6054
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004BC1 RID: 19393 RVA: 0x000A7E87 File Offset: 0x000A6087
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040015A2 RID: 5538
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateSetMovementMode.TsAnimNotifyStateSetMovementMode_C";

	// Token: 0x040015A3 RID: 5539
	private static IntPtr _ClassPtr;

	// Token: 0x040015A4 RID: 5540
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040015A5 RID: 5541
	private static int __PropertyOffset_EnterMode;

	// Token: 0x040015A6 RID: 5542
	private static int __PropertyOffset_EnterCustomMode;

	// Token: 0x040015A7 RID: 5543
	private static int __PropertyOffset_LeaveMode;

	// Token: 0x040015A8 RID: 5544
	private static int __PropertyOffset_LeaveCustomMode;
}
