using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003675 RID: 13941
public class __TsTaskTerritoryWander_InheritProxy : TsTaskTerritoryWander
{
	// Token: 0x0601CE99 RID: 118425 RVA: 0x008B84B4 File Offset: 0x008B66B4
	[NullableContext(1)]
	public __TsTaskTerritoryWander_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskTerritoryWander.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CE9A RID: 118426 RVA: 0x008B84E7 File Offset: 0x008B66E7
	protected __TsTaskTerritoryWander_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601CE9B RID: 118427 RVA: 0x008B84F0 File Offset: 0x008B66F0
	protected unsafe override void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		base.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0601CE9C RID: 118428 RVA: 0x008B8520 File Offset: 0x008B6720
	protected unsafe override void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		base.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x0601CE9D RID: 118429 RVA: 0x008B8553 File Offset: 0x008B6753
	protected override void __CPPCALL_FindWanderLocation_Implementation()
	{
		base.FindWanderLocation_Implementation();
	}

	// Token: 0x0601CE9E RID: 118430 RVA: 0x008B855B File Offset: 0x008B675B
	protected override void __CPPCALL_FindWanderPath_Implementation()
	{
		base.FindWanderPath_Implementation();
	}

	// Token: 0x0601CE9F RID: 118431 RVA: 0x008B8563 File Offset: 0x008B6763
	protected override void __CPPCALL_DebugDraw_Implementation()
	{
		base.DebugDraw_Implementation();
	}
}
