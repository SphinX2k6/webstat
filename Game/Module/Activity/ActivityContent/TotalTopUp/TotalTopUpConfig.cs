using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp
{
	// Token: 0x0200625B RID: 25179
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class TotalTopUpConfig : ConfigBase<TotalTopUpConfig>
	{
		// Token: 0x0603F74B RID: 259915 RVA: 0x010444D0 File Offset: 0x010426D0
		public TotalTopUpReward? GetRewardConfigById(int rewardId)
		{
			return ConfigTotalTopUpRewardById.GetConfig(rewardId, true);
		}

		// Token: 0x0603F74C RID: 259916 RVA: 0x010444D9 File Offset: 0x010426D9
		public IReadOnlyList<TotalTopUpReward> GetAllRewardConfigs()
		{
			return ConfigTotalTopUpRewardAll.GetConfigList(true);
		}

		// Token: 0x0603F74D RID: 259917 RVA: 0x010444E4 File Offset: 0x010426E4
		public string GetTotalUpScoreIcon(int activityId)
		{
			TotalTopUpViewConfig? config = ConfigTotalTopUpViewConfigByActivityId.GetConfig(activityId, true);
			if (config == null)
			{
				return null;
			}
			return config.Value.ScoreIcon;
		}

		// Token: 0x0603F74E RID: 259918 RVA: 0x01044513 File Offset: 0x01042713
		public TotalTopUpRoleViewConfig? GetRoleViewConfigByRoleIdOrItemId(int roleIdOrItemId)
		{
			return ConfigTotalTopUpRoleViewConfigByItemId.GetConfig(roleIdOrItemId, true);
		}

		// Token: 0x0603F74F RID: 259919 RVA: 0x0104451C File Offset: 0x0104271C
		public TotalTopUpViewConfig? GetViewConfigByActivityId(int activityId)
		{
			return ConfigTotalTopUpViewConfigByActivityId.GetConfig(activityId, true);
		}
	}
}
