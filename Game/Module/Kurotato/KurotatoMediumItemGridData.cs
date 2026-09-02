using System;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A4C RID: 23116
	public class KurotatoMediumItemGridData : IKurotatoMediumItemGridData
	{
		// Token: 0x1700953F RID: 38207
		// (get) Token: 0x0603A83C RID: 239676 RVA: 0x00ED2FCC File Offset: 0x00ED11CC
		// (set) Token: 0x0603A83D RID: 239677 RVA: 0x00ED2FD4 File Offset: 0x00ED11D4
		public EKurotatoCardType Type { get; set; }

		// Token: 0x17009540 RID: 38208
		// (get) Token: 0x0603A83E RID: 239678 RVA: 0x00ED2FDD File Offset: 0x00ED11DD
		// (set) Token: 0x0603A83F RID: 239679 RVA: 0x00ED2FE5 File Offset: 0x00ED11E5
		public int Id { get; set; }

		// Token: 0x17009541 RID: 38209
		// (get) Token: 0x0603A840 RID: 239680 RVA: 0x00ED2FEE File Offset: 0x00ED11EE
		// (set) Token: 0x0603A841 RID: 239681 RVA: 0x00ED2FF6 File Offset: 0x00ED11F6
		public int IncId { get; set; }

		// Token: 0x17009542 RID: 38210
		// (get) Token: 0x0603A842 RID: 239682 RVA: 0x00ED2FFF File Offset: 0x00ED11FF
		// (set) Token: 0x0603A843 RID: 239683 RVA: 0x00ED3007 File Offset: 0x00ED1207
		public int Count { get; set; }

		// Token: 0x17009543 RID: 38211
		// (get) Token: 0x0603A844 RID: 239684 RVA: 0x00ED3010 File Offset: 0x00ED1210
		// (set) Token: 0x0603A845 RID: 239685 RVA: 0x00ED3018 File Offset: 0x00ED1218
		public int? PreWaveDealtDamage { get; set; }
	}
}
