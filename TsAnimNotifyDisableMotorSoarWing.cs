using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DC6 RID: 3526
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyDisableMotorSoarWing.TsAnimNotifyDisableMotorSoarWing_C")]
public class TsAnimNotifyDisableMotorSoarWing : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x06005038 RID: 20536 RVA: 0x000B9010 File Offset: 0x000B7210
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

	// Token: 0x06005039 RID: 20537 RVA: 0x000B90B0 File Offset: 0x000B72B0
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseVehicle))
		{
			return false;
		}
		Entity entityNoBlueprint = (owner as TsBaseVehicle).GetEntityNoBlueprint();
		MotorcycleOutlookComponent motorcycleOutlookComponent = (entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<MotorcycleOutlookComponent>() : null;
		if (motorcycleOutlookComponent == null)
		{
			return false;
		}
		motorcycleOutlookComponent.DisableSoarWing();
		return true;
	}

	// Token: 0x0600503A RID: 20538 RVA: 0x000B90F4 File Offset: 0x000B72F4
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

	// Token: 0x0600503B RID: 20539 RVA: 0x000B916F File Offset: 0x000B736F
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "隐藏摩托翱翔翼";
	}

	// Token: 0x0600503C RID: 20540 RVA: 0x000B9176 File Offset: 0x000B7376
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyDisableMotorSoarWing._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyDisableMotorSoarWing.TsAnimNotifyDisableMotorSoarWing_C");
		}
		return TsAnimNotifyDisableMotorSoarWing._ClassPtr;
	}

	// Token: 0x0600503D RID: 20541 RVA: 0x000B919C File Offset: 0x000B739C
	public TsAnimNotifyDisableMotorSoarWing() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyDisableMotorSoarWing.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600503E RID: 20542 RVA: 0x000B91C4 File Offset: 0x000B73C4
	[NullableContext(1)]
	public TsAnimNotifyDisableMotorSoarWing(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyDisableMotorSoarWing.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600503F RID: 20543 RVA: 0x000B91F7 File Offset: 0x000B73F7
	protected TsAnimNotifyDisableMotorSoarWing(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06005040 RID: 20544 RVA: 0x000B9200 File Offset: 0x000B7400
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06005041 RID: 20545 RVA: 0x000B9233 File Offset: 0x000B7433
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400176F RID: 5999
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyDisableMotorSoarWing.TsAnimNotifyDisableMotorSoarWing_C";

	// Token: 0x04001770 RID: 6000
	private static IntPtr _ClassPtr;

	// Token: 0x04001771 RID: 6001
	private static IntPtr _ClassDefaultObjectPtr;
}
