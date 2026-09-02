using System;
using System.Runtime.CompilerServices;

// Token: 0x02001495 RID: 5269
public class PinballLevelRecordData
{
	// Token: 0x04004431 RID: 17457
	public int LevelId;

	// Token: 0x04004432 RID: 17458
	public int ChapterId;

	// Token: 0x04004433 RID: 17459
	[Nullable(1)]
	public int[] LevelStarConditionIds = Array.Empty<int>();

	// Token: 0x04004434 RID: 17460
	public int LevelScore;

	// Token: 0x04004435 RID: 17461
	public int LevelPassedTime;

	// Token: 0x04004436 RID: 17462
	public EPinballLevelShowType LevelShowType = EPinballLevelShowType.Normal;

	// Token: 0x04004437 RID: 17463
	public EPinballLevelPassStatus PassStatus = EPinballLevelPassStatus.Unfinished;
}
