using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A55 RID: 23125
	[NullableContext(1)]
	public interface IKurotatoAttrPreviewDelta
	{
		// Token: 0x1700955E RID: 38238
		// (get) Token: 0x0603A87F RID: 239743
		// (set) Token: 0x0603A880 RID: 239744
		int PropertyId { get; set; }

		// Token: 0x1700955F RID: 38239
		// (get) Token: 0x0603A881 RID: 239745
		// (set) Token: 0x0603A882 RID: 239746
		string ValueStr { get; set; }

		// Token: 0x17009560 RID: 38240
		// (get) Token: 0x0603A883 RID: 239747
		// (set) Token: 0x0603A884 RID: 239748
		int? LockValue { get; set; }
	}
}
