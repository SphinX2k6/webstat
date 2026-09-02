using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058C3 RID: 22723
	[NullableContext(1)]
	[Nullable(0)]
	public class FishingPointMarkCreateParam : IDynamicMarkCreateParams
	{
		// Token: 0x1700933D RID: 37693
		// (get) Token: 0x06039B10 RID: 236304 RVA: 0x00EA00C1 File Offset: 0x00E9E2C1
		// (set) Token: 0x06039B11 RID: 236305 RVA: 0x00EA00C9 File Offset: 0x00E9E2C9
		public TTrackTarget TrackTarget { get; set; }

		// Token: 0x1700933E RID: 37694
		// (get) Token: 0x06039B12 RID: 236306 RVA: 0x00EA00D2 File Offset: 0x00E9E2D2
		// (set) Token: 0x06039B13 RID: 236307 RVA: 0x00EA00DA File Offset: 0x00E9E2DA
		public int MarkConfigId { get; set; }

		// Token: 0x1700933F RID: 37695
		// (get) Token: 0x06039B14 RID: 236308 RVA: 0x00EA00E3 File Offset: 0x00E9E2E3
		// (set) Token: 0x06039B15 RID: 236309 RVA: 0x00EA00EB File Offset: 0x00E9E2EB
		public EMarkType MarkType { get; set; }

		// Token: 0x17009340 RID: 37696
		// (get) Token: 0x06039B16 RID: 236310 RVA: 0x00EA00F4 File Offset: 0x00E9E2F4
		// (set) Token: 0x06039B17 RID: 236311 RVA: 0x00EA00FC File Offset: 0x00E9E2FC
		public int? MarkId { get; set; }

		// Token: 0x17009341 RID: 37697
		// (get) Token: 0x06039B18 RID: 236312 RVA: 0x00EA0105 File Offset: 0x00E9E305
		// (set) Token: 0x06039B19 RID: 236313 RVA: 0x00EA010D File Offset: 0x00E9E30D
		public ETrackSource? TrackSource { get; set; }

		// Token: 0x17009342 RID: 37698
		// (get) Token: 0x06039B1A RID: 236314 RVA: 0x00EA0116 File Offset: 0x00E9E316
		// (set) Token: 0x06039B1B RID: 236315 RVA: 0x00EA011E File Offset: 0x00E9E31E
		public bool? DestroyOnUnTrack { get; set; }

		// Token: 0x17009343 RID: 37699
		// (get) Token: 0x06039B1C RID: 236316 RVA: 0x00EA0127 File Offset: 0x00E9E327
		// (set) Token: 0x06039B1D RID: 236317 RVA: 0x00EA012F File Offset: 0x00E9E32F
		public int? TeleportId { get; set; }

		// Token: 0x17009344 RID: 37700
		// (get) Token: 0x06039B1E RID: 236318 RVA: 0x00EA0138 File Offset: 0x00E9E338
		// (set) Token: 0x06039B1F RID: 236319 RVA: 0x00EA0140 File Offset: 0x00E9E340
		public int? EntityConfigId { get; set; }

		// Token: 0x17009345 RID: 37701
		// (get) Token: 0x06039B20 RID: 236320 RVA: 0x00EA0149 File Offset: 0x00E9E349
		// (set) Token: 0x06039B21 RID: 236321 RVA: 0x00EA0151 File Offset: 0x00E9E351
		public MarkState? ServerMarkState { get; set; }

		// Token: 0x17009346 RID: 37702
		// (get) Token: 0x06039B22 RID: 236322 RVA: 0x00EA015A File Offset: 0x00E9E35A
		// (set) Token: 0x06039B23 RID: 236323 RVA: 0x00EA0162 File Offset: 0x00E9E362
		[Nullable(2)]
		public MapAndDungeonInfo MapAndDungeonInfo { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17009347 RID: 37703
		// (get) Token: 0x06039B24 RID: 236324 RVA: 0x00EA016B File Offset: 0x00E9E36B
		// (set) Token: 0x06039B25 RID: 236325 RVA: 0x00EA0173 File Offset: 0x00E9E373
		public EMapGravityDirection? Gravity { get; set; }

		// Token: 0x17009348 RID: 37704
		// (get) Token: 0x06039B26 RID: 236326 RVA: 0x00EA017C File Offset: 0x00E9E37C
		// (set) Token: 0x06039B27 RID: 236327 RVA: 0x00EA0184 File Offset: 0x00E9E384
		public int? AreaId { get; set; }

		// Token: 0x17009349 RID: 37705
		// (get) Token: 0x06039B28 RID: 236328 RVA: 0x00EA018D File Offset: 0x00E9E38D
		// (set) Token: 0x06039B29 RID: 236329 RVA: 0x00EA0195 File Offset: 0x00E9E395
		public EFishPointDetectSourceType FishPointDetectSourceType { get; set; }
	}
}
