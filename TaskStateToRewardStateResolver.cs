using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001171 RID: 4465
public class TaskStateToRewardStateResolver : IStaticVariableResetter
{
	// Token: 0x06007589 RID: 30089 RVA: 0x001ED05B File Offset: 0x001EB25B
	static TaskStateToRewardStateResolver()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TaskStateToRewardStateResolver.CreateStaticDefaultValue), new Action(TaskStateToRewardStateResolver.ResetStaticDefaultValue));
	}

	// Token: 0x0600758A RID: 30090 RVA: 0x001ED07A File Offset: 0x001EB27A
	public static void CreateStaticDefaultValue()
	{
		TaskStateToRewardStateResolver.Value = new Dictionary<EActivityTaskState, EActivityRewardState>
		{
			{
				EActivityTaskState.Active,
				EActivityRewardState.Disabled
			},
			{
				EActivityTaskState.FinishedAndUnclaimed,
				EActivityRewardState.Enable
			},
			{
				EActivityTaskState.FinishedAndClaimed,
				EActivityRewardState.Claimed
			}
		};
	}

	// Token: 0x0600758B RID: 30091 RVA: 0x001ED09E File Offset: 0x001EB29E
	public static void ResetStaticDefaultValue()
	{
		TaskStateToRewardStateResolver.Value = null;
	}

	// Token: 0x040038FD RID: 14589
	[Nullable(1)]
	public static Dictionary<EActivityTaskState, EActivityRewardState> Value;
}
