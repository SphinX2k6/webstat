using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.MapDefine;

namespace CSharpScript.Game.Module.WorldMap
{
	// Token: 0x02004B28 RID: 19240
	[NullableContext(2)]
	public interface IWorldMapViewOpenParams
	{
		// Token: 0x170085D4 RID: 34260
		// (get) Token: 0x0603232F RID: 205615
		// (set) Token: 0x06032330 RID: 205616
		EMarkType MarkType { get; set; }

		// Token: 0x170085D5 RID: 34261
		// (get) Token: 0x06032331 RID: 205617
		// (set) Token: 0x06032332 RID: 205618
		int? MarkId { get; set; }

		// Token: 0x170085D6 RID: 34262
		// (get) Token: 0x06032333 RID: 205619
		// (set) Token: 0x06032334 RID: 205620
		Vector2D StartWorldPosition { get; set; }

		// Token: 0x170085D7 RID: 34263
		// (get) Token: 0x06032335 RID: 205621
		// (set) Token: 0x06032336 RID: 205622
		Vector DebugWorldPosition { get; set; }

		// Token: 0x170085D8 RID: 34264
		// (get) Token: 0x06032337 RID: 205623
		// (set) Token: 0x06032338 RID: 205624
		int? MapId { get; set; }

		// Token: 0x170085D9 RID: 34265
		// (get) Token: 0x06032339 RID: 205625
		// (set) Token: 0x0603233A RID: 205626
		float? StartScale { get; set; }

		// Token: 0x170085DA RID: 34266
		// (get) Token: 0x0603233B RID: 205627
		// (set) Token: 0x0603233C RID: 205628
		int? OpenFogId { get; set; }

		// Token: 0x170085DB RID: 34267
		// (get) Token: 0x0603233D RID: 205629
		// (set) Token: 0x0603233E RID: 205630
		bool? ShowFogEffectInstant { get; set; }

		// Token: 0x170085DC RID: 34268
		// (get) Token: 0x0603233F RID: 205631
		// (set) Token: 0x06032340 RID: 205632
		bool? IsNotFocusTween { get; set; }

		// Token: 0x170085DD RID: 34269
		// (get) Token: 0x06032341 RID: 205633
		// (set) Token: 0x06032342 RID: 205634
		bool? IsNotFocal { get; set; }

		// Token: 0x170085DE RID: 34270
		// (get) Token: 0x06032343 RID: 205635
		// (set) Token: 0x06032344 RID: 205636
		bool? IsNotNeedUnLockEffect { get; set; }

		// Token: 0x170085DF RID: 34271
		// (get) Token: 0x06032345 RID: 205637
		// (set) Token: 0x06032346 RID: 205638
		int[] FocusExplorePlayPoint { get; set; }

		// Token: 0x170085E0 RID: 34272
		// (get) Token: 0x06032347 RID: 205639
		// (set) Token: 0x06032348 RID: 205640
		int[] SkipToExploreAreaDetailView { get; set; }

		// Token: 0x170085E1 RID: 34273
		// (get) Token: 0x06032349 RID: 205641
		// (set) Token: 0x0603234A RID: 205642
		bool? NeedRefreshMultiFloor { get; set; }

		// Token: 0x170085E2 RID: 34274
		// (get) Token: 0x0603234B RID: 205643
		// (set) Token: 0x0603234C RID: 205644
		EWorldMapExtraUiPanelName? SkipToExtraUiName { get; set; }

		// Token: 0x170085E3 RID: 34275
		// (get) Token: 0x0603234D RID: 205645
		// (set) Token: 0x0603234E RID: 205646
		object SkipToExtraUiParam { get; set; }

		// Token: 0x170085E4 RID: 34276
		// (get) Token: 0x0603234F RID: 205647
		// (set) Token: 0x06032350 RID: 205648
		IRegionalTerminalBarItemParams RegionalTerminalBarItemParams { get; set; }
	}
}
