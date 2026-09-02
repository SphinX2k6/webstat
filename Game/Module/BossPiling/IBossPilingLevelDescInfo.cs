using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BossPiling
{
	// Token: 0x02005EE7 RID: 24295
	[NullableContext(1)]
	public interface IBossPilingLevelDescInfo
	{
		// Token: 0x17009A0C RID: 39436
		// (get) Token: 0x0603D0C3 RID: 250051
		// (set) Token: 0x0603D0C4 RID: 250052
		bool IsFirstLevel { get; set; }

		// Token: 0x17009A0D RID: 39437
		// (get) Token: 0x0603D0C5 RID: 250053
		// (set) Token: 0x0603D0C6 RID: 250054
		int LevelId { get; set; }

		// Token: 0x17009A0E RID: 39438
		// (get) Token: 0x0603D0C7 RID: 250055
		// (set) Token: 0x0603D0C8 RID: 250056
		string LevelMechanism { get; set; }

		// Token: 0x17009A0F RID: 39439
		// (get) Token: 0x0603D0C9 RID: 250057
		// (set) Token: 0x0603D0CA RID: 250058
		string MonsterDesc { get; set; }

		// Token: 0x17009A10 RID: 39440
		// (get) Token: 0x0603D0CB RID: 250059
		// (set) Token: 0x0603D0CC RID: 250060
		string LevelDesc { get; set; }
	}
}
