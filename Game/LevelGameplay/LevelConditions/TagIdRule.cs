using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006CCE RID: 27854
	[NullableContext(1)]
	[Nullable(0)]
	public class TagIdRule
	{
		// Token: 0x040260CB RID: 155851
		public List<int> RequireTags = new List<int>();

		// Token: 0x040260CC RID: 155852
		public List<int> BanTags = new List<int>();

		// Token: 0x040260CD RID: 155853
		public bool LastReached;
	}
}
