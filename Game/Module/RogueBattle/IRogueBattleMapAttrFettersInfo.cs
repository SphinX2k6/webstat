using System;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005243 RID: 21059
	public interface IRogueBattleMapAttrFettersInfo
	{
		// Token: 0x17008CB5 RID: 36021
		// (get) Token: 0x06035ED4 RID: 220884
		// (set) Token: 0x06035ED5 RID: 220885
		int ConfigId { get; set; }

		// Token: 0x17008CB6 RID: 36022
		// (get) Token: 0x06035ED6 RID: 220886
		// (set) Token: 0x06035ED7 RID: 220887
		bool IsUnlock { get; set; }

		// Token: 0x17008CB7 RID: 36023
		// (get) Token: 0x06035ED8 RID: 220888
		// (set) Token: 0x06035ED9 RID: 220889
		int Level { get; set; }

		// Token: 0x17008CB8 RID: 36024
		// (get) Token: 0x06035EDA RID: 220890
		// (set) Token: 0x06035EDB RID: 220891
		bool? IsMaxLevel { get; set; }
	}
}
