using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B05 RID: 23301
	[NullableContext(2)]
	public interface IExtendRewardInfo
	{
		// Token: 0x1700962F RID: 38447
		// (get) Token: 0x0603AF16 RID: 241430
		// (set) Token: 0x0603AF17 RID: 241431
		[Nullable(new byte[]
		{
			2,
			1
		})]
		List<RewardItemData> ItemList { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17009630 RID: 38448
		// (get) Token: 0x0603AF18 RID: 241432
		// (set) Token: 0x0603AF19 RID: 241433
		[Nullable(new byte[]
		{
			2,
			1
		})]
		List<IRewardProgress> ProgressQueue { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17009631 RID: 38449
		// (get) Token: 0x0603AF1A RID: 241434
		// (set) Token: 0x0603AF1B RID: 241435
		IRewardExploreRecord ExploreRecordInfo { get; set; }

		// Token: 0x17009632 RID: 38450
		// (get) Token: 0x0603AF1C RID: 241436
		// (set) Token: 0x0603AF1D RID: 241437
		[Nullable(new byte[]
		{
			2,
			1
		})]
		List<IRewardExploreBar> ExploreBarDataList { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17009633 RID: 38451
		// (get) Token: 0x0603AF1E RID: 241438
		// (set) Token: 0x0603AF1F RID: 241439
		[Nullable(new byte[]
		{
			2,
			1
		})]
		List<IRewardExploreFriendData> ExploreFriendDataList { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17009634 RID: 38452
		// (get) Token: 0x0603AF20 RID: 241440
		// (set) Token: 0x0603AF21 RID: 241441
		[Nullable(new byte[]
		{
			2,
			1
		})]
		List<IRewardExploreConfirmButton> ButtonInfoList { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17009635 RID: 38453
		// (get) Token: 0x0603AF22 RID: 241442
		// (set) Token: 0x0603AF23 RID: 241443
		[Nullable(new byte[]
		{
			2,
			1
		})]
		List<IRewardExploreTargetReached> TargetReached { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17009636 RID: 38454
		// (get) Token: 0x0603AF24 RID: 241444
		// (set) Token: 0x0603AF25 RID: 241445
		IRewardExploreScoreBelongHalfArea ScoreHalfArea { get; set; }

		// Token: 0x17009637 RID: 38455
		// (get) Token: 0x0603AF26 RID: 241446
		// (set) Token: 0x0603AF27 RID: 241447
		ReachTargetData ScoreReached { get; set; }

		// Token: 0x17009638 RID: 38456
		// (get) Token: 0x0603AF28 RID: 241448
		// (set) Token: 0x0603AF29 RID: 241449
		IRewardExploreToggle StateToggle { get; set; }

		// Token: 0x17009639 RID: 38457
		// (get) Token: 0x0603AF2A RID: 241450
		// (set) Token: 0x0603AF2B RID: 241451
		AccumulatedScoreData AccumulatedScoreData { get; set; }

		// Token: 0x1700963A RID: 38458
		// (get) Token: 0x0603AF2C RID: 241452
		// (set) Token: 0x0603AF2D RID: 241453
		IBabelTowerSuccessData BabelTowerSuccessData { get; set; }

		// Token: 0x1700963B RID: 38459
		// (get) Token: 0x0603AF2E RID: 241454
		// (set) Token: 0x0603AF2F RID: 241455
		IDangoAbyssSuccessData DangoAbyssSuccessData { get; set; }

		// Token: 0x1700963C RID: 38460
		// (get) Token: 0x0603AF30 RID: 241456
		// (set) Token: 0x0603AF31 RID: 241457
		IHonamiTowerSuccessData HonamiTowerSuccessData { get; set; }

		// Token: 0x1700963D RID: 38461
		// (get) Token: 0x0603AF32 RID: 241458
		// (set) Token: 0x0603AF33 RID: 241459
		IRoguelikeBossChallengeData RoguelikeBossChallengeData { get; set; }
	}
}
