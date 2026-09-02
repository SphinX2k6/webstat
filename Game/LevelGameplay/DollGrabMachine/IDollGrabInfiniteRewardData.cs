using System;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine
{
	// Token: 0x02006ECC RID: 28364
	public interface IDollGrabInfiniteRewardData
	{
		// Token: 0x1700A3EB RID: 41963
		// (get) Token: 0x06044BB9 RID: 281529
		// (set) Token: 0x06044BBA RID: 281530
		int DropId { get; set; }

		// Token: 0x1700A3EC RID: 41964
		// (get) Token: 0x06044BBB RID: 281531
		// (set) Token: 0x06044BBC RID: 281532
		int CurrentScore { get; set; }

		// Token: 0x1700A3ED RID: 41965
		// (get) Token: 0x06044BBD RID: 281533
		// (set) Token: 0x06044BBE RID: 281534
		int CurrentAccumulatedScore { get; set; }

		// Token: 0x1700A3EE RID: 41966
		// (get) Token: 0x06044BBF RID: 281535
		// (set) Token: 0x06044BC0 RID: 281536
		int TargetAccumulatedScore { get; set; }

		// Token: 0x1700A3EF RID: 41967
		// (get) Token: 0x06044BC1 RID: 281537
		// (set) Token: 0x06044BC2 RID: 281538
		int HighestScore { get; set; }

		// Token: 0x1700A3F0 RID: 41968
		// (get) Token: 0x06044BC3 RID: 281539
		// (set) Token: 0x06044BC4 RID: 281540
		bool IsFinalReward { get; set; }

		// Token: 0x1700A3F1 RID: 41969
		// (get) Token: 0x06044BC5 RID: 281541
		// (set) Token: 0x06044BC6 RID: 281542
		bool IsFirstGetReward { get; set; }
	}
}
