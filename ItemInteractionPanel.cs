using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001978 RID: 6520
[NullableContext(1)]
[Nullable(0)]
public class ItemInteractionPanel : UiPanelBase
{
	// Token: 0x0600BB60 RID: 47968 RVA: 0x0031C588 File Offset: 0x0031A788
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
	}

	// Token: 0x0600BB61 RID: 47969 RVA: 0x0031C63A File Offset: 0x0031A83A
	protected override void OnStart()
	{
		this.ItemScrollView = new LoopScrollView<ItemInteractionMediumItemGrid, ItemInteractionPanelItemData>(base.GetLoopScrollViewComponent(5), base.GetItem(6).GetOwner() as AUIBaseActor, new Func<ItemInteractionMediumItemGrid>(this.OnGridProxyCreate), false);
	}

	// Token: 0x0600BB62 RID: 47970 RVA: 0x0031C66C File Offset: 0x0031A86C
	public UniTask Refresh(IItemInteractionPanel itemInteractionPanelInfo)
	{
		ItemInteractionPanel.<Refresh>d__15 <Refresh>d__;
		<Refresh>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Refresh>d__.<>4__this = this;
		<Refresh>d__.itemInteractionPanelInfo = itemInteractionPanelInfo;
		<Refresh>d__.<>1__state = -1;
		<Refresh>d__.<>t__builder.Start<ItemInteractionPanel.<Refresh>d__15>(ref <Refresh>d__);
		return <Refresh>d__.<>t__builder.Task;
	}

	// Token: 0x0600BB63 RID: 47971 RVA: 0x0031C6B7 File Offset: 0x0031A8B7
	private ItemInteractionMediumItemGrid OnGridProxyCreate()
	{
		ItemInteractionMediumItemGrid itemInteractionMediumItemGrid = new ItemInteractionMediumItemGrid();
		itemInteractionMediumItemGrid.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.OnItemExtendToggleStateChanged));
		itemInteractionMediumItemGrid.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(this.OnCanExecuteChange));
		itemInteractionMediumItemGrid.BindReduceLongPress(new Action<bool, MediumItemGrid, object>(this.OnReduceButtonLongPress));
		return itemInteractionMediumItemGrid;
	}

	// Token: 0x0600BB64 RID: 47972 RVA: 0x0031C6F4 File Offset: 0x0031A8F4
	private void OnReduceButtonLongPress(bool isShortPress, MediumItemGrid mediumItemGrid, [Nullable(2)] object data)
	{
		if (data == null)
		{
			return;
		}
		ItemInteractionPanelItemData obj = data as ItemInteractionPanelItemData;
		if (this.OnReduceButtonTriggerCallback != null)
		{
			this.OnReduceButtonTriggerCallback(obj);
		}
	}

	// Token: 0x0600BB65 RID: 47973 RVA: 0x0031C720 File Offset: 0x0031A920
	private void OnItemExtendToggleStateChanged(MediumItemGridExtendCallback callbackParameter)
	{
		ItemInteractionPanelItemData itemInteractionPanelItemData = callbackParameter.Data as ItemInteractionPanelItemData;
		this.SetItemGridSelected(true, itemInteractionPanelItemData);
		if (this.OnItemExtendToggleStateChangedCallback != null)
		{
			this.OnItemExtendToggleStateChangedCallback(itemInteractionPanelItemData);
		}
	}

	// Token: 0x0600BB66 RID: 47974 RVA: 0x0031C758 File Offset: 0x0031A958
	[NullableContext(2)]
	private bool OnCanExecuteChange(object data, bool isForceSelected, EToggleState state)
	{
		ItemInteractionPanelItemData itemInteractionPanelItemData = data as ItemInteractionPanelItemData;
		return (this.CurrentSelectedData == null || !this.CurrentSelectedData.IsSelected || itemInteractionPanelItemData != this.CurrentSelectedData) && this.CurrentItemDataList.IndexOf(itemInteractionPanelItemData) >= 0 && (this.OnCanExecuteChangeCallback == null || this.OnCanExecuteChangeCallback(itemInteractionPanelItemData));
	}

	// Token: 0x0600BB67 RID: 47975 RVA: 0x0031C7B3 File Offset: 0x0031A9B3
	public void BindOnReduceButtonTrigger(Action<ItemInteractionPanelItemData> onReduceButtonTriggerCallback)
	{
		this.OnReduceButtonTriggerCallback = onReduceButtonTriggerCallback;
	}

	// Token: 0x0600BB68 RID: 47976 RVA: 0x0031C7BC File Offset: 0x0031A9BC
	public void BindOnItemExtendToggleStateChanged(Action<ItemInteractionPanelItemData> onItemExtendToggleStateChangedCallback)
	{
		this.OnItemExtendToggleStateChangedCallback = onItemExtendToggleStateChangedCallback;
	}

	// Token: 0x0600BB69 RID: 47977 RVA: 0x0031C7C5 File Offset: 0x0031A9C5
	public void BindOnCanExecuteChange(Func<ItemInteractionPanelItemData, bool> onCanExecuteChangeCallback)
	{
		this.OnCanExecuteChangeCallback = onCanExecuteChangeCallback;
	}

	// Token: 0x0600BB6A RID: 47978 RVA: 0x0031C7D0 File Offset: 0x0031A9D0
	protected override void OnBeforeDestroy()
	{
		this.MainTypeIdList.Clear();
		this.CurrentItemDataList.Clear();
		this.ItemScrollView = null;
		this.SelectedMainTypeItem = null;
		this.ItemDataMainTypeMap.Clear();
		this.ItemDataMap.Clear();
		this.OnItemExtendToggleStateChangedCallback = null;
		this.OnReduceButtonTriggerCallback = null;
		this.ClearMainTypeItem();
	}

	// Token: 0x0600BB6B RID: 47979 RVA: 0x0031C82C File Offset: 0x0031AA2C
	private void RefreshItemDataMap()
	{
		this.ItemDataMainTypeMap.Clear();
		this.ItemDataMap.Clear();
		this.MainTypeIdList.Clear();
		this.CurrentItemDataList.Clear();
		InventoryConfig instance = ConfigBase<InventoryConfig>.Instance;
		foreach (IItemInteractionPanelItemInfo itemInteractionPanelItemInfo in this.ItemInteractionPanelInfo.ItemInfoList)
		{
			int itemConfigId = itemInteractionPanelItemInfo.ItemConfigId;
			ItemInfo? itemConfig = instance.GetItemConfig(itemConfigId);
			if (itemConfig != null)
			{
				int mainTypeId = itemConfig.Value.MainTypeId;
				ItemInteractionPanelItemData itemInteractionPanelItemData = new ItemInteractionPanelItemData(itemInteractionPanelItemInfo, itemConfig.Value.QualityId);
				List<ItemInteractionPanelItemData> list;
				if (this.ItemDataMainTypeMap.TryGetValue(mainTypeId, out list))
				{
					list.Add(itemInteractionPanelItemData);
				}
				else
				{
					this.ItemDataMainTypeMap[mainTypeId] = new List<ItemInteractionPanelItemData>
					{
						itemInteractionPanelItemData
					};
					this.MainTypeIdList.Add(mainTypeId);
				}
				this.ItemDataMap[itemConfigId] = itemInteractionPanelItemData;
			}
		}
		using (Dictionary<int, List<ItemInteractionPanelItemData>>.ValueCollection.Enumerator enumerator2 = this.ItemDataMainTypeMap.Values.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				enumerator2.Current.Sort(delegate(ItemInteractionPanelItemData a, ItemInteractionPanelItemData b)
				{
					int qualityId = a.GetQualityId();
					int qualityId2 = b.GetQualityId();
					if (qualityId != qualityId2)
					{
						return qualityId - qualityId2;
					}
					int itemCount = a.GetItemCount();
					int itemCount2 = b.GetItemCount();
					if (itemCount != itemCount2)
					{
						return itemCount2 - itemCount;
					}
					return a.ItemConfigId - b.ItemConfigId;
				});
			}
		}
	}

	// Token: 0x0600BB6C RID: 47980 RVA: 0x0031C9B0 File Offset: 0x0031ABB0
	private UniTask RefreshMainTypeExtendToggle()
	{
		ItemInteractionPanel.<RefreshMainTypeExtendToggle>d__25 <RefreshMainTypeExtendToggle>d__;
		<RefreshMainTypeExtendToggle>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshMainTypeExtendToggle>d__.<>4__this = this;
		<RefreshMainTypeExtendToggle>d__.<>1__state = -1;
		<RefreshMainTypeExtendToggle>d__.<>t__builder.Start<ItemInteractionPanel.<RefreshMainTypeExtendToggle>d__25>(ref <RefreshMainTypeExtendToggle>d__);
		return <RefreshMainTypeExtendToggle>d__.<>t__builder.Task;
	}

	// Token: 0x0600BB6D RID: 47981 RVA: 0x0031C9F3 File Offset: 0x0031ABF3
	private void OnMainTypeExtendToggleStateChanged(int mainTypeId)
	{
		this.SelectedMainType(mainTypeId);
	}

	// Token: 0x0600BB6E RID: 47982 RVA: 0x0031C9FC File Offset: 0x0031ABFC
	public void SelectedMainType(int mainTypeId)
	{
		this.RefreshItemPanel(this.ItemDataMainTypeMap[mainTypeId]);
		ItemInteractionPanelMainTypeItem selectedMainTypeItem = this.SelectedMainTypeItem;
		if (selectedMainTypeItem != null)
		{
			selectedMainTypeItem.SetSelected(false);
		}
		ItemInteractionPanelMainTypeItem itemInteractionPanelMainTypeItem;
		if (this.MainTypeItemMap.TryGetValue(mainTypeId, out itemInteractionPanelMainTypeItem))
		{
			itemInteractionPanelMainTypeItem.SetSelected(true);
			itemInteractionPanelMainTypeItem.SetRedDotVisible(false);
			this.SelectedMainTypeItem = itemInteractionPanelMainTypeItem;
		}
	}

	// Token: 0x0600BB6F RID: 47983 RVA: 0x0031CA54 File Offset: 0x0031AC54
	public void SetMainTypeRedDotVisible(int mainTypeId, bool bVisible)
	{
		ItemInteractionPanelMainTypeItem itemInteractionPanelMainTypeItem;
		if (this.MainTypeItemMap.TryGetValue(mainTypeId, out itemInteractionPanelMainTypeItem))
		{
			itemInteractionPanelMainTypeItem.SetRedDotVisible(bVisible);
		}
	}

	// Token: 0x0600BB70 RID: 47984 RVA: 0x0031CA78 File Offset: 0x0031AC78
	private void ClearMainTypeItem()
	{
		foreach (ItemInteractionPanelMainTypeItem itemInteractionPanelMainTypeItem in this.MainTypeItemMap.Values)
		{
			itemInteractionPanelMainTypeItem.Destroy(null);
		}
		this.MainTypeItemMap.Clear();
	}

	// Token: 0x0600BB71 RID: 47985 RVA: 0x0031CADC File Offset: 0x0031ACDC
	public void RefreshItemPanel(List<ItemInteractionPanelItemData> itemDataList)
	{
		LoopScrollView<ItemInteractionMediumItemGrid, ItemInteractionPanelItemData> itemScrollView = this.ItemScrollView;
		if (itemScrollView != null)
		{
			itemScrollView.RefreshByData(itemDataList, false, null, false);
		}
		this.CurrentItemDataList = itemDataList;
		this.CurrentSelectedData = null;
	}

	// Token: 0x0600BB72 RID: 47986 RVA: 0x0031CB04 File Offset: 0x0031AD04
	public void RefreshItemGrid(ItemInteractionPanelItemData data)
	{
		int num = this.CurrentItemDataList.IndexOf(data);
		if (num < 0)
		{
			return;
		}
		LoopScrollView<ItemInteractionMediumItemGrid, ItemInteractionPanelItemData> itemScrollView = this.ItemScrollView;
		if (itemScrollView == null)
		{
			return;
		}
		itemScrollView.RefreshGridProxy(num);
	}

	// Token: 0x0600BB73 RID: 47987 RVA: 0x0031CB34 File Offset: 0x0031AD34
	public void SetItemGridSelected(bool bSelected, ItemInteractionPanelItemData data)
	{
		int num = this.CurrentItemDataList.IndexOf(data);
		if (num < 0)
		{
			return;
		}
		data.IsSelected = bSelected;
		if (bSelected)
		{
			this.CurrentSelectedData = data;
		}
		else
		{
			this.CurrentSelectedData = null;
		}
		LoopScrollView<ItemInteractionMediumItemGrid, ItemInteractionPanelItemData> itemScrollView = this.ItemScrollView;
		if (itemScrollView == null)
		{
			return;
		}
		itemScrollView.RefreshGridProxy(num);
	}

	// Token: 0x0600BB74 RID: 47988 RVA: 0x0031CB7E File Offset: 0x0031AD7E
	public List<ItemInteractionPanelItemData> GetCurrentItemDataList()
	{
		return this.CurrentItemDataList;
	}

	// Token: 0x0600BB75 RID: 47989 RVA: 0x0031CB88 File Offset: 0x0031AD88
	[NullableContext(2)]
	public ItemInteractionPanelItemData GetItemData(int itemConfigId)
	{
		ItemInteractionPanelItemData result;
		if (this.ItemDataMap.TryGetValue(itemConfigId, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x0600BB76 RID: 47990 RVA: 0x0031CBA8 File Offset: 0x0031ADA8
	public IReadOnlyDictionary<int, List<ItemInteractionPanelItemData>> GetItemDataMainTypeMap()
	{
		return this.ItemDataMainTypeMap;
	}

	// Token: 0x0600BB77 RID: 47991 RVA: 0x0031CBB0 File Offset: 0x0031ADB0
	public IReadOnlyList<int> GetMainTypeIdList()
	{
		return this.MainTypeIdList;
	}

	// Token: 0x04005880 RID: 22656
	[Nullable(2)]
	private IItemInteractionPanel ItemInteractionPanelInfo;

	// Token: 0x04005881 RID: 22657
	private readonly Dictionary<int, List<ItemInteractionPanelItemData>> ItemDataMainTypeMap = new Dictionary<int, List<ItemInteractionPanelItemData>>();

	// Token: 0x04005882 RID: 22658
	private readonly Dictionary<int, ItemInteractionPanelItemData> ItemDataMap = new Dictionary<int, ItemInteractionPanelItemData>();

	// Token: 0x04005883 RID: 22659
	private readonly List<int> MainTypeIdList = new List<int>();

	// Token: 0x04005884 RID: 22660
	private List<ItemInteractionPanelItemData> CurrentItemDataList = new List<ItemInteractionPanelItemData>();

	// Token: 0x04005885 RID: 22661
	private readonly Dictionary<int, ItemInteractionPanelMainTypeItem> MainTypeItemMap = new Dictionary<int, ItemInteractionPanelMainTypeItem>();

	// Token: 0x04005886 RID: 22662
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<ItemInteractionMediumItemGrid, ItemInteractionPanelItemData> ItemScrollView;

	// Token: 0x04005887 RID: 22663
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<ItemInteractionPanelItemData> OnItemExtendToggleStateChangedCallback;

	// Token: 0x04005888 RID: 22664
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<ItemInteractionPanelItemData> OnReduceButtonTriggerCallback;

	// Token: 0x04005889 RID: 22665
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Func<ItemInteractionPanelItemData, bool> OnCanExecuteChangeCallback;

	// Token: 0x0400588A RID: 22666
	[Nullable(2)]
	private ItemInteractionPanelMainTypeItem SelectedMainTypeItem;

	// Token: 0x0400588B RID: 22667
	[Nullable(2)]
	private ItemInteractionPanelItemData CurrentSelectedData;

	// Token: 0x02007C8A RID: 31882
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402A87A RID: 174202
		TitleSprite,
		// Token: 0x0402A87B RID: 174203
		TitleText,
		// Token: 0x0402A87C RID: 174204
		ContentSprite,
		// Token: 0x0402A87D RID: 174205
		TitleHorizontalItem,
		// Token: 0x0402A87E RID: 174206
		MainTypeItem,
		// Token: 0x0402A87F RID: 174207
		LoopScrollView,
		// Token: 0x0402A880 RID: 174208
		SourceItemGridItem
	}
}
