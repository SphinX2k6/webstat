using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200247E RID: 9342
public class RecommendData
{
	// Token: 0x06012221 RID: 74273 RVA: 0x004FBCC9 File Offset: 0x004F9EC9
	public RecommendData()
	{
		this.MonsterIdList = new List<int>();
	}

	// Token: 0x04008D7D RID: 36221
	public int RoleId;

	// Token: 0x04008D7E RID: 36222
	[Nullable(1)]
	public List<int> MonsterIdList;

	// Token: 0x04008D7F RID: 36223
	public int FetterGroupId;

	// Token: 0x04008D80 RID: 36224
	public int MainPropId;
}
