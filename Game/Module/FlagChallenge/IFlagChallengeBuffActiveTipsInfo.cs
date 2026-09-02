using System;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D35 RID: 23861
	public interface IFlagChallengeBuffActiveTipsInfo
	{
		// Token: 0x1700988C RID: 39052
		// (get) Token: 0x0603C2E0 RID: 246496
		// (set) Token: 0x0603C2E1 RID: 246497
		int BuffId { get; set; }

		// Token: 0x1700988D RID: 39053
		// (get) Token: 0x0603C2E2 RID: 246498
		// (set) Token: 0x0603C2E3 RID: 246499
		EFlagChallengeBuffStatus State { get; set; }
	}
}
