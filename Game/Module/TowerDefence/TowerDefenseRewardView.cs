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

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EE0 RID: 20192
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefenseRewardView : UiTickViewBase
	{
		// Token: 0x06034265 RID: 213605 RVA: 0x00D0A244 File Offset: 0x00D08444
		public TowerDefenseRewardView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06034266 RID: 213606 RVA: 0x00D0A250 File Offset: 0x00D08450
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUILoopScrollViewComponent));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06034267 RID: 213607 RVA: 0x00D0A340 File Offset: 0x00D08540
		protected override UniTask OnBeforeStartAsync()
		{
			TowerDefenseRewardView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TowerDefenseRewardView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034268 RID: 213608 RVA: 0x00D0A383 File Offset: 0x00D08583
		private void OnClickBackBtn()
		{
			base.CloseMe(null);
		}

		// Token: 0x06034269 RID: 213609 RVA: 0x00D0A38C File Offset: 0x00D0858C
		protected override void OnStart()
		{
			this.MenuLayout = new GenericScrollViewNew<TowerDefenseRewardMenuItem, TowerDefenseRewardMenuItemData>(base.GetScrollViewWithScrollbar(1), new Func<TowerDefenseRewardMenuItem>(this.InitMenuItem), null, false, null);
			this.RewardLayout = new LoopScrollView<TowerDefenseRewardItem, IActivityRewardData>(base.GetLoopScrollViewComponent(5), base.GetLoopScrollViewComponent(5).TemplateGrid, new Func<TowerDefenseRewardItem>(this.InitRewardItem), true);
			Singleton<EventSystem>.Instance.Add<IActivityRewardViewData>(EEventName.RefreshCommonActivityRewardPopUpView, new Action<IActivityRewardViewData>(this.OnRefreshByData));
		}

		// Token: 0x0603426A RID: 213610 RVA: 0x00D0A406 File Offset: 0x00D08606
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove<IActivityRewardViewData>(EEventName.RefreshCommonActivityRewardPopUpView, new Action<IActivityRewardViewData>(this.OnRefreshByData));
		}

		// Token: 0x0603426B RID: 213611 RVA: 0x00D0A424 File Offset: 0x00D08624
		protected override void OnBeforeShow()
		{
			if (this.Data == null)
			{
				return;
			}
			this.Refresh();
			this.LeftTimeActive = this.RefreshLeftTime();
			this.LeftTimeAccumulator = 0f;
		}

		// Token: 0x0603426C RID: 213612 RVA: 0x00D0A44C File Offset: 0x00D0864C
		protected override void OnTick(float delta)
		{
			if (!this.LeftTimeActive)
			{
				return;
			}
			this.LeftTimeAccumulator += delta;
			if (this.LeftTimeAccumulator < 1f)
			{
				return;
			}
			this.LeftTimeAccumulator = 0f;
			this.LeftTimeActive = this.RefreshLeftTime();
		}

		// Token: 0x0603426D RID: 213613 RVA: 0x00D0A48A File Offset: 0x00D0868A
		private TowerDefenseRewardMenuItem InitMenuItem()
		{
			return new TowerDefenseRewardMenuItem
			{
				OnClick = new Action<int>(this.SelectTab)
			};
		}

		// Token: 0x0603426E RID: 213614 RVA: 0x00D0A4A3 File Offset: 0x00D086A3
		private TowerDefenseRewardItem InitRewardItem()
		{
			return new TowerDefenseRewardItem();
		}

		// Token: 0x0603426F RID: 213615 RVA: 0x00D0A4AA File Offset: 0x00D086AA
		private void OnRefreshByData(IActivityRewardViewData data)
		{
			if (this.Data != null && data.Source != this.Data.Source)
			{
				return;
			}
			this.Data = data;
			this.RefreshMenuRedDots();
			this.RefreshRewardListByTabIndex(this.SelectedTabIndex);
		}

		// Token: 0x06034270 RID: 213616 RVA: 0x00D0A4E8 File Offset: 0x00D086E8
		private void Refresh()
		{
			List<IActivityRewardDataPage> dataPageList = this.Data.DataPageList;
			if (this.SelectedTabIndex >= dataPageList.Count)
			{
				this.SelectedTabIndex = 0;
			}
			List<TowerDefenseRewardMenuItemData> list = new List<TowerDefenseRewardMenuItemData>();
			for (int i = 0; i < dataPageList.Count; i++)
			{
				list.Add(new TowerDefenseRewardMenuItemData
				{
					Page = dataPageList[i],
					Index = i,
					IsSelected = (i == this.SelectedTabIndex),
					HasRedDot = this.CheckPageHasRedDot(dataPageList[i])
				});
			}
			GenericScrollViewNew<TowerDefenseRewardMenuItem, TowerDefenseRewardMenuItemData> menuLayout = this.MenuLayout;
			if (menuLayout != null)
			{
				menuLayout.RefreshByData(list, null, false);
			}
			this.RefreshRewardListByTabIndex(this.SelectedTabIndex);
		}

		// Token: 0x06034271 RID: 213617 RVA: 0x00D0A590 File Offset: 0x00D08790
		private void RefreshMenuRedDots()
		{
			List<IActivityRewardDataPage> dataPageList = this.Data.DataPageList;
			for (int i = 0; i < dataPageList.Count; i++)
			{
				GenericScrollViewNew<TowerDefenseRewardMenuItem, TowerDefenseRewardMenuItemData> menuLayout = this.MenuLayout;
				TowerDefenseRewardMenuItem towerDefenseRewardMenuItem = (menuLayout != null) ? menuLayout.GetScrollItemByIndex(i) : null;
				if (towerDefenseRewardMenuItem != null)
				{
					towerDefenseRewardMenuItem.SetRedDot(this.CheckPageHasRedDot(dataPageList[i]));
				}
			}
		}

		// Token: 0x06034272 RID: 213618 RVA: 0x00D0A5E8 File Offset: 0x00D087E8
		private void SelectTab(int index)
		{
			if (index == this.SelectedTabIndex)
			{
				return;
			}
			int selectedTabIndex = this.SelectedTabIndex;
			this.SelectedTabIndex = index;
			GenericScrollViewNew<TowerDefenseRewardMenuItem, TowerDefenseRewardMenuItemData> menuLayout = this.MenuLayout;
			if (menuLayout != null)
			{
				TowerDefenseRewardMenuItem scrollItemByIndex = menuLayout.GetScrollItemByIndex(selectedTabIndex);
				if (scrollItemByIndex != null)
				{
					scrollItemByIndex.SetSelected(false);
				}
			}
			GenericScrollViewNew<TowerDefenseRewardMenuItem, TowerDefenseRewardMenuItemData> menuLayout2 = this.MenuLayout;
			if (menuLayout2 != null)
			{
				TowerDefenseRewardMenuItem scrollItemByIndex2 = menuLayout2.GetScrollItemByIndex(index);
				if (scrollItemByIndex2 != null)
				{
					scrollItemByIndex2.SetSelected(true);
				}
			}
			this.RefreshRewardListByTabIndex(index);
		}

		// Token: 0x06034273 RID: 213619 RVA: 0x00D0A650 File Offset: 0x00D08850
		private void RefreshRewardListByTabIndex(int index)
		{
			if (index < 0 || index >= this.Data.DataPageList.Count)
			{
				LoopScrollView<TowerDefenseRewardItem, IActivityRewardData> rewardLayout = this.RewardLayout;
				if (rewardLayout == null)
				{
					return;
				}
				rewardLayout.RefreshByData(new List<IActivityRewardData>(), false, null, false);
				return;
			}
			else
			{
				IActivityRewardDataPage activityRewardDataPage = this.Data.DataPageList[index];
				LoopScrollView<TowerDefenseRewardItem, IActivityRewardData> rewardLayout2 = this.RewardLayout;
				if (rewardLayout2 == null)
				{
					return;
				}
				rewardLayout2.RefreshByData(activityRewardDataPage.DataList, false, null, true);
				return;
			}
		}

		// Token: 0x06034274 RID: 213620 RVA: 0x00D0A6B8 File Offset: 0x00D088B8
		private bool CheckPageHasRedDot(IActivityRewardDataPage page)
		{
			using (List<IActivityRewardData>.Enumerator enumerator = page.DataList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.RewardState == EActivityRewardState.Enable)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06034275 RID: 213621 RVA: 0x00D0A714 File Offset: 0x00D08914
		private bool RefreshLeftTime()
		{
			UUIItem item = base.GetItem(3);
			UUIText text = base.GetText(4);
			if (item == null || text == null)
			{
				return false;
			}
			ParsedTowerDefenseMsg orCreateParsedTowerDefenseMsg = ModelBase<TowerDefenseModel>.Instance.GetOrCreateParsedTowerDefenseMsg();
			if (orCreateParsedTowerDefenseMsg == null)
			{
				item.SetUIActive(false);
				return false;
			}
			ValueTuple<bool, string, long> timeVisibleAndRemainTime = ModelBase<ActivityModel>.Instance.GetTimeVisibleAndRemainTime(orCreateParsedTowerDefenseMsg, null);
			bool item2 = timeVisibleAndRemainTime.Item1;
			string item3 = timeVisibleAndRemainTime.Item2;
			long item4 = timeVisibleAndRemainTime.Item3;
			if (!item2 || item4 <= 0L)
			{
				item.SetUIActive(false);
				return false;
			}
			item.SetUIActive(true);
			text.SetText(item3, true);
			return true;
		}

		// Token: 0x0401E1C5 RID: 123333
		[Nullable(2)]
		private IActivityRewardViewData Data;

		// Token: 0x0401E1C6 RID: 123334
		[Nullable(2)]
		private PopupCaptionItem Caption;

		// Token: 0x0401E1C7 RID: 123335
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<TowerDefenseRewardMenuItem, TowerDefenseRewardMenuItemData> MenuLayout;

		// Token: 0x0401E1C8 RID: 123336
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<TowerDefenseRewardItem, IActivityRewardData> RewardLayout;

		// Token: 0x0401E1C9 RID: 123337
		private int SelectedTabIndex;

		// Token: 0x0401E1CA RID: 123338
		private float LeftTimeAccumulator;

		// Token: 0x0401E1CB RID: 123339
		private bool LeftTimeActive;

		// Token: 0x0200AE93 RID: 44691
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403633B RID: 222011
			public const int CaptionItem = 0;

			// Token: 0x0403633C RID: 222012
			public const int MenuScroll = 1;

			// Token: 0x0403633D RID: 222013
			public const int MenuItem = 2;

			// Token: 0x0403633E RID: 222014
			public const int LeftTimeItem = 3;

			// Token: 0x0403633F RID: 222015
			public const int LeftTimeTxt = 4;

			// Token: 0x04036340 RID: 222016
			public const int RewardScroll = 5;
		}
	}
}
