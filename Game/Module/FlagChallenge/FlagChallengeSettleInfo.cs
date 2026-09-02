using System;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D3A RID: 23866
	public class FlagChallengeSettleInfo : IFlagChallengeSettleInfo
	{
		// Token: 0x17009899 RID: 39065
		// (get) Token: 0x0603C2FC RID: 246524 RVA: 0x00F42C22 File Offset: 0x00F40E22
		// (set) Token: 0x0603C2FD RID: 246525 RVA: 0x00F42C2A File Offset: 0x00F40E2A
		public int Level { get; set; }

		// Token: 0x1700989A RID: 39066
		// (get) Token: 0x0603C2FE RID: 246526 RVA: 0x00F42C33 File Offset: 0x00F40E33
		// (set) Token: 0x0603C2FF RID: 246527 RVA: 0x00F42C3B File Offset: 0x00F40E3B
		public int CacheLevel { get; set; }

		// Token: 0x1700989B RID: 39067
		// (get) Token: 0x0603C300 RID: 246528 RVA: 0x00F42C44 File Offset: 0x00F40E44
		// (set) Token: 0x0603C301 RID: 246529 RVA: 0x00F42C4C File Offset: 0x00F40E4C
		public int BoxLevel { get; set; }
	}
}
