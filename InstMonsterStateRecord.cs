using System;
using System.Runtime.CompilerServices;

// Token: 0x02002124 RID: 8484
[NullableContext(1)]
[Nullable(0)]
public class InstMonsterStateRecord : MonsterStateRecord
{
	// Token: 0x0601036E RID: 66414 RVA: 0x004751E3 File Offset: 0x004733E3
	public InstMonsterStateRecord(int monsterId, string pbModelConfigId, int inst_id, string fight_id) : base(monsterId, pbModelConfigId)
	{
		this.i_inst_id = inst_id;
		this.s_fight_id = fight_id;
	}

	// Token: 0x17001380 RID: 4992
	// (get) Token: 0x0601036F RID: 66415 RVA: 0x00475212 File Offset: 0x00473412
	// (set) Token: 0x06010370 RID: 66416 RVA: 0x0047521A File Offset: 0x0047341A
	public override string event_id { get; set; } = "102805";

	// Token: 0x04007D41 RID: 32065
	public int i_inst_id;

	// Token: 0x04007D42 RID: 32066
	public string s_fight_id = "";
}
