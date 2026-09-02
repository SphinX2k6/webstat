using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003829 RID: 14377
public class __TsBaseCharacter_InheritProxy : TsBaseCharacter
{
	// Token: 0x0601D493 RID: 119955 RVA: 0x008C664C File Offset: 0x008C484C
	[NullableContext(1)]
	public __TsBaseCharacter_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsBaseCharacter.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D494 RID: 119956 RVA: 0x008C667F File Offset: 0x008C487F
	protected __TsBaseCharacter_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D495 RID: 119957 RVA: 0x008C6688 File Offset: 0x008C4888
	protected unsafe override void __CPPCALL_K2_OnMovementModeChanged_Implementation(ACharacter.__K2_OnMovementModeChanged_FunctionParams* __Params)
	{
		EMovementMode prevMovementMode = __Params->PrevMovementMode;
		EMovementMode newMovementMode = __Params->NewMovementMode;
		base.K2_OnMovementModeChanged_Implementation(prevMovementMode, newMovementMode, __Params->PrevCustomMode, __Params->NewCustomMode);
	}

	// Token: 0x0601D496 RID: 119958 RVA: 0x008C66C1 File Offset: 0x008C48C1
	protected unsafe override void __CPPCALL_BindGameplayEnableState_Implementation(TsBaseCharacter.__BindGameplayEnableState_FunctionParams* __Params)
	{
		base.BindGameplayEnableState_Implementation(ref __Params->gameplayEnable);
	}

	// Token: 0x0601D497 RID: 119959 RVA: 0x008C66D0 File Offset: 0x008C48D0
	protected unsafe override void __CPPCALL_ReceivePossessed_Implementation(APawn.__ReceivePossessed_FunctionParams* __Params)
	{
		AController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AController>(__Params->NewController);
		base.ReceivePossessed_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601D498 RID: 119960 RVA: 0x008C66F0 File Offset: 0x008C48F0
	protected unsafe override void __CPPCALL_ReceiveUnpossessed_Implementation(APawn.__ReceiveUnpossessed_FunctionParams* __Params)
	{
		AController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AController>(__Params->OldController);
		base.ReceiveUnpossessed_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601D499 RID: 119961 RVA: 0x008C6710 File Offset: 0x008C4910
	protected unsafe override void __CPPCALL_GetEntityId_Implementation(TsBaseCharacter.__GetEntityId_FunctionParams* __Params)
	{
		__Params->__Result = base.GetEntityId_Implementation();
	}

	// Token: 0x0601D49A RID: 119962 RVA: 0x008C671E File Offset: 0x008C491E
	protected override void __CPPCALL_Initialize_Implementation()
	{
		base.Initialize_Implementation();
	}

	// Token: 0x0601D49B RID: 119963 RVA: 0x008C6728 File Offset: 0x008C4928
	protected unsafe override void __CPPCALL_SetDitherEffect_Implementation(TsBaseCharacter.__SetDitherEffect_FunctionParams* __Params)
	{
		ECharacterDitherType ditherType = (ECharacterDitherType)__Params->ditherType;
		base.SetDitherEffect_Implementation(__Params->dither, ditherType);
	}

	// Token: 0x0601D49C RID: 119964 RVA: 0x008C6749 File Offset: 0x008C4949
	protected unsafe override void __CPPCALL_K2_UpdateCustomMovement_Implementation(ACharacter.__K2_UpdateCustomMovement_FunctionParams* __Params)
	{
		base.K2_UpdateCustomMovement_Implementation(__Params->DeltaTime);
	}

	// Token: 0x0601D49D RID: 119965 RVA: 0x008C6757 File Offset: 0x008C4957
	protected unsafe override void __CPPCALL_FightCommand_Implementation(TsBaseCharacter.__FightCommand_FunctionParams* __Params)
	{
		base.FightCommand_Implementation(__Params->isInAir);
	}

	// Token: 0x0601D49E RID: 119966 RVA: 0x008C6765 File Offset: 0x008C4965
	protected override void __CPPCALL_ReceiveDestroyed_Implementation()
	{
		base.ReceiveDestroyed_Implementation();
	}
}
