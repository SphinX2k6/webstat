using System;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D39 RID: 23865
	public interface IFlagChallengeSettleInfo
	{
		// Token: 0x17009896 RID: 39062
		// (get) Token: 0x0603C2F6 RID: 246518
		// (set) Token: 0x0603C2F7 RID: 246519
		int Level { get; set; }

		// Token: 0x17009897 RID: 39063
		// (get) Token: 0x0603C2F8 RID: 246520
		// (set) Token: 0x0603C2F9 RID: 246521
		int CacheLevel { get; set; }

		// Token: 0x17009898 RID: 39064
		// (get) Token: 0x0603C2FA RID: 246522
		// (set) Token: 0x0603C2FB RID: 246523
		int BoxLevel { get; set; }
	}
}
