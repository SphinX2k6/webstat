using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020011FA RID: 4602
[NullableContext(2)]
[Nullable(0)]
public class BabelTowerInstanceData
{
	// Token: 0x04003A94 RID: 14996
	public int LevelId;

	// Token: 0x04003A95 RID: 14997
	public int CurStarNum;

	// Token: 0x04003A96 RID: 14998
	public int UseReviveCount;

	// Token: 0x04003A97 RID: 14999
	public int RoleCd;

	// Token: 0x04003A98 RID: 15000
	public List<int> BuffSelection;

	// Token: 0x04003A99 RID: 15001
	public List<int> DeTermIdList;

	// Token: 0x04003A9A RID: 15002
	[Nullable(1)]
	public string TraceId = "";
}
