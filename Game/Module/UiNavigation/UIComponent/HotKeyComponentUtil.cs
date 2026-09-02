using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation.UIComponent
{
	// Token: 0x02004D83 RID: 19843
	[NullableContext(1)]
	[Nullable(0)]
	public static class HotKeyComponentUtil
	{
		// Token: 0x0603362C RID: 210476 RVA: 0x00CDA518 File Offset: 0x00CD8718
		private static List<T> GetComponentsFromPanel<[Nullable(0)] T>([Nullable(2)] TsUiNavigationPanelConfig panelConfig, Type componentClass) where T : HotKeyComponent
		{
			List<T> list = new List<T>();
			if (((panelConfig != null) ? panelConfig.HotKeyItemSet : null) == null)
			{
				return list;
			}
			foreach (HotKeyItem hotKeyItem in panelConfig.HotKeyItemSet)
			{
				foreach (HotKeyComponent hotKeyComponent in hotKeyItem.GetHotKeyComponentArray())
				{
					if (((hotKeyComponent != null) ? hotKeyComponent.GetType() : null) == componentClass || (hotKeyComponent != null && hotKeyComponent.GetType().IsSubclassOf(componentClass)))
					{
						T t = hotKeyComponent as T;
						if (t != null)
						{
							list.Add(t);
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0603362D RID: 210477 RVA: 0x00CDA5FC File Offset: 0x00CD87FC
		[NullableContext(2)]
		private static TsUiNavigationPanelConfig GetPanelConfigByRootItem(UUIItem rootItem)
		{
			if (rootItem == null || !rootItem.IsValid())
			{
				return null;
			}
			AActor owner = rootItem.GetOwner();
			if (owner == null || !owner.IsValid())
			{
				return null;
			}
			return owner.GetComponentByClass(TsUiNavigationPanelConfig.StaticClass()) as TsUiNavigationPanelConfig;
		}

		// Token: 0x0603362E RID: 210478 RVA: 0x00CDA64C File Offset: 0x00CD884C
		public static void SetupComponents<[Nullable(0)] T>([Nullable(2)] UUIItem rootItem, EHotKeyCacheKey cacheKey, Func<object> callbackFn) where T : HotKeyComponent
		{
			if (Singleton<Info>.Instance.IsInTouch())
			{
				return;
			}
			TsUiNavigationPanelConfig panelConfigByRootItem = HotKeyComponentUtil.GetPanelConfigByRootItem(rootItem);
			if (panelConfigByRootItem == null)
			{
				return;
			}
			Type componentClass;
			if (!HotKeyUtilConfig.CacheKey2CompMap.TryGetValue(cacheKey, out componentClass))
			{
				return;
			}
			List<T> componentsFromPanel = HotKeyComponentUtil.GetComponentsFromPanel<T>(panelConfigByRootItem, componentClass);
			if (componentsFromPanel.Count > 0)
			{
				using (List<T>.Enumerator enumerator = componentsFromPanel.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						T t = enumerator.Current;
						if (t != null)
						{
							T t2 = t;
							t2.SetDataCallback(callbackFn);
						}
					}
					return;
				}
			}
			HotKeyComponentUtil.SetCacheCallback<T>(panelConfigByRootItem, cacheKey, componentClass, callbackFn);
		}

		// Token: 0x0603362F RID: 210479 RVA: 0x00CDA6F0 File Offset: 0x00CD88F0
		public static int ExecuteOnComponents<[Nullable(0)] T>([Nullable(2)] UUIItem rootItem, Type componentClass, Action<T> actionFn) where T : HotKeyComponent
		{
			if (Singleton<Info>.Instance.IsInTouch())
			{
				return 0;
			}
			return HotKeyComponentUtil.ExecuteOnPanelComponents<T>(HotKeyComponentUtil.GetPanelConfigByRootItem(rootItem), componentClass, actionFn);
		}

		// Token: 0x06033630 RID: 210480 RVA: 0x00CDA710 File Offset: 0x00CD8910
		private static int ExecuteOnPanelComponents<[Nullable(0)] T>([Nullable(2)] TsUiNavigationPanelConfig panelConfig, Type componentClass, Action<T> actionFn) where T : HotKeyComponent
		{
			List<T> componentsFromPanel = HotKeyComponentUtil.GetComponentsFromPanel<T>(panelConfig, componentClass);
			foreach (T obj in componentsFromPanel)
			{
				actionFn(obj);
			}
			return componentsFromPanel.Count;
		}

		// Token: 0x06033631 RID: 210481 RVA: 0x00CDA76C File Offset: 0x00CD896C
		private static void SetCacheCallback<[Nullable(0)] T>(TsUiNavigationPanelConfig panelConfig, EHotKeyCacheKey cacheKey, Type componentClass, Func<object> callbackFn) where T : HotKeyComponent
		{
			if (panelConfig.CacheHotKeyComponentCallbackMap == null)
			{
				panelConfig.CacheHotKeyComponentCallbackMap = new Dictionary<EHotKeyCacheKey, Action<HotKeyItem>>();
			}
			panelConfig.CacheHotKeyComponentCallbackMap[cacheKey] = delegate(HotKeyItem hotKeyItem)
			{
				foreach (HotKeyComponent hotKeyComponent in hotKeyItem.GetHotKeyComponentArray())
				{
					if (((hotKeyComponent != null) ? hotKeyComponent.GetType() : null) == componentClass || (hotKeyComponent != null && hotKeyComponent.GetType().IsSubclassOf(componentClass)))
					{
						T t = hotKeyComponent as T;
						if (t != null)
						{
							t.SetDataCallback(callbackFn);
						}
					}
				}
			};
		}

		// Token: 0x06033632 RID: 210482 RVA: 0x00CDA7B8 File Offset: 0x00CD89B8
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public static Action<HotKeyItem> GetCacheCallback(TsUiNavigationPanelConfig panelConfig, EHotKeyCacheKey cacheKey)
		{
			Dictionary<EHotKeyCacheKey, Action<HotKeyItem>> cacheHotKeyComponentCallbackMap = panelConfig.CacheHotKeyComponentCallbackMap;
			if (cacheHotKeyComponentCallbackMap == null)
			{
				return null;
			}
			return cacheHotKeyComponentCallbackMap.GetValueOrDefault(cacheKey);
		}

		// Token: 0x06033633 RID: 210483 RVA: 0x00CDA7CC File Offset: 0x00CD89CC
		public static void ClearCacheCallback(TsUiNavigationPanelConfig panelConfig, EHotKeyCacheKey cacheKey)
		{
			Dictionary<EHotKeyCacheKey, Action<HotKeyItem>> cacheHotKeyComponentCallbackMap = panelConfig.CacheHotKeyComponentCallbackMap;
			if (cacheHotKeyComponentCallbackMap == null)
			{
				return;
			}
			cacheHotKeyComponentCallbackMap.Remove(cacheKey);
		}

		// Token: 0x06033634 RID: 210484 RVA: 0x00CDA7E0 File Offset: 0x00CD89E0
		public static void ClearAllCacheCallbacks(TsUiNavigationPanelConfig panelConfig)
		{
			Dictionary<EHotKeyCacheKey, Action<HotKeyItem>> cacheHotKeyComponentCallbackMap = panelConfig.CacheHotKeyComponentCallbackMap;
			if (cacheHotKeyComponentCallbackMap == null)
			{
				return;
			}
			cacheHotKeyComponentCallbackMap.Clear();
		}
	}
}
