using System;
using System.Runtime.CompilerServices;

// Token: 0x02002153 RID: 8531
[NullableContext(1)]
[Nullable(0)]
public class OnClickRecommendSkinButtonLogEvent : PlayerCommonLogData
{
	// Token: 0x170013AB RID: 5035
	// (get) Token: 0x060103F6 RID: 66550 RVA: 0x00475C93 File Offset: 0x00473E93
	// (set) Token: 0x060103F7 RID: 66551 RVA: 0x00475C9B File Offset: 0x00473E9B
	public override string event_id { get; set; } = "1827";

	// Token: 0x04007E79 RID: 32377
	public int i_operation_type;

	// Token: 0x04007E7A RID: 32378
	public int i_item_id;
}
