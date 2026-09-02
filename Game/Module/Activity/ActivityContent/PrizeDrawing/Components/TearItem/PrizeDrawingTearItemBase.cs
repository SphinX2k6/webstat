using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Activity.ActivityContent.PrizeDrawing.Components.TearItem
{
	// Token: 0x02006573 RID: 25971
	[NullableContext(1)]
	[Nullable(0)]
	public class PrizeDrawingTearItemBase : UiPanelBase
	{
		// Token: 0x06040DFF RID: 265727 RVA: 0x010A41C0 File Offset: 0x010A23C0
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.LevelSequencePlayer.PlaySequencePurely("Reveal", false, false, null, null, false);
			this.LevelSequencePlayer.StopCurrentSequence(false, false);
		}

		// Token: 0x06040E00 RID: 265728 RVA: 0x010A4208 File Offset: 0x010A2408
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.Clear();
		}

		// Token: 0x06040E01 RID: 265729 RVA: 0x010A421C File Offset: 0x010A241C
		public void PlayRevelAnimation()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlaySequencePurely("Reveal", false, false, null, null, false);
		}

		// Token: 0x06040E02 RID: 265730 RVA: 0x010A424B File Offset: 0x010A244B
		public void SetRewardList(List<IKujiAwardData> rewardList)
		{
			this.RewardList = rewardList;
		}

		// Token: 0x06040E03 RID: 265731 RVA: 0x010A4254 File Offset: 0x010A2454
		protected string RareIdToTexPath(int id, bool isNormal = false)
		{
			string[] array;
			if (!this.RareToTexIdMap.TryGetValue(id, out array))
			{
				return "";
			}
			string resourceId = (isNormal && array.Length > 1) ? array[1] : array[0];
			return ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		}

		// Token: 0x0402469B RID: 149147
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected List<IKujiAwardData> RewardList;

		// Token: 0x0402469C RID: 149148
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0402469D RID: 149149
		private readonly Dictionary<int, string[]> RareToTexIdMap = new Dictionary<int, string[]>
		{
			{
				0,
				new string[]
				{
					"T_PrizeDrawingTearLevelS"
				}
			},
			{
				1,
				new string[]
				{
					"T_PrizeDrawingTearLevelA",
					"T_PrizeDrawingTearLevelA_Nml"
				}
			},
			{
				2,
				new string[]
				{
					"T_PrizeDrawingTearLevelB",
					"T_PrizeDrawingTearLevelB_Nml"
				}
			},
			{
				3,
				new string[]
				{
					"T_PrizeDrawingTearLevelC",
					"T_PrizeDrawingTearLevelC_Nml"
				}
			},
			{
				4,
				new string[]
				{
					"T_PrizeDrawingTearLevelD",
					"T_PrizeDrawingTearLevelD_Nml"
				}
			},
			{
				5,
				new string[]
				{
					"T_PrizeDrawingTearLevelE",
					"T_PrizeDrawingTearLevelE_Nml"
				}
			},
			{
				6,
				new string[]
				{
					"T_PrizeDrawingTearLevelF",
					"T_PrizeDrawingTearLevelF_Nml"
				}
			}
		};
	}
}
