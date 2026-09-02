using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001169 RID: 4457
[NullableContext(1)]
public interface IActivityRewardViewData
{
	// Token: 0x170009CB RID: 2507
	// (get) Token: 0x0600755E RID: 30046
	// (set) Token: 0x0600755F RID: 30047
	List<IActivityRewardDataPage> DataPageList { get; set; }

	// Token: 0x170009CC RID: 2508
	// (get) Token: 0x06007560 RID: 30048
	// (set) Token: 0x06007561 RID: 30049
	EActivityRewardSource Source { get; set; }

	// Token: 0x170009CD RID: 2509
	// (get) Token: 0x06007562 RID: 30050
	// (set) Token: 0x06007563 RID: 30051
	[Nullable(2)]
	string TitleTextId { [NullableContext(2)] get; [NullableContext(2)] set; }
}
