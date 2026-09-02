using System;

namespace CSharpScript.Game.Module.BossPiling
{
	// Token: 0x02005EE5 RID: 24293
	public interface IBossPilingScoreTabInfo
	{
		// Token: 0x17009A06 RID: 39430
		// (get) Token: 0x0603D0B6 RID: 250038
		// (set) Token: 0x0603D0B7 RID: 250039
		int BossHp { get; set; }

		// Token: 0x17009A07 RID: 39431
		// (get) Token: 0x0603D0B8 RID: 250040
		// (set) Token: 0x0603D0B9 RID: 250041
		int Quality { get; set; }

		// Token: 0x17009A08 RID: 39432
		// (get) Token: 0x0603D0BA RID: 250042
		// (set) Token: 0x0603D0BB RID: 250043
		bool IsAchieve { get; set; }
	}
}
