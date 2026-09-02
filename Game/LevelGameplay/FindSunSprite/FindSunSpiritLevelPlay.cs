using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.FindSunSprite
{
	// Token: 0x02006EAD RID: 28333
	[NullableContext(1)]
	[Nullable(0)]
	public class FindSunSpiritLevelPlay
	{
		// Token: 0x040263E0 RID: 156640
		public int CurrentStep;

		// Token: 0x040263E1 RID: 156641
		public int SelectedModifierIndex;

		// Token: 0x040263E2 RID: 156642
		public List<FindSunSpiritGrid> GridList = new List<FindSunSpiritGrid>();

		// Token: 0x040263E3 RID: 156643
		public HashSet<int> SunSpiritIndexSet = new HashSet<int>();

		// Token: 0x040263E4 RID: 156644
		public int SunSpiritNum;
	}
}
