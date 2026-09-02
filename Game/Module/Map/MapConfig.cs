using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.WorldMap;

namespace CSharpScript.Game.Module.Map
{
	// Token: 0x020057E4 RID: 22500
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MapConfig : ConfigBase<MapConfig>
	{
		// Token: 0x060392B2 RID: 234162 RVA: 0x00E7E168 File Offset: 0x00E7C368
		protected override bool OnInit()
		{
			this.MarkHasFunctionMap = new Dictionary<int, bool>();
			this.MapFogConfigMap = new Dictionary<string, bool>();
			IReadOnlyList<MapMarkRelativeSubType> configList = ConfigMapMarkRelativeSubTypeAll.GetConfigList(true);
			if (configList != null)
			{
				foreach (MapMarkRelativeSubType mapMarkRelativeSubType in configList)
				{
					this.MarkHasFunctionMap[mapMarkRelativeSubType.FunctionId] = true;
				}
			}
			IReadOnlyList<FogBlock> configList2 = ConfigFogBlockAll.GetConfigList(true);
			if (configList2 != null)
			{
				foreach (FogBlock fogBlock in configList2)
				{
					Dictionary<string, bool> mapFogConfigMap = this.MapFogConfigMap;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
					defaultInterpolatedStringHandler.AppendFormatted(fogBlock.Block);
					defaultInterpolatedStringHandler.AppendLiteral("_");
					defaultInterpolatedStringHandler.AppendFormatted<int>(fogBlock.MapId);
					mapFogConfigMap[defaultInterpolatedStringHandler.ToStringAndClear()] = true;
				}
			}
			IReadOnlyList<TaskMark> configList3 = ConfigTaskMarkAll.GetConfigList(true);
			if (configList3 != null)
			{
				this.TaskMarkMap = new Dictionary<int, TaskMark>();
				foreach (TaskMark value in configList3)
				{
					this.TaskMarkMap[value.QuestId] = value;
				}
			}
			IReadOnlyList<MonsterDetection> configList4 = ConfigMonsterDetectionAll.GetConfigList(true);
			if (configList4 != null)
			{
				this.MonsterDetectionMap = new Dictionary<int, MonsterDetection>();
				foreach (MonsterDetection value2 in configList4)
				{
					this.MonsterDetectionMap[value2.MarkId] = value2;
				}
			}
			IReadOnlyList<MapMark> configList5 = ConfigMapMarkAll.GetConfigList(true);
			if (configList5 != null)
			{
				this.MapMarkMap = new Dictionary<int, MapMark>();
				foreach (MapMark value3 in configList5)
				{
					this.MapMarkMap[value3.MarkId] = value3;
				}
			}
			IReadOnlyList<DynamicMapMark> configList6 = ConfigDynamicMapMarkAll.GetConfigList(true);
			if (configList6 != null)
			{
				this.DynamicMarkMap = new Dictionary<int, DynamicMapMark>();
				foreach (DynamicMapMark value4 in configList6)
				{
					this.DynamicMarkMap[value4.MarkId] = value4;
				}
			}
			this.InitWorldMapNavigateMap();
			this.InitFogTextureConfigMapping();
			this.InitMapBorderConfigMapping();
			this.InitMultiMapConfigMapping();
			this.InitInstanceTeleporterIdList();
			return true;
		}

		// Token: 0x060392B3 RID: 234163 RVA: 0x00E7E408 File Offset: 0x00E7C608
		protected override bool OnClear()
		{
			Dictionary<int, bool> markHasFunctionMap = this.MarkHasFunctionMap;
			if (markHasFunctionMap != null)
			{
				markHasFunctionMap.Clear();
			}
			Dictionary<string, bool> mapFogConfigMap = this.MapFogConfigMap;
			if (mapFogConfigMap != null)
			{
				mapFogConfigMap.Clear();
			}
			Dictionary<int, TaskMark> taskMarkMap = this.TaskMarkMap;
			if (taskMarkMap != null)
			{
				taskMarkMap.Clear();
			}
			Dictionary<int, MapMark> mapMarkMap = this.MapMarkMap;
			if (mapMarkMap != null)
			{
				mapMarkMap.Clear();
			}
			Dictionary<int, DynamicMapMark> dynamicMarkMap = this.DynamicMarkMap;
			if (dynamicMarkMap != null)
			{
				dynamicMarkMap.Clear();
			}
			Dictionary<int, IWorldMapNavigate> worldMapNavigateAreaMapInner = this.WorldMapNavigateAreaMapInner;
			if (worldMapNavigateAreaMapInner != null)
			{
				worldMapNavigateAreaMapInner.Clear();
			}
			Dictionary<int, IWorldMapNavigateCountry> worldMapNavigateCountryMapInner = this.WorldMapNavigateCountryMapInner;
			if (worldMapNavigateCountryMapInner != null)
			{
				worldMapNavigateCountryMapInner.Clear();
			}
			Dictionary<int, MonsterDetection> monsterDetectionMap = this.MonsterDetectionMap;
			if (monsterDetectionMap != null)
			{
				monsterDetectionMap.Clear();
			}
			this.SearchLevelEntityConfigFailureLogSet.Clear();
			Dictionary<string, FogTextureConfig> fogTextureConfigMap = this.FogTextureConfigMap;
			if (fogTextureConfigMap != null)
			{
				fogTextureConfigMap.Clear();
			}
			this.MarkHasFunctionMap = null;
			this.MapFogConfigMap = null;
			this.MapBorderMapping.Clear();
			this.MultiMapConfigMapping.Clear();
			this.MultiMapConfigArray.Clear();
			this.AreaIdToMultiMapIdMapping.Clear();
			this.SubMapAreaSetMapping.Clear();
			this.InstanceTeleporterIdList.Clear();
			return true;
		}

		// Token: 0x060392B4 RID: 234164 RVA: 0x00E7E50C File Offset: 0x00E7C70C
		private void InitWorldMapNavigateMap()
		{
			this.WorldMapNavigateAreaMapInner = new Dictionary<int, IWorldMapNavigate>();
			this.WorldMapNavigateCountryMapInner = new Dictionary<int, IWorldMapNavigateCountry>();
			IReadOnlyList<Aki.Config.Area> worldMapNavigateMap = ConfigAreaByLevel.GetConfigList(2, true) ?? new List<Aki.Config.Area>();
			this.SetWorldMapNavigateMap(worldMapNavigateMap);
		}

		// Token: 0x060392B5 RID: 234165 RVA: 0x00E7E548 File Offset: 0x00E7C748
		private void InitFogTextureConfigMapping()
		{
			IReadOnlyList<FogTextureConfig> allTileConfig = this.GetAllTileConfig();
			if (allTileConfig != null)
			{
				foreach (FogTextureConfig value in allTileConfig)
				{
					string tileConfigKey = this.GetTileConfigKey(value.Block, value.MapId, (EMapGravityDirection)value.GravityFlip);
					this.FogTextureConfigMap[tileConfigKey] = value;
				}
			}
		}

		// Token: 0x060392B6 RID: 234166 RVA: 0x00E7E5BC File Offset: 0x00E7C7BC
		private void InitMapBorderConfigMapping()
		{
			IReadOnlyList<MapBorder> mapBorderConfigList = this.GetMapBorderConfigList();
			if (mapBorderConfigList != null)
			{
				foreach (MapBorder value in mapBorderConfigList)
				{
					string mapBorderConfigKey = this.GetMapBorderConfigKey(value.BorderId, value.MapId);
					this.MapBorderMapping[mapBorderConfigKey] = value;
				}
			}
		}

		// Token: 0x060392B7 RID: 234167 RVA: 0x00E7E62C File Offset: 0x00E7C82C
		private unsafe void InitMultiMapConfigMapping()
		{
			IReadOnlyList<MultiMap> configList = ConfigMultiMapAll.GetConfigList(true);
			if (configList != null)
			{
				foreach (MultiMap multiMap in configList)
				{
					this.MultiMapConfigMapping[multiMap.Id] = multiMap;
					this.MultiMapConfigArray.Add(multiMap);
					HashSet<int> hashSet = new HashSet<int>();
					Span<int> areaBytes = multiMap.GetAreaBytes();
					for (int i = 0; i < areaBytes.Length; i++)
					{
						int num = *areaBytes[i];
						if (!this.AreaIdToMultiMapIdMapping.ContainsKey(num))
						{
							this.AreaIdToMultiMapIdMapping[num] = multiMap.Id;
						}
						hashSet.Add(num);
					}
					this.SubMapAreaSetMapping[multiMap.Id] = hashSet;
				}
			}
		}

		// Token: 0x060392B8 RID: 234168 RVA: 0x00E7E710 File Offset: 0x00E7C910
		private void InitInstanceTeleporterIdList()
		{
			foreach (InstEntityTeleporter instEntityTeleporter in (ConfigInstEntityTeleporterAll.GetConfigList(true) ?? Array.Empty<InstEntityTeleporter>()))
			{
				this.InstanceTeleporterIdList.Add(instEntityTeleporter.Id);
			}
		}

		// Token: 0x060392B9 RID: 234169 RVA: 0x00E7E774 File Offset: 0x00E7C974
		private void SetWorldMapNavigateMap(IReadOnlyList<Aki.Config.Area> areaList)
		{
			foreach (Aki.Config.Area area in areaList)
			{
				WorldMapNavigateImpl worldMapNavigateImpl = new WorldMapNavigateImpl
				{
					AreaId = area.AreaId,
					StateId = new int?(area.StateId),
					CountryId = area.CountryId,
					MarkId = area.DeliveryMarkId,
					MarkType = (EMarkType)area.DeliveryMarkType,
					SortIndex = area.SortIndex
				};
				this.WorldMapNavigateAreaMapInner[area.AreaId] = worldMapNavigateImpl;
				IWorldMapNavigateCountry worldMapNavigateCountry;
				if (!this.WorldMapNavigateCountryMapInner.TryGetValue(area.CountryId, out worldMapNavigateCountry))
				{
					worldMapNavigateCountry = new WorldMapNavigateCountryImpl
					{
						StateMap = null,
						AreaNavigateList = new List<IWorldMapNavigate>()
					};
					this.WorldMapNavigateCountryMapInner[area.CountryId] = worldMapNavigateCountry;
					WorldMapNavigateCountryData item = new WorldMapNavigateCountryData
					{
						CountryId = area.CountryId,
						NavigateCountry = worldMapNavigateCountry
					};
					this.WorldMapNavigateCountryListInner.Add(item);
					this.WorldMapNavigateCountryListInner.Sort(delegate(IWorldMapNavigateCountryData a, IWorldMapNavigateCountryData b)
					{
						Country? countryConfig = ConfigBase<InfluenceConfig>.Instance.GetCountryConfig(a.CountryId);
						int num = (countryConfig != null) ? countryConfig.GetValueOrDefault().SortIndex : 0;
						countryConfig = ConfigBase<InfluenceConfig>.Instance.GetCountryConfig(b.CountryId);
						int value = (countryConfig != null) ? countryConfig.GetValueOrDefault().SortIndex : 0;
						return num.CompareTo(value);
					});
				}
				int valueOrDefault = worldMapNavigateImpl.StateId.GetValueOrDefault();
				if (valueOrDefault != 0)
				{
					if (worldMapNavigateCountry.StateMap == null)
					{
						worldMapNavigateCountry.StateMap = new Dictionary<int, IWorldMapNavigateState>();
					}
					if (!worldMapNavigateCountry.StateMap.ContainsKey(valueOrDefault))
					{
						worldMapNavigateCountry.StateMap[valueOrDefault] = new WorldMapNavigateState
						{
							StateId = valueOrDefault,
							SortIndex = ConfigBase<ExploreProgressConfig>.Instance.GetStateConfigByStateId(valueOrDefault).Value.SortIndex,
							AreaNavigateList = new List<IWorldMapNavigate>()
						};
					}
					worldMapNavigateCountry.StateMap[valueOrDefault].AreaNavigateList.Add(worldMapNavigateImpl);
				}
				worldMapNavigateCountry.AreaNavigateList.Add(worldMapNavigateImpl);
			}
			foreach (IWorldMapNavigateCountry worldMapNavigateCountry2 in this.WorldMapNavigateCountryMapInner.Values)
			{
				List<IWorldMapNavigate> areaNavigateList = worldMapNavigateCountry2.AreaNavigateList;
				Comparison<IWorldMapNavigate> comparison;
				if ((comparison = MapConfig.<>O.<0>__CompareNavigate) == null)
				{
					comparison = (MapConfig.<>O.<0>__CompareNavigate = new Comparison<IWorldMapNavigate>(MapConfig.CompareNavigate));
				}
				areaNavigateList.Sort(comparison);
				if (worldMapNavigateCountry2.StateMap != null)
				{
					foreach (IWorldMapNavigateState worldMapNavigateState in worldMapNavigateCountry2.StateMap.Values)
					{
						List<IWorldMapNavigate> areaNavigateList2 = worldMapNavigateState.AreaNavigateList;
						Comparison<IWorldMapNavigate> comparison2;
						if ((comparison2 = MapConfig.<>O.<0>__CompareNavigate) == null)
						{
							comparison2 = (MapConfig.<>O.<0>__CompareNavigate = new Comparison<IWorldMapNavigate>(MapConfig.CompareNavigate));
						}
						areaNavigateList2.Sort(comparison2);
					}
				}
			}
		}

		// Token: 0x060392BA RID: 234170 RVA: 0x00E7EA64 File Offset: 0x00E7CC64
		private static int CompareNavigate(IWorldMapNavigate a, IWorldMapNavigate b)
		{
			int sortIndex = a.SortIndex;
			int sortIndex2 = b.SortIndex;
			if (sortIndex != sortIndex2)
			{
				return sortIndex.CompareTo(sortIndex2);
			}
			return a.AreaId.CompareTo(b.AreaId);
		}

		// Token: 0x170091C9 RID: 37321
		// (get) Token: 0x060392BB RID: 234171 RVA: 0x00E7EAA0 File Offset: 0x00E7CCA0
		public Dictionary<int, IWorldMapNavigate> WorldMapNavigateAreaMap
		{
			get
			{
				return this.WorldMapNavigateAreaMapInner;
			}
		}

		// Token: 0x170091CA RID: 37322
		// (get) Token: 0x060392BC RID: 234172 RVA: 0x00E7EAA8 File Offset: 0x00E7CCA8
		public Dictionary<int, IWorldMapNavigateCountry> WorldMapNavigateCountryMap
		{
			get
			{
				return this.WorldMapNavigateCountryMapInner;
			}
		}

		// Token: 0x170091CB RID: 37323
		// (get) Token: 0x060392BD RID: 234173 RVA: 0x00E7EAB0 File Offset: 0x00E7CCB0
		public List<IWorldMapNavigateCountryData> WorldMapNavigateCountryList
		{
			get
			{
				return this.WorldMapNavigateCountryListInner;
			}
		}

		// Token: 0x060392BE RID: 234174 RVA: 0x00E7EAB8 File Offset: 0x00E7CCB8
		public TaskMark? GetTaskMarkConfig(int markId)
		{
			return ConfigTaskMarkByMarkId.GetConfig(markId, true);
		}

		// Token: 0x060392BF RID: 234175 RVA: 0x00E7EAC4 File Offset: 0x00E7CCC4
		public TaskMark? GetTaskMarkConfigByQuestId(int questId)
		{
			Dictionary<int, TaskMark> taskMarkMap = this.TaskMarkMap;
			if (taskMarkMap == null)
			{
				return null;
			}
			return taskMarkMap.GetValueOrNull(questId);
		}

		// Token: 0x060392C0 RID: 234176 RVA: 0x00E7EAEC File Offset: 0x00E7CCEC
		public MonsterDetection? GetMonsterDetectionConfig(int markId)
		{
			Dictionary<int, MonsterDetection> monsterDetectionMap = this.MonsterDetectionMap;
			if (monsterDetectionMap == null)
			{
				return null;
			}
			return monsterDetectionMap.GetValueOrNull(markId);
		}

		// Token: 0x060392C1 RID: 234177 RVA: 0x00E7EB14 File Offset: 0x00E7CD14
		[NullableContext(2)]
		public IReadOnlyList<MapMark> GetConfigMarks(int mapId)
		{
			IReadOnlyList<MapMark> configList = ConfigMapMarkByMapId.GetConfigList(mapId, true);
			if (configList == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Map;
				ELogAuthor author = ELogAuthor.LYX;
				string message = "GetConfigMarks-> 找不到MapMark对应MapId的配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("mapId", mapId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return configList;
		}

		// Token: 0x060392C2 RID: 234178 RVA: 0x00E7EB58 File Offset: 0x00E7CD58
		public MapMark? GetConfigMark(int markId)
		{
			Dictionary<int, MapMark> mapMarkMap = this.MapMarkMap;
			if (mapMarkMap == null)
			{
				return null;
			}
			return mapMarkMap.GetValueOrNull(markId);
		}

		// Token: 0x060392C3 RID: 234179 RVA: 0x00E7EB7F File Offset: 0x00E7CD7F
		public Dictionary<int, MapMark> GetConfigMarkMap()
		{
			return this.MapMarkMap;
		}

		// Token: 0x060392C4 RID: 234180 RVA: 0x00E7EB88 File Offset: 0x00E7CD88
		public DynamicMapMark? GetDynamicConfigMark(int markId)
		{
			DynamicMapMark? config = ConfigDynamicMapMarkByMarkId.GetConfig(markId, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Map;
				ELogAuthor author = ELogAuthor.LYX;
				string message = "找不到DynamicMapMark表";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("markId", markId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x060392C5 RID: 234181 RVA: 0x00E7EBD4 File Offset: 0x00E7CDD4
		[NullableContext(0)]
		public OneOf<MapMark, DynamicMapMark>? SearchMarkConfig(int markId)
		{
			MapMark value;
			if (this.MapMarkMap != null && this.MapMarkMap.TryGetValue(markId, out value))
			{
				return new OneOf<MapMark, DynamicMapMark>?(value);
			}
			DynamicMapMark value2;
			if (this.DynamicMarkMap != null && this.DynamicMarkMap.TryGetValue(markId, out value2))
			{
				return new OneOf<MapMark, DynamicMapMark>?(value2);
			}
			return null;
		}

		// Token: 0x060392C6 RID: 234182 RVA: 0x00E7EC34 File Offset: 0x00E7CE34
		[NullableContext(0)]
		public OneOf<MapMark, DynamicMapMark>? SearchMapConfigByType(int markId, EMarkType markType)
		{
			MapMark value;
			if (this.MapMarkMap != null && this.MapMarkMap.TryGetValue(markId, out value) && value.ObjectType == (int)markType)
			{
				return new OneOf<MapMark, DynamicMapMark>?(value);
			}
			DynamicMapMark value2;
			if (this.DynamicMarkMap != null && this.DynamicMarkMap.TryGetValue(markId, out value2) && value2.ObjectType == (int)markType)
			{
				return new OneOf<MapMark, DynamicMapMark>?(value2);
			}
			return null;
		}

		// Token: 0x060392C7 RID: 234183 RVA: 0x00E7ECA8 File Offset: 0x00E7CEA8
		public int? SearchMarkInstanceDungeonId(int markId, EMarkType markType)
		{
			if (markType == EMarkType.Custom)
			{
				return null;
			}
			OneOf<MapMark, DynamicMapMark>? oneOf = this.SearchMapConfigByType(markId, markType);
			if (oneOf != null)
			{
				if (oneOf.Value.IsT1)
				{
					return new int?(oneOf.Value.AsT1.RelativeDungeonId);
				}
				if (oneOf.Value.IsT2)
				{
					return new int?(oneOf.Value.AsT2.InstanceDungeonId);
				}
			}
			return null;
		}

		// Token: 0x060392C8 RID: 234184 RVA: 0x00E7ED3C File Offset: 0x00E7CF3C
		public Teleporter? GetTeleportConfigById(int teleportId)
		{
			Teleporter? config = ConfigTeleporterById.GetConfig(teleportId, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Map;
				ELogAuthor author = ELogAuthor.LYX;
				string message = "找不到Teleporter表的配置,Id = ";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("teleportId", teleportId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x060392C9 RID: 234185 RVA: 0x00E7ED88 File Offset: 0x00E7CF88
		public InstEntityTeleporter? GetInstEntityTeleportConfigById(int instEntityTeleportId)
		{
			InstEntityTeleporter? config = ConfigInstEntityTeleporterById.GetConfig(instEntityTeleportId, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Map;
				ELogAuthor author = ELogAuthor.LYX;
				string message = "找不到InstEntityTeleporter表的配置,EntityId = ";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("InstEntityTeleportId", instEntityTeleportId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x060392CA RID: 234186 RVA: 0x00E7EDD3 File Offset: 0x00E7CFD3
		public bool GetIsInstanceTeleporterExist(int instEntityTeleportId)
		{
			return this.InstanceTeleporterIdList.Contains(instEntityTeleportId);
		}

		// Token: 0x060392CB RID: 234187 RVA: 0x00E7EDE4 File Offset: 0x00E7CFE4
		public TemporaryTeleportMark? GetTemporaryTeleportMarkConfigById(int markId)
		{
			TemporaryTeleportMark? config = ConfigTemporaryTeleportMarkByMarkId.GetConfig(markId, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Map;
				ELogAuthor author = ELogAuthor.LYX;
				string message = "找不到TemporaryTeleportMark表的配置,Id = ";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("markId", markId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x060392CC RID: 234188 RVA: 0x00E7EE30 File Offset: 0x00E7D030
		private string GetTileConfigKey(string blockIndex, int mapId, EMapGravityDirection mapGravity)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
			defaultInterpolatedStringHandler.AppendFormatted(blockIndex);
			defaultInterpolatedStringHandler.AppendLiteral("_");
			defaultInterpolatedStringHandler.AppendFormatted<int>(mapId);
			defaultInterpolatedStringHandler.AppendLiteral("_");
			defaultInterpolatedStringHandler.AppendFormatted<EMapGravityDirection>(mapGravity);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x060392CD RID: 234189 RVA: 0x00E7EE80 File Offset: 0x00E7D080
		public FogTextureConfig? GetTileConfig(string blockIndex, int mapId, EMapGravityDirection mapGravity)
		{
			string tileConfigKey = this.GetTileConfigKey(blockIndex, mapId, mapGravity);
			FogTextureConfig value;
			if (this.FogTextureConfigMap.TryGetValue(tileConfigKey, out value))
			{
				return new FogTextureConfig?(value);
			}
			return null;
		}

		// Token: 0x060392CE RID: 234190 RVA: 0x00E7EEB7 File Offset: 0x00E7D0B7
		[NullableContext(2)]
		public IReadOnlyList<FogTextureConfig> GetAllTileConfig()
		{
			return ConfigFogTextureConfigAll.GetConfigList(true);
		}

		// Token: 0x060392CF RID: 234191 RVA: 0x00E7EEBF File Offset: 0x00E7D0BF
		[NullableContext(2)]
		public IReadOnlyList<FogTextureConfig> GetAllTileConfigByMapId(int mapId)
		{
			return ConfigFogTextureConfigByMapId.GetConfigList(mapId, true);
		}

		// Token: 0x060392D0 RID: 234192 RVA: 0x00E7EEC8 File Offset: 0x00E7D0C8
		public BlockSwitch? GetUnlockMapTileConfigById(int id)
		{
			return ConfigBlockSwitchById.GetConfig(id, true);
		}

		// Token: 0x060392D1 RID: 234193 RVA: 0x00E7EED4 File Offset: 0x00E7D0D4
		public List<MultiMap> GetSubMapConfigByGroupId(int groupId)
		{
			List<MultiMap> list = new List<MultiMap>();
			foreach (MultiMap item in this.MultiMapConfigArray)
			{
				if (item.GroupId == groupId)
				{
					list.Add(item);
				}
			}
			return list;
		}

		// Token: 0x060392D2 RID: 234194 RVA: 0x00E7EF38 File Offset: 0x00E7D138
		public MultiMap? GetSubMapConfigById(int id)
		{
			MultiMap value;
			if (this.MultiMapConfigMapping.TryGetValue(id, out value))
			{
				return new MultiMap?(value);
			}
			return null;
		}

		// Token: 0x060392D3 RID: 234195 RVA: 0x00E7EF65 File Offset: 0x00E7D165
		public List<MultiMap> GetAllSubMapConfig()
		{
			return this.MultiMapConfigArray;
		}

		// Token: 0x060392D4 RID: 234196 RVA: 0x00E7EF70 File Offset: 0x00E7D170
		public MultiMap? GetSubMapConfigByAreaId(int areaId)
		{
			if (areaId == 0)
			{
				return null;
			}
			int id;
			if (this.AreaIdToMultiMapIdMapping.TryGetValue(areaId, out id))
			{
				return this.GetSubMapConfigById(id);
			}
			return null;
		}

		// Token: 0x060392D5 RID: 234197 RVA: 0x00E7EFAC File Offset: 0x00E7D1AC
		public bool IsAreaInSubMap(int multiMapId, int areaId)
		{
			HashSet<int> hashSet;
			return this.SubMapAreaSetMapping.TryGetValue(multiMapId, out hashSet) && hashSet.Contains(areaId);
		}

		// Token: 0x060392D6 RID: 234198 RVA: 0x00E7EFD4 File Offset: 0x00E7D1D4
		public CustomMark? GetCustomMarkConfig(int id)
		{
			CustomMark? config = ConfigCustomMarkByMarkId.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Map;
				ELogAuthor author = ELogAuthor.LYX;
				string message = "找不到CustomMark表的配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MarkId", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x060392D7 RID: 234199 RVA: 0x00E7F020 File Offset: 0x00E7D220
		public FogBlock? GetFogBlockConfig(string blockIndex, int mapId)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted(blockIndex);
			defaultInterpolatedStringHandler.AppendLiteral("_");
			defaultInterpolatedStringHandler.AppendFormatted<int>(mapId);
			string key = defaultInterpolatedStringHandler.ToStringAndClear();
			if (this.MapFogConfigMap != null && this.MapFogConfigMap.ContainsKey(key))
			{
				return ConfigFogBlockByBlockAndMapId.GetConfig(blockIndex, mapId, true);
			}
			return null;
		}

		// Token: 0x060392D8 RID: 234200 RVA: 0x00E7F082 File Offset: 0x00E7D282
		public string GetLocalText(string textKey)
		{
			return ConfigMultiTextLang.GetLocalTextNew(textKey, null) ?? "";
		}

		// Token: 0x060392D9 RID: 234201 RVA: 0x00E7F094 File Offset: 0x00E7D294
		public LevelEntityConfig? GetEntityConfigByMapIdAndEntityId(int mapId, int entityId)
		{
			if (entityId == 0)
			{
				return null;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(mapId);
			defaultInterpolatedStringHandler.AppendLiteral("-");
			defaultInterpolatedStringHandler.AppendFormatted<int>(entityId);
			string item = defaultInterpolatedStringHandler.ToStringAndClear();
			if (this.SearchLevelEntityConfigFailureLogSet.Contains(item))
			{
				return null;
			}
			LevelEntityConfig? config = ConfigLevelEntityConfigByMapIdAndEntityId.GetConfig(mapId, entityId, true);
			if (config == null)
			{
				this.SearchLevelEntityConfigFailureLogSet.Add(item);
			}
			return config;
		}

		// Token: 0x060392DA RID: 234202 RVA: 0x00E7F114 File Offset: 0x00E7D314
		private string GetMapBorderConfigKey(int borderId, int mapId)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(borderId);
			defaultInterpolatedStringHandler.AppendLiteral("_");
			defaultInterpolatedStringHandler.AppendFormatted<int>(mapId);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x060392DB RID: 234203 RVA: 0x00E7F150 File Offset: 0x00E7D350
		public MapBorder? GetMapBorderConfig(int borderId, int mapId)
		{
			string mapBorderConfigKey = this.GetMapBorderConfigKey(borderId, mapId);
			return this.MapBorderMapping.GetValueOrNull(mapBorderConfigKey);
		}

		// Token: 0x060392DC RID: 234204 RVA: 0x00E7F172 File Offset: 0x00E7D372
		[NullableContext(2)]
		public IReadOnlyList<MapBorder> GetMapBorderConfigList()
		{
			return ConfigMapBorderAll.GetConfigList(true);
		}

		// Token: 0x060392DD RID: 234205 RVA: 0x00E7F17A File Offset: 0x00E7D37A
		public int? GetMapDissolveTime()
		{
			return ConfigCommonParamById.GetIntConfig("MapDissolveTime");
		}

		// Token: 0x060392DE RID: 234206 RVA: 0x00E7F188 File Offset: 0x00E7D388
		public SoundBoxMark? GetSoundBoxMarkConfig(int markId)
		{
			SoundBoxMark? config = ConfigSoundBoxMarkByMarkId.GetConfig(markId, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Map;
				ELogAuthor author = ELogAuthor.LYX;
				string message = "找不到SoundBoxMark表的配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MarkId", markId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x060392DF RID: 234207 RVA: 0x00E7F1D4 File Offset: 0x00E7D3D4
		public TreasureBoxMark? GetTreasureBoxMarkConfig(int markId)
		{
			TreasureBoxMark? config = ConfigTreasureBoxMarkByMarkId.GetConfig(markId, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Map;
				ELogAuthor author = ELogAuthor.LYX;
				string message = "找不到TreasureBoxMark表的配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MarkId", markId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x060392E0 RID: 234208 RVA: 0x00E7F220 File Offset: 0x00E7D420
		public TreasureBoxDetectorMark? GetTreasureBoxDetectorMarkConfig(int markId)
		{
			TreasureBoxDetectorMark? config = ConfigTreasureBoxDetectorMarkByMarkId.GetConfig(markId, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Map;
				ELogAuthor author = ELogAuthor.LK;
				string message = "找不到TreasureBoxDetectorMark表的配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MarkId", markId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x060392E1 RID: 234209 RVA: 0x00E7F26C File Offset: 0x00E7D46C
		public MapMarkRelativeSubType? GetMapMarkFuncTypeConfigByFuncId(int functionType)
		{
			if (this.MarkHasFunctionMap != null && this.MarkHasFunctionMap.ContainsKey(functionType))
			{
				return ConfigMapMarkRelativeSubTypeByFunctionId.GetConfig(functionType, true);
			}
			return null;
		}

		// Token: 0x060392E2 RID: 234210 RVA: 0x00E7F2A0 File Offset: 0x00E7D4A0
		public MapMarkRelativeSubType? GetMapMarkFuncTypeConfigById(int id)
		{
			return ConfigMapMarkRelativeSubTypeById.GetConfig(id, true);
		}

		// Token: 0x060392E3 RID: 234211 RVA: 0x00E7F2AC File Offset: 0x00E7D4AC
		public string GetUiResourcePathById(string key)
		{
			if (StringUtils.IsEmpty(key))
			{
				return "";
			}
			UiResource? config = ConfigUiResourceById.GetConfig(key, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Map;
				ELogAuthor author = ELogAuthor.LYX;
				string message = "找不到UiResource表的配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("key", key);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return "";
			}
			return config.Value.Path;
		}

		// Token: 0x060392E4 RID: 234212 RVA: 0x00E7F314 File Offset: 0x00E7D514
		[NullableContext(2)]
		public IReadOnlyList<MultiMapAreaConfig> GetMultiMapAreaConfigList()
		{
			return ConfigMultiMapAreaConfigAll.GetConfigList(true);
		}

		// Token: 0x060392E5 RID: 234213 RVA: 0x00E7F31C File Offset: 0x00E7D51C
		[NullableContext(2)]
		public IReadOnlyList<EnrichmentAreaConfig> GetEnrichmentAreaConfigByItemId(int itemId)
		{
			return ConfigEnrichmentAreaConfigByItemId.GetConfigList(itemId, true);
		}

		// Token: 0x060392E6 RID: 234214 RVA: 0x00E7F328 File Offset: 0x00E7D528
		public EnrichmentAreaConfig? GetEnrichmentAreaConfigByEnrichmentId(int enrichmentId)
		{
			IReadOnlyList<EnrichmentAreaConfig> configList = ConfigEnrichmentAreaConfigByEnrichmentId.GetConfigList(enrichmentId, true);
			if (configList != null && configList.Count > 0)
			{
				return new EnrichmentAreaConfig?(configList[0]);
			}
			return null;
		}

		// Token: 0x060392E7 RID: 234215 RVA: 0x00E7F35F File Offset: 0x00E7D55F
		public MapMark? GetMapMarkByRelativeId(int relativeId, int instanceDungeonId)
		{
			return ConfigMapMarkByRelativeId.GetConfig(relativeId, instanceDungeonId, true);
		}

		// Token: 0x060392E8 RID: 234216 RVA: 0x00E7F369 File Offset: 0x00E7D569
		public MapMark? GetMapMarkByEntityConfigId(int entityId)
		{
			return ConfigMapMarkByEntityConfigId.GetConfig(entityId, true);
		}

		// Token: 0x060392E9 RID: 234217 RVA: 0x00E7F372 File Offset: 0x00E7D572
		[NullableContext(2)]
		public IReadOnlyList<MapMark> GetMapMarkListByInstanceDungeonId(int instanceDungeonId)
		{
			return ConfigMapMarkByInstanceDungeonId.GetConfigList(instanceDungeonId, true);
		}

		// Token: 0x060392EA RID: 234218 RVA: 0x00E7F37B File Offset: 0x00E7D57B
		public MapPeriodicActivity? GetMapPeriodicActivityConfig(EMapPeriodicActivityId id)
		{
			return ConfigMapPeriodicActivityById.GetConfig((int)id, true);
		}

		// Token: 0x060392EB RID: 234219 RVA: 0x00E7F384 File Offset: 0x00E7D584
		[NullableContext(2)]
		public IReadOnlyList<MapPeriodicActivity> GetMapPeriodicActivityListConfigs()
		{
			return ConfigMapPeriodicActivityAll.GetConfigList(true);
		}

		// Token: 0x060392EC RID: 234220 RVA: 0x00E7F38C File Offset: 0x00E7D58C
		[NullableContext(2)]
		public IReadOnlyList<MapRoadWays> GetMapRoadWaysByMapId(int mapId)
		{
			return ConfigMapRoadWaysByMapId.GetConfigList(mapId, true);
		}

		// Token: 0x060392ED RID: 234221 RVA: 0x00E7F395 File Offset: 0x00E7D595
		[NullableContext(2)]
		public IReadOnlyList<MapFog> GetMapFogByAreaId(int areaId)
		{
			return ConfigMapFogByAreaId.GetConfigList(areaId, true);
		}

		// Token: 0x04020879 RID: 133241
		private readonly Dictionary<string, FogTextureConfig> FogTextureConfigMap = new Dictionary<string, FogTextureConfig>();

		// Token: 0x0402087A RID: 133242
		[Nullable(2)]
		private Dictionary<int, bool> MarkHasFunctionMap;

		// Token: 0x0402087B RID: 133243
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<string, bool> MapFogConfigMap;

		// Token: 0x0402087C RID: 133244
		[Nullable(2)]
		private Dictionary<int, TaskMark> TaskMarkMap;

		// Token: 0x0402087D RID: 133245
		[Nullable(2)]
		private Dictionary<int, MapMark> MapMarkMap;

		// Token: 0x0402087E RID: 133246
		[Nullable(2)]
		private Dictionary<int, DynamicMapMark> DynamicMarkMap;

		// Token: 0x0402087F RID: 133247
		[Nullable(2)]
		private Dictionary<int, MonsterDetection> MonsterDetectionMap;

		// Token: 0x04020880 RID: 133248
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<int, IWorldMapNavigate> WorldMapNavigateAreaMapInner;

		// Token: 0x04020881 RID: 133249
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<int, IWorldMapNavigateCountry> WorldMapNavigateCountryMapInner;

		// Token: 0x04020882 RID: 133250
		private readonly List<IWorldMapNavigateCountryData> WorldMapNavigateCountryListInner = new List<IWorldMapNavigateCountryData>();

		// Token: 0x04020883 RID: 133251
		private readonly HashSet<string> SearchLevelEntityConfigFailureLogSet = new HashSet<string>();

		// Token: 0x04020884 RID: 133252
		private readonly Dictionary<string, MapBorder> MapBorderMapping = new Dictionary<string, MapBorder>();

		// Token: 0x04020885 RID: 133253
		private readonly Dictionary<int, MultiMap> MultiMapConfigMapping = new Dictionary<int, MultiMap>();

		// Token: 0x04020886 RID: 133254
		private readonly List<MultiMap> MultiMapConfigArray = new List<MultiMap>();

		// Token: 0x04020887 RID: 133255
		private readonly Dictionary<int, int> AreaIdToMultiMapIdMapping = new Dictionary<int, int>();

		// Token: 0x04020888 RID: 133256
		private readonly Dictionary<int, HashSet<int>> SubMapAreaSetMapping = new Dictionary<int, HashSet<int>>();

		// Token: 0x04020889 RID: 133257
		private readonly HashSet<int> InstanceTeleporterIdList = new HashSet<int>();

		// Token: 0x0402088A RID: 133258
		[StaticVariableRuleIgnore]
		public static bool EnableAsyncMiniMap;

		// Token: 0x0200B85F RID: 47199
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0403906C RID: 233580
			[Nullable(new byte[]
			{
				0,
				1
			})]
			public static Comparison<IWorldMapNavigate> <0>__CompareNavigate;
		}
	}
}
