using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020026EA RID: 9962
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class RacingBetsConfig : ConfigBase<RacingBetsConfig>
{
	// Token: 0x06013AA6 RID: 80550 RVA: 0x0057BD3C File Offset: 0x00579F3C
	public RacingBetsSeason? GetRacingBetsSeasonConfig(int seasonId)
	{
		RacingBetsSeason? config = ConfigRacingBetsSeasonById.GetConfig(seasonId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RacingBets;
			ELogAuthor author = ELogAuthor.BB;
			string message = "RacingBetsSeason表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("SeasonId", seasonId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x06013AA7 RID: 80551 RVA: 0x0057BD94 File Offset: 0x00579F94
	public RacingBetsGroupMatch? GetRacingBetsGroupMatch(int matchId)
	{
		RacingBetsGroupMatch? config = ConfigRacingBetsGroupMatchById.GetConfig(matchId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RacingBets;
			ELogAuthor author = ELogAuthor.BB;
			string message = "RacingBetsGroupMatch表无效MatchId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MatchId", matchId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x06013AA8 RID: 80552 RVA: 0x0057BDEC File Offset: 0x00579FEC
	public RacingBetsLegMatches? GetRacingBetsLegMatches(int id)
	{
		RacingBetsLegMatches? config = ConfigRacingBetsLegMatchesById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RacingBets;
			ELogAuthor author = ELogAuthor.BB;
			string message = "RacingBetsLegMatches表无效Id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x06013AA9 RID: 80553 RVA: 0x0057BE44 File Offset: 0x0057A044
	public IReadOnlyList<RacingBetsReward> GetRacingBetsRewardList(int seasonId)
	{
		IReadOnlyList<RacingBetsReward> configList = ConfigRacingBetsRewardBySeasonId.GetConfigList(seasonId, true);
		if (configList == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RacingBets;
			ELogAuthor author = ELogAuthor.BB;
			string message = "RacingBetsReward表无效seasonId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("seasonId", seasonId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return configList;
	}

	// Token: 0x06013AAA RID: 80554 RVA: 0x0057BE90 File Offset: 0x0057A090
	public RacingBetsReward? GetRacingBetsReward(int id)
	{
		RacingBetsReward? config = ConfigRacingBetsRewardById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RacingBets;
			ELogAuthor author = ELogAuthor.BB;
			string message = "RacingBetsReward表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x06013AAB RID: 80555 RVA: 0x0057BEE8 File Offset: 0x0057A0E8
	public RacingBetsBulletScreen? GetRacingBetsBulletScreen(int bulletScreenId)
	{
		RacingBetsBulletScreen? config = ConfigRacingBetsBulletScreenById.GetConfig(bulletScreenId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RacingBets;
			ELogAuthor author = ELogAuthor.BB;
			string message = "RacingBetsBulletScreen表无效bulletScreenId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("bulletScreenId", bulletScreenId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x06013AAC RID: 80556 RVA: 0x0057BF40 File Offset: 0x0057A140
	public IReadOnlyList<RacingBetsBulletScreen> GetRacingBetsBulletScreenList(int seasonId)
	{
		IReadOnlyList<RacingBetsBulletScreen> configList = ConfigRacingBetsBulletScreenBySeasonId.GetConfigList(seasonId, true);
		if (configList == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RacingBets;
			ELogAuthor author = ELogAuthor.BB;
			string message = "RacingBetsBulletScreen表无效seasonId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("seasonId", seasonId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return configList;
	}

	// Token: 0x06013AAD RID: 80557 RVA: 0x0057BF8C File Offset: 0x0057A18C
	public IReadOnlyList<RacingBettingGear> GetRacingBettingGearList(int seasonId)
	{
		IReadOnlyList<RacingBettingGear> configList = ConfigRacingBettingGearBySeasonId.GetConfigList(seasonId, true);
		if (configList == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RacingBets;
			ELogAuthor author = ELogAuthor.BB;
			string message = "RacingBettingGear表无效seasonId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("seasonId", seasonId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return configList;
	}

	// Token: 0x06013AAE RID: 80558 RVA: 0x0057BFD8 File Offset: 0x0057A1D8
	public IReadOnlyList<RacingBetConversionRate> GetRacingBetConversionRateList(int seasonId)
	{
		IReadOnlyList<RacingBetConversionRate> configList = ConfigRacingBetConversionRateBySeasonId.GetConfigList(seasonId, true);
		if (configList == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RacingBets;
			ELogAuthor author = ELogAuthor.BB;
			string message = "RacingBetConversionRate表无效seasonId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("seasonId", seasonId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return configList;
	}

	// Token: 0x06013AAF RID: 80559 RVA: 0x0057C024 File Offset: 0x0057A224
	public RacingBetMapPoint? GetRacingBetMapPointConfig(int pointId)
	{
		RacingBetMapPoint? config = ConfigRacingBetMapPointById.GetConfig(pointId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RacingBets;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "RacingBetMapPoint表无效pointId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("pointId", pointId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x06013AB0 RID: 80560 RVA: 0x0057C07C File Offset: 0x0057A27C
	public IReadOnlyList<RacingBetMapPoint> GetRacingBetMapPointList(int seasonId)
	{
		IReadOnlyList<RacingBetMapPoint> configList = ConfigRacingBetMapPointBySeasonId.GetConfigList(seasonId, true);
		if (configList == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RacingBets;
			ELogAuthor author = ELogAuthor.BB;
			string message = "RacingBetMapPoint表无效seasonId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("seasonId", seasonId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return configList;
	}

	// Token: 0x06013AB1 RID: 80561 RVA: 0x0057C0C8 File Offset: 0x0057A2C8
	public RacingBetRankOpenTime? GetRacingBetRankOpenTime(int legMatchId)
	{
		RacingBetRankOpenTime? config = ConfigRacingBetRankOpenTimeById.GetConfig(legMatchId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RacingBets;
			ELogAuthor author = ELogAuthor.BB;
			string message = "RacingBetRankOpenTime表无效legMatchId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("legMatchId", legMatchId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x06013AB2 RID: 80562 RVA: 0x0057C120 File Offset: 0x0057A320
	public DangoBroadcast? GetRacingBetsDangoBroadcast(int dangoId)
	{
		DangoBroadcast? config = ConfigDangoBroadcastById.GetConfig(dangoId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RacingBets;
			ELogAuthor author = ELogAuthor.BB;
			string message = "DangoBroadcast表无效dangoId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("dangoId", dangoId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x06013AB3 RID: 80563 RVA: 0x0057C178 File Offset: 0x0057A378
	public int GetRacingBetConversionRate(int rank)
	{
		RacingBetConversionRate? config = ConfigRacingBetConversionRateById.GetConfig(rank, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RacingBets;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "RacingBetConversionRate表无效rank";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("rank", rank);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return 0;
		}
		return config.Value.ConversionRate;
	}

	// Token: 0x06013AB4 RID: 80564 RVA: 0x0057C1D8 File Offset: 0x0057A3D8
	public unsafe int? GetPointIdBySortId(int seasonId, int sortId)
	{
		if (!this.SortIdToPointIdCache.ContainsKey(seasonId))
		{
			IReadOnlyList<RacingBetMapPoint> racingBetMapPointList = this.GetRacingBetMapPointList(seasonId);
			if (racingBetMapPointList == null)
			{
				return null;
			}
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			foreach (RacingBetMapPoint racingBetMapPoint in racingBetMapPointList)
			{
				dictionary[racingBetMapPoint.SortId] = racingBetMapPoint.Id;
			}
			this.SortIdToPointIdCache[seasonId] = dictionary;
		}
		int value;
		if (!this.SortIdToPointIdCache[seasonId].TryGetValue(sortId, out value))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RacingBets;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "GetPointIdBySortId pointId is undefined";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("seasonId", seasonId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("sortId", sortId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return null;
		}
		return new int?(value);
	}

	// Token: 0x06013AB5 RID: 80565 RVA: 0x0057C2F4 File Offset: 0x0057A4F4
	public int GetPointTotal(int seasonId)
	{
		if (this.PointTotalNum != 0)
		{
			return this.PointTotalNum;
		}
		IReadOnlyList<RacingBetMapPoint> racingBetMapPointList = this.GetRacingBetMapPointList(seasonId);
		if (racingBetMapPointList == null)
		{
			return 0;
		}
		this.PointTotalNum = racingBetMapPointList.Count;
		return this.PointTotalNum;
	}

	// Token: 0x06013AB6 RID: 80566 RVA: 0x0057C32F File Offset: 0x0057A52F
	public IReadOnlyList<RacingBetsRuleTextPool> GetRandomRuleTextPool(int seasonId)
	{
		return ConfigRacingBetsRuleTextPoolBySeasonId.GetConfigList(seasonId, true);
	}

	// Token: 0x06013AB7 RID: 80567 RVA: 0x0057C338 File Offset: 0x0057A538
	[NullableContext(1)]
	public string GetRandomRuleText(int seasonId)
	{
		IReadOnlyList<RacingBetsRuleTextPool> configList = ConfigRacingBetsRuleTextPoolBySeasonId.GetConfigList(seasonId, true);
		if (configList == null || configList.Count == 0)
		{
			return string.Empty;
		}
		int index = new Random().Next(configList.Count);
		return configList[index].RuleText;
	}

	// Token: 0x06013AB8 RID: 80568 RVA: 0x0057C380 File Offset: 0x0057A580
	public float GetRuleRate()
	{
		return ConfigCommonParamById.GetFloatConfig("RacingBetsBroadcastRuleRate").GetValueOrDefault();
	}

	// Token: 0x06013AB9 RID: 80569 RVA: 0x0057C39F File Offset: 0x0057A59F
	public IReadOnlyList<RacingBetsMatch> GetMatchTableConfigBySeasonId(int seasonId)
	{
		return ConfigRacingBetsMatchBySeasonId.GetConfigList(seasonId, true);
	}

	// Token: 0x06013ABA RID: 80570 RVA: 0x0057C3A8 File Offset: 0x0057A5A8
	public RacingBetsMatch? GetMatchTableConfigById(int id)
	{
		return ConfigRacingBetsMatchById.GetConfig(id, true);
	}

	// Token: 0x06013ABB RID: 80571 RVA: 0x0057C3B4 File Offset: 0x0057A5B4
	public Dictionary<int, int> GetLegMatchOrganMap(int seasonId, int legMatchId)
	{
		RacingBetsLegMatches? racingBetsLegMatches = this.GetRacingBetsLegMatches(legMatchId);
		if (racingBetsLegMatches == null)
		{
			return null;
		}
		int organListLength = racingBetsLegMatches.Value.OrganListLength;
		List<string> list = new List<string>(organListLength);
		for (int i = 0; i < organListLength; i++)
		{
			list.Add(racingBetsLegMatches.Value.OrganList(i));
		}
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		int pointTotal = this.GetPointTotal(seasonId);
		if (pointTotal == 0)
		{
			return dictionary;
		}
		foreach (string text in list)
		{
			string[] array = text.Split(':', StringSplitOptions.None);
			int num;
			int value;
			if (array.Length >= 2 && int.TryParse(array[0], out num) && int.TryParse(array[1], out value))
			{
				int sortId = ((num - 1) % pointTotal + pointTotal) % pointTotal + 1;
				int? pointIdBySortId = this.GetPointIdBySortId(seasonId, sortId);
				if (pointIdBySortId != null)
				{
					dictionary[pointIdBySortId.Value] = value;
				}
			}
		}
		return dictionary;
	}

	// Token: 0x06013ABC RID: 80572 RVA: 0x0057C4C4 File Offset: 0x0057A6C4
	public RacingBetsOrgan? GetOrganConfig(int organId)
	{
		RacingBetsOrgan? config = ConfigRacingBetsOrganById.GetConfig(organId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RacingBets;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "RacingBetsOrgan表无效organId";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("organId", organId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x06013ABD RID: 80573 RVA: 0x0057C51C File Offset: 0x0057A71C
	[NullableContext(1)]
	public List<int> GetDangoIdByType(ERacingBetsDangoType type)
	{
		IReadOnlyList<Dango> configList = ConfigDangoByType.GetConfigList((int)type, true);
		if (configList == null)
		{
			return new List<int>();
		}
		List<int> list = new List<int>();
		foreach (Dango dango in configList)
		{
			list.Add(dango.Id);
		}
		return list;
	}

	// Token: 0x040098FA RID: 39162
	[Nullable(1)]
	private readonly Dictionary<int, Dictionary<int, int>> SortIdToPointIdCache = new Dictionary<int, Dictionary<int, int>>();

	// Token: 0x040098FB RID: 39163
	private int PointTotalNum;
}
