using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020012B7 RID: 4791
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class CumulativeShopConfig : ConfigBase<CumulativeShopConfig>
{
	// Token: 0x060080A5 RID: 32933 RVA: 0x0021FBB4 File Offset: 0x0021DDB4
	public ConsumptiveTask? GetCumulativeShopTaskConfig(int taskId)
	{
		return ConfigConsumptiveTaskById.GetConfig(taskId, true);
	}

	// Token: 0x060080A6 RID: 32934 RVA: 0x0021FBBD File Offset: 0x0021DDBD
	public ConsumptiveTaskTab? GetCumulativeShopTaskTabConfig(int tabId)
	{
		return ConfigConsumptiveTaskTabById.GetConfig(tabId, true);
	}
}
