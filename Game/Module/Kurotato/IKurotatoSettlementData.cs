using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A62 RID: 23138
	[NullableContext(1)]
	public interface IKurotatoSettlementData
	{
		// Token: 0x17009568 RID: 38248
		// (get) Token: 0x0603A895 RID: 239765
		// (set) Token: 0x0603A896 RID: 239766
		bool IsPass { get; set; }

		// Token: 0x17009569 RID: 38249
		// (get) Token: 0x0603A897 RID: 239767
		// (set) Token: 0x0603A898 RID: 239768
		long CompletionTime { get; set; }

		// Token: 0x1700956A RID: 38250
		// (get) Token: 0x0603A899 RID: 239769
		// (set) Token: 0x0603A89A RID: 239770
		List<KurotatoItemData> ItemPanelData { get; set; }

		// Token: 0x1700956B RID: 38251
		// (get) Token: 0x0603A89B RID: 239771
		// (set) Token: 0x0603A89C RID: 239772
		List<KurotatoWeaponData> WeaponPanelData { get; set; }

		// Token: 0x1700956C RID: 38252
		// (get) Token: 0x0603A89D RID: 239773
		// (set) Token: 0x0603A89E RID: 239774
		int PassWaveCount { get; set; }

		// Token: 0x1700956D RID: 38253
		// (get) Token: 0x0603A89F RID: 239775
		// (set) Token: 0x0603A8A0 RID: 239776
		int CumulativeKills { get; set; }

		// Token: 0x1700956E RID: 38254
		// (get) Token: 0x0603A8A1 RID: 239777
		// (set) Token: 0x0603A8A2 RID: 239778
		Dictionary<int, int> PropertyMap { get; set; }

		// Token: 0x1700956F RID: 38255
		// (get) Token: 0x0603A8A3 RID: 239779
		// (set) Token: 0x0603A8A4 RID: 239780
		List<int> UnlockWeapons { get; set; }

		// Token: 0x17009570 RID: 38256
		// (get) Token: 0x0603A8A5 RID: 239781
		// (set) Token: 0x0603A8A6 RID: 239782
		List<int> UnlockItems { get; set; }

		// Token: 0x17009571 RID: 38257
		// (get) Token: 0x0603A8A7 RID: 239783
		// (set) Token: 0x0603A8A8 RID: 239784
		List<int> UnlockRoles { get; set; }
	}
}
