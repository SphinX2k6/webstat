using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038FD RID: 14589
public class __TsBpFxEffect_InheritProxy : TsBpFxEffect
{
	// Token: 0x0601D76B RID: 120683 RVA: 0x008CDB34 File Offset: 0x008CBD34
	[NullableContext(1)]
	public __TsBpFxEffect_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsBpFxEffect.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D76C RID: 120684 RVA: 0x008CDB67 File Offset: 0x008CBD67
	protected __TsBpFxEffect_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D76D RID: 120685 RVA: 0x008CDB70 File Offset: 0x008CBD70
	protected override void __CPPCALL_ReceiveBeginPlay_Implementation()
	{
		base.ReceiveBeginPlay_Implementation();
	}

	// Token: 0x0601D76E RID: 120686 RVA: 0x008CDB78 File Offset: 0x008CBD78
	protected unsafe override void __CPPCALL_ReceiveEndPlay_Implementation(TsBpFxEffect.__ReceiveEndPlay_FunctionParams* __Params)
	{
		base.ReceiveEndPlay_Implementation(__Params->endPlayReason);
	}

	// Token: 0x0601D76F RID: 120687 RVA: 0x008CDB86 File Offset: 0x008CBD86
	protected override void __CPPCALL_TryRecord_Implementation()
	{
		base.TryRecord_Implementation();
	}

	// Token: 0x0601D770 RID: 120688 RVA: 0x008CDB8E File Offset: 0x008CBD8E
	protected unsafe override void __CPPCALL_AddAutoFloatTrack_Implementation(TsBpFxEffect.__AddAutoFloatTrack_FunctionParams* __Params)
	{
		base.AddAutoFloatTrack_Implementation(__Params->propertyName);
	}

	// Token: 0x0601D771 RID: 120689 RVA: 0x008CDB9C File Offset: 0x008CBD9C
	protected unsafe override void __CPPCALL_AddAutoVectorTrack_Implementation(TsBpFxEffect.__AddAutoVectorTrack_FunctionParams* __Params)
	{
		base.AddAutoVectorTrack_Implementation(__Params->propertyName);
	}

	// Token: 0x0601D772 RID: 120690 RVA: 0x008CDBAA File Offset: 0x008CBDAA
	protected unsafe override void __CPPCALL_AddAutoObjectTrack_Implementation(TsBpFxEffect.__AddAutoObjectTrack_FunctionParams* __Params)
	{
		base.AddAutoObjectTrack_Implementation(__Params->propertyName);
	}

	// Token: 0x0601D773 RID: 120691 RVA: 0x008CDBB8 File Offset: 0x008CBDB8
	protected override void __CPPCALL_OnRecordStart_Implementation()
	{
		base.OnRecordStart_Implementation();
	}

	// Token: 0x0601D774 RID: 120692 RVA: 0x008CDBC0 File Offset: 0x008CBDC0
	protected unsafe override void __CPPCALL_OnRecordTick_Implementation(TsBpFxEffect.__OnRecordTick_FunctionParams* __Params)
	{
		base.OnRecordTick_Implementation(__Params->deltaSeconds);
	}

	// Token: 0x0601D775 RID: 120693 RVA: 0x008CDBCE File Offset: 0x008CBDCE
	protected override void __CPPCALL_OnRecordStop_Implementation()
	{
		base.OnRecordStop_Implementation();
	}
}
