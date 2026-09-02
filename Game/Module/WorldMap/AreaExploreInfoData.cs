using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WorldMap
{
	// Token: 0x02004B41 RID: 19265
	[NullableContext(1)]
	[Nullable(0)]
	public class AreaExploreInfoData : IAreaExploreInfoData
	{
		// Token: 0x17008641 RID: 34369
		// (get) Token: 0x0603243A RID: 205882 RVA: 0x00C91065 File Offset: 0x00C8F265
		// (set) Token: 0x0603243B RID: 205883 RVA: 0x00C9106D File Offset: 0x00C8F26D
		public int AreaId { get; set; }

		// Token: 0x17008642 RID: 34370
		// (get) Token: 0x0603243C RID: 205884 RVA: 0x00C91076 File Offset: 0x00C8F276
		// (set) Token: 0x0603243D RID: 205885 RVA: 0x00C9107E File Offset: 0x00C8F27E
		public List<IOneExploreItemData> ExploreProgress { get; set; }

		// Token: 0x17008643 RID: 34371
		// (get) Token: 0x0603243E RID: 205886 RVA: 0x00C91087 File Offset: 0x00C8F287
		// (set) Token: 0x0603243F RID: 205887 RVA: 0x00C9108F File Offset: 0x00C8F28F
		public float ExplorePercent { get; set; }
	}
}
