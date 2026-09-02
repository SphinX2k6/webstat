using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x0200629E RID: 25246
	[NullableContext(1)]
	[Nullable(0)]
	public class TetrisSelectGroupData : ITetrisSelectGroupData
	{
		// Token: 0x17009C6B RID: 40043
		// (get) Token: 0x0603F89B RID: 260251 RVA: 0x01049305 File Offset: 0x01047505
		// (set) Token: 0x0603F89C RID: 260252 RVA: 0x0104930D File Offset: 0x0104750D
		public int GroupId { get; set; }

		// Token: 0x17009C6C RID: 40044
		// (get) Token: 0x0603F89D RID: 260253 RVA: 0x01049316 File Offset: 0x01047516
		// (set) Token: 0x0603F89E RID: 260254 RVA: 0x0104931E File Offset: 0x0104751E
		public List<int> ChallengeIds { get; set; }
	}
}
