using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020035FB RID: 13819
public class __TsTaskBigAnimalEscape_InheritProxy : TsTaskBigAnimalEscape
{
	// Token: 0x0601CD42 RID: 118082 RVA: 0x008B53E0 File Offset: 0x008B35E0
	[NullableContext(1)]
	public __TsTaskBigAnimalEscape_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskBigAnimalEscape.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CD43 RID: 118083 RVA: 0x008B5413 File Offset: 0x008B3613
	protected __TsTaskBigAnimalEscape_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601CD44 RID: 118084 RVA: 0x008B541C File Offset: 0x008B361C
	protected override void __CPPCALL_InitTsVariables_Implementation()
	{
		base.InitTsVariables_Implementation();
	}

	// Token: 0x0601CD45 RID: 118085 RVA: 0x008B5424 File Offset: 0x008B3624
	protected unsafe override void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		base.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0601CD46 RID: 118086 RVA: 0x008B5451 File Offset: 0x008B3651
	protected override void __CPPCALL_InitData_Implementation()
	{
		base.InitData_Implementation();
	}

	// Token: 0x0601CD47 RID: 118087 RVA: 0x008B5459 File Offset: 0x008B3659
	protected override void __CPPCALL_FindMovePath_Implementation()
	{
		base.FindMovePath_Implementation();
	}

	// Token: 0x0601CD48 RID: 118088 RVA: 0x008B5461 File Offset: 0x008B3661
	protected override void __CPPCALL_GenerateFailurePath_Implementation()
	{
		base.GenerateFailurePath_Implementation();
	}

	// Token: 0x0601CD49 RID: 118089 RVA: 0x008B546C File Offset: 0x008B366C
	protected unsafe override void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		base.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}
}
