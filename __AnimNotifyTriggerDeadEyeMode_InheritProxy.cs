using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003859 RID: 14425
public class __AnimNotifyTriggerDeadEyeMode_InheritProxy : AnimNotifyTriggerDeadEyeMode
{
	// Token: 0x0601D560 RID: 120160 RVA: 0x008C8D48 File Offset: 0x008C6F48
	[NullableContext(1)]
	public __AnimNotifyTriggerDeadEyeMode_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(AnimNotifyTriggerDeadEyeMode.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D561 RID: 120161 RVA: 0x008C8D7B File Offset: 0x008C6F7B
	protected __AnimNotifyTriggerDeadEyeMode_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D562 RID: 120162 RVA: 0x008C8D84 File Offset: 0x008C6F84
	protected unsafe override void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = base.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}
}
