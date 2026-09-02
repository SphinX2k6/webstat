using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B01 RID: 23297
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class ItemRewardConfig : ConfigBase<ItemRewardConfig>
	{
		// Token: 0x0603AE8B RID: 241291 RVA: 0x00EF04BB File Offset: 0x00EEE6BB
		public RewardViewFromSource? GetRewardViewFromSourceConfig(int sourceId)
		{
			return ConfigRewardViewFromSourceBySourceId.GetConfig(sourceId, true);
		}

		// Token: 0x0603AE8C RID: 241292 RVA: 0x00EF04C4 File Offset: 0x00EEE6C4
		public CommonRewardViewDisplay? GetCommonRewardViewDisplayConfig(int configId)
		{
			return ConfigCommonRewardViewDisplayById.GetConfig(configId, true);
		}

		// Token: 0x0603AE8D RID: 241293 RVA: 0x00EF04CD File Offset: 0x00EEE6CD
		public CompositeRewardDisplay? GetCompositeRewardViewDisplayConfig(int configId)
		{
			return ConfigCompositeRewardDisplayById.GetConfig(configId, true);
		}

		// Token: 0x0603AE8E RID: 241294 RVA: 0x00EF04D6 File Offset: 0x00EEE6D6
		public ExploreRewardDisplay? GetExploreRewardDisplayConfig(int configId)
		{
			return ConfigExploreRewardDisplayById.GetConfig(configId, true);
		}

		// Token: 0x0603AE8F RID: 241295 RVA: 0x00EF04DF File Offset: 0x00EEE6DF
		public IReadOnlyList<RewardViewFromSource> GetAllRewardViewFromSourceConfig()
		{
			return ConfigRewardViewFromSourceAll.GetConfigList(true);
		}
	}
}
