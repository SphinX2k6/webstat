using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002474 RID: 9332
[NullableContext(1)]
public interface IPhantomManagerEditPopInfo
{
	// Token: 0x170016C5 RID: 5829
	// (get) Token: 0x0601212E RID: 74030
	// (set) Token: 0x0601212F RID: 74031
	int FetterId { get; set; }

	// Token: 0x170016C6 RID: 5830
	// (get) Token: 0x06012130 RID: 74032
	// (set) Token: 0x06012131 RID: 74033
	int Count { get; set; }

	// Token: 0x170016C7 RID: 5831
	// (get) Token: 0x06012132 RID: 74034
	// (set) Token: 0x06012133 RID: 74035
	List<IPhantomManagerConfigNewSettingInfo> DataList { get; set; }

	// Token: 0x170016C8 RID: 5832
	// (get) Token: 0x06012134 RID: 74036
	// (set) Token: 0x06012135 RID: 74037
	[Nullable(2)]
	Action CloseCb { [NullableContext(2)] get; [NullableContext(2)] set; }
}
