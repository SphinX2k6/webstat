using System;
using System.Runtime.CompilerServices;

// Token: 0x020021A5 RID: 8613
[NullableContext(1)]
[Nullable(0)]
public class OnJumpInShortMessageLogEvent : PlayerCommonLogData
{
	// Token: 0x170013FC RID: 5116
	// (get) Token: 0x060104EA RID: 66794 RVA: 0x00476AAC File Offset: 0x00474CAC
	// (set) Token: 0x060104EB RID: 66795 RVA: 0x00476AB4 File Offset: 0x00474CB4
	public override string event_id { get; set; } = "1817";

	// Token: 0x04007FD2 RID: 32722
	public int i_id;

	// Token: 0x04007FD3 RID: 32723
	public int i_type;

	// Token: 0x04007FD4 RID: 32724
	public int i_role_id;

	// Token: 0x04007FD5 RID: 32725
	public long l_received_time;

	// Token: 0x04007FD6 RID: 32726
	public int i_trigger_type;

	// Token: 0x04007FD7 RID: 32727
	public int i_config_id;
}
