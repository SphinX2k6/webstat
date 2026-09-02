using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001E4C RID: 7756
[NullableContext(1)]
[Nullable(0)]
public abstract class HandBookBaseView : UiViewBase
{
	// Token: 0x0600E592 RID: 58770 RVA: 0x003E0354 File Offset: 0x003DE554
	public HandBookBaseView(UiViewInfo viewInfo) : base(viewInfo)
	{
		this.TabList = new List<CommonTabData>();
		this.HandBookCommonItemDataList = new List<HandBookCommonItemData>();
		this.PhantomFetterDataList = new List<PhantomFetter>();
		this.HandBookCommonTypeItemDataList = new List<List<HandBookCommonItemData>>();
		this.InfoTextList = new List<string>();
		this.ContentTextList = new List<HandBookContentItemData>();
		this.AttributeList = new List<CSharpScript.Game.Module.Common.AttributeData>();
		this.PhantomDataList = new List<HandBookCommonItemData>();
	}

	// Token: 0x0600E593 RID: 58771 RVA: 0x003E03C0 File Offset: 0x003DE5C0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIText)),
			new ValueTuple<int, Type>(11, typeof(UUIText)),
			new ValueTuple<int, Type>(12, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(15, typeof(UUIItem)),
			new ValueTuple<int, Type>(16, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(17, typeof(UUIText)),
			new ValueTuple<int, Type>(18, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(19, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(20, typeof(UUIItem)),
			new ValueTuple<int, Type>(21, typeof(UUIItem)),
			new ValueTuple<int, Type>(22, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(23, typeof(UUIText)),
			new ValueTuple<int, Type>(24, typeof(UUIText)),
			new ValueTuple<int, Type>(25, typeof(UUITexture)),
			new ValueTuple<int, Type>(26, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(22, new Action(this.CloseClick))
		};
	}

	// Token: 0x0600E594 RID: 58772 RVA: 0x003E0660 File Offset: 0x003DE860
	protected void SetDefaultState()
	{
		base.GetItem(0).SetUIActive(false);
		base.GetItem(1).SetUIActive(false);
		base.GetItem(2).SetUIActive(false);
		base.GetItem(3).SetUIActive(false);
		base.GetLoopScrollViewComponent(4).RootUIComp.Get().SetUIActive(false);
		base.GetItem(5).SetUIActive(false);
		base.GetItem(6).SetUIActive(false);
		base.GetScrollViewWithScrollbar(7).RootUIComp.Get().SetUIActive(false);
		base.GetItem(8).SetUIActive(false);
		base.GetText(9).SetUIActive(false);
		base.GetText(10).SetUIActive(false);
		base.GetText(11).SetUIActive(false);
		base.GetVerticalLayout(12).RootUIComp.Get().SetUIActive(false);
		base.GetItem(13).SetUIActive(false);
		base.GetHorizontalLayout(14).RootUIComp.Get().SetUIActive(false);
		base.GetItem(15).SetUIActive(false);
		base.GetVerticalLayout(16).RootUIComp.Get().SetUIActive(false);
		base.GetText(17).SetUIActive(false);
		base.GetVerticalLayout(18).RootUIComp.Get().SetUIActive(false);
		base.GetVerticalLayout(19).RootUIComp.Get().SetUIActive(false);
		base.GetTexture(25).SetUIActive(false);
		base.GetItem(26).SetUIActive(false);
	}

	// Token: 0x0600E595 RID: 58773 RVA: 0x003E07F4 File Offset: 0x003DE9F4
	protected void InitTabComponent(List<CommonTabData> tabList)
	{
		base.GetItem(26).SetUIActive(true);
		UUIItem item = base.GetItem(0);
		base.GetItem(1).SetUIActive(true);
		item.SetUIActive(true);
		if (this.TabComponent == null)
		{
			this.TabComponent = new TabComponent<CommonTabItem>(item, new Func<UUIItem, int?, CommonTabItem>(this.TabItemProxyCreate), new Action<int>(this.ToggleCallBack), null);
		}
		this.TabList = tabList;
		List<CommonTabItemData> tabItemData = this.GetTabItemData(this.TabList);
		this.TabComponent.RefreshTabItem(tabItemData, null);
		this.TabComponent.SelectToggleByIndex(0, false, true);
	}

	// Token: 0x0600E596 RID: 58774
	public abstract List<CommonTabItemData> GetTabItemData(List<CommonTabData> tabData);

	// Token: 0x0600E597 RID: 58775 RVA: 0x003E0888 File Offset: 0x003DEA88
	protected void InitCommonTabTitle(string iconPath, CommonTabTitleData titleData)
	{
		UUIItem item = base.GetItem(2);
		item.SetUIActive(true);
		this.CommonTabTitle = new CommonTabTitle(item);
		this.CommonTabTitle.UpdateIcon(iconPath);
		this.CommonTabTitle.UpdateTitle(titleData);
	}

	// Token: 0x0600E598 RID: 58776 RVA: 0x003E08C8 File Offset: 0x003DEAC8
	protected void UpdateTitle(CommonTabTitleData titleData)
	{
		if (this.CommonTabTitle == null)
		{
			return;
		}
		this.CommonTabTitle.UpdateTitle(titleData);
	}

	// Token: 0x0600E599 RID: 58777 RVA: 0x003E08DF File Offset: 0x003DEADF
	public void SetTabToggleCallBack(Action<int> toggleCallBack)
	{
		this.OnToggleCallBack = toggleCallBack;
	}

	// Token: 0x0600E59A RID: 58778 RVA: 0x003E08E8 File Offset: 0x003DEAE8
	protected virtual void OnPhantomToggleClick(HandBookCommonItemData handBookCommonItemData, int girdIndex)
	{
	}

	// Token: 0x0600E59B RID: 58779 RVA: 0x003E08EA File Offset: 0x003DEAEA
	private void ToggleCallBack(int index)
	{
		if (this.OnToggleCallBack != null)
		{
			this.OnToggleCallBack(index);
		}
	}

	// Token: 0x0600E59C RID: 58780 RVA: 0x003E0900 File Offset: 0x003DEB00
	protected virtual CommonTabItem TabItemProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new CommonTabItem();
	}

	// Token: 0x0600E59D RID: 58781 RVA: 0x003E0908 File Offset: 0x003DEB08
	public void InitScrollViewByCommonItem(List<HandBookCommonItemData> handBookCommonItemDataList)
	{
		this.HandBookCommonItemDataList = handBookCommonItemDataList;
		UUIItem item = base.GetItem(6);
		AUIBaseActor gridActor = item.GetOwner() as AUIBaseActor;
		item.SetUIActive(true);
		UUILoopScrollViewComponent loopScrollViewComponent = base.GetLoopScrollViewComponent(4);
		loopScrollViewComponent.RootUIComp.Get().SetUIActive(true);
		if (this.ScrollViewFetter != null)
		{
			this.ScrollViewFetter.ClearGridProxies();
			this.ScrollViewFetter = null;
		}
		if (this.ScrollViewCommon == null)
		{
			this.ScrollViewCommon = new LoopScrollView<HandBookCommonItem, HandBookCommonItemData>(loopScrollViewComponent, gridActor, new Func<HandBookCommonItem>(this.InitHandBookCommonItem), false);
		}
		item.SetUIActive(false);
		this.ScrollViewCommon.ClearGridProxies();
		this.ScrollViewCommon.DeselectCurrentGridProxy(false);
		this.ScrollViewCommon.ReloadProxyData(new Func<int, HandBookCommonItemData>(this.GetHandBookCommonItemData), this.HandBookCommonItemDataList.Count, false, false);
		this.ScrollViewCommon.RefreshAllGridProxies();
		if (this.ScrollViewCommon.StartGridIndex != -1)
		{
			this.ScrollViewCommon.ScrollToGridIndex(0, true);
			this.ScrollViewCommon.SelectGridProxy(0, true);
		}
	}

	// Token: 0x0600E59E RID: 58782 RVA: 0x003E0A04 File Offset: 0x003DEC04
	public void InitScrollViewByFetterItem(List<PhantomFetter> phantomFetterDataList)
	{
		this.PhantomFetterDataList = phantomFetterDataList;
		UUIItem item = base.GetItem(5);
		AUIBaseActor gridActor = item.GetOwner() as AUIBaseActor;
		item.SetUIActive(true);
		UUILoopScrollViewComponent loopScrollViewComponent = base.GetLoopScrollViewComponent(4);
		loopScrollViewComponent.RootUIComp.Get().SetUIActive(true);
		if (this.ScrollViewCommon != null)
		{
			this.ScrollViewCommon.ClearGridProxies();
			this.ScrollViewCommon = null;
		}
		if (this.ScrollViewFetter == null)
		{
			this.ScrollViewFetter = new LoopScrollView<HandBookFetterItem, PhantomFetter>(loopScrollViewComponent, gridActor, new Func<HandBookFetterItem>(this.InitHandBookFetterItem), false);
		}
		item.SetUIActive(false);
		this.ScrollViewFetter.ClearGridProxies();
		this.ScrollViewFetter.ReloadProxyData(new Func<int, PhantomFetter>(this.GetPhantomFetterData), this.PhantomFetterDataList.Count, false, false);
		this.ScrollViewFetter.RefreshAllGridProxies();
	}

	// Token: 0x0600E59F RID: 58783 RVA: 0x003E0ACC File Offset: 0x003DECCC
	public void InitScrollViewByCommonTypeItem(List<List<HandBookCommonItemData>> handBookCommonTypeItemDataList)
	{
		this.HandBookCommonTypeItemDataList = handBookCommonTypeItemDataList;
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(7);
		scrollViewWithScrollbar.RootUIComp.Get().SetUIActive(true);
		if (this.ScrollViewCommonType == null)
		{
			this.ScrollViewCommonType = new GenericScrollView<HandBookCommonTypeItem>(scrollViewWithScrollbar, new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<HandBookCommonTypeItem>(this.InitHandBookCommonTypeItem), null);
		}
		this.ScrollViewCommonType.RefreshByData<List<HandBookCommonItemData>>(this.HandBookCommonTypeItemDataList, null);
	}

	// Token: 0x0600E5A0 RID: 58784 RVA: 0x003E0B37 File Offset: 0x003DED37
	protected virtual HandBookCommonItem InitHandBookCommonItem()
	{
		return new HandBookCommonItem();
	}

	// Token: 0x0600E5A1 RID: 58785 RVA: 0x003E0B3E File Offset: 0x003DED3E
	protected virtual HandBookFetterItem InitHandBookFetterItem()
	{
		return new HandBookFetterItem();
	}

	// Token: 0x0600E5A2 RID: 58786 RVA: 0x003E0B48 File Offset: 0x003DED48
	protected ILayoutItem<HandBookCommonTypeItem> InitHandBookCommonTypeItem(object data, UUIItem uiItem, int index)
	{
		HandBookCommonTypeItem handBookCommonTypeItem = new HandBookCommonTypeItem();
		handBookCommonTypeItem.Initialize(null);
		return new LayoutItem<HandBookCommonTypeItem>
		{
			Key = index,
			Value = handBookCommonTypeItem
		};
	}

	// Token: 0x0600E5A3 RID: 58787 RVA: 0x003E0B7A File Offset: 0x003DED7A
	private PhantomFetter GetPhantomFetterData(int gridIndex)
	{
		return this.PhantomFetterDataList[gridIndex];
	}

	// Token: 0x0600E5A4 RID: 58788 RVA: 0x003E0B88 File Offset: 0x003DED88
	private HandBookCommonItemData GetHandBookCommonItemData(int gridIndex)
	{
		return this.HandBookCommonItemDataList[gridIndex];
	}

	// Token: 0x0600E5A5 RID: 58789 RVA: 0x003E0B96 File Offset: 0x003DED96
	protected void SetNameText(string name)
	{
		UUIText text = base.GetText(9);
		text.SetUIActive(true);
		text.SetText(name, true);
	}

	// Token: 0x0600E5A6 RID: 58790 RVA: 0x003E0BAE File Offset: 0x003DEDAE
	protected void SetTypeText(string type)
	{
		UUIText text = base.GetText(10);
		text.SetUIActive(true);
		text.SetText(type, true);
	}

	// Token: 0x0600E5A7 RID: 58791 RVA: 0x003E0BC6 File Offset: 0x003DEDC6
	protected void SetDescribeText(string describe)
	{
		UUIText text = base.GetText(11);
		text.SetUIActive(true);
		text.SetText(describe, true);
	}

	// Token: 0x0600E5A8 RID: 58792 RVA: 0x003E0BE0 File Offset: 0x003DEDE0
	protected void InitInfoItemLayout(List<string> infoList)
	{
		this.InfoTextList = infoList;
		UUIVerticalLayout verticalLayout = base.GetVerticalLayout(12);
		verticalLayout.RootUIComp.Get().SetUIActive(true);
		if (this.InfoItemLayout == null)
		{
			UUILayoutBase layout = verticalLayout;
			CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<HandBookInfoTextItem> refreshFunction;
			if ((refreshFunction = HandBookBaseView.<>O.<0>__InitInfoItem) == null)
			{
				refreshFunction = (HandBookBaseView.<>O.<0>__InitInfoItem = new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<HandBookInfoTextItem>(HandBookBaseViewHelper.InitInfoItem));
			}
			this.InfoItemLayout = new GenericLayoutNew<HandBookInfoTextItem>(layout, refreshFunction, null);
		}
		this.InfoItemLayout.RebuildLayoutByDataNew<string>(this.InfoTextList, null);
	}

	// Token: 0x0600E5A9 RID: 58793 RVA: 0x003E0C5C File Offset: 0x003DEE5C
	protected void InitStarItemLayout(int starCount)
	{
		this.StarCount = starCount;
		UUIHorizontalLayout horizontalLayout = base.GetHorizontalLayout(14);
		horizontalLayout.RootUIComp.Get().SetUIActive(true);
		if (this.StarItemLayout == null)
		{
			this.StarItemLayout = new GenericLayoutNew<UiPanelBase>(horizontalLayout, null, null);
		}
		this.StarItemLayout.RebuildLayoutByDataNew<int>(null, new int?(this.StarCount));
	}

	// Token: 0x0600E5AA RID: 58794 RVA: 0x003E0CBC File Offset: 0x003DEEBC
	protected void InitContentItemLayout(List<HandBookContentItemData> contentTextList)
	{
		this.ContentTextList = contentTextList;
		UUIVerticalLayout verticalLayout = base.GetVerticalLayout(16);
		verticalLayout.RootUIComp.Get().SetUIActive(true);
		if (this.ContentItemLayout == null)
		{
			UUILayoutBase layout = verticalLayout;
			CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<HandBookContentItem> refreshFunction;
			if ((refreshFunction = HandBookBaseView.<>O.<1>__InitContentItem) == null)
			{
				refreshFunction = (HandBookBaseView.<>O.<1>__InitContentItem = new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<HandBookContentItem>(HandBookBaseViewHelper.InitContentItem));
			}
			this.ContentItemLayout = new GenericLayoutNew<HandBookContentItem>(layout, refreshFunction, null);
		}
		this.ContentItemLayout.RebuildLayoutByDataNew<HandBookContentItemData>(this.ContentTextList, null);
	}

	// Token: 0x0600E5AB RID: 58795 RVA: 0x003E0D38 File Offset: 0x003DEF38
	protected void InitAttributeLayout(List<CSharpScript.Game.Module.Common.AttributeData> attributeList)
	{
		base.GetVerticalLayout(19).RootUIComp.Get().SetUIActive(true);
		this.AttributeList = attributeList;
		this.AttributeLayout.RefreshByData(this.AttributeList, null, false);
	}

	// Token: 0x0600E5AC RID: 58796 RVA: 0x003E0D7C File Offset: 0x003DEF7C
	protected void InitHandBookPhantomLayout(List<HandBookCommonItemData> handBookCommonItemData)
	{
		UUIVerticalLayout verticalLayout = base.GetVerticalLayout(18);
		verticalLayout.RootUIComp.Get().SetUIActive(true);
		this.PhantomDataList = handBookCommonItemData;
		if (this.HandBookPhantomLayout == null)
		{
			this.HandBookPhantomLayout = new GenericLayoutNew<HandBookPhantomItem>(verticalLayout, new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<HandBookPhantomItem>(this.InitHandBookPhantom), null);
		}
		this.HandBookPhantomLayout.RebuildLayoutByDataNew<HandBookCommonItemData>(this.PhantomDataList, null);
	}

	// Token: 0x0600E5AD RID: 58797 RVA: 0x003E0DEC File Offset: 0x003DEFEC
	protected virtual ILayoutItem<HandBookPhantomItem> InitHandBookPhantom(object data, UUIItem uiItem, int index)
	{
		HandBookPhantomItem handBookPhantomItem = new HandBookPhantomItem();
		handBookPhantomItem.Initialize((HandBookCommonItemData)data, uiItem);
		handBookPhantomItem.BindToggleCallback(new THandBookPhantomItemToggleFunction(this.OnPhantomToggleClick));
		return new LayoutItem<HandBookPhantomItem>
		{
			Key = index,
			Value = handBookPhantomItem
		};
	}

	// Token: 0x0600E5AE RID: 58798 RVA: 0x003E0E38 File Offset: 0x003DF038
	protected void SetDateText(string time)
	{
		UUIText text = base.GetText(17);
		text.SetUIActive(true);
		Singleton<LguiUtil>.Instance.SetLocalText(text, "HandBookGet", new <>z__ReadOnlySingleElementList<object>(time));
	}

	// Token: 0x0600E5AF RID: 58799 RVA: 0x003E0E6C File Offset: 0x003DF06C
	protected void SetCollectText(int curCount, int totalCount)
	{
		base.GetText(23).SetUIActive(true);
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(23), "RoleExp", new <>z__ReadOnlyArray<object>(new object[]
		{
			curCount,
			totalCount
		}));
	}

	// Token: 0x0600E5B0 RID: 58800 RVA: 0x003E0EBB File Offset: 0x003DF0BB
	protected void SetOwnText(int count)
	{
		base.GetText(17).SetUIActive(true);
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(17), "HandBookItemHaveNum", new <>z__ReadOnlySingleElementList<object>(count));
	}

	// Token: 0x0600E5B1 RID: 58801 RVA: 0x003E0EED File Offset: 0x003DF0ED
	protected void SetKillText(int count)
	{
		base.GetText(17).SetUIActive(true);
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(17), "KillCount", new <>z__ReadOnlySingleElementList<object>(count));
	}

	// Token: 0x0600E5B2 RID: 58802 RVA: 0x003E0F1F File Offset: 0x003DF11F
	protected void SetLockState(bool isLock)
	{
		base.GetItem(21).SetUIActive(isLock);
		base.GetItem(20).SetUIActive(!isLock);
	}

	// Token: 0x0600E5B3 RID: 58803 RVA: 0x003E0F40 File Offset: 0x003DF140
	protected void SetLockText(string lockDesc)
	{
		base.GetText(24).SetText(lockDesc, true);
	}

	// Token: 0x0600E5B4 RID: 58804 RVA: 0x003E0F54 File Offset: 0x003DF154
	protected void SetItemTexture(string path)
	{
		UUITexture texture = base.GetTexture(25);
		texture.SetUIActive(true);
		base.SetTextureByPath(path, texture, null, null);
	}

	// Token: 0x0600E5B5 RID: 58805 RVA: 0x003E0F83 File Offset: 0x003DF183
	protected override void OnStart()
	{
	}

	// Token: 0x0600E5B6 RID: 58806 RVA: 0x003E0F85 File Offset: 0x003DF185
	protected override void OnAfterShow()
	{
	}

	// Token: 0x0600E5B7 RID: 58807 RVA: 0x003E0F87 File Offset: 0x003DF187
	protected void CloseClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600E5B8 RID: 58808 RVA: 0x003E0F90 File Offset: 0x003DF190
	protected override void OnBeforeDestroy()
	{
		if (this.ScrollViewCommon != null)
		{
			this.ScrollViewCommon.ClearGridProxies();
			this.ScrollViewCommon = null;
		}
		if (this.ScrollViewFetter != null)
		{
			this.ScrollViewFetter.ClearGridProxies();
			this.ScrollViewFetter = null;
		}
		if (this.ScrollViewCommonType != null)
		{
			this.ScrollViewCommonType.ClearChildren();
			this.ScrollViewCommonType = null;
		}
		if (this.InfoItemLayout != null)
		{
			this.InfoItemLayout.ClearChildren();
			this.InfoItemLayout = null;
		}
		if (this.ContentItemLayout != null)
		{
			this.ContentItemLayout.ClearChildren();
			this.ContentItemLayout = null;
		}
		if (this.StarItemLayout != null)
		{
			this.StarItemLayout.ClearChildren();
			this.StarItemLayout = null;
		}
		if (this.TabComponent != null)
		{
			this.TabComponent.Destroy(null);
			this.TabComponent = null;
		}
		if (this.HandBookPhantomLayout != null)
		{
			this.HandBookPhantomLayout.ClearChildren();
			this.HandBookPhantomLayout = null;
		}
		this.TabList = new List<CommonTabData>();
		this.OnToggleCallBack = null;
		this.OnPhantomToggleCallBack = null;
		this.CommonTabTitle = null;
		this.HandBookCommonItemDataList = new List<HandBookCommonItemData>();
		this.PhantomFetterDataList = new List<PhantomFetter>();
		this.HandBookCommonTypeItemDataList = new List<List<HandBookCommonItemData>>();
		this.InfoTextList = new List<string>();
		this.ContentTextList = new List<HandBookContentItemData>();
		this.AttributeList = new List<CSharpScript.Game.Module.Common.AttributeData>();
		this.PhantomDataList = new List<HandBookCommonItemData>();
		this.StarCount = 0;
	}

	// Token: 0x04006E93 RID: 28307
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected TabComponent<CommonTabItem> TabComponent;

	// Token: 0x04006E94 RID: 28308
	protected List<CommonTabData> TabList;

	// Token: 0x04006E95 RID: 28309
	[Nullable(2)]
	protected Action<int> OnToggleCallBack;

	// Token: 0x04006E96 RID: 28310
	[Nullable(2)]
	protected Action<PhantomItem> OnPhantomToggleCallBack;

	// Token: 0x04006E97 RID: 28311
	[Nullable(2)]
	protected CommonTabTitle CommonTabTitle;

	// Token: 0x04006E98 RID: 28312
	protected List<HandBookCommonItemData> HandBookCommonItemDataList;

	// Token: 0x04006E99 RID: 28313
	protected List<PhantomFetter> PhantomFetterDataList;

	// Token: 0x04006E9A RID: 28314
	protected List<List<HandBookCommonItemData>> HandBookCommonTypeItemDataList;

	// Token: 0x04006E9B RID: 28315
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected LoopScrollView<HandBookCommonItem, HandBookCommonItemData> ScrollViewCommon;

	// Token: 0x04006E9C RID: 28316
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected LoopScrollView<HandBookFetterItem, PhantomFetter> ScrollViewFetter;

	// Token: 0x04006E9D RID: 28317
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected GenericScrollView<HandBookCommonTypeItem> ScrollViewCommonType;

	// Token: 0x04006E9E RID: 28318
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected GenericLayoutNew<HandBookInfoTextItem> InfoItemLayout;

	// Token: 0x04006E9F RID: 28319
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected GenericLayoutNew<HandBookContentItem> ContentItemLayout;

	// Token: 0x04006EA0 RID: 28320
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected GenericLayoutNew<UiPanelBase> StarItemLayout;

	// Token: 0x04006EA1 RID: 28321
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected GenericLayoutNew<HandBookPhantomItem> HandBookPhantomLayout;

	// Token: 0x04006EA2 RID: 28322
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected GenericLayout<AttributeItem, CSharpScript.Game.Module.Common.AttributeData> AttributeLayout;

	// Token: 0x04006EA3 RID: 28323
	protected List<string> InfoTextList;

	// Token: 0x04006EA4 RID: 28324
	protected List<HandBookContentItemData> ContentTextList;

	// Token: 0x04006EA5 RID: 28325
	protected List<CSharpScript.Game.Module.Common.AttributeData> AttributeList;

	// Token: 0x04006EA6 RID: 28326
	protected List<HandBookCommonItemData> PhantomDataList;

	// Token: 0x04006EA7 RID: 28327
	protected int StarCount;

	// Token: 0x020081B1 RID: 33201
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x0402C04D RID: 180301
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<HandBookInfoTextItem> <0>__InitInfoItem;

		// Token: 0x0402C04E RID: 180302
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<HandBookContentItem> <1>__InitContentItem;
	}
}
