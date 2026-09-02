using System;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DD4 RID: 19924
	public class TrapDefensePauseInfo : ITrapDefensePauseInfo
	{
		// Token: 0x17008853 RID: 34899
		// (get) Token: 0x06033909 RID: 211209 RVA: 0x00CE4794 File Offset: 0x00CE2994
		// (set) Token: 0x0603390A RID: 211210 RVA: 0x00CE479C File Offset: 0x00CE299C
		public ETrapDefensePauseInfoType Type { get; set; }

		// Token: 0x17008854 RID: 34900
		// (get) Token: 0x0603390B RID: 211211 RVA: 0x00CE47A5 File Offset: 0x00CE29A5
		// (set) Token: 0x0603390C RID: 211212 RVA: 0x00CE47AD File Offset: 0x00CE29AD
		public int? Value { get; set; }

		// Token: 0x17008855 RID: 34901
		// (get) Token: 0x0603390D RID: 211213 RVA: 0x00CE47B6 File Offset: 0x00CE29B6
		// (set) Token: 0x0603390E RID: 211214 RVA: 0x00CE47BE File Offset: 0x00CE29BE
		public int? MaxBatch { get; set; }
	}
}
