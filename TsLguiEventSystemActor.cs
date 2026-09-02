using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Cursor;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x0200343E RID: 13374
[UClass("/Game/Aki/TypeScript/Game/Ui/LguiEventSystem/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Ui/LguiEventSystem/TsLguiEventSystemActor.TsLguiEventSystemActor_C")]
public class TsLguiEventSystemActor : ALGUIEventSystemActor, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601C078 RID: 114808 RVA: 0x0085B97E File Offset: 0x00859B7E
	static TsLguiEventSystemActor()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TsLguiEventSystemActor.CreateStaticDefaultValue), new Action(TsLguiEventSystemActor.ResetStaticDefaultValue));
	}

	// Token: 0x17002642 RID: 9794
	// (get) Token: 0x0601C079 RID: 114809 RVA: 0x0085B99D File Offset: 0x00859B9D
	// (set) Token: 0x0601C07A RID: 114810 RVA: 0x0085B9B1 File Offset: 0x00859BB1
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	private unsafe ULGUI_StandaloneInputModule StandaloneInputModule
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<ULGUI_StandaloneInputModule>(base.NativePtr / (IntPtr)sizeof(void*) + TsLguiEventSystemActor.__PropertyOffset_StandaloneInputModule);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsLguiEventSystemActor.__PropertyOffset_StandaloneInputModule, value);
		}
	}

	// Token: 0x17002643 RID: 9795
	// (get) Token: 0x0601C07B RID: 114811 RVA: 0x0085B9C6 File Offset: 0x00859BC6
	// (set) Token: 0x0601C07C RID: 114812 RVA: 0x0085B9DA File Offset: 0x00859BDA
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	private unsafe ULGUI_TouchInputModule TouchInputModule
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<ULGUI_TouchInputModule>(base.NativePtr / (IntPtr)sizeof(void*) + TsLguiEventSystemActor.__PropertyOffset_TouchInputModule);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsLguiEventSystemActor.__PropertyOffset_TouchInputModule, value);
		}
	}

	// Token: 0x17002644 RID: 9796
	// (get) Token: 0x0601C07D RID: 114813 RVA: 0x0085B9EF File Offset: 0x00859BEF
	// (set) Token: 0x0601C07E RID: 114814 RVA: 0x0085B9F7 File Offset: 0x00859BF7
	[Nullable(2)]
	private ULGUI_PointerInputModule CurrentInputModule { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x17002645 RID: 9797
	// (get) Token: 0x0601C07F RID: 114815 RVA: 0x0085BA00 File Offset: 0x00859C00
	// (set) Token: 0x0601C080 RID: 114816 RVA: 0x0085BA10 File Offset: 0x00859C10
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool NavigationEnable
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsLguiEventSystemActor.__PropertyOffset_NavigationEnable) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsLguiEventSystemActor.__PropertyOffset_NavigationEnable) = (value ? 1 : 0);
		}
	}

	// Token: 0x0601C081 RID: 114817 RVA: 0x0085BA24 File Offset: 0x00859C24
	public void InitializeLguiEventSystemActor()
	{
		this.RefreshCurrentInputModule();
		ULGUI_StandaloneInputModule standaloneInputModule = this.StandaloneInputModule;
		FLGUIDelegateHandleWrapper handleWrapper;
		if (standaloneInputModule == null)
		{
			handleWrapper = null;
		}
		else
		{
			Action<ELGUIPointerInputType> callback;
			if ((callback = TsLguiEventSystemActor.<>O.<0>__ChangeController) == null)
			{
				callback = (TsLguiEventSystemActor.<>O.<0>__ChangeController = new Action<ELGUIPointerInputType>(TsLguiEventSystemActor.ChangeController));
			}
			FLGUIPointerInputChange_DynamicDelegate flguipointerInputChange_DynamicDelegate = global::DelegateUtils.ToManualReleaseDelegate<FLGUIPointerInputChange_DynamicDelegate>(callback);
			handleWrapper = standaloneInputModule.RegisterInputChangeEvent(flguipointerInputChange_DynamicDelegate);
		}
		this.HandleWrapper = handleWrapper;
		this.AddEvents();
		this.RegisterControllerChange();
		ControllerBase<CursorController>.Instance.SetWindowCursorStyle();
		this.RegisterPointEnterExitEvent();
		this.BroadCastInputType();
	}

	// Token: 0x0601C082 RID: 114818 RVA: 0x0085BA94 File Offset: 0x00859C94
	public void ResetLguiEventSystemActor()
	{
		if (this.HandleWrapper != null)
		{
			ULGUI_StandaloneInputModule standaloneInputModule = this.StandaloneInputModule;
			if (standaloneInputModule != null)
			{
				standaloneInputModule.UnregisterInputChangeEvent(this.HandleWrapper);
			}
		}
		Action<ELGUIPointerInputType> callBack;
		if ((callBack = TsLguiEventSystemActor.<>O.<0>__ChangeController) == null)
		{
			callBack = (TsLguiEventSystemActor.<>O.<0>__ChangeController = new Action<ELGUIPointerInputType>(TsLguiEventSystemActor.ChangeController));
		}
		global::DelegateUtils.ReleaseManualReleaseDelegate(callBack);
		this.HandleWrapper = null;
		this.UnRegisterControllerChange();
		this.RemoveEvents();
		this.UnRegisterPointEnterExitEvent();
	}

	// Token: 0x0601C083 RID: 114819 RVA: 0x0085BAF9 File Offset: 0x00859CF9
	private void AddEvents()
	{
		this.ShowTypeChange = delegate(EOperationType last, EOperationType now)
		{
			this.RefreshCurrentInputModule();
		};
		Singleton<CSharpScript.Game.Common.Event.EventSystem>.Instance.Add<EOperationType, EOperationType>(EEventName.ShowTypeChange, this.ShowTypeChange);
	}

	// Token: 0x0601C084 RID: 114820 RVA: 0x0085BB23 File Offset: 0x00859D23
	private void RemoveEvents()
	{
		Singleton<CSharpScript.Game.Common.Event.EventSystem>.Instance.Remove<EOperationType, EOperationType>(EEventName.ShowTypeChange, this.ShowTypeChange);
	}

	// Token: 0x0601C085 RID: 114821 RVA: 0x0085BB3C File Offset: 0x00859D3C
	private void RegisterControllerChange()
	{
		this.ControllerConnectChange = delegate(bool bIsConnected, int platformUserId, int controllerId)
		{
			Singleton<CSharpScript.Game.Common.Event.EventSystem>.Instance.Emit<bool, int, int>(EEventName.ControllerConnectChange, bIsConnected, platformUserId, controllerId);
		};
		ULGUIEventSystem eventSystem = base.EventSystem;
		if (eventSystem == null)
		{
			return;
		}
		eventSystem.OnConnectionChanged.Add(this.ControllerConnectChange);
	}

	// Token: 0x0601C086 RID: 114822 RVA: 0x0085BB89 File Offset: 0x00859D89
	private void UnRegisterControllerChange()
	{
		ULGUIEventSystem eventSystem = base.EventSystem;
		if (eventSystem == null)
		{
			return;
		}
		eventSystem.OnConnectionChanged.Remove(this.ControllerConnectChange);
	}

	// Token: 0x0601C087 RID: 114823 RVA: 0x0085BBA8 File Offset: 0x00859DA8
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void InputTrigger(bool triggerPress, EMouseButtonType mouseButtonType)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601C088 RID: 114824 RVA: 0x0085BC28 File Offset: 0x00859E28
	protected void InputTrigger_Implementation(bool triggerPress, EMouseButtonType mouseButtonType)
	{
		if (Singleton<Info>.Instance.IsInTouch())
		{
			return;
		}
		APlayerController playerController = Global.PlayerController;
		if (playerController == null)
		{
			return;
		}
		if (!playerController.bShowMouseCursor)
		{
			return;
		}
		ULGUI_StandaloneInputModule standaloneInputModule = this.StandaloneInputModule;
		if (standaloneInputModule == null)
		{
			return;
		}
		standaloneInputModule.InputTrigger(triggerPress, mouseButtonType);
	}

	// Token: 0x0601C089 RID: 114825 RVA: 0x0085BC68 File Offset: 0x00859E68
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void InputNavigation(ELGUINavigationDirection direction, bool pressOrRelease, bool forceNavigation = false)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601C08A RID: 114826 RVA: 0x0085BCEE File Offset: 0x00859EEE
	protected void InputNavigation_Implementation(ELGUINavigationDirection direction, bool pressOrRelease, bool forceNavigation = false)
	{
		if (!this.NavigationEnable && !forceNavigation)
		{
			return;
		}
		if (this.CurrentInputModule == null)
		{
			return;
		}
		TsLguiEventSystemActor.InputType = ELGUIPointerInputType.Navigation;
		this.CurrentInputModule.InputNavigation(direction, pressOrRelease);
	}

	// Token: 0x0601C08B RID: 114827 RVA: 0x0085BD18 File Offset: 0x00859F18
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void InputTriggerForNavigation(bool triggerPress)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601C08C RID: 114828 RVA: 0x0085BD8E File Offset: 0x00859F8E
	protected void InputTriggerForNavigation_Implementation(bool triggerPress)
	{
		if (this.CurrentInputModule == null)
		{
			return;
		}
		TsLguiEventSystemActor.InputType = ELGUIPointerInputType.Navigation;
		this.CurrentInputModule.InputTriggerForNavigation(triggerPress);
	}

	// Token: 0x0601C08D RID: 114829 RVA: 0x0085BDAB File Offset: 0x00859FAB
	public void SwitchToNavigationInputType()
	{
		if (this.CurrentInputModule == null)
		{
			return;
		}
		if (TsLguiEventSystemActor.InputType == ELGUIPointerInputType.Navigation)
		{
			return;
		}
		TsLguiEventSystemActor.InputType = ELGUIPointerInputType.Navigation;
		this.CurrentInputModule.SwitchToNavigationInputType();
	}

	// Token: 0x0601C08E RID: 114830 RVA: 0x0085BDD0 File Offset: 0x00859FD0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void InputScroll(float axisValue)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601C08F RID: 114831 RVA: 0x0085BE48 File Offset: 0x0085A048
	protected void InputScroll_Implementation(float axisValue)
	{
		ULGUI_StandaloneInputModule standaloneInputModule = this.StandaloneInputModule;
		if (standaloneInputModule != null)
		{
			standaloneInputModule.InputScroll(axisValue);
		}
		if (Singleton<Info>.Instance.IsInTouch())
		{
			return;
		}
		if (axisValue != 0f)
		{
			ULGUIPointerEventData pointerEventData = this.GetPointerEventData(0f, true);
			if (pointerEventData != null && pointerEventData.inputType != ELGUIPointerInputType.Pointer)
			{
				pointerEventData.inputType = ELGUIPointerInputType.Pointer;
				TsLguiEventSystemActor.ChangeController(pointerEventData.inputType);
			}
		}
	}

	// Token: 0x0601C090 RID: 114832 RVA: 0x0085BEA8 File Offset: 0x0085A0A8
	public void InputScrollByGamepad(float axisValue)
	{
		ULGUI_StandaloneInputModule standaloneInputModule = this.StandaloneInputModule;
		if (standaloneInputModule != null)
		{
			standaloneInputModule.InputScroll(axisValue);
		}
		if (axisValue != 0f)
		{
			ULGUIPointerEventData pointerEventData = this.GetPointerEventData(0f, true);
			if (pointerEventData != null && pointerEventData.inputType != ELGUIPointerInputType.Navigation)
			{
				pointerEventData.inputType = ELGUIPointerInputType.Navigation;
				TsLguiEventSystemActor.ChangeController(pointerEventData.inputType);
			}
		}
	}

	// Token: 0x0601C091 RID: 114833 RVA: 0x0085BEFC File Offset: 0x0085A0FC
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void InputTouchTrigger(bool touchPress, int touchId, FVector touchPointPosition)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601C092 RID: 114834 RVA: 0x0085BF80 File Offset: 0x0085A180
	protected void InputTouchTrigger_Implementation(bool touchPress, int touchId, FVector touchPointPosition)
	{
		int inTouchID = touchId;
		if (Singleton<Info>.Instance.IsMobileInputModel() && Singleton<Info>.Instance.IsInGamepad())
		{
			inTouchID = touchId + 1000;
		}
		ULGUI_TouchInputModule touchInputModule = this.TouchInputModule;
		if (touchInputModule == null)
		{
			return;
		}
		touchInputModule.InputTouchTrigger(touchPress, inTouchID, touchPointPosition);
	}

	// Token: 0x0601C093 RID: 114835 RVA: 0x0085BFC4 File Offset: 0x0085A1C4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void InputTouchMove(int touchId, FVector touchPointPosition)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601C094 RID: 114836 RVA: 0x0085C044 File Offset: 0x0085A244
	protected void InputTouchMove_Implementation(int touchId, FVector touchPointPosition)
	{
		if (Singleton<Info>.Instance.IsMobileInputModel() && Singleton<Info>.Instance.IsInGamepad())
		{
			int inTouchID = touchId + 1000;
			ULGUI_TouchInputModule touchInputModule = this.TouchInputModule;
			if (touchInputModule != null)
			{
				touchInputModule.InputTouchMoved(inTouchID, touchPointPosition);
			}
			ULGUI_TouchInputModule touchInputModule2 = this.TouchInputModule;
			if (touchInputModule2 == null)
			{
				return;
			}
			touchInputModule2.RefreshProcessInput();
			return;
		}
		else
		{
			ULGUI_TouchInputModule touchInputModule3 = this.TouchInputModule;
			if (touchInputModule3 == null)
			{
				return;
			}
			touchInputModule3.InputTouchMoved(touchId, touchPointPosition);
			return;
		}
	}

	// Token: 0x0601C095 RID: 114837 RVA: 0x0085C0AB File Offset: 0x0085A2AB
	public void RefreshCurrentInputModule()
	{
		if (Singleton<Info>.Instance.IsInTouch())
		{
			this.CurrentInputModule = this.TouchInputModule;
		}
		else
		{
			this.CurrentInputModule = this.StandaloneInputModule;
		}
		ULGUI_PointerInputModule currentInputModule = this.CurrentInputModule;
		if (currentInputModule == null)
		{
			return;
		}
		currentInputModule.Activate(false);
	}

	// Token: 0x0601C096 RID: 114838 RVA: 0x0085C0E4 File Offset: 0x0085A2E4
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual UUIItem GetNowHitComponent()
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		UUIItem orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<UUIItem>(ptr2->__Result);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return orCreateUObjectByNativePointer;
	}

	// Token: 0x0601C097 RID: 114839 RVA: 0x0085C15E File Offset: 0x0085A35E
	[NullableContext(2)]
	protected UUIItem GetNowHitComponent_Implementation()
	{
		ULGUI_PointerInputModule currentInputModule = this.CurrentInputModule;
		if (currentInputModule == null)
		{
			return null;
		}
		return currentInputModule.GetNowHitComponent();
	}

	// Token: 0x0601C098 RID: 114840 RVA: 0x0085C174 File Offset: 0x0085A374
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual ULGUIPointerEventData GetPointerEventData(float pointerId, bool createIfNotExist = false)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		ULGUIPointerEventData orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<ULGUIPointerEventData>(ptr2->__Result);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return orCreateUObjectByNativePointer;
	}

	// Token: 0x0601C099 RID: 114841 RVA: 0x0085C1FC File Offset: 0x0085A3FC
	[NullableContext(2)]
	protected ULGUIPointerEventData GetPointerEventData_Implementation(float pointerId, bool createIfNotExist = false)
	{
		ULGUI_PointerInputModule currentInputModule = this.CurrentInputModule;
		if (currentInputModule == null)
		{
			return null;
		}
		return currentInputModule.GetPointerEventData((int)pointerId, createIfNotExist);
	}

	// Token: 0x0601C09A RID: 114842 RVA: 0x0085C214 File Offset: 0x0085A414
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual bool IsPointerEventDataLineTrace(ULGUIPointerEventData pointerEventData)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0601C09B RID: 114843 RVA: 0x0085C29E File Offset: 0x0085A49E
	[NullableContext(1)]
	protected bool IsPointerEventDataLineTrace_Implementation(ULGUIPointerEventData pointerEventData)
	{
		return this.CurrentInputModule != null && !this.CurrentInputModule.IsPointerEventDataLineTrace(pointerEventData);
	}

	// Token: 0x0601C09C RID: 114844 RVA: 0x0085C2BC File Offset: 0x0085A4BC
	[NullableContext(1)]
	public bool SimulateClickButton(int pointerId, UUIItem uiItem, FVector2D? pivot)
	{
		pivot = new FVector2D?(pivot ?? new FVector2D(0.5f, 0.5f));
		ULGUI_StandaloneInputModule standaloneInputModule = this.StandaloneInputModule;
		return standaloneInputModule != null && standaloneInputModule.SimulationLineTrace(pointerId, uiItem, pivot);
	}

	// Token: 0x0601C09D RID: 114845 RVA: 0x0085C308 File Offset: 0x0085A508
	[NullableContext(1)]
	public bool SimulationPointerDownUp(int pointerId, UUIItem uiItem, bool isPress, FVector2D pivot)
	{
		ULGUI_StandaloneInputModule standaloneInputModule = this.StandaloneInputModule;
		if (standaloneInputModule == null)
		{
			return false;
		}
		FVector2D? fvector2D = new FVector2D?(pivot);
		return standaloneInputModule.SimulationPointerDownUp(pointerId, uiItem, isPress, fvector2D);
	}

	// Token: 0x0601C09E RID: 114846 RVA: 0x0085C333 File Offset: 0x0085A533
	public void SimulationPointerTrigger(int pointerId, bool isPress)
	{
		ULGUI_StandaloneInputModule standaloneInputModule = this.StandaloneInputModule;
		if (standaloneInputModule == null)
		{
			return;
		}
		standaloneInputModule.SimulationPointerTrigger(pointerId, isPress);
	}

	// Token: 0x0601C09F RID: 114847 RVA: 0x0085C347 File Offset: 0x0085A547
	public void ResetNowIsTriggerPressed(int pointerId)
	{
		ULGUI_StandaloneInputModule standaloneInputModule = this.StandaloneInputModule;
		if (standaloneInputModule == null)
		{
			return;
		}
		standaloneInputModule.ResetNowIsTriggerPressed(pointerId);
	}

	// Token: 0x0601C0A0 RID: 114848 RVA: 0x0085C35A File Offset: 0x0085A55A
	[NullableContext(2)]
	public void UpdateNavigationListener(USceneComponent component)
	{
		ULGUI_StandaloneInputModule standaloneInputModule = this.StandaloneInputModule;
		if (standaloneInputModule == null)
		{
			return;
		}
		standaloneInputModule.UpdateNavigation(component);
	}

	// Token: 0x0601C0A1 RID: 114849 RVA: 0x0085C36D File Offset: 0x0085A56D
	public void SetIsUseMouse(bool value)
	{
		ULGUI_StandaloneInputModule standaloneInputModule = this.StandaloneInputModule;
		if (standaloneInputModule == null)
		{
			return;
		}
		standaloneInputModule.SetIsForceChange(value);
	}

	// Token: 0x0601C0A2 RID: 114850 RVA: 0x0085C380 File Offset: 0x0085A580
	public void SetIsForceChange(bool value)
	{
		ULGUI_StandaloneInputModule standaloneInputModule = this.StandaloneInputModule;
		if (standaloneInputModule == null)
		{
			return;
		}
		standaloneInputModule.SetIsForceChange(value);
	}

	// Token: 0x0601C0A3 RID: 114851 RVA: 0x0085C394 File Offset: 0x0085A594
	public void SetPrevMousePosition(float x, float y)
	{
		ULGUIPointerEventData pointerEventData = this.GetPointerEventData(0f, true);
		if (pointerEventData != null)
		{
			pointerEventData.prevMousePos = new FVector2D(x, y);
		}
	}

	// Token: 0x0601C0A4 RID: 114852 RVA: 0x0085C3BE File Offset: 0x0085A5BE
	public void SetCurrentInputKeyType(EInputKeyType inputKeyType)
	{
		if (Singleton<Info>.Instance.IsInTouch())
		{
			ULGUI_TouchInputModule touchInputModule = this.TouchInputModule;
			if (touchInputModule != null)
			{
				touchInputModule.SetCurrentInputKeyType(inputKeyType);
			}
		}
		else
		{
			ULGUI_StandaloneInputModule standaloneInputModule = this.StandaloneInputModule;
			if (standaloneInputModule != null)
			{
				standaloneInputModule.SetCurrentInputKeyType(inputKeyType);
			}
		}
		this.SetClickThresholdWithInputKeyType(inputKeyType);
	}

	// Token: 0x0601C0A5 RID: 114853 RVA: 0x0085C3FC File Offset: 0x0085A5FC
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void SetClickThresholdWithInputKeyType(EInputKeyType inputKeyType)
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
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x0601C0A6 RID: 114854 RVA: 0x0085C474 File Offset: 0x0085A674
	protected void SetClickThresholdWithInputKeyType_Implementation(EInputKeyType inputKeyType)
	{
		if (this.StandaloneInputModule != null)
		{
			switch (inputKeyType)
			{
			case EInputKeyType.KeyboardOrMouse:
				this.StandaloneInputModule.SetClickThreshold(this.MouseClickThreshold);
				return;
			case EInputKeyType.Gamepad:
				this.StandaloneInputModule.SetClickThreshold(this.GamepadClickThreshold);
				break;
			case EInputKeyType.Touch:
				this.StandaloneInputModule.SetClickThreshold(this.TouchClickThreshold);
				return;
			default:
				return;
			}
		}
	}

	// Token: 0x0601C0A7 RID: 114855 RVA: 0x0085C4D3 File Offset: 0x0085A6D3
	public void OverrideMousePosition(FVector2D vector2D)
	{
		ULGUI_StandaloneInputModule standaloneInputModule = this.StandaloneInputModule;
		if (standaloneInputModule == null)
		{
			return;
		}
		standaloneInputModule.InputOverrideMousePosition(vector2D);
	}

	// Token: 0x0601C0A8 RID: 114856 RVA: 0x0085C4E7 File Offset: 0x0085A6E7
	public void SetIsOverrideMousePosition(bool value)
	{
		if (this.StandaloneInputModule != null)
		{
			this.StandaloneInputModule.bOverrideMousePosition = value;
		}
	}

	// Token: 0x0601C0A9 RID: 114857 RVA: 0x0085C4FD File Offset: 0x0085A6FD
	public bool IsInPointerInputType()
	{
		return TsLguiEventSystemActor.InputType == ELGUIPointerInputType.Pointer;
	}

	// Token: 0x0601C0AA RID: 114858 RVA: 0x0085C507 File Offset: 0x0085A707
	public bool IsInNavigationInputType()
	{
		return TsLguiEventSystemActor.InputType == ELGUIPointerInputType.Navigation;
	}

	// Token: 0x0601C0AB RID: 114859 RVA: 0x0085C514 File Offset: 0x0085A714
	private void RegisterPointEnterExitEvent()
	{
		if (Singleton<Info>.Instance.IsPcOrGamepadPlatform())
		{
			ULGUIEventSystem eventSystem = base.EventSystem;
			if (eventSystem == null)
			{
				return;
			}
			FLGUIPointerEnterExit_DynamicDelegate flguipointerEnterExit_DynamicDelegate = global::DelegateUtils.ToManualReleaseDelegate<FLGUIPointerEnterExit_DynamicDelegate>(new Action<bool>(ControllerBase<CursorController>.Instance.CursorEnterExit));
			eventSystem.RegisterPointerEnterExitEvent(flguipointerEnterExit_DynamicDelegate);
		}
	}

	// Token: 0x0601C0AC RID: 114860 RVA: 0x0085C555 File Offset: 0x0085A755
	private void UnRegisterPointEnterExitEvent()
	{
		if (Singleton<Info>.Instance.IsPcOrGamepadPlatform())
		{
			ULGUIEventSystem eventSystem = base.EventSystem;
			if (eventSystem != null)
			{
				eventSystem.UnRegisterPointerEnterExitEvent();
			}
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<bool>(ControllerBase<CursorController>.Instance.CursorEnterExit));
		}
	}

	// Token: 0x0601C0AD RID: 114861 RVA: 0x0085C589 File Offset: 0x0085A789
	private void BroadCastInputType()
	{
		TsLguiEventSystemActor.InputType = base.EventSystem.defaultInputType;
		Singleton<CSharpScript.Game.Common.Event.EventSystem>.Instance.Emit<ELGUIPointerInputType>(EEventName.PointerInputTypeChange, base.EventSystem.defaultInputType);
	}

	// Token: 0x0601C0AE RID: 114862 RVA: 0x0085C5B6 File Offset: 0x0085A7B6
	private static void ChangeController(ELGUIPointerInputType type)
	{
		TsLguiEventSystemActor.InputType = type;
		if (type == ELGUIPointerInputType.Pointer)
		{
			Singleton<Info>.Instance.SwitchInputControllerType(EInputControllerType.Keyboard, "MouseMove");
		}
		Singleton<CSharpScript.Game.Common.Event.EventSystem>.Instance.Emit<ELGUIPointerInputType>(EEventName.PointerInputTypeChange, type);
	}

	// Token: 0x0601C0AF RID: 114863 RVA: 0x0085C5E2 File Offset: 0x0085A7E2
	public static void CreateStaticDefaultValue()
	{
	}

	// Token: 0x0601C0B0 RID: 114864 RVA: 0x0085C5E4 File Offset: 0x0085A7E4
	public static void ResetStaticDefaultValue()
	{
		TsLguiEventSystemActor.InputType = ELGUIPointerInputType.None;
	}

	// Token: 0x0601C0B1 RID: 114865 RVA: 0x0085C5EC File Offset: 0x0085A7EC
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsLguiEventSystemActor._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Ui/LguiEventSystem/TsLguiEventSystemActor.TsLguiEventSystemActor_C");
		}
		return TsLguiEventSystemActor._ClassPtr;
	}

	// Token: 0x0601C0B2 RID: 114866 RVA: 0x0085C610 File Offset: 0x0085A810
	public TsLguiEventSystemActor() : this(BuiltinUtils.AllocNativeUObject(TsLguiEventSystemActor.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601C0B3 RID: 114867 RVA: 0x0085C638 File Offset: 0x0085A838
	[NullableContext(1)]
	public TsLguiEventSystemActor(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsLguiEventSystemActor.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601C0B4 RID: 114868 RVA: 0x0085C66B File Offset: 0x0085A86B
	protected TsLguiEventSystemActor(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601C0B5 RID: 114869 RVA: 0x0085C698 File Offset: 0x0085A898
	protected unsafe virtual void __CPPCALL_InputTrigger_Implementation(TsLguiEventSystemActor.__InputTrigger_FunctionParams* __Params)
	{
		EMouseButtonType mouseButtonType = (EMouseButtonType)__Params->mouseButtonType;
		this.InputTrigger_Implementation(__Params->triggerPress, mouseButtonType);
	}

	// Token: 0x0601C0B6 RID: 114870 RVA: 0x0085C6BC File Offset: 0x0085A8BC
	protected unsafe virtual void __CPPCALL_InputNavigation_Implementation(TsLguiEventSystemActor.__InputNavigation_FunctionParams* __Params)
	{
		ELGUINavigationDirection direction = (ELGUINavigationDirection)__Params->direction;
		this.InputNavigation_Implementation(direction, __Params->pressOrRelease, __Params->forceNavigation);
	}

	// Token: 0x0601C0B7 RID: 114871 RVA: 0x0085C6E3 File Offset: 0x0085A8E3
	protected unsafe virtual void __CPPCALL_InputTriggerForNavigation_Implementation(TsLguiEventSystemActor.__InputTriggerForNavigation_FunctionParams* __Params)
	{
		this.InputTriggerForNavigation_Implementation(__Params->triggerPress);
	}

	// Token: 0x0601C0B8 RID: 114872 RVA: 0x0085C6F1 File Offset: 0x0085A8F1
	protected unsafe virtual void __CPPCALL_InputScroll_Implementation(TsLguiEventSystemActor.__InputScroll_FunctionParams* __Params)
	{
		this.InputScroll_Implementation(__Params->axisValue);
	}

	// Token: 0x0601C0B9 RID: 114873 RVA: 0x0085C6FF File Offset: 0x0085A8FF
	protected unsafe virtual void __CPPCALL_InputTouchTrigger_Implementation(TsLguiEventSystemActor.__InputTouchTrigger_FunctionParams* __Params)
	{
		this.InputTouchTrigger_Implementation(__Params->touchPress, __Params->touchId, __Params->touchPointPosition);
	}

	// Token: 0x0601C0BA RID: 114874 RVA: 0x0085C719 File Offset: 0x0085A919
	protected unsafe virtual void __CPPCALL_InputTouchMove_Implementation(TsLguiEventSystemActor.__InputTouchMove_FunctionParams* __Params)
	{
		this.InputTouchMove_Implementation(__Params->touchId, __Params->touchPointPosition);
	}

	// Token: 0x0601C0BB RID: 114875 RVA: 0x0085C72D File Offset: 0x0085A92D
	protected unsafe virtual void __CPPCALL_GetNowHitComponent_Implementation(TsLguiEventSystemActor.__GetNowHitComponent_FunctionParams* __Params)
	{
		ref IntPtr ptr = ref *(&__Params->__Result);
		UUIItem nowHitComponent_Implementation = this.GetNowHitComponent_Implementation();
		ptr = ((nowHitComponent_Implementation != null) ? nowHitComponent_Implementation.NativePtr : ((IntPtr)0));
	}

	// Token: 0x0601C0BC RID: 114876 RVA: 0x0085C74A File Offset: 0x0085A94A
	protected unsafe virtual void __CPPCALL_GetPointerEventData_Implementation(TsLguiEventSystemActor.__GetPointerEventData_FunctionParams* __Params)
	{
		ref IntPtr ptr = ref *(&__Params->__Result);
		ULGUIPointerEventData pointerEventData_Implementation = this.GetPointerEventData_Implementation(__Params->pointerId, __Params->createIfNotExist);
		ptr = ((pointerEventData_Implementation != null) ? pointerEventData_Implementation.NativePtr : ((IntPtr)0));
	}

	// Token: 0x0601C0BD RID: 114877 RVA: 0x0085C774 File Offset: 0x0085A974
	protected unsafe virtual void __CPPCALL_IsPointerEventDataLineTrace_Implementation(TsLguiEventSystemActor.__IsPointerEventDataLineTrace_FunctionParams* __Params)
	{
		ULGUIPointerEventData orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<ULGUIPointerEventData>(__Params->pointerEventData);
		__Params->__Result = this.IsPointerEventDataLineTrace_Implementation(orCreateUObjectByNativePointer);
	}

	// Token: 0x0601C0BE RID: 114878 RVA: 0x0085C79C File Offset: 0x0085A99C
	protected unsafe virtual void __CPPCALL_SetClickThresholdWithInputKeyType_Implementation(TsLguiEventSystemActor.__SetClickThresholdWithInputKeyType_FunctionParams* __Params)
	{
		EInputKeyType inputKeyType = (EInputKeyType)__Params->inputKeyType;
		this.SetClickThresholdWithInputKeyType_Implementation(inputKeyType);
	}

	// Token: 0x0400E27C RID: 57980
	[Nullable(2)]
	private FLGUIDelegateHandleWrapper HandleWrapper;

	// Token: 0x0400E27D RID: 57981
	private static ELGUIPointerInputType InputType;

	// Token: 0x0400E27E RID: 57982
	[Nullable(1)]
	private Action<EOperationType, EOperationType> ShowTypeChange;

	// Token: 0x0400E27F RID: 57983
	[Nullable(1)]
	private Action<bool, int, int> ControllerConnectChange;

	// Token: 0x0400E280 RID: 57984
	private readonly float TouchClickThreshold = 10f;

	// Token: 0x0400E281 RID: 57985
	private readonly float MouseClickThreshold = 5f;

	// Token: 0x0400E282 RID: 57986
	private readonly float GamepadClickThreshold = 5f;

	// Token: 0x0400E283 RID: 57987
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Ui/LguiEventSystem/TsLguiEventSystemActor.TsLguiEventSystemActor_C";

	// Token: 0x0400E284 RID: 57988
	private static IntPtr _ClassPtr;

	// Token: 0x0400E285 RID: 57989
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400E286 RID: 57990
	private static int __PropertyOffset_StandaloneInputModule;

	// Token: 0x0400E287 RID: 57991
	private static int __PropertyOffset_TouchInputModule;

	// Token: 0x0400E288 RID: 57992
	private static int __PropertyOffset_NavigationEnable;

	// Token: 0x02009504 RID: 38148
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 2)]
	protected ref struct __InputTrigger_FunctionParams
	{
		// Token: 0x0403152A RID: 202026
		[FieldOffset(0)]
		public bool triggerPress;

		// Token: 0x0403152B RID: 202027
		[FieldOffset(1)]
		public byte mouseButtonType;
	}

	// Token: 0x02009505 RID: 38149
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 3)]
	protected ref struct __InputNavigation_FunctionParams
	{
		// Token: 0x0403152C RID: 202028
		[FieldOffset(0)]
		public byte direction;

		// Token: 0x0403152D RID: 202029
		[FieldOffset(1)]
		public bool pressOrRelease;

		// Token: 0x0403152E RID: 202030
		[FieldOffset(2)]
		public bool forceNavigation;
	}

	// Token: 0x02009506 RID: 38150
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __InputTriggerForNavigation_FunctionParams
	{
		// Token: 0x0403152F RID: 202031
		[FieldOffset(0)]
		public bool triggerPress;
	}

	// Token: 0x02009507 RID: 38151
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 4)]
	protected ref struct __InputScroll_FunctionParams
	{
		// Token: 0x04031530 RID: 202032
		[FieldOffset(0)]
		public float axisValue;
	}

	// Token: 0x02009508 RID: 38152
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 20)]
	protected ref struct __InputTouchTrigger_FunctionParams
	{
		// Token: 0x04031531 RID: 202033
		[FieldOffset(0)]
		public bool touchPress;

		// Token: 0x04031532 RID: 202034
		[FieldOffset(4)]
		public int touchId;

		// Token: 0x04031533 RID: 202035
		[FieldOffset(8)]
		public FVector touchPointPosition;
	}

	// Token: 0x02009509 RID: 38153
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __InputTouchMove_FunctionParams
	{
		// Token: 0x04031534 RID: 202036
		[FieldOffset(0)]
		public int touchId;

		// Token: 0x04031535 RID: 202037
		[FieldOffset(4)]
		public FVector touchPointPosition;
	}

	// Token: 0x0200950A RID: 38154
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __GetNowHitComponent_FunctionParams
	{
		// Token: 0x04031536 RID: 202038
		[FieldOffset(0)]
		public IntPtr __Result;
	}

	// Token: 0x0200950B RID: 38155
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __GetPointerEventData_FunctionParams
	{
		// Token: 0x04031537 RID: 202039
		[FieldOffset(0)]
		public float pointerId;

		// Token: 0x04031538 RID: 202040
		[FieldOffset(4)]
		public bool createIfNotExist;

		// Token: 0x04031539 RID: 202041
		[FieldOffset(8)]
		public IntPtr __Result;
	}

	// Token: 0x0200950C RID: 38156
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __IsPointerEventDataLineTrace_FunctionParams
	{
		// Token: 0x0403153A RID: 202042
		[FieldOffset(0)]
		public IntPtr pointerEventData;

		// Token: 0x0403153B RID: 202043
		[FieldOffset(8)]
		public bool __Result;
	}

	// Token: 0x0200950D RID: 38157
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 1)]
	protected ref struct __SetClickThresholdWithInputKeyType_FunctionParams
	{
		// Token: 0x0403153C RID: 202044
		[FieldOffset(0)]
		public byte inputKeyType;
	}

	// Token: 0x0200950E RID: 38158
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x0403153D RID: 202045
		public static Action<ELGUIPointerInputType> <0>__ChangeController;
	}
}
