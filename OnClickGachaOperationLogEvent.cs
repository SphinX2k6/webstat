using System;
using System.Runtime.CompilerServices;

// Token: 0x0200214D RID: 8525
[NullableContext(1)]
[Nullable(0)]
public class OnClickGachaOperationLogEvent : PlayerCommonLogData
{
	// Token: 0x170013A5 RID: 5029
	// (get) Token: 0x060103E4 RID: 66532 RVA: 0x00475BBB File Offset: 0x00473DBB
	// (set) Token: 0x060103E5 RID: 66533 RVA: 0x00475BC3 File Offset: 0x00473DC3
	public override string event_id { get; set; } = "1823";

	// Token: 0x04007E67 RID: 32359
	public int i_gacha_id;

	// Token: 0x04007E68 RID: 32360
	public int i_operation_type;
}
