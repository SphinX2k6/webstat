using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween
{
	// Token: 0x02006524 RID: 25892
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class ActivityRealmBetweenConfig : ConfigBase<ActivityRealmBetweenConfig>
	{
		// Token: 0x06040C0B RID: 265227 RVA: 0x0109AC40 File Offset: 0x01098E40
		public RealmBetweenConfig? GetActivityConfig(int activityId)
		{
			RealmBetweenConfig? config = ConfigRealmBetweenConfigByActivityId.GetConfig(activityId, true);
			if (config != null)
			{
				return new RealmBetweenConfig?(config.Value);
			}
			return null;
		}

		// Token: 0x06040C0C RID: 265228 RVA: 0x0109AC74 File Offset: 0x01098E74
		public RealmBetweenLevelExp? GetLevelExpConfig(int id)
		{
			RealmBetweenLevelExp? config = ConfigRealmBetweenLevelExpById.GetConfig(id, true);
			if (config != null)
			{
				return new RealmBetweenLevelExp?(config.Value);
			}
			return null;
		}

		// Token: 0x06040C0D RID: 265229 RVA: 0x0109ACA8 File Offset: 0x01098EA8
		public IReadOnlyList<RealmBetweenLevelExp> GetAllLevelExpConfig(int activityId)
		{
			return ConfigRealmBetweenLevelExpByActivityId.GetConfigList(activityId, true) ?? new List<RealmBetweenLevelExp>();
		}

		// Token: 0x06040C0E RID: 265230 RVA: 0x0109ACBC File Offset: 0x01098EBC
		public RealmBetweenTask? GetRealmBetweenTaskConfig(int taskId)
		{
			RealmBetweenTask? config = ConfigRealmBetweenTaskByTaskId.GetConfig(taskId, true);
			if (config != null)
			{
				return new RealmBetweenTask?(config.Value);
			}
			return null;
		}

		// Token: 0x06040C0F RID: 265231 RVA: 0x0109ACF0 File Offset: 0x01098EF0
		public IReadOnlyList<RealmBetweenTask> GetAllRealmBetweenTaskConfig(int activityId)
		{
			return ConfigRealmBetweenTaskByActivityId.GetConfigList(activityId, true) ?? new List<RealmBetweenTask>();
		}

		// Token: 0x06040C10 RID: 265232 RVA: 0x0109AD04 File Offset: 0x01098F04
		public RealmBetweenArea? GetAreaConfig(int id)
		{
			RealmBetweenArea? config = ConfigRealmBetweenAreaById.GetConfig(id, true);
			if (config != null)
			{
				return new RealmBetweenArea?(config.Value);
			}
			return null;
		}

		// Token: 0x06040C11 RID: 265233 RVA: 0x0109AD38 File Offset: 0x01098F38
		public IReadOnlyList<RealmBetweenArea> GetAllAreaConfig(int activityId)
		{
			return ConfigRealmBetweenAreaByActivityId.GetConfigList(activityId, true) ?? new List<RealmBetweenArea>();
		}

		// Token: 0x06040C12 RID: 265234 RVA: 0x0109AD4C File Offset: 0x01098F4C
		public RealmBetweenPhantomGain? GetPhantomConfig(int id)
		{
			RealmBetweenPhantomGain? config = ConfigRealmBetweenPhantomGainById.GetConfig(id, true);
			if (config != null)
			{
				return new RealmBetweenPhantomGain?(config.Value);
			}
			return null;
		}

		// Token: 0x06040C13 RID: 265235 RVA: 0x0109AD80 File Offset: 0x01098F80
		public IReadOnlyList<RealmBetweenPhantomGain> GetAllPhantomConfig(int activityId)
		{
			return ConfigRealmBetweenPhantomGainByActivityId.GetConfigList(activityId, true) ?? new List<RealmBetweenPhantomGain>();
		}

		// Token: 0x06040C14 RID: 265236 RVA: 0x0109AD92 File Offset: 0x01098F92
		public IReadOnlyList<RealmBetweenChallenge> GetAllMotorChallengeConfig()
		{
			return ConfigRealmBetweenChallengeAll.GetConfigList(true) ?? new List<RealmBetweenChallenge>();
		}

		// Token: 0x06040C15 RID: 265237 RVA: 0x0109ADA4 File Offset: 0x01098FA4
		public RealmBetweenChallenge? GetMotorChallengeConfig(int id)
		{
			RealmBetweenChallenge? config = ConfigRealmBetweenChallengeById.GetConfig(id, true);
			if (config != null)
			{
				return new RealmBetweenChallenge?(config.Value);
			}
			return null;
		}
	}
}
