using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005DB2 RID: 23986
	[NullableContext(1)]
	[Nullable(0)]
	public class DreamLinkReachedData : IDreamLinkReachedData
	{
		// Token: 0x170098BD RID: 39101
		// (get) Token: 0x0603C651 RID: 247377 RVA: 0x00F5494E File Offset: 0x00F52B4E
		// (set) Token: 0x0603C652 RID: 247378 RVA: 0x00F54956 File Offset: 0x00F52B56
		public string Title { get; set; }

		// Token: 0x170098BE RID: 39102
		// (get) Token: 0x0603C653 RID: 247379 RVA: 0x00F5495F File Offset: 0x00F52B5F
		// (set) Token: 0x0603C654 RID: 247380 RVA: 0x00F54967 File Offset: 0x00F52B67
		public string Score { get; set; }

		// Token: 0x170098BF RID: 39103
		// (get) Token: 0x0603C655 RID: 247381 RVA: 0x00F54970 File Offset: 0x00F52B70
		// (set) Token: 0x0603C656 RID: 247382 RVA: 0x00F54978 File Offset: 0x00F52B78
		public bool IsReached { get; set; }
	}
}
