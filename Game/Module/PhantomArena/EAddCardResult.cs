using System;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x02005473 RID: 21619
	public enum EAddCardResult
	{
		// Token: 0x0401FB2A RID: 129834
		Success,
		// Token: 0x0401FB2B RID: 129835
		CoreSlotLocked,
		// Token: 0x0401FB2C RID: 129836
		TotalCoreCardCountLimit,
		// Token: 0x0401FB2D RID: 129837
		TotalFieldCardCountLimit,
		// Token: 0x0401FB2E RID: 129838
		TotalItemCardCountLimit,
		// Token: 0x0401FB2F RID: 129839
		CoreCardSlotLimit,
		// Token: 0x0401FB30 RID: 129840
		TotalNormalCardCountLimit,
		// Token: 0x0401FB31 RID: 129841
		NormalCardSlotLimit,
		// Token: 0x0401FB32 RID: 129842
		ElementLimit,
		// Token: 0x0401FB33 RID: 129843
		CardMaxLimitByCost3,
		// Token: 0x0401FB34 RID: 129844
		CardMaxLimitByCost1,
		// Token: 0x0401FB35 RID: 129845
		AddCountZero
	}
}
