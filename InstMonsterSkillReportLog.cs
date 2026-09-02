using System;
using System.Runtime.CompilerServices;

// Token: 0x02002127 RID: 8487
[NullableContext(1)]
[Nullable(0)]
public class InstMonsterSkillReportLog : MonsterSkillReportLog
{
	// Token: 0x06010377 RID: 66423 RVA: 0x0047529D File Offset: 0x0047349D
	public InstMonsterSkillReportLog(int monsterId, string pbModelConfigId, int inst_id, string fight_id) : base(monsterId, pbModelConfigId)
	{
		this.i_inst_id = inst_id;
		this.s_fight_id = fight_id;
	}

	// Token: 0x17001383 RID: 4995
	// (get) Token: 0x06010378 RID: 66424 RVA: 0x004752CC File Offset: 0x004734CC
	// (set) Token: 0x06010379 RID: 66425 RVA: 0x004752D4 File Offset: 0x004734D4
	public override string event_id { get; set; } = "102808";

	// Token: 0x04007D4A RID: 32074
	public int i_inst_id;

	// Token: 0x04007D4B RID: 32075
	public string s_fight_id = "";
}
