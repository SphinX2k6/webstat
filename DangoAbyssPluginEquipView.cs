using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Dango;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001AEF RID: 6895
[NullableContext(1)]
[Nullable(0)]
public class DangoAbyssPluginEquipView : UiViewBase
{
	// Token: 0x0600C67E RID: 50814 RVA: 0x0034722E File Offset: 0x0034542E
	public DangoAbyssPluginEquipView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600C67F RID: 50815 RVA: 0x00347270 File Offset: 0x00345470
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIDynScrollViewComponent)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(14, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickClose)),
			new ValueTuple<int, Delegate>(2, new Action(this.OnClickBtnRecovery))
		};
	}

	// Token: 0x0600C680 RID: 50816 RVA: 0x00347413 File Offset: 0x00345613
	public override bool GetLoopAudioEventSwitch()
	{
		return !ModelBase<DangoAbyssModel>.Instance.CheckIfInSmallWorldInstance();
	}

	// Token: 0x0600C681 RID: 50817 RVA: 0x00347424 File Offset: 0x00345624
	protected override UniTask OnBeforeStartAsync()
	{
		DangoAbyssPluginEquipView.<OnBeforeStartAsync>d__16 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DangoAbyssPluginEquipView.<OnBeforeStartAsync>d__16>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C682 RID: 50818 RVA: 0x00347467 File Offset: 0x00345667
	private DangoAbyssItemMediumItemGrid CreateGridItem()
	{
		DangoAbyssItemMediumItemGrid dangoAbyssItemMediumItemGrid = new DangoAbyssItemMediumItemGrid();
		dangoAbyssItemMediumItemGrid.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.OnClickItem));
		dangoAbyssItemMediumItemGrid.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(this.OnCanExecuteChange));
		return dangoAbyssItemMediumItemGrid;
	}

	// Token: 0x0600C683 RID: 50819 RVA: 0x00347494 File Offset: 0x00345694
	protected override void OnBeforeShow()
	{
		this.ViewModel.SetPluginItem(null, true);
		this.ViewModel.Bind(new TCallback<EPluginEquipViewData>(this.OnDataUpdate));
		this.AttributeScrollData = new List<DangoAbyssDefine.EquipViewAttributeData>();
		this.LastSlotIndexForList = this.ViewModel.GetSlotIndex();
		int dangoId = this.ViewModel.GetDangoId();
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Activity;
		ELogAuthor author = ELogAuthor.WDX;
		string message = "打开装备页";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("dangoId", dangoId);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		bool recoveryAvailable = ModelBase<DangoAbyssModel>.Instance.GetRecoveryAvailable();
		base.GetButton(2).RootUIComp.Get().SetUIActive(recoveryAvailable);
		base.SetButtonUiActive(13, false);
		this.RefreshAll();
		AbyssDangoRoleData dangoAbyssRoleData = ModelBase<DangoAbyssModel>.Instance.GetDangoAbyssRoleData(dangoId);
		this.CurEquipListForGuide = (((dangoAbyssRoleData != null) ? dangoAbyssRoleData.GetEquipItems().ToList<int>() : null) ?? new List<int>());
	}

	// Token: 0x0600C684 RID: 50820 RVA: 0x0034757D File Offset: 0x0034577D
	private void OnDataUpdate(EPluginEquipViewData key)
	{
		switch (key)
		{
		case EPluginEquipViewData.DangoId:
			this.OnDangoIdUpdate();
			return;
		case EPluginEquipViewData.SlotIndex:
			this.OnSlotIndexUpdate();
			return;
		case EPluginEquipViewData.PluginItem:
			this.OnPluginItemUpdate();
			return;
		default:
			return;
		}
	}

	// Token: 0x0600C685 RID: 50821 RVA: 0x003475A6 File Offset: 0x003457A6
	protected override void OnBeforeDestroy()
	{
		this.ViewModel.SetSlotIndex(-1, true);
		this.ViewModel.SetPluginItem(null, true);
		this.ViewModel.UnBind(new TCallback<EPluginEquipViewData>(this.OnDataUpdate));
	}

	// Token: 0x0600C686 RID: 50822 RVA: 0x003475D9 File Offset: 0x003457D9
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnAbyssRoleInfoUpdate, new Action(this.OnEventRoleUpdate));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnItemFuncValueChange, new Action<int>(this.OnEventItemFuncValueChange));
	}

	// Token: 0x0600C687 RID: 50823 RVA: 0x00347613 File Offset: 0x00345813
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAbyssRoleInfoUpdate, new Action(this.OnEventRoleUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnItemFuncValueChange, new Action<int>(this.OnEventItemFuncValueChange));
	}

	// Token: 0x0600C688 RID: 50824 RVA: 0x0034764D File Offset: 0x0034584D
	private void RefreshAll()
	{
		this.RefreshPlugin();
		this.RefreshList();
		this.RefreshAttribute();
		this.RefreshTipsComponent();
	}

	// Token: 0x0600C689 RID: 50825 RVA: 0x00347667 File Offset: 0x00345867
	private void RefreshPlugin()
	{
		this.PluginPanel.Refresh();
	}

	// Token: 0x0600C68A RID: 50826 RVA: 0x00347674 File Offset: 0x00345874
	private void RefreshList()
	{
		int slotIndex = this.ViewModel.GetSlotIndex();
		AbyssPluginItemInfo[] pluginItemListBySlotIndex = ModelBase<DangoAbyssModel>.Instance.GetPluginItemListBySlotIndex(slotIndex);
		int dangoId = this.ViewModel.GetDangoId();
		this.FilterSortEntrance.UpdateData(EFilterSortGroupId.DangoAbyssPluginEquip, pluginItemListBySlotIndex.ToList<AbyssPluginItemInfo>(), new object[]
		{
			dangoId
		});
	}

	// Token: 0x0600C68B RID: 50827 RVA: 0x003476C8 File Offset: 0x003458C8
	private void RefreshAttribute()
	{
		int dangoId = this.ViewModel.GetDangoId();
		if (ModelBase<DangoAbyssModel>.Instance.GetDangoAbyssRoleData(dangoId) == null)
		{
			base.GetItem(12).SetUIActive(true);
			base.GetUIDynScrollViewComponent(11).RootUIComp.Get().SetUIActive(false);
			return;
		}
		base.GetItem(12).SetUIActive(false);
		base.GetUIDynScrollViewComponent(11).RootUIComp.Get().SetUIActive(true);
		List<DangoAbyssDefine.EquipViewAttributeData> list = ModelBase<DangoAbyssModel>.Instance.GetEquipViewAttributeDataById(dangoId);
		list = ModelBase<DangoAbyssModel>.Instance.SetEquipViewAttributeType(this.AttributeScrollData, list);
		this.AttributeScrollData = list;
		this.AttributeScroll.RefreshByData(list.ToArray(), false, false);
	}

	// Token: 0x0600C68C RID: 50828 RVA: 0x0034777C File Offset: 0x0034597C
	private void RefreshTipsComponent()
	{
		AbyssPluginItemInfo pluginItem = this.ViewModel.GetPluginItem();
		if (pluginItem == null)
		{
			this.TipsComponent.SetUiActive(false);
			return;
		}
		int configId = pluginItem.GetConfigId();
		int slotIndex = this.ViewModel.GetSlotIndex();
		int dangoId = this.ViewModel.GetDangoId();
		ItemTipsData tipsDataByPram = ItemTipsComponentUtilTool.GetTipsDataByPram(ModelBase<DangoAbyssModel>.Instance.GetPluginItemTipsData(configId, pluginItem.GetUniqueId(), new int?(slotIndex), new int?(dangoId)));
		this.TipsComponent.Refresh(tipsDataByPram);
		this.TipsComponent.SetUiActive(true);
	}

	// Token: 0x0600C68D RID: 50829 RVA: 0x00347804 File Offset: 0x00345A04
	private void RefreshAfterFilterSort(bool keepPosition)
	{
		List<AbyssPluginItemInfo> dataAfterFilter = this.DataAfterFilter;
		base.GetItem(6).SetUIActive(dataAfterFilter.Count <= 0);
		int slotIndex = this.ViewModel.GetSlotIndex();
		int count = dataAfterFilter.Count;
		int num = ModelBase<DangoAbyssModel>.Instance.GetAllPluginItemList().Length;
		string slotTypeTextIdBySlotIndex = ModelBase<DangoAbyssModel>.Instance.GetSlotTypeTextIdBySlotIndex(slotIndex);
		Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(1), slotTypeTextIdBySlotIndex, new <>z__ReadOnlySingleElementList<object>(count));
		int pluginItemPackageCapacity = ModelBase<DangoAbyssModel>.Instance.GetPluginItemPackageCapacity();
		Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(14), "Text_DangoPluginItemCapacity_Text", new <>z__ReadOnlyArray<object>(new object[]
		{
			num,
			pluginItemPackageCapacity
		}));
		this.ItemScroll.RefreshByData(dataAfterFilter, keepPosition, null, false);
	}

	// Token: 0x0600C68E RID: 50830 RVA: 0x003478CC File Offset: 0x00345ACC
	private void SelectAfterFilter(bool keepPosition)
	{
		List<AbyssPluginItemInfo> dataAfterFilter = this.DataAfterFilter;
		if (this.GetSelectIndex() < 0)
		{
			AbyssPluginItemInfo pluginItem = (dataAfterFilter.Count > 0) ? dataAfterFilter[0] : null;
			this.ViewModel.SetPluginItem(pluginItem, false);
		}
		this.ItemScroll.DeselectCurrentGridProxy(false);
		int selectIndex = this.GetSelectIndex();
		this.ItemScroll.SelectGridProxy(selectIndex, false);
		if (!keepPosition)
		{
			this.ScrollToSelect();
		}
	}

	// Token: 0x0600C68F RID: 50831 RVA: 0x00347934 File Offset: 0x00345B34
	private void ScrollToSelect()
	{
		int selectIndex = this.GetSelectIndex();
		if (selectIndex >= 0)
		{
			this.ItemScroll.ScrollToGridIndex(selectIndex, true);
		}
	}

	// Token: 0x0600C690 RID: 50832 RVA: 0x00347959 File Offset: 0x00345B59
	private void OnFilterSortRefresh(List<AbyssPluginItemInfo> list, bool _1, EFilterSortType _2)
	{
		this.DataAfterFilter = list;
		this.RefreshTipsComponent();
		this.RefreshAfterFilterSort(false);
		this.SelectAfterFilter(false);
	}

	// Token: 0x0600C691 RID: 50833 RVA: 0x00347976 File Offset: 0x00345B76
	private void OnDangoIdUpdate()
	{
		this.RefreshAll();
	}

	// Token: 0x0600C692 RID: 50834 RVA: 0x00347980 File Offset: 0x00345B80
	private void OnSlotIndexUpdate()
	{
		int slotIndex = this.ViewModel.GetSlotIndex();
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Activity;
		ELogAuthor author = ELogAuthor.WDX;
		string message = "EquipView OnSlotIndexUpdate";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("index", slotIndex);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.RefreshPlugin();
		int dangoId = this.ViewModel.GetDangoId();
		int pluginItemIncIdBySlotIndex = ModelBase<DangoAbyssModel>.Instance.GetPluginItemIncIdBySlotIndex(dangoId, slotIndex);
		if (pluginItemIncIdBySlotIndex > 0)
		{
			AbyssPluginItemInfo pluginItemInfoById = ModelBase<DangoAbyssModel>.Instance.GetPluginItemInfoById(pluginItemIncIdBySlotIndex);
			AbyssPluginItemInfo pluginItem = this.ViewModel.GetPluginItem();
			if (pluginItem != null && pluginItem.GetUniqueId() != pluginItemInfoById.GetUniqueId())
			{
				this.ItemScroll.DeselectCurrentGridProxy(false);
			}
			this.ViewModel.SetPluginItem(pluginItemInfoById, true);
		}
		if (ModelBase<DangoAbyssModel>.Instance.GetIfSlotTypeChange(this.LastSlotIndexForList, slotIndex))
		{
			this.RefreshList();
		}
		else
		{
			this.RefreshAfterFilterSort(pluginItemIncIdBySlotIndex <= 0);
			this.SelectAfterFilter(pluginItemIncIdBySlotIndex <= 0);
		}
		this.LastSlotIndexForList = slotIndex;
		this.RefreshTipsComponent();
	}

	// Token: 0x0600C693 RID: 50835 RVA: 0x00347A78 File Offset: 0x00345C78
	private void OnPluginItemUpdate()
	{
		this.ItemScroll.DeselectCurrentGridProxy(false);
		int selectIndex = this.GetSelectIndex();
		this.ItemScroll.SelectGridProxy(selectIndex, false);
		this.ItemScroll.RefreshAllGridProxies();
		this.RefreshTipsComponent();
	}

	// Token: 0x0600C694 RID: 50836 RVA: 0x00347AB8 File Offset: 0x00345CB8
	private void OnEventRoleUpdate()
	{
		List<int> oldEquipList = this.CurEquipListForGuide;
		this.RefreshPlugin();
		this.ItemScroll.RefreshAllGridProxies();
		this.RefreshAttribute();
		this.RefreshTipsComponent();
		int dangoId = this.ViewModel.GetDangoId();
		AbyssDangoRoleData dangoAbyssRoleData = ModelBase<DangoAbyssModel>.Instance.GetDangoAbyssRoleData(dangoId);
		this.CurEquipListForGuide = (((dangoAbyssRoleData != null) ? dangoAbyssRoleData.GetEquipItems().ToList<int>() : null) ?? new List<int>());
		if (this.CurEquipListForGuide.Exists((int item) => !oldEquipList.Contains(item)) || oldEquipList.Exists((int item) => !this.CurEquipListForGuide.Contains(item)))
		{
			ControllerBase<GuideController>.Instance.TryFinishRunningGuides();
			this.GuideValidAttrIndexCache = this.GetValidAttrChangeIndex();
			this.GuideInvalidAttrIndexCache = this.GetInvalidAttrIndex();
			Singleton<EventSystem>.Instance.Emit<bool, bool>(EEventName.OnAbyssPluginEquipAttrRefresh, this.GuideInvalidAttrIndexCache > -1, this.GuideValidAttrIndexCache > -1);
		}
	}

	// Token: 0x0600C695 RID: 50837 RVA: 0x00347BAC File Offset: 0x00345DAC
	private void OnEventItemFuncValueChange(int uniqueId)
	{
		int indexById = this.GetIndexById(uniqueId, -1);
		if (indexById < 0)
		{
			return;
		}
		this.ItemScroll.RefreshGridProxy(indexById);
	}

	// Token: 0x0600C696 RID: 50838 RVA: 0x00347BD3 File Offset: 0x00345DD3
	private void OnClickClose()
	{
		this.ViewModel.UnBind(new TCallback<EPluginEquipViewData>(this.OnDataUpdate));
		base.CloseMe(null);
	}

	// Token: 0x0600C697 RID: 50839 RVA: 0x00347BF3 File Offset: 0x00345DF3
	private void OnClickBtnRecovery()
	{
		if (!ModelBase<DangoAbyssModel>.Instance.GetRecoveryAvailable())
		{
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.DangoAbyssPluginRecoveryView, this.ViewModel, null);
	}

	// Token: 0x0600C698 RID: 50840 RVA: 0x00347C18 File Offset: 0x00345E18
	private DangoAbyssAttributeParentItem OnCreateAttributeItem(DangoAbyssDefine.EquipViewAttributeData data, UUIItem uiItem, int index)
	{
		return new DangoAbyssAttributeParentItem();
	}

	// Token: 0x0600C699 RID: 50841 RVA: 0x00347C20 File Offset: 0x00345E20
	private int GetSelectIndex()
	{
		AbyssPluginItemInfo pluginItem = this.ViewModel.GetPluginItem();
		if (pluginItem == null)
		{
			return -1;
		}
		return this.GetIndexById(pluginItem.GetUniqueId(), pluginItem.GetConfigId());
	}

	// Token: 0x0600C69A RID: 50842 RVA: 0x00347C50 File Offset: 0x00345E50
	private int GetIndexById(int incId, int itemId)
	{
		if (incId > 0 || itemId > 0)
		{
			for (int i = 0; i < this.DataAfterFilter.Count; i++)
			{
				AbyssPluginItemInfo abyssPluginItemInfo = this.DataAfterFilter[i];
				if (incId > 0)
				{
					if (abyssPluginItemInfo.GetUniqueId() == incId)
					{
						return i;
					}
				}
				else if (abyssPluginItemInfo.GetConfigId() == itemId)
				{
					return i;
				}
			}
		}
		return -1;
	}

	// Token: 0x0600C69B RID: 50843 RVA: 0x00347CA4 File Offset: 0x00345EA4
	private void OnClickItem(MediumItemGridExtendCallback gridData)
	{
		AbyssPluginItemInfo abyssPluginItemInfo = (AbyssPluginItemInfo)gridData.Data;
		AbyssPluginItemInfo pluginItem = this.ViewModel.GetPluginItem();
		int uniqueId = abyssPluginItemInfo.GetUniqueId();
		int? num = (pluginItem != null) ? new int?(pluginItem.GetUniqueId()) : null;
		if (uniqueId == num.GetValueOrDefault() & num != null)
		{
			return;
		}
		if (gridData.State == EToggleState.ETT_Checked)
		{
			AbyssPluginItemInfo pluginItemInfoById = ModelBase<DangoAbyssModel>.Instance.GetPluginItemInfoById(abyssPluginItemInfo.GetUniqueId());
			this.ViewModel.SetPluginItem(pluginItemInfoById, false);
		}
	}

	// Token: 0x0600C69C RID: 50844 RVA: 0x00347D28 File Offset: 0x00345F28
	protected bool OnCanExecuteChange(object data, bool isForceSelected, EToggleState state)
	{
		AbyssPluginItemInfo abyssPluginItemInfo = (AbyssPluginItemInfo)data;
		AbyssPluginItemInfo pluginItem = this.ViewModel.GetPluginItem();
		int uniqueId = abyssPluginItemInfo.GetUniqueId();
		int? num = (pluginItem != null) ? new int?(pluginItem.GetUniqueId()) : null;
		bool flag = uniqueId == num.GetValueOrDefault() & num != null;
		bool flag2 = state == EToggleState.ETT_Checked;
		return !flag || !flag2;
	}

	// Token: 0x0600C69D RID: 50845 RVA: 0x00347D88 File Offset: 0x00345F88
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length == 0)
		{
			return null;
		}
		string a = configParams[0];
		if (a == "PluginSelect")
		{
			if (configParams.Length < 2)
			{
				return null;
			}
			int displayIndex;
			if (!int.TryParse(configParams[1], out displayIndex))
			{
				return null;
			}
			LoopScrollView<DangoAbyssItemMediumItemGrid, AbyssPluginItemInfo> itemScroll = this.ItemScroll;
			UUIItem uuiitem = (itemScroll != null) ? itemScroll.GetGridByDisplayIndex(displayIndex) : null;
			if (uuiitem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem,
				uuiitem
			};
		}
		else if (a == "InvalidAttr")
		{
			int guideInvalidAttrIndexCache = this.GuideInvalidAttrIndexCache;
			DynamicScrollView<DangoAbyssAttributeParentItem, DangoAbyssAttributeBaseItem, DangoAbyssDefine.EquipViewAttributeData> attributeScroll = this.AttributeScroll;
			UUIItem uuiitem2 = (attributeScroll != null) ? attributeScroll.GetGridByDisplayIndex(guideInvalidAttrIndexCache) : null;
			if (uuiitem2 == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem2,
				uuiitem2
			};
		}
		else if (a == "ValidAttr")
		{
			int guideValidAttrIndexCache = this.GuideValidAttrIndexCache;
			DynamicScrollView<DangoAbyssAttributeParentItem, DangoAbyssAttributeBaseItem, DangoAbyssDefine.EquipViewAttributeData> attributeScroll2 = this.AttributeScroll;
			UUIItem uuiitem3 = (attributeScroll2 != null) ? attributeScroll2.GetGridByDisplayIndex(guideValidAttrIndexCache) : null;
			if (uuiitem3 == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem3,
				uuiitem3
			};
		}
		else
		{
			if (!(a == "DangoPlugin"))
			{
				return null;
			}
			ItemTipsComponentContentComponent tipsComponent = this.TipsComponent;
			if (tipsComponent == null)
			{
				return null;
			}
			return tipsComponent.GetGuideUiItemAndUiItemForShowEx(configParams);
		}
	}

	// Token: 0x0600C69E RID: 50846 RVA: 0x00347E8D File Offset: 0x0034608D
	private int GetInvalidAttrIndex()
	{
		return this.AttributeScrollData.FindIndex((DangoAbyssDefine.EquipViewAttributeData data) => !data.IsValid && data.Tag != null);
	}

	// Token: 0x0600C69F RID: 50847 RVA: 0x00347EB9 File Offset: 0x003460B9
	private int GetValidAttrChangeIndex()
	{
		return this.AttributeScrollData.FindIndex((DangoAbyssDefine.EquipViewAttributeData data) => data.IsChange && data.IsValid);
	}

	// Token: 0x04005F14 RID: 24340
	[Nullable(2)]
	private PluginPanel PluginPanel;

	// Token: 0x04005F15 RID: 24341
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<DangoAbyssItemMediumItemGrid, AbyssPluginItemInfo> ItemScroll;

	// Token: 0x04005F16 RID: 24342
	[Nullable(2)]
	private ItemTipsComponentContentComponent TipsComponent;

	// Token: 0x04005F17 RID: 24343
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private FilterSortEntrance<AbyssPluginItemInfo> FilterSortEntrance;

	// Token: 0x04005F18 RID: 24344
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	private DynamicScrollView<DangoAbyssAttributeParentItem, DangoAbyssAttributeBaseItem, DangoAbyssDefine.EquipViewAttributeData> AttributeScroll;

	// Token: 0x04005F19 RID: 24345
	[Nullable(2)]
	private PluginEquipViewModel ViewModel;

	// Token: 0x04005F1A RID: 24346
	private List<DangoAbyssDefine.EquipViewAttributeData> AttributeScrollData = new List<DangoAbyssDefine.EquipViewAttributeData>();

	// Token: 0x04005F1B RID: 24347
	private List<AbyssPluginItemInfo> DataAfterFilter = new List<AbyssPluginItemInfo>();

	// Token: 0x04005F1C RID: 24348
	private int LastSlotIndexForList = -1;

	// Token: 0x04005F1D RID: 24349
	private List<int> CurEquipListForGuide = new List<int>();

	// Token: 0x04005F1E RID: 24350
	private int GuideValidAttrIndexCache = -1;

	// Token: 0x04005F1F RID: 24351
	private int GuideInvalidAttrIndexCache = -1;

	// Token: 0x02007DC0 RID: 32192
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402AD4E RID: 175438
		BtnClose,
		// Token: 0x0402AD4F RID: 175439
		TextTypeCount,
		// Token: 0x0402AD50 RID: 175440
		BtnRecovery,
		// Token: 0x0402AD51 RID: 175441
		ItemTipsItem,
		// Token: 0x0402AD52 RID: 175442
		PluginScrollView,
		// Token: 0x0402AD53 RID: 175443
		PluginItem,
		// Token: 0x0402AD54 RID: 175444
		EmptyItem,
		// Token: 0x0402AD55 RID: 175445
		FilterSortEntrance,
		// Token: 0x0402AD56 RID: 175446
		PluginItemPanel,
		// Token: 0x0402AD57 RID: 175447
		AttributeContent,
		// Token: 0x0402AD58 RID: 175448
		AttributeItem,
		// Token: 0x0402AD59 RID: 175449
		AttributeScroller,
		// Token: 0x0402AD5A RID: 175450
		AttributeEmptyItem,
		// Token: 0x0402AD5B RID: 175451
		BtnMask,
		// Token: 0x0402AD5C RID: 175452
		TextMax
	}
}
