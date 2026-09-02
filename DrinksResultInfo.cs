using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02000FF9 RID: 4089
public class DrinksResultInfo
{
	// Token: 0x04003269 RID: 12905
	public int RequireId;

	// Token: 0x0400326A RID: 12906
	[Nullable(1)]
	public List<int> DrinkBase = new List<int>();

	// Token: 0x0400326B RID: 12907
	public int Ornament;

	// Token: 0x0400326C RID: 12908
	[Nullable(2)]
	public IReadOnlyList<int> Batching;
}
