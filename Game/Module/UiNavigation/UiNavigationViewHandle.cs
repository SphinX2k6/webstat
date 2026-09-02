using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CE0 RID: 19680
	[NullableContext(1)]
	[Nullable(0)]
	public class UiNavigationViewHandle
	{
		// Token: 0x170087CF RID: 34767
		// (get) Token: 0x0603332F RID: 209711 RVA: 0x00CD2066 File Offset: 0x00CD0266
		// (set) Token: 0x06033330 RID: 209712 RVA: 0x00CD206E File Offset: 0x00CD026E
		public EViewHandleState State
		{
			get
			{
				return this.StateInternal;
			}
			set
			{
				this.StateInternal != value;
				this.StateInternal = value;
			}
		}

		// Token: 0x06033331 RID: 209713 RVA: 0x00CD2084 File Offset: 0x00CD0284
		public UiNavigationViewHandle(int tagId, TsUiNavigationPanelConfig panelConfig)
		{
			this.TagId = tagId;
			this.ViewName = panelConfig.ViewName;
			this.MainPanel = panelConfig;
			this.CurrentPanel = panelConfig;
			this.ScrollBallData = new NavigationScrollbarData();
			this.InitGamepadControlMouse();
		}

		// Token: 0x06033332 RID: 209714 RVA: 0x00CD211C File Offset: 0x00CD031C
		private void ResetState()
		{
			this.State = EViewHandleState.None;
			if (this.FocusListener != null)
			{
				ControllerBase<UiNavigationNewController>.Instance.SwitchNavigationFocus(null);
			}
			foreach (TsUiNavigationPanelConfig tsUiNavigationPanelConfig in this.PanelConfigMap.Values)
			{
				SpecialPanelHandleBase panelHandle = tsUiNavigationPanelConfig.GetPanelHandle();
				if (panelHandle != null)
				{
					panelHandle.ResetGroupConfigMemory();
				}
			}
		}

		// Token: 0x06033333 RID: 209715 RVA: 0x00CD219C File Offset: 0x00CD039C
		public int GetDepth()
		{
			if (this.CurrentPanel == null || !this.CurrentPanel.IsValid() || !this.CurrentPanel.RootUIComp.IsValid(false, false))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiNavigation;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "查找对象深度索引异常,对象无效";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", this.ViewName);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return 0;
			}
			return this.CurrentPanel.RootUIComp.Get().GetFlattenHierarchyIndex();
		}

		// Token: 0x06033334 RID: 209716 RVA: 0x00CD221E File Offset: 0x00CD041E
		private bool HasNavigation()
		{
			return this.State == EViewHandleState.HasNavigation;
		}

		// Token: 0x06033335 RID: 209717 RVA: 0x00CD2230 File Offset: 0x00CD0430
		private bool NeedFindAgain()
		{
			return this.State == EViewHandleState.NavigateNext || this.State == EViewHandleState.None;
		}

		// Token: 0x06033336 RID: 209718 RVA: 0x00CD2256 File Offset: 0x00CD0456
		public bool HasNavigationButDisActive()
		{
			return this.State == EViewHandleState.HasNavigationButDisActive;
		}

		// Token: 0x06033337 RID: 209719 RVA: 0x00CD2268 File Offset: 0x00CD0468
		public bool IsNonNavigation()
		{
			return this.State == EViewHandleState.NonNavigation;
		}

		// Token: 0x06033338 RID: 209720 RVA: 0x00CD227A File Offset: 0x00CD047A
		public void SetIsInController(bool value)
		{
			if (this.IsInController == value)
			{
				return;
			}
			this.IsInController = value;
			this.UpdateAllHotKeyVisibleMode();
			if (!value)
			{
				this.PauseNavigation();
			}
		}

		// Token: 0x06033339 RID: 209721 RVA: 0x00CD229C File Offset: 0x00CD049C
		public void ResetStateIfNullFocus()
		{
			if (this.FocusListener == null && this.IsNonNavigation())
			{
				this.State = EViewHandleState.None;
			}
		}

		// Token: 0x0603333A RID: 209722 RVA: 0x00CD22B9 File Offset: 0x00CD04B9
		public void SetIsUsable(bool value)
		{
			this.IsUsable = value;
			if (!value)
			{
				this.ResetState();
			}
			Singleton<UiNavigationViewManager>.Instance.MarkCalculateCurrentPanelDirty();
		}

		// Token: 0x0603333B RID: 209723 RVA: 0x00CD22D5 File Offset: 0x00CD04D5
		public bool GetIsUsable()
		{
			return this.IsUsable;
		}

		// Token: 0x0603333C RID: 209724 RVA: 0x00CD22DD File Offset: 0x00CD04DD
		public void SetIsActive(bool value)
		{
			if (this.IsActive == value)
			{
				return;
			}
			this.IsActive = value;
			Singleton<UiNavigationViewManager>.Instance.MarkCalculateCurrentPanelDirty();
		}

		// Token: 0x0603333D RID: 209725 RVA: 0x00CD22FA File Offset: 0x00CD04FA
		public bool GetIsActive()
		{
			return this.IsActive;
		}

		// Token: 0x0603333E RID: 209726 RVA: 0x00CD2302 File Offset: 0x00CD0502
		public TsUiNavigationBehaviorListener GetFocusListener()
		{
			return this.FocusListener;
		}

		// Token: 0x0603333F RID: 209727 RVA: 0x00CD230C File Offset: 0x00CD050C
		public List<TsUiNavigationBehaviorListener> GetActiveListenerListByTag(string tag)
		{
			List<TsUiNavigationBehaviorListener> list = new List<TsUiNavigationBehaviorListener>();
			foreach (TsUiNavigationPanelConfig tsUiNavigationPanelConfig in this.PanelConfigMap.Values)
			{
				foreach (TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener in tsUiNavigationPanelConfig.GetListenerListByTag(tag))
				{
					if (tsUiNavigationBehaviorListener.IsListenerActive())
					{
						list.Add(tsUiNavigationBehaviorListener);
					}
				}
			}
			return list;
		}

		// Token: 0x06033340 RID: 209728 RVA: 0x00CD23B0 File Offset: 0x00CD05B0
		[return: Nullable(2)]
		public TsUiNavigationBehaviorListener GetActiveListenerByTag(string tag)
		{
			if (!(tag == "tag1"))
			{
				return this.GetActiveListenerByNormalTag(tag);
			}
			return this.GetActiveListenerByExitTag();
		}

		// Token: 0x06033341 RID: 209729 RVA: 0x00CD23D0 File Offset: 0x00CD05D0
		[return: Nullable(2)]
		private TsUiNavigationBehaviorListener GetActiveListenerByNormalTag(string tag)
		{
			foreach (TsUiNavigationPanelConfig tsUiNavigationPanelConfig in this.PanelConfigMap.Values)
			{
				foreach (TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener in tsUiNavigationPanelConfig.GetListenerListByTag(tag))
				{
					if (tsUiNavigationBehaviorListener.IsListenerActive())
					{
						return tsUiNavigationBehaviorListener;
					}
				}
			}
			return null;
		}

		// Token: 0x06033342 RID: 209730 RVA: 0x00CD246C File Offset: 0x00CD066C
		[NullableContext(2)]
		private TsUiNavigationBehaviorListener GetActiveListenerByExitTag()
		{
			List<TsUiNavigationBehaviorListener> list = new List<TsUiNavigationBehaviorListener>();
			foreach (TsUiNavigationPanelConfig tsUiNavigationPanelConfig in this.PanelConfigMap.Values)
			{
				foreach (TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener in tsUiNavigationPanelConfig.GetPanelHandle().GetListenerSet())
				{
					if (tsUiNavigationBehaviorListener.IsListenerActive() && tsUiNavigationBehaviorListener.TagArray.Contains("tag1"))
					{
						list.Add(tsUiNavigationBehaviorListener);
					}
				}
			}
			list.Sort(delegate(TsUiNavigationBehaviorListener aListener, TsUiNavigationBehaviorListener bListener)
			{
				if (aListener.ExitTagPriority >= bListener.ExitTagPriority)
				{
					return 1;
				}
				return -1;
			});
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		// Token: 0x06033343 RID: 209731 RVA: 0x00CD255C File Offset: 0x00CD075C
		[return: Nullable(2)]
		public NavigationGroup GetActiveNavigationGroupByNameCheckAll(string groupName)
		{
			NavigationGroup navigationGroup = null;
			foreach (TsUiNavigationPanelConfig tsUiNavigationPanelConfig in this.PanelConfigMap.Values)
			{
				navigationGroup = tsUiNavigationPanelConfig.GetNavigationGroup(groupName);
				if (UiNavigationLogic.HasActiveListenerInGroup(navigationGroup))
				{
					return navigationGroup;
				}
			}
			return navigationGroup;
		}

		// Token: 0x06033344 RID: 209732 RVA: 0x00CD25C4 File Offset: 0x00CD07C4
		[return: Nullable(2)]
		public NavigationGroup GetNavigationGroupByName(string groupName)
		{
			TsUiNavigationPanelConfig currentPanel = this.CurrentPanel;
			if (currentPanel == null)
			{
				return null;
			}
			return currentPanel.GetNavigationGroup(groupName);
		}

		// Token: 0x06033345 RID: 209733 RVA: 0x00CD25D8 File Offset: 0x00CD07D8
		private void FindSuitablePanel()
		{
			foreach (TsUiNavigationPanelConfig tsUiNavigationPanelConfig in this.PanelConfigMap.Values)
			{
				if (tsUiNavigationPanelConfig.IsInActive)
				{
					this.CurrentPanel = tsUiNavigationPanelConfig;
					break;
				}
			}
		}

		// Token: 0x06033346 RID: 209734 RVA: 0x00CD263C File Offset: 0x00CD083C
		public void AddPanelConfig(int tagId, TsUiNavigationPanelConfig panelConfig)
		{
			panelConfig.SetViewHandle(this);
			this.PanelConfigMap[tagId] = panelConfig;
			this.UpdateHotKeyVisibleMode(panelConfig);
			this.SetCurrentAddPanel(panelConfig);
			this.SkipMainPanelFallbackOnce = false;
		}

		// Token: 0x06033347 RID: 209735 RVA: 0x00CD2668 File Offset: 0x00CD0868
		public void DeletePanelConfig(int tagId)
		{
			TsUiNavigationPanelConfig tsUiNavigationPanelConfig;
			if (!this.PanelConfigMap.Remove(tagId, out tsUiNavigationPanelConfig))
			{
				return;
			}
			this.NonIndependentPanelFocusCache.Remove(tsUiNavigationPanelConfig);
			if (this.CurrentPanel == tsUiNavigationPanelConfig)
			{
				this.CurrentPanel = null;
				this.FocusListener = null;
				this.FindSuitableNavigation(false);
			}
			if (this.CurrentAddPanel == tsUiNavigationPanelConfig)
			{
				this.CurrentAddPanel = null;
				TsUiNavigationBehaviorListener focusListener = this.FocusListener;
				if (((focusListener != null) ? focusListener.PanelConfig : null) == tsUiNavigationPanelConfig)
				{
					this.FocusListener = null;
					this.FindSuitableNavigation(false);
				}
			}
			tsUiNavigationPanelConfig.SetViewHandle(null);
			this.DeleteScrollData(tsUiNavigationPanelConfig.TsScrollBarGroup);
		}

		// Token: 0x06033348 RID: 209736 RVA: 0x00CD26F7 File Offset: 0x00CD08F7
		public Dictionary<int, TsUiNavigationPanelConfig> GetPanelConfigMap()
		{
			return this.PanelConfigMap;
		}

		// Token: 0x06033349 RID: 209737 RVA: 0x00CD2700 File Offset: 0x00CD0900
		[NullableContext(2)]
		public TsUiNavigationPanelConfig GetPanelConfigByType(ESpecialPanelHandleDefine type)
		{
			foreach (TsUiNavigationPanelConfig tsUiNavigationPanelConfig in this.PanelConfigMap.Values)
			{
				if (tsUiNavigationPanelConfig.GetPanelHandle().GetType() == type)
				{
					return tsUiNavigationPanelConfig;
				}
			}
			return null;
		}

		// Token: 0x0603334A RID: 209738 RVA: 0x00CD276C File Offset: 0x00CD096C
		public TsUiNavigationPanelConfig GetCurrentPanel()
		{
			return this.CurrentPanel;
		}

		// Token: 0x0603334B RID: 209739 RVA: 0x00CD2774 File Offset: 0x00CD0974
		public void ClearPanelConfig()
		{
			this.PanelConfigMap.Clear();
			this.NonIndependentPanelFocusCache.Clear();
			GamepadControlMouse gamepadControlInternal = this.GamepadControlInternal;
			if (gamepadControlInternal != null)
			{
				gamepadControlInternal.Clear();
			}
			this.CurrentPanel = null;
		}

		// Token: 0x0603334C RID: 209740 RVA: 0x00CD27A4 File Offset: 0x00CD09A4
		public void SetCurrentAddPanel(TsUiNavigationPanelConfig panelConfig)
		{
			this.CurrentAddPanel = panelConfig;
			UiNavigationGlobalData.NeedRefreshPanelId = this.TagId;
		}

		// Token: 0x0603334D RID: 209741 RVA: 0x00CD27B8 File Offset: 0x00CD09B8
		public bool HasAnyPanelActive()
		{
			using (Dictionary<int, TsUiNavigationPanelConfig>.ValueCollection.Enumerator enumerator = this.PanelConfigMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsInActive)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0603334E RID: 209742 RVA: 0x00CD2818 File Offset: 0x00CD0A18
		private void ResumeNavigation()
		{
			TsUiNavigationBehaviorListener focusListener = this.FocusListener;
			bool flag;
			if (focusListener == null)
			{
				flag = false;
			}
			else
			{
				TsUiNavigationPanelConfig panelConfig = focusListener.PanelConfig;
				bool? flag2 = (panelConfig != null) ? new bool?(panelConfig.IsInActive) : null;
				bool flag3 = false;
				flag = (flag2.GetValueOrDefault() == flag3 & flag2 != null);
			}
			if (flag && !this.HasOtherActiveSubPanel())
			{
				return;
			}
			TsUiNavigationBehaviorListener focusListener2 = this.FocusListener;
			if (focusListener2 != null && focusListener2.IsValid() && focusListener2.GetScrollOrLayoutActor() != null && focusListener2.IsInScrollOrLayoutAnimation())
			{
				NavigationGroup navigationGroup = focusListener2.GetNavigationGroup();
				if (navigationGroup == null || navigationGroup.WaitScrollAnimation)
				{
					return;
				}
			}
			this.ScrollBallData.ResumeLastListener();
			TsUiNavigationBehaviorListener resumeListener = this.GetResumeListener();
			if (resumeListener != null)
			{
				this.State = EViewHandleState.HasNavigation;
				ControllerBase<UiNavigationNewController>.Instance.SwitchNavigationFocus(resumeListener);
				return;
			}
			this.State = EViewHandleState.None;
			this.FocusListener = null;
		}

		// Token: 0x0603334F RID: 209743 RVA: 0x00CD28E8 File Offset: 0x00CD0AE8
		private bool HasOtherActiveSubPanel()
		{
			TsUiNavigationBehaviorListener focusListener = this.FocusListener;
			TsUiNavigationPanelConfig tsUiNavigationPanelConfig = (focusListener != null) ? focusListener.PanelConfig : null;
			foreach (TsUiNavigationPanelConfig tsUiNavigationPanelConfig2 in this.PanelConfigMap.Values)
			{
				if (tsUiNavigationPanelConfig2 != tsUiNavigationPanelConfig && tsUiNavigationPanelConfig2 != this.MainPanel && tsUiNavigationPanelConfig2.IsInActive)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06033350 RID: 209744 RVA: 0x00CD2968 File Offset: 0x00CD0B68
		[NullableContext(2)]
		private TsUiNavigationBehaviorListener GetResumeListener()
		{
			TsUiNavigationBehaviorListener focusListener = this.FocusListener;
			if (focusListener == null || !focusListener.IsValid())
			{
				return null;
			}
			if (this.FocusListener.IsInScrollOrLayoutCanFocus())
			{
				if (this.FocusListener.ScrollProxy == null || !this.FocusListener.ScrollProxy.HasMultiTemplateScrollView())
				{
					return this.FocusListener;
				}
				UiNavigationScrollProxy scrollProxy = this.FocusListener.ScrollProxy;
				if (scrollProxy == null)
				{
					return null;
				}
				return scrollProxy.GetCurrentFocusListenerInMultiTemplateScrollView();
			}
			else
			{
				NavigationGroup navigationGroup = this.FocusListener.GetNavigationGroup();
				AActor scrollOrLayoutActor = this.FocusListener.GetScrollOrLayoutActor();
				int i = 0;
				int count = navigationGroup.ListenerList.Count;
				while (i < count)
				{
					TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = navigationGroup.ListenerList[i];
					if (tsUiNavigationBehaviorListener.IsScrollOrLayoutActor() && (scrollOrLayoutActor == null || tsUiNavigationBehaviorListener.GetScrollOrLayoutActor() == scrollOrLayoutActor) && tsUiNavigationBehaviorListener.IsInScrollOrLayoutCanFocus())
					{
						return tsUiNavigationBehaviorListener;
					}
					i++;
				}
				if (this.FocusListener.IsListenerActive())
				{
					return this.FocusListener;
				}
				return null;
			}
		}

		// Token: 0x06033351 RID: 209745 RVA: 0x00CD2A4D File Offset: 0x00CD0C4D
		private void PauseNavigation()
		{
			if (this.HasNavigation())
			{
				this.State = EViewHandleState.HasNavigationButDisActive;
				UiNavigationModel instance = ModelBase<UiNavigationModel>.Instance;
				if (instance != null)
				{
					instance.SetCursorFollowItem(null);
				}
				TsUiNavigationBehaviorListener focusListener = this.FocusListener;
				if (focusListener == null)
				{
					return;
				}
				UiNavigationScrollProxy scrollProxy = focusListener.ScrollProxy;
				if (scrollProxy == null)
				{
					return;
				}
				scrollProxy.RecordFocusListenerIndexInMultiTemplateScrollView();
			}
		}

		// Token: 0x06033352 RID: 209746 RVA: 0x00CD2A8D File Offset: 0x00CD0C8D
		public void FindDefaultNavigation()
		{
			if (this.SwitchNavigationFocusListener != null)
			{
				return;
			}
			if (this.HasNavigationButDisActive())
			{
				this.ResumeNavigation();
				return;
			}
			if (this.NeedFindAgain())
			{
				this.FindSuitableNavigation(true);
			}
		}

		// Token: 0x06033353 RID: 209747 RVA: 0x00CD2AB8 File Offset: 0x00CD0CB8
		[NullableContext(2)]
		private TsUiNavigationBehaviorListener TryRestoreNonIndependentPanelFocus()
		{
			foreach (KeyValuePair<TsUiNavigationPanelConfig, TsUiNavigationBehaviorListener> keyValuePair in this.NonIndependentPanelFocusCache)
			{
				TsUiNavigationPanelConfig tsUiNavigationPanelConfig;
				TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener;
				keyValuePair.Deconstruct(out tsUiNavigationPanelConfig, out tsUiNavigationBehaviorListener);
				TsUiNavigationPanelConfig tsUiNavigationPanelConfig2 = tsUiNavigationPanelConfig;
				TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener2 = tsUiNavigationBehaviorListener;
				if (tsUiNavigationPanelConfig2.IsInActive)
				{
					this.NonIndependentPanelFocusCache.Remove(tsUiNavigationPanelConfig2);
					if (tsUiNavigationBehaviorListener2.IsValid() && (tsUiNavigationBehaviorListener2.IsInScrollOrLayoutCanFocus() || tsUiNavigationBehaviorListener2.IsListenerActive()))
					{
						return tsUiNavigationBehaviorListener2;
					}
				}
			}
			return null;
		}

		// Token: 0x06033354 RID: 209748 RVA: 0x00CD2B4C File Offset: 0x00CD0D4C
		public void FindSuitableNavigation(bool isDefault)
		{
			TsUiNavigationPanelConfig mainPanel = this.MainPanel;
			if (mainPanel != null && mainPanel.IsGamepadControlMouse)
			{
				return;
			}
			if (this.CurrentPanel == null || this.ResetCurrentPanelDirty)
			{
				this.ResetCurrentPanelDirty = false;
				this.FindSuitablePanel();
			}
			if (this.CurrentPanel == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiNavigation;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "找不到合适的导航面板";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", this.ViewName);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (this.FocusListener != null)
			{
				this.State = EViewHandleState.HasNavigation;
				return;
			}
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = this.TryRestoreNonIndependentPanelFocus();
			if (tsUiNavigationBehaviorListener != null)
			{
				this.State = EViewHandleState.HasNavigation;
				ControllerBase<UiNavigationNewController>.Instance.SwitchNavigationFocus(tsUiNavigationBehaviorListener);
				return;
			}
			this.CurrentPanel.FindSuitableNavigation(isDefault);
			if (this.IsNonNavigation())
			{
				this.MarkRefreshHotKeyDirty();
				this.FindNavigationInAllPanel(this.CurrentPanel, isDefault);
			}
		}

		// Token: 0x06033355 RID: 209749 RVA: 0x00CD2C20 File Offset: 0x00CD0E20
		public void FindAddPanelConfigNavigation()
		{
			if (!this.IsNonNavigation())
			{
				return;
			}
			if (this.CurrentAddPanel == null)
			{
				return;
			}
			if (!this.CurrentAddPanel.Independent)
			{
				TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = this.TryRestoreNonIndependentPanelFocus();
				if (tsUiNavigationBehaviorListener != null)
				{
					this.State = EViewHandleState.HasNavigation;
					ControllerBase<UiNavigationNewController>.Instance.SwitchNavigationFocus(tsUiNavigationBehaviorListener);
					return;
				}
			}
			this.CurrentAddPanel.FindSuitableNavigation(false);
			if (this.IsNonNavigation())
			{
				this.FindNavigationInAllPanel(this.CurrentAddPanel, false);
			}
		}

		// Token: 0x06033356 RID: 209750 RVA: 0x00CD2C8E File Offset: 0x00CD0E8E
		public void NotifyWaitingScrollPanelHidden()
		{
			this.SkipMainPanelFallbackOnce = true;
		}

		// Token: 0x06033357 RID: 209751 RVA: 0x00CD2C98 File Offset: 0x00CD0E98
		private void FindNavigationInAllPanel(TsUiNavigationPanelConfig excludePanelConfig, bool isDefault)
		{
			if (this.SkipMainPanelFallbackOnce)
			{
				this.SkipMainPanelFallbackOnce = false;
				this.State = EViewHandleState.NavigateNext;
				return;
			}
			if (excludePanelConfig.FirstFindFromSubPanelWhenFindNone)
			{
				foreach (TsUiNavigationPanelConfig tsUiNavigationPanelConfig in this.PanelConfigMap.Values)
				{
					if (tsUiNavigationPanelConfig != excludePanelConfig && tsUiNavigationPanelConfig != this.MainPanel)
					{
						if (!this.IsNonNavigation())
						{
							break;
						}
						tsUiNavigationPanelConfig.FindSuitableNavigation(isDefault);
					}
				}
				if (this.IsNonNavigation())
				{
					TsUiNavigationPanelConfig mainPanel = this.MainPanel;
					if (mainPanel == null)
					{
						return;
					}
					mainPanel.FindSuitableNavigation(isDefault);
					return;
				}
			}
			else
			{
				foreach (TsUiNavigationPanelConfig tsUiNavigationPanelConfig2 in this.PanelConfigMap.Values)
				{
					if (tsUiNavigationPanelConfig2 != excludePanelConfig)
					{
						if (!this.IsNonNavigation())
						{
							break;
						}
						tsUiNavigationPanelConfig2.FindSuitableNavigation(isDefault);
					}
				}
			}
		}

		// Token: 0x06033358 RID: 209752 RVA: 0x00CD2D9C File Offset: 0x00CD0F9C
		public void NotifySuitableNavigation(FindNavigationResult result)
		{
			if (result.IsFindNavigation())
			{
				this.State = EViewHandleState.HasNavigation;
				ControllerBase<UiNavigationNewController>.Instance.SwitchNavigationFocus(result.Listener);
				return;
			}
			if (!result.IsNotFindNavigation())
			{
				if (this.FocusListener != null)
				{
					ControllerBase<UiNavigationNewController>.Instance.SwitchNavigationFocus(result.Listener);
				}
				this.State = EViewHandleState.NavigateNext;
				return;
			}
			if (this.IsUsable)
			{
				this.State = EViewHandleState.NonNavigation;
				ControllerBase<UiNavigationNewController>.Instance.SwitchNavigationFocus(result.Listener);
				return;
			}
			this.ResetState();
		}

		// Token: 0x06033359 RID: 209753 RVA: 0x00CD2E23 File Offset: 0x00CD1023
		public void MarkRefreshScrollDataDirty()
		{
			this.RefreshScrollDataDirty = true;
		}

		// Token: 0x0603335A RID: 209754 RVA: 0x00CD2E2C File Offset: 0x00CD102C
		private void RefreshScrollData()
		{
			if (!this.RefreshScrollDataDirty)
			{
				return;
			}
			this.RefreshScrollDataDirty = false;
			List<NavigationGroup> list = new List<NavigationGroup>();
			foreach (TsUiNavigationPanelConfig tsUiNavigationPanelConfig in this.PanelConfigMap.Values)
			{
				if (tsUiNavigationPanelConfig.TsScrollBarGroup != null)
				{
					list.Add(tsUiNavigationPanelConfig.TsScrollBarGroup);
				}
			}
			this.AddScrollData(list);
			this.MarkRefreshHotKeyDirty();
		}

		// Token: 0x0603335B RID: 209755 RVA: 0x00CD2EB4 File Offset: 0x00CD10B4
		private void AddScrollData(List<NavigationGroup> groupArray)
		{
			this.ScrollBallData.AddScrollbar(groupArray);
		}

		// Token: 0x0603335C RID: 209756 RVA: 0x00CD2EC2 File Offset: 0x00CD10C2
		[NullableContext(2)]
		private void DeleteScrollData(NavigationGroup group)
		{
			this.ScrollBallData.DeleteScrollbar(group);
		}

		// Token: 0x0603335D RID: 209757 RVA: 0x00CD2ED0 File Offset: 0x00CD10D0
		public void FindNextScrollData()
		{
			NavigationScrollbarData scrollBallData = this.ScrollBallData;
			if (scrollBallData == null)
			{
				return;
			}
			scrollBallData.FindNextScrollbar();
		}

		// Token: 0x0603335E RID: 209758 RVA: 0x00CD2EE2 File Offset: 0x00CD10E2
		public void TryFindScrollData()
		{
			NavigationScrollbarData scrollBallData = this.ScrollBallData;
			if (scrollBallData == null)
			{
				return;
			}
			scrollBallData.TryFindScrollbar();
		}

		// Token: 0x0603335F RID: 209759 RVA: 0x00CD2EF4 File Offset: 0x00CD10F4
		public NavigationScrollbarData GetScrollbarData()
		{
			return this.ScrollBallData;
		}

		// Token: 0x06033360 RID: 209760 RVA: 0x00CD2EFC File Offset: 0x00CD10FC
		[NullableContext(2)]
		public unsafe void UpdateFocus(TsUiNavigationBehaviorListener listener)
		{
			if (this.HasGamepadControlMouse())
			{
				return;
			}
			bool flag = this.FocusListener == listener;
			if (this.FocusListener != null && !flag)
			{
				this.FocusListener.ResetNavigationState();
			}
			TsUiNavigationBehaviorListener focusListener = this.FocusListener;
			if (focusListener != null && focusListener.PanelConfig != null && !this.FocusListener.PanelConfig.Independent && this.FocusListener.PanelConfig.NeedCacheListener)
			{
				this.NonIndependentPanelFocusCache[this.FocusListener.PanelConfig] = this.FocusListener;
			}
			this.FocusListener = listener;
			if (listener != null)
			{
				this.CurrentPanel = listener.PanelConfig;
			}
			if (this.IsInController)
			{
				if (ModelBase<UiNavigationModel>.Instance.IsOpenLog)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.UiNavigation;
					ELogAuthor author = ELogAuthor.XXJ;
					string message = "设置当前的导航对象";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("DisplayName", (listener != null) ? listener.RootUIComp.Get().displayName : null);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ViewName", this.ViewName);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Path", (listener != null) ? UiNavigationUtil.GetFullPathOfActor(listener.GetOwner()) : "");
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				}
				UiNavigationLogic.UpdateNavigationListener(listener);
				if (listener != null)
				{
					this.State = EViewHandleState.HasNavigation;
					listener.ActiveNavigationState(flag);
				}
			}
			this.MarkRefreshHotKeyDirty();
		}

		// Token: 0x06033361 RID: 209761 RVA: 0x00CD3074 File Offset: 0x00CD1274
		public void ResetNavigationListener()
		{
			this.ResetState();
			this.MarkResetCurrentPanelDirty();
			this.ClearDynamicScrollViewNavigationContext();
		}

		// Token: 0x06033362 RID: 209762 RVA: 0x00CD3088 File Offset: 0x00CD1288
		public void MarkResetCurrentPanelDirty()
		{
			this.ResetCurrentPanelDirty = true;
		}

		// Token: 0x170087D0 RID: 34768
		// (get) Token: 0x06033363 RID: 209763 RVA: 0x00CD3091 File Offset: 0x00CD1291
		public bool IsListenerCanFocusByPanelConfig
		{
			get
			{
				return Singleton<UiNavigationViewManager>.Instance.CanFocusViewHandle(this);
			}
		}

		// Token: 0x06033364 RID: 209764 RVA: 0x00CD309E File Offset: 0x00CD129E
		public void UpdateHotKeyVisibleMode(TsUiNavigationPanelConfig panelConfig)
		{
			if (this.IsInController)
			{
				panelConfig.SetHotKeyVisibleMode(HotKeyViewDefine.ELogicMode.BlockView, true);
			}
			else
			{
				panelConfig.SetHotKeyVisibleMode(HotKeyViewDefine.ELogicMode.BlockView, false);
			}
			this.MarkRefreshHotKeyDirty();
		}

		// Token: 0x06033365 RID: 209765 RVA: 0x00CD30C0 File Offset: 0x00CD12C0
		public void UpdateAllHotKeyVisibleMode()
		{
			foreach (TsUiNavigationPanelConfig panelConfig in this.PanelConfigMap.Values)
			{
				this.UpdateHotKeyVisibleMode(panelConfig);
			}
		}

		// Token: 0x06033366 RID: 209766 RVA: 0x00CD3118 File Offset: 0x00CD1318
		private void RefreshHotKeyComponents()
		{
			if (!this.RefreshHotKeyDirty)
			{
				return;
			}
			this.RefreshHotKeyDirty = false;
			foreach (TsUiNavigationPanelConfig tsUiNavigationPanelConfig in this.PanelConfigMap.Values)
			{
				tsUiNavigationPanelConfig.RefreshHotKeyComponents();
			}
		}

		// Token: 0x06033367 RID: 209767 RVA: 0x00CD3180 File Offset: 0x00CD1380
		public void MarkRefreshHotKeyDirty()
		{
			this.RefreshHotKeyDirty = true;
		}

		// Token: 0x06033368 RID: 209768 RVA: 0x00CD318C File Offset: 0x00CD138C
		private void RefreshHotKeyTextId()
		{
			if (!this.RefreshHotKeyTextIdDirty)
			{
				return;
			}
			this.RefreshHotKeyTextIdDirty = false;
			foreach (TsUiNavigationPanelConfig tsUiNavigationPanelConfig in this.PanelConfigMap.Values)
			{
				tsUiNavigationPanelConfig.RefreshHotKeyTextId();
			}
		}

		// Token: 0x06033369 RID: 209769 RVA: 0x00CD31F4 File Offset: 0x00CD13F4
		public void MarkRefreshHotKeyTextIdDirty()
		{
			this.RefreshHotKeyTextIdDirty = true;
		}

		// Token: 0x0603336A RID: 209770 RVA: 0x00CD31FD File Offset: 0x00CD13FD
		private void RefreshNavigation()
		{
			if (!this.RefreshNavigationDirty)
			{
				return;
			}
			this.RefreshNavigationDirty = false;
			if (Singleton<UiNavigationViewManager>.Instance.NeedSkipFindNavigationByCache() || this.SwitchNavigationFocusListener != null)
			{
				this.IsRefreshNavigationSwallowed = true;
				return;
			}
			this.ResetState();
			this.FindSuitableNavigation(false);
		}

		// Token: 0x0603336B RID: 209771 RVA: 0x00CD3238 File Offset: 0x00CD1438
		public void RestoreSwallowedRefreshNavigation()
		{
			if (!this.IsRefreshNavigationSwallowed)
			{
				return;
			}
			this.IsRefreshNavigationSwallowed = false;
			this.RefreshNavigationDirty = true;
		}

		// Token: 0x0603336C RID: 209772 RVA: 0x00CD3251 File Offset: 0x00CD1451
		public void DiscardSwallowedRefreshNavigation()
		{
			this.IsRefreshNavigationSwallowed = false;
		}

		// Token: 0x0603336D RID: 209773 RVA: 0x00CD325A File Offset: 0x00CD145A
		public void MarkRefreshNavigationDirty(int instanceId = 0)
		{
			this.RefreshListenerInstanceId = instanceId;
			this.RefreshNavigationDirty = true;
		}

		// Token: 0x0603336E RID: 209774 RVA: 0x00CD326A File Offset: 0x00CD146A
		public void ResetNavigationDirty(int instanceId = 0)
		{
			if (this.RefreshListenerInstanceId != 0 && instanceId != 0 && this.RefreshListenerInstanceId != instanceId)
			{
				return;
			}
			this.RefreshNavigationDirty = false;
		}

		// Token: 0x0603336F RID: 209775 RVA: 0x00CD3288 File Offset: 0x00CD1488
		private void RefreshSwitchNavigationFocus()
		{
			if (this.SwitchNavigationFocusListener == null)
			{
				return;
			}
			if (!this.SwitchNavigationFocusListener.IsValid())
			{
				this.SwitchNavigationFocusListener = null;
				this.RestoreSwallowedRefreshNavigation();
				return;
			}
			ControllerBase<UiNavigationNewController>.Instance.SwitchNavigationFocus(this.SwitchNavigationFocusListener);
			this.SwitchNavigationFocusListener = null;
			this.DiscardSwallowedRefreshNavigation();
		}

		// Token: 0x06033370 RID: 209776 RVA: 0x00CD32D6 File Offset: 0x00CD14D6
		[NullableContext(2)]
		public void MarkSwitchNavigationFocusDirty(TsUiNavigationBehaviorListener listener)
		{
			this.SwitchNavigationFocusListener = listener;
		}

		// Token: 0x06033371 RID: 209777 RVA: 0x00CD32E0 File Offset: 0x00CD14E0
		private void InitGamepadControlMouse()
		{
			if (this.HasGamepadControlMouse())
			{
				this.GamepadControlInternal = new GamepadControlMouse(this.MainPanel.GamepadMouseItem, this);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiNavigation;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "UiNavigation:GamepadControlMouse 初始化手柄控制鼠标";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", this.ViewName);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}

		// Token: 0x06033372 RID: 209778 RVA: 0x00CD333B File Offset: 0x00CD153B
		private void RefreshGamepadControl(float deltaTime)
		{
			GamepadControlMouse gamepadControlInternal = this.GamepadControlInternal;
			if (gamepadControlInternal == null)
			{
				return;
			}
			gamepadControlInternal.Tick(deltaTime);
		}

		// Token: 0x06033373 RID: 209779 RVA: 0x00CD334E File Offset: 0x00CD154E
		public bool HasGamepadControlMouse()
		{
			TsUiNavigationPanelConfig mainPanel = this.MainPanel;
			return mainPanel != null && mainPanel.IsGamepadControlMouse;
		}

		// Token: 0x06033374 RID: 209780 RVA: 0x00CD3361 File Offset: 0x00CD1561
		public void CanOverridePositionByGamepad(bool value)
		{
			GamepadControlMouse gamepadControlInternal = this.GamepadControlInternal;
			if (gamepadControlInternal == null)
			{
				return;
			}
			gamepadControlInternal.CanOverridePosition(value);
		}

		// Token: 0x06033375 RID: 209781 RVA: 0x00CD3374 File Offset: 0x00CD1574
		public void SetGamepadMouseMoveForward(float value)
		{
			GamepadControlMouse gamepadControlInternal = this.GamepadControlInternal;
			if (gamepadControlInternal == null)
			{
				return;
			}
			gamepadControlInternal.MoveForwardByGamepad(value);
		}

		// Token: 0x06033376 RID: 209782 RVA: 0x00CD3387 File Offset: 0x00CD1587
		public void SetGamepadMouseMoveRight(float value)
		{
			GamepadControlMouse gamepadControlInternal = this.GamepadControlInternal;
			if (gamepadControlInternal == null)
			{
				return;
			}
			gamepadControlInternal.MoveRightByGamepad(value);
		}

		// Token: 0x06033377 RID: 209783 RVA: 0x00CD339A File Offset: 0x00CD159A
		public void SetGamepadMouseTrigger(bool isPress)
		{
			GamepadControlMouse gamepadControlInternal = this.GamepadControlInternal;
			if (gamepadControlInternal == null)
			{
				return;
			}
			gamepadControlInternal.TriggerByGamepad(isPress);
		}

		// Token: 0x06033378 RID: 209784 RVA: 0x00CD33AD File Offset: 0x00CD15AD
		public void UpdateMousePositionByItem(UUIItem uiItem)
		{
			GamepadControlMouse gamepadControlInternal = this.GamepadControlInternal;
			if (gamepadControlInternal == null)
			{
				return;
			}
			gamepadControlInternal.UpdateMousePositionByItem(uiItem);
		}

		// Token: 0x06033379 RID: 209785 RVA: 0x00CD33C0 File Offset: 0x00CD15C0
		public void UpdateMousePositionForGuide(UUIItem uiItem)
		{
			GamepadControlMouse gamepadControlInternal = this.GamepadControlInternal;
			if (gamepadControlInternal == null)
			{
				return;
			}
			gamepadControlInternal.UpdateMousePositionForGuide(uiItem);
		}

		// Token: 0x0603337A RID: 209786 RVA: 0x00CD33D3 File Offset: 0x00CD15D3
		public void ResetNavigationFocusForGuide()
		{
			GamepadControlMouse gamepadControlInternal = this.GamepadControlInternal;
			if (gamepadControlInternal == null)
			{
				return;
			}
			gamepadControlInternal.ResetNavigationFocusForGuide();
		}

		// Token: 0x0603337B RID: 209787 RVA: 0x00CD33E5 File Offset: 0x00CD15E5
		public bool IsGamepadHitListenerUseDrag()
		{
			GamepadControlMouse gamepadControlInternal = this.GamepadControlInternal;
			return gamepadControlInternal != null && gamepadControlInternal.IsNearlyListenerUseDrag();
		}

		// Token: 0x0603337C RID: 209788 RVA: 0x00CD33F8 File Offset: 0x00CD15F8
		public void SetLockUseDragState(bool value)
		{
			GamepadControlMouse gamepadControlInternal = this.GamepadControlInternal;
			if (gamepadControlInternal == null)
			{
				return;
			}
			gamepadControlInternal.SetLockUseDragState(value);
		}

		// Token: 0x0603337D RID: 209789 RVA: 0x00CD340B File Offset: 0x00CD160B
		[NullableContext(2)]
		public TsUiNavigationBehaviorListener GetHitComponentListener()
		{
			GamepadControlMouse gamepadControlInternal = this.GamepadControlInternal;
			if (gamepadControlInternal == null)
			{
				return null;
			}
			return gamepadControlInternal.GetHitComponentListener();
		}

		// Token: 0x0603337E RID: 209790 RVA: 0x00CD341E File Offset: 0x00CD161E
		[NullableContext(2)]
		public TsUiNavigationBehaviorListener GetGuideUiListener()
		{
			GamepadControlMouse gamepadControlInternal = this.GamepadControlInternal;
			if (gamepadControlInternal == null)
			{
				return null;
			}
			return gamepadControlInternal.GetGuideUiListener();
		}

		// Token: 0x0603337F RID: 209791 RVA: 0x00CD3431 File Offset: 0x00CD1631
		[NullableContext(2)]
		public TsUiNavigationBehaviorListener GetAdsorbedListener()
		{
			GamepadControlMouse gamepadControlInternal = this.GamepadControlInternal;
			if (gamepadControlInternal == null)
			{
				return null;
			}
			return gamepadControlInternal.GetAdsorbedListener();
		}

		// Token: 0x06033380 RID: 209792 RVA: 0x00CD3444 File Offset: 0x00CD1644
		public void NotifyNavigationMousePositionDragState(bool state)
		{
			GamepadControlMouse gamepadControlInternal = this.GamepadControlInternal;
			if (gamepadControlInternal == null)
			{
				return;
			}
			gamepadControlInternal.NotifyNavigationMousePositionDragState(state);
		}

		// Token: 0x06033381 RID: 209793 RVA: 0x00CD3457 File Offset: 0x00CD1657
		[NullableContext(2)]
		public Vector2D GetMouseViewportPosition()
		{
			GamepadControlMouse gamepadControlInternal = this.GamepadControlInternal;
			if (gamepadControlInternal == null)
			{
				return null;
			}
			return gamepadControlInternal.GetMouseViewportPosition();
		}

		// Token: 0x06033382 RID: 209794 RVA: 0x00CD346A File Offset: 0x00CD166A
		public bool IsNavigationMousePositionDragging()
		{
			GamepadControlMouse gamepadControlInternal = this.GamepadControlInternal;
			return gamepadControlInternal != null && gamepadControlInternal.IsNavigationMousePositionDragging();
		}

		// Token: 0x06033383 RID: 209795 RVA: 0x00CD347D File Offset: 0x00CD167D
		public void SetDynamicScrollViewNavigationContext(NavigationDynamicScrollViewFindContext context)
		{
			if (this.DynamicScrollViewNavigationContext != null)
			{
				return;
			}
			this.DynamicScrollViewNavigationContext = context;
		}

		// Token: 0x06033384 RID: 209796 RVA: 0x00CD348F File Offset: 0x00CD168F
		public void ClearDynamicScrollViewNavigationContext()
		{
			this.DynamicScrollViewNavigationContext = null;
		}

		// Token: 0x170087D1 RID: 34769
		// (get) Token: 0x06033385 RID: 209797 RVA: 0x00CD3498 File Offset: 0x00CD1698
		public bool IsWaitToFindDynamicGrid
		{
			get
			{
				return this.DynamicScrollViewNavigationContext != null;
			}
		}

		// Token: 0x06033386 RID: 209798 RVA: 0x00CD34A3 File Offset: 0x00CD16A3
		[NullableContext(2)]
		public NavigationDynamicScrollViewFindContext GetDynamicScrollViewNavigationContext()
		{
			return this.DynamicScrollViewNavigationContext;
		}

		// Token: 0x06033387 RID: 209799 RVA: 0x00CD34AB File Offset: 0x00CD16AB
		public void TickViewHandle(float deltaTime)
		{
			this.RefreshNavigation();
			this.RefreshHotKeyComponents();
			this.RefreshHotKeyTextId();
			this.RefreshScrollData();
			this.RefreshSwitchNavigationFocus();
			this.RefreshGamepadControl(deltaTime);
		}

		// Token: 0x0401DC0A RID: 121866
		public readonly int TagId;

		// Token: 0x0401DC0B RID: 121867
		public readonly string ViewName;

		// Token: 0x0401DC0C RID: 121868
		private readonly Dictionary<int, TsUiNavigationPanelConfig> PanelConfigMap = new Dictionary<int, TsUiNavigationPanelConfig>();

		// Token: 0x0401DC0D RID: 121869
		[Nullable(2)]
		public readonly TsUiNavigationPanelConfig MainPanel;

		// Token: 0x0401DC0E RID: 121870
		[Nullable(2)]
		private TsUiNavigationPanelConfig CurrentPanel;

		// Token: 0x0401DC0F RID: 121871
		[Nullable(2)]
		private TsUiNavigationPanelConfig CurrentAddPanel;

		// Token: 0x0401DC10 RID: 121872
		[Nullable(2)]
		private TsUiNavigationBehaviorListener FocusListener;

		// Token: 0x0401DC11 RID: 121873
		private bool IsInController = true;

		// Token: 0x0401DC12 RID: 121874
		private bool IsActive = true;

		// Token: 0x0401DC13 RID: 121875
		private bool IsUsable = true;

		// Token: 0x0401DC14 RID: 121876
		private readonly Dictionary<TsUiNavigationPanelConfig, TsUiNavigationBehaviorListener> NonIndependentPanelFocusCache = new Dictionary<TsUiNavigationPanelConfig, TsUiNavigationBehaviorListener>();

		// Token: 0x0401DC15 RID: 121877
		private readonly NavigationScrollbarData ScrollBallData;

		// Token: 0x0401DC16 RID: 121878
		private EViewHandleState StateInternal = EViewHandleState.None;

		// Token: 0x0401DC17 RID: 121879
		private bool ResetCurrentPanelDirty;

		// Token: 0x0401DC18 RID: 121880
		private bool SkipMainPanelFallbackOnce;

		// Token: 0x0401DC19 RID: 121881
		private readonly Stat StatsObject = Stat.Create("UiNavigationViewHandle", "", "");

		// Token: 0x0401DC1A RID: 121882
		private bool RefreshScrollDataDirty;

		// Token: 0x0401DC1B RID: 121883
		private bool RefreshHotKeyDirty;

		// Token: 0x0401DC1C RID: 121884
		private bool RefreshHotKeyTextIdDirty;

		// Token: 0x0401DC1D RID: 121885
		private bool RefreshNavigationDirty;

		// Token: 0x0401DC1E RID: 121886
		private int RefreshListenerInstanceId;

		// Token: 0x0401DC1F RID: 121887
		private bool IsRefreshNavigationSwallowed;

		// Token: 0x0401DC20 RID: 121888
		[Nullable(2)]
		private TsUiNavigationBehaviorListener SwitchNavigationFocusListener;

		// Token: 0x0401DC21 RID: 121889
		[Nullable(2)]
		private GamepadControlMouse GamepadControlInternal;

		// Token: 0x0401DC22 RID: 121890
		[Nullable(2)]
		private NavigationDynamicScrollViewFindContext DynamicScrollViewNavigationContext;
	}
}
