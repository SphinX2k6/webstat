using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003513 RID: 13587
public class __TsDecoratorCheckAnimalMoveRange_InheritProxy : TsDecoratorCheckAnimalMoveRange
{
	// Token: 0x0601CADD RID: 117469 RVA: 0x008AFFB0 File Offset: 0x008AE1B0
	[NullableContext(1)]
	public __TsDecoratorCheckAnimalMoveRange_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckAnimalMoveRange.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CADE RID: 117470 RVA: 0x008AFFE3 File Offset: 0x008AE1E3
	protected __TsDecoratorCheckAnimalMoveRange_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601CADF RID: 117471 RVA: 0x008AFFEC File Offset: 0x008AE1EC
	protected unsafe override void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = base.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}
}
