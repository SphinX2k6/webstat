using System;

namespace CSharpScript.Game.LevelGamePlay.ResetPlayer
{
	// Token: 0x02006B2A RID: 27434
	public class IActionResetReplyData
	{
		// Token: 0x1700A309 RID: 41737
		// (get) Token: 0x06043C8F RID: 277647 RVA: 0x011831D9 File Offset: 0x011813D9
		// (set) Token: 0x06043C90 RID: 277648 RVA: 0x011831E1 File Offset: 0x011813E1
		public int PlayerId { get; set; }

		// Token: 0x1700A30A RID: 41738
		// (get) Token: 0x06043C91 RID: 277649 RVA: 0x011831EA File Offset: 0x011813EA
		// (set) Token: 0x06043C92 RID: 277650 RVA: 0x011831F2 File Offset: 0x011813F2
		public int IncId { get; set; }

		// Token: 0x1700A30B RID: 41739
		// (get) Token: 0x06043C93 RID: 277651 RVA: 0x011831FB File Offset: 0x011813FB
		// (set) Token: 0x06043C94 RID: 277652 RVA: 0x01183203 File Offset: 0x01181403
		public int Index { get; set; }
	}
}
