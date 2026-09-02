using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.VillageInfr
{
	// Token: 0x02004C2D RID: 19501
	[NullableContext(2)]
	public interface IVillageInfrBuildInfoParam
	{
		// Token: 0x17008735 RID: 34613
		// (get) Token: 0x06032D8E RID: 208270
		// (set) Token: 0x06032D8F RID: 208271
		EVillageInfrSelectType SelectType { get; set; }

		// Token: 0x17008736 RID: 34614
		// (get) Token: 0x06032D90 RID: 208272
		// (set) Token: 0x06032D91 RID: 208273
		int SelectId { get; set; }

		// Token: 0x17008737 RID: 34615
		// (get) Token: 0x06032D92 RID: 208274
		// (set) Token: 0x06032D93 RID: 208275
		bool IsDelivery { get; set; }

		// Token: 0x17008738 RID: 34616
		// (get) Token: 0x06032D94 RID: 208276
		// (set) Token: 0x06032D95 RID: 208277
		Action CloseCb { get; set; }
	}
}
