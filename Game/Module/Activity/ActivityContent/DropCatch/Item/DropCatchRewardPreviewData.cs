using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Item
{
	// Token: 0x020068E6 RID: 26854
	public class DropCatchRewardPreviewData : IDropCatchRewardPreviewData
	{
		// Token: 0x1700A1C2 RID: 41410
		// (get) Token: 0x06042BE9 RID: 273385 RVA: 0x01121341 File Offset: 0x0111F541
		// (set) Token: 0x06042BEA RID: 273386 RVA: 0x01121349 File Offset: 0x0111F549
		public int CfgId { get; set; }

		// Token: 0x1700A1C3 RID: 41411
		// (get) Token: 0x06042BEB RID: 273387 RVA: 0x01121352 File Offset: 0x0111F552
		// (set) Token: 0x06042BEC RID: 273388 RVA: 0x0112135A File Offset: 0x0111F55A
		public EDropCatchLevelState? State { get; set; }

		// Token: 0x1700A1C4 RID: 41412
		// (get) Token: 0x06042BED RID: 273389 RVA: 0x01121363 File Offset: 0x0111F563
		// (set) Token: 0x06042BEE RID: 273390 RVA: 0x0112136B File Offset: 0x0111F56B
		public bool IsLast { get; set; }
	}
}
