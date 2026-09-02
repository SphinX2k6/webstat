using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002706 RID: 9990
[NullableContext(1)]
[Nullable(0)]
public class RacingBetsSelfRankData : IRacingBetsSelfRankData
{
	// Token: 0x17001932 RID: 6450
	// (get) Token: 0x06013B69 RID: 80745 RVA: 0x0057D48A File Offset: 0x0057B68A
	// (set) Token: 0x06013B6A RID: 80746 RVA: 0x0057D492 File Offset: 0x0057B692
	public RacingBetsRankStatus RankStatus { get; set; }

	// Token: 0x17001933 RID: 6451
	// (get) Token: 0x06013B6B RID: 80747 RVA: 0x0057D49B File Offset: 0x0057B69B
	// (set) Token: 0x06013B6C RID: 80748 RVA: 0x0057D4A3 File Offset: 0x0057B6A3
	public int RankNum { get; set; }

	// Token: 0x17001934 RID: 6452
	// (get) Token: 0x06013B6D RID: 80749 RVA: 0x0057D4AC File Offset: 0x0057B6AC
	// (set) Token: 0x06013B6E RID: 80750 RVA: 0x0057D4B4 File Offset: 0x0057B6B4
	public int HeadIcon { get; set; }

	// Token: 0x17001935 RID: 6453
	// (get) Token: 0x06013B6F RID: 80751 RVA: 0x0057D4BD File Offset: 0x0057B6BD
	// (set) Token: 0x06013B70 RID: 80752 RVA: 0x0057D4C5 File Offset: 0x0057B6C5
	public string Name { get; set; }

	// Token: 0x17001936 RID: 6454
	// (get) Token: 0x06013B71 RID: 80753 RVA: 0x0057D4CE File Offset: 0x0057B6CE
	// (set) Token: 0x06013B72 RID: 80754 RVA: 0x0057D4D6 File Offset: 0x0057B6D6
	public int HitNum { get; set; }

	// Token: 0x17001937 RID: 6455
	// (get) Token: 0x06013B73 RID: 80755 RVA: 0x0057D4DF File Offset: 0x0057B6DF
	// (set) Token: 0x06013B74 RID: 80756 RVA: 0x0057D4E7 File Offset: 0x0057B6E7
	public int CashNum { get; set; }
}
