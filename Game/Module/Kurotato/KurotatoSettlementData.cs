using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A63 RID: 23139
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoSettlementData : IKurotatoSettlementData
	{
		// Token: 0x17009572 RID: 38258
		// (get) Token: 0x0603A8A9 RID: 239785 RVA: 0x00ED318B File Offset: 0x00ED138B
		// (set) Token: 0x0603A8AA RID: 239786 RVA: 0x00ED3193 File Offset: 0x00ED1393
		public bool IsPass { get; set; }

		// Token: 0x17009573 RID: 38259
		// (get) Token: 0x0603A8AB RID: 239787 RVA: 0x00ED319C File Offset: 0x00ED139C
		// (set) Token: 0x0603A8AC RID: 239788 RVA: 0x00ED31A4 File Offset: 0x00ED13A4
		public long CompletionTime { get; set; }

		// Token: 0x17009574 RID: 38260
		// (get) Token: 0x0603A8AD RID: 239789 RVA: 0x00ED31AD File Offset: 0x00ED13AD
		// (set) Token: 0x0603A8AE RID: 239790 RVA: 0x00ED31B5 File Offset: 0x00ED13B5
		public List<KurotatoItemData> ItemPanelData { get; set; }

		// Token: 0x17009575 RID: 38261
		// (get) Token: 0x0603A8AF RID: 239791 RVA: 0x00ED31BE File Offset: 0x00ED13BE
		// (set) Token: 0x0603A8B0 RID: 239792 RVA: 0x00ED31C6 File Offset: 0x00ED13C6
		public List<KurotatoWeaponData> WeaponPanelData { get; set; }

		// Token: 0x17009576 RID: 38262
		// (get) Token: 0x0603A8B1 RID: 239793 RVA: 0x00ED31CF File Offset: 0x00ED13CF
		// (set) Token: 0x0603A8B2 RID: 239794 RVA: 0x00ED31D7 File Offset: 0x00ED13D7
		public int PassWaveCount { get; set; }

		// Token: 0x17009577 RID: 38263
		// (get) Token: 0x0603A8B3 RID: 239795 RVA: 0x00ED31E0 File Offset: 0x00ED13E0
		// (set) Token: 0x0603A8B4 RID: 239796 RVA: 0x00ED31E8 File Offset: 0x00ED13E8
		public int CumulativeKills { get; set; }

		// Token: 0x17009578 RID: 38264
		// (get) Token: 0x0603A8B5 RID: 239797 RVA: 0x00ED31F1 File Offset: 0x00ED13F1
		// (set) Token: 0x0603A8B6 RID: 239798 RVA: 0x00ED31F9 File Offset: 0x00ED13F9
		public Dictionary<int, int> PropertyMap { get; set; }

		// Token: 0x17009579 RID: 38265
		// (get) Token: 0x0603A8B7 RID: 239799 RVA: 0x00ED3202 File Offset: 0x00ED1402
		// (set) Token: 0x0603A8B8 RID: 239800 RVA: 0x00ED320A File Offset: 0x00ED140A
		public List<int> UnlockWeapons { get; set; }

		// Token: 0x1700957A RID: 38266
		// (get) Token: 0x0603A8B9 RID: 239801 RVA: 0x00ED3213 File Offset: 0x00ED1413
		// (set) Token: 0x0603A8BA RID: 239802 RVA: 0x00ED321B File Offset: 0x00ED141B
		public List<int> UnlockItems { get; set; }

		// Token: 0x1700957B RID: 38267
		// (get) Token: 0x0603A8BB RID: 239803 RVA: 0x00ED3224 File Offset: 0x00ED1424
		// (set) Token: 0x0603A8BC RID: 239804 RVA: 0x00ED322C File Offset: 0x00ED142C
		public List<int> UnlockRoles { get; set; }
	}
}
