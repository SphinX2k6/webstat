using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.LevelGamePlay.UnopenedArea;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Misc;
using CSharpScript.Game.Module.Map.View.BaseMap.Assistant;
using CSharpScript.Game.Module.Map.View.BaseMap.Assistant.MapLifeEvent;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.Map
{
	// Token: 0x020057E7 RID: 22503
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MapModel : ModelBase<MapModel>
	{
		// Token: 0x170091CC RID: 37324
		// (get) Token: 0x060392F3 RID: 234227 RVA: 0x00E7F650 File Offset: 0x00E7D850
		// (set) Token: 0x060392F4 RID: 234228 RVA: 0x00E7F658 File Offset: 0x00E7D858
		public int? LastHighLevelArea
		{
			get
			{
				return this.LastHighLevelAreaInner;
			}
			set
			{
				this.LastHighLevelAreaInner = value;
			}
		}

		// Token: 0x060392F5 RID: 234229 RVA: 0x00E7F664 File Offset: 0x00E7D864
		protected override bool OnInit()
		{
			this.DynamicMarks = new Dictionary<EMarkType, Dictionary<int, DynamicMarkCreateInfo>>();
			this.UnlockedTeleports = new Dictionary<int, bool>();
			this.UnlockedFogs = new Dictionary<int, bool>();
			this.UnlockedAreas = new Dictionary<int, bool>();
			this.PendingAddEntityList = new Dictionary<int, int>();
			this.PendingAddTempMapMarkList = new HashSet<int>();
			this.MarkExtraShowStateReference = new Dictionary<int, IMarkShowState>();
			this.DynamicMarksSearchMap = new Dictionary<int, DynamicMarkCreateInfo>();
			this.MarkVisibleStateRecord = new Dictionary<int, Dictionary<int, bool>>();
			this.SceneGamePlayRefQuestMap = new Dictionary<int, long>();
			this.OccupationResourceRefPlayMap = new Dictionary<string, int[]>();
			this.ServerUnlockedMarksMap = new Dictionary<int, bool>();
			this.MapLifeEventListenerTriggerMap = new Dictionary<EMapLifeEventListenerType, IMapLifeEventTriggerParam>();
			this.TreasureBoxSlotRawDataMap = new Dictionary<int, TreasureBoxSlotInfo>();
			this.TemporaryTeleportInfoRawDataMap = new Dictionary<int, TemporaryTeleportInfo>();
			this.UnlockMapBlockIds = new List<int>();
			this.SystemMarkHideInfoMap = new Dictionary<string, SystemMarkHideInfoPb>();
			this.EntityIdToMarkType = new Dictionary<int, EMarkType>();
			this.ExtraMarkTypeMap = new Dictionary<EMapType, HashSet<EMarkType>>();
			this.ExtraMarkIdMap = new Dictionary<EMapType, HashSet<int>>();
			this.ExtraUiTileRange = new Dictionary<EMapType, ITileNum>();
			this.InitTeleportMarkQueryCache();
			return true;
		}

		// Token: 0x060392F6 RID: 234230 RVA: 0x00E7F75F File Offset: 0x00E7D95F
		protected override bool OnChangeMode()
		{
			ModelBase<TrackModel>.Instance.ClearTrackData();
			this.SetCurTrackMark(null);
			return true;
		}

		// Token: 0x060392F7 RID: 234231 RVA: 0x00E7F774 File Offset: 0x00E7D974
		protected override bool OnClear()
		{
			Dictionary<EMarkType, Dictionary<int, DynamicMarkCreateInfo>> dynamicMarks = this.DynamicMarks;
			if (dynamicMarks != null)
			{
				dynamicMarks.Clear();
			}
			Dictionary<int, bool> unlockedTeleports = this.UnlockedTeleports;
			if (unlockedTeleports != null)
			{
				unlockedTeleports.Clear();
			}
			Dictionary<int, bool> unlockedFogs = this.UnlockedFogs;
			if (unlockedFogs != null)
			{
				unlockedFogs.Clear();
			}
			Dictionary<int, bool> unlockedAreas = this.UnlockedAreas;
			if (unlockedAreas != null)
			{
				unlockedAreas.Clear();
			}
			Dictionary<int, int> pendingAddEntityList = this.PendingAddEntityList;
			if (pendingAddEntityList != null)
			{
				pendingAddEntityList.Clear();
			}
			HashSet<int> pendingAddTempMapMarkList = this.PendingAddTempMapMarkList;
			if (pendingAddTempMapMarkList != null)
			{
				pendingAddTempMapMarkList.Clear();
			}
			Dictionary<int, Dictionary<int, bool>> markVisibleStateRecord = this.MarkVisibleStateRecord;
			if (markVisibleStateRecord != null)
			{
				markVisibleStateRecord.Clear();
			}
			Dictionary<int, long> sceneGamePlayRefQuestMap = this.SceneGamePlayRefQuestMap;
			if (sceneGamePlayRefQuestMap != null)
			{
				sceneGamePlayRefQuestMap.Clear();
			}
			Dictionary<string, int[]> occupationResourceRefPlayMap = this.OccupationResourceRefPlayMap;
			if (occupationResourceRefPlayMap != null)
			{
				occupationResourceRefPlayMap.Clear();
			}
			Dictionary<int, bool> serverUnlockedMarksMap = this.ServerUnlockedMarksMap;
			if (serverUnlockedMarksMap != null)
			{
				serverUnlockedMarksMap.Clear();
			}
			Dictionary<int, TreasureBoxSlotInfo> treasureBoxSlotRawDataMap = this.TreasureBoxSlotRawDataMap;
			if (treasureBoxSlotRawDataMap != null)
			{
				treasureBoxSlotRawDataMap.Clear();
			}
			Dictionary<int, TemporaryTeleportInfo> temporaryTeleportInfoRawDataMap = this.TemporaryTeleportInfoRawDataMap;
			if (temporaryTeleportInfoRawDataMap != null)
			{
				temporaryTeleportInfoRawDataMap.Clear();
			}
			Dictionary<string, SystemMarkHideInfoPb> systemMarkHideInfoMap = this.SystemMarkHideInfoMap;
			if (systemMarkHideInfoMap != null)
			{
				systemMarkHideInfoMap.Clear();
			}
			Dictionary<int, EMarkType> entityIdToMarkType = this.EntityIdToMarkType;
			if (entityIdToMarkType != null)
			{
				entityIdToMarkType.Clear();
			}
			this.DynamicMarks = null;
			this.UnlockedTeleports = null;
			this.UnlockedFogs = null;
			this.UnlockedAreas = null;
			this.PendingAddEntityList = null;
			this.PendingAddTempMapMarkList = null;
			this.CurTrackParams = null;
			this.CacheEnrichmentAreaWorldMapCircle = null;
			this.CacheEnrichmentAreaEntityId = 0;
			this.ExtraMarkTypeMap = null;
			this.ExtraMarkIdMap = null;
			this.ExtraUiTileRange = null;
			return true;
		}

		// Token: 0x060392F8 RID: 234232 RVA: 0x00E7F8C4 File Offset: 0x00E7DAC4
		[NullableContext(2)]
		public Dictionary<int, bool> GetUnlockedTeleportMap()
		{
			return this.UnlockedTeleports;
		}

		// Token: 0x060392F9 RID: 234233 RVA: 0x00E7F8CC File Offset: 0x00E7DACC
		[NullableContext(2)]
		public DynamicMarkCreateInfo GetDynamicMark(int markId)
		{
			Dictionary<int, DynamicMarkCreateInfo> dynamicMarksSearchMap = this.DynamicMarksSearchMap;
			if (dynamicMarksSearchMap == null)
			{
				return null;
			}
			return dynamicMarksSearchMap.GetValueOrDefault(markId);
		}

		// Token: 0x060392FA RID: 234234 RVA: 0x00E7F8E0 File Offset: 0x00E7DAE0
		[NullableContext(2)]
		public DynamicMarkCreateInfo GetMark(EMarkType markType, int markId)
		{
			Dictionary<EMarkType, Dictionary<int, DynamicMarkCreateInfo>> dynamicMarks = this.DynamicMarks;
			Dictionary<int, DynamicMarkCreateInfo> dictionary;
			if (dynamicMarks != null && dynamicMarks.TryGetValue(markType, out dictionary))
			{
				DynamicMarkCreateInfo result;
				dictionary.TryGetValue(markId, out result);
				return result;
			}
			return null;
		}

		// Token: 0x060392FB RID: 234235 RVA: 0x00E7F911 File Offset: 0x00E7DB11
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public Dictionary<int, DynamicMarkCreateInfo> GetMarkByType(EMarkType markType)
		{
			return this.DynamicMarks.GetValueOrDefault(markType);
		}

		// Token: 0x060392FC RID: 234236 RVA: 0x00E7F920 File Offset: 0x00E7DB20
		public int GetMarkCountByType(EMarkType markType)
		{
			Dictionary<EMarkType, Dictionary<int, DynamicMarkCreateInfo>> dynamicMarks = this.DynamicMarks;
			int? num;
			if (dynamicMarks == null)
			{
				num = null;
			}
			else
			{
				Dictionary<int, DynamicMarkCreateInfo> valueOrDefault = dynamicMarks.GetValueOrDefault(markType);
				num = ((valueOrDefault != null) ? new int?(valueOrDefault.Count) : null);
			}
			int? num2 = num;
			return num2.GetValueOrDefault();
		}

		// Token: 0x060392FD RID: 234237 RVA: 0x00E7F96C File Offset: 0x00E7DB6C
		public TTrackTarget GetConfigMarkTrackTarget(int markId)
		{
			MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(markId);
			if (configMark != null)
			{
				if (configMark.Value.EntityConfigId > 0)
				{
					return configMark.Value.EntityConfigId;
				}
				if (configMark.Value.MarkVector != null)
				{
					return global::Vector.Create(configMark.Value.MarkVector);
				}
			}
			return 0;
		}

		// Token: 0x060392FE RID: 234238 RVA: 0x00E7F9F0 File Offset: 0x00E7DBF0
		[NullableContext(2)]
		public QuestMarkCreateInfo GetMarkByQuestId(int questId)
		{
			Dictionary<int, DynamicMarkCreateInfo> markByType = this.GetMarkByType(EMarkType.Quest);
			if (markByType != null)
			{
				foreach (DynamicMarkCreateInfo dynamicMarkCreateInfo in markByType.Values)
				{
					QuestMarkCreateInfo questMarkCreateInfo = (QuestMarkCreateInfo)dynamicMarkCreateInfo;
					if (questMarkCreateInfo.NodeId != 0)
					{
						long treeId = questMarkCreateInfo.TreeId;
						BaseBehaviorTree behaviorTree = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTree(new long?(treeId), false);
						if (behaviorTree != null && behaviorTree.TreeConfigId == questId)
						{
							return questMarkCreateInfo;
						}
					}
					else if (questMarkCreateInfo.TreeId == (long)questId)
					{
						return questMarkCreateInfo;
					}
				}
			}
			return null;
		}

		// Token: 0x060392FF RID: 234239 RVA: 0x00E7FA98 File Offset: 0x00E7DC98
		[return: Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Dictionary<EMarkType, Dictionary<int, DynamicMarkCreateInfo>> GetAllDynamicMarks()
		{
			return this.DynamicMarks;
		}

		// Token: 0x06039300 RID: 234240 RVA: 0x00E7FAA0 File Offset: 0x00E7DCA0
		[NullableContext(2)]
		public DynamicMarkCreateInfo GetDynamicMarkInfoById(int markId)
		{
			DynamicMarkCreateInfo result = null;
			if (this.DynamicMarks != null)
			{
				using (Dictionary<EMarkType, Dictionary<int, DynamicMarkCreateInfo>>.ValueCollection.Enumerator enumerator = this.DynamicMarks.Values.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						DynamicMarkCreateInfo dynamicMarkCreateInfo;
						if (enumerator.Current.TryGetValue(markId, out dynamicMarkCreateInfo))
						{
							result = dynamicMarkCreateInfo;
							break;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06039301 RID: 234241 RVA: 0x00E7FB0C File Offset: 0x00E7DD0C
		[NullableContext(2)]
		public void SetCurTrackMark(TrackMapMarkParams trackMark)
		{
			this.CurTrackParams = trackMark;
		}

		// Token: 0x06039302 RID: 234242 RVA: 0x00E7FB18 File Offset: 0x00E7DD18
		[NullableContext(2)]
		public bool IsEqualToCurTrack(TrackMapMarkParams trackMark)
		{
			int? num = (trackMark != null) ? new int?(trackMark.MarkId) : null;
			TrackMapMarkParams curTrackParams = this.CurTrackParams;
			int? num2 = (curTrackParams != null) ? new int?(curTrackParams.MarkId) : null;
			if (num.GetValueOrDefault() == num2.GetValueOrDefault() & num != null == (num2 != null))
			{
				EMarkType? emarkType = (trackMark != null) ? new EMarkType?(trackMark.MarkType) : null;
				TrackMapMarkParams curTrackParams2 = this.CurTrackParams;
				EMarkType? emarkType2 = (curTrackParams2 != null) ? new EMarkType?(curTrackParams2.MarkType) : null;
				if (emarkType.GetValueOrDefault() == emarkType2.GetValueOrDefault() & emarkType != null == (emarkType2 != null))
				{
					bool? flag = (trackMark != null) ? new bool?(trackMark.Track) : null;
					TrackMapMarkParams curTrackParams3 = this.CurTrackParams;
					bool? flag2 = (curTrackParams3 != null) ? new bool?(curTrackParams3.Track) : null;
					if (flag.GetValueOrDefault() == flag2.GetValueOrDefault() & flag != null == (flag2 != null))
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06039303 RID: 234243 RVA: 0x00E7FC49 File Offset: 0x00E7DE49
		[NullableContext(2)]
		public TrackMapMarkParams GetCurTrackMark()
		{
			return this.CurTrackParams;
		}

		// Token: 0x06039304 RID: 234244 RVA: 0x00E7FC51 File Offset: 0x00E7DE51
		public void CreateServerSaveMark(DynamicMarkCreateInfo info)
		{
			this.CreateDynamicMark(info);
		}

		// Token: 0x06039305 RID: 234245 RVA: 0x00E7FC5C File Offset: 0x00E7DE5C
		public int CreateDyMarkByEntity(int entityId, EMarkType markType, int configId, int mapId)
		{
			Dictionary<int, DynamicMarkCreateInfo> valueOrDefault = this.DynamicMarks.GetValueOrDefault(markType);
			if (valueOrDefault != null)
			{
				DynamicMarkCreateInfo dynamicMarkCreateInfo = valueOrDefault.Values.FirstOrDefault((DynamicMarkCreateInfo mark) => (TTrackTarget_Int)mark.TrackTarget == entityId);
				if (dynamicMarkCreateInfo != null)
				{
					return dynamicMarkCreateInfo.MarkId.Value;
				}
			}
			DynamicMarkCreateInfo info = new DynamicMarkCreateInfo(new DynamicMarkCreateParams
			{
				TrackTarget = entityId,
				MarkConfigId = configId,
				MarkType = markType,
				DestroyOnUnTrack = new bool?(true),
				MapAndDungeonInfo = new MapAndDungeonInfo
				{
					MapConfigId = new int?(mapId)
				},
				EntityConfigId = new int?(entityId)
			});
			return this.CreateMapMark(info);
		}

		// Token: 0x06039306 RID: 234246 RVA: 0x00E7FD17 File Offset: 0x00E7DF17
		public void CreateTempMapMark(int mapMarkId)
		{
			this.AddPendingTempMapMarkList(mapMarkId);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.CreateTempMapMark, mapMarkId);
		}

		// Token: 0x06039307 RID: 234247 RVA: 0x00E7FD31 File Offset: 0x00E7DF31
		public HashSet<int> GetPendingAddTempMapMarkList()
		{
			return this.PendingAddTempMapMarkList;
		}

		// Token: 0x06039308 RID: 234248 RVA: 0x00E7FD39 File Offset: 0x00E7DF39
		public void ClearPendingAddTempMapMarkList()
		{
			HashSet<int> pendingAddTempMapMarkList = this.PendingAddTempMapMarkList;
			if (pendingAddTempMapMarkList == null)
			{
				return;
			}
			pendingAddTempMapMarkList.Clear();
		}

		// Token: 0x06039309 RID: 234249 RVA: 0x00E7FD4B File Offset: 0x00E7DF4B
		public void AddPendingTempMapMarkList(int mapMarkId)
		{
			HashSet<int> pendingAddTempMapMarkList = this.PendingAddTempMapMarkList;
			if (pendingAddTempMapMarkList == null)
			{
				return;
			}
			pendingAddTempMapMarkList.Add(mapMarkId);
		}

		// Token: 0x0603930A RID: 234250 RVA: 0x00E7FD60 File Offset: 0x00E7DF60
		public int CreateMapMark(DynamicMarkCreateInfo info)
		{
			info.MarkId = new int?(this.SpawnDynamicMarkId());
			this.CreateDynamicMark(info);
			return info.MarkId.Value;
		}

		// Token: 0x0603930B RID: 234251 RVA: 0x00E7FD94 File Offset: 0x00E7DF94
		public void CacheMapFishingShipMark(EntityMapMarkInfoPb[] entityMapMarkInfo)
		{
			this.CacheEntityMapMarkInfo.Clear();
			foreach (EntityMapMarkInfoPb entityMapMarkInfoPb in entityMapMarkInfo)
			{
				List<MarkDefine.FishingShipMarkCacheInfo> cacheEntityMapMarkInfo = this.CacheEntityMapMarkInfo;
				MarkDefine.FishingShipMarkCacheInfo fishingShipMarkCacheInfo = new MarkDefine.FishingShipMarkCacheInfo();
				fishingShipMarkCacheInfo.InstanceId = entityMapMarkInfoPb.InstId;
				fishingShipMarkCacheInfo.TemplateId = entityMapMarkInfoPb.TemplateId;
				Aki.Protocol.Vector location = entityMapMarkInfoPb.Location;
				fishingShipMarkCacheInfo.PositionX = (double)((location != null) ? location.X : 0f);
				Aki.Protocol.Vector location2 = entityMapMarkInfoPb.Location;
				fishingShipMarkCacheInfo.PositionY = (double)((location2 != null) ? location2.Y : 0f);
				Aki.Protocol.Vector location3 = entityMapMarkInfoPb.Location;
				fishingShipMarkCacheInfo.PositionZ = (double)((location3 != null) ? location3.Z : 0f);
				cacheEntityMapMarkInfo.Add(fishingShipMarkCacheInfo);
				ELogAuthor author = ELogAuthor.LYX;
				string message = "标记系统->CacheMapFishingShipMark";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MarkInfo", entityMapMarkInfoPb);
				MapLogger.Debug(author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			this.TryRecreateShipMark();
		}

		// Token: 0x0603930C RID: 234252 RVA: 0x00E7FE6C File Offset: 0x00E7E06C
		public void TryRecreateShipMark()
		{
			if (this.GetMarkCountByType(EMarkType.FishingShip) > 0)
			{
				return;
			}
			foreach (MarkDefine.FishingShipMarkCacheInfo fishingShipMarkCacheInfo in this.CacheEntityMapMarkInfo)
			{
				FishingShipMarkCreateInfo info = new FishingShipMarkCreateInfo(new DynamicMarkCreateParams
				{
					TrackTarget = global::Vector.Create(fishingShipMarkCacheInfo.PositionX, fishingShipMarkCacheInfo.PositionY, fishingShipMarkCacheInfo.PositionZ),
					MarkConfigId = 8,
					MarkType = EMarkType.FishingShip,
					TrackSource = new ETrackSource?(ETrackSource.MapMark),
					EntityConfigId = new int?(fishingShipMarkCacheInfo.TemplateId),
					MapAndDungeonInfo = new MapAndDungeonInfo
					{
						DungeonId = new int?(fishingShipMarkCacheInfo.InstanceId)
					}
				});
				this.CreateMapMark(info);
			}
		}

		// Token: 0x0603930D RID: 234253 RVA: 0x00E7FF48 File Offset: 0x00E7E148
		public void RemoveFishingShipMarkAndCache()
		{
			this.CacheEntityMapMarkInfo.Clear();
			this.RemoveMapMarkByType(EMarkType.FishingShip);
		}

		// Token: 0x0603930E RID: 234254 RVA: 0x00E7FF60 File Offset: 0x00E7E160
		public void SyncLocalShipLocationToCacheInfo()
		{
			Dictionary<int, DynamicMarkCreateInfo> markByType = this.GetMarkByType(EMarkType.FishingShip);
			if (markByType != null)
			{
				using (Dictionary<int, DynamicMarkCreateInfo>.ValueCollection.Enumerator enumerator = markByType.Values.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						DynamicMarkCreateInfo markInfo = enumerator.Current;
						List<MarkDefine.FishingShipMarkCacheInfo> list = this.CacheEntityMapMarkInfo.Where(delegate(MarkDefine.FishingShipMarkCacheInfo value)
						{
							int templateId = value.TemplateId;
							int? num = markInfo.EntityConfigId;
							if (templateId == num.GetValueOrDefault() & num != null)
							{
								int instanceId = value.InstanceId;
								num = markInfo.InstanceDungeonId;
								return instanceId == num.GetValueOrDefault() & num != null;
							}
							return false;
						}).ToList<MarkDefine.FishingShipMarkCacheInfo>();
						global::Vector trackPositionByTrackTargetConfig = MapUtil.GetTrackPositionByTrackTargetConfig(markInfo.TrackTarget, markInfo.MapId, null);
						if (list.Count > 0)
						{
							using (List<MarkDefine.FishingShipMarkCacheInfo>.Enumerator enumerator2 = list.GetEnumerator())
							{
								while (enumerator2.MoveNext())
								{
									MarkDefine.FishingShipMarkCacheInfo fishingShipMarkCacheInfo = enumerator2.Current;
									fishingShipMarkCacheInfo.PositionX = trackPositionByTrackTargetConfig.X;
									fishingShipMarkCacheInfo.PositionY = trackPositionByTrackTargetConfig.Y;
									fishingShipMarkCacheInfo.PositionZ = trackPositionByTrackTargetConfig.Z;
								}
								continue;
							}
						}
						this.CacheEntityMapMarkInfo.Add(new MarkDefine.FishingShipMarkCacheInfo
						{
							InstanceId = markInfo.InstanceDungeonId.GetValueOrDefault(),
							TemplateId = markInfo.EntityConfigId.GetValueOrDefault(),
							PositionX = trackPositionByTrackTargetConfig.X,
							PositionY = trackPositionByTrackTargetConfig.Y,
							PositionZ = trackPositionByTrackTargetConfig.Z
						});
					}
				}
			}
		}

		// Token: 0x0603930F RID: 234255 RVA: 0x00E800F0 File Offset: 0x00E7E2F0
		private bool IsNeedCheckSamePosition(DynamicMarkCreateInfo markInfo)
		{
			return markInfo.MarkType != EMarkType.Quest && markInfo.MarkType != EMarkType.TemporaryTeleport && markInfo.MarkType != EMarkType.TreasureBoxDetector && markInfo.MarkType != EMarkType.Custom;
		}

		// Token: 0x06039310 RID: 234256 RVA: 0x00E80120 File Offset: 0x00E7E320
		public void ResetDynamicMarkData()
		{
			Dictionary<int, IMarkShowState> markExtraShowStateReference = this.MarkExtraShowStateReference;
			if (markExtraShowStateReference != null)
			{
				markExtraShowStateReference.Clear();
			}
			Dictionary<int, bool> serverUnlockedMarksMap = this.ServerUnlockedMarksMap;
			if (serverUnlockedMarksMap != null)
			{
				serverUnlockedMarksMap.Clear();
			}
			Dictionary<int, DynamicMarkCreateInfo> valueOrDefault = this.DynamicMarks.GetValueOrDefault(EMarkType.Quest);
			Dictionary<EMarkType, Dictionary<int, DynamicMarkCreateInfo>> dynamicMarks = this.DynamicMarks;
			Dictionary<int, DynamicMarkCreateInfo> markCreateInfoList = (dynamicMarks != null) ? dynamicMarks.GetValueOrDefault(EMarkType.Entity) : null;
			Dictionary<EMarkType, Dictionary<int, DynamicMarkCreateInfo>> exploreEntityDynamicMarks = this.GetExploreEntityDynamicMarks();
			Dictionary<EMarkType, Dictionary<int, DynamicMarkCreateInfo>> dynamicMarks2 = this.DynamicMarks;
			if (dynamicMarks2 != null)
			{
				dynamicMarks2.Clear();
			}
			Dictionary<int, DynamicMarkCreateInfo> dynamicMarksSearchMap = this.DynamicMarksSearchMap;
			if (dynamicMarksSearchMap != null)
			{
				dynamicMarksSearchMap.Clear();
			}
			this.AddDynamicMarkDataList(EMarkType.Quest, valueOrDefault);
			this.AddDynamicMarkDataList(EMarkType.Entity, markCreateInfoList);
			this.AddExploreEntityDynamicMarks(exploreEntityDynamicMarks);
		}

		// Token: 0x06039311 RID: 234257 RVA: 0x00E801B4 File Offset: 0x00E7E3B4
		private void AddDynamicMarkDataList(EMarkType markType, [Nullable(new byte[]
		{
			2,
			1
		})] Dictionary<int, DynamicMarkCreateInfo> markCreateInfoList)
		{
			if (markCreateInfoList != null)
			{
				this.DynamicMarks[markType] = markCreateInfoList;
				foreach (DynamicMarkCreateInfo dynamicMarkCreateInfo in markCreateInfoList.Values)
				{
					this.DynamicMarksSearchMap[dynamicMarkCreateInfo.MarkId.Value] = dynamicMarkCreateInfo;
				}
			}
		}

		// Token: 0x06039312 RID: 234258 RVA: 0x00E8022C File Offset: 0x00E7E42C
		private void AddExploreEntityDynamicMarks(Dictionary<EMarkType, Dictionary<int, DynamicMarkCreateInfo>> exploreEntityDynamicMarks)
		{
			foreach (KeyValuePair<EMarkType, Dictionary<int, DynamicMarkCreateInfo>> keyValuePair in exploreEntityDynamicMarks)
			{
				this.DynamicMarks[keyValuePair.Key] = keyValuePair.Value;
				foreach (DynamicMarkCreateInfo dynamicMarkCreateInfo in keyValuePair.Value.Values)
				{
					this.DynamicMarksSearchMap[dynamicMarkCreateInfo.MarkId.Value] = dynamicMarkCreateInfo;
				}
			}
		}

		// Token: 0x06039313 RID: 234259 RVA: 0x00E802E8 File Offset: 0x00E7E4E8
		private Dictionary<EMarkType, Dictionary<int, DynamicMarkCreateInfo>> GetExploreEntityDynamicMarks()
		{
			Dictionary<EMarkType, Dictionary<int, DynamicMarkCreateInfo>> dictionary = new Dictionary<EMarkType, Dictionary<int, DynamicMarkCreateInfo>>();
			Dictionary<int, DynamicMarkCreateInfo> valueOrDefault = this.DynamicMarks.GetValueOrDefault(EMarkType.SightSpot);
			if (valueOrDefault != null)
			{
				dictionary[EMarkType.SightSpot] = valueOrDefault;
			}
			valueOrDefault = this.DynamicMarks.GetValueOrDefault(EMarkType.FlyingHunter);
			if (valueOrDefault != null)
			{
				dictionary[EMarkType.FlyingHunter] = valueOrDefault;
			}
			valueOrDefault = this.DynamicMarks.GetValueOrDefault(EMarkType.Frostbite);
			if (valueOrDefault != null)
			{
				dictionary[EMarkType.Frostbite] = valueOrDefault;
			}
			return dictionary;
		}

		// Token: 0x06039314 RID: 234260 RVA: 0x00E8034C File Offset: 0x00E7E54C
		private void CreateDynamicMark(DynamicMarkCreateInfo info)
		{
			if (this.DynamicMarks == null)
			{
				return;
			}
			ELogAuthor author = ELogAuthor.LYX;
			string message = "标记系统->CreateDynamicMark";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("DynamicMarkCreateInfo", info);
			MapLogger.Debug(author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Dictionary<int, DynamicMarkCreateInfo> dictionary;
			if (!this.DynamicMarks.TryGetValue(info.MarkType, out dictionary))
			{
				dictionary = new Dictionary<int, DynamicMarkCreateInfo>();
				this.DynamicMarks[info.MarkType] = dictionary;
			}
			DynamicMarkCreateInfo dynamicMarkCreateInfo = null;
			foreach (DynamicMarkCreateInfo dynamicMarkCreateInfo2 in dictionary.Values)
			{
				if (this.IsNeedCheckSamePosition(info))
				{
					TTrackTarget_Vector ttrackTarget_Vector = dynamicMarkCreateInfo2.TrackTarget as TTrackTarget_Vector;
					if (ttrackTarget_Vector != null)
					{
						TTrackTarget_Vector ttrackTarget_Vector2 = info.TrackTarget as TTrackTarget_Vector;
						if (ttrackTarget_Vector2 != null && ttrackTarget_Vector == ttrackTarget_Vector2)
						{
							dynamicMarkCreateInfo = dynamicMarkCreateInfo2;
						}
					}
				}
				int? markId = dynamicMarkCreateInfo2.MarkId;
				int? markId2 = info.MarkId;
				if (markId.GetValueOrDefault() == markId2.GetValueOrDefault() & markId != null == (markId2 != null))
				{
					dynamicMarkCreateInfo = dynamicMarkCreateInfo2;
				}
			}
			if (dynamicMarkCreateInfo != null)
			{
				ELogAuthor author2 = ELogAuthor.LYX;
				string message2 = "标记系统->existMarkInfo";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("DynamicMarkCreateInfo", info);
				MapLogger.Debug(author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				this.RemoveMapMark(new EMarkType?(dynamicMarkCreateInfo.MarkType), dynamicMarkCreateInfo.MarkId);
			}
			dictionary[info.MarkId.Value] = info;
			this.DynamicMarksSearchMap[info.MarkId.Value] = info;
			Singleton<EventSystem>.Instance.Emit<DynamicMarkCreateInfo>(EEventName.CreateMapMark, info);
		}

		// Token: 0x06039315 RID: 234261 RVA: 0x00E804DC File Offset: 0x00E7E6DC
		public void SetTrackMark(EMarkType markType, int markId, bool value)
		{
			Singleton<EventSystem>.Instance.Emit<EMarkType, int, bool>(EEventName.TrackMapMark, markType, markId, value);
			if (value)
			{
				return;
			}
			if (this.DynamicMarks == null)
			{
				return;
			}
			Dictionary<int, DynamicMarkCreateInfo> dictionary;
			if (!this.DynamicMarks.TryGetValue(markType, out dictionary))
			{
				return;
			}
			DynamicMarkCreateInfo dynamicMarkCreateInfo;
			if (dictionary.TryGetValue(markId, out dynamicMarkCreateInfo) && dynamicMarkCreateInfo != null && dynamicMarkCreateInfo.DestroyOnUnTrack)
			{
				this.RemoveMapMark(new EMarkType?(markType), new int?(markId));
			}
		}

		// Token: 0x06039316 RID: 234262 RVA: 0x00E80544 File Offset: 0x00E7E744
		public bool IsMarkIdExist(EMarkType type, int markId)
		{
			if (this.DynamicMarks == null || type == EMarkType.None || markId == 0)
			{
				return false;
			}
			Dictionary<int, DynamicMarkCreateInfo> dictionary;
			if (this.DynamicMarks.TryGetValue(type, out dictionary))
			{
				return dictionary.ContainsKey(markId);
			}
			OneOf<MapMark, DynamicMapMark>? oneOf = ConfigBase<MapConfig>.Instance.SearchMarkConfig(markId);
			if (oneOf != null)
			{
				if (oneOf.Value.IsT1)
				{
					return oneOf.Value.AsT1.ObjectType == (int)type;
				}
				if (oneOf.Value.IsT2)
				{
					return oneOf.Value.AsT2.ObjectType == (int)type;
				}
			}
			return false;
		}

		// Token: 0x06039317 RID: 234263 RVA: 0x00E805E8 File Offset: 0x00E7E7E8
		public EMarkType? GetMarkTypeByMarkId(int markId)
		{
			DynamicMarkCreateInfo dynamicMark = this.GetDynamicMark(markId);
			if (dynamicMark != null)
			{
				return new EMarkType?(dynamicMark.MarkType);
			}
			OneOf<MapMark, DynamicMapMark>? oneOf = ConfigBase<MapConfig>.Instance.SearchMarkConfig(markId);
			if (oneOf != null)
			{
				if (oneOf.Value.IsT1)
				{
					return new EMarkType?((EMarkType)oneOf.Value.AsT1.ObjectType);
				}
				if (oneOf.Value.IsT2)
				{
					return new EMarkType?((EMarkType)oneOf.Value.AsT2.ObjectType);
				}
			}
			return null;
		}

		// Token: 0x06039318 RID: 234264 RVA: 0x00E80688 File Offset: 0x00E7E888
		[NullableContext(0)]
		public ValueTuple<int, EMarkType>? GetSoundBoxDetectMark()
		{
			Dictionary<int, DynamicMarkCreateInfo> markByType = this.GetMarkByType(EMarkType.SoundBox);
			if (markByType != null && markByType.Count > 0)
			{
				DynamicMarkCreateInfo dynamicMarkCreateInfo = markByType.Values.First<DynamicMarkCreateInfo>();
				return new ValueTuple<int, EMarkType>?(new ValueTuple<int, EMarkType>(dynamicMarkCreateInfo.MarkId.Value, dynamicMarkCreateInfo.MarkType));
			}
			Dictionary<int, DynamicMarkCreateInfo> markByType2 = this.GetMarkByType(EMarkType.CalmingWindBell);
			if (markByType2 != null && markByType2.Count > 0)
			{
				DynamicMarkCreateInfo dynamicMarkCreateInfo2 = markByType2.Values.First<DynamicMarkCreateInfo>();
				return new ValueTuple<int, EMarkType>?(new ValueTuple<int, EMarkType>(dynamicMarkCreateInfo2.MarkId.Value, dynamicMarkCreateInfo2.MarkType));
			}
			return null;
		}

		// Token: 0x06039319 RID: 234265 RVA: 0x00E80724 File Offset: 0x00E7E924
		[NullableContext(0)]
		public ValueTuple<int, EMarkType>? GetSoundBoxDetectMarkCalc()
		{
			Dictionary<int, DynamicMarkCreateInfo> markByType = this.GetMarkByType(EMarkType.SoundBox);
			Dictionary<int, DynamicMarkCreateInfo> markByType2 = this.GetMarkByType(EMarkType.CalmingWindBell);
			if ((markByType == null || markByType.Count == 0) && (markByType2 == null || markByType2.Count == 0))
			{
				return null;
			}
			int currentWorldMapConfigId = this.CurrentWorldMapConfigId;
			List<DynamicMarkCreateInfo> list = new List<DynamicMarkCreateInfo>();
			if (markByType != null)
			{
				foreach (DynamicMarkCreateInfo dynamicMarkCreateInfo in markByType.Values)
				{
					if (dynamicMarkCreateInfo.MapId == currentWorldMapConfigId)
					{
						list.Add(dynamicMarkCreateInfo);
					}
				}
			}
			if (markByType2 != null)
			{
				foreach (DynamicMarkCreateInfo dynamicMarkCreateInfo2 in markByType2.Values)
				{
					if (dynamicMarkCreateInfo2.MapId == currentWorldMapConfigId)
					{
						list.Add(dynamicMarkCreateInfo2);
					}
				}
			}
			if (list.Count > 0)
			{
				DynamicMarkCreateInfo dynamicMarkCreateInfo3 = list[0];
				double num = double.MaxValue;
				global::Vector playerPosition = ModelBase<WorldMapModel>.Instance.GetPlayerPosition();
				foreach (DynamicMarkCreateInfo dynamicMarkCreateInfo4 in list)
				{
					global::Vector v = global::Vector.Create(((TTrackTarget_Vector)dynamicMarkCreateInfo4.TrackTarget).Value);
					double num2 = global::Vector.Dist(playerPosition, v);
					if (num2 < num)
					{
						num = num2;
						dynamicMarkCreateInfo3 = dynamicMarkCreateInfo4;
					}
				}
				return new ValueTuple<int, EMarkType>?(new ValueTuple<int, EMarkType>(dynamicMarkCreateInfo3.MarkId.Value, dynamicMarkCreateInfo3.MarkType));
			}
			return this.GetSoundBoxDetectMark();
		}

		// Token: 0x0603931A RID: 234266 RVA: 0x00E808D8 File Offset: 0x00E7EAD8
		public bool IsConfigMarkIdUnlock(int markId)
		{
			MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(markId);
			if (configMark == null)
			{
				return false;
			}
			if (!this.IsMarkIdExist((EMarkType)configMark.Value.ObjectType, markId))
			{
				return false;
			}
			bool flag = this.IsFogUnlock(configMark.Value);
			bool flag2 = this.IsConditionUnlock(configMark.Value);
			return flag && flag2;
		}

		// Token: 0x0603931B RID: 234267 RVA: 0x00E80934 File Offset: 0x00E7EB34
		private bool IsFogUnlock(MapMark markConfig)
		{
			return markConfig.FogShow == 1 || this.CheckFogUnlocked(markConfig.FogHide, null);
		}

		// Token: 0x0603931C RID: 234268 RVA: 0x00E80964 File Offset: 0x00E7EB64
		private bool IsConditionUnlock(MapMark markConfig)
		{
			int showCondition = markConfig.ShowCondition;
			int markId = markConfig.MarkId;
			if (showCondition < 0)
			{
				return this.GetMarkExtraShowState(markId).ShowFlag > MapMarkShowFlag.Hide;
			}
			return showCondition == 0 || this.IsMarkUnlockedByServer(markId);
		}

		// Token: 0x0603931D RID: 234269 RVA: 0x00E809A4 File Offset: 0x00E7EBA4
		public unsafe void RemoveMapMark(EMarkType? markType, int? markId)
		{
			if (this.DynamicMarks == null || markType == null || markId == null)
			{
				return;
			}
			Dictionary<int, DynamicMarkCreateInfo> dictionary;
			if (!this.DynamicMarks.TryGetValue(markType.Value, out dictionary) || dictionary == null)
			{
				return;
			}
			this.RemoveTrackMarkId(markId.Value);
			bool flag = dictionary.Remove(markId.Value);
			Dictionary<int, DynamicMarkCreateInfo> dynamicMarksSearchMap = this.DynamicMarksSearchMap;
			if (dynamicMarksSearchMap != null)
			{
				dynamicMarksSearchMap.Remove(markId.Value);
			}
			if (!flag)
			{
				return;
			}
			ELogAuthor author = ELogAuthor.LYX;
			string message = "标记系统->RemoveMapMark";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("markType", markType);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("markId", markId);
			MapLogger.Debug(author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			Singleton<EventSystem>.Instance.Emit<EMarkType, int>(EEventName.RemoveMapMark, markType.Value, markId.Value);
		}

		// Token: 0x0603931E RID: 234270 RVA: 0x00E80A90 File Offset: 0x00E7EC90
		public void RemoveMapMarkByType(EMarkType markType)
		{
			Dictionary<int, DynamicMarkCreateInfo> markByType = this.GetMarkByType(markType);
			if (markByType != null && markByType.Count > 0)
			{
				HashSet<int> hashSet = new HashSet<int>();
				foreach (DynamicMarkCreateInfo dynamicMarkCreateInfo in markByType.Values)
				{
					if (dynamicMarkCreateInfo.MarkId != null)
					{
						hashSet.Add(dynamicMarkCreateInfo.MarkId.Value);
					}
				}
				foreach (int value in hashSet)
				{
					this.RemoveMapMark(new EMarkType?(markType), new int?(value));
				}
			}
		}

		// Token: 0x0603931F RID: 234271 RVA: 0x00E80B70 File Offset: 0x00E7ED70
		public void RemoveMapMarksByConfigId(EMarkType? markType, int? markConfigId)
		{
			if (this.DynamicMarks == null || markType == null || markConfigId == null)
			{
				return;
			}
			Dictionary<int, DynamicMarkCreateInfo> dictionary;
			if (!this.DynamicMarks.TryGetValue(markType.Value, out dictionary) || dictionary == null)
			{
				return;
			}
			List<int> list = new List<int>();
			foreach (KeyValuePair<int, DynamicMarkCreateInfo> keyValuePair in dictionary)
			{
				EMarkType markType2 = keyValuePair.Value.MarkType;
				EMarkType? emarkType = markType;
				if (markType2 == emarkType.GetValueOrDefault() & emarkType != null)
				{
					list.Add(keyValuePair.Key);
				}
			}
			foreach (int value in list)
			{
				this.RemoveMapMark(markType, new int?(value));
			}
		}

		// Token: 0x06039320 RID: 234272 RVA: 0x00E80C68 File Offset: 0x00E7EE68
		public void RemoveDynamicMapMark(int? markId)
		{
			if (markId != null)
			{
				Dictionary<int, DynamicMarkCreateInfo> dynamicMarksSearchMap = this.DynamicMarksSearchMap;
				DynamicMarkCreateInfo dynamicMarkCreateInfo;
				if (dynamicMarksSearchMap != null && dynamicMarksSearchMap.TryGetValue(markId.Value, out dynamicMarkCreateInfo))
				{
					this.RemoveMapMark((dynamicMarkCreateInfo != null) ? new EMarkType?(dynamicMarkCreateInfo.MarkType) : null, (dynamicMarkCreateInfo != null) ? dynamicMarkCreateInfo.MarkId : null);
					return;
				}
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Map;
			ELogAuthor author = ELogAuthor.LYX;
			string message = "找不到mark id:";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("markId", markId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x06039321 RID: 234273 RVA: 0x00E80D00 File Offset: 0x00E7EF00
		public void UpdateCustomMarkInfo(int markId, global::Vector newVector)
		{
			if (this.DynamicMarks == null)
			{
				return;
			}
			Dictionary<int, DynamicMarkCreateInfo> dictionary;
			if (!this.DynamicMarks.TryGetValue(EMarkType.Custom, out dictionary))
			{
				Singleton<Log>.Instance.Error(ELogModule.Map, ELogAuthor.LYX, "找不到markId", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			DynamicMarkCreateInfo dynamicMarkCreateInfo;
			if (dictionary.TryGetValue(markId, out dynamicMarkCreateInfo))
			{
				dynamicMarkCreateInfo.TrackTarget = newVector;
			}
		}

		// Token: 0x06039322 RID: 234274 RVA: 0x00E80D5C File Offset: 0x00E7EF5C
		public void ReplaceCustomMarkIcon(int markId, int newConfigId)
		{
			if (this.DynamicMarks == null)
			{
				return;
			}
			Dictionary<int, DynamicMarkCreateInfo> dictionary;
			if (!this.DynamicMarks.TryGetValue(EMarkType.Custom, out dictionary))
			{
				return;
			}
			DynamicMarkCreateInfo dynamicMarkCreateInfo;
			if (!dictionary.TryGetValue(markId, out dynamicMarkCreateInfo))
			{
				return;
			}
			dynamicMarkCreateInfo.MarkConfigId = newConfigId;
			Singleton<EventSystem>.Instance.Emit<EMarkType, int, int>(EEventName.MapReplaceMarkResponse, EMarkType.Custom, markId, newConfigId);
		}

		// Token: 0x06039323 RID: 234275 RVA: 0x00E80DAC File Offset: 0x00E7EFAC
		public int SpawnDynamicMarkId()
		{
			int num = this.DynamicMarkId - 1;
			this.DynamicMarkId = num;
			return num;
		}

		// Token: 0x06039324 RID: 234276 RVA: 0x00E80DCC File Offset: 0x00E7EFCC
		public void UnlockTeleports(int[] ids, bool clearCache = false)
		{
			if (clearCache)
			{
				Dictionary<int, bool> unlockedTeleports = this.UnlockedTeleports;
				if (unlockedTeleports != null)
				{
					unlockedTeleports.Clear();
				}
			}
			if (ids.Length == 0)
			{
				return;
			}
			List<Teleporter> list = new List<Teleporter>();
			for (int i = 0; i < ids.Length; i++)
			{
				Teleporter? config = ConfigTeleporterById.GetConfig(ids[i], true);
				if (config != null)
				{
					list.Add(config.Value);
				}
			}
			foreach (Teleporter teleporter in list)
			{
				if (teleporter.TeleportEntityConfigId > 0)
				{
					ControllerBase<CreatureController>.Instance.ChangeLockTagByTeleportPbDataId(teleporter.TeleportEntityConfigId, GameplayTagDefine.EGameplayTagId["物体.物体阶段.已解锁"]);
				}
				this.UnlockedTeleports[teleporter.Id] = true;
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.UnlockTeleport, teleporter.Id);
			}
		}

		// Token: 0x06039325 RID: 234277 RVA: 0x00E80EB8 File Offset: 0x00E7F0B8
		public bool CheckTeleportUnlocked(int id)
		{
			MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(id);
			if (configMark != null && configMark.Value.InstanceDungeonId != 0)
			{
				return this.IsInstanceTeleportUnlock(id);
			}
			return this.UnlockedTeleports.GetValueOrDefault(id, false);
		}

		// Token: 0x06039326 RID: 234278 RVA: 0x00E80F00 File Offset: 0x00E7F100
		public bool IsTeleportLocked(int markId)
		{
			return this.GetMarkExtraShowState(markId).ShowFlag == MapMarkShowFlag.ShowDisable || !this.CheckTeleportUnlocked(markId);
		}

		// Token: 0x06039327 RID: 234279 RVA: 0x00E80F20 File Offset: 0x00E7F120
		public bool IsInstanceTeleportUnlock(int markId)
		{
			MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(markId);
			if (configMark == null || configMark.Value.InstanceDungeonId == 0)
			{
				return false;
			}
			if (!ConfigBase<MapConfig>.Instance.GetIsInstanceTeleporterExist(markId))
			{
				return false;
			}
			InstEntityTeleporter? instEntityTeleportConfigById = ConfigBase<MapConfig>.Instance.GetInstEntityTeleportConfigById(markId);
			if (instEntityTeleportConfigById == null)
			{
				return false;
			}
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(instEntityTeleportConfigById.Value.EntityConfigId);
			if (entityByPbDataId == null)
			{
				return false;
			}
			WorldEntity entity = entityByPbDataId.Entity;
			int? num;
			if (entity == null)
			{
				num = null;
			}
			else
			{
				SceneItemStateComponent component = entity.GetComponent<SceneItemStateComponent>();
				num = ((component != null) ? new int?(component.StateTagId) : null);
			}
			int? num2 = num;
			int num3 = GameplayTagDefine.EGameplayTagId["关卡.Common.状态.激活"];
			return num2.GetValueOrDefault() == num3 & num2 != null;
		}

		// Token: 0x06039328 RID: 234280 RVA: 0x00E80FF6 File Offset: 0x00E7F1F6
		[NullableContext(2)]
		public Dictionary<int, bool> GetAllUnlockedFogs()
		{
			return this.UnlockedFogs;
		}

		// Token: 0x06039329 RID: 234281 RVA: 0x00E80FFE File Offset: 0x00E7F1FE
		public bool GetFogIsUnlocked(int fogId)
		{
			Dictionary<int, bool> unlockedFogs = this.UnlockedFogs;
			return unlockedFogs != null && unlockedFogs.GetValueOrDefault(fogId);
		}

		// Token: 0x0603932A RID: 234282 RVA: 0x00E81012 File Offset: 0x00E7F212
		[NullableContext(2)]
		public Dictionary<int, bool> GetAllUnlockedAreas()
		{
			return this.UnlockedAreas;
		}

		// Token: 0x0603932B RID: 234283 RVA: 0x00E8101A File Offset: 0x00E7F21A
		public void AddUnlockedFogs(int fogId)
		{
			this.UnlockedFogs[fogId] = true;
			this.AddUnlockedAreaByFog(fogId);
			ModelBase<HonamiStoryModel>.Instance.CurrentUnlockFogId = fogId;
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.MapOpenFogChange, fogId);
		}

		// Token: 0x0603932C RID: 234284 RVA: 0x00E8104C File Offset: 0x00E7F24C
		public void FullUpdateUnlockedFogs(RepeatedField<int> unlockFogIds)
		{
			this.UnlockedFogs.Clear();
			this.UnlockedAreas.Clear();
			foreach (int num in unlockFogIds)
			{
				this.UnlockedFogs[num] = true;
				this.AddUnlockedAreaByFog(num);
			}
			Singleton<EventSystem>.Instance.Emit<IReadOnlyDictionary<int, bool>>(EEventName.MapOpenFogFullUpdate, this.UnlockedFogs);
		}

		// Token: 0x0603932D RID: 234285 RVA: 0x00E810D0 File Offset: 0x00E7F2D0
		private void AddUnlockedAreaByFog(int fogId)
		{
			MapFog? mapFogConfig = ConfigBase<WorldMapConfig>.Instance.GetMapFogConfig(fogId);
			if (mapFogConfig != null)
			{
				this.UnlockedAreas[mapFogConfig.Value.AreaId] = true;
			}
		}

		// Token: 0x0603932E RID: 234286 RVA: 0x00E8110D File Offset: 0x00E7F30D
		public bool CheckAreasUnlocked(int areaId, bool zeroAsUnlock = true)
		{
			if (areaId == 0 && zeroAsUnlock)
			{
				return true;
			}
			Dictionary<int, bool> unlockedAreas = this.UnlockedAreas;
			return unlockedAreas != null && unlockedAreas.GetValueOrDefault(areaId);
		}

		// Token: 0x0603932F RID: 234287 RVA: 0x00E8112C File Offset: 0x00E7F32C
		public bool CheckFogUnlocked(int fogId, int? dungeonId = null)
		{
			if (fogId == 0)
			{
				return true;
			}
			if (dungeonId != null && !ConfigBase<WorldMapConfig>.Instance.IsMapInWorld(dungeonId.Value))
			{
				InstanceDungeon? instanceDungeon;
				return ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(dungeonId.Value) != null && instanceDungeon.GetValueOrDefault().IsFogFullUnlock;
			}
			Dictionary<int, bool> unlockedFogs = this.UnlockedFogs;
			return unlockedFogs != null && unlockedFogs.GetValueOrDefault(fogId);
		}

		// Token: 0x06039330 RID: 234288 RVA: 0x00E8119C File Offset: 0x00E7F39C
		public bool IsMarkFogUnlock(int markId)
		{
			MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(markId);
			if (configMark == null)
			{
				return false;
			}
			MapMark value = configMark.Value;
			return value.FogShow == 1 || this.CheckFogUnlocked(value.FogHide, new int?(value.RelativeDungeonId));
		}

		// Token: 0x06039331 RID: 234289 RVA: 0x00E811ED File Offset: 0x00E7F3ED
		public void SetUnlockMultiMapIds(List<int> ids)
		{
			this.UnlockMultiMapIds = ids;
			Singleton<EventSystem>.Instance.Emit(EEventName.MultiMapUnlockChanged);
		}

		// Token: 0x06039332 RID: 234290 RVA: 0x00E81206 File Offset: 0x00E7F406
		public void AddUnlockMultiMapIds(List<int> ids)
		{
			this.UnlockMultiMapIds = this.UnlockMultiMapIds.Union(ids).ToList<int>();
			Singleton<EventSystem>.Instance.Emit(EEventName.MultiMapUnlockChanged);
		}

		// Token: 0x06039333 RID: 234291 RVA: 0x00E8122F File Offset: 0x00E7F42F
		public void SetUnlockMapBlockIds(List<int> ids)
		{
			this.UnlockMapBlockIds = ids;
			Singleton<EventSystem>.Instance.Emit(EEventName.MiniMapForceUpdate);
		}

		// Token: 0x06039334 RID: 234292 RVA: 0x00E81248 File Offset: 0x00E7F448
		public void AddUnlockMapBlockIds(List<int> ids)
		{
			this.UnlockMapBlockIds = this.UnlockMapBlockIds.Union(ids).ToList<int>();
			Singleton<EventSystem>.Instance.Emit(EEventName.MiniMapForceUpdate);
		}

		// Token: 0x06039335 RID: 234293 RVA: 0x00E81271 File Offset: 0x00E7F471
		public bool CheckUnlockMultiMapIds(int id)
		{
			List<int> unlockMultiMapIds = this.UnlockMultiMapIds;
			return unlockMultiMapIds != null && unlockMultiMapIds.Contains(id);
		}

		// Token: 0x06039336 RID: 234294 RVA: 0x00E81288 File Offset: 0x00E7F488
		public int CheckUnlockMapBlockIds(string block, EMapGravityDirection gravity, int mapId)
		{
			int result = 0;
			List<BlockSwitch> list = new List<BlockSwitch>();
			foreach (int id in this.UnlockMapBlockIds)
			{
				BlockSwitch? unlockMapTileConfigById = ConfigBase<MapConfig>.Instance.GetUnlockMapTileConfigById(id);
				if (unlockMapTileConfigById != null && unlockMapTileConfigById.Value.Block == block && unlockMapTileConfigById.Value.GravityFlip == (int)gravity && unlockMapTileConfigById.Value.MapConfigId == mapId)
				{
					list.Add(unlockMapTileConfigById.Value);
				}
			}
			if (list.Count > 0)
			{
				list.Sort((BlockSwitch a, BlockSwitch b) => b.Priority.CompareTo(a.Priority));
				result = list[0].Id;
			}
			return result;
		}

		// Token: 0x06039337 RID: 234295 RVA: 0x00E81380 File Offset: 0x00E7F580
		public int CheckIsInMultiMapWithAreaId(int areaId)
		{
			int result = 0;
			foreach (MultiMap multiMap in ConfigBase<MapConfig>.Instance.GetAllSubMapConfig())
			{
				if (multiMap.GetAreaBytes().Contains(areaId))
				{
					result = multiMap.Id;
					break;
				}
			}
			return result;
		}

		// Token: 0x06039338 RID: 234296 RVA: 0x00E813EC File Offset: 0x00E7F5EC
		public void AddEntityIdToPendingList(int entityId, int markId)
		{
			this.PendingAddEntityList[entityId] = markId;
		}

		// Token: 0x06039339 RID: 234297 RVA: 0x00E813FB File Offset: 0x00E7F5FB
		public void RemoveEntityIdToPendingList(int entityId)
		{
			this.PendingAddEntityList.Remove(entityId);
		}

		// Token: 0x0603933A RID: 234298 RVA: 0x00E8140A File Offset: 0x00E7F60A
		[NullableContext(2)]
		public Dictionary<int, int> GetEntityPendingList()
		{
			return this.PendingAddEntityList;
		}

		// Token: 0x0603933B RID: 234299 RVA: 0x00E81414 File Offset: 0x00E7F614
		public bool IsInMapPolygon(global::Vector playerPosition)
		{
			if (!this.CurrentInWorld)
			{
				return true;
			}
			if (this.LastSafeLocation.IsNearlyZero(9.999999747378752E-05))
			{
				this.LastSafeLocation.DeepCopy(playerPosition);
			}
			InstanceDungeon? instanceDungeon = ModelBase<GameModeModel>.Instance.InstanceDungeon;
			int mapId = (instanceDungeon != null) ? instanceDungeon.GetValueOrDefault().MapConfigId : 0;
			instanceDungeon = ModelBase<GameModeModel>.Instance.InstanceDungeon;
			int dungeonId = (instanceDungeon != null) ? instanceDungeon.GetValueOrDefault().Id : 0;
			bool flag = ControllerBase<UnopenedAreaController>.Instance.OnCheckUnopenedArea(playerPosition, mapId, dungeonId);
			if (flag)
			{
				this.LastSafeLocation.DeepCopy(playerPosition);
			}
			return flag;
		}

		// Token: 0x0603933C RID: 234300 RVA: 0x00E814B7 File Offset: 0x00E7F6B7
		public global::Vector GetLastSafeLocation()
		{
			return this.LastSafeLocation;
		}

		// Token: 0x0603933D RID: 234301 RVA: 0x00E814BF File Offset: 0x00E7F6BF
		public bool IsInUnopenedAreaPullback()
		{
			return ModelBase<GameModeModel>.Instance.WorldDone && !ModelBase<GameModeModel>.Instance.IsTeleport && this.CurrentInWorld && ControllerBase<UnopenedAreaController>.Instance.CheckInPullback();
		}

		// Token: 0x0603933E RID: 234302 RVA: 0x00E814F1 File Offset: 0x00E7F6F1
		public bool SetMarkExtraShowState(int markId, bool needFocus, MapMarkShowFlag showFlag)
		{
			this.MarkExtraShowStateReference[markId] = new MarkShowState
			{
				Id = markId,
				NeedFocus = needFocus,
				ShowFlag = showFlag
			};
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnMarkItemShowStateChange, markId);
			return needFocus;
		}

		// Token: 0x0603933F RID: 234303 RVA: 0x00E8152C File Offset: 0x00E7F72C
		public IMarkShowState GetMarkExtraShowState(int markId)
		{
			Dictionary<int, IMarkShowState> markExtraShowStateReference = this.MarkExtraShowStateReference;
			IMarkShowState markShowState = (markExtraShowStateReference != null) ? markExtraShowStateReference.GetValueOrDefault(markId) : null;
			if (markShowState == null)
			{
				markShowState = new MarkShowState
				{
					Id = markId,
					NeedFocus = false,
					ShowFlag = MapMarkShowFlag.Hide
				};
			}
			EMarkType? markTypeByMarkId = this.GetMarkTypeByMarkId(markId);
			if (markTypeByMarkId != null && this.IsMarkForbidGravityTeleport(markId, markTypeByMarkId.Value))
			{
				markShowState.ShowFlag = MapMarkShowFlag.ShowDisable;
			}
			return markShowState;
		}

		// Token: 0x06039340 RID: 234304 RVA: 0x00E81594 File Offset: 0x00E7F794
		public void UpdateCompleteMarks(int[] markIdList)
		{
			this.CompleteMarks.Clear();
			foreach (int item in markIdList)
			{
				this.CompleteMarks.Add(item);
			}
		}

		// Token: 0x06039341 RID: 234305 RVA: 0x00E815D0 File Offset: 0x00E7F7D0
		public void SetCompleteMarkState(int[] markIdList)
		{
			foreach (int item in markIdList)
			{
				this.CompleteMarks.Add(item);
			}
		}

		// Token: 0x06039342 RID: 234306 RVA: 0x00E815FE File Offset: 0x00E7F7FE
		public bool IsCompleteMark(int markId)
		{
			return this.CompleteMarks.Contains(markId);
		}

		// Token: 0x06039343 RID: 234307 RVA: 0x00E8160C File Offset: 0x00E7F80C
		public bool IsMarkForbidGravityTeleport(int markId, EMarkType markType)
		{
			return ModelBase<OnlineModel>.Instance.GetIsTeamModel() && this.GetMarkMapGravity(markId, markType) == EMapGravityDirection.Up && ModelBase<WorldMapModel>.Instance.IsGravityMap(this.GetMarkMapConfigId(markId, markType)) && this.MapMarkConfigIsCanTeleport(markId);
		}

		// Token: 0x06039344 RID: 234308 RVA: 0x00E81648 File Offset: 0x00E7F848
		public bool MapMarkConfigIsCanTeleport(int markId)
		{
			MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(markId);
			if (configMark == null)
			{
				return false;
			}
			MapMark value = configMark.Value;
			return value.ObjectType == 6 || value.ObjectType == 5 || value.EnableQuickTransfer == 1;
		}

		// Token: 0x06039345 RID: 234309 RVA: 0x00E81694 File Offset: 0x00E7F894
		public bool MapMarkIsCanTeleport(int markId)
		{
			return this.MapMarkConfigIsCanTeleport(markId) && !this.IsTeleportLocked(markId);
		}

		// Token: 0x06039346 RID: 234310 RVA: 0x00E816AC File Offset: 0x00E7F8AC
		public MapBorder? GetCurMapBorderConfig(int mapId, int instanceDungeonId, EMapType mapType, EMapGravityDirection gravity)
		{
			MapBorder? curMapBorderByFilterFunc = this.GetCurMapBorderByFilterFunc(delegate(MapBorder config)
			{
				bool flag = config.InstanceDungeonId == instanceDungeonId && config.GravityFlip == (int)gravity;
				if (config.InstanceDungeonIdMapType != 0)
				{
					return flag && config.InstanceDungeonIdMapType == (int)mapType;
				}
				return flag;
			});
			if (curMapBorderByFilterFunc != null)
			{
				return new MapBorder?(curMapBorderByFilterFunc.Value);
			}
			curMapBorderByFilterFunc = this.GetCurMapBorderByFilterFunc((MapBorder config) => config.MapId == mapId && config.GravityFlip == (int)gravity && config.InstanceDungeonId == 0);
			MapBorder? result = curMapBorderByFilterFunc;
			if (result == null)
			{
				return ConfigBase<MapConfig>.Instance.GetMapBorderConfig(1, mapId);
			}
			return result;
		}

		// Token: 0x06039347 RID: 234311 RVA: 0x00E81738 File Offset: 0x00E7F938
		public MapBorder? GetCurMapBorderByFilterFunc(Func<MapBorder, bool> filterFunc)
		{
			MapBorder? result = null;
			IReadOnlyList<MapBorder> mapBorderConfigList = ConfigBase<MapConfig>.Instance.GetMapBorderConfigList();
			if (mapBorderConfigList != null)
			{
				foreach (MapBorder mapBorder in mapBorderConfigList)
				{
					int conditionId = mapBorder.ConditionId;
					if (filterFunc(mapBorder))
					{
						bool flag = conditionId == 0 || ControllerBase<LevelGeneralController>.Instance.CheckCondition(conditionId.ToString(), null, false, Array.Empty<object>());
						if (!flag)
						{
							break;
						}
						result = new MapBorder?(mapBorder);
					}
				}
			}
			return result;
		}

		// Token: 0x06039348 RID: 234312 RVA: 0x00E817D0 File Offset: 0x00E7F9D0
		public void ForceSetMarkVisible(EMarkType markType, int markId, bool visible)
		{
			Dictionary<int, bool> dictionary;
			if (!this.MarkVisibleStateRecord.TryGetValue((int)markType, out dictionary))
			{
				dictionary = new Dictionary<int, bool>();
				this.MarkVisibleStateRecord[(int)markType] = dictionary;
			}
			dictionary[markId] = visible;
		}

		// Token: 0x06039349 RID: 234313 RVA: 0x00E81808 File Offset: 0x00E7FA08
		public bool GetMarkForceVisible(EMarkType markType, int markId)
		{
			bool result = true;
			Dictionary<int, bool> dictionary;
			bool flag;
			if (this.MarkVisibleStateRecord.TryGetValue((int)markType, out dictionary) && dictionary.TryGetValue(markId, out flag))
			{
				result = flag;
			}
			return result;
		}

		// Token: 0x0603934A RID: 234314 RVA: 0x00E81838 File Offset: 0x00E7FA38
		public void AddOccupationInfo(OccupationPbInfo info)
		{
			NewOccupationConfig? newOccupationConfig = ConfigBase<QuestNewConfig>.Instance.GetNewOccupationConfig(info.ResourceName);
			if (newOccupationConfig == null || string.IsNullOrEmpty(newOccupationConfig.Value.OccupationData) || newOccupationConfig.Value.OccupationData == "Empty")
			{
				return;
			}
			OccupationData occupationData = Json.Parse<OccupationData>(newOccupationConfig.Value.OccupationData, null);
			if (occupationData == null)
			{
				return;
			}
			int[] levelPlayIds = occupationData.LevelPlayIds;
			foreach (int key in levelPlayIds)
			{
				this.SceneGamePlayRefQuestMap[key] = info.IncId;
			}
			this.OccupationResourceRefPlayMap[info.ResourceName] = levelPlayIds;
		}

		// Token: 0x0603934B RID: 234315 RVA: 0x00E818F4 File Offset: 0x00E7FAF4
		public void RemoveOccupationInfo(string resource)
		{
			Dictionary<string, int[]> occupationResourceRefPlayMap = this.OccupationResourceRefPlayMap;
			if (occupationResourceRefPlayMap == null || !occupationResourceRefPlayMap.ContainsKey(resource))
			{
				return;
			}
			int[] array = this.OccupationResourceRefPlayMap[resource];
			Dictionary<string, int[]> occupationResourceRefPlayMap2 = this.OccupationResourceRefPlayMap;
			if (occupationResourceRefPlayMap2 != null)
			{
				occupationResourceRefPlayMap2.Remove(resource);
			}
			foreach (int key in array)
			{
				Dictionary<int, long> sceneGamePlayRefQuestMap = this.SceneGamePlayRefQuestMap;
				if (sceneGamePlayRefQuestMap != null)
				{
					sceneGamePlayRefQuestMap.Remove(key);
				}
			}
		}

		// Token: 0x0603934C RID: 234316 RVA: 0x00E81960 File Offset: 0x00E7FB60
		public WorldLevelPlayOccupationResult IsLevelPlayOccupied(int levelPlayId)
		{
			Dictionary<int, long> sceneGamePlayRefQuestMap = this.SceneGamePlayRefQuestMap;
			long? questId = (sceneGamePlayRefQuestMap != null) ? sceneGamePlayRefQuestMap.GetValueOrNull(levelPlayId) : null;
			return new WorldLevelPlayOccupationResult
			{
				IsOccupied = (questId != null && questId.Value != 0L),
				QuestId = questId
			};
		}

		// Token: 0x0603934D RID: 234317 RVA: 0x00E819B2 File Offset: 0x00E7FBB2
		public bool IsMarkUnlockedByServer(int markId)
		{
			Dictionary<int, bool> serverUnlockedMarksMap = this.ServerUnlockedMarksMap;
			return serverUnlockedMarksMap != null && serverUnlockedMarksMap.GetValueOrDefault(markId);
		}

		// Token: 0x0603934E RID: 234318 RVA: 0x00E819C6 File Offset: 0x00E7FBC6
		public void SetMarkServerOpenState(int markId, bool state)
		{
			this.ServerUnlockedMarksMap[markId] = state;
		}

		// Token: 0x0603934F RID: 234319 RVA: 0x00E819D8 File Offset: 0x00E7FBD8
		public string GetMarkAreaText(int mapId, int entityId)
		{
			LevelEntityConfig? levelEntityConfig;
			int areaId = (ConfigBase<MapConfig>.Instance.GetEntityConfigByMapIdAndEntityId(mapId, entityId) != null) ? levelEntityConfig.GetValueOrDefault().AreaId : 0;
			return this.GetMarkAreaTextByAreaId(areaId);
		}

		// Token: 0x06039350 RID: 234320 RVA: 0x00E81A18 File Offset: 0x00E7FC18
		public string GetMarkAreaTextByAreaId(int areaId)
		{
			int parentAreaId = ConfigBase<AreaConfig>.Instance.GetParentAreaId(areaId);
			Aki.Config.Area? areaInfo = ConfigBase<AreaConfig>.Instance.GetAreaInfo(areaId);
			string text = (areaInfo != null) ? ConfigBase<AreaConfig>.Instance.GetAreaLocalName(areaInfo.Value.Title) : "";
			Aki.Config.Area? areaInfo2 = ConfigBase<AreaConfig>.Instance.GetAreaInfo(parentAreaId);
			string value = (areaInfo2 != null) ? ConfigBase<AreaConfig>.Instance.GetAreaLocalName(areaInfo2.Value.Title) : "";
			string text2 = (areaInfo != null) ? ConfigBase<InfluenceConfig>.Instance.GetCountryTitle(areaInfo.Value.CountryId) : "";
			int num = (areaInfo2 != null) ? areaInfo2.GetValueOrDefault().Level : 0;
			if ((areaInfo2 != null && areaInfo2.GetValueOrDefault().Father == 0) || num <= 0)
			{
				return text2 + "-" + text;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
			defaultInterpolatedStringHandler.AppendFormatted(text2);
			defaultInterpolatedStringHandler.AppendLiteral("-");
			defaultInterpolatedStringHandler.AppendFormatted(value);
			defaultInterpolatedStringHandler.AppendLiteral("-");
			defaultInterpolatedStringHandler.AppendFormatted(text);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06039351 RID: 234321 RVA: 0x00E81B60 File Offset: 0x00E7FD60
		public void UpdateBoxSlotInfo(TreasureBoxSlotInfo treasureBoxSlotInfo)
		{
			this.TreasureBoxSlotRawDataMap[treasureBoxSlotInfo.MarkId] = treasureBoxSlotInfo;
		}

		// Token: 0x06039352 RID: 234322 RVA: 0x00E81B74 File Offset: 0x00E7FD74
		public void RemoveBoxSlotInfo(long slotId)
		{
			if (this.TreasureBoxSlotRawDataMap == null)
			{
				return;
			}
			foreach (TreasureBoxSlotInfo treasureBoxSlotInfo in this.TreasureBoxSlotRawDataMap.Values.ToList<TreasureBoxSlotInfo>())
			{
				if (treasureBoxSlotInfo.DetectionSlotId == slotId)
				{
					this.TreasureBoxSlotRawDataMap.Remove(treasureBoxSlotInfo.MarkId);
					break;
				}
			}
		}

		// Token: 0x06039353 RID: 234323 RVA: 0x00E81BF0 File Offset: 0x00E7FDF0
		public void FullUpdateBoxSlotInfo(RepeatedField<TreasureBoxSlotInfo> allTreasureBoxSlotInfo)
		{
			this.TreasureBoxSlotRawDataMap.Clear();
			foreach (TreasureBoxSlotInfo treasureBoxSlotInfo in allTreasureBoxSlotInfo)
			{
				this.UpdateBoxSlotInfo(treasureBoxSlotInfo);
			}
		}

		// Token: 0x06039354 RID: 234324 RVA: 0x00E81C44 File Offset: 0x00E7FE44
		[NullableContext(2)]
		public TreasureBoxSlotInfo GetBoxSlotInfoByMarkId(int markId)
		{
			if (this.TreasureBoxSlotRawDataMap == null)
			{
				return null;
			}
			return this.TreasureBoxSlotRawDataMap.Values.FirstOrDefault((TreasureBoxSlotInfo slotInfo) => slotInfo.MarkId == markId);
		}

		// Token: 0x06039355 RID: 234325 RVA: 0x00E81C84 File Offset: 0x00E7FE84
		public void UpdateTemporaryTeleportInfo(TemporaryTeleportInfo temporaryTeleportInfo)
		{
			this.TemporaryTeleportInfoRawDataMap[temporaryTeleportInfo.MarkId] = temporaryTeleportInfo;
			DynamicMarkCreateInfo dynamicMark = this.GetDynamicMark(temporaryTeleportInfo.MarkId);
			if (dynamicMark != null)
			{
				dynamicMark.TeleportId = new int?((int)temporaryTeleportInfo.TemporaryTeleportId);
				if (temporaryTeleportInfo.Area > 0)
				{
					dynamicMark.AreaId = new int?(temporaryTeleportInfo.Area);
				}
			}
		}

		// Token: 0x06039356 RID: 234326 RVA: 0x00E81CE0 File Offset: 0x00E7FEE0
		public void RemoveTemporaryTeleportInfo(int markId)
		{
			if (this.TemporaryTeleportInfoRawDataMap == null)
			{
				return;
			}
			foreach (TemporaryTeleportInfo temporaryTeleportInfo in this.TemporaryTeleportInfoRawDataMap.Values.ToList<TemporaryTeleportInfo>())
			{
				if (temporaryTeleportInfo.MarkId == markId)
				{
					this.TemporaryTeleportInfoRawDataMap.Remove(temporaryTeleportInfo.MarkId);
					break;
				}
			}
		}

		// Token: 0x06039357 RID: 234327 RVA: 0x00E81D5C File Offset: 0x00E7FF5C
		public void FullUpdateTemporaryTeleportInfo(RepeatedField<TemporaryTeleportInfo> allTemporaryTeleportInfo)
		{
			Dictionary<int, TemporaryTeleportInfo> temporaryTeleportInfoRawDataMap = this.TemporaryTeleportInfoRawDataMap;
			if (temporaryTeleportInfoRawDataMap != null)
			{
				temporaryTeleportInfoRawDataMap.Clear();
			}
			foreach (TemporaryTeleportInfo temporaryTeleportInfo in allTemporaryTeleportInfo)
			{
				this.UpdateTemporaryTeleportInfo(temporaryTeleportInfo);
			}
		}

		// Token: 0x06039358 RID: 234328 RVA: 0x00E81DB8 File Offset: 0x00E7FFB8
		public int GetDungeonMapConfigId(int dungeonId)
		{
			if (dungeonId == 0)
			{
				return dungeonId;
			}
			InstanceDungeon? dungeonConfig = ConfigBase<WorldMapConfig>.Instance.GetDungeonConfig(dungeonId);
			if (dungeonConfig == null)
			{
				return dungeonId;
			}
			return dungeonConfig.Value.MapConfigId;
		}

		// Token: 0x06039359 RID: 234329 RVA: 0x00E81DF0 File Offset: 0x00E7FFF0
		public int? GetDungeonLocateWorldMapId(int dungeonId)
		{
			if (dungeonId == 0)
			{
				return null;
			}
			InstanceDungeon? dungeonConfig = ConfigBase<WorldMapConfig>.Instance.GetDungeonConfig(dungeonId);
			if (dungeonConfig == null)
			{
				return null;
			}
			if (dungeonConfig.Value.InstSubType == 12)
			{
				InstanceDungeon? dungeonEntranceConfig = this.GetDungeonEntranceConfig(dungeonConfig.Value);
				if (dungeonEntranceConfig != null)
				{
					return new int?(dungeonEntranceConfig.Value.MapConfigId);
				}
			}
			return new int?(dungeonConfig.Value.MapConfigId);
		}

		// Token: 0x0603935A RID: 234330 RVA: 0x00E81E7C File Offset: 0x00E8007C
		[NullableContext(2)]
		public global::Vector GetDungeonLocateWorldMapLocation(int dungeonId)
		{
			if (dungeonId == 0)
			{
				return null;
			}
			InstanceDungeon? dungeonConfig = ConfigBase<WorldMapConfig>.Instance.GetDungeonConfig(dungeonId);
			if (dungeonConfig == null)
			{
				return null;
			}
			if (dungeonConfig.Value.InstSubType != 12)
			{
				return null;
			}
			InstanceDungeon? dungeonEntranceConfig = this.GetDungeonEntranceConfig(dungeonConfig.Value);
			if (dungeonEntranceConfig != null)
			{
				int entranceEntityId = dungeonConfig.Value.EntranceEntities(0).Value.EntranceEntityId;
				return ModelBase<WorldMapModel>.Instance.GetEntityPosition(entranceEntityId, dungeonEntranceConfig.Value.MapConfigId);
			}
			return null;
		}

		// Token: 0x0603935B RID: 234331 RVA: 0x00E81F10 File Offset: 0x00E80110
		[NullableContext(2)]
		public global::Vector GetDungeonExitLocation(int dungeonId)
		{
			if (dungeonId == 0)
			{
				return null;
			}
			InstanceDungeon? dungeonConfig = ConfigBase<WorldMapConfig>.Instance.GetDungeonConfig(dungeonId);
			if (dungeonConfig == null)
			{
				return null;
			}
			if (dungeonConfig.Value.InstSubType != 12)
			{
				return null;
			}
			int pbDataId = dungeonConfig.Value.ExitEntities(0);
			return ModelBase<WorldMapModel>.Instance.GetEntityPosition(pbDataId, dungeonConfig.Value.MapConfigId);
		}

		// Token: 0x0603935C RID: 234332 RVA: 0x00E81F7C File Offset: 0x00E8017C
		public unsafe InstanceDungeon? GetDungeonEntranceConfig(InstanceDungeon config)
		{
			if (config.EntranceEntitiesLength < 1)
			{
				object key = config.Id;
				ELogAuthor author = ELogAuthor.LYX;
				string message = "世界副本查找入口实体失败->实体列表为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("副本Id", config.Id);
				MapLogger.ErrorOnce(key, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			int dungeonId = config.EntranceEntities(0).Value.DungeonId;
			InstanceDungeon? dungeonConfig = ConfigBase<WorldMapConfig>.Instance.GetDungeonConfig(dungeonId);
			if (dungeonConfig == null)
			{
				object key2 = config.Id;
				ELogAuthor author2 = ELogAuthor.LYX;
				string message2 = "世界副本查找入口实体失败->入口副本配置为空";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("副本Id", config.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("entranceDungeonId", dungeonId);
				MapLogger.ErrorOnce(key2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			return dungeonConfig;
		}

		// Token: 0x0603935D RID: 234333 RVA: 0x00E82070 File Offset: 0x00E80270
		public int GetMarkMapConfigId(int markId, EMarkType markType)
		{
			DynamicMarkCreateInfo mark = this.GetMark(markType, markId);
			if (mark != null)
			{
				return mark.MapId;
			}
			OneOf<MapMark, DynamicMapMark>? oneOf = ConfigBase<MapConfig>.Instance.SearchMarkConfig(markId);
			if (oneOf != null && oneOf.GetValueOrDefault().IsT1)
			{
				return oneOf.Value.AsT1.MapId;
			}
			if (oneOf != null && oneOf.GetValueOrDefault().IsT2)
			{
				return oneOf.Value.AsT2.MapId;
			}
			return 8;
		}

		// Token: 0x0603935E RID: 234334 RVA: 0x00E82108 File Offset: 0x00E80308
		public EMapGravityDirection GetMarkMapGravity(int markId, EMarkType markType)
		{
			DynamicMarkCreateInfo mark = this.GetMark(markType, markId);
			if (mark != null)
			{
				return mark.MapGravity;
			}
			MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(markId);
			int? num = (configMark != null) ? new int?(configMark.GetValueOrDefault().GravityFlip) : null;
			if (num != null)
			{
				return (EMapGravityDirection)num.Value;
			}
			return EMapGravityDirection.Down;
		}

		// Token: 0x170091CD RID: 37325
		// (get) Token: 0x0603935F RID: 234335 RVA: 0x00E82170 File Offset: 0x00E80370
		public int CurrentMapConfigId
		{
			get
			{
				InstanceDungeon? instanceDungeon = ModelBase<GameModeModel>.Instance.InstanceDungeon;
				if (instanceDungeon == null || instanceDungeon.GetValueOrDefault().ViewMapId != 0)
				{
					return instanceDungeon.Value.ViewMapId;
				}
				if (instanceDungeon == null)
				{
					return 0;
				}
				return instanceDungeon.GetValueOrDefault().MapConfigId;
			}
		}

		// Token: 0x06039360 RID: 234336 RVA: 0x00E821D4 File Offset: 0x00E803D4
		public int GetDungeonWorldMapConfigId(int instanceDungeonId)
		{
			InstanceDungeon? dungeonConfig = ConfigBase<WorldMapConfig>.Instance.GetDungeonConfig(instanceDungeonId);
			if (dungeonConfig != null && dungeonConfig.Value.ViewMapId != 0)
			{
				return dungeonConfig.Value.ViewMapId;
			}
			int? dungeonLocateWorldMapId = this.GetDungeonLocateWorldMapId(instanceDungeonId);
			if (dungeonLocateWorldMapId != null)
			{
				return dungeonLocateWorldMapId.GetValueOrDefault();
			}
			if (dungeonConfig == null)
			{
				return 0;
			}
			return dungeonConfig.GetValueOrDefault().MapConfigId;
		}

		// Token: 0x170091CE RID: 37326
		// (get) Token: 0x06039361 RID: 234337 RVA: 0x00E8224C File Offset: 0x00E8044C
		public int CurrentWorldMapConfigId
		{
			get
			{
				InstanceDungeon? instanceDungeon = ModelBase<GameModeModel>.Instance.InstanceDungeon;
				if (instanceDungeon == null || instanceDungeon.GetValueOrDefault().ViewMapId != 0)
				{
					return instanceDungeon.Value.ViewMapId;
				}
				int? dungeonLocateWorldMapId = this.GetDungeonLocateWorldMapId(instanceDungeon.Value.Id);
				if (dungeonLocateWorldMapId != null)
				{
					return dungeonLocateWorldMapId.GetValueOrDefault();
				}
				if (instanceDungeon == null)
				{
					return 0;
				}
				return instanceDungeon.GetValueOrDefault().MapConfigId;
			}
		}

		// Token: 0x170091CF RID: 37327
		// (get) Token: 0x06039362 RID: 234338 RVA: 0x00E822D8 File Offset: 0x00E804D8
		public bool CurrentInWorld
		{
			get
			{
				int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
				return ConfigBase<WorldMapConfig>.Instance.IsDungeonInWorld(instanceId);
			}
		}

		// Token: 0x170091D0 RID: 37328
		// (get) Token: 0x06039363 RID: 234339 RVA: 0x00E822FC File Offset: 0x00E804FC
		public EMapGravityDirection CurrentPlayerGravity
		{
			get
			{
				TsBaseCharacter baseCharacter = Global.BaseCharacter;
				CharacterActorComponent characterActorComponent = (baseCharacter != null) ? baseCharacter.CharacterActorComponent : null;
				bool? flag;
				if (characterActorComponent == null)
				{
					flag = null;
				}
				else
				{
					BaseMoveComponent moveComp = characterActorComponent.MoveComp;
					flag = ((moveComp != null) ? new bool?(moveComp.IsStandardGravity) : null);
				}
				bool? flag2 = flag;
				if (!flag2.GetValueOrDefault())
				{
					return EMapGravityDirection.Up;
				}
				return EMapGravityDirection.Down;
			}
		}

		// Token: 0x170091D1 RID: 37329
		// (get) Token: 0x06039364 RID: 234340 RVA: 0x00E82354 File Offset: 0x00E80554
		[Nullable(2)]
		public global::Vector CurrentPlayerGravityDirection
		{
			[NullableContext(2)]
			get
			{
				TsBaseCharacter baseCharacter = Global.BaseCharacter;
				CharacterActorComponent characterActorComponent = (baseCharacter != null) ? baseCharacter.CharacterActorComponent : null;
				if (characterActorComponent == null)
				{
					return null;
				}
				BaseMoveComponent moveComp = characterActorComponent.MoveComp;
				if (moveComp == null)
				{
					return null;
				}
				return moveComp.GravityDirect;
			}
		}

		// Token: 0x170091D2 RID: 37330
		// (get) Token: 0x06039365 RID: 234341 RVA: 0x00E8237D File Offset: 0x00E8057D
		public bool IsPlayerInStandardGravity
		{
			get
			{
				return this.CurrentPlayerGravity == EMapGravityDirection.Down;
			}
		}

		// Token: 0x06039366 RID: 234342 RVA: 0x00E82388 File Offset: 0x00E80588
		public int GetInstanceIdByWorldMapId(int worldMapInstanceId)
		{
			if (worldMapInstanceId == this.CurrentWorldMapConfigId || !ConfigBase<WorldMapConfig>.Instance.IsMapInWorld(worldMapInstanceId))
			{
				return ModelBase<CreatureModel>.Instance.GetInstanceId();
			}
			return worldMapInstanceId;
		}

		// Token: 0x06039367 RID: 234343 RVA: 0x00E823AC File Offset: 0x00E805AC
		public void AddTrackMarkId(int markId)
		{
			this.RemoteTrackingMarkSet.Add(markId);
		}

		// Token: 0x06039368 RID: 234344 RVA: 0x00E823BB File Offset: 0x00E805BB
		public void RemoveTrackMarkId(int markId)
		{
			this.RemoteTrackingMarkSet.Remove(markId);
		}

		// Token: 0x06039369 RID: 234345 RVA: 0x00E823CA File Offset: 0x00E805CA
		public void ClearTrackMarkId()
		{
			this.RemoteTrackingMarkSet.Clear();
		}

		// Token: 0x0603936A RID: 234346 RVA: 0x00E823D7 File Offset: 0x00E805D7
		public bool IsMarkTracking(int markId)
		{
			return this.RemoteTrackingMarkSet.Contains(markId);
		}

		// Token: 0x0603936B RID: 234347 RVA: 0x00E823E8 File Offset: 0x00E805E8
		public void UpdateMarkHideInfo(SystemMarkHideInfoPb hideInfo)
		{
			string markHideInfoKey = this.GetMarkHideInfoKey(hideInfo.MapId, hideInfo.EntityConfigId);
			if (string.IsNullOrEmpty(hideInfo.HideInfo))
			{
				this.SystemMarkHideInfoMap.Remove(markHideInfoKey);
			}
			else
			{
				this.SystemMarkHideInfoMap[markHideInfoKey] = hideInfo;
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnMarkItemUpdateMarkHideInfo);
		}

		// Token: 0x0603936C RID: 234348 RVA: 0x00E82441 File Offset: 0x00E80641
		public void ClearMarkHideInfo()
		{
			this.SystemMarkHideInfoMap.Clear();
		}

		// Token: 0x0603936D RID: 234349 RVA: 0x00E82450 File Offset: 0x00E80650
		public string GetMarkHideInfoKey(int mapId, int entityId)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(mapId);
			defaultInterpolatedStringHandler.AppendLiteral("_");
			defaultInterpolatedStringHandler.AppendFormatted<int>(entityId);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x0603936E RID: 234350 RVA: 0x00E8248C File Offset: 0x00E8068C
		public bool IsMarkHideByServer(int mapId, int entityId)
		{
			string markHideInfoKey = this.GetMarkHideInfoKey(mapId, entityId);
			return this.SystemMarkHideInfoMap.ContainsKey(markHideInfoKey);
		}

		// Token: 0x0603936F RID: 234351 RVA: 0x00E824B0 File Offset: 0x00E806B0
		[NullableContext(2)]
		public string GetMarkHideReason(int mapId, int entityId)
		{
			string markHideInfoKey = this.GetMarkHideInfoKey(mapId, entityId);
			SystemMarkHideInfoPb systemMarkHideInfoPb;
			if (this.SystemMarkHideInfoMap.TryGetValue(markHideInfoKey, out systemMarkHideInfoPb) && systemMarkHideInfoPb != null && systemMarkHideInfoPb.HideInfo != null)
			{
				return this.ParseHideReason(systemMarkHideInfoPb.HideInfo);
			}
			return null;
		}

		// Token: 0x06039370 RID: 234352 RVA: 0x00E824F0 File Offset: 0x00E806F0
		[return: Nullable(2)]
		public string ParseHideReason(string hideInfo)
		{
			if (hideInfo.ToLower() == "d")
			{
				return ConfigBase<TextConfig>.Instance.GetMultiText("Mark_Occupied_Not_Refresh_Text", Array.Empty<string>());
			}
			string[] array = hideInfo.Split('_', StringSplitOptions.None);
			if (array.Length < 2)
			{
				return null;
			}
			string a = array[0].ToLower();
			int num = int.Parse(array[1]);
			if (a == "q")
			{
				string questName = ModelBase<QuestNewModel>.Instance.GetQuestName(num);
				return ConfigBase<TextConfig>.Instance.GetMultiText("Mark_Quest_Occupied_Text", new string[]
				{
					questName
				});
			}
			if (a == "l")
			{
				global::LevelPlayInfo levelPlayInfo = ModelBase<LevelPlayModel>.Instance.GetLevelPlayInfo(num);
				if (levelPlayInfo != null)
				{
					string multiText = ConfigBase<TextConfig>.Instance.GetMultiText(levelPlayInfo.NameKey, Array.Empty<string>());
					return ConfigBase<TextConfig>.Instance.GetMultiText("Mark_Play_Occupied_Text", new string[]
					{
						multiText
					});
				}
			}
			return null;
		}

		// Token: 0x06039371 RID: 234353 RVA: 0x00E825D0 File Offset: 0x00E807D0
		public void InitTeleportMarkQueryCache()
		{
			foreach (MapMark mapMark in ConfigBase<MapConfig>.Instance.GetConfigMarkMap().Values)
			{
				if (mapMark.ObjectType == 15 || mapMark.ObjectType == 5 || mapMark.ObjectType == 6 || mapMark.ObjectType == 10 || mapMark.ObjectType == 19 || mapMark.EnableQuickTransfer == 1)
				{
					global::Vector vector = global::Vector.Create();
					MapUtil.GetConfigPosition(mapMark.EntityConfigId, vector, mapMark.RelativeDungeonId);
					MapTeleportQueryInfo item = new MapTeleportQueryInfo
					{
						MarkId = mapMark.MarkId,
						MarkType = (EMarkType)mapMark.ObjectType,
						MapId = mapMark.MapId,
						InstanceDungeonId = mapMark.RelativeDungeonId,
						Gravity = (EMapGravityDirection)mapMark.GravityFlip,
						MultiMapId = mapMark.MultiMapFloorId,
						ConnectMultiMapIds = (mapMark.GetConnetMultiMapFloorIdArray() ?? Array.Empty<int>()),
						WorldPosition = vector
					};
					int key = MapUtil.ConvertWorldPositionToIndex(vector);
					HashSet<MapTeleportQueryInfo> hashSet;
					if (!this.MarkQueryInfoInGrid.TryGetValue(key, out hashSet))
					{
						HashSet<MapTeleportQueryInfo> value = new HashSet<MapTeleportQueryInfo>
						{
							item
						};
						this.MarkQueryInfoInGrid[key] = value;
					}
					else
					{
						hashSet.Add(item);
					}
				}
			}
		}

		// Token: 0x06039372 RID: 234354 RVA: 0x00E82748 File Offset: 0x00E80948
		public QueryNearestTeleporterResult QueryNearestTeleporter(int targetMarkId, EMarkType targetMarkType, global::Vector playerPosition)
		{
			MapModel.<>c__DisplayClass168_0 CS$<>8__locals1 = new MapModel.<>c__DisplayClass168_0();
			CS$<>8__locals1.targetMarkId = targetMarkId;
			CS$<>8__locals1.<>4__this = this;
			MapModel.<>c__DisplayClass168_0 CS$<>8__locals2 = CS$<>8__locals1;
			DynamicMarkCreateInfo mark = this.GetMark(targetMarkType, CS$<>8__locals1.targetMarkId);
			int? num = (mark != null) ? mark.InstanceDungeonId : null;
			int targetDungeonId;
			if (num == null)
			{
				MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(CS$<>8__locals1.targetMarkId);
				targetDungeonId = ((configMark != null) ? configMark.GetValueOrDefault().RelativeDungeonId : 0);
			}
			else
			{
				targetDungeonId = num.GetValueOrDefault();
			}
			CS$<>8__locals2.targetDungeonId = targetDungeonId;
			MapModel.<>c__DisplayClass168_0 CS$<>8__locals3 = CS$<>8__locals1;
			DynamicMarkCreateInfo mark2 = this.GetMark(targetMarkType, CS$<>8__locals1.targetMarkId);
			EMapGravityDirection targetGravity;
			if (mark2 == null)
			{
				MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(CS$<>8__locals1.targetMarkId);
				if (configMark != null)
				{
					int gravityFlip = configMark.GetValueOrDefault().GravityFlip;
				}
				targetGravity = ((EMapGravityDirection?)null).GetValueOrDefault();
			}
			else
			{
				targetGravity = mark2.MapGravity;
			}
			CS$<>8__locals3.targetGravity = targetGravity;
			return this.QueryNearestTeleporterInternal(CS$<>8__locals1.targetMarkId, targetMarkType, playerPosition, delegate(MapTeleportQueryInfo queryInfo)
			{
				if (CS$<>8__locals1.targetMarkId == queryInfo.MarkId)
				{
					return false;
				}
				MapMark? configMark2 = ConfigBase<MapConfig>.Instance.GetConfigMark(queryInfo.MarkId);
				if (CS$<>8__locals1.targetDungeonId != queryInfo.InstanceDungeonId)
				{
					return false;
				}
				bool flag = CS$<>8__locals1.<>4__this.IsTeleportLocked(queryInfo.MarkId);
				bool flag2 = CS$<>8__locals1.<>4__this.IsMarkFogUnlock(queryInfo.MarkId);
				if (flag || !flag2)
				{
					return false;
				}
				if ((queryInfo.MarkType == EMarkType.SceneGameplay || queryInfo.MarkType == EMarkType.FixedSceneGameplay) && configMark2 != null)
				{
					global::LevelPlayInfo levelPlayInfo = ModelBase<LevelPlayModel>.Instance.GetLevelPlayInfo(configMark2.Value.RelativeId);
					if (levelPlayInfo == null || levelPlayInfo.IsClose)
					{
						return false;
					}
					if (CS$<>8__locals1.<>4__this.IsLevelPlayOccupied(levelPlayInfo.Id).IsOccupied)
					{
						return false;
					}
				}
				return (queryInfo.MarkType == EMarkType.TemporaryTeleport || queryInfo.MarkType == EMarkType.BigTeleport || queryInfo.MarkType == EMarkType.SmallTeleport || queryInfo.MarkType == EMarkType.SceneGameplay || queryInfo.MarkType == EMarkType.FixedSceneGameplay) && (CS$<>8__locals1.targetGravity == EMapGravityDirection.All || queryInfo.Gravity == EMapGravityDirection.All || queryInfo.Gravity == CS$<>8__locals1.targetGravity);
			});
		}

		// Token: 0x06039373 RID: 234355 RVA: 0x00E82844 File Offset: 0x00E80A44
		private unsafe TTrackTarget GetMarkTrackTarget(int targetMarkId, EMarkType targetMarkType)
		{
			DynamicMarkCreateInfo mark = this.GetMark(targetMarkType, targetMarkId);
			TTrackTarget result = 0;
			if (mark == null)
			{
				MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(targetMarkId);
				if (configMark == null)
				{
					object key = targetMarkId;
					ELogAuthor author = ELogAuthor.LYX;
					string message = "查询标记追踪目标->目标的标记配置和数据都为空";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("trackTargetMarkId", targetMarkId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("targetMarkType", targetMarkType);
					MapLogger.ErrorOnce(key, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					return result;
				}
				result = ((configMark.Value.EntityConfigId > 0) ? new TTrackTarget_Int(configMark.Value.EntityConfigId) : new TTrackTarget_Vector(global::Vector.Create(configMark.Value.MarkVector)));
			}
			else
			{
				result = mark.TrackTarget;
			}
			return result;
		}

		// Token: 0x06039374 RID: 234356 RVA: 0x00E8292C File Offset: 0x00E80B2C
		private QueryNearestTeleporterResult QueryNearestTeleporterInternal(int targetMarkId, EMarkType targetMarkType, global::Vector playerPosition, [Nullable(new byte[]
		{
			2,
			1
		})] Func<MapTeleportQueryInfo, bool> filterFunction = null)
		{
			TTrackTarget markTrackTarget = this.GetMarkTrackTarget(targetMarkId, targetMarkType);
			if (markTrackTarget as TTrackTarget_Int == 0)
			{
				return new QueryNearestTeleporterResult
				{
					TargetMarkId = targetMarkId,
					TargetMarkType = targetMarkType,
					FailedReason = new EQueryNearestTeleporterFailedReason?(EQueryNearestTeleporterFailedReason.NotFound)
				};
			}
			int markMapConfigId = this.GetMarkMapConfigId(targetMarkId, targetMarkType);
			global::Vector trackPositionByTrackTargetConfig = MapUtil.GetTrackPositionByTrackTargetConfig(markTrackTarget, markMapConfigId, null);
			List<ValueTuple<MapTeleportQueryInfo, double>> list = this.MarkQueryInfoCache.Get(targetMarkId);
			if (list == null)
			{
				list = new List<ValueTuple<MapTeleportQueryInfo, double>>();
				int num = ConfigCommonParamById.GetIntConfig("QuickTransferRange").Value * 100;
				HashSet<int> queryNearestIndexSet = MapUtil.GetQueryNearestIndexSet(trackPositionByTrackTargetConfig, (float)num);
				float num2 = (float)(num * num);
				foreach (int key in queryNearestIndexSet)
				{
					HashSet<MapTeleportQueryInfo> hashSet;
					if (this.MarkQueryInfoInGrid.TryGetValue(key, out hashSet))
					{
						foreach (MapTeleportQueryInfo mapTeleportQueryInfo in hashSet)
						{
							double num3 = global::Vector.DistSquared(mapTeleportQueryInfo.WorldPosition, trackPositionByTrackTargetConfig);
							if (num3 <= (double)num2)
							{
								list.Add(new ValueTuple<MapTeleportQueryInfo, double>(mapTeleportQueryInfo, num3));
							}
						}
					}
				}
				this.MarkQueryInfoCache.Put(targetMarkId, list, 1);
				MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(targetMarkId);
				int targetMultiMapId = (configMark != null) ? MapModel.GetEffectiveMultiMapId(configMark.Value.MultiMapFloorId, configMark.Value.GetConnetMultiMapFloorIdArray() ?? Array.Empty<int>()) : 0;
				bool isLayered = targetMultiMapId != 0;
				float num4 = (float)(ConfigCommonParamById.GetIntConfig("SameLayerQuickTransferRange").GetValueOrDefault() * 100);
				double sameLayerRangeSquared = (double)(num4 * num4);
				list.Sort(delegate([Nullable(new byte[]
				{
					0,
					1
				})] ValueTuple<MapTeleportQueryInfo, double> a, [Nullable(new byte[]
				{
					0,
					1
				})] ValueTuple<MapTeleportQueryInfo, double> b)
				{
					if (isLayered)
					{
						int num7 = (a.Item2 <= sameLayerRangeSquared && MapModel.GetEffectiveMultiMapId(a.Item1.MultiMapId, a.Item1.ConnectMultiMapIds) == targetMultiMapId) ? 0 : 1;
						int num8 = (b.Item2 <= sameLayerRangeSquared && MapModel.GetEffectiveMultiMapId(b.Item1.MultiMapId, b.Item1.ConnectMultiMapIds) == targetMultiMapId) ? 0 : 1;
						if (num7 != num8)
						{
							return num7 - num8;
						}
					}
					return a.Item2.CompareTo(b.Item2);
				});
			}
			foreach (ValueTuple<MapTeleportQueryInfo, double> valueTuple in list)
			{
				MapTeleportQueryInfo item = valueTuple.Item1;
				if (filterFunction == null || filterFunction(item))
				{
					double num5 = global::Vector.DistSquared(playerPosition, trackPositionByTrackTargetConfig);
					double num6 = global::Vector.DistSquared(item.WorldPosition, trackPositionByTrackTargetConfig);
					if (num5 <= num6)
					{
						return new QueryNearestTeleporterResult
						{
							TargetMarkId = targetMarkId,
							TargetMarkType = targetMarkType,
							FailedReason = new EQueryNearestTeleporterFailedReason?(EQueryNearestTeleporterFailedReason.PlayerCloserToTarget)
						};
					}
					return new QueryNearestTeleporterResult
					{
						TargetMarkId = targetMarkId,
						TargetMarkType = targetMarkType,
						Info = item
					};
				}
			}
			return new QueryNearestTeleporterResult
			{
				TargetMarkId = targetMarkId,
				TargetMarkType = targetMarkType,
				FailedReason = new EQueryNearestTeleporterFailedReason?(EQueryNearestTeleporterFailedReason.NotFound)
			};
		}

		// Token: 0x06039375 RID: 234357 RVA: 0x00E82BEC File Offset: 0x00E80DEC
		private static int GetEffectiveMultiMapId(int multiMapId, int[] connectMultiMapIds)
		{
			if (multiMapId == 0 && connectMultiMapIds.Length != 0)
			{
				return connectMultiMapIds[0];
			}
			return multiMapId;
		}

		// Token: 0x06039376 RID: 234358 RVA: 0x00E82BFC File Offset: 0x00E80DFC
		public EMarkType? GetEntityIdToMarkType(int entityId)
		{
			Dictionary<int, EMarkType> entityIdToMarkType = this.EntityIdToMarkType;
			if (entityIdToMarkType == null)
			{
				return null;
			}
			return new EMarkType?(entityIdToMarkType.GetValueOrDefault(entityId));
		}

		// Token: 0x06039377 RID: 234359 RVA: 0x00E82C28 File Offset: 0x00E80E28
		public void AddEntityIdToMarkType(int entityId, EMarkType markType)
		{
			this.EntityIdToMarkType[entityId] = markType;
		}

		// Token: 0x06039378 RID: 234360 RVA: 0x00E82C37 File Offset: 0x00E80E37
		public void RemoveEntityIdToMarkType(int entityId)
		{
			Dictionary<int, EMarkType> entityIdToMarkType = this.EntityIdToMarkType;
			if (entityIdToMarkType == null)
			{
				return;
			}
			entityIdToMarkType.Remove(entityId);
		}

		// Token: 0x06039379 RID: 234361 RVA: 0x00E82C4B File Offset: 0x00E80E4B
		public void UpdateHonamiScanMarkInfo(int markId, MarkState state)
		{
			this.HonamiScanMarkInfo[markId] = state;
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnHonamiScanMarkInfoUpdate, markId);
		}

		// Token: 0x0603937A RID: 234362 RVA: 0x00E82C6B File Offset: 0x00E80E6B
		public MarkState GetHonamiScanMarkInfo(int markId)
		{
			return this.HonamiScanMarkInfo.GetValueOrDefault(markId, MarkState.MarkDisable);
		}

		// Token: 0x0603937B RID: 234363 RVA: 0x00E82C7A File Offset: 0x00E80E7A
		public void ClearHonamiScanMarkInfo()
		{
			this.HonamiScanMarkInfo.Clear();
		}

		// Token: 0x0603937C RID: 234364 RVA: 0x00E82C87 File Offset: 0x00E80E87
		public void InitExtraUiMarkType(EMapType mapType)
		{
			if (this.ExtraMarkTypeMap != null)
			{
				this.ExtraMarkTypeMap[mapType] = new HashSet<EMarkType>();
			}
		}

		// Token: 0x0603937D RID: 234365 RVA: 0x00E82CA2 File Offset: 0x00E80EA2
		public void AddExtraUiMarkType(EMapType mapType, EMarkType markType)
		{
			if (this.ExtraMarkTypeMap != null && !this.ExtraMarkTypeMap.ContainsKey(mapType))
			{
				this.InitExtraUiMarkType(mapType);
			}
			Dictionary<EMapType, HashSet<EMarkType>> extraMarkTypeMap = this.ExtraMarkTypeMap;
			if (extraMarkTypeMap == null)
			{
				return;
			}
			HashSet<EMarkType> valueOrDefault = extraMarkTypeMap.GetValueOrDefault(mapType);
			if (valueOrDefault == null)
			{
				return;
			}
			valueOrDefault.Add(markType);
		}

		// Token: 0x0603937E RID: 234366 RVA: 0x00E82CDE File Offset: 0x00E80EDE
		public bool HasExtraUiMarkType(EMapType mapType)
		{
			Dictionary<EMapType, HashSet<EMarkType>> extraMarkTypeMap = this.ExtraMarkTypeMap;
			return ((extraMarkTypeMap != null) ? extraMarkTypeMap.GetValueOrDefault(mapType) : null) != null;
		}

		// Token: 0x0603937F RID: 234367 RVA: 0x00E82CF8 File Offset: 0x00E80EF8
		public bool IsExtraUiMarkType(EMapType mapType, EMarkType markType)
		{
			Dictionary<EMapType, HashSet<EMarkType>> extraMarkTypeMap = this.ExtraMarkTypeMap;
			bool? flag;
			if (extraMarkTypeMap == null)
			{
				flag = null;
			}
			else
			{
				HashSet<EMarkType> valueOrDefault = extraMarkTypeMap.GetValueOrDefault(mapType);
				flag = ((valueOrDefault != null) ? new bool?(valueOrDefault.Contains(markType)) : null);
			}
			bool? flag2 = flag;
			return flag2.GetValueOrDefault();
		}

		// Token: 0x06039380 RID: 234368 RVA: 0x00E82D42 File Offset: 0x00E80F42
		public void ClearExtraUiMarkType(EMapType mapType)
		{
			Dictionary<EMapType, HashSet<EMarkType>> extraMarkTypeMap = this.ExtraMarkTypeMap;
			if (extraMarkTypeMap == null)
			{
				return;
			}
			extraMarkTypeMap.Remove(mapType);
		}

		// Token: 0x06039381 RID: 234369 RVA: 0x00E82D56 File Offset: 0x00E80F56
		public void InitExtraUiMarkId(EMapType mapType)
		{
			if (this.ExtraMarkIdMap != null)
			{
				this.ExtraMarkIdMap[mapType] = new HashSet<int>();
			}
		}

		// Token: 0x06039382 RID: 234370 RVA: 0x00E82D71 File Offset: 0x00E80F71
		public void AddExtraUiMarkId(EMapType mapType, int markId)
		{
			if (this.ExtraMarkIdMap != null && !this.ExtraMarkIdMap.ContainsKey(mapType))
			{
				this.InitExtraUiMarkId(mapType);
			}
			Dictionary<EMapType, HashSet<int>> extraMarkIdMap = this.ExtraMarkIdMap;
			if (extraMarkIdMap == null)
			{
				return;
			}
			HashSet<int> valueOrDefault = extraMarkIdMap.GetValueOrDefault(mapType);
			if (valueOrDefault == null)
			{
				return;
			}
			valueOrDefault.Add(markId);
		}

		// Token: 0x06039383 RID: 234371 RVA: 0x00E82DAD File Offset: 0x00E80FAD
		public bool HasExtraUiMarkId(EMapType mapType)
		{
			Dictionary<EMapType, HashSet<int>> extraMarkIdMap = this.ExtraMarkIdMap;
			return ((extraMarkIdMap != null) ? extraMarkIdMap.GetValueOrDefault(mapType) : null) != null;
		}

		// Token: 0x06039384 RID: 234372 RVA: 0x00E82DC8 File Offset: 0x00E80FC8
		public bool IsExtraUiMarkId(EMapType mapType, int markId)
		{
			Dictionary<EMapType, HashSet<int>> extraMarkIdMap = this.ExtraMarkIdMap;
			bool? flag;
			if (extraMarkIdMap == null)
			{
				flag = null;
			}
			else
			{
				HashSet<int> valueOrDefault = extraMarkIdMap.GetValueOrDefault(mapType);
				flag = ((valueOrDefault != null) ? new bool?(valueOrDefault.Contains(markId)) : null);
			}
			bool? flag2 = flag;
			return flag2.GetValueOrDefault();
		}

		// Token: 0x06039385 RID: 234373 RVA: 0x00E82E12 File Offset: 0x00E81012
		public void ClearExtraUiMarkId(EMapType mapType)
		{
			Dictionary<EMapType, HashSet<int>> extraMarkIdMap = this.ExtraMarkIdMap;
			if (extraMarkIdMap == null)
			{
				return;
			}
			extraMarkIdMap.Remove(mapType);
		}

		// Token: 0x06039386 RID: 234374 RVA: 0x00E82E26 File Offset: 0x00E81026
		public void SetExtraUiTileRange(EMapType mapType, ITileNum tileRange)
		{
			if (this.ExtraUiTileRange != null)
			{
				this.ExtraUiTileRange[mapType] = tileRange;
			}
		}

		// Token: 0x06039387 RID: 234375 RVA: 0x00E82E3D File Offset: 0x00E8103D
		public void ClearExtraUiTileRange(EMapType mapType)
		{
			Dictionary<EMapType, ITileNum> extraUiTileRange = this.ExtraUiTileRange;
			if (extraUiTileRange == null)
			{
				return;
			}
			extraUiTileRange.Remove(mapType);
		}

		// Token: 0x06039388 RID: 234376 RVA: 0x00E82E51 File Offset: 0x00E81051
		public bool HasExtraUiTileRange(EMapType mapType)
		{
			Dictionary<EMapType, ITileNum> extraUiTileRange = this.ExtraUiTileRange;
			return extraUiTileRange != null && extraUiTileRange.ContainsKey(mapType);
		}

		// Token: 0x06039389 RID: 234377 RVA: 0x00E82E68 File Offset: 0x00E81068
		public bool IsInExtraUiTileRange(EMapType mapType, global::Vector uiPosition)
		{
			ITileNum tileNum;
			if (this.ExtraUiTileRange == null || !this.ExtraUiTileRange.TryGetValue(mapType, out tileNum))
			{
				return true;
			}
			int num = (int)Math.Ceiling(uiPosition.X / 850.0);
			int num2 = (int)Math.Ceiling(uiPosition.Y / 850.0);
			return num >= tileNum.MinX && num <= tileNum.MaxX && num2 >= tileNum.MinY && num2 <= tileNum.MaxY;
		}

		// Token: 0x0402088D RID: 133261
		private int DynamicMarkId;

		// Token: 0x0402088E RID: 133262
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private Dictionary<EMarkType, Dictionary<int, DynamicMarkCreateInfo>> DynamicMarks;

		// Token: 0x0402088F RID: 133263
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<int, Dictionary<int, bool>> MarkVisibleStateRecord;

		// Token: 0x04020890 RID: 133264
		[Nullable(2)]
		private Dictionary<int, long> SceneGamePlayRefQuestMap;

		// Token: 0x04020891 RID: 133265
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private Dictionary<string, int[]> OccupationResourceRefPlayMap;

		// Token: 0x04020892 RID: 133266
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<int, DynamicMarkCreateInfo> DynamicMarksSearchMap;

		// Token: 0x04020893 RID: 133267
		[Nullable(2)]
		private Dictionary<int, bool> UnlockedTeleports;

		// Token: 0x04020894 RID: 133268
		[Nullable(2)]
		private Dictionary<int, bool> UnlockedFogs;

		// Token: 0x04020895 RID: 133269
		[Nullable(2)]
		private Dictionary<int, bool> UnlockedAreas;

		// Token: 0x04020896 RID: 133270
		[Nullable(2)]
		private TrackMapMarkParams CurTrackParams;

		// Token: 0x04020897 RID: 133271
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<int, IMarkShowState> MarkExtraShowStateReference;

		// Token: 0x04020898 RID: 133272
		private HashSet<int> CompleteMarks = new HashSet<int>();

		// Token: 0x04020899 RID: 133273
		[Nullable(2)]
		private Dictionary<int, int> PendingAddEntityList;

		// Token: 0x0402089A RID: 133274
		[Nullable(2)]
		private HashSet<int> PendingAddTempMapMarkList;

		// Token: 0x0402089B RID: 133275
		[Nullable(2)]
		private Dictionary<int, bool> ServerUnlockedMarksMap;

		// Token: 0x0402089C RID: 133276
		private List<int> UnlockMultiMapIds = new List<int>();

		// Token: 0x0402089D RID: 133277
		public List<int> UnlockMapBlockIds = new List<int>();

		// Token: 0x0402089E RID: 133278
		public readonly global::Vector LastSafeLocation = global::Vector.Create();

		// Token: 0x0402089F RID: 133279
		[Nullable(2)]
		public Circle CacheEnrichmentAreaWorldMapCircle;

		// Token: 0x040208A0 RID: 133280
		public int CacheEnrichmentAreaEntityId;

		// Token: 0x040208A1 RID: 133281
		public Dictionary<int, MarkState> HonamiScanMarkInfo = new Dictionary<int, MarkState>();

		// Token: 0x040208A2 RID: 133282
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<int, TreasureBoxSlotInfo> TreasureBoxSlotRawDataMap;

		// Token: 0x040208A3 RID: 133283
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<int, TemporaryTeleportInfo> TemporaryTeleportInfoRawDataMap;

		// Token: 0x040208A4 RID: 133284
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Dictionary<EMapLifeEventListenerType, IMapLifeEventTriggerParam> MapLifeEventListenerTriggerMap;

		// Token: 0x040208A5 RID: 133285
		private readonly List<MarkDefine.FishingShipMarkCacheInfo> CacheEntityMapMarkInfo = new List<MarkDefine.FishingShipMarkCacheInfo>();

		// Token: 0x040208A6 RID: 133286
		private readonly HashSet<int> RemoteTrackingMarkSet = new HashSet<int>();

		// Token: 0x040208A7 RID: 133287
		private Dictionary<string, SystemMarkHideInfoPb> SystemMarkHideInfoMap = new Dictionary<string, SystemMarkHideInfoPb>();

		// Token: 0x040208A8 RID: 133288
		[Nullable(2)]
		private Dictionary<int, EMarkType> EntityIdToMarkType;

		// Token: 0x040208A9 RID: 133289
		public int? LastHighLevelAreaInner;

		// Token: 0x040208AA RID: 133290
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<EMapType, HashSet<EMarkType>> ExtraMarkTypeMap;

		// Token: 0x040208AB RID: 133291
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<EMapType, HashSet<int>> ExtraMarkIdMap;

		// Token: 0x040208AC RID: 133292
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<EMapType, ITileNum> ExtraUiTileRange;

		// Token: 0x040208AD RID: 133293
		private readonly Dictionary<int, HashSet<MapTeleportQueryInfo>> MarkQueryInfoInGrid = new Dictionary<int, HashSet<MapTeleportQueryInfo>>();

		// Token: 0x040208AE RID: 133294
		[Nullable(new byte[]
		{
			1,
			1,
			0,
			1
		})]
		private readonly TrimLru<int, List<ValueTuple<MapTeleportQueryInfo, double>>> MarkQueryInfoCache = new TrimLru<int, List<ValueTuple<MapTeleportQueryInfo, double>>>(3, false);
	}
}
