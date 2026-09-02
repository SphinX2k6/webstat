using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.UiNavigation;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002CC6 RID: 11462
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[TickController(0)]
public class UiNavigationNewController : UiControllerBase<UiNavigationNewController>
{
	// Token: 0x17001E65 RID: 7781
	// (get) Token: 0x060170EF RID: 94447 RVA: 0x006632B4 File Offset: 0x006614B4
	protected override bool IsTickEvenPausedInternal
	{
		get
		{
			return true;
		}
	}

	// Token: 0x060170F0 RID: 94448 RVA: 0x006632B8 File Offset: 0x006614B8
	[NullableContext(2)]
	private NavigationScrollbarData GetCurrentNavigationScrollbarData()
	{
		UiNavigationViewHandle currentViewHandle = Singleton<UiNavigationViewManager>.Instance.GetCurrentViewHandle();
		if (currentViewHandle == null)
		{
			Singleton<Log>.Instance.Info(ELogModule.UiNavigation, ELogAuthor.XXJ, "[GetCurrentNavigationScrollbarData]查找不到当前的导航句柄", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		return currentViewHandle.GetScrollbarData();
	}

	// Token: 0x060170F1 RID: 94449 RVA: 0x006632FC File Offset: 0x006614FC
	[return: Nullable(2)]
	public unsafe TsUiNavigationBehaviorListener GetCurrentNavigationActiveListenerByTag(string tag, bool isAllowEmpty = false)
	{
		UiNavigationViewHandle currentViewHandle = Singleton<UiNavigationViewManager>.Instance.GetCurrentViewHandle();
		if (currentViewHandle == null)
		{
			Singleton<Log>.Instance.Info(ELogModule.UiNavigation, ELogAuthor.XXJ, "[GetCurrentNavigationActiveListenerByTag]查找不到当前的导航句柄", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		if (!currentViewHandle.GetIsActive())
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiNavigation;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "[GetCurrentNavigationActiveListenerByTag]当前的导航句柄不在显示中";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Tag", tag);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ViewName", currentViewHandle.ViewName);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return null;
		}
		TsUiNavigationBehaviorListener activeListenerByTag = currentViewHandle.GetActiveListenerByTag(tag);
		if (activeListenerByTag == null && !isAllowEmpty)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.UiNavigation;
			ELogAuthor author2 = ELogAuthor.XXJ;
			string message2 = "[GetCurrentNavigationActiveListenerByTag]查找不到对应的按钮";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Tag", tag);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("ViewName", currentViewHandle.ViewName);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return null;
		}
		return activeListenerByTag;
	}

	// Token: 0x060170F2 RID: 94450 RVA: 0x0066340C File Offset: 0x0066160C
	[NullableContext(2)]
	public TsUiNavigationBehaviorListener GetCurrentNavigationFocusListener()
	{
		UiNavigationViewHandle currentViewHandle = Singleton<UiNavigationViewManager>.Instance.GetCurrentViewHandle();
		if (currentViewHandle == null)
		{
			Singleton<Log>.Instance.Info(ELogModule.UiNavigation, ELogAuthor.XXJ, "[GetCurrentNavigationFocusListener]查找不到当前的导航句柄", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		TsUiNavigationBehaviorListener focusListener = currentViewHandle.GetFocusListener();
		if (focusListener == null)
		{
			return null;
		}
		return focusListener;
	}

	// Token: 0x060170F3 RID: 94451 RVA: 0x00663458 File Offset: 0x00661658
	[NullableContext(2)]
	private NavigationGroup GetCurrentNavigationListenerGroup()
	{
		TsUiNavigationBehaviorListener currentNavigationFocusListener = this.GetCurrentNavigationFocusListener();
		if (currentNavigationFocusListener == null)
		{
			return null;
		}
		UiNavigationLogic.MemoryGroupConfigLastSelect(currentNavigationFocusListener);
		NavigationGroup navigationGroup = currentNavigationFocusListener.GetNavigationGroup();
		if (navigationGroup == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.UiNavigation, ELogAuthor.XXJ, "[GetCurrentNavigationListenerGroup]查找不到当前导航的导航组,逻辑上有问题", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		return navigationGroup;
	}

	// Token: 0x060170F4 RID: 94452 RVA: 0x006634A4 File Offset: 0x006616A4
	protected unsafe override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.LoadLguiEventSystemActor, new Action(this.Initialize));
		Singleton<EventSystem>.Instance.Add(EEventName.DestroyLguiEventSystemActor, new Action(this.Destroy));
		Singleton<EventSystem>.Instance.Add<EInputControllerMainType, EInputControllerMainType>(EEventName.InputControllerMainTypeChange, new Action<EInputControllerMainType, EInputControllerMainType>(this.InputControllerMainTypeChange));
		Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
		Singleton<EventSystem>.Instance.Add(EEventName.PointerInputTypeChange, new Action<ELGUIPointerInputType>(this.PointerInputTypeChange));
		int num = 4;
		List<string> list = new List<string>(num);
		CollectionsMarshal.SetCount<string>(list, num);
		Span<string> span = CollectionsMarshal.AsSpan<string>(list);
		int num2 = 0;
		*span[num2] = "UI方向上";
		num2++;
		*span[num2] = "UI方向下";
		num2++;
		*span[num2] = "UI方向左";
		num2++;
		*span[num2] = "UI方向右";
		List<string> actionNames = list;
		ControllerBase<InputDistributeController>.Instance.BindActions(actionNames, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputNavigation));
		ControllerBase<InputDistributeController>.Instance.BindAction("手柄引导下一步", new TInputHandle<InputDistributeDefine.EActionType>(this.OnGuideInputNavigation));
	}

	// Token: 0x060170F5 RID: 94453 RVA: 0x006635CC File Offset: 0x006617CC
	protected unsafe override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.LoadLguiEventSystemActor, new Action(this.Initialize));
		Singleton<EventSystem>.Instance.Remove(EEventName.DestroyLguiEventSystemActor, new Action(this.Destroy));
		Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerMainTypeChange, new Action<EInputControllerMainType, EInputControllerMainType>(this.InputControllerMainTypeChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.PointerInputTypeChange, new Action<ELGUIPointerInputType>(this.PointerInputTypeChange));
		int num = 4;
		List<string> list = new List<string>(num);
		CollectionsMarshal.SetCount<string>(list, num);
		Span<string> span = CollectionsMarshal.AsSpan<string>(list);
		int num2 = 0;
		*span[num2] = "UI方向上";
		num2++;
		*span[num2] = "UI方向下";
		num2++;
		*span[num2] = "UI方向左";
		num2++;
		*span[num2] = "UI方向右";
		List<string> actionNames = list;
		ControllerBase<InputDistributeController>.Instance.UnBindActions(actionNames, new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputNavigation));
		ControllerBase<InputDistributeController>.Instance.UnBindAction("手柄引导下一步", new TInputHandle<InputDistributeDefine.EActionType>(this.OnGuideInputNavigation));
	}

	// Token: 0x060170F6 RID: 94454 RVA: 0x006636F4 File Offset: 0x006618F4
	private void Initialize()
	{
		ULGUIEventSystem lguiEventSystem = Singleton<LguiEventSystemManager>.Instance.LguiEventSystem;
		if (lguiEventSystem == null)
		{
			return;
		}
		UiNavigationLogic.InitNavigationDelegate(Singleton<LguiEventSystemManager>.Instance.LguiEventSystem);
		lguiEventSystem.HighlightWhenMouseMoveOut = ConfigBase<UiNavigationConfig>.Instance.GetHighlightWhenMouseMoveOut();
		UUISelectableComponent.SetShieldMobileHighlight(ConfigBase<UiNavigationConfig>.Instance.GetMobileHighlight());
		UUISelectableComponent.SetShieldPCPress(ConfigBase<UiNavigationConfig>.Instance.GetPcPress());
		ModelBase<InputDistributeModel>.Instance.AddInputDistributeTagChangedListener("UiInputRoot.Navigation", new TInputTagChangedCallback(this.OnNavigationTagChanged));
	}

	// Token: 0x060170F7 RID: 94455 RVA: 0x00663768 File Offset: 0x00661968
	private void Destroy()
	{
		UiNavigationLogic.ClearNavigationDelegate(Singleton<LguiEventSystemManager>.Instance.LguiEventSystem);
		InputDistributeModel instance = ModelBase<InputDistributeModel>.Instance;
		if (instance == null)
		{
			return;
		}
		instance.RemoveInputDistributeTagChangedListener("UiInputRoot.Navigation", new TInputTagChangedCallback(this.OnNavigationTagChanged));
	}

	// Token: 0x060170F8 RID: 94456 RVA: 0x0066379C File Offset: 0x0066199C
	private void OnNavigationTagChanged(string tagName, bool tagExist)
	{
		if (!tagExist)
		{
			Singleton<Log>.Instance.Info(ELogModule.UiNavigation, ELogAuthor.XXJ, "导航的输入分发被删除,需要抬起持续输入的按钮", default(ReadOnlySpan<ValueTuple<string, object>>));
			UiNavigationJoystickInput.ResetJoystickActionInput();
		}
	}

	// Token: 0x060170F9 RID: 94457 RVA: 0x006637D0 File Offset: 0x006619D0
	private void InputControllerMainTypeChange(EInputControllerMainType last, EInputControllerMainType now)
	{
		if (last == EInputControllerMainType.Gamepad || last == EInputControllerMainType.Keyboard)
		{
			Singleton<Log>.Instance.Info(ELogModule.UiNavigation, ELogAuthor.XXJ, "输入总类型发生变更,需要抬起持续输入的按钮", default(ReadOnlySpan<ValueTuple<string, object>>));
			UiNavigationJoystickInput.ResetJoystickActionInput();
		}
	}

	// Token: 0x060170FA RID: 94458 RVA: 0x0066380C File Offset: 0x00661A0C
	private unsafe void InputControllerChange(EInputControllerType last, EInputControllerType now)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.UiNavigation;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "[InputChange]输入类型改变!";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("last", last);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("now", now);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		ModelBase<UiNavigationModel>.Instance.InputControllerModeChange();
		UiNavigationLogic.HandleInputControllerTypeChange();
		UiNavigationLogic.ForceChangeInputType();
		Singleton<UiNavigationViewManager>.Instance.RefreshCurrentHotKey();
	}

	// Token: 0x060170FB RID: 94459 RVA: 0x00663898 File Offset: 0x00661A98
	private void PointerInputTypeChange(ELGUIPointerInputType type)
	{
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.UiNavigation;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "[InputChange]输入类型改变!";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("InputType", type);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		UiNavigationLogic.HandleInputControllerTypeChange();
	}

	// Token: 0x060170FC RID: 94460 RVA: 0x006638E6 File Offset: 0x00661AE6
	private void OnInputNavigation(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
	{
		UiNavigationJoystickInput.TriggerActionInputTick(actionName, actionType);
	}

	// Token: 0x060170FD RID: 94461 RVA: 0x006638F0 File Offset: 0x00661AF0
	private void OnGuideInputNavigation(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
	{
		UiNavigationModel instance = ModelBase<UiNavigationModel>.Instance;
		if (instance == null)
		{
			return;
		}
		if (instance.GuideFocusListener != null)
		{
			this.ClickButtonInternal(instance.GuideFocusListener);
			this.ResetNavigationFocusForGuide();
		}
	}

	// Token: 0x060170FE RID: 94462 RVA: 0x00663921 File Offset: 0x00661B21
	protected override void OnTick(float delta)
	{
		UiNavigationJoystickInput.Tick(delta);
		ModelBase<UiNavigationModel>.Instance.Tick(delta);
	}

	// Token: 0x060170FF RID: 94463 RVA: 0x00663934 File Offset: 0x00661B34
	public void HotKeyCloseView()
	{
		TsUiNavigationBehaviorListener currentNavigationActiveListenerByTag = this.GetCurrentNavigationActiveListenerByTag("tag1", true);
		if (Singleton<Info>.Instance.IsInGamepad() && this.JumpNavigationGroup(ELGUINavigationDirection.Prev))
		{
			UiNavigationLogic.ExecuteInterfaceMethod<INavigationInteractPrevGroup>(currentNavigationActiveListenerByTag.GetNavigationComponent(), "InteractClickPrevGroup", Array.Empty<object>());
			return;
		}
		if (currentNavigationActiveListenerByTag == null)
		{
			return;
		}
		this.ClickButtonInternal(currentNavigationActiveListenerByTag);
	}

	// Token: 0x06017100 RID: 94464 RVA: 0x00663984 File Offset: 0x00661B84
	public void ClickButton(string tag)
	{
		TsUiNavigationBehaviorListener currentNavigationActiveListenerByTag = this.GetCurrentNavigationActiveListenerByTag(tag, true);
		if (currentNavigationActiveListenerByTag == null)
		{
			return;
		}
		this.ClickButtonInternal(currentNavigationActiveListenerByTag);
	}

	// Token: 0x06017101 RID: 94465 RVA: 0x006639A8 File Offset: 0x00661BA8
	public bool SimulateClickItem(UUIItem uiItem, FVector2D? pivot)
	{
		TsLguiEventSystemActor lguiEventSystemActor = Singleton<LguiEventSystemManager>.Instance.LguiEventSystemActor;
		if (lguiEventSystemActor == null)
		{
			return false;
		}
		int pointerId = UiNavigationInputEventData.ActivateInputEventDataOnce();
		return lguiEventSystemActor.SimulateClickButton(pointerId, uiItem, pivot);
	}

	// Token: 0x06017102 RID: 94466 RVA: 0x006639D4 File Offset: 0x00661BD4
	private void ClickButtonInternal(TsUiNavigationBehaviorListener listener)
	{
		if (this.InMaskState())
		{
			return;
		}
		if (!this.SimulateClickItem(listener.GetBehaviorComponent().RootUIComp, new FVector2D?(listener.ClickPivot)))
		{
			UiNavigationLogic.ExecuteInterfaceMethod<INavigationInteractFailClick>(listener.GetNavigationComponent(), "InteractClickFailHandle", Array.Empty<object>());
			return;
		}
		UiNavigationLogic.ExecuteInterfaceMethod<INavigationInteractClick>(listener.GetNavigationComponent(), "InteractClickHandle", Array.Empty<object>());
		UiNavigationModel instance = ModelBase<UiNavigationModel>.Instance;
		if (instance == null)
		{
			return;
		}
		instance.RepeatMove();
	}

	// Token: 0x06017103 RID: 94467 RVA: 0x00663A48 File Offset: 0x00661C48
	public void ClickButtonInside(string tag)
	{
		TsUiNavigationBehaviorListener currentNavigationFocusListener = this.GetCurrentNavigationFocusListener();
		if (currentNavigationFocusListener == null)
		{
			return;
		}
		TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = this.GetFocusListenerInsideListenerByTag(currentNavigationFocusListener, tag);
		if (tsUiNavigationBehaviorListener == null)
		{
			tsUiNavigationBehaviorListener = currentNavigationFocusListener.GetChildListenerByTag(tag);
		}
		if (tsUiNavigationBehaviorListener == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiNavigation;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "[ClickButtonInside]查找不到对应的热键按钮";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Tag", tag);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.ClickButtonInternal(tsUiNavigationBehaviorListener);
	}

	// Token: 0x06017104 RID: 94468 RVA: 0x00663AAC File Offset: 0x00661CAC
	public bool Interact(bool bPress, int configId)
	{
		TsUiNavigationBehaviorListener currentNavigationFocusListener = this.GetCurrentNavigationFocusListener();
		if (currentNavigationFocusListener == null)
		{
			return false;
		}
		if (bPress)
		{
			return this.PointDownUpInternal(currentNavigationFocusListener, true, configId, this.DefaultPivot);
		}
		return this.PointDownUpInternal(currentNavigationFocusListener, false, configId, this.DefaultPivot);
	}

	// Token: 0x06017105 RID: 94469 RVA: 0x00663AE7 File Offset: 0x00661CE7
	[NullableContext(2)]
	public bool InteractRelease(int configId, TsUiNavigationBehaviorListener listener)
	{
		return listener != null && this.PointDownUpInternal(listener, false, configId, this.DefaultPivot);
	}

	// Token: 0x06017106 RID: 94470 RVA: 0x00663B00 File Offset: 0x00661D00
	public void InteractClick()
	{
		TsUiNavigationBehaviorListener currentNavigationFocusListener = this.GetCurrentNavigationFocusListener();
		this.InteractClickByListener(currentNavigationFocusListener);
	}

	// Token: 0x06017107 RID: 94471 RVA: 0x00663B1B File Offset: 0x00661D1B
	[NullableContext(2)]
	public void InteractClickByListener(TsUiNavigationBehaviorListener listener)
	{
		if (listener == null)
		{
			return;
		}
		UiNavigationGlobalData.IsAllowLoopScrollInteractHighlight = true;
		this.ClickButtonInternal(listener);
		UiNavigationGlobalData.IsAllowLoopScrollInteractHighlight = false;
	}

	// Token: 0x06017108 RID: 94472 RVA: 0x00663B34 File Offset: 0x00661D34
	public void FindScrollbar(bool isNext)
	{
		NavigationScrollbarData currentNavigationScrollbarData = this.GetCurrentNavigationScrollbarData();
		if (currentNavigationScrollbarData == null)
		{
			return;
		}
		if (isNext)
		{
			currentNavigationScrollbarData.FindNextScrollbar();
			return;
		}
		currentNavigationScrollbarData.FindPrevScrollbar();
	}

	// Token: 0x06017109 RID: 94473 RVA: 0x00663B5C File Offset: 0x00661D5C
	public void ScrollBarChangeSchedule(float value)
	{
		NavigationScrollbarData currentNavigationScrollbarData = this.GetCurrentNavigationScrollbarData();
		if (currentNavigationScrollbarData == null)
		{
			return;
		}
		UUIScrollViewComponent currentScrollbar = currentNavigationScrollbarData.GetCurrentScrollbar();
		this.HandleScrollbarComponentSetValue(currentScrollbar, value);
	}

	// Token: 0x0601710A RID: 94474 RVA: 0x00663B84 File Offset: 0x00661D84
	public void ScrollBarChangeScheduleByListener(TsUiNavigationBehaviorListener listener, float value)
	{
		UUIScrollViewComponent uuiscrollViewComponent = listener.GetBehaviorComponent() as UUIScrollViewComponent;
		if (uuiscrollViewComponent == null)
		{
			return;
		}
		this.HandleScrollbarComponentSetValue(uuiscrollViewComponent, value);
	}

	// Token: 0x0601710B RID: 94475 RVA: 0x00663BAC File Offset: 0x00661DAC
	public void VerticalScrollBarChangeSchedule(float value)
	{
		NavigationScrollbarData currentNavigationScrollbarData = this.GetCurrentNavigationScrollbarData();
		if (currentNavigationScrollbarData == null)
		{
			return;
		}
		UUIScrollViewComponent currentScrollbar = currentNavigationScrollbarData.GetCurrentScrollbar();
		if (currentScrollbar == null)
		{
			return;
		}
		this.HandleVerticalScrollbarComponentSetValue(currentScrollbar, value);
	}

	// Token: 0x0601710C RID: 94476 RVA: 0x00663BD8 File Offset: 0x00661DD8
	public void HorizontalScrollBarChangeSchedule(float value)
	{
		NavigationScrollbarData currentNavigationScrollbarData = this.GetCurrentNavigationScrollbarData();
		if (currentNavigationScrollbarData == null)
		{
			return;
		}
		UUIScrollViewComponent currentScrollbar = currentNavigationScrollbarData.GetCurrentScrollbar();
		this.HandleHorizontalScrollbarComponentSetValue(currentScrollbar, value);
	}

	// Token: 0x0601710D RID: 94477 RVA: 0x00663C00 File Offset: 0x00661E00
	public void BookMarkNavigation(ELGUINavigationDirection direction, string tag)
	{
		TsUiNavigationBehaviorListener currentNavigationActiveListenerByTag = this.GetCurrentNavigationActiveListenerByTag(tag, false);
		if (currentNavigationActiveListenerByTag == null)
		{
			return;
		}
		NavigationGroup navigationGroup = currentNavigationActiveListenerByTag.GetNavigationGroup();
		if (navigationGroup == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiNavigation;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "[BookMarkNavigation]查找不到对应的导航组";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Tag", tag);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		UUIExtendToggle uuiextendToggle = null;
		List<TsUiNavigationBehaviorListener> canFocusListeners = (from l in navigationGroup.ListenerList
		where l.IsCanFocus()
		select l).ToList<TsUiNavigationBehaviorListener>();
		List<TsUiNavigationBehaviorListener> list = (from l in canFocusListeners
		where l.IsSelectedToggle()
		select l).ToList<TsUiNavigationBehaviorListener>();
		if (list.Count == 1)
		{
			uuiextendToggle = (list[0].GetSelectableComponent() as UUIExtendToggle);
		}
		else if (list.Count > 1)
		{
			List<int> indices = (from l in list
			select canFocusListeners.IndexOf(l) into x
			orderby x
			select x).ToList<int>();
			if (!indices.Select((int val, int idx) => new ValueTuple<int, int>(val, idx)).All(([TupleElementNames(new string[]
			{
				"val",
				"idx"
			})] ValueTuple<int, int> x) => x.Item2 == 0 || x.Item1 == indices[x.Item2 - 1] + 1))
			{
				List<TsUiNavigationBehaviorListener> canFocusListeners2 = canFocusListeners;
				List<int> indices3 = indices;
				uuiextendToggle = (canFocusListeners2[indices3[indices3.Count - 1]].GetSelectableComponent() as UUIExtendToggle);
			}
			else
			{
				int num;
				if (direction != ELGUINavigationDirection.Right && direction != ELGUINavigationDirection.Down && direction != ELGUINavigationDirection.Next)
				{
					num = indices[0];
				}
				else
				{
					List<int> indices2 = indices;
					num = indices2[indices2.Count - 1];
				}
				int index = num;
				uuiextendToggle = (canFocusListeners[index].GetSelectableComponent() as UUIExtendToggle);
			}
		}
		USceneComponent usceneComponent = UiNavigationLogic.TryFindNavigationDelegate(direction, uuiextendToggle);
		object obj;
		if (usceneComponent == null)
		{
			obj = null;
		}
		else
		{
			AActor owner = usceneComponent.GetOwner();
			obj = ((owner != null) ? owner.GetComponentByClass(UUIExtendToggle.StaticClass()) : null);
		}
		UUIExtendToggle uuiextendToggle2 = obj as UUIExtendToggle;
		if (uuiextendToggle2 == null || uuiextendToggle == uuiextendToggle2)
		{
			ELGUINavigationDirection? elguinavigationDirection = null;
			switch (direction)
			{
			case ELGUINavigationDirection.Left:
				elguinavigationDirection = new ELGUINavigationDirection?(ELGUINavigationDirection.Up);
				break;
			case ELGUINavigationDirection.Right:
				elguinavigationDirection = new ELGUINavigationDirection?(ELGUINavigationDirection.Down);
				break;
			case ELGUINavigationDirection.Up:
				elguinavigationDirection = new ELGUINavigationDirection?(ELGUINavigationDirection.Left);
				break;
			case ELGUINavigationDirection.Down:
				elguinavigationDirection = new ELGUINavigationDirection?(ELGUINavigationDirection.Right);
				break;
			default:
				elguinavigationDirection = new ELGUINavigationDirection?(ELGUINavigationDirection.None);
				break;
			}
			USceneComponent usceneComponent2 = UiNavigationLogic.TryFindNavigationDelegate(elguinavigationDirection.Value, uuiextendToggle);
			object obj2;
			if (usceneComponent2 == null)
			{
				obj2 = null;
			}
			else
			{
				AActor owner2 = usceneComponent2.GetOwner();
				obj2 = ((owner2 != null) ? owner2.GetComponentByClass(UUIExtendToggle.StaticClass()) : null);
			}
			uuiextendToggle2 = (obj2 as UUIExtendToggle);
		}
		if (uuiextendToggle2 == null)
		{
			return;
		}
		TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = uuiextendToggle2.GetOwner().GetComponentByClass(TsUiNavigationBehaviorListener.StaticClass()) as TsUiNavigationBehaviorListener;
		if (uuiextendToggle2.bAutoScrollOnSelected && tsUiNavigationBehaviorListener != null)
		{
			UiNavigationScrollProxy scrollProxy = tsUiNavigationBehaviorListener.ScrollProxy;
			bool? flag;
			if (scrollProxy == null)
			{
				flag = null;
			}
			else
			{
				UUIScrollViewWithScrollbarComponent scrollView = scrollProxy.ScrollView;
				flag = ((scrollView != null) ? new bool?(scrollView.IsValid()) : null);
			}
			bool? flag2 = flag;
			if (flag2.GetValueOrDefault())
			{
				this.NavigateScrollTo(tsUiNavigationBehaviorListener);
			}
		}
		this.ClickButtonInternal(tsUiNavigationBehaviorListener);
		if (navigationGroup.RefreshNavigation)
		{
			this.MarkViewHandleRefreshNavigationDirty();
		}
	}

	// Token: 0x0601710E RID: 94478 RVA: 0x00663F3C File Offset: 0x0066213C
	public void MarkViewHandleRefreshNavigationDirty()
	{
		UiNavigationViewHandle currentViewHandle = Singleton<UiNavigationViewManager>.Instance.GetCurrentViewHandle();
		if (currentViewHandle == null)
		{
			return;
		}
		currentViewHandle.MarkRefreshNavigationDirty(0);
	}

	// Token: 0x0601710F RID: 94479 RVA: 0x00663F54 File Offset: 0x00662154
	public void MarkViewHandleRefreshNavigationDirtyByGroupItem(UUIItem uiItem)
	{
		TsUiNavigationPanelConfig tsUiNavigationPanelConfig = uiItem.GetOwner().GetComponentByClass(TsUiNavigationPanelConfig.StaticClass()) as TsUiNavigationPanelConfig;
		if (tsUiNavigationPanelConfig != null)
		{
			UiNavigationViewHandle viewHandle = tsUiNavigationPanelConfig.ViewHandle;
			if (viewHandle == null)
			{
				return;
			}
			viewHandle.MarkRefreshNavigationDirty(0);
		}
	}

	// Token: 0x06017110 RID: 94480 RVA: 0x00663F90 File Offset: 0x00662190
	public bool JumpNavigationGroupByTag(string tag)
	{
		NavigationGroup currentNavigationListenerGroup = this.GetCurrentNavigationListenerGroup();
		if (currentNavigationListenerGroup == null)
		{
			return false;
		}
		if (StringUtils.IsBlank(tag))
		{
			return this.JumpNavigationGroup(ELGUINavigationDirection.Next);
		}
		string text;
		string nextGroupName = currentNavigationListenerGroup.GroupNameMap.TryGetValue(tag, out text) ? text : string.Empty;
		return this.JumpNavigationGroupByName(currentNavigationListenerGroup.GroupName, nextGroupName);
	}

	// Token: 0x06017111 RID: 94481 RVA: 0x00663FE0 File Offset: 0x006621E0
	public bool JumpNavigationGroupByName(string lastGroupName, string nextGroupName)
	{
		UiNavigationViewHandle currentViewHandle = Singleton<UiNavigationViewManager>.Instance.GetCurrentViewHandle();
		bool flag = this.ChangeFocusListenerByGroupName(currentViewHandle, nextGroupName);
		if (flag)
		{
			NavigationGroup activeNavigationGroupByNameCheckAll = currentViewHandle.GetActiveNavigationGroupByNameCheckAll(nextGroupName);
			if (activeNavigationGroupByNameCheckAll != null)
			{
				activeNavigationGroupByNameCheckAll.PrevGroupName = lastGroupName;
			}
		}
		return flag;
	}

	// Token: 0x06017112 RID: 94482 RVA: 0x00664018 File Offset: 0x00662218
	public bool JumpNavigationGroup(ELGUINavigationDirection direction)
	{
		NavigationGroup currentNavigationListenerGroup = this.GetCurrentNavigationListenerGroup();
		if (currentNavigationListenerGroup == null)
		{
			return false;
		}
		UiNavigationViewHandle currentViewHandle = Singleton<UiNavigationViewManager>.Instance.GetCurrentViewHandle();
		if (direction == ELGUINavigationDirection.Next)
		{
			return this.ChangeFocusListenerByGroupName(currentViewHandle, currentNavigationListenerGroup.NextGroupName);
		}
		if (direction != ELGUINavigationDirection.Prev)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiNavigation;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "导航组跳转方向错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("direction", direction);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		bool flag = this.ChangeFocusListenerByGroupName(currentViewHandle, currentNavigationListenerGroup.PrevGroupName);
		if (flag && currentNavigationListenerGroup.SelectableMemory)
		{
			currentNavigationListenerGroup.LastSelectListener = null;
		}
		return flag;
	}

	// Token: 0x06017113 RID: 94483 RVA: 0x006640A4 File Offset: 0x006622A4
	private bool ChangeFocusListenerByGroupName(UiNavigationViewHandle viewHandle, string groupName)
	{
		if (UiNavigationGlobalData.IsBlockNavigation)
		{
			return false;
		}
		NavigationGroup activeNavigationGroupByNameCheckAll = viewHandle.GetActiveNavigationGroupByNameCheckAll(groupName);
		if (activeNavigationGroupByNameCheckAll == null)
		{
			return false;
		}
		TsUiNavigationBehaviorListener canNavigationListenerInGroup = this.GetCanNavigationListenerInGroup(activeNavigationGroupByNameCheckAll);
		if (canNavigationListenerInGroup == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiNavigation;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "[ChangeFocusListenerByGroupName]找不到可跳转的导航对象";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("GroupName", groupName);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		this.NavigateScrollTo(canNavigationListenerInGroup);
		this.SwitchNavigationFocus(canNavigationListenerInGroup);
		return true;
	}

	// Token: 0x06017114 RID: 94484 RVA: 0x00664110 File Offset: 0x00662310
	private void NavigateScrollTo(TsUiNavigationBehaviorListener listener)
	{
		UiNavigationScrollProxy scrollProxy = listener.ScrollProxy;
		if (((scrollProxy != null) ? scrollProxy.ScrollView : null) == null)
		{
			return;
		}
		UUISelectableComponent selectableComponent = listener.GetSelectableComponent();
		if (selectableComponent == null)
		{
			return;
		}
		listener.ScrollProxy.ScrollView.ScrollTo(selectableComponent.GetRootComponent(), false);
	}

	// Token: 0x06017115 RID: 94485 RVA: 0x00664154 File Offset: 0x00662354
	[return: Nullable(2)]
	private TsUiNavigationBehaviorListener GetCanNavigationListenerInGroup(NavigationGroup groupConfig)
	{
		if (groupConfig == null)
		{
			Singleton<Log>.Instance.Info(ELogModule.UiNavigation, ELogAuthor.XXJ, "[GetActiveListenerInGroup]找不到导航组", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		if (groupConfig.SelectableMemory && groupConfig.LastSelectListener != null)
		{
			TsUiNavigationBehaviorListener lastSelectListener = groupConfig.LastSelectListener;
			if (lastSelectListener.IsCanFocus())
			{
				return lastSelectListener;
			}
		}
		return this.FindListenerByGroupConfig(groupConfig);
	}

	// Token: 0x06017116 RID: 94486 RVA: 0x006641B0 File Offset: 0x006623B0
	[NullableContext(2)]
	private static TsUiNavigationBehaviorListener GetLastCanNavigationListenerInGroup(NavigationGroup groupConfig)
	{
		if (groupConfig == null)
		{
			Singleton<Log>.Instance.Info(ELogModule.UiNavigation, ELogAuthor.XXJ, "[GetLastCanNavigationListenerInGroup]找不到导航组", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		List<TsUiNavigationBehaviorListener> listenerList = groupConfig.ListenerList;
		if (listenerList.Count <= 0)
		{
			return null;
		}
		List<TsUiNavigationBehaviorListener> list = new List<TsUiNavigationBehaviorListener>(listenerList);
		list.Sort((TsUiNavigationBehaviorListener a, TsUiNavigationBehaviorListener b) => b.RootUIComp.Get().GetFlattenHierarchyIndex().CompareTo(a.RootUIComp.Get().GetFlattenHierarchyIndex()));
		for (int i = 0; i < list.Count; i++)
		{
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = list[i];
			if (tsUiNavigationBehaviorListener.IsCanFocus())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiNavigation;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "[GetLastCanNavigationListenerInGroup]找到最后一个可导航对象";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("i", i);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return tsUiNavigationBehaviorListener;
			}
		}
		return null;
	}

	// Token: 0x06017117 RID: 94487 RVA: 0x0066427C File Offset: 0x0066247C
	[return: Nullable(2)]
	private TsUiNavigationBehaviorListener FindListenerByGroupConfig(NavigationGroup groupConfig)
	{
		if (groupConfig.DefaultListener != null)
		{
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = groupConfig.DefaultListener;
			if (tsUiNavigationBehaviorListener.IsIgnoreScrollOrLayoutCheckInSwitchGroup())
			{
				return this.FindLoopOrLayoutListener(groupConfig);
			}
			if (tsUiNavigationBehaviorListener.GetNavigationGroup() != null && tsUiNavigationBehaviorListener.GetNavigationGroup().SuitableListenerByNoDynamic)
			{
				TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener2 = this.FindSuitableListenerWithoutLayout(groupConfig);
				if (tsUiNavigationBehaviorListener2 != null)
				{
					tsUiNavigationBehaviorListener = tsUiNavigationBehaviorListener2;
				}
			}
			if (!tsUiNavigationBehaviorListener.IsScrollOrLayoutActor() && tsUiNavigationBehaviorListener.IsCanFocus())
			{
				return tsUiNavigationBehaviorListener;
			}
		}
		return this.FindLoopOrDynListener(groupConfig);
	}

	// Token: 0x06017118 RID: 94488 RVA: 0x006642E4 File Offset: 0x006624E4
	[return: Nullable(2)]
	public TsUiNavigationBehaviorListener FindLoopOrDynListener(NavigationGroup groupConfig)
	{
		TsUiNavigationBehaviorListener defaultListener = groupConfig.DefaultListener;
		if (defaultListener != null)
		{
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = this.FindLoopOrLayoutListenerWithDefault(groupConfig, defaultListener);
			if (tsUiNavigationBehaviorListener != null)
			{
				return tsUiNavigationBehaviorListener;
			}
		}
		return this.FindLoopOrLayoutListener(groupConfig);
	}

	// Token: 0x06017119 RID: 94489 RVA: 0x00664310 File Offset: 0x00662510
	[return: Nullable(2)]
	private TsUiNavigationBehaviorListener FindDynListenerWithoutDefault(NavigationGroup groupConfig, TsUiNavigationBehaviorListener defaultListener)
	{
		TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = null;
		UiNavigationScrollProxy scrollProxy = defaultListener.ScrollProxy;
		TArray<TWeakObjectPtr<AUIBaseActor>> displayItemArray = (((scrollProxy != null) ? scrollProxy.ScrollView : null) as UUIDynScrollViewComponent).DisplayItemArray;
		int i = 0;
		int num = displayItemArray.Num();
		while (i < num)
		{
			TWeakObjectPtr<AUIBaseActor> weak = displayItemArray.Get(i);
			List<TsUiNavigationBehaviorListener> dynListenerListInGroup = this.GetDynListenerListInGroup(weak, groupConfig);
			if (dynListenerListInGroup.Count != 0)
			{
				int j = 0;
				int count = dynListenerListInGroup.Count;
				while (j < count)
				{
					TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener2 = dynListenerListInGroup[j];
					if (tsUiNavigationBehaviorListener == null && tsUiNavigationBehaviorListener2.IsCanFocus())
					{
						tsUiNavigationBehaviorListener = tsUiNavigationBehaviorListener2;
					}
					if (tsUiNavigationBehaviorListener2.IsInDynScrollDisplay() && tsUiNavigationBehaviorListener2.IsInScrollOrLayoutCanFocus())
					{
						return tsUiNavigationBehaviorListener2;
					}
					j++;
				}
			}
			i++;
		}
		return tsUiNavigationBehaviorListener;
	}

	// Token: 0x0601711A RID: 94490 RVA: 0x006643BC File Offset: 0x006625BC
	[return: Nullable(2)]
	private TsUiNavigationBehaviorListener FindMultiTemplateScrollListenerWithoutDefault(NavigationGroup groupConfig, TsUiNavigationBehaviorListener defaultListener)
	{
		TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = null;
		AActor scrollOrLayoutActor = defaultListener.GetScrollOrLayoutActor();
		List<TsUiNavigationBehaviorListener> multiTemplateScrollSortListenerList = groupConfig.MultiTemplateScrollSortListenerList;
		int i = 0;
		int count = multiTemplateScrollSortListenerList.Count;
		while (i < count)
		{
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener2 = multiTemplateScrollSortListenerList[i];
			if (tsUiNavigationBehaviorListener == null && tsUiNavigationBehaviorListener2.IsCanFocus())
			{
				tsUiNavigationBehaviorListener = tsUiNavigationBehaviorListener2;
			}
			if (tsUiNavigationBehaviorListener2.IsInScrollDisplayByGridActor() && (scrollOrLayoutActor == null || tsUiNavigationBehaviorListener2.GetScrollOrLayoutActor() == scrollOrLayoutActor) && tsUiNavigationBehaviorListener2.IsInScrollOrLayoutCanFocus())
			{
				return tsUiNavigationBehaviorListener2;
			}
			i++;
		}
		return tsUiNavigationBehaviorListener;
	}

	// Token: 0x0601711B RID: 94491 RVA: 0x00664429 File Offset: 0x00662629
	[return: Nullable(2)]
	private TsUiNavigationBehaviorListener FindLoopOrLayoutListenerWithoutDefault(NavigationGroup groupConfig, TsUiNavigationBehaviorListener listener)
	{
		if (listener.HasDynamicScrollView())
		{
			return this.FindDynListenerWithoutDefault(groupConfig, listener);
		}
		if (listener.HasMultiTemplateScrollView())
		{
			return this.FindMultiTemplateScrollListenerWithoutDefault(groupConfig, listener);
		}
		if (listener.IsInScrollOrLayoutCanFocus())
		{
			return listener;
		}
		return null;
	}

	// Token: 0x0601711C RID: 94492 RVA: 0x00664458 File Offset: 0x00662658
	[return: Nullable(2)]
	private TsUiNavigationBehaviorListener FindLoopOrLayoutListener(NavigationGroup groupConfig)
	{
		TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = null;
		int i = 0;
		int count = groupConfig.ListenerList.Count;
		while (i < count)
		{
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener2 = groupConfig.ListenerList[i];
			if (tsUiNavigationBehaviorListener == null && tsUiNavigationBehaviorListener2.IsCanFocus())
			{
				tsUiNavigationBehaviorListener = tsUiNavigationBehaviorListener2;
			}
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener3 = this.FindLoopOrLayoutListenerWithoutDefault(groupConfig, tsUiNavigationBehaviorListener2);
			if (tsUiNavigationBehaviorListener3 != null)
			{
				return tsUiNavigationBehaviorListener3;
			}
			i++;
		}
		return tsUiNavigationBehaviorListener;
	}

	// Token: 0x0601711D RID: 94493 RVA: 0x006644AB File Offset: 0x006626AB
	[return: Nullable(2)]
	private TsUiNavigationBehaviorListener FindLoopOrLayoutListenerWithDefault(NavigationGroup groupConfig, TsUiNavigationBehaviorListener defaultListener)
	{
		if (defaultListener.HasDynamicScrollView())
		{
			return this.FindDynListenerWithDefault(groupConfig, defaultListener);
		}
		if (defaultListener.HasMultiTemplateScrollView())
		{
			return this.FindMultiTemplateScrollListenerWithDefault(groupConfig, defaultListener);
		}
		return this.FindLoopListenerWithDefault(groupConfig, defaultListener);
	}

	// Token: 0x0601711E RID: 94494 RVA: 0x006644D8 File Offset: 0x006626D8
	private List<TsUiNavigationBehaviorListener> GetDynListenerListInGroup(AUIBaseActor baseActor, NavigationGroup groupConfig)
	{
		TArray<UActorComponent> componentsInChildren = ULGUIBPLibrary.GetComponentsInChildren(baseActor, TsUiNavigationBehaviorListener.StaticClass(), true);
		List<TsUiNavigationBehaviorListener> list = new List<TsUiNavigationBehaviorListener>();
		for (int i = componentsInChildren.Num() - 1; i >= 0; i--)
		{
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = componentsInChildren.Get(i) as TsUiNavigationBehaviorListener;
			if (tsUiNavigationBehaviorListener.GroupName == groupConfig.GroupName && tsUiNavigationBehaviorListener.IsCanFocus())
			{
				list.Add(tsUiNavigationBehaviorListener);
			}
		}
		return list;
	}

	// Token: 0x0601711F RID: 94495 RVA: 0x00664540 File Offset: 0x00662740
	[return: Nullable(2)]
	private TsUiNavigationBehaviorListener FindDynListenerWithDefault(NavigationGroup groupConfig, TsUiNavigationBehaviorListener defaultListener)
	{
		TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = null;
		UiNavigationScrollProxy scrollProxy = defaultListener.ScrollProxy;
		TArray<TWeakObjectPtr<AUIBaseActor>> displayItemArray = (((scrollProxy != null) ? scrollProxy.ScrollView : null) as UUIDynScrollViewComponent).DisplayItemArray;
		int i = 0;
		int num = displayItemArray.Num();
		while (i < num)
		{
			List<TsUiNavigationBehaviorListener> dynListenerListInGroup = this.GetDynListenerListInGroup(displayItemArray.Get(i).Get(), groupConfig);
			if (dynListenerListInGroup.Count != 0)
			{
				int j = 0;
				int count = dynListenerListInGroup.Count;
				while (j < count)
				{
					TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener2 = dynListenerListInGroup[j];
					if (tsUiNavigationBehaviorListener2.IsInDynScrollDisplay() && tsUiNavigationBehaviorListener2.IsScrollOrLayoutActor())
					{
						if (tsUiNavigationBehaviorListener == null && tsUiNavigationBehaviorListener2.IsCanFocus())
						{
							tsUiNavigationBehaviorListener = tsUiNavigationBehaviorListener2;
						}
						if (tsUiNavigationBehaviorListener2.IsInScrollOrLayoutCanFocus())
						{
							return tsUiNavigationBehaviorListener2;
						}
					}
					j++;
				}
			}
			i++;
		}
		return tsUiNavigationBehaviorListener;
	}

	// Token: 0x06017120 RID: 94496 RVA: 0x006645F4 File Offset: 0x006627F4
	[return: Nullable(2)]
	private TsUiNavigationBehaviorListener FindLoopListenerWithDefault(NavigationGroup groupConfig, TsUiNavigationBehaviorListener defaultListener)
	{
		TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = null;
		AActor scrollOrLayoutActor = defaultListener.GetScrollOrLayoutActor();
		List<TsUiNavigationBehaviorListener> loopScrollSortListenerList = groupConfig.LoopScrollSortListenerList;
		int i = 0;
		int count = loopScrollSortListenerList.Count;
		while (i < count)
		{
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener2 = loopScrollSortListenerList[i];
			if (tsUiNavigationBehaviorListener2.IsScrollOrLayoutActor() && tsUiNavigationBehaviorListener2.IsInNormalScrollDisplayByGridActor() && tsUiNavigationBehaviorListener2.IsInLoopScrollDisplayByGridActor())
			{
				if (tsUiNavigationBehaviorListener == null && tsUiNavigationBehaviorListener2.IsCanFocus())
				{
					tsUiNavigationBehaviorListener = tsUiNavigationBehaviorListener2;
				}
				if ((scrollOrLayoutActor == null || tsUiNavigationBehaviorListener2.GetScrollOrLayoutActor() == scrollOrLayoutActor) && tsUiNavigationBehaviorListener2.IsInScrollOrLayoutCanFocus())
				{
					return tsUiNavigationBehaviorListener2;
				}
			}
			i++;
		}
		return tsUiNavigationBehaviorListener;
	}

	// Token: 0x06017121 RID: 94497 RVA: 0x00664674 File Offset: 0x00662874
	[return: Nullable(2)]
	private TsUiNavigationBehaviorListener FindMultiTemplateScrollListenerWithDefault(NavigationGroup groupConfig, TsUiNavigationBehaviorListener defaultListener)
	{
		TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = null;
		AActor scrollOrLayoutActor = defaultListener.GetScrollOrLayoutActor();
		List<TsUiNavigationBehaviorListener> multiTemplateScrollSortListenerList = groupConfig.MultiTemplateScrollSortListenerList;
		int i = 0;
		int count = multiTemplateScrollSortListenerList.Count;
		while (i < count)
		{
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener2 = multiTemplateScrollSortListenerList[i];
			if (tsUiNavigationBehaviorListener2.IsScrollOrLayoutActor() && tsUiNavigationBehaviorListener2.IsInScrollDisplayByGridActor())
			{
				if (tsUiNavigationBehaviorListener == null && tsUiNavigationBehaviorListener2.IsCanFocus())
				{
					tsUiNavigationBehaviorListener = tsUiNavigationBehaviorListener2;
				}
				if ((scrollOrLayoutActor == null || tsUiNavigationBehaviorListener2.GetScrollOrLayoutActor() == scrollOrLayoutActor) && tsUiNavigationBehaviorListener2.IsInScrollOrLayoutCanFocus())
				{
					return tsUiNavigationBehaviorListener2;
				}
			}
			i++;
		}
		return tsUiNavigationBehaviorListener;
	}

	// Token: 0x06017122 RID: 94498 RVA: 0x006646EC File Offset: 0x006628EC
	[return: Nullable(2)]
	public TsUiNavigationBehaviorListener FindSuitableListenerWithoutLayout(NavigationGroup groupConfig)
	{
		TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = null;
		int i = 0;
		int count = groupConfig.ListenerList.Count;
		while (i < count)
		{
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener2 = groupConfig.ListenerList[i];
			if (tsUiNavigationBehaviorListener == null && tsUiNavigationBehaviorListener2.IsCanFocus())
			{
				tsUiNavigationBehaviorListener = tsUiNavigationBehaviorListener2;
			}
			if (tsUiNavigationBehaviorListener2.IsInScrollOrLayoutCanFocus())
			{
				return tsUiNavigationBehaviorListener2;
			}
			i++;
		}
		return tsUiNavigationBehaviorListener;
	}

	// Token: 0x06017123 RID: 94499 RVA: 0x00664738 File Offset: 0x00662938
	[return: Nullable(2)]
	public TsUiNavigationBehaviorListener GetCanFocusInsideListener(TsUiNavigationBehaviorListener listener)
	{
		HashSet<string> insideGroupNameSet = listener.GetNavigationGroup().InsideGroupNameSet;
		TArray<UActorComponent> componentsInChildrenWithHirerarchyIndex = ULGUIBPLibrary.GetComponentsInChildrenWithHirerarchyIndex(listener.InsideGroupActor as AUIBaseActor, TsUiNavigationBehaviorListener.StaticClass(), true);
		if (componentsInChildrenWithHirerarchyIndex == null)
		{
			return null;
		}
		int i = 0;
		int num = componentsInChildrenWithHirerarchyIndex.Num();
		while (i < num)
		{
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = componentsInChildrenWithHirerarchyIndex.Get(i) as TsUiNavigationBehaviorListener;
			if (!StringUtils.IsEmpty(tsUiNavigationBehaviorListener.GroupName) && insideGroupNameSet.Contains(tsUiNavigationBehaviorListener.GroupName) && tsUiNavigationBehaviorListener.IsCanFocus())
			{
				return tsUiNavigationBehaviorListener;
			}
			i++;
		}
		return null;
	}

	// Token: 0x06017124 RID: 94500 RVA: 0x006647C0 File Offset: 0x006629C0
	public List<TsUiNavigationBehaviorListener> GetCanFocusInsideListenerList(TsUiNavigationBehaviorListener listener)
	{
		HashSet<string> insideGroupNameSet = listener.GetNavigationGroup().InsideGroupNameSet;
		TArray<UActorComponent> componentsInChildrenWithHirerarchyIndex = ULGUIBPLibrary.GetComponentsInChildrenWithHirerarchyIndex(listener.InsideGroupActor as AUIBaseActor, TsUiNavigationBehaviorListener.StaticClass(), true);
		if (componentsInChildrenWithHirerarchyIndex == null)
		{
			return new List<TsUiNavigationBehaviorListener>();
		}
		List<TsUiNavigationBehaviorListener> list = new List<TsUiNavigationBehaviorListener>();
		int i = 0;
		int num = componentsInChildrenWithHirerarchyIndex.Num();
		while (i < num)
		{
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = componentsInChildrenWithHirerarchyIndex.Get(i) as TsUiNavigationBehaviorListener;
			if (!StringUtils.IsEmpty(tsUiNavigationBehaviorListener.GroupName) && insideGroupNameSet.Contains(tsUiNavigationBehaviorListener.GroupName) && tsUiNavigationBehaviorListener.IsCanFocus())
			{
				list.Add(tsUiNavigationBehaviorListener);
			}
			i++;
		}
		return list;
	}

	// Token: 0x06017125 RID: 94501 RVA: 0x00664858 File Offset: 0x00662A58
	public bool IsInFocusInsideListenerList(TsUiNavigationBehaviorListener parent, TsUiNavigationBehaviorListener target)
	{
		if (StringUtils.IsEmpty(target.GroupName))
		{
			return false;
		}
		HashSet<string> insideGroupNameSet = parent.GetNavigationGroup().InsideGroupNameSet;
		TArray<UActorComponent> componentsInChildren = ULGUIBPLibrary.GetComponentsInChildren(parent.InsideGroupActor, TsUiNavigationBehaviorListener.StaticClass(), true);
		return componentsInChildren != null && insideGroupNameSet.Contains(target.GroupName) && componentsInChildren.Contains(target);
	}

	// Token: 0x06017126 RID: 94502 RVA: 0x006648B4 File Offset: 0x00662AB4
	public void JumpInsideNavigationGroup()
	{
		NavigationGroup currentNavigationListenerGroup = this.GetCurrentNavigationListenerGroup();
		if (currentNavigationListenerGroup == null)
		{
			return;
		}
		TsUiNavigationBehaviorListener currentNavigationFocusListener = this.GetCurrentNavigationFocusListener();
		TsUiNavigationBehaviorListener canFocusInsideListener = this.GetCanFocusInsideListener(currentNavigationFocusListener);
		if (canFocusInsideListener == null)
		{
			List<string> list = new List<string>();
			foreach (string item in currentNavigationListenerGroup.InsideGroupNameSet)
			{
				list.Add(item);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiNavigation;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "[JumpInsideNavigationGroup]查找不到内部有可导航对象";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("InsideGroupName", list.ToArray());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.SwitchNavigationFocus(canFocusInsideListener);
	}

	// Token: 0x06017127 RID: 94503 RVA: 0x00664968 File Offset: 0x00662B68
	public void SimulationPointUp(string tag, int configId, Vector2D pivot = null)
	{
		pivot = (pivot ?? this.DefaultPivot);
		TsUiNavigationBehaviorListener currentNavigationActiveListenerByTag = this.GetCurrentNavigationActiveListenerByTag(tag, true);
		if (currentNavigationActiveListenerByTag == null)
		{
			TsLguiEventSystemActor lguiEventSystemActor = Singleton<LguiEventSystemManager>.Instance.LguiEventSystemActor;
			if (lguiEventSystemActor != null)
			{
				List<int> list = UiNavigationInputEventData.TryClearUnValidData();
				int i = 0;
				int count = list.Count;
				while (i < count)
				{
					int pointerId = list[i];
					lguiEventSystemActor.ResetNowIsTriggerPressed(pointerId);
					i++;
				}
			}
			return;
		}
		this.PointDownUpInternal(currentNavigationActiveListenerByTag, false, configId, pivot);
	}

	// Token: 0x06017128 RID: 94504 RVA: 0x006649D4 File Offset: 0x00662BD4
	public void SimulationPointUpInside(string tag, int configId, [Nullable(2)] TsUiNavigationBehaviorListener listener)
	{
		if (listener != null)
		{
			this.PointDownUpInternal(listener, false, configId, this.DefaultPivot);
			return;
		}
		TsUiNavigationBehaviorListener currentNavigationFocusListener = this.GetCurrentNavigationFocusListener();
		if (currentNavigationFocusListener == null)
		{
			return;
		}
		TsUiNavigationBehaviorListener childListenerByTag = currentNavigationFocusListener.GetChildListenerByTag(tag);
		if (childListenerByTag == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiNavigation;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "[SimulationPointUpInside]查找不到对应的热键按钮";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Tag", tag);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.PointDownUpInternal(childListenerByTag, false, configId, this.DefaultPivot);
	}

	// Token: 0x06017129 RID: 94505 RVA: 0x00664A48 File Offset: 0x00662C48
	private bool PointDownUpInternal(TsUiNavigationBehaviorListener listener, bool isPress, int configId, Vector2D pivot)
	{
		if (isPress && this.InMaskState())
		{
			return false;
		}
		TsLguiEventSystemActor lguiEventSystemActor = Singleton<LguiEventSystemManager>.Instance.LguiEventSystemActor;
		if (lguiEventSystemActor == null)
		{
			return false;
		}
		if (isPress)
		{
			int pointerId = UiNavigationInputEventData.CreateInputEventData(configId, listener);
			return lguiEventSystemActor.SimulationPointerDownUp(pointerId, listener.RootUIComp, true, pivot.ToUeVector2D(false));
		}
		int pointerId2 = UiNavigationInputEventData.RecycleInputEventData(configId, listener);
		return lguiEventSystemActor.SimulationPointerDownUp(pointerId2, listener.RootUIComp, false, pivot.ToUeVector2D(false));
	}

	// Token: 0x0601712A RID: 94506 RVA: 0x00664ABC File Offset: 0x00662CBC
	[NullableContext(2)]
	public bool GamepadInteractSimulationPointer(ULGUIBehaviour selectableComponent, bool isPress)
	{
		if (selectableComponent == null)
		{
			return false;
		}
		TsLguiEventSystemActor lguiEventSystemActor = Singleton<LguiEventSystemManager>.Instance.LguiEventSystemActor;
		return lguiEventSystemActor != null && lguiEventSystemActor.SimulationPointerDownUp(0, selectableComponent.RootUIComp, isPress, this.DefaultPivot.ToUeVector2D(false));
	}

	// Token: 0x0601712B RID: 94507 RVA: 0x00664B00 File Offset: 0x00662D00
	public void SimulationPointDown(string tag, int configId, Vector2D pivot = null)
	{
		pivot = (pivot ?? this.DefaultPivot);
		TsUiNavigationBehaviorListener currentNavigationActiveListenerByTag = this.GetCurrentNavigationActiveListenerByTag(tag, true);
		if (currentNavigationActiveListenerByTag == null)
		{
			return;
		}
		this.PointDownUpInternal(currentNavigationActiveListenerByTag, true, configId, pivot);
	}

	// Token: 0x0601712C RID: 94508 RVA: 0x00664B34 File Offset: 0x00662D34
	[return: Nullable(2)]
	public TsUiNavigationBehaviorListener SimulationPointDownInside(string tag, int configId)
	{
		TsUiNavigationBehaviorListener currentNavigationFocusListener = this.GetCurrentNavigationFocusListener();
		if (currentNavigationFocusListener == null)
		{
			return null;
		}
		TsUiNavigationBehaviorListener childListenerByTag = currentNavigationFocusListener.GetChildListenerByTag(tag);
		if (childListenerByTag == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiNavigation;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "[SimulationPointDownInside]查找不到对应的热键按钮";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Tag", tag);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		this.PointDownUpInternal(childListenerByTag, true, configId, this.DefaultPivot);
		return childListenerByTag;
	}

	// Token: 0x0601712D RID: 94509 RVA: 0x00664B98 File Offset: 0x00662D98
	public void FindTarget(ELGUINavigationDirection direction)
	{
		TsUiNavigationBehaviorListener currentNavigationFocusListener = this.GetCurrentNavigationFocusListener();
		if (currentNavigationFocusListener == null)
		{
			return;
		}
		UUISelectableComponent selectableComponent = currentNavigationFocusListener.GetSelectableComponent();
		USceneComponent usceneComponent = UiNavigationLogic.TryFindNavigationDelegate(direction, selectableComponent);
		if (usceneComponent == selectableComponent.RootUIComp.Get())
		{
			return;
		}
		TsUiNavigationBehaviorListener listener = usceneComponent.GetOwner().GetComponentByClass(TsUiNavigationBehaviorListener.StaticClass()) as TsUiNavigationBehaviorListener;
		this.NavigateScrollTo(listener);
	}

	// Token: 0x0601712E RID: 94510 RVA: 0x00664BF4 File Offset: 0x00662DF4
	public void SliderComponentSetValue(string tag, float value)
	{
		TsUiNavigationBehaviorListener currentNavigationActiveListenerByTag = this.GetCurrentNavigationActiveListenerByTag(tag, false);
		if (currentNavigationActiveListenerByTag == null)
		{
			return;
		}
		this.HandleSliderComponentValue(currentNavigationActiveListenerByTag.GetSelectableComponent(), value);
	}

	// Token: 0x0601712F RID: 94511 RVA: 0x00664C1C File Offset: 0x00662E1C
	public void SliderInsideComponentSetValue(string tag, float value)
	{
		TsUiNavigationBehaviorListener currentNavigationFocusListener = this.GetCurrentNavigationFocusListener();
		if (currentNavigationFocusListener == null)
		{
			return;
		}
		TsUiNavigationBehaviorListener focusListenerInsideListenerByTag = this.GetFocusListenerInsideListenerByTag(currentNavigationFocusListener, tag);
		if (focusListenerInsideListenerByTag == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiNavigation;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "[SliderInsideComponentSetValue]查找不到对应的热键按钮";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Tag", tag);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.HandleSliderComponentValue(focusListenerInsideListenerByTag.GetSelectableComponent(), value);
	}

	// Token: 0x06017130 RID: 94512 RVA: 0x00664C78 File Offset: 0x00662E78
	public void ScrollbarInsideComponentSetValue(string tag, float value)
	{
		TsUiNavigationBehaviorListener currentNavigationFocusListener = this.GetCurrentNavigationFocusListener();
		if (currentNavigationFocusListener == null)
		{
			return;
		}
		TsUiNavigationBehaviorListener focusListenerInsideListenerByTag = this.GetFocusListenerInsideListenerByTag(currentNavigationFocusListener, tag);
		if (focusListenerInsideListenerByTag == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiNavigation;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "[ScrollbarInsideComponentSetValue]查找不到对应的热键按钮";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Tag", tag);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.HandleScrollbarComponentSetValue(focusListenerInsideListenerByTag.GetBehaviorComponent(), value);
	}

	// Token: 0x06017131 RID: 94513 RVA: 0x00664CD4 File Offset: 0x00662ED4
	private void HandleScrollbarComponentSetValue(ULGUIBehaviour behavior, float value)
	{
		UUIScrollViewComponent uuiscrollViewComponent = behavior as UUIScrollViewComponent;
		if (uuiscrollViewComponent != null)
		{
			if (uuiscrollViewComponent.Vertical)
			{
				uuiscrollViewComponent.SetVelocity(value * 800f);
				return;
			}
			uuiscrollViewComponent.SetVelocity(-value * 800f);
		}
	}

	// Token: 0x06017132 RID: 94514 RVA: 0x00664D10 File Offset: 0x00662F10
	private void HandleVerticalScrollbarComponentSetValue(ULGUIBehaviour behavior, float value)
	{
		UUIScrollViewComponent uuiscrollViewComponent = behavior as UUIScrollViewComponent;
		if (uuiscrollViewComponent != null)
		{
			uuiscrollViewComponent.SetVerticalVelocity(value * 800f);
		}
	}

	// Token: 0x06017133 RID: 94515 RVA: 0x00664D34 File Offset: 0x00662F34
	private void HandleHorizontalScrollbarComponentSetValue(ULGUIBehaviour behavior, float value)
	{
		UUIScrollViewComponent uuiscrollViewComponent = behavior as UUIScrollViewComponent;
		if (uuiscrollViewComponent != null)
		{
			uuiscrollViewComponent.SetHorizontalVelocity(value * 800f);
		}
	}

	// Token: 0x06017134 RID: 94516 RVA: 0x00664D58 File Offset: 0x00662F58
	private void HandleSliderComponentValue(UUISelectableComponent selectableComponent, float value)
	{
		UUISliderComponent uuisliderComponent = selectableComponent as UUISliderComponent;
		if (uuisliderComponent != null)
		{
			float value2 = uuisliderComponent.Value;
			uuisliderComponent.SetProgressIncrement(value, uuisliderComponent.WholeNumbers, true);
			if (value2 == uuisliderComponent.Value)
			{
				if (value > 0f && value2 != uuisliderComponent.MaxValue)
				{
					uuisliderComponent.SetValueWithAudio(value2 + 1f, true);
					return;
				}
				if (value < 0f && value2 != uuisliderComponent.MinValue)
				{
					uuisliderComponent.SetValueWithAudio(value2 - 1f, true);
				}
			}
		}
	}

	// Token: 0x06017135 RID: 94517 RVA: 0x00664DCC File Offset: 0x00662FCC
	public void DraggableComponentNavigate(string tag, bool toNext)
	{
		TsUiNavigationBehaviorListener currentNavigationActiveListenerByTag = this.GetCurrentNavigationActiveListenerByTag(tag, false);
		if (currentNavigationActiveListenerByTag == null)
		{
			return;
		}
		this.HandleDraggableComponentNavigate(currentNavigationActiveListenerByTag.GetBehaviorComponent(), toNext);
	}

	// Token: 0x06017136 RID: 94518 RVA: 0x00664DF4 File Offset: 0x00662FF4
	public void DraggableInsideComponentNavigate(string tag, bool toNext)
	{
		TsUiNavigationBehaviorListener currentNavigationFocusListener = this.GetCurrentNavigationFocusListener();
		if (currentNavigationFocusListener == null)
		{
			return;
		}
		TsUiNavigationBehaviorListener focusListenerInsideListenerByTag = this.GetFocusListenerInsideListenerByTag(currentNavigationFocusListener, tag);
		if (focusListenerInsideListenerByTag == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiNavigation;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "[ScrollbarInsideComponentSetValue]查找不到对应的热键按钮";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Tag", tag);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.HandleDraggableComponentNavigate(focusListenerInsideListenerByTag.GetBehaviorComponent(), toNext);
	}

	// Token: 0x06017137 RID: 94519 RVA: 0x00664E50 File Offset: 0x00663050
	private void HandleDraggableComponentNavigate(ULGUIBehaviour behavior, bool toNext)
	{
		UUIDraggableComponent uuidraggableComponent = behavior as UUIDraggableComponent;
		if (uuidraggableComponent != null)
		{
			if (!toNext)
			{
				uuidraggableComponent.NotifyNavigateToPrev();
				return;
			}
			uuidraggableComponent.NotifyNavigateToNext();
		}
	}

	// Token: 0x06017138 RID: 94520 RVA: 0x00664E78 File Offset: 0x00663078
	[NullableContext(2)]
	public void SwitchNavigationFocus(TsUiNavigationBehaviorListener listener)
	{
		UiNavigationViewHandle currentViewHandle = Singleton<UiNavigationViewManager>.Instance.GetCurrentViewHandle();
		if (currentViewHandle == null || currentViewHandle.HasGamepadControlMouse())
		{
			return;
		}
		if (Singleton<LguiEventSystemManager>.Instance.LguiEventSystem.navigationComponent == null && this.GetCurrentNavigationFocusListener() == null && listener == null)
		{
			return;
		}
		UiNavigationGlobalData.IsAllowCrossNavigationGroup = true;
		if (Singleton<LguiEventSystemManager>.Instance.LguiEventSystem.navigationComponent == null)
		{
			ULGUIPointerEventData pointerEventData = Singleton<LguiEventSystemManager>.Instance.GetPointerEventData(0, false);
			ULGUIEventSystem lguiEventSystem = Singleton<LguiEventSystemManager>.Instance.LguiEventSystem;
			if (lguiEventSystem != null)
			{
				lguiEventSystem.SetSelectComponent(null, pointerEventData, ELGUIEventFireType.TargetActorAndAllItsComponents);
			}
		}
		TsLguiEventSystemActor lguiEventSystemActor = Singleton<LguiEventSystemManager>.Instance.LguiEventSystemActor;
		USceneComponent component = (listener != null) ? listener.GetSceneComponent() : null;
		if (lguiEventSystemActor != null)
		{
			lguiEventSystemActor.UpdateNavigationListener(component);
		}
		if (listener == null)
		{
			Singleton<UiNavigationViewManager>.Instance.GetCurrentViewHandle().UpdateFocus(null);
		}
		UiNavigationGlobalData.IsAllowCrossNavigationGroup = false;
	}

	// Token: 0x06017139 RID: 94521 RVA: 0x00664F34 File Offset: 0x00663134
	[NullableContext(2)]
	public bool SwitchNavigationFocusWithDirtyCheck(TsUiNavigationBehaviorListener listener)
	{
		UiNavigationViewHandle uiNavigationViewHandle;
		if (listener == null)
		{
			uiNavigationViewHandle = null;
		}
		else
		{
			TsUiNavigationPanelConfig panelConfig = listener.PanelConfig;
			uiNavigationViewHandle = ((panelConfig != null) ? panelConfig.ViewHandle : null);
		}
		UiNavigationViewHandle uiNavigationViewHandle2 = uiNavigationViewHandle;
		if (uiNavigationViewHandle2 == null)
		{
			Singleton<Log>.Instance.Info(ELogModule.UiNavigation, ELogAuthor.XXJ, "[SwitchNavigationFocusWithDirtyCheck]查找不到当前的导航句柄", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		if (uiNavigationViewHandle2 != null)
		{
			uiNavigationViewHandle2.MarkSwitchNavigationFocusDirty(listener);
		}
		return true;
	}

	// Token: 0x0601713A RID: 94522 RVA: 0x00664F8C File Offset: 0x0066318C
	public bool SetNavigationFocusForView(UUIItem uiItem, bool checkDirty = false, bool waitListenerActive = false, bool suppressDefaultFind = false)
	{
		if (Singleton<Info>.Instance.IsInTouch())
		{
			return false;
		}
		if (waitListenerActive)
		{
			Singleton<UiNavigationViewManager>.Instance.SetNavigationFocusForView(uiItem, checkDirty, suppressDefaultFind);
			return true;
		}
		if (uiItem == null || !uiItem.IsValid())
		{
			return false;
		}
		object obj;
		if (uiItem == null)
		{
			obj = null;
		}
		else
		{
			AActor owner = uiItem.GetOwner();
			obj = ((owner != null) ? owner.GetComponentByClass(TsUiNavigationBehaviorListener.StaticClass()) : null);
		}
		TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = obj as TsUiNavigationBehaviorListener;
		if (tsUiNavigationBehaviorListener == null)
		{
			return false;
		}
		if (StringUtils.IsBlank(tsUiNavigationBehaviorListener.GroupName))
		{
			return false;
		}
		NavigationGroup navigationGroup = tsUiNavigationBehaviorListener.GetNavigationGroup();
		if (navigationGroup == null || navigationGroup.GroupType == 2)
		{
			return false;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.UiNavigation;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "业务设置了导航对象";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("名字", uiItem.displayName);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (checkDirty)
		{
			return this.SwitchNavigationFocusWithDirtyCheck(tsUiNavigationBehaviorListener);
		}
		this.SwitchNavigationFocus(tsUiNavigationBehaviorListener);
		return true;
	}

	// Token: 0x0601713B RID: 94523 RVA: 0x00665064 File Offset: 0x00663264
	public void SetNavigationFocusForViewByRootItem(UUIItem uiItem, string targetGroupName, bool checkDirty = false)
	{
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			if (!uiItem.IsValid())
			{
				return;
			}
			TArray<UActorComponent> componentsInChildren = ULGUIBPLibrary.GetComponentsInChildren(uiItem.GetOwner(), TsUiNavigationBehaviorListener.StaticClass(), true);
			if (componentsInChildren.Num() == 0)
			{
				return;
			}
			int i = 0;
			int num = componentsInChildren.Num();
			while (i < num)
			{
				TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = componentsInChildren.Get(i) as TsUiNavigationBehaviorListener;
				if (!StringUtils.IsBlank(tsUiNavigationBehaviorListener.GroupName) && !(tsUiNavigationBehaviorListener.GroupName != targetGroupName))
				{
					NavigationGroup navigationGroup = tsUiNavigationBehaviorListener.GetNavigationGroup();
					if (navigationGroup != null && navigationGroup.GroupType != 2)
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.UiNavigation;
						ELogAuthor author = ELogAuthor.XXJ;
						string message = "业务设置了导航对象";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("名字", uiItem.displayName);
						instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						if (checkDirty)
						{
							this.SwitchNavigationFocusWithDirtyCheck(tsUiNavigationBehaviorListener);
							return;
						}
						this.SwitchNavigationFocus(tsUiNavigationBehaviorListener);
						return;
					}
				}
				i++;
			}
		}
	}

	// Token: 0x0601713C RID: 94524 RVA: 0x0066514C File Offset: 0x0066334C
	public void ResetNavigationFocusForViewWithDirtyCheck()
	{
		if (!Singleton<Info>.Instance.IsInTouch())
		{
			Singleton<Log>.Instance.Info(ELogModule.UiNavigation, ELogAuthor.XXJ, "业务重置了导航对象", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.SwitchNavigationFocus(null);
		}
	}

	// Token: 0x0601713D RID: 94525 RVA: 0x0066518C File Offset: 0x0066338C
	public void SetNavigationFocusForViewSameGroup(UUIItem uiItem)
	{
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			if (uiItem == null || !uiItem.IsValid())
			{
				return;
			}
			object obj;
			if (uiItem == null)
			{
				obj = null;
			}
			else
			{
				AActor owner = uiItem.GetOwner();
				obj = ((owner != null) ? owner.GetComponentByClass(TsUiNavigationBehaviorListener.StaticClass()) : null);
			}
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = obj as TsUiNavigationBehaviorListener;
			if (tsUiNavigationBehaviorListener == null)
			{
				return;
			}
			if (StringUtils.IsBlank(tsUiNavigationBehaviorListener.GroupName))
			{
				return;
			}
			NavigationGroup navigationGroup = tsUiNavigationBehaviorListener.GetNavigationGroup();
			if (navigationGroup == null || navigationGroup.GroupType == 2)
			{
				return;
			}
			TsUiNavigationBehaviorListener currentNavigationFocusListener = this.GetCurrentNavigationFocusListener();
			if (currentNavigationFocusListener != null && currentNavigationFocusListener.GroupName != tsUiNavigationBehaviorListener.GroupName)
			{
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiNavigation;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "业务设置了导航对象";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("名字", uiItem.displayName);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.SwitchNavigationFocus(tsUiNavigationBehaviorListener);
		}
	}

	// Token: 0x0601713E RID: 94526 RVA: 0x0066525C File Offset: 0x0066345C
	private void SetNavigationMousePositionForGuide(UUIItem uiItem)
	{
		UiNavigationViewHandle currentViewHandle = Singleton<UiNavigationViewManager>.Instance.GetCurrentViewHandle();
		if (currentViewHandle == null)
		{
			return;
		}
		if (currentViewHandle.HasGamepadControlMouse())
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiNavigation;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "引导设置了光标位置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("名字", uiItem.displayName);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			currentViewHandle.UpdateMousePositionForGuide(uiItem);
		}
	}

	// Token: 0x0601713F RID: 94527 RVA: 0x006652B8 File Offset: 0x006634B8
	public void RefreshNavigationMousePositionForGuide(UUIItem uiItem)
	{
		if (!Singleton<Info>.Instance.IsInGamepad())
		{
			return;
		}
		if (uiItem == null || !uiItem.IsValid())
		{
			return;
		}
		UiNavigationViewHandle currentViewHandle = Singleton<UiNavigationViewManager>.Instance.GetCurrentViewHandle();
		if (currentViewHandle == null)
		{
			return;
		}
		if (currentViewHandle.HasGamepadControlMouse())
		{
			currentViewHandle.UpdateMousePositionByItem(uiItem);
		}
	}

	// Token: 0x06017140 RID: 94528 RVA: 0x00665304 File Offset: 0x00663504
	public void SetNavigationFocusForGuide(UUIItem uiItem)
	{
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			if (uiItem == null || !uiItem.IsValid())
			{
				return;
			}
			object obj;
			if (uiItem == null)
			{
				obj = null;
			}
			else
			{
				AActor owner = uiItem.GetOwner();
				obj = ((owner != null) ? owner.GetComponentByClass(TsUiNavigationBehaviorListener.StaticClass()) : null);
			}
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = obj as TsUiNavigationBehaviorListener;
			if (tsUiNavigationBehaviorListener == null)
			{
				this.SetNavigationMousePositionForGuide(uiItem);
				return;
			}
			UiNavigationViewHandle currentViewHandle = Singleton<UiNavigationViewManager>.Instance.GetCurrentViewHandle();
			if (currentViewHandle != null && currentViewHandle.HasGamepadControlMouse())
			{
				this.SetNavigationMousePositionForGuide(uiItem);
			}
			if (StringUtils.IsBlank(tsUiNavigationBehaviorListener.GroupName))
			{
				return;
			}
			NavigationGroup navigationGroup = tsUiNavigationBehaviorListener.GetNavigationGroup();
			if (navigationGroup == null || navigationGroup.GroupType == 2)
			{
				return;
			}
			if (navigationGroup.GroupType == 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiNavigation;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "引导设置了导航对象";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("名字", uiItem.displayName);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.SwitchNavigationFocus(tsUiNavigationBehaviorListener);
				return;
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.UiNavigation;
			ELogAuthor author2 = ELogAuthor.XXJ;
			string message2 = "引导设置了非导航对象";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("名字", uiItem.displayName);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			ModelBase<UiNavigationModel>.Instance.SetGuideFocusListener(tsUiNavigationBehaviorListener);
		}
	}

	// Token: 0x06017141 RID: 94529 RVA: 0x00665424 File Offset: 0x00663624
	public void SetNavigationMousePositionForView(UUIItem uiItem)
	{
		if (!Singleton<Info>.Instance.IsInGamepad())
		{
			return;
		}
		if (uiItem == null || !uiItem.IsValid())
		{
			return;
		}
		UiNavigationViewHandle currentViewHandle = Singleton<UiNavigationViewManager>.Instance.GetCurrentViewHandle();
		if (currentViewHandle == null)
		{
			return;
		}
		if (currentViewHandle.HasGamepadControlMouse())
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiNavigation;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "业务设置了模拟光标位置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("名字", uiItem.displayName);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			currentViewHandle.UpdateMousePositionByItem(uiItem);
		}
	}

	// Token: 0x06017142 RID: 94530 RVA: 0x006654A0 File Offset: 0x006636A0
	public void MarkViewHandleRefreshNavigationDirtyByItem(UUIItem uiItem)
	{
		if (!Singleton<Info>.Instance.IsInTouch())
		{
			if (uiItem == null || !uiItem.IsValid())
			{
				return;
			}
			object obj;
			if (uiItem == null)
			{
				obj = null;
			}
			else
			{
				AActor owner = uiItem.GetOwner();
				obj = ((owner != null) ? owner.GetComponentByClass(TsUiNavigationBehaviorListener.StaticClass()) : null);
			}
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = obj as TsUiNavigationBehaviorListener;
			if (tsUiNavigationBehaviorListener == null)
			{
				return;
			}
			if (StringUtils.IsBlank(tsUiNavigationBehaviorListener.GroupName))
			{
				return;
			}
			NavigationGroup navigationGroup = tsUiNavigationBehaviorListener.GetNavigationGroup();
			if (navigationGroup == null || navigationGroup.GroupType == 2)
			{
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiNavigation;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "业务刷新界面导航对象查找";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("名字", uiItem.displayName);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			TsUiNavigationPanelConfig panelConfig = tsUiNavigationBehaviorListener.PanelConfig;
			if (panelConfig == null)
			{
				return;
			}
			UiNavigationViewHandle viewHandle = panelConfig.ViewHandle;
			if (viewHandle == null)
			{
				return;
			}
			viewHandle.MarkRefreshNavigationDirty(0);
		}
	}

	// Token: 0x06017143 RID: 94531 RVA: 0x00665566 File Offset: 0x00663766
	[NullableContext(2)]
	public void MarkViewHandleRefreshNavigationDirtyByListener(TsUiNavigationBehaviorListener listener)
	{
		if (!Singleton<Info>.Instance.IsInTouch())
		{
			if (listener == null)
			{
				return;
			}
			TsUiNavigationPanelConfig panelConfig = listener.PanelConfig;
			if (panelConfig == null)
			{
				return;
			}
			UiNavigationViewHandle viewHandle = panelConfig.ViewHandle;
			if (viewHandle == null)
			{
				return;
			}
			viewHandle.MarkRefreshNavigationDirty(0);
		}
	}

	// Token: 0x06017144 RID: 94532 RVA: 0x00665594 File Offset: 0x00663794
	public void ResetNavigationFocusForGuide()
	{
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			UiNavigationViewHandle currentViewHandle = Singleton<UiNavigationViewManager>.Instance.GetCurrentViewHandle();
			if (currentViewHandle != null)
			{
				currentViewHandle.ResetNavigationFocusForGuide();
			}
			ModelBase<UiNavigationModel>.Instance.ResetGuideFocusListener();
		}
	}

	// Token: 0x06017145 RID: 94533 RVA: 0x006655CC File Offset: 0x006637CC
	[return: Nullable(2)]
	public UUIItem GetNoneTagNavigateItemByUiItem(UUIItem uiItem)
	{
		TArray<UActorComponent> componentsInChildren = ULGUIBPLibrary.GetComponentsInChildren(uiItem.GetOwner(), TsUiNavigationBehaviorListener.StaticClass(), true);
		if (componentsInChildren == null)
		{
			return null;
		}
		for (int i = componentsInChildren.Num() - 1; i >= 0; i--)
		{
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = componentsInChildren.Get(i) as TsUiNavigationBehaviorListener;
			if (tsUiNavigationBehaviorListener.TagArray != null && tsUiNavigationBehaviorListener.TagArray.Num() <= 0 && tsUiNavigationBehaviorListener.IsCanFocus())
			{
				return tsUiNavigationBehaviorListener.RootUIComp;
			}
		}
		return null;
	}

	// Token: 0x06017146 RID: 94534 RVA: 0x00665640 File Offset: 0x00663840
	[return: Nullable(2)]
	public TsUiNavigationBehaviorListener GetFocusListenerInsideListenerByTag(TsUiNavigationBehaviorListener listener, string tag)
	{
		AActor aactor = listener.InsideActorMap.GetValueOrDefault(tag);
		if (aactor == null)
		{
			aactor = listener.GetOwner();
		}
		TArray<UActorComponent> componentsInChildren = ULGUIBPLibrary.GetComponentsInChildren(aactor, TsUiNavigationBehaviorListener.StaticClass(), true);
		if (componentsInChildren == null)
		{
			return null;
		}
		for (int i = componentsInChildren.Num() - 1; i >= 0; i--)
		{
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = componentsInChildren.Get(i) as TsUiNavigationBehaviorListener;
			TArray<string> tagArray = tsUiNavigationBehaviorListener.TagArray;
			if (tagArray != null && tagArray.Contains(tag) && tsUiNavigationBehaviorListener.IsCanFocus())
			{
				return tsUiNavigationBehaviorListener;
			}
		}
		return null;
	}

	// Token: 0x06017147 RID: 94535 RVA: 0x006656C0 File Offset: 0x006638C0
	public List<TsUiNavigationBehaviorListener> GetMarkBookActiveListenerList([Nullable(2)] NavigationGroup groupConfig)
	{
		if (groupConfig == null)
		{
			return new List<TsUiNavigationBehaviorListener>();
		}
		if (groupConfig.GroupType != 1)
		{
			return new List<TsUiNavigationBehaviorListener>();
		}
		List<TsUiNavigationBehaviorListener> list = new List<TsUiNavigationBehaviorListener>();
		int i = 0;
		int count = groupConfig.ListenerList.Count;
		while (i < count)
		{
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = groupConfig.ListenerList[i];
			if (tsUiNavigationBehaviorListener.IsListenerActive())
			{
				list.Add(tsUiNavigationBehaviorListener);
			}
			i++;
		}
		return list;
	}

	// Token: 0x06017148 RID: 94536 RVA: 0x00665720 File Offset: 0x00663920
	public void ActiveTextInput(string tag)
	{
		TsUiNavigationBehaviorListener currentNavigationActiveListenerByTag = this.GetCurrentNavigationActiveListenerByTag(tag, false);
		if (currentNavigationActiveListenerByTag == null)
		{
			return;
		}
		(currentNavigationActiveListenerByTag.GetBehaviorComponent() as UUITextInputComponent).ActivateInputText();
	}

	// Token: 0x06017149 RID: 94537 RVA: 0x0066574C File Offset: 0x0066394C
	public void ActiveTextInputInside(string tag)
	{
		TsUiNavigationBehaviorListener currentNavigationFocusListener = this.GetCurrentNavigationFocusListener();
		if (currentNavigationFocusListener == null)
		{
			return;
		}
		TsUiNavigationBehaviorListener focusListenerInsideListenerByTag = this.GetFocusListenerInsideListenerByTag(currentNavigationFocusListener, tag);
		if (focusListenerInsideListenerByTag == null)
		{
			return;
		}
		(focusListenerInsideListenerByTag.GetBehaviorComponent() as UUITextInputComponent).ActivateInputText();
	}

	// Token: 0x0601714A RID: 94538 RVA: 0x00665784 File Offset: 0x00663984
	public void HandleCommonConsumeNavigation(string tag)
	{
		if (StringUtils.IsBlank(tag))
		{
			return;
		}
		NavigationGroup currentNavigationListenerGroup = this.GetCurrentNavigationListenerGroup();
		if (currentNavigationListenerGroup == null)
		{
			return;
		}
		string text = (!string.IsNullOrEmpty(tag)) ? currentNavigationListenerGroup.GroupNameMap.GetValueOrDefault(tag) : currentNavigationListenerGroup.NextGroupName;
		if (StringUtils.IsEmpty(text))
		{
			return;
		}
		UiNavigationViewHandle currentViewHandle = Singleton<UiNavigationViewManager>.Instance.GetCurrentViewHandle();
		NavigationGroup activeNavigationGroupByNameCheckAll = currentViewHandle.GetActiveNavigationGroupByNameCheckAll(text);
		if (activeNavigationGroupByNameCheckAll == null)
		{
			return;
		}
		if (activeNavigationGroupByNameCheckAll.ActiveListenerList.Count > 1)
		{
			if (this.ChangeFocusListenerByGroupName(currentViewHandle, text))
			{
				activeNavigationGroupByNameCheckAll.PrevGroupName = currentNavigationListenerGroup.GroupName;
				return;
			}
		}
		else if (activeNavigationGroupByNameCheckAll.ActiveListenerList.Count == 1)
		{
			TsUiNavigationBehaviorListener focusListener = currentViewHandle.GetFocusListener();
			bool flag = focusListener.IsInScrollOrLayoutCanFocus();
			TsUiNavigationBehaviorListener listener = activeNavigationGroupByNameCheckAll.ActiveListenerList[0];
			this.ClickButtonInternal(listener);
			if (flag && !focusListener.IsInScrollOrLayoutCanFocus())
			{
				this.MarkViewHandleRefreshNavigationDirty();
			}
		}
	}

	// Token: 0x0601714B RID: 94539 RVA: 0x0066584C File Offset: 0x00663A4C
	public void HandleCommonConsumeNavigationToLast(string tag)
	{
		if (StringUtils.IsBlank(tag))
		{
			return;
		}
		NavigationGroup currentNavigationListenerGroup = this.GetCurrentNavigationListenerGroup();
		if (currentNavigationListenerGroup == null)
		{
			return;
		}
		string text = (!string.IsNullOrEmpty(tag)) ? currentNavigationListenerGroup.GroupNameMap.GetValueOrDefault(tag) : currentNavigationListenerGroup.NextGroupName;
		if (StringUtils.IsEmpty(text))
		{
			return;
		}
		NavigationGroup activeNavigationGroupByNameCheckAll = Singleton<UiNavigationViewManager>.Instance.GetCurrentViewHandle().GetActiveNavigationGroupByNameCheckAll(text);
		if (activeNavigationGroupByNameCheckAll == null)
		{
			return;
		}
		TsUiNavigationBehaviorListener lastCanNavigationListenerInGroup = UiNavigationNewController.GetLastCanNavigationListenerInGroup(activeNavigationGroupByNameCheckAll);
		if (lastCanNavigationListenerInGroup == null)
		{
			return;
		}
		this.NavigateScrollTo(lastCanNavigationListenerInGroup);
		this.SwitchNavigationFocus(lastCanNavigationListenerInGroup);
		activeNavigationGroupByNameCheckAll.PrevGroupName = currentNavigationListenerGroup.GroupName;
	}

	// Token: 0x0601714C RID: 94540 RVA: 0x006658D0 File Offset: 0x00663AD0
	public void HandleCommonConsumeNavigationInside()
	{
		TsUiNavigationBehaviorListener currentNavigationFocusListener = this.GetCurrentNavigationFocusListener();
		if (currentNavigationFocusListener == null)
		{
			return;
		}
		List<TsUiNavigationBehaviorListener> canFocusInsideListenerList = this.GetCanFocusInsideListenerList(currentNavigationFocusListener);
		if (canFocusInsideListenerList.Count > 1)
		{
			TsUiNavigationBehaviorListener listener = canFocusInsideListenerList[0];
			this.SwitchNavigationFocus(listener);
			return;
		}
		if (canFocusInsideListenerList.Count == 1)
		{
			bool flag = currentNavigationFocusListener.IsInScrollOrLayoutCanFocus();
			TsUiNavigationBehaviorListener listener2 = canFocusInsideListenerList[0];
			this.ClickButtonInternal(listener2);
			if (flag && !currentNavigationFocusListener.IsInScrollOrLayoutCanFocus())
			{
				this.MarkViewHandleRefreshNavigationDirty();
			}
		}
	}

	// Token: 0x0601714D RID: 94541 RVA: 0x00665937 File Offset: 0x00663B37
	public bool IsGamepadHitListenerUseDrag()
	{
		return Singleton<Info>.Instance.IsInGamepad() && Singleton<UiNavigationViewManager>.Instance.GetCurrentViewHandle().IsGamepadHitListenerUseDrag();
	}

	// Token: 0x0601714E RID: 94542 RVA: 0x00665958 File Offset: 0x00663B58
	public void SimulationPointerTrigger(bool isPress)
	{
		TsLguiEventSystemActor lguiEventSystemActor = Singleton<LguiEventSystemManager>.Instance.LguiEventSystemActor;
		if (lguiEventSystemActor == null)
		{
			return;
		}
		lguiEventSystemActor.SimulationPointerTrigger(0, isPress);
		UiNavigationViewHandle currentViewHandle = Singleton<UiNavigationViewManager>.Instance.GetCurrentViewHandle();
		if (currentViewHandle == null)
		{
			return;
		}
		currentViewHandle.SetGamepadMouseTrigger(isPress);
	}

	// Token: 0x0601714F RID: 94543 RVA: 0x00665994 File Offset: 0x00663B94
	public void GamepadControlMouseMoveForward(float value)
	{
		UiNavigationViewHandle currentViewHandle = Singleton<UiNavigationViewManager>.Instance.GetCurrentViewHandle();
		if (currentViewHandle == null)
		{
			return;
		}
		currentViewHandle.SetGamepadMouseMoveForward(value);
	}

	// Token: 0x06017150 RID: 94544 RVA: 0x006659B8 File Offset: 0x00663BB8
	public void GamepadControlMouseMoveRight(float value)
	{
		UiNavigationViewHandle currentViewHandle = Singleton<UiNavigationViewManager>.Instance.GetCurrentViewHandle();
		if (currentViewHandle == null)
		{
			return;
		}
		currentViewHandle.SetGamepadMouseMoveRight(value);
	}

	// Token: 0x06017151 RID: 94545 RVA: 0x006659DB File Offset: 0x00663BDB
	public void RepeatCursorMove()
	{
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			UiNavigationModel instance = ModelBase<UiNavigationModel>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.RepeatMove();
		}
	}

	// Token: 0x06017152 RID: 94546 RVA: 0x006659F8 File Offset: 0x00663BF8
	private bool InMaskState()
	{
		return Singleton<UiLayer>.Instance.IsInMask() || !ModelBase<ReConnectModel>.Instance.IsRpcEmpty();
	}

	// Token: 0x06017153 RID: 94547 RVA: 0x00665A18 File Offset: 0x00663C18
	public List<TsUiNavigationBehaviorListener> GetDynamicScrollListenerListByListener(TsUiNavigationBehaviorListener listener)
	{
		NavigationGroup navigationGroup = listener.GetNavigationGroup();
		if (navigationGroup == null)
		{
			return new List<TsUiNavigationBehaviorListener>();
		}
		UiNavigationScrollProxy scrollProxy = listener.ScrollProxy;
		TArray<TWeakObjectPtr<AUIBaseActor>> displayItemArray = (((scrollProxy != null) ? scrollProxy.ScrollView : null) as UUIDynScrollViewComponent).DisplayItemArray;
		List<TsUiNavigationBehaviorListener> list = new List<TsUiNavigationBehaviorListener>();
		int i = 0;
		int num = displayItemArray.Num();
		while (i < num)
		{
			TWeakObjectPtr<AUIBaseActor> weak = displayItemArray.Get(i);
			List<TsUiNavigationBehaviorListener> dynListenerListInGroup = this.GetDynListenerListInGroup(weak, navigationGroup);
			list.AddRange(dynListenerListInGroup);
			i++;
		}
		return list;
	}

	// Token: 0x06017154 RID: 94548 RVA: 0x00665A90 File Offset: 0x00663C90
	public void NotifyNavigationMousePositionDragState(bool state)
	{
		if (Singleton<Info>.Instance.IsInTouch())
		{
			return;
		}
		UiNavigationViewHandle currentViewHandle = Singleton<UiNavigationViewManager>.Instance.GetCurrentViewHandle();
		if (currentViewHandle == null)
		{
			return;
		}
		currentViewHandle.NotifyNavigationMousePositionDragState(state);
	}

	// Token: 0x06017155 RID: 94549 RVA: 0x00665AC0 File Offset: 0x00663CC0
	public bool IsNavigationMousePositionDragging()
	{
		if (Singleton<Info>.Instance.IsInTouch())
		{
			return false;
		}
		UiNavigationViewHandle currentViewHandle = Singleton<UiNavigationViewManager>.Instance.GetCurrentViewHandle();
		return currentViewHandle != null && currentViewHandle.IsNavigationMousePositionDragging();
	}

	// Token: 0x06017156 RID: 94550 RVA: 0x00665AF4 File Offset: 0x00663CF4
	public void SetLockUseDragState(bool lockState)
	{
		if (Singleton<Info>.Instance.IsInTouch())
		{
			return;
		}
		UiNavigationViewHandle currentViewHandle = Singleton<UiNavigationViewManager>.Instance.GetCurrentViewHandle();
		if (currentViewHandle == null)
		{
			return;
		}
		currentViewHandle.SetLockUseDragState(lockState);
	}

	// Token: 0x06017157 RID: 94551 RVA: 0x00665B24 File Offset: 0x00663D24
	public void SetLockUseDragStateByPanelItem(UUIItem uiItem, bool lockState)
	{
		if (Singleton<Info>.Instance.IsInTouch())
		{
			return;
		}
		if (uiItem == null || !uiItem.IsValid())
		{
			return;
		}
		object obj;
		if (uiItem == null)
		{
			obj = null;
		}
		else
		{
			AActor owner = uiItem.GetOwner();
			obj = ((owner != null) ? owner.GetComponentByClass(TsUiNavigationPanelConfig.StaticClass()) : null);
		}
		TsUiNavigationPanelConfig tsUiNavigationPanelConfig = obj as TsUiNavigationPanelConfig;
		if (tsUiNavigationPanelConfig == null)
		{
			return;
		}
		UiNavigationViewHandle viewHandle = tsUiNavigationPanelConfig.ViewHandle;
		if (viewHandle == null)
		{
			return;
		}
		viewHandle.SetLockUseDragState(lockState);
	}

	// Token: 0x06017158 RID: 94552 RVA: 0x00665B90 File Offset: 0x00663D90
	[NullableContext(2)]
	public Vector2D GetMouseViewportPosition()
	{
		if (!Singleton<Info>.Instance.IsInGamepad())
		{
			return null;
		}
		UiNavigationViewHandle currentViewHandle = Singleton<UiNavigationViewManager>.Instance.GetCurrentViewHandle();
		if (currentViewHandle == null)
		{
			return null;
		}
		return currentViewHandle.GetMouseViewportPosition();
	}

	// Token: 0x0400B1A4 RID: 45476
	protected Vector2D DefaultPivot = Vector2D.Create(0.5, 0.5);
}
