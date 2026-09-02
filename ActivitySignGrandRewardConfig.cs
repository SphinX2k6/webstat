using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x0200145F RID: 5215
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ActivitySignGrandRewardConfig : ConfigBase<ActivitySignGrandRewardConfig>
{
	// Token: 0x0600915F RID: 37215 RVA: 0x00264FFE File Offset: 0x002631FE
	public ActivitySignGrandReward? GetById(int actId)
	{
		return ConfigActivitySignGrandRewardById.GetConfig(actId, true);
	}
}
