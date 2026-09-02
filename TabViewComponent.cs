using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Guide.StepInfo;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02001A6D RID: 6765
[NullableContext(1)]
[Nullable(0)]
public class TabViewComponent<[Nullable(2)] TData>
{
	// Token: 0x0600C19F RID: 49567 RVA: 0x0032F817 File Offset: 0x0032DA17
	public TabViewComponent(UUIItem rootViewItem, EKeyMode keyMode = EKeyMode.Default)
	{
		this.RootViewItem = rootViewItem;
		this.KeyMode = keyMode;
		Singleton<EventSystem>.Instance.Add<GuideStepInfo, GuideFocusNew>(EEventName.GuideFocusNeedUiTabView, new Action<GuideStepInfo, GuideFocusNew>(this.OnGuideFocusNeedUiTabView));
	}

	// Token: 0x0600C1A0 RID: 49568 RVA: 0x0032F854 File Offset: 0x0032DA54
	private void RegisterViewModule(CommonTabItemBase tabItem, UiTabViewBase tabView)
	{
		ITabViewRegister tabViewRegister = tabItem as ITabViewRegister;
		if (tabViewRegister == null)
		{
			return;
		}
		tabViewRegister.RegisterViewModule(tabView);
	}

	// Token: 0x0600C1A1 RID: 49569 RVA: 0x0032F868 File Offset: 0x0032DA68
	private void ClearUiTabView()
	{
		foreach (UiTabViewBase uiTabViewBase in this.UiTabViewMap.Values)
		{
			uiTabViewBase.Destroy(null);
		}
		this.UiTabViewMap.Clear();
	}

	// Token: 0x0600C1A2 RID: 49570 RVA: 0x0032F8CC File Offset: 0x0032DACC
	private void HideTabView(EUiTabViewName? selectKey)
	{
		if (selectKey == null)
		{
			return;
		}
		UiTabViewBase uiTabViewBase;
		this.UiTabViewMap.TryGetValue(selectKey.Value, out uiTabViewBase);
		if (uiTabViewBase == null)
		{
			return;
		}
		if (uiTabViewBase.IsCreateOrCreating || uiTabViewBase.IsStarting)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiTabModule;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "异步加载中,不执行页签隐藏";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TabViewName", this.SelectedKey);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		uiTabViewBase.HideUiTabView(true);
	}

	// Token: 0x0600C1A3 RID: 49571 RVA: 0x0032F948 File Offset: 0x0032DB48
	public void HideCurrentTabView()
	{
		if (this.SelectedKey == null)
		{
			return;
		}
		UiTabViewBase uiTabViewBase;
		this.UiTabViewMap.TryGetValue(this.SelectedKey.Value, out uiTabViewBase);
		if (uiTabViewBase == null)
		{
			return;
		}
		if (uiTabViewBase.IsCreateOrCreating || uiTabViewBase.IsStarting)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiTabModule;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "异步加载中,不执行页签隐藏";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TabViewName", this.SelectedKey);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		uiTabViewBase.HideUiTabView(true);
		this.SelectedKey = null;
	}

	// Token: 0x0600C1A4 RID: 49572 RVA: 0x0032F9D8 File Offset: 0x0032DBD8
	[NullableContext(2)]
	public void ToggleCallBackNew([Nullable(1)] TData data, EUiTabViewName viewName, CommonTabItemBase tabItem = null, object extraParams = null, int? index = null)
	{
		EUiTabViewName tabKey = this.GetTabKey(viewName, index);
		this.SelectedKey = new EUiTabViewName?(tabKey);
		UiTabViewBase uiTabView;
		this.UiTabViewMap.TryGetValue(tabKey, out uiTabView);
		if (uiTabView == null)
		{
			IUiTabViewTsInfo uiTabViewBase = Singleton<UiTabViewStorage>.Instance.GetUiTabViewBase(viewName);
			if (uiTabViewBase == null)
			{
				return;
			}
			uiTabView = uiTabViewBase.CreateUiTabView();
			uiTabView.SetTabViewName(viewName);
			uiTabView.SetParams(data);
			uiTabView.SetExtraParams(extraParams);
			if (tabItem != null)
			{
				this.RegisterViewModule(tabItem, uiTabView);
			}
			this.UiTabViewMap[tabKey] = uiTabView;
			uiTabView.CreateByResourceIdAsync(uiTabViewBase.ResourceId, this.RootViewItem, false).ContinueWith(delegate()
			{
				if (this.SelectedKey == tabKey)
				{
					if (this.HideTabViewKey != null)
					{
						this.HideTabView(this.HideTabViewKey);
					}
					this.HideTabViewKey = new EUiTabViewName?(tabKey);
					UiTabViewBase uiTabView = uiTabView;
					if (uiTabView == null)
					{
						return;
					}
					uiTabView.ShowUiTabViewFromToggle();
					return;
				}
				else
				{
					UiTabViewBase uiTabView;
					UiTabViewBase uiTabView2 = uiTabView;
					if (uiTabView2 == null)
					{
						return;
					}
					uiTabView2.HideUiTabView(true);
					return;
				}
			}).Forget();
		}
		else
		{
			uiTabView.SetParams(data);
			uiTabView.SetExtraParams(extraParams);
		}
		if (uiTabView.IsCreateOrCreating || uiTabView.IsStarting)
		{
			return;
		}
		if (this.HideTabViewKey != null)
		{
			this.HideTabView(this.HideTabViewKey);
		}
		this.HideTabViewKey = new EUiTabViewName?(tabKey);
		uiTabView.ShowUiTabViewFromToggle();
	}

	// Token: 0x0600C1A5 RID: 49573 RVA: 0x0032FB48 File Offset: 0x0032DD48
	[NullableContext(2)]
	public void ToggleCallBack([Nullable(1)] TData data, EUiTabViewName viewName, CommonTabItemBase tabItem = null, object extraParams = null, int? index = null)
	{
		EUiTabViewName tabKey = this.GetTabKey(viewName, index);
		if (this.SelectedKey != null)
		{
			this.HideCurrentTabView();
		}
		this.SelectedKey = new EUiTabViewName?(tabKey);
		UiTabViewBase uiTabView;
		this.UiTabViewMap.TryGetValue(tabKey, out uiTabView);
		if (uiTabView == null)
		{
			IUiTabViewTsInfo uiTabViewBase = Singleton<UiTabViewStorage>.Instance.GetUiTabViewBase(viewName);
			if (uiTabViewBase == null)
			{
				return;
			}
			uiTabView = uiTabViewBase.CreateUiTabView();
			uiTabView.SetTabViewName(viewName);
			uiTabView.SetParams(data);
			uiTabView.SetExtraParams(extraParams);
			if (tabItem != null)
			{
				this.RegisterViewModule(tabItem, uiTabView);
			}
			this.UiTabViewMap[tabKey] = uiTabView;
			uiTabView.CreateByResourceIdAsync(uiTabViewBase.ResourceId, this.RootViewItem, false).ContinueWith(delegate()
			{
				if (this.SelectedKey == tabKey)
				{
					UiTabViewBase uiTabView = uiTabView;
					if (uiTabView == null)
					{
						return;
					}
					uiTabView.ShowUiTabViewFromToggle();
					return;
				}
				else
				{
					UiTabViewBase uiTabView;
					UiTabViewBase uiTabView2 = uiTabView;
					if (uiTabView2 == null)
					{
						return;
					}
					uiTabView2.HideUiTabView(true);
					return;
				}
			}).Forget();
		}
		else
		{
			uiTabView.SetParams(data);
			uiTabView.SetExtraParams(extraParams);
		}
		if (uiTabView.IsCreateOrCreating || uiTabView.IsStarting)
		{
			return;
		}
		uiTabView.ShowUiTabViewFromToggle();
	}

	// Token: 0x0600C1A6 RID: 49574 RVA: 0x0032FCA0 File Offset: 0x0032DEA0
	private EUiTabViewName GetTabKey(EUiTabViewName viewName, int? index = null)
	{
		if (this.KeyMode == EKeyMode.Index && index == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.UiTabModule, ELogAuthor.YZY, "索引模式下必须传入索引", default(ReadOnlySpan<ValueTuple<string, object>>));
			return new EUiTabViewName("");
		}
		if (this.KeyMode == EKeyMode.Default)
		{
			return viewName;
		}
		return new EUiTabViewName(StringUtils.Format("{0}_{1}", new string[]
		{
			viewName.ToString(),
			index.ToString()
		}));
	}

	// Token: 0x0600C1A7 RID: 49575 RVA: 0x0032FD28 File Offset: 0x0032DF28
	public EUiTabViewName? GetCurrentTabViewName(int? index = null)
	{
		if (this.KeyMode == EKeyMode.Index && index == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.UiTabModule, ELogAuthor.YZY, "索引模式下必须传入索引", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		if (this.KeyMode != EKeyMode.Index)
		{
			return this.SelectedKey;
		}
		string[] array = (this.SelectedKey != null) ? this.SelectedKey.GetValueOrDefault().ToString().Split('_', StringSplitOptions.None) : null;
		if (array == null || array.Length != 2)
		{
			Singleton<Log>.Instance.Error(ELogModule.UiTabModule, ELogAuthor.YZY, "索引模式下Key不符合规范", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		if (array[1] != ((index != null) ? index.GetValueOrDefault().ToString() : null))
		{
			Singleton<Log>.Instance.Error(ELogModule.UiTabModule, ELogAuthor.YZY, "索引模式下Key索引不一致", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		return new EUiTabViewName?((EUiTabViewName)array[0]);
	}

	// Token: 0x0600C1A8 RID: 49576 RVA: 0x0032FE40 File Offset: 0x0032E040
	[NullableContext(2)]
	public UiTabViewBase GetCurrentTabView()
	{
		if (this.SelectedKey == null)
		{
			return null;
		}
		UiTabViewBase result;
		this.UiTabViewMap.TryGetValue(this.SelectedKey.Value, out result);
		return result;
	}

	// Token: 0x0600C1A9 RID: 49577 RVA: 0x0032FE78 File Offset: 0x0032E078
	[NullableContext(2)]
	public UiTabViewBase GetTabViewByTabKey(EUiTabViewName viewName, int? index = null)
	{
		UiTabViewBase result;
		this.UiTabViewMap.TryGetValue(this.GetTabKey(viewName, index), out result);
		return result;
	}

	// Token: 0x0600C1AA RID: 49578 RVA: 0x0032FE9C File Offset: 0x0032E09C
	public void SetCurrentTabViewState(bool bShow)
	{
		if (this.SelectedKey == null)
		{
			return;
		}
		UiTabViewBase uiTabViewBase;
		this.UiTabViewMap.TryGetValue(this.SelectedKey.Value, out uiTabViewBase);
		if (uiTabViewBase == null)
		{
			return;
		}
		if (bShow && uiTabViewBase.IsHideOrHiding)
		{
			uiTabViewBase.ShowUiTabViewFromView();
			return;
		}
		if (!bShow && !uiTabViewBase.IsHideOrHiding)
		{
			uiTabViewBase.HideUiTabView(false);
		}
	}

	// Token: 0x0600C1AB RID: 49579 RVA: 0x0032FEF8 File Offset: 0x0032E0F8
	public void DestroyTabViewComponent()
	{
		this.ClearUiTabView();
		Singleton<EventSystem>.Instance.Remove(EEventName.GuideFocusNeedUiTabView, new Action<GuideStepInfo, GuideFocusNew>(this.OnGuideFocusNeedUiTabView));
	}

	// Token: 0x0600C1AC RID: 49580 RVA: 0x0032FF1C File Offset: 0x0032E11C
	private void OnGuideFocusNeedUiTabView(GuideStepInfo stepInfo, GuideFocusNew focusConf)
	{
		EUiTabViewName? euiTabViewName = this.SelectedKey;
		EUiTabViewName? euiTabViewName2 = (euiTabViewName != null) ? euiTabViewName : this.Default;
		string dynamicTabName = focusConf.DynamicTabName;
		euiTabViewName = euiTabViewName2;
		if (dynamicTabName != ((euiTabViewName != null) ? euiTabViewName.GetValueOrDefault() : null))
		{
			return;
		}
		UiTabViewBase uiTabViewBase;
		this.UiTabViewMap.TryGetValue(euiTabViewName2.Value, out uiTabViewBase);
		if (uiTabViewBase != null)
		{
			GuideStepViewData viewData = stepInfo.ViewData;
			if (viewData == null)
			{
				return;
			}
			viewData.SetAttachedView(uiTabViewBase);
		}
	}

	// Token: 0x04005A9C RID: 23196
	private readonly EKeyMode KeyMode;

	// Token: 0x04005A9D RID: 23197
	private EUiTabViewName? SelectedKey;

	// Token: 0x04005A9E RID: 23198
	private readonly EUiTabViewName? Default;

	// Token: 0x04005A9F RID: 23199
	private readonly Dictionary<EUiTabViewName, UiTabViewBase> UiTabViewMap = new Dictionary<EUiTabViewName, UiTabViewBase>();

	// Token: 0x04005AA0 RID: 23200
	private EUiTabViewName? HideTabViewKey;

	// Token: 0x04005AA1 RID: 23201
	private readonly UUIItem RootViewItem;
}
