using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005DB5 RID: 23989
	[NullableContext(1)]
	[Nullable(0)]
	public class DreamLinkRecordData : IDreamLinkRecordData
	{
		// Token: 0x170098C3 RID: 39107
		// (get) Token: 0x0603C661 RID: 247393 RVA: 0x00F54A4F File Offset: 0x00F52C4F
		// (set) Token: 0x0603C662 RID: 247394 RVA: 0x00F54A57 File Offset: 0x00F52C57
		public string Title { get; set; }

		// Token: 0x170098C4 RID: 39108
		// (get) Token: 0x0603C663 RID: 247395 RVA: 0x00F54A60 File Offset: 0x00F52C60
		// (set) Token: 0x0603C664 RID: 247396 RVA: 0x00F54A68 File Offset: 0x00F52C68
		public string Score { get; set; }

		// Token: 0x170098C5 RID: 39109
		// (get) Token: 0x0603C665 RID: 247397 RVA: 0x00F54A71 File Offset: 0x00F52C71
		// (set) Token: 0x0603C666 RID: 247398 RVA: 0x00F54A79 File Offset: 0x00F52C79
		public bool IsNew { get; set; }
	}
}
