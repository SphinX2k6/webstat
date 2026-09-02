using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F8A RID: 24458
	public class TowerMergeHeadStateInfo
	{
		// Token: 0x04022820 RID: 141344
		public int MainMonsterInfoId;

		// Token: 0x04022821 RID: 141345
		public bool IsVisible;

		// Token: 0x04022822 RID: 141346
		public float TotalHp;

		// Token: 0x04022823 RID: 141347
		public float TotalHpMax;

		// Token: 0x04022824 RID: 141348
		[Nullable(1)]
		public Dictionary<int, TowerMergeHeadStateMonsterInfo> MonsterInfos = new Dictionary<int, TowerMergeHeadStateMonsterInfo>();
	}
}
