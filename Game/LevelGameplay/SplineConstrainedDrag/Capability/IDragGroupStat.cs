using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGameplay.SplineConstrainedDrag.Capability
{
	// Token: 0x020069FA RID: 27130
	[NullableContext(1)]
	public interface IDragGroupStat
	{
		// Token: 0x1700A1FC RID: 41468
		// (get) Token: 0x06043382 RID: 275330
		// (set) Token: 0x06043383 RID: 275331
		int Total { get; set; }

		// Token: 0x1700A1FD RID: 41469
		// (get) Token: 0x06043384 RID: 275332
		// (set) Token: 0x06043385 RID: 275333
		int[] StateCounts { get; set; }

		// Token: 0x1700A1FE RID: 41470
		// (get) Token: 0x06043386 RID: 275334
		// (set) Token: 0x06043387 RID: 275335
		int ConditionOkCount { get; set; }

		// Token: 0x1700A1FF RID: 41471
		// (get) Token: 0x06043388 RID: 275336
		// (set) Token: 0x06043389 RID: 275337
		bool HasActive { get; set; }
	}
}
