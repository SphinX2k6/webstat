using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.WorldMap;

// Token: 0x02001B7F RID: 7039
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class ExploreProgressModel : ModelBase<ExploreProgressModel>
{
	// Token: 0x17001083 RID: 4227
	// (get) Token: 0x0600CC58 RID: 52312 RVA: 0x00366832 File Offset: 0x00364A32
	public bool GetIsRedDotAreaRewardBox
	{
		get
		{
			return this.IsRedDotAreaRewardBox;
		}
	}

	// Token: 0x0600CC59 RID: 52313 RVA: 0x0036683A File Offset: 0x00364A3A
	protected override bool OnClear()
	{
		this.ClearExploreAreaData();
		return true;
	}

	// Token: 0x0600CC5A RID: 52314 RVA: 0x00366843 File Offset: 0x00364A43
	protected override bool OnLeaveLevel()
	{
		this.ClearExploreAreaData();
		return true;
	}

	// Token: 0x0600CC5B RID: 52315 RVA: 0x0036684C File Offset: 0x00364A4C
	public void InitializeExploreAreaData()
	{
		List<Country> countryList = ConfigBase<InfluenceConfig>.Instance.GetCountryList();
		AreaConfig instance = ConfigBase<AreaConfig>.Instance;
		this.AllAreaIdList.Clear();
		foreach (Country config in countryList)
		{
			ExploreCountryData exploreCountryData = new ExploreCountryData();
			exploreCountryData.Initialize(config);
			this.ExploreCountryDataMap[config.Id] = exploreCountryData;
			IReadOnlyList<Aki.Config.Area> areaConfigByCountryAndLevel = instance.GetAreaConfigByCountryAndLevel(config.Id, 2);
			if (areaConfigByCountryAndLevel != null)
			{
				foreach (Aki.Config.Area areaConfig in areaConfigByCountryAndLevel)
				{
					if (!areaConfig.IsDisableInExplore)
					{
						int areaId = areaConfig.AreaId;
						ExploreAreaData value = exploreCountryData.AddExploreAreaData(areaConfig);
						this.ExploreAreaDataMap[areaId] = value;
						this.AllAreaIdList.Add(areaId);
					}
				}
			}
			exploreCountryData.UpdateStateAreaDataListSort();
		}
	}

	// Token: 0x0600CC5C RID: 52316 RVA: 0x0036695C File Offset: 0x00364B5C
	public void InitializeCurrentCountryIdAndAreaId()
	{
		AreaModel instance = ModelBase<AreaModel>.Instance;
		this.SelectedCountryId = instance.GetAreaCountryId().GetValueOrDefault();
		if (this.SelectedCountryId <= 0)
		{
			this.SelectedCountryId = 1;
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ExploreProgress;
			ELogAuthor author = ELogAuthor.LYX;
			string message = "初始化所有探索度区域数据时，找不到所在国家则选中皇龙";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CountryId", this.SelectedCountryId);
			instance2.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		int worldMapLevelOneAreaId = MapUtil.GetWorldMapLevelOneAreaId();
		if (this.GetExploreAreaData(worldMapLevelOneAreaId) != null)
		{
			this.SelectedAreaId = worldMapLevelOneAreaId;
			return;
		}
		List<ExploreAreaData> exploreAreaDataList = this.GetExploreCountryData(this.SelectedCountryId).GetExploreAreaDataList();
		this.SelectedAreaId = exploreAreaDataList[0].AreaId;
		Log instance3 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.ExploreProgress;
		ELogAuthor author2 = ELogAuthor.LYX;
		string message2 = "初始化所有探索度区域数据时，若玩家当前所在区域没有在对应区域探索数据，则选中当前国家的第一个区域";
		ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("AreaId", this.SelectedAreaId);
		instance3.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
	}

	// Token: 0x0600CC5D RID: 52317 RVA: 0x00366A39 File Offset: 0x00364C39
	public void ClearExploreAreaData()
	{
		this.ExploreCountryDataMap.Clear();
		this.ExploreAreaDataMap.Clear();
		this.AllAreaIdList.Clear();
	}

	// Token: 0x0600CC5E RID: 52318 RVA: 0x00366A5C File Offset: 0x00364C5C
	public void RefreshExploreAreaData(AreaExploreInfo areaExploreInfo)
	{
		ExploreAreaData exploreAreaData;
		if (this.ExploreAreaDataMap.TryGetValue(areaExploreInfo.AreaId, out exploreAreaData))
		{
			exploreAreaData.Refresh(areaExploreInfo);
		}
	}

	// Token: 0x0600CC5F RID: 52319 RVA: 0x00366A88 File Offset: 0x00364C88
	[NullableContext(2)]
	public ExploreCountryData GetExploreCountryData(int countryId)
	{
		ExploreCountryData result;
		this.ExploreCountryDataMap.TryGetValue(countryId, out result);
		return result;
	}

	// Token: 0x0600CC60 RID: 52320 RVA: 0x00366AA8 File Offset: 0x00364CA8
	[NullableContext(2)]
	public ExploreAreaData GetExploreAreaData(int areaId)
	{
		ExploreAreaData result;
		this.ExploreAreaDataMap.TryGetValue(areaId, out result);
		return result;
	}

	// Token: 0x0600CC61 RID: 52321 RVA: 0x00366AC5 File Offset: 0x00364CC5
	public IReadOnlyDictionary<int, ExploreCountryData> GetExploreCountryDataMap()
	{
		return this.ExploreCountryDataMap;
	}

	// Token: 0x0600CC62 RID: 52322 RVA: 0x00366ACD File Offset: 0x00364CCD
	public IReadOnlyList<ExploreCountryData> GetExploreCountryDataList()
	{
		return this.ExploreCountryDataMap.Values.ToArray<ExploreCountryData>();
	}

	// Token: 0x0600CC63 RID: 52323 RVA: 0x00366AE0 File Offset: 0x00364CE0
	public List<ExploreAreaData> GetAllAreaDataListSortCountryState()
	{
		List<ExploreAreaData> list = new List<ExploreAreaData>();
		foreach (KeyValuePair<int, ExploreCountryData> keyValuePair in this.ExploreCountryDataMap)
		{
			foreach (ExploreStateData exploreStateData in keyValuePair.Value.GetStateDataList())
			{
				list.AddRange(exploreStateData.ExploreAreaDataList);
			}
		}
		return list;
	}

	// Token: 0x0600CC64 RID: 52324 RVA: 0x00366B84 File Offset: 0x00364D84
	public List<int> GetAllAreaIdList()
	{
		return this.AllAreaIdList;
	}

	// Token: 0x0600CC65 RID: 52325 RVA: 0x00366B8C File Offset: 0x00364D8C
	public void InitAreaStageRewardIdToAreaIdMap()
	{
		if (this.AreaStageRewardIdToAreaIdMap.Count > 0)
		{
			return;
		}
		IReadOnlyList<ExploreProgressReward> areaStageRewardConfigList = ConfigBase<ExploreProgressConfig>.Instance.GetAreaStageRewardConfigList();
		if (areaStageRewardConfigList != null)
		{
			foreach (ExploreProgressReward exploreProgressReward in areaStageRewardConfigList)
			{
				this.AreaStageRewardIdToAreaIdMap[exploreProgressReward.Id] = exploreProgressReward.Area;
			}
		}
	}

	// Token: 0x0600CC66 RID: 52326 RVA: 0x00366C04 File Offset: 0x00364E04
	public void UpdateAreaStageRewardDataList(IReadOnlyList<int> rewardIds)
	{
		this.InitAreaStageRewardIdToAreaIdMap();
		foreach (int num in rewardIds)
		{
			int areaId;
			if (this.AreaStageRewardIdToAreaIdMap.TryGetValue(num, out areaId))
			{
				ExploreAreaData exploreAreaData = this.GetExploreAreaData(areaId);
				if (exploreAreaData != null)
				{
					exploreAreaData.UpdateAchievedStageReward(num);
				}
			}
			this.AchievedAreaRewardIds.Add(num);
		}
		this.CheckRedDotAreaRewardBox();
		Singleton<EventSystem>.Instance.Emit(EEventName.RedDotUpdateMapAreaBoxReward);
	}

	// Token: 0x0600CC67 RID: 52327 RVA: 0x00366C94 File Offset: 0x00364E94
	public bool IsAreaStageRewardIdAchieved(int rewardId)
	{
		return this.AchievedAreaRewardIds.Contains(rewardId);
	}

	// Token: 0x0600CC68 RID: 52328 RVA: 0x00366CA2 File Offset: 0x00364EA2
	[NullableContext(2)]
	public ExploreCountryData GetCurrentCountryData()
	{
		return this.GetExploreCountryData(this.SelectedCountryId);
	}

	// Token: 0x0600CC69 RID: 52329 RVA: 0x00366CB0 File Offset: 0x00364EB0
	private void CheckRedDotAreaRewardBox()
	{
		foreach (int areaId in this.AllAreaIdList)
		{
			ExploreAreaData exploreAreaData = this.GetExploreAreaData(areaId);
			if (exploreAreaData != null && exploreAreaData.HasCanTakeStageReward())
			{
				this.IsRedDotAreaRewardBox = true;
				return;
			}
		}
		this.IsRedDotAreaRewardBox = false;
	}

	// Token: 0x0600CC6A RID: 52330 RVA: 0x00366D20 File Offset: 0x00364F20
	public void SureHasAreaRewardBox()
	{
		this.IsRedDotAreaRewardBox = true;
	}

	// Token: 0x0600CC6B RID: 52331 RVA: 0x00366D2C File Offset: 0x00364F2C
	public bool IsCollectAllStageReward()
	{
		foreach (int areaId in this.AllAreaIdList)
		{
			ExploreAreaData exploreAreaData = this.GetExploreAreaData(areaId);
			if (exploreAreaData == null || !exploreAreaData.IsCollectAllStageReward())
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0600CC6C RID: 52332 RVA: 0x00366D94 File Offset: 0x00364F94
	public void UpdatePlayPointState(int areaId, Dictionary<int, LevelPlayStateMsg> playPointStateDict)
	{
		ExploreAreaData exploreAreaData = this.GetExploreAreaData(areaId);
		if (exploreAreaData == null)
		{
			return;
		}
		exploreAreaData.UpdatePlayPointData(playPointStateDict);
	}

	// Token: 0x0600CC6D RID: 52333 RVA: 0x00366DA8 File Offset: 0x00364FA8
	public void UpdateTraceEntities(int areaId, int exploratoryDegree, int[] entities)
	{
		ExploreAreaData exploreAreaData = this.GetExploreAreaData(areaId);
		if (exploreAreaData == null)
		{
			return;
		}
		exploreAreaData.UpdateTraceEntities(exploratoryDegree, entities);
	}

	// Token: 0x0600CC6E RID: 52334 RVA: 0x00366DC0 File Offset: 0x00364FC0
	public void UpdateOnlinePlayersArea(Dictionary<int, int> areaDict)
	{
		this.OnlinePlayersAreaMap.Clear();
		foreach (KeyValuePair<int, int> keyValuePair in areaDict)
		{
			int key = keyValuePair.Key;
			int value = keyValuePair.Value;
			this.OnlinePlayersAreaMap[key] = value;
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.UpdateOnlinePlayersArea);
	}

	// Token: 0x0600CC6F RID: 52335 RVA: 0x00366E40 File Offset: 0x00365040
	public int? GetOnlinePlayersArea(int playerId)
	{
		int value;
		if (this.OnlinePlayersAreaMap.TryGetValue(playerId, out value))
		{
			return new int?(value);
		}
		return null;
	}

	// Token: 0x0600CC70 RID: 52336 RVA: 0x00366E70 File Offset: 0x00365070
	public List<int> GetOnlinePlayerIndexListByAreaId(int areaId)
	{
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, int> keyValuePair in this.OnlinePlayersAreaMap)
		{
			int key = keyValuePair.Key;
			int value = keyValuePair.Value;
			if (ConfigBase<AreaConfig>.Instance.GetLevelOneAreaId(value) == areaId)
			{
				OnlineModel instance = ModelBase<OnlineModel>.Instance;
				OnlineTeamData onlineTeamData = (instance != null) ? instance.GetCurrentTeamListById(key) : null;
				if (onlineTeamData != null)
				{
					int playerNumber = onlineTeamData.PlayerNumber;
					list.Add(onlineTeamData.PlayerNumber);
				}
			}
		}
		return list;
	}

	// Token: 0x0600CC71 RID: 52337 RVA: 0x00366F10 File Offset: 0x00365110
	public void SetTrackTaskAreaId(int areaId, string taskIconPath)
	{
		this.TrackTaskAreaId = areaId;
		this.TrackTaskIconPath = taskIconPath;
	}

	// Token: 0x0600CC72 RID: 52338 RVA: 0x00366F20 File Offset: 0x00365120
	public void ClearTrackTaskAreaId()
	{
		this.TrackTaskAreaId = 0;
		this.TrackTaskIconPath = "";
	}

	// Token: 0x0600CC73 RID: 52339 RVA: 0x00366F34 File Offset: 0x00365134
	public void ClearTrackExploreAreaItemData()
	{
		this.TrackExploreAreaItemData = null;
	}

	// Token: 0x0600CC74 RID: 52340 RVA: 0x00366F3D File Offset: 0x0036513D
	public void CheckTrackExploreAreaItemData()
	{
		if (this.TrackExploreAreaItemData != null)
		{
			this.TrackExploreAreaItemData.TrackPoint();
			this.ClearTrackExploreAreaItemData();
		}
	}

	// Token: 0x0600CC75 RID: 52341 RVA: 0x00366F58 File Offset: 0x00365158
	public void SetTrackExploreAreaItemData(int areaId, int exploreType)
	{
		ExploreAreaData exploreAreaData = this.GetExploreAreaData(areaId);
		if (exploreAreaData != null)
		{
			this.TrackExploreAreaItemData = exploreAreaData.GetExploreAreaItemData((EExploreType)exploreType);
		}
	}

	// Token: 0x0600CC76 RID: 52342 RVA: 0x00366F7D File Offset: 0x0036517D
	public void SetTrackExploreAreaItemData(ExploreAreaItemData data)
	{
		this.TrackExploreAreaItemData = data;
	}

	// Token: 0x0600CC77 RID: 52343 RVA: 0x00366F86 File Offset: 0x00365186
	public void WorldMapViewClose()
	{
		this.ClearTrackExploreAreaItemData();
		this.SaveLocalAreaExplorePlayState();
	}

	// Token: 0x0600CC78 RID: 52344 RVA: 0x00366F94 File Offset: 0x00365194
	private void SaveLocalAreaExplorePlayState()
	{
		int worldMapLevelOneAreaId = MapUtil.GetWorldMapLevelOneAreaId();
		ExploreAreaData exploreAreaData = this.GetExploreAreaData(worldMapLevelOneAreaId);
		if (exploreAreaData != null)
		{
			exploreAreaData.SaveLocalAreaExplorePlayState();
		}
		if (exploreAreaData == null)
		{
			return;
		}
		exploreAreaData.ClearFlagSaveLocalAreaExplorePlayState();
	}

	// Token: 0x0600CC79 RID: 52345 RVA: 0x00366FC4 File Offset: 0x003651C4
	public IReadOnlySet<EMapNoteId> GetLocalShowNoteIdMap()
	{
		return this.ShowNoteIdMap;
	}

	// Token: 0x0600CC7A RID: 52346 RVA: 0x00366FCC File Offset: 0x003651CC
	public void SetLocalShowNoteIdMap(EMapNoteId noteId)
	{
		this.ShowNoteIdMap.Add(noteId);
	}

	// Token: 0x0600CC7B RID: 52347 RVA: 0x00366FDB File Offset: 0x003651DB
	public void SaveToLocalShowNoteIdMap()
	{
		LocalStorage.SetPlayer<HashSet<EMapNoteId>>(ELocalStoragePlayerKey.ShowNoteIdMap, this.ShowNoteIdMap);
	}

	// Token: 0x0600CC7C RID: 52348 RVA: 0x00366FEE File Offset: 0x003651EE
	public void LoadLocalShowNoteIdMap()
	{
		this.ShowNoteIdMap = (LocalStorage.GetPlayer<HashSet<EMapNoteId>>(ELocalStoragePlayerKey.ShowNoteIdMap, null) ?? new HashSet<EMapNoteId>());
	}

	// Token: 0x0600CC7D RID: 52349 RVA: 0x0036700A File Offset: 0x0036520A
	public void ClearShowNoteIdMap()
	{
		this.ShowNoteIdMap.Clear();
	}

	// Token: 0x040061BC RID: 25020
	private readonly Dictionary<int, ExploreCountryData> ExploreCountryDataMap = new Dictionary<int, ExploreCountryData>();

	// Token: 0x040061BD RID: 25021
	private readonly Dictionary<int, ExploreAreaData> ExploreAreaDataMap = new Dictionary<int, ExploreAreaData>();

	// Token: 0x040061BE RID: 25022
	private readonly List<int> AllAreaIdList = new List<int>();

	// Token: 0x040061BF RID: 25023
	public int SelectedCountryId;

	// Token: 0x040061C0 RID: 25024
	public int SelectedAreaId;

	// Token: 0x040061C1 RID: 25025
	private readonly Dictionary<int, int> AreaStageRewardIdToAreaIdMap = new Dictionary<int, int>();

	// Token: 0x040061C2 RID: 25026
	private readonly HashSet<int> AchievedAreaRewardIds = new HashSet<int>();

	// Token: 0x040061C3 RID: 25027
	private bool IsRedDotAreaRewardBox;

	// Token: 0x040061C4 RID: 25028
	public readonly Dictionary<int, int> OnlinePlayersAreaMap = new Dictionary<int, int>();

	// Token: 0x040061C5 RID: 25029
	public int TrackTaskAreaId;

	// Token: 0x040061C6 RID: 25030
	public string TrackTaskIconPath = "";

	// Token: 0x040061C7 RID: 25031
	[Nullable(2)]
	private ExploreAreaItemData TrackExploreAreaItemData;

	// Token: 0x040061C8 RID: 25032
	private HashSet<EMapNoteId> ShowNoteIdMap = new HashSet<EMapNoteId>();
}
