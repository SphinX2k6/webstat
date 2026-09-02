using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002561 RID: 9569
public class PhoneMsgShortMsgData
{
	// Token: 0x060129E7 RID: 76263 RVA: 0x00521E7C File Offset: 0x0052007C
	public PhoneMsgShortMsgData(int shortMsgId)
	{
		this.ShortMsgId = shortMsgId;
	}

	// Token: 0x0400914D RID: 37197
	public readonly int ShortMsgId;

	// Token: 0x0400914E RID: 37198
	public bool IsRead;

	// Token: 0x0400914F RID: 37199
	public bool IsReceived;

	// Token: 0x04009150 RID: 37200
	public long UnLockTime;

	// Token: 0x04009151 RID: 37201
	public int LatestProgress;

	// Token: 0x04009152 RID: 37202
	[Nullable(1)]
	public Dictionary<int, int> SelectedOptionsDict = new Dictionary<int, int>();
}
