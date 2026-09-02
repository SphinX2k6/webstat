using System;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A3D RID: 23101
	public interface IKurotatoCardItemData
	{
		// Token: 0x170094F8 RID: 38136
		// (get) Token: 0x0603A7A7 RID: 239527
		// (set) Token: 0x0603A7A8 RID: 239528
		int Id { get; set; }

		// Token: 0x170094F9 RID: 38137
		// (get) Token: 0x0603A7A9 RID: 239529
		// (set) Token: 0x0603A7AA RID: 239530
		int SelectionId { get; set; }

		// Token: 0x170094FA RID: 38138
		// (get) Token: 0x0603A7AB RID: 239531
		// (set) Token: 0x0603A7AC RID: 239532
		int Cost { get; set; }

		// Token: 0x170094FB RID: 38139
		// (get) Token: 0x0603A7AD RID: 239533
		// (set) Token: 0x0603A7AE RID: 239534
		EKurotatoCardType CardType { get; set; }

		// Token: 0x170094FC RID: 38140
		// (get) Token: 0x0603A7AF RID: 239535
		// (set) Token: 0x0603A7B0 RID: 239536
		bool HasBuy { get; set; }

		// Token: 0x170094FD RID: 38141
		// (get) Token: 0x0603A7B1 RID: 239537
		// (set) Token: 0x0603A7B2 RID: 239538
		bool IsRecommend { get; set; }

		// Token: 0x170094FE RID: 38142
		// (get) Token: 0x0603A7B3 RID: 239539
		// (set) Token: 0x0603A7B4 RID: 239540
		bool HasLock { get; set; }

		// Token: 0x170094FF RID: 38143
		// (get) Token: 0x0603A7B5 RID: 239541
		// (set) Token: 0x0603A7B6 RID: 239542
		bool ShowLock { get; set; }
	}
}
