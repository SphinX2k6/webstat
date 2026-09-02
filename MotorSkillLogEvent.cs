using System;
using System.Runtime.CompilerServices;

// Token: 0x0200217D RID: 8573
[NullableContext(1)]
[Nullable(0)]
public class MotorSkillLogEvent : PlayerCommonLogData
{
	// Token: 0x170013D5 RID: 5077
	// (get) Token: 0x06010474 RID: 66676 RVA: 0x0047646D File Offset: 0x0047466D
	// (set) Token: 0x06010475 RID: 66677 RVA: 0x00476475 File Offset: 0x00474675
	public override string event_id { get; set; } = "2000";

	// Token: 0x04007F35 RID: 32565
	public string i_skill_id = "";
}
