using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005144 RID: 20804
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeBossChallengeDefine
	{
		// Token: 0x060358C6 RID: 219334 RVA: 0x00D714D9 File Offset: 0x00D6F6D9
		public static ERoguelikeBossChallengeBossState ConvertProtoToBossState(RogueTowerTrialBossState protoState)
		{
			switch (protoState)
			{
			case RogueTowerTrialBossState.IsLock:
				return ERoguelikeBossChallengeBossState.Locked;
			case RogueTowerTrialBossState.Selectable:
				return ERoguelikeBossChallengeBossState.Processing;
			case RogueTowerTrialBossState.Completed:
				return ERoguelikeBossChallengeBossState.Finished;
			default:
				return ERoguelikeBossChallengeBossState.Locked;
			}
		}

		// Token: 0x060358C7 RID: 219335 RVA: 0x00D714F6 File Offset: 0x00D6F6F6
		private static int GetBossStateSortPriority(ERoguelikeBossChallengeBossState state)
		{
			switch (state)
			{
			case ERoguelikeBossChallengeBossState.Finished:
				return 0;
			case ERoguelikeBossChallengeBossState.Processing:
				return 1;
			case ERoguelikeBossChallengeBossState.Locked:
				return 2;
			default:
				return 3;
			}
		}

		// Token: 0x060358C8 RID: 219336 RVA: 0x00D71514 File Offset: 0x00D6F714
		public static List<RoguelikeBossChallengeBossData> SortBossDataListStable(List<RoguelikeBossChallengeBossData> dataList)
		{
			List<RoguelikeBossChallengeDefine.IndexedBossData> list = new List<RoguelikeBossChallengeDefine.IndexedBossData>();
			for (int i = 0; i < dataList.Count; i++)
			{
				list.Add(new RoguelikeBossChallengeDefine.IndexedBossData
				{
					BossData = dataList[i],
					OriginalIndex = i
				});
			}
			list.Sort(delegate(RoguelikeBossChallengeDefine.IndexedBossData a, RoguelikeBossChallengeDefine.IndexedBossData b)
			{
				int num = RoguelikeBossChallengeDefine.GetBossStateSortPriority(a.BossData.State) - RoguelikeBossChallengeDefine.GetBossStateSortPriority(b.BossData.State);
				if (num == 0)
				{
					return a.OriginalIndex - b.OriginalIndex;
				}
				return num;
			});
			List<RoguelikeBossChallengeBossData> list2 = new List<RoguelikeBossChallengeBossData>();
			foreach (RoguelikeBossChallengeDefine.IndexedBossData indexedBossData in list)
			{
				list2.Add(indexedBossData.BossData);
			}
			return list2;
		}

		// Token: 0x0401EC3F RID: 126015
		public const int ROGUELIKE_BOSS_CHALLENGE_INSTANCE_SUCCESS = 3032;

		// Token: 0x0200B0E2 RID: 45282
		private interface IIndexedBossData
		{
			// Token: 0x1700A95A RID: 43354
			// (get) Token: 0x0604C4F0 RID: 312560
			// (set) Token: 0x0604C4F1 RID: 312561
			RoguelikeBossChallengeBossData BossData { get; set; }

			// Token: 0x1700A95B RID: 43355
			// (get) Token: 0x0604C4F2 RID: 312562
			// (set) Token: 0x0604C4F3 RID: 312563
			int OriginalIndex { get; set; }
		}

		// Token: 0x0200B0E3 RID: 45283
		[Nullable(0)]
		private class IndexedBossData : RoguelikeBossChallengeDefine.IIndexedBossData
		{
			// Token: 0x1700A95C RID: 43356
			// (get) Token: 0x0604C4F4 RID: 312564 RVA: 0x014E082D File Offset: 0x014DEA2D
			// (set) Token: 0x0604C4F5 RID: 312565 RVA: 0x014E0835 File Offset: 0x014DEA35
			public RoguelikeBossChallengeBossData BossData { get; set; } = new RoguelikeBossChallengeBossData();

			// Token: 0x1700A95D RID: 43357
			// (get) Token: 0x0604C4F6 RID: 312566 RVA: 0x014E083E File Offset: 0x014DEA3E
			// (set) Token: 0x0604C4F7 RID: 312567 RVA: 0x014E0846 File Offset: 0x014DEA46
			public int OriginalIndex { get; set; }
		}
	}
}
