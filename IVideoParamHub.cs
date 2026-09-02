using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;

// Token: 0x02002CE5 RID: 11493
[NullableContext(2)]
public interface IVideoParamHub
{
	// Token: 0x17001E88 RID: 7816
	// (get) Token: 0x0601729A RID: 94874
	// (set) Token: 0x0601729B RID: 94875
	VideoData VideoDataConf { get; set; }

	// Token: 0x17001E89 RID: 7817
	// (get) Token: 0x0601729C RID: 94876
	// (set) Token: 0x0601729D RID: 94877
	Action VideoCloseCb { get; set; }

	// Token: 0x17001E8A RID: 7818
	// (get) Token: 0x0601729E RID: 94878
	// (set) Token: 0x0601729F RID: 94879
	IMovieBackgroundFadeData BackgroundColor { get; set; }

	// Token: 0x17001E8B RID: 7819
	// (get) Token: 0x060172A0 RID: 94880
	// (set) Token: 0x060172A1 RID: 94881
	bool? RemainViewWhenEnd { get; set; }

	// Token: 0x17001E8C RID: 7820
	// (get) Token: 0x060172A2 RID: 94882
	// (set) Token: 0x060172A3 RID: 94883
	IProgramSpecialConfigBase ProgramSpecialConfig { get; set; }

	// Token: 0x17001E8D RID: 7821
	// (get) Token: 0x060172A4 RID: 94884
	// (set) Token: 0x060172A5 RID: 94885
	float? Mp4FadeOutTime { get; set; }

	// Token: 0x17001E8E RID: 7822
	// (get) Token: 0x060172A6 RID: 94886
	// (set) Token: 0x060172A7 RID: 94887
	float? BlackBorderFadeOutTime { get; set; }

	// Token: 0x17001E8F RID: 7823
	// (get) Token: 0x060172A8 RID: 94888
	// (set) Token: 0x060172A9 RID: 94889
	SetBlendAnim Mp4BlendAnim { get; set; }

	// Token: 0x17001E90 RID: 7824
	// (get) Token: 0x060172AA RID: 94890
	// (set) Token: 0x060172AB RID: 94891
	bool? SeamlessEndOnTick { get; set; }
}
