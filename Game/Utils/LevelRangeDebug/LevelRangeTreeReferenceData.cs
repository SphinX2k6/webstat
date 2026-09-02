using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Utils.LevelRangeDebug
{
	// Token: 0x0200470D RID: 18189
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelRangeTreeReferenceData
	{
		// Token: 0x0401AEF9 RID: 110329
		public HashSet<int> LevelPlayIds = new HashSet<int>();

		// Token: 0x0401AEFA RID: 110330
		public HashSet<int> PbDataIds = new HashSet<int>();
	}
}
