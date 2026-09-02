using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x020064B4 RID: 25780
	[NullableContext(1)]
	[Nullable(0)]
	public class RoadBookTravelTaskView : UiViewBase
	{
		// Token: 0x060409B9 RID: 264633 RVA: 0x0108F9FF File Offset: 0x0108DBFF
		public RoadBookTravelTaskView(UiViewInfo uiViewInfo) : base(uiViewInfo)
		{
		}

		// Token: 0x060409BA RID: 264634 RVA: 0x0108FA28 File Offset: 0x0108DC28
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIDynScrollViewComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIDynScrollViewComponent)),
				new ValueTuple<int, Type>(5, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
		}

		// Token: 0x060409BB RID: 264635 RVA: 0x0108FAD0 File Offset: 0x0108DCD0
		protected override UniTask OnBeforeStartAsync()
		{
			RoadBookTravelTaskView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoadBookTravelTaskView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060409BC RID: 264636 RVA: 0x0108FB13 File Offset: 0x0108DD13
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.RoadBookTaskRefresh, new Action(this.RefreshCurrent));
			Singleton<EventSystem>.Instance.Add(EEventName.RoadBookTaskNavigationNext, new Action(this.OnRoadBookTaskNavigationNext));
		}

		// Token: 0x060409BD RID: 264637 RVA: 0x0108FB4D File Offset: 0x0108DD4D
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RoadBookTaskRefresh, new Action(this.RefreshCurrent));
			Singleton<EventSystem>.Instance.Remove(EEventName.RoadBookTaskNavigationNext, new Action(this.OnRoadBookTaskNavigationNext));
		}

		// Token: 0x060409BE RID: 264638 RVA: 0x0108FB87 File Offset: 0x0108DD87
		private AreaLayout CreateAreaLayoutItem(AreaLayoutItemData data, UUIItem uiItem, int index)
		{
			return new AreaLayout(this.ActivityBaseData);
		}

		// Token: 0x060409BF RID: 264639 RVA: 0x0108FB94 File Offset: 0x0108DD94
		private RoadBookTabDynamicScrollItem CreateTabItem(RoadBookAreaData data, UUIItem uiItem, int index)
		{
			RoadBookTabDynamicScrollItem roadBookTabDynamicScrollItem = new RoadBookTabDynamicScrollItem(this.ActivityBaseData);
			roadBookTabDynamicScrollItem.BindSelectedCallBack(new Action<RoadBookAreaData, int>(this.TabSelectedCallBack));
			roadBookTabDynamicScrollItem.BindIsSelectedOn(new Func<RoadBookAreaData, int, bool>(this.IsSelectedOn));
			return roadBookTabDynamicScrollItem;
		}

		// Token: 0x060409C0 RID: 264640 RVA: 0x0108FBC5 File Offset: 0x0108DDC5
		protected override void OnStart()
		{
		}

		// Token: 0x060409C1 RID: 264641 RVA: 0x0108FBC8 File Offset: 0x0108DDC8
		protected void OnRoadBookTaskNavigationNext()
		{
			AreaLayout scrollItemFromIndex = this.AreaLayoutList.GetScrollItemFromIndex(this.SelectedTabIndex);
			UUIItem uuiitem = (scrollItemFromIndex != null) ? scrollItemFromIndex.GetFirstItem() : null;
			if (uuiitem != null)
			{
				ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(uuiitem, false, false, false);
			}
		}

		// Token: 0x060409C2 RID: 264642 RVA: 0x0108FC08 File Offset: 0x0108DE08
		protected void RefreshCurrent()
		{
			RewardPanel panelReward = this.PanelReward;
			if (panelReward != null)
			{
				panelReward.Refresh();
			}
			List<RoadBookAreaData> list = new List<RoadBookAreaData>();
			foreach (RoadBookAreaData roadBookAreaData in this.ActivityBaseData.GetAllAreaData())
			{
				if (roadBookAreaData.TravelTaskIdSet.Count > 0)
				{
					list.Add(roadBookAreaData);
				}
			}
			this.TabLayout.RefreshByData(list.ToArray(), false, false);
			List<AreaLayoutItemData> flatData = this.GetFlatData(list);
			this.AreaLayoutList.RefreshByData(flatData.ToArray(), false, false);
		}

		// Token: 0x060409C3 RID: 264643 RVA: 0x0108FCB4 File Offset: 0x0108DEB4
		private UniTask Refresh()
		{
			RoadBookTravelTaskView.<Refresh>d__21 <Refresh>d__;
			<Refresh>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Refresh>d__.<>4__this = this;
			<Refresh>d__.<>1__state = -1;
			<Refresh>d__.<>t__builder.Start<RoadBookTravelTaskView.<Refresh>d__21>(ref <Refresh>d__);
			return <Refresh>d__.<>t__builder.Task;
		}

		// Token: 0x060409C4 RID: 264644 RVA: 0x0108FCF8 File Offset: 0x0108DEF8
		private List<AreaLayoutItemData> GetFlatData(List<RoadBookAreaData> areaDataList)
		{
			List<AreaLayoutItemData> list = new List<AreaLayoutItemData>();
			foreach (RoadBookAreaData roadBookAreaData in areaDataList)
			{
				list.Add(new AreaLayoutItemData(true, roadBookAreaData, null));
				if (roadBookAreaData.IsUnlock)
				{
					foreach (ActivityTaskData taskData in this.ActivityBaseData.GetAreaTaskDataList(roadBookAreaData.AreaId))
					{
						list.Add(new AreaLayoutItemData(false, roadBookAreaData, taskData));
					}
				}
			}
			return list;
		}

		// Token: 0x060409C5 RID: 264645 RVA: 0x0108FDB4 File Offset: 0x0108DFB4
		private void InitViewRelation(List<AreaLayoutItemData> flatDataList)
		{
			this.TabAnchorOffset.Clear();
			float height = base.GetUIDynScrollViewComponent(4).RootUIComp.Get().GetHeight();
			float spacingVertical = base.GetUIDynScrollViewComponent(4).SpacingVertical;
			float num = 0f;
			float num2 = 0f;
			this.TabAnchorOffset.Add(-2.1474836E+09f);
			for (int i = 0; i < flatDataList.Count; i++)
			{
				float y = this.AreaLayoutList.GetItemSizeFromData(flatDataList[i]).Y;
				if (i == flatDataList.Count - 1)
				{
					num += y;
					num2 += y;
				}
				else
				{
					num += y + spacingVertical;
					num2 += y + spacingVertical;
				}
				if (i > 0 && flatDataList[i].IsTitle)
				{
					this.TabAnchorOffset.Add(num - y);
					num2 = y;
				}
			}
			this.TabAnchorOffset.Add(2.1474836E+09f);
			if (num2 < height)
			{
				float value = height - num2;
				flatDataList[flatDataList.Count - 1].ExtraHeight = new float?(value);
			}
			this.MissionViewHeight = height;
		}

		// Token: 0x060409C6 RID: 264646 RVA: 0x0108FEC5 File Offset: 0x0108E0C5
		private void SelectTab(int index, bool bOn, bool bFireEvent)
		{
			RoadBookTabDynamicScrollItem scrollItemFromIndex = this.TabLayout.GetScrollItemFromIndex(index);
			if (scrollItemFromIndex == null)
			{
				return;
			}
			scrollItemFromIndex.SetSelected(bOn, bFireEvent);
		}

		// Token: 0x060409C7 RID: 264647 RVA: 0x0108FEE0 File Offset: 0x0108E0E0
		private void OnContentUpdate(FVector2D _)
		{
			if (this.InitRefresh)
			{
				return;
			}
			int displayGridStartIndex = this.TabLayout.GetDisplayGridStartIndex();
			int displayGridEndIndex = this.TabLayout.GetDisplayGridEndIndex();
			int num = this.FindTargetTabIndex();
			if (num != -1)
			{
				this.SelectTab(this.SelectedTabIndex, false, false);
				UUIDynScrollViewComponent uidynScrollViewComponent = base.GetUIDynScrollViewComponent(2);
				float anchorOffsetY = uidynScrollViewComponent.ContentUIItem.Get().GetAnchorOffsetY();
				float num2 = anchorOffsetY + uidynScrollViewComponent.RootUIComp.Get().Height;
				UUIItem grid = this.TabLayout.GetGrid(num);
				float anchorOffsetY2 = grid.GetAnchorOffsetY();
				if (num < displayGridStartIndex || num > displayGridEndIndex || -anchorOffsetY2 + grid.GetHeight() > num2 || -anchorOffsetY2 < anchorOffsetY)
				{
					float scrollProgress = (num == 0) ? 0f : ((float)(num + 1) / (float)(this.TabAnchorOffset.Count - 1));
					uidynScrollViewComponent.SetScrollProgress(scrollProgress);
				}
				this.SelectedTabIndex = num;
				this.SelectTab(this.SelectedTabIndex, true, false);
			}
		}

		// Token: 0x060409C8 RID: 264648 RVA: 0x0108FFD4 File Offset: 0x0108E1D4
		private int FindTargetTabIndex()
		{
			float anchorOffsetY = base.GetUIDynScrollViewComponent(4).ContentUIItem.Get().GetAnchorOffsetY();
			if (this.TabAnchorOffset[this.SelectedTabIndex] < anchorOffsetY + this.MissionViewHeight && this.TabAnchorOffset[this.SelectedTabIndex + 1] > anchorOffsetY)
			{
				return -1;
			}
			int result = -1;
			if (((anchorOffsetY > this.TabAnchorOffset[this.SelectedTabIndex]) ? 1 : -1) > 0)
			{
				for (int i = this.SelectedTabIndex + 1; i < this.TabAnchorOffset.Count; i++)
				{
					if (this.TabAnchorOffset[i] <= anchorOffsetY + this.MissionViewHeight && anchorOffsetY < this.TabAnchorOffset[i + 1])
					{
						result = i;
						break;
					}
				}
			}
			else
			{
				for (int j = this.SelectedTabIndex - 1; j >= 0; j--)
				{
					if (this.TabAnchorOffset[j] <= anchorOffsetY + this.MissionViewHeight && anchorOffsetY < this.TabAnchorOffset[j + 1])
					{
						result = j;
						break;
					}
				}
			}
			return result;
		}

		// Token: 0x060409C9 RID: 264649 RVA: 0x010900DB File Offset: 0x0108E2DB
		private void TabSelectedCallBack(RoadBookAreaData tabData, int index)
		{
			if (index != this.SelectedTabIndex)
			{
				this.SelectTab(this.SelectedTabIndex, false, false);
			}
			this.SelectedTabIndex = index;
			base.GetUIDynScrollViewComponent(4).StopMovement();
			this.TabSelected(index);
		}

		// Token: 0x060409CA RID: 264650 RVA: 0x01090110 File Offset: 0x0108E310
		private void TabSelected(int index)
		{
			int itemIndex = this.AreaIndex2DynamicTitleIndex[index];
			base.GetUIDynScrollViewComponent(4).ScrollToItemIndex(itemIndex, true, 0f, false);
		}

		// Token: 0x060409CB RID: 264651 RVA: 0x0109013E File Offset: 0x0108E33E
		private bool IsSelectedOn(RoadBookAreaData tabData, int index)
		{
			return this.SelectedTabIndex == index;
		}

		// Token: 0x060409CC RID: 264652 RVA: 0x0109014C File Offset: 0x0108E34C
		public UniTask PlayStartSequence()
		{
			RoadBookTravelTaskView.<PlayStartSequence>d__30 <PlayStartSequence>d__;
			<PlayStartSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayStartSequence>d__.<>4__this = this;
			<PlayStartSequence>d__.<>1__state = -1;
			<PlayStartSequence>d__.<>t__builder.Start<RoadBookTravelTaskView.<PlayStartSequence>d__30>(ref <PlayStartSequence>d__);
			return <PlayStartSequence>d__.<>t__builder.Task;
		}

		// Token: 0x060409CD RID: 264653 RVA: 0x01090190 File Offset: 0x0108E390
		public UniTask PlayCloseSequence()
		{
			RoadBookTravelTaskView.<PlayCloseSequence>d__31 <PlayCloseSequence>d__;
			<PlayCloseSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayCloseSequence>d__.<>4__this = this;
			<PlayCloseSequence>d__.<>1__state = -1;
			<PlayCloseSequence>d__.<>t__builder.Start<RoadBookTravelTaskView.<PlayCloseSequence>d__31>(ref <PlayCloseSequence>d__);
			return <PlayCloseSequence>d__.<>t__builder.Task;
		}

		// Token: 0x060409CE RID: 264654 RVA: 0x010901D3 File Offset: 0x0108E3D3
		private void SetDefault()
		{
			this.SelectTab(this.SelectedTabIndex, false, false);
			this.SelectedTabIndex = -1;
		}

		// Token: 0x060409CF RID: 264655 RVA: 0x010901EC File Offset: 0x0108E3EC
		private void OnClickHelpBtn()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(this.ActivityBaseData.LocalConfig.Value.HelpId);
		}

		// Token: 0x040242E8 RID: 148200
		[Nullable(2)]
		private PopupCaptionItem CaptionComponent;

		// Token: 0x040242E9 RID: 148201
		private ActivityRoadBookData ActivityBaseData;

		// Token: 0x040242EA RID: 148202
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		protected DynamicScrollView<AreaLayout, AreaLayoutBaseItem, AreaLayoutItemData> AreaLayoutList;

		// Token: 0x040242EB RID: 148203
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x040242EC RID: 148204
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		protected DynamicScrollView<RoadBookTabDynamicScrollItem, RoadBookTabDynamicItem, RoadBookAreaData> TabLayout;

		// Token: 0x040242ED RID: 148205
		[Nullable(2)]
		private RewardPanel PanelReward;

		// Token: 0x040242EE RID: 148206
		private readonly List<float> TabAnchorOffset = new List<float>();

		// Token: 0x040242EF RID: 148207
		private int SelectedTabIndex = -1;

		// Token: 0x040242F0 RID: 148208
		private bool InitRefresh;

		// Token: 0x040242F1 RID: 148209
		private float MissionViewHeight;

		// Token: 0x040242F2 RID: 148210
		private List<int> AreaIndex2DynamicTitleIndex = new List<int>();
	}
}
