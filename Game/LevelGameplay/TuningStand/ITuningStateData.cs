using System;

namespace CSharpScript.Game.LevelGamePlay.TuningStand
{
	// Token: 0x02006A71 RID: 27249
	public interface ITuningStateData
	{
		// Token: 0x1700A257 RID: 41559
		// (get) Token: 0x06043676 RID: 276086
		// (set) Token: 0x06043677 RID: 276087
		EGridBelongType State { get; set; }

		// Token: 0x1700A258 RID: 41560
		// (get) Token: 0x06043678 RID: 276088
		// (set) Token: 0x06043679 RID: 276089
		int? Prev { get; set; }

		// Token: 0x1700A259 RID: 41561
		// (get) Token: 0x0604367A RID: 276090
		// (set) Token: 0x0604367B RID: 276091
		int? Next { get; set; }
	}
}
