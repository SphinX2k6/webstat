using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Dango.DangoLogic;
using CSharpScript.Game.Module.RacingBets;
using CSharpScript.Game.Module.RacingBets.Data;

// Token: 0x020026E8 RID: 9960
[NullableContext(1)]
[Nullable(0)]
public class RacingBetsLegMatchData
{
	// Token: 0x170018E2 RID: 6370
	// (get) Token: 0x06013A6F RID: 80495 RVA: 0x0057AB40 File Offset: 0x00578D40
	public int Id
	{
		get
		{
			return this.IdInternal;
		}
	}

	// Token: 0x170018E3 RID: 6371
	// (get) Token: 0x06013A70 RID: 80496 RVA: 0x0057AB48 File Offset: 0x00578D48
	public string Name
	{
		get
		{
			return this.LegMatchConfig.Name;
		}
	}

	// Token: 0x170018E4 RID: 6372
	// (get) Token: 0x06013A71 RID: 80497 RVA: 0x0057AB55 File Offset: 0x00578D55
	public string ShortName
	{
		get
		{
			return this.LegMatchConfig.ShortName;
		}
	}

	// Token: 0x170018E5 RID: 6373
	// (get) Token: 0x06013A72 RID: 80498 RVA: 0x0057AB62 File Offset: 0x00578D62
	public string SimpleName
	{
		get
		{
			return this.LegMatchConfig.SimpleName;
		}
	}

	// Token: 0x170018E6 RID: 6374
	// (get) Token: 0x06013A73 RID: 80499 RVA: 0x0057AB6F File Offset: 0x00578D6F
	public int Type
	{
		get
		{
			return this.LegMatchConfig.Type;
		}
	}

	// Token: 0x170018E7 RID: 6375
	// (get) Token: 0x06013A74 RID: 80500 RVA: 0x0057AB7C File Offset: 0x00578D7C
	public ERacingBetsGroupMatchType GroupMatchType
	{
		get
		{
			return this.ParentMatchData.MatchType;
		}
	}

	// Token: 0x170018E8 RID: 6376
	// (get) Token: 0x06013A75 RID: 80501 RVA: 0x0057AB89 File Offset: 0x00578D89
	public RacingBetsGroupMatchData ParentGroupMatchData
	{
		get
		{
			return this.ParentMatchData;
		}
	}

	// Token: 0x170018E9 RID: 6377
	// (get) Token: 0x06013A76 RID: 80502 RVA: 0x0057AB91 File Offset: 0x00578D91
	public double BetsStartTime
	{
		get
		{
			return this.BetsStartTimeInternal;
		}
	}

	// Token: 0x170018EA RID: 6378
	// (get) Token: 0x06013A77 RID: 80503 RVA: 0x0057AB99 File Offset: 0x00578D99
	public double BetsEndTime
	{
		get
		{
			return this.BetsEndTimeInternal;
		}
	}

	// Token: 0x170018EB RID: 6379
	// (get) Token: 0x06013A78 RID: 80504 RVA: 0x0057ABA1 File Offset: 0x00578DA1
	public double MatchStartTime
	{
		get
		{
			return this.MatchStartTimeInternal;
		}
	}

	// Token: 0x170018EC RID: 6380
	// (get) Token: 0x06013A79 RID: 80505 RVA: 0x0057ABA9 File Offset: 0x00578DA9
	public double MatchEndTime
	{
		get
		{
			return this.MatchEndTimeInternal;
		}
	}

	// Token: 0x170018ED RID: 6381
	// (get) Token: 0x06013A7A RID: 80506 RVA: 0x0057ABB1 File Offset: 0x00578DB1
	public bool HasBetting
	{
		get
		{
			return this.HasBettingInternal;
		}
	}

	// Token: 0x170018EE RID: 6382
	// (get) Token: 0x06013A7B RID: 80507 RVA: 0x0057ABB9 File Offset: 0x00578DB9
	public int BetDangoId
	{
		get
		{
			return this.BetDangoIdInternal;
		}
	}

	// Token: 0x170018EF RID: 6383
	// (get) Token: 0x06013A7C RID: 80508 RVA: 0x0057ABC1 File Offset: 0x00578DC1
	public string MatchBtnBgPath
	{
		get
		{
			return this.LegMatchConfig.BtnBgPath;
		}
	}

	// Token: 0x06013A7D RID: 80509 RVA: 0x0057ABD0 File Offset: 0x00578DD0
	public int GetBetDangoRank()
	{
		if (this.DangoRank.Count < 0)
		{
			return 0;
		}
		int result = 0;
		for (int i = 0; i < this.DangoRank.Count; i++)
		{
			if (this.BetDangoId == this.DangoRank[i])
			{
				result = i + 1;
				break;
			}
		}
		return result;
	}

	// Token: 0x170018F0 RID: 6384
	// (get) Token: 0x06013A7E RID: 80510 RVA: 0x0057AC20 File Offset: 0x00578E20
	public int BetGearId
	{
		get
		{
			return this.BetGearIdInternal;
		}
	}

	// Token: 0x170018F1 RID: 6385
	// (get) Token: 0x06013A7F RID: 80511 RVA: 0x0057AC28 File Offset: 0x00578E28
	public int BetGearCash
	{
		get
		{
			return this.BetGearCashInternal;
		}
	}

	// Token: 0x170018F2 RID: 6386
	// (get) Token: 0x06013A80 RID: 80512 RVA: 0x0057AC30 File Offset: 0x00578E30
	public double NextOddsRateRefreshTime
	{
		get
		{
			return this.NextOddsRateRefreshTimeInternal;
		}
	}

	// Token: 0x170018F3 RID: 6387
	// (get) Token: 0x06013A81 RID: 80513 RVA: 0x0057AC38 File Offset: 0x00578E38
	public bool IsFinalOddsRefresh
	{
		get
		{
			return this.IsFinalOddsRefreshInternal;
		}
	}

	// Token: 0x170018F4 RID: 6388
	// (get) Token: 0x06013A82 RID: 80514 RVA: 0x0057AC40 File Offset: 0x00578E40
	public int Odds
	{
		get
		{
			return this.OddsInternal;
		}
	}

	// Token: 0x170018F5 RID: 6389
	// (get) Token: 0x06013A83 RID: 80515 RVA: 0x0057AC48 File Offset: 0x00578E48
	public string OddsVersion
	{
		get
		{
			return this.OddsVersionInternal;
		}
	}

	// Token: 0x170018F6 RID: 6390
	// (get) Token: 0x06013A84 RID: 80516 RVA: 0x0057AC50 File Offset: 0x00578E50
	public int LeaveCancelNum
	{
		get
		{
			return this.LeaveCancelNumInternal;
		}
	}

	// Token: 0x170018F7 RID: 6391
	// (get) Token: 0x06013A85 RID: 80517 RVA: 0x0057AC58 File Offset: 0x00578E58
	public int OddsReward
	{
		get
		{
			return this.OddsRewardInternal;
		}
	}

	// Token: 0x06013A86 RID: 80518 RVA: 0x0057AC60 File Offset: 0x00578E60
	public unsafe void Init(RacingBetsLegMatchesInfo legMatchInfo, RacingBetsGroupMatchData matchData)
	{
		this.IdInternal = legMatchInfo.Id;
		this.LegMatchConfig = ConfigBase<RacingBetsConfig>.Instance.GetRacingBetsLegMatches(this.IdInternal).Value;
		this.ParentMatchData = matchData;
		this.MatchWholeStartTimeInternal = (double)Singleton<MathUtils>.Instance.LongToBigInt(legMatchInfo.LegMatchWholeTime.BeginTime);
		this.MatchWholeEndTimeInternal = (double)Singleton<MathUtils>.Instance.LongToBigInt(legMatchInfo.LegMatchWholeTime.EndTime);
		this.BetsStartTimeInternal = (double)Singleton<MathUtils>.Instance.LongToBigInt(legMatchInfo.GearStartEndTime.BeginTime);
		this.BetsEndTimeInternal = (double)Singleton<MathUtils>.Instance.LongToBigInt(legMatchInfo.GearStartEndTime.EndTime);
		this.MatchStartTimeInternal = (double)Singleton<MathUtils>.Instance.LongToBigInt(legMatchInfo.MatchStartEndTime.BeginTime);
		this.MatchEndTimeInternal = (double)Singleton<MathUtils>.Instance.LongToBigInt(legMatchInfo.MatchStartEndTime.EndTime);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.RacingBets;
		ELogAuthor author = ELogAuthor.LRC;
		string message = "RacingBetsLegMatchData Init";
		<>y__InlineArray7<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray7<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", this.Id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("MatchWholeStartTimeInternal", this.MatchWholeStartTimeInternal);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("MatchWholeEndTimeInternal", this.MatchWholeEndTimeInternal);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("BetsStartTimeInternal", this.BetsStartTimeInternal);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("BetsEndTimeInternal", this.BetsEndTimeInternal);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("MatchStartTimeInternal", this.MatchStartTimeInternal);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 6) = new ValueTuple<string, object>("MatchEndTimeInternal", this.MatchEndTimeInternal);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 7));
		this.Refresh(legMatchInfo);
	}

	// Token: 0x06013A87 RID: 80519 RVA: 0x0057AE64 File Offset: 0x00579064
	public unsafe void RefreshBetInfo(RacingBetsGearInfo info)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.RacingBets;
		ELogAuthor author = ELogAuthor.BB;
		string message = "RacingBetsLegMatchData刷新下注信息";
		<>y__InlineArray8<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray8<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", this.Id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("BetDangoId", info.DangoId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("BetGearId", info.BettingGearId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("BetGearCash", info.BettingGearCash);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("Odds", info.Odds);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("OddsVersion", info.OddsVersion);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 6) = new ValueTuple<string, object>("LeaveCancelNum", info.LeaveCancelNum);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 7) = new ValueTuple<string, object>("OddsReward", info.OddsReward);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray8<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 8));
		this.HasBettingInternal = (info.DangoId > 0);
		this.BetDangoIdInternal = info.DangoId;
		this.BetGearIdInternal = info.BettingGearId;
		this.BetGearCashInternal = info.BettingGearCash;
		this.OddsInternal = info.Odds;
		this.OddsVersionInternal = info.OddsVersion;
		this.LeaveCancelNumInternal = info.LeaveCancelNum;
		this.OddsRewardInternal = info.OddsReward;
	}

	// Token: 0x06013A88 RID: 80520 RVA: 0x0057B005 File Offset: 0x00579205
	public void RefreshLegMatchResultNotify(RacingBetLegMatchResultNotify data)
	{
		this.BetDangoIdInternal = data.BetDangoId;
		this.BetGearCashInternal = data.BetCount;
		this.OddsRewardInternal = data.Reward;
	}

	// Token: 0x06013A89 RID: 80521 RVA: 0x0057B02C File Offset: 0x0057922C
	public void Refresh(RacingBetsLegMatchesInfo legMatchInfo)
	{
		this.DangoRank = new List<int>(legMatchInfo.DangoRank);
		long num = Singleton<MathUtils>.Instance.LongToBigInt(legMatchInfo.NextOddsTime);
		double serverTimeStamp = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
		this.IsFinalOddsRefreshInternal = (serverTimeStamp >= (double)num);
		this.NextOddsRateRefreshTimeInternal = (double)num;
		this.OddsVersionInternal = legMatchInfo.OddsVersion;
		this.RefreshDangoActorInfo(new List<RacingBetsDangoInfo>(legMatchInfo.DangoInfo));
	}

	// Token: 0x06013A8A RID: 80522 RVA: 0x0057B09C File Offset: 0x0057929C
	public void RefreshDangoOdds(RacingBetsUpdateOddsResponse info)
	{
		long num = Singleton<MathUtils>.Instance.LongToBigInt(info.NextOddsTime);
		double serverTimeStamp = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
		this.IsFinalOddsRefreshInternal = (serverTimeStamp >= (double)num);
		this.NextOddsRateRefreshTimeInternal = (double)num;
		this.OddsVersionInternal = info.OddsVersion;
		this.RefreshDangoActorInfo(new List<RacingBetsDangoInfo>(info.DangoInfo));
	}

	// Token: 0x06013A8B RID: 80523 RVA: 0x0057B0F8 File Offset: 0x005792F8
	private void RefreshDangoActorInfo(List<RacingBetsDangoInfo> dangoInfo)
	{
		if (this.DangoActorDataList.Count <= 0 && this.AbuDangoData == null)
		{
			int num = 0;
			using (List<RacingBetsDangoInfo>.Enumerator enumerator = dangoInfo.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					RacingBetsDangoInfo racingBetsDangoInfo = enumerator.Current;
					DangoConfig instance = ConfigBase<DangoConfig>.Instance;
					Dango? dango = (instance != null) ? instance.GetDangoById(racingBetsDangoInfo.Id) : null;
					if (dango != null && dango.GetValueOrDefault().Type == 1)
					{
						this.AbuDangoData = new RacingBetsDangoActorData
						{
							UiModelUseWay = EUiModelUseWay.OddsDango,
							DangoId = racingBetsDangoInfo.Id,
							Odds = 0,
							DangoPointCase = "DangoCase7",
							DangoCamera = "Camera_DangoFocus_7",
							IsAbuDango = true
						};
						this.AllDangoActorDataList.Add(this.AbuDangoData);
					}
					else
					{
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
						defaultInterpolatedStringHandler.AppendLiteral("DangoCase");
						defaultInterpolatedStringHandler.AppendFormatted<int>(num + 1);
						string dangoPointCase = defaultInterpolatedStringHandler.ToStringAndClear();
						defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 1);
						defaultInterpolatedStringHandler.AppendLiteral("Camera_DangoFocus_");
						defaultInterpolatedStringHandler.AppendFormatted<int>(num + 1);
						string dangoCamera = defaultInterpolatedStringHandler.ToStringAndClear();
						float dangoOffset = RacingBetsDefine.RacingBetsDangoOddsOffsetList[num];
						RacingBetsDangoActorData item = new RacingBetsDangoActorData
						{
							UiModelUseWay = EUiModelUseWay.OddsDango,
							DangoId = racingBetsDangoInfo.Id,
							Odds = racingBetsDangoInfo.Odds,
							DangoPointCase = dangoPointCase,
							DangoCamera = dangoCamera,
							DangoOffset = dangoOffset,
							IsAbuDango = false
						};
						this.DangoActorDataList.Add(item);
						this.AllDangoActorDataList.Add(item);
						num++;
					}
				}
				return;
			}
		}
		foreach (RacingBetsDangoInfo racingBetsDangoInfo2 in dangoInfo)
		{
			DangoConfig instance2 = ConfigBase<DangoConfig>.Instance;
			Dango? dango2 = (instance2 != null) ? instance2.GetDangoById(racingBetsDangoInfo2.Id) : null;
			if (dango2 == null || dango2.GetValueOrDefault().Type != 1)
			{
				IRacingBetsDangoActorData dangoActorData = this.GetDangoActorData(racingBetsDangoInfo2.Id);
				if (dangoActorData != null)
				{
					dangoActorData.Odds = racingBetsDangoInfo2.Odds;
				}
			}
		}
	}

	// Token: 0x06013A8C RID: 80524 RVA: 0x0057B374 File Offset: 0x00579574
	public void RefreshLegMatchResult(MatchResult matchResult)
	{
		this.DangoRank = new List<int>(matchResult.DangoRank);
	}

	// Token: 0x06013A8D RID: 80525 RVA: 0x0057B388 File Offset: 0x00579588
	public ERacingBetsLegMatchState GetLegMatchState()
	{
		double serverTimeStamp = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
		if (serverTimeStamp < this.MatchWholeStartTimeInternal)
		{
			return ERacingBetsLegMatchState.NotOpen;
		}
		if (serverTimeStamp < this.BetsEndTimeInternal)
		{
			return ERacingBetsLegMatchState.BettingPeriod;
		}
		if (serverTimeStamp < this.MatchStartTimeInternal)
		{
			return ERacingBetsLegMatchState.EndOfBetting;
		}
		if (serverTimeStamp < this.MatchEndTimeInternal)
		{
			if (this.DangoRank.Count <= 0)
			{
				return ERacingBetsLegMatchState.MatchPeriod;
			}
			return ERacingBetsLegMatchState.EndOfMatch;
		}
		else
		{
			if (serverTimeStamp >= this.MatchWholeEndTimeInternal)
			{
				return ERacingBetsLegMatchState.End;
			}
			if (this.DangoRank.Count > 0)
			{
				return ERacingBetsLegMatchState.EndOfMatch;
			}
			return ERacingBetsLegMatchState.MatchPeriod;
		}
	}

	// Token: 0x06013A8E RID: 80526 RVA: 0x0057B3F8 File Offset: 0x005795F8
	public double GetLegRemindTime()
	{
		RacingBetsSeasonData racingBetsSeasonData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsSeasonData();
		if (racingBetsSeasonData == null)
		{
			return 0.0;
		}
		double serverTimeStamp = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
		if (serverTimeStamp < this.BetsStartTimeInternal || this.DangoActorDataList.Count <= 0)
		{
			return Singleton<TimeUtil>.Instance.SetTimeSecond(this.BetsStartTimeInternal - serverTimeStamp);
		}
		if (serverTimeStamp < this.BetsEndTimeInternal)
		{
			return Singleton<TimeUtil>.Instance.SetTimeSecond(this.BetsEndTimeInternal - serverTimeStamp);
		}
		if (serverTimeStamp < this.MatchStartTimeInternal)
		{
			return Singleton<TimeUtil>.Instance.SetTimeSecond(this.MatchStartTimeInternal - serverTimeStamp);
		}
		if (this.DangoRank.Count <= 0 && serverTimeStamp < this.MatchEndTimeInternal)
		{
			return Singleton<TimeUtil>.Instance.SetTimeSecond(this.MatchEndTimeInternal - serverTimeStamp);
		}
		RacingBetsLegMatchData nextLegMatchData = racingBetsSeasonData.GetNextLegMatchData(this.IdInternal);
		if (nextLegMatchData != null)
		{
			return Singleton<TimeUtil>.Instance.SetTimeSecond(nextLegMatchData.BetsStartTimeInternal - serverTimeStamp);
		}
		return 0.0;
	}

	// Token: 0x06013A8F RID: 80527 RVA: 0x0057B4E0 File Offset: 0x005796E0
	public bool IsLegMatchFinished()
	{
		ERacingBetsLegMatchState legMatchState = this.GetLegMatchState();
		return legMatchState == ERacingBetsLegMatchState.EndOfMatch || legMatchState == ERacingBetsLegMatchState.End;
	}

	// Token: 0x06013A90 RID: 80528 RVA: 0x0057B4FE File Offset: 0x005796FE
	private string GetResultShowGroupName(int groupMatchId)
	{
		RacingBetsGroupMatchData racingBetsGroupMatchData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsGroupMatchData(groupMatchId);
		return ((racingBetsGroupMatchData != null) ? racingBetsGroupMatchData.ShortName : null) ?? "";
	}

	// Token: 0x06013A91 RID: 80529 RVA: 0x0057B520 File Offset: 0x00579720
	private bool IsLastLegMatchInGroup()
	{
		List<RacingBetsLegMatchData> legMatchList = this.ParentMatchData.GetLegMatchList();
		RacingBetsLegMatchData racingBetsLegMatchData = legMatchList.ElementAtOrDefault(legMatchList.Count - 1);
		int? num = (racingBetsLegMatchData != null) ? new int?(racingBetsLegMatchData.Id) : null;
		int idInternal = this.IdInternal;
		return num.GetValueOrDefault() == idInternal & num != null;
	}

	// Token: 0x06013A92 RID: 80530 RVA: 0x0057B57C File Offset: 0x0057977C
	public List<IRacingBetsLegMatchResultData> GetLegMatchResultList()
	{
		List<int> promoteDangoList = this.ParentMatchData.GetPromoteDangoList();
		List<IRacingBetsLegMatchResultData> list = new List<IRacingBetsLegMatchResultData>();
		bool flag = ModelBase<RacingBetsModel>.Instance.IsFinalLegMatch(this.IdInternal);
		bool flag2 = this.IsLastLegMatchInGroup();
		RacingBetsGroupMatchData parentMatchData = this.ParentMatchData;
		ERacingBetsLegMatchResultType resultShowType = flag2 ? parentMatchData.ResultShowType : ERacingBetsLegMatchResultType.Hidden;
		int advancedNextGroupMatchId = parentMatchData.AdvancedNextGroupMatchId;
		int loserNextGroupMatchId = parentMatchData.LoserNextGroupMatchId;
		for (int i = 0; i < this.DangoRank.Count; i++)
		{
			int num = this.DangoRank[i];
			bool hasAdvanced = promoteDangoList.Contains(num);
			RacingBetsLegMatchResultData item = new RacingBetsLegMatchResultData
			{
				DangoId = num,
				Rank = i + 1,
				HasAdvanced = hasAdvanced,
				LegMatchType = (ERacingBetsLegMatchType)this.Type,
				IsChampion = (flag && i == 0),
				ResultShowType = resultShowType,
				AdvancedNextMatchName = ((advancedNextGroupMatchId > 0) ? this.GetResultShowGroupName(advancedNextGroupMatchId) : ""),
				LoserNextMatchName = ((loserNextGroupMatchId > 0) ? this.GetResultShowGroupName(loserNextGroupMatchId) : "")
			};
			list.Add(item);
		}
		return list;
	}

	// Token: 0x06013A93 RID: 80531 RVA: 0x0057B694 File Offset: 0x00579894
	public int GetChampionDangoId()
	{
		if (this.DangoRank.Count <= 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RacingBets;
			ELogAuthor author = ELogAuthor.BB;
			string message = "半场赛没有排名数据";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("LegMatchId", this.Id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return 0;
		}
		return this.DangoRank[0];
	}

	// Token: 0x06013A94 RID: 80532 RVA: 0x0057B6F4 File Offset: 0x005798F4
	[NullableContext(2)]
	public unsafe IRacingBetsDangoActorData GetDangoActorData(int dangoId)
	{
		foreach (IRacingBetsDangoActorData racingBetsDangoActorData in this.DangoActorDataList)
		{
			if (racingBetsDangoActorData.DangoId == dangoId)
			{
				return racingBetsDangoActorData;
			}
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.RacingBets;
		ELogAuthor author = ELogAuthor.BB;
		string message = "RacingBetsLegMatchData Invalid DangoId";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("MatchId", this.Id);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("DangoId", dangoId);
		instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		return null;
	}

	// Token: 0x06013A95 RID: 80533 RVA: 0x0057B7B8 File Offset: 0x005799B8
	public List<IRacingBetsDangoActorData> GetAllDangoActorDataList()
	{
		return this.AllDangoActorDataList;
	}

	// Token: 0x06013A96 RID: 80534 RVA: 0x0057B7C0 File Offset: 0x005799C0
	public int GetOddsRewardCount()
	{
		return (int)Math.Ceiling((double)(this.BetGearCash * this.Odds) / 100.0);
	}

	// Token: 0x06013A97 RID: 80535 RVA: 0x0057B7E0 File Offset: 0x005799E0
	public ERacingBetsMainViewShowType GetRacingBetsMainViewActorShowType(ERacingBetsLegMatchState matchState)
	{
		if (ModelBase<RacingBetsModel>.Instance.IsFinalLegMatch(this.IdInternal) && (matchState == ERacingBetsLegMatchState.EndOfMatch || matchState == ERacingBetsLegMatchState.End))
		{
			return ERacingBetsMainViewShowType.OneDango;
		}
		if (matchState == ERacingBetsLegMatchState.EndOfMatch)
		{
			return ERacingBetsMainViewShowType.OneDango;
		}
		return ERacingBetsMainViewShowType.SixDango;
	}

	// Token: 0x06013A98 RID: 80536 RVA: 0x0057B805 File Offset: 0x00579A05
	public string GetMainViewCameraHandleName(ERacingBetsMainViewShowType showType)
	{
		if (showType == ERacingBetsMainViewShowType.OneDango)
		{
			return "Camera_DangoFocus_RaceEnd";
		}
		return "Camera_DangoPreview_6Player";
	}

	// Token: 0x06013A99 RID: 80537 RVA: 0x0057B818 File Offset: 0x00579A18
	[NullableContext(2)]
	public IRacingBetsDangoActorData GetChampionDangoActorData()
	{
		if (this.DangoRank.Count <= 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RacingBets;
			ELogAuthor author = ELogAuthor.BB;
			string message = "半场赛没有排名数据";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("LegMatchId", this.Id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return new RacingBetsDangoActorData
		{
			UiModelUseWay = EUiModelUseWay.Dango,
			DangoId = this.DangoRank[0],
			Odds = 0,
			DangoPointCase = "DangoChampionCase",
			DangoCamera = "",
			DangoOffset = 0f
		};
	}

	// Token: 0x06013A9A RID: 80538 RVA: 0x0057B8B0 File Offset: 0x00579AB0
	[return: TupleElementNames(new string[]
	{
		"Text",
		"DangoId"
	})]
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public ValueTuple<string, int> GetDangoBroadcastText()
	{
		int num;
		if (this.DangoRank.Count > 0)
		{
			num = this.DangoRank[0];
		}
		else
		{
			int index = new Random().Next(this.DangoActorDataList.Count);
			num = this.DangoActorDataList[index].DangoId;
		}
		string item = "";
		DangoBroadcast? racingBetsDangoBroadcast = ConfigBase<RacingBetsConfig>.Instance.GetRacingBetsDangoBroadcast(num);
		if (racingBetsDangoBroadcast == null)
		{
			return new ValueTuple<string, int>(item, num);
		}
		ERacingBetsGroupMatchType matchType = this.ParentMatchData.MatchType;
		int num2 = new Random().Next(2);
		switch (matchType)
		{
		case ERacingBetsGroupMatchType.GroupStage:
			item = (this.IsLegMatchFinished() ? racingBetsDangoBroadcast.Value.GroupStageChampText : ((num2 == 0) ? racingBetsDangoBroadcast.Value.GroupStageCheerText1 : racingBetsDangoBroadcast.Value.GroupStageCheerText2));
			break;
		case ERacingBetsGroupMatchType.PromotionRound:
			item = (this.IsLegMatchFinished() ? racingBetsDangoBroadcast.Value.AdvanceStageChampText : ((num2 == 0) ? racingBetsDangoBroadcast.Value.AdvanceStageCheerText1 : racingBetsDangoBroadcast.Value.AdvanceStageCheerText2));
			break;
		case ERacingBetsGroupMatchType.Final:
			item = (this.IsLegMatchFinished() ? racingBetsDangoBroadcast.Value.FinalStageChampText : ((num2 == 0) ? racingBetsDangoBroadcast.Value.FinalStageCheerText1 : racingBetsDangoBroadcast.Value.FinalStageCheerText2));
			break;
		case ERacingBetsGroupMatchType.ShowMatch:
			item = (this.IsLegMatchFinished() ? racingBetsDangoBroadcast.Value.ShowMatchChampText : racingBetsDangoBroadcast.Value.ShowMatchText);
			break;
		}
		return new ValueTuple<string, int>(item, num);
	}

	// Token: 0x06013A9B RID: 80539 RVA: 0x0057BA60 File Offset: 0x00579C60
	public string GetRandomRuleText()
	{
		RacingBetsSeasonData racingBetsSeasonData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsSeasonData();
		if (racingBetsSeasonData == null)
		{
			return "";
		}
		int id = racingBetsSeasonData.Id;
		IReadOnlyList<RacingBetsRuleTextPool> randomRuleTextPool = ConfigBase<RacingBetsConfig>.Instance.GetRandomRuleTextPool(id);
		if (randomRuleTextPool == null)
		{
			return "";
		}
		ERacingBetsLegMatchState legMatchState = this.GetLegMatchState();
		int num = (legMatchState == ERacingBetsLegMatchState.NotOpen || legMatchState == ERacingBetsLegMatchState.BettingPeriod || legMatchState == ERacingBetsLegMatchState.EndOfBetting || legMatchState == ERacingBetsLegMatchState.MatchPeriod) ? 0 : 1;
		List<RacingBetsRuleTextPool> list = new List<RacingBetsRuleTextPool>();
		foreach (RacingBetsRuleTextPool item in randomRuleTextPool)
		{
			if (item.LegMatchId == this.IdInternal && item.MatchState == num)
			{
				list.Add(item);
			}
		}
		if (list.Count <= 0)
		{
			return "";
		}
		int index = new Random().Next(list.Count);
		return list[index].RuleText;
	}

	// Token: 0x040098DE RID: 39134
	private int IdInternal;

	// Token: 0x040098DF RID: 39135
	private bool HasBettingInternal;

	// Token: 0x040098E0 RID: 39136
	private int BetDangoIdInternal;

	// Token: 0x040098E1 RID: 39137
	private int BetGearIdInternal;

	// Token: 0x040098E2 RID: 39138
	private int BetGearCashInternal;

	// Token: 0x040098E3 RID: 39139
	private double NextOddsRateRefreshTimeInternal;

	// Token: 0x040098E4 RID: 39140
	private bool IsFinalOddsRefreshInternal;

	// Token: 0x040098E5 RID: 39141
	private int OddsInternal;

	// Token: 0x040098E6 RID: 39142
	private string OddsVersionInternal = "";

	// Token: 0x040098E7 RID: 39143
	private int LeaveCancelNumInternal;

	// Token: 0x040098E8 RID: 39144
	private int OddsRewardInternal;

	// Token: 0x040098E9 RID: 39145
	private double MatchWholeStartTimeInternal;

	// Token: 0x040098EA RID: 39146
	private double MatchWholeEndTimeInternal;

	// Token: 0x040098EB RID: 39147
	private double BetsStartTimeInternal;

	// Token: 0x040098EC RID: 39148
	private double BetsEndTimeInternal;

	// Token: 0x040098ED RID: 39149
	private double MatchStartTimeInternal;

	// Token: 0x040098EE RID: 39150
	private double MatchEndTimeInternal;

	// Token: 0x040098EF RID: 39151
	private RacingBetsLegMatches LegMatchConfig;

	// Token: 0x040098F0 RID: 39152
	private List<int> DangoRank = new List<int>();

	// Token: 0x040098F1 RID: 39153
	private RacingBetsGroupMatchData ParentMatchData;

	// Token: 0x040098F2 RID: 39154
	private readonly List<IRacingBetsDangoActorData> DangoActorDataList = new List<IRacingBetsDangoActorData>();

	// Token: 0x040098F3 RID: 39155
	private readonly List<IRacingBetsDangoActorData> AllDangoActorDataList = new List<IRacingBetsDangoActorData>();

	// Token: 0x040098F4 RID: 39156
	[Nullable(2)]
	private IRacingBetsDangoActorData AbuDangoData;
}
