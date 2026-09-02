using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.FeedbackReward
{
	// Token: 0x02005D89 RID: 23945
	internal class RewardItem : GridProxyAbstract<int>
	{
		// Token: 0x0603C4B4 RID: 246964 RVA: 0x00F4D0F4 File Offset: 0x00F4B2F4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603C4B5 RID: 246965 RVA: 0x00F4D1A0 File Offset: 0x00F4B3A0
		protected override UniTask OnBeforeStartAsync()
		{
			RewardItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RewardItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C4B6 RID: 246966 RVA: 0x00F4D1E4 File Offset: 0x00F4B3E4
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			GivebackScoreReward? givebackScoreRewardById = ConfigBase<FeedbackRewardConfig>.Instance.GetGivebackScoreRewardById(data);
			if (givebackScoreRewardById == null)
			{
				return;
			}
			this.RewardId = data;
			base.GetText(3).SetText(givebackScoreRewardById.Value.Target.ToString(), true);
			EFeedbackRewardState feedbackRewardState = ModelBase<FeedbackRewardModel>.Instance.GetFeedbackRewardState(data);
			DropPackage? dropPackage = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(givebackScoreRewardById.Value.DropId);
			if (dropPackage != null)
			{
				using (Dictionary<int, int>.Enumerator enumerator = dropPackage.Value.DropPreview().GetEnumerator())
				{
					if (enumerator.MoveNext())
					{
						KeyValuePair<int, int> keyValuePair = enumerator.Current;
						PropSmallItemGrid parameters = new PropSmallItemGrid
						{
							Data = keyValuePair.Key,
							ItemConfigId = new int?(keyValuePair.Key),
							BottomText = ((keyValuePair.Value > 0) ? keyValuePair.Value.ToString() : null),
							IsStarReceivableVisible = new bool?(feedbackRewardState == EFeedbackRewardState.Finish),
							IsReceivedVisible = new bool?(feedbackRewardState == EFeedbackRewardState.Claimed)
						};
						SmallItemGrid showItem = this.ShowItem;
						if (showItem != null)
						{
							showItem.Apply<PropSmallItemGrid>(parameters);
						}
					}
				}
			}
			base.GetItem(0).SetUIActive(gridIndex > 0);
			base.GetItem(1).SetUIActive(feedbackRewardState >= EFeedbackRewardState.Finish);
		}

		// Token: 0x0603C4B7 RID: 246967 RVA: 0x00F4D35C File Offset: 0x00F4B55C
		[NullableContext(1)]
		private void OnExtendToggleClicked(MediumItemGridExtendCallback _)
		{
			if (ModelBase<FeedbackRewardModel>.Instance.GetFeedbackRewardState(this.RewardId) == EFeedbackRewardState.Finish)
			{
				ControllerBase<FeedbackRewardController>.Instance.GivebackRewardRequest().Forget();
				return;
			}
			GivebackScoreReward? givebackScoreRewardById = ConfigBase<FeedbackRewardConfig>.Instance.GetGivebackScoreRewardById(this.RewardId);
			if (givebackScoreRewardById == null)
			{
				return;
			}
			if (givebackScoreRewardById.Value.ShowType == 3)
			{
				ControllerBase<ItemController>.Instance.OpenTitleTipsByItemId(givebackScoreRewardById.Value.SkipParam);
				return;
			}
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(givebackScoreRewardById.Value.SkipParam, true, null);
		}

		// Token: 0x0603C4B8 RID: 246968 RVA: 0x00F4D3EE File Offset: 0x00F4B5EE
		public void SetPreviewVisible(bool value)
		{
			SmallItemGrid showItem = this.ShowItem;
			if (showItem == null)
			{
				return;
			}
			showItem.SetPreviewVisible(value);
		}

		// Token: 0x04021E89 RID: 138889
		public int RewardId;

		// Token: 0x04021E8A RID: 138890
		[Nullable(2)]
		private SmallItemGrid ShowItem;

		// Token: 0x0200BDBB RID: 48571
		private enum ERewardItem
		{
			// Token: 0x0403A6E3 RID: 239331
			BarItem,
			// Token: 0x0403A6E4 RID: 239332
			FinishItem,
			// Token: 0x0403A6E5 RID: 239333
			GirdItem,
			// Token: 0x0403A6E6 RID: 239334
			PointText
		}
	}
}
