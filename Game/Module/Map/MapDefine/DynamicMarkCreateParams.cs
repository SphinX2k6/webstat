using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058B3 RID: 22707
	[NullableContext(1)]
	[Nullable(0)]
	public class DynamicMarkCreateParams : IDynamicMarkCreateParams
	{
		// Token: 0x17009330 RID: 37680
		// (get) Token: 0x06039AF5 RID: 236277 RVA: 0x00E9FFD2 File Offset: 0x00E9E1D2
		// (set) Token: 0x06039AF6 RID: 236278 RVA: 0x00E9FFDA File Offset: 0x00E9E1DA
		public TTrackTarget TrackTarget { get; set; }

		// Token: 0x17009331 RID: 37681
		// (get) Token: 0x06039AF7 RID: 236279 RVA: 0x00E9FFE3 File Offset: 0x00E9E1E3
		// (set) Token: 0x06039AF8 RID: 236280 RVA: 0x00E9FFEB File Offset: 0x00E9E1EB
		public int MarkConfigId { get; set; }

		// Token: 0x17009332 RID: 37682
		// (get) Token: 0x06039AF9 RID: 236281 RVA: 0x00E9FFF4 File Offset: 0x00E9E1F4
		// (set) Token: 0x06039AFA RID: 236282 RVA: 0x00E9FFFC File Offset: 0x00E9E1FC
		public EMarkType MarkType { get; set; }

		// Token: 0x17009333 RID: 37683
		// (get) Token: 0x06039AFB RID: 236283 RVA: 0x00EA0005 File Offset: 0x00E9E205
		// (set) Token: 0x06039AFC RID: 236284 RVA: 0x00EA000D File Offset: 0x00E9E20D
		public int? MarkId { get; set; }

		// Token: 0x17009334 RID: 37684
		// (get) Token: 0x06039AFD RID: 236285 RVA: 0x00EA0016 File Offset: 0x00E9E216
		// (set) Token: 0x06039AFE RID: 236286 RVA: 0x00EA001E File Offset: 0x00E9E21E
		public ETrackSource? TrackSource { get; set; }

		// Token: 0x17009335 RID: 37685
		// (get) Token: 0x06039AFF RID: 236287 RVA: 0x00EA0027 File Offset: 0x00E9E227
		// (set) Token: 0x06039B00 RID: 236288 RVA: 0x00EA002F File Offset: 0x00E9E22F
		public bool? DestroyOnUnTrack { get; set; }

		// Token: 0x17009336 RID: 37686
		// (get) Token: 0x06039B01 RID: 236289 RVA: 0x00EA0038 File Offset: 0x00E9E238
		// (set) Token: 0x06039B02 RID: 236290 RVA: 0x00EA0040 File Offset: 0x00E9E240
		public int? TeleportId { get; set; }

		// Token: 0x17009337 RID: 37687
		// (get) Token: 0x06039B03 RID: 236291 RVA: 0x00EA0049 File Offset: 0x00E9E249
		// (set) Token: 0x06039B04 RID: 236292 RVA: 0x00EA0051 File Offset: 0x00E9E251
		public int? EntityConfigId { get; set; }

		// Token: 0x17009338 RID: 37688
		// (get) Token: 0x06039B05 RID: 236293 RVA: 0x00EA005A File Offset: 0x00E9E25A
		// (set) Token: 0x06039B06 RID: 236294 RVA: 0x00EA0062 File Offset: 0x00E9E262
		public MarkState? ServerMarkState { get; set; }

		// Token: 0x17009339 RID: 37689
		// (get) Token: 0x06039B07 RID: 236295 RVA: 0x00EA006B File Offset: 0x00E9E26B
		// (set) Token: 0x06039B08 RID: 236296 RVA: 0x00EA0073 File Offset: 0x00E9E273
		[Nullable(2)]
		public MapAndDungeonInfo MapAndDungeonInfo { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x1700933A RID: 37690
		// (get) Token: 0x06039B09 RID: 236297 RVA: 0x00EA007C File Offset: 0x00E9E27C
		// (set) Token: 0x06039B0A RID: 236298 RVA: 0x00EA0084 File Offset: 0x00E9E284
		public EMapGravityDirection? Gravity { get; set; }

		// Token: 0x1700933B RID: 37691
		// (get) Token: 0x06039B0B RID: 236299 RVA: 0x00EA008D File Offset: 0x00E9E28D
		// (set) Token: 0x06039B0C RID: 236300 RVA: 0x00EA0095 File Offset: 0x00E9E295
		public int? AreaId { get; set; }
	}
}
