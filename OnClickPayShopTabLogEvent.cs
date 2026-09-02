using System;
using System.Runtime.CompilerServices;

// Token: 0x02002152 RID: 8530
[NullableContext(1)]
[Nullable(0)]
public class OnClickPayShopTabLogEvent : PlayerCommonLogData
{
	// Token: 0x170013AA RID: 5034
	// (get) Token: 0x060103F3 RID: 66547 RVA: 0x00475C6F File Offset: 0x00473E6F
	// (set) Token: 0x060103F4 RID: 66548 RVA: 0x00475C77 File Offset: 0x00473E77
	public override string event_id { get; set; } = "1826";

	// Token: 0x04007E76 RID: 32374
	public int i_shop_id;

	// Token: 0x04007E77 RID: 32375
	public int i_tab_id;
}
