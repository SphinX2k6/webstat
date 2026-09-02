using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x02006335 RID: 25397
	[NullableContext(2)]
	[Nullable(0)]
	public class SpringMonorRewardView : UiTickViewBase
	{
		// Token: 0x0603FCAE RID: 261294 RVA: 0x0105BA9B File Offset: 0x01059C9B
		[NullableContext(1)]
		public SpringMonorRewardView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603FCAF RID: 261295 RVA: 0x0105BAAC File Offset: 0x01059CAC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
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
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickPreview));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603FCB0 RID: 261296 RVA: 0x0105BC18 File Offset: 0x01059E18
		protected override UniTask OnBeforeStartAsync()
		{
			SpringMonorRewardView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpringMonorRewardView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603FCB1 RID: 261297 RVA: 0x0105BC5C File Offset: 0x01059E5C
		protected override void OnStart()
		{
			this.InitCaption();
			this.InitQuestScroll();
			this.InitTabLayout();
			SpringManorRewardBottomItem bottomItem = this.BottomItem;
			if (bottomItem != null)
			{
				bottomItem.Refresh();
			}
			this.TimeTextItem = base.GetText(7);
			this.FormatTimeText = ConfigMultiTextLang.GetLocalTextNew("ActivityRemainingTime", null);
		}

		// Token: 0x0603FCB2 RID: 261298 RVA: 0x0105BCAC File Offset: 0x01059EAC
		protected override void OnBeforeHide()
		{
			GameSettingsDeviceRender instance = Singleton<GameSettingsDeviceRender>.Instance;
			UiViewInfo viewInfo = this.ViewInfo;
			EUiViewName? euiViewName = (viewInfo != null) ? new EUiViewName?(viewInfo.Name) : null;
			instance.CancelPerformanceLimit((euiViewName != null) ? euiViewName.GetValueOrDefault() : null);
		}

		// Token: 0x0603FCB3 RID: 261299 RVA: 0x0105BCFC File Offset: 0x01059EFC
		protected override void OnTick(float delta)
		{
			string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(ModelBase<SpringManorModel>.Instance.ActivityData.EndShowTime, this.FormatTimeText);
			UUIText timeTextItem = this.TimeTextItem;
			if (timeTextItem == null)
			{
				return;
			}
			timeTextItem.SetText(remainTimeText, true);
		}

		// Token: 0x0603FCB4 RID: 261300 RVA: 0x0105BD3B File Offset: 0x01059F3B
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.SpringManorTaskUpdateNotify, new Action(this.RefreshView));
		}

		// Token: 0x0603FCB5 RID: 261301 RVA: 0x0105BD59 File Offset: 0x01059F59
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.SpringManorTaskUpdateNotify, new Action(this.RefreshView));
		}

		// Token: 0x0603FCB6 RID: 261302 RVA: 0x0105BD77 File Offset: 0x01059F77
		private void RefreshView()
		{
			GenericLayout<TabItem, int> tabLayout = this.TabLayout;
			if (tabLayout != null)
			{
				tabLayout.RefreshWithoutDataSync();
			}
			this.RefreshQuestScroll(true);
			SpringManorRewardBottomItem bottomItem = this.BottomItem;
			if (bottomItem == null)
			{
				return;
			}
			bottomItem.Refresh();
		}

		// Token: 0x0603FCB7 RID: 261303 RVA: 0x0105BDA4 File Offset: 0x01059FA4
		private void InitCaption()
		{
			this.CaptionItem.SetCloseCallBack(new Action(this.OnClickClose));
			PopupCaptionItem captionItem = this.CaptionItem;
			if (captionItem == null)
			{
				return;
			}
			captionItem.SetHelpCallBack(delegate
			{
				ControllerBase<HelpController>.Instance.OpenHelpById(502);
			});
		}

		// Token: 0x0603FCB8 RID: 261304 RVA: 0x0105BDF8 File Offset: 0x01059FF8
		private void InitTabLayout()
		{
			this.TabLayout = new GenericLayout<TabItem, int>(base.GetLayoutBase(3), new Func<TabItem>(this.CreateTabItem), base.GetItem(4).GetOwner() as AUIBaseActor, false, true);
			List<int> rewardTaskTabList = ModelBase<SpringManorModel>.Instance.GetRewardTaskTabList();
			this.TabLayout.RefreshByData(rewardTaskTabList, delegate
			{
				GenericLayout<TabItem, int> tabLayout = this.TabLayout;
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

		// Token: 0x0603FCB9 RID: 261305 RVA: 0x0105BE5A File Offset: 0x0105A05A
		[NullableContext(1)]
		private TabItem CreateTabItem()
		{
			TabItem tabItem = new TabItem();
			tabItem.SetTabClickCallback(new Action<int>(this.OnClickTab));
			return tabItem;
		}

		// Token: 0x0603FCBA RID: 261306 RVA: 0x0105BE73 File Offset: 0x0105A073
		private void OnClickTab(int tabIndex)
		{
			this.SelectedTabIndex = tabIndex;
			GenericLayout<TabItem, int> tabLayout = this.TabLayout;
			if (tabLayout != null)
			{
				tabLayout.SelectGridProxy(tabIndex, false);
			}
			this.RefreshQuestScroll(false);
		}

		// Token: 0x0603FCBB RID: 261307 RVA: 0x0105BE96 File Offset: 0x0105A096
		private void InitQuestScroll()
		{
			this.QuestScroll = new GenericScrollViewNew<SpringManorRewardQuestItem, int>(base.GetScrollViewWithScrollbar(1), new Func<SpringManorRewardQuestItem>(this.CreateQuestItem), null, false, null);
		}

		// Token: 0x0603FCBC RID: 261308 RVA: 0x0105BEBC File Offset: 0x0105A0BC
		private void RefreshQuestScroll(bool keepPosition = true)
		{
			List<int> rewardTaskListByTabId = ModelBase<SpringManorModel>.Instance.ActivityData.GetRewardTaskListByTabId(this.SelectedTabIndex);
			rewardTaskListByTabId.Sort(delegate(int idA, int idB)
			{
				ActivitySpringManorTaskData rewardTaskData = ModelBase<SpringManorModel>.Instance.ActivityData.GetRewardTaskData(idA);
				ActivitySpringManorTaskData rewardTaskData2 = ModelBase<SpringManorModel>.Instance.ActivityData.GetRewardTaskData(idB);
				EActivityTaskState status = rewardTaskData.Status;
				EActivityTaskState status2 = rewardTaskData2.Status;
				if (status != status2)
				{
					return status - status2;
				}
				return rewardTaskData.Sort - rewardTaskData.Sort;
			});
			Action callBack = null;
			if (!keepPosition)
			{
				callBack = delegate()
				{
					GenericScrollViewNew<SpringManorRewardQuestItem, int> questScroll2 = this.QuestScroll;
					if (questScroll2 == null)
					{
						return;
					}
					questScroll2.ScrollToTop(0);
				};
			}
			GenericScrollViewNew<SpringManorRewardQuestItem, int> questScroll = this.QuestScroll;
			if (questScroll == null)
			{
				return;
			}
			questScroll.RefreshByData(rewardTaskListByTabId, callBack, true);
		}

		// Token: 0x0603FCBD RID: 261309 RVA: 0x0105BF29 File Offset: 0x0105A129
		[NullableContext(1)]
		private SpringManorRewardQuestItem CreateQuestItem()
		{
			SpringManorRewardQuestItem springManorRewardQuestItem = new SpringManorRewardQuestItem();
			springManorRewardQuestItem.SetReceiveClickCallback(new Action(this.OnClickTaskReceive));
			springManorRewardQuestItem.OnSkipClick = new Action<ESpringRewardTaskSkipType>(this.OnClickTaskSkip);
			return springManorRewardQuestItem;
		}

		// Token: 0x0603FCBE RID: 261310 RVA: 0x0105BF54 File Offset: 0x0105A154
		private void OnClickTaskSkip(ESpringRewardTaskSkipType skipType)
		{
			if (skipType == ESpringRewardTaskSkipType.WorldPosition)
			{
				base.CloseMe(null);
			}
		}

		// Token: 0x0603FCBF RID: 261311 RVA: 0x0105BF61 File Offset: 0x0105A161
		private void OnClickTaskReceive()
		{
			ControllerBase<SpringManorController>.Instance.RequestTaskRewardReceive(this.SelectedTabIndex, new Action(this.RefreshView));
		}

		// Token: 0x0603FCC0 RID: 261312 RVA: 0x0105BF7F File Offset: 0x0105A17F
		private void OnClickClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603FCC1 RID: 261313 RVA: 0x0105BF88 File Offset: 0x0105A188
		private void OnClickPreview()
		{
			SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
			int? num = (instance != null) ? new int?(instance.GetActivityConfig().VisionSkinItemId) : null;
			ControllerBase<CalabashController>.Instance.JumpToCalabashCollectTabViewOnlyShow(num.Value, true);
		}

		// Token: 0x04023D3D RID: 146749
		private PopupCaptionItem CaptionItem;

		// Token: 0x04023D3E RID: 146750
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<TabItem, int> TabLayout;

		// Token: 0x04023D3F RID: 146751
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<SpringManorRewardQuestItem, int> QuestScroll;

		// Token: 0x04023D40 RID: 146752
		private int SelectedTabIndex = -1;

		// Token: 0x04023D41 RID: 146753
		private SpringManorRewardBottomItem BottomItem;

		// Token: 0x04023D42 RID: 146754
		private UUIText TimeTextItem;

		// Token: 0x04023D43 RID: 146755
		private string FormatTimeText;
	}
}
