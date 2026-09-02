using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A69 RID: 23145
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoSaveViewOpenParam : IKurotatoSaveViewOpenParam
	{
		// Token: 0x17009588 RID: 38280
		// (get) Token: 0x0603A8D8 RID: 239832 RVA: 0x00ED32A2 File Offset: 0x00ED14A2
		// (set) Token: 0x0603A8D9 RID: 239833 RVA: 0x00ED32AA File Offset: 0x00ED14AA
		public List<KurotatoInstInfo> InstInfos { get; set; }

		// Token: 0x17009589 RID: 38281
		// (get) Token: 0x0603A8DA RID: 239834 RVA: 0x00ED32B3 File Offset: 0x00ED14B3
		// (set) Token: 0x0603A8DB RID: 239835 RVA: 0x00ED32BB File Offset: 0x00ED14BB
		public int DefaultIndex { get; set; }
	}
}
