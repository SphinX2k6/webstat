using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Roguelike;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B59 RID: 23385
	[NullableContext(1)]
	[Nullable(0)]
	public class RewardExploreRoguelikeBossChallengeItem : UiPanelBase
	{
		// Token: 0x0603B28D RID: 242317 RVA: 0x00EF8210 File Offset: 0x00EF6410
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B28E RID: 242318 RVA: 0x00EF82BC File Offset: 0x00EF64BC
		protected override UniTask OnBeforeStartAsync()
		{
			RewardExploreRoguelikeBossChallengeItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RewardExploreRoguelikeBossChallengeItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B28F RID: 242319 RVA: 0x00EF82FF File Offset: 0x00EF64FF
		public void Refresh(IRoguelikeBossChallengeData data)
		{
			RoguelikeResultRecordItem resultRecordItem = this.ResultRecordItem;
			if (resultRecordItem != null)
			{
				resultRecordItem.Refresh(data);
			}
			this.RefreshBossList(data);
		}

		// Token: 0x0603B290 RID: 242320 RVA: 0x00EF831C File Offset: 0x00EF651C
		private void RefreshBossList(IRoguelikeBossChallengeData data)
		{
			RoguelikeConfig instance = ConfigBase<RoguelikeConfig>.Instance;
			RogueInst? rogueInst = (instance != null) ? instance.GetRogueInstConfig(data.InstId) : null;
			if (rogueInst == null)
			{
				return;
			}
			int num = (rogueInst.Value.SpecialBossIndex > 0) ? (rogueInst.Value.SpecialBossIndex - 1) : -1;
			List<RoguelikeBossChallengeBossData> list = new List<RoguelikeBossChallengeBossData>();
			for (int i = 0; i < data.BossTotalCount; i++)
			{
				RoguelikeBossChallengeBossData roguelikeBossChallengeBossData = new RoguelikeBossChallengeBossData();
				if (i < data.FinishedBossIdList.Count)
				{
					roguelikeBossChallengeBossData.Id = data.FinishedBossIdList[i];
					roguelikeBossChallengeBossData.State = ERoguelikeBossChallengeBossState.Finished;
				}
				else
				{
					if (i == data.FinishedBossIdList.Count && data.CurrentBossId != null)
					{
						int? currentBossId = data.CurrentBossId;
						int num2 = 0;
						if (!(currentBossId.GetValueOrDefault() == num2 & currentBossId != null))
						{
							roguelikeBossChallengeBossData.Id = data.CurrentBossId.Value;
							roguelikeBossChallengeBossData.State = ERoguelikeBossChallengeBossState.Processing;
							goto IL_105;
						}
					}
					roguelikeBossChallengeBossData.Id = 0;
					roguelikeBossChallengeBossData.State = ERoguelikeBossChallengeBossState.Locked;
				}
				IL_105:
				roguelikeBossChallengeBossData.IsSpecial = (num == i);
				list.Add(roguelikeBossChallengeBossData);
			}
			GenericLayout<RoguelikeBossChallengeBossItem, RoguelikeBossChallengeBossData> bossItemLayout = this.BossItemLayout;
			if (bossItemLayout == null)
			{
				return;
			}
			bossItemLayout.RefreshByData(list, new Action(this.OnBossListRefreshed), false);
		}

		// Token: 0x0603B291 RID: 242321 RVA: 0x00EF8474 File Offset: 0x00EF6674
		private void OnBossListRefreshed()
		{
			if (this.BossItemLayout == null)
			{
				return;
			}
			List<RoguelikeBossChallengeBossItem> layoutItemList = this.BossItemLayout.GetLayoutItemList();
			int num = layoutItemList.Count - 1;
			for (int i = 0; i < layoutItemList.Count; i++)
			{
				layoutItemList[i].SetArrowVisible(i < num);
			}
		}

		// Token: 0x0603B292 RID: 242322 RVA: 0x00EF84C0 File Offset: 0x00EF66C0
		private RoguelikeBossChallengeBossItem CreateBossItem()
		{
			return new RoguelikeBossChallengeBossItem();
		}

		// Token: 0x0603B293 RID: 242323 RVA: 0x00EF84C7 File Offset: 0x00EF66C7
		protected override void OnBeforeDestroy()
		{
			this.ResultRecordItem = null;
			this.BossItemLayout = null;
		}

		// Token: 0x04021595 RID: 136597
		[Nullable(2)]
		private RoguelikeResultRecordItem ResultRecordItem;

		// Token: 0x04021596 RID: 136598
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RoguelikeBossChallengeBossItem, RoguelikeBossChallengeBossData> BossItemLayout;

		// Token: 0x0200BB5F RID: 47967
		[NullableContext(0)]
		private class EBossChallengeComponent
		{
			// Token: 0x04039D14 RID: 236820
			public const int ResultRecordItem = 0;

			// Token: 0x04039D15 RID: 236821
			public const int BossItemLayout = 1;

			// Token: 0x04039D16 RID: 236822
			public const int TxtNum = 2;

			// Token: 0x04039D17 RID: 236823
			public const int ResultNewTagItem = 3;
		}
	}
}
