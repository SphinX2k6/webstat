using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View
{
	// Token: 0x020055AC RID: 21932
	[NullableContext(1)]
	public interface ICountEffectServerActionList : IServerAction
	{
		// Token: 0x17008FD5 RID: 36821
		// (get) Token: 0x06037D61 RID: 228705
		// (set) Token: 0x06037D62 RID: 228706
		List<int> CardIdList { get; set; }
	}
}
