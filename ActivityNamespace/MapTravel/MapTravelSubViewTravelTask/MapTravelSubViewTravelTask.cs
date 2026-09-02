using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace ActivityNamespace.MapTravel.MapTravelSubViewTravelTask
{
	// Token: 0x020043C7 RID: 17351
	[NullableContext(1)]
	[Nullable(0)]
	public class MapTravelSubViewTravelTask : UiPanelBase, IMapTravelSubViewInterface
	{
		// Token: 0x17007F08 RID: 32520
		// (get) Token: 0x0602E1EF RID: 188911 RVA: 0x00AD7F8B File Offset: 0x00AD618B
		// (set) Token: 0x0602E1F0 RID: 188912 RVA: 0x00AD7F93 File Offset: 0x00AD6193
		public bool NeedDestroySelf { get; set; }

		// Token: 0x0602E1F1 RID: 188913 RVA: 0x00AD7F9C File Offset: 0x00AD619C
		public MapTravelSubViewTravelTask(ActivityMapTravelData ActivityBaseData)
		{
			this.ActivityBaseData = ActivityBaseData;
		}

		// Token: 0x0602E1F2 RID: 188914 RVA: 0x00AD7FC0 File Offset: 0x00AD61C0
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
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0602E1F3 RID: 188915 RVA: 0x00AD80D0 File Offset: 0x00AD62D0
		protected override UniTask OnBeforeStartAsync()
		{
			MapTravelSubViewTravelTask.<OnBeforeStartAsync>d__16 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MapTravelSubViewTravelTask.<OnBeforeStartAsync>d__16>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0602E1F4 RID: 188916 RVA: 0x00AD8113 File Offset: 0x00AD6313
		protected override void OnBeforeShow()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.MapTravelTaskRefresh, new Action(this.RefreshCurrent));
			Singleton<EventSystem>.Instance.Add(EEventName.MapTravelTaskNavigationNext, new Action(this.OnMapTravelTaskNavigationNext));
		}

		// Token: 0x0602E1F5 RID: 188917 RVA: 0x00AD814D File Offset: 0x00AD634D
		protected override void OnBeforeHide()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.MapTravelTaskRefresh, new Action(this.RefreshCurrent));
			Singleton<EventSystem>.Instance.Remove(EEventName.MapTravelTaskNavigationNext, new Action(this.OnMapTravelTaskNavigationNext));
		}

		// Token: 0x0602E1F6 RID: 188918 RVA: 0x00AD8187 File Offset: 0x00AD6387
		private AreaLayout InitItem()
		{
			return new AreaLayout(this.ActivityBaseData);
		}

		// Token: 0x0602E1F7 RID: 188919 RVA: 0x00AD8194 File Offset: 0x00AD6394
		private MapTravelTabDynamicScrollItem CreateTabItem(MapTravelAreaData data, UUIItem uiItem, int index)
		{
			MapTravelTabDynamicScrollItem mapTravelTabDynamicScrollItem = new MapTravelTabDynamicScrollItem(this.ActivityBaseData);
			mapTravelTabDynamicScrollItem.BindSelectedCallBack(new Action<MapTravelAreaData, int>(this.TabSelectedCallBack));
			mapTravelTabDynamicScrollItem.BindIsSelectedOn(new Func<MapTravelAreaData, int, bool>(this.IsSelectedOn));
			return mapTravelTabDynamicScrollItem;
		}

		// Token: 0x0602E1F8 RID: 188920 RVA: 0x00AD81C5 File Offset: 0x00AD63C5
		protected override void OnStart()
		{
		}

		// Token: 0x0602E1F9 RID: 188921 RVA: 0x00AD81C8 File Offset: 0x00AD63C8
		protected void OnMapTravelTaskNavigationNext()
		{
			UUIItem firstItem = this.AreaLayoutList.GetScrollItemByIndex(this.SelectedTabIndex).GetFirstItem();
			if (firstItem != null)
			{
				ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(firstItem, false, false, false);
			}
		}

		// Token: 0x0602E1FA RID: 188922 RVA: 0x00AD8200 File Offset: 0x00AD6400
		protected void RefreshCurrent()
		{
			RewardPanel panelReward = this.PanelReward;
			if (panelReward != null)
			{
				panelReward.Refresh();
			}
			List<MapTravelAreaData> list = this.ActivityBaseData.GetAllAreaData().FindAll((MapTravelAreaData data) => data.TravelTaskIdSet.Count > 0);
			this.TabLayout.RefreshByData(list.ToArray(), true, false);
			this.AreaLayoutList.RefreshByDataAsync(list, true);
		}

		// Token: 0x0602E1FB RID: 188923 RVA: 0x00AD8270 File Offset: 0x00AD6470
		private UniTask Refresh()
		{
			MapTravelSubViewTravelTask.<Refresh>d__24 <Refresh>d__;
			<Refresh>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Refresh>d__.<>4__this = this;
			<Refresh>d__.<>1__state = -1;
			<Refresh>d__.<>t__builder.Start<MapTravelSubViewTravelTask.<Refresh>d__24>(ref <Refresh>d__);
			return <Refresh>d__.<>t__builder.Task;
		}

		// Token: 0x0602E1FC RID: 188924 RVA: 0x00AD82B4 File Offset: 0x00AD64B4
		private void InitViewRelation(List<MapTravelAreaData> areaDataList)
		{
			this.TabAnchorOffset.Clear();
			float height = base.GetScrollViewWithScrollbar(3).RootUIComp.Get().GetHeight();
			List<AreaLayout> scrollItemList = this.AreaLayoutList.GetScrollItemList();
			float num = 0f;
			float num2 = 0f;
			this.TabAnchorOffset.Add(-2147483647);
			for (int i = 0; i < scrollItemList.Count; i++)
			{
				if (i == scrollItemList.Count - 1)
				{
					num += scrollItemList[i].GetRootItem().GetHeight();
					num2 = scrollItemList[i].GetRootItem().GetHeight();
				}
				else
				{
					num += scrollItemList[i].GetRootItem().GetHeight() + 20f;
					this.TabAnchorOffset.Add((int)num);
				}
			}
			this.TabAnchorOffset.Add(int.MaxValue);
			if (num2 >= height)
			{
				float height2 = num2 % height;
				base.GetItem(5).SetHeight(height2);
			}
			else
			{
				float height3 = height - num2;
				base.GetItem(5).SetHeight(height3);
			}
			base.GetItem(5).SetHierarchyIndex(areaDataList.Count + 1);
		}

		// Token: 0x0602E1FD RID: 188925 RVA: 0x00AD83D2 File Offset: 0x00AD65D2
		private void SelectTab(int index, bool bOn, bool bFireEvent)
		{
			MapTravelTabDynamicScrollItem scrollItemFromIndex = this.TabLayout.GetScrollItemFromIndex(index);
			if (scrollItemFromIndex == null)
			{
				return;
			}
			scrollItemFromIndex.SetSelected(bOn, bFireEvent);
		}

		// Token: 0x0602E1FE RID: 188926 RVA: 0x00AD83EC File Offset: 0x00AD65EC
		private void OnContentUpdate(FVector2D _)
		{
			if (this.InitRefresh)
			{
				return;
			}
			float anchorOffsetY = base.GetItem(6).GetAnchorOffsetY();
			int displayGridStartIndex = this.TabLayout.GetDisplayGridStartIndex();
			int displayGridEndIndex = this.TabLayout.GetDisplayGridEndIndex();
			int i = 0;
			while (i < this.TabAnchorOffset.Count - 1)
			{
				if ((float)this.TabAnchorOffset[i] <= anchorOffsetY && anchorOffsetY < (float)this.TabAnchorOffset[i + 1])
				{
					if (i == this.SelectedTabIndex)
					{
						return;
					}
					this.SelectTab(this.SelectedTabIndex, false, false);
					if (i < displayGridStartIndex || i > displayGridEndIndex)
					{
						float scrollProgress = (i == 0) ? 0f : ((float)(i + 1) / (float)(this.TabAnchorOffset.Count - 1));
						base.GetUIDynScrollViewComponent(1).SetScrollProgress(scrollProgress);
					}
					this.SelectedTabIndex = i;
					this.SelectTab(this.SelectedTabIndex, true, false);
					return;
				}
				else
				{
					i++;
				}
			}
		}

		// Token: 0x0602E1FF RID: 188927 RVA: 0x00AD84CA File Offset: 0x00AD66CA
		private void TabSelectedCallBack(MapTravelAreaData tabData, int index)
		{
			if (index != this.SelectedTabIndex)
			{
				this.SelectTab(this.SelectedTabIndex, false, false);
			}
			this.SelectedTabIndex = index;
			base.GetScrollViewWithScrollbar(3).StopMovement();
			this.TabSelected(index);
		}

		// Token: 0x0602E200 RID: 188928 RVA: 0x00AD8500 File Offset: 0x00AD6700
		private void TabSelected(int index)
		{
			int num = Math.Max(this.TabAnchorOffset[index], 0);
			base.GetItem(6).SetAnchorOffsetY((float)num);
		}

		// Token: 0x0602E201 RID: 188929 RVA: 0x00AD852E File Offset: 0x00AD672E
		private bool IsSelectedOn(MapTravelAreaData tabData, int index)
		{
			return this.SelectedTabIndex == index;
		}

		// Token: 0x0602E202 RID: 188930 RVA: 0x00AD853C File Offset: 0x00AD673C
		public UniTask PlayStartSequence()
		{
			MapTravelSubViewTravelTask.<PlayStartSequence>d__31 <PlayStartSequence>d__;
			<PlayStartSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayStartSequence>d__.<>4__this = this;
			<PlayStartSequence>d__.<>1__state = -1;
			<PlayStartSequence>d__.<>t__builder.Start<MapTravelSubViewTravelTask.<PlayStartSequence>d__31>(ref <PlayStartSequence>d__);
			return <PlayStartSequence>d__.<>t__builder.Task;
		}

		// Token: 0x0602E203 RID: 188931 RVA: 0x00AD8580 File Offset: 0x00AD6780
		public UniTask PlayCloseSequence()
		{
			MapTravelSubViewTravelTask.<PlayCloseSequence>d__32 <PlayCloseSequence>d__;
			<PlayCloseSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayCloseSequence>d__.<>4__this = this;
			<PlayCloseSequence>d__.<>1__state = -1;
			<PlayCloseSequence>d__.<>t__builder.Start<MapTravelSubViewTravelTask.<PlayCloseSequence>d__32>(ref <PlayCloseSequence>d__);
			return <PlayCloseSequence>d__.<>t__builder.Task;
		}

		// Token: 0x0602E204 RID: 188932 RVA: 0x00AD85C3 File Offset: 0x00AD67C3
		private void SetDefault()
		{
			this.SelectTab(this.SelectedTabIndex, false, false);
			this.SelectedTabIndex = -1;
		}

		// Token: 0x0401A173 RID: 106867
		private const int LAYOUT_PADDING = 20;

		// Token: 0x0401A174 RID: 106868
		protected ActivityMapTravelData ActivityBaseData;

		// Token: 0x0401A176 RID: 106870
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<AreaLayout, MapTravelAreaData> AreaLayoutList;

		// Token: 0x0401A177 RID: 106871
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0401A178 RID: 106872
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		protected DynamicScrollView<MapTravelTabDynamicScrollItem, MapTravelTabDynamicItem, MapTravelAreaData> TabLayout;

		// Token: 0x0401A179 RID: 106873
		[Nullable(2)]
		private RewardPanel PanelReward;

		// Token: 0x0401A17A RID: 106874
		private readonly List<int> TabAnchorOffset = new List<int>();

		// Token: 0x0401A17B RID: 106875
		private int SelectedTabIndex = -1;

		// Token: 0x0401A17C RID: 106876
		private bool InitRefresh;

		// Token: 0x0200A631 RID: 42545
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x04033642 RID: 210498
			public const int PanelTop = 0;

			// Token: 0x04033643 RID: 210499
			public const int TabLayout = 1;

			// Token: 0x04033644 RID: 210500
			public const int TabItem = 2;

			// Token: 0x04033645 RID: 210501
			public const int ContentLayout = 3;

			// Token: 0x04033646 RID: 210502
			public const int ContentItem = 4;

			// Token: 0x04033647 RID: 210503
			public const int OccupiedItem = 5;

			// Token: 0x04033648 RID: 210504
			public const int Content = 6;
		}
	}
}
