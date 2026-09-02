using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x020061FD RID: 25085
	[NullableContext(1)]
	[Nullable(0)]
	public class ResultBossInfo : IResultBossInfo
	{
		// Token: 0x17009B69 RID: 39785
		// (get) Token: 0x0603F4C8 RID: 259272 RVA: 0x0103E6C7 File Offset: 0x0103C8C7
		// (set) Token: 0x0603F4C9 RID: 259273 RVA: 0x0103E6CF File Offset: 0x0103C8CF
		public IBossItemData BossInfo { get; set; } = new BossItemData();

		// Token: 0x17009B6A RID: 39786
		// (get) Token: 0x0603F4CA RID: 259274 RVA: 0x0103E6D8 File Offset: 0x0103C8D8
		// (set) Token: 0x0603F4CB RID: 259275 RVA: 0x0103E6E0 File Offset: 0x0103C8E0
		public bool IsDead { get; set; }
	}
}
