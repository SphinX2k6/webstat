using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoleSkinReward
{
	// Token: 0x0200647D RID: 25725
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class ActivityRoleSkinRewardConfig : ConfigBase<ActivityRoleSkinRewardConfig>
	{
		// Token: 0x0604088F RID: 264335 RVA: 0x0108AC1C File Offset: 0x01088E1C
		public SkinRewardActivityReward? GetActivityConfig(int activityId)
		{
			SkinRewardActivityReward? config = ConfigSkinRewardActivityRewardByActivityId.GetConfig(activityId, true);
			if (config != null)
			{
				return new SkinRewardActivityReward?(config.Value);
			}
			return null;
		}
	}
}
