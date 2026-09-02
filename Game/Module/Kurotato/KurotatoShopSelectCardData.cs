using System;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A44 RID: 23108
	public class KurotatoShopSelectCardData : IKurotatoShopSelectCardData
	{
		// Token: 0x1700951A RID: 38170
		// (get) Token: 0x0603A7EE RID: 239598 RVA: 0x00ED2E58 File Offset: 0x00ED1058
		// (set) Token: 0x0603A7EF RID: 239599 RVA: 0x00ED2E60 File Offset: 0x00ED1060
		public int Id { get; set; }

		// Token: 0x1700951B RID: 38171
		// (get) Token: 0x0603A7F0 RID: 239600 RVA: 0x00ED2E69 File Offset: 0x00ED1069
		// (set) Token: 0x0603A7F1 RID: 239601 RVA: 0x00ED2E71 File Offset: 0x00ED1071
		public int SelectionId { get; set; }

		// Token: 0x1700951C RID: 38172
		// (get) Token: 0x0603A7F2 RID: 239602 RVA: 0x00ED2E7A File Offset: 0x00ED107A
		// (set) Token: 0x0603A7F3 RID: 239603 RVA: 0x00ED2E82 File Offset: 0x00ED1082
		public EKurotatoCardType CardType { get; set; }

		// Token: 0x1700951D RID: 38173
		// (get) Token: 0x0603A7F4 RID: 239604 RVA: 0x00ED2E8B File Offset: 0x00ED108B
		// (set) Token: 0x0603A7F5 RID: 239605 RVA: 0x00ED2E93 File Offset: 0x00ED1093
		public int OriginalCost { get; set; }

		// Token: 0x1700951E RID: 38174
		// (get) Token: 0x0603A7F6 RID: 239606 RVA: 0x00ED2E9C File Offset: 0x00ED109C
		// (set) Token: 0x0603A7F7 RID: 239607 RVA: 0x00ED2EA4 File Offset: 0x00ED10A4
		public int Cost { get; set; }

		// Token: 0x1700951F RID: 38175
		// (get) Token: 0x0603A7F8 RID: 239608 RVA: 0x00ED2EAD File Offset: 0x00ED10AD
		// (set) Token: 0x0603A7F9 RID: 239609 RVA: 0x00ED2EB5 File Offset: 0x00ED10B5
		public bool IsLock { get; set; }

		// Token: 0x17009520 RID: 38176
		// (get) Token: 0x0603A7FA RID: 239610 RVA: 0x00ED2EBE File Offset: 0x00ED10BE
		// (set) Token: 0x0603A7FB RID: 239611 RVA: 0x00ED2EC6 File Offset: 0x00ED10C6
		public bool HasBuy { get; set; }

		// Token: 0x17009521 RID: 38177
		// (get) Token: 0x0603A7FC RID: 239612 RVA: 0x00ED2ECF File Offset: 0x00ED10CF
		// (set) Token: 0x0603A7FD RID: 239613 RVA: 0x00ED2ED7 File Offset: 0x00ED10D7
		public bool IsRecommend { get; set; }
	}
}
