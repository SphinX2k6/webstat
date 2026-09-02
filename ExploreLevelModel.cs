using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.ExploreLevel;

// Token: 0x02001B60 RID: 7008
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class ExploreLevelModel : ModelBase<ExploreLevelModel>
{
	// Token: 0x0600CAED RID: 51949 RVA: 0x00361BA4 File Offset: 0x0035FDA4
	protected override bool OnInit()
	{
		foreach (Country country in ConfigBase<InfluenceConfig>.Instance.GetCountryList())
		{
			this.AddCountryExploreLevelData(country.Id);
		}
		IEnumerable<ExploreScore> exploreScoreConfigList = ConfigBase<ExploreLevelConfig>.Instance.GetExploreScoreConfigList();
		AreaConfig instance = ConfigBase<AreaConfig>.Instance;
		foreach (ExploreScore exploreScore in exploreScoreConfigList)
		{
			int area = exploreScore.Area;
			int countryId = instance.GetAreaInfo(area).Value.CountryId;
			CountryExploreLevelData countryExploreLevelData = this.GetCountryExploreLevelData(countryId);
			int lastProgress = 0;
			for (int i = 0; i < exploreScore.ScoreLength; i++)
			{
				DicIntInt value = exploreScore.Score(i).Value;
				int key = value.Key;
				int value2 = value.Value;
				countryExploreLevelData.AddExploreScoreData(area, key, lastProgress, value2);
				lastProgress = key;
			}
		}
		this.ExploreScoreItemTexturePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("T_IconA_currency_5_UI");
		return true;
	}

	// Token: 0x0600CAEE RID: 51950 RVA: 0x00361CE0 File Offset: 0x0035FEE0
	protected override bool OnClear()
	{
		this.CountryExploreLevelDataMap.Clear();
		return true;
	}

	// Token: 0x0600CAEF RID: 51951 RVA: 0x00361CF0 File Offset: 0x0035FEF0
	public CountryExploreLevelData AddCountryExploreLevelData(int countryId)
	{
		IReadOnlyList<ExploreReward> exploreRewardListByCountry = ConfigBase<ExploreLevelConfig>.Instance.GetExploreRewardListByCountry(countryId);
		CountryExploreLevelData countryExploreLevelData = new CountryExploreLevelData();
		countryExploreLevelData.Initialize(countryId, exploreRewardListByCountry);
		this.CountryExploreLevelDataMap[countryId] = countryExploreLevelData;
		return countryExploreLevelData;
	}

	// Token: 0x0600CAF0 RID: 51952 RVA: 0x00361D28 File Offset: 0x0035FF28
	[NullableContext(2)]
	public CountryExploreLevelData GetCountryExploreLevelData(int countryId)
	{
		CountryExploreLevelData result;
		this.CountryExploreLevelDataMap.TryGetValue(countryId, out result);
		return result;
	}

	// Token: 0x0600CAF1 RID: 51953 RVA: 0x00361D48 File Offset: 0x0035FF48
	[NullableContext(2)]
	public CountryExploreLevelData GetCurrentCountryExploreLevelData()
	{
		return this.GetCountryExploreLevelData(ModelBase<AreaModel>.Instance.GetAreaCountryId().Value);
	}

	// Token: 0x0600CAF2 RID: 51954 RVA: 0x00361D70 File Offset: 0x0035FF70
	public void SetCountryExploreLevel(int countryId, int countryExploreLevel)
	{
		CountryExploreLevelData countryExploreLevelData = this.GetCountryExploreLevelData(countryId);
		if (countryExploreLevelData == null)
		{
			return;
		}
		countryExploreLevelData.SetExploreLevel(countryExploreLevel);
	}

	// Token: 0x0600CAF3 RID: 51955 RVA: 0x00361D90 File Offset: 0x0035FF90
	public void SetCountryExploreScore(int countryId, int exploreScore)
	{
		CountryExploreLevelData countryExploreLevelData = this.GetCountryExploreLevelData(countryId);
		if (countryExploreLevelData == null)
		{
			return;
		}
		countryExploreLevelData.SetExploreScore(exploreScore);
	}

	// Token: 0x0600CAF4 RID: 51956 RVA: 0x00361DB0 File Offset: 0x0035FFB0
	public void SetCountryExploreScoreReceived(int areaId, int progress, bool bReceived)
	{
		Area? areaInfo = ConfigBase<AreaConfig>.Instance.GetAreaInfo(areaId);
		if (areaInfo == null)
		{
			return;
		}
		int countryId = areaInfo.Value.CountryId;
		CountryExploreLevelData countryExploreLevelData = this.GetCountryExploreLevelData(countryId);
		if (countryExploreLevelData == null)
		{
			return;
		}
		countryExploreLevelData.SetExploreScoreDataReceived(areaId, progress, bReceived);
	}

	// Token: 0x04006110 RID: 24848
	private Dictionary<int, CountryExploreLevelData> CountryExploreLevelDataMap = new Dictionary<int, CountryExploreLevelData>();

	// Token: 0x04006111 RID: 24849
	public string ExploreScoreItemTexturePath = "";
}
