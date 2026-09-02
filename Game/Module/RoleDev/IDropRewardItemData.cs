using System;

namespace CSharpScript.Game.Module.RoleDev
{
	// Token: 0x0200503C RID: 20540
	public interface IDropRewardItemData
	{
		// Token: 0x17008AF9 RID: 35577
		// (get) Token: 0x06034E34 RID: 216628
		// (set) Token: 0x06034E35 RID: 216629
		int ItemId { get; set; }

		// Token: 0x17008AFA RID: 35578
		// (get) Token: 0x06034E36 RID: 216630
		// (set) Token: 0x06034E37 RID: 216631
		int Count { get; set; }

		// Token: 0x17008AFB RID: 35579
		// (get) Token: 0x06034E38 RID: 216632
		// (set) Token: 0x06034E39 RID: 216633
		bool HaveFinish { get; set; }
	}
}
