using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B04 RID: 23300
	[NullableContext(2)]
	[Nullable(0)]
	public class ExploreRewardViewData : IExploreRewardViewData
	{
		// Token: 0x17009619 RID: 38425
		// (get) Token: 0x0603AEE9 RID: 241385 RVA: 0x00EF1FFA File Offset: 0x00EF01FA
		// (set) Token: 0x0603AEEA RID: 241386 RVA: 0x00EF2002 File Offset: 0x00EF0202
		public int ConfigId { get; set; }

		// Token: 0x1700961A RID: 38426
		// (get) Token: 0x0603AEEB RID: 241387 RVA: 0x00EF200B File Offset: 0x00EF020B
		// (set) Token: 0x0603AEEC RID: 241388 RVA: 0x00EF2013 File Offset: 0x00EF0213
		public bool IsSuccess { get; set; }

		// Token: 0x1700961B RID: 38427
		// (get) Token: 0x0603AEED RID: 241389 RVA: 0x00EF201C File Offset: 0x00EF021C
		// (set) Token: 0x0603AEEE RID: 241390 RVA: 0x00EF2024 File Offset: 0x00EF0224
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<RewardItemData> RewardItemDataList { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x1700961C RID: 38428
		// (get) Token: 0x0603AEEF RID: 241391 RVA: 0x00EF202D File Offset: 0x00EF022D
		// (set) Token: 0x0603AEF0 RID: 241392 RVA: 0x00EF2035 File Offset: 0x00EF0235
		public IRewardExploreRecord ExploreRecordInfo { get; set; }

		// Token: 0x1700961D RID: 38429
		// (get) Token: 0x0603AEF1 RID: 241393 RVA: 0x00EF203E File Offset: 0x00EF023E
		// (set) Token: 0x0603AEF2 RID: 241394 RVA: 0x00EF2046 File Offset: 0x00EF0246
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

		// Token: 0x1700961E RID: 38430
		// (get) Token: 0x0603AEF3 RID: 241395 RVA: 0x00EF204F File Offset: 0x00EF024F
		// (set) Token: 0x0603AEF4 RID: 241396 RVA: 0x00EF2057 File Offset: 0x00EF0257
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

		// Token: 0x1700961F RID: 38431
		// (get) Token: 0x0603AEF5 RID: 241397 RVA: 0x00EF2060 File Offset: 0x00EF0260
		// (set) Token: 0x0603AEF6 RID: 241398 RVA: 0x00EF2068 File Offset: 0x00EF0268
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

		// Token: 0x17009620 RID: 38432
		// (get) Token: 0x0603AEF7 RID: 241399 RVA: 0x00EF2071 File Offset: 0x00EF0271
		// (set) Token: 0x0603AEF8 RID: 241400 RVA: 0x00EF2079 File Offset: 0x00EF0279
		public IRewardExploreToggle StateToggle { get; set; }

		// Token: 0x17009621 RID: 38433
		// (get) Token: 0x0603AEF9 RID: 241401 RVA: 0x00EF2082 File Offset: 0x00EF0282
		// (set) Token: 0x0603AEFA RID: 241402 RVA: 0x00EF208A File Offset: 0x00EF028A
		public Action OnCloseCallback { get; set; }

		// Token: 0x17009622 RID: 38434
		// (get) Token: 0x0603AEFB RID: 241403 RVA: 0x00EF2093 File Offset: 0x00EF0293
		// (set) Token: 0x0603AEFC RID: 241404 RVA: 0x00EF209B File Offset: 0x00EF029B
		public string Tip { get; set; }

		// Token: 0x17009623 RID: 38435
		// (get) Token: 0x0603AEFD RID: 241405 RVA: 0x00EF20A4 File Offset: 0x00EF02A4
		// (set) Token: 0x0603AEFE RID: 241406 RVA: 0x00EF20AC File Offset: 0x00EF02AC
		public Action<bool> FinishCallback { get; set; }

		// Token: 0x17009624 RID: 38436
		// (get) Token: 0x0603AEFF RID: 241407 RVA: 0x00EF20B5 File Offset: 0x00EF02B5
		// (set) Token: 0x0603AF00 RID: 241408 RVA: 0x00EF20BD File Offset: 0x00EF02BD
		public bool? IsShowOnlineChallengePlayer { get; set; }

		// Token: 0x17009625 RID: 38437
		// (get) Token: 0x0603AF01 RID: 241409 RVA: 0x00EF20C6 File Offset: 0x00EF02C6
		// (set) Token: 0x0603AF02 RID: 241410 RVA: 0x00EF20CE File Offset: 0x00EF02CE
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

		// Token: 0x17009626 RID: 38438
		// (get) Token: 0x0603AF03 RID: 241411 RVA: 0x00EF20D7 File Offset: 0x00EF02D7
		// (set) Token: 0x0603AF04 RID: 241412 RVA: 0x00EF20DF File Offset: 0x00EF02DF
		public ReachTargetData ScoreReachedData { get; set; }

		// Token: 0x17009627 RID: 38439
		// (get) Token: 0x0603AF05 RID: 241413 RVA: 0x00EF20E8 File Offset: 0x00EF02E8
		// (set) Token: 0x0603AF06 RID: 241414 RVA: 0x00EF20F0 File Offset: 0x00EF02F0
		public bool? IsRewardMultiLine { get; set; }

		// Token: 0x17009628 RID: 38440
		// (get) Token: 0x0603AF07 RID: 241415 RVA: 0x00EF20F9 File Offset: 0x00EF02F9
		// (set) Token: 0x0603AF08 RID: 241416 RVA: 0x00EF2101 File Offset: 0x00EF0301
		public AccumulatedScoreData AccumulatedScoreData { get; set; }

		// Token: 0x17009629 RID: 38441
		// (get) Token: 0x0603AF09 RID: 241417 RVA: 0x00EF210A File Offset: 0x00EF030A
		// (set) Token: 0x0603AF0A RID: 241418 RVA: 0x00EF2112 File Offset: 0x00EF0312
		public string TitleTextId { get; set; }

		// Token: 0x1700962A RID: 38442
		// (get) Token: 0x0603AF0B RID: 241419 RVA: 0x00EF211B File Offset: 0x00EF031B
		// (set) Token: 0x0603AF0C RID: 241420 RVA: 0x00EF2123 File Offset: 0x00EF0323
		public IBabelTowerSuccessData BabelTowerSuccessData { get; set; }

		// Token: 0x1700962B RID: 38443
		// (get) Token: 0x0603AF0D RID: 241421 RVA: 0x00EF212C File Offset: 0x00EF032C
		// (set) Token: 0x0603AF0E RID: 241422 RVA: 0x00EF2134 File Offset: 0x00EF0334
		public bool? IsBagFull { get; set; }

		// Token: 0x1700962C RID: 38444
		// (get) Token: 0x0603AF0F RID: 241423 RVA: 0x00EF213D File Offset: 0x00EF033D
		// (set) Token: 0x0603AF10 RID: 241424 RVA: 0x00EF2145 File Offset: 0x00EF0345
		public IDangoAbyssSuccessData DangoAbyssSuccessData { get; set; }

		// Token: 0x1700962D RID: 38445
		// (get) Token: 0x0603AF11 RID: 241425 RVA: 0x00EF214E File Offset: 0x00EF034E
		// (set) Token: 0x0603AF12 RID: 241426 RVA: 0x00EF2156 File Offset: 0x00EF0356
		public IHonamiTowerSuccessData HonamiTowerSuccessData { get; set; }

		// Token: 0x1700962E RID: 38446
		// (get) Token: 0x0603AF13 RID: 241427 RVA: 0x00EF215F File Offset: 0x00EF035F
		// (set) Token: 0x0603AF14 RID: 241428 RVA: 0x00EF2167 File Offset: 0x00EF0367
		public IRoguelikeBossChallengeData RoguelikeBossChallengeData { get; set; }
	}
}
