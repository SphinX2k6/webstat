using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark.Component;
using CSharpScript.Game.Module.Map.Marks;
using CSharpScript.Game.Module.WorldMap.ViewComponent;

namespace CSharpScript.Game.Module.Map.Mark
{
	// Token: 0x02005822 RID: 22562
	[NullableContext(1)]
	[Nullable(0)]
	public static class MarkFactory
	{
		// Token: 0x060395C2 RID: 234946 RVA: 0x00E8E4A7 File Offset: 0x00E8C6A7
		public static MarkItemEntity CreateAndAssembleMark(ICreateMarkParam param)
		{
			MarkItemEntity markItemEntity = MarkFactory.CreateDefaultEntity(param);
			MarkFactory.AssembleMarkComponents(markItemEntity, param);
			return markItemEntity;
		}

		// Token: 0x060395C3 RID: 234947 RVA: 0x00E8E4B8 File Offset: 0x00E8C6B8
		private static void AssembleMarkComponents(MarkItemEntity markItemEntity, ICreateMarkParam param)
		{
			EMapComponent[] array;
			if (MarkFactory.MarkAssembleRegisterMap.TryGetValue(param.MarkType, out array))
			{
				foreach (EMapComponent emapComponent in array)
				{
					switch (emapComponent)
					{
					case EMapComponent.WorldMapSecondaryUi:
						markItemEntity.AddComponent<WorldMapSecondaryUiComponent>(emapComponent);
						break;
					case EMapComponent.WorldMapInteract:
						markItemEntity.AddComponent<WorldMapInteractComponent>(emapComponent);
						break;
					case EMapComponent.WorldMapMove:
						markItemEntity.AddComponent<WorldMapMoveComponent>(emapComponent);
						break;
					case EMapComponent.WorldMapScale:
						markItemEntity.AddComponent<WorldMapScaleComponent>(emapComponent);
						break;
					case EMapComponent.WorldMapPlayer:
						markItemEntity.AddComponent<WorldMapPlayerComponent>(emapComponent);
						break;
					case EMapComponent.WorldMapMultiFloor:
						markItemEntity.AddComponent<WorldMapMultiFloorComponent>(emapComponent);
						break;
					case EMapComponent.WorldMapQuickNavigate:
						markItemEntity.AddComponent<WorldMapQuickNavigateComponent>(emapComponent);
						break;
					case EMapComponent.WorldMapStreaming:
						markItemEntity.AddComponent<WorldMapStreamingComponent>(emapComponent);
						break;
					case EMapComponent.WorldMapAlterMap:
						markItemEntity.AddComponent<WorldMapAlterMapComponent>(emapComponent);
						break;
					case EMapComponent.MarkGamePlay:
						markItemEntity.AddComponent<MarkGamePlayComponent>(emapComponent);
						break;
					case EMapComponent.MarkResource:
						markItemEntity.AddComponent<MarkResourceComponent>(emapComponent);
						break;
					case EMapComponent.MarkViewLifeCircle:
						markItemEntity.AddComponent<MarkViewLifeCircleComponent>(emapComponent);
						break;
					case EMapComponent.MarkGamePlayState:
						markItemEntity.AddComponent<MarkGamePlayStateComponent>(emapComponent);
						break;
					case EMapComponent.MarkCommonGamePlayState:
						markItemEntity.AddComponent<MarkCommonGamePlayStateComponent>(emapComponent);
						break;
					case EMapComponent.MarkConfig:
						markItemEntity.AddComponent<MarkConfigComponent>(emapComponent);
						break;
					case EMapComponent.MarkFishingPoint:
						markItemEntity.AddComponent<MarkFishingPointComponent>(emapComponent);
						break;
					case EMapComponent.MarkMultiFloor:
						markItemEntity.AddComponent<MarkMultiFloorComponent>(emapComponent);
						break;
					case EMapComponent.MarkEntity:
						markItemEntity.AddComponent<MarkEntityComponent>(emapComponent);
						break;
					case EMapComponent.WorldMapExtraUiPanel:
						markItemEntity.AddComponent<WorldMapExtraUiPanelComponent>(emapComponent);
						break;
					default:
						throw new ArgumentOutOfRangeException("assembleComponent", emapComponent, "未知的EMapComponent类型");
					}
				}
			}
		}

		// Token: 0x060395C4 RID: 234948 RVA: 0x00E8E63B File Offset: 0x00E8C83B
		public static MarkItemEntity CreateAndAssembleConfigMark(ICreateMarkParam param)
		{
			MarkItemEntity markItemEntity = MarkFactory.CreateConfigMark(param);
			MarkFactory.AssembleMarkComponents(markItemEntity, param);
			return markItemEntity;
		}

		// Token: 0x060395C5 RID: 234949 RVA: 0x00E8E64A File Offset: 0x00E8C84A
		public static MarkItemEntity CreateAndAssembleServerMark(ICreateMarkParam param)
		{
			MarkItemEntity markItemEntity = MarkFactory.CreateServerMark(param);
			MarkFactory.AssembleMarkComponents(markItemEntity, param);
			return markItemEntity;
		}

		// Token: 0x060395C6 RID: 234950 RVA: 0x00E8E659 File Offset: 0x00E8C859
		public static MarkItemEntity CreateAndAssembleDynamicConfigMark(ICreateMarkParam param)
		{
			MarkItemEntity markItemEntity = MarkFactory.CreateDynamicConfigMark(param);
			MarkFactory.AssembleMarkComponents(markItemEntity, param);
			return markItemEntity;
		}

		// Token: 0x060395C7 RID: 234951 RVA: 0x00E8E668 File Offset: 0x00E8C868
		private static MarkItemEntity CreateDefaultEntity(ICreateMarkParam param)
		{
			return new MarkItemEntity
			{
				GamePlay = 
				{
					MarkId = param.MarkId,
					MarkType = param.MarkType,
					Gravity = param.Gravity,
					MapId = param.MapId
				}
			};
		}

		// Token: 0x060395C8 RID: 234952 RVA: 0x00E8E6BE File Offset: 0x00E8C8BE
		private static MarkItemEntity CreateConfigMark(ICreateMarkParam param)
		{
			MarkItemEntity markItemEntity = MarkFactory.CreateDefaultEntity(param);
			markItemEntity.AddComponent<MarkConfigComponent>(EMapComponent.MarkConfig).Config = param.Config;
			markItemEntity.AddComponent<MarkEntityComponent>(EMapComponent.MarkEntity).EntityId = new int?(param.EntityId);
			return markItemEntity;
		}

		// Token: 0x060395C9 RID: 234953 RVA: 0x00E8E6F6 File Offset: 0x00E8C8F6
		private static MarkItemEntity CreateServerMark(ICreateMarkParam param)
		{
			MarkItemEntity markItemEntity = MarkFactory.CreateDefaultEntity(param);
			markItemEntity.AddComponent<MarkEntityComponent>(EMapComponent.MarkEntity).EntityId = new int?(param.EntityId);
			return markItemEntity;
		}

		// Token: 0x060395CA RID: 234954 RVA: 0x00E8E716 File Offset: 0x00E8C916
		private static MarkItemEntity CreateDynamicConfigMark(ICreateMarkParam param)
		{
			MarkItemEntity markItemEntity = MarkFactory.CreateDefaultEntity(param);
			markItemEntity.AddComponent<MarkConfigComponent>(EMapComponent.MarkConfig).Config = param.DynamicConfig;
			return markItemEntity;
		}

		// Token: 0x060395CB RID: 234955 RVA: 0x00E8E738 File Offset: 0x00E8C938
		// Note: this type is marked as 'beforefieldinit'.
		static MarkFactory()
		{
			Dictionary<EMarkType, EMapComponent[]> dictionary = new Dictionary<EMarkType, EMapComponent[]>();
			dictionary[EMarkType.CommonGamePlay] = new EMapComponent[]
			{
				EMapComponent.MarkCommonGamePlayState
			};
			dictionary[EMarkType.LevelPlayReport] = new EMapComponent[]
			{
				EMapComponent.MarkCommonGamePlayState
			};
			dictionary[EMarkType.SceneGameplay] = new EMapComponent[]
			{
				EMapComponent.MarkGamePlayState
			};
			dictionary[EMarkType.FishingPoint] = new EMapComponent[]
			{
				EMapComponent.MarkFishingPoint,
				EMapComponent.MarkConfig
			};
			dictionary[EMarkType.FishingShip] = new EMapComponent[]
			{
				EMapComponent.MarkConfig
			};
			dictionary[EMarkType.Entity] = new EMapComponent[]
			{
				EMapComponent.MarkCommonGamePlayState
			};
			dictionary[EMarkType.SightSpot] = new EMapComponent[]
			{
				EMapComponent.MarkConfig
			};
			dictionary[EMarkType.FlyingHunter] = new EMapComponent[]
			{
				EMapComponent.MarkConfig
			};
			dictionary[EMarkType.Frostbite] = new EMapComponent[]
			{
				EMapComponent.MarkConfig
			};
			dictionary[EMarkType.GreatSwordChallenge] = new EMapComponent[]
			{
				EMapComponent.MarkCommonGamePlayState
			};
			MarkFactory.MarkAssembleRegisterMap = dictionary;
		}

		// Token: 0x040209F1 RID: 133617
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<EMarkType, EMapComponent[]> MarkAssembleRegisterMap;
	}
}
