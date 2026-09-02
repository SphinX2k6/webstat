using System;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x0200523A RID: 21050
	public class RogueBattleElementInfo : IRogueBattleElementInfo
	{
		// Token: 0x17008CA0 RID: 36000
		// (get) Token: 0x06035EA6 RID: 220838 RVA: 0x00D91EF6 File Offset: 0x00D900F6
		// (set) Token: 0x06035EA7 RID: 220839 RVA: 0x00D91EFE File Offset: 0x00D900FE
		public int ElementId { get; set; }

		// Token: 0x17008CA1 RID: 36001
		// (get) Token: 0x06035EA8 RID: 220840 RVA: 0x00D91F07 File Offset: 0x00D90107
		// (set) Token: 0x06035EA9 RID: 220841 RVA: 0x00D91F0F File Offset: 0x00D9010F
		public int Count { get; set; }

		// Token: 0x17008CA2 RID: 36002
		// (get) Token: 0x06035EAA RID: 220842 RVA: 0x00D91F18 File Offset: 0x00D90118
		// (set) Token: 0x06035EAB RID: 220843 RVA: 0x00D91F20 File Offset: 0x00D90120
		public bool IsPreview { get; set; }
	}
}
