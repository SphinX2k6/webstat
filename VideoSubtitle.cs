using System;
using System.Runtime.CompilerServices;

// Token: 0x02002CDF RID: 11487
[NullableContext(1)]
[Nullable(0)]
public class VideoSubtitle
{
	// Token: 0x0601726D RID: 94829 RVA: 0x0066A1D1 File Offset: 0x006683D1
	public VideoSubtitle(int showMoment, int duration, string captionText, int captionId, bool isPlaySubtitleVoice)
	{
		this.ShowMoment = showMoment;
		this.Duration = duration;
		this.CaptionText = captionText;
		this.CaptionId = captionId;
		this.IsPlaySubtitleVoice = isPlaySubtitleVoice;
	}

	// Token: 0x0400B210 RID: 45584
	public int ShowMoment;

	// Token: 0x0400B211 RID: 45585
	public int Duration;

	// Token: 0x0400B212 RID: 45586
	public string CaptionText;

	// Token: 0x0400B213 RID: 45587
	public int CaptionId;

	// Token: 0x0400B214 RID: 45588
	public bool IsPlaySubtitleVoice;
}
