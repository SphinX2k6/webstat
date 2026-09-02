using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E47 RID: 20039
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseRewardTabData
	{
		// Token: 0x06033CB2 RID: 212146 RVA: 0x00CF28F1 File Offset: 0x00CF0AF1
		public TrapDefenseRewardTabData(ETrapDefenseRewardType type)
		{
			this.Type = type;
		}

		// Token: 0x06033CB3 RID: 212147 RVA: 0x00CF2900 File Offset: 0x00CF0B00
		public string GetTitle()
		{
			return TrapDefenseDefine.rewardTypeNames[this.Type];
		}

		// Token: 0x06033CB4 RID: 212148 RVA: 0x00CF2914 File Offset: 0x00CF0B14
		public string GetProgressText()
		{
			ValueTuple<int, int> rewardProgressByType = ModelBase<TrapDefenseModel>.Instance.RewardData.GetRewardProgressByType(this.Type);
			int item = rewardProgressByType.Item1;
			int item2 = rewardProgressByType.Item2;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(item);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(item2);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06033CB5 RID: 212149 RVA: 0x00CF2970 File Offset: 0x00CF0B70
		public bool IsFinished()
		{
			ValueTuple<int, int> rewardProgressByType = ModelBase<TrapDefenseModel>.Instance.RewardData.GetRewardProgressByType(this.Type);
			int item = rewardProgressByType.Item1;
			int item2 = rewardProgressByType.Item2;
			return item >= item2;
		}

		// Token: 0x06033CB6 RID: 212150 RVA: 0x00CF29A6 File Offset: 0x00CF0BA6
		public bool HasRedDot()
		{
			return ModelBase<TrapDefenseModel>.Instance.RewardData.IsCanClaimLimitRewardByType(this.Type);
		}

		// Token: 0x0401DF94 RID: 122772
		public readonly ETrapDefenseRewardType Type;
	}
}
