using System;

namespace CSharpScript.Game.LevelGamePlay.TuningStand
{
	// Token: 0x02006A74 RID: 27252
	public class TuningStateData : ITuningStateData
	{
		// Token: 0x1700A25B RID: 41563
		// (get) Token: 0x06043683 RID: 276099 RVA: 0x0115D412 File Offset: 0x0115B612
		// (set) Token: 0x06043684 RID: 276100 RVA: 0x0115D41A File Offset: 0x0115B61A
		public EGridBelongType State { get; set; }

		// Token: 0x1700A25C RID: 41564
		// (get) Token: 0x06043685 RID: 276101 RVA: 0x0115D423 File Offset: 0x0115B623
		// (set) Token: 0x06043686 RID: 276102 RVA: 0x0115D42B File Offset: 0x0115B62B
		public int? Prev { get; set; }

		// Token: 0x1700A25D RID: 41565
		// (get) Token: 0x06043687 RID: 276103 RVA: 0x0115D434 File Offset: 0x0115B634
		// (set) Token: 0x06043688 RID: 276104 RVA: 0x0115D43C File Offset: 0x0115B63C
		public int? Next { get; set; }
	}
}
