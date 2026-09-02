using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B06 RID: 23302
	[NullableContext(2)]
	[Nullable(0)]
	public class ExtendRewardInfo : IExtendRewardInfo
	{
		// Token: 0x1700963E RID: 38462
		// (get) Token: 0x0603AF34 RID: 241460 RVA: 0x00EF2178 File Offset: 0x00EF0378
		// (set) Token: 0x0603AF35 RID: 241461 RVA: 0x00EF2180 File Offset: 0x00EF0380
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<RewardItemData> ItemList { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x1700963F RID: 38463
		// (get) Token: 0x0603AF36 RID: 241462 RVA: 0x00EF2189 File Offset: 0x00EF0389
		// (set) Token: 0x0603AF37 RID: 241463 RVA: 0x00EF2191 File Offset: 0x00EF0391
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<IRewardProgress> ProgressQueue { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17009640 RID: 38464
		// (get) Token: 0x0603AF38 RID: 241464 RVA: 0x00EF219A File Offset: 0x00EF039A
		// (set) Token: 0x0603AF39 RID: 241465 RVA: 0x00EF21A2 File Offset: 0x00EF03A2
		public IRewardExploreRecord ExploreRecordInfo { get; set; }

		// Token: 0x17009641 RID: 38465
		// (get) Token: 0x0603AF3A RID: 241466 RVA: 0x00EF21AB File Offset: 0x00EF03AB
		// (set) Token: 0x0603AF3B RID: 241467 RVA: 0x00EF21B3 File Offset: 0x00EF03B3
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<IRewardExploreBar> ExploreBarDataList { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17009642 RID: 38466
		// (get) Token: 0x0603AF3C RID: 241468 RVA: 0x00EF21BC File Offset: 0x00EF03BC
		// (set) Token: 0x0603AF3D RID: 241469 RVA: 0x00EF21C4 File Offset: 0x00EF03C4
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<IRewardExploreFriendData> ExploreFriendDataList { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17009643 RID: 38467
		// (get) Token: 0x0603AF3E RID: 241470 RVA: 0x00EF21CD File Offset: 0x00EF03CD
		// (set) Token: 0x0603AF3F RID: 241471 RVA: 0x00EF21D5 File Offset: 0x00EF03D5
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<IRewardExploreConfirmButton> ButtonInfoList { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17009644 RID: 38468
		// (get) Token: 0x0603AF40 RID: 241472 RVA: 0x00EF21DE File Offset: 0x00EF03DE
		// (set) Token: 0x0603AF41 RID: 241473 RVA: 0x00EF21E6 File Offset: 0x00EF03E6
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<IRewardExploreTargetReached> TargetReached { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17009645 RID: 38469
		// (get) Token: 0x0603AF42 RID: 241474 RVA: 0x00EF21EF File Offset: 0x00EF03EF
		// (set) Token: 0x0603AF43 RID: 241475 RVA: 0x00EF21F7 File Offset: 0x00EF03F7
		public IRewardExploreScoreBelongHalfArea ScoreHalfArea { get; set; }

		// Token: 0x17009646 RID: 38470
		// (get) Token: 0x0603AF44 RID: 241476 RVA: 0x00EF2200 File Offset: 0x00EF0400
		// (set) Token: 0x0603AF45 RID: 241477 RVA: 0x00EF2208 File Offset: 0x00EF0408
		public ReachTargetData ScoreReached { get; set; }

		// Token: 0x17009647 RID: 38471
		// (get) Token: 0x0603AF46 RID: 241478 RVA: 0x00EF2211 File Offset: 0x00EF0411
		// (set) Token: 0x0603AF47 RID: 241479 RVA: 0x00EF2219 File Offset: 0x00EF0419
		public IRewardExploreToggle StateToggle { get; set; }

		// Token: 0x17009648 RID: 38472
		// (get) Token: 0x0603AF48 RID: 241480 RVA: 0x00EF2222 File Offset: 0x00EF0422
		// (set) Token: 0x0603AF49 RID: 241481 RVA: 0x00EF222A File Offset: 0x00EF042A
		public AccumulatedScoreData AccumulatedScoreData { get; set; }

		// Token: 0x17009649 RID: 38473
		// (get) Token: 0x0603AF4A RID: 241482 RVA: 0x00EF2233 File Offset: 0x00EF0433
		// (set) Token: 0x0603AF4B RID: 241483 RVA: 0x00EF223B File Offset: 0x00EF043B
		public IBabelTowerSuccessData BabelTowerSuccessData { get; set; }

		// Token: 0x1700964A RID: 38474
		// (get) Token: 0x0603AF4C RID: 241484 RVA: 0x00EF2244 File Offset: 0x00EF0444
		// (set) Token: 0x0603AF4D RID: 241485 RVA: 0x00EF224C File Offset: 0x00EF044C
		public IDangoAbyssSuccessData DangoAbyssSuccessData { get; set; }

		// Token: 0x1700964B RID: 38475
		// (get) Token: 0x0603AF4E RID: 241486 RVA: 0x00EF2255 File Offset: 0x00EF0455
		// (set) Token: 0x0603AF4F RID: 241487 RVA: 0x00EF225D File Offset: 0x00EF045D
		public IHonamiTowerSuccessData HonamiTowerSuccessData { get; set; }

		// Token: 0x1700964C RID: 38476
		// (get) Token: 0x0603AF50 RID: 241488 RVA: 0x00EF2266 File Offset: 0x00EF0466
		// (set) Token: 0x0603AF51 RID: 241489 RVA: 0x00EF226E File Offset: 0x00EF046E
		public IRoguelikeBossChallengeData RoguelikeBossChallengeData { get; set; }
	}
}
