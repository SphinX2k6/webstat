using System;

// Token: 0x02002CE9 RID: 11497
public class VideoSoundPlay
{
	// Token: 0x060172C9 RID: 94921 RVA: 0x0066AA48 File Offset: 0x00668C48
	public VideoSoundPlay(int handle, double endMomentMs)
	{
		this.Handle = handle;
		this.EndMomentMs = endMomentMs;
	}

	// Token: 0x0400B238 RID: 45624
	public int Handle;

	// Token: 0x0400B239 RID: 45625
	public double EndMomentMs;
}
