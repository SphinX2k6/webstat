using System;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x0200524C RID: 21068
	public class RogueBattleMapFetterInfo : IRogueBattleMapFetterInfo
	{
		// Token: 0x17008CD0 RID: 36048
		// (get) Token: 0x06035F0E RID: 220942 RVA: 0x00D920E4 File Offset: 0x00D902E4
		// (set) Token: 0x06035F0F RID: 220943 RVA: 0x00D920EC File Offset: 0x00D902EC
		public int ConfigId { get; set; }

		// Token: 0x17008CD1 RID: 36049
		// (get) Token: 0x06035F10 RID: 220944 RVA: 0x00D920F5 File Offset: 0x00D902F5
		// (set) Token: 0x06035F11 RID: 220945 RVA: 0x00D920FD File Offset: 0x00D902FD
		public int Level { get; set; }

		// Token: 0x17008CD2 RID: 36050
		// (get) Token: 0x06035F12 RID: 220946 RVA: 0x00D92106 File Offset: 0x00D90306
		// (set) Token: 0x06035F13 RID: 220947 RVA: 0x00D9210E File Offset: 0x00D9030E
		public bool IsReached { get; set; }
	}
}
