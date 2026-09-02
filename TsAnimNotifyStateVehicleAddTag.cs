using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D98 RID: 3480
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateVehicleAddTag.TsAnimNotifyStateVehicleAddTag_C")]
public class TsAnimNotifyStateVehicleAddTag : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170004AF RID: 1199
	// (get) Token: 0x06004D63 RID: 19811 RVA: 0x000AE6D3 File Offset: 0x000AC8D3
	// (set) Token: 0x06004D64 RID: 19812 RVA: 0x000AE6E7 File Offset: 0x000AC8E7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FGameplayTag Tag
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateVehicleAddTag.__PropertyOffset_Tag);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateVehicleAddTag.__PropertyOffset_Tag) = value;
		}
	}

	// Token: 0x170004B0 RID: 1200
	// (get) Token: 0x06004D65 RID: 19813 RVA: 0x000AE6FC File Offset: 0x000AC8FC
	// (set) Token: 0x06004D66 RID: 19814 RVA: 0x000AE70C File Offset: 0x000AC90C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool AddToVehicle
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateVehicleAddTag.__PropertyOffset_AddToVehicle) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateVehicleAddTag.__PropertyOffset_AddToVehicle) = (value ? 1 : 0);
		}
	}

	// Token: 0x170004B1 RID: 1201
	// (get) Token: 0x06004D67 RID: 19815 RVA: 0x000AE71D File Offset: 0x000AC91D
	// (set) Token: 0x06004D68 RID: 19816 RVA: 0x000AE72D File Offset: 0x000AC92D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool AddToDriver
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateVehicleAddTag.__PropertyOffset_AddToDriver) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateVehicleAddTag.__PropertyOffset_AddToDriver) = (value ? 1 : 0);
		}
	}

	// Token: 0x170004B2 RID: 1202
	// (get) Token: 0x06004D69 RID: 19817 RVA: 0x000AE73E File Offset: 0x000AC93E
	// (set) Token: 0x06004D6A RID: 19818 RVA: 0x000AE74E File Offset: 0x000AC94E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool AddToPassengerExceptDriver
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateVehicleAddTag.__PropertyOffset_AddToPassengerExceptDriver) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateVehicleAddTag.__PropertyOffset_AddToPassengerExceptDriver) = (value ? 1 : 0);
		}
	}

	// Token: 0x06004D6B RID: 19819 RVA: 0x000AE760 File Offset: 0x000AC960
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

	// Token: 0x06004D6C RID: 19820 RVA: 0x000AE808 File Offset: 0x000ACA08
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		int tagId = this.Tag.TagId();
		if (!(owner is TsBaseVehicle))
		{
			return false;
		}
		VehicleActorComponent vehicleActorComponent = (owner as TsBaseVehicle).VehicleActorComponent;
		Entity entity = (vehicleActorComponent != null) ? vehicleActorComponent.Entity : null;
		VehicleTagComponent vehicleTagComponent = (entity != null) ? entity.GetComponent<VehicleTagComponent>() : null;
		if (entity == null || vehicleTagComponent == null)
		{
			return false;
		}
		if (this.AddToVehicle)
		{
			vehicleTagComponent.TagContainer.AddExactTag(ETagChannel.Anim, tagId);
		}
		BaseVehiclePerformComponent component = entity.GetComponent<BaseVehiclePerformComponent>();
		if (this.AddToDriver && component.Driver != null)
		{
			vehicleTagComponent.AddTagForPassenger(component.Driver, ETagChannel.Anim, tagId);
		}
		if (this.AddToPassengerExceptDriver)
		{
			foreach (VehiclePassengerInfo vehiclePassengerInfo in component.PassengerInfoMap.Values)
			{
				if (!vehiclePassengerInfo.IsDriver && vehiclePassengerInfo.PassengerEntity != null)
				{
					vehicleTagComponent.AddTagForPassenger(vehiclePassengerInfo.PassengerEntity, ETagChannel.Anim, tagId);
				}
			}
		}
		return true;
	}

	// Token: 0x06004D6D RID: 19821 RVA: 0x000AE910 File Offset: 0x000ACB10
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

	// Token: 0x06004D6E RID: 19822 RVA: 0x000AE9B0 File Offset: 0x000ACBB0
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AActor owner = meshComp.GetOwner();
		int tagId = this.Tag.TagId();
		if (!(owner is TsBaseVehicle))
		{
			return false;
		}
		VehicleActorComponent vehicleActorComponent = (owner as TsBaseVehicle).VehicleActorComponent;
		Entity entity = (vehicleActorComponent != null) ? vehicleActorComponent.Entity : null;
		VehicleTagComponent vehicleTagComponent = (entity != null) ? entity.GetComponent<VehicleTagComponent>() : null;
		if (entity == null || vehicleTagComponent == null)
		{
			return false;
		}
		if (this.AddToVehicle)
		{
			BaseTagComponent baseTagComponent = (entity != null) ? entity.GetComponent<BaseTagComponent>() : null;
			if (baseTagComponent != null)
			{
				baseTagComponent.TagContainer.RemoveExactTag(ETagChannel.Anim, tagId);
			}
		}
		BaseVehiclePerformComponent component = entity.GetComponent<BaseVehiclePerformComponent>();
		if (this.AddToDriver && component.Driver != null)
		{
			vehicleTagComponent.RemoveTagForPassenger(component.Driver, ETagChannel.Anim, tagId);
		}
		if (this.AddToPassengerExceptDriver)
		{
			foreach (VehiclePassengerInfo vehiclePassengerInfo in component.PassengerInfoMap.Values)
			{
				if (!vehiclePassengerInfo.IsDriver && vehiclePassengerInfo.PassengerEntity != null)
				{
					vehicleTagComponent.RemoveTagForPassenger(vehiclePassengerInfo.PassengerEntity, ETagChannel.Anim, tagId);
				}
			}
		}
		return true;
	}

	// Token: 0x06004D6F RID: 19823 RVA: 0x000AEAC8 File Offset: 0x000ACCC8
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

	// Token: 0x06004D70 RID: 19824 RVA: 0x000AEB43 File Offset: 0x000ACD43
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "载具添加TAG";
	}

	// Token: 0x06004D71 RID: 19825 RVA: 0x000AEB4A File Offset: 0x000ACD4A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateVehicleAddTag._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateVehicleAddTag.TsAnimNotifyStateVehicleAddTag_C");
		}
		return TsAnimNotifyStateVehicleAddTag._ClassPtr;
	}

	// Token: 0x06004D72 RID: 19826 RVA: 0x000AEB70 File Offset: 0x000ACD70
	public TsAnimNotifyStateVehicleAddTag() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateVehicleAddTag.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004D73 RID: 19827 RVA: 0x000AEB98 File Offset: 0x000ACD98
	[NullableContext(1)]
	public TsAnimNotifyStateVehicleAddTag(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateVehicleAddTag.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004D74 RID: 19828 RVA: 0x000AEBCB File Offset: 0x000ACDCB
	protected TsAnimNotifyStateVehicleAddTag(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004D75 RID: 19829 RVA: 0x000AEBD4 File Offset: 0x000ACDD4
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004D76 RID: 19830 RVA: 0x000AEC10 File Offset: 0x000ACE10
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004D77 RID: 19831 RVA: 0x000AEC43 File Offset: 0x000ACE43
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400164B RID: 5707
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateVehicleAddTag.TsAnimNotifyStateVehicleAddTag_C";

	// Token: 0x0400164C RID: 5708
	private static IntPtr _ClassPtr;

	// Token: 0x0400164D RID: 5709
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400164E RID: 5710
	private static int __PropertyOffset_Tag;

	// Token: 0x0400164F RID: 5711
	private static int __PropertyOffset_AddToVehicle;

	// Token: 0x04001650 RID: 5712
	private static int __PropertyOffset_AddToDriver;

	// Token: 0x04001651 RID: 5713
	private static int __PropertyOffset_AddToPassengerExceptDriver;
}
