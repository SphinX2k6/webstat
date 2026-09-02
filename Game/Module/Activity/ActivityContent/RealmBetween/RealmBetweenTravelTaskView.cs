using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween
{
	// Token: 0x02006552 RID: 25938
	[NullableContext(1)]
	[Nullable(0)]
	public class RealmBetweenTravelTaskView : UiViewBase
	{
		// Token: 0x06040CFC RID: 265468 RVA: 0x0109E85E File Offset: 0x0109CA5E
		public RealmBetweenTravelTaskView(UiViewInfo uiViewInfo) : base(uiViewInfo)
		{
		}

		// Token: 0x06040CFD RID: 265469 RVA: 0x0109E884 File Offset: 0x0109CA84
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIScrollViewComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIMultiTemplateScrollViewComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
		}

		// Token: 0x06040CFE RID: 265470 RVA: 0x0109E918 File Offset: 0x0109CB18
		protected override UniTask OnBeforeStartAsync()
		{
			RealmBetweenTravelTaskView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RealmBetweenTravelTaskView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040CFF RID: 265471 RVA: 0x0109E95B File Offset: 0x0109CB5B
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.RealmBetweenTaskRefresh, new Action(this.OnRealmBetweenTaskRefresh));
			Singleton<EventSystem>.Instance.Add(EEventName.RealmBetweenTaskNavigationNext, new Action(this.OnRealmBetweenTaskNavigationNext));
		}

		// Token: 0x06040D00 RID: 265472 RVA: 0x0109E995 File Offset: 0x0109CB95
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RealmBetweenTaskRefresh, new Action(this.OnRealmBetweenTaskRefresh));
			Singleton<EventSystem>.Instance.Remove(EEventName.RealmBetweenTaskNavigationNext, new Action(this.OnRealmBetweenTaskNavigationNext));
		}

		// Token: 0x06040D01 RID: 265473 RVA: 0x0109E9D0 File Offset: 0x0109CBD0
		private UniTask EnsureMenuItems(List<RealmBetweenAreaData> areaDataList)
		{
			RealmBetweenTravelTaskView.<EnsureMenuItems>d__14 <EnsureMenuItems>d__;
			<EnsureMenuItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<EnsureMenuItems>d__.<>4__this = this;
			<EnsureMenuItems>d__.areaDataList = areaDataList;
			<EnsureMenuItems>d__.<>1__state = -1;
			<EnsureMenuItems>d__.<>t__builder.Start<RealmBetweenTravelTaskView.<EnsureMenuItems>d__14>(ref <EnsureMenuItems>d__);
			return <EnsureMenuItems>d__.<>t__builder.Task;
		}

		// Token: 0x06040D02 RID: 265474 RVA: 0x0109EA1C File Offset: 0x0109CC1C
		private void OnRealmBetweenTaskNavigationNext()
		{
			List<RealmBetweenAreaData> areaDataList = this.GetAreaDataList();
			int missionTitleIndexByMenuIndex = this.GetMissionTitleIndexByMenuIndex(areaDataList, this.TabSelectIndex);
			AreaTaskItem areaTaskItem = this.AreaMissionItemScroll.GetProxyByGridIndex(missionTitleIndexByMenuIndex + 1) as AreaTaskItem;
			UUIItem uuiitem = (areaTaskItem != null) ? areaTaskItem.GetFirstUiItem() : null;
			if (uuiitem != null)
			{
				ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(uuiitem, false, false, false);
			}
		}

		// Token: 0x06040D03 RID: 265475 RVA: 0x0109EA70 File Offset: 0x0109CC70
		private void OnRealmBetweenTaskRefresh()
		{
			this.RefreshCurrentAsync().Forget();
		}

		// Token: 0x06040D04 RID: 265476 RVA: 0x0109EA80 File Offset: 0x0109CC80
		private UniTask RefreshCurrentAsync()
		{
			RealmBetweenTravelTaskView.<RefreshCurrentAsync>d__17 <RefreshCurrentAsync>d__;
			<RefreshCurrentAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshCurrentAsync>d__.<>4__this = this;
			<RefreshCurrentAsync>d__.<>1__state = -1;
			<RefreshCurrentAsync>d__.<>t__builder.Start<RealmBetweenTravelTaskView.<RefreshCurrentAsync>d__17>(ref <RefreshCurrentAsync>d__);
			return <RefreshCurrentAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040D05 RID: 265477 RVA: 0x0109EAC4 File Offset: 0x0109CCC4
		private UniTask Refresh()
		{
			RealmBetweenTravelTaskView.<Refresh>d__18 <Refresh>d__;
			<Refresh>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Refresh>d__.<>4__this = this;
			<Refresh>d__.<>1__state = -1;
			<Refresh>d__.<>t__builder.Start<RealmBetweenTravelTaskView.<Refresh>d__18>(ref <Refresh>d__);
			return <Refresh>d__.<>t__builder.Task;
		}

		// Token: 0x06040D06 RID: 265478 RVA: 0x0109EB08 File Offset: 0x0109CD08
		private List<IMultiTemplateGridData> GetMissionGridDataList(List<RealmBetweenAreaData> areaDataList)
		{
			List<IMultiTemplateGridData> list = new List<IMultiTemplateGridData>();
			foreach (RealmBetweenAreaData realmBetweenAreaData in areaDataList)
			{
				list.Add(new AreaTitleGridData(realmBetweenAreaData, this.ActivityBaseData));
				if (realmBetweenAreaData.IsUnlock)
				{
					using (List<ActivityTaskData>.Enumerator enumerator2 = this.ActivityBaseData.GetAreaTaskDataList(realmBetweenAreaData.AreaId).GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							ActivityTaskData taskData = enumerator2.Current;
							list.Add(new AreaTaskGridData(taskData, realmBetweenAreaData, this.ActivityBaseData));
						}
						continue;
					}
				}
				list.Add(new AreaLockGuideGridData(realmBetweenAreaData, this.ActivityBaseData));
			}
			return list;
		}

		// Token: 0x06040D07 RID: 265479 RVA: 0x0109EBE4 File Offset: 0x0109CDE4
		private int GetMissionTitleIndexByMenuIndex(List<RealmBetweenAreaData> areaDataList, int menuIndex)
		{
			int num = menuIndex;
			List<IMultiTemplateGridData> missionGridDataList = this.GetMissionGridDataList(areaDataList);
			for (int i = 0; i < missionGridDataList.Count; i++)
			{
				if (missionGridDataList[i].GetTemplateIndex() == 0)
				{
					num--;
					if (num < 0)
					{
						return i;
					}
				}
			}
			return 0;
		}

		// Token: 0x06040D08 RID: 265480 RVA: 0x0109EC28 File Offset: 0x0109CE28
		private void RebuildAreaMissionTitleOffsets(List<IMultiTemplateGridData> flatDataList)
		{
			this.AreaMissionTitleOffsets.Clear();
			UUIMultiTemplateScrollViewComponent scrollView = this.AreaMissionItemScroll.ScrollView;
			float num = 0f;
			for (int i = 0; i < flatDataList.Count; i++)
			{
				if (flatDataList[i].GetTemplateIndex() == 0)
				{
					this.AreaMissionTitleOffsets.Add(num);
				}
				num += scrollView.GetLineHeightWhenVertical(i);
			}
		}

		// Token: 0x06040D09 RID: 265481 RVA: 0x0109EC88 File Offset: 0x0109CE88
		private void EnsureMissionScrollFitsLastArea(List<IMultiTemplateGridData> flatDataList)
		{
			UUIMultiTemplateScrollViewComponent scrollView = this.AreaMissionItemScroll.ScrollView;
			float height = scrollView.RootUIComp.Get().GetHeight();
			float num = 0f;
			for (int i = 0; i < flatDataList.Count; i++)
			{
				float lineHeightWhenVertical = scrollView.GetLineHeightWhenVertical(i);
				num = ((i > 0 && flatDataList[i].GetTemplateIndex() == 0) ? lineHeightWhenVertical : (num + lineHeightWhenVertical));
			}
			if (num < height)
			{
				FMargin contentPadding = scrollView.GetContentPadding();
				contentPadding.Bottom = height - num;
				scrollView.SetContentPadding(contentPadding);
			}
		}

		// Token: 0x06040D0A RID: 265482 RVA: 0x0109ED18 File Offset: 0x0109CF18
		private List<RealmBetweenAreaData> GetAreaDataList()
		{
			List<RealmBetweenAreaData> list = new List<RealmBetweenAreaData>();
			foreach (RealmBetweenAreaData realmBetweenAreaData in this.ActivityBaseData.GetAllAreaData())
			{
				if (realmBetweenAreaData.TravelTaskIdSet.Count > 0)
				{
					list.Add(realmBetweenAreaData);
				}
			}
			list.Sort((RealmBetweenAreaData a, RealmBetweenAreaData b) => a.AreaId - b.AreaId);
			return list;
		}

		// Token: 0x06040D0B RID: 265483 RVA: 0x0109EDAC File Offset: 0x0109CFAC
		private void SetMenuTabSelected(int index, bool bOn, bool bFireEvent)
		{
			this.TabSelectIndex = index;
			if (index >= 0 && index < this.MenuTabItems.Count)
			{
				this.MenuTabItems[index].SetSelected(bOn, bFireEvent);
			}
		}

		// Token: 0x06040D0C RID: 265484 RVA: 0x0109EDDC File Offset: 0x0109CFDC
		private int? GetNewMenuTab()
		{
			List<RealmBetweenAreaData> areaDataList = this.GetAreaDataList();
			int? result = null;
			for (int i = 0; i < areaDataList.Count; i++)
			{
				int areaId = areaDataList[i].AreaId;
				bool areaNewUnlockState = this.ActivityBaseData.GetAreaNewUnlockState(areaId);
				if (result == null && areaNewUnlockState)
				{
					result = new int?(i);
				}
			}
			return result;
		}

		// Token: 0x06040D0D RID: 265485 RVA: 0x0109EE3C File Offset: 0x0109D03C
		private void OnContentUpdate(FVector2D _)
		{
			if (this.IsRefreshEnd || this.MenuTabItems.Count == 0 || this.AreaMissionTitleOffsets.Count == 0)
			{
				return;
			}
			float anchorOffsetY = this.AreaMissionItemScroll.ScrollView.ContentUIItem.Get().GetAnchorOffsetY();
			int num = this.FindAreaIndexByScroll(anchorOffsetY);
			if (num == this.TabSelectIndex)
			{
				return;
			}
			this.SetMenuTabSelected(this.TabSelectIndex, false, false);
			this.SetMenuTabSelected(num, true, false);
			if (num >= 0 && num < this.MenuTabItems.Count)
			{
				this.MenuTabItems[num].MarkNewUnlockSeen();
			}
			this.EnsureMenuTabVisible(num);
		}

		// Token: 0x06040D0E RID: 265486 RVA: 0x0109EEE0 File Offset: 0x0109D0E0
		private int FindAreaIndexByScroll(float scrollY)
		{
			int i = 0;
			int num = this.AreaMissionTitleOffsets.Count - 1;
			while (i < num)
			{
				int num2 = (i + num + 1) / 2;
				if (this.AreaMissionTitleOffsets[num2] <= scrollY)
				{
					i = num2;
				}
				else
				{
					num = num2 - 1;
				}
			}
			return i;
		}

		// Token: 0x06040D0F RID: 265487 RVA: 0x0109EF24 File Offset: 0x0109D124
		private void EnsureMenuTabVisible(int menuTabIndex)
		{
			UUIScrollViewComponent scrollView = base.GetScrollView(2);
			UUIItem uuiitem = (menuTabIndex >= 0 && menuTabIndex < this.MenuTabItems.Count) ? this.MenuTabItems[menuTabIndex].GetRootItem() : null;
			if (uuiitem == null)
			{
				return;
			}
			float height = scrollView.RootUIComp.Get().Height;
			float height2 = scrollView.ContentUIItem.Get().GetHeight();
			float num = Math.Max(0f, height2 - height);
			if (num <= 0f)
			{
				return;
			}
			float num2 = -uuiitem.GetAnchorOffsetY();
			float num3 = num2 + uuiitem.GetHeight();
			float anchorOffsetY = scrollView.ContentUIItem.Get().GetAnchorOffsetY();
			float num4 = anchorOffsetY + height;
			if (num2 >= anchorOffsetY && num3 <= num4)
			{
				return;
			}
			float num5 = (num2 < anchorOffsetY) ? num2 : (num3 - height);
			scrollView.SetScrollProgress(Math.Max(0f, Math.Min(1f, num5 / num)));
		}

		// Token: 0x06040D10 RID: 265488 RVA: 0x0109F014 File Offset: 0x0109D214
		private void TabSelectedCallBack(RealmBetweenAreaData tabData, int index)
		{
			if (index != this.TabSelectIndex)
			{
				this.SetMenuTabSelected(this.TabSelectIndex, false, false);
			}
			List<RealmBetweenAreaData> areaDataList = this.GetAreaDataList();
			int missionTitleIndexByMenuIndex = this.GetMissionTitleIndexByMenuIndex(areaDataList, index);
			this.TabSelectIndex = index;
			this.AreaMissionItemScroll.ScrollView.StopMovement();
			this.AreaMissionItemScroll.ScrollView.ScrollToGridIndex(missionTitleIndexByMenuIndex, true);
		}

		// Token: 0x06040D11 RID: 265489 RVA: 0x0109F074 File Offset: 0x0109D274
		public UniTask PlayStartSequence()
		{
			RealmBetweenTravelTaskView.<PlayStartSequence>d__30 <PlayStartSequence>d__;
			<PlayStartSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayStartSequence>d__.<>4__this = this;
			<PlayStartSequence>d__.<>1__state = -1;
			<PlayStartSequence>d__.<>t__builder.Start<RealmBetweenTravelTaskView.<PlayStartSequence>d__30>(ref <PlayStartSequence>d__);
			return <PlayStartSequence>d__.<>t__builder.Task;
		}

		// Token: 0x06040D12 RID: 265490 RVA: 0x0109F0B8 File Offset: 0x0109D2B8
		public UniTask PlayCloseSequence()
		{
			RealmBetweenTravelTaskView.<PlayCloseSequence>d__31 <PlayCloseSequence>d__;
			<PlayCloseSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayCloseSequence>d__.<>4__this = this;
			<PlayCloseSequence>d__.<>1__state = -1;
			<PlayCloseSequence>d__.<>t__builder.Start<RealmBetweenTravelTaskView.<PlayCloseSequence>d__31>(ref <PlayCloseSequence>d__);
			return <PlayCloseSequence>d__.<>t__builder.Task;
		}

		// Token: 0x06040D13 RID: 265491 RVA: 0x0109F0FB File Offset: 0x0109D2FB
		private bool IsSelectedOn(RealmBetweenAreaData tabData, int index)
		{
			return this.TabSelectIndex == index;
		}

		// Token: 0x06040D14 RID: 265492 RVA: 0x0109F108 File Offset: 0x0109D308
		private void OnClickHelpBtn()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(this.ActivityBaseData.LocalConfig.Value.HelpId);
		}

		// Token: 0x040245DF RID: 148959
		[Nullable(2)]
		private PopupCaptionItem CaptionComponent;

		// Token: 0x040245E0 RID: 148960
		private ActivityRealmBetweenData ActivityBaseData;

		// Token: 0x040245E1 RID: 148961
		[Nullable(2)]
		private RewardPanel PanelReward;

		// Token: 0x040245E2 RID: 148962
		private bool IsRefreshEnd;

		// Token: 0x040245E3 RID: 148963
		private int TabSelectIndex = -1;

		// Token: 0x040245E4 RID: 148964
		private readonly List<RealmBetweenTabItem> MenuTabItems = new List<RealmBetweenTabItem>();

		// Token: 0x040245E5 RID: 148965
		[Nullable(2)]
		private MultiTemplateScrollView AreaMissionItemScroll;

		// Token: 0x040245E6 RID: 148966
		private readonly List<float> AreaMissionTitleOffsets = new List<float>();

		// Token: 0x040245E7 RID: 148967
		[Nullable(2)]
		private LevelSequencePlayer SequencePlayer;
	}
}
