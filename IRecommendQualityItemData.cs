using System;
using System.Runtime.CompilerServices;

// Token: 0x0200274C RID: 10060
[NullableContext(1)]
public interface IRecommendQualityItemData
{
	// Token: 0x17001962 RID: 6498
	// (get) Token: 0x06013DC3 RID: 81347
	// (set) Token: 0x06013DC4 RID: 81348
	EGameQualitySettingLevel Quality { get; set; }

	// Token: 0x17001963 RID: 6499
	// (get) Token: 0x06013DC5 RID: 81349
	// (set) Token: 0x06013DC6 RID: 81350
	string Name { get; set; }

	// Token: 0x17001964 RID: 6500
	// (get) Token: 0x06013DC7 RID: 81351
	// (set) Token: 0x06013DC8 RID: 81352
	bool IsRecommend { get; set; }

	// Token: 0x17001965 RID: 6501
	// (get) Token: 0x06013DC9 RID: 81353
	// (set) Token: 0x06013DCA RID: 81354
	string Bg { get; set; }
}
