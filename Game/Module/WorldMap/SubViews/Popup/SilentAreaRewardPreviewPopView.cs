using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.Popup
{
	// Token: 0x02004B97 RID: 19351
	public class SilentAreaRewardPreviewPopView : UiViewBase
	{
		// Token: 0x0603287F RID: 206975 RVA: 0x00CA6148 File Offset: 0x00CA4348
		[NullableContext(1)]
		public SilentAreaRewardPreviewPopView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06032880 RID: 206976 RVA: 0x00CA6154 File Offset: 0x00CA4354
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

		// Token: 0x06032881 RID: 206977 RVA: 0x00CA61C8 File Offset: 0x00CA43C8
		protected override UniTask OnBeforeStartAsync()
		{
			SilentAreaRewardPreviewPopView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SilentAreaRewardPreviewPopView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032882 RID: 206978 RVA: 0x00CA6204 File Offset: 0x00CA4404
		protected override void OnStart()
		{
			this.RewardScroll = new GenericScrollViewNew<RewardPreviewListItem, TLevelDropReward>(base.GetScrollViewWithScrollbar(2), new Func<RewardPreviewListItem>(this.RewardPreviewItemCreateFunc), null, false, null);
			this.ExchangeRewardId = (int)this.OpenParam;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "SilentArea_rewardinfo", Array.Empty<object>());
		}

		// Token: 0x06032883 RID: 206979 RVA: 0x00CA625E File Offset: 0x00CA445E
		protected override void OnBeforeShow()
		{
			this.ShowReward();
		}

		// Token: 0x06032884 RID: 206980 RVA: 0x00CA6268 File Offset: 0x00CA4468
		private void ShowReward()
		{
			ExchangeReward? config = ConfigExchangeRewardById.GetConfig(this.ExchangeRewardId, true);
			if (config == null)
			{
				return;
			}
			List<TLevelDropReward> list = new List<TLevelDropReward>();
			for (int i = 0; i < config.Value.RewardIdLength; i++)
			{
				DicIntInt? dicIntInt = config.Value.RewardId(i);
				list.Add(new TLevelDropReward
				{
					WorldLevel = dicIntInt.Value.Key,
					DropId = dicIntInt.Value.Value
				});
			}
			list.Sort((TLevelDropReward a, TLevelDropReward b) => a.WorldLevel - b.WorldLevel);
			List<TLevelDropReward> list2 = new List<TLevelDropReward>();
			WorldLevelModel instance = ModelBase<WorldLevelModel>.Instance;
			int num = (instance != null) ? instance.CurWorldLevel : 0;
			int num2 = 0;
			int selectIndex = 0;
			foreach (TLevelDropReward tlevelDropReward in list)
			{
				list2.Add(tlevelDropReward);
				if (num2 < tlevelDropReward.WorldLevel && num >= tlevelDropReward.WorldLevel)
				{
					num2 = tlevelDropReward.WorldLevel;
					selectIndex = list2.Count - 1;
				}
			}
			if (this.RewardScroll != null)
			{
				TTimerAction <>9__2;
				this.RewardScroll.RefreshByDataAsync(list, false).Finally(delegate()
				{
					TimerSystemInstance gameplayTimeInstance = TimerSystem.GameplayTimeInstance;
					TTimerAction action;
					if ((action = <>9__2) == null)
					{
						action = (<>9__2 = delegate(float delta)
						{
							GenericScrollViewNew<RewardPreviewListItem, TLevelDropReward> rewardScroll = this.RewardScroll;
							if (rewardScroll == null)
							{
								return;
							}
							rewardScroll.ScrollToTopByIndex(selectIndex);
						});
					}
					gameplayTimeInstance.Next(action, null, null);
				});
			}
		}

		// Token: 0x06032885 RID: 206981 RVA: 0x00CA63F0 File Offset: 0x00CA45F0
		[NullableContext(1)]
		private RewardPreviewListItem RewardPreviewItemCreateFunc()
		{
			return new RewardPreviewListItem();
		}

		// Token: 0x0401D777 RID: 120695
		private int ExchangeRewardId;

		// Token: 0x0401D778 RID: 120696
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<RewardPreviewListItem, TLevelDropReward> RewardScroll;

		// Token: 0x0200AC6A RID: 44138
		public static class ERewardPreviewComponents
		{
			// Token: 0x040359A4 RID: 219556
			public const int TxtTitle = 1;

			// Token: 0x040359A5 RID: 219557
			public const int RewardScrollList = 2;
		}
	}
}
