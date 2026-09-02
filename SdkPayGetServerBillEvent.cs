using System;
using System.Runtime.CompilerServices;

// Token: 0x02002149 RID: 8521
[NullableContext(1)]
[Nullable(0)]
public class SdkPayGetServerBillEvent : PlayerCommonLogData
{
	// Token: 0x170013A1 RID: 5025
	// (get) Token: 0x060103D8 RID: 66520 RVA: 0x00475B15 File Offset: 0x00473D15
	// (set) Token: 0x060103D9 RID: 66521 RVA: 0x00475B1D File Offset: 0x00473D1D
	public override string event_id { get; set; } = "1043";

	// Token: 0x04007E5D RID: 32349
	public string s_sdk_pay_order = "";
}
