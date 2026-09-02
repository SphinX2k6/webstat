using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Common.Event
{
	// Token: 0x0200706F RID: 28783
	[NullableContext(1)]
	internal interface IEventSystemCacheKeyNode
	{
		// Token: 0x1700A594 RID: 42388
		// (get) Token: 0x06045B95 RID: 285589
		// (set) Token: 0x06045B96 RID: 285590
		object Key { get; set; }

		// Token: 0x1700A595 RID: 42389
		// (get) Token: 0x06045B97 RID: 285591
		// (set) Token: 0x06045B98 RID: 285592
		object Target { get; set; }

		// Token: 0x1700A596 RID: 42390
		// (get) Token: 0x06045B99 RID: 285593
		// (set) Token: 0x06045B9A RID: 285594
		Delegate Handle { get; set; }

		// Token: 0x1700A597 RID: 42391
		// (get) Token: 0x06045B9B RID: 285595
		// (set) Token: 0x06045B9C RID: 285596
		EEventName EventName { get; set; }
	}
}
