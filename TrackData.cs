using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.MapDefine;

// Token: 0x02002C11 RID: 11281
[NullableContext(2)]
[Nullable(0)]
public class TrackData : ITrackData
{
	// Token: 0x17001D8F RID: 7567
	// (get) Token: 0x06016825 RID: 92197 RVA: 0x00641A07 File Offset: 0x0063FC07
	// (set) Token: 0x06016826 RID: 92198 RVA: 0x00641A0F File Offset: 0x0063FC0F
	public ETrackSource TrackSource { get; set; }

	// Token: 0x17001D90 RID: 7568
	// (get) Token: 0x06016827 RID: 92199 RVA: 0x00641A18 File Offset: 0x0063FC18
	// (set) Token: 0x06016828 RID: 92200 RVA: 0x00641A20 File Offset: 0x0063FC20
	public EMarkType? MarkType { get; set; }

	// Token: 0x17001D91 RID: 7569
	// (get) Token: 0x06016829 RID: 92201 RVA: 0x00641A29 File Offset: 0x0063FC29
	// (set) Token: 0x0601682A RID: 92202 RVA: 0x00641A31 File Offset: 0x0063FC31
	public int Id { get; set; }

	// Token: 0x17001D92 RID: 7570
	// (get) Token: 0x0601682B RID: 92203 RVA: 0x00641A3A File Offset: 0x0063FC3A
	// (set) Token: 0x0601682C RID: 92204 RVA: 0x00641A42 File Offset: 0x0063FC42
	[Nullable(1)]
	public string IconPath { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x17001D93 RID: 7571
	// (get) Token: 0x0601682D RID: 92205 RVA: 0x00641A4B File Offset: 0x0063FC4B
	// (set) Token: 0x0601682E RID: 92206 RVA: 0x00641A53 File Offset: 0x0063FC53
	public TTrackTarget TrackTarget { get; set; }

	// Token: 0x17001D94 RID: 7572
	// (get) Token: 0x0601682F RID: 92207 RVA: 0x00641A5C File Offset: 0x0063FC5C
	// (set) Token: 0x06016830 RID: 92208 RVA: 0x00641A64 File Offset: 0x0063FC64
	public int? TrackInstanceId { get; set; }

	// Token: 0x17001D95 RID: 7573
	// (get) Token: 0x06016831 RID: 92209 RVA: 0x00641A6D File Offset: 0x0063FC6D
	// (set) Token: 0x06016832 RID: 92210 RVA: 0x00641A75 File Offset: 0x0063FC75
	public bool? TrackHudEnable { get; set; }

	// Token: 0x17001D96 RID: 7574
	// (get) Token: 0x06016833 RID: 92211 RVA: 0x00641A7E File Offset: 0x0063FC7E
	// (set) Token: 0x06016834 RID: 92212 RVA: 0x00641A86 File Offset: 0x0063FC86
	public float? TrackAutoCancelDistance { get; set; }

	// Token: 0x17001D97 RID: 7575
	// (get) Token: 0x06016835 RID: 92213 RVA: 0x00641A8F File Offset: 0x0063FC8F
	// (set) Token: 0x06016836 RID: 92214 RVA: 0x00641A97 File Offset: 0x0063FC97
	public bool? IsSubTrack { get; set; }

	// Token: 0x17001D98 RID: 7576
	// (get) Token: 0x06016837 RID: 92215 RVA: 0x00641AA0 File Offset: 0x0063FCA0
	// (set) Token: 0x06016838 RID: 92216 RVA: 0x00641AA8 File Offset: 0x0063FCA8
	public float? TrackHideDis { get; set; }

	// Token: 0x17001D99 RID: 7577
	// (get) Token: 0x06016839 RID: 92217 RVA: 0x00641AB1 File Offset: 0x0063FCB1
	// (set) Token: 0x0601683A RID: 92218 RVA: 0x00641AB9 File Offset: 0x0063FCB9
	public int? ShowGroupId { get; set; }

	// Token: 0x17001D9A RID: 7578
	// (get) Token: 0x0601683B RID: 92219 RVA: 0x00641AC2 File Offset: 0x0063FCC2
	// (set) Token: 0x0601683C RID: 92220 RVA: 0x00641ACA File Offset: 0x0063FCCA
	public ETrackType? TrackType { get; set; }

	// Token: 0x17001D9B RID: 7579
	// (get) Token: 0x0601683D RID: 92221 RVA: 0x00641AD3 File Offset: 0x0063FCD3
	// (set) Token: 0x0601683E RID: 92222 RVA: 0x00641ADB File Offset: 0x0063FCDB
	public bool? AutoHideTrack { get; set; }

	// Token: 0x17001D9C RID: 7580
	// (get) Token: 0x0601683F RID: 92223 RVA: 0x00641AE4 File Offset: 0x0063FCE4
	// (set) Token: 0x06016840 RID: 92224 RVA: 0x00641AEC File Offset: 0x0063FCEC
	public string PrefabPath { get; set; }

	// Token: 0x17001D9D RID: 7581
	// (get) Token: 0x06016841 RID: 92225 RVA: 0x00641AF5 File Offset: 0x0063FCF5
	// (set) Token: 0x06016842 RID: 92226 RVA: 0x00641AFD File Offset: 0x0063FCFD
	public Vector Offset { get; set; }

	// Token: 0x17001D9E RID: 7582
	// (get) Token: 0x06016843 RID: 92227 RVA: 0x00641B06 File Offset: 0x0063FD06
	// (set) Token: 0x06016844 RID: 92228 RVA: 0x00641B0E File Offset: 0x0063FD0E
	public bool? IsInTrackRange { get; set; }

	// Token: 0x17001D9F RID: 7583
	// (get) Token: 0x06016845 RID: 92229 RVA: 0x00641B17 File Offset: 0x0063FD17
	// (set) Token: 0x06016846 RID: 92230 RVA: 0x00641B1F File Offset: 0x0063FD1F
	public int? AreaId { get; set; }

	// Token: 0x17001DA0 RID: 7584
	// (get) Token: 0x06016847 RID: 92231 RVA: 0x00641B28 File Offset: 0x0063FD28
	// (set) Token: 0x06016848 RID: 92232 RVA: 0x00641B30 File Offset: 0x0063FD30
	public int? MultiMapId { get; set; }

	// Token: 0x17001DA1 RID: 7585
	// (get) Token: 0x06016849 RID: 92233 RVA: 0x00641B39 File Offset: 0x0063FD39
	// (set) Token: 0x0601684A RID: 92234 RVA: 0x00641B41 File Offset: 0x0063FD41
	public int? TaskMarkConfigId { get; set; }

	// Token: 0x17001DA2 RID: 7586
	// (get) Token: 0x0601684B RID: 92235 RVA: 0x00641B4A File Offset: 0x0063FD4A
	// (set) Token: 0x0601684C RID: 92236 RVA: 0x00641B52 File Offset: 0x0063FD52
	public bool? WeakTrack { get; set; }
}
