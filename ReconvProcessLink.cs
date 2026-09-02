using System;
using System.Runtime.CompilerServices;

// Token: 0x0200212C RID: 8492
[NullableContext(1)]
[Nullable(0)]
public class ReconvProcessLink : CommonLogData
{
	// Token: 0x17001388 RID: 5000
	// (get) Token: 0x06010386 RID: 66438 RVA: 0x004754E8 File Offset: 0x004736E8
	// (set) Token: 0x06010387 RID: 66439 RVA: 0x004754F0 File Offset: 0x004736F0
	public override string event_id { get; set; } = "18001";

	// Token: 0x04007D7C RID: 32124
	public string s_trace_id = "";

	// Token: 0x04007D7D RID: 32125
	public string s_player_id = "";

	// Token: 0x04007D7E RID: 32126
	public string s_user_id = "";

	// Token: 0x04007D7F RID: 32127
	public string s_user_name = "";

	// Token: 0x04007D80 RID: 32128
	public string s_reconv_step = "";

	// Token: 0x04007D81 RID: 32129
	public string s_app_version = "";

	// Token: 0x04007D82 RID: 32130
	public string s_launcher_version = "";

	// Token: 0x04007D83 RID: 32131
	public string s_resource_version = "";

	// Token: 0x04007D84 RID: 32132
	public string s_client_version = "";

	// Token: 0x04007D85 RID: 32133
	public int i_error_code;
}
