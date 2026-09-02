using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003964 RID: 14692
[NullableContext(1)]
[Nullable(0)]
public class __TsLguiEventSystemActor_SubClassMissingExportProxy : __TsLguiEventSystemActor_InheritProxy
{
	// Token: 0x0601D9C8 RID: 121288 RVA: 0x008D572C File Offset: 0x008D392C
	protected __TsLguiEventSystemActor_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsLguiEventSystemActor.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D9C9 RID: 121289 RVA: 0x008D575F File Offset: 0x008D395F
	protected __TsLguiEventSystemActor_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D9CA RID: 121290 RVA: 0x008D5768 File Offset: 0x008D3968
	public unsafe override void InputTrigger(bool triggerPress, EMouseButtonType mouseButtonType)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("InputTrigger"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsLguiEventSystemActor.__InputTrigger_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsLguiEventSystemActor.__InputTrigger_FunctionParams*)ptr + 15L / (long)sizeof(TsLguiEventSystemActor.__InputTrigger_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->triggerPress = triggerPress;
			*(&ptr2->mouseButtonType) = (byte)mouseButtonType;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D9CB RID: 121291 RVA: 0x008D57E8 File Offset: 0x008D39E8
	public unsafe override void InputNavigation(ELGUINavigationDirection direction, bool pressOrRelease, bool forceNavigation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("InputNavigation"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsLguiEventSystemActor.__InputNavigation_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsLguiEventSystemActor.__InputNavigation_FunctionParams*)ptr + 15L / (long)sizeof(TsLguiEventSystemActor.__InputNavigation_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->direction) = (byte)direction;
			ptr2->pressOrRelease = pressOrRelease;
			ptr2->forceNavigation = forceNavigation;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D9CC RID: 121292 RVA: 0x008D5870 File Offset: 0x008D3A70
	public unsafe override void InputTriggerForNavigation(bool triggerPress)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("InputTriggerForNavigation"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsLguiEventSystemActor.__InputTriggerForNavigation_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsLguiEventSystemActor.__InputTriggerForNavigation_FunctionParams*)ptr + 15L / (long)sizeof(TsLguiEventSystemActor.__InputTriggerForNavigation_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->triggerPress = triggerPress;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D9CD RID: 121293 RVA: 0x008D58E8 File Offset: 0x008D3AE8
	public unsafe override void InputScroll(float axisValue)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("InputScroll"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsLguiEventSystemActor.__InputScroll_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsLguiEventSystemActor.__InputScroll_FunctionParams*)ptr + 15L / (long)sizeof(TsLguiEventSystemActor.__InputScroll_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->axisValue = axisValue;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D9CE RID: 121294 RVA: 0x008D5960 File Offset: 0x008D3B60
	public unsafe override void InputTouchTrigger(bool touchPress, int touchId, FVector touchPointPosition)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("InputTouchTrigger"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsLguiEventSystemActor.__InputTouchTrigger_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsLguiEventSystemActor.__InputTouchTrigger_FunctionParams*)ptr + 15L / (long)sizeof(TsLguiEventSystemActor.__InputTouchTrigger_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->touchPress = touchPress;
			ptr2->touchId = touchId;
			ptr2->touchPointPosition = touchPointPosition;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D9CF RID: 121295 RVA: 0x008D59E8 File Offset: 0x008D3BE8
	public unsafe override void InputTouchMove(int touchId, FVector touchPointPosition)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("InputTouchMove"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsLguiEventSystemActor.__InputTouchMove_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsLguiEventSystemActor.__InputTouchMove_FunctionParams*)ptr + 15L / (long)sizeof(TsLguiEventSystemActor.__InputTouchMove_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->touchId = touchId;
			ptr2->touchPointPosition = touchPointPosition;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601D9D0 RID: 121296 RVA: 0x008D5A68 File Offset: 0x008D3C68
	[NullableContext(2)]
	public unsafe override UUIItem GetNowHitComponent()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetNowHitComponent"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsLguiEventSystemActor.__GetNowHitComponent_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsLguiEventSystemActor.__GetNowHitComponent_FunctionParams*)ptr + 15L / (long)sizeof(TsLguiEventSystemActor.__GetNowHitComponent_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		UUIItem orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UUIItem>(ptr2->__Result);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return orCreateUObjectByNativePointer;
	}

	// Token: 0x0601D9D1 RID: 121297 RVA: 0x008D5AE4 File Offset: 0x008D3CE4
	[NullableContext(2)]
	public unsafe override ULGUIPointerEventData GetPointerEventData(float pointerId, bool createIfNotExist)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetPointerEventData"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsLguiEventSystemActor.__GetPointerEventData_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsLguiEventSystemActor.__GetPointerEventData_FunctionParams*)ptr + 15L / (long)sizeof(TsLguiEventSystemActor.__GetPointerEventData_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->pointerId = pointerId;
			ptr2->createIfNotExist = createIfNotExist;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		ULGUIPointerEventData orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<ULGUIPointerEventData>(ptr2->__Result);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return orCreateUObjectByNativePointer;
	}

	// Token: 0x0601D9D2 RID: 121298 RVA: 0x008D5B70 File Offset: 0x008D3D70
	public unsafe override bool IsPointerEventDataLineTrace(ULGUIPointerEventData pointerEventData)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("IsPointerEventDataLineTrace"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsLguiEventSystemActor.__IsPointerEventDataLineTrace_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsLguiEventSystemActor.__IsPointerEventDataLineTrace_FunctionParams*)ptr + 15L / (long)sizeof(TsLguiEventSystemActor.__IsPointerEventDataLineTrace_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->pointerEventData) = ((pointerEventData != null) ? pointerEventData.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601D9D3 RID: 121299 RVA: 0x008D5BFC File Offset: 0x008D3DFC
	protected unsafe override void SetClickThresholdWithInputKeyType(EInputKeyType inputKeyType)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetClickThresholdWithInputKeyType"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsLguiEventSystemActor.__SetClickThresholdWithInputKeyType_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsLguiEventSystemActor.__SetClickThresholdWithInputKeyType_FunctionParams*)ptr + 15L / (long)sizeof(TsLguiEventSystemActor.__SetClickThresholdWithInputKeyType_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->inputKeyType) = (byte)inputKeyType;
		}
		UnrealReflectionUtils.CallUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2, 0);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}
}
