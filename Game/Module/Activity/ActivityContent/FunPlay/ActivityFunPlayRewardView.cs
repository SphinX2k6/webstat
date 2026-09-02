using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.FunPlay
{
	// Token: 0x02006777 RID: 26487
	public class ActivityFunPlayRewardView : UiPanelBase
	{
		// Token: 0x06042060 RID: 270432 RVA: 0x010F0928 File Offset: 0x010EEB28
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickFinishButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06042061 RID: 270433 RVA: 0x010F0A54 File Offset: 0x010EEC54
		protected override void OnStart()
		{
			UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(1);
			this.RewardScrollView = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(scrollViewWithScrollbar, new Func<CommonItemSmallItemGrid>(this.<OnStart>g__Function1|3_0), null, false, null);
			this.AddEventListener();
		}

		// Token: 0x06042062 RID: 270434 RVA: 0x010F0A8A File Offset: 0x010EEC8A
		protected void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.ActivityFunPlayInfoRefresh, new Action(this.OnGetFunPlayReward));
		}

		// Token: 0x06042063 RID: 270435 RVA: 0x010F0AA8 File Offset: 0x010EECA8
		protected void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.ActivityFunPlayInfoRefresh, new Action(this.OnGetFunPlayReward));
		}

		// Token: 0x06042064 RID: 270436 RVA: 0x010F0AC6 File Offset: 0x010EECC6
		private void OnGetFunPlayReward()
		{
			this.Refresh();
		}

		// Token: 0x06042065 RID: 270437 RVA: 0x010F0ACE File Offset: 0x010EECCE
		[NullableContext(1)]
		private CommonItemSmallItemGrid CreatePropItem()
		{
			CommonItemSmallItemGrid commonItemSmallItemGrid = new CommonItemSmallItemGrid();
			commonItemSmallItemGrid.ShowReceivedCallBack = delegate(TItem _)
			{
				ActivityFunPlayChallengeData currentChallengeData = ModelBase<ActivityFunPlayModel>.Instance.GetCurrentChallengeData();
				return currentChallengeData != null && currentChallengeData.CheckRewardStatus(FunPlayChallengeRewardStatus.FunPlayRewarded);
			};
			return commonItemSmallItemGrid;
		}

		// Token: 0x06042066 RID: 270438 RVA: 0x010F0AFC File Offset: 0x010EECFC
		private void OnClickFinishButton()
		{
			ActivityFunPlayChallengeData currentChallengeData = ModelBase<ActivityFunPlayModel>.Instance.GetCurrentChallengeData();
			int? num = (currentChallengeData != null) ? new int?(currentChallengeData.GetChallengeId()) : null;
			if (num == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.ActivityFunPlay, ELogAuthor.CB, "当前趣味玩法关卡数据为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			ControllerBase<ActivityFunPlayController>.Instance.ChallengeAwardRequest(num.Value);
		}

		// Token: 0x06042067 RID: 270439 RVA: 0x010F0B67 File Offset: 0x010EED67
		public void Refresh()
		{
			this.RefreshReward();
			this.RefreshContentState();
		}

		// Token: 0x06042068 RID: 270440 RVA: 0x010F0B78 File Offset: 0x010EED78
		private void RefreshReward()
		{
			ActivityFunPlayChallengeData currentChallengeData = ModelBase<ActivityFunPlayModel>.Instance.GetCurrentChallengeData();
			List<TItem> list = (currentChallengeData != null) ? currentChallengeData.GetPreviewReward() : null;
			if (list != null)
			{
				GenericScrollViewNew<CommonItemSmallItemGrid, TItem> rewardScrollView = this.RewardScrollView;
				if (rewardScrollView == null)
				{
					return;
				}
				rewardScrollView.RefreshByData(list, null, false);
			}
		}

		// Token: 0x06042069 RID: 270441 RVA: 0x010F0BB4 File Offset: 0x010EEDB4
		private void RefreshContentState()
		{
			ActivityFunPlayChallengeData currentChallengeData = ModelBase<ActivityFunPlayModel>.Instance.GetCurrentChallengeData();
			if (currentChallengeData == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.ActivityFunPlay, ELogAuthor.CB, "趣味玩法关卡数据空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			UUIText text = base.GetText(2);
			if (text != null)
			{
				text.SetUIActive(currentChallengeData.CheckRewardStatus(FunPlayChallengeRewardStatus.FunPlayCanNoReward));
			}
			UUIItem item = base.GetItem(5);
			if (item != null)
			{
				item.SetUIActive(currentChallengeData.CheckRewardStatus(FunPlayChallengeRewardStatus.FunPlayCanReward));
			}
			UUIButtonComponent button = base.GetButton(4);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(currentChallengeData.CheckRewardStatus(FunPlayChallengeRewardStatus.FunPlayCanReward));
			}
			UUISprite sprite = base.GetSprite(3);
			if (sprite == null)
			{
				return;
			}
			sprite.SetUIActive(currentChallengeData.CheckRewardStatus(FunPlayChallengeRewardStatus.FunPlayRewarded));
		}

		// Token: 0x0604206A RID: 270442 RVA: 0x010F0C5F File Offset: 0x010EEE5F
		protected override void OnBeforeDestroy()
		{
			this.RemoveEventListener();
		}

		// Token: 0x0604206C RID: 270444 RVA: 0x010F0C6F File Offset: 0x010EEE6F
		[NullableContext(1)]
		[CompilerGenerated]
		private CommonItemSmallItemGrid <OnStart>g__Function1|3_0()
		{
			return this.CreatePropItem();
		}

		// Token: 0x04024D11 RID: 150801
		[Nullable(1)]
		private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScrollView;

		// Token: 0x0200C793 RID: 51091
		private class EComponents
		{
			// Token: 0x0403D711 RID: 251665
			public const int Title = 0;

			// Token: 0x0403D712 RID: 251666
			public const int ItemScroller = 1;

			// Token: 0x0403D713 RID: 251667
			public const int UnFinishedText = 2;

			// Token: 0x0403D714 RID: 251668
			public const int SprDone = 3;

			// Token: 0x0403D715 RID: 251669
			public const int FinishButton = 4;

			// Token: 0x0403D716 RID: 251670
			public const int FinishedItem = 5;
		}
	}
}
