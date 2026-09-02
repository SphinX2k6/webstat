using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038BB RID: 14523
public class __TsCharacterDebugComponent_InheritProxy : TsCharacterDebugComponent
{
	// Token: 0x0601D679 RID: 120441 RVA: 0x008CB16C File Offset: 0x008C936C
	[NullableContext(1)]
	public __TsCharacterDebugComponent_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsCharacterDebugComponent.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D67A RID: 120442 RVA: 0x008CB19F File Offset: 0x008C939F
	protected __TsCharacterDebugComponent_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D67B RID: 120443 RVA: 0x008CB1A8 File Offset: 0x008C93A8
	protected unsafe override void __CPPCALL_SetMovementDebug_Implementation(TsCharacterDebugComponent.__SetMovementDebug_FunctionParams* __Params)
	{
		base.SetMovementDebug_Implementation(__Params->newDebug);
	}

	// Token: 0x0601D67C RID: 120444 RVA: 0x008CB1B6 File Offset: 0x008C93B6
	protected override void __CPPCALL_ChangeEnterClimbTrace_Implementation()
	{
		base.ChangeEnterClimbTrace_Implementation();
	}

	// Token: 0x0601D67D RID: 120445 RVA: 0x008CB1BE File Offset: 0x008C93BE
	protected override void __CPPCALL_ChangeVaultClimbTrace_Implementation()
	{
		base.ChangeVaultClimbTrace_Implementation();
	}

	// Token: 0x0601D67E RID: 120446 RVA: 0x008CB1C6 File Offset: 0x008C93C6
	protected override void __CPPCALL_ChangeUpArriveClimbTrace_Implementation()
	{
		base.ChangeUpArriveClimbTrace_Implementation();
	}

	// Token: 0x0601D67F RID: 120447 RVA: 0x008CB1CE File Offset: 0x008C93CE
	protected override void __CPPCALL_ChangeClimbingTrace_Implementation()
	{
		base.ChangeClimbingTrace_Implementation();
	}

	// Token: 0x0601D680 RID: 120448 RVA: 0x008CB1D6 File Offset: 0x008C93D6
	protected override void __CPPCALL_ChangeNoTop_Implementation()
	{
		base.ChangeNoTop_Implementation();
	}

	// Token: 0x0601D681 RID: 120449 RVA: 0x008CB1DE File Offset: 0x008C93DE
	protected override void __CPPCALL_ReceiveBeginPlay_Implementation()
	{
		base.ReceiveBeginPlay_Implementation();
	}

	// Token: 0x0601D682 RID: 120450 RVA: 0x008CB1E6 File Offset: 0x008C93E6
	protected unsafe override void __CPPCALL_ReceiveTick_Implementation(UActorComponent.__ReceiveTick_FunctionParams* __Params)
	{
		base.ReceiveTick_Implementation(__Params->DeltaSeconds);
	}

	// Token: 0x0601D683 RID: 120451 RVA: 0x008CB1F4 File Offset: 0x008C93F4
	protected unsafe override void __CPPCALL_ActivateDebugSpeed_Implementation(TsCharacterDebugComponent.__ActivateDebugSpeed_FunctionParams* __Params)
	{
		base.ActivateDebugSpeed_Implementation(__Params->activate);
	}

	// Token: 0x0601D684 RID: 120452 RVA: 0x008CB202 File Offset: 0x008C9402
	protected override void __CPPCALL_DebugDrawActivateArea_Implementation()
	{
		base.DebugDrawActivateArea_Implementation();
	}

	// Token: 0x0601D685 RID: 120453 RVA: 0x008CB20A File Offset: 0x008C940A
	protected unsafe override void __CPPCALL_SetDebugRiseEnable_Implementation(TsCharacterDebugComponent.__SetDebugRiseEnable_FunctionParams* __Params)
	{
		base.SetDebugRiseEnable_Implementation(__Params->enable);
	}

	// Token: 0x0601D686 RID: 120454 RVA: 0x008CB218 File Offset: 0x008C9418
	protected override void __CPPCALL_DrawDebugPatrolPoints_Implementation()
	{
		base.DrawDebugPatrolPoints_Implementation();
	}

	// Token: 0x0601D687 RID: 120455 RVA: 0x008CB220 File Offset: 0x008C9420
	protected override void __CPPCALL_DrawErrorNavigationPaths_Implementation()
	{
		base.DrawErrorNavigationPaths_Implementation();
	}
}
