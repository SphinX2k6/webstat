using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.ExploreLevel
{
	// Token: 0x02005D8C RID: 23948
	[NullableContext(1)]
	[Nullable(0)]
	public class CountryExploreLevelData
	{
		// Token: 0x0603C4C1 RID: 246977 RVA: 0x00F4D730 File Offset: 0x00F4B930
		public void Initialize(int countryId, IReadOnlyList<ExploreReward> rewardConfigList)
		{
			this.CountryId = countryId;
			this.MaxExploreLevel = 0;
			foreach (ExploreReward exploreRewardConfig in rewardConfigList)
			{
				CountryExploreLevelRewardData countryExploreLevelRewardData = new CountryExploreLevelRewardData();
				countryExploreLevelRewardData.Initialize(exploreRewardConfig);
				int exploreLevel = exploreRewardConfig.ExploreLevel;
				this.ExploreLevelRewardDataMap[exploreLevel] = countryExploreLevelRewardData;
				this.ExploreLevelRewardDataList.Add(countryExploreLevelRewardData);
				if (exploreRewardConfig.Show)
				{
					this.UnlockFunctionExploreLevelRewardDataList.Add(countryExploreLevelRewardData);
				}
				if (this.MaxExploreLevel < exploreLevel)
				{
					this.MaxExploreLevel = exploreLevel;
				}
			}
		}

		// Token: 0x0603C4C2 RID: 246978 RVA: 0x00F4D7D4 File Offset: 0x00F4B9D4
		public void AddExploreScoreData(int areaId, int progress, int lastProgress, int score)
		{
			CountryExploreScoreData countryExploreScoreData = new CountryExploreScoreData();
			countryExploreScoreData.Initialize(this.CountryId, areaId, progress, lastProgress, score);
			Dictionary<int, CountryExploreScoreData> dictionary;
			if (!this.CountryExploreScoreDataAreaMap.TryGetValue(areaId, out dictionary))
			{
				dictionary = new Dictionary<int, CountryExploreScoreData>();
				this.CountryExploreScoreDataAreaMap[areaId] = dictionary;
			}
			dictionary[progress] = countryExploreScoreData;
			this.CountryExploreScoreDataList.Add(countryExploreScoreData);
		}

		// Token: 0x0603C4C3 RID: 246979 RVA: 0x00F4D830 File Offset: 0x00F4BA30
		[NullableContext(2)]
		public CountryExploreScoreData GetExploreScoreData(int areaId, int progress)
		{
			Dictionary<int, CountryExploreScoreData> dictionary;
			if (this.CountryExploreScoreDataAreaMap.TryGetValue(areaId, out dictionary))
			{
				CountryExploreScoreData result;
				dictionary.TryGetValue(progress, out result);
				return result;
			}
			return null;
		}

		// Token: 0x0603C4C4 RID: 246980 RVA: 0x00F4D85A File Offset: 0x00F4BA5A
		public List<CountryExploreScoreData> GetAllExploreScoreData()
		{
			return this.CountryExploreScoreDataList;
		}

		// Token: 0x0603C4C5 RID: 246981 RVA: 0x00F4D864 File Offset: 0x00F4BA64
		public List<CountryExploreScoreData> GetVisibleExploreScoreDataList()
		{
			List<CountryExploreScoreData> list = new List<CountryExploreScoreData>();
			foreach (Dictionary<int, CountryExploreScoreData> dictionary in this.CountryExploreScoreDataAreaMap.Values)
			{
				foreach (KeyValuePair<int, CountryExploreScoreData> keyValuePair in dictionary)
				{
					int num;
					CountryExploreScoreData countryExploreScoreData;
					keyValuePair.Deconstruct(out num, out countryExploreScoreData);
					int num2 = num;
					CountryExploreScoreData countryExploreScoreData2 = countryExploreScoreData;
					int lastProgress = countryExploreScoreData2.LastProgress;
					CountryExploreScoreData countryExploreScoreData3;
					dictionary.TryGetValue(lastProgress, out countryExploreScoreData3);
					if (countryExploreScoreData3 == null || countryExploreScoreData3.GetIsReceived())
					{
						if (countryExploreScoreData2.CanReceive())
						{
							list.Add(countryExploreScoreData2);
						}
						else if (countryExploreScoreData2.GetIsReceived())
						{
							list.Add(countryExploreScoreData2);
						}
						else if (num2 > countryExploreScoreData2.GetAreaProgress())
						{
							list.Add(countryExploreScoreData2);
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0603C4C6 RID: 246982 RVA: 0x00F4D968 File Offset: 0x00F4BB68
		public void SetExploreScoreDataReceived(int areaId, int progress, bool bReceived)
		{
			CountryExploreScoreData exploreScoreData = this.GetExploreScoreData(areaId, progress);
			if (exploreScoreData == null)
			{
				return;
			}
			exploreScoreData.SetReceived(bReceived);
		}

		// Token: 0x0603C4C7 RID: 246983 RVA: 0x00F4D97D File Offset: 0x00F4BB7D
		public int GetCountryId()
		{
			return this.CountryId;
		}

		// Token: 0x0603C4C8 RID: 246984 RVA: 0x00F4D985 File Offset: 0x00F4BB85
		public void SetExploreLevel(int exploreLevel)
		{
			this.ExploreLevel = exploreLevel;
		}

		// Token: 0x0603C4C9 RID: 246985 RVA: 0x00F4D98E File Offset: 0x00F4BB8E
		public int GetExploreLevel()
		{
			return this.ExploreLevel;
		}

		// Token: 0x0603C4CA RID: 246986 RVA: 0x00F4D996 File Offset: 0x00F4BB96
		public void SetExploreScore(int exploreScore)
		{
			this.ExploreScore = exploreScore;
		}

		// Token: 0x0603C4CB RID: 246987 RVA: 0x00F4D99F File Offset: 0x00F4BB9F
		public int GetExploreScore()
		{
			return this.ExploreScore;
		}

		// Token: 0x0603C4CC RID: 246988 RVA: 0x00F4D9A8 File Offset: 0x00F4BBA8
		[NullableContext(2)]
		public CountryExploreLevelRewardData GetExploreLevelRewardData(int exploreLevel)
		{
			CountryExploreLevelRewardData result;
			this.ExploreLevelRewardDataMap.TryGetValue(exploreLevel, out result);
			return result;
		}

		// Token: 0x0603C4CD RID: 246989 RVA: 0x00F4D9C5 File Offset: 0x00F4BBC5
		public Dictionary<int, CountryExploreLevelRewardData> GetExploreLevelRewardDataMap()
		{
			return this.ExploreLevelRewardDataMap;
		}

		// Token: 0x0603C4CE RID: 246990 RVA: 0x00F4D9CD File Offset: 0x00F4BBCD
		[NullableContext(2)]
		public CountryExploreLevelRewardData GetCurrentExploreLevelRewardData()
		{
			return this.GetExploreLevelRewardData(this.ExploreLevel);
		}

		// Token: 0x0603C4CF RID: 246991 RVA: 0x00F4D9DB File Offset: 0x00F4BBDB
		public List<CountryExploreLevelRewardData> GetAllExploreLevelRewardData()
		{
			return this.ExploreLevelRewardDataList;
		}

		// Token: 0x0603C4D0 RID: 246992 RVA: 0x00F4D9E3 File Offset: 0x00F4BBE3
		public List<CountryExploreLevelRewardData> GetUnlockFunctionExploreLevelRewardDataList()
		{
			return this.UnlockFunctionExploreLevelRewardDataList;
		}

		// Token: 0x0603C4D1 RID: 246993 RVA: 0x00F4D9EB File Offset: 0x00F4BBEB
		public int GetMaxExploreLevel()
		{
			return this.MaxExploreLevel;
		}

		// Token: 0x0603C4D2 RID: 246994 RVA: 0x00F4D9F4 File Offset: 0x00F4BBF4
		public bool CanLevelUp()
		{
			int num = 0;
			foreach (CountryExploreScoreData countryExploreScoreData in this.CountryExploreScoreDataList)
			{
				if (countryExploreScoreData.CanReceive())
				{
					num += countryExploreScoreData.Score;
				}
			}
			CountryExploreLevelRewardData currentExploreLevelRewardData = this.GetCurrentExploreLevelRewardData();
			return num != 0 && this.ExploreScore < currentExploreLevelRewardData.GetMaxExploreScore() && this.ExploreScore + num >= currentExploreLevelRewardData.GetMaxExploreScore();
		}

		// Token: 0x04021E8C RID: 138892
		private int CountryId;

		// Token: 0x04021E8D RID: 138893
		private int ExploreLevel;

		// Token: 0x04021E8E RID: 138894
		private int ExploreScore;

		// Token: 0x04021E8F RID: 138895
		private Dictionary<int, CountryExploreLevelRewardData> ExploreLevelRewardDataMap = new Dictionary<int, CountryExploreLevelRewardData>();

		// Token: 0x04021E90 RID: 138896
		private List<CountryExploreLevelRewardData> ExploreLevelRewardDataList = new List<CountryExploreLevelRewardData>();

		// Token: 0x04021E91 RID: 138897
		private List<CountryExploreLevelRewardData> UnlockFunctionExploreLevelRewardDataList = new List<CountryExploreLevelRewardData>();

		// Token: 0x04021E92 RID: 138898
		private Dictionary<int, Dictionary<int, CountryExploreScoreData>> CountryExploreScoreDataAreaMap = new Dictionary<int, Dictionary<int, CountryExploreScoreData>>();

		// Token: 0x04021E93 RID: 138899
		private List<CountryExploreScoreData> CountryExploreScoreDataList = new List<CountryExploreScoreData>();

		// Token: 0x04021E94 RID: 138900
		private int MaxExploreLevel;
	}
}
