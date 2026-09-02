using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x0200249F RID: 9375
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class VisionRecommendConfig : ConfigBase<VisionRecommendConfig>
{
	// Token: 0x0601230C RID: 74508 RVA: 0x005014CA File Offset: 0x004FF6CA
	public IReadOnlyList<PhantomOneKeyEquip> GetAllVisionEquipPlanConfig()
	{
		return ConfigPhantomOneKeyEquipAll.GetConfigList(true);
	}
}
