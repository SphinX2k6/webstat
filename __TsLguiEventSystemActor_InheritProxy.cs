using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003963 RID: 14691
public class __TsLguiEventSystemActor_InheritProxy : TsLguiEventSystemActor
{
	// Token: 0x0601D9BC RID: 121276 RVA: 0x008D55D0 File Offset: 0x008D37D0
	[NullableContext(1)]
	public __TsLguiEventSystemActor_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsLguiEventSystemActor.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D9BD RID: 121277 RVA: 0x008D5603 File Offset: 0x008D3803
	protected __TsLguiEventSystemActor_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D9BE RID: 121278 RVA: 0x008D560C File Offset: 0x008D380C
	protected unsafe override void __CPPCALL_InputTrigger_Implementation(TsLguiEventSystemActor.__InputTrigger_FunctionParams* __Params)
	{
		EMouseButtonType mouseButtonType = (EMouseButtonType)__Params->mouseButtonType;
		base.InputTrigger_Implementation(__Params->triggerPress, mouseButtonType);
	}

	// Token: 0x0601D9BF RID: 121279 RVA: 0x008D5630 File Offset: 0x008D3830
	protected unsafe override void __CPPCALL_InputNavigation_Implementation(TsLguiEventSystemActor.__InputNavigation_FunctionParams* __Params)
	{
		ELGUINavigationDirection direction = (ELGUINavigationDirection)__Params->direction;
		base.InputNavigation_Implementation(direction, __Params->pressOrRelease, __Params->forceNavigation);
	}

	// Token: 0x0601D9C0 RID: 121280 RVA: 0x008D5657 File Offset: 0x008D3857
	protected unsafe override void __CPPCALL_InputTriggerForNavigation_Implementation(TsLguiEventSystemActor.__InputTriggerForNavigation_FunctionParams* __Params)
	{
		base.InputTriggerForNavigation_Implementation(__Params->triggerPress);
	}

	// Token: 0x0601D9C1 RID: 121281 RVA: 0x008D5665 File Offset: 0x008D3865
	protected unsafe override void __CPPCALL_InputScroll_Implementation(TsLguiEventSystemActor.__InputScroll_FunctionParams* __Params)
	{
		base.InputScroll_Implementation(__Params->axisValue);
	}

	// Token: 0x0601D9C2 RID: 121282 RVA: 0x008D5673 File Offset: 0x008D3873
	protected unsafe override void __CPPCALL_InputTouchTrigger_Implementation(TsLguiEventSystemActor.__InputTouchTrigger_FunctionParams* __Params)
	{
		base.InputTouchTrigger_Implementation(__Params->touchPress, __Params->touchId, __Params->touchPointPosition);
	}

	// Token: 0x0601D9C3 RID: 121283 RVA: 0x008D568D File Offset: 0x008D388D
	protected unsafe override void __CPPCALL_InputTouchMove_Implementation(TsLguiEventSystemActor.__InputTouchMove_FunctionParams* __Params)
	{
		base.InputTouchMove_Implementation(__Params->touchId, __Params->touchPointPosition);
	}

	// Token: 0x0601D9C4 RID: 121284 RVA: 0x008D56A1 File Offset: 0x008D38A1
	protected unsafe override void __CPPCALL_GetNowHitComponent_Implementation(TsLguiEventSystemActor.__GetNowHitComponent_FunctionParams* __Params)
	{
		ref IntPtr ptr = ref *(&__Params->__Result);
		UUIItem nowHitComponent_Implementation = base.GetNowHitComponent_Implementation();
		ptr = ((nowHitComponent_Implementation != null) ? nowHitComponent_Implementation.NativePtr : ((IntPtr)0));
	}

	// Token: 0x0601D9C5 RID: 121285 RVA: 0x008D56BE File Offset: 0x008D38BE
	protected unsafe override void __CPPCALL_GetPointerEventData_Implementation(TsLguiEventSystemActor.__GetPointerEventData_FunctionParams* __Params)
	{
		ref IntPtr ptr = ref *(&__Params->__Result);
		ULGUIPointerEventData pointerEventData_Implementation = base.GetPointerEventData_Implementation(__Params->pointerId, __Params->createIfNotExist);
		ptr = ((pointerEventData_Implementation != null) ? pointerEventData_Implementation.NativePtr : ((IntPtr)0));
	}

	// Token: 0x0601D9C6 RID: 121286 RVA: 0x008D56E8 File Offset: 0x008D38E8
	protected unsafe override void __CPPCALL_IsPointerEventDataLineTrace_Implementation(TsLguiEventSystemActor.__IsPointerEventDataLineTrace_FunctionParams* __Params)
	{
		ULGUIPointerEventData orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<ULGUIPointerEventData>(__Params->pointerEventData);
		__Params->__Result = base.IsPointerEventDataLineTrace_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601D9C7 RID: 121287 RVA: 0x008D5710 File Offset: 0x008D3910
	protected unsafe override void __CPPCALL_SetClickThresholdWithInputKeyType_Implementation(TsLguiEventSystemActor.__SetClickThresholdWithInputKeyType_FunctionParams* __Params)
	{
		EInputKeyType inputKeyType = (EInputKeyType)__Params->inputKeyType;
		base.SetClickThresholdWithInputKeyType_Implementation(inputKeyType);
	}
}
