using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058E5 RID: 22757
	[NullableContext(1)]
	[Nullable(0)]
	public class QuestMarkCreateParams : IDynamicMarkCreateParams
	{
		// Token: 0x170093AD RID: 37805
		// (get) Token: 0x06039C08 RID: 236552 RVA: 0x00EA07BA File Offset: 0x00E9E9BA
		// (set) Token: 0x06039C09 RID: 236553 RVA: 0x00EA07C2 File Offset: 0x00E9E9C2
		public TTrackTarget TrackTarget { get; set; }

		// Token: 0x170093AE RID: 37806
		// (get) Token: 0x06039C0A RID: 236554 RVA: 0x00EA07CB File Offset: 0x00E9E9CB
		// (set) Token: 0x06039C0B RID: 236555 RVA: 0x00EA07D3 File Offset: 0x00E9E9D3
		public int MarkConfigId { get; set; }

		// Token: 0x170093AF RID: 37807
		// (get) Token: 0x06039C0C RID: 236556 RVA: 0x00EA07DC File Offset: 0x00E9E9DC
		// (set) Token: 0x06039C0D RID: 236557 RVA: 0x00EA07E4 File Offset: 0x00E9E9E4
		public EMarkType MarkType { get; set; }

		// Token: 0x170093B0 RID: 37808
		// (get) Token: 0x06039C0E RID: 236558 RVA: 0x00EA07ED File Offset: 0x00E9E9ED
		// (set) Token: 0x06039C0F RID: 236559 RVA: 0x00EA07F5 File Offset: 0x00E9E9F5
		public int? MarkId { get; set; }

		// Token: 0x170093B1 RID: 37809
		// (get) Token: 0x06039C10 RID: 236560 RVA: 0x00EA07FE File Offset: 0x00E9E9FE
		// (set) Token: 0x06039C11 RID: 236561 RVA: 0x00EA0806 File Offset: 0x00E9EA06
		public ETrackSource? TrackSource { get; set; }

		// Token: 0x170093B2 RID: 37810
		// (get) Token: 0x06039C12 RID: 236562 RVA: 0x00EA080F File Offset: 0x00E9EA0F
		// (set) Token: 0x06039C13 RID: 236563 RVA: 0x00EA0817 File Offset: 0x00E9EA17
		public bool? DestroyOnUnTrack { get; set; }

		// Token: 0x170093B3 RID: 37811
		// (get) Token: 0x06039C14 RID: 236564 RVA: 0x00EA0820 File Offset: 0x00E9EA20
		// (set) Token: 0x06039C15 RID: 236565 RVA: 0x00EA0828 File Offset: 0x00E9EA28
		public int? TeleportId { get; set; }

		// Token: 0x170093B4 RID: 37812
		// (get) Token: 0x06039C16 RID: 236566 RVA: 0x00EA0831 File Offset: 0x00E9EA31
		// (set) Token: 0x06039C17 RID: 236567 RVA: 0x00EA0839 File Offset: 0x00E9EA39
		public int? EntityConfigId { get; set; }

		// Token: 0x170093B5 RID: 37813
		// (get) Token: 0x06039C18 RID: 236568 RVA: 0x00EA0842 File Offset: 0x00E9EA42
		// (set) Token: 0x06039C19 RID: 236569 RVA: 0x00EA084A File Offset: 0x00E9EA4A
		public MarkState? ServerMarkState { get; set; }

		// Token: 0x170093B6 RID: 37814
		// (get) Token: 0x06039C1A RID: 236570 RVA: 0x00EA0853 File Offset: 0x00E9EA53
		// (set) Token: 0x06039C1B RID: 236571 RVA: 0x00EA085B File Offset: 0x00E9EA5B
		[Nullable(2)]
		public MapAndDungeonInfo MapAndDungeonInfo { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x170093B7 RID: 37815
		// (get) Token: 0x06039C1C RID: 236572 RVA: 0x00EA0864 File Offset: 0x00E9EA64
		// (set) Token: 0x06039C1D RID: 236573 RVA: 0x00EA086C File Offset: 0x00E9EA6C
		public EMapGravityDirection? Gravity { get; set; }

		// Token: 0x170093B8 RID: 37816
		// (get) Token: 0x06039C1E RID: 236574 RVA: 0x00EA0875 File Offset: 0x00E9EA75
		// (set) Token: 0x06039C1F RID: 236575 RVA: 0x00EA087D File Offset: 0x00E9EA7D
		public int? AreaId { get; set; }

		// Token: 0x04020BFB RID: 134139
		public long TreeId;

		// Token: 0x04020BFC RID: 134140
		public int NodeId;

		// Token: 0x04020BFD RID: 134141
		public bool? IsBoundToParentQuest;
	}
}
