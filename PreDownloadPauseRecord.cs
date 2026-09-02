using System;
using System.Runtime.CompilerServices;

// Token: 0x02002162 RID: 8546
[NullableContext(1)]
[Nullable(0)]
public class PreDownloadPauseRecord : PlayerCommonLogData
{
	// Token: 0x170013BA RID: 5050
	// (get) Token: 0x06010423 RID: 66595 RVA: 0x00475ED3 File Offset: 0x004740D3
	// (set) Token: 0x06010424 RID: 66596 RVA: 0x00475EDB File Offset: 0x004740DB
	public override string event_id { get; set; } = "1056";

	// Token: 0x06010425 RID: 66597 RVA: 0x00475EE4 File Offset: 0x004740E4
	public PreDownloadPauseRecord(int Id)
	{
		this.i_pause_reason = Id;
	}

	// Token: 0x04007EAC RID: 32428
	public int i_pause_reason;
}
