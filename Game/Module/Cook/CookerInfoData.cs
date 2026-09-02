using System;

namespace CSharpScript.Game.Module.Cook
{
	// Token: 0x02005E07 RID: 24071
	public class CookerInfoData : ICookerInfoData
	{
		// Token: 0x1700990F RID: 39183
		// (get) Token: 0x0603C938 RID: 248120 RVA: 0x00F62391 File Offset: 0x00F60591
		// (set) Token: 0x0603C939 RID: 248121 RVA: 0x00F62399 File Offset: 0x00F60599
		public int CookingLevel { get; set; }

		// Token: 0x17009910 RID: 39184
		// (get) Token: 0x0603C93A RID: 248122 RVA: 0x00F623A2 File Offset: 0x00F605A2
		// (set) Token: 0x0603C93B RID: 248123 RVA: 0x00F623AA File Offset: 0x00F605AA
		public int TotalProficiencys { get; set; }

		// Token: 0x17009911 RID: 39185
		// (get) Token: 0x0603C93C RID: 248124 RVA: 0x00F623B3 File Offset: 0x00F605B3
		// (set) Token: 0x0603C93D RID: 248125 RVA: 0x00F623BB File Offset: 0x00F605BB
		public int AddExp { get; set; }
	}
}
