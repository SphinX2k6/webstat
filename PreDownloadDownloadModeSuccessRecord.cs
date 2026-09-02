using System;
using System.Runtime.CompilerServices;

// Token: 0x02002163 RID: 8547
[NullableContext(1)]
[Nullable(0)]
public class PreDownloadDownloadModeSuccessRecord : PlayerCommonLogData
{
	// Token: 0x170013BB RID: 5051
	// (get) Token: 0x06010426 RID: 66598 RVA: 0x00475EFE File Offset: 0x004740FE
	// (set) Token: 0x06010427 RID: 66599 RVA: 0x00475F06 File Offset: 0x00474106
	public override string event_id { get; set; } = "1057";

	// Token: 0x06010428 RID: 66600 RVA: 0x00475F0F File Offset: 0x0047410F
	public PreDownloadDownloadModeSuccessRecord(int Id)
	{
		this.i_download_mode = Id;
	}

	// Token: 0x04007EAE RID: 32430
	public int i_download_mode;
}
