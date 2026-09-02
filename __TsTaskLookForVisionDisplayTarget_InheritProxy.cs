using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003633 RID: 13875
public class __TsTaskLookForVisionDisplayTarget_InheritProxy : TsTaskLookForVisionDisplayTarget
{
	// Token: 0x0601CDEA RID: 118250 RVA: 0x008B6CEC File Offset: 0x008B4EEC
	[NullableContext(1)]
	public __TsTaskLookForVisionDisplayTarget_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskLookForVisionDisplayTarget.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CDEB RID: 118251 RVA: 0x008B6D1F File Offset: 0x008B4F1F
	protected __TsTaskLookForVisionDisplayTarget_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601CDEC RID: 118252 RVA: 0x008B6D28 File Offset: 0x008B4F28
	protected unsafe override void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		base.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}
}
