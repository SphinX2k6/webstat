using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058C6 RID: 22726
	[NullableContext(1)]
	public interface IDynamicMarkCreateParams
	{
		// Token: 0x1700934B RID: 37707
		// (get) Token: 0x06039B2F RID: 236335
		// (set) Token: 0x06039B30 RID: 236336
		TTrackTarget TrackTarget { get; set; }

		// Token: 0x1700934C RID: 37708
		// (get) Token: 0x06039B31 RID: 236337
		// (set) Token: 0x06039B32 RID: 236338
		int MarkConfigId { get; set; }

		// Token: 0x1700934D RID: 37709
		// (get) Token: 0x06039B33 RID: 236339
		// (set) Token: 0x06039B34 RID: 236340
		EMarkType MarkType { get; set; }

		// Token: 0x1700934E RID: 37710
		// (get) Token: 0x06039B35 RID: 236341
		// (set) Token: 0x06039B36 RID: 236342
		int? MarkId { get; set; }

		// Token: 0x1700934F RID: 37711
		// (get) Token: 0x06039B37 RID: 236343
		// (set) Token: 0x06039B38 RID: 236344
		ETrackSource? TrackSource { get; set; }

		// Token: 0x17009350 RID: 37712
		// (get) Token: 0x06039B39 RID: 236345
		// (set) Token: 0x06039B3A RID: 236346
		bool? DestroyOnUnTrack { get; set; }

		// Token: 0x17009351 RID: 37713
		// (get) Token: 0x06039B3B RID: 236347
		// (set) Token: 0x06039B3C RID: 236348
		int? TeleportId { get; set; }

		// Token: 0x17009352 RID: 37714
		// (get) Token: 0x06039B3D RID: 236349
		// (set) Token: 0x06039B3E RID: 236350
		int? EntityConfigId { get; set; }

		// Token: 0x17009353 RID: 37715
		// (get) Token: 0x06039B3F RID: 236351
		// (set) Token: 0x06039B40 RID: 236352
		MarkState? ServerMarkState { get; set; }

		// Token: 0x17009354 RID: 37716
		// (get) Token: 0x06039B41 RID: 236353
		// (set) Token: 0x06039B42 RID: 236354
		[Nullable(2)]
		MapAndDungeonInfo MapAndDungeonInfo { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17009355 RID: 37717
		// (get) Token: 0x06039B43 RID: 236355
		// (set) Token: 0x06039B44 RID: 236356
		EMapGravityDirection? Gravity { get; set; }

		// Token: 0x17009356 RID: 37718
		// (get) Token: 0x06039B45 RID: 236357
		// (set) Token: 0x06039B46 RID: 236358
		int? AreaId { get; set; }
	}
}
