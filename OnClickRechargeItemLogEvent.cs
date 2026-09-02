using System;
using System.Runtime.CompilerServices;

// Token: 0x02002156 RID: 8534
[NullableContext(1)]
[Nullable(0)]
public class OnClickRechargeItemLogEvent : PlayerCommonLogData
{
	// Token: 0x170013AE RID: 5038
	// (get) Token: 0x060103FF RID: 66559 RVA: 0x00475CFF File Offset: 0x00473EFF
	// (set) Token: 0x06010400 RID: 66560 RVA: 0x00475D07 File Offset: 0x00473F07
	public override string event_id { get; set; } = "1830";

	// Token: 0x04007E85 RID: 32389
	public int i_id;

	// Token: 0x04007E86 RID: 32390
	public int i_shop_id;
}
