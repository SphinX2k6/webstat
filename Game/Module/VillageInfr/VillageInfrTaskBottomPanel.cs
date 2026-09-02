using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.VillageInfr
{
	// Token: 0x02004C1B RID: 19483
	public class VillageInfrTaskBottomPanel : UiPanelBase
	{
		// Token: 0x06032D1A RID: 208154 RVA: 0x00CBBBF4 File Offset: 0x00CB9DF4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUISprite)),
				new ValueTuple<int, Type>(4, typeof(UUISprite))
			};
		}

		// Token: 0x06032D1B RID: 208155 RVA: 0x00CBBC7A File Offset: 0x00CB9E7A
		protected override void OnStart()
		{
			this.CreateRewardLayout();
			this.Refresh();
		}

		// Token: 0x06032D1C RID: 208156 RVA: 0x00CBBC88 File Offset: 0x00CB9E88
		public void Refresh()
		{
			this.RefreshReward();
		}

		// Token: 0x06032D1D RID: 208157 RVA: 0x00CBBC90 File Offset: 0x00CB9E90
		private void CreateRewardLayout()
		{
			this.RewardLayout = new GenericLayout<RewardItem, int>(base.GetHorizontalLayout(1), () => new RewardItem(), null, false, true);
		}

		// Token: 0x06032D1E RID: 208158 RVA: 0x00CBBCC8 File Offset: 0x00CB9EC8
		public void RefreshReward()
		{
			List<InfrV2ScoreReward> list = new List<InfrV2ScoreReward>(ConfigBase<VillageInfrConfig>.Instance.GetScoreReward());
			list.Sort((InfrV2ScoreReward a, InfrV2ScoreReward b) => a.Score - b.Score);
			List<int> list2 = new List<int>();
			foreach (InfrV2ScoreReward infrV2ScoreReward in list)
			{
				list2.Add(infrV2ScoreReward.Id);
			}
			this.RewardLayout.RefreshByData(list2, null, false);
			InfrV2ScoreReward infrV2ScoreReward2 = list[0];
			foreach (InfrV2ScoreReward infrV2ScoreReward3 in list)
			{
				if (infrV2ScoreReward3.Score > infrV2ScoreReward2.Score)
				{
					infrV2ScoreReward2 = infrV2ScoreReward3;
				}
			}
			int score = infrV2ScoreReward2.Score;
			int rewardScore = ModelBase<VillageInfrModel>.Instance.GetRewardScore();
			base.GetText(0).SetText(rewardScore.ToString(), true);
			base.GetSprite(4).SetFillAmount((float)Math.Min((double)rewardScore / (double)score, 1.0));
		}

		// Token: 0x0401D948 RID: 121160
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<RewardItem, int> RewardLayout;
	}
}
