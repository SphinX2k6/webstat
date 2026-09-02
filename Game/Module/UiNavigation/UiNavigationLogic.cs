using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CDE RID: 19678
	[NullableContext(1)]
	[Nullable(0)]
	public class UiNavigationLogic : IStaticVariableResetter
	{
		// Token: 0x060332F7 RID: 209655 RVA: 0x00CD0152 File Offset: 0x00CCE352
		static UiNavigationLogic()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(UiNavigationLogic.CreateStaticDefaultValue), new Action(UiNavigationLogic.ResetStaticDefaultValue));
		}

		// Token: 0x060332F8 RID: 209656 RVA: 0x00CD0171 File Offset: 0x00CCE371
		public static void InitNavigationDelegate(ULGUIEventSystem eventSystem)
		{
			FLGUITryFindNavigationDelegate tryFindNavigationDelegate = eventSystem.TryFindNavigationDelegate;
			Func<ELGUINavigationDirection, UUISelectableComponent, USceneComponent> callback;
			if ((callback = UiNavigationLogic.<>O.<0>__TryFindNavigationDelegate) == null)
			{
				callback = (UiNavigationLogic.<>O.<0>__TryFindNavigationDelegate = new Func<ELGUINavigationDirection, UUISelectableComponent, USceneComponent>(UiNavigationLogic.TryFindNavigationDelegate));
			}
			tryFindNavigationDelegate.Bind(callback);
		}

		// Token: 0x060332F9 RID: 209657 RVA: 0x00CD0199 File Offset: 0x00CCE399
		public static void ClearNavigationDelegate(ULGUIEventSystem eventSystem)
		{
			eventSystem.TryFindNavigationDelegate.Unbind();
		}

		// Token: 0x060332FA RID: 209658 RVA: 0x00CD01A8 File Offset: 0x00CCE3A8
		[NullableContext(2)]
		public static USceneComponent TryFindNavigationDelegate(ELGUINavigationDirection direction, UUISelectableComponent selectable)
		{
			if (direction == ELGUINavigationDirection.None && selectable == null)
			{
				ULGUIEventSystem lguiEventSystem = Singleton<LguiEventSystemManager>.Instance.LguiEventSystem;
				if (lguiEventSystem == null)
				{
					return null;
				}
				return lguiEventSystem.navigationComponent;
			}
			else
			{
				if (UiNavigationGlobalData.IsBlockNavigation)
				{
					return null;
				}
				USceneComponent sceneComponent;
				if (selectable == null)
				{
					ULGUIEventSystem lguiEventSystem2 = Singleton<LguiEventSystemManager>.Instance.LguiEventSystem;
					sceneComponent = ((lguiEventSystem2 != null) ? lguiEventSystem2.navigationComponent : null);
				}
				else
				{
					sceneComponent = selectable.GetRootComponent();
				}
				TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = UiNavigationLogic.FindListener(sceneComponent);
				if (tsUiNavigationBehaviorListener == null)
				{
					return null;
				}
				TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener2 = UiNavigationLogic.FindNavigation(tsUiNavigationBehaviorListener, direction);
				TsUiNavigationPanelConfig panelConfig = tsUiNavigationBehaviorListener.PanelConfig;
				if (panelConfig != null && panelConfig.CanOverrideFindNavigation(direction, tsUiNavigationBehaviorListener, tsUiNavigationBehaviorListener2))
				{
					TsUiNavigationPanelConfig panelConfig2 = tsUiNavigationBehaviorListener.PanelConfig;
					TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener3 = (panelConfig2 != null) ? panelConfig2.HandleOverrideFindNavigation(direction, tsUiNavigationBehaviorListener, tsUiNavigationBehaviorListener2) : null;
					if (tsUiNavigationBehaviorListener3 == null)
					{
						return null;
					}
					return tsUiNavigationBehaviorListener3.GetSceneComponent();
				}
				else
				{
					UiNavigationLogic.HandleScrollViewLogic(tsUiNavigationBehaviorListener, tsUiNavigationBehaviorListener2, direction);
					UiNavigationLogic.HandleNavigateAudio(tsUiNavigationBehaviorListener2);
					if (tsUiNavigationBehaviorListener2 == null)
					{
						return null;
					}
					return tsUiNavigationBehaviorListener2.GetSceneComponent();
				}
			}
		}

		// Token: 0x060332FB RID: 209659 RVA: 0x00CD025F File Offset: 0x00CCE45F
		private static bool CheckIsUsefulDirection(UUIScrollViewWithScrollbarComponent scrollView, ELGUINavigationDirection direction)
		{
			if (scrollView.Horizontal)
			{
				return direction == ELGUINavigationDirection.Right || direction == ELGUINavigationDirection.Left;
			}
			return direction == ELGUINavigationDirection.Down || direction == ELGUINavigationDirection.Up;
		}

		// Token: 0x060332FC RID: 209660 RVA: 0x00CD027E File Offset: 0x00CCE47E
		[NullableContext(2)]
		private static bool CheckNavigationConfig(bool isMoveRightOrDown, NavigationGroup group)
		{
			return group != null && ((group.SlideToRightOrDown && isMoveRightOrDown) || (group.SlideToLeftOrTop && !isMoveRightOrDown));
		}

		// Token: 0x060332FD RID: 209661 RVA: 0x00CD02A0 File Offset: 0x00CCE4A0
		private static void HandleNormalScrollViewLogic(TsUiNavigationBehaviorListener originalListener, [Nullable(2)] TsUiNavigationBehaviorListener targetListener, ELGUINavigationDirection direction)
		{
			UiNavigationScrollProxy scrollProxy = originalListener.ScrollProxy;
			UUIScrollViewWithScrollbarComponent uuiscrollViewWithScrollbarComponent = (scrollProxy != null) ? scrollProxy.ScrollView : null;
			NavigationGroup navigationGroup = originalListener.GetNavigationGroup();
			bool flag = direction == ELGUINavigationDirection.Right || direction == ELGUINavigationDirection.Down;
			if (UiNavigationLogic.CheckNavigationConfig(flag, navigationGroup) && UiNavigationLogic.CheckIsUsefulDirection(uuiscrollViewWithScrollbarComponent, direction))
			{
				if (targetListener == null)
				{
					bool flag2 = !flag;
					if (uuiscrollViewWithScrollbarComponent != null)
					{
						uuiscrollViewWithScrollbarComponent.SetScrollProgress(!flag2);
					}
					UiNavigationModel instance = ModelBase<UiNavigationModel>.Instance;
					if (instance != null)
					{
						instance.RepeatMove();
					}
					Singleton<UiNavigationViewManager>.Instance.RefreshCurrentHotKey();
					return;
				}
				if (!UiNavigationModeModule.FindOppositeNavigationResult.IsOppositeNavigationPositive)
				{
					if (uuiscrollViewWithScrollbarComponent != null)
					{
						uuiscrollViewWithScrollbarComponent.SetScrollProgress(!flag);
					}
					UiNavigationModel instance2 = ModelBase<UiNavigationModel>.Instance;
					if (instance2 != null)
					{
						instance2.RepeatMove();
					}
					Singleton<UiNavigationViewManager>.Instance.RefreshCurrentHotKey();
				}
			}
		}

		// Token: 0x060332FE RID: 209662 RVA: 0x00CD034C File Offset: 0x00CCE54C
		private static void HandleDynamicScrollViewLogic([Nullable(2)] TsUiNavigationBehaviorListener originalListener, TsUiNavigationBehaviorListener targetListener, ELGUINavigationDirection direction)
		{
			NavigationGroup navigationGroup = targetListener.GetNavigationGroup();
			UiNavigationScrollProxy scrollProxy = targetListener.ScrollProxy;
			bool flag;
			if (scrollProxy == null)
			{
				flag = false;
			}
			else
			{
				UUIScrollViewWithScrollbarComponent scrollView = scrollProxy.ScrollView;
				flag = ((scrollView != null) ? new bool?(scrollView.Horizontal) : null).GetValueOrDefault();
			}
			UINavigationWrapMode mode = flag ? navigationGroup.HorizontalWrapMode : navigationGroup.VerticalWrapMode;
			UiNavigationScrollProxy scrollProxy2 = targetListener.ScrollProxy;
			UUIDynScrollViewComponent uuidynScrollViewComponent = ((scrollProxy2 != null) ? scrollProxy2.ScrollView : null) as UUIDynScrollViewComponent;
			bool bReversed = (direction == ELGUINavigationDirection.Right || direction == ELGUINavigationDirection.Down) != UiNavigationModeModule.FindOppositeNavigationResult.IsOppositeNavigationPositive;
			uuidynScrollViewComponent.NavigateScrollToUIItem((targetListener != null) ? targetListener.GetRootComponent() : null, bReversed, mode);
		}

		// Token: 0x060332FF RID: 209663 RVA: 0x00CD03E9 File Offset: 0x00CCE5E9
		[NullableContext(2)]
		private static void HandleScrollViewLogic(TsUiNavigationBehaviorListener originalListener, TsUiNavigationBehaviorListener targetListener, ELGUINavigationDirection direction)
		{
			if (originalListener != null && originalListener.HasNormalScrollView())
			{
				UiNavigationLogic.HandleNormalScrollViewLogic(originalListener, targetListener, direction);
			}
			if (targetListener != null && targetListener.HasDynamicScrollView())
			{
				UiNavigationLogic.HandleDynamicScrollViewLogic(originalListener, targetListener, direction);
			}
		}

		// Token: 0x06033300 RID: 209664 RVA: 0x00CD0411 File Offset: 0x00CCE611
		[NullableContext(2)]
		private static void HandleNavigateAudio(TsUiNavigationBehaviorListener listener)
		{
			if (listener != null)
			{
				Singleton<AudioSystem>.Instance.PostEvent("play_ui_gamepad_navigation_common");
			}
		}

		// Token: 0x06033301 RID: 209665 RVA: 0x00CD0428 File Offset: 0x00CCE628
		[return: Nullable(2)]
		private static TsUiNavigationBehaviorListener FindNavigation(TsUiNavigationBehaviorListener listener, ELGUINavigationDirection direction)
		{
			TsUiNavigationPanelConfig panelConfig = listener.PanelConfig;
			if (panelConfig == null || !panelConfig.IsAllowNavigate())
			{
				return null;
			}
			if (!listener.GetNavigationComponent().CheckFindNavigationBefore())
			{
				return null;
			}
			NavigationGroup navigationGroup = listener.GetNavigationGroup();
			USceneComponent sceneComponent;
			if (navigationGroup != null && navigationGroup.GroupType == 0)
			{
				sceneComponent = UiNavigationLogic.FindNormalNavigation(listener, direction, navigationGroup.AllowNavigationInSelfDynamic);
			}
			else
			{
				sceneComponent = listener.FindNavigation(direction);
			}
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = UiNavigationLogic.FindListener(sceneComponent);
			if (!listener.GetNavigationComponent().CheckFindNavigationAfter(tsUiNavigationBehaviorListener))
			{
				return null;
			}
			return tsUiNavigationBehaviorListener;
		}

		// Token: 0x06033302 RID: 209666 RVA: 0x00CD04A4 File Offset: 0x00CCE6A4
		[return: Nullable(2)]
		private static USceneComponent FindNormalNavigation(TsUiNavigationBehaviorListener listener, ELGUINavigationDirection direction, bool isAllowNavigationInSelfDynamic)
		{
			USceneComponent usceneComponent = listener.FindNavigation(direction);
			if (isAllowNavigationInSelfDynamic)
			{
				return usceneComponent;
			}
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = UiNavigationLogic.FindListener(usceneComponent);
			if (tsUiNavigationBehaviorListener == null)
			{
				return usceneComponent;
			}
			if (listener.ScrollViewActor == null && tsUiNavigationBehaviorListener.ScrollViewActor == null && listener.LayoutActor == null && tsUiNavigationBehaviorListener.LayoutActor == null)
			{
				return listener.GetSceneComponent();
			}
			if (listener.ScrollViewActor != tsUiNavigationBehaviorListener.ScrollViewActor)
			{
				return listener.GetSceneComponent();
			}
			if (listener.LayoutActor != tsUiNavigationBehaviorListener.LayoutActor)
			{
				return listener.GetSceneComponent();
			}
			return usceneComponent;
		}

		// Token: 0x06033303 RID: 209667 RVA: 0x00CD051C File Offset: 0x00CCE71C
		[NullableContext(2)]
		private static TsUiNavigationBehaviorListener FindListener(USceneComponent sceneComponent)
		{
			object obj;
			if (sceneComponent == null)
			{
				obj = null;
			}
			else
			{
				AActor owner = sceneComponent.GetOwner();
				obj = ((owner != null) ? owner.GetComponentByClass(TsUiNavigationBehaviorListener.StaticClass()) : null);
			}
			return obj as TsUiNavigationBehaviorListener;
		}

		// Token: 0x06033304 RID: 209668 RVA: 0x00CD0548 File Offset: 0x00CCE748
		public static TsUiNavigationPanelConfig FindUiNavigationPanelConfig(AActor actor)
		{
			AActor attachParentActor = actor.GetAttachParentActor();
			TsUiNavigationPanelConfig tsUiNavigationPanelConfig = null;
			while (attachParentActor != null)
			{
				tsUiNavigationPanelConfig = (attachParentActor.GetComponentByClass(TsUiNavigationPanelConfig.StaticClass()) as TsUiNavigationPanelConfig);
				if (tsUiNavigationPanelConfig != null)
				{
					break;
				}
				attachParentActor = attachParentActor.GetAttachParentActor();
			}
			return tsUiNavigationPanelConfig;
		}

		// Token: 0x06033305 RID: 209669 RVA: 0x00CD0584 File Offset: 0x00CCE784
		public static TsUiNavigationBehaviorListener FindUpNavigationListener(AActor actor)
		{
			AActor attachParentActor = actor.GetAttachParentActor();
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = null;
			while (attachParentActor != null && !(attachParentActor.GetComponentByClass(TsUiNavigationPanelConfig.StaticClass()) is TsUiNavigationPanelConfig))
			{
				tsUiNavigationBehaviorListener = (attachParentActor.GetComponentByClass(TsUiNavigationBehaviorListener.StaticClass()) as TsUiNavigationBehaviorListener);
				if (tsUiNavigationBehaviorListener != null)
				{
					break;
				}
				attachParentActor = attachParentActor.GetAttachParentActor();
			}
			return tsUiNavigationBehaviorListener;
		}

		// Token: 0x06033306 RID: 209670 RVA: 0x00CD05D8 File Offset: 0x00CCE7D8
		public static void BindHotKeyComponentAction(HotKeyComponent hotKeyComponent, bool bAdd)
		{
			UiNavigationModel instance = ModelBase<UiNavigationModel>.Instance;
			string actionName = hotKeyComponent.GetActionName();
			if (string.IsNullOrEmpty(actionName))
			{
				return;
			}
			HashSet<HotKeyComponent> orAddActionHotKeyComponentSet = instance.GetOrAddActionHotKeyComponentSet(actionName);
			if (bAdd)
			{
				if (orAddActionHotKeyComponentSet.Count <= 0)
				{
					ControllerBase<InputDistributeController>.Instance.BindAction(actionName, UiNavigationLogic.OnInputAction);
				}
				if (orAddActionHotKeyComponentSet.Contains(hotKeyComponent))
				{
					return;
				}
				orAddActionHotKeyComponentSet.Add(hotKeyComponent);
				return;
			}
			else
			{
				if (orAddActionHotKeyComponentSet.Count <= 0)
				{
					return;
				}
				orAddActionHotKeyComponentSet.Remove(hotKeyComponent);
				if (orAddActionHotKeyComponentSet.Count <= 0)
				{
					ControllerBase<InputDistributeController>.Instance.UnBindAction(actionName, UiNavigationLogic.OnInputAction);
				}
				return;
			}
		}

		// Token: 0x06033307 RID: 209671 RVA: 0x00CD0660 File Offset: 0x00CCE860
		public static void BindHotKeyComponentAxis(HotKeyComponent hotKeyComponent, bool bAdd)
		{
			UiNavigationModel instance = ModelBase<UiNavigationModel>.Instance;
			string axisName = hotKeyComponent.GetAxisName();
			if (string.IsNullOrEmpty(axisName))
			{
				return;
			}
			HashSet<HotKeyComponent> orAddAxisHotKeyComponentsSet = instance.GetOrAddAxisHotKeyComponentsSet(axisName);
			if (bAdd)
			{
				if (orAddAxisHotKeyComponentsSet.Count <= 0)
				{
					ControllerBase<InputDistributeController>.Instance.BindAxis(axisName, UiNavigationLogic.OnInputAxis);
				}
				if (orAddAxisHotKeyComponentsSet.Contains(hotKeyComponent))
				{
					return;
				}
				orAddAxisHotKeyComponentsSet.Add(hotKeyComponent);
				return;
			}
			else
			{
				if (orAddAxisHotKeyComponentsSet.Count == 0)
				{
					return;
				}
				orAddAxisHotKeyComponentsSet.Remove(hotKeyComponent);
				if (orAddAxisHotKeyComponentsSet.Count == 0)
				{
					ControllerBase<InputDistributeController>.Instance.UnBindAxis(axisName, UiNavigationLogic.OnInputAxis);
				}
				return;
			}
		}

		// Token: 0x06033308 RID: 209672 RVA: 0x00CD06E4 File Offset: 0x00CCE8E4
		[NullableContext(2)]
		public static bool HasActiveListenerInGroup(NavigationGroup groupConfig)
		{
			if (groupConfig == null)
			{
				return false;
			}
			int i = 0;
			int count = groupConfig.ListenerList.Count;
			while (i < count)
			{
				if (groupConfig.ListenerList[i].IsListenerActive())
				{
					return true;
				}
				i++;
			}
			return false;
		}

		// Token: 0x06033309 RID: 209673 RVA: 0x00CD0724 File Offset: 0x00CCE924
		[NullableContext(2)]
		public static void UpdateNavigationListener(TsUiNavigationBehaviorListener listener)
		{
			UiNavigationModel instance = ModelBase<UiNavigationModel>.Instance;
			if (instance == null)
			{
				return;
			}
			ULGUIEventSystem lguiEventSystem = Singleton<LguiEventSystemManager>.Instance.LguiEventSystem;
			TWeakObjectPtr<UUIItem>? tweakObjectPtr = (listener != null) ? new TWeakObjectPtr<UUIItem>?(listener.RootUIComp) : null;
			lguiEventSystem.navigationComponent = ((tweakObjectPtr != null) ? tweakObjectPtr.GetValueOrDefault() : null);
			instance.SetCursorFollowItem(listener);
			UiNavigationLogic.MemoryGroupConfigLastSelect(listener);
			Singleton<EventSystem>.Instance.Emit(EEventName.UpdateNavigationListener);
		}

		// Token: 0x0603330A RID: 209674 RVA: 0x00CD079C File Offset: 0x00CCE99C
		public static void UpdateSameNavigationListener(TsUiNavigationBehaviorListener listener)
		{
			if (Singleton<LguiEventSystemManager>.Instance.LguiEventSystem.navigationComponent != listener.RootUIComp.Get())
			{
				return;
			}
			UiNavigationModel instance = ModelBase<UiNavigationModel>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.SetCursorFollowItem(listener);
			UiNavigationLogic.MemoryGroupConfigLastSelect(listener);
			Singleton<EventSystem>.Instance.Emit(EEventName.UpdateNavigationListener);
		}

		// Token: 0x0603330B RID: 209675 RVA: 0x00CD07F0 File Offset: 0x00CCE9F0
		[NullableContext(2)]
		public static void MemoryGroupConfigLastSelect(TsUiNavigationBehaviorListener listener)
		{
			if (listener == null)
			{
				return;
			}
			NavigationGroup navigationGroup = listener.GetNavigationGroup();
			if (navigationGroup == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.UiNavigation, ELogAuthor.XXJ, "[MemoryGroupConfigLastSelect]查找不到当前导航的导航组,逻辑上有问题", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (navigationGroup.SelectableMemory)
			{
				navigationGroup.LastSelectListener = listener;
			}
		}

		// Token: 0x0603330C RID: 209676 RVA: 0x00CD083C File Offset: 0x00CCEA3C
		public static void HandleInputControllerTypeChange()
		{
			bool flag = Singleton<Info>.Instance.IsInGamepad();
			TsLguiEventSystemActor lguiEventSystemActor = Singleton<LguiEventSystemManager>.Instance.LguiEventSystemActor;
			if (lguiEventSystemActor == null)
			{
				ModelBase<UiNavigationModel>.Instance.SetIsUseMouse(!flag);
				return;
			}
			if (lguiEventSystemActor.GetPointerEventData(0f, false) == null)
			{
				ModelBase<UiNavigationModel>.Instance.SetIsUseMouse(!flag);
				return;
			}
			UiNavigationViewHandle currentViewHandle = Singleton<UiNavigationViewManager>.Instance.GetCurrentViewHandle();
			bool flag2 = currentViewHandle == null || currentViewHandle.GetCurrentPanel().AllowNavigateInKeyBoard;
			if (flag)
			{
				lguiEventSystemActor.SetIsUseMouse(false);
				lguiEventSystemActor.SwitchToNavigationInputType();
				lguiEventSystemActor.UpdateNavigationListener(null);
				ModelBase<UiNavigationModel>.Instance.SetIsUseMouse(false);
				if (!flag2)
				{
					Singleton<EventSystem>.Instance.Emit(EEventName.ResetNavigationListener);
				}
				return;
			}
			if (!flag2)
			{
				ModelBase<UiNavigationModel>.Instance.SetIsUseMouse(true);
				Singleton<EventSystem>.Instance.Emit(EEventName.ResetNavigationListener);
				return;
			}
			ModelBase<UiNavigationModel>.Instance.SetIsUseMouse(!flag);
		}

		// Token: 0x0603330D RID: 209677 RVA: 0x00CD0910 File Offset: 0x00CCEB10
		public static void ForceChangeInputType()
		{
			if (!Singleton<Info>.Instance.IsInKeyBoard())
			{
				return;
			}
			UiNavigationViewHandle currentViewHandle = Singleton<UiNavigationViewManager>.Instance.GetCurrentViewHandle();
			if (currentViewHandle == null)
			{
				return;
			}
			if (currentViewHandle.GetCurrentPanel().IsAllowNavigate())
			{
				return;
			}
			TsLguiEventSystemActor lguiEventSystemActor = Singleton<LguiEventSystemManager>.Instance.LguiEventSystemActor;
			if (lguiEventSystemActor == null)
			{
				return;
			}
			if (lguiEventSystemActor.GetPointerEventData(0f, false).inputType == ELGUIPointerInputType.Navigation)
			{
				lguiEventSystemActor.SetIsForceChange(true);
			}
		}

		// Token: 0x0603330E RID: 209678 RVA: 0x00CD0974 File Offset: 0x00CCEB74
		public static void ExecuteInputNavigation(string actionName, InputDistributeDefine.EActionType actionType)
		{
			if (actionType == InputDistributeDefine.EActionType.Release)
			{
				if (UiNavigationLogic.IsPress)
				{
					UiNavigationLogic.IsPress = false;
					Singleton<LguiEventSystemManager>.Instance.InputNavigation(actionName, InputDistributeDefine.EActionType.Release);
					return;
				}
			}
			else
			{
				UiNavigationViewHandle currentViewHandle = Singleton<UiNavigationViewManager>.Instance.GetCurrentViewHandle();
				if (currentViewHandle == null)
				{
					return;
				}
				if (currentViewHandle.GetFocusListener() == null)
				{
					return;
				}
				UiNavigationLogic.IsPress = true;
				Singleton<LguiEventSystemManager>.Instance.InputNavigation(actionName, InputDistributeDefine.EActionType.Press);
			}
		}

		// Token: 0x0603330F RID: 209679 RVA: 0x00CD09CC File Offset: 0x00CCEBCC
		public static void ExecuteInterfaceMethod<[Nullable(2)] T>(object obj, string methodName, params object[] args)
		{
			MethodInfo method = obj.GetType().GetMethod(methodName);
			if (method != null)
			{
				method.Invoke(obj, args);
			}
		}

		// Token: 0x06033310 RID: 209680 RVA: 0x00CD09F8 File Offset: 0x00CCEBF8
		public static void CreateStaticDefaultValue()
		{
			UiNavigationLogic.OnInputAction = delegate(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification _)
			{
				UiNavigationModel instance = ModelBase<UiNavigationModel>.Instance;
				if (instance == null)
				{
					return;
				}
				foreach (HotKeyComponent hotKeyComponent in new HashSet<HotKeyComponent>(instance.GetActionHotKeyComponentSet(actionName)))
				{
					if (hotKeyComponent.IsHotKeyActive())
					{
						if (actionType == InputDistributeDefine.EActionType.Press)
						{
							hotKeyComponent.Press();
						}
						else
						{
							hotKeyComponent.Release();
						}
					}
				}
			};
			UiNavigationLogic.OnInputAxis = delegate(string axisName, float value, InputIdentification _)
			{
				UiNavigationModel instance = ModelBase<UiNavigationModel>.Instance;
				if (instance == null)
				{
					return;
				}
				foreach (HotKeyComponent hotKeyComponent in new HashSet<HotKeyComponent>(instance.GetAxisHotKeyComponentSet(axisName)))
				{
					if (hotKeyComponent.IsAllowTickContinue())
					{
						hotKeyComponent.InputAxis(axisName, value);
					}
				}
			};
			UiNavigationLogic.IsPress = false;
		}

		// Token: 0x06033311 RID: 209681 RVA: 0x00CD0A53 File Offset: 0x00CCEC53
		public static void ResetStaticDefaultValue()
		{
			UiNavigationLogic.OnInputAction = null;
			UiNavigationLogic.OnInputAxis = null;
			UiNavigationLogic.IsPress = false;
		}

		// Token: 0x0401DC01 RID: 121857
		private static TInputHandle<InputDistributeDefine.EActionType> OnInputAction;

		// Token: 0x0401DC02 RID: 121858
		private static TInputHandle<float> OnInputAxis;

		// Token: 0x0401DC03 RID: 121859
		private static bool IsPress;

		// Token: 0x0200AD4F RID: 44367
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x04035D76 RID: 220534
			[Nullable(new byte[]
			{
				0,
				2,
				2
			})]
			public static Func<ELGUINavigationDirection, UUISelectableComponent, USceneComponent> <0>__TryFindNavigationDelegate;
		}
	}
}
