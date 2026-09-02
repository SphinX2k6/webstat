using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BossPiling.View
{
	// Token: 0x02005EFF RID: 24319
	[NullableContext(1)]
	[Nullable(0)]
	public class BossPilingTaskView : UiTickViewBase
	{
		// Token: 0x0603D175 RID: 250229 RVA: 0x00F84306 File Offset: 0x00F82506
		public BossPilingTaskView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603D176 RID: 250230 RVA: 0x00F84310 File Offset: 0x00F82510
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D177 RID: 250231 RVA: 0x00F84400 File Offset: 0x00F82600
		protected override void OnStart()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnBossPilingReward, new Action(this.RefreshRewardLayout));
			this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
			this.CaptionItem.SetCloseCallBack(delegate
			{
				base.CloseMe(null);
			});
			this.CaptionItem.SetTitleByTextIdAndArgNew("BossPilingActivity_RewardTitle", Array.Empty<object>());
			this.TabDataLayout = new GenericLayout<BossPilingRewardTabItem, int>(base.GetVerticalLayout(1), new Func<BossPilingRewardTabItem>(this.CreateRewardTabItem), null, false, true);
			this.RewardLayout = new GenericLayout<BossPilingRewardItem, ActivityRewardData>(base.GetVerticalLayout(3), new Func<BossPilingRewardItem>(this.CreateRewardItem), null, false, true);
			this.ActivityData = ModelBase<BossPilingModel>.Instance.GetActivityData();
			ValueTuple<bool, string, long> timeVisibleAndRemainTime = ModelBase<ActivityModel>.Instance.GetTimeVisibleAndRemainTime(this.ActivityData, null);
			bool item = timeVisibleAndRemainTime.Item1;
			string item2 = timeVisibleAndRemainTime.Item2;
			UUIText text = base.GetText(5);
			if (text != null)
			{
				text.SetUIActive(item);
			}
			UUIText text2 = base.GetText(5);
			if (text2 == null)
			{
				return;
			}
			text2.SetText(item2, true);
		}

		// Token: 0x0603D178 RID: 250232 RVA: 0x00F84500 File Offset: 0x00F82700
		protected override void OnBeforeShow()
		{
			List<int> taskTabList = this.ActivityData.GetTaskTabList();
			GenericLayout<BossPilingRewardTabItem, int> tabDataLayout = this.TabDataLayout;
			if (tabDataLayout == null)
			{
				return;
			}
			tabDataLayout.RefreshByData(taskTabList, null, true);
		}

		// Token: 0x0603D179 RID: 250233 RVA: 0x00F8452C File Offset: 0x00F8272C
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<IReadOnlySet<int>>(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
		}

		// Token: 0x0603D17A RID: 250234 RVA: 0x00F8454A File Offset: 0x00F8274A
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<IReadOnlySet<int>>(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
		}

		// Token: 0x0603D17B RID: 250235 RVA: 0x00F84568 File Offset: 0x00F82768
		private void OnActivityClose(IReadOnlySet<int> closeActivities)
		{
			ModelBase<BossPilingModel>.Instance.CloseActivityView(closeActivities);
		}

		// Token: 0x0603D17C RID: 250236 RVA: 0x00F84575 File Offset: 0x00F82775
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnBossPilingReward, new Action(this.RefreshRewardLayout));
		}

		// Token: 0x0603D17D RID: 250237 RVA: 0x00F84594 File Offset: 0x00F82794
		protected override void OnTick(float delta)
		{
			ValueTuple<bool, string, long> timeVisibleAndRemainTime = ModelBase<ActivityModel>.Instance.GetTimeVisibleAndRemainTime(this.ActivityData, null);
			bool item = timeVisibleAndRemainTime.Item1;
			string item2 = timeVisibleAndRemainTime.Item2;
			UUIText text = base.GetText(5);
			if (text != null)
			{
				text.SetUIActive(item);
			}
			UUIText text2 = base.GetText(5);
			if (text2 == null)
			{
				return;
			}
			text2.SetText(item2, true);
		}

		// Token: 0x0603D17E RID: 250238 RVA: 0x00F845E5 File Offset: 0x00F827E5
		private BossPilingRewardTabItem CreateRewardTabItem()
		{
			BossPilingRewardTabItem bossPilingRewardTabItem = new BossPilingRewardTabItem();
			bossPilingRewardTabItem.SetClickCallBack(new Action<BossPilingRewardTabItem>(this.ClickTabToggle));
			return bossPilingRewardTabItem;
		}

		// Token: 0x0603D17F RID: 250239 RVA: 0x00F845FE File Offset: 0x00F827FE
		private BossPilingRewardItem CreateRewardItem()
		{
			return new BossPilingRewardItem();
		}

		// Token: 0x0603D180 RID: 250240 RVA: 0x00F84605 File Offset: 0x00F82805
		private void ClickTabToggle(BossPilingRewardTabItem item)
		{
			BossPilingRewardTabItem currentSelectTabItem = this.CurrentSelectTabItem;
			if (currentSelectTabItem != null)
			{
				currentSelectTabItem.SetToggleUnCheck();
			}
			this.CurrentSelectTabItem = item;
			this.RefreshRewardLayout();
		}

		// Token: 0x0603D181 RID: 250241 RVA: 0x00F84628 File Offset: 0x00F82828
		private void RefreshRewardLayout()
		{
			if (this.CurrentSelectTabItem == null)
			{
				return;
			}
			List<ActivityRewardData> taskGroupByLevel = this.ActivityData.GetTaskGroupByLevel(this.CurrentSelectTabItem.GetLevelId());
			GenericLayout<BossPilingRewardItem, ActivityRewardData> rewardLayout = this.RewardLayout;
			if (rewardLayout == null)
			{
				return;
			}
			rewardLayout.RefreshByData(taskGroupByLevel, delegate
			{
				foreach (BossPilingRewardTabItem bossPilingRewardTabItem in this.TabDataLayout.GetLayoutItemList())
				{
					bossPilingRewardTabItem.RefreshRedDot();
				}
			}, true);
		}

		// Token: 0x0402243F RID: 140351
		private PopupCaptionItem CaptionItem;

		// Token: 0x04022440 RID: 140352
		private GenericLayout<BossPilingRewardTabItem, int> TabDataLayout;

		// Token: 0x04022441 RID: 140353
		[Nullable(2)]
		private BossPilingRewardTabItem CurrentSelectTabItem;

		// Token: 0x04022442 RID: 140354
		private GenericLayout<BossPilingRewardItem, ActivityRewardData> RewardLayout;

		// Token: 0x04022443 RID: 140355
		private BossPilingActivityData ActivityData;

		// Token: 0x0200BF01 RID: 48897
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403AC91 RID: 240785
			CaptionItem,
			// Token: 0x0403AC92 RID: 240786
			TabContentItem,
			// Token: 0x0403AC93 RID: 240787
			TabItem,
			// Token: 0x0403AC94 RID: 240788
			RewardContentItem,
			// Token: 0x0403AC95 RID: 240789
			RewardItem,
			// Token: 0x0403AC96 RID: 240790
			TimeRemain
		}
	}
}
