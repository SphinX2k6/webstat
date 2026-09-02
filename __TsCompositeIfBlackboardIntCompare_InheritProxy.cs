using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003511 RID: 13585
public class __TsCompositeIfBlackboardIntCompare_InheritProxy : TsCompositeIfBlackboardIntCompare
{
	// Token: 0x0601CAD8 RID: 117464 RVA: 0x008AFF04 File Offset: 0x008AE104
	[NullableContext(1)]
	public __TsCompositeIfBlackboardIntCompare_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsCompositeIfBlackboardIntCompare.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CAD9 RID: 117465 RVA: 0x008AFF37 File Offset: 0x008AE137
	protected __TsCompositeIfBlackboardIntCompare_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601CADA RID: 117466 RVA: 0x008AFF40 File Offset: 0x008AE140
	protected unsafe override void __CPPCALL_PerformConditionCheckAI_Implementation(UBTComposite_If.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = base.PerformConditionCheckAI(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}
}
