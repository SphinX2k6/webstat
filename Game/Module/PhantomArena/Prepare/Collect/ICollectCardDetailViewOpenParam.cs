using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Collect
{
	// Token: 0x02005514 RID: 21780
	[NullableContext(1)]
	public interface ICollectCardDetailViewOpenParam
	{
		// Token: 0x17008F24 RID: 36644
		// (get) Token: 0x060378F4 RID: 227572
		// (set) Token: 0x060378F5 RID: 227573
		int CardId { get; set; }

		// Token: 0x17008F25 RID: 36645
		// (get) Token: 0x060378F6 RID: 227574
		// (set) Token: 0x060378F7 RID: 227575
		int ActivityId { get; set; }

		// Token: 0x17008F26 RID: 36646
		// (get) Token: 0x060378F8 RID: 227576
		// (set) Token: 0x060378F9 RID: 227577
		Action<int> CallbackOnClose { get; set; }
	}
}
