using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Coop
{
	// Token: 0x02006999 RID: 27033
	[NullableContext(1)]
	[Nullable(0)]
	public class CoopRoleSelectViewParams
	{
		// Token: 0x1700A1E8 RID: 41448
		// (get) Token: 0x060430E1 RID: 274657 RVA: 0x011384BE File Offset: 0x011366BE
		// (set) Token: 0x060430E2 RID: 274658 RVA: 0x011384C6 File Offset: 0x011366C6
		public CoopActivityData ActivityData { get; set; }

		// Token: 0x1700A1E9 RID: 41449
		// (get) Token: 0x060430E3 RID: 274659 RVA: 0x011384CF File Offset: 0x011366CF
		// (set) Token: 0x060430E4 RID: 274660 RVA: 0x011384D7 File Offset: 0x011366D7
		public int Index { get; set; }

		// Token: 0x1700A1EA RID: 41450
		// (get) Token: 0x060430E5 RID: 274661 RVA: 0x011384E0 File Offset: 0x011366E0
		// (set) Token: 0x060430E6 RID: 274662 RVA: 0x011384E8 File Offset: 0x011366E8
		public int Level { get; set; }

		// Token: 0x1700A1EB RID: 41451
		// (get) Token: 0x060430E7 RID: 274663 RVA: 0x011384F1 File Offset: 0x011366F1
		// (set) Token: 0x060430E8 RID: 274664 RVA: 0x011384F9 File Offset: 0x011366F9
		public int LevelId { get; set; }

		// Token: 0x1700A1EC RID: 41452
		// (get) Token: 0x060430E9 RID: 274665 RVA: 0x01138502 File Offset: 0x01136702
		// (set) Token: 0x060430EA RID: 274666 RVA: 0x0113850A File Offset: 0x0113670A
		public bool IsOpenByUpGradeView { get; set; }
	}
}
