using System;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x020051D0 RID: 20944
	public interface IFetterData
	{
		// Token: 0x17008C93 RID: 35987
		// (get) Token: 0x06035D1F RID: 220447
		// (set) Token: 0x06035D20 RID: 220448
		int Id { get; set; }

		// Token: 0x17008C94 RID: 35988
		// (get) Token: 0x06035D21 RID: 220449
		// (set) Token: 0x06035D22 RID: 220450
		int Lv { get; set; }

		// Token: 0x17008C95 RID: 35989
		// (get) Token: 0x06035D23 RID: 220451
		// (set) Token: 0x06035D24 RID: 220452
		int Star { get; set; }

		// Token: 0x17008C96 RID: 35990
		// (get) Token: 0x06035D25 RID: 220453
		// (set) Token: 0x06035D26 RID: 220454
		bool IsLevelUp { get; set; }
	}
}
