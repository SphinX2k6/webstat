using System;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A43 RID: 23107
	public interface IKurotatoShopSelectCardData
	{
		// Token: 0x17009512 RID: 38162
		// (get) Token: 0x0603A7DE RID: 239582
		// (set) Token: 0x0603A7DF RID: 239583
		int Id { get; set; }

		// Token: 0x17009513 RID: 38163
		// (get) Token: 0x0603A7E0 RID: 239584
		// (set) Token: 0x0603A7E1 RID: 239585
		int SelectionId { get; set; }

		// Token: 0x17009514 RID: 38164
		// (get) Token: 0x0603A7E2 RID: 239586
		// (set) Token: 0x0603A7E3 RID: 239587
		EKurotatoCardType CardType { get; set; }

		// Token: 0x17009515 RID: 38165
		// (get) Token: 0x0603A7E4 RID: 239588
		// (set) Token: 0x0603A7E5 RID: 239589
		int OriginalCost { get; set; }

		// Token: 0x17009516 RID: 38166
		// (get) Token: 0x0603A7E6 RID: 239590
		// (set) Token: 0x0603A7E7 RID: 239591
		int Cost { get; set; }

		// Token: 0x17009517 RID: 38167
		// (get) Token: 0x0603A7E8 RID: 239592
		// (set) Token: 0x0603A7E9 RID: 239593
		bool IsLock { get; set; }

		// Token: 0x17009518 RID: 38168
		// (get) Token: 0x0603A7EA RID: 239594
		// (set) Token: 0x0603A7EB RID: 239595
		bool HasBuy { get; set; }

		// Token: 0x17009519 RID: 38169
		// (get) Token: 0x0603A7EC RID: 239596
		// (set) Token: 0x0603A7ED RID: 239597
		bool IsRecommend { get; set; }
	}
}
