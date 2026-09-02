using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003857 RID: 14423
public class __AnimNotifyDeadEyeModeShowShooter_InheritProxy : AnimNotifyDeadEyeModeShowShooter
{
	// Token: 0x0601D55B RID: 120155 RVA: 0x008C8C9C File Offset: 0x008C6E9C
	[NullableContext(1)]
	public __AnimNotifyDeadEyeModeShowShooter_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(AnimNotifyDeadEyeModeShowShooter.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D55C RID: 120156 RVA: 0x008C8CCF File Offset: 0x008C6ECF
	protected __AnimNotifyDeadEyeModeShowShooter_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D55D RID: 120157 RVA: 0x008C8CD8 File Offset: 0x008C6ED8
	protected unsafe override void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = base.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}
}
