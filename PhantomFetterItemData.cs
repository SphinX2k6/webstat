using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002491 RID: 9361
public class PhantomFetterItemData
{
	// Token: 0x04008DCD RID: 36301
	public PhantomFetterGroup? PhantomFetterGroup;

	// Token: 0x04008DCE RID: 36302
	public int RoleId;

	// Token: 0x04008DCF RID: 36303
	[Nullable(1)]
	public List<int> RecommendGroupIds = new List<int>();
}
