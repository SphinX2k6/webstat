using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001A9B RID: 6811
public class DailyActiveTaskData
{
	// Token: 0x04005D77 RID: 23927
	[Nullable(1)]
	public List<TItem> RewardItemList = new List<TItem>();

	// Token: 0x04005D78 RID: 23928
	public int? TaskId = new int?(0);

	// Token: 0x04005D79 RID: 23929
	public EDailyActiveState TaskState = EDailyActiveState.Unfinished;

	// Token: 0x04005D7A RID: 23930
	public int? CurrentProgress = new int?(0);

	// Token: 0x04005D7B RID: 23931
	public int? TargetProgress = new int?(0);

	// Token: 0x04005D7C RID: 23932
	public int Sort;

	// Token: 0x04005D7D RID: 23933
	public bool IsFunctionUnlock;
}
