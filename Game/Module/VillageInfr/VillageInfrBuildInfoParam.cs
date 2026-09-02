using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.VillageInfr
{
	// Token: 0x02004C2E RID: 19502
	[NullableContext(2)]
	[Nullable(0)]
	public class VillageInfrBuildInfoParam : IVillageInfrBuildInfoParam
	{
		// Token: 0x17008739 RID: 34617
		// (get) Token: 0x06032D96 RID: 208278 RVA: 0x00CBD3D7 File Offset: 0x00CBB5D7
		// (set) Token: 0x06032D97 RID: 208279 RVA: 0x00CBD3DF File Offset: 0x00CBB5DF
		public EVillageInfrSelectType SelectType { get; set; }

		// Token: 0x1700873A RID: 34618
		// (get) Token: 0x06032D98 RID: 208280 RVA: 0x00CBD3E8 File Offset: 0x00CBB5E8
		// (set) Token: 0x06032D99 RID: 208281 RVA: 0x00CBD3F0 File Offset: 0x00CBB5F0
		public int SelectId { get; set; }

		// Token: 0x1700873B RID: 34619
		// (get) Token: 0x06032D9A RID: 208282 RVA: 0x00CBD3F9 File Offset: 0x00CBB5F9
		// (set) Token: 0x06032D9B RID: 208283 RVA: 0x00CBD401 File Offset: 0x00CBB601
		public bool IsDelivery { get; set; }

		// Token: 0x1700873C RID: 34620
		// (get) Token: 0x06032D9C RID: 208284 RVA: 0x00CBD40A File Offset: 0x00CBB60A
		// (set) Token: 0x06032D9D RID: 208285 RVA: 0x00CBD412 File Offset: 0x00CBB612
		public Action CloseCb { get; set; }
	}
}
