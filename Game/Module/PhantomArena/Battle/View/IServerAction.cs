using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View
{
	// Token: 0x020055AB RID: 21931
	[NullableContext(1)]
	public interface IServerAction
	{
		// Token: 0x17008FD3 RID: 36819
		// (get) Token: 0x06037D5D RID: 228701
		// (set) Token: 0x06037D5E RID: 228702
		List<TServerAction> ActionList { get; set; }

		// Token: 0x17008FD4 RID: 36820
		// (get) Token: 0x06037D5F RID: 228703
		// (set) Token: 0x06037D60 RID: 228704
		EServerActionType Type { get; set; }
	}
}
