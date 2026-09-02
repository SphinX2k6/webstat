using System;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005111 RID: 20753
	public class PhantomSelectItemData : IPhantomSelectItemData
	{
		// Token: 0x17008C58 RID: 35928
		// (get) Token: 0x06035772 RID: 218994 RVA: 0x00D6B37E File Offset: 0x00D6957E
		// (set) Token: 0x06035773 RID: 218995 RVA: 0x00D6B386 File Offset: 0x00D69586
		public int PhantomId { get; set; }

		// Token: 0x17008C59 RID: 35929
		// (get) Token: 0x06035774 RID: 218996 RVA: 0x00D6B38F File Offset: 0x00D6958F
		// (set) Token: 0x06035775 RID: 218997 RVA: 0x00D6B397 File Offset: 0x00D69597
		public int Index { get; set; }

		// Token: 0x17008C5A RID: 35930
		// (get) Token: 0x06035776 RID: 218998 RVA: 0x00D6B3A0 File Offset: 0x00D695A0
		// (set) Token: 0x06035777 RID: 218999 RVA: 0x00D6B3A8 File Offset: 0x00D695A8
		public bool IsLock { get; set; }
	}
}
