using System;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DD1 RID: 19921
	public class TrapDefenseDevelopBranchSelectInfo : ITrapDefenseDevelopBranchSelectInfo
	{
		// Token: 0x1700884D RID: 34893
		// (get) Token: 0x060338FC RID: 211196 RVA: 0x00CE4759 File Offset: 0x00CE2959
		// (set) Token: 0x060338FD RID: 211197 RVA: 0x00CE4761 File Offset: 0x00CE2961
		public int Id { get; set; }

		// Token: 0x1700884E RID: 34894
		// (get) Token: 0x060338FE RID: 211198 RVA: 0x00CE476A File Offset: 0x00CE296A
		// (set) Token: 0x060338FF RID: 211199 RVA: 0x00CE4772 File Offset: 0x00CE2972
		public bool IsCurLevel { get; set; }

		// Token: 0x1700884F RID: 34895
		// (get) Token: 0x06033900 RID: 211200 RVA: 0x00CE477B File Offset: 0x00CE297B
		// (set) Token: 0x06033901 RID: 211201 RVA: 0x00CE4783 File Offset: 0x00CE2983
		public bool IsSelected { get; set; }
	}
}
