using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000DC3 RID: 3523
[UClass("/Game/Aki/TypeScript/Game/AnimNotify/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyDetachFromVehicle.TsAnimNotifyDetachFromVehicle_C")]
public class TsAnimNotifyDetachFromVehicle : TsAnimNotifyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x06005018 RID: 20504 RVA: 0x000B8824 File Offset: 0x000B6A24
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

	// Token: 0x06005019 RID: 20505 RVA: 0x000B88C4 File Offset: 0x000B6AC4
	[NullableContext(2)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = ((meshComp != null) ? meshComp.GetOwner() : null) as TsBaseCharacter;
		if (tsBaseCharacter == null)
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
		if (characterActorComponent == null || !characterActorComponent.Valid)
		{
			return false;
		}
		int? ridingVehicle = ControllerBase<NpcVehicleRiderController>.Instance.GetRidingVehicle(characterActorComponent.Entity.Id);
		if (ridingVehicle == null)
		{
			return false;
		}
		NpcVehiclePerformComponent component = Singleton<EntitySystem>.Instance.GetComponent<NpcVehiclePerformComponent>(ridingVehicle.Value);
		if (component == null || !component.Valid)
		{
			return false;
		}
		BaseTagComponent component2 = Singleton<EntitySystem>.Instance.GetComponent<BaseTagComponent>(characterActorComponent.Entity.Id);
		if (component2 != null && component2.Valid)
		{
			component2.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["角色.Common.载具驾驶.逻辑.强制更新移动"]));
		}
		ControllerBase<NpcVehicleRiderController>.Instance.SetNpcVehicleRideState(characterActorComponent.Entity.Id, ENpcVehicleRideState.WaitingToFinishDismount);
		component.TryLeave(characterActorComponent.Entity, ELeaveVehicleType.StandUp);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.NPC;
		ELogAuthor author = ELogAuthor.LJM;
		string message = "AN提前下载具";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", characterActorComponent.Entity.Id);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return true;
	}

	// Token: 0x0600501A RID: 20506 RVA: 0x000B89E8 File Offset: 0x000B6BE8
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

	// Token: 0x0600501B RID: 20507 RVA: 0x000B8A63 File Offset: 0x000B6C63
	[NullableContext(1)]
	protected override string GetNotifyName_Implementation()
	{
		return "下载具时从载具解绑";
	}

	// Token: 0x0600501C RID: 20508 RVA: 0x000B8A6A File Offset: 0x000B6C6A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyDetachFromVehicle._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyDetachFromVehicle.TsAnimNotifyDetachFromVehicle_C");
		}
		return TsAnimNotifyDetachFromVehicle._ClassPtr;
	}

	// Token: 0x0600501D RID: 20509 RVA: 0x000B8A90 File Offset: 0x000B6C90
	public TsAnimNotifyDetachFromVehicle() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyDetachFromVehicle.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600501E RID: 20510 RVA: 0x000B8AB8 File Offset: 0x000B6CB8
	[NullableContext(1)]
	public TsAnimNotifyDetachFromVehicle(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyDetachFromVehicle.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600501F RID: 20511 RVA: 0x000B8AEB File Offset: 0x000B6CEB
	protected TsAnimNotifyDetachFromVehicle(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06005020 RID: 20512 RVA: 0x000B8AF4 File Offset: 0x000B6CF4
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06005021 RID: 20513 RVA: 0x000B8B27 File Offset: 0x000B6D27
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x04001765 RID: 5989
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotify/TsAnimNotifyDetachFromVehicle.TsAnimNotifyDetachFromVehicle_C";

	// Token: 0x04001766 RID: 5990
	private static IntPtr _ClassPtr;

	// Token: 0x04001767 RID: 5991
	private static IntPtr _ClassDefaultObjectPtr;
}
