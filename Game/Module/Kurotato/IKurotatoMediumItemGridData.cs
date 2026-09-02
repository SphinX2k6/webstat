using System;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A4B RID: 23115
	public interface IKurotatoMediumItemGridData
	{
		// Token: 0x1700953A RID: 38202
		// (get) Token: 0x0603A832 RID: 239666
		// (set) Token: 0x0603A833 RID: 239667
		EKurotatoCardType Type { get; set; }

		// Token: 0x1700953B RID: 38203
		// (get) Token: 0x0603A834 RID: 239668
		// (set) Token: 0x0603A835 RID: 239669
		int Id { get; set; }

		// Token: 0x1700953C RID: 38204
		// (get) Token: 0x0603A836 RID: 239670
		// (set) Token: 0x0603A837 RID: 239671
		int IncId { get; set; }

		// Token: 0x1700953D RID: 38205
		// (get) Token: 0x0603A838 RID: 239672
		// (set) Token: 0x0603A839 RID: 239673
		int Count { get; set; }

		// Token: 0x1700953E RID: 38206
		// (get) Token: 0x0603A83A RID: 239674
		// (set) Token: 0x0603A83B RID: 239675
		int? PreWaveDealtDamage { get; set; }
	}
}
