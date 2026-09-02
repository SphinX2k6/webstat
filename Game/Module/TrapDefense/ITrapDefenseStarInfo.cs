using System;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E21 RID: 20001
	public class ITrapDefenseStarInfo
	{
		// Token: 0x170088C3 RID: 35011
		// (get) Token: 0x06033B69 RID: 211817 RVA: 0x00CECF0D File Offset: 0x00CEB10D
		// (set) Token: 0x06033B6A RID: 211818 RVA: 0x00CECF15 File Offset: 0x00CEB115
		public bool IsAchieve { get; set; }

		// Token: 0x170088C4 RID: 35012
		// (get) Token: 0x06033B6B RID: 211819 RVA: 0x00CECF1E File Offset: 0x00CEB11E
		// (set) Token: 0x06033B6C RID: 211820 RVA: 0x00CECF26 File Offset: 0x00CEB126
		public bool IsNew { get; set; }

		// Token: 0x170088C5 RID: 35013
		// (get) Token: 0x06033B6D RID: 211821 RVA: 0x00CECF2F File Offset: 0x00CEB12F
		// (set) Token: 0x06033B6E RID: 211822 RVA: 0x00CECF37 File Offset: 0x00CEB137
		public bool HasPlayed { get; set; }

		// Token: 0x170088C6 RID: 35014
		// (get) Token: 0x06033B6F RID: 211823 RVA: 0x00CECF40 File Offset: 0x00CEB140
		// (set) Token: 0x06033B70 RID: 211824 RVA: 0x00CECF48 File Offset: 0x00CEB148
		public int PlayDelay { get; set; }
	}
}
