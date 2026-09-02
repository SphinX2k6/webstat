using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.WorldMap.SubViews.Popup;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005185 RID: 20869
	public class RoguelikeBlackFlowerPreviewView : UiViewBase
	{
		// Token: 0x06035B17 RID: 219927 RVA: 0x00D7D543 File Offset: 0x00D7B743
		[NullableContext(1)]
		public RoguelikeBlackFlowerPreviewView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06035B18 RID: 219928 RVA: 0x00D7D54C File Offset: 0x00D7B74C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent));
			this.ComponentRegisterInfos = list;
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
		}

		// Token: 0x06035B19 RID: 219929 RVA: 0x00D7D5C0 File Offset: 0x00D7B7C0
		protected override void OnStart()
		{
			this.RewardScroll = new GenericScrollViewNew<BlackFlowerRewardPreviewListItem, TLevelDropReward>(base.GetScrollViewWithScrollbar(2), new Func<BlackFlowerRewardPreviewListItem>(this.RewardPreviewItemCreateFunc), null, false, null);
			this.ExchangeRewardId = (this.OpenParam as RoguelikeBlackFlowerOpenParam).DropId;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "BlackFlower_RewardInfo", Array.Empty<object>());
		}

		// Token: 0x06035B1A RID: 219930 RVA: 0x00D7D61F File Offset: 0x00D7B81F
		protected override void OnBeforeShow()
		{
			this.ShowReward();
		}

		// Token: 0x06035B1B RID: 219931 RVA: 0x00D7D628 File Offset: 0x00D7B828
		private void ShowReward()
		{
			ExchangeReward? config = ConfigExchangeRewardById.GetConfig(this.ExchangeRewardId, true);
			List<TLevelDropReward> list = new List<TLevelDropReward>();
			foreach (DicIntInt dicIntInt in config.Value.RewardIdIter())
			{
				TLevelDropReward item = new TLevelDropReward
				{
					WorldLevel = dicIntInt.Key,
					DropId = dicIntInt.Value
				};
				list.Add(item);
			}
			list.Sort((TLevelDropReward a, TLevelDropReward b) => a.WorldLevel - b.WorldLevel);
			List<ValueTuple<int, int>> list2 = new List<ValueTuple<int, int>>();
			int curWorldLevel = ModelBase<WorldLevelModel>.Instance.CurWorldLevel;
			int num = 0;
			int selectIndex = 0;
			foreach (TLevelDropReward tlevelDropReward in list)
			{
				int worldLevel = tlevelDropReward.WorldLevel;
				int dropId = tlevelDropReward.DropId;
				list2.Add(new ValueTuple<int, int>(worldLevel, dropId));
				if (num < worldLevel && curWorldLevel >= worldLevel)
				{
					num = worldLevel;
					selectIndex = list2.Count - 1;
				}
			}
			GenericScrollViewNew<BlackFlowerRewardPreviewListItem, TLevelDropReward> rewardScroll = this.RewardScroll;
			if (rewardScroll == null)
			{
				return;
			}
			TTimerAction <>9__2;
			rewardScroll.RefreshByDataAsync(list, false).ContinueWith(delegate()
			{
				TimerSystemInstance gameplayTimeInstance = TimerSystem.GameplayTimeInstance;
				TTimerAction action;
				if ((action = <>9__2) == null)
				{
					action = (<>9__2 = delegate(float _)
					{
						this.RewardScroll.ScrollToTop(selectIndex);
					});
				}
				gameplayTimeInstance.Next(action, null, null);
			});
		}

		// Token: 0x06035B1C RID: 219932 RVA: 0x00D7D7A8 File Offset: 0x00D7B9A8
		[NullableContext(1)]
		private BlackFlowerRewardPreviewListItem RewardPreviewItemCreateFunc()
		{
			return new BlackFlowerRewardPreviewListItem();
		}

		// Token: 0x0401ED0F RID: 126223
		private int ExchangeRewardId;

		// Token: 0x0401ED10 RID: 126224
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<BlackFlowerRewardPreviewListItem, TLevelDropReward> RewardScroll;

		// Token: 0x0200B140 RID: 45376
		private class ERewardPreviewComponents
		{
			// Token: 0x04036F92 RID: 225170
			public const int TxtTitle = 1;

			// Token: 0x04036F93 RID: 225171
			public const int RewardScrollList = 2;
		}
	}
}
