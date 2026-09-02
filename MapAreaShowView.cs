using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001B94 RID: 7060
[NullableContext(1)]
[Nullable(0)]
public class MapAreaShowView : UiViewBase
{
	// Token: 0x0600CD38 RID: 52536 RVA: 0x00369F9B File Offset: 0x0036819B
	public MapAreaShowView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600CD39 RID: 52537 RVA: 0x00369FA4 File Offset: 0x003681A4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600CD3A RID: 52538 RVA: 0x0036A094 File Offset: 0x00368294
	protected override UniTask OnBeforeStartAsync()
	{
		MapAreaShowView.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MapAreaShowView.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600CD3B RID: 52539 RVA: 0x0036A0D7 File Offset: 0x003682D7
	protected override void OnStart()
	{
		this.TabComponent.SetHelpButtonShowState(false);
	}

	// Token: 0x0600CD3C RID: 52540 RVA: 0x0036A0E5 File Offset: 0x003682E5
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MapAreaShowClickArea, new Action<int>(this.EventMapAreaShowClickArea));
	}

	// Token: 0x0600CD3D RID: 52541 RVA: 0x0036A103 File Offset: 0x00368303
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MapAreaShowClickArea, new Action<int>(this.EventMapAreaShowClickArea));
	}

	// Token: 0x0600CD3E RID: 52542 RVA: 0x0036A124 File Offset: 0x00368324
	protected override void OnBeforeShow()
	{
		this.DataParam = (this.OpenParam as MapAreaShowViewParams);
		MapAreaShowViewParams dataParam = this.DataParam;
		int key = ((dataParam != null) ? dataParam.AreaId : null) ?? MapUtil.GetWorldMapLevelOneAreaId();
		IWorldMapNavigate valueOrDefault = ConfigBase<MapConfig>.Instance.WorldMapNavigateAreaMap.GetValueOrDefault(key);
		MapAreaShowViewParams dataParam2 = this.DataParam;
		int num = ((dataParam2 != null) ? dataParam2.CountryId : null) ?? ((valueOrDefault != null) ? valueOrDefault.CountryId : 0);
		this.PendingDefaultStateId = ((valueOrDefault != null) ? valueOrDefault.StateId : null).GetValueOrDefault();
		MapAreaShowViewParams dataParam3 = this.DataParam;
		int index = 0;
		for (int i = 0; i < this.OneTabDataList.Count; i++)
		{
			if (this.OneTabDataList[i].CountryId == num)
			{
				index = i;
				break;
			}
		}
		this.TabComponent.SelectToggleByIndex(index, true);
	}

	// Token: 0x0600CD3F RID: 52543 RVA: 0x0036A232 File Offset: 0x00368432
	protected override void OnBeforeDestroy()
	{
		if (this.TwoTabGroup != null)
		{
			this.TwoTabGroup.Destroy(null);
			this.TwoTabGroup = null;
		}
	}

	// Token: 0x0600CD40 RID: 52544 RVA: 0x0036A250 File Offset: 0x00368450
	protected UniTask InitCommonOneTab()
	{
		MapAreaShowView.<InitCommonOneTab>d__20 <InitCommonOneTab>d__;
		<InitCommonOneTab>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitCommonOneTab>d__.<>4__this = this;
		<InitCommonOneTab>d__.<>1__state = -1;
		<InitCommonOneTab>d__.<>t__builder.Start<MapAreaShowView.<InitCommonOneTab>d__20>(ref <InitCommonOneTab>d__);
		return <InitCommonOneTab>d__.<>t__builder.Task;
	}

	// Token: 0x0600CD41 RID: 52545 RVA: 0x0036A293 File Offset: 0x00368493
	private MapAreaShowCountryItem ProxyCreate([Nullable(2)] UUIItem item, int? index)
	{
		return new MapAreaShowCountryItem();
	}

	// Token: 0x0600CD42 RID: 52546 RVA: 0x0036A29A File Offset: 0x0036849A
	private void ToggleCallBack(int index)
	{
		this.LastClickTime = new double?(Singleton<Time>.Instance.Now);
		this.CurSelectOneTabIndex = index;
		this.RefreshTwoTab();
	}

	// Token: 0x0600CD43 RID: 52547 RVA: 0x0036A2C0 File Offset: 0x003684C0
	private CommonTabData GetCommonTitleData(int index)
	{
		ExploreCountryData exploreCountryData = this.OneTabDataList[index];
		return new CommonTabData(exploreCountryData.Icon, new CommonTabTitleData(exploreCountryData.TitleId, new object[]
		{
			exploreCountryData
		}), null);
	}

	// Token: 0x0600CD44 RID: 52548 RVA: 0x0036A2FB File Offset: 0x003684FB
	private void OnClickCloseButton()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600CD45 RID: 52549 RVA: 0x0036A304 File Offset: 0x00368504
	private bool CanToggleChange(int index, bool? forceSwitch)
	{
		return Singleton<Info>.Instance.IsInGamepad() || (this.LastClickTime == null || Singleton<Time>.Instance.Now - this.LastClickTime.Value >= (double)this.Interval);
	}

	// Token: 0x0600CD46 RID: 52550 RVA: 0x0036A344 File Offset: 0x00368544
	private void RefreshTwoTab()
	{
		if (this.TwoTabGroup == null)
		{
			this.TwoTabGroup = new TabComponent<MapAreaShowTabItem>(base.GetItem(3), new Func<UUIItem, int?, MapAreaShowTabItem>(this.TabItemProxyCreate), new Action<int>(this.ToggleTwoTabCallBack), base.GetItem(5));
		}
		ExploreCountryData exploreCountryData = this.OneTabDataList[this.CurSelectOneTabIndex];
		this.TwoTabDataList = (from s in exploreCountryData.GetStateDataList()
		orderby s.SortIndex, s.StateId
		select s).ToList<ExploreStateData>();
		int count = this.TwoTabDataList.Count;
		this.TwoTabGroup.RefreshTabItemByLength(count, new Action(this.RefreshTwoTabFinish));
	}

	// Token: 0x0600CD47 RID: 52551 RVA: 0x0036A41C File Offset: 0x0036861C
	private void RefreshTwoTabFinish()
	{
		int index = 0;
		if (this.PendingDefaultStateId != 0)
		{
			int num = -1;
			int num2 = 0;
			for (;;)
			{
				int num3 = num2;
				IReadOnlyList<ExploreStateData> twoTabDataList = this.TwoTabDataList;
				if (num3 >= ((twoTabDataList != null) ? twoTabDataList.Count : 0))
				{
					goto IL_46;
				}
				if (this.TwoTabDataList[num2].StateId == this.PendingDefaultStateId)
				{
					break;
				}
				num2++;
			}
			num = num2;
			IL_46:
			if (num >= 0)
			{
				index = num;
			}
			this.PendingDefaultStateId = 0;
		}
		Dictionary<int, MapAreaShowTabItem> tabItemMap = this.TwoTabGroup.GetTabItemMap();
		bool uiactive = false;
		foreach (KeyValuePair<int, MapAreaShowTabItem> keyValuePair in tabItemMap)
		{
			int key = keyValuePair.Key;
			MapAreaShowTabItem value = keyValuePair.Value;
			IReadOnlyList<ExploreStateData> twoTabDataList2 = this.TwoTabDataList;
			value.UpdateView((twoTabDataList2 != null) ? twoTabDataList2[key] : null);
			if (!this.TwoTabDataList[key].IsNoneState)
			{
				uiactive = true;
			}
		}
		this.TwoTabGroup.SelectToggleByIndex(index, true, true);
		base.GetItem(3).SetUIActive(uiactive);
	}

	// Token: 0x0600CD48 RID: 52552 RVA: 0x0036A520 File Offset: 0x00368720
	private MapAreaShowTabItem TabItemProxyCreate([Nullable(2)] UUIItem item, int? index)
	{
		return new MapAreaShowTabItem();
	}

	// Token: 0x0600CD49 RID: 52553 RVA: 0x0036A527 File Offset: 0x00368727
	private void ToggleTwoTabCallBack(int index)
	{
		this.CurSelectTwoTabIndex = index;
		this.RefreshArea();
	}

	// Token: 0x0600CD4A RID: 52554 RVA: 0x0036A536 File Offset: 0x00368736
	private void RefreshArea()
	{
		this.RefreshLoopScrollView();
	}

	// Token: 0x0600CD4B RID: 52555 RVA: 0x0036A540 File Offset: 0x00368740
	protected void RefreshLoopScrollView()
	{
		UUILoopScrollViewComponent loopScrollViewComponent = base.GetLoopScrollViewComponent(1);
		if (this.AreaScroll == null)
		{
			this.AreaScroll = new LoopScrollView<MapAreaShowItem, ExploreAreaData>(loopScrollViewComponent, base.GetItem(2).GetOwner() as AUIBaseActor, new Func<MapAreaShowItem>(this.InitHandBookQuestItem), true);
		}
		IReadOnlyList<ExploreStateData> twoTabDataList = this.TwoTabDataList;
		List<ExploreAreaData> data = (twoTabDataList != null) ? twoTabDataList[this.CurSelectTwoTabIndex].ExploreAreaDataList : null;
		this.AreaScroll.RefreshByData(data, false, delegate
		{
		}, true);
	}

	// Token: 0x0600CD4C RID: 52556 RVA: 0x0036A5D2 File Offset: 0x003687D2
	private MapAreaShowItem InitHandBookQuestItem()
	{
		return new MapAreaShowItem();
	}

	// Token: 0x0600CD4D RID: 52557 RVA: 0x0036A5D9 File Offset: 0x003687D9
	private void EventMapAreaShowClickArea(int areaId)
	{
		MapAreaShowViewParams dataParam = this.DataParam;
		if (dataParam == null)
		{
			return;
		}
		Action<int> onClickArea = dataParam.OnClickArea;
		if (onClickArea == null)
		{
			return;
		}
		onClickArea(areaId);
	}

	// Token: 0x04006211 RID: 25105
	private IReadOnlyList<ExploreCountryData> OneTabDataList;

	// Token: 0x04006212 RID: 25106
	private TabComponentWithCaptionItem<MapAreaShowCountryItem> TabComponent;

	// Token: 0x04006213 RID: 25107
	private int CurSelectOneTabIndex;

	// Token: 0x04006214 RID: 25108
	private int Interval;

	// Token: 0x04006215 RID: 25109
	private double? LastClickTime;

	// Token: 0x04006216 RID: 25110
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected LoopScrollView<MapAreaShowItem, ExploreAreaData> AreaScroll;

	// Token: 0x04006217 RID: 25111
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TabComponent<MapAreaShowTabItem> TwoTabGroup;

	// Token: 0x04006218 RID: 25112
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private IReadOnlyList<ExploreStateData> TwoTabDataList;

	// Token: 0x04006219 RID: 25113
	private int CurSelectTwoTabIndex;

	// Token: 0x0400621A RID: 25114
	[Nullable(2)]
	private MapAreaShowViewParams DataParam;

	// Token: 0x0400621B RID: 25115
	private int PendingDefaultStateId;

	// Token: 0x02007E75 RID: 32373
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402B139 RID: 176441
		TitleItem,
		// Token: 0x0402B13A RID: 176442
		LoopScrollView,
		// Token: 0x0402B13B RID: 176443
		ScrollViewItem,
		// Token: 0x0402B13C RID: 176444
		TwoTabRoot,
		// Token: 0x0402B13D RID: 176445
		TwoTabScrollView,
		// Token: 0x0402B13E RID: 176446
		TwoTabItem
	}
}
