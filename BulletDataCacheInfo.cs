using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002D9A RID: 11674
public class BulletDataCacheInfo
{
	// Token: 0x0400B490 RID: 46224
	[Nullable(1)]
	public Dictionary<string, BulletDataMain> BulletDataMap = new Dictionary<string, BulletDataMain>();

	// Token: 0x0400B491 RID: 46225
	[Nullable(2)]
	public UDataTable DataTable;

	// Token: 0x0400B492 RID: 46226
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public UDataTable[] DataTableExtraList;

	// Token: 0x0400B493 RID: 46227
	public int EntityCount;
}
