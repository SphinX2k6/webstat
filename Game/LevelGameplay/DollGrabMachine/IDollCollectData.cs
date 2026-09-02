using System;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine
{
	// Token: 0x02006ED2 RID: 28370
	public interface IDollCollectData
	{
		// Token: 0x1700A403 RID: 41987
		// (get) Token: 0x06044BEE RID: 281582
		// (set) Token: 0x06044BEF RID: 281583
		int CurrentCollectCount { get; set; }

		// Token: 0x1700A404 RID: 41988
		// (get) Token: 0x06044BF0 RID: 281584
		// (set) Token: 0x06044BF1 RID: 281585
		int TotalCollectCount { get; set; }

		// Token: 0x1700A405 RID: 41989
		// (get) Token: 0x06044BF2 RID: 281586
		// (set) Token: 0x06044BF3 RID: 281587
		int CurrentCollectItemCount { get; set; }

		// Token: 0x1700A406 RID: 41990
		// (get) Token: 0x06044BF4 RID: 281588
		// (set) Token: 0x06044BF5 RID: 281589
		int TotalCollectItemCount { get; set; }
	}
}
