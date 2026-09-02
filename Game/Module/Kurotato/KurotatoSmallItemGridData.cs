using System;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A4A RID: 23114
	public class KurotatoSmallItemGridData : IKurotatoSmallItemGridData
	{
		// Token: 0x17009532 RID: 38194
		// (get) Token: 0x0603A821 RID: 239649 RVA: 0x00ED2F3C File Offset: 0x00ED113C
		// (set) Token: 0x0603A822 RID: 239650 RVA: 0x00ED2F44 File Offset: 0x00ED1144
		public EKurotatoCardType Type { get; set; }

		// Token: 0x17009533 RID: 38195
		// (get) Token: 0x0603A823 RID: 239651 RVA: 0x00ED2F4D File Offset: 0x00ED114D
		// (set) Token: 0x0603A824 RID: 239652 RVA: 0x00ED2F55 File Offset: 0x00ED1155
		public int Id { get; set; }

		// Token: 0x17009534 RID: 38196
		// (get) Token: 0x0603A825 RID: 239653 RVA: 0x00ED2F5E File Offset: 0x00ED115E
		// (set) Token: 0x0603A826 RID: 239654 RVA: 0x00ED2F66 File Offset: 0x00ED1166
		public int IncId { get; set; }

		// Token: 0x17009535 RID: 38197
		// (get) Token: 0x0603A827 RID: 239655 RVA: 0x00ED2F6F File Offset: 0x00ED116F
		// (set) Token: 0x0603A828 RID: 239656 RVA: 0x00ED2F77 File Offset: 0x00ED1177
		public int Count { get; set; }

		// Token: 0x17009536 RID: 38198
		// (get) Token: 0x0603A829 RID: 239657 RVA: 0x00ED2F80 File Offset: 0x00ED1180
		// (set) Token: 0x0603A82A RID: 239658 RVA: 0x00ED2F88 File Offset: 0x00ED1188
		public bool? PlayComposeFx { get; set; }

		// Token: 0x17009537 RID: 38199
		// (get) Token: 0x0603A82B RID: 239659 RVA: 0x00ED2F91 File Offset: 0x00ED1191
		// (set) Token: 0x0603A82C RID: 239660 RVA: 0x00ED2F99 File Offset: 0x00ED1199
		public bool? ShowArrow { get; set; }

		// Token: 0x17009538 RID: 38200
		// (get) Token: 0x0603A82D RID: 239661 RVA: 0x00ED2FA2 File Offset: 0x00ED11A2
		// (set) Token: 0x0603A82E RID: 239662 RVA: 0x00ED2FAA File Offset: 0x00ED11AA
		public bool? IsReceived { get; set; }

		// Token: 0x17009539 RID: 38201
		// (get) Token: 0x0603A82F RID: 239663 RVA: 0x00ED2FB3 File Offset: 0x00ED11B3
		// (set) Token: 0x0603A830 RID: 239664 RVA: 0x00ED2FBB File Offset: 0x00ED11BB
		public bool? IsShowCount { get; set; }
	}
}
