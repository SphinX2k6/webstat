using System;
using System.Runtime.CompilerServices;

// Token: 0x02002148 RID: 8520
[NullableContext(1)]
[Nullable(0)]
public class FailSdkPayEvent : PlayerCommonLogData
{
	// Token: 0x170013A0 RID: 5024
	// (get) Token: 0x060103D5 RID: 66517 RVA: 0x00475ADB File Offset: 0x00473CDB
	// (set) Token: 0x060103D6 RID: 66518 RVA: 0x00475AE3 File Offset: 0x00473CE3
	public override string event_id { get; set; } = "1042";

	// Token: 0x04007E5A RID: 32346
	public string s_sdk_pay_order = "";

	// Token: 0x04007E5B RID: 32347
	public string s_reason = "";
}
