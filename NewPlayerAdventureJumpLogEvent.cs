using System;
using System.Runtime.CompilerServices;

// Token: 0x02002181 RID: 8577
[NullableContext(1)]
[Nullable(0)]
public class NewPlayerAdventureJumpLogEvent : PlayerCommonLogData
{
	// Token: 0x170013D9 RID: 5081
	// (get) Token: 0x06010480 RID: 66688 RVA: 0x00476508 File Offset: 0x00474708
	// (set) Token: 0x06010481 RID: 66689 RVA: 0x00476510 File Offset: 0x00474710
	public override string event_id { get; set; } = "2004";

	// Token: 0x04007F41 RID: 32577
	public int i_roleid_id;

	// Token: 0x04007F42 RID: 32578
	public int i_inst_type;

	// Token: 0x04007F43 RID: 32579
	public int i_inst_id;

	// Token: 0x04007F44 RID: 32580
	public int i_time_left;
}
