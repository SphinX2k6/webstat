using System;
using System.Runtime.CompilerServices;

// Token: 0x0200218A RID: 8586
[NullableContext(1)]
[Nullable(0)]
public class RoleDevelopSkillRecommendClickLogEvent : PlayerCommonLogData
{
	// Token: 0x170013E2 RID: 5090
	// (get) Token: 0x0601049B RID: 66715 RVA: 0x0047664C File Offset: 0x0047484C
	// (set) Token: 0x0601049C RID: 66716 RVA: 0x00476654 File Offset: 0x00474854
	public override string event_id { get; set; } = "1919";

	// Token: 0x04007F63 RID: 32611
	public int i_role_id;

	// Token: 0x04007F64 RID: 32612
	public int i_operation;
}
