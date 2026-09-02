using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.FindSunSprite
{
	// Token: 0x02006EAC RID: 28332
	public class FindSunSpiritModifier
	{
		// Token: 0x040263DC RID: 156636
		public int GridIndex;

		// Token: 0x040263DD RID: 156637
		public float GridX;

		// Token: 0x040263DE RID: 156638
		public float GridY;

		// Token: 0x040263DF RID: 156639
		[Nullable(1)]
		public HashSet<int> ModifyIndexSet = new HashSet<int>();
	}
}
