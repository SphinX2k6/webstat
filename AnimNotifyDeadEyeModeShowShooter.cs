using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02001B1C RID: 6940
[UClass("/Game/Aki/TypeScript/Game/Module/DeadEyeMode/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Module/DeadEyeMode/AnimNotifyDeadEyeModeShowShooter.AnimNotifyDeadEyeModeShowShooter_C")]
public class AnimNotifyDeadEyeModeShowShooter : UKuroAnimNotify, IUnrealUObject, IUnrealObject
{
	// Token: 0x0600C7ED RID: 51181 RVA: 0x0034E850 File Offset: 0x0034CA50
	[NullableContext(1)]
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

	// Token: 0x0600C7EE RID: 51182 RVA: 0x0034E8F0 File Offset: 0x0034CAF0
	[NullableContext(1)]
	protected virtual bool K2_Notify_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		if (!meshComp.IsVisible())
		{
			return false;
		}
		TsBaseVehicle tsBaseVehicle = meshComp.GetOwner() as TsBaseVehicle;
		if (tsBaseVehicle != null)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnDeadEyeModeShowShooter, tsBaseVehicle.EntityId);
		}
		return true;
	}

	// Token: 0x0600C7EF RID: 51183 RVA: 0x0034E92D File Offset: 0x0034CB2D
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (AnimNotifyDeadEyeModeShowShooter._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Module/DeadEyeMode/AnimNotifyDeadEyeModeShowShooter.AnimNotifyDeadEyeModeShowShooter_C");
		}
		return AnimNotifyDeadEyeModeShowShooter._ClassPtr;
	}

	// Token: 0x0600C7F0 RID: 51184 RVA: 0x0034E954 File Offset: 0x0034CB54
	public AnimNotifyDeadEyeModeShowShooter() : this(BuiltinUtils.AllocNativeUObject(AnimNotifyDeadEyeModeShowShooter.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600C7F1 RID: 51185 RVA: 0x0034E97C File Offset: 0x0034CB7C
	[NullableContext(1)]
	public AnimNotifyDeadEyeModeShowShooter(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(AnimNotifyDeadEyeModeShowShooter.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600C7F2 RID: 51186 RVA: 0x0034E9AF File Offset: 0x0034CBAF
	protected AnimNotifyDeadEyeModeShowShooter(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600C7F3 RID: 51187 RVA: 0x0034E9B8 File Offset: 0x0034CBB8
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04005FDC RID: 24540
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Module/DeadEyeMode/AnimNotifyDeadEyeModeShowShooter.AnimNotifyDeadEyeModeShowShooter_C";

	// Token: 0x04005FDD RID: 24541
	private static IntPtr _ClassPtr;

	// Token: 0x04005FDE RID: 24542
	private static IntPtr _ClassDefaultObjectPtr;
}
