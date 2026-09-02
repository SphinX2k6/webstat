using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002BDE RID: 11230
public class TowerDetailBuffData
{
	// Token: 0x0400AD7A RID: 44410
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<TowerDetailBuff> Buffs;

	// Token: 0x0400AD7B RID: 44411
	[Nullable(1)]
	public string Title = string.Empty;

	// Token: 0x0400AD7C RID: 44412
	public int Priority;
}
