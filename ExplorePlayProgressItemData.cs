using System;
using System.Runtime.CompilerServices;

// Token: 0x02001B75 RID: 7029
[NullableContext(2)]
[Nullable(0)]
public class ExplorePlayProgressItemData : IExplorePlayProgressItemData
{
	// Token: 0x17001065 RID: 4197
	// (get) Token: 0x0600CC18 RID: 52248 RVA: 0x003666BE File Offset: 0x003648BE
	// (set) Token: 0x0600CC19 RID: 52249 RVA: 0x003666C6 File Offset: 0x003648C6
	public EExploreType ExploreType { get; set; }

	// Token: 0x17001066 RID: 4198
	// (get) Token: 0x0600CC1A RID: 52250 RVA: 0x003666CF File Offset: 0x003648CF
	// (set) Token: 0x0600CC1B RID: 52251 RVA: 0x003666D7 File Offset: 0x003648D7
	public EPlayPointType PlayPointType { get; set; }

	// Token: 0x17001067 RID: 4199
	// (get) Token: 0x0600CC1C RID: 52252 RVA: 0x003666E0 File Offset: 0x003648E0
	// (set) Token: 0x0600CC1D RID: 52253 RVA: 0x003666E8 File Offset: 0x003648E8
	public EPlayPointState PlayPointState { get; set; }

	// Token: 0x17001068 RID: 4200
	// (get) Token: 0x0600CC1E RID: 52254 RVA: 0x003666F1 File Offset: 0x003648F1
	// (set) Token: 0x0600CC1F RID: 52255 RVA: 0x003666F9 File Offset: 0x003648F9
	public int? PlayPointId { get; set; }

	// Token: 0x17001069 RID: 4201
	// (get) Token: 0x0600CC20 RID: 52256 RVA: 0x00366702 File Offset: 0x00364902
	// (set) Token: 0x0600CC21 RID: 52257 RVA: 0x0036670A File Offset: 0x0036490A
	public EPlayPointState? LastPlayPointState { get; set; }

	// Token: 0x1700106A RID: 4202
	// (get) Token: 0x0600CC22 RID: 52258 RVA: 0x00366713 File Offset: 0x00364913
	// (set) Token: 0x0600CC23 RID: 52259 RVA: 0x0036671B File Offset: 0x0036491B
	public int? EntityId { get; set; }

	// Token: 0x1700106B RID: 4203
	// (get) Token: 0x0600CC24 RID: 52260 RVA: 0x00366724 File Offset: 0x00364924
	// (set) Token: 0x0600CC25 RID: 52261 RVA: 0x0036672C File Offset: 0x0036492C
	public bool? IgnoreHiddenType { get; set; }

	// Token: 0x1700106C RID: 4204
	// (get) Token: 0x0600CC26 RID: 52262 RVA: 0x00366735 File Offset: 0x00364935
	// (set) Token: 0x0600CC27 RID: 52263 RVA: 0x0036673D File Offset: 0x0036493D
	public bool? IsClear { get; set; }

	// Token: 0x1700106D RID: 4205
	// (get) Token: 0x0600CC28 RID: 52264 RVA: 0x00366746 File Offset: 0x00364946
	// (set) Token: 0x0600CC29 RID: 52265 RVA: 0x0036674E File Offset: 0x0036494E
	public string ClearInfo { get; set; }

	// Token: 0x1700106E RID: 4206
	// (get) Token: 0x0600CC2A RID: 52266 RVA: 0x00366757 File Offset: 0x00364957
	// (set) Token: 0x0600CC2B RID: 52267 RVA: 0x0036675F File Offset: 0x0036495F
	public bool? IsUnlock { get; set; }
}
