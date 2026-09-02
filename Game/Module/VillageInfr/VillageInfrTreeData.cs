using System;
using Aki.Protocol;

namespace CSharpScript.Game.Module.VillageInfr
{
	// Token: 0x02004C29 RID: 19497
	public class VillageInfrTreeData : IVillageInfrTreeData
	{
		// Token: 0x17008732 RID: 34610
		// (get) Token: 0x06032D85 RID: 208261 RVA: 0x00CBD37F File Offset: 0x00CBB57F
		// (set) Token: 0x06032D86 RID: 208262 RVA: 0x00CBD387 File Offset: 0x00CBB587
		public int Id { get; set; }

		// Token: 0x17008733 RID: 34611
		// (get) Token: 0x06032D87 RID: 208263 RVA: 0x00CBD390 File Offset: 0x00CBB590
		// (set) Token: 0x06032D88 RID: 208264 RVA: 0x00CBD398 File Offset: 0x00CBB598
		public InfrV2StatusPb Status { get; set; }

		// Token: 0x17008734 RID: 34612
		// (get) Token: 0x06032D89 RID: 208265 RVA: 0x00CBD3A1 File Offset: 0x00CBB5A1
		// (set) Token: 0x06032D8A RID: 208266 RVA: 0x00CBD3A9 File Offset: 0x00CBB5A9
		public long CompleteTime { get; set; }
	}
}
