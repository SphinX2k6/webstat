using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001EA6 RID: 7846
[NullableContext(1)]
[Nullable(0)]
public class PhantomHandBookView : HandBookBaseView
{
	// Token: 0x0600E7F3 RID: 59379 RVA: 0x003EB0CC File Offset: 0x003E92CC
	public PhantomHandBookView(UiViewInfo viewInfo) : base(viewInfo)
	{
		this.PhantomHandBookPageList = new List<PhantomHandBookPage>();
		this.HandBookFetterItemList = new List<HandBookFetterItem>();
		this.HandBookPhantomItemList = new List<HandBookPhantomItem>();
		this.HandBookCommonItemList = new List<HandBookCommonItem>();
	}

	// Token: 0x0600E7F4 RID: 59380 RVA: 0x003EB101 File Offset: 0x003E9301
	protected override void OnStart()
	{
		base.SetDefaultState();
		this.Refresh();
	}

	// Token: 0x0600E7F5 RID: 59381 RVA: 0x003EB110 File Offset: 0x003E9310
	protected override void OnAfterShow()
	{
		this.UiCameraHandleData = Singleton<UiCameraAnimationManager>.Instance.PushCameraHandleByHandleName("1062", false, false, "1001", false, null, null);
	}

	// Token: 0x0600E7F6 RID: 59382 RVA: 0x003EB144 File Offset: 0x003E9344
	private void OnHandBookDataUpdate(EHandBookTabType eHandBookTabType, int i)
	{
		this.Refresh();
	}

	// Token: 0x0600E7F7 RID: 59383 RVA: 0x003EB14C File Offset: 0x003E934C
	protected void Refresh()
	{
		this.RefreshTabComponent();
		this.RefreshPhantomTitle();
		this.RefreshPhantom();
		this.RefreshCollectText();
		this.RefreshLockText();
	}

	// Token: 0x0600E7F8 RID: 59384 RVA: 0x003EB16C File Offset: 0x003E936C
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnHandBookDataInit, new Action(this.Refresh));
		Singleton<EventSystem>.Instance.Add<EHandBookTabType, int>(EEventName.OnHandBookDataUpdate, new Action<EHandBookTabType, int>(this.OnHandBookDataUpdate));
		Singleton<EventSystem>.Instance.Add(EEventName.OnHandBookRead, new Action<EHandBookTabType, int>(this.OnHandBookRead));
	}

	// Token: 0x0600E7F9 RID: 59385 RVA: 0x003EB1D0 File Offset: 0x003E93D0
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHandBookDataInit, new Action(this.Refresh));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHandBookDataUpdate, new Action<EHandBookTabType, int>(this.OnHandBookDataUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHandBookRead, new Action<EHandBookTabType, int>(this.OnHandBookRead));
	}

	// Token: 0x0600E7FA RID: 59386 RVA: 0x003EB234 File Offset: 0x003E9434
	protected void OnHandBookRead(EHandBookTabType type, int id)
	{
		if (type != EHandBookTabType.Phantom)
		{
			return;
		}
		int count = this.HandBookCommonItemList.Count;
		for (int i = 0; i < count; i++)
		{
			HandBookCommonItem handBookCommonItem = this.HandBookCommonItemList[i];
			HandBookCommonItemData data = handBookCommonItem.GetData();
			PhantomHandBook? phantomHandBook = data.Config as PhantomHandBook?;
			if (phantomHandBook != null && phantomHandBook.Value.Id == id)
			{
				data.IsNew = false;
				handBookCommonItem.SetNewFlagVisible(new bool?(false));
				return;
			}
		}
	}

	// Token: 0x0600E7FB RID: 59387 RVA: 0x003EB2B4 File Offset: 0x003E94B4
	protected void TabToggleCallBack(int index)
	{
		base.SetDefaultState();
		base.GetItem(0).SetUIActive(true);
		int id = this.PhantomHandBookPageList[index].Id;
		this.PageType = new EPhantomHandBookPageType?((EPhantomHandBookPageType)id);
		if (id == 0)
		{
			this.RefreshPhantomTitle();
			this.RefreshPhantom();
			return;
		}
		this.RefreshPhantomFetterTitle();
		this.RefreshPhantomFetter();
	}

	// Token: 0x0600E7FC RID: 59388 RVA: 0x003EB314 File Offset: 0x003E9514
	protected override HandBookCommonItem InitHandBookCommonItem()
	{
		HandBookCommonItem handBookCommonItem = new HandBookCommonItem();
		this.HandBookCommonItemList.Add(handBookCommonItem);
		handBookCommonItem.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.OnToggleClick));
		return handBookCommonItem;
	}

	// Token: 0x0600E7FD RID: 59389 RVA: 0x003EB348 File Offset: 0x003E9548
	protected void OnToggleClick(MediumItemGridExtendCallback callbackParameter)
	{
		HandBookCommonItemData handBookCommonItemData = callbackParameter.Data as HandBookCommonItemData;
		int gridIndex = (callbackParameter.MediumItemGrid as HandBookCommonItem).GridIndex;
		this.ScrollViewCommon.DeselectCurrentGridProxy(false);
		this.ScrollViewCommon.SelectGridProxy(gridIndex, false);
		this.ScrollViewCommon.RefreshGridProxy(gridIndex);
		if (handBookCommonItemData.IsLock)
		{
			base.SetLockState(true);
			return;
		}
		base.SetLockState(false);
		this.RefreshPhantomContent(handBookCommonItemData);
	}

	// Token: 0x0600E7FE RID: 59390 RVA: 0x003EB3B8 File Offset: 0x003E95B8
	protected void RefreshPhantomContent(HandBookCommonItemData handBookCommonItemData)
	{
		if (this.PageType.GetValueOrDefault() == EPhantomHandBookPageType.PhantomFetter)
		{
			return;
		}
		base.GetVerticalLayout(18).RootUIComp.Get().SetUIActive(false);
		PhantomHandBook? phantomHandBook = handBookCommonItemData.Config as PhantomHandBook?;
		HandBookEntry handBookInfo = ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Phantom, phantomHandBook.Value.Id);
		if (handBookInfo != null)
		{
			base.SetDateText(handBookInfo.CreateTime);
		}
		if (handBookCommonItemData.IsNew)
		{
			ControllerBase<HandBookController>.Instance.SendIllustratedReadRequest(EHandBookTabType.Phantom, phantomHandBook.Value.Id);
		}
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(phantomHandBook.Value.Name, null);
		string localTextNew2 = ConfigMultiTextLang.GetLocalTextNew(phantomHandBook.Value.TypeDescrtption, null);
		string localTextNew3 = ConfigMultiTextLang.GetLocalTextNew(phantomHandBook.Value.Intensity, null);
		List<string> list = new List<string>();
		if (localTextNew3 != null)
		{
			list.Add(localTextNew3);
		}
		if (localTextNew2 != null)
		{
			list.Add(localTextNew2);
		}
		if (localTextNew != null)
		{
			base.SetNameText(localTextNew);
		}
		base.InitInfoItemLayout(list);
		ControllerBase<HandBookController>.Instance.SetPhantomMeshShow(phantomHandBook.Value.Id, this.SkeletalObserverHandle);
		List<HandBookContentItemData> list2 = new List<HandBookContentItemData>();
		string localTextNew4 = ConfigMultiTextLang.GetLocalTextNew(phantomHandBook.Value.Title1, null);
		string localTextNew5 = ConfigMultiTextLang.GetLocalTextNew(phantomHandBook.Value.Descrtption1, null);
		string localTextNew6 = ConfigMultiTextLang.GetLocalTextNew(phantomHandBook.Value.Title2, null);
		string localTextNew7 = ConfigMultiTextLang.GetLocalTextNew(phantomHandBook.Value.Descrtption2, null);
		if (localTextNew4 != null && localTextNew5 != null)
		{
			list2.Add(new HandBookContentItemData(localTextNew4, localTextNew5));
		}
		if (localTextNew6 != null && localTextNew7 != null)
		{
			list2.Add(new HandBookContentItemData(localTextNew6, localTextNew7));
		}
		base.InitContentItemLayout(list2);
	}

	// Token: 0x0600E7FF RID: 59391 RVA: 0x003EB588 File Offset: 0x003E9788
	protected void RefreshPhantom()
	{
		this.RefreshCollectText();
		base.GetItem(26).SetUIActive(true);
		IReadOnlyList<PhantomHandBook> phantomHandBookConfig = ConfigBase<HandBookConfig>.Instance.GetPhantomHandBookConfig();
		List<HandBookCommonItemData> list = new List<HandBookCommonItemData>();
		int num = (phantomHandBookConfig != null) ? phantomHandBookConfig.Count : 0;
		for (int i = 0; i < num; i++)
		{
			PhantomHandBook phantomHandBook = phantomHandBookConfig[i];
			HandBookCommonItemData handBookCommonItemData = new HandBookCommonItemData();
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(phantomHandBook.TypeDescrtption, null);
			if (localTextNew != null)
			{
				handBookCommonItemData.Title = localTextNew;
			}
			IReadOnlyList<PhantomItem> phantomItemConfigListByMonsterId = ConfigBase<InventoryConfig>.Instance.GetPhantomItemConfigListByMonsterId(phantomHandBook.Id);
			if (phantomItemConfigListByMonsterId != null && phantomItemConfigListByMonsterId.Count > 0)
			{
				PhantomItem phantomItem = phantomItemConfigListByMonsterId[0];
				HandBookEntry handBookInfo = ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Phantom, phantomItem.MonsterId);
				bool isLock = handBookInfo == null;
				bool isNew = handBookInfo != null && !handBookInfo.IsRead;
				handBookCommonItemData.Icon = phantomItem.IconSmall;
				handBookCommonItemData.Config = phantomHandBook;
				handBookCommonItemData.IsLock = isLock;
				handBookCommonItemData.IsNew = isNew;
				list.Add(handBookCommonItemData);
			}
		}
		this.HandBookCommonItemList = new List<HandBookCommonItem>();
		base.InitScrollViewByCommonItem(list);
	}

	// Token: 0x0600E800 RID: 59392 RVA: 0x003EB6A6 File Offset: 0x003E98A6
	protected override CommonTabItem TabItemProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new CommonTabItem();
	}

	// Token: 0x0600E801 RID: 59393 RVA: 0x003EB6B0 File Offset: 0x003E98B0
	public override List<CommonTabItemData> GetTabItemData(List<CommonTabData> tabData)
	{
		int count = tabData.Count;
		List<CommonTabItemData> list = new List<CommonTabItemData>();
		for (int i = 0; i < count; i++)
		{
			CommonTabItemData commonTabItemData = new CommonTabItemData();
			commonTabItemData.Index = i;
			if (i == 0)
			{
				commonTabItemData.RedDotName = new ERedDotName?(ERedDotName.PhantomHandBook);
			}
			commonTabItemData.Data = this.TabList[i];
			list.Add(commonTabItemData);
		}
		return list;
	}

	// Token: 0x0600E802 RID: 59394 RVA: 0x003EB710 File Offset: 0x003E9910
	protected void RefreshCollectText()
	{
		int[] collectProgress = ControllerBase<HandBookController>.Instance.GetCollectProgress(EHandBookTabType.Phantom);
		base.SetCollectText(collectProgress[0], collectProgress[1]);
	}

	// Token: 0x0600E803 RID: 59395 RVA: 0x003EB738 File Offset: 0x003E9938
	protected void RefreshLockText()
	{
		string textById = ConfigBase<TextConfig>.Instance.GetTextById("PhantomHandBookLock");
		if (textById != null)
		{
			base.SetLockText(textById);
		}
	}

	// Token: 0x0600E804 RID: 59396 RVA: 0x003EB760 File Offset: 0x003E9960
	protected void RefreshTabComponent()
	{
		this.PhantomHandBookPageList = ConfigCommon.ToList<PhantomHandBookPage>(ConfigBase<HandBookConfig>.Instance.GetPhantomHandBookPageConfig());
		this.PhantomHandBookPageList.Sort(new Comparison<PhantomHandBookPage>(this.SortIndex));
		int count = this.PhantomHandBookPageList.Count;
		List<CommonTabData> list = new List<CommonTabData>();
		for (int i = 0; i < count; i++)
		{
			list.Add(new CommonTabData(this.PhantomHandBookPageList[i].Icon, null, null));
		}
		base.InitTabComponent(list);
		base.SetTabToggleCallBack(new Action<int>(this.TabToggleCallBack));
	}

	// Token: 0x0600E805 RID: 59397 RVA: 0x003EB7F4 File Offset: 0x003E99F4
	protected void RefreshPhantomTitle()
	{
		HandBookEntrance? handBookEntranceConfig = ConfigBase<HandBookConfig>.Instance.GetHandBookEntranceConfig(EHandBookTabType.Phantom);
		base.InitCommonTabTitle(handBookEntranceConfig.Value.TitleIcon, new CommonTabTitleData(handBookEntranceConfig.Value.Name, Array.Empty<object>()));
	}

	// Token: 0x0600E806 RID: 59398 RVA: 0x003EB83C File Offset: 0x003E9A3C
	protected void RefreshPhantomFetterTitle()
	{
		string textContentIdById = ConfigBase<TextConfig>.Instance.GetTextContentIdById("Fetter");
		HandBookEntrance? handBookEntranceConfig = ConfigBase<HandBookConfig>.Instance.GetHandBookEntranceConfig(EHandBookTabType.Phantom);
		if (textContentIdById != null)
		{
			base.InitCommonTabTitle(handBookEntranceConfig.Value.TitleIcon, new CommonTabTitleData(textContentIdById, Array.Empty<object>()));
		}
	}

	// Token: 0x0600E807 RID: 59399 RVA: 0x003EB888 File Offset: 0x003E9A88
	private int SortIndex(PhantomHandBookPage a, PhantomHandBookPage b)
	{
		return a.Id - b.Id;
	}

	// Token: 0x0600E808 RID: 59400 RVA: 0x003EB89C File Offset: 0x003E9A9C
	protected void RefreshPhantomFetter()
	{
		base.GetItem(26).SetUIActive(true);
		base.GetText(23).SetUIActive(false);
		IReadOnlyList<PhantomFetterHandBook> phantomFetterHandBookConfig = ConfigBase<HandBookConfig>.Instance.GetPhantomFetterHandBookConfig();
		List<PhantomFetter> list = new List<PhantomFetter>();
		int num = (phantomFetterHandBookConfig != null) ? phantomFetterHandBookConfig.Count : 0;
		for (int i = 0; i < num; i++)
		{
			PhantomFetterHandBook phantomFetterHandBook = phantomFetterHandBookConfig[i];
			PhantomFetter phantomFetterById = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomFetterById(phantomFetterHandBook.Id);
			list.Add(phantomFetterById);
		}
		this.HandBookFetterItemList = new List<HandBookFetterItem>();
		base.InitScrollViewByFetterItem(list);
		this.InitToggleState();
		base.GetText(17).SetUIActive(false);
	}

	// Token: 0x0600E809 RID: 59401 RVA: 0x003EB93C File Offset: 0x003E9B3C
	protected void InitToggleState()
	{
		int count = this.HandBookFetterItemList.Count;
		for (int i = 0; i < count; i++)
		{
			HandBookFetterItem handBookFetterItem = this.HandBookFetterItemList[i];
			if (i == 0)
			{
				handBookFetterItem.SetToggleStateForce(EToggleState.ETT_Checked, false);
				handBookFetterItem.OnSelected(true);
			}
			else
			{
				handBookFetterItem.SetToggleStateForce(EToggleState.ETT_UnChecked, false);
			}
		}
	}

	// Token: 0x0600E80A RID: 59402 RVA: 0x003EB98C File Offset: 0x003E9B8C
	protected void RefreshHandBookPhantomLayout(PhantomFetter phantomFetter)
	{
		List<HandBookCommonItemData> handBookCommonItemData = new List<HandBookCommonItemData>();
		base.InitHandBookPhantomLayout(handBookCommonItemData);
		this.RefreshHandBookPhantomItemToggleState();
	}

	// Token: 0x0600E80B RID: 59403 RVA: 0x003EB9AC File Offset: 0x003E9BAC
	protected void RefreshHandBookPhantomItemToggleState()
	{
		int count = this.HandBookPhantomItemList.Count;
		if (count == 0)
		{
			return;
		}
		for (int i = 0; i < count; i++)
		{
			HandBookPhantomItem handBookPhantomItem = this.HandBookPhantomItemList[i];
			if (i == 0)
			{
				handBookPhantomItem.SetToggleStateForce(EToggleState.ETT_Checked, false);
				handBookPhantomItem.OnSelected(true);
			}
			else
			{
				handBookPhantomItem.SetToggleStateForce(EToggleState.ETT_UnChecked, false);
			}
		}
	}

	// Token: 0x0600E80C RID: 59404 RVA: 0x003EBA00 File Offset: 0x003E9C00
	protected override ILayoutItem<HandBookPhantomItem> InitHandBookPhantom(object data, UUIItem uiItem, int index)
	{
		HandBookPhantomItem handBookPhantomItem = new HandBookPhantomItem();
		handBookPhantomItem.Initialize((HandBookCommonItemData)data, uiItem);
		handBookPhantomItem.BindToggleCallback(new THandBookPhantomItemToggleFunction(this.OnPhantomToggleClick));
		this.HandBookPhantomItemList.Add(handBookPhantomItem);
		return new LayoutItem<HandBookPhantomItem>
		{
			Key = index,
			Value = handBookPhantomItem
		};
	}

	// Token: 0x0600E80D RID: 59405 RVA: 0x003EBA58 File Offset: 0x003E9C58
	protected override void OnPhantomToggleClick(HandBookCommonItemData handBookCommonItemData, int index)
	{
		EPhantomHandBookPageType? pageType = this.PageType;
		EPhantomHandBookPageType ephantomHandBookPageType = EPhantomHandBookPageType.Phantom;
		if (pageType.GetValueOrDefault() == ephantomHandBookPageType & pageType != null)
		{
			return;
		}
		PhantomItem? phantomItem = handBookCommonItemData.Config as PhantomItem?;
		base.SetLockState(false);
		if (handBookCommonItemData.IsNew)
		{
			ControllerBase<HandBookController>.Instance.SendIllustratedReadRequest(EHandBookTabType.Phantom, phantomItem.Value.ItemId);
		}
		PhantomHandBook? phantomHandBookConfigById = ConfigBase<HandBookConfig>.Instance.GetPhantomHandBookConfigById(phantomItem.Value.MonsterId);
		if (phantomHandBookConfigById == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Role, ELogAuthor.BB, "怪物id为:" + phantomItem.Value.MonsterId.ToString() + "对应声骸图鉴数据找不到！", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (!handBookCommonItemData.IsLock)
		{
			ControllerBase<HandBookController>.Instance.SetPhantomMeshShow(phantomHandBookConfigById.Value.Id, this.SkeletalObserverHandle);
		}
	}

	// Token: 0x0600E80E RID: 59406 RVA: 0x003EBB4C File Offset: 0x003E9D4C
	protected override HandBookFetterItem InitHandBookFetterItem()
	{
		HandBookFetterItem handBookFetterItem = new HandBookFetterItem();
		handBookFetterItem.BindFetterToggleCallback(new TFetterToggleFunction(this.OnFetterToggleClicked));
		this.HandBookFetterItemList.Add(handBookFetterItem);
		return handBookFetterItem;
	}

	// Token: 0x0600E80F RID: 59407 RVA: 0x003EBB80 File Offset: 0x003E9D80
	private void OnFetterToggleClicked(HandBookFetterItem handBookFetterItem)
	{
		int girdIndex = handBookFetterItem.GetGirdIndex();
		this.ScrollViewFetter.DeselectCurrentGridProxy(false);
		this.ScrollViewFetter.SelectGridProxy(girdIndex, false);
		this.ScrollViewFetter.RefreshGridProxy(girdIndex);
		PhantomFetter? phantomFetter = handBookFetterItem.GetPhantomFetter();
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(phantomFetter.Value.Name, null);
		if (localTextNew != null)
		{
			base.SetNameText(localTextNew);
		}
		this.RefreshPhantomFetterLayout(phantomFetter.Value);
		this.RefreshHandBookPhantomLayout(phantomFetter.Value);
	}

	// Token: 0x0600E810 RID: 59408 RVA: 0x003EBBFC File Offset: 0x003E9DFC
	protected void RefreshPhantomFetterLayout(PhantomFetter phantomFetter)
	{
		List<HandBookContentItemData> list = new List<HandBookContentItemData>();
		string textById = ConfigBase<TextConfig>.Instance.GetTextById("FetterEffectDescription");
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(phantomFetter.EffectDescription, null);
		string textById2 = ConfigBase<TextConfig>.Instance.GetTextById("FetterEffectDefineDescription");
		string localTextNew2 = ConfigMultiTextLang.GetLocalTextNew(phantomFetter.EffectDefineDescription, null);
		if (textById != null && localTextNew != null)
		{
			list.Add(new HandBookContentItemData(textById, localTextNew));
		}
		if (textById2 != null && localTextNew2 != null)
		{
			list.Add(new HandBookContentItemData(textById2, localTextNew2));
		}
		base.InitContentItemLayout(list);
	}

	// Token: 0x0600E811 RID: 59409 RVA: 0x003EBC7B File Offset: 0x003E9E7B
	protected override void OnBeforePlayCloseSequence()
	{
		if (this.UiCameraHandleData != null)
		{
			Singleton<UiCameraAnimationManager>.Instance.PopCameraHandle(this.UiCameraHandleData, null);
		}
	}

	// Token: 0x0600E812 RID: 59410 RVA: 0x003EBC96 File Offset: 0x003E9E96
	protected override void OnBeforeCreateImplementImplement()
	{
		Singleton<UiSceneManager>.Instance.InitPhantomObserver();
		this.SkeletalObserverHandle = Singleton<UiSceneManager>.Instance.GetPhantomObserver();
	}

	// Token: 0x0600E813 RID: 59411 RVA: 0x003EBCB2 File Offset: 0x003E9EB2
	protected override void OnBeforeDestroy()
	{
		Singleton<UiSceneManager>.Instance.DestroyPhantomObserver();
		this.SkeletalObserverHandle = null;
		this.PhantomHandBookPageList = new List<PhantomHandBookPage>();
		this.HandBookFetterItemList = new List<HandBookFetterItem>();
		this.HandBookPhantomItemList = new List<HandBookPhantomItem>();
		this.HandBookCommonItemList = new List<HandBookCommonItem>();
	}

	// Token: 0x04006FD8 RID: 28632
	private List<PhantomHandBookPage> PhantomHandBookPageList;

	// Token: 0x04006FD9 RID: 28633
	private List<HandBookFetterItem> HandBookFetterItemList;

	// Token: 0x04006FDA RID: 28634
	private List<HandBookPhantomItem> HandBookPhantomItemList;

	// Token: 0x04006FDB RID: 28635
	private List<HandBookCommonItem> HandBookCommonItemList;

	// Token: 0x04006FDC RID: 28636
	private EPhantomHandBookPageType? PageType;

	// Token: 0x04006FDD RID: 28637
	[Nullable(2)]
	private UiCameraHandleData UiCameraHandleData;

	// Token: 0x04006FDE RID: 28638
	[Nullable(2)]
	private SkeletalObserverHandle SkeletalObserverHandle;
}
