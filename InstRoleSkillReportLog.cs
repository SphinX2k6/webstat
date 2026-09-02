using System;
using System.Runtime.CompilerServices;

// Token: 0x02002125 RID: 8485
[NullableContext(1)]
[Nullable(0)]
public class InstRoleSkillReportLog : RoleSkillReportLog
{
	// Token: 0x06010371 RID: 66417 RVA: 0x00475223 File Offset: 0x00473423
	public InstRoleSkillReportLog(int inst_id, string fight_id)
	{
		this.i_inst_id = inst_id;
		this.s_fight_id = fight_id;
	}

	// Token: 0x17001381 RID: 4993
	// (get) Token: 0x06010372 RID: 66418 RVA: 0x0047524F File Offset: 0x0047344F
	// (set) Token: 0x06010373 RID: 66419 RVA: 0x00475257 File Offset: 0x00473457
	public override string event_id { get; set; } = "102806";

	// Token: 0x04007D44 RID: 32068
	public int i_inst_id;

	// Token: 0x04007D45 RID: 32069
	public string s_fight_id = "";
}
