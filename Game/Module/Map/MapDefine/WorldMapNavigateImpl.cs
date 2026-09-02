using System;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058CA RID: 22730
	public class WorldMapNavigateImpl : IWorldMapNavigate
	{
		// Token: 0x17009360 RID: 37728
		// (get) Token: 0x06039B54 RID: 236372 RVA: 0x00EA01B7 File Offset: 0x00E9E3B7
		// (set) Token: 0x06039B55 RID: 236373 RVA: 0x00EA01BF File Offset: 0x00E9E3BF
		public int AreaId { get; set; }

		// Token: 0x17009361 RID: 37729
		// (get) Token: 0x06039B56 RID: 236374 RVA: 0x00EA01C8 File Offset: 0x00E9E3C8
		// (set) Token: 0x06039B57 RID: 236375 RVA: 0x00EA01D0 File Offset: 0x00E9E3D0
		public int? StateId { get; set; }

		// Token: 0x17009362 RID: 37730
		// (get) Token: 0x06039B58 RID: 236376 RVA: 0x00EA01D9 File Offset: 0x00E9E3D9
		// (set) Token: 0x06039B59 RID: 236377 RVA: 0x00EA01E1 File Offset: 0x00E9E3E1
		public int CountryId { get; set; }

		// Token: 0x17009363 RID: 37731
		// (get) Token: 0x06039B5A RID: 236378 RVA: 0x00EA01EA File Offset: 0x00E9E3EA
		// (set) Token: 0x06039B5B RID: 236379 RVA: 0x00EA01F2 File Offset: 0x00E9E3F2
		public int MarkId { get; set; }

		// Token: 0x17009364 RID: 37732
		// (get) Token: 0x06039B5C RID: 236380 RVA: 0x00EA01FB File Offset: 0x00E9E3FB
		// (set) Token: 0x06039B5D RID: 236381 RVA: 0x00EA0203 File Offset: 0x00E9E403
		public EMarkType MarkType { get; set; }

		// Token: 0x17009365 RID: 37733
		// (get) Token: 0x06039B5E RID: 236382 RVA: 0x00EA020C File Offset: 0x00E9E40C
		// (set) Token: 0x06039B5F RID: 236383 RVA: 0x00EA0214 File Offset: 0x00E9E414
		public int SortIndex { get; set; }
	}
}
