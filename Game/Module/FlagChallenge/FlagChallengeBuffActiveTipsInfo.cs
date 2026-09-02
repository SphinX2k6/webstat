using System;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D36 RID: 23862
	public class FlagChallengeBuffActiveTipsInfo : IFlagChallengeBuffActiveTipsInfo
	{
		// Token: 0x1700988E RID: 39054
		// (get) Token: 0x0603C2E4 RID: 246500 RVA: 0x00F42BBD File Offset: 0x00F40DBD
		// (set) Token: 0x0603C2E5 RID: 246501 RVA: 0x00F42BC5 File Offset: 0x00F40DC5
		public int BuffId { get; set; }

		// Token: 0x1700988F RID: 39055
		// (get) Token: 0x0603C2E6 RID: 246502 RVA: 0x00F42BCE File Offset: 0x00F40DCE
		// (set) Token: 0x0603C2E7 RID: 246503 RVA: 0x00F42BD6 File Offset: 0x00F40DD6
		public EFlagChallengeBuffStatus State { get; set; }
	}
}
