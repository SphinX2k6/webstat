using System;
using System.Runtime.CompilerServices;

// Token: 0x0200211D RID: 8477
[NullableContext(1)]
[Nullable(0)]
public class MonsterSkillReportLog : PlayerCommonLogData
{
	// Token: 0x0601035B RID: 66395 RVA: 0x00474E90 File Offset: 0x00473090
	public MonsterSkillReportLog(int monsterId, string pbModelConfigId)
	{
		this.i_monster_id = monsterId;
		this.s_pb_model_config_id = pbModelConfigId;
	}

	// Token: 0x1700137B RID: 4987
	// (get) Token: 0x0601035C RID: 66396 RVA: 0x00474EDD File Offset: 0x004730DD
	// (set) Token: 0x0601035D RID: 66397 RVA: 0x00474EE5 File Offset: 0x004730E5
	public override string event_id { get; set; } = "102803";

	// Token: 0x04007D05 RID: 32005
	public string s_battle_id = "";

	// Token: 0x04007D06 RID: 32006
	public int i_monster_id;

	// Token: 0x04007D07 RID: 32007
	public int i_monster_level;

	// Token: 0x04007D08 RID: 32008
	public string s_pb_model_config_id = "";

	// Token: 0x04007D09 RID: 32009
	public string s_reports = "";
}
