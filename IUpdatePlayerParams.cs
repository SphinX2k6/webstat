using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200295F RID: 10591
[NullableContext(1)]
public interface IUpdatePlayerParams
{
	// Token: 0x17001BA7 RID: 7079
	// (get) Token: 0x060150CB RID: 86219
	// (set) Token: 0x060150CC RID: 86220
	int PlayerId { get; set; }

	// Token: 0x17001BA8 RID: 7080
	// (get) Token: 0x060150CD RID: 86221
	// (set) Token: 0x060150CE RID: 86222
	ETeamGroupType CurrentGroupType { get; set; }

	// Token: 0x17001BA9 RID: 7081
	// (get) Token: 0x060150CF RID: 86223
	// (set) Token: 0x060150D0 RID: 86224
	IList<IUpdateGroupParams> Groups { get; set; }
}
