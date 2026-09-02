using System;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A38 RID: 23096
	public class KurotatoWeaponData : IKurotatoWeaponData
	{
		// Token: 0x170094E2 RID: 38114
		// (get) Token: 0x0603A778 RID: 239480 RVA: 0x00ED2C6E File Offset: 0x00ED0E6E
		// (set) Token: 0x0603A779 RID: 239481 RVA: 0x00ED2C76 File Offset: 0x00ED0E76
		public int WeaponId { get; set; }

		// Token: 0x170094E3 RID: 38115
		// (get) Token: 0x0603A77A RID: 239482 RVA: 0x00ED2C7F File Offset: 0x00ED0E7F
		// (set) Token: 0x0603A77B RID: 239483 RVA: 0x00ED2C87 File Offset: 0x00ED0E87
		public int IncId { get; set; }

		// Token: 0x170094E4 RID: 38116
		// (get) Token: 0x0603A77C RID: 239484 RVA: 0x00ED2C90 File Offset: 0x00ED0E90
		// (set) Token: 0x0603A77D RID: 239485 RVA: 0x00ED2C98 File Offset: 0x00ED0E98
		public int SellPrice { get; set; }

		// Token: 0x170094E5 RID: 38117
		// (get) Token: 0x0603A77E RID: 239486 RVA: 0x00ED2CA1 File Offset: 0x00ED0EA1
		// (set) Token: 0x0603A77F RID: 239487 RVA: 0x00ED2CA9 File Offset: 0x00ED0EA9
		public int PreWaveDealtDamage { get; set; }
	}
}
