using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Dango;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001AF5 RID: 6901
[NullableContext(1)]
[Nullable(0)]
public class DangoAbyssPluginRecoveryView : UiViewBase
{
	// Token: 0x0600C6BC RID: 50876 RVA: 0x003488CB File Offset: 0x00346ACB
	public DangoAbyssPluginRecoveryView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600C6BD RID: 50877 RVA: 0x003488F8 File Offset: 0x00346AF8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(13, typeof(UUIExtendToggle))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickClose)),
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickConfirm)),
			new ValueTuple<int, Delegate>(12, new Action(this.OnClickMask)),
			new ValueTuple<int, Delegate>(13, new Action<EToggleState>(this.OnClickAll))
		};
	}

	// Token: 0x0600C6BE RID: 50878 RVA: 0x00348AB6 File Offset: 0x00346CB6
	public override bool GetLoopAudioEventSwitch()
	{
		return !ModelBase<DangoAbyssModel>.Instance.CheckIfInSmallWorldInstance();
	}

	// Token: 0x0600C6BF RID: 50879 RVA: 0x00348AC8 File Offset: 0x00346CC8
	protected override UniTask OnBeforeStartAsync()
	{
		DangoAbyssPluginRecoveryView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DangoAbyssPluginRecoveryView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C6C0 RID: 50880 RVA: 0x00348B0B File Offset: 0x00346D0B
	protected override void OnBeforeShow()
	{
		this.RefreshList();
		this.RefreshAwardText();
		base.GetItem(0).SetUIActive(true);
	}

	// Token: 0x0600C6C1 RID: 50881 RVA: 0x00348B28 File Offset: 0x00346D28
	private void RefreshList()
	{
		global::AbyssPluginItemInfo[] allPluginItemList = ModelBase<DangoAbyssModel>.Instance.GetAllPluginItemList();
		this.DataList = allPluginItemList.ToList<global::AbyssPluginItemInfo>();
		Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(6), "Text_DangoPluginCount_Text", new <>z__ReadOnlySingleElementList<object>(allPluginItemList.Length));
		base.GetItem(9).SetUIActive(allPluginItemList.Length == 0);
		this.ItemScroll.UpdateComponent(allPluginItemList.ToList<global::AbyssPluginItemInfo>(), this.Selection, null);
		int dangoId = this.ViewModel.GetDangoId();
		this.FilterSortEntrance.UpdateData(EFilterSortGroupId.DangoAbyssPluginRecovery, this.DataList, new object[]
		{
			dangoId
		});
	}

	// Token: 0x0600C6C2 RID: 50882 RVA: 0x00348BC8 File Offset: 0x00346DC8
	private void RefreshAwardText()
	{
		int pluginItemPackageCapacity = ModelBase<DangoAbyssModel>.Instance.GetPluginItemPackageCapacity();
		Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(2), "Text_RecoverySelect_Text", new <>z__ReadOnlyArray<object>(new object[]
		{
			this.Selection.Count,
			pluginItemPackageCapacity
		}));
		Dictionary<int, int> recoverySelectionCountMap = ModelBase<DangoAbyssModel>.Instance.GetRecoverySelectionCountMap(this.Selection);
		Dictionary<int, int> recoveryTimesCountMap = ModelBase<DangoAbyssModel>.Instance.GetRecoveryTimesCountMap(recoverySelectionCountMap);
		Dictionary<int, int> recoveryRewardItemMap = ModelBase<DangoAbyssModel>.Instance.GetRecoveryRewardItemMap(recoveryTimesCountMap);
		List<DangoAbyssDefine.IRecoveryRewardData> list = new List<DangoAbyssDefine.IRecoveryRewardData>();
		foreach (KeyValuePair<int, int> keyValuePair in recoveryRewardItemMap)
		{
			DangoAbyssDefine.IRecoveryRewardData item = new DangoAbyssDefine.IRecoveryRewardData
			{
				ItemId = keyValuePair.Key,
				Count = keyValuePair.Value
			};
			list.Add(item);
		}
		int num;
		recoveryRewardItemMap.TryGetValue(80200001, out num);
		this.AwardScroll.RefreshByData(list, null, false);
		Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(3), "Text_RecoveryTimes_Text", new <>z__ReadOnlySingleElementList<object>(num));
	}

	// Token: 0x0600C6C3 RID: 50883 RVA: 0x00348CF4 File Offset: 0x00346EF4
	public void ShowTipsComponent(ItemTipsData data)
	{
		this.TipsComponent.Refresh(data);
		base.GetItem(11).SetUIActive(true);
		base.GetButton(12).RootUIComp.Get().SetUIActive(true);
	}

	// Token: 0x0600C6C4 RID: 50884 RVA: 0x00348D38 File Offset: 0x00346F38
	private void SwitchAllSelection(bool isClear)
	{
		if (isClear)
		{
			this.Selection = new List<ISelectedData>();
		}
		else
		{
			foreach (global::AbyssPluginItemInfo abyssPluginItemInfo in this.DataList)
			{
				int uniqueId = abyssPluginItemInfo.GetUniqueId();
				if (abyssPluginItemInfo.GetCanRecovery())
				{
					ISelectedData selectedData = null;
					foreach (ISelectedData selectedData2 in this.Selection)
					{
						if (selectedData2.IncId == uniqueId)
						{
							selectedData = selectedData2;
							break;
						}
					}
					if (selectedData == null)
					{
						ISelectedData selectablePropData = SelectablePropDataUtil.GetSelectablePropData(abyssPluginItemInfo);
						selectablePropData.SelectedCount = 1;
						this.Selection.Add(selectablePropData);
					}
				}
			}
		}
		this.ItemScroll.UpdateComponent(this.DataList.ToList<global::AbyssPluginItemInfo>(), this.Selection, null);
		this.ItemScroll.UpdateDataList(this.DataList.ToList<global::AbyssPluginItemInfo>());
		this.RefreshAwardText();
	}

	// Token: 0x0600C6C5 RID: 50885 RVA: 0x00348E50 File Offset: 0x00347050
	private void OnChangeSelection(List<ISelectedData> dataList, SelectableExpData _)
	{
		this.Selection = dataList;
		this.RefreshAwardText();
	}

	// Token: 0x0600C6C6 RID: 50886 RVA: 0x00348E5F File Offset: 0x0034705F
	private RecoveryRewardItem InitAwardItem()
	{
		return new RecoveryRewardItem();
	}

	// Token: 0x0600C6C7 RID: 50887 RVA: 0x00348E66 File Offset: 0x00347066
	private void OnClickClose()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600C6C8 RID: 50888 RVA: 0x00348E70 File Offset: 0x00347070
	private void OnClickConfirm()
	{
		Singleton<Log>.Instance.Info(ELogModule.Activity, ELogAuthor.WDX, "OnClickConfirm", default(ReadOnlySpan<ValueTuple<string, object>>));
		base.GetItem(11).SetUIActive(false);
		base.GetButton(12).RootUIComp.Get().SetUIActive(false);
		Dictionary<int, int> recoverySelectionCountMap = ModelBase<DangoAbyssModel>.Instance.GetRecoverySelectionCountMap(this.Selection);
		if (ModelBase<DangoAbyssModel>.Instance.GetRecoveryTimesCountAll(recoverySelectionCountMap) <= 0)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Text_NotEnoughItem_Text", Array.Empty<object>());
			return;
		}
		List<int> list = new List<int>();
		foreach (ISelectedData selectedData in this.Selection)
		{
			list.Add(selectedData.IncId);
		}
		ControllerBase<DangoAbyssActivityController>.Instance.RequestPluginRecovery(list);
	}

	// Token: 0x0600C6C9 RID: 50889 RVA: 0x00348F58 File Offset: 0x00347158
	protected void OnClickMask()
	{
		base.GetItem(11).SetUIActive(false);
		base.GetButton(12).RootUIComp.Get().SetUIActive(false);
	}

	// Token: 0x0600C6CA RID: 50890 RVA: 0x00348F8E File Offset: 0x0034718E
	protected void OnClickAll(EToggleState state)
	{
		this.SwitchAllSelection(state == EToggleState.ETT_UnChecked);
	}

	// Token: 0x0600C6CB RID: 50891 RVA: 0x00348F9C File Offset: 0x0034719C
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnSelectItemAdd, new Action<int, int>(this.OnEventClickItem));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnItemFuncValueChange, new Action<int>(this.OnEventItemFuncValueChange));
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<AddCountItemInfo>>(EEventName.OnAbyssPluginRecovery, new Action<IReadOnlyList<AddCountItemInfo>>(this.OnEventRecovery));
	}

	// Token: 0x0600C6CC RID: 50892 RVA: 0x00349000 File Offset: 0x00347200
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.OnSelectItemAdd, new Action<int, int>(this.OnEventClickItem));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnItemFuncValueChange, new Action<int>(this.OnEventItemFuncValueChange));
		Singleton<EventSystem>.Instance.Remove<IReadOnlyList<AddCountItemInfo>>(EEventName.OnAbyssPluginRecovery, new Action<IReadOnlyList<AddCountItemInfo>>(this.OnEventRecovery));
	}

	// Token: 0x0600C6CD RID: 50893 RVA: 0x00349064 File Offset: 0x00347264
	private void OnEventClickItem(int itemId, int uniqueId)
	{
		ItemTipsData tipsDataByPram = ItemTipsComponentUtilTool.GetTipsDataByPram(ModelBase<DangoAbyssModel>.Instance.GetPluginItemTipsData(itemId, uniqueId, null, null));
		this.ShowTipsComponent(tipsDataByPram);
	}

	// Token: 0x0600C6CE RID: 50894 RVA: 0x0034909C File Offset: 0x0034729C
	private void OnEventItemFuncValueChange(int uniqueId)
	{
		int num = -1;
		for (int i = 0; i < this.Selection.Count; i++)
		{
			if (this.Selection[i].IncId == uniqueId)
			{
				num = i;
				break;
			}
		}
		if (num >= 0)
		{
			this.Selection.RemoveAt(num);
		}
		this.ItemScroll.RemoveAndRefresh(uniqueId);
		this.RefreshAwardText();
	}

	// Token: 0x0600C6CF RID: 50895 RVA: 0x003490FC File Offset: 0x003472FC
	private void OnEventRecovery(IReadOnlyList<AddCountItemInfo> infoList)
	{
		if (infoList == null || infoList.Count <= 0)
		{
			this.Selection = new List<ISelectedData>();
			this.RefreshList();
			this.RefreshAwardText();
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.DangoAbyssPluginRecoveryResultView, infoList.ToArray<AddCountItemInfo>(), delegate(bool _1, int _2)
		{
			this.Selection = new List<ISelectedData>();
			this.RefreshList();
			this.RefreshAwardText();
		});
	}

	// Token: 0x0600C6D0 RID: 50896 RVA: 0x00349150 File Offset: 0x00347350
	private void OnFilterSortRefresh(List<global::AbyssPluginItemInfo> list, bool _1, EFilterSortType _2)
	{
		this.DataList = list;
		this.ItemScroll.UpdateDataList(this.DataList);
		base.GetItem(11).SetUIActive(false);
		base.GetButton(12).RootUIComp.Get().SetUIActive(false);
	}

	// Token: 0x04005F32 RID: 24370
	private List<ISelectedData> Selection = new List<ISelectedData>();

	// Token: 0x04005F33 RID: 24371
	private List<global::AbyssPluginItemInfo> DataList = new List<global::AbyssPluginItemInfo>();

	// Token: 0x04005F34 RID: 24372
	[Nullable(2)]
	private ItemTipsComponentContentComponent TipsComponent;

	// Token: 0x04005F35 RID: 24373
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private FilterSortEntrance<global::AbyssPluginItemInfo> FilterSortEntrance;

	// Token: 0x04005F36 RID: 24374
	private readonly DangoAbyssSelectableComponent<global::AbyssPluginItemInfo> ItemScroll = new DangoAbyssSelectableComponent<global::AbyssPluginItemInfo>(false);

	// Token: 0x04005F37 RID: 24375
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<RecoveryRewardItem, DangoAbyssDefine.IRecoveryRewardData> AwardScroll;

	// Token: 0x04005F38 RID: 24376
	[Nullable(2)]
	private PluginEquipViewModel ViewModel;

	// Token: 0x02007DC9 RID: 32201
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402AD80 RID: 175488
		PanelReward,
		// Token: 0x0402AD81 RID: 175489
		LayoutReward,
		// Token: 0x0402AD82 RID: 175490
		TextSelection,
		// Token: 0x0402AD83 RID: 175491
		TextCount,
		// Token: 0x0402AD84 RID: 175492
		BtnConfirm,
		// Token: 0x0402AD85 RID: 175493
		BtnClose,
		// Token: 0x0402AD86 RID: 175494
		TextPluginCount,
		// Token: 0x0402AD87 RID: 175495
		ItemFilterSort,
		// Token: 0x0402AD88 RID: 175496
		LoopScrollPlugin,
		// Token: 0x0402AD89 RID: 175497
		ItemEmpty,
		// Token: 0x0402AD8A RID: 175498
		ItemPlugin,
		// Token: 0x0402AD8B RID: 175499
		ItemTips,
		// Token: 0x0402AD8C RID: 175500
		BtnMask,
		// Token: 0x0402AD8D RID: 175501
		ToggleAll
	}
}
