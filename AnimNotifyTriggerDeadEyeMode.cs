using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02001B1D RID: 6941
[UClass("/Game/Aki/TypeScript/Game/Module/DeadEyeMode/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Module/DeadEyeMode/AnimNotifyTriggerDeadEyeMode.AnimNotifyTriggerDeadEyeMode_C")]
public class AnimNotifyTriggerDeadEyeMode : UKuroAnimNotify, IUnrealUObject, IUnrealObject
{
	// Token: 0x0600C7F4 RID: 51188 RVA: 0x0034E9EC File Offset: 0x0034CBEC
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

	// Token: 0x0600C7F5 RID: 51189 RVA: 0x0034EA8C File Offset: 0x0034CC8C
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
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnDeadEyeModeTrigger, tsBaseVehicle.EntityId);
		}
		return true;
	}

	// Token: 0x0600C7F6 RID: 51190 RVA: 0x0034EAC9 File Offset: 0x0034CCC9
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (AnimNotifyTriggerDeadEyeMode._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Module/DeadEyeMode/AnimNotifyTriggerDeadEyeMode.AnimNotifyTriggerDeadEyeMode_C");
		}
		return AnimNotifyTriggerDeadEyeMode._ClassPtr;
	}

	// Token: 0x0600C7F7 RID: 51191 RVA: 0x0034EAF0 File Offset: 0x0034CCF0
	public AnimNotifyTriggerDeadEyeMode() : this(BuiltinUtils.AllocNativeUObject(AnimNotifyTriggerDeadEyeMode.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600C7F8 RID: 51192 RVA: 0x0034EB18 File Offset: 0x0034CD18
	[NullableContext(1)]
	public AnimNotifyTriggerDeadEyeMode(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(AnimNotifyTriggerDeadEyeMode.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600C7F9 RID: 51193 RVA: 0x0034EB4B File Offset: 0x0034CD4B
	protected AnimNotifyTriggerDeadEyeMode(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600C7FA RID: 51194 RVA: 0x0034EB54 File Offset: 0x0034CD54
	protected unsafe virtual void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04005FDF RID: 24543
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Module/DeadEyeMode/AnimNotifyTriggerDeadEyeMode.AnimNotifyTriggerDeadEyeMode_C";

	// Token: 0x04005FE0 RID: 24544
	private static IntPtr _ClassPtr;

	// Token: 0x04005FE1 RID: 24545
	private static IntPtr _ClassDefaultObjectPtr;
}
