using System;
using System.Runtime.CompilerServices;

// Token: 0x02002126 RID: 8486
[NullableContext(1)]
[Nullable(0)]
public class InstReactionLogRecord : ReactionLogRecord
{
	// Token: 0x06010374 RID: 66420 RVA: 0x00475260 File Offset: 0x00473460
	public InstReactionLogRecord(int inst_id, string fight_id)
	{
		this.i_inst_id = inst_id;
		this.s_fight_id = fight_id;
	}

	// Token: 0x17001382 RID: 4994
	// (get) Token: 0x06010375 RID: 66421 RVA: 0x0047528C File Offset: 0x0047348C
	// (set) Token: 0x06010376 RID: 66422 RVA: 0x00475294 File Offset: 0x00473494
	public override string event_id { get; set; } = "102807";

	// Token: 0x04007D47 RID: 32071
	public int i_inst_id;

	// Token: 0x04007D48 RID: 32072
	public string s_fight_id = "";
}
