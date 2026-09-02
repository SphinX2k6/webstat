using System;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A3E RID: 23102
	public class KurotatoCardItemData : IKurotatoCardItemData
	{
		// Token: 0x17009500 RID: 38144
		// (get) Token: 0x0603A7B7 RID: 239543 RVA: 0x00ED2D63 File Offset: 0x00ED0F63
		// (set) Token: 0x0603A7B8 RID: 239544 RVA: 0x00ED2D6B File Offset: 0x00ED0F6B
		public int Id { get; set; }

		// Token: 0x17009501 RID: 38145
		// (get) Token: 0x0603A7B9 RID: 239545 RVA: 0x00ED2D74 File Offset: 0x00ED0F74
		// (set) Token: 0x0603A7BA RID: 239546 RVA: 0x00ED2D7C File Offset: 0x00ED0F7C
		public int SelectionId { get; set; }

		// Token: 0x17009502 RID: 38146
		// (get) Token: 0x0603A7BB RID: 239547 RVA: 0x00ED2D85 File Offset: 0x00ED0F85
		// (set) Token: 0x0603A7BC RID: 239548 RVA: 0x00ED2D8D File Offset: 0x00ED0F8D
		public int Cost { get; set; }

		// Token: 0x17009503 RID: 38147
		// (get) Token: 0x0603A7BD RID: 239549 RVA: 0x00ED2D96 File Offset: 0x00ED0F96
		// (set) Token: 0x0603A7BE RID: 239550 RVA: 0x00ED2D9E File Offset: 0x00ED0F9E
		public EKurotatoCardType CardType { get; set; }

		// Token: 0x17009504 RID: 38148
		// (get) Token: 0x0603A7BF RID: 239551 RVA: 0x00ED2DA7 File Offset: 0x00ED0FA7
		// (set) Token: 0x0603A7C0 RID: 239552 RVA: 0x00ED2DAF File Offset: 0x00ED0FAF
		public bool HasBuy { get; set; }

		// Token: 0x17009505 RID: 38149
		// (get) Token: 0x0603A7C1 RID: 239553 RVA: 0x00ED2DB8 File Offset: 0x00ED0FB8
		// (set) Token: 0x0603A7C2 RID: 239554 RVA: 0x00ED2DC0 File Offset: 0x00ED0FC0
		public bool IsRecommend { get; set; }

		// Token: 0x17009506 RID: 38150
		// (get) Token: 0x0603A7C3 RID: 239555 RVA: 0x00ED2DC9 File Offset: 0x00ED0FC9
		// (set) Token: 0x0603A7C4 RID: 239556 RVA: 0x00ED2DD1 File Offset: 0x00ED0FD1
		public bool HasLock { get; set; }

		// Token: 0x17009507 RID: 38151
		// (get) Token: 0x0603A7C5 RID: 239557 RVA: 0x00ED2DDA File Offset: 0x00ED0FDA
		// (set) Token: 0x0603A7C6 RID: 239558 RVA: 0x00ED2DE2 File Offset: 0x00ED0FE2
		public bool ShowLock { get; set; }
	}
}
