using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001167 RID: 4455
[NullableContext(2)]
[Nullable(0)]
public class ActivityRewardDataPage : IActivityRewardDataPage
{
	// Token: 0x170009C7 RID: 2503
	// (get) Token: 0x0600754D RID: 30029 RVA: 0x001ECD77 File Offset: 0x001EAF77
	// (set) Token: 0x0600754E RID: 30030 RVA: 0x001ECD7F File Offset: 0x001EAF7F
	public string TabName { get; set; }

	// Token: 0x170009C8 RID: 2504
	// (get) Token: 0x0600754F RID: 30031 RVA: 0x001ECD88 File Offset: 0x001EAF88
	// (set) Token: 0x06007550 RID: 30032 RVA: 0x001ECD90 File Offset: 0x001EAF90
	[Nullable(1)]
	public List<IActivityRewardData> DataList { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x170009C9 RID: 2505
	// (get) Token: 0x06007551 RID: 30033 RVA: 0x001ECD99 File Offset: 0x001EAF99
	// (set) Token: 0x06007552 RID: 30034 RVA: 0x001ECDA1 File Offset: 0x001EAFA1
	public string TabTips { get; set; }

	// Token: 0x170009CA RID: 2506
	// (get) Token: 0x06007553 RID: 30035 RVA: 0x001ECDAA File Offset: 0x001EAFAA
	// (set) Token: 0x06007554 RID: 30036 RVA: 0x001ECDB2 File Offset: 0x001EAFB2
	public Action<int> TabExtraFunction { get; set; }
}
