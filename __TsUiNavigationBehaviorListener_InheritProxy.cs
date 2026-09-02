using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003879 RID: 14457
public class __TsUiNavigationBehaviorListener_InheritProxy : TsUiNavigationBehaviorListener
{
	// Token: 0x0601D5D7 RID: 120279 RVA: 0x008CA078 File Offset: 0x008C8278
	[NullableContext(1)]
	public __TsUiNavigationBehaviorListener_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsUiNavigationBehaviorListener.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D5D8 RID: 120280 RVA: 0x008CA0AB File Offset: 0x008C82AB
	protected __TsUiNavigationBehaviorListener_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D5D9 RID: 120281 RVA: 0x008CA0B4 File Offset: 0x008C82B4
	protected override void __CPPCALL_AwakeBP_Implementation()
	{
		base.AwakeBP_Implementation();
	}

	// Token: 0x0601D5DA RID: 120282 RVA: 0x008CA0BC File Offset: 0x008C82BC
	protected override void __CPPCALL_StartBP_Implementation()
	{
		base.StartBP_Implementation();
	}

	// Token: 0x0601D5DB RID: 120283 RVA: 0x008CA0C4 File Offset: 0x008C82C4
	protected unsafe override void __CPPCALL_OnNotifyNavigationEnterBP_Implementation(UUINavigationBehaviour.__OnNotifyNavigationEnterBP_FunctionParams* __Params)
	{
		ULGUIPointerEventData orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<ULGUIPointerEventData>(__Params->eventData);
		base.OnNotifyNavigationEnterBP_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601D5DC RID: 120284 RVA: 0x008CA0E4 File Offset: 0x008C82E4
	protected unsafe override void __CPPCALL_OnNotifyNavigationSelectBP_Implementation(UUINavigationBehaviour.__OnNotifyNavigationSelectBP_FunctionParams* __Params)
	{
		ULGUIPointerEventData orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<ULGUIPointerEventData>(__Params->eventData);
		base.OnNotifyNavigationSelectBP_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601D5DD RID: 120285 RVA: 0x008CA104 File Offset: 0x008C8304
	protected unsafe override void __CPPCALL_OnCheckCanSetNavigationBP_Implementation(UUINavigationBehaviour.__OnCheckCanSetNavigationBP_FunctionParams* __Params)
	{
		__Params->__Result = base.OnCheckCanSetNavigationBP_Implementation();
	}

	// Token: 0x0601D5DE RID: 120286 RVA: 0x008CA112 File Offset: 0x008C8312
	protected unsafe override void __CPPCALL_OnCheckLoopScrollChangeNavigationBP_Implementation(UUINavigationBehaviour.__OnCheckLoopScrollChangeNavigationBP_FunctionParams* __Params)
	{
		__Params->__Result = base.OnCheckLoopScrollChangeNavigationBP_Implementation();
	}

	// Token: 0x0601D5DF RID: 120287 RVA: 0x008CA120 File Offset: 0x008C8320
	protected override void __CPPCALL_OnEnableBP_Implementation()
	{
		base.OnEnableBP_Implementation();
	}

	// Token: 0x0601D5E0 RID: 120288 RVA: 0x008CA128 File Offset: 0x008C8328
	protected override void __CPPCALL_OnDisableBP_Implementation()
	{
		base.OnDisableBP_Implementation();
	}

	// Token: 0x0601D5E1 RID: 120289 RVA: 0x008CA130 File Offset: 0x008C8330
	protected override void __CPPCALL_OnNotifyInteractiveBP_Implementation()
	{
		base.OnNotifyInteractiveBP_Implementation();
	}

	// Token: 0x0601D5E2 RID: 120290 RVA: 0x008CA138 File Offset: 0x008C8338
	protected override void __CPPCALL_OnNotifyNotInteractiveBP_Implementation()
	{
		base.OnNotifyNotInteractiveBP_Implementation();
	}

	// Token: 0x0601D5E3 RID: 120291 RVA: 0x008CA140 File Offset: 0x008C8340
	protected override void __CPPCALL_OnPreDestroyBP_Implementation()
	{
		base.OnPreDestroyBP_Implementation();
	}
}
