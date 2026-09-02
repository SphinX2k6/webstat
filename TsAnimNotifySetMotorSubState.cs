using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DEB RID: 3563
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifySetMotorSubState.TsAnimNotifySetMotorSubState_C")]
public class TsAnimNotifySetMotorSubState : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700056A RID: 1386
	// (get) Token: 0x06005234 RID: 21044 RVA: 0x000BFF4B File Offset: 0x000BE14B
	// (set) Token: 0x06005235 RID: 21045 RVA: 0x000BFF5B File Offset: 0x000BE15B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EMotorSubState SubState
	{
		get
		{
			return (EMotorSubState)(*(base.NativePtr + (IntPtr)TsAnimNotifySetMotorSubState.__PropertyOffset_SubState));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifySetMotorSubState.__PropertyOffset_SubState) = (byte)value;
		}
	}

	// Token: 0x06005236 RID: 21046 RVA: 0x000BFF6C File Offset: 0x000BE16C
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

	// Token: 0x06005237 RID: 21047 RVA: 0x000C000C File Offset: 0x000BE20C
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseVehicle tsBaseVehicle = meshComp.GetOwner() as TsBaseVehicle;
		if (tsBaseVehicle != null)
		{
			UKuroVehicleMovementComponent vehicleMovementComponent = tsBaseVehicle.VehicleMovementComponent;
			if (vehicleMovementComponent != null)
			{
				vehicleMovementComponent.SetMotorSubState(this.SubState);
			}
		}
		return true;
	}

	// Token: 0x06005238 RID: 21048 RVA: 0x000C0040 File Offset: 0x000BE240
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

	// Token: 0x06005239 RID: 21049 RVA: 0x000C00BB File Offset: 0x000BE2BB
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "设置摩托移动模式";
	}

	// Token: 0x0600523A RID: 21050 RVA: 0x000C00C2 File Offset: 0x000BE2C2
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifySetMotorSubState._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifySetMotorSubState.TsAnimNotifySetMotorSubState_C");
		}
		return TsAnimNotifySetMotorSubState._ClassPtr;
	}

	// Token: 0x0600523B RID: 21051 RVA: 0x000C00E8 File Offset: 0x000BE2E8
	public TsAnimNotifySetMotorSubState() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifySetMotorSubState.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600523C RID: 21052 RVA: 0x000C0110 File Offset: 0x000BE310
	[NullableContext(1)]
	public TsAnimNotifySetMotorSubState(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifySetMotorSubState.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600523D RID: 21053 RVA: 0x000C0143 File Offset: 0x000BE343
	protected TsAnimNotifySetMotorSubState(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600523E RID: 21054 RVA: 0x000C014C File Offset: 0x000BE34C
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0600523F RID: 21055 RVA: 0x000C017F File Offset: 0x000BE37F
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001833 RID: 6195
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifySetMotorSubState.TsAnimNotifySetMotorSubState_C";

	// Token: 0x04001834 RID: 6196
	private static IntPtr _ClassPtr;

	// Token: 0x04001835 RID: 6197
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001836 RID: 6198
	private static int __PropertyOffset_SubState;
}
