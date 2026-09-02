using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

// Token: 0x02002CE4 RID: 11492
[NullableContext(2)]
[Nullable(0)]
public class ShowVideoCgConfig : IShowVideoCgConfig
{
	// Token: 0x17001E80 RID: 7808
	// (get) Token: 0x06017289 RID: 94857 RVA: 0x0066A74A File Offset: 0x0066894A
	// (set) Token: 0x0601728A RID: 94858 RVA: 0x0066A752 File Offset: 0x00668952
	public IMovieBackgroundFadeData BackgroundFade { get; set; }

	// Token: 0x17001E81 RID: 7809
	// (get) Token: 0x0601728B RID: 94859 RVA: 0x0066A75B File Offset: 0x0066895B
	// (set) Token: 0x0601728C RID: 94860 RVA: 0x0066A763 File Offset: 0x00668963
	public bool? RemainViewWhenEnd { get; set; }

	// Token: 0x17001E82 RID: 7810
	// (get) Token: 0x0601728D RID: 94861 RVA: 0x0066A76C File Offset: 0x0066896C
	// (set) Token: 0x0601728E RID: 94862 RVA: 0x0066A774 File Offset: 0x00668974
	public bool? InPlot { get; set; }

	// Token: 0x17001E83 RID: 7811
	// (get) Token: 0x0601728F RID: 94863 RVA: 0x0066A77D File Offset: 0x0066897D
	// (set) Token: 0x06017290 RID: 94864 RVA: 0x0066A785 File Offset: 0x00668985
	public IProgramSpecialConfigBase ProgramSpecialConfig { get; set; }

	// Token: 0x17001E84 RID: 7812
	// (get) Token: 0x06017291 RID: 94865 RVA: 0x0066A78E File Offset: 0x0066898E
	// (set) Token: 0x06017292 RID: 94866 RVA: 0x0066A796 File Offset: 0x00668996
	public float? Mp4FadeOutTime { get; set; }

	// Token: 0x17001E85 RID: 7813
	// (get) Token: 0x06017293 RID: 94867 RVA: 0x0066A79F File Offset: 0x0066899F
	// (set) Token: 0x06017294 RID: 94868 RVA: 0x0066A7A7 File Offset: 0x006689A7
	public float? BlackBorderFadeOutTime { get; set; }

	// Token: 0x17001E86 RID: 7814
	// (get) Token: 0x06017295 RID: 94869 RVA: 0x0066A7B0 File Offset: 0x006689B0
	// (set) Token: 0x06017296 RID: 94870 RVA: 0x0066A7B8 File Offset: 0x006689B8
	public SetBlendAnim Mp4BlendAnim { get; set; }

	// Token: 0x17001E87 RID: 7815
	// (get) Token: 0x06017297 RID: 94871 RVA: 0x0066A7C1 File Offset: 0x006689C1
	// (set) Token: 0x06017298 RID: 94872 RVA: 0x0066A7C9 File Offset: 0x006689C9
	public bool? SeamlessEndOnTick { get; set; }
}
