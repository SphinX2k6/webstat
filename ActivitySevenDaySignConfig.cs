using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020015A9 RID: 5545
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ActivitySevenDaySignConfig : ConfigBase<ActivitySevenDaySignConfig>
{
	// Token: 0x06009C46 RID: 40006 RVA: 0x0028ECA0 File Offset: 0x0028CEA0
	public ActivitySign? GetActivitySignById(int actId)
	{
		return ConfigActivitySignById.GetConfig(actId, true);
	}

	// Token: 0x06009C47 RID: 40007 RVA: 0x0028ECAC File Offset: 0x0028CEAC
	public OneItemConfig? GetActivityRewardByDay(int actId, int day)
	{
		ActivitySign? config = ConfigActivitySignById.GetConfig(actId, true);
		if (config == null)
		{
			return null;
		}
		return config.GetValueOrDefault().SignRewards(day);
	}
}
