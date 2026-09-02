using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.MapDefine;

// Token: 0x02002C10 RID: 11280
[NullableContext(2)]
public interface ITrackData
{
	// Token: 0x17001D7B RID: 7547
	// (get) Token: 0x060167FD RID: 92157
	// (set) Token: 0x060167FE RID: 92158
	ETrackSource TrackSource { get; set; }

	// Token: 0x17001D7C RID: 7548
	// (get) Token: 0x060167FF RID: 92159
	// (set) Token: 0x06016800 RID: 92160
	EMarkType? MarkType { get; set; }

	// Token: 0x17001D7D RID: 7549
	// (get) Token: 0x06016801 RID: 92161
	// (set) Token: 0x06016802 RID: 92162
	int Id { get; set; }

	// Token: 0x17001D7E RID: 7550
	// (get) Token: 0x06016803 RID: 92163
	// (set) Token: 0x06016804 RID: 92164
	[Nullable(1)]
	string IconPath { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x17001D7F RID: 7551
	// (get) Token: 0x06016805 RID: 92165
	// (set) Token: 0x06016806 RID: 92166
	TTrackTarget TrackTarget { get; set; }

	// Token: 0x17001D80 RID: 7552
	// (get) Token: 0x06016807 RID: 92167
	// (set) Token: 0x06016808 RID: 92168
	int? TrackInstanceId { get; set; }

	// Token: 0x17001D81 RID: 7553
	// (get) Token: 0x06016809 RID: 92169
	// (set) Token: 0x0601680A RID: 92170
	bool? TrackHudEnable { get; set; }

	// Token: 0x17001D82 RID: 7554
	// (get) Token: 0x0601680B RID: 92171
	// (set) Token: 0x0601680C RID: 92172
	float? TrackAutoCancelDistance { get; set; }

	// Token: 0x17001D83 RID: 7555
	// (get) Token: 0x0601680D RID: 92173
	// (set) Token: 0x0601680E RID: 92174
	bool? IsSubTrack { get; set; }

	// Token: 0x17001D84 RID: 7556
	// (get) Token: 0x0601680F RID: 92175
	// (set) Token: 0x06016810 RID: 92176
	float? TrackHideDis { get; set; }

	// Token: 0x17001D85 RID: 7557
	// (get) Token: 0x06016811 RID: 92177
	// (set) Token: 0x06016812 RID: 92178
	int? ShowGroupId { get; set; }

	// Token: 0x17001D86 RID: 7558
	// (get) Token: 0x06016813 RID: 92179
	// (set) Token: 0x06016814 RID: 92180
	ETrackType? TrackType { get; set; }

	// Token: 0x17001D87 RID: 7559
	// (get) Token: 0x06016815 RID: 92181
	// (set) Token: 0x06016816 RID: 92182
	bool? AutoHideTrack { get; set; }

	// Token: 0x17001D88 RID: 7560
	// (get) Token: 0x06016817 RID: 92183
	// (set) Token: 0x06016818 RID: 92184
	string PrefabPath { get; set; }

	// Token: 0x17001D89 RID: 7561
	// (get) Token: 0x06016819 RID: 92185
	// (set) Token: 0x0601681A RID: 92186
	Vector Offset { get; set; }

	// Token: 0x17001D8A RID: 7562
	// (get) Token: 0x0601681B RID: 92187
	// (set) Token: 0x0601681C RID: 92188
	bool? IsInTrackRange { get; set; }

	// Token: 0x17001D8B RID: 7563
	// (get) Token: 0x0601681D RID: 92189
	// (set) Token: 0x0601681E RID: 92190
	int? AreaId { get; set; }

	// Token: 0x17001D8C RID: 7564
	// (get) Token: 0x0601681F RID: 92191
	// (set) Token: 0x06016820 RID: 92192
	int? MultiMapId { get; set; }

	// Token: 0x17001D8D RID: 7565
	// (get) Token: 0x06016821 RID: 92193
	// (set) Token: 0x06016822 RID: 92194
	int? TaskMarkConfigId { get; set; }

	// Token: 0x17001D8E RID: 7566
	// (get) Token: 0x06016823 RID: 92195
	// (set) Token: 0x06016824 RID: 92196
	bool? WeakTrack { get; set; }
}
