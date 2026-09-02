using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Mark.Component;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks
{
	// Token: 0x02005833 RID: 22579
	[NullableContext(1)]
	[Nullable(0)]
	public static class MarkItemUtil
	{
		// Token: 0x06039662 RID: 235106 RVA: 0x00E922C8 File Offset: 0x00E904C8
		[return: Nullable(2)]
		public static MarkItem Create([Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})] OneOf<ConfigMarkCreateInfo, DynamicMarkCreateInfo, PlayerMarkCreateInfo> config, EMapType mapType, float markScale, UUIItem parent)
		{
			MarkItem markItem = null;
			if (config.IsT1)
			{
				return MarkItemUtil.CreateConfigMark(config.AsT1.MarkId, config.AsT1.MarkConfig, mapType, markScale, parent);
			}
			if (config.IsT2)
			{
				return MarkItemUtil.CreateDynamicMark(config.AsT2, mapType, markScale, parent);
			}
			if (config.IsT3)
			{
				markItem = new PlayerMarkItem(parent, config.AsT3, mapType, markScale, ETrackSource.MapMark);
				MarkItemUtil.InitializeMarkItem(markItem, config.AsT3.Gravity);
				return markItem;
			}
			return markItem;
		}

		// Token: 0x06039663 RID: 235107 RVA: 0x00E92350 File Offset: 0x00E90550
		[return: Nullable(2)]
		public static ConfigMarkItem CreateConfigMark(int markId, MapMark markConfig, EMapType mapType, float markScale, UUIItem parent)
		{
			ConfigMarkItem configMarkItem;
			switch (markConfig.ObjectType)
			{
			case 1:
				configMarkItem = new AreaMarkItem(markId, markConfig, parent, mapType, markScale, null);
				goto IL_31E;
			case 5:
			case 6:
				configMarkItem = new TeleportMarkItem(markId, markConfig, parent, mapType, markScale, ETrackSource.MapMark);
				goto IL_31E;
			case 7:
				configMarkItem = new EntityMarkItem(markId, markConfig, parent, global::Vector.Create((double)markConfig.MarkVector.Value.X, (double)markConfig.MarkVector.Value.Y, (double)markConfig.MarkVector.Value.Z), mapType, markScale);
				goto IL_31E;
			case 8:
				configMarkItem = new MingSuNpcMarkItem(markId, markConfig, parent, mapType, markScale, ETrackSource.MapMark);
				goto IL_31E;
			case 9:
				configMarkItem = null;
				goto IL_31E;
			case 10:
				configMarkItem = new SceneGameplayMarkItem(markId, markConfig, parent, mapType, markScale, null);
				goto IL_31E;
			case 13:
				configMarkItem = new ParkourMarkItem(markId, markConfig, parent, mapType, markScale, null);
				goto IL_31E;
			case 19:
				configMarkItem = new FixedSceneGameplayMarkItem(markId, markConfig, parent, mapType, markScale, ETrackSource.MapMark);
				goto IL_31E;
			case 20:
				configMarkItem = new LandscapeMarkItem(markId, markConfig, parent, mapType, markScale, ETrackSource.MapMark);
				goto IL_31E;
			case 24:
				configMarkItem = new CorniceMeetingMarkItem(markId, markConfig, parent, mapType, markScale, null);
				goto IL_31E;
			case 25:
				configMarkItem = new PunishReportMarkItem(markId, markConfig, parent, mapType, markScale, ETrackSource.MapMark);
				goto IL_31E;
			case 26:
				configMarkItem = new CaveHoleMarkItem(markId, markConfig, parent, mapType, markScale, ETrackSource.MapMark);
				goto IL_31E;
			case 27:
				configMarkItem = new DreamLinkRunMarkItem(markId, markConfig, parent, mapType, markScale, null);
				goto IL_31E;
			case 28:
				configMarkItem = new LevelPlayReportMarkItem(markId, markConfig, parent, mapType, markScale, ETrackSource.MapMark);
				goto IL_31E;
			case 39:
				configMarkItem = new HonamiScanMarkItem(markId, markConfig, parent, mapType, markScale, ETrackSource.Instance);
				goto IL_31E;
			case 42:
				configMarkItem = new GreatSwordChallengeMarkItem(markId, markConfig, parent, mapType, markScale, ETrackSource.MapMark);
				goto IL_31E;
			case 43:
				configMarkItem = new InfrRoadMarkItem(markId, markConfig, parent, mapType, markScale, ETrackSource.MapMark);
				goto IL_31E;
			case 44:
				configMarkItem = new InfrObservatoryMarkItem(markId, markConfig, parent, mapType, markScale, ETrackSource.MapMark);
				goto IL_31E;
			case 45:
				configMarkItem = new PhantomArenaNpcMarkItem(markId, markConfig, parent, mapType, markScale, ETrackSource.MapMark);
				goto IL_31E;
			case 46:
				configMarkItem = new FloatLightForestMarkItem(markId, markConfig, parent, mapType, markScale, null);
				goto IL_31E;
			case 47:
				configMarkItem = new VillageInfrMarkItem(markId, markConfig, parent, mapType, markScale, ETrackSource.MapMark);
				goto IL_31E;
			case 48:
				configMarkItem = new VillageInfrTreeMarkItem(markId, markConfig, parent, mapType, markScale, ETrackSource.MapMark);
				goto IL_31E;
			case 49:
				configMarkItem = new SheriffAnomalyMarkItem(markId, markConfig, parent, mapType, markScale, ETrackSource.MapMark);
				goto IL_31E;
			case 50:
				configMarkItem = new SheriffQuestMarkItem(markId, markConfig, parent, mapType, markScale, ETrackSource.MapMark);
				goto IL_31E;
			case 51:
				configMarkItem = new DollGrabMachineMarkItem(markId, markConfig, parent, mapType, markScale, ETrackSource.MapMark);
				goto IL_31E;
			}
			configMarkItem = new ConfigMarkItem(markId, markConfig, parent, mapType, markScale, null);
			IL_31E:
			if (configMarkItem != null)
			{
				MarkItemUtil.InitializeConfigMarkItem(configMarkItem);
			}
			return configMarkItem;
		}

		// Token: 0x06039664 RID: 235108 RVA: 0x00E92688 File Offset: 0x00E90888
		[return: Nullable(2)]
		public static MarkItem CreateDynamicMark(DynamicMarkCreateInfo config, EMapType mapType, float markScale, UUIItem parent)
		{
			EMarkType markType = config.MarkType;
			ServerMarkItem serverMarkItem;
			switch (markType)
			{
			case EMarkType.Entity:
				break;
			case EMarkType.NPC:
			case EMarkType.SceneGameplay:
			case EMarkType.OtherPlayers:
			case EMarkType.Parkour:
			case (EMarkType)14:
			case EMarkType.FixedSceneGameplay:
			case EMarkType.LandscapeMark:
				goto IL_156;
			case EMarkType.Custom:
				serverMarkItem = new CustomMarkItem(config, parent, mapType, markScale);
				goto IL_160;
			case EMarkType.Quest:
				serverMarkItem = new TaskMarkItem((QuestMarkCreateInfo)config, parent, mapType, markScale);
				goto IL_160;
			case EMarkType.TemporaryTeleport:
				serverMarkItem = new TemporaryTeleportMarkItem(config, parent, mapType, markScale);
				goto IL_160;
			case EMarkType.SoundBox:
			case EMarkType.CalmingWindBell:
				serverMarkItem = new SoundBoxMarkItem(config, parent, mapType, markScale);
				goto IL_160;
			case EMarkType.TreasureBoxDetector:
				serverMarkItem = new TreasureBoxDetectorMarkItem(config, parent, mapType, markScale);
				goto IL_160;
			case EMarkType.TreasureBox:
				serverMarkItem = new TreasureBoxMarkItem(config, parent, mapType, markScale);
				goto IL_160;
			case EMarkType.EnrichmentArea:
				serverMarkItem = new EnrichmentAreaItem(config, parent, mapType, markScale);
				goto IL_160;
			case EMarkType.EnrichmentCollectProduct:
				serverMarkItem = new EnrichmentCollectProductItem(config, parent, mapType, markScale);
				goto IL_160;
			default:
				switch (markType)
				{
				case EMarkType.FishingShip:
					serverMarkItem = new FishingShipMarkItem((FishingShipMarkCreateInfo)config, parent, mapType, markScale);
					goto IL_160;
				case EMarkType.FishingPoint:
					serverMarkItem = new FishingPointMarkItem((FishingPointMarkCreateInfo)config, parent, mapType, markScale);
					goto IL_160;
				case EMarkType.FishingCage:
				case EMarkType.FishingDock:
				case EMarkType.HonamiScan:
					goto IL_156;
				case EMarkType.MoraleExploreBox:
					break;
				case EMarkType.SightSpot:
				case EMarkType.FlyingHunter:
				case EMarkType.Frostbite:
					serverMarkItem = new TraceExploreEntityMarkItem(config, parent, mapType, markScale);
					goto IL_160;
				case EMarkType.HonamiScanItem:
					serverMarkItem = new HonamiScanItemMarkItem(config, parent, mapType, markScale);
					goto IL_160;
				default:
					goto IL_156;
				}
				break;
			}
			return MarkItemUtil.CreateDynamicEntityMark(config.MarkId.Value, config.MarkConfigId, parent, config.TrackTarget, mapType, markScale);
			IL_156:
			serverMarkItem = new ServerMarkItem(config, parent, mapType, markScale);
			IL_160:
			MarkItemUtil.InitializeServerMarkItem(serverMarkItem, config.MapGravity);
			return serverMarkItem;
		}

		// Token: 0x06039665 RID: 235109 RVA: 0x00E92804 File Offset: 0x00E90A04
		[return: Nullable(2)]
		public static EntityMarkItem CreateEntityMark(int markId, int markConfigId, UUIItem parent, TTrackTarget trackTarget, EMapType mapType, float markScale)
		{
			MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(markConfigId);
			if (configMark == null)
			{
				return null;
			}
			EntityMarkItem entityMarkItem = new EntityMarkItem(markId, configMark.Value, parent, trackTarget, mapType, markScale);
			MarkItemUtil.InitializeMarkItem(entityMarkItem, (EMapGravityDirection)configMark.Value.GravityFlip);
			return entityMarkItem;
		}

		// Token: 0x06039666 RID: 235110 RVA: 0x00E92850 File Offset: 0x00E90A50
		[return: Nullable(2)]
		public static DynamicEntityMarkItem CreateDynamicEntityMark(int markId, int markConfigId, UUIItem parent, TTrackTarget trackTarget, EMapType mapType, float markScale)
		{
			DynamicMapMark? dynamicConfigMark = ConfigBase<MapConfig>.Instance.GetDynamicConfigMark(markConfigId);
			if (dynamicConfigMark == null)
			{
				return null;
			}
			DynamicEntityMarkItem dynamicEntityMarkItem = new DynamicEntityMarkItem(markId, dynamicConfigMark.Value, parent, trackTarget, mapType, markScale);
			DynamicMarkCreateInfo mark = ModelBase<MapModel>.Instance.GetMark((EMarkType)dynamicConfigMark.Value.ObjectType, markId);
			if (mark != null)
			{
				dynamicEntityMarkItem.OverrideMapId = new int?(mark.MapId);
			}
			MarkItemUtil.InitializeDynamicMarkItem(dynamicEntityMarkItem, (mark != null) ? mark.MapGravity : EMapGravityDirection.All, trackTarget);
			return dynamicEntityMarkItem;
		}

		// Token: 0x06039667 RID: 235111 RVA: 0x00E928CC File Offset: 0x00E90ACC
		public static bool IsTrackPointedMarkInCurrentDungeon(ITrackData trackData, bool fallbackReturn = false)
		{
			ETrackSource trackSource = trackData.TrackSource;
			if (trackSource != ETrackSource.MapMark)
			{
				return trackSource != ETrackSource.Instance || MarkItemUtil.IsTrackPointedMarkInCurrentDungeonByInstance(trackData);
			}
			return MarkItemUtil.IsTrackPointedMarkInCurrentDungeonByMapMark(trackData, fallbackReturn);
		}

		// Token: 0x06039668 RID: 235112 RVA: 0x00E928FC File Offset: 0x00E90AFC
		private static bool IsTrackPointedMarkInCurrentDungeonByMapMark(ITrackData trackData, bool fallbackReturn)
		{
			InstanceDungeon? instanceDungeon;
			int? num = (ModelBase<GameModeModel>.Instance.InstanceDungeon != null) ? new int?(instanceDungeon.GetValueOrDefault().MapConfigId) : null;
			if (trackData.Id <= 0)
			{
				DynamicMarkCreateInfo dynamicMarkInfoById = ModelBase<MapModel>.Instance.GetDynamicMarkInfoById(trackData.Id);
				if (dynamicMarkInfoById == null || dynamicMarkInfoById.MapId <= 0)
				{
					return fallbackReturn;
				}
				if (dynamicMarkInfoById.MarkType == EMarkType.Quest)
				{
					return true;
				}
				int? num2 = num;
				int mapId = dynamicMarkInfoById.MapId;
				return num2.GetValueOrDefault() == mapId & num2 != null;
			}
			else
			{
				DynamicMarkCreateInfo dynamicMarkInfoById2 = ModelBase<MapModel>.Instance.GetDynamicMarkInfoById(trackData.Id);
				if (dynamicMarkInfoById2 != null && dynamicMarkInfoById2.MapId > 0)
				{
					if (dynamicMarkInfoById2.MarkType == EMarkType.Quest)
					{
						return true;
					}
					int? num2 = num;
					int mapId = dynamicMarkInfoById2.MapId;
					return num2.GetValueOrDefault() == mapId & num2 != null;
				}
				else
				{
					MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(trackData.Id);
					if (configMark != null && configMark.Value.MapId > 0)
					{
						int? num2 = num;
						int mapId = configMark.Value.MapId;
						return num2.GetValueOrDefault() == mapId & num2 != null;
					}
					return fallbackReturn;
				}
			}
		}

		// Token: 0x06039669 RID: 235113 RVA: 0x00E92A38 File Offset: 0x00E90C38
		private static bool IsTrackPointedMarkInCurrentDungeonByInstance(ITrackData trackData)
		{
			InstanceDungeon? instanceDungeon;
			int? num = (ModelBase<GameModeModel>.Instance.InstanceDungeon != null) ? new int?(instanceDungeon.GetValueOrDefault().Id) : null;
			if (num == null || trackData.TrackInstanceId == null)
			{
				return true;
			}
			DynamicMarkCreateInfo dynamicMarkInfoById = ModelBase<MapModel>.Instance.GetDynamicMarkInfoById(trackData.Id);
			if (dynamicMarkInfoById != null && dynamicMarkInfoById.InstanceDungeonId != null && dynamicMarkInfoById.MarkType == EMarkType.Quest)
			{
				return true;
			}
			int? num2 = num;
			int? trackInstanceId = trackData.TrackInstanceId;
			return num2.GetValueOrDefault() == trackInstanceId.GetValueOrDefault() & num2 != null == (trackInstanceId != null);
		}

		// Token: 0x0603966A RID: 235114 RVA: 0x00E92AF0 File Offset: 0x00E90CF0
		public static bool IsHideTrackInView(ITrackData trackData)
		{
			if (trackData.MarkType.GetValueOrDefault() == EMarkType.Quest)
			{
				return false;
			}
			if (trackData.TrackHudEnable != null)
			{
				return !trackData.TrackHudEnable.Value;
			}
			return trackData.TrackSource == ETrackSource.MapMark;
		}

		// Token: 0x0603966B RID: 235115 RVA: 0x00E92B3C File Offset: 0x00E90D3C
		[NullableContext(2)]
		public static bool CanShowTrackMark(ITrackData trackData)
		{
			return trackData != null && MarkItemUtil.IsTrackPointedMarkInCurrentDungeon(trackData, true) && !MarkItemUtil.IsHideTrackInView(trackData);
		}

		// Token: 0x0603966C RID: 235116 RVA: 0x00E92B58 File Offset: 0x00E90D58
		private static void InitializeMarkItem(MarkItem markItem, EMapGravityDirection gravity)
		{
			markItem.MarkItemEntity = MarkFactory.CreateAndAssembleMark(new CreateMarkParam
			{
				MarkId = markItem.MarkId,
				MarkType = markItem.MarkType,
				Gravity = gravity,
				MapId = markItem.MapId
			});
			markItem.Initialize();
		}

		// Token: 0x0603966D RID: 235117 RVA: 0x00E92BA8 File Offset: 0x00E90DA8
		private static void InitializeConfigMarkItem(ConfigMarkItem markItem)
		{
			markItem.MarkItemEntity = MarkFactory.CreateAndAssembleConfigMark(new CreateMarkParam
			{
				MarkId = markItem.MarkId,
				MarkType = markItem.MarkType,
				Gravity = (EMapGravityDirection)markItem.MarkConfig.Value.GravityFlip,
				Config = markItem.MarkConfig.Value,
				EntityId = markItem.MarkConfig.Value.EntityConfigId,
				MapId = markItem.MapId
			});
			markItem.Initialize();
		}

		// Token: 0x0603966E RID: 235118 RVA: 0x00E92C34 File Offset: 0x00E90E34
		private static void InitializeServerMarkItem(ServerMarkItem markItem, EMapGravityDirection gravity)
		{
			markItem.MarkItemEntity = MarkFactory.CreateAndAssembleServerMark(new CreateMarkParam
			{
				MarkId = markItem.MarkId,
				MarkType = markItem.MarkType,
				Gravity = gravity,
				EntityId = markItem.EntityConfigId,
				MapId = markItem.MapId
			});
			markItem.Initialize();
		}

		// Token: 0x0603966F RID: 235119 RVA: 0x00E92C90 File Offset: 0x00E90E90
		private static void InitializeDynamicMarkItem(DynamicConfigMarkItem markItem, EMapGravityDirection gravity, TTrackTarget trackTarget)
		{
			markItem.MarkItemEntity = MarkFactory.CreateAndAssembleDynamicConfigMark(new CreateMarkParam
			{
				MarkId = markItem.MarkId,
				MarkType = markItem.MarkType,
				Gravity = gravity,
				MapId = markItem.MapId,
				DynamicConfig = markItem.MarkConfig.Value
			});
			markItem.Initialize();
			if (trackTarget is TTrackTarget_Int)
			{
				markItem.MarkItemEntity.GetOrAddComponent<MarkEntityComponent>(EMapComponent.MarkEntity).EntityId = new int?(((TTrackTarget_Int)trackTarget).Value);
			}
			markItem.MarkItemEntity.GetOrAddComponent<MarkEntityComponent>(EMapComponent.MarkEntity).Init();
		}
	}
}
