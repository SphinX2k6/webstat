using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x02006482 RID: 25730
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class ActivityRoadBookConfig : ConfigBase<ActivityRoadBookConfig>
	{
		// Token: 0x060408B6 RID: 264374 RVA: 0x0108B858 File Offset: 0x01089A58
		public RoadBookConfig? GetActivityConfig(int activityId)
		{
			RoadBookConfig? config = ConfigRoadBookConfigByActivityId.GetConfig(activityId, true);
			if (config != null)
			{
				return new RoadBookConfig?(config.Value);
			}
			return null;
		}

		// Token: 0x060408B7 RID: 264375 RVA: 0x0108B88C File Offset: 0x01089A8C
		public RoadBookLevelExp? GetLevelExpConfig(int id)
		{
			RoadBookLevelExp? config = ConfigRoadBookLevelExpById.GetConfig(id, true);
			if (config != null)
			{
				return new RoadBookLevelExp?(config.Value);
			}
			return null;
		}

		// Token: 0x060408B8 RID: 264376 RVA: 0x0108B8C0 File Offset: 0x01089AC0
		public IReadOnlyList<RoadBookLevelExp> GetAllLevelExpConfig(int activityId)
		{
			return ConfigRoadBookLevelExpByActivityId.GetConfigList(activityId, true) ?? new List<RoadBookLevelExp>();
		}

		// Token: 0x060408B9 RID: 264377 RVA: 0x0108B8D4 File Offset: 0x01089AD4
		public RoadBookTask? GetRoadBookTaskConfig(int taskId)
		{
			RoadBookTask? config = ConfigRoadBookTaskByTaskId.GetConfig(taskId, true);
			if (config != null)
			{
				return new RoadBookTask?(config.Value);
			}
			return null;
		}

		// Token: 0x060408BA RID: 264378 RVA: 0x0108B908 File Offset: 0x01089B08
		public IReadOnlyList<RoadBookTask> GetAllRoadBookTaskConfig(int activityId)
		{
			return ConfigRoadBookTaskByActivityId.GetConfigList(activityId, true) ?? new List<RoadBookTask>();
		}

		// Token: 0x060408BB RID: 264379 RVA: 0x0108B91C File Offset: 0x01089B1C
		public RoadBookArea? GetAreaConfig(int id)
		{
			RoadBookArea? config = ConfigRoadBookAreaById.GetConfig(id, true);
			if (config != null)
			{
				return new RoadBookArea?(config.Value);
			}
			return null;
		}

		// Token: 0x060408BC RID: 264380 RVA: 0x0108B950 File Offset: 0x01089B50
		public IReadOnlyList<RoadBookArea> GetAllAreaConfig(int activityId)
		{
			return ConfigRoadBookAreaByActivityId.GetConfigList(activityId, true) ?? new List<RoadBookArea>();
		}

		// Token: 0x060408BD RID: 264381 RVA: 0x0108B964 File Offset: 0x01089B64
		public RoadBookPhantomGain? GetPhantomConfig(int id)
		{
			RoadBookPhantomGain? config = ConfigRoadBookPhantomGainById.GetConfig(id, true);
			if (config != null)
			{
				return new RoadBookPhantomGain?(config.Value);
			}
			return null;
		}

		// Token: 0x060408BE RID: 264382 RVA: 0x0108B998 File Offset: 0x01089B98
		public IReadOnlyList<RoadBookPhantomGain> GetAllPhantomConfig(int activityId)
		{
			return ConfigRoadBookPhantomGainByActivityId.GetConfigList(activityId, true) ?? new List<RoadBookPhantomGain>();
		}

		// Token: 0x060408BF RID: 264383 RVA: 0x0108B9AA File Offset: 0x01089BAA
		public IReadOnlyList<MotorcycleChallenge> GetAllMotorChallengeConfig()
		{
			return ConfigMotorcycleChallengeAll.GetConfigList(true) ?? new List<MotorcycleChallenge>();
		}

		// Token: 0x060408C0 RID: 264384 RVA: 0x0108B9BC File Offset: 0x01089BBC
		public MotorcycleChallenge? GetMotorChallengeConfig(int id)
		{
			MotorcycleChallenge? config = ConfigMotorcycleChallengeById.GetConfig(id, true);
			if (config != null)
			{
				return new MotorcycleChallenge?(config.Value);
			}
			return null;
		}
	}
}
