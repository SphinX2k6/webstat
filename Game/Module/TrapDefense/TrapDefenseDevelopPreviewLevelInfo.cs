using System;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DCF RID: 19919
	public class TrapDefenseDevelopPreviewLevelInfo : ITrapDefenseDevelopPreviewLevelInfo
	{
		// Token: 0x17008847 RID: 34887
		// (get) Token: 0x060338EF RID: 211183 RVA: 0x00CE471E File Offset: 0x00CE291E
		// (set) Token: 0x060338F0 RID: 211184 RVA: 0x00CE4726 File Offset: 0x00CE2926
		public int Id { get; set; }

		// Token: 0x17008848 RID: 34888
		// (get) Token: 0x060338F1 RID: 211185 RVA: 0x00CE472F File Offset: 0x00CE292F
		// (set) Token: 0x060338F2 RID: 211186 RVA: 0x00CE4737 File Offset: 0x00CE2937
		public bool IsCurLevel { get; set; }

		// Token: 0x17008849 RID: 34889
		// (get) Token: 0x060338F3 RID: 211187 RVA: 0x00CE4740 File Offset: 0x00CE2940
		// (set) Token: 0x060338F4 RID: 211188 RVA: 0x00CE4748 File Offset: 0x00CE2948
		public bool? NeedAlpha { get; set; }
	}
}
