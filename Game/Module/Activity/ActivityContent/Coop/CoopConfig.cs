using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Coop
{
	// Token: 0x0200698A RID: 27018
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class CoopConfig : ConfigBase<CoopConfig>
	{
		// Token: 0x060430B0 RID: 274608 RVA: 0x0113780C File Offset: 0x01135A0C
		public CoopRoleLevel? GetCoopConfigById(int id)
		{
			return ConfigCoopRoleLevelByID.GetConfig(id, true);
		}

		// Token: 0x060430B1 RID: 274609 RVA: 0x01137815 File Offset: 0x01135A15
		public IReadOnlyList<CoopRoleLevel> GetCoopConfigAllLevel(int activityId, int roleId)
		{
			return ConfigCoopRoleLevelAllLevelData.GetConfigList(activityId, roleId, true);
		}

		// Token: 0x060430B2 RID: 274610 RVA: 0x0113781F File Offset: 0x01135A1F
		public CoopRole? GetCoopRoleConfigByRoleId(int roleId)
		{
			return ConfigCoopRoleByRoleId.GetConfig(roleId, true);
		}

		// Token: 0x060430B3 RID: 274611 RVA: 0x01137828 File Offset: 0x01135A28
		public CoopSpReward? GetCoopSpRewardConfigById(int id)
		{
			return ConfigCoopSpRewardById.GetConfig(id, true);
		}

		// Token: 0x060430B4 RID: 274612 RVA: 0x01137831 File Offset: 0x01135A31
		public IReadOnlyList<CoopSpReward> GetCoopSpRewardConfigByActivityId(int activityId)
		{
			return ConfigCoopSpRewardListByActivityId.GetConfigList(activityId, true);
		}

		// Token: 0x060430B5 RID: 274613 RVA: 0x0113783A File Offset: 0x01135A3A
		public CoopTaskConfig? GetCoopTaskConfigById(int id)
		{
			return ConfigCoopTaskConfigByID.GetConfig(id, true);
		}
	}
}
