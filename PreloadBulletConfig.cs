using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002D99 RID: 11673
public class PreloadBulletConfig
{
	// Token: 0x0400B48C RID: 46220
	public int ModelId;

	// Token: 0x0400B48D RID: 46221
	[Nullable(2)]
	public UDataTable DataTable;

	// Token: 0x0400B48E RID: 46222
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public string[] RowNames;

	// Token: 0x0400B48F RID: 46223
	public int CurIndex;
}
