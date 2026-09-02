using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BossPiling
{
	// Token: 0x02005EE4 RID: 24292
	[NullableContext(1)]
	[Nullable(0)]
	public class BossPilingLevelInfo : IBossPilingLevelInfo
	{
		// Token: 0x17009A00 RID: 39424
		// (get) Token: 0x0603D0A9 RID: 250025 RVA: 0x00F810D6 File Offset: 0x00F7F2D6
		// (set) Token: 0x0603D0AA RID: 250026 RVA: 0x00F810DE File Offset: 0x00F7F2DE
		public int Id { get; set; }

		// Token: 0x17009A01 RID: 39425
		// (get) Token: 0x0603D0AB RID: 250027 RVA: 0x00F810E7 File Offset: 0x00F7F2E7
		// (set) Token: 0x0603D0AC RID: 250028 RVA: 0x00F810EF File Offset: 0x00F7F2EF
		public int UnlockTime { get; set; }

		// Token: 0x17009A02 RID: 39426
		// (get) Token: 0x0603D0AD RID: 250029 RVA: 0x00F810F8 File Offset: 0x00F7F2F8
		// (set) Token: 0x0603D0AE RID: 250030 RVA: 0x00F81100 File Offset: 0x00F7F300
		public int BossHp { get; set; }

		// Token: 0x17009A03 RID: 39427
		// (get) Token: 0x0603D0AF RID: 250031 RVA: 0x00F81109 File Offset: 0x00F7F309
		// (set) Token: 0x0603D0B0 RID: 250032 RVA: 0x00F81111 File Offset: 0x00F7F311
		public List<int> SelectedRoleIds { get; set; }

		// Token: 0x17009A04 RID: 39428
		// (get) Token: 0x0603D0B1 RID: 250033 RVA: 0x00F8111A File Offset: 0x00F7F31A
		// (set) Token: 0x0603D0B2 RID: 250034 RVA: 0x00F81122 File Offset: 0x00F7F322
		public List<int> SelectedTagBranchIds { get; set; }

		// Token: 0x17009A05 RID: 39429
		// (get) Token: 0x0603D0B3 RID: 250035 RVA: 0x00F8112B File Offset: 0x00F7F32B
		// (set) Token: 0x0603D0B4 RID: 250036 RVA: 0x00F81133 File Offset: 0x00F7F333
		public bool IsUnlock { get; set; }
	}
}
