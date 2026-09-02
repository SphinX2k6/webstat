using System;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A49 RID: 23113
	public interface IKurotatoSmallItemGridData
	{
		// Token: 0x1700952A RID: 38186
		// (get) Token: 0x0603A811 RID: 239633
		// (set) Token: 0x0603A812 RID: 239634
		EKurotatoCardType Type { get; set; }

		// Token: 0x1700952B RID: 38187
		// (get) Token: 0x0603A813 RID: 239635
		// (set) Token: 0x0603A814 RID: 239636
		int Id { get; set; }

		// Token: 0x1700952C RID: 38188
		// (get) Token: 0x0603A815 RID: 239637
		// (set) Token: 0x0603A816 RID: 239638
		int IncId { get; set; }

		// Token: 0x1700952D RID: 38189
		// (get) Token: 0x0603A817 RID: 239639
		// (set) Token: 0x0603A818 RID: 239640
		int Count { get; set; }

		// Token: 0x1700952E RID: 38190
		// (get) Token: 0x0603A819 RID: 239641
		// (set) Token: 0x0603A81A RID: 239642
		bool? PlayComposeFx { get; set; }

		// Token: 0x1700952F RID: 38191
		// (get) Token: 0x0603A81B RID: 239643
		// (set) Token: 0x0603A81C RID: 239644
		bool? ShowArrow { get; set; }

		// Token: 0x17009530 RID: 38192
		// (get) Token: 0x0603A81D RID: 239645
		// (set) Token: 0x0603A81E RID: 239646
		bool? IsReceived { get; set; }

		// Token: 0x17009531 RID: 38193
		// (get) Token: 0x0603A81F RID: 239647
		// (set) Token: 0x0603A820 RID: 239648
		bool? IsShowCount { get; set; }
	}
}
