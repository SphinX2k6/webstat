using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005DB1 RID: 23985
	[NullableContext(1)]
	public interface IDreamLinkReachedData
	{
		// Token: 0x170098BA RID: 39098
		// (get) Token: 0x0603C64B RID: 247371
		// (set) Token: 0x0603C64C RID: 247372
		string Title { get; set; }

		// Token: 0x170098BB RID: 39099
		// (get) Token: 0x0603C64D RID: 247373
		// (set) Token: 0x0603C64E RID: 247374
		string Score { get; set; }

		// Token: 0x170098BC RID: 39100
		// (get) Token: 0x0603C64F RID: 247375
		// (set) Token: 0x0603C650 RID: 247376
		bool IsReached { get; set; }
	}
}
