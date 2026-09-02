using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B5B RID: 23387
	[NullableContext(1)]
	[Nullable(0)]
	public class RewardExploreScoreSubTitle : UiPanelBase
	{
		// Token: 0x0603B29C RID: 242332 RVA: 0x00EF8618 File Offset: 0x00EF6818
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
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
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B29D RID: 242333 RVA: 0x00EF86E4 File Offset: 0x00EF68E4
		protected override UniTask OnBeforeStartAsync()
		{
			RewardExploreScoreSubTitle.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RewardExploreScoreSubTitle.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B29E RID: 242334 RVA: 0x00EF8728 File Offset: 0x00EF6928
		public void RefreshData(IRewardExploreScoreBelongHalfArea exploreScore)
		{
			int num = 0;
			int num2 = 0;
			foreach (IRewardExploreScoreBelongHalfAreaItem rewardExploreScoreBelongHalfAreaItem in exploreScore.ItemList)
			{
				if (rewardExploreScoreBelongHalfAreaItem.Belong == ETeamBelong.FirstPart)
				{
					if (num < this.FirstItemList.Count)
					{
						RewardExploreScoreSubTitleItem rewardExploreScoreSubTitleItem = this.FirstItemList[num++];
						rewardExploreScoreSubTitleItem.SetUiActive(true);
						rewardExploreScoreSubTitleItem.RefreshText(rewardExploreScoreBelongHalfAreaItem);
					}
				}
				else if (rewardExploreScoreBelongHalfAreaItem.Belong == ETeamBelong.LowPart && num2 < this.LowItemList.Count)
				{
					RewardExploreScoreSubTitleItem rewardExploreScoreSubTitleItem2 = this.LowItemList[num2++];
					rewardExploreScoreSubTitleItem2.SetUiActive(true);
					rewardExploreScoreSubTitleItem2.RefreshText(rewardExploreScoreBelongHalfAreaItem);
				}
			}
			RewardExploreScoreSubTitle.NewRecordItem newRecordItemInstance = this.NewRecordItemInstance;
			if (newRecordItemInstance == null)
			{
				return;
			}
			newRecordItemInstance.Refresh(exploreScore);
		}

		// Token: 0x04021599 RID: 136601
		private readonly List<RewardExploreScoreSubTitleItem> FirstItemList = new List<RewardExploreScoreSubTitleItem>();

		// Token: 0x0402159A RID: 136602
		private readonly List<RewardExploreScoreSubTitleItem> LowItemList = new List<RewardExploreScoreSubTitleItem>();

		// Token: 0x0402159B RID: 136603
		private RewardExploreScoreSubTitle.NewRecordItem NewRecordItemInstance;

		// Token: 0x0200BB65 RID: 47973
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04039D26 RID: 236838
			public const int FirstTargetItem1 = 0;

			// Token: 0x04039D27 RID: 236839
			public const int FirstTargetItem2 = 1;

			// Token: 0x04039D28 RID: 236840
			public const int LowTargetItem1 = 2;

			// Token: 0x04039D29 RID: 236841
			public const int LowTargetItem2 = 3;

			// Token: 0x04039D2A RID: 236842
			public const int NewRecordItem = 4;
		}

		// Token: 0x0200BB66 RID: 47974
		[NullableContext(0)]
		public class NewRecordItem : UiPanelBase
		{
			// Token: 0x0604D9EC RID: 317932 RVA: 0x01570C88 File Offset: 0x0156EE88
			protected unsafe override void OnRegisterComponent()
			{
				int num = 3;
				List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
				CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
				Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
				int num2 = 0;
				*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
				this.ComponentRegisterInfos = list;
				this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
			}

			// Token: 0x0604D9ED RID: 317933 RVA: 0x01570D1D File Offset: 0x0156EF1D
			[NullableContext(1)]
			public void Refresh(IRewardExploreScoreBelongHalfArea data)
			{
				this.RefreshRecord(data);
				this.SetNewRecordItemVisible(data.IfNewRecord);
			}

			// Token: 0x0604D9EE RID: 317934 RVA: 0x01570D34 File Offset: 0x0156EF34
			[NullableContext(1)]
			private void RefreshRecord(IRewardExploreScoreBelongHalfArea data)
			{
				UUIText text = base.GetText(1);
				if (text == null)
				{
					return;
				}
				text.SetText(data.FullScore.ToString(), true);
			}

			// Token: 0x0604D9EF RID: 317935 RVA: 0x01570D61 File Offset: 0x0156EF61
			private void SetNewRecordItemVisible(bool bVisible)
			{
				UUIItem item = base.GetItem(2);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(bVisible);
			}

			// Token: 0x0200CF40 RID: 53056
			private class ENewRecordComponent
			{
				// Token: 0x0403FD82 RID: 261506
				public const int TitleText = 0;

				// Token: 0x0403FD83 RID: 261507
				public const int RecordText = 1;

				// Token: 0x0403FD84 RID: 261508
				public const int NewRecordItem = 2;
			}
		}
	}
}
