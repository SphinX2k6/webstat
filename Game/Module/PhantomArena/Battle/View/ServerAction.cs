using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View
{
	// Token: 0x020055AD RID: 21933
	[NullableContext(1)]
	[Nullable(0)]
	public class ServerAction : IServerAction
	{
		// Token: 0x17008FD6 RID: 36822
		// (get) Token: 0x06037D63 RID: 228707 RVA: 0x00E252B7 File Offset: 0x00E234B7
		// (set) Token: 0x06037D64 RID: 228708 RVA: 0x00E252BF File Offset: 0x00E234BF
		public List<TServerAction> ActionList { get; set; }

		// Token: 0x17008FD7 RID: 36823
		// (get) Token: 0x06037D65 RID: 228709 RVA: 0x00E252C8 File Offset: 0x00E234C8
		// (set) Token: 0x06037D66 RID: 228710 RVA: 0x00E252D0 File Offset: 0x00E234D0
		public EServerActionType Type { get; set; }
	}
}
