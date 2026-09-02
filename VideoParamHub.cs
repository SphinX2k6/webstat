using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;

// Token: 0x02002CE6 RID: 11494
[NullableContext(2)]
[Nullable(0)]
public class VideoParamHub : IVideoParamHub
{
	// Token: 0x17001E91 RID: 7825
	// (get) Token: 0x060172AC RID: 94892 RVA: 0x0066A7DA File Offset: 0x006689DA
	// (set) Token: 0x060172AD RID: 94893 RVA: 0x0066A7E2 File Offset: 0x006689E2
	public VideoData VideoDataConf { get; set; }

	// Token: 0x17001E92 RID: 7826
	// (get) Token: 0x060172AE RID: 94894 RVA: 0x0066A7EB File Offset: 0x006689EB
	// (set) Token: 0x060172AF RID: 94895 RVA: 0x0066A7F3 File Offset: 0x006689F3
	public Action VideoCloseCb { get; set; }

	// Token: 0x17001E93 RID: 7827
	// (get) Token: 0x060172B0 RID: 94896 RVA: 0x0066A7FC File Offset: 0x006689FC
	// (set) Token: 0x060172B1 RID: 94897 RVA: 0x0066A804 File Offset: 0x00668A04
	public IMovieBackgroundFadeData BackgroundColor { get; set; }

	// Token: 0x17001E94 RID: 7828
	// (get) Token: 0x060172B2 RID: 94898 RVA: 0x0066A80D File Offset: 0x00668A0D
	// (set) Token: 0x060172B3 RID: 94899 RVA: 0x0066A815 File Offset: 0x00668A15
	public bool? RemainViewWhenEnd { get; set; }

	// Token: 0x17001E95 RID: 7829
	// (get) Token: 0x060172B4 RID: 94900 RVA: 0x0066A81E File Offset: 0x00668A1E
	// (set) Token: 0x060172B5 RID: 94901 RVA: 0x0066A826 File Offset: 0x00668A26
	public IProgramSpecialConfigBase ProgramSpecialConfig { get; set; }

	// Token: 0x17001E96 RID: 7830
	// (get) Token: 0x060172B6 RID: 94902 RVA: 0x0066A82F File Offset: 0x00668A2F
	// (set) Token: 0x060172B7 RID: 94903 RVA: 0x0066A837 File Offset: 0x00668A37
	public float? Mp4FadeOutTime { get; set; }

	// Token: 0x17001E97 RID: 7831
	// (get) Token: 0x060172B8 RID: 94904 RVA: 0x0066A840 File Offset: 0x00668A40
	// (set) Token: 0x060172B9 RID: 94905 RVA: 0x0066A848 File Offset: 0x00668A48
	public float? BlackBorderFadeOutTime { get; set; }

	// Token: 0x17001E98 RID: 7832
	// (get) Token: 0x060172BA RID: 94906 RVA: 0x0066A851 File Offset: 0x00668A51
	// (set) Token: 0x060172BB RID: 94907 RVA: 0x0066A859 File Offset: 0x00668A59
	public SetBlendAnim Mp4BlendAnim { get; set; }

	// Token: 0x17001E99 RID: 7833
	// (get) Token: 0x060172BC RID: 94908 RVA: 0x0066A862 File Offset: 0x00668A62
	// (set) Token: 0x060172BD RID: 94909 RVA: 0x0066A86A File Offset: 0x00668A6A
	public bool? SeamlessEndOnTick { get; set; }
}
