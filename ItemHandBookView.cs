using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001E93 RID: 7827
[NullableContext(1)]
[Nullable(0)]
public class ItemHandBookView : HandBookBaseView
{
	// Token: 0x0600E766 RID: 59238 RVA: 0x003E7DA8 File Offset: 0x003E5FA8
	public ItemHandBookView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600E767 RID: 59239 RVA: 0x003E7DF8 File Offset: 0x003E5FF8
	protected override void OnStart()
	{
		base.SetDefaultState();
		this.RefreshTabComponent();
		this.RefreshItemTitle();
		this.RefreshCollectText();
		this.RefreshLockText();
		int? firstPageType = this.GetFirstPageType();
		if (firstPageType != null)
		{
			this.RefreshScrollView(firstPageType.Value);
		}
	}

	// Token: 0x0600E768 RID: 59240 RVA: 0x003E7E40 File Offset: 0x003E6040
	private void OnHandBookDataUpdate(EHandBookTabType eHandBookTabType, int i)
	{
		this.Refresh();
	}

	// Token: 0x0600E769 RID: 59241 RVA: 0x003E7E48 File Offset: 0x003E6048
	protected void Refresh()
	{
		int? firstPageType = this.GetFirstPageType();
		if (firstPageType != null)
		{
			this.RefreshScrollView(firstPageType.Value);
		}
	}

	// Token: 0x0600E76A RID: 59242 RVA: 0x003E7E74 File Offset: 0x003E6074
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnHandBookDataInit, new Action(this.Refresh));
		Singleton<EventSystem>.Instance.Add<EHandBookTabType, int>(EEventName.OnHandBookDataUpdate, new Action<EHandBookTabType, int>(this.OnHandBookDataUpdate));
		Singleton<EventSystem>.Instance.Add(EEventName.OnHandBookRead, new Action<EHandBookTabType, int>(this.OnHandBookRead));
	}

	// Token: 0x0600E76B RID: 59243 RVA: 0x003E7ED8 File Offset: 0x003E60D8
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHandBookDataInit, new Action(this.Refresh));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHandBookDataUpdate, new Action<EHandBookTabType, int>(this.OnHandBookDataUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHandBookRead, new Action<EHandBookTabType, int>(this.OnHandBookRead));
	}

	// Token: 0x0600E76C RID: 59244 RVA: 0x003E7F3C File Offset: 0x003E613C
	protected void OnHandBookRead(EHandBookTabType type, int id)
	{
		if (type != EHandBookTabType.Item)
		{
			return;
		}
		int count = this.HandBookCommonItemList.Count;
		for (int i = 0; i < count; i++)
		{
			HandBookCommonItem handBookCommonItem = this.HandBookCommonItemList[i];
			if (((ItemHandBook)handBookCommonItem.GetData().Config).Id == id)
			{
				handBookCommonItem.SetNewFlagVisible(new bool?(false));
				return;
			}
		}
	}

	// Token: 0x0600E76D RID: 59245 RVA: 0x003E7F9C File Offset: 0x003E619C
	protected void TabToggleCallBack(int index)
	{
		int id = this.ItemHandBookTypeList[index].Id;
		this.RefreshScrollView(id);
	}

	// Token: 0x0600E76E RID: 59246 RVA: 0x003E7FC8 File Offset: 0x003E61C8
	protected override HandBookCommonItem InitHandBookCommonItem()
	{
		HandBookCommonItem handBookCommonItem = new HandBookCommonItem();
		this.HandBookCommonItemList.Add(handBookCommonItem);
		handBookCommonItem.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.OnToggleClick));
		return handBookCommonItem;
	}

	// Token: 0x0600E76F RID: 59247 RVA: 0x003E7FFC File Offset: 0x003E61FC
	protected void OnToggleClick(MediumItemGridExtendCallback callbackParameter)
	{
		HandBookCommonItemData handBookCommonItemData = callbackParameter.Data as HandBookCommonItemData;
		int gridIndex = (callbackParameter.MediumItemGrid as HandBookCommonItem).GridIndex;
		this.ScrollViewCommon.DeselectCurrentGridProxy(false);
		this.ScrollViewCommon.SelectGridProxy(gridIndex, false);
		this.ScrollViewCommon.RefreshGridProxy(gridIndex);
		this.RefreshTitleText(((ItemHandBook)handBookCommonItemData.Config).Id);
		if (handBookCommonItemData.IsLock)
		{
			this.SetItemLockState(true);
			return;
		}
		this.SetItemLockState(false);
		this.RefreshItemContent(handBookCommonItemData);
	}

	// Token: 0x0600E770 RID: 59248 RVA: 0x003E8082 File Offset: 0x003E6282
	protected void SetItemLockState(bool state)
	{
		base.SetLockState(state);
		base.GetTexture(25).SetUIActive(!state);
	}

	// Token: 0x0600E771 RID: 59249 RVA: 0x003E809C File Offset: 0x003E629C
	protected void RefreshItemContent(HandBookCommonItemData handBookCommonItemData)
	{
		ItemHandBook itemHandBook = (ItemHandBook)handBookCommonItemData.Config;
		if (handBookCommonItemData.IsNew)
		{
			ControllerBase<HandBookController>.Instance.SendIllustratedReadRequest(EHandBookTabType.Item, itemHandBook.Id);
		}
		ItemInfo value = ConfigBase<InventoryConfig>.Instance.GetItemConfig(itemHandBook.Id).Value;
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(value.Name, null);
		base.SetNameText(localTextNew);
		base.SetItemTexture(value.IconMiddle);
		string localTextNew2 = ConfigMultiTextLang.GetLocalTextNew(itemHandBook.Title, null);
		List<string> list = new List<string>();
		if (localTextNew2 != null)
		{
			list.Add(localTextNew2);
		}
		base.InitInfoItemLayout(list);
		List<HandBookContentItemData> list2 = new List<HandBookContentItemData>();
		string desc = ConfigMultiTextLang.GetLocalTextNew(value.BgDescription, null) ?? "";
		list2.Add(new HandBookContentItemData("", desc));
		base.InitContentItemLayout(list2);
		this.RefreshOwnText(value.Id);
	}

	// Token: 0x0600E772 RID: 59250 RVA: 0x003E817C File Offset: 0x003E637C
	protected void RefreshCollectText()
	{
		int[] collectProgress = ControllerBase<HandBookController>.Instance.GetCollectProgress(EHandBookTabType.Item);
		base.SetCollectText(collectProgress[0], collectProgress[1]);
	}

	// Token: 0x0600E773 RID: 59251 RVA: 0x003E81A4 File Offset: 0x003E63A4
	protected void RefreshLockText()
	{
		string textById = ConfigBase<TextConfig>.Instance.GetTextById("ItemHandBookLock");
		base.SetLockText(textById);
	}

	// Token: 0x0600E774 RID: 59252 RVA: 0x003E81C8 File Offset: 0x003E63C8
	protected void RefreshOwnText(int itemId)
	{
		HandBookEntry handBookInfo = ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Item, itemId);
		base.SetOwnText(handBookInfo.Num);
	}

	// Token: 0x0600E775 RID: 59253 RVA: 0x003E81F0 File Offset: 0x003E63F0
	protected int GetFirstTypeId()
	{
		return ConfigBase<HandBookConfig>.Instance.GetItemHandBookTypeConfigList()[0].Id;
	}

	// Token: 0x0600E776 RID: 59254 RVA: 0x003E8218 File Offset: 0x003E6418
	protected void RefreshScrollView(int type)
	{
		if (type == 0)
		{
			return;
		}
		IReadOnlyList<ItemHandBook> itemHandBookConfigByType = ConfigBase<HandBookConfig>.Instance.GetItemHandBookConfigByType(type);
		List<HandBookCommonItemData> list = new List<HandBookCommonItemData>();
		int count = itemHandBookConfigByType.Count;
		for (int i = 0; i < count; i++)
		{
			ItemHandBook itemHandBook = itemHandBookConfigByType[i];
			HandBookEntry handBookInfo = ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Item, itemHandBook.Id);
			bool isLock = handBookInfo == null;
			bool isNew = handBookInfo != null && !handBookInfo.IsRead;
			HandBookCommonItemData handBookCommonItemData = new HandBookCommonItemData();
			ItemInfo value = ConfigBase<InventoryConfig>.Instance.GetItemConfig(itemHandBook.Id).Value;
			handBookCommonItemData.Icon = value.IconSmall;
			handBookCommonItemData.QualityId = value.QualityId;
			handBookCommonItemData.ConfigId = value.Id;
			handBookCommonItemData.IsLock = isLock;
			handBookCommonItemData.IsNew = isNew;
			handBookCommonItemData.Config = itemHandBook;
			list.Add(handBookCommonItemData);
		}
		base.InitScrollViewByCommonItem(list);
	}

	// Token: 0x0600E777 RID: 59255 RVA: 0x003E8308 File Offset: 0x003E6508
	protected int? GetFirstPageType()
	{
		if (this.ItemHandBookTypeList.Count == 0)
		{
			return null;
		}
		return new int?(this.ItemHandBookTypeList[0].Id);
	}

	// Token: 0x0600E778 RID: 59256 RVA: 0x003E8348 File Offset: 0x003E6548
	protected void RefreshTabComponent()
	{
		this.ItemHandBookTypeList = ConfigCommon.ToList<ItemHandBookType>(ConfigBase<HandBookConfig>.Instance.GetItemHandBookTypeConfigList());
		this.ItemHandBookTypeList.Sort(this.SortIndex);
		int count = this.ItemHandBookTypeList.Count;
		List<CommonTabData> list = new List<CommonTabData>();
		for (int i = 0; i < count; i++)
		{
			list.Add(new CommonTabData(this.ItemHandBookTypeList[i].Icon, null, null));
		}
		base.InitTabComponent(list);
		base.SetTabToggleCallBack(new Action<int>(this.TabToggleCallBack));
	}

	// Token: 0x0600E779 RID: 59257 RVA: 0x003E83D4 File Offset: 0x003E65D4
	protected void RefreshItemTitle()
	{
		HandBookEntrance value = ConfigBase<HandBookConfig>.Instance.GetHandBookEntranceConfig(EHandBookTabType.Item).Value;
		base.InitCommonTabTitle(value.TitleIcon, new CommonTabTitleData(value.Name, Array.Empty<object>()));
	}

	// Token: 0x0600E77A RID: 59258 RVA: 0x003E8414 File Offset: 0x003E6614
	protected void RefreshTitleText(int id)
	{
		ItemHandBook value = ConfigBase<HandBookConfig>.Instance.GetItemHandBookConfigById(id).Value;
		base.UpdateTitle(new CommonTabTitleData(ConfigBase<HandBookConfig>.Instance.GetItemHandBookTypeConfig(value.Type).Value.Descrtption, Array.Empty<object>()));
	}

	// Token: 0x0600E77B RID: 59259 RVA: 0x003E8466 File Offset: 0x003E6666
	protected override CommonTabItem TabItemProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new CommonTabItem();
	}

	// Token: 0x0600E77C RID: 59260 RVA: 0x003E8470 File Offset: 0x003E6670
	public override List<CommonTabItemData> GetTabItemData(List<CommonTabData> tabData)
	{
		int count = tabData.Count;
		List<CommonTabItemData> list = new List<CommonTabItemData>();
		for (int i = 0; i < count; i++)
		{
			list.Add(new CommonTabItemData
			{
				Index = i,
				RedDotName = new ERedDotName?(ERedDotName.ItemHandBook),
				RedDotUid = new int?(this.ItemHandBookTypeList[i].Id),
				Data = this.TabList[i]
			});
		}
		return list;
	}

	// Token: 0x0600E77D RID: 59261 RVA: 0x003E84EA File Offset: 0x003E66EA
	protected override void OnBeforeDestroy()
	{
		this.ItemHandBookTypeList = new List<ItemHandBookType>();
		this.HandBookCommonItemList = new List<HandBookCommonItem>();
	}

	// Token: 0x04006F95 RID: 28565
	private List<ItemHandBookType> ItemHandBookTypeList = new List<ItemHandBookType>();

	// Token: 0x04006F96 RID: 28566
	private List<HandBookCommonItem> HandBookCommonItemList = new List<HandBookCommonItem>();

	// Token: 0x04006F97 RID: 28567
	private readonly Comparison<ItemHandBookType> SortIndex = (ItemHandBookType a, ItemHandBookType b) => a.Id - b.Id;
}
