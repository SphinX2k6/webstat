using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B03 RID: 23299
	[NullableContext(2)]
	public interface IExploreRewardViewData
	{
		// Token: 0x17009603 RID: 38403
		// (get) Token: 0x0603AEBD RID: 241341
		// (set) Token: 0x0603AEBE RID: 241342
		int ConfigId { get; set; }

		// Token: 0x17009604 RID: 38404
		// (get) Token: 0x0603AEBF RID: 241343
		// (set) Token: 0x0603AEC0 RID: 241344
		bool IsSuccess { get; set; }

		// Token: 0x17009605 RID: 38405
		// (get) Token: 0x0603AEC1 RID: 241345
		// (set) Token: 0x0603AEC2 RID: 241346
		[Nullable(new byte[]
		{
			2,
			1
		})]
		List<RewardItemData> RewardItemDataList { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x17009606 RID: 38406
		// (get) Token: 0x0603AEC3 RID: 241347
		// (set) Token: 0x0603AEC4 RID: 241348
		IRewardExploreRecord ExploreRecordInfo { get; set; }

		// Token: 0x17009607 RID: 38407
		// (get) Token: 0x0603AEC5 RID: 241349
		// (set) Token: 0x0603AEC6 RID: 241350
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

		// Token: 0x17009608 RID: 38408
		// (get) Token: 0x0603AEC7 RID: 241351
		// (set) Token: 0x0603AEC8 RID: 241352
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

		// Token: 0x17009609 RID: 38409
		// (get) Token: 0x0603AEC9 RID: 241353
		// (set) Token: 0x0603AECA RID: 241354
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

		// Token: 0x1700960A RID: 38410
		// (get) Token: 0x0603AECB RID: 241355
		// (set) Token: 0x0603AECC RID: 241356
		IRewardExploreToggle StateToggle { get; set; }

		// Token: 0x1700960B RID: 38411
		// (get) Token: 0x0603AECD RID: 241357
		// (set) Token: 0x0603AECE RID: 241358
		Action OnCloseCallback { get; set; }

		// Token: 0x1700960C RID: 38412
		// (get) Token: 0x0603AECF RID: 241359
		// (set) Token: 0x0603AED0 RID: 241360
		string Tip { get; set; }

		// Token: 0x1700960D RID: 38413
		// (get) Token: 0x0603AED1 RID: 241361
		// (set) Token: 0x0603AED2 RID: 241362
		Action<bool> FinishCallback { get; set; }

		// Token: 0x1700960E RID: 38414
		// (get) Token: 0x0603AED3 RID: 241363
		// (set) Token: 0x0603AED4 RID: 241364
		bool? IsShowOnlineChallengePlayer { get; set; }

		// Token: 0x1700960F RID: 38415
		// (get) Token: 0x0603AED5 RID: 241365
		// (set) Token: 0x0603AED6 RID: 241366
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

		// Token: 0x17009610 RID: 38416
		// (get) Token: 0x0603AED7 RID: 241367
		// (set) Token: 0x0603AED8 RID: 241368
		ReachTargetData ScoreReachedData { get; set; }

		// Token: 0x17009611 RID: 38417
		// (get) Token: 0x0603AED9 RID: 241369
		// (set) Token: 0x0603AEDA RID: 241370
		bool? IsRewardMultiLine { get; set; }

		// Token: 0x17009612 RID: 38418
		// (get) Token: 0x0603AEDB RID: 241371
		// (set) Token: 0x0603AEDC RID: 241372
		AccumulatedScoreData AccumulatedScoreData { get; set; }

		// Token: 0x17009613 RID: 38419
		// (get) Token: 0x0603AEDD RID: 241373
		// (set) Token: 0x0603AEDE RID: 241374
		string TitleTextId { get; set; }

		// Token: 0x17009614 RID: 38420
		// (get) Token: 0x0603AEDF RID: 241375
		// (set) Token: 0x0603AEE0 RID: 241376
		IBabelTowerSuccessData BabelTowerSuccessData { get; set; }

		// Token: 0x17009615 RID: 38421
		// (get) Token: 0x0603AEE1 RID: 241377
		// (set) Token: 0x0603AEE2 RID: 241378
		bool? IsBagFull { get; set; }

		// Token: 0x17009616 RID: 38422
		// (get) Token: 0x0603AEE3 RID: 241379
		// (set) Token: 0x0603AEE4 RID: 241380
		IDangoAbyssSuccessData DangoAbyssSuccessData { get; set; }

		// Token: 0x17009617 RID: 38423
		// (get) Token: 0x0603AEE5 RID: 241381
		// (set) Token: 0x0603AEE6 RID: 241382
		IHonamiTowerSuccessData HonamiTowerSuccessData { get; set; }

		// Token: 0x17009618 RID: 38424
		// (get) Token: 0x0603AEE7 RID: 241383
		// (set) Token: 0x0603AEE8 RID: 241384
		IRoguelikeBossChallengeData RoguelikeBossChallengeData { get; set; }
	}
}
