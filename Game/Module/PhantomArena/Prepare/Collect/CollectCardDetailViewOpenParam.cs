using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Collect
{
	// Token: 0x02005515 RID: 21781
	[NullableContext(1)]
	[Nullable(0)]
	public class CollectCardDetailViewOpenParam : ICollectCardDetailViewOpenParam
	{
		// Token: 0x17008F27 RID: 36647
		// (get) Token: 0x060378FA RID: 227578 RVA: 0x00E1867A File Offset: 0x00E1687A
		// (set) Token: 0x060378FB RID: 227579 RVA: 0x00E18682 File Offset: 0x00E16882
		public int CardId { get; set; }

		// Token: 0x17008F28 RID: 36648
		// (get) Token: 0x060378FC RID: 227580 RVA: 0x00E1868B File Offset: 0x00E1688B
		// (set) Token: 0x060378FD RID: 227581 RVA: 0x00E18693 File Offset: 0x00E16893
		public int ActivityId { get; set; }

		// Token: 0x17008F29 RID: 36649
		// (get) Token: 0x060378FE RID: 227582 RVA: 0x00E1869C File Offset: 0x00E1689C
		// (set) Token: 0x060378FF RID: 227583 RVA: 0x00E186A4 File Offset: 0x00E168A4
		public Action<int> CallbackOnClose { get; set; }
	}
}
