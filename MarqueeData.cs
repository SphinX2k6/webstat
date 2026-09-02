using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;

// Token: 0x02002258 RID: 8792
[NullableContext(1)]
[Nullable(0)]
public class MarqueeData
{
	// Token: 0x06010954 RID: 67924 RVA: 0x004889DC File Offset: 0x00486BDC
	public void RefreshContent()
	{
		if (this.Contents != null)
		{
			MarqueeContent marqueeContent = null;
			foreach (MarqueeContent marqueeContent2 in this.Contents)
			{
				if (marqueeContent2.language == Singleton<LanguageSystem>.Instance.PackageLanguage)
				{
					marqueeContent = marqueeContent2;
					break;
				}
			}
			if (marqueeContent != null)
			{
				this.Content = marqueeContent.content;
			}
			if (string.IsNullOrEmpty(this.Content))
			{
				if (this.Contents != null && this.Contents.Count > 0)
				{
					this.Content = this.Contents[0].content;
					return;
				}
				this.Content = "";
			}
		}
	}

	// Token: 0x06010955 RID: 67925 RVA: 0x00488AA8 File Offset: 0x00486CA8
	public void Phrase(MarqueeDataEx data)
	{
		this.Id = data.id.ToString();
		this.EndTime = data.endTimeMs / 1000.0;
		this.BeginTime = data.startTimeMs / 1000.0;
		this.WhiteLists = data.whiteList;
		this.ScrollInterval = data.timeInterval;
		this.ScrollTimes = data.times;
		this.Contents = data.contents;
		this.RefreshContent();
		this.Platform = data.platform;
		this.Channel = data.channel;
	}

	// Token: 0x06010956 RID: 67926 RVA: 0x00488B40 File Offset: 0x00486D40
	public bool CheckPlatformAndChannelIfShow()
	{
		string item = "";
		if (ControllerBase<KuroSdkController>.Instance.CanUseSdk())
		{
			item = ControllerBase<KuroSdkController>.Instance.GetChannelId();
		}
		if (this.Channel != null && this.Channel.Count > 0 && !this.Channel.Contains(item))
		{
			return false;
		}
		int item2 = 1;
		if (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.Android)
		{
			item2 = 2;
		}
		else if (Singleton<Info>.Instance.PlatformType == ESourcePlatformType.IOS)
		{
			item2 = 3;
		}
		return this.Platform == null || this.Platform.Count <= 0 || this.Platform.Contains(item2);
	}

	// Token: 0x04008285 RID: 33413
	public string Id = "";

	// Token: 0x04008286 RID: 33414
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<string> WhiteLists;

	// Token: 0x04008287 RID: 33415
	public double ModifyTime;

	// Token: 0x04008288 RID: 33416
	[Nullable(2)]
	public string Content = "";

	// Token: 0x04008289 RID: 33417
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<MarqueeContent> Contents;

	// Token: 0x0400828A RID: 33418
	public double BeginTime;

	// Token: 0x0400828B RID: 33419
	public double EndTime;

	// Token: 0x0400828C RID: 33420
	public int ScrollInterval;

	// Token: 0x0400828D RID: 33421
	public int ScrollTimes;

	// Token: 0x0400828E RID: 33422
	public int ShowInFight;

	// Token: 0x0400828F RID: 33423
	public int ShowInPhotograph;

	// Token: 0x04008290 RID: 33424
	[Nullable(2)]
	public List<int> Platform;

	// Token: 0x04008291 RID: 33425
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<string> Channel;

	// Token: 0x04008292 RID: 33426
	public bool IsClientMarquee;

	// Token: 0x04008293 RID: 33427
	public string LocalTextKey = "";

	// Token: 0x04008294 RID: 33428
	public bool UseLocalTextKey;

	// Token: 0x04008295 RID: 33429
	private const int MARQUEEPLATFORMPC = 1;

	// Token: 0x04008296 RID: 33430
	private const int MARQUEEPLATFORMIOS = 2;

	// Token: 0x04008297 RID: 33431
	private const int MARQUEEPLATFORMANDROID = 3;
}
