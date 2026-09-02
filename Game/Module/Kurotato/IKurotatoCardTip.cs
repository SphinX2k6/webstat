using System;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A4F RID: 23119
	public interface IKurotatoCardTip
	{
		// Token: 0x1700954C RID: 38220
		// (get) Token: 0x0603A858 RID: 239704
		// (set) Token: 0x0603A859 RID: 239705
		EKurotatoCardType CardType { get; set; }

		// Token: 0x1700954D RID: 38221
		// (get) Token: 0x0603A85A RID: 239706
		// (set) Token: 0x0603A85B RID: 239707
		int SelectId { get; set; }

		// Token: 0x1700954E RID: 38222
		// (get) Token: 0x0603A85C RID: 239708
		// (set) Token: 0x0603A85D RID: 239709
		bool? IsConfigId { get; set; }
	}
}
