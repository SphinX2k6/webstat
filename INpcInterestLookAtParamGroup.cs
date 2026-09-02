using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200319D RID: 12701
[NullableContext(1)]
public interface INpcInterestLookAtParamGroup
{
	// Token: 0x170023D4 RID: 9172
	// (get) Token: 0x0601A592 RID: 107922
	// (set) Token: 0x0601A593 RID: 107923
	string Key { get; set; }

	// Token: 0x170023D5 RID: 9173
	// (get) Token: 0x0601A594 RID: 107924
	// (set) Token: 0x0601A595 RID: 107925
	IList<int> PbDataIds { get; set; }

	// Token: 0x170023D6 RID: 9174
	// (get) Token: 0x0601A596 RID: 107926
	// (set) Token: 0x0601A597 RID: 107927
	IList<INpcInterestLookAtParam> Params { get; set; }
}
