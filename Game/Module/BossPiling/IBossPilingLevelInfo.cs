using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BossPiling
{
	// Token: 0x02005EE3 RID: 24291
	[NullableContext(1)]
	public interface IBossPilingLevelInfo
	{
		// Token: 0x170099FA RID: 39418
		// (get) Token: 0x0603D09D RID: 250013
		// (set) Token: 0x0603D09E RID: 250014
		int Id { get; set; }

		// Token: 0x170099FB RID: 39419
		// (get) Token: 0x0603D09F RID: 250015
		// (set) Token: 0x0603D0A0 RID: 250016
		int UnlockTime { get; set; }

		// Token: 0x170099FC RID: 39420
		// (get) Token: 0x0603D0A1 RID: 250017
		// (set) Token: 0x0603D0A2 RID: 250018
		int BossHp { get; set; }

		// Token: 0x170099FD RID: 39421
		// (get) Token: 0x0603D0A3 RID: 250019
		// (set) Token: 0x0603D0A4 RID: 250020
		List<int> SelectedRoleIds { get; set; }

		// Token: 0x170099FE RID: 39422
		// (get) Token: 0x0603D0A5 RID: 250021
		// (set) Token: 0x0603D0A6 RID: 250022
		List<int> SelectedTagBranchIds { get; set; }

		// Token: 0x170099FF RID: 39423
		// (get) Token: 0x0603D0A7 RID: 250023
		// (set) Token: 0x0603D0A8 RID: 250024
		bool IsUnlock { get; set; }
	}
}
