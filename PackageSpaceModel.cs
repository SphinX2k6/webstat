using System;

// Token: 0x020034E0 RID: 13536
public class PackageSpaceModel
{
	// Token: 0x0601C980 RID: 117120 RVA: 0x0089215C File Offset: 0x0089035C
	public void Reset()
	{
		this.DownloadSize = 0L;
		this.SavedSize = 0L;
		this.PatchPeak = 0L;
		this.PatchNetDelta = 0L;
		this.CopySize = 0L;
	}

	// Token: 0x0400E64D RID: 58957
	public long DownloadSize;

	// Token: 0x0400E64E RID: 58958
	public long SavedSize;

	// Token: 0x0400E64F RID: 58959
	public long PatchPeak;

	// Token: 0x0400E650 RID: 58960
	public long PatchNetDelta;

	// Token: 0x0400E651 RID: 58961
	public long CopySize;
}
