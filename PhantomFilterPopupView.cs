using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using FilterDefine;
using UnrealEngine;

// Token: 0x02001912 RID: 6418
[NullableContext(1)]
[Nullable(0)]
public class PhantomFilterPopupView : UiViewBase
{
	// Token: 0x0600B862 RID: 47202 RVA: 0x00310080 File Offset: 0x0030E280
	public PhantomFilterPopupView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600B863 RID: 47203 RVA: 0x003100A8 File Offset: 0x0030E2A8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 12;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 3;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickAddMainProperty));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(9, new Action(this.OnClickBtnReset));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(12, new Action(this.OnClickClose));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600B864 RID: 47204 RVA: 0x003102E8 File Offset: 0x0030E4E8
	protected override UniTask OnBeforeStartAsync()
	{
		PhantomFilterPopupView.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomFilterPopupView.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600B865 RID: 47205 RVA: 0x0031032C File Offset: 0x0030E52C
	protected override void OnStart()
	{
		this.RootActor.OnSequencePlayEvent.Bind(new Action<string, string>(this.OnPlaySequenceEvent));
		this.InitDropDown();
		this.LoadFilterData();
		FilterResultData filterResultData = ModelBase<FilterModel>.Instance.GetFilterResultData(this.ViewData.UniqueId);
		Dictionary<int, string> dictionary = (filterResultData != null) ? filterResultData.GetSelectRuleDataById(FilterDefine.EFilterType.PhantomManageFirstMainProp) : null;
		if (dictionary != null && dictionary.Count > 0)
		{
			this.MainAttributeFilterType = FilterDefine.EFilterType.PhantomManageFirstMainProp;
		}
		this.LoadMainPropertiesData();
		this.UpdateQuickButtonState();
		this.UpdateFilterCount();
		this.InitState = true;
	}

	// Token: 0x0600B866 RID: 47206 RVA: 0x003103B2 File Offset: 0x0030E5B2
	protected override void OnBeforeDestroy()
	{
		CommonDropDown<int, int> commonDropDown = this.CommonDropDown;
		if (commonDropDown != null)
		{
			commonDropDown.Destroy(null);
		}
		this.CommonDropDown = null;
	}

	// Token: 0x0600B867 RID: 47207 RVA: 0x003103CD File Offset: 0x0030E5CD
	protected override void OnBeforeShow()
	{
		this.UpdateFilterAnimation();
	}

	// Token: 0x0600B868 RID: 47208 RVA: 0x003103D6 File Offset: 0x0030E5D6
	private void OnClickClose()
	{
		Action onFilterViewClose = this.ViewData.OnFilterViewClose;
		if (onFilterViewClose != null)
		{
			onFilterViewClose();
		}
		Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, null);
	}

	// Token: 0x0600B869 RID: 47209 RVA: 0x00310404 File Offset: 0x0030E604
	private void OnFilterConfirm()
	{
		Action confirmFunction = this.ViewData.ConfirmFunction;
		if (confirmFunction != null)
		{
			confirmFunction();
		}
		this.UpdateQuickButtonState();
		if (!this.UpdateFilterAnimation())
		{
			this.UpdateFilterCount();
		}
	}

	// Token: 0x0600B86A RID: 47210 RVA: 0x00310430 File Offset: 0x0030E630
	private void OnPlaySequenceEvent(string sequenceName, string eventName)
	{
		if (eventName != "Sequence_Change_Number")
		{
			return;
		}
		this.UpdateFilterCount();
	}

	// Token: 0x0600B86B RID: 47211 RVA: 0x00310448 File Offset: 0x0030E648
	private void UpdateFilterCount()
	{
		List<IPhantomFilterData> filteredPhantomList = this.GetFilteredPhantomList();
		UUIText text = base.GetText(8);
		if (text != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "PhantomFilterCount", new <>z__ReadOnlySingleElementList<object>(filteredPhantomList.Count));
		}
	}

	// Token: 0x0600B86C RID: 47212 RVA: 0x00310488 File Offset: 0x0030E688
	private bool CheckHasFilter()
	{
		FilterResultData filterResultData = ModelBase<FilterModel>.Instance.GetFilterResultData(this.ViewData.UniqueId);
		if (filterResultData == null)
		{
			return false;
		}
		using (Dictionary<FilterDefine.EFilterType, Dictionary<int, string>>.ValueCollection.Enumerator enumerator = filterResultData.GetSelectRuleData().Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Count > 0)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0600B86D RID: 47213 RVA: 0x00310504 File Offset: 0x0030E704
	private bool UpdateFilterAnimation()
	{
		bool flag = this.CheckHasFilter();
		if (flag != this.LastHasFilter)
		{
			this.LastHasFilter = flag;
			if (!flag)
			{
				UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
				if (uiViewSequence != null)
				{
					uiViewSequence.PlaySequence("filtrate_Out", false, null);
				}
				return true;
			}
			UiBehaviorLevelSequence uiViewSequence2 = this.UiViewSequence;
			if (uiViewSequence2 != null)
			{
				uiViewSequence2.PlaySequence("filtrate_In", false, null);
			}
		}
		return false;
	}

	// Token: 0x0600B86E RID: 47214 RVA: 0x00310570 File Offset: 0x0030E770
	private void OnClickBtnReset()
	{
		FilterResultData filterResultData = ModelBase<FilterModel>.Instance.GetFilterResultData(this.ViewData.UniqueId);
		if (filterResultData == null)
		{
			return;
		}
		filterResultData.ClearSelectRuleData();
		this.LoadFilterData();
		this.LoadMainPropertiesData();
		if (this.CurrentSelectSuitIndex != 0)
		{
			this.CurrentSelectSuitIndex = 0;
			CommonDropDown<int, int> commonDropDown = this.CommonDropDown;
			if (commonDropDown != null)
			{
				commonDropDown.SetSelectedIndex(0, true);
			}
		}
		else
		{
			Action confirmFunction = this.ViewData.ConfirmFunction;
			if (confirmFunction != null)
			{
				confirmFunction();
			}
		}
		this.UpdateQuickButtonState();
		this.UpdateFilterAnimation();
	}

	// Token: 0x0600B86F RID: 47215 RVA: 0x003105F0 File Offset: 0x0030E7F0
	private void InitQualityLayout()
	{
		UUIHorizontalLayout horizontalLayout = base.GetHorizontalLayout(2);
		if (horizontalLayout == null)
		{
			return;
		}
		this.QualityLayout = new GenericLayout<QualityToggleGridProxy, FilterItemData>(horizontalLayout, new Func<QualityToggleGridProxy>(this.CreateQualityToggle), null, false, true);
	}

	// Token: 0x0600B870 RID: 47216 RVA: 0x00310624 File Offset: 0x0030E824
	private void InitStateLayout()
	{
		UUIHorizontalLayout horizontalLayout = base.GetHorizontalLayout(1);
		if (horizontalLayout == null)
		{
			return;
		}
		this.StateLayout = new GenericLayout<StateToggleGridProxy, FilterItemData>(horizontalLayout, new Func<StateToggleGridProxy>(this.CreateStateToggle), null, false, true);
	}

	// Token: 0x0600B871 RID: 47217 RVA: 0x00310658 File Offset: 0x0030E858
	private void InitMainPropertiesLayout()
	{
		UUIVerticalLayout verticalLayout = base.GetVerticalLayout(6);
		if (verticalLayout == null)
		{
			return;
		}
		this.MainPropertiesLayout = new GenericLayout<MainPropertyItem, FilterItemData>(verticalLayout, new Func<MainPropertyItem>(this.CreateMainPropertyItem), null, false, true);
	}

	// Token: 0x0600B872 RID: 47218 RVA: 0x0031068C File Offset: 0x0030E88C
	private QualityToggleGridProxy CreateQualityToggle()
	{
		QualityToggleGridProxy qualityToggleGridProxy = new QualityToggleGridProxy();
		qualityToggleGridProxy.SetToggleFunction(new TQualityToggleFunction(this.OnQualityToggleChanged));
		return qualityToggleGridProxy;
	}

	// Token: 0x0600B873 RID: 47219 RVA: 0x003106A5 File Offset: 0x0030E8A5
	private StateToggleGridProxy CreateStateToggle()
	{
		StateToggleGridProxy stateToggleGridProxy = new StateToggleGridProxy();
		stateToggleGridProxy.SetToggleFunction(new TQualityToggleFunction(this.OnStateToggleChanged));
		return stateToggleGridProxy;
	}

	// Token: 0x0600B874 RID: 47220 RVA: 0x003106BE File Offset: 0x0030E8BE
	private MainPropertyItem CreateMainPropertyItem()
	{
		MainPropertyItem mainPropertyItem = new MainPropertyItem();
		mainPropertyItem.SetDeleteCallback(new Action<int>(this.OnDeleteMainProperty));
		return mainPropertyItem;
	}

	// Token: 0x0600B875 RID: 47221 RVA: 0x003106D8 File Offset: 0x0030E8D8
	private void OnQualityToggleChanged(bool isChecked, int filterId, string content)
	{
		FilterResultData filterResultData = ModelBase<FilterModel>.Instance.GetFilterResultData(this.ViewData.UniqueId);
		Dictionary<int, string> dictionary = filterResultData.GetSelectRuleDataById(FilterDefine.EFilterType.VisionDestroyQuality) ?? new Dictionary<int, string>();
		if (isChecked)
		{
			dictionary[filterId] = content;
		}
		else
		{
			dictionary.Remove(filterId);
		}
		filterResultData.SetSelectRuleData(FilterDefine.EFilterType.VisionDestroyQuality, dictionary);
		this.OnFilterConfirm();
	}

	// Token: 0x0600B876 RID: 47222 RVA: 0x00310730 File Offset: 0x0030E930
	private void OnStateToggleChanged(bool isChecked, int filterId, string content)
	{
		FilterResultData filterResultData = ModelBase<FilterModel>.Instance.GetFilterResultData(this.ViewData.UniqueId);
		Dictionary<int, string> dictionary = ((filterResultData != null) ? filterResultData.GetSelectRuleDataById(FilterDefine.EFilterType.PhantomDeprecate) : null) ?? new Dictionary<int, string>();
		dictionary.Clear();
		if (isChecked)
		{
			dictionary[filterId] = content;
		}
		filterResultData.SetSelectRuleData(FilterDefine.EFilterType.PhantomDeprecate, dictionary);
		if (this.StateLayout != null)
		{
			foreach (StateToggleGridProxy stateToggleGridProxy in this.StateLayout.GetLayoutItemList())
			{
				FilterItemData data = stateToggleGridProxy.Data;
				if (data != null && data.FilterId == filterId && isChecked)
				{
					stateToggleGridProxy.SetSelectedState(true);
				}
				else
				{
					stateToggleGridProxy.SetSelectedState(false);
				}
			}
		}
		this.OnFilterConfirm();
	}

	// Token: 0x0600B877 RID: 47223 RVA: 0x00310800 File Offset: 0x0030EA00
	private void OnClickAddMainProperty()
	{
		int defaultSelectCostTab = 4;
		EFilterSortGroupId groupId = this.ViewData.GroupId;
		if (groupId != EFilterSortGroupId.VisionRefineMainCost3C)
		{
			if (groupId == EFilterSortGroupId.VisionRefineMainCost1C)
			{
				defaultSelectCostTab = 1;
			}
		}
		else
		{
			defaultSelectCostTab = 3;
		}
		int num = this.FetterSuitFilterArray[this.CurrentSelectSuitIndex];
		MainPropertyFilterViewData param = new MainPropertyFilterViewData
		{
			UniqueId = this.ViewData.UniqueId,
			DefaultSelectCostTab = defaultSelectCostTab,
			ConfirmFunction = delegate
			{
				this.LoadMainPropertiesData();
				this.OnFilterConfirm();
			},
			CurrentFetterId = ((num == 0) ? null : new int?(num))
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomMainPropertyPopupView, param, null);
	}

	// Token: 0x0600B878 RID: 47224 RVA: 0x0031089C File Offset: 0x0030EA9C
	private void OnDeleteMainProperty(int filterId)
	{
		FilterResultData filterResultData = ModelBase<FilterModel>.Instance.GetFilterResultData(this.ViewData.UniqueId);
		Dictionary<int, string> dictionary = ((filterResultData != null) ? filterResultData.GetSelectRuleDataById(this.MainAttributeFilterType) : null) ?? new Dictionary<int, string>();
		dictionary.Remove(filterId);
		filterResultData.SetSelectRuleData(this.MainAttributeFilterType, dictionary);
		this.LoadMainPropertiesData();
		this.OnFilterConfirm();
	}

	// Token: 0x0600B879 RID: 47225 RVA: 0x003108FC File Offset: 0x0030EAFC
	private void LoadFilterData()
	{
		FilterResultData resultData = ModelBase<FilterModel>.Instance.GetFilterResultData(this.ViewData.UniqueId);
		if (resultData == null)
		{
			return;
		}
		Filter? filterConfig = ConfigBase<FilterConfig>.Instance.GetFilterConfig(resultData.ConfigId);
		if (filterConfig == null)
		{
			return;
		}
		int[] array = filterConfig.Value.RuleList();
		int? num = null;
		foreach (int num2 in array)
		{
			if (ConfigBase<FilterConfig>.Instance.GetFilterRuleConfig(num2).Value.FilterType == 24)
			{
				num = new int?(num2);
				break;
			}
		}
		if (num != null)
		{
			List<FilterItemData> filterItemDataList = ModelBase<FilterModel>.Instance.GetFilterItemDataList(num.Value, resultData.ConfigId);
			if (filterItemDataList != null && filterItemDataList.Count > 0)
			{
				GenericLayout<QualityToggleGridProxy, FilterItemData> qualityLayout = this.QualityLayout;
				if (qualityLayout != null)
				{
					qualityLayout.RefreshByData(filterItemDataList, delegate
					{
						Dictionary<int, string> selectRuleDataById = resultData.GetSelectRuleDataById(FilterDefine.EFilterType.VisionDestroyQuality);
						GenericLayout<QualityToggleGridProxy, FilterItemData> qualityLayout2 = this.QualityLayout;
						List<QualityToggleGridProxy> list = (qualityLayout2 != null) ? qualityLayout2.GetLayoutItemList() : null;
						if (list != null)
						{
							foreach (QualityToggleGridProxy qualityToggleGridProxy in list)
							{
								if (selectRuleDataById != null)
								{
									Dictionary<int, string> dictionary = selectRuleDataById;
									FilterItemData data = qualityToggleGridProxy.Data;
									if (dictionary.ContainsKey((data != null) ? data.FilterId : 0))
									{
										qualityToggleGridProxy.SetSelectedState(true);
										continue;
									}
								}
								qualityToggleGridProxy.SetSelectedState(false);
							}
						}
					}, false);
				}
			}
		}
		int? num3 = null;
		foreach (int num4 in array)
		{
			if (ConfigBase<FilterConfig>.Instance.GetFilterRuleConfig(num4).Value.FilterType == 28)
			{
				num3 = new int?(num4);
				break;
			}
		}
		if (num3 != null)
		{
			List<FilterItemData> filterItemDataList2 = ModelBase<FilterModel>.Instance.GetFilterItemDataList(num3.Value, resultData.ConfigId);
			if (filterItemDataList2 != null && filterItemDataList2.Count > 0)
			{
				GenericLayout<StateToggleGridProxy, FilterItemData> stateLayout = this.StateLayout;
				if (stateLayout == null)
				{
					return;
				}
				stateLayout.RefreshByData(filterItemDataList2, delegate
				{
					Dictionary<int, string> selectRuleDataById = resultData.GetSelectRuleDataById(FilterDefine.EFilterType.PhantomDeprecate);
					GenericLayout<StateToggleGridProxy, FilterItemData> stateLayout2 = this.StateLayout;
					List<StateToggleGridProxy> list = (stateLayout2 != null) ? stateLayout2.GetLayoutItemList() : null;
					if (list != null)
					{
						foreach (StateToggleGridProxy stateToggleGridProxy in list)
						{
							if (selectRuleDataById != null)
							{
								Dictionary<int, string> dictionary = selectRuleDataById;
								FilterItemData data = stateToggleGridProxy.Data;
								if (dictionary.ContainsKey((data != null) ? data.FilterId : 0))
								{
									stateToggleGridProxy.SetSelectedState(true);
									continue;
								}
							}
							stateToggleGridProxy.SetSelectedState(false);
						}
					}
				}, false);
			}
		}
	}

	// Token: 0x0600B87A RID: 47226 RVA: 0x00310AB8 File Offset: 0x0030ECB8
	private void LoadMainPropertiesData()
	{
		FilterResultData filterResultData = ModelBase<FilterModel>.Instance.GetFilterResultData(this.ViewData.UniqueId);
		if (filterResultData == null)
		{
			return;
		}
		Dictionary<int, string> selectRuleDataById = filterResultData.GetSelectRuleDataById(this.MainAttributeFilterType);
		List<FilterItemData> list = new List<FilterItemData>();
		if (selectRuleDataById != null)
		{
			foreach (KeyValuePair<int, string> keyValuePair in selectRuleDataById)
			{
				list.Add(new FilterItemData(keyValuePair.Key, keyValuePair.Value, null));
			}
		}
		GenericLayout<MainPropertyItem, FilterItemData> mainPropertiesLayout = this.MainPropertiesLayout;
		if (mainPropertiesLayout == null)
		{
			return;
		}
		mainPropertiesLayout.RefreshByData(list, null, false);
	}

	// Token: 0x0600B87B RID: 47227 RVA: 0x00310B60 File Offset: 0x0030ED60
	private UniTask InitSuitFilter()
	{
		PhantomFilterPopupView.<InitSuitFilter>d__40 <InitSuitFilter>d__;
		<InitSuitFilter>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitSuitFilter>d__.<>4__this = this;
		<InitSuitFilter>d__.<>1__state = -1;
		<InitSuitFilter>d__.<>t__builder.Start<PhantomFilterPopupView.<InitSuitFilter>d__40>(ref <InitSuitFilter>d__);
		return <InitSuitFilter>d__.<>t__builder.Task;
	}

	// Token: 0x0600B87C RID: 47228 RVA: 0x00310BA4 File Offset: 0x0030EDA4
	private void InitDropDown()
	{
		IEnumerable<PhantomFetterGroup> fetterGroupArray = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupArray();
		this.FetterSortIdMap.Clear();
		this.FetterSuitFilterArray.Clear();
		foreach (PhantomFetterGroup phantomFetterGroup in fetterGroupArray)
		{
			this.FetterSuitFilterArray.Add(phantomFetterGroup.Id);
			this.FetterSortIdMap[phantomFetterGroup.Id] = phantomFetterGroup.SortId;
		}
		this.FetterSuitFilterArray.Sort((int a, int b) => this.FetterSortIdMap[b] - this.FetterSortIdMap[a]);
		this.FetterSuitFilterArray.Insert(0, 0);
		FilterResultData filterResultData = ModelBase<FilterModel>.Instance.GetFilterResultData(this.ViewData.UniqueId);
		Dictionary<int, string> dictionary = (filterResultData != null) ? filterResultData.GetSelectRuleDataById(FilterDefine.EFilterType.VisionDestroyFetterGroup) : null;
		if (dictionary != null && dictionary.Count > 0)
		{
			int item = 0;
			using (Dictionary<int, string>.Enumerator enumerator2 = dictionary.GetEnumerator())
			{
				if (enumerator2.MoveNext())
				{
					KeyValuePair<int, string> keyValuePair = enumerator2.Current;
					item = keyValuePair.Key;
				}
			}
			int num = this.FetterSuitFilterArray.IndexOf(item);
			if (num != -1)
			{
				this.CurrentSelectSuitIndex = num;
			}
		}
		else
		{
			this.CurrentSelectSuitIndex = 0;
		}
		this.CommonDropDown.SetOnSelectCall(new Action<int, int>(this.OnDropDownSelectCall));
		this.CommonDropDown.SetShowType(ECommonDropDownShowType.Down);
		this.CommonDropDown.InitScroll(this.FetterSuitFilterArray, new Func<int, int>(this.GetDropDownTextId), this.CurrentSelectSuitIndex, true);
	}

	// Token: 0x0600B87D RID: 47229 RVA: 0x00310D34 File Offset: 0x0030EF34
	private void OnDropDownSelectCall(int index, int data)
	{
		this.CurrentSelectSuitIndex = index;
		if (!this.InitState)
		{
			return;
		}
		this.UpdateSuitFilter();
		this.OnFilterConfirm();
	}

	// Token: 0x0600B87E RID: 47230 RVA: 0x00310D52 File Offset: 0x0030EF52
	private int GetDropDownTextId(int data)
	{
		return data;
	}

	// Token: 0x0600B87F RID: 47231 RVA: 0x00310D55 File Offset: 0x0030EF55
	private VisionEquipmentDropDownItem CreateDropDownItem(UUIItem uiItem, int data)
	{
		return new VisionEquipmentDropDownItem(uiItem);
	}

	// Token: 0x0600B880 RID: 47232 RVA: 0x00310D5D File Offset: 0x0030EF5D
	private VisionEquipmentDropDownTitleItem CreateTitleItem(UUIItem uiItem)
	{
		return new VisionEquipmentDropDownTitleItem(uiItem);
	}

	// Token: 0x0600B881 RID: 47233 RVA: 0x00310D68 File Offset: 0x0030EF68
	private void UpdateSuitFilter()
	{
		int num = this.FetterSuitFilterArray[this.CurrentSelectSuitIndex];
		FilterResultData filterResultData = ModelBase<FilterModel>.Instance.GetFilterResultData(this.ViewData.UniqueId);
		Dictionary<int, string> dictionary = ((filterResultData != null) ? filterResultData.GetSelectRuleDataById(FilterDefine.EFilterType.VisionDestroyFetterGroup) : null) ?? new Dictionary<int, string>();
		dictionary.Clear();
		if (num > 0)
		{
			PhantomFetterGroup fetterGroupById = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(num);
			string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(fetterGroupById.FetterGroupName, "");
			dictionary[num] = multiTextByKey;
		}
		filterResultData.SetSelectRuleData(FilterDefine.EFilterType.VisionDestroyFetterGroup, dictionary);
	}

	// Token: 0x0600B882 RID: 47234 RVA: 0x00310DF4 File Offset: 0x0030EFF4
	private InventoryDefine.EItemDataFunctionValue? CheckSelectStateSame()
	{
		List<IPhantomFilterData> filteredPhantomList = this.GetFilteredPhantomList();
		if (filteredPhantomList.Count == 0)
		{
			InventoryDefine.EItemDataFunctionValue? result = null;
			return result;
		}
		InventoryDefine.EItemDataFunctionValue? eitemDataFunctionValue = null;
		foreach (IPhantomFilterData phantomFilterData in filteredPhantomList)
		{
			PhantomItemData phantomItemData = ModelBase<InventoryModel>.Instance.GetPhantomItemData(phantomFilterData.GetUniqueId());
			if (phantomItemData != null)
			{
				InventoryDefine.EItemDataFunctionValue functionValueType = phantomItemData.GetFunctionValueType();
				if (eitemDataFunctionValue == null)
				{
					eitemDataFunctionValue = new InventoryDefine.EItemDataFunctionValue?(functionValueType);
				}
				else
				{
					InventoryDefine.EItemDataFunctionValue eitemDataFunctionValue2 = functionValueType;
					InventoryDefine.EItemDataFunctionValue? result = eitemDataFunctionValue;
					if (!(eitemDataFunctionValue2 == result.GetValueOrDefault() & result != null))
					{
						result = null;
						return result;
					}
				}
			}
		}
		return eitemDataFunctionValue;
	}

	// Token: 0x0600B883 RID: 47235 RVA: 0x00310EB8 File Offset: 0x0030F0B8
	private void UpdateQuickButtonState()
	{
		InventoryDefine.EItemDataFunctionValue? eitemDataFunctionValue = this.CheckSelectStateSame();
		if (eitemDataFunctionValue.GetValueOrDefault() == InventoryDefine.EItemDataFunctionValue.Deprecate)
		{
			ButtonItem btnDiscardItem = this.BtnDiscardItem;
			if (btnDiscardItem != null)
			{
				btnDiscardItem.SetShowText("PhantomFilterQuickCancelDiscard");
			}
		}
		else
		{
			ButtonItem btnDiscardItem2 = this.BtnDiscardItem;
			if (btnDiscardItem2 != null)
			{
				btnDiscardItem2.SetShowText("PhantomFilterQuickDiscard");
			}
		}
		if (eitemDataFunctionValue.GetValueOrDefault() == InventoryDefine.EItemDataFunctionValue.Lock)
		{
			ButtonItem btnLockItem = this.BtnLockItem;
			if (btnLockItem == null)
			{
				return;
			}
			btnLockItem.SetShowText("PhantomFilterQuickCancelLock");
			return;
		}
		else
		{
			ButtonItem btnLockItem2 = this.BtnLockItem;
			if (btnLockItem2 == null)
			{
				return;
			}
			btnLockItem2.SetShowText("PhantomFilterQuickLock");
			return;
		}
	}

	// Token: 0x0600B884 RID: 47236 RVA: 0x00310F39 File Offset: 0x0030F139
	private List<IPhantomFilterData> GetFilteredPhantomList()
	{
		PhantomFilterViewData<IPhantomFilterData> viewData = this.ViewData;
		if (((viewData != null) ? viewData.GetFilteredDataListFunc : null) == null)
		{
			return new List<IPhantomFilterData>();
		}
		return this.ViewData.GetFilteredDataListFunc();
	}

	// Token: 0x0600B885 RID: 47237 RVA: 0x00310F68 File Offset: 0x0030F168
	private void OnClickBtnDiscard(int state)
	{
		bool isCancel = this.CheckSelectStateSame().GetValueOrDefault() == InventoryDefine.EItemDataFunctionValue.Deprecate;
		List<IPhantomFilterData> filteredPhantomList = this.GetFilteredPhantomList();
		if (filteredPhantomList.Count == 0)
		{
			return;
		}
		List<int> uniqueIdList = new List<int>();
		foreach (IPhantomFilterData phantomFilterData in filteredPhantomList)
		{
			uniqueIdList.Add(phantomFilterData.GetUniqueId());
		}
		PhantomConfirmPopupViewData phantomConfirmPopupViewData = new PhantomConfirmPopupViewData();
		phantomConfirmPopupViewData.Title = (isCancel ? "PhantomFilterCancelDiscardConfirmTitle" : "PhantomFilterDiscardConfirmTitle");
		phantomConfirmPopupViewData.SubTitle = (isCancel ? "PhantomFilterCancelDiscardDisplayTips" : "PhantomFilterDiscardDisplayTips");
		phantomConfirmPopupViewData.PhantomUniqueIdList = uniqueIdList;
		phantomConfirmPopupViewData.OnLeft = delegate()
		{
		};
		phantomConfirmPopupViewData.OnMiddle = delegate()
		{
			this.ExecuteBatchDeprecate(uniqueIdList, !isCancel).ContinueWith(new Action(this.OnFilterConfirm));
		};
		phantomConfirmPopupViewData.LeftTxtKey = "PhantomFilterButtonText_Cancel";
		phantomConfirmPopupViewData.MiddleTxtKey = "PhantomFilterButtonText_Confirm";
		PhantomConfirmPopupViewData param = phantomConfirmPopupViewData;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomBatchConfirmPopupView, param, null);
	}

	// Token: 0x0600B886 RID: 47238 RVA: 0x003110A8 File Offset: 0x0030F2A8
	private void OnClickBtnLock(int state)
	{
		bool isCancel = this.CheckSelectStateSame().GetValueOrDefault() == InventoryDefine.EItemDataFunctionValue.Lock;
		List<IPhantomFilterData> filteredPhantomList = this.GetFilteredPhantomList();
		if (filteredPhantomList.Count == 0)
		{
			return;
		}
		List<int> uniqueIdList = new List<int>();
		foreach (IPhantomFilterData phantomFilterData in filteredPhantomList)
		{
			uniqueIdList.Add(phantomFilterData.GetUniqueId());
		}
		PhantomConfirmPopupViewData phantomConfirmPopupViewData = new PhantomConfirmPopupViewData();
		phantomConfirmPopupViewData.Title = (isCancel ? "PhantomFilterCancelLockConfirmTitle" : "PhantomFilterLockConfirmTitle");
		phantomConfirmPopupViewData.SubTitle = (isCancel ? "PhantomFilterCancelLockDisplayTips" : "PhantomFilterLockDisplayTips");
		phantomConfirmPopupViewData.PhantomUniqueIdList = uniqueIdList;
		phantomConfirmPopupViewData.OnLeft = delegate()
		{
		};
		phantomConfirmPopupViewData.OnMiddle = delegate()
		{
			this.ExecuteBatchLock(uniqueIdList, !isCancel).ContinueWith(new Action(this.OnFilterConfirm));
		};
		phantomConfirmPopupViewData.LeftTxtKey = "PhantomFilterButtonText_Cancel";
		phantomConfirmPopupViewData.MiddleTxtKey = "PhantomFilterButtonText_Confirm";
		PhantomConfirmPopupViewData param = phantomConfirmPopupViewData;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomBatchConfirmPopupView, param, null);
	}

	// Token: 0x0600B887 RID: 47239 RVA: 0x003111E8 File Offset: 0x0030F3E8
	private UniTask ExecuteBatchDeprecate(List<int> uniqueIdList, bool isDeprecate)
	{
		PhantomFilterPopupView.<ExecuteBatchDeprecate>d__52 <ExecuteBatchDeprecate>d__;
		<ExecuteBatchDeprecate>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ExecuteBatchDeprecate>d__.uniqueIdList = uniqueIdList;
		<ExecuteBatchDeprecate>d__.isDeprecate = isDeprecate;
		<ExecuteBatchDeprecate>d__.<>1__state = -1;
		<ExecuteBatchDeprecate>d__.<>t__builder.Start<PhantomFilterPopupView.<ExecuteBatchDeprecate>d__52>(ref <ExecuteBatchDeprecate>d__);
		return <ExecuteBatchDeprecate>d__.<>t__builder.Task;
	}

	// Token: 0x0600B888 RID: 47240 RVA: 0x00311234 File Offset: 0x0030F434
	private UniTask ExecuteBatchLock(List<int> uniqueIdList, bool isLock)
	{
		PhantomFilterPopupView.<ExecuteBatchLock>d__53 <ExecuteBatchLock>d__;
		<ExecuteBatchLock>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ExecuteBatchLock>d__.uniqueIdList = uniqueIdList;
		<ExecuteBatchLock>d__.isLock = isLock;
		<ExecuteBatchLock>d__.<>1__state = -1;
		<ExecuteBatchLock>d__.<>t__builder.Start<PhantomFilterPopupView.<ExecuteBatchLock>d__53>(ref <ExecuteBatchLock>d__);
		return <ExecuteBatchLock>d__.<>t__builder.Task;
	}

	// Token: 0x040056D9 RID: 22233
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private PhantomFilterViewData<IPhantomFilterData> ViewData;

	// Token: 0x040056DA RID: 22234
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<QualityToggleGridProxy, FilterItemData> QualityLayout;

	// Token: 0x040056DB RID: 22235
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<StateToggleGridProxy, FilterItemData> StateLayout;

	// Token: 0x040056DC RID: 22236
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<MainPropertyItem, FilterItemData> MainPropertiesLayout;

	// Token: 0x040056DD RID: 22237
	[Nullable(2)]
	private CommonDropDown<int, int> CommonDropDown;

	// Token: 0x040056DE RID: 22238
	private readonly List<int> FetterSuitFilterArray = new List<int>();

	// Token: 0x040056DF RID: 22239
	private readonly Dictionary<int, int> FetterSortIdMap = new Dictionary<int, int>();

	// Token: 0x040056E0 RID: 22240
	private int CurrentSelectSuitIndex;

	// Token: 0x040056E1 RID: 22241
	[Nullable(2)]
	private ButtonItem BtnDiscardItem;

	// Token: 0x040056E2 RID: 22242
	[Nullable(2)]
	private ButtonItem BtnLockItem;

	// Token: 0x040056E3 RID: 22243
	[Nullable(2)]
	public PopupCaptionItem CaptionItem;

	// Token: 0x040056E4 RID: 22244
	private bool InitState;

	// Token: 0x040056E5 RID: 22245
	private bool LastHasFilter;

	// Token: 0x040056E6 RID: 22246
	private FilterDefine.EFilterType MainAttributeFilterType = FilterDefine.EFilterType.VisionDestroyAttribute;

	// Token: 0x02007C5F RID: 31839
	[NullableContext(0)]
	private class EPhantomFilterComp
	{
		// Token: 0x0402A7AA RID: 173994
		public const int Caption = 0;

		// Token: 0x0402A7AB RID: 173995
		public const int StateLayout = 1;

		// Token: 0x0402A7AC RID: 173996
		public const int QualityLayout = 2;

		// Token: 0x0402A7AD RID: 173997
		public const int TogQualityItem = 3;

		// Token: 0x0402A7AE RID: 173998
		public const int SuitFilter = 4;

		// Token: 0x0402A7AF RID: 173999
		public const int BtnAddMainPro = 5;

		// Token: 0x0402A7B0 RID: 174000
		public const int PanelMainPropertiesLayout = 6;

		// Token: 0x0402A7B1 RID: 174001
		public const int PanelPropertyItem = 7;

		// Token: 0x0402A7B2 RID: 174002
		public const int TxtFilterCount = 8;

		// Token: 0x0402A7B3 RID: 174003
		public const int BtnReset = 9;

		// Token: 0x0402A7B4 RID: 174004
		public const int BtnConfirmBaseDiscard = 10;

		// Token: 0x0402A7B5 RID: 174005
		public const int BtnConfirmBaseLock = 11;

		// Token: 0x0402A7B6 RID: 174006
		public const int BtnClose = 12;
	}
}
