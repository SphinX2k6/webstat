using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip
{
	// Token: 0x020064C6 RID: 25798
	public interface IRhythmShipLevelDifficultyInfo
	{
		// Token: 0x17009E64 RID: 40548
		// (get) Token: 0x06040A4E RID: 264782
		// (set) Token: 0x06040A4F RID: 264783
		int HistoryScore { get; set; }

		// Token: 0x17009E65 RID: 40549
		// (get) Token: 0x06040A50 RID: 264784
		// (set) Token: 0x06040A51 RID: 264785
		int Accuracy { get; set; }

		// Token: 0x17009E66 RID: 40550
		// (get) Token: 0x06040A52 RID: 264786
		// (set) Token: 0x06040A53 RID: 264787
		int Rating { get; set; }
	}
}
