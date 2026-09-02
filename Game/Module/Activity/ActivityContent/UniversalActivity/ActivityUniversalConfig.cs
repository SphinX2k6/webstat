using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.UniversalActivity
{
	// Token: 0x02006257 RID: 25175
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class ActivityUniversalConfig : ConfigBase<ActivityUniversalConfig>
	{
		// Token: 0x0603F735 RID: 259893 RVA: 0x01044192 File Offset: 0x01042392
		public UniversalActivity? GetActivityUniversalConfig(int activityId)
		{
			return ConfigUniversalActivityById.GetConfig(activityId, true);
		}
	}
}
