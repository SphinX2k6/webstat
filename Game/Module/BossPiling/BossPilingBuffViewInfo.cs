using System;

namespace CSharpScript.Game.Module.BossPiling
{
	// Token: 0x02005EEA RID: 24298
	public class BossPilingBuffViewInfo : IBossPilingBuffViewInfo
	{
		// Token: 0x17009A18 RID: 39448
		// (get) Token: 0x0603D0DC RID: 250076 RVA: 0x00F811DC File Offset: 0x00F7F3DC
		// (set) Token: 0x0603D0DD RID: 250077 RVA: 0x00F811E4 File Offset: 0x00F7F3E4
		public int LevelId { get; set; }

		// Token: 0x17009A19 RID: 39449
		// (get) Token: 0x0603D0DE RID: 250078 RVA: 0x00F811ED File Offset: 0x00F7F3ED
		// (set) Token: 0x0603D0DF RID: 250079 RVA: 0x00F811F5 File Offset: 0x00F7F3F5
		public bool InGame { get; set; }
	}
}
