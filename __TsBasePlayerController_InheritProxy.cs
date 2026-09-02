using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200382F RID: 14383
public class __TsBasePlayerController_InheritProxy : TsBasePlayerController
{
	// Token: 0x0601D4B4 RID: 119988 RVA: 0x008C6CE4 File Offset: 0x008C4EE4
	[NullableContext(1)]
	public __TsBasePlayerController_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsBasePlayerController.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D4B5 RID: 119989 RVA: 0x008C6D17 File Offset: 0x008C4F17
	protected __TsBasePlayerController_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D4B6 RID: 119990 RVA: 0x008C6D20 File Offset: 0x008C4F20
	protected override void __CPPCALL_ReceiveSetupInputComponent_Implementation()
	{
		base.ReceiveSetupInputComponent_Implementation();
	}

	// Token: 0x0601D4B7 RID: 119991 RVA: 0x008C6D28 File Offset: 0x008C4F28
	protected override void __CPPCALL_ReceiveBeginPlay_Implementation()
	{
		base.ReceiveBeginPlay_Implementation();
	}

	// Token: 0x0601D4B8 RID: 119992 RVA: 0x008C6D30 File Offset: 0x008C4F30
	protected override void __CPPCALL_ReceiveDestroyed_Implementation()
	{
		base.ReceiveDestroyed_Implementation();
	}

	// Token: 0x0601D4B9 RID: 119993 RVA: 0x008C6D38 File Offset: 0x008C4F38
	protected unsafe override void __CPPCALL_ReceiveTick_Implementation(AActor.__ReceiveTick_FunctionParams* __Params)
	{
		base.ReceiveTick_Implementation(__Params->DeltaSeconds);
	}

	// Token: 0x0601D4BA RID: 119994 RVA: 0x008C6D46 File Offset: 0x008C4F46
	protected override void __CPPCALL_OnReceivedPlayer_Implementation()
	{
		base.OnReceivedPlayer_Implementation();
	}

	// Token: 0x0601D4BB RID: 119995 RVA: 0x008C6D4E File Offset: 0x008C4F4E
	protected override void __CPPCALL_InitInputHandle_Implementation()
	{
		base.InitInputHandle_Implementation();
	}

	// Token: 0x0601D4BC RID: 119996 RVA: 0x008C6D56 File Offset: 0x008C4F56
	protected override void __CPPCALL_AddInputBinding_Implementation()
	{
		base.AddInputBinding_Implementation();
	}

	// Token: 0x0601D4BD RID: 119997 RVA: 0x008C6D5E File Offset: 0x008C4F5E
	protected override void __CPPCALL_ClearInputBinding_Implementation()
	{
		base.ClearInputBinding_Implementation();
	}

	// Token: 0x0601D4BE RID: 119998 RVA: 0x008C6D66 File Offset: 0x008C4F66
	protected override void __CPPCALL_OnSetupInputComponent_Implementation()
	{
		base.OnSetupInputComponent_Implementation();
	}

	// Token: 0x0601D4BF RID: 119999 RVA: 0x008C6D6E File Offset: 0x008C4F6E
	protected override void __CPPCALL_BindTouchHandle_Implementation()
	{
		base.BindTouchHandle_Implementation();
	}

	// Token: 0x0601D4C0 RID: 120000 RVA: 0x008C6D78 File Offset: 0x008C4F78
	protected unsafe override void __CPPCALL_OnTouchBegin_Implementation(TsBasePlayerController.__OnTouchBegin_FunctionParams* __Params)
	{
		ETouchIndex touchIndex = (ETouchIndex)__Params->touchIndex;
		base.OnTouchBegin_Implementation(touchIndex, __Params->position);
	}

	// Token: 0x0601D4C1 RID: 120001 RVA: 0x008C6D9C File Offset: 0x008C4F9C
	protected unsafe override void __CPPCALL_OnTouchEnd_Implementation(TsBasePlayerController.__OnTouchEnd_FunctionParams* __Params)
	{
		ETouchIndex touchIndex = (ETouchIndex)__Params->touchIndex;
		base.OnTouchEnd_Implementation(touchIndex, __Params->position);
	}

	// Token: 0x0601D4C2 RID: 120002 RVA: 0x008C6DC0 File Offset: 0x008C4FC0
	protected unsafe override void __CPPCALL_OnTouchMove_Implementation(TsBasePlayerController.__OnTouchMove_FunctionParams* __Params)
	{
		ETouchIndex touchIndex = (ETouchIndex)__Params->touchIndex;
		base.OnTouchMove_Implementation(touchIndex, __Params->position);
	}

	// Token: 0x0601D4C3 RID: 120003 RVA: 0x008C6DE4 File Offset: 0x008C4FE4
	protected unsafe override void __CPPCALL_OnPressAnyKey_Implementation(TsBasePlayerController.__OnPressAnyKey_FunctionParams* __Params)
	{
		FKey key = new FKey(&__Params->key, true, true);
		base.OnPressAnyKey_Implementation(key);
	}

	// Token: 0x0601D4C4 RID: 120004 RVA: 0x008C6E08 File Offset: 0x008C5008
	protected unsafe override void __CPPCALL_OnReleaseAnyKey_Implementation(TsBasePlayerController.__OnReleaseAnyKey_FunctionParams* __Params)
	{
		FKey key = new FKey(&__Params->key, true, true);
		base.OnReleaseAnyKey_Implementation(key);
	}

	// Token: 0x0601D4C5 RID: 120005 RVA: 0x008C6E2C File Offset: 0x008C502C
	protected unsafe override void __CPPCALL_RemoveActionHandle_Implementation(TsBasePlayerController.__RemoveActionHandle_FunctionParams* __Params)
	{
		string actionName = FString.ToString((void*)(&__Params->actionName));
		base.RemoveActionHandle_Implementation(actionName);
	}

	// Token: 0x0601D4C6 RID: 120006 RVA: 0x008C6E50 File Offset: 0x008C5050
	protected unsafe override void __CPPCALL_GetActionHandle_Implementation(TsBasePlayerController.__GetActionHandle_FunctionParams* __Params)
	{
		string actionName = FString.ToString((void*)(&__Params->actionName));
		ref IntPtr ptr = ref *(&__Params->__Result);
		TsActionHandle actionHandle_Implementation = base.GetActionHandle_Implementation(actionName);
		ptr = ((actionHandle_Implementation != null) ? actionHandle_Implementation.NativePtr : ((IntPtr)0));
	}

	// Token: 0x0601D4C7 RID: 120007 RVA: 0x008C6E88 File Offset: 0x008C5088
	protected unsafe override void __CPPCALL_RemoveAxisHandle_Implementation(TsBasePlayerController.__RemoveAxisHandle_FunctionParams* __Params)
	{
		string axisName = FString.ToString((void*)(&__Params->axisName));
		base.RemoveAxisHandle_Implementation(axisName);
	}

	// Token: 0x0601D4C8 RID: 120008 RVA: 0x008C6EAC File Offset: 0x008C50AC
	protected unsafe override void __CPPCALL_GetAxisHandle_Implementation(TsBasePlayerController.__GetAxisHandle_FunctionParams* __Params)
	{
		string actionName = FString.ToString((void*)(&__Params->actionName));
		ref IntPtr ptr = ref *(&__Params->__Result);
		TsAxisHandle axisHandle_Implementation = base.GetAxisHandle_Implementation(actionName);
		ptr = ((axisHandle_Implementation != null) ? axisHandle_Implementation.NativePtr : ((IntPtr)0));
	}

	// Token: 0x0601D4C9 RID: 120009 RVA: 0x008C6EE2 File Offset: 0x008C50E2
	protected unsafe override void __CPPCALL_IsInTouch_Implementation(TsBasePlayerController.__IsInTouch_FunctionParams* __Params)
	{
		__Params->__Result = base.IsInTouch_Implementation(__Params->touchId);
	}

	// Token: 0x0601D4CA RID: 120010 RVA: 0x008C6EF6 File Offset: 0x008C50F6
	protected unsafe override void __CPPCALL_SetIsPrintKeyName_Implementation(TsBasePlayerController.__SetIsPrintKeyName_FunctionParams* __Params)
	{
		base.SetIsPrintKeyName_Implementation(__Params->bPrintKeyName);
	}
}
