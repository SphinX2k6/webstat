using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine
{
	// Token: 0x02006EC3 RID: 28355
	public class DollMapInfo
	{
		// Token: 0x04026467 RID: 156775
		[Nullable(1)]
		public HashSet<int> CollectItemIdSet = new HashSet<int>();

		// Token: 0x04026468 RID: 156776
		public int CurrentScore;
	}
}
