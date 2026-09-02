using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200355F RID: 13663
public class __TsDecoratorCheckMoveStuck_InheritProxy : TsDecoratorCheckMoveStuck
{
	// Token: 0x0601CB9B RID: 117659 RVA: 0x008B1938 File Offset: 0x008AFB38
	[NullableContext(1)]
	public __TsDecoratorCheckMoveStuck_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckMoveStuck.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CB9C RID: 117660 RVA: 0x008B196B File Offset: 0x008AFB6B
	protected __TsDecoratorCheckMoveStuck_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601CB9D RID: 117661 RVA: 0x008B1974 File Offset: 0x008AFB74
	protected unsafe override void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = base.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0601CB9E RID: 117662 RVA: 0x008B19A8 File Offset: 0x008AFBA8
	protected unsafe override void __CPPCALL_ReceiveExecutionFinishAI_Implementation(UBTDecorator_BlueprintBase.__ReceiveExecutionFinishAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		EBTNodeResult nodeResult = __Params->NodeResult;
		base.ReceiveExecutionFinishAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, nodeResult);
	}

	// Token: 0x0601CB9F RID: 117663 RVA: 0x008B19E4 File Offset: 0x008AFBE4
	protected unsafe override void __CPPCALL_ReceiveObserverDeactivatedAI_Implementation(UBTDecorator_BlueprintBase.__ReceiveObserverDeactivatedAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		base.ReceiveObserverDeactivatedAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}
}
