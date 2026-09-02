using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A40 RID: 23104
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoShopOpenParam : IKurotatoShopOpenParam
	{
		// Token: 0x17009509 RID: 38153
		// (get) Token: 0x0603A7CA RID: 239562 RVA: 0x00ED2DF3 File Offset: 0x00ED0FF3
		// (set) Token: 0x0603A7CB RID: 239563 RVA: 0x00ED2DFB File Offset: 0x00ED0FFB
		public List<int> Items { get; set; }
	}
}
