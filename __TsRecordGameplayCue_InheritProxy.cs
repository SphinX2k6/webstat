using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003901 RID: 14593
public class __TsRecordGameplayCue_InheritProxy : TsRecordGameplayCue
{
	// Token: 0x0601D789 RID: 120713 RVA: 0x008CE07C File Offset: 0x008CC27C
	[NullableContext(1)]
	public __TsRecordGameplayCue_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsRecordGameplayCue.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D78A RID: 120714 RVA: 0x008CE0AF File Offset: 0x008CC2AF
	protected __TsRecordGameplayCue_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D78B RID: 120715 RVA: 0x008CE0B8 File Offset: 0x008CC2B8
	protected override void __CPPCALL_ReceiveBeginPlay_Implementation()
	{
		base.ReceiveBeginPlay_Implementation();
	}

	// Token: 0x0601D78C RID: 120716 RVA: 0x008CE0C0 File Offset: 0x008CC2C0
	protected unsafe override void __CPPCALL_ReceiveEndPlay_Implementation(AActor.__ReceiveEndPlay_FunctionParams* __Params)
	{
		EEndPlayReason endPlayReason = __Params->EndPlayReason;
		base.ReceiveEndPlay_Implementation(endPlayReason);
	}

	// Token: 0x0601D78D RID: 120717 RVA: 0x008CE0E0 File Offset: 0x008CC2E0
	protected override void __CPPCALL_OnPlay_Implementation()
	{
		base.OnPlay_Implementation();
	}

	// Token: 0x0601D78E RID: 120718 RVA: 0x008CE0E8 File Offset: 0x008CC2E8
	protected override void __CPPCALL_OnStop_Implementation()
	{
		base.OnStop_Implementation();
	}

	// Token: 0x0601D78F RID: 120719 RVA: 0x008CE0F0 File Offset: 0x008CC2F0
	protected unsafe override void __CPPCALL_ReceiveTick_Implementation(AActor.__ReceiveTick_FunctionParams* __Params)
	{
		base.ReceiveTick_Implementation(__Params->DeltaSeconds);
	}
}
