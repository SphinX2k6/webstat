using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058D0 RID: 22736
	[NullableContext(1)]
	[Nullable(0)]
	public class WorldMapNavigateState : IWorldMapNavigateState
	{
		// Token: 0x17009371 RID: 37745
		// (get) Token: 0x06039B75 RID: 236405 RVA: 0x00EA0284 File Offset: 0x00E9E484
		// (set) Token: 0x06039B76 RID: 236406 RVA: 0x00EA028C File Offset: 0x00E9E48C
		public int StateId { get; set; }

		// Token: 0x17009372 RID: 37746
		// (get) Token: 0x06039B77 RID: 236407 RVA: 0x00EA0295 File Offset: 0x00E9E495
		// (set) Token: 0x06039B78 RID: 236408 RVA: 0x00EA029D File Offset: 0x00E9E49D
		public int SortIndex { get; set; }

		// Token: 0x17009373 RID: 37747
		// (get) Token: 0x06039B79 RID: 236409 RVA: 0x00EA02A6 File Offset: 0x00E9E4A6
		// (set) Token: 0x06039B7A RID: 236410 RVA: 0x00EA02AE File Offset: 0x00E9E4AE
		public List<IWorldMapNavigate> AreaNavigateList { get; set; } = new List<IWorldMapNavigate>();
	}
}
