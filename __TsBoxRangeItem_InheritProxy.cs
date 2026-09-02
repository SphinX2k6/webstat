using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038DF RID: 14559
public class __TsBoxRangeItem_InheritProxy : TsBoxRangeItem
{
	// Token: 0x0601D6F3 RID: 120563 RVA: 0x008CC530 File Offset: 0x008CA730
	[NullableContext(1)]
	public __TsBoxRangeItem_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsBoxRangeItem.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D6F4 RID: 120564 RVA: 0x008CC563 File Offset: 0x008CA763
	protected __TsBoxRangeItem_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D6F5 RID: 120565 RVA: 0x008CC56C File Offset: 0x008CA76C
	protected override void __CPPCALL_ReceiveBeginPlay_Implementation()
	{
		base.ReceiveBeginPlay_Implementation();
	}

	// Token: 0x0601D6F6 RID: 120566 RVA: 0x008CC574 File Offset: 0x008CA774
	protected unsafe override void __CPPCALL_ReceiveTick_Implementation(AActor.__ReceiveTick_FunctionParams* __Params)
	{
		base.ReceiveTick_Implementation(__Params->DeltaSeconds);
	}

	// Token: 0x0601D6F7 RID: 120567 RVA: 0x008CC584 File Offset: 0x008CA784
	protected unsafe override void __CPPCALL_ReceiveEndPlay_Implementation(AActor.__ReceiveEndPlay_FunctionParams* __Params)
	{
		EEndPlayReason endPlayReason = __Params->EndPlayReason;
		base.ReceiveEndPlay_Implementation(endPlayReason);
	}
}
