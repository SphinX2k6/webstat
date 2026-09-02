using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Item
{
	// Token: 0x020068E5 RID: 26853
	public interface IDropCatchRewardPreviewData
	{
		// Token: 0x1700A1BF RID: 41407
		// (get) Token: 0x06042BE3 RID: 273379
		// (set) Token: 0x06042BE4 RID: 273380
		int CfgId { get; set; }

		// Token: 0x1700A1C0 RID: 41408
		// (get) Token: 0x06042BE5 RID: 273381
		// (set) Token: 0x06042BE6 RID: 273382
		EDropCatchLevelState? State { get; set; }

		// Token: 0x1700A1C1 RID: 41409
		// (get) Token: 0x06042BE7 RID: 273383
		// (set) Token: 0x06042BE8 RID: 273384
		bool IsLast { get; set; }
	}
}
