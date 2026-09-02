using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using FilterDefine;
using UnrealEngine;

// Token: 0x02001919 RID: 6425
[NullableContext(1)]
[Nullable(0)]
public class PhantomMainPropertyPopupView : UiViewBase
{
	// Token: 0x0600B8B2 RID: 47282 RVA: 0x003116C4 File Offset: 0x0030F8C4
	public PhantomMainPropertyPopupView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600B8B3 RID: 47283 RVA: 0x00311718 File Offset: 0x0030F918
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 3;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action<EToggleState>(this.OnToggleSelectAll));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickReset));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnClickConfirm));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600B8B4 RID: 47284 RVA: 0x00311910 File Offset: 0x0030FB10
	protected override UniTask OnBeforeStartAsync()
	{
		PhantomMainPropertyPopupView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomMainPropertyPopupView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600B8B5 RID: 47285 RVA: 0x00311954 File Offset: 0x0030FB54
	protected override void OnStart()
	{
		this.LoadAllCostPropertiesData();
		this.LoadSavedSelections();
		IMainPropertyFilterViewData viewData = this.ViewData;
		int cost = (viewData != null) ? viewData.DefaultSelectCostTab : 4;
		this.SwitchToCost(cost);
	}

	// Token: 0x0600B8B6 RID: 47286 RVA: 0x00311988 File Offset: 0x0030FB88
	private void InitFetterConfigShow()
	{
		IMainPropertyFilterViewData viewData = this.ViewData;
		bool flag = viewData != null && viewData.CurrentFetterId != null;
		PhantomManagerConfigNewElementItem elementItem = this.ElementItem;
		if (elementItem != null)
		{
			elementItem.SetUiActive(flag);
		}
		if (flag)
		{
			PhantomFetterGroup fetterGroupById = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(this.ViewData.CurrentFetterId.Value);
			PhantomManagerConfigNewElementItem elementItem2 = this.ElementItem;
			if (elementItem2 != null)
			{
				elementItem2.Refresh(fetterGroupById.FetterElementPath);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), "PhantomFilterSonataTips_1", Array.Empty<object>());
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), "PhantomFilterSonataTips_2", Array.Empty<object>());
	}

	// Token: 0x0600B8B7 RID: 47287 RVA: 0x00311A34 File Offset: 0x0030FC34
	private UniTask InitCostTabLayoutAsync()
	{
		PhantomMainPropertyPopupView.<InitCostTabLayoutAsync>d__14 <InitCostTabLayoutAsync>d__;
		<InitCostTabLayoutAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitCostTabLayoutAsync>d__.<>4__this = this;
		<InitCostTabLayoutAsync>d__.<>1__state = -1;
		<InitCostTabLayoutAsync>d__.<>t__builder.Start<PhantomMainPropertyPopupView.<InitCostTabLayoutAsync>d__14>(ref <InitCostTabLayoutAsync>d__);
		return <InitCostTabLayoutAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600B8B8 RID: 47288 RVA: 0x00311A78 File Offset: 0x0030FC78
	private void InitPropertyLayout()
	{
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(4);
		if (scrollViewWithScrollbar == null)
		{
			return;
		}
		this.PropertyLayout = new GenericScrollViewNew<PropertyToggleGridProxy, FilterItemData>(scrollViewWithScrollbar, new Func<PropertyToggleGridProxy>(this.CreatePropertyToggle), null, false, null);
	}

	// Token: 0x0600B8B9 RID: 47289 RVA: 0x00311AAC File Offset: 0x0030FCAC
	private CostTabToggleGridProxy CreateCostTabToggle()
	{
		CostTabToggleGridProxy costTabToggleGridProxy = new CostTabToggleGridProxy();
		costTabToggleGridProxy.SetToggleFunction(new TCostTabToggleFunction(this.OnCostTabChanged));
		return costTabToggleGridProxy;
	}

	// Token: 0x0600B8BA RID: 47290 RVA: 0x00311AC5 File Offset: 0x0030FCC5
	private PropertyToggleGridProxy CreatePropertyToggle()
	{
		PropertyToggleGridProxy propertyToggleGridProxy = new PropertyToggleGridProxy();
		propertyToggleGridProxy.SetToggleFunction(new TPropertyToggleFunction(this.OnPropertyToggleChanged));
		return propertyToggleGridProxy;
	}

	// Token: 0x0600B8BB RID: 47291 RVA: 0x00311ADE File Offset: 0x0030FCDE
	private void OnCostTabChanged(int cost)
	{
		this.SwitchToCost(cost);
	}

	// Token: 0x0600B8BC RID: 47292 RVA: 0x00311AE7 File Offset: 0x0030FCE7
	private void SwitchToCost(int cost)
	{
		this.CurrentCost = cost;
		this.UpdateTabHighlight();
		this.LoadPropertiesForCurrentCost();
		this.UpdateSelectAllToggle();
		this.UpdateTabMarks();
	}

	// Token: 0x0600B8BD RID: 47293 RVA: 0x00311B08 File Offset: 0x0030FD08
	private void UpdateTabHighlight()
	{
		GenericLayout<CostTabToggleGridProxy, int> costTabLayout = this.CostTabLayout;
		List<CostTabToggleGridProxy> list = (costTabLayout != null) ? costTabLayout.GetLayoutItemList() : null;
		if (list != null)
		{
			foreach (CostTabToggleGridProxy costTabToggleGridProxy in list)
			{
				costTabToggleGridProxy.SetSelectedState(costTabToggleGridProxy.Cost == this.CurrentCost);
			}
		}
	}

	// Token: 0x0600B8BE RID: 47294 RVA: 0x00311B78 File Offset: 0x0030FD78
	private void LoadSavedSelections()
	{
		FilterResultData filterResultData = ModelBase<FilterModel>.Instance.GetFilterResultData(this.ViewData.UniqueId);
		if (filterResultData == null)
		{
			return;
		}
		Dictionary<int, string> selectRuleDataById = filterResultData.GetSelectRuleDataById(FilterDefine.EFilterType.VisionDestroyAttribute);
		if (selectRuleDataById == null)
		{
			return;
		}
		this.CostSelectionMap.Clear();
		foreach (KeyValuePair<int, string> keyValuePair in selectRuleDataById)
		{
			int key = keyValuePair.Key;
			string value = keyValuePair.Value;
			foreach (int key2 in ConfigBase<FilterConfig>.Instance.GetCostByMainMainProp(key))
			{
				if (!this.CostSelectionMap.ContainsKey(key2))
				{
					this.CostSelectionMap[key2] = new Dictionary<int, string>();
				}
				this.CostSelectionMap[key2][key] = value;
			}
		}
		this.UpdateTabMarks();
	}

	// Token: 0x0600B8BF RID: 47295 RVA: 0x00311C88 File Offset: 0x0030FE88
	private void UpdateTabMarks()
	{
		GenericLayout<CostTabToggleGridProxy, int> costTabLayout = this.CostTabLayout;
		List<CostTabToggleGridProxy> list = (costTabLayout != null) ? costTabLayout.GetLayoutItemList() : null;
		if (list != null)
		{
			foreach (CostTabToggleGridProxy costTabToggleGridProxy in list)
			{
				bool markVisible = this.CostSelectionMap.ContainsKey(costTabToggleGridProxy.Cost) && this.CostSelectionMap[costTabToggleGridProxy.Cost].Count > 0;
				costTabToggleGridProxy.SetMarkVisible(markVisible);
			}
		}
	}

	// Token: 0x0600B8C0 RID: 47296 RVA: 0x00311D1C File Offset: 0x0030FF1C
	private void LoadAllCostPropertiesData()
	{
		foreach (int num in this.CostList)
		{
			if (!this.CostPropertyDataMap.ContainsKey(num))
			{
				IEnumerable<int> mainPropIdsByCost = ConfigBase<FilterConfig>.Instance.GetMainPropIdsByCost(num);
				List<FilterItemData> list = new List<FilterItemData>();
				foreach (int num2 in mainPropIdsByCost)
				{
					string sortRuleName = ConfigBase<SortConfig>.Instance.GetSortRuleName(num2, ESortDataType.Phantom);
					int sortRuleAttributeId = ConfigBase<SortConfig>.Instance.GetSortRuleAttributeId(num2, ESortDataType.Phantom);
					string propertyIndexIcon = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexIcon(sortRuleAttributeId);
					list.Add(new FilterItemData(num2, sortRuleName, propertyIndexIcon));
				}
				this.CostPropertyDataMap[num] = list;
			}
		}
	}

	// Token: 0x0600B8C1 RID: 47297 RVA: 0x00311E08 File Offset: 0x00310008
	private void LoadPropertiesForCurrentCost()
	{
		List<FilterItemData> data;
		if (!this.CostPropertyDataMap.TryGetValue(this.CurrentCost, out data))
		{
			return;
		}
		GenericScrollViewNew<PropertyToggleGridProxy, FilterItemData> propertyLayout = this.PropertyLayout;
		if (propertyLayout == null)
		{
			return;
		}
		propertyLayout.RefreshByData(data, new Action(this.RestoreCurrentCostSelection), false);
	}

	// Token: 0x0600B8C2 RID: 47298 RVA: 0x00311E4C File Offset: 0x0031004C
	private void RestoreCurrentCostSelection()
	{
		Dictionary<int, string> dictionary;
		this.CostSelectionMap.TryGetValue(this.CurrentCost, out dictionary);
		GenericScrollViewNew<PropertyToggleGridProxy, FilterItemData> propertyLayout = this.PropertyLayout;
		List<PropertyToggleGridProxy> list = (propertyLayout != null) ? propertyLayout.GetScrollItemList() : null;
		if (list != null)
		{
			foreach (PropertyToggleGridProxy propertyToggleGridProxy in list)
			{
				bool flag;
				if (dictionary != null)
				{
					Dictionary<int, string> dictionary2 = dictionary;
					FilterItemData data = propertyToggleGridProxy.Data;
					flag = dictionary2.ContainsKey((data != null) ? data.FilterId : 0);
				}
				else
				{
					flag = false;
				}
				bool selectedState = flag;
				propertyToggleGridProxy.SetSelectedState(selectedState);
			}
		}
	}

	// Token: 0x0600B8C3 RID: 47299 RVA: 0x00311EE8 File Offset: 0x003100E8
	private void OnPropertyToggleChanged(bool isChecked, int filterId, string content)
	{
		this.SetCostSelection(filterId, isChecked, content);
		this.UpdateSelectAllToggle();
		this.UpdateTabMarks();
	}

	// Token: 0x0600B8C4 RID: 47300 RVA: 0x00311F00 File Offset: 0x00310100
	private void OnToggleSelectAll(EToggleState state)
	{
		bool flag = state == EToggleState.ETT_Checked;
		GenericScrollViewNew<PropertyToggleGridProxy, FilterItemData> propertyLayout = this.PropertyLayout;
		List<PropertyToggleGridProxy> list = (propertyLayout != null) ? propertyLayout.GetScrollItemList() : null;
		if (list == null)
		{
			return;
		}
		foreach (PropertyToggleGridProxy propertyToggleGridProxy in list)
		{
			this.SetCostSelection(propertyToggleGridProxy.Data.FilterId, flag, propertyToggleGridProxy.Data.Content ?? "");
			propertyToggleGridProxy.SetSelectedState(flag);
		}
		this.UpdateTabMarks();
	}

	// Token: 0x0600B8C5 RID: 47301 RVA: 0x00311F98 File Offset: 0x00310198
	private void UpdateSelectAllToggle()
	{
		Dictionary<int, string> dictionary;
		this.CostSelectionMap.TryGetValue(this.CurrentCost, out dictionary);
		bool flag = true;
		List<FilterItemData> list;
		if (this.CostPropertyDataMap.TryGetValue(this.CurrentCost, out list))
		{
			foreach (FilterItemData filterItemData in list)
			{
				if (dictionary == null || !dictionary.ContainsKey(filterItemData.FilterId))
				{
					flag = false;
					break;
				}
			}
		}
		UUIExtendToggle extendToggle = base.GetExtendToggle(3);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(flag ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}
	}

	// Token: 0x0600B8C6 RID: 47302 RVA: 0x00312040 File Offset: 0x00310240
	private void OnClickReset()
	{
		this.CostSelectionMap.Clear();
		GenericScrollViewNew<PropertyToggleGridProxy, FilterItemData> propertyLayout = this.PropertyLayout;
		List<PropertyToggleGridProxy> list = (propertyLayout != null) ? propertyLayout.GetScrollItemList() : null;
		if (list != null)
		{
			foreach (PropertyToggleGridProxy propertyToggleGridProxy in list)
			{
				propertyToggleGridProxy.SetSelectedState(false);
			}
		}
		this.UpdateSelectAllToggle();
		this.UpdateTabMarks();
	}

	// Token: 0x0600B8C7 RID: 47303 RVA: 0x003120BC File Offset: 0x003102BC
	private void OnClickConfirm()
	{
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		foreach (Dictionary<int, string> dictionary2 in this.CostSelectionMap.Values)
		{
			foreach (KeyValuePair<int, string> keyValuePair in dictionary2)
			{
				dictionary[keyValuePair.Key] = keyValuePair.Value;
			}
		}
		FilterResultData filterResultData = ModelBase<FilterModel>.Instance.GetFilterResultData(this.ViewData.UniqueId);
		if (filterResultData != null)
		{
			filterResultData.SetSelectRuleData(FilterDefine.EFilterType.VisionDestroyAttribute, dictionary);
		}
		IMainPropertyFilterViewData viewData = this.ViewData;
		if (viewData != null)
		{
			Action confirmFunction = viewData.ConfirmFunction;
			if (confirmFunction != null)
			{
				confirmFunction();
			}
		}
		Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, null);
	}

	// Token: 0x0600B8C8 RID: 47304 RVA: 0x003121B0 File Offset: 0x003103B0
	private void SetCostSelection(int filterId, bool isSelected, string content)
	{
		foreach (int key in ConfigBase<FilterConfig>.Instance.GetCostByMainMainProp(filterId))
		{
			Dictionary<int, string> dictionary;
			if (!this.CostSelectionMap.TryGetValue(key, out dictionary))
			{
				dictionary = new Dictionary<int, string>();
				this.CostSelectionMap[key] = dictionary;
			}
			if (isSelected)
			{
				dictionary[filterId] = content;
			}
			else
			{
				dictionary.Remove(filterId);
			}
		}
	}

	// Token: 0x040056F0 RID: 22256
	[Nullable(2)]
	private PhantomManagerConfigNewElementItem ElementItem;

	// Token: 0x040056F1 RID: 22257
	[Nullable(2)]
	private IMainPropertyFilterViewData ViewData;

	// Token: 0x040056F2 RID: 22258
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<CostTabToggleGridProxy, int> CostTabLayout;

	// Token: 0x040056F3 RID: 22259
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<PropertyToggleGridProxy, FilterItemData> PropertyLayout;

	// Token: 0x040056F4 RID: 22260
	private int CurrentCost = 4;

	// Token: 0x040056F5 RID: 22261
	private readonly Dictionary<int, Dictionary<int, string>> CostSelectionMap = new Dictionary<int, Dictionary<int, string>>();

	// Token: 0x040056F6 RID: 22262
	private readonly List<int> CostList = new List<int>
	{
		4,
		3,
		1
	};

	// Token: 0x040056F7 RID: 22263
	private readonly Dictionary<int, List<FilterItemData>> CostPropertyDataMap = new Dictionary<int, List<FilterItemData>>();

	// Token: 0x02007C6A RID: 31850
	[NullableContext(0)]
	private class EFilterPropertyPopupComponents
	{
		// Token: 0x0402A7DB RID: 174043
		public const int PanelTabTogLayout = 0;

		// Token: 0x0402A7DC RID: 174044
		public const int TogTopTabItemFilter = 1;

		// Token: 0x0402A7DD RID: 174045
		public const int UiItemFilterGridS2 = 2;

		// Token: 0x0402A7DE RID: 174046
		public const int TogSelectAll = 3;

		// Token: 0x0402A7DF RID: 174047
		public const int PropertyLayout = 4;

		// Token: 0x0402A7E0 RID: 174048
		public const int TogItemProperty = 5;

		// Token: 0x0402A7E1 RID: 174049
		public const int BtnReset = 6;

		// Token: 0x0402A7E2 RID: 174050
		public const int BtnConfirm = 7;

		// Token: 0x0402A7E3 RID: 174051
		public const int PanelElementIcon = 8;

		// Token: 0x0402A7E4 RID: 174052
		public const int TxtAll = 9;
	}
}
