using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003887 RID: 14471
public class __AnimNotifyWuWaGoAttackHit_InheritProxy : AnimNotifyWuWaGoAttackHit
{
	// Token: 0x0601D610 RID: 120336 RVA: 0x008CA508 File Offset: 0x008C8708
	[NullableContext(1)]
	public __AnimNotifyWuWaGoAttackHit_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(AnimNotifyWuWaGoAttackHit.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D611 RID: 120337 RVA: 0x008CA53B File Offset: 0x008C873B
	protected __AnimNotifyWuWaGoAttackHit_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D612 RID: 120338 RVA: 0x008CA544 File Offset: 0x008C8744
	protected unsafe override void __CPPCALL_K2_Notify_Implementation(UKuroAnimNotify.__K2_Notify_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = base.K2_Notify_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}
}
