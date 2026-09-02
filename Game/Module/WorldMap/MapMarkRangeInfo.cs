using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.MapDefine;

namespace CSharpScript.Game.Module.WorldMap
{
	// Token: 0x02004B32 RID: 19250
	[NullableContext(1)]
	[Nullable(0)]
	public class MapMarkRangeInfo : IMapMarkRangeInfo
	{
		// Token: 0x17008609 RID: 34313
		// (get) Token: 0x060323A0 RID: 205728 RVA: 0x00C8FAFB File Offset: 0x00C8DCFB
		// (set) Token: 0x060323A1 RID: 205729 RVA: 0x00C8FB03 File Offset: 0x00C8DD03
		public Vector2D Position { get; set; }

		// Token: 0x1700860A RID: 34314
		// (get) Token: 0x060323A2 RID: 205730 RVA: 0x00C8FB0C File Offset: 0x00C8DD0C
		// (set) Token: 0x060323A3 RID: 205731 RVA: 0x00C8FB14 File Offset: 0x00C8DD14
		public int? MapId { get; set; }

		// Token: 0x1700860B RID: 34315
		// (get) Token: 0x060323A4 RID: 205732 RVA: 0x00C8FB1D File Offset: 0x00C8DD1D
		// (set) Token: 0x060323A5 RID: 205733 RVA: 0x00C8FB25 File Offset: 0x00C8DD25
		public EMapGravityDirection? Gravity { get; set; }

		// Token: 0x1700860C RID: 34316
		// (get) Token: 0x060323A6 RID: 205734 RVA: 0x00C8FB2E File Offset: 0x00C8DD2E
		// (set) Token: 0x060323A7 RID: 205735 RVA: 0x00C8FB36 File Offset: 0x00C8DD36
		public float? Width { get; set; }

		// Token: 0x1700860D RID: 34317
		// (get) Token: 0x060323A8 RID: 205736 RVA: 0x00C8FB3F File Offset: 0x00C8DD3F
		// (set) Token: 0x060323A9 RID: 205737 RVA: 0x00C8FB47 File Offset: 0x00C8DD47
		public float? Height { get; set; }
	}
}
