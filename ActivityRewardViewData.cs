using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200116A RID: 4458
[NullableContext(1)]
[Nullable(0)]
public class ActivityRewardViewData : IActivityRewardViewData
{
	// Token: 0x170009CE RID: 2510
	// (get) Token: 0x06007564 RID: 30052 RVA: 0x001ECEF9 File Offset: 0x001EB0F9
	// (set) Token: 0x06007565 RID: 30053 RVA: 0x001ECF01 File Offset: 0x001EB101
	public List<IActivityRewardDataPage> DataPageList { get; set; }

	// Token: 0x170009CF RID: 2511
	// (get) Token: 0x06007566 RID: 30054 RVA: 0x001ECF0A File Offset: 0x001EB10A
	// (set) Token: 0x06007567 RID: 30055 RVA: 0x001ECF12 File Offset: 0x001EB112
	public EActivityRewardSource Source { get; set; }

	// Token: 0x170009D0 RID: 2512
	// (get) Token: 0x06007568 RID: 30056 RVA: 0x001ECF1B File Offset: 0x001EB11B
	// (set) Token: 0x06007569 RID: 30057 RVA: 0x001ECF23 File Offset: 0x001EB123
	[Nullable(2)]
	public string TitleTextId { [NullableContext(2)] get; [NullableContext(2)] set; }
}
