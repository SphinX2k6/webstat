using System;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine
{
	// Token: 0x02006ED0 RID: 28368
	public interface IDollGrabInfiniteShowCaseRewardData
	{
		// Token: 0x1700A3FD RID: 41981
		// (get) Token: 0x06044BE1 RID: 281569
		// (set) Token: 0x06044BE2 RID: 281570
		int DropId { get; set; }

		// Token: 0x1700A3FE RID: 41982
		// (get) Token: 0x06044BE3 RID: 281571
		// (set) Token: 0x06044BE4 RID: 281572
		int GetRewardIndex { get; set; }

		// Token: 0x1700A3FF RID: 41983
		// (get) Token: 0x06044BE5 RID: 281573
		// (set) Token: 0x06044BE6 RID: 281574
		int NextRewardIndex { get; set; }
	}
}
