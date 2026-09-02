using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A68 RID: 23144
	[NullableContext(1)]
	public interface IKurotatoSaveViewOpenParam
	{
		// Token: 0x17009586 RID: 38278
		// (get) Token: 0x0603A8D4 RID: 239828
		// (set) Token: 0x0603A8D5 RID: 239829
		List<KurotatoInstInfo> InstInfos { get; set; }

		// Token: 0x17009587 RID: 38279
		// (get) Token: 0x0603A8D6 RID: 239830
		// (set) Token: 0x0603A8D7 RID: 239831
		int DefaultIndex { get; set; }
	}
}
