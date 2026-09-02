using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001177 RID: 4471
[NullableContext(1)]
public interface IActivityCategoryTabData
{
	// Token: 0x170009E8 RID: 2536
	// (get) Token: 0x060075AB RID: 30123
	// (set) Token: 0x060075AC RID: 30124
	bool IsLineType { get; set; }

	// Token: 0x170009E9 RID: 2537
	// (get) Token: 0x060075AD RID: 30125
	// (set) Token: 0x060075AE RID: 30126
	int? Id { get; set; }

	// Token: 0x170009EA RID: 2538
	// (get) Token: 0x060075AF RID: 30127
	// (set) Token: 0x060075B0 RID: 30128
	string TextId { get; set; }

	// Token: 0x170009EB RID: 2539
	// (get) Token: 0x060075B1 RID: 30129
	// (set) Token: 0x060075B2 RID: 30130
	string IconPath { get; set; }

	// Token: 0x170009EC RID: 2540
	// (get) Token: 0x060075B3 RID: 30131
	// (set) Token: 0x060075B4 RID: 30132
	List<ActivityBaseData> Activities { get; set; }
}
