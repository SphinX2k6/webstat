using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052DB RID: 21211
	[NullableContext(1)]
	public interface IQuickHackHighlightPreProcessResult
	{
		// Token: 0x17008D01 RID: 36097
		// (get) Token: 0x060362D3 RID: 221907
		// (set) Token: 0x060362D4 RID: 221908
		HashSet<EntityHandle> NewOnScreenTargetSet { get; set; }

		// Token: 0x17008D02 RID: 36098
		// (get) Token: 0x060362D5 RID: 221909
		// (set) Token: 0x060362D6 RID: 221910
		HashSet<EntityHandle> NewLockTargetSet { get; set; }
	}
}
