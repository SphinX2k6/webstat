using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

// Token: 0x02002CE3 RID: 11491
[NullableContext(2)]
public interface IShowVideoCgConfig
{
	// Token: 0x17001E78 RID: 7800
	// (get) Token: 0x06017279 RID: 94841
	// (set) Token: 0x0601727A RID: 94842
	IMovieBackgroundFadeData BackgroundFade { get; set; }

	// Token: 0x17001E79 RID: 7801
	// (get) Token: 0x0601727B RID: 94843
	// (set) Token: 0x0601727C RID: 94844
	bool? RemainViewWhenEnd { get; set; }

	// Token: 0x17001E7A RID: 7802
	// (get) Token: 0x0601727D RID: 94845
	// (set) Token: 0x0601727E RID: 94846
	bool? InPlot { get; set; }

	// Token: 0x17001E7B RID: 7803
	// (get) Token: 0x0601727F RID: 94847
	// (set) Token: 0x06017280 RID: 94848
	IProgramSpecialConfigBase ProgramSpecialConfig { get; set; }

	// Token: 0x17001E7C RID: 7804
	// (get) Token: 0x06017281 RID: 94849
	// (set) Token: 0x06017282 RID: 94850
	float? Mp4FadeOutTime { get; set; }

	// Token: 0x17001E7D RID: 7805
	// (get) Token: 0x06017283 RID: 94851
	// (set) Token: 0x06017284 RID: 94852
	float? BlackBorderFadeOutTime { get; set; }

	// Token: 0x17001E7E RID: 7806
	// (get) Token: 0x06017285 RID: 94853
	// (set) Token: 0x06017286 RID: 94854
	SetBlendAnim Mp4BlendAnim { get; set; }

	// Token: 0x17001E7F RID: 7807
	// (get) Token: 0x06017287 RID: 94855
	// (set) Token: 0x06017288 RID: 94856
	bool? SeamlessEndOnTick { get; set; }
}
