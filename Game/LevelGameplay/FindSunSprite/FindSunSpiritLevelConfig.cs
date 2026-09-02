using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.FindSunSprite
{
	// Token: 0x02006EAE RID: 28334
	[NullableContext(1)]
	[Nullable(0)]
	public class FindSunSpiritLevelConfig
	{
		// Token: 0x040263E5 RID: 156645
		public int CurrentLevelId;

		// Token: 0x040263E6 RID: 156646
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public FindSunSpiritGrid[] GridList;

		// Token: 0x040263E7 RID: 156647
		public int LevelWidth;

		// Token: 0x040263E8 RID: 156648
		public int LevelHeight;

		// Token: 0x040263E9 RID: 156649
		public List<int> SunSpiritStartGridIndices = new List<int>();

		// Token: 0x040263EA RID: 156650
		public int SunSpiritEndIndex = -1;

		// Token: 0x040263EB RID: 156651
		public int MaxJumpHeight = 1;

		// Token: 0x040263EC RID: 156652
		public int MaxDropHeight = -1;

		// Token: 0x040263ED RID: 156653
		public int MaxStep = -1;

		// Token: 0x040263EE RID: 156654
		public List<FindSunSpiritModifier> ModifierList = new List<FindSunSpiritModifier>();
	}
}
