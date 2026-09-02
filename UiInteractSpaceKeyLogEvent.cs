using System;
using System.Runtime.CompilerServices;

// Token: 0x02002186 RID: 8582
[NullableContext(1)]
[Nullable(0)]
public class UiInteractSpaceKeyLogEvent : PlayerCommonLogData
{
	// Token: 0x170013DE RID: 5086
	// (get) Token: 0x0601048F RID: 66703 RVA: 0x004765BC File Offset: 0x004747BC
	// (set) Token: 0x06010490 RID: 66704 RVA: 0x004765C4 File Offset: 0x004747C4
	public override string event_id { get; set; } = "1806";

	// Token: 0x04007F4E RID: 32590
	public int i_type;

	// Token: 0x04007F4F RID: 32591
	public int i_status;
}
