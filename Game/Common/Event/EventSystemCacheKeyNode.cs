using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Common.Event
{
	// Token: 0x02007070 RID: 28784
	[NullableContext(1)]
	[Nullable(0)]
	internal class EventSystemCacheKeyNode : IEventSystemCacheKeyNode
	{
		// Token: 0x1700A598 RID: 42392
		// (get) Token: 0x06045B9D RID: 285597 RVA: 0x0123ED88 File Offset: 0x0123CF88
		// (set) Token: 0x06045B9E RID: 285598 RVA: 0x0123ED90 File Offset: 0x0123CF90
		public object Key { get; set; }

		// Token: 0x1700A599 RID: 42393
		// (get) Token: 0x06045B9F RID: 285599 RVA: 0x0123ED99 File Offset: 0x0123CF99
		// (set) Token: 0x06045BA0 RID: 285600 RVA: 0x0123EDA1 File Offset: 0x0123CFA1
		public object Target { get; set; }

		// Token: 0x1700A59A RID: 42394
		// (get) Token: 0x06045BA1 RID: 285601 RVA: 0x0123EDAA File Offset: 0x0123CFAA
		// (set) Token: 0x06045BA2 RID: 285602 RVA: 0x0123EDB2 File Offset: 0x0123CFB2
		public Delegate Handle { get; set; }

		// Token: 0x1700A59B RID: 42395
		// (get) Token: 0x06045BA3 RID: 285603 RVA: 0x0123EDBB File Offset: 0x0123CFBB
		// (set) Token: 0x06045BA4 RID: 285604 RVA: 0x0123EDC3 File Offset: 0x0123CFC3
		public EEventName EventName { get; set; }
	}
}
