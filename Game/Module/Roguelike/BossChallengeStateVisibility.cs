using System;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200513B RID: 20795
	public class BossChallengeStateVisibility : IBossChallengeStateVisibility
	{
		// Token: 0x17008C74 RID: 35956
		// (get) Token: 0x06035885 RID: 219269 RVA: 0x00D70582 File Offset: 0x00D6E782
		// (set) Token: 0x06035886 RID: 219270 RVA: 0x00D7058A File Offset: 0x00D6E78A
		public bool ShowUnlock { get; set; }

		// Token: 0x17008C75 RID: 35957
		// (get) Token: 0x06035887 RID: 219271 RVA: 0x00D70593 File Offset: 0x00D6E793
		// (set) Token: 0x06035888 RID: 219272 RVA: 0x00D7059B File Offset: 0x00D6E79B
		public bool ShowEmptyIcon { get; set; }

		// Token: 0x17008C76 RID: 35958
		// (get) Token: 0x06035889 RID: 219273 RVA: 0x00D705A4 File Offset: 0x00D6E7A4
		// (set) Token: 0x0603588A RID: 219274 RVA: 0x00D705AC File Offset: 0x00D6E7AC
		public bool ShowFinished { get; set; }
	}
}
