using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002472 RID: 9330
[NullableContext(1)]
public interface IPhantomManagerApplySettingDetailInfo
{
	// Token: 0x170016C1 RID: 5825
	// (get) Token: 0x06012125 RID: 74021
	// (set) Token: 0x06012126 RID: 74022
	List<PhantomItemData> DiscardList { get; set; }

	// Token: 0x170016C2 RID: 5826
	// (get) Token: 0x06012127 RID: 74023
	// (set) Token: 0x06012128 RID: 74024
	List<PhantomItemData> LockList { get; set; }
}
