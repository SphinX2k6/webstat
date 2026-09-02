using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DD8 RID: 3544
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyLeaveVehicle.TsAnimNotifyLeaveVehicle_C")]
public class TsAnimNotifyLeaveVehicle : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700053D RID: 1341
	// (get) Token: 0x06005120 RID: 20768 RVA: 0x000BC3B3 File Offset: 0x000BA5B3
	// (set) Token: 0x06005121 RID: 20769 RVA: 0x000BC3C3 File Offset: 0x000BA5C3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int ExitType
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyLeaveVehicle.__PropertyOffset_ExitType);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyLeaveVehicle.__PropertyOffset_ExitType) = value;
		}
	}

	// Token: 0x06005122 RID: 20770 RVA: 0x000BC3D4 File Offset: 0x000BA5D4
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

	// Token: 0x06005123 RID: 20771 RVA: 0x000BC474 File Offset: 0x000BA674
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseVehicle))
		{
			return true;
		}
		Entity entityNoBlueprint = (owner as TsBaseVehicle).GetEntityNoBlueprint();
		BaseVehiclePerformComponent baseVehiclePerformComponent = (entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<BaseVehiclePerformComponent>() : null;
		if (((baseVehiclePerformComponent != null) ? baseVehiclePerformComponent.Driver : null) != null)
		{
			BaseActorComponent component = baseVehiclePerformComponent.Driver.GetComponent<BaseActorComponent>();
			bool flag = component != null && component.IsMoveAutonomousProxy;
			baseVehiclePerformComponent.TryLeaveAtOnce(baseVehiclePerformComponent.Driver, (this.ExitType != 0) ? ELeaveVehicleType.StandUp : ELeaveVehicleType.Launch, "TsAnimNotifyLeaveVehicle", !flag);
		}
		return true;
	}

	// Token: 0x06005124 RID: 20772 RVA: 0x000BC4F4 File Offset: 0x000BA6F4
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

	// Token: 0x06005125 RID: 20773 RVA: 0x000BC56F File Offset: 0x000BA76F
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "退出乘坐状态";
	}

	// Token: 0x06005126 RID: 20774 RVA: 0x000BC576 File Offset: 0x000BA776
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyLeaveVehicle._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyLeaveVehicle.TsAnimNotifyLeaveVehicle_C");
		}
		return TsAnimNotifyLeaveVehicle._ClassPtr;
	}

	// Token: 0x06005127 RID: 20775 RVA: 0x000BC59C File Offset: 0x000BA79C
	public TsAnimNotifyLeaveVehicle() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyLeaveVehicle.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06005128 RID: 20776 RVA: 0x000BC5C4 File Offset: 0x000BA7C4
	[NullableContext(1)]
	public TsAnimNotifyLeaveVehicle(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyLeaveVehicle.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06005129 RID: 20777 RVA: 0x000BC5F7 File Offset: 0x000BA7F7
	protected TsAnimNotifyLeaveVehicle(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600512A RID: 20778 RVA: 0x000BC600 File Offset: 0x000BA800
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0600512B RID: 20779 RVA: 0x000BC633 File Offset: 0x000BA833
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x040017C7 RID: 6087
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyLeaveVehicle.TsAnimNotifyLeaveVehicle_C";

	// Token: 0x040017C8 RID: 6088
	private static IntPtr _ClassPtr;

	// Token: 0x040017C9 RID: 6089
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040017CA RID: 6090
	private static int __PropertyOffset_ExitType;
}
