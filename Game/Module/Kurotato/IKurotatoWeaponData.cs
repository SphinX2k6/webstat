using System;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A37 RID: 23095
	public interface IKurotatoWeaponData
	{
		// Token: 0x170094DE RID: 38110
		// (get) Token: 0x0603A770 RID: 239472
		// (set) Token: 0x0603A771 RID: 239473
		int WeaponId { get; set; }

		// Token: 0x170094DF RID: 38111
		// (get) Token: 0x0603A772 RID: 239474
		// (set) Token: 0x0603A773 RID: 239475
		int IncId { get; set; }

		// Token: 0x170094E0 RID: 38112
		// (get) Token: 0x0603A774 RID: 239476
		// (set) Token: 0x0603A775 RID: 239477
		int SellPrice { get; set; }

		// Token: 0x170094E1 RID: 38113
		// (get) Token: 0x0603A776 RID: 239478
		// (set) Token: 0x0603A777 RID: 239479
		int PreWaveDealtDamage { get; set; }
	}
}
