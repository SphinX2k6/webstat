using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.LinkageReward
{
	// Token: 0x02006753 RID: 26451
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class LinkageRewardActivityConfig : ConfigBase<LinkageRewardActivityConfig>
	{
		// Token: 0x06041F1B RID: 270107 RVA: 0x010EABE4 File Offset: 0x010E8DE4
		public LinkageReward? GetById(int id)
		{
			return ConfigLinkageRewardById.GetConfig(id, true);
		}

		// Token: 0x06041F1C RID: 270108 RVA: 0x010EABED File Offset: 0x010E8DED
		public IReadOnlyList<LinkageReward> GetListByActivityId(int activityId)
		{
			return ConfigLinkageRewardByActivityId.GetConfigList(activityId, true);
		}
	}
}
