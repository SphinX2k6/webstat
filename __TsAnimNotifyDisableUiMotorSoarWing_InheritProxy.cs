using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020037B9 RID: 14265
public class __TsAnimNotifyDisableUiMotorSoarWing_InheritProxy : TsAnimNotifyDisableUiMotorSoarWing
{
	// Token: 0x0601D347 RID: 119623 RVA: 0x008C3CB4 File Offset: 0x008C1EB4
	[NullableContext(1)]
	public __TsAnimNotifyDisableUiMotorSoarWing_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyDisableUiMotorSoarWing.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D348 RID: 119624 RVA: 0x008C3CE7 File Offset: 0x008C1EE7
	protected __TsAnimNotifyDisableUiMotorSoarWing_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D349 RID: 119625 RVA: 0x008C3CF0 File Offset: 0x008C1EF0
	protected unsafe override void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = base.K2_Notify(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0601D34A RID: 119626 RVA: 0x008C3D23 File Offset: 0x008C1F23
	protected unsafe override void __CPPCALL_GetNotifyName_Implementation(UAnimNotify.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), base.GetNotifyName());
	}
}
