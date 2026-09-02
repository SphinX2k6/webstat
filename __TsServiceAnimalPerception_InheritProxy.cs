using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003593 RID: 13715
public class __TsServiceAnimalPerception_InheritProxy : TsServiceAnimalPerception
{
	// Token: 0x0601CC1F RID: 117791 RVA: 0x008B2B1C File Offset: 0x008B0D1C
	[NullableContext(1)]
	public __TsServiceAnimalPerception_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsServiceAnimalPerception.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CC20 RID: 117792 RVA: 0x008B2B4F File Offset: 0x008B0D4F
	protected __TsServiceAnimalPerception_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601CC21 RID: 117793 RVA: 0x008B2B58 File Offset: 0x008B0D58
	protected unsafe override void __CPPCALL_ReceiveActivationAI_Implementation(UBTService_BlueprintBase.__ReceiveActivationAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		base.ReceiveActivationAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0601CC22 RID: 117794 RVA: 0x008B2B88 File Offset: 0x008B0D88
	protected unsafe override void __CPPCALL_ReceiveTickAI_Implementation(UBTService_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		base.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}
}
