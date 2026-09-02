using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020035EB RID: 13803
public class __TsTaskAiFindClosetItem_InheritProxy : TsTaskAiFindClosetItem
{
	// Token: 0x0601CD0E RID: 118030 RVA: 0x008B4BE0 File Offset: 0x008B2DE0
	[NullableContext(1)]
	public __TsTaskAiFindClosetItem_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskAiFindClosetItem.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CD0F RID: 118031 RVA: 0x008B4C13 File Offset: 0x008B2E13
	protected __TsTaskAiFindClosetItem_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601CD10 RID: 118032 RVA: 0x008B4C1C File Offset: 0x008B2E1C
	protected override void __CPPCALL_InitTsVariables_Implementation()
	{
		base.InitTsVariables_Implementation();
	}

	// Token: 0x0601CD11 RID: 118033 RVA: 0x008B4C24 File Offset: 0x008B2E24
	protected unsafe override void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		base.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}
}
