using System;
using System.Runtime.CompilerServices;

// Token: 0x02002189 RID: 8585
[NullableContext(1)]
[Nullable(0)]
public class RoleDevLogEvent : PlayerCommonLogData
{
	// Token: 0x170013E1 RID: 5089
	// (get) Token: 0x06010498 RID: 66712 RVA: 0x00476628 File Offset: 0x00474828
	// (set) Token: 0x06010499 RID: 66713 RVA: 0x00476630 File Offset: 0x00474830
	public override string event_id { get; set; } = "1807";

	// Token: 0x04007F5D RID: 32605
	public int i_role_id;

	// Token: 0x04007F5E RID: 32606
	public int i_role_type;

	// Token: 0x04007F5F RID: 32607
	public int i_main_page;

	// Token: 0x04007F60 RID: 32608
	public int i_sub_page;

	// Token: 0x04007F61 RID: 32609
	public int i_type;
}
