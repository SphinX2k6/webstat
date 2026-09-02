using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Dango.DangoLogic;
using CSharpScript.Game.Module.RacingBets;

// Token: 0x020026E6 RID: 9958
[NullableContext(1)]
[Nullable(0)]
public class RacingBetsGroupMatchData
{
	// Token: 0x06013A56 RID: 80470 RVA: 0x0057A240 File Offset: 0x00578440
	public void Init(RacingBetsGroupMatchesInfo matchInfo)
	{
		this.Id = matchInfo.GroupMatchId;
		this.MatchConfig = ConfigBase<RacingBetsConfig>.Instance.GetRacingBetsGroupMatch(this.Id);
		this.MatchTypeInternal = (ERacingBetsGroupMatchType)this.MatchConfig.Value.Type;
		this.InitLegMatchList(new List<RacingBetsLegMatchesInfo>(matchInfo.LegMatchesInfo));
		this.PromoteDangoList = new List<int>(matchInfo.PromoteDangos);
		this.UpdateDangoIdList(new List<int>(matchInfo.Dangos));
	}

	// Token: 0x06013A57 RID: 80471 RVA: 0x0057A2BB File Offset: 0x005784BB
	public void Refresh(RacingBetsGroupMatchesInfo matchInfo)
	{
		this.PromoteDangoList = new List<int>(matchInfo.PromoteDangos);
		this.UpdateDangoIdList(new List<int>(matchInfo.Dangos));
	}

	// Token: 0x06013A58 RID: 80472 RVA: 0x0057A2E0 File Offset: 0x005784E0
	private void UpdateDangoIdList(List<int> idList)
	{
		this.InGameDangoIdList = new List<int>();
		foreach (int num in idList)
		{
			DangoConfig instance = ConfigBase<DangoConfig>.Instance;
			Dango? dango = (instance != null) ? instance.GetDangoById(num) : null;
			if (dango == null || dango.GetValueOrDefault().Type != 1)
			{
				this.InGameDangoIdList.Add(num);
			}
		}
		if (this.PromoteDangoList.Count > 0)
		{
			HashSet<int> hashSet = new HashSet<int>(this.PromoteDangoList);
			this.LossDangoList = new List<int>();
			foreach (int item in this.InGameDangoIdList)
			{
				if (!hashSet.Contains(item))
				{
					this.LossDangoList.Add(item);
				}
			}
		}
	}

	// Token: 0x06013A59 RID: 80473 RVA: 0x0057A3F8 File Offset: 0x005785F8
	private void InitLegMatchList(List<RacingBetsLegMatchesInfo> legMatchInfo)
	{
		this.LegMatchList = new List<RacingBetsLegMatchData>();
		foreach (RacingBetsLegMatchesInfo legMatchInfo2 in legMatchInfo)
		{
			RacingBetsLegMatchData racingBetsLegMatchData = new RacingBetsLegMatchData();
			racingBetsLegMatchData.Init(legMatchInfo2, this);
			this.LegMatchList.Add(racingBetsLegMatchData);
		}
	}

	// Token: 0x06013A5A RID: 80474 RVA: 0x0057A464 File Offset: 0x00578664
	public void RefreshGroupMatchResult(MatchResult matchResult)
	{
		this.PromoteDangoList = new List<int>();
		int num = 0;
		while (num < matchResult.PromoteNum && num < matchResult.DangoRank.Count)
		{
			this.PromoteDangoList.Add(matchResult.DangoRank[num]);
			num++;
		}
	}

	// Token: 0x06013A5B RID: 80475 RVA: 0x0057A4B2 File Offset: 0x005786B2
	public List<RacingBetsLegMatchData> GetLegMatchList()
	{
		return this.LegMatchList;
	}

	// Token: 0x06013A5C RID: 80476 RVA: 0x0057A4BA File Offset: 0x005786BA
	public List<int> GetPromoteDangoList()
	{
		return this.PromoteDangoList;
	}

	// Token: 0x06013A5D RID: 80477 RVA: 0x0057A4C2 File Offset: 0x005786C2
	public List<int> GetLossDangoList()
	{
		return this.LossDangoList;
	}

	// Token: 0x170018DC RID: 6364
	// (get) Token: 0x06013A5E RID: 80478 RVA: 0x0057A4CA File Offset: 0x005786CA
	public ERacingBetsGroupMatchType MatchType
	{
		get
		{
			return this.MatchTypeInternal;
		}
	}

	// Token: 0x170018DD RID: 6365
	// (get) Token: 0x06013A5F RID: 80479 RVA: 0x0057A4D4 File Offset: 0x005786D4
	public string Name
	{
		get
		{
			return ((this.MatchConfig != null) ? this.MatchConfig.GetValueOrDefault().Name : null) ?? string.Empty;
		}
	}

	// Token: 0x170018DE RID: 6366
	// (get) Token: 0x06013A60 RID: 80480 RVA: 0x0057A50C File Offset: 0x0057870C
	public string ShortName
	{
		get
		{
			return ((this.MatchConfig != null) ? this.MatchConfig.GetValueOrDefault().ShortName : null) ?? string.Empty;
		}
	}

	// Token: 0x170018DF RID: 6367
	// (get) Token: 0x06013A61 RID: 80481 RVA: 0x0057A544 File Offset: 0x00578744
	public ERacingBetsLegMatchResultType ResultShowType
	{
		get
		{
			if (this.MatchConfig == null)
			{
				return ERacingBetsLegMatchResultType.Hidden;
			}
			return (ERacingBetsLegMatchResultType)this.MatchConfig.GetValueOrDefault().ResultShowType;
		}
	}

	// Token: 0x170018E0 RID: 6368
	// (get) Token: 0x06013A62 RID: 80482 RVA: 0x0057A570 File Offset: 0x00578770
	public int AdvancedNextGroupMatchId
	{
		get
		{
			if (this.MatchConfig == null)
			{
				return 0;
			}
			return this.MatchConfig.GetValueOrDefault().AdvancedGroupId;
		}
	}

	// Token: 0x170018E1 RID: 6369
	// (get) Token: 0x06013A63 RID: 80483 RVA: 0x0057A59C File Offset: 0x0057879C
	public int LoserNextGroupMatchId
	{
		get
		{
			if (this.MatchConfig == null)
			{
				return 0;
			}
			return this.MatchConfig.GetValueOrDefault().LoseGroupId;
		}
	}

	// Token: 0x06013A64 RID: 80484 RVA: 0x0057A5C8 File Offset: 0x005787C8
	public bool IsGroupMatchFinished()
	{
		using (List<RacingBetsLegMatchData>.Enumerator enumerator = this.LegMatchList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (!enumerator.Current.IsLegMatchFinished())
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x06013A65 RID: 80485 RVA: 0x0057A624 File Offset: 0x00578824
	public List<int> GetInGameDangoList()
	{
		if (this.InGameDangoIdList.Count != 0 || (this.MatchConfig != null && this.MatchConfig.GetValueOrDefault().DangoIsOnlyReadServerData))
		{
			return this.InGameDangoIdList;
		}
		if (this.MatchConfig != null && this.MatchConfig.GetValueOrDefault().DangoList().Length != 0)
		{
			return new List<int>(this.MatchConfig.Value.DangoList());
		}
		if (this.MatchConfig == null || this.MatchConfig.GetValueOrDefault().DangoSourceMatchScheduleId != 0)
		{
			return this.GetMatchDangoListByLastScheduleAdvanced();
		}
		List<int> list = new List<int>();
		foreach (int matchId in this.SourceAdvanceGroupMatchIdList)
		{
			RacingBetsGroupMatchData racingBetsGroupMatchData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsGroupMatchData(matchId);
			if (racingBetsGroupMatchData != null)
			{
				list.AddRange(racingBetsGroupMatchData.GetPromoteDangoList());
			}
		}
		foreach (int matchId2 in this.SourceLossGroupMatchIdList)
		{
			RacingBetsGroupMatchData racingBetsGroupMatchData2 = ModelBase<RacingBetsModel>.Instance.GetRacingBetsGroupMatchData(matchId2);
			if (racingBetsGroupMatchData2 != null)
			{
				list.AddRange(racingBetsGroupMatchData2.GetLossDangoList());
			}
		}
		return list;
	}

	// Token: 0x06013A66 RID: 80486 RVA: 0x0057A790 File Offset: 0x00578990
	public unsafe List<int> GetMatchDangoListByLastScheduleAdvanced()
	{
		if (this.MatchConfig == null)
		{
			return new List<int>();
		}
		RacingBetsMatch? matchTableConfigById = ConfigBase<RacingBetsConfig>.Instance.GetMatchTableConfigById(this.MatchConfig.Value.DangoSourceMatchScheduleId);
		if (matchTableConfigById == null)
		{
			return new List<int>();
		}
		int num = 0;
		foreach (int num2 in matchTableConfigById.Value.AdvancedDangoIdTargetGroupMatchList())
		{
			if (num2 != this.Id)
			{
				num = num2;
				break;
			}
		}
		if (num == 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RacingBets;
			ELogAuthor author = ELogAuthor.CXJ;
			string message = "Advanced dango destination config error for previous schedule";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("groupMatchId", this.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("scheduleId", matchTableConfigById.Value.Id);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return new List<int>();
		}
		RacingBetsGroupMatchData racingBetsGroupMatchData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsGroupMatchData(num);
		if (racingBetsGroupMatchData == null)
		{
			return new List<int>();
		}
		List<int> inGameDangoList = racingBetsGroupMatchData.GetInGameDangoList();
		if (inGameDangoList.Count == 0)
		{
			return new List<int>();
		}
		List<int> advanceMatchDangoList = ModelBase<RacingBetsModel>.Instance.GetAdvanceMatchDangoList((ERacingBetsMatchTableType)this.MatchConfig.Value.DangoSourceMatchScheduleId);
		HashSet<int> hashSet = new HashSet<int>(inGameDangoList);
		List<int> list = new List<int>();
		foreach (int item in advanceMatchDangoList)
		{
			if (!hashSet.Contains(item))
			{
				list.Add(item);
			}
		}
		return list;
	}

	// Token: 0x06013A67 RID: 80487 RVA: 0x0057A940 File Offset: 0x00578B40
	[NullableContext(0)]
	[return: TupleElementNames(new string[]
	{
		"startTime",
		"endTime"
	})]
	public ValueTuple<long, long> GetTimeRange()
	{
		long num = 0L;
		long num2 = 0L;
		foreach (RacingBetsLegMatchData racingBetsLegMatchData in this.LegMatchList)
		{
			long num3 = (long)racingBetsLegMatchData.MatchStartTime;
			if (num == 0L || num3 < num)
			{
				num = num3;
			}
			if (num2 == 0L || num3 > num2)
			{
				num2 = num3;
			}
		}
		return new ValueTuple<long, long>(num, num2);
	}

	// Token: 0x06013A68 RID: 80488 RVA: 0x0057A9B4 File Offset: 0x00578BB4
	public void PushSourceAdvancedGroupMatchId(int groupMatchId)
	{
		this.SourceAdvanceGroupMatchIdList.Add(groupMatchId);
	}

	// Token: 0x06013A69 RID: 80489 RVA: 0x0057A9C2 File Offset: 0x00578BC2
	public void PushSourceLossGroupMatchId(int groupMatchId)
	{
		this.SourceLossGroupMatchIdList.Add(groupMatchId);
	}

	// Token: 0x040098D3 RID: 39123
	public int Id;

	// Token: 0x040098D4 RID: 39124
	private RacingBetsGroupMatch? MatchConfig;

	// Token: 0x040098D5 RID: 39125
	private List<RacingBetsLegMatchData> LegMatchList = new List<RacingBetsLegMatchData>();

	// Token: 0x040098D6 RID: 39126
	private ERacingBetsGroupMatchType MatchTypeInternal = ERacingBetsGroupMatchType.GroupStage;

	// Token: 0x040098D7 RID: 39127
	private List<int> InGameDangoIdList = new List<int>();

	// Token: 0x040098D8 RID: 39128
	private List<int> PromoteDangoList = new List<int>();

	// Token: 0x040098D9 RID: 39129
	private List<int> LossDangoList = new List<int>();

	// Token: 0x040098DA RID: 39130
	private readonly List<int> SourceAdvanceGroupMatchIdList = new List<int>();

	// Token: 0x040098DB RID: 39131
	private readonly List<int> SourceLossGroupMatchIdList = new List<int>();
}
