using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.MusicGamePlay
{
	// Token: 0x02006B3A RID: 27450
	[NullableContext(1)]
	public interface IBeatEntity
	{
		// Token: 0x1700A324 RID: 41764
		// (get) Token: 0x06043D5D RID: 277853
		// (set) Token: 0x06043D5E RID: 277854
		string Archetype { get; set; }

		// Token: 0x1700A325 RID: 41765
		// (get) Token: 0x06043D5F RID: 277855
		// (set) Token: 0x06043D60 RID: 277856
		IBeatData[] Data { get; set; }
	}
}
