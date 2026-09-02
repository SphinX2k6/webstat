using System;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005246 RID: 21062
	public class RogueBattleMapRoleGridInfo : IRogueBattleMapRoleGridInfo
	{
		// Token: 0x17008CC0 RID: 36032
		// (get) Token: 0x06035EEB RID: 220907 RVA: 0x00D9202E File Offset: 0x00D9022E
		// (set) Token: 0x06035EEC RID: 220908 RVA: 0x00D92036 File Offset: 0x00D90236
		public int ConfigId { get; set; }

		// Token: 0x17008CC1 RID: 36033
		// (get) Token: 0x06035EED RID: 220909 RVA: 0x00D9203F File Offset: 0x00D9023F
		// (set) Token: 0x06035EEE RID: 220910 RVA: 0x00D92047 File Offset: 0x00D90247
		public bool IsGain { get; set; }

		// Token: 0x17008CC2 RID: 36034
		// (get) Token: 0x06035EEF RID: 220911 RVA: 0x00D92050 File Offset: 0x00D90250
		// (set) Token: 0x06035EF0 RID: 220912 RVA: 0x00D92058 File Offset: 0x00D90258
		public bool NeedLevel { get; set; }
	}
}
