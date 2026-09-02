using System;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005239 RID: 21049
	public interface IRogueBattleElementInfo
	{
		// Token: 0x17008C9D RID: 35997
		// (get) Token: 0x06035EA0 RID: 220832
		// (set) Token: 0x06035EA1 RID: 220833
		int ElementId { get; set; }

		// Token: 0x17008C9E RID: 35998
		// (get) Token: 0x06035EA2 RID: 220834
		// (set) Token: 0x06035EA3 RID: 220835
		int Count { get; set; }

		// Token: 0x17008C9F RID: 35999
		// (get) Token: 0x06035EA4 RID: 220836
		// (set) Token: 0x06035EA5 RID: 220837
		bool IsPreview { get; set; }
	}
}
