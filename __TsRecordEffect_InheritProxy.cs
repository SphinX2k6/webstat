using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038FF RID: 14591
public class __TsRecordEffect_InheritProxy : TsRecordEffect
{
	// Token: 0x0601D780 RID: 120704 RVA: 0x008CDFBC File Offset: 0x008CC1BC
	[NullableContext(1)]
	public __TsRecordEffect_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsRecordEffect.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D781 RID: 120705 RVA: 0x008CDFEF File Offset: 0x008CC1EF
	protected __TsRecordEffect_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D782 RID: 120706 RVA: 0x008CDFF8 File Offset: 0x008CC1F8
	protected override void __CPPCALL_ReceiveBeginPlay_Implementation()
	{
		base.ReceiveBeginPlay_Implementation();
	}

	// Token: 0x0601D783 RID: 120707 RVA: 0x008CE000 File Offset: 0x008CC200
	protected unsafe override void __CPPCALL_ReceiveEndPlay_Implementation(AActor.__ReceiveEndPlay_FunctionParams* __Params)
	{
		EEndPlayReason endPlayReason = __Params->EndPlayReason;
		base.ReceiveEndPlay_Implementation(endPlayReason);
	}

	// Token: 0x0601D784 RID: 120708 RVA: 0x008CE020 File Offset: 0x008CC220
	protected unsafe override void __CPPCALL_ReceiveTick_Implementation(AActor.__ReceiveTick_FunctionParams* __Params)
	{
		base.ReceiveTick_Implementation(__Params->DeltaSeconds);
	}

	// Token: 0x0601D785 RID: 120709 RVA: 0x008CE02E File Offset: 0x008CC22E
	protected override void __CPPCALL_OnPlay_Implementation()
	{
		base.OnPlay_Implementation();
	}

	// Token: 0x0601D786 RID: 120710 RVA: 0x008CE036 File Offset: 0x008CC236
	protected override void __CPPCALL_OnStop_Implementation()
	{
		base.OnStop_Implementation();
	}
}
