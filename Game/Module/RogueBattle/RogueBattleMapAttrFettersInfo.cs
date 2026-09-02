using System;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005244 RID: 21060
	public class RogueBattleMapAttrFettersInfo : IRogueBattleMapAttrFettersInfo
	{
		// Token: 0x17008CB9 RID: 36025
		// (get) Token: 0x06035EDC RID: 220892 RVA: 0x00D91FE2 File Offset: 0x00D901E2
		// (set) Token: 0x06035EDD RID: 220893 RVA: 0x00D91FEA File Offset: 0x00D901EA
		public int ConfigId { get; set; }

		// Token: 0x17008CBA RID: 36026
		// (get) Token: 0x06035EDE RID: 220894 RVA: 0x00D91FF3 File Offset: 0x00D901F3
		// (set) Token: 0x06035EDF RID: 220895 RVA: 0x00D91FFB File Offset: 0x00D901FB
		public bool IsUnlock { get; set; }

		// Token: 0x17008CBB RID: 36027
		// (get) Token: 0x06035EE0 RID: 220896 RVA: 0x00D92004 File Offset: 0x00D90204
		// (set) Token: 0x06035EE1 RID: 220897 RVA: 0x00D9200C File Offset: 0x00D9020C
		public int Level { get; set; }

		// Token: 0x17008CBC RID: 36028
		// (get) Token: 0x06035EE2 RID: 220898 RVA: 0x00D92015 File Offset: 0x00D90215
		// (set) Token: 0x06035EE3 RID: 220899 RVA: 0x00D9201D File Offset: 0x00D9021D
		public bool? IsMaxLevel { get; set; }
	}
}
