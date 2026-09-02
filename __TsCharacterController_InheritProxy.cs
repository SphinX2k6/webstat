using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003831 RID: 14385
public class __TsCharacterController_InheritProxy : TsCharacterController
{
	// Token: 0x0601D4DD RID: 120029 RVA: 0x008C7724 File Offset: 0x008C5924
	[NullableContext(1)]
	public __TsCharacterController_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsCharacterController.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D4DE RID: 120030 RVA: 0x008C7757 File Offset: 0x008C5957
	protected __TsCharacterController_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D4DF RID: 120031 RVA: 0x008C7760 File Offset: 0x008C5960
	protected override void __CPPCALL_ReceiveBeginPlay_Implementation()
	{
		base.ReceiveBeginPlay_Implementation();
	}

	// Token: 0x0601D4E0 RID: 120032 RVA: 0x008C7768 File Offset: 0x008C5968
	protected override void __CPPCALL_ReceiveDestroyed_Implementation()
	{
		base.ReceiveDestroyed_Implementation();
	}

	// Token: 0x0601D4E1 RID: 120033 RVA: 0x008C7770 File Offset: 0x008C5970
	protected unsafe override void __CPPCALL_ReceivePossess_Implementation(AController.__ReceivePossess_FunctionParams* __Params)
	{
		APawn orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->PossessedPawn);
		base.ReceivePossess_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601D4E2 RID: 120034 RVA: 0x008C7790 File Offset: 0x008C5990
	protected unsafe override void __CPPCALL_ReceiveUnPossess_Implementation(AController.__ReceiveUnPossess_FunctionParams* __Params)
	{
		APawn orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->UnpossessedPawn);
		base.ReceiveUnPossess_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601D4E3 RID: 120035 RVA: 0x008C77B0 File Offset: 0x008C59B0
	protected override void __CPPCALL_OnSetupInputComponent_Implementation()
	{
		base.OnSetupInputComponent_Implementation();
	}

	// Token: 0x0601D4E4 RID: 120036 RVA: 0x008C77B8 File Offset: 0x008C59B8
	protected unsafe override void __CPPCALL_ReceivePreProcessInput_Implementation(ABasePlayerController.__ReceivePreProcessInput_FunctionParams* __Params)
	{
		base.ReceivePreProcessInput_Implementation(__Params->DeltaTime, __Params->bGamePaused);
	}

	// Token: 0x0601D4E5 RID: 120037 RVA: 0x008C77CC File Offset: 0x008C59CC
	protected unsafe override void __CPPCALL_ReceivePostProcessInput_Implementation(ABasePlayerController.__ReceivePostProcessInput_FunctionParams* __Params)
	{
		base.ReceivePostProcessInput_Implementation(__Params->DeltaTime, __Params->bGamePaused);
	}

	// Token: 0x0601D4E6 RID: 120038 RVA: 0x008C77E0 File Offset: 0x008C59E0
	protected override void __CPPCALL_OnSetUiRootActive_Implementation()
	{
		base.OnSetUiRootActive_Implementation();
	}

	// Token: 0x0601D4E7 RID: 120039 RVA: 0x008C77E8 File Offset: 0x008C59E8
	protected override void __CPPCALL_OnSetUiRootDeactivate_Implementation()
	{
		base.OnSetUiRootDeactivate_Implementation();
	}
}
