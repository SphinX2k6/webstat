using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Item
{
	// Token: 0x020068E1 RID: 26849
	public interface IDropCatchLevelItemData
	{
		// Token: 0x1700A1B9 RID: 41401
		// (get) Token: 0x06042BCD RID: 273357
		// (set) Token: 0x06042BCE RID: 273358
		int CfgId { get; set; }

		// Token: 0x1700A1BA RID: 41402
		// (get) Token: 0x06042BCF RID: 273359
		// (set) Token: 0x06042BD0 RID: 273360
		EDropCatchLevelState? State { get; set; }

		// Token: 0x1700A1BB RID: 41403
		// (get) Token: 0x06042BD1 RID: 273361
		// (set) Token: 0x06042BD2 RID: 273362
		bool HasRedPoint { get; set; }
	}
}
