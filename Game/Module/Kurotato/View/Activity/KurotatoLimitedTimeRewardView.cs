using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Kurotato.Data;
using CSharpScript.Game.Module.UiNavigation;
using CSharpScript.Game.Module.UiNavigation.UIComponent;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Activity
{
	// Token: 0x02005ADC RID: 23260
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoLimitedTimeRewardView : UiTickViewBase
	{
		// Token: 0x0603ACE1 RID: 240865 RVA: 0x00EE9AF0 File Offset: 0x00EE7CF0
		public KurotatoLimitedTimeRewardView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603ACE2 RID: 240866 RVA: 0x00EE9B14 File Offset: 0x00EE7D14
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
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
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickDetail));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603ACE3 RID: 240867 RVA: 0x00EE9CC4 File Offset: 0x00EE7EC4
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshKurotatoLimitRewardData, new Action(this.RefreshView));
		}

		// Token: 0x0603ACE4 RID: 240868 RVA: 0x00EE9CE2 File Offset: 0x00EE7EE2
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshKurotatoLimitRewardData, new Action(this.RefreshView));
		}

		// Token: 0x0603ACE5 RID: 240869 RVA: 0x00EE9D00 File Offset: 0x00EE7F00
		protected override void OnStart()
		{
			this.InitQuestScroll();
			this.InitTabLayout();
			KurotatoLimitedTimeRewardBottomItem bottomItem = this.BottomItem;
			if (bottomItem != null)
			{
				bottomItem.Refresh();
			}
			this.TimeTextItem = base.GetText(7);
			this.FormatTimeText = ConfigMultiTextLang.GetLocalTextNew("ActivityRemainingTime", null);
			BackgroundCard? config = ConfigBackgroundCardById.GetConfig(ModelBase<KurotatoModel>.Instance.GetActivityConfig().Value.PersonalCardId, true);
			if (config == null)
			{
				return;
			}
			UUIText text = base.GetText(8);
			if (text != null)
			{
				text.ShowTextNew(config.Value.Title);
			}
			UUIText text2 = base.GetText(9);
			if (text2 == null)
			{
				return;
			}
			text2.ShowTextNew(config.Value.AttributesDescription);
		}

		// Token: 0x0603ACE6 RID: 240870 RVA: 0x00EE9DB8 File Offset: 0x00EE7FB8
		private void InitTabLayout()
		{
			this.TabLayout = new GenericLayout<TabItem, KurotatoRewardTab>(base.GetHorizontalLayout(3), new Func<TabItem>(this.CreateTabItem), base.GetItem(4).GetOwner() as AUIBaseActor, false, true);
			List<KurotatoRewardTab> data = ConfigBase<KurotatoConfig>.Instance.GetAllRewardTabConfig().ToList<KurotatoRewardTab>();
			this.TabLayout.RefreshByData(data, delegate
			{
				GenericLayout<TabItem, KurotatoRewardTab> tabLayout = this.TabLayout;
				if (tabLayout == null)
				{
					return;
				}
				TabItem layoutItemByIndex = tabLayout.GetLayoutItemByIndex(0);
				if (layoutItemByIndex == null)
				{
					return;
				}
				layoutItemByIndex.SetToggleSelect(true, true);
			}, false);
		}

		// Token: 0x0603ACE7 RID: 240871 RVA: 0x00EE9E1F File Offset: 0x00EE801F
		private TabItem CreateTabItem()
		{
			TabItem tabItem = new TabItem();
			tabItem.SetTabClickCallback(new Action<int>(this.OnClickTab));
			return tabItem;
		}

		// Token: 0x0603ACE8 RID: 240872 RVA: 0x00EE9E38 File Offset: 0x00EE8038
		private void OnClickTab(int tabIndex)
		{
			this.SelectedTabIndex = tabIndex;
			GenericLayout<TabItem, KurotatoRewardTab> tabLayout = this.TabLayout;
			if (tabLayout != null)
			{
				tabLayout.SelectGridProxy(tabIndex, false);
			}
			this.RefreshQuestScroll();
			GenericScrollViewNew<KurotatoRewardItem, KurotatoRewardItemData> questScroll = this.QuestScroll;
			if (questScroll == null)
			{
				return;
			}
			questScroll.ScrollToTopByIndex(0);
		}

		// Token: 0x0603ACE9 RID: 240873 RVA: 0x00EE9E6B File Offset: 0x00EE806B
		private void InitQuestScroll()
		{
			this.QuestScroll = new GenericScrollViewNew<KurotatoRewardItem, KurotatoRewardItemData>(base.GetScrollViewWithScrollbar(1), new Func<KurotatoRewardItem>(this.CreateQuestItem), null, false, null);
		}

		// Token: 0x0603ACEA RID: 240874 RVA: 0x00EE9E90 File Offset: 0x00EE8090
		private void RefreshQuestScroll()
		{
			List<KurotatoLimitedTimeRewardItemData> limitedTimeTaskListByTabId = ControllerBase<KurotatoActivityController>.Instance.GetActivityData().GetLimitedTimeTaskListByTabId(this.SelectedTabIndex);
			limitedTimeTaskListByTabId.Sort((KurotatoLimitedTimeRewardItemData a, KurotatoLimitedTimeRewardItemData b) => Array.IndexOf<EKurotatoRewardStatus>(this.StatusOrder, a.Status) - Array.IndexOf<EKurotatoRewardStatus>(this.StatusOrder, b.Status));
			GenericScrollViewNew<KurotatoRewardItem, KurotatoRewardItemData> questScroll = this.QuestScroll;
			if (questScroll == null)
			{
				return;
			}
			questScroll.RefreshByData(limitedTimeTaskListByTabId, null, true);
		}

		// Token: 0x0603ACEB RID: 240875 RVA: 0x00EE9ED8 File Offset: 0x00EE80D8
		private KurotatoRewardItem CreateQuestItem()
		{
			KurotatoRewardItem kurotatoRewardItem = new KurotatoRewardItem();
			kurotatoRewardItem.SetReceiveClickCallback(new Action(this.OnClickTaskReceive));
			return kurotatoRewardItem;
		}

		// Token: 0x0603ACEC RID: 240876 RVA: 0x00EE9EF4 File Offset: 0x00EE80F4
		protected override void OnTick(float delta)
		{
			KurotatoActivityData activityData = ControllerBase<KurotatoActivityController>.Instance.GetActivityData();
			if (activityData == null)
			{
				base.CloseMe(null);
				return;
			}
			if (!activityData.CheckIfInLimitTime())
			{
				base.CloseMe(null);
				return;
			}
			string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(activityData.EndRewardTime, this.FormatTimeText);
			UUIText timeTextItem = this.TimeTextItem;
			if (timeTextItem == null)
			{
				return;
			}
			timeTextItem.SetText(remainTimeText, true);
		}

		// Token: 0x0603ACED RID: 240877 RVA: 0x00EE9F50 File Offset: 0x00EE8150
		protected override UniTask OnBeforeStartAsync()
		{
			KurotatoLimitedTimeRewardView.<OnBeforeStartAsync>d__21 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<KurotatoLimitedTimeRewardView.<OnBeforeStartAsync>d__21>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603ACEE RID: 240878 RVA: 0x00EE9F93 File Offset: 0x00EE8193
		protected override void OnBeforeShow()
		{
			HotKeyComponentUtil.SetupComponents<RewardTakeComponent>(this.RootItem, EHotKeyCacheKey.RewardTakeDataCallback, () => ControllerBase<KurotatoActivityController>.Instance.GetActivityData().GetLastNotTakenScoreRewardIndex());
			this.RefreshView();
		}

		// Token: 0x0603ACEF RID: 240879 RVA: 0x00EE9FC6 File Offset: 0x00EE81C6
		private void OnCloseClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603ACF0 RID: 240880 RVA: 0x00EE9FCF File Offset: 0x00EE81CF
		private void RefreshView()
		{
			KurotatoLimitedTimeRewardBottomItem bottomItem = this.BottomItem;
			if (bottomItem != null)
			{
				bottomItem.Refresh();
			}
			this.RefreshQuestScroll();
		}

		// Token: 0x0603ACF1 RID: 240881 RVA: 0x00EE9FE8 File Offset: 0x00EE81E8
		private void OnClickDetail()
		{
			KurotatoActivityConfig? activityConfig = ModelBase<KurotatoModel>.Instance.GetActivityConfig();
			if (activityConfig == null)
			{
				return;
			}
			int personalCardId = activityConfig.Value.PersonalCardId;
			if (personalCardId <= 0)
			{
				return;
			}
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(personalCardId, true, null);
		}

		// Token: 0x0603ACF2 RID: 240882 RVA: 0x00EEA02C File Offset: 0x00EE822C
		private void OnClickTaskReceive()
		{
			List<int> limitedTimeTaskCanClaimableIdListByTabId = ControllerBase<KurotatoActivityController>.Instance.GetActivityData().GetLimitedTimeTaskCanClaimableIdListByTabId(this.SelectedTabIndex);
			if (limitedTimeTaskCanClaimableIdListByTabId.Count <= 0)
			{
				return;
			}
			ControllerBase<KurotatoActivityController>.Instance.RequestLimitTimeReward(limitedTimeTaskCanClaimableIdListByTabId, new Action(this.RefreshView));
		}

		// Token: 0x040213B6 RID: 136118
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x040213B7 RID: 136119
		[Nullable(2)]
		private KurotatoLimitedTimeRewardBottomItem BottomItem;

		// Token: 0x040213B8 RID: 136120
		[Nullable(2)]
		private UUIText TimeTextItem;

		// Token: 0x040213B9 RID: 136121
		[Nullable(2)]
		private string FormatTimeText;

		// Token: 0x040213BA RID: 136122
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<KurotatoRewardItem, KurotatoRewardItemData> QuestScroll;

		// Token: 0x040213BB RID: 136123
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<TabItem, KurotatoRewardTab> TabLayout;

		// Token: 0x040213BC RID: 136124
		private int SelectedTabIndex = -1;

		// Token: 0x040213BD RID: 136125
		private readonly EKurotatoRewardStatus[] StatusOrder = new EKurotatoRewardStatus[]
		{
			EKurotatoRewardStatus.CanReceive,
			EKurotatoRewardStatus.Doing,
			EKurotatoRewardStatus.Taken
		};

		// Token: 0x0200BB0B RID: 47883
		[NullableContext(0)]
		private enum EComponents
		{
			// Token: 0x04039BAC RID: 236460
			Caption,
			// Token: 0x04039BAD RID: 236461
			QuestScroll,
			// Token: 0x04039BAE RID: 236462
			QuestItem,
			// Token: 0x04039BAF RID: 236463
			TabLayout,
			// Token: 0x04039BB0 RID: 236464
			TabItem,
			// Token: 0x04039BB1 RID: 236465
			PanelBottom,
			// Token: 0x04039BB2 RID: 236466
			DetailButton,
			// Token: 0x04039BB3 RID: 236467
			TextDelayTime,
			// Token: 0x04039BB4 RID: 236468
			DetailName,
			// Token: 0x04039BB5 RID: 236469
			DetailDesc
		}
	}
}
