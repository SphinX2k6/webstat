using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.MapDefine;

namespace CSharpScript.Game.Module.WorldMap
{
	// Token: 0x02004B29 RID: 19241
	[NullableContext(2)]
	[Nullable(0)]
	public class WorldMapViewOpenParams : IWorldMapViewOpenParams
	{
		// Token: 0x170085E5 RID: 34277
		// (get) Token: 0x06032351 RID: 205649 RVA: 0x00C8F94B File Offset: 0x00C8DB4B
		// (set) Token: 0x06032352 RID: 205650 RVA: 0x00C8F953 File Offset: 0x00C8DB53
		public EMarkType MarkType { get; set; }

		// Token: 0x170085E6 RID: 34278
		// (get) Token: 0x06032353 RID: 205651 RVA: 0x00C8F95C File Offset: 0x00C8DB5C
		// (set) Token: 0x06032354 RID: 205652 RVA: 0x00C8F964 File Offset: 0x00C8DB64
		public int? MarkId { get; set; }

		// Token: 0x170085E7 RID: 34279
		// (get) Token: 0x06032355 RID: 205653 RVA: 0x00C8F96D File Offset: 0x00C8DB6D
		// (set) Token: 0x06032356 RID: 205654 RVA: 0x00C8F975 File Offset: 0x00C8DB75
		public Vector2D StartWorldPosition { get; set; }

		// Token: 0x170085E8 RID: 34280
		// (get) Token: 0x06032357 RID: 205655 RVA: 0x00C8F97E File Offset: 0x00C8DB7E
		// (set) Token: 0x06032358 RID: 205656 RVA: 0x00C8F986 File Offset: 0x00C8DB86
		public Vector DebugWorldPosition { get; set; }

		// Token: 0x170085E9 RID: 34281
		// (get) Token: 0x06032359 RID: 205657 RVA: 0x00C8F98F File Offset: 0x00C8DB8F
		// (set) Token: 0x0603235A RID: 205658 RVA: 0x00C8F997 File Offset: 0x00C8DB97
		public int? MapId { get; set; }

		// Token: 0x170085EA RID: 34282
		// (get) Token: 0x0603235B RID: 205659 RVA: 0x00C8F9A0 File Offset: 0x00C8DBA0
		// (set) Token: 0x0603235C RID: 205660 RVA: 0x00C8F9A8 File Offset: 0x00C8DBA8
		public float? StartScale { get; set; }

		// Token: 0x170085EB RID: 34283
		// (get) Token: 0x0603235D RID: 205661 RVA: 0x00C8F9B1 File Offset: 0x00C8DBB1
		// (set) Token: 0x0603235E RID: 205662 RVA: 0x00C8F9B9 File Offset: 0x00C8DBB9
		public int? OpenFogId { get; set; }

		// Token: 0x170085EC RID: 34284
		// (get) Token: 0x0603235F RID: 205663 RVA: 0x00C8F9C2 File Offset: 0x00C8DBC2
		// (set) Token: 0x06032360 RID: 205664 RVA: 0x00C8F9CA File Offset: 0x00C8DBCA
		public bool? ShowFogEffectInstant { get; set; }

		// Token: 0x170085ED RID: 34285
		// (get) Token: 0x06032361 RID: 205665 RVA: 0x00C8F9D3 File Offset: 0x00C8DBD3
		// (set) Token: 0x06032362 RID: 205666 RVA: 0x00C8F9DB File Offset: 0x00C8DBDB
		public bool? IsNotFocusTween { get; set; }

		// Token: 0x170085EE RID: 34286
		// (get) Token: 0x06032363 RID: 205667 RVA: 0x00C8F9E4 File Offset: 0x00C8DBE4
		// (set) Token: 0x06032364 RID: 205668 RVA: 0x00C8F9EC File Offset: 0x00C8DBEC
		public bool? IsNotFocal { get; set; }

		// Token: 0x170085EF RID: 34287
		// (get) Token: 0x06032365 RID: 205669 RVA: 0x00C8F9F5 File Offset: 0x00C8DBF5
		// (set) Token: 0x06032366 RID: 205670 RVA: 0x00C8F9FD File Offset: 0x00C8DBFD
		public bool? IsNotNeedUnLockEffect { get; set; }

		// Token: 0x170085F0 RID: 34288
		// (get) Token: 0x06032367 RID: 205671 RVA: 0x00C8FA06 File Offset: 0x00C8DC06
		// (set) Token: 0x06032368 RID: 205672 RVA: 0x00C8FA0E File Offset: 0x00C8DC0E
		public int[] FocusExplorePlayPoint { get; set; }

		// Token: 0x170085F1 RID: 34289
		// (get) Token: 0x06032369 RID: 205673 RVA: 0x00C8FA17 File Offset: 0x00C8DC17
		// (set) Token: 0x0603236A RID: 205674 RVA: 0x00C8FA1F File Offset: 0x00C8DC1F
		public int[] SkipToExploreAreaDetailView { get; set; }

		// Token: 0x170085F2 RID: 34290
		// (get) Token: 0x0603236B RID: 205675 RVA: 0x00C8FA28 File Offset: 0x00C8DC28
		// (set) Token: 0x0603236C RID: 205676 RVA: 0x00C8FA30 File Offset: 0x00C8DC30
		public bool? NeedRefreshMultiFloor { get; set; }

		// Token: 0x170085F3 RID: 34291
		// (get) Token: 0x0603236D RID: 205677 RVA: 0x00C8FA39 File Offset: 0x00C8DC39
		// (set) Token: 0x0603236E RID: 205678 RVA: 0x00C8FA41 File Offset: 0x00C8DC41
		public EWorldMapExtraUiPanelName? SkipToExtraUiName { get; set; }

		// Token: 0x170085F4 RID: 34292
		// (get) Token: 0x0603236F RID: 205679 RVA: 0x00C8FA4A File Offset: 0x00C8DC4A
		// (set) Token: 0x06032370 RID: 205680 RVA: 0x00C8FA52 File Offset: 0x00C8DC52
		public object SkipToExtraUiParam { get; set; }

		// Token: 0x170085F5 RID: 34293
		// (get) Token: 0x06032371 RID: 205681 RVA: 0x00C8FA5B File Offset: 0x00C8DC5B
		// (set) Token: 0x06032372 RID: 205682 RVA: 0x00C8FA63 File Offset: 0x00C8DC63
		public IRegionalTerminalBarItemParams RegionalTerminalBarItemParams { get; set; }
	}
}
