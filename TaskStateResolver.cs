using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001170 RID: 4464
[NullableContext(1)]
[Nullable(0)]
public class TaskStateResolver : IStaticVariableResetter
{
	// Token: 0x06007585 RID: 30085 RVA: 0x001ECFAA File Offset: 0x001EB1AA
	static TaskStateResolver()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TaskStateResolver.CreateStaticDefaultValue), new Action(TaskStateResolver.ResetStaticDefaultValue));
	}

	// Token: 0x06007586 RID: 30086 RVA: 0x001ECFCC File Offset: 0x001EB1CC
	public static void CreateStaticDefaultValue()
	{
		TaskStateResolver.TaskState = new Dictionary<ActivityTaskState, EActivityTaskState>
		{
			{
				ActivityTaskState.ActivityTaskRunning,
				EActivityTaskState.Active
			},
			{
				ActivityTaskState.ActivityTaskFinish,
				EActivityTaskState.FinishedAndUnclaimed
			},
			{
				ActivityTaskState.ActivityTaskTaken,
				EActivityTaskState.FinishedAndClaimed
			}
		};
		TaskStateResolver.ConditionState = new Dictionary<ConditionTaskState, EActivityTaskState>
		{
			{
				ConditionTaskState.ConditionTaskRunning,
				EActivityTaskState.Active
			},
			{
				ConditionTaskState.ConditionTaskFinish,
				EActivityTaskState.FinishedAndUnclaimed
			},
			{
				ConditionTaskState.ConditionTaskTaken,
				EActivityTaskState.FinishedAndClaimed
			}
		};
		TaskStateResolver.TrackMoonTargetState = new Dictionary<TrackMoonTargetState, EActivityTaskState>
		{
			{
				Aki.Protocol.TrackMoonTargetState.TrackMoonTargetRunning,
				EActivityTaskState.Active
			},
			{
				Aki.Protocol.TrackMoonTargetState.TrackMoonTargetFinish,
				EActivityTaskState.FinishedAndUnclaimed
			},
			{
				Aki.Protocol.TrackMoonTargetState.TrackMoonTargetTaken,
				EActivityTaskState.FinishedAndClaimed
			}
		};
	}

	// Token: 0x06007587 RID: 30087 RVA: 0x001ED03F File Offset: 0x001EB23F
	public static void ResetStaticDefaultValue()
	{
		TaskStateResolver.TaskState = null;
		TaskStateResolver.ConditionState = null;
		TaskStateResolver.TrackMoonTargetState = null;
	}

	// Token: 0x040038FA RID: 14586
	public static Dictionary<ActivityTaskState, EActivityTaskState> TaskState;

	// Token: 0x040038FB RID: 14587
	public static Dictionary<ConditionTaskState, EActivityTaskState> ConditionState;

	// Token: 0x040038FC RID: 14588
	public static Dictionary<TrackMoonTargetState, EActivityTaskState> TrackMoonTargetState;
}
