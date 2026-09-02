using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.LineCross
{
	// Token: 0x02006765 RID: 26469
	public class LineCrossChallengeData
	{
		// Token: 0x06041FA9 RID: 270249 RVA: 0x010EDCC3 File Offset: 0x010EBEC3
		public int GetId()
		{
			return this.Id;
		}

		// Token: 0x06041FAA RID: 270250 RVA: 0x010EDCCB File Offset: 0x010EBECB
		public bool GetHasGetReward()
		{
			return this.HasGetReward;
		}

		// Token: 0x06041FAB RID: 270251 RVA: 0x010EDCD3 File Offset: 0x010EBED3
		public long GetOpenTime()
		{
			return this.OpenTime / 1000L;
		}

		// Token: 0x06041FAC RID: 270252 RVA: 0x010EDCE2 File Offset: 0x010EBEE2
		public int GetRewardId()
		{
			return this.RewardId;
		}

		// Token: 0x06041FAD RID: 270253 RVA: 0x010EDCEA File Offset: 0x010EBEEA
		public int GetEntityConfigId()
		{
			return this.EntityConfigId;
		}

		// Token: 0x06041FAE RID: 270254 RVA: 0x010EDCF2 File Offset: 0x010EBEF2
		public bool GetPreChallengeState()
		{
			return this.PreChallengeState;
		}

		// Token: 0x06041FAF RID: 270255 RVA: 0x010EDCFC File Offset: 0x010EBEFC
		[NullableContext(1)]
		public void Phrase(LineCrossChallengeData data)
		{
			this.Id = data.ChallengeId;
			this.HasGetReward = data.Rewarded;
			this.OpenTime = data.OpenTime;
			this.RewardId = data.RewardId;
			this.EntityConfigId = data.EntityConfigId;
			this.PreChallengeState = data.PreChallenged;
		}

		// Token: 0x04024CDF RID: 150751
		private int Id;

		// Token: 0x04024CE0 RID: 150752
		private bool HasGetReward;

		// Token: 0x04024CE1 RID: 150753
		private long OpenTime;

		// Token: 0x04024CE2 RID: 150754
		private int RewardId;

		// Token: 0x04024CE3 RID: 150755
		private int EntityConfigId;

		// Token: 0x04024CE4 RID: 150756
		private bool PreChallengeState;
	}
}
