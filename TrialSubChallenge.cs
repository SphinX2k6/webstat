using System;
using Aki.Config;

// Token: 0x02001E0E RID: 7694
public class TrialSubChallenge : ITrialSubChallenge
{
	// Token: 0x170011BC RID: 4540
	// (get) Token: 0x0600E32F RID: 58159 RVA: 0x003D3067 File Offset: 0x003D1267
	// (set) Token: 0x0600E330 RID: 58160 RVA: 0x003D306F File Offset: 0x003D126F
	public BlackSwordGameplay Config { get; set; }

	// Token: 0x170011BD RID: 4541
	// (get) Token: 0x0600E331 RID: 58161 RVA: 0x003D3078 File Offset: 0x003D1278
	// (set) Token: 0x0600E332 RID: 58162 RVA: 0x003D3080 File Offset: 0x003D1280
	public bool Unlocked { get; set; }

	// Token: 0x170011BE RID: 4542
	// (get) Token: 0x0600E333 RID: 58163 RVA: 0x003D3089 File Offset: 0x003D1289
	// (set) Token: 0x0600E334 RID: 58164 RVA: 0x003D3091 File Offset: 0x003D1291
	public bool Completed { get; set; }
}
