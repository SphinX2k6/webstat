using System;
using Aki.Config;

// Token: 0x02001E0D RID: 7693
public interface ITrialSubChallenge
{
	// Token: 0x170011B9 RID: 4537
	// (get) Token: 0x0600E329 RID: 58153
	// (set) Token: 0x0600E32A RID: 58154
	BlackSwordGameplay Config { get; set; }

	// Token: 0x170011BA RID: 4538
	// (get) Token: 0x0600E32B RID: 58155
	// (set) Token: 0x0600E32C RID: 58156
	bool Unlocked { get; set; }

	// Token: 0x170011BB RID: 4539
	// (get) Token: 0x0600E32D RID: 58157
	// (set) Token: 0x0600E32E RID: 58158
	bool Completed { get; set; }
}
