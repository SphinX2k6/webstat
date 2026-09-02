using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003809 RID: 14345
public class __TsAnimNotifySummonGongduolaSetLocAndRot_InheritProxy : TsAnimNotifySummonGongduolaSetLocAndRot
{
	// Token: 0x0601D436 RID: 119862 RVA: 0x008C5A80 File Offset: 0x008C3C80
	[NullableContext(1)]
	public __TsAnimNotifySummonGongduolaSetLocAndRot_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifySummonGongduolaSetLocAndRot.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D437 RID: 119863 RVA: 0x008C5AB3 File Offset: 0x008C3CB3
	protected __TsAnimNotifySummonGongduolaSetLocAndRot_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D438 RID: 119864 RVA: 0x008C5ABC File Offset: 0x008C3CBC
	protected unsafe override void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = base.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}
}
