using System;
using System.Runtime.CompilerServices;

// Token: 0x0200215B RID: 8539
[NullableContext(1)]
[Nullable(0)]
public class MailJumpLogEvent : PlayerCommonLogData
{
	// Token: 0x170013B3 RID: 5043
	// (get) Token: 0x0601040E RID: 66574 RVA: 0x00475DB3 File Offset: 0x00473FB3
	// (set) Token: 0x0601040F RID: 66575 RVA: 0x00475DBB File Offset: 0x00473FBB
	public override string event_id { get; set; } = "1934";

	// Token: 0x04007E91 RID: 32401
	public string s_mail_id = "";

	// Token: 0x04007E92 RID: 32402
	public int i_level;

	// Token: 0x04007E93 RID: 32403
	public long l_received_time;

	// Token: 0x04007E94 RID: 32404
	public int i_reason;

	// Token: 0x04007E95 RID: 32405
	public long l_take_time;
}
