using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.BossPiling
{
	// Token: 0x02005EF1 RID: 24305
	[NullableContext(1)]
	[Nullable(0)]
	public class BossPilingDefine : IStaticVariableResetter
	{
		// Token: 0x0603D104 RID: 250116 RVA: 0x00F812A6 File Offset: 0x00F7F4A6
		static BossPilingDefine()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(BossPilingDefine.CreateStaticDefaultValue), new Action(BossPilingDefine.ResetStaticDefaultValue));
		}

		// Token: 0x0603D105 RID: 250117 RVA: 0x00F812C8 File Offset: 0x00F7F4C8
		public static void CreateStaticDefaultValue()
		{
			BossPilingDefine.BossPilingScoreTexMap = new Dictionary<int, string>
			{
				{
					1,
					"SP_BossPilingBossSelectScoreB"
				},
				{
					2,
					"SP_BossPilingBossSelectScoreA"
				},
				{
					3,
					"SP_BossPilingBossSelectScoreS"
				},
				{
					4,
					"SP_BossPilingBossSelectScoreSS"
				}
			};
			BossPilingDefine.BossPilingTaskStateToRewardStateResolver = new Dictionary<ConditionTaskState, EActivityRewardState>
			{
				{
					ConditionTaskState.ConditionTaskRunning,
					EActivityRewardState.Disabled
				},
				{
					ConditionTaskState.ConditionTaskFinish,
					EActivityRewardState.Enable
				},
				{
					ConditionTaskState.ConditionTaskTaken,
					EActivityRewardState.Claimed
				}
			};
			BossPilingDefine.BossPilingTaskStateToRewardText = new Dictionary<ConditionTaskState, string>
			{
				{
					ConditionTaskState.ConditionTaskRunning,
					"BossPilingActivity_Reward13"
				},
				{
					ConditionTaskState.ConditionTaskFinish,
					"BossPilingActivity_Reward12"
				},
				{
					ConditionTaskState.ConditionTaskTaken,
					"BossPilingActivity_Reward12"
				}
			};
		}

		// Token: 0x0603D106 RID: 250118 RVA: 0x00F8135F File Offset: 0x00F7F55F
		public static void ResetStaticDefaultValue()
		{
			BossPilingDefine.BossPilingScoreTexMap = null;
			BossPilingDefine.BossPilingTaskStateToRewardStateResolver = null;
			BossPilingDefine.BossPilingTaskStateToRewardText = null;
		}

		// Token: 0x04022405 RID: 140293
		public static Dictionary<int, string> BossPilingScoreTexMap;

		// Token: 0x04022406 RID: 140294
		public static Dictionary<ConditionTaskState, EActivityRewardState> BossPilingTaskStateToRewardStateResolver;

		// Token: 0x04022407 RID: 140295
		public static Dictionary<ConditionTaskState, string> BossPilingTaskStateToRewardText;
	}
}
