using System;
using System.Runtime.CompilerServices;

// Token: 0x02002146 RID: 8518
[NullableContext(1)]
[Nullable(0)]
public class StartSdkPayEvent : PlayerCommonLogData
{
	// Token: 0x1700139E RID: 5022
	// (get) Token: 0x060103CF RID: 66511 RVA: 0x00475A72 File Offset: 0x00473C72
	// (set) Token: 0x060103D0 RID: 66512 RVA: 0x00475A7A File Offset: 0x00473C7A
	public override string event_id { get; set; } = "1040";

	// Token: 0x04007E55 RID: 32341
	public string s_sdk_pay_order = "";

	// Token: 0x04007E56 RID: 32342
	public string s_sdk_callback_url = "";
}
