using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MoonSignIn
{
	// Token: 0x02006722 RID: 26402
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class MoonSignInConfig : ConfigBase<MoonSignInConfig>
	{
		// Token: 0x06041DCF RID: 269775 RVA: 0x010E5EA2 File Offset: 0x010E40A2
		public IReadOnlyList<PhaseOfMoon> GetPhaseOfMoonList()
		{
			return ConfigPhaseOfMoonAll.GetConfigList(true);
		}

		// Token: 0x06041DD0 RID: 269776 RVA: 0x010E5EAA File Offset: 0x010E40AA
		public MoonPhaseReward? GetMoonSignReward(int activityId)
		{
			return ConfigMoonPhaseRewardByActivityId.GetConfig(activityId, true);
		}

		// Token: 0x06041DD1 RID: 269777 RVA: 0x010E5EB3 File Offset: 0x010E40B3
		public PhaseOfMoon? GetPhaseOfMoonById(int moonId)
		{
			return ConfigPhaseOfMoonById.GetConfig(moonId, true);
		}

		// Token: 0x06041DD2 RID: 269778 RVA: 0x010E5EBC File Offset: 0x010E40BC
		public MoonLabel? GetMoonLabelById(int moonId)
		{
			return ConfigMoonLabelById.GetConfig(moonId, true);
		}
	}
}
