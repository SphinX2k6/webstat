using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine
{
	// Token: 0x02006ECD RID: 28365
	[RequiredMember]
	public class DollGrabInfiniteRewardData : IDollGrabInfiniteRewardData
	{
		// Token: 0x1700A3F2 RID: 41970
		// (get) Token: 0x06044BC7 RID: 281543 RVA: 0x011DE21B File Offset: 0x011DC41B
		// (set) Token: 0x06044BC8 RID: 281544 RVA: 0x011DE223 File Offset: 0x011DC423
		[RequiredMember]
		public int DropId { get; set; }

		// Token: 0x1700A3F3 RID: 41971
		// (get) Token: 0x06044BC9 RID: 281545 RVA: 0x011DE22C File Offset: 0x011DC42C
		// (set) Token: 0x06044BCA RID: 281546 RVA: 0x011DE234 File Offset: 0x011DC434
		[RequiredMember]
		public int CurrentScore { get; set; }

		// Token: 0x1700A3F4 RID: 41972
		// (get) Token: 0x06044BCB RID: 281547 RVA: 0x011DE23D File Offset: 0x011DC43D
		// (set) Token: 0x06044BCC RID: 281548 RVA: 0x011DE245 File Offset: 0x011DC445
		[RequiredMember]
		public int CurrentAccumulatedScore { get; set; }

		// Token: 0x1700A3F5 RID: 41973
		// (get) Token: 0x06044BCD RID: 281549 RVA: 0x011DE24E File Offset: 0x011DC44E
		// (set) Token: 0x06044BCE RID: 281550 RVA: 0x011DE256 File Offset: 0x011DC456
		[RequiredMember]
		public int TargetAccumulatedScore { get; set; }

		// Token: 0x1700A3F6 RID: 41974
		// (get) Token: 0x06044BCF RID: 281551 RVA: 0x011DE25F File Offset: 0x011DC45F
		// (set) Token: 0x06044BD0 RID: 281552 RVA: 0x011DE267 File Offset: 0x011DC467
		[RequiredMember]
		public int HighestScore { get; set; }

		// Token: 0x1700A3F7 RID: 41975
		// (get) Token: 0x06044BD1 RID: 281553 RVA: 0x011DE270 File Offset: 0x011DC470
		// (set) Token: 0x06044BD2 RID: 281554 RVA: 0x011DE278 File Offset: 0x011DC478
		[RequiredMember]
		public bool IsFinalReward { get; set; }

		// Token: 0x1700A3F8 RID: 41976
		// (get) Token: 0x06044BD3 RID: 281555 RVA: 0x011DE281 File Offset: 0x011DC481
		// (set) Token: 0x06044BD4 RID: 281556 RVA: 0x011DE289 File Offset: 0x011DC489
		[RequiredMember]
		public bool IsFirstGetReward { get; set; }

		// Token: 0x06044BD5 RID: 281557 RVA: 0x011DE292 File Offset: 0x011DC492
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public DollGrabInfiniteRewardData()
		{
		}
	}
}
