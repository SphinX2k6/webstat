using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200377B RID: 14203
public class __TsAnimNotifyBase_InheritProxy : TsAnimNotifyBase
{
	// Token: 0x0601D28E RID: 119438 RVA: 0x008C2588 File Offset: 0x008C0788
	[NullableContext(1)]
	public __TsAnimNotifyBase_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyBase.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D28F RID: 119439 RVA: 0x008C25BB File Offset: 0x008C07BB
	protected __TsAnimNotifyBase_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D290 RID: 119440 RVA: 0x008C25C4 File Offset: 0x008C07C4
	protected unsafe override void __CPPCALL_K2_NotifyConditionCheck_Implementation(UKuroAnimNotify.__K2_NotifyConditionCheck_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = base.K2_NotifyConditionCheck_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}
}
