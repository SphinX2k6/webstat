using System;

namespace CSharpScript.Game.Module.VillageInfr
{
	// Token: 0x02004C38 RID: 19512
	public class VillageInfrBuildFinishTipParam : IVillageInfrBuildFinishTipParam
	{
		// Token: 0x1700874F RID: 34639
		// (get) Token: 0x06032DC7 RID: 208327 RVA: 0x00CBD4CB File Offset: 0x00CBB6CB
		// (set) Token: 0x06032DC8 RID: 208328 RVA: 0x00CBD4D3 File Offset: 0x00CBB6D3
		public EVillageInfrSelectType SelectType { get; set; }

		// Token: 0x17008750 RID: 34640
		// (get) Token: 0x06032DC9 RID: 208329 RVA: 0x00CBD4DC File Offset: 0x00CBB6DC
		// (set) Token: 0x06032DCA RID: 208330 RVA: 0x00CBD4E4 File Offset: 0x00CBB6E4
		public int SelectId { get; set; }
	}
}
