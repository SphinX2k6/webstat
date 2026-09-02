using System;
using System.Runtime.CompilerServices;

// Token: 0x02001B5C RID: 7004
[NullableContext(1)]
[Nullable(0)]
public class MessageDecodeData : CommonLogData
{
	// Token: 0x17001041 RID: 4161
	// (get) Token: 0x0600CACC RID: 51916 RVA: 0x00361026 File Offset: 0x0035F226
	// (set) Token: 0x0600CACD RID: 51917 RVA: 0x0036102E File Offset: 0x0035F22E
	public override string event_id { get; set; } = "1022";

	// Token: 0x04006105 RID: 24837
	public uint i_kcp_conv;

	// Token: 0x04006106 RID: 24838
	public int i_seq_no;

	// Token: 0x04006107 RID: 24839
	public int i_message_id;

	// Token: 0x04006108 RID: 24840
	public int i_crc;

	// Token: 0x04006109 RID: 24841
	public int i_error_code;

	// Token: 0x0400610A RID: 24842
	public string s_channel_id = string.Empty;

	// Token: 0x0400610B RID: 24843
	public string s_client_ip = string.Empty;

	// Token: 0x0400610C RID: 24844
	public string s_before_hexdump = string.Empty;

	// Token: 0x0400610D RID: 24845
	public string s_after_hexdump = string.Empty;
}
