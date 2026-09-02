using System;
using System.Runtime.CompilerServices;

// Token: 0x02002161 RID: 8545
[NullableContext(1)]
[Nullable(0)]
public class PreDownloadDownloadModeSwitchRecord : PlayerCommonLogData
{
	// Token: 0x170013B9 RID: 5049
	// (get) Token: 0x06010420 RID: 66592 RVA: 0x00475EA8 File Offset: 0x004740A8
	// (set) Token: 0x06010421 RID: 66593 RVA: 0x00475EB0 File Offset: 0x004740B0
	public override string event_id { get; set; } = "1055";

	// Token: 0x06010422 RID: 66594 RVA: 0x00475EB9 File Offset: 0x004740B9
	public PreDownloadDownloadModeSwitchRecord(int Id)
	{
		this.i_download_mode = Id;
	}

	// Token: 0x04007EAA RID: 32426
	public int i_download_mode;
}
