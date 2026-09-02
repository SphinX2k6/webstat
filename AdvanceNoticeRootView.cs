using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001196 RID: 4502
[NullableContext(1)]
[Nullable(0)]
public class AdvanceNoticeRootView : UiViewBase
{
	// Token: 0x06007661 RID: 30305 RVA: 0x001EFCE5 File Offset: 0x001EDEE5
	public AdvanceNoticeRootView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06007662 RID: 30306 RVA: 0x001EFCF0 File Offset: 0x001EDEF0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(8, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(6, new Action(this.OnLeftArrowButtonClick)),
			new ValueTuple<int, Delegate>(7, new Action(this.OnRightArrowButtonClick))
		};
	}

	// Token: 0x06007663 RID: 30307 RVA: 0x001EFE0C File Offset: 0x001EE00C
	protected override UniTask OnBeforeStartAsync()
	{
		AdvanceNoticeRootView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<AdvanceNoticeRootView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007664 RID: 30308 RVA: 0x001EFE50 File Offset: 0x001EE050
	protected override void OnBeforeShow()
	{
		this.HideArrow();
		this.HasTabScrollFirstLateUpdate = false;
		int num = this.ViewModel.TabIndex;
		if (num == 0 || num == -1)
		{
			num = 0;
		}
		this.TabComponent.LateScrollToToggleByIndex(num);
	}

	// Token: 0x06007665 RID: 30309 RVA: 0x001EFE8C File Offset: 0x001EE08C
	protected void InitTabComponent()
	{
		CommonTabComponentData<AdvanceNoticeTabItem> data = new CommonTabComponentData<AdvanceNoticeTabItem>(new Func<UUIItem, int?, AdvanceNoticeTabItem>(this.ProxyCreate), new Action<int>(this.ToggleCallBack), new Func<int, CommonTabData>(this.GetCommonData));
		this.TabComponent = new TabComponentWithCaptionItem<AdvanceNoticeTabItem>(base.GetItem(0), data, new Action(this.OnCloseClicked), false);
		this.TabComponent.SetHelpButtonShowState(false);
		this.TabViewComponent = new TabViewComponent<AdvanceNoticeViewModel>(base.GetItem(1), EKeyMode.Default);
	}

	// Token: 0x06007666 RID: 30310 RVA: 0x001EFF04 File Offset: 0x001EE104
	private UniTask InitTabListAsync()
	{
		AdvanceNoticeRootView.<InitTabListAsync>d__11 <InitTabListAsync>d__;
		<InitTabListAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitTabListAsync>d__.<>4__this = this;
		<InitTabListAsync>d__.<>1__state = -1;
		<InitTabListAsync>d__.<>t__builder.Start<AdvanceNoticeRootView.<InitTabListAsync>d__11>(ref <InitTabListAsync>d__);
		return <InitTabListAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007667 RID: 30311 RVA: 0x001EFF47 File Offset: 0x001EE147
	private AdvanceNoticeTabItem ProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new AdvanceNoticeTabItem();
	}

	// Token: 0x06007668 RID: 30312 RVA: 0x001EFF50 File Offset: 0x001EE150
	private void ToggleCallBack(int index)
	{
		AdvanceNoticeTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(index);
		int id = this.ViewModel.TabList[index];
		AdvertisingTabInfo advertisingTabInfoById = ConfigBase<AdvanceNoticeConfig>.Instance.GetAdvertisingTabInfoById(id);
		EUiTabViewName viewName = AdvanceNoticeDefine.advanceNoticeTabTypeToTabViewName[(EAdvanceNoticeTabType)advertisingTabInfoById.Type];
		this.ViewModel.UpdateTabDataOnTabChange(index);
		this.TabViewComponent.ToggleCallBack(this.ViewModel, viewName, tabItemByIndex, null, null);
		this.AdvanceNoticeSwitchComponent.Refresh(this.ViewModel);
		AdvanceNoticeViewModel viewModel = this.ViewModel;
		if (viewModel == null)
		{
			return;
		}
		viewModel.ClickTabLogEvent();
	}

	// Token: 0x06007669 RID: 30313 RVA: 0x001EFFE8 File Offset: 0x001EE1E8
	private CommonTabData GetCommonData(int index)
	{
		int id = this.ViewModel.TabList[index];
		AdvertisingTabInfo advertisingTabInfoById = ConfigBase<AdvanceNoticeConfig>.Instance.GetAdvertisingTabInfoById(id);
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("AdvanceNoticeTitleIcon");
		CommonTabData commonTabData = new CommonTabData(advertisingTabInfoById.TabIcon, new CommonTabTitleData("Advertising_SubTitle", Array.Empty<object>()), new CommonTabTitleData(advertisingTabInfoById.TabTitle, Array.Empty<object>()));
		commonTabData.SetSmallIcon(resourcePath);
		return commonTabData;
	}

	// Token: 0x0600766A RID: 30314 RVA: 0x001F0058 File Offset: 0x001EE258
	private void OnSwitchSubTab(int subTabIndex)
	{
		AdvanceNoticeTabViewBase advanceNoticeTabViewBase = this.TabViewComponent.GetTabViewByTabKey(this.ViewModel.CurrentTabView, null) as AdvanceNoticeTabViewBase;
		if (advanceNoticeTabViewBase != null)
		{
			advanceNoticeTabViewBase.OnSwitchSubTab(subTabIndex);
		}
	}

	// Token: 0x0600766B RID: 30315 RVA: 0x001F0094 File Offset: 0x001EE294
	private void OnCloseClicked()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600766C RID: 30316 RVA: 0x001F009D File Offset: 0x001EE29D
	private void OnLeftArrowButtonClick()
	{
		this.AdvanceNoticeSwitchComponent.SelectPreviousThumb();
	}

	// Token: 0x0600766D RID: 30317 RVA: 0x001F00AA File Offset: 0x001EE2AA
	private void OnRightArrowButtonClick()
	{
		this.AdvanceNoticeSwitchComponent.SelectNextThumb();
	}

	// Token: 0x0600766E RID: 30318 RVA: 0x001F00B7 File Offset: 0x001EE2B7
	private void OnTabScrollValueChange(FVector2D _)
	{
		if (!this.HasTabScrollFirstLateUpdate)
		{
			return;
		}
		this.RefreshArrow();
	}

	// Token: 0x0600766F RID: 30319 RVA: 0x001F00C8 File Offset: 0x001EE2C8
	private void OnTabScrollLateUpdate(float _)
	{
		if (!this.HasTabScrollFirstLateUpdate)
		{
			this.RefreshArrow();
			this.HasTabScrollFirstLateUpdate = true;
		}
	}

	// Token: 0x06007670 RID: 30320 RVA: 0x001F00E0 File Offset: 0x001EE2E0
	private void RefreshArrow()
	{
		int count = this.ViewModel.TabList.Count;
		if (this.TabComponent == null || count <= 0)
		{
			this.HideArrow();
			return;
		}
		UUIScrollViewWithScrollbarComponent scrollView = this.TabComponent.GetScrollView();
		AdvanceNoticeTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(0);
		UUIItem uuiitem = (tabItemByIndex != null) ? tabItemByIndex.GetRootItem() : null;
		AdvanceNoticeTabItem tabItemByIndex2 = this.TabComponent.GetTabItemByIndex(count - 1);
		UUIItem uuiitem2 = (tabItemByIndex2 != null) ? tabItemByIndex2.GetRootItem() : null;
		if (uuiitem == null || uuiitem2 == null)
		{
			this.HideArrow();
			return;
		}
		EOutOfBoundsType eoutOfBoundsType = EOutOfBoundsType.EOutOfBoundsType_MAX;
		EOutOfBoundsType eoutOfBoundsType2 = EOutOfBoundsType.EOutOfBoundsType_MAX;
		scrollView.GetOutOfBottomBoundsType(uuiitem, ref eoutOfBoundsType, ref eoutOfBoundsType2, 0.1f);
		EOutOfBoundsType eoutOfBoundsType3 = EOutOfBoundsType.EOutOfBoundsType_MAX;
		EOutOfBoundsType eoutOfBoundsType4 = EOutOfBoundsType.EOutOfBoundsType_MAX;
		scrollView.GetOutOfBottomBoundsType(uuiitem2, ref eoutOfBoundsType3, ref eoutOfBoundsType4, 0.1f);
		base.GetItem(2).SetUIActive(eoutOfBoundsType == EOutOfBoundsType.OutOfBegin);
		base.GetItem(3).SetUIActive(eoutOfBoundsType3 == EOutOfBoundsType.OutOfEnd);
	}

	// Token: 0x06007671 RID: 30321 RVA: 0x001F01AC File Offset: 0x001EE3AC
	private void HideArrow()
	{
		base.GetItem(2).SetUIActive(false);
		base.GetItem(3).SetUIActive(false);
	}

	// Token: 0x06007672 RID: 30322 RVA: 0x001F01C8 File Offset: 0x001EE3C8
	protected override void OnBeforeDestroy()
	{
		if (this.TabComponent != null)
		{
			this.TabComponent.Destroy(null);
			this.TabComponent = null;
		}
	}

	// Token: 0x0400394A RID: 14666
	[Nullable(2)]
	protected AdvanceNoticeViewModel ViewModel;

	// Token: 0x0400394B RID: 14667
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected TabComponentWithCaptionItem<AdvanceNoticeTabItem> TabComponent;

	// Token: 0x0400394C RID: 14668
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected TabViewComponent<AdvanceNoticeViewModel> TabViewComponent;

	// Token: 0x0400394D RID: 14669
	[Nullable(2)]
	protected AdvanceNoticeSwitchComponent AdvanceNoticeSwitchComponent;

	// Token: 0x0400394E RID: 14670
	protected bool HasTabScrollFirstLateUpdate;

	// Token: 0x020074F2 RID: 29938
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x04028605 RID: 165381
		public const int CaptionItem = 0;

		// Token: 0x04028606 RID: 165382
		public const int ContentRootItem = 1;

		// Token: 0x04028607 RID: 165383
		public const int ArrowUpItem = 2;

		// Token: 0x04028608 RID: 165384
		public const int ArrowDownItem = 3;

		// Token: 0x04028609 RID: 165385
		public const int ThumbScrollView = 4;

		// Token: 0x0402860A RID: 165386
		public const int ThumbItem = 5;

		// Token: 0x0402860B RID: 165387
		public const int LeftArrowButton = 6;

		// Token: 0x0402860C RID: 165388
		public const int RightArrowButton = 7;

		// Token: 0x0402860D RID: 165389
		public const int ReminderText = 8;
	}
}
