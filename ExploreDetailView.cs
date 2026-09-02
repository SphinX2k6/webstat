using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001B87 RID: 7047
[NullableContext(1)]
[Nullable(0)]
public class ExploreDetailView : UiViewBase
{
	// Token: 0x0600CCC6 RID: 52422 RVA: 0x00367CE3 File Offset: 0x00365EE3
	public ExploreDetailView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600CCC7 RID: 52423 RVA: 0x00367CF4 File Offset: 0x00365EF4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
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
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickSkipButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600CCC8 RID: 52424 RVA: 0x00367E40 File Offset: 0x00366040
	protected override UniTask OnBeforeStartAsync()
	{
		ExploreDetailView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ExploreDetailView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600CCC9 RID: 52425 RVA: 0x00367E84 File Offset: 0x00366084
	protected override void OnStart()
	{
		this.PopupCaptionItem = new PopupCaptionItem(base.GetItem(0));
		this.PopupCaptionItem.SetCloseCallBack(new Action(this.OnCloseButtonClicked));
		this.GenericScrollView = new GenericScrollView<ExploreProgressItem>(base.GetScrollViewWithScrollbar(4), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<ExploreProgressItem>(this.OnCreateExploreProgressItem), null);
		this.RefreshSelectedCountryIdAndAreaId(ModelBase<AreaModel>.Instance.GetAreaCountryId().GetValueOrDefault());
		this.RefreshTabScrollView();
		if (this.SelectedAreaItem == null)
		{
			this.RefreshExploreProgressScrollView();
		}
	}

	// Token: 0x0600CCCA RID: 52426 RVA: 0x00367F08 File Offset: 0x00366108
	protected override void OnBeforeDestroy()
	{
		PopupCaptionItem popupCaptionItem = this.PopupCaptionItem;
		if (popupCaptionItem != null)
		{
			popupCaptionItem.Destroy(null);
		}
		this.PopupCaptionItem = null;
		DynamicScrollView<ExploreAreaParentItem, ExploreAreaDynamicItem, ExploreAreaViewData> tabLoopScroll = this.TabLoopScroll;
		if (tabLoopScroll != null)
		{
			tabLoopScroll.ClearChildren();
		}
		this.TabLoopScroll = null;
		GenericScrollView<ExploreProgressItem> genericScrollView = this.GenericScrollView;
		if (genericScrollView != null)
		{
			genericScrollView.ClearChildren();
		}
		this.GenericScrollView = null;
	}

	// Token: 0x0600CCCB RID: 52427 RVA: 0x00367F60 File Offset: 0x00366160
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	private ILayoutItem<ExploreProgressItem> OnCreateExploreProgressItem(object rawData, UUIItem uiItem, int index)
	{
		ExploreAreaItemData data = rawData as ExploreAreaItemData;
		ExploreProgressItem exploreProgressItem = new ExploreProgressItem();
		exploreProgressItem.CreateByActorAsync(uiItem.GetOwner(), null, false).ContinueWith(delegate()
		{
			exploreProgressItem.Refresh(data);
			exploreProgressItem.SetUiActive(true);
		});
		return new LayoutItem<ExploreProgressItem>
		{
			Key = index,
			Value = exploreProgressItem
		};
	}

	// Token: 0x0600CCCC RID: 52428 RVA: 0x00367FCC File Offset: 0x003661CC
	private void OnCloseButtonClicked()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.ExploreDetailView, null);
	}

	// Token: 0x0600CCCD RID: 52429 RVA: 0x00367FE0 File Offset: 0x003661E0
	private void OnClickSkipButton()
	{
		if (ModelBase<FunctionModel>.Instance.IsOpen(10057))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.ExploreDetailView, null);
			SkipTaskManager.Run(ESkipName.SkipToWorldMapView, new object[]
			{
				8,
				3
			});
			return;
		}
		ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("ExploreProgressRewardNotOpen", Array.Empty<object>());
	}

	// Token: 0x0600CCCE RID: 52430 RVA: 0x00368044 File Offset: 0x00366244
	private ExploreAreaParentItem OnCreateTabItem(ExploreAreaViewData data, UUIItem uiItem, int index)
	{
		ExploreAreaParentItem exploreAreaParentItem = new ExploreAreaParentItem();
		exploreAreaParentItem.BindOnCountrySelected(new Action<ExploreCountryItem, ExploreAreaViewData, EToggleState>(this.OnCountrySelected));
		exploreAreaParentItem.BindOnAreaSelected(new Action<ExploreAreaItem, ExploreAreaViewData, bool>(this.OnAreaSelected));
		if (index == this.SelectedAreaIndex)
		{
			this.SelectedAreaItem = exploreAreaParentItem.ExploreAreaItem;
			this.SelectedAreaIndex = -1;
		}
		return exploreAreaParentItem;
	}

	// Token: 0x0600CCCF RID: 52431 RVA: 0x00368098 File Offset: 0x00366298
	private void OnCountrySelected(ExploreCountryItem exploreCountryItem, ExploreAreaViewData data, EToggleState state)
	{
		int countryId = data.CountryId;
		if (state == EToggleState.ETT_Checked)
		{
			this.RefreshSelectedCountryIdAndAreaId(countryId);
			this.RefreshTabScrollView();
			return;
		}
		ExploreProgressModel instance = ModelBase<ExploreProgressModel>.Instance;
		instance.SelectedCountryId = 0;
		instance.SelectedAreaId = 0;
		this.RefreshTabScrollView();
	}

	// Token: 0x0600CCD0 RID: 52432 RVA: 0x003680D6 File Offset: 0x003662D6
	private void OnAreaSelected(ExploreAreaItem exploreAreaItem, ExploreAreaViewData data, bool bSelected)
	{
		if (!bSelected)
		{
			return;
		}
		this.SelectedArea(data.AreaId, exploreAreaItem);
		this.RefreshExploreProgressScrollView();
		base.PlaySequence("Switch", null, false);
	}

	// Token: 0x0600CCD1 RID: 52433 RVA: 0x003680FC File Offset: 0x003662FC
	[NullableContext(2)]
	private void SelectedArea(int areaId, ExploreAreaItem exploreAreaItem = null)
	{
		if (exploreAreaItem == null)
		{
			return;
		}
		ExploreAreaItem selectedAreaItem = this.SelectedAreaItem;
		if (selectedAreaItem != null)
		{
			selectedAreaItem.SetSelected(false, false);
		}
		this.SelectedAreaItem = exploreAreaItem;
		exploreAreaItem.SetSelected(true, false);
		ModelBase<ExploreProgressModel>.Instance.SelectedAreaId = areaId;
	}

	// Token: 0x0600CCD2 RID: 52434 RVA: 0x00368130 File Offset: 0x00366330
	private void RefreshSelectedCountryIdAndAreaId(int countryId)
	{
		ExploreProgressModel instance = ModelBase<ExploreProgressModel>.Instance;
		if (countryId <= 0)
		{
			instance.SelectedCountryId = 1;
			ExploreAreaData exploreAreaData = instance.GetExploreCountryData(countryId).GetExploreAreaDataList()[0];
			instance.SelectedAreaId = exploreAreaData.AreaId;
		}
		instance.SelectedCountryId = countryId;
		instance.SelectedAreaId = MapUtil.GetWorldMapLevelOneAreaId();
	}

	// Token: 0x0600CCD3 RID: 52435 RVA: 0x00368180 File Offset: 0x00366380
	private void RefreshTabScrollView()
	{
		List<ExploreAreaViewData> list = new List<ExploreAreaViewData>();
		int exploreAreaViewDataList = this.GetExploreAreaViewDataList(list);
		if (list.ElementAtOrDefault(exploreAreaViewDataList) == null)
		{
			this.SelectedAreaItem = null;
			return;
		}
		this.TabLoopScroll.RefreshByData(list.ToArray(), false, false);
		this.SelectedAreaIndex = exploreAreaViewDataList;
	}

	// Token: 0x0600CCD4 RID: 52436 RVA: 0x003681C8 File Offset: 0x003663C8
	private int GetExploreAreaViewDataList(List<ExploreAreaViewData> exploreAreaViewDataList)
	{
		ExploreProgressModel instance = ModelBase<ExploreProgressModel>.Instance;
		IReadOnlyDictionary<int, ExploreCountryData> exploreCountryDataMap = ModelBase<ExploreProgressModel>.Instance.GetExploreCountryDataMap();
		int result = 0;
		foreach (ExploreCountryData exploreCountryData in exploreCountryDataMap.Values)
		{
			if (exploreCountryData.GetAreaSize() > 0)
			{
				int countryId = exploreCountryData.CountryId;
				ExploreAreaViewData exploreAreaViewData = new ExploreAreaViewData();
				exploreAreaViewData.RefreshCountry(countryId, exploreCountryData.GetNameId(), false);
				exploreAreaViewDataList.Add(exploreAreaViewData);
				if (countryId == instance.SelectedCountryId)
				{
					List<ExploreAreaData> exploreAreaDataList = exploreCountryData.GetExploreAreaDataList();
					exploreAreaDataList.Sort(delegate(ExploreAreaData a, ExploreAreaData b)
					{
						int sortIndex = a.GetSortIndex();
						int sortIndex2 = b.GetSortIndex();
						if (sortIndex == 0 || sortIndex2 == 0)
						{
							return a.AreaId.CompareTo(b.AreaId);
						}
						if (sortIndex != sortIndex2)
						{
							return sortIndex.CompareTo(sortIndex2);
						}
						return a.AreaId.CompareTo(b.AreaId);
					});
					foreach (ExploreAreaData exploreAreaData in exploreAreaDataList)
					{
						if (exploreAreaData.GetAllExploreAreaItemData().Count > 0)
						{
							int areaId = exploreAreaData.AreaId;
							ExploreAreaViewData exploreAreaViewData2 = new ExploreAreaViewData();
							exploreAreaViewData2.RefreshArea(areaId, exploreAreaData.GetNameId(), (float)exploreAreaData.GetProgress());
							exploreAreaViewDataList.Add(exploreAreaViewData2);
							if (instance.SelectedAreaId == areaId)
							{
								result = exploreAreaViewDataList.Count - 1;
							}
						}
					}
				}
			}
		}
		return result;
	}

	// Token: 0x0600CCD5 RID: 52437 RVA: 0x00368334 File Offset: 0x00366534
	private void RefreshExploreProgressScrollView()
	{
		ExploreProgressModel instance = ModelBase<ExploreProgressModel>.Instance;
		int selectedAreaId = instance.SelectedAreaId;
		ExploreAreaData exploreAreaData = instance.GetExploreAreaData(selectedAreaId);
		if (exploreAreaData == null)
		{
			return;
		}
		this.GenericScrollView.RefreshByData<ExploreAreaItemData>(exploreAreaData.GetAllExploreAreaItemData(), null);
	}

	// Token: 0x040061E1 RID: 25057
	[Nullable(2)]
	private PopupCaptionItem PopupCaptionItem;

	// Token: 0x040061E2 RID: 25058
	[Nullable(2)]
	private ExploreAreaItem SelectedAreaItem;

	// Token: 0x040061E3 RID: 25059
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	private DynamicScrollView<ExploreAreaParentItem, ExploreAreaDynamicItem, ExploreAreaViewData> TabLoopScroll;

	// Token: 0x040061E4 RID: 25060
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollView<ExploreProgressItem> GenericScrollView;

	// Token: 0x040061E5 RID: 25061
	private int SelectedAreaIndex = -1;

	// Token: 0x02007E67 RID: 32359
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402B0EA RID: 176362
		PopupCaptionItem,
		// Token: 0x0402B0EB RID: 176363
		TagDynamicScrollViewItem,
		// Token: 0x0402B0EC RID: 176364
		TabSourceItem,
		// Token: 0x0402B0ED RID: 176365
		AreaContentItem,
		// Token: 0x0402B0EE RID: 176366
		ExploreProgressScrollView,
		// Token: 0x0402B0EF RID: 176367
		ExploreProgressContentItem,
		// Token: 0x0402B0F0 RID: 176368
		SkipButton
	}
}
