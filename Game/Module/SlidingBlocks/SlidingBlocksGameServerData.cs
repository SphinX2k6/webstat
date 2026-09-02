using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.SlidingBlocks
{
	// Token: 0x02004EFE RID: 20222
	[NullableContext(1)]
	[Nullable(0)]
	public class SlidingBlocksGameServerData
	{
		// Token: 0x0603444D RID: 214093 RVA: 0x00D1308C File Offset: 0x00D1128C
		public void Init(int instanceId, int historyScore, int[] historyReceivedRewardIds)
		{
			this.InstanceId = instanceId;
			this.HistoryReceivedRewardIds = historyReceivedRewardIds;
			this.HistoryScore = historyScore;
			AvoidBlockLevel? config = ConfigAvoidBlockLevelByInstId.GetConfig(instanceId, true);
			if (config == null)
			{
				return;
			}
			this.MainTitleTextKey = config.Value.MainTitleText;
			this.AchieveTextKey = config.Value.AchieveText;
			this.RewardTitleTextKey = config.Value.RewardTitleText;
		}

		// Token: 0x0603444E RID: 214094 RVA: 0x00D130FF File Offset: 0x00D112FF
		public void Reset()
		{
			this.InstanceId = 0;
			this.MainTitleTextKey = null;
			this.RewardTitleTextKey = null;
			this.HistoryScore = 0;
		}

		// Token: 0x0401E268 RID: 123496
		[Nullable(2)]
		public string MainTitleTextKey;

		// Token: 0x0401E269 RID: 123497
		[Nullable(2)]
		public string AchieveTextKey;

		// Token: 0x0401E26A RID: 123498
		[Nullable(2)]
		public string RewardTitleTextKey;

		// Token: 0x0401E26B RID: 123499
		public bool IsWin;

		// Token: 0x0401E26C RID: 123500
		public int HistoryScore;

		// Token: 0x0401E26D RID: 123501
		public List<TItem> RewardList = new List<TItem>();

		// Token: 0x0401E26E RID: 123502
		public int InstanceId;

		// Token: 0x0401E26F RID: 123503
		public int[] HistoryReceivedRewardIds = Array.Empty<int>();
	}
}
