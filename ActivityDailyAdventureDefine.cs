using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x020012C9 RID: 4809
public class ActivityDailyAdventureDefine : IStaticVariableResetter
{
	// Token: 0x0600811D RID: 33053 RVA: 0x00221E26 File Offset: 0x00220026
	static ActivityDailyAdventureDefine()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(ActivityDailyAdventureDefine.CreateStaticDefaultValue), new Action(ActivityDailyAdventureDefine.ResetStaticDefaultValue));
	}

	// Token: 0x0600811E RID: 33054 RVA: 0x00221E45 File Offset: 0x00220045
	public static void CreateStaticDefaultValue()
	{
		ActivityDailyAdventureDefine.RewardStateResolver = new Dictionary<DailyAdventureTaskState, ERewardState>
		{
			{
				DailyAdventureTaskState.DailyAdventureTaskRunning,
				ERewardState.Progress
			},
			{
				DailyAdventureTaskState.DailyAdventureTaskFinish,
				ERewardState.FinishedAndUnClaimed
			},
			{
				DailyAdventureTaskState.DailyAdventureTaskTaken,
				ERewardState.FinishedAndClaimed
			}
		};
	}

	// Token: 0x0600811F RID: 33055 RVA: 0x00221E69 File Offset: 0x00220069
	public static void ResetStaticDefaultValue()
	{
		ActivityDailyAdventureDefine.RewardStateResolver = null;
	}

	// Token: 0x04003DAD RID: 15789
	public const int DAILY_ADVENTURE_PT_CONFIGID = 13;

	// Token: 0x04003DAE RID: 15790
	[Nullable(1)]
	public static Dictionary<DailyAdventureTaskState, ERewardState> RewardStateResolver;
}
