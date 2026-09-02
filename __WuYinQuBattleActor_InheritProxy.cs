using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003905 RID: 14597
public class __WuYinQuBattleActor_InheritProxy : WuYinQuBattleActor
{
	// Token: 0x0601D7CE RID: 120782 RVA: 0x008CF080 File Offset: 0x008CD280
	[NullableContext(1)]
	public __WuYinQuBattleActor_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(WuYinQuBattleActor.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D7CF RID: 120783 RVA: 0x008CF0B3 File Offset: 0x008CD2B3
	protected __WuYinQuBattleActor_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D7D0 RID: 120784 RVA: 0x008CF0BC File Offset: 0x008CD2BC
	protected override void __CPPCALL_手动初始化_Implementation()
	{
		base.手动初始化_Implementation();
	}

	// Token: 0x0601D7D1 RID: 120785 RVA: 0x008CF0C4 File Offset: 0x008CD2C4
	protected override void __CPPCALL_显示Debug线框_Implementation()
	{
		base.显示Debug线框_Implementation();
	}

	// Token: 0x0601D7D2 RID: 120786 RVA: 0x008CF0CC File Offset: 0x008CD2CC
	protected override void __CPPCALL_切换到清空状态_Implementation()
	{
		base.切换到清空状态_Implementation();
	}

	// Token: 0x0601D7D3 RID: 120787 RVA: 0x008CF0D4 File Offset: 0x008CD2D4
	protected override void __CPPCALL_切换到静止状态_Implementation()
	{
		base.切换到静止状态_Implementation();
	}

	// Token: 0x0601D7D4 RID: 120788 RVA: 0x008CF0DC File Offset: 0x008CD2DC
	protected override void __CPPCALL_切换到战斗阶段1_Implementation()
	{
		base.切换到战斗阶段1_Implementation();
	}

	// Token: 0x0601D7D5 RID: 120789 RVA: 0x008CF0E4 File Offset: 0x008CD2E4
	protected override void __CPPCALL_切换到战斗阶段2_Implementation()
	{
		base.切换到战斗阶段2_Implementation();
	}

	// Token: 0x0601D7D6 RID: 120790 RVA: 0x008CF0EC File Offset: 0x008CD2EC
	protected override void __CPPCALL_切换到战斗阶段3_Implementation()
	{
		base.切换到战斗阶段3_Implementation();
	}

	// Token: 0x0601D7D7 RID: 120791 RVA: 0x008CF0F4 File Offset: 0x008CD2F4
	protected override void __CPPCALL_ReceiveBeginPlay_Implementation()
	{
		base.ReceiveBeginPlay_Implementation();
	}

	// Token: 0x0601D7D8 RID: 120792 RVA: 0x008CF0FC File Offset: 0x008CD2FC
	protected unsafe override void __CPPCALL_ReceiveEndPlay_Implementation(AActor.__ReceiveEndPlay_FunctionParams* __Params)
	{
		EEndPlayReason endPlayReason = __Params->EndPlayReason;
		base.ReceiveEndPlay_Implementation(endPlayReason);
	}
}
