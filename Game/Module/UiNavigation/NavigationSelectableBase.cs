using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.UiNavigation.Enum;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CB3 RID: 19635
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class NavigationSelectableBase
	{
		// Token: 0x0603322B RID: 209451 RVA: 0x00CCE004 File Offset: 0x00CCC204
		protected NavigationSelectableBase(ULGUIBehaviour selectable, string type, List<string> paramList)
		{
		}

		// Token: 0x0603322C RID: 209452 RVA: 0x00CCE03C File Offset: 0x00CCC23C
		public void Init()
		{
			this.OnInit();
		}

		// Token: 0x0603322D RID: 209453 RVA: 0x00CCE044 File Offset: 0x00CCC244
		public void Start()
		{
			this.OnStart();
		}

		// Token: 0x0603322E RID: 209454 RVA: 0x00CCE04C File Offset: 0x00CCC24C
		public void Clear()
		{
			this.OnClear();
		}

		// Token: 0x0603322F RID: 209455 RVA: 0x00CCE054 File Offset: 0x00CCC254
		public bool CanFocus()
		{
			return this.IsInteractive && this.Selectable != null && this.Selectable.IsValid() && this.Selectable.RootUIComp.Get().IsUIActiveInHierarchy();
		}

		// Token: 0x06033230 RID: 209456 RVA: 0x00CCE09A File Offset: 0x00CCC29A
		public bool CanFocusInScrollOrLayout()
		{
			return this.OnCanFocusInScrollOrLayout();
		}

		// Token: 0x06033231 RID: 209457 RVA: 0x00CCE0A4 File Offset: 0x00CCC2A4
		public bool IsActive()
		{
			return this.IsInteractive && this.Selectable != null && this.Selectable.IsValid() && this.Selectable.RootUIComp.Get().IsUIActiveInHierarchy();
		}

		// Token: 0x06033232 RID: 209458 RVA: 0x00CCE0EA File Offset: 0x00CCC2EA
		public void SetIsInteractive(bool value)
		{
			this.IsInteractive = value;
		}

		// Token: 0x06033233 RID: 209459 RVA: 0x00CCE0F3 File Offset: 0x00CCC2F3
		public ULGUIBehaviour GetSelectable()
		{
			return this.Selectable;
		}

		// Token: 0x06033234 RID: 209460 RVA: 0x00CCE0FB File Offset: 0x00CCC2FB
		public void SetListener(TsUiNavigationBehaviorListener listener)
		{
			this.Listener = listener;
		}

		// Token: 0x06033235 RID: 209461 RVA: 0x00CCE104 File Offset: 0x00CCC304
		public void SetPanelHandle(SpecialPanelHandleBase panelHandle)
		{
			this.PanelHandle = panelHandle;
		}

		// Token: 0x06033236 RID: 209462 RVA: 0x00CCE10D File Offset: 0x00CCC30D
		public string GetTipsTextId()
		{
			return this.OnGetTipsTextId();
		}

		// Token: 0x06033237 RID: 209463 RVA: 0x00CCE115 File Offset: 0x00CCC315
		public bool CheckFindNavigationBefore()
		{
			return !Singleton<UiLayer>.Instance.IsInMask() && this.OnCheckFindNavigationBefore();
		}

		// Token: 0x06033238 RID: 209464 RVA: 0x00CCE12B File Offset: 0x00CCC32B
		public bool CheckFindOpposite()
		{
			return this.Listener.IsCanFocus() && this.OnCheckFindOpposite();
		}

		// Token: 0x06033239 RID: 209465 RVA: 0x00CCE142 File Offset: 0x00CCC342
		[NullableContext(2)]
		public bool CheckFindNavigationAfter(TsUiNavigationBehaviorListener findListener)
		{
			return this.OnCheckFindNavigationAfter(findListener);
		}

		// Token: 0x0603323A RID: 209466 RVA: 0x00CCE14B File Offset: 0x00CCC34B
		public bool HandlePointerEnter(ULGUIPointerEventData eventData)
		{
			return this.IsAllowNavigationByGroup() && this.IsAllowNavigationBySelfParam(eventData) && this.IsAllowCrossNavigationGroup() && this.OnHandlePointerEnter(eventData);
		}

		// Token: 0x0603323B RID: 209467 RVA: 0x00CCE173 File Offset: 0x00CCC373
		public bool HandlePointerSelect(ULGUIPointerEventData eventData)
		{
			return this.IsAllowCrossNavigationGroup() && this.OnHandlePointerSelect(eventData);
		}

		// Token: 0x0603323C RID: 209468 RVA: 0x00CCE186 File Offset: 0x00CCC386
		public bool IsIgnoreScrollOrLayoutCheckInSwitchGroup()
		{
			return this.OnIsIgnoreScrollOrLayoutCheck();
		}

		// Token: 0x0603323D RID: 209469 RVA: 0x00CCE18E File Offset: 0x00CCC38E
		[NullableContext(2)]
		public UUISelectableComponent FindLoopScrollViewNavigationComponent(FVector direction, UINavigationWrapMode wrapMode)
		{
			return this.OnFindLoopScrollViewNavigationComponent(direction, wrapMode);
		}

		// Token: 0x0603323E RID: 209470 RVA: 0x00CCE198 File Offset: 0x00CCC398
		[NullableContext(2)]
		public UUISelectableComponent FindMultiTemplateScrollViewNavigationComponent(FVector direction, UINavigationWrapMode wrapMode, UINavigationPriorityMode priorityMode, ELGUINavigationDirection directionType, float navigateTolerance, float navigateToleranceReverse)
		{
			ValueTuple<UUISelectableComponent, bool, int> valueTuple = this.OnFindMultiTemplateScrollViewNavigationComponent(direction, wrapMode, priorityMode, navigateTolerance, navigateToleranceReverse);
			UUISelectableComponent item = valueTuple.Item1;
			object obj;
			if (item == null)
			{
				obj = null;
			}
			else
			{
				AActor owner = item.GetOwner();
				obj = ((owner != null) ? owner.GetComponentByClass(TsUiNavigationBehaviorListener.StaticClass()) : null);
			}
			TsUiNavigationBehaviorListener targetListener = obj as TsUiNavigationBehaviorListener;
			TsUiNavigationPanelConfig panelConfig = this.Listener.PanelConfig;
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = (panelConfig != null) ? panelConfig.HandleAfterFindOpposite(directionType, this.Listener, targetListener, valueTuple.Item2) : null;
			if (valueTuple.Item3 != -1 && tsUiNavigationBehaviorListener == null)
			{
				FindMultiTemplateNavigationListener findMultiTemplateNavigationListener = new FindMultiTemplateNavigationListener();
				findMultiTemplateNavigationListener.PanelConfig = this.Listener.PanelConfig;
				findMultiTemplateNavigationListener.AddParam(new object[]
				{
					this.Listener,
					valueTuple.Item3
				});
				TsUiNavigationPanelConfig panelConfig2 = this.Listener.PanelConfig;
				if (panelConfig2 != null)
				{
					panelConfig2.SetFindNavigationAction(findMultiTemplateNavigationListener);
				}
				ControllerBase<UiNavigationNewController>.Instance.MarkViewHandleRefreshNavigationDirty();
			}
			if (tsUiNavigationBehaviorListener == null)
			{
				return null;
			}
			return tsUiNavigationBehaviorListener.GetSelectableComponent();
		}

		// Token: 0x0603323F RID: 209471 RVA: 0x00CCE27A File Offset: 0x00CCC47A
		public void MultiTemplateScrollViewScrollToIndex(int findIndex, bool bScrollToTop)
		{
			(this.Listener.ScrollProxy.ScrollView as UUIMultiTemplateScrollViewComponent).TryScrollToGridIndex(findIndex, bScrollToTop);
		}

		// Token: 0x06033240 RID: 209472 RVA: 0x00CCE298 File Offset: 0x00CCC498
		public void NotifyFocusListener(bool isSameListener)
		{
			this.OnNotifyFocusListener(isSameListener);
		}

		// Token: 0x06033241 RID: 209473 RVA: 0x00CCE2A4 File Offset: 0x00CCC4A4
		protected bool IsAllowNavigationByGroup()
		{
			if (string.IsNullOrEmpty(this.Listener.GroupName))
			{
				return false;
			}
			NavigationGroup navigationGroup = this.Listener.PanelConfig.GetNavigationGroup(this.Listener.GroupName);
			return navigationGroup != null && navigationGroup.GroupType == 0;
		}

		// Token: 0x06033242 RID: 209474 RVA: 0x00CCE2F4 File Offset: 0x00CCC4F4
		protected virtual string OnGetTipsTextId()
		{
			string result;
			if (!this.Listener.HotKeyTipsTextIdMap.TryGetValue(EHotKeyNameStateType.Normal, out result))
			{
				return string.Empty;
			}
			return result;
		}

		// Token: 0x06033243 RID: 209475 RVA: 0x00CCE31D File Offset: 0x00CCC51D
		protected virtual bool OnCheckFindNavigationBefore()
		{
			return true;
		}

		// Token: 0x06033244 RID: 209476 RVA: 0x00CCE320 File Offset: 0x00CCC520
		protected virtual bool OnCheckFindOpposite()
		{
			return true;
		}

		// Token: 0x06033245 RID: 209477 RVA: 0x00CCE323 File Offset: 0x00CCC523
		[NullableContext(2)]
		protected virtual bool OnCheckFindNavigationAfter(TsUiNavigationBehaviorListener findListener)
		{
			return true;
		}

		// Token: 0x06033246 RID: 209478 RVA: 0x00CCE326 File Offset: 0x00CCC526
		protected virtual bool IsAllowNavigationBySelfParam(ULGUIPointerEventData eventData)
		{
			return true;
		}

		// Token: 0x06033247 RID: 209479 RVA: 0x00CCE32C File Offset: 0x00CCC52C
		protected virtual bool OnCanFocusInScrollOrLayout()
		{
			return this.IsInteractive && this.Selectable.RootUIComp.Get().IsUIActiveInHierarchy();
		}

		// Token: 0x06033248 RID: 209480 RVA: 0x00CCE360 File Offset: 0x00CCC560
		protected virtual bool OnHandlePointerEnter(ULGUIPointerEventData eventData)
		{
			return true;
		}

		// Token: 0x06033249 RID: 209481 RVA: 0x00CCE363 File Offset: 0x00CCC563
		protected virtual bool OnIsIgnoreScrollOrLayoutCheck()
		{
			return false;
		}

		// Token: 0x0603324A RID: 209482 RVA: 0x00CCE368 File Offset: 0x00CCC568
		[NullableContext(2)]
		protected virtual UUISelectableComponent OnFindLoopScrollViewNavigationComponent(FVector direction, UINavigationWrapMode wrapMode)
		{
			UUISelectableComponent uuiselectableComponent = null;
			if (this.Listener.HasLoopScrollView())
			{
				int i = 0;
				TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = this.Listener;
				while (i < 20)
				{
					uuiselectableComponent = this.Listener.ScrollProxy.ScrollView.FindNavigationComponent(tsUiNavigationBehaviorListener.GetSelectableComponent(), direction, wrapMode, false);
					if (uuiselectableComponent == null)
					{
						break;
					}
					object obj;
					if (uuiselectableComponent == null)
					{
						obj = null;
					}
					else
					{
						AActor owner = uuiselectableComponent.GetOwner();
						obj = ((owner != null) ? owner.GetComponentByClass(TsUiNavigationBehaviorListener.StaticClass()) : null);
					}
					tsUiNavigationBehaviorListener = (obj as TsUiNavigationBehaviorListener);
					i++;
					if (tsUiNavigationBehaviorListener != null && tsUiNavigationBehaviorListener.IsCanFocus())
					{
						break;
					}
				}
			}
			return uuiselectableComponent;
		}

		// Token: 0x0603324B RID: 209483 RVA: 0x00CCE3F0 File Offset: 0x00CCC5F0
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		protected virtual ValueTuple<UUISelectableComponent, bool, int> OnFindMultiTemplateScrollViewNavigationComponent(FVector direction, UINavigationWrapMode wrapMode, UINavigationPriorityMode priorityMode, float navigateTolerance, float navigateToleranceReverse)
		{
			UUISelectableComponent item = null;
			int num = -1;
			if (!this.Listener.HasMultiTemplateScrollView())
			{
				return new ValueTuple<UUISelectableComponent, bool, int>(item, true, num);
			}
			UUIMultiTemplateScrollViewComponent uuimultiTemplateScrollViewComponent = this.Listener.ScrollProxy.ScrollView as UUIMultiTemplateScrollViewComponent;
			num = uuimultiTemplateScrollViewComponent.FindNavigationIndex(this.Listener.GetSelectableComponent(), direction, wrapMode, priorityMode, navigateTolerance, navigateToleranceReverse);
			if (num == -1)
			{
				return new ValueTuple<UUISelectableComponent, bool, int>(item, true, num);
			}
			if (!uuimultiTemplateScrollViewComponent.IsInDisplayRange(num, true))
			{
				item = null;
			}
			else
			{
				item = uuimultiTemplateScrollViewComponent.GetNavigationComponentByGridIndex(num);
			}
			int gridIndexByChildComponent = uuimultiTemplateScrollViewComponent.GetGridIndexByChildComponent(this.Listener.GetSelectableComponent());
			bool multiTemplateScrollPositiveFind = this.Listener.ScrollProxy.GetMultiTemplateScrollPositiveFind(direction, gridIndexByChildComponent, num);
			NavigationGroup navigationGroup = this.Listener.GetNavigationGroup();
			if (!multiTemplateScrollPositiveFind && !this.Listener.ScrollProxy.IsNeedReturnBestPick(direction, navigationGroup))
			{
				this.Listener.ScrollProxy.SetScrollProgress(direction.X < 0f || direction.Z > 0f);
				return new ValueTuple<UUISelectableComponent, bool, int>(null, multiTemplateScrollPositiveFind, -1);
			}
			this.Listener.ScrollProxy.TryMultiTemplateScrollToGridIndex(gridIndexByChildComponent, num);
			if (this.Listener.ScrollProxy.IsNeedSlideToEdge(gridIndexByChildComponent, num, multiTemplateScrollPositiveFind, navigationGroup))
			{
				this.Listener.ScrollProxy.SetScrollProgress(direction.X > 0f || direction.Z < 0f);
			}
			return new ValueTuple<UUISelectableComponent, bool, int>(item, multiTemplateScrollPositiveFind, num);
		}

		// Token: 0x0603324C RID: 209484 RVA: 0x00CCE550 File Offset: 0x00CCC750
		private bool IsAllowCrossNavigationGroup()
		{
			if (this.Listener.PanelConfig == null)
			{
				return false;
			}
			if (UiNavigationGlobalData.IsAllowCrossNavigationGroup)
			{
				return true;
			}
			TsUiNavigationBehaviorListener focusListener = this.Listener.PanelConfig.GetFocusListener();
			if (focusListener == null)
			{
				return true;
			}
			NavigationGroup navigationGroup = this.Listener.PanelConfig.GetNavigationGroup(focusListener.GroupName);
			return navigationGroup != null && !(navigationGroup.GroupName != this.Listener.GroupName) && (navigationGroup.AllowNavigationInSelfDynamic || ((this.Listener.ScrollViewActor != null || focusListener.ScrollViewActor != null || this.Listener.LayoutActor != null || focusListener.LayoutActor != null) && this.Listener.ScrollViewActor == focusListener.ScrollViewActor && this.Listener.LayoutActor == focusListener.LayoutActor));
		}

		// Token: 0x0603324D RID: 209485 RVA: 0x00CCE622 File Offset: 0x00CCC822
		protected virtual void OnNotifyFocusListener(bool isSameListener)
		{
		}

		// Token: 0x0603324E RID: 209486
		protected abstract bool OnHandlePointerSelect(ULGUIPointerEventData eventData);

		// Token: 0x0603324F RID: 209487 RVA: 0x00CCE624 File Offset: 0x00CCC824
		protected virtual void OnInit()
		{
		}

		// Token: 0x06033250 RID: 209488 RVA: 0x00CCE626 File Offset: 0x00CCC826
		protected virtual void OnStart()
		{
		}

		// Token: 0x06033251 RID: 209489 RVA: 0x00CCE628 File Offset: 0x00CCC828
		protected virtual void OnClear()
		{
		}

		// Token: 0x06033252 RID: 209490 RVA: 0x00CCE62A File Offset: 0x00CCC82A
		public new ENavigationSelectableDefine GetType()
		{
			return this.Type;
		}

		// Token: 0x0401DB81 RID: 121729
		protected bool IsInteractive = true;

		// Token: 0x0401DB82 RID: 121730
		[Nullable(2)]
		protected ULGUIBehaviour Selectable = selectable;

		// Token: 0x0401DB83 RID: 121731
		[Nullable(2)]
		protected TsUiNavigationBehaviorListener Listener;

		// Token: 0x0401DB84 RID: 121732
		[Nullable(2)]
		protected SpecialPanelHandleBase PanelHandle;

		// Token: 0x0401DB85 RID: 121733
		protected ENavigationSelectableDefine Type = (ENavigationSelectableDefine)Enum.Parse(typeof(ENavigationSelectableDefine), type);

		// Token: 0x0401DB86 RID: 121734
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected List<string> ParamList = paramList;
	}
}
