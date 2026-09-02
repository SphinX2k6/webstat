using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020035CF RID: 13775
public class __TsTaskFindNearestInteractiveTarget_InheritProxy : TsTaskFindNearestInteractiveTarget
{
	// Token: 0x0601CCC2 RID: 117954 RVA: 0x008B4174 File Offset: 0x008B2374
	[NullableContext(1)]
	public __TsTaskFindNearestInteractiveTarget_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskFindNearestInteractiveTarget.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CCC3 RID: 117955 RVA: 0x008B41A7 File Offset: 0x008B23A7
	protected __TsTaskFindNearestInteractiveTarget_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601CCC4 RID: 117956 RVA: 0x008B41B0 File Offset: 0x008B23B0
	protected unsafe override void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		base.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}
}
