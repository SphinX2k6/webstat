using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RougeActivity
{
	// Token: 0x02006471 RID: 25713
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class ActivityRogueConfig : ConfigBase<ActivityRogueConfig>
	{
		// Token: 0x060407F5 RID: 264181 RVA: 0x01087600 File Offset: 0x01085800
		public RogueActivity? GetActivityUniversalConfig(int activityId)
		{
			RogueActivity? config = ConfigRogueActivityById.GetConfig(activityId, true);
			if (config == null)
			{
				return null;
			}
			return config;
		}
	}
}
