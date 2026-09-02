using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F79 RID: 24441
	[NullableContext(2)]
	[Nullable(0)]
	public class MergeHeadStateInfo
	{
		// Token: 0x0402272E RID: 141102
		public int Id;

		// Token: 0x0402272F RID: 141103
		public long? TreeId;

		// Token: 0x04022730 RID: 141104
		public int NodeId;

		// Token: 0x04022731 RID: 141105
		public string MonsterGroupName;

		// Token: 0x04022732 RID: 141106
		public IMonsterMergedHpBarSettings MonsterMergedHpBarSettings;

		// Token: 0x04022733 RID: 141107
		public bool IsVisible;

		// Token: 0x04022734 RID: 141108
		public float TotalHp;

		// Token: 0x04022735 RID: 141109
		public float TotalHpMax;

		// Token: 0x04022736 RID: 141110
		[Nullable(1)]
		public Dictionary<int, MergeHeadStateMonsterInfo> MonsterInfos = new Dictionary<int, MergeHeadStateMonsterInfo>();
	}
}
