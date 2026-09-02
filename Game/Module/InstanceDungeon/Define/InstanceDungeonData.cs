using System;
using Aki.Config;

namespace CSharpScript.Game.Module.InstanceDungeon.Define
{
	// Token: 0x02005C04 RID: 23556
	public class InstanceDungeonData
	{
		// Token: 0x0603B98A RID: 244106 RVA: 0x00F1B768 File Offset: 0x00F19968
		public InstanceDungeonData(int shareId)
		{
			this.ShareId = shareId;
			InstanceEnterControl? countConfig = ConfigBase<InstanceDungeonConfig>.Instance.GetCountConfig(this.ShareId);
			this.LimitChallengeTimes = ((countConfig != null) ? countConfig.GetValueOrDefault().EnterCount : 0);
			this.CostTypeInternal = (EInstanceCostType)((countConfig != null) ? countConfig.GetValueOrDefault().EnterCountConsumeType : 0);
		}

		// Token: 0x170097AD RID: 38829
		// (get) Token: 0x0603B98B RID: 244107 RVA: 0x00F1B7D5 File Offset: 0x00F199D5
		// (set) Token: 0x0603B98C RID: 244108 RVA: 0x00F1B7DD File Offset: 0x00F199DD
		public int ChallengedTimes
		{
			get
			{
				return this.ChallengedTimesInternal;
			}
			set
			{
				this.ChallengedTimesInternal = value;
			}
		}

		// Token: 0x170097AE RID: 38830
		// (get) Token: 0x0603B98D RID: 244109 RVA: 0x00F1B7E6 File Offset: 0x00F199E6
		public EInstanceCostType CostType
		{
			get
			{
				return this.CostTypeInternal;
			}
		}

		// Token: 0x170097AF RID: 38831
		// (get) Token: 0x0603B98E RID: 244110 RVA: 0x00F1B7EE File Offset: 0x00F199EE
		public int LimitChallengedTimes
		{
			get
			{
				return this.LimitChallengeTimes;
			}
		}

		// Token: 0x170097B0 RID: 38832
		// (get) Token: 0x0603B98F RID: 244111 RVA: 0x00F1B7F8 File Offset: 0x00F199F8
		public int LeftChallengedTimes
		{
			get
			{
				int num = this.LimitChallengedTimes - this.ChallengedTimesInternal;
				if (num < 0)
				{
					return 0;
				}
				return num;
			}
		}

		// Token: 0x170097B1 RID: 38833
		// (get) Token: 0x0603B990 RID: 244112 RVA: 0x00F1B81A File Offset: 0x00F19A1A
		public bool CanRepeatChallenge
		{
			get
			{
				return this.LimitChallengedTimes <= 0;
			}
		}

		// Token: 0x170097B2 RID: 38834
		// (get) Token: 0x0603B991 RID: 244113 RVA: 0x00F1B828 File Offset: 0x00F19A28
		public bool CanChallenge
		{
			get
			{
				return this.CanRepeatChallenge || (this.CostTypeInternal == EInstanceCostType.ComeTimeNotReward || this.CostTypeInternal == EInstanceCostType.RewardTimeNotReward) || this.ChallengedTimes < this.LimitChallengedTimes;
			}
		}

		// Token: 0x170097B3 RID: 38835
		// (get) Token: 0x0603B992 RID: 244114 RVA: 0x00F1B858 File Offset: 0x00F19A58
		public bool CanReward
		{
			get
			{
				if (this.CanRepeatChallenge)
				{
					return true;
				}
				if (this.CostTypeInternal == EInstanceCostType.ComeTimeNotComing || this.CostTypeInternal == EInstanceCostType.RewardTimeNotComing)
				{
					return true;
				}
				if (this.CostTypeInternal == EInstanceCostType.ComeTimeNotReward)
				{
					return this.ChallengedTimes <= this.LimitChallengedTimes;
				}
				return this.ChallengedTimes < this.LimitChallengedTimes;
			}
		}

		// Token: 0x040218B0 RID: 137392
		private readonly int ShareId;

		// Token: 0x040218B1 RID: 137393
		private readonly int LimitChallengeTimes;

		// Token: 0x040218B2 RID: 137394
		private readonly EInstanceCostType CostTypeInternal;

		// Token: 0x040218B3 RID: 137395
		private int ChallengedTimesInternal;
	}
}
