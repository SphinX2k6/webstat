using System;
using System.Runtime.CompilerServices;

// Token: 0x02002123 RID: 8483
[NullableContext(1)]
[Nullable(0)]
public class InstRoleStateRecord : RoleStateRecord
{
	// Token: 0x0601036B RID: 66411 RVA: 0x004751A5 File Offset: 0x004733A5
	public InstRoleStateRecord(int roleId, int inst_id, string fight_id) : base(roleId)
	{
		this.i_inst_id = inst_id;
		this.s_fight_id = fight_id;
	}

	// Token: 0x1700137F RID: 4991
	// (get) Token: 0x0601036C RID: 66412 RVA: 0x004751D2 File Offset: 0x004733D2
	// (set) Token: 0x0601036D RID: 66413 RVA: 0x004751DA File Offset: 0x004733DA
	public override string event_id { get; set; } = "102804";

	// Token: 0x04007D3E RID: 32062
	public int i_inst_id;

	// Token: 0x04007D3F RID: 32063
	public string s_fight_id = "";
}
