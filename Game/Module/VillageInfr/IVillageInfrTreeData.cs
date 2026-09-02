using System;
using Aki.Protocol;

namespace CSharpScript.Game.Module.VillageInfr
{
	// Token: 0x02004C28 RID: 19496
	public interface IVillageInfrTreeData
	{
		// Token: 0x1700872F RID: 34607
		// (get) Token: 0x06032D7F RID: 208255
		// (set) Token: 0x06032D80 RID: 208256
		int Id { get; set; }

		// Token: 0x17008730 RID: 34608
		// (get) Token: 0x06032D81 RID: 208257
		// (set) Token: 0x06032D82 RID: 208258
		InfrV2StatusPb Status { get; set; }

		// Token: 0x17008731 RID: 34609
		// (get) Token: 0x06032D83 RID: 208259
		// (set) Token: 0x06032D84 RID: 208260
		long CompleteTime { get; set; }
	}
}
