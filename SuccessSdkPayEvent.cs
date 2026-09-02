using System;
using System.Runtime.CompilerServices;

// Token: 0x02002147 RID: 8519
[NullableContext(1)]
[Nullable(0)]
public class SuccessSdkPayEvent : PlayerCommonLogData
{
	// Token: 0x1700139F RID: 5023
	// (get) Token: 0x060103D2 RID: 66514 RVA: 0x00475AAC File Offset: 0x00473CAC
	// (set) Token: 0x060103D3 RID: 66515 RVA: 0x00475AB4 File Offset: 0x00473CB4
	public override string event_id { get; set; } = "1041";

	// Token: 0x04007E58 RID: 32344
	public string s_sdk_pay_order = "";
}
