using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CE1 RID: 19681
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class UiNavigationViewManager : Singleton<UiNavigationViewManager>
	{
		// Token: 0x06033388 RID: 209800 RVA: 0x00CD34D2 File Offset: 0x00CD16D2
		public void Initialize()
		{
			this.AddEventListener();
			this.AddTick();
		}

		// Token: 0x06033389 RID: 209801 RVA: 0x00CD34E0 File Offset: 0x00CD16E0
		public void Clear()
		{
			this.RemoveEventListener();
			this.RemoveTick();
		}

		// Token: 0x0603338A RID: 209802 RVA: 0x00CD34EE File Offset: 0x00CD16EE
		private void PrePhysicTick(float deltaTime)
		{
			if (this.NeedSkipFindNavigationByCache())
			{
				return;
			}
			this.FindDefaultNavigation();
		}

		// Token: 0x0603338B RID: 209803 RVA: 0x00CD34FF File Offset: 0x00CD16FF
		private void EndPhysicTick(float deltaTime)
		{
			this.RefreshCurrentPanel();
			this.TickCurrentViewHandle(deltaTime);
			this.UpdateCurrentPanel();
			this.HandleCachePanelConfigToCurrentPanel();
			this.HandleCachePopPanelConfig();
			this.SetNavigationFocusForViewInternal(this.CacheUiItem, this.CacheCheckDirty);
		}

		// Token: 0x0603338C RID: 209804 RVA: 0x00CD3534 File Offset: 0x00CD1734
		private void AddTick()
		{
			Ticker ticker = Singleton<TickSystem>.Instance.Add(new Action<float>(this.PrePhysicTick), "UiNavigationViewManager", ETickingGroup.TG_PrePhysics, true, 0, false);
			this.PrePhysicsTickId = ((ticker != null) ? ticker.Id : -1);
			Ticker ticker2 = Singleton<TickSystem>.Instance.Add(new Action<float>(this.EndPhysicTick), "UiNavigationViewManager", ETickingGroup.TG_EndPhysics, true, 0, false);
			this.EndPhysicTickId = ((ticker2 != null) ? ticker2.Id : -1);
		}

		// Token: 0x0603338D RID: 209805 RVA: 0x00CD35A4 File Offset: 0x00CD17A4
		private void RemoveTick()
		{
			if (this.PrePhysicsTickId != -1)
			{
				Singleton<TickSystem>.Instance.Remove(this.PrePhysicsTickId);
				this.PrePhysicsTickId = -1;
			}
			if (this.EndPhysicTickId != -1)
			{
				Singleton<TickSystem>.Instance.Remove(this.EndPhysicTickId);
				this.EndPhysicTickId = -1;
			}
		}

		// Token: 0x0603338E RID: 209806 RVA: 0x00CD35F4 File Offset: 0x00CD17F4
		private void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.NavigationViewCreate, new Action<int, AActor>(this.NavigationViewCreate));
			Singleton<EventSystem>.Instance.Add(EEventName.NavigationViewDestroy, new Action<int, AActor>(this.NavigationViewDestroy));
			Singleton<EventSystem>.Instance.Add(EEventName.ResetNavigationListener, new Action(this.ResetNavigationListener));
		}

		// Token: 0x0603338F RID: 209807 RVA: 0x00CD3658 File Offset: 0x00CD1858
		private void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.NavigationViewCreate, new Action<int, AActor>(this.NavigationViewCreate));
			Singleton<EventSystem>.Instance.Remove(EEventName.NavigationViewDestroy, new Action<int, AActor>(this.NavigationViewDestroy));
			Singleton<EventSystem>.Instance.Remove(EEventName.ResetNavigationListener, new Action(this.ResetNavigationListener));
		}

		// Token: 0x06033390 RID: 209808 RVA: 0x00CD36BC File Offset: 0x00CD18BC
		[NullableContext(2)]
		private void NavigationViewCreate(int tagId, AActor actor)
		{
			TsUiNavigationPanelConfig tsUiNavigationPanelConfig = actor.GetComponentByClass(TsUiNavigationPanelConfig.StaticClass()) as TsUiNavigationPanelConfig;
			if (tsUiNavigationPanelConfig == null)
			{
				return;
			}
			if (Singleton<Info>.Instance.IsInTouch())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiNavigation;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "移动端出现PC配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ViewName", tsUiNavigationPanelConfig.ViewName);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (tsUiNavigationPanelConfig.Independent)
			{
				this.CreateNavigationViewHandle(tagId, tsUiNavigationPanelConfig);
				this.MarkCalculateCurrentPanelDirty();
				return;
			}
			this.CheckAndInsertPanelConfig(tagId, tsUiNavigationPanelConfig);
		}

		// Token: 0x06033391 RID: 209809 RVA: 0x00CD3740 File Offset: 0x00CD1940
		private void CheckAndInsertPanelConfig(int tagId, TsUiNavigationPanelConfig panelConfig)
		{
			if (panelConfig.ViewName != "弹窗通用")
			{
				this.InsertNavigationViewPanelConfig(tagId, panelConfig);
				return;
			}
			TArray<UActorComponent> componentsInChildren = ULGUIBPLibrary.GetComponentsInChildren(panelConfig.GetOwner(), TsUiNavigationPanelConfig.StaticClass(), false);
			if (componentsInChildren.Num() > 0)
			{
				int i = componentsInChildren.Num() - 1;
				while (i >= 0)
				{
					TsUiNavigationPanelConfig tsUiNavigationPanelConfig = componentsInChildren.Get(i) as TsUiNavigationPanelConfig;
					if (tsUiNavigationPanelConfig.Independent && !(tsUiNavigationPanelConfig.ViewName != "弹窗通用"))
					{
						if (this.IsExistInNavigationViewMap(tsUiNavigationPanelConfig))
						{
							this.InsertNavigationViewPanelConfig(tagId, panelConfig);
							return;
						}
						this.CacheInsertPopPanelConfigMap[new ValueTuple<int, TsUiNavigationPanelConfig>(tagId, panelConfig)] = tsUiNavigationPanelConfig;
						return;
					}
					else
					{
						i--;
					}
				}
				return;
			}
			if (this.CacheInsertPopPanelConfigMap.Count > 0)
			{
				TsUiNavigationPanelConfig tsUiNavigationPanelConfig2 = UiNavigationLogic.FindUiNavigationPanelConfig(panelConfig.GetOwner());
				if (tsUiNavigationPanelConfig2 != null)
				{
					this.CacheInsertPopPanelConfigMap[new ValueTuple<int, TsUiNavigationPanelConfig>(tagId, panelConfig)] = tsUiNavigationPanelConfig2;
				}
				return;
			}
			if (!this.InsertNavigationViewPanelConfig(tagId, panelConfig))
			{
				TsUiNavigationPanelConfig tsUiNavigationPanelConfig3 = UiNavigationLogic.FindUiNavigationPanelConfig(panelConfig.GetOwner());
				if (tsUiNavigationPanelConfig3 != null)
				{
					this.CacheInsertPopPanelConfigMap[new ValueTuple<int, TsUiNavigationPanelConfig>(tagId, panelConfig)] = tsUiNavigationPanelConfig3;
				}
			}
		}

		// Token: 0x06033392 RID: 209810 RVA: 0x00CD384D File Offset: 0x00CD1A4D
		private void NavigationViewDestroy(int tagId, AActor actor)
		{
			if (actor == null)
			{
				return;
			}
			if (!this.DeleteNavigationViewPanelConfig(tagId))
			{
				return;
			}
			this.DestroyNavigationViewHandle(tagId);
			this.ResetCurrentHandle(tagId);
			this.MarkCalculateCurrentPanelDirty();
		}

		// Token: 0x06033393 RID: 209811 RVA: 0x00CD3872 File Offset: 0x00CD1A72
		private void ResetNavigationListener()
		{
			if (this.CurrentHandle == null)
			{
				return;
			}
			this.CurrentHandle.ResetNavigationListener();
			ModelBase<UiNavigationModel>.Instance.MarkMoveInstantly();
		}

		// Token: 0x06033394 RID: 209812 RVA: 0x00CD3894 File Offset: 0x00CD1A94
		private void CreateNavigationViewHandle(int tagId, TsUiNavigationPanelConfig panelConfig)
		{
			UiNavigationViewHandle uiNavigationViewHandle = new UiNavigationViewHandle(tagId, panelConfig);
			uiNavigationViewHandle.AddPanelConfig(tagId, panelConfig);
			this.NavigationViewMap[tagId] = uiNavigationViewHandle;
			this.PanelConfigMap[tagId] = uiNavigationViewHandle;
		}

		// Token: 0x06033395 RID: 209813 RVA: 0x00CD38CC File Offset: 0x00CD1ACC
		private bool IsExistInNavigationViewMap(TsUiNavigationPanelConfig panelConfig)
		{
			foreach (UiNavigationViewHandle uiNavigationViewHandle in this.NavigationViewMap.Values)
			{
				TsUiNavigationPanelConfig mainPanel = uiNavigationViewHandle.MainPanel;
				IntPtr? intPtr = (mainPanel != null) ? new IntPtr?(mainPanel.GetNativePtr_Unchecked()) : null;
				IntPtr nativePtr_Unchecked = panelConfig.GetNativePtr_Unchecked();
				if (intPtr.GetValueOrDefault() == nativePtr_Unchecked & intPtr != null)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06033396 RID: 209814 RVA: 0x00CD3960 File Offset: 0x00CD1B60
		private bool InsertPanelConfigToCurrentHandle(int tagId, TsUiNavigationPanelConfig panelConfig)
		{
			UiNavigationViewHandle uiNavigationViewHandle = null;
			foreach (UiNavigationViewHandle uiNavigationViewHandle2 in this.NavigationViewMap.Values)
			{
				if (uiNavigationViewHandle2.ViewName == panelConfig.ViewName)
				{
					uiNavigationViewHandle = uiNavigationViewHandle2;
				}
			}
			if (uiNavigationViewHandle == null)
			{
				return false;
			}
			uiNavigationViewHandle.AddPanelConfig(tagId, panelConfig);
			this.PanelConfigMap[tagId] = uiNavigationViewHandle;
			return true;
		}

		// Token: 0x06033397 RID: 209815 RVA: 0x00CD39E4 File Offset: 0x00CD1BE4
		private bool InsertNavigationViewPanelConfig(int tagId, TsUiNavigationPanelConfig panelConfig)
		{
			if (UiNavigationGlobalData.NeedCalculateCurrentPanel)
			{
				this.CacheInsertPanelConfigMap[tagId] = panelConfig;
				return true;
			}
			return this.InsertPanelConfigToCurrentHandle(tagId, panelConfig);
		}

		// Token: 0x06033398 RID: 209816 RVA: 0x00CD3A04 File Offset: 0x00CD1C04
		private bool DeleteNavigationViewPanelConfig(int tagId)
		{
			UiNavigationViewHandle uiNavigationViewHandle;
			if (this.PanelConfigMap.TryGetValue(tagId, out uiNavigationViewHandle))
			{
				this.PanelConfigMap.Remove(tagId);
				uiNavigationViewHandle.DeletePanelConfig(tagId);
				return tagId == uiNavigationViewHandle.TagId;
			}
			return false;
		}

		// Token: 0x06033399 RID: 209817 RVA: 0x00CD3A40 File Offset: 0x00CD1C40
		private bool DestroyNavigationViewHandle(int tagId)
		{
			UiNavigationViewHandle uiNavigationViewHandle;
			if (this.NavigationViewMap.TryGetValue(tagId, out uiNavigationViewHandle))
			{
				this.NavigationViewMap.Remove(tagId);
				foreach (int key in uiNavigationViewHandle.GetPanelConfigMap().Keys)
				{
					this.PanelConfigMap.Remove(key);
				}
				uiNavigationViewHandle.ClearPanelConfig();
				return true;
			}
			return false;
		}

		// Token: 0x0603339A RID: 209818 RVA: 0x00CD3AC4 File Offset: 0x00CD1CC4
		private void ResetCurrentHandle(int tagId)
		{
			if (this.CurrentHandle == null)
			{
				Singleton<Log>.Instance.Info(ELogModule.UiNavigation, ELogAuthor.XXJ, "当前导航面板不存在,将导航对象置为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				UiNavigationLogic.UpdateNavigationListener(null);
				return;
			}
			if (this.CurrentHandle.TagId == tagId)
			{
				Singleton<Log>.Instance.Info(ELogModule.UiNavigation, ELogAuthor.XXJ, "当前导航面板销毁,将导航对象置为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				UiNavigationLogic.UpdateNavigationListener(null);
				this.CurrentHandle = null;
			}
		}

		// Token: 0x0603339B RID: 209819 RVA: 0x00CD3B39 File Offset: 0x00CD1D39
		public void MarkCalculateCurrentPanelDirty()
		{
			UiNavigationGlobalData.NeedCalculateCurrentPanel = true;
		}

		// Token: 0x0603339C RID: 209820 RVA: 0x00CD3B41 File Offset: 0x00CD1D41
		private void UpdateCurrentPanel()
		{
			if (!UiNavigationGlobalData.NeedCalculateCurrentPanel)
			{
				return;
			}
			UiNavigationGlobalData.NeedCalculateCurrentPanel = false;
			this.CalculateCurrentPanel();
		}

		// Token: 0x0603339D RID: 209821 RVA: 0x00CD3B58 File Offset: 0x00CD1D58
		private bool CheckDepthValid(UiNavigationViewHandle newHandle, UiNavigationViewHandle oldHandle)
		{
			int depth = newHandle.GetDepth();
			int depth2 = oldHandle.GetDepth();
			return depth != -1 && depth2 != -1;
		}

		// Token: 0x0603339E RID: 209822 RVA: 0x00CD3B80 File Offset: 0x00CD1D80
		private void CalculateCurrentPanel()
		{
			if (this.NavigationViewMap.Count <= 0)
			{
				this.CurrentHandle = null;
				Singleton<Log>.Instance.Info(ELogModule.UiNavigation, ELogAuthor.XXJ, "当前没有导航面板,将导航对象置为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				UiNavigationLogic.UpdateNavigationListener(null);
				return;
			}
			UiNavigationViewHandle uiNavigationViewHandle = null;
			bool flag = true;
			foreach (UiNavigationViewHandle uiNavigationViewHandle2 in this.NavigationViewMap.Values)
			{
				if (uiNavigationViewHandle2.GetIsActive() && uiNavigationViewHandle2.GetIsUsable())
				{
					if (uiNavigationViewHandle == null)
					{
						uiNavigationViewHandle = uiNavigationViewHandle2;
					}
					else
					{
						if (!this.CheckDepthValid(uiNavigationViewHandle2, uiNavigationViewHandle))
						{
							flag = false;
							break;
						}
						if (uiNavigationViewHandle2.GetDepth() > uiNavigationViewHandle.GetDepth())
						{
							uiNavigationViewHandle = uiNavigationViewHandle2;
						}
						else
						{
							uiNavigationViewHandle2.SetIsInController(false);
						}
					}
				}
			}
			if (!flag)
			{
				this.MarkCalculateCurrentPanelDirty();
				return;
			}
			if (this.CurrentHandle != uiNavigationViewHandle)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiNavigation;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "查找当前导航界面句柄";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("名字", (uiNavigationViewHandle != null) ? uiNavigationViewHandle.ViewName : null);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				if (this.CurrentHandle != null)
				{
					this.CurrentHandle.SetIsInController(false);
					this.CurrentHandle.CanOverridePositionByGamepad(false);
				}
				if (uiNavigationViewHandle != null)
				{
					uiNavigationViewHandle.SetIsInController(true);
					uiNavigationViewHandle.CanOverridePositionByGamepad(true);
					uiNavigationViewHandle.ResetStateIfNullFocus();
				}
				this.CurrentHandle = uiNavigationViewHandle;
			}
		}

		// Token: 0x0603339F RID: 209823 RVA: 0x00CD3CE0 File Offset: 0x00CD1EE0
		private void FindDefaultNavigation()
		{
			if (this.CurrentHandle == null)
			{
				return;
			}
			this.CurrentHandle.FindDefaultNavigation();
		}

		// Token: 0x060333A0 RID: 209824 RVA: 0x00CD3CF8 File Offset: 0x00CD1EF8
		private void RefreshCurrentPanel()
		{
			if (UiNavigationGlobalData.NeedRefreshPanelId == 0)
			{
				return;
			}
			if (this.NeedSkipFindNavigationByCache())
			{
				return;
			}
			if (this.CurrentHandle == null || this.CurrentHandle.TagId != UiNavigationGlobalData.NeedRefreshPanelId)
			{
				UiNavigationGlobalData.NeedRefreshPanelId = 0;
				return;
			}
			UiNavigationGlobalData.NeedRefreshPanelId = 0;
			if (this.CurrentHandle == null)
			{
				return;
			}
			if (!this.CurrentHandle.HasAnyPanelActive())
			{
				this.MarkCalculateCurrentPanelDirty();
				return;
			}
			this.CurrentHandle.FindAddPanelConfigNavigation();
		}

		// Token: 0x060333A1 RID: 209825 RVA: 0x00CD3D68 File Offset: 0x00CD1F68
		private void HandleCachePanelConfigToCurrentPanel()
		{
			if (this.CacheInsertPanelConfigMap.Count <= 0)
			{
				return;
			}
			foreach (KeyValuePair<int, TsUiNavigationPanelConfig> keyValuePair in this.CacheInsertPanelConfigMap)
			{
				this.InsertPanelConfigToCurrentHandle(keyValuePair.Key, keyValuePair.Value);
			}
			this.CacheInsertPanelConfigMap.Clear();
		}

		// Token: 0x060333A2 RID: 209826 RVA: 0x00CD3DE4 File Offset: 0x00CD1FE4
		private void HandleCachePopPanelConfig()
		{
			if (this.CacheInsertPopPanelConfigMap.Count <= 0)
			{
				return;
			}
			if (this.CurrentHandle == null)
			{
				return;
			}
			List<ValueTuple<int, TsUiNavigationPanelConfig>> list = new List<ValueTuple<int, TsUiNavigationPanelConfig>>();
			foreach (KeyValuePair<ValueTuple<int, TsUiNavigationPanelConfig>, TsUiNavigationPanelConfig> keyValuePair in this.CacheInsertPopPanelConfigMap)
			{
				IntPtr nativePtr_Unchecked = keyValuePair.Value.GetNativePtr_Unchecked();
				TsUiNavigationPanelConfig mainPanel = this.CurrentHandle.MainPanel;
				IntPtr? intPtr = (mainPanel != null) ? new IntPtr?(mainPanel.GetNativePtr_Unchecked()) : null;
				if (nativePtr_Unchecked == intPtr.GetValueOrDefault() & intPtr != null)
				{
					list.Add(keyValuePair.Key);
					this.InsertNavigationViewPanelConfig(keyValuePair.Key.Item1, keyValuePair.Key.Item2);
				}
			}
			foreach (ValueTuple<int, TsUiNavigationPanelConfig> key in list)
			{
				this.CacheInsertPopPanelConfigMap.Remove(key);
			}
		}

		// Token: 0x060333A3 RID: 209827 RVA: 0x00CD3F08 File Offset: 0x00CD2108
		private void TickCurrentViewHandle(float deltaTime)
		{
			if (this.CurrentHandle == null)
			{
				return;
			}
			this.CurrentHandle.TickViewHandle(deltaTime);
		}

		// Token: 0x060333A4 RID: 209828 RVA: 0x00CD3F1F File Offset: 0x00CD211F
		public UiNavigationViewHandle GetCurrentViewHandle()
		{
			return this.CurrentHandle;
		}

		// Token: 0x060333A5 RID: 209829 RVA: 0x00CD3F27 File Offset: 0x00CD2127
		public void RefreshCurrentHotKey()
		{
			if (this.CurrentHandle == null)
			{
				return;
			}
			this.CurrentHandle.MarkRefreshHotKeyDirty();
		}

		// Token: 0x060333A6 RID: 209830 RVA: 0x00CD3F3D File Offset: 0x00CD213D
		public void RefreshCurrentHotKeyTextId()
		{
			if (this.CurrentHandle == null)
			{
				return;
			}
			this.CurrentHandle.MarkRefreshHotKeyTextIdDirty();
		}

		// Token: 0x060333A7 RID: 209831 RVA: 0x00CD3F53 File Offset: 0x00CD2153
		public bool CanFocusViewHandle(UiNavigationViewHandle viewHandle)
		{
			UiNavigationViewHandle currentHandle = this.CurrentHandle;
			return currentHandle == null || !currentHandle.HasGamepadControlMouse() || this.CurrentHandle == viewHandle;
		}

		// Token: 0x060333A8 RID: 209832 RVA: 0x00CD3F75 File Offset: 0x00CD2175
		public bool NeedSkipFindNavigationByCache()
		{
			return this.CacheUiItem != null && this.CacheSuppressDefaultFind;
		}

		// Token: 0x060333A9 RID: 209833 RVA: 0x00CD3F87 File Offset: 0x00CD2187
		private void ClearNavigationFocusCache()
		{
			this.CacheUiItem = null;
			this.CacheCheckDirty = false;
			this.CacheSuppressDefaultFind = false;
		}

		// Token: 0x060333AA RID: 209834 RVA: 0x00CD3FA0 File Offset: 0x00CD21A0
		[NullableContext(2)]
		private void SetNavigationFocusForViewInternal(UUIItem uiItem, bool checkDirty = false)
		{
			if (Singleton<Info>.Instance.IsInTouch())
			{
				return;
			}
			if (uiItem == null)
			{
				return;
			}
			if (!uiItem.IsValid())
			{
				Singleton<Log>.Instance.Info(ELogModule.UiNavigation, ELogAuthor.SYB, "缓存的导航对象已无效,放弃本次设置", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.ClearNavigationFocusCache();
				UiNavigationViewHandle currentHandle = this.CurrentHandle;
				if (currentHandle == null)
				{
					return;
				}
				currentHandle.RestoreSwallowedRefreshNavigation();
				return;
			}
			else
			{
				bool flag = ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(uiItem, checkDirty, false, false);
				this.ClearNavigationFocusCache();
				if (flag)
				{
					if (!checkDirty)
					{
						UiNavigationViewHandle currentHandle2 = this.CurrentHandle;
						if (currentHandle2 == null)
						{
							return;
						}
						currentHandle2.DiscardSwallowedRefreshNavigation();
					}
					return;
				}
				UiNavigationViewHandle currentHandle3 = this.CurrentHandle;
				if (currentHandle3 == null)
				{
					return;
				}
				currentHandle3.RestoreSwallowedRefreshNavigation();
				return;
			}
		}

		// Token: 0x060333AB RID: 209835 RVA: 0x00CD4036 File Offset: 0x00CD2236
		public void SetNavigationFocusForView(UUIItem uiItem, bool checkDirty = false, bool suppressDefaultFind = false)
		{
			if (Singleton<Info>.Instance.IsInTouch())
			{
				return;
			}
			this.CacheUiItem = uiItem;
			this.CacheCheckDirty = checkDirty;
			this.CacheSuppressDefaultFind = suppressDefaultFind;
		}

		// Token: 0x0401DC23 RID: 121891
		[Nullable(2)]
		private UiNavigationViewHandle CurrentHandle;

		// Token: 0x0401DC24 RID: 121892
		private readonly Dictionary<int, UiNavigationViewHandle> NavigationViewMap = new Dictionary<int, UiNavigationViewHandle>();

		// Token: 0x0401DC25 RID: 121893
		private readonly Dictionary<int, UiNavigationViewHandle> PanelConfigMap = new Dictionary<int, UiNavigationViewHandle>();

		// Token: 0x0401DC26 RID: 121894
		private readonly Dictionary<int, TsUiNavigationPanelConfig> CacheInsertPanelConfigMap = new Dictionary<int, TsUiNavigationPanelConfig>();

		// Token: 0x0401DC27 RID: 121895
		[Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})]
		private readonly Dictionary<ValueTuple<int, TsUiNavigationPanelConfig>, TsUiNavigationPanelConfig> CacheInsertPopPanelConfigMap = new Dictionary<ValueTuple<int, TsUiNavigationPanelConfig>, TsUiNavigationPanelConfig>();

		// Token: 0x0401DC28 RID: 121896
		private int PrePhysicsTickId = -1;

		// Token: 0x0401DC29 RID: 121897
		private int EndPhysicTickId = -1;

		// Token: 0x0401DC2A RID: 121898
		[Nullable(2)]
		protected UUIItem CacheUiItem;

		// Token: 0x0401DC2B RID: 121899
		protected bool CacheCheckDirty;

		// Token: 0x0401DC2C RID: 121900
		protected bool CacheSuppressDefaultFind;
	}
}
