using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x02006210 RID: 25104
	[NullableContext(1)]
	[Nullable(0)]
	public class WheelTowerPopupData : IWheelTowerPopupData
	{
		// Token: 0x17009BAC RID: 39852
		// (get) Token: 0x0603F556 RID: 259414 RVA: 0x0103E974 File Offset: 0x0103CB74
		// (set) Token: 0x0603F557 RID: 259415 RVA: 0x0103E97C File Offset: 0x0103CB7C
		public int TotalScore { get; set; }

		// Token: 0x17009BAD RID: 39853
		// (get) Token: 0x0603F558 RID: 259416 RVA: 0x0103E985 File Offset: 0x0103CB85
		// (set) Token: 0x0603F559 RID: 259417 RVA: 0x0103E98D File Offset: 0x0103CB8D
		public int RoundScore { get; set; }

		// Token: 0x17009BAE RID: 39854
		// (get) Token: 0x0603F55A RID: 259418 RVA: 0x0103E996 File Offset: 0x0103CB96
		// (set) Token: 0x0603F55B RID: 259419 RVA: 0x0103E99E File Offset: 0x0103CB9E
		public int ScoreRecord { get; set; }

		// Token: 0x17009BAF RID: 39855
		// (get) Token: 0x0603F55C RID: 259420 RVA: 0x0103E9A7 File Offset: 0x0103CBA7
		// (set) Token: 0x0603F55D RID: 259421 RVA: 0x0103E9AF File Offset: 0x0103CBAF
		public List<int> TeamRoleIdList { get; set; } = new List<int>();

		// Token: 0x17009BB0 RID: 39856
		// (get) Token: 0x0603F55E RID: 259422 RVA: 0x0103E9B8 File Offset: 0x0103CBB8
		// (set) Token: 0x0603F55F RID: 259423 RVA: 0x0103E9C0 File Offset: 0x0103CBC0
		public int BuffId { get; set; }
	}
}
