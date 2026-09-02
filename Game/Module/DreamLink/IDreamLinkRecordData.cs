using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005DB4 RID: 23988
	[NullableContext(1)]
	public interface IDreamLinkRecordData
	{
		// Token: 0x170098C0 RID: 39104
		// (get) Token: 0x0603C65B RID: 247387
		// (set) Token: 0x0603C65C RID: 247388
		string Title { get; set; }

		// Token: 0x170098C1 RID: 39105
		// (get) Token: 0x0603C65D RID: 247389
		// (set) Token: 0x0603C65E RID: 247390
		string Score { get; set; }

		// Token: 0x170098C2 RID: 39106
		// (get) Token: 0x0603C65F RID: 247391
		// (set) Token: 0x0603C660 RID: 247392
		bool IsNew { get; set; }
	}
}
