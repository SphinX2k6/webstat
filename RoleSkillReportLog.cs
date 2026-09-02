using System;
using System.Runtime.CompilerServices;

// Token: 0x0200211B RID: 8475
[NullableContext(1)]
[Nullable(0)]
public class RoleSkillReportLog : PlayerCommonLogData
{
	// Token: 0x1700137A RID: 4986
	// (get) Token: 0x06010357 RID: 66391 RVA: 0x00474E45 File Offset: 0x00473045
	// (set) Token: 0x06010358 RID: 66392 RVA: 0x00474E4D File Offset: 0x0047304D
	public override string event_id { get; set; } = "102702";

	// Token: 0x04007CF8 RID: 31992
	public string s_battle_id = "";

	// Token: 0x04007CF9 RID: 31993
	public int i_role_id;

	// Token: 0x04007CFA RID: 31994
	public int i_role_level;

	// Token: 0x04007CFB RID: 31995
	public int i_role_quality;

	// Token: 0x04007CFC RID: 31996
	public string s_reports = "";
}
