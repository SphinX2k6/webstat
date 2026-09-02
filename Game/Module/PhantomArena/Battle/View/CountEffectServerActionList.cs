using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View
{
	// Token: 0x020055AE RID: 21934
	[NullableContext(1)]
	[Nullable(0)]
	public class CountEffectServerActionList : ICountEffectServerActionList, IServerAction
	{
		// Token: 0x17008FD8 RID: 36824
		// (get) Token: 0x06037D68 RID: 228712 RVA: 0x00E252E1 File Offset: 0x00E234E1
		// (set) Token: 0x06037D69 RID: 228713 RVA: 0x00E252E9 File Offset: 0x00E234E9
		public List<TServerAction> ActionList { get; set; }

		// Token: 0x17008FD9 RID: 36825
		// (get) Token: 0x06037D6A RID: 228714 RVA: 0x00E252F2 File Offset: 0x00E234F2
		// (set) Token: 0x06037D6B RID: 228715 RVA: 0x00E252FA File Offset: 0x00E234FA
		public EServerActionType Type { get; set; }

		// Token: 0x17008FDA RID: 36826
		// (get) Token: 0x06037D6C RID: 228716 RVA: 0x00E25303 File Offset: 0x00E23503
		// (set) Token: 0x06037D6D RID: 228717 RVA: 0x00E2530B File Offset: 0x00E2350B
		public List<int> CardIdList { get; set; }
	}
}
