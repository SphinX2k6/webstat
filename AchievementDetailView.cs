using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.InputView;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02000FDC RID: 4060
[NullableContext(1)]
[Nullable(0)]
public class AchievementDetailView : UiViewBase
{
	// Token: 0x060068A1 RID: 26785 RVA: 0x001B4278 File Offset: 0x001B2478
	public AchievementDetailView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060068A2 RID: 26786 RVA: 0x001B428C File Offset: 0x001B248C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 11;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIDynScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060068A3 RID: 26787 RVA: 0x001B4424 File Offset: 0x001B2624
	protected override UniTask OnBeforeStartAsync()
	{
		AchievementDetailView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<AchievementDetailView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060068A4 RID: 26788 RVA: 0x001B4468 File Offset: 0x001B2668
	private UniTask RefreshTabRedPoint()
	{
		AchievementDetailView.<RefreshTabRedPoint>d__12 <RefreshTabRedPoint>d__;
		<RefreshTabRedPoint>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshTabRedPoint>d__.<>4__this = this;
		<RefreshTabRedPoint>d__.<>1__state = -1;
		<RefreshTabRedPoint>d__.<>t__builder.Start<AchievementDetailView.<RefreshTabRedPoint>d__12>(ref <RefreshTabRedPoint>d__);
		return <RefreshTabRedPoint>d__.<>t__builder.Task;
	}

	// Token: 0x060068A5 RID: 26789 RVA: 0x001B44AC File Offset: 0x001B26AC
	protected override void OnBeforeShow()
	{
		AchievementGroupData selectGroupData = ModelBase<AchievementModel>.Instance.CurrentSelectGroup;
		int index = ModelBase<AchievementModel>.Instance.GetAchievementCategoryGroups(ModelBase<AchievementModel>.Instance.CurrentSelectCategory.GetId(), true).FindIndex((AchievementGroupData groupData) => groupData == selectGroupData);
		this.ScrollToSelectGroup(index);
		AchievementCategoryData currentSelectCategory = ModelBase<AchievementModel>.Instance.CurrentSelectCategory;
		if (currentSelectCategory == null)
		{
			return;
		}
		int achievementCategoryIndex = ModelBase<AchievementModel>.Instance.GetAchievementCategoryIndex(currentSelectCategory);
		if (achievementCategoryIndex < 0)
		{
			return;
		}
		TabComponentWithCaptionItem<CommonTabItem> captionItem = this.CaptionItem;
		if (captionItem == null)
		{
			return;
		}
		captionItem.SelectToggleByIndex(achievementCategoryIndex, true);
	}

	// Token: 0x060068A6 RID: 26790 RVA: 0x001B4534 File Offset: 0x001B2734
	protected override void OnStart()
	{
		this.AchievementGroupTitleItem = new AchievementGroupTitleItem();
		this.AchievementGroupTitleItem.Initialize(base.GetItem(3));
		this.SearchComponent = new CommonSearchComponent(base.GetItem(7), new Action<string>(this.SearchResult), new Action(this.ResetSearch));
	}

	// Token: 0x060068A7 RID: 26791 RVA: 0x001B4588 File Offset: 0x001B2788
	private CommonTabItem TabItemProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new CommonTabItem();
	}

	// Token: 0x060068A8 RID: 26792 RVA: 0x001B4590 File Offset: 0x001B2790
	private void ToggleCallBack(int index)
	{
		AchievementCategoryData achievementCategoryData = this.AchievementCategoryDataList[index];
		ModelBase<AchievementModel>.Instance.CurrentSelectCategory = achievementCategoryData;
		ModelBase<AchievementModel>.Instance.AchievementSearchState = false;
		List<AchievementGroupData> achievementCategoryGroups = ModelBase<AchievementModel>.Instance.GetAchievementCategoryGroups(achievementCategoryData.GetId(), true);
		if (achievementCategoryGroups.Count <= 0)
		{
			return;
		}
		AchievementGroupData currentSelectGroup = ModelBase<AchievementModel>.Instance.CurrentSelectGroup;
		int num = achievementCategoryGroups.IndexOf(currentSelectGroup);
		AchievementGroupData currentSelectGroup2 = (num >= 0) ? achievementCategoryGroups[num] : achievementCategoryGroups[0];
		ModelBase<AchievementModel>.Instance.CurrentSelectGroup = currentSelectGroup2;
		base.GetText(10).SetText(achievementCategoryData.GetAchievementCategoryProgress(), true);
		this.ResetSearchComponent();
		this.RefreshViewTypeSearchType();
		this.RefreshGroupScroller();
		this.RefreshSearchingItem();
	}

	// Token: 0x060068A9 RID: 26793 RVA: 0x001B463D File Offset: 0x001B283D
	private void ScrollToSelectGroup(int index)
	{
		if (index < 0)
		{
			return;
		}
		this.AchievementGroupScroller.LateScrollTo(index);
	}

	// Token: 0x060068AA RID: 26794 RVA: 0x001B4650 File Offset: 0x001B2850
	private CommonTabData GetCommonData(int index)
	{
		AchievementCategoryData achievementCategoryData = this.AchievementCategoryDataList[index];
		return new CommonTabData(achievementCategoryData.GetSprite(), new CommonTabTitleData(achievementCategoryData.GetOrignalTitle(), Array.Empty<object>()), null);
	}

	// Token: 0x060068AB RID: 26795 RVA: 0x001B4686 File Offset: 0x001B2886
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnAchievementGroupChange, new Action(this.OnAchievementGroupChange));
		Singleton<EventSystem>.Instance.Add(EEventName.OnAchievementDataNotify, new Action(this.OnAchievementDataNotify));
	}

	// Token: 0x060068AC RID: 26796 RVA: 0x001B46C0 File Offset: 0x001B28C0
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAchievementGroupChange, new Action(this.OnAchievementGroupChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAchievementDataNotify, new Action(this.OnAchievementDataNotify));
	}

	// Token: 0x060068AD RID: 26797 RVA: 0x001B46FC File Offset: 0x001B28FC
	protected override void OnBeforeDestroy()
	{
		if (this.CaptionItem != null)
		{
			this.CaptionItem.Destroy(null);
			this.CaptionItem = null;
		}
		if (this.AchievementGroupTitleItem != null)
		{
			this.AchievementGroupTitleItem.Destroy(null);
			this.AchievementGroupTitleItem = null;
		}
		if (this.AchievementGroupDataItem != null)
		{
			this.AchievementGroupDataItem.Destroy(null);
			this.AchievementGroupDataItem = null;
		}
		if (this.AchievementSearchItem != null)
		{
			this.AchievementSearchItem.Destroy(null);
			this.AchievementSearchItem = null;
		}
		if (this.AchievementGroupScroller != null)
		{
			this.AchievementGroupScroller.ClearChildren();
		}
		if (this.AchievementGroupSmallDynItem != null)
		{
			this.AchievementGroupSmallDynItem.ClearItem();
			this.AchievementGroupSmallDynItem = null;
		}
		this.SearchComponent.Destroy(null);
	}

	// Token: 0x060068AE RID: 26798 RVA: 0x001B47AE File Offset: 0x001B29AE
	private void OnAchievementGroupChange()
	{
		this.RefreshViewTypeSearchType();
	}

	// Token: 0x060068AF RID: 26799 RVA: 0x001B47B6 File Offset: 0x001B29B6
	private void OnAchievementDataNotify()
	{
		ModelBase<AchievementModel>.Instance.RefreshSearchResult();
		this.RefreshViewTypeSearchType();
	}

	// Token: 0x060068B0 RID: 26800 RVA: 0x001B47C8 File Offset: 0x001B29C8
	private void SearchResult(string content)
	{
		ModelBase<AchievementModel>.Instance.CurrentSearchText = content;
		ModelBase<AchievementModel>.Instance.RefreshSearchResult();
		ModelBase<AchievementModel>.Instance.AchievementSearchState = !StringUtils.IsEmpty(content);
		this.RefreshViewTypeSearchType();
		this.RefreshSearchingItem();
		Singleton<EventSystem>.Instance.Emit(EEventName.OnGetAchievementSearchTextChange);
	}

	// Token: 0x060068B1 RID: 26801 RVA: 0x001B481C File Offset: 0x001B2A1C
	private void ResetSearch()
	{
		bool achievementSearchState = ModelBase<AchievementModel>.Instance.AchievementSearchState;
		ModelBase<AchievementModel>.Instance.AchievementSearchState = false;
		ModelBase<AchievementModel>.Instance.CurrentSearchText = "";
		if (achievementSearchState != ModelBase<AchievementModel>.Instance.AchievementSearchState)
		{
			this.RefreshViewTypeSearchType();
			this.RefreshGroupScroller();
		}
		this.RefreshSearchingItem();
		Singleton<EventSystem>.Instance.Emit(EEventName.OnGetAchievementSearchTextChange);
	}

	// Token: 0x060068B2 RID: 26802 RVA: 0x001B487B File Offset: 0x001B2A7B
	private void ResetSearchComponent()
	{
		CommonSearchComponent searchComponent = this.SearchComponent;
		if (searchComponent == null)
		{
			return;
		}
		searchComponent.ResetSearch(true);
	}

	// Token: 0x060068B3 RID: 26803 RVA: 0x001B4890 File Offset: 0x001B2A90
	private void RefreshGroupScroller()
	{
		AchievementModel instance = ModelBase<AchievementModel>.Instance;
		List<AchievementGroupData> achievementCategoryGroups = instance.GetAchievementCategoryGroups(instance.CurrentSelectCategory.GetId(), true);
		this.AchievementGroupScroller.RefreshByData(achievementCategoryGroups.ToArray(), false, false);
	}

	// Token: 0x060068B4 RID: 26804 RVA: 0x001B48C8 File Offset: 0x001B2AC8
	private void RefreshSearchingItem()
	{
		bool achievementSearchState = ModelBase<AchievementModel>.Instance.AchievementSearchState;
		bool searchResultIfNull = ModelBase<AchievementModel>.Instance.GetSearchResultIfNull();
		base.GetItem(2).SetUIActive(achievementSearchState && !searchResultIfNull);
	}

	// Token: 0x060068B5 RID: 26805 RVA: 0x001B4904 File Offset: 0x001B2B04
	private void RefreshViewTypeSearchType()
	{
		bool achievementSearchState = ModelBase<AchievementModel>.Instance.AchievementSearchState;
		this.AchievementGroupTitleItem.SetActive(!achievementSearchState);
		this.AchievementGroupDataItem.SetActive(!achievementSearchState);
		this.AchievementSearchItem.SetActive(achievementSearchState);
		base.GetUIDynScrollViewComponent(1).GetRootComponent().SetUIActive(!achievementSearchState);
		if (achievementSearchState)
		{
			bool searchResultIfNull = ModelBase<AchievementModel>.Instance.GetSearchResultIfNull();
			UUIItem item = base.GetItem(8);
			if (item != null)
			{
				item.SetUIActive(!searchResultIfNull);
			}
			UUIItem item2 = base.GetItem(9);
			if (item2 != null)
			{
				item2.SetUIActive(searchResultIfNull);
			}
			this.AchievementSearchItem.Update();
			return;
		}
		if (ModelBase<AchievementModel>.Instance.CurrentSelectGroup != null)
		{
			this.AchievementGroupTitleItem.Update(ModelBase<AchievementModel>.Instance.CurrentSelectGroup);
			this.AchievementGroupDataItem.Update(ModelBase<AchievementModel>.Instance.CurrentSelectGroup);
		}
		else
		{
			this.AchievementGroupTitleItem.SetActive(false);
		}
		UUIItem item3 = base.GetItem(8);
		if (item3 != null)
		{
			item3.SetUIActive(false);
		}
		UUIItem item4 = base.GetItem(9);
		if (item4 == null)
		{
			return;
		}
		item4.SetUIActive(false);
	}

	// Token: 0x060068B6 RID: 26806 RVA: 0x001B4A09 File Offset: 0x001B2C09
	private AchievementGroupSmallItem OnSmallItemCreate(AchievementGroupData data, UUIItem uiItem, int index)
	{
		return new AchievementGroupSmallItem();
	}

	// Token: 0x060068B7 RID: 26807 RVA: 0x001B4A10 File Offset: 0x001B2C10
	private void OnClickBackBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x040031CB RID: 12747
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TabComponentWithCaptionItem<CommonTabItem> CaptionItem;

	// Token: 0x040031CC RID: 12748
	[Nullable(2)]
	private AchievementSearchItem AchievementSearchItem;

	// Token: 0x040031CD RID: 12749
	[Nullable(2)]
	private AchievementGroupDataItem AchievementGroupDataItem;

	// Token: 0x040031CE RID: 12750
	[Nullable(2)]
	private AchievementGroupTitleItem AchievementGroupTitleItem;

	// Token: 0x040031CF RID: 12751
	[Nullable(2)]
	private AchievementGroupSmallDynItem AchievementGroupSmallDynItem;

	// Token: 0x040031D0 RID: 12752
	[Nullable(2)]
	private CommonSearchComponent SearchComponent;

	// Token: 0x040031D1 RID: 12753
	private List<AchievementCategoryData> AchievementCategoryDataList = new List<AchievementCategoryData>();

	// Token: 0x040031D2 RID: 12754
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	private DynamicScrollView<AchievementGroupSmallItem, AchievementGroupSmallDynItem, AchievementGroupData> AchievementGroupScroller;

	// Token: 0x020073B8 RID: 29624
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x040280A9 RID: 164009
		CaptionItem,
		// Token: 0x040280AA RID: 164010
		AchievementGroupScroller,
		// Token: 0x040280AB RID: 164011
		SearchingItem,
		// Token: 0x040280AC RID: 164012
		GroupTitleItem,
		// Token: 0x040280AD RID: 164013
		GroupDataItem,
		// Token: 0x040280AE RID: 164014
		SearchItem,
		// Token: 0x040280AF RID: 164015
		AchievementGroupTemplate,
		// Token: 0x040280B0 RID: 164016
		SearchInput,
		// Token: 0x040280B1 RID: 164017
		LeftSearchTip,
		// Token: 0x040280B2 RID: 164018
		RightSearchTip,
		// Token: 0x040280B3 RID: 164019
		CategoryProgressText
	}
}
