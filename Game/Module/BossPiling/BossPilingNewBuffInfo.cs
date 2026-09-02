using System;

namespace CSharpScript.Game.Module.BossPiling
{
	// Token: 0x02005EF0 RID: 24304
	public class BossPilingNewBuffInfo : IBossPilingNewBuffInfo
	{
		// Token: 0x17009A26 RID: 39462
		// (get) Token: 0x0603D0FB RID: 250107 RVA: 0x00F8125A File Offset: 0x00F7F45A
		// (set) Token: 0x0603D0FC RID: 250108 RVA: 0x00F81262 File Offset: 0x00F7F462
		public int BuffId { get; set; }

		// Token: 0x17009A27 RID: 39463
		// (get) Token: 0x0603D0FD RID: 250109 RVA: 0x00F8126B File Offset: 0x00F7F46B
		// (set) Token: 0x0603D0FE RID: 250110 RVA: 0x00F81273 File Offset: 0x00F7F473
		public int OldValue { get; set; }

		// Token: 0x17009A28 RID: 39464
		// (get) Token: 0x0603D0FF RID: 250111 RVA: 0x00F8127C File Offset: 0x00F7F47C
		// (set) Token: 0x0603D100 RID: 250112 RVA: 0x00F81284 File Offset: 0x00F7F484
		public int NewValue { get; set; }

		// Token: 0x17009A29 RID: 39465
		// (get) Token: 0x0603D101 RID: 250113 RVA: 0x00F8128D File Offset: 0x00F7F48D
		// (set) Token: 0x0603D102 RID: 250114 RVA: 0x00F81295 File Offset: 0x00F7F495
		public bool NeedAccelerate { get; set; }
	}
}
