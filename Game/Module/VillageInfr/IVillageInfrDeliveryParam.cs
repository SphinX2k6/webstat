using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.VillageInfr
{
	// Token: 0x02004C2F RID: 19503
	[NullableContext(1)]
	public interface IVillageInfrDeliveryParam
	{
		// Token: 0x1700873D RID: 34621
		// (get) Token: 0x06032D9F RID: 208287
		// (set) Token: 0x06032DA0 RID: 208288
		EVillageInfrSelectType SelectType { get; set; }

		// Token: 0x1700873E RID: 34622
		// (get) Token: 0x06032DA1 RID: 208289
		// (set) Token: 0x06032DA2 RID: 208290
		int SelectId { get; set; }

		// Token: 0x1700873F RID: 34623
		// (get) Token: 0x06032DA3 RID: 208291
		// (set) Token: 0x06032DA4 RID: 208292
		string UiCameraName { get; set; }
	}
}
