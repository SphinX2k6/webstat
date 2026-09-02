using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.PreWarm
{
	// Token: 0x0200657A RID: 25978
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class ActivityPreWarmConfig : ConfigBase<ActivityPreWarmConfig>
	{
		// Token: 0x06040E23 RID: 265763 RVA: 0x010A4F07 File Offset: 0x010A3107
		public PreHeatTaskActivity? GetPreWarmConfig(int id)
		{
			return ConfigPreHeatTaskActivityById.GetConfig(id, true);
		}
	}
}
