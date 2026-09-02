using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.FilterSort.Sort.SortEntrance;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001817 RID: 6167
[NullableContext(2)]
[Nullable(0)]
public class VisionRefineChoosePanel : UiPanelBase
{
	// Token: 0x17000E4C RID: 3660
	// (get) Token: 0x0600AF8A RID: 44938 RVA: 0x002EC778 File Offset: 0x002EA978
	private PhantomItemData SelectedData
	{
		get
		{
			if (this.CurrentRefineType == EVisionRefineRefineType.Main)
			{
				Singleton<Log>.Instance.Error(ELogModule.Calabash, ELogAuthor.WZ, "主音洗练时不应该使用单选逻辑", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			return this.SelectedDataInternal;
		}
	}

	// Token: 0x17000E4D RID: 3661
	// (get) Token: 0x0600AF8B RID: 44939 RVA: 0x002EC7B4 File Offset: 0x002EA9B4
	public EFilterSortGroupId FilterSortGroupId
	{
		get
		{
			if (this.CurrentRefineType == EVisionRefineRefineType.Main)
			{
				EVisionRefineCostType? currentCostType = this.CurrentCostType;
				if (currentCostType != null)
				{
					switch (currentCostType.GetValueOrDefault())
					{
					case EVisionRefineCostType.Cost4:
						return EFilterSortGroupId.VisionRefineMainCost4C;
					case EVisionRefineCostType.Cost3:
						return EFilterSortGroupId.VisionRefineMainCost3C;
					case EVisionRefineCostType.Cost1:
						return EFilterSortGroupId.VisionRefineMainCost1C;
					}
				}
				return EFilterSortGroupId.VisionRefine;
			}
			if (this.CurrentRefineType == EVisionRefineRefineType.Sub)
			{
				return EFilterSortGroupId.VisionRefineSub;
			}
			return EFilterSortGroupId.VisionRefine;
		}
	}

	// Token: 0x17000E4E RID: 3662
	// (get) Token: 0x0600AF8C RID: 44940 RVA: 0x002EC810 File Offset: 0x002EAA10
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<PhantomItemData> CurrentSelectedList
	{
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		get
		{
			if (this.CurrentRefineType != EVisionRefineRefineType.Main)
			{
				Singleton<Log>.Instance.Error(ELogModule.Calabash, ELogAuthor.WZ, "辅音洗练时不应该使用多选逻辑", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			if (this.CurrentCostType == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Calabash, ELogAuthor.WZ, "主音洗练时尚未选择cost，检查调用时机", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			List<PhantomItemData> result;
			if (this.MultiSelectedData.TryGetValue(this.CurrentCostType.Value, out result))
			{
				return result;
			}
			return null;
		}
	}

	// Token: 0x17000E4F RID: 3663
	// (get) Token: 0x0600AF8D RID: 44941 RVA: 0x002EC897 File Offset: 0x002EAA97
	// (set) Token: 0x0600AF8E RID: 44942 RVA: 0x002EC89F File Offset: 0x002EAA9F
	public EVisionRefineRefineType CurrentRefineType
	{
		get
		{
			return this.CurrentRefineTypeInternal;
		}
		set
		{
			this.CurrentRefineTypeInternal = value;
			UUIItem item = base.GetItem(9);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(this.CurrentRefineTypeInternal == EVisionRefineRefineType.Main);
		}
	}

	// Token: 0x17000E50 RID: 3664
	// (get) Token: 0x0600AF8F RID: 44943 RVA: 0x002EC8C4 File Offset: 0x002EAAC4
	public EVisionRefineCostType? CurrentCostType
	{
		get
		{
			if (this.CurrentRefineType == EVisionRefineRefineType.Sub)
			{
				Singleton<Log>.Instance.Error(ELogModule.Calabash, ELogAuthor.WZ, "辅音洗练时不应该使用Cost逻辑", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			return new EVisionRefineCostType?(this.CurrentCostTypeInternal);
		}
	}

	// Token: 0x0600AF90 RID: 44944 RVA: 0x002EC910 File Offset: 0x002EAB10
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnClickMask)),
			new ValueTuple<int, Delegate>(3, new Action(this.OnClickClose))
		};
	}

	// Token: 0x0600AF91 RID: 44945 RVA: 0x002ECA6F File Offset: 0x002EAC6F
	protected override void OnBeforeCreateImplement()
	{
		this.UiViewSequence = new UiBehaviorLevelSequence(this);
		base.AddUiBehavior(this.UiViewSequence);
	}

	// Token: 0x0600AF92 RID: 44946 RVA: 0x002ECA8C File Offset: 0x002EAC8C
	protected override UniTask OnBeforeStartAsync()
	{
		VisionRefineChoosePanel.<OnBeforeStartAsync>d__32 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VisionRefineChoosePanel.<OnBeforeStartAsync>d__32>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600AF93 RID: 44947 RVA: 0x002ECACF File Offset: 0x002EACCF
	protected override void OnStart()
	{
		this.FilterEntrance = new FilterEntrance<PhantomItemData>(base.GetItem(7), new TUpdateDataListFunction<PhantomItemData>(this.OnFilterSortRefresh));
		this.SortEntrance = new SortEntrance<PhantomItemData>(base.GetItem(8), new TUpdateDataListFunction<PhantomItemData>(this.OnFilterSortRefresh));
	}

	// Token: 0x0600AF94 RID: 44948 RVA: 0x002ECB10 File Offset: 0x002EAD10
	[NullableContext(1)]
	private VisionRefineMediumItemGrid InitItem()
	{
		VisionRefineMediumItemGrid visionRefineMediumItemGrid = new VisionRefineMediumItemGrid();
		visionRefineMediumItemGrid.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.OnItemToggleStateChanged));
		visionRefineMediumItemGrid.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(this.OnItemCanExecuteChange));
		visionRefineMediumItemGrid.BindReduceButtonCallback(new Action<MediumItemGridButtonCallback>(this.OnItemReduceButtonClicked), null);
		visionRefineMediumItemGrid.CheckSelectByView = new Func<PhantomItemData, bool>(this.CheckItemSelect);
		visionRefineMediumItemGrid.CheckWarningByView = new Func<PhantomItemData, bool>(this.CheckItemWarning);
		visionRefineMediumItemGrid.GetRefineType = (() => this.CurrentRefineType);
		return visionRefineMediumItemGrid;
	}

	// Token: 0x0600AF95 RID: 44949 RVA: 0x002ECB8F File Offset: 0x002EAD8F
	[NullableContext(1)]
	private VisionRefineTabCostItem InitCostTabItem()
	{
		return new VisionRefineTabCostItem();
	}

	// Token: 0x0600AF96 RID: 44950 RVA: 0x002ECB96 File Offset: 0x002EAD96
	public void ClearSelection()
	{
		this.RefreshChangeSelect(null);
		if (this.OnChangeCallBack != null)
		{
			this.OnChangeCallBack(this.SelectedData);
		}
	}

	// Token: 0x0600AF97 RID: 44951 RVA: 0x002ECBB8 File Offset: 0x002EADB8
	public void ClearCurrentCostMultiChoose()
	{
		if (this.CurrentCostType == null)
		{
			return;
		}
		List<PhantomItemData> list;
		if (!this.MultiSelectedData.TryGetValue(this.CurrentCostType.Value, out list))
		{
			return;
		}
		for (int i = list.Count - 1; i >= 0; i--)
		{
			PhantomItemData itemData = list[i];
			list.RemoveAt(i);
			this.RefreshGridByData(itemData);
		}
	}

	// Token: 0x0600AF98 RID: 44952 RVA: 0x002ECC20 File Offset: 0x002EAE20
	public void RemoveInvalidSelections()
	{
		this.ShowTipsComponent(null);
		if (this.SelectedDataInternal != null)
		{
			int uniqueId = this.SelectedDataInternal.GetUniqueId();
			if (ModelBase<PhantomBattleModel>.Instance.GetPhantomDataBase(uniqueId) == null)
			{
				this.SelectedDataInternal = null;
			}
		}
		foreach (KeyValuePair<EVisionRefineCostType, List<PhantomItemData>> keyValuePair in this.MultiSelectedData)
		{
			List<PhantomItemData> value = keyValuePair.Value;
			for (int i = value.Count - 1; i >= 0; i--)
			{
				int uniqueId2 = value[i].GetUniqueId();
				if (ModelBase<PhantomBattleModel>.Instance.GetPhantomDataBase(uniqueId2) == null)
				{
					value.RemoveAt(i);
				}
			}
		}
	}

	// Token: 0x0600AF99 RID: 44953 RVA: 0x002ECCE0 File Offset: 0x002EAEE0
	public PhantomItemData GetSelection()
	{
		return this.SelectedData;
	}

	// Token: 0x0600AF9A RID: 44954 RVA: 0x002ECCE8 File Offset: 0x002EAEE8
	public void SetSelection(PhantomItemData data)
	{
		this.SelectedDataInternal = data;
	}

	// Token: 0x0600AF9B RID: 44955 RVA: 0x002ECCF4 File Offset: 0x002EAEF4
	[NullableContext(1)]
	private bool CostFilter(PhantomItemData value)
	{
		int rarity = value.GetConfig().As<PhantomItem>().Value.Rarity;
		switch (ConfigBase<PhantomBattleConfig>.Instance.GetPhantomRareConfig(rarity).Value.Cost)
		{
		case 1:
			return this.CurrentCostType.GetValueOrDefault() == EVisionRefineCostType.Cost1;
		case 3:
			return this.CurrentCostType.GetValueOrDefault() == EVisionRefineCostType.Cost3;
		case 4:
		{
			EVisionRefineCostType? currentCostType = this.CurrentCostType;
			EVisionRefineCostType evisionRefineCostType = EVisionRefineCostType.Cost4;
			return currentCostType.GetValueOrDefault() == evisionRefineCostType & currentCostType != null;
		}
		}
		return false;
	}

	// Token: 0x0600AF9C RID: 44956 RVA: 0x002ECD9C File Offset: 0x002EAF9C
	[NullableContext(1)]
	public void SetSelectionDummy(PhantomItemData data)
	{
		int rarity = data.GetConfig().As<PhantomItem>().Value.Rarity;
		switch (ConfigBase<PhantomBattleConfig>.Instance.GetPhantomRareConfig(rarity).Value.Cost)
		{
		case 1:
			this.CurrentCostTypeInternal = EVisionRefineCostType.Cost1;
			break;
		case 3:
			this.CurrentCostTypeInternal = EVisionRefineCostType.Cost3;
			break;
		case 4:
			this.CurrentCostTypeInternal = EVisionRefineCostType.Cost4;
			break;
		}
		List<PhantomItemData> list;
		this.MultiSelectedData.TryGetValue(this.CurrentCostTypeInternal, out list);
		if (list == null || list.Count != 0)
		{
			return;
		}
		list.Add(data);
	}

	// Token: 0x0600AF9D RID: 44957 RVA: 0x002ECE40 File Offset: 0x002EB040
	[NullableContext(1)]
	public void RefreshList(List<PhantomItemData> data)
	{
		this.MetaAllDataCache = data;
		List<PhantomItemData> dataList = data;
		if (this.CurrentRefineType == EVisionRefineRefineType.Main)
		{
			List<PhantomItemData> list = new List<PhantomItemData>();
			foreach (PhantomItemData phantomItemData in data)
			{
				if (this.CostFilter(phantomItemData))
				{
					list.Add(phantomItemData);
				}
			}
			dataList = list;
		}
		this.SortEntrance.SetSortToggleState(false);
		this.FilterEntrance.UpdateData(this.FilterSortGroupId, dataList, Array.Empty<object>());
		int uniqueIdByGroupId = this.FilterEntrance.GetUniqueIdByGroupId(this.FilterSortGroupId);
		this.SortEntrance.SetFilterUniqueId(uniqueIdByGroupId);
		this.SortEntrance.UpdateData(this.FilterSortGroupId, dataList, Array.Empty<object>());
		int uniqueIdByGroupId2 = this.SortEntrance.GetUniqueIdByGroupId(this.FilterSortGroupId);
		this.FilterEntrance.SetSortUniqueId(uniqueIdByGroupId2);
	}

	// Token: 0x0600AF9E RID: 44958 RVA: 0x002ECF2C File Offset: 0x002EB12C
	public void ShowTipsComponent(PhantomItemData itemData)
	{
		if (itemData == null || this.CurrentRefineType == EVisionRefineRefineType.Sub)
		{
			base.GetItem(2).SetUIActive(false);
			UUIButtonComponent button = base.GetButton(1);
			if (button == null)
			{
				return;
			}
			button.RootUIComp.Get().SetUIActive(false);
			return;
		}
		else
		{
			ItemTipsData tipsDataById = ItemTipsComponentUtilTool.GetTipsDataById(itemData.GetConfigId(), new int?(itemData.GetUniqueId()), null);
			if (tipsDataById != null)
			{
				this.TipsComponent.Refresh(tipsDataById);
			}
			base.GetItem(2).SetUIActive(true);
			UUIButtonComponent button2 = base.GetButton(1);
			if (button2 == null)
			{
				return;
			}
			button2.RootUIComp.Get().SetUIActive(true);
			return;
		}
	}

	// Token: 0x0600AF9F RID: 44959 RVA: 0x002ECFC5 File Offset: 0x002EB1C5
	public void RefreshCurrency(int[] itemIdList)
	{
		if (itemIdList == null)
		{
			PopupCaptionItem captionItem = this.CaptionItem;
			if (captionItem == null)
			{
				return;
			}
			captionItem.SetUiActive(false);
			return;
		}
		else
		{
			PopupCaptionItem captionItem2 = this.CaptionItem;
			if (captionItem2 != null)
			{
				captionItem2.SetUiActive(true);
			}
			PopupCaptionItem captionItem3 = this.CaptionItem;
			if (captionItem3 == null)
			{
				return;
			}
			captionItem3.SetCurrencyItemList(itemIdList).Forget();
			return;
		}
	}

	// Token: 0x0600AFA0 RID: 44960 RVA: 0x002ED004 File Offset: 0x002EB204
	protected void OnClickMask()
	{
		base.GetItem(2).SetUIActive(false);
		UUIButtonComponent button = base.GetButton(1);
		if (button == null)
		{
			return;
		}
		button.RootUIComp.Get().SetUIActive(false);
	}

	// Token: 0x0600AFA1 RID: 44961 RVA: 0x002ED03D File Offset: 0x002EB23D
	protected void OnClickClose()
	{
		if (this.OnClickCloseCallBack != null)
		{
			this.OnClickCloseCallBack();
			return;
		}
		this.SetActive(false);
	}

	// Token: 0x0600AFA2 RID: 44962 RVA: 0x002ED05C File Offset: 0x002EB25C
	[NullableContext(1)]
	private void OnItemToggleStateChanged(MediumItemGridExtendCallback callbackData)
	{
		PhantomItemData itemData = callbackData.Data as PhantomItemData;
		this.RefreshSelectionByItemData(itemData);
	}

	// Token: 0x0600AFA3 RID: 44963 RVA: 0x002ED07C File Offset: 0x002EB27C
	[NullableContext(1)]
	public void RefreshSelectionByItemData(PhantomItemData itemData)
	{
		PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(itemData.GetUniqueId());
		if (phantomBattleData == null || !phantomBattleData.GetVisionIfCanRefine(this.CurrentRefineType))
		{
			return;
		}
		if (this.CurrentRefineType == EVisionRefineRefineType.Main)
		{
			if (this.CurrentSelectedList == null)
			{
				return;
			}
			int num = 0;
			foreach (PhantomItemData phantomItemData in this.CurrentSelectedList)
			{
				if (itemData.GetUniqueId() == phantomItemData.GetUniqueId())
				{
					this.CurrentSelectedList.RemoveAt(num);
					this.RefreshGridByData(itemData);
					this.ShowTipsComponent(itemData);
					List<PhantomItemData> obj;
					if (this.OnChangeMultiCallback != null && this.CurrentCostType != null && this.MultiSelectedData.TryGetValue(this.CurrentCostType.Value, out obj))
					{
						this.OnChangeMultiCallback(obj);
					}
					return;
				}
				num++;
			}
			this.RefreshChangeMultiSelect(itemData);
			this.ShowTipsComponent(itemData);
			List<PhantomItemData> obj2;
			if (this.OnChangeMultiCallback != null && this.CurrentCostType != null && this.MultiSelectedData.TryGetValue(this.CurrentCostType.Value, out obj2))
			{
				this.OnChangeMultiCallback(obj2);
				return;
			}
		}
		else
		{
			if (this.SelectedData == itemData)
			{
				this.ClearSelection();
				return;
			}
			this.RefreshChangeSelect(itemData);
			this.ShowTipsComponent(itemData);
			if (this.OnChangeCallBack != null)
			{
				this.OnChangeCallBack(this.SelectedData);
			}
		}
	}

	// Token: 0x0600AFA4 RID: 44964 RVA: 0x002ED204 File Offset: 0x002EB404
	public void OnItemFuncValueChange(int uniqueId)
	{
		if (ModelBase<InventoryModel>.Instance.GetAttributeItemData(uniqueId) == null)
		{
			return;
		}
		for (int i = 0; i < this.AllData.Count; i++)
		{
			if (this.AllData[i].GetUniqueId() == uniqueId)
			{
				this.ItemScroll.RefreshGridProxy(i);
				return;
			}
		}
	}

	// Token: 0x0600AFA5 RID: 44965 RVA: 0x002ED258 File Offset: 0x002EB458
	[NullableContext(1)]
	private bool OnItemCanExecuteChange(object data, bool isForceSelected, EToggleState state)
	{
		PhantomItemData phantomItemData = data as PhantomItemData;
		int uniqueId = phantomItemData.GetUniqueId();
		PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(uniqueId);
		if (phantomBattleData == null)
		{
			return false;
		}
		if (!phantomBattleData.GetVisionIfCanRefine(this.CurrentRefineType))
		{
			EVisionRefineRefineType currentRefineType = this.CurrentRefineType;
			if (currentRefineType != EVisionRefineRefineType.Main)
			{
				if (currentRefineType == EVisionRefineRefineType.Sub)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Text_VisionRefineSub_InvalidTips_Text", Array.Empty<object>());
				}
			}
			else
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("VisionRefineChooseCheck", Array.Empty<object>());
			}
			this.ShowTipsComponent(phantomItemData);
			return false;
		}
		if (this.CurrentRefineType == EVisionRefineRefineType.Main && this.CurrentSelectedList != null)
		{
			bool flag = false;
			using (List<PhantomItemData>.Enumerator enumerator = this.CurrentSelectedList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.GetUniqueId() == uniqueId)
					{
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				return false;
			}
			if (this.CurrentSelectedList.Count >= 10)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Text_VisionRefineChooseListFull_Text", Array.Empty<object>());
				this.ShowTipsComponent(phantomItemData);
				return false;
			}
		}
		return true;
	}

	// Token: 0x0600AFA6 RID: 44966 RVA: 0x002ED368 File Offset: 0x002EB568
	[NullableContext(1)]
	private void OnItemReduceButtonClicked(MediumItemGridButtonCallback args)
	{
		PhantomItemData itemData = args.Data as PhantomItemData;
		this.RefreshSelectionByItemData(itemData);
		this.ShowTipsComponent(null);
	}

	// Token: 0x0600AFA7 RID: 44967 RVA: 0x002ED390 File Offset: 0x002EB590
	[NullableContext(1)]
	private void OnFilterSortRefresh(List<PhantomItemData> list, bool _1, EFilterSortType _2)
	{
		List<PhantomItemData> list2 = new List<PhantomItemData>();
		foreach (PhantomItemData phantomItemData in list)
		{
			if (phantomItemData != null)
			{
				PhantomItemData item = phantomItemData;
				list2.Add(item);
			}
		}
		this.AllData = list2;
		this.ItemScroll.RefreshByData(this.AllData, false, null, false);
		base.GetItem(6).SetUIActive(list.Count <= 0);
		this.ShowTipsComponent(null);
	}

	// Token: 0x0600AFA8 RID: 44968 RVA: 0x002ED424 File Offset: 0x002EB624
	private bool CheckItemSelect(PhantomItemData data)
	{
		if (this.CurrentRefineType == EVisionRefineRefineType.Main)
		{
			if (this.CurrentSelectedList == null)
			{
				return false;
			}
			foreach (PhantomItemData phantomItemData in this.CurrentSelectedList)
			{
				int uniqueId = phantomItemData.GetUniqueId();
				int? num = (data != null) ? new int?(data.GetUniqueId()) : null;
				if (uniqueId == num.GetValueOrDefault() & num != null)
				{
					return true;
				}
			}
			return false;
		}
		else
		{
			if (data == null || this.SelectedData == null)
			{
				return false;
			}
			int uniqueId2 = data.GetUniqueId();
			int uniqueId3 = this.SelectedData.GetUniqueId();
			return uniqueId2 == uniqueId3;
		}
	}

	// Token: 0x0600AFA9 RID: 44969 RVA: 0x002ED4E0 File Offset: 0x002EB6E0
	private bool CheckItemWarning(PhantomItemData data)
	{
		int? num = (data != null) ? new int?(data.GetUniqueId()) : null;
		if (num == null)
		{
			return false;
		}
		if (this.OnGetMainPropItemIdCallback == null)
		{
			return false;
		}
		PhantomDataBase phantomDataBase = ModelBase<PhantomBattleModel>.Instance.GetPhantomDataBase(num.Value);
		if (phantomDataBase == null)
		{
			return false;
		}
		int? num2 = this.OnGetMainPropItemIdCallback();
		return num2 != null && num2.Value == phantomDataBase.GetPhantomFirstMainProp().PhantomPropId;
	}

	// Token: 0x0600AFAA RID: 44970 RVA: 0x002ED560 File Offset: 0x002EB760
	private void RefreshChangeSelect(PhantomItemData newData)
	{
		PhantomItemData selectedData = this.SelectedData;
		this.SelectedDataInternal = null;
		this.RefreshGridByData(selectedData);
		this.SelectedDataInternal = newData;
		this.RefreshGridByData(newData);
	}

	// Token: 0x0600AFAB RID: 44971 RVA: 0x002ED590 File Offset: 0x002EB790
	[NullableContext(1)]
	private void RefreshChangeMultiSelect(PhantomItemData newData)
	{
		if (this.CurrentSelectedList == null || this.CurrentSelectedList.Count >= 10)
		{
			return;
		}
		this.CurrentSelectedList.Add(newData);
		this.RefreshGridByData(newData);
	}

	// Token: 0x0600AFAC RID: 44972 RVA: 0x002ED5C0 File Offset: 0x002EB7C0
	private void OnEventClickItem(int configId, int incId)
	{
		PhantomItemData phantomItemData = ModelBase<InventoryModel>.Instance.GetPhantomItemData(incId);
		this.ShowTipsComponent(phantomItemData);
	}

	// Token: 0x0600AFAD RID: 44973 RVA: 0x002ED5E0 File Offset: 0x002EB7E0
	private void RefreshGridByData(PhantomItemData itemData)
	{
		if (itemData == null)
		{
			return;
		}
		int gridIndex = -1;
		for (int i = 0; i < this.AllData.Count; i++)
		{
			if (this.AllData[i].GetUniqueId() == itemData.GetUniqueId())
			{
				gridIndex = i;
				break;
			}
		}
		if (!this.ItemScroll.IsGridDisplaying(gridIndex))
		{
			return;
		}
		VisionRefineMediumItemGrid visionRefineMediumItemGrid = this.ItemScroll.UnsafeGetGridProxy(gridIndex, false);
		if (visionRefineMediumItemGrid == null)
		{
			return;
		}
		visionRefineMediumItemGrid.RefreshByView(itemData);
	}

	// Token: 0x0600AFAE RID: 44974 RVA: 0x002ED650 File Offset: 0x002EB850
	[NullableContext(1)]
	private List<VisionRefineTabCostItemData> BuildCostTabData()
	{
		List<VisionRefineTabCostItemData> list = new List<VisionRefineTabCostItemData>();
		if (CalabashDefine.visionRefineCostMap == null)
		{
			return list;
		}
		foreach (KeyValuePair<EVisionRefineCostType, string> keyValuePair in CalabashDefine.visionRefineCostMap)
		{
			EVisionRefineCostType e = keyValuePair.Key;
			string value = keyValuePair.Value;
			VisionRefineTabCostItemData visionRefineTabCostItemData = new VisionRefineTabCostItemData();
			VisionRefineTabCostItemData visionRefineTabCostItemData2 = visionRefineTabCostItemData;
			EVisionRefineCostType e2 = e;
			EVisionRefineCostType? currentCostType = this.CurrentCostType;
			visionRefineTabCostItemData2.IsChosen = (e2 == currentCostType.GetValueOrDefault() & currentCostType != null);
			visionRefineTabCostItemData.CostType = e;
			visionRefineTabCostItemData.TabTextId = value;
			visionRefineTabCostItemData.OnClick = delegate()
			{
				this.CurrentCostTypeInternal = e;
				this.OnClickRefreshCostTab(e);
				this.RefreshList(this.MetaAllDataCache);
				if (this.OnCostTabChangeCallback != null)
				{
					this.OnCostTabChangeCallback();
				}
			};
			list.Add(visionRefineTabCostItemData);
		}
		return list;
	}

	// Token: 0x0600AFAF RID: 44975 RVA: 0x002ED734 File Offset: 0x002EB934
	private void OnClickRefreshCostTab(EVisionRefineCostType current)
	{
		if (this.CostTabLayout == null)
		{
			return;
		}
		foreach (VisionRefineTabCostItem visionRefineTabCostItem in this.CostTabLayout.GetLayoutItemList())
		{
			if (visionRefineTabCostItem.CheckChosen(current))
			{
				visionRefineTabCostItem.OnSelected(false);
			}
			else
			{
				visionRefineTabCostItem.OnDeselected(false);
			}
		}
	}

	// Token: 0x0600AFB0 RID: 44976 RVA: 0x002ED7A8 File Offset: 0x002EB9A8
	protected override void OnAfterShow()
	{
		this.OnAddEventListener();
	}

	// Token: 0x0600AFB1 RID: 44977 RVA: 0x002ED7B0 File Offset: 0x002EB9B0
	protected override void OnBeforeHide()
	{
		this.OnRemoveEventListener();
	}

	// Token: 0x0600AFB2 RID: 44978 RVA: 0x002ED7B8 File Offset: 0x002EB9B8
	protected void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnSelectItemAdd, new Action<int, int>(this.OnEventClickItem));
	}

	// Token: 0x0600AFB3 RID: 44979 RVA: 0x002ED7D6 File Offset: 0x002EB9D6
	protected void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSelectItemAdd, new Action<int, int>(this.OnEventClickItem));
	}

	// Token: 0x0600AFB4 RID: 44980 RVA: 0x002ED7F4 File Offset: 0x002EB9F4
	[NullableContext(1)]
	public UUIItem GetFilterToggleItem()
	{
		return this.FilterEntrance.GetFilterToggleItem();
	}

	// Token: 0x0400533C RID: 21308
	[Nullable(1)]
	private List<PhantomItemData> AllData = new List<PhantomItemData>();

	// Token: 0x0400533D RID: 21309
	[Nullable(1)]
	private List<PhantomItemData> MetaAllDataCache = new List<PhantomItemData>();

	// Token: 0x0400533E RID: 21310
	private PhantomItemData SelectedDataInternal;

	// Token: 0x0400533F RID: 21311
	public UiBehaviorLevelSequence UiViewSequence;

	// Token: 0x04005340 RID: 21312
	private ItemTipsComponentContentComponent TipsComponent;

	// Token: 0x04005341 RID: 21313
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<VisionRefineMediumItemGrid, PhantomItemData> ItemScroll;

	// Token: 0x04005342 RID: 21314
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private FilterEntrance<PhantomItemData> FilterEntrance;

	// Token: 0x04005343 RID: 21315
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private SortEntrance<PhantomItemData> SortEntrance;

	// Token: 0x04005344 RID: 21316
	[Nullable(1)]
	private readonly Dictionary<EVisionRefineCostType, List<PhantomItemData>> MultiSelectedData = new Dictionary<EVisionRefineCostType, List<PhantomItemData>>
	{
		{
			EVisionRefineCostType.Cost1,
			new List<PhantomItemData>()
		},
		{
			EVisionRefineCostType.Cost3,
			new List<PhantomItemData>()
		},
		{
			EVisionRefineCostType.Cost4,
			new List<PhantomItemData>()
		}
	};

	// Token: 0x04005345 RID: 21317
	private EVisionRefineRefineType CurrentRefineTypeInternal;

	// Token: 0x04005346 RID: 21318
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<VisionRefineTabCostItem, VisionRefineTabCostItemData> CostTabLayout;

	// Token: 0x04005347 RID: 21319
	private EVisionRefineCostType CurrentCostTypeInternal;

	// Token: 0x04005348 RID: 21320
	private PopupCaptionItem CaptionItem;

	// Token: 0x04005349 RID: 21321
	public Action OnClickCloseCallBack;

	// Token: 0x0400534A RID: 21322
	public Action<PhantomItemData> OnChangeCallBack;

	// Token: 0x0400534B RID: 21323
	[Nullable(new byte[]
	{
		2,
		2,
		1
	})]
	public Action<List<PhantomItemData>> OnChangeMultiCallback;

	// Token: 0x0400534C RID: 21324
	public Action OnCostTabChangeCallback;

	// Token: 0x0400534D RID: 21325
	public Func<int?> OnGetMainPropItemIdCallback;

	// Token: 0x02007B9B RID: 31643
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402A3F6 RID: 173046
		RootTips,
		// Token: 0x0402A3F7 RID: 173047
		BtnMask,
		// Token: 0x0402A3F8 RID: 173048
		ItemTips,
		// Token: 0x0402A3F9 RID: 173049
		BtnClose,
		// Token: 0x0402A3FA RID: 173050
		ItemScrollView,
		// Token: 0x0402A3FB RID: 173051
		ItemBase,
		// Token: 0x0402A3FC RID: 173052
		EmptyItem,
		// Token: 0x0402A3FD RID: 173053
		FilterItem,
		// Token: 0x0402A3FE RID: 173054
		SortItem,
		// Token: 0x0402A3FF RID: 173055
		CostTabRootItem,
		// Token: 0x0402A400 RID: 173056
		CostTabLayout,
		// Token: 0x0402A401 RID: 173057
		CostTabLayoutItem,
		// Token: 0x0402A402 RID: 173058
		CurrencyCaptionItem
	}
}
