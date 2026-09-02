using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001B69 RID: 7017
[NullableContext(1)]
[Nullable(0)]
public class ExploreCountryData
{
	// Token: 0x17001049 RID: 4169
	// (get) Token: 0x0600CBB5 RID: 52149 RVA: 0x00365F01 File Offset: 0x00364101
	// (set) Token: 0x0600CBB6 RID: 52150 RVA: 0x00365F09 File Offset: 0x00364109
	public int CountryId { get; set; }

	// Token: 0x1700104A RID: 4170
	// (get) Token: 0x0600CBB7 RID: 52151 RVA: 0x00365F12 File Offset: 0x00364112
	// (set) Token: 0x0600CBB8 RID: 52152 RVA: 0x00365F1A File Offset: 0x0036411A
	public string Icon { get; set; } = "";

	// Token: 0x1700104B RID: 4171
	// (get) Token: 0x0600CBB9 RID: 52153 RVA: 0x00365F23 File Offset: 0x00364123
	// (set) Token: 0x0600CBBA RID: 52154 RVA: 0x00365F2B File Offset: 0x0036412B
	public string TitleId { get; set; } = "";

	// Token: 0x1700104C RID: 4172
	// (get) Token: 0x0600CBBB RID: 52155 RVA: 0x00365F34 File Offset: 0x00364134
	// (set) Token: 0x0600CBBC RID: 52156 RVA: 0x00365F3C File Offset: 0x0036413C
	public int SortIndex { get; set; }

	// Token: 0x0600CBBD RID: 52157 RVA: 0x00365F45 File Offset: 0x00364145
	public void Initialize(Country config)
	{
		this.CountryId = config.Id;
		this.TitleId = config.Title;
		this.Icon = config.Icon;
		this.SortIndex = config.SortIndex;
	}

	// Token: 0x0600CBBE RID: 52158 RVA: 0x00365F7C File Offset: 0x0036417C
	public ExploreAreaData AddExploreAreaData(Area areaConfig)
	{
		int areaId = areaConfig.AreaId;
		ExploreAreaData exploreAreaData = new ExploreAreaData();
		exploreAreaData.Initialize(areaConfig);
		this.ExploreAreaDataMap[areaId] = exploreAreaData;
		this.ExploreAreaDataList.Add(exploreAreaData);
		IReadOnlyList<ExploreProgress> exploreProgressConfigListByArea = ConfigBase<ExploreProgressConfig>.Instance.GetExploreProgressConfigListByArea(areaId);
		if (exploreProgressConfigListByArea != null)
		{
			foreach (ExploreProgress exploreItemConfig in exploreProgressConfigListByArea)
			{
				exploreAreaData.AddExploreAreaItemData(exploreItemConfig);
			}
		}
		exploreAreaData.AddExploreAreaItemDataFinish();
		int stateId = exploreAreaData.StateId;
		ExploreStateData exploreStateData;
		ExploreStateData exploreStateData2;
		if (this.ExploreStateDataMap.TryGetValue(stateId, out exploreStateData))
		{
			exploreStateData2 = exploreStateData;
		}
		else
		{
			exploreStateData2 = new ExploreStateData();
			this.ExploreStateDataMap[stateId] = exploreStateData2;
			exploreStateData2.Initialize(stateId, this.CountryId);
		}
		exploreStateData2.PushAreaData(exploreAreaData);
		return exploreAreaData;
	}

	// Token: 0x0600CBBF RID: 52159 RVA: 0x00366058 File Offset: 0x00364258
	[NullableContext(2)]
	public ExploreAreaData GetExploreAreaData(int areaId)
	{
		return this.ExploreAreaDataMap.GetValueOrDefault(areaId);
	}

	// Token: 0x0600CBC0 RID: 52160 RVA: 0x00366066 File Offset: 0x00364266
	public IReadOnlyDictionary<int, ExploreAreaData> GetExploreAreaDataMap()
	{
		return this.ExploreAreaDataMap;
	}

	// Token: 0x0600CBC1 RID: 52161 RVA: 0x0036606E File Offset: 0x0036426E
	public List<ExploreAreaData> GetExploreAreaDataList()
	{
		return this.ExploreAreaDataList;
	}

	// Token: 0x0600CBC2 RID: 52162 RVA: 0x00366076 File Offset: 0x00364276
	public int GetAreaSize()
	{
		return this.ExploreAreaDataMap.Count;
	}

	// Token: 0x0600CBC3 RID: 52163 RVA: 0x00366083 File Offset: 0x00364283
	public string GetNameId()
	{
		return this.TitleId;
	}

	// Token: 0x0600CBC4 RID: 52164 RVA: 0x0036608C File Offset: 0x0036428C
	public float GetCountryExploreProgress()
	{
		float num = 100f * (float)this.ExploreAreaDataList.Count;
		float num2 = 0f;
		foreach (ExploreAreaData exploreAreaData in this.ExploreAreaDataList)
		{
			num2 += (float)exploreAreaData.GetProgress();
		}
		return num2 / num;
	}

	// Token: 0x0600CBC5 RID: 52165 RVA: 0x00366100 File Offset: 0x00364300
	public List<ExploreStateData> GetStateDataList()
	{
		List<ExploreStateData> list = this.ExploreStateDataMap.Values.ToList<ExploreStateData>();
		if (list.Count <= 1)
		{
			return list;
		}
		list.Sort((ExploreStateData a, ExploreStateData b) => a.StateId.CompareTo(b.StateId));
		return list;
	}

	// Token: 0x0600CBC6 RID: 52166 RVA: 0x0036614F File Offset: 0x0036434F
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public List<ExploreAreaData> GetAreaDataListByStateId(int stateId)
	{
		ExploreStateData stateDataByStateId = this.GetStateDataByStateId(stateId);
		if (stateDataByStateId == null)
		{
			return null;
		}
		return stateDataByStateId.ExploreAreaDataList;
	}

	// Token: 0x0600CBC7 RID: 52167 RVA: 0x00366163 File Offset: 0x00364363
	[NullableContext(2)]
	public ExploreStateData GetStateDataByStateId(int stateId)
	{
		return this.ExploreStateDataMap.GetValueOrDefault(stateId);
	}

	// Token: 0x0600CBC8 RID: 52168 RVA: 0x00366171 File Offset: 0x00364371
	public bool HasCanTakeStageReward()
	{
		return this.ExploreAreaDataList.Any((ExploreAreaData data) => data.HasCanTakeStageReward());
	}

	// Token: 0x0600CBC9 RID: 52169 RVA: 0x003661A0 File Offset: 0x003643A0
	public void UpdateStateAreaDataListSort()
	{
		foreach (ExploreStateData exploreStateData in this.ExploreStateDataMap.Values)
		{
			exploreStateData.ExploreAreaDataList.Sort(delegate(ExploreAreaData a, ExploreAreaData b)
			{
				if (a.GetSortIndex() != b.GetSortIndex())
				{
					return a.GetSortIndex().CompareTo(b.GetSortIndex());
				}
				return a.AreaId.CompareTo(b.AreaId);
			});
		}
	}

	// Token: 0x04006172 RID: 24946
	private readonly Dictionary<int, ExploreAreaData> ExploreAreaDataMap = new Dictionary<int, ExploreAreaData>();

	// Token: 0x04006173 RID: 24947
	private readonly List<ExploreAreaData> ExploreAreaDataList = new List<ExploreAreaData>();

	// Token: 0x04006174 RID: 24948
	private readonly Dictionary<int, ExploreStateData> ExploreStateDataMap = new Dictionary<int, ExploreStateData>();
}
