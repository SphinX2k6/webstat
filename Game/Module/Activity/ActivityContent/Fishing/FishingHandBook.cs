using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067FE RID: 26622
	public class FishingHandBook : IFishingHandBook
	{
		// Token: 0x1700A14A RID: 41290
		// (get) Token: 0x060425DD RID: 271837 RVA: 0x01104655 File Offset: 0x01102855
		// (set) Token: 0x060425DE RID: 271838 RVA: 0x0110465D File Offset: 0x0110285D
		public int Id { get; set; }

		// Token: 0x1700A14B RID: 41291
		// (get) Token: 0x060425DF RID: 271839 RVA: 0x01104666 File Offset: 0x01102866
		// (set) Token: 0x060425E0 RID: 271840 RVA: 0x0110466E File Offset: 0x0110286E
		public int MaxSize { get; set; }

		// Token: 0x1700A14C RID: 41292
		// (get) Token: 0x060425E1 RID: 271841 RVA: 0x01104677 File Offset: 0x01102877
		// (set) Token: 0x060425E2 RID: 271842 RVA: 0x0110467F File Offset: 0x0110287F
		public int MinSize { get; set; }
	}
}
