using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02003118 RID: 12568
[NullableContext(2)]
[Nullable(0)]
public class FightDataTableSnapshot
{
	// Token: 0x0400D0B5 RID: 53429
	public UDataTable SelfTable;

	// Token: 0x0400D0B6 RID: 53430
	public UDataTable CommonTable;

	// Token: 0x0400D0B7 RID: 53431
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public IReadOnlyList<UDataTable> ExtraTables;
}
