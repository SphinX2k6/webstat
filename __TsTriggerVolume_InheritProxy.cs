using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038F3 RID: 14579
public class __TsTriggerVolume_InheritProxy : TsTriggerVolume
{
	// Token: 0x0601D747 RID: 120647 RVA: 0x008CD594 File Offset: 0x008CB794
	[NullableContext(1)]
	public __TsTriggerVolume_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTriggerVolume.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D748 RID: 120648 RVA: 0x008CD5C7 File Offset: 0x008CB7C7
	protected __TsTriggerVolume_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D749 RID: 120649 RVA: 0x008CD5D0 File Offset: 0x008CB7D0
	protected override void __CPPCALL_ReceiveBeginPlay_Implementation()
	{
		base.ReceiveBeginPlay_Implementation();
	}

	// Token: 0x0601D74A RID: 120650 RVA: 0x008CD5D8 File Offset: 0x008CB7D8
	protected unsafe override void __CPPCALL_ReceiveEndPlay_Implementation(AActor.__ReceiveEndPlay_FunctionParams* __Params)
	{
		EEndPlayReason endPlayReason = __Params->EndPlayReason;
		base.ReceiveEndPlay_Implementation(endPlayReason);
	}

	// Token: 0x0601D74B RID: 120651 RVA: 0x008CD5F8 File Offset: 0x008CB7F8
	protected unsafe override void __CPPCALL_ReceiveTick_Implementation(AActor.__ReceiveTick_FunctionParams* __Params)
	{
		base.ReceiveTick_Implementation(__Params->DeltaSeconds);
	}

	// Token: 0x0601D74C RID: 120652 RVA: 0x008CD606 File Offset: 0x008CB806
	protected unsafe override void __CPPCALL_AddBuffInner_Implementation(TsTriggerVolume.__AddBuffInner_FunctionParams* __Params)
	{
		base.AddBuffInner_Implementation(__Params->buffId);
	}

	// Token: 0x0601D74D RID: 120653 RVA: 0x008CD614 File Offset: 0x008CB814
	protected override void __CPPCALL_TryReportSelfBuffDamageLog_Implementation()
	{
		base.TryReportSelfBuffDamageLog_Implementation();
	}
}
