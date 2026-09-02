using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001166 RID: 4454
[NullableContext(2)]
public interface IActivityRewardDataPage
{
	// Token: 0x170009C3 RID: 2499
	// (get) Token: 0x06007545 RID: 30021
	// (set) Token: 0x06007546 RID: 30022
	string TabName { get; set; }

	// Token: 0x170009C4 RID: 2500
	// (get) Token: 0x06007547 RID: 30023
	// (set) Token: 0x06007548 RID: 30024
	[Nullable(1)]
	List<IActivityRewardData> DataList { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x170009C5 RID: 2501
	// (get) Token: 0x06007549 RID: 30025
	// (set) Token: 0x0600754A RID: 30026
	string TabTips { get; set; }

	// Token: 0x170009C6 RID: 2502
	// (get) Token: 0x0600754B RID: 30027
	// (set) Token: 0x0600754C RID: 30028
	Action<int> TabExtraFunction { get; set; }
}
