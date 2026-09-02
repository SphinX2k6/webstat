using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.VillageInfr
{
	// Token: 0x02004C30 RID: 19504
	[NullableContext(1)]
	[Nullable(0)]
	public class VillageInfrDeliveryParam : IVillageInfrDeliveryParam
	{
		// Token: 0x17008740 RID: 34624
		// (get) Token: 0x06032DA5 RID: 208293 RVA: 0x00CBD423 File Offset: 0x00CBB623
		// (set) Token: 0x06032DA6 RID: 208294 RVA: 0x00CBD42B File Offset: 0x00CBB62B
		public EVillageInfrSelectType SelectType { get; set; }

		// Token: 0x17008741 RID: 34625
		// (get) Token: 0x06032DA7 RID: 208295 RVA: 0x00CBD434 File Offset: 0x00CBB634
		// (set) Token: 0x06032DA8 RID: 208296 RVA: 0x00CBD43C File Offset: 0x00CBB63C
		public int SelectId { get; set; }

		// Token: 0x17008742 RID: 34626
		// (get) Token: 0x06032DA9 RID: 208297 RVA: 0x00CBD445 File Offset: 0x00CBB645
		// (set) Token: 0x06032DAA RID: 208298 RVA: 0x00CBD44D File Offset: 0x00CBB64D
		public string UiCameraName { get; set; }
	}
}
