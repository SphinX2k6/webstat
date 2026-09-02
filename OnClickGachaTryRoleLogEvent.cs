using System;
using System.Runtime.CompilerServices;

// Token: 0x0200214E RID: 8526
[NullableContext(1)]
[Nullable(0)]
public class OnClickGachaTryRoleLogEvent : PlayerCommonLogData
{
	// Token: 0x170013A6 RID: 5030
	// (get) Token: 0x060103E7 RID: 66535 RVA: 0x00475BDF File Offset: 0x00473DDF
	// (set) Token: 0x060103E8 RID: 66536 RVA: 0x00475BE7 File Offset: 0x00473DE7
	public override string event_id { get; set; } = "1824";

	// Token: 0x04007E6A RID: 32362
	public int i_gacha_id;

	// Token: 0x04007E6B RID: 32363
	public int i_role_id;
}
