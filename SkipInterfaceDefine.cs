using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.SkipInterface.SkipTask;

// Token: 0x02002A80 RID: 10880
public class SkipInterfaceDefine : IStaticVariableResetter
{
	// Token: 0x06015C78 RID: 89208 RVA: 0x0060A9C3 File Offset: 0x00608BC3
	static SkipInterfaceDefine()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(SkipInterfaceDefine.CreateStaticDefaultValue), new Action(SkipInterfaceDefine.ResetStaticDefaultValue));
	}

	// Token: 0x06015C79 RID: 89209 RVA: 0x0060A9E4 File Offset: 0x00608BE4
	public static void CreateStaticDefaultValue()
	{
		SkipInterfaceDefine.SkipClassMap = new Dictionary<ESkipName, Type>
		{
			{
				ESkipName.SkipToWorldMapView,
				typeof(SkipTaskWorldMap)
			},
			{
				ESkipName.SkipToAdventureGuide,
				typeof(SkipTaskAdventureGuide)
			},
			{
				ESkipName.SkipToInstanceEnterEntrance,
				typeof(SkipTaskEnterEntrance)
			},
			{
				ESkipName.SkipToTaskPayShop,
				typeof(SkipTaskPayShop)
			},
			{
				ESkipName.SkipToWeaponRoot,
				typeof(SkipTaskWeaponRoot)
			},
			{
				ESkipName.SkipToVisionIntensifyView,
				typeof(SkipTaskVisionIntensifyView)
			},
			{
				ESkipName.SkipToRoguelike,
				typeof(SkipTaskRogueActivity)
			},
			{
				ESkipName.SkipToQuest,
				typeof(SkipTaskQuest)
			},
			{
				ESkipName.SkipToDyMarkEntity,
				typeof(SkipToDyMarkEntity)
			},
			{
				ESkipName.SkipToBusinessMainView,
				typeof(SkipToBusinessMainView)
			},
			{
				ESkipName.SkipToBusinessRoleView,
				typeof(SkipToBusinessRoleView)
			},
			{
				ESkipName.SkipToBuildingView,
				typeof(SkipToBuildingView)
			},
			{
				ESkipName.SkipToTaskView,
				typeof(SkipToTaskView)
			},
			{
				ESkipName.SkipToBusinessMainViewDirect,
				typeof(SkipToBusinessMainViewDirect)
			},
			{
				ESkipName.SkipToTaskViewDirect,
				typeof(SkipToTaskViewDirect)
			},
			{
				ESkipName.SkipToEnrichmentArea,
				typeof(SkipToEnrichmentArea)
			},
			{
				ESkipName.SkipToHelp,
				typeof(SkipTaskHelp)
			},
			{
				ESkipName.SkipToActivity,
				typeof(SkipTaskActivity)
			},
			{
				ESkipName.SkipToRole,
				typeof(SkipTaskRole)
			},
			{
				ESkipName.SkipToMapTempMark,
				typeof(SkipToMapTempMark)
			},
			{
				ESkipName.SkipTaskPayShopToSpecifyTab,
				typeof(SkipTaskPayShopToSpecifyTab)
			},
			{
				ESkipName.SkipToCompose,
				typeof(SkipToCompose)
			},
			{
				ESkipName.SkipToComposeExchange,
				typeof(SkipToComposeExchange)
			},
			{
				ESkipName.SkipToExploreAreaDetailView,
				typeof(SkipToExploreAreaDetailView)
			},
			{
				ESkipName.SkipToExploreAreaPlayPoint,
				typeof(SkipToExploreAreaPlayPoint)
			},
			{
				ESkipName.SkipToFishingTech,
				typeof(SkipToFishingTech)
			},
			{
				ESkipName.SkipToTrackNewSoundArea,
				typeof(SkipTaskTrackNewSoundArea)
			},
			{
				ESkipName.SkipToFishingRelatedView,
				typeof(SkipTaskFishingRelatedView)
			},
			{
				ESkipName.SkipToInventoryGiftView,
				typeof(SkipToInventoryGiftView)
			},
			{
				ESkipName.SkipToGachaView,
				typeof(SkipToGachaView)
			},
			{
				ESkipName.SkipToFloroRanchRelatedView,
				typeof(SkipTaskFloroRanchRelatedView)
			},
			{
				ESkipName.SkipToDailyActiveTask,
				typeof(SkipTaskDailyTask)
			},
			{
				ESkipName.SkipToQuestByType,
				typeof(SkipTaskQuestByType)
			},
			{
				ESkipName.SkipToWorldMapWithMarkCheck,
				typeof(SkipToMapWithMarkCheck)
			},
			{
				ESkipName.SkipToMapWithPhantomAreaChallenge,
				typeof(SkipToMapWithPhantomAreaChallenge)
			},
			{
				ESkipName.SkipToInfrastructureMainView,
				typeof(SkipToInfrastructureMainView)
			},
			{
				ESkipName.SkipToMotorcycleView,
				typeof(SkipToMotorcycleView)
			},
			{
				ESkipName.SkipToDetectionMaterial,
				typeof(SkipToDetectionMaterial)
			},
			{
				ESkipName.SkipCommonView,
				typeof(SkipTaskCommonView)
			},
			{
				ESkipName.SkipToVillageInfrMainView,
				typeof(SkipToVillageInfrMainView)
			},
			{
				ESkipName.SkipToRouletteAssembly,
				typeof(SkipTaskRouletteAssembly)
			},
			{
				ESkipName.SkipToShopRecommendId,
				typeof(SkipToShopRecommendId)
			},
			{
				ESkipName.SkipToFloroRanchWeekly,
				typeof(SkipToFloroRanchWeekly)
			},
			{
				ESkipName.SkipToWeeklyRogue,
				typeof(SkipTaskWeeklyRogue)
			},
			{
				ESkipName.SkipToQuestTreeNode,
				typeof(SkipTaskQuestTreeNode)
			},
			{
				ESkipName.SkipToDailyActivityWeeklyTab,
				typeof(SkipToDailyActivityWeeklyTab)
			},
			{
				ESkipName.SkipToRoleOrnamentId,
				typeof(SkipToRoleOrnamentId)
			},
			{
				ESkipName.SkipCyberPunkAdamSmasher,
				typeof(SkipTaskCyberPunkAdamSmasher)
			},
			{
				ESkipName.SkipToPhoneMsgSetting,
				typeof(SkipToPhoneMsgSetting)
			},
			{
				ESkipName.SkipToKurotatoLevelSelectView,
				typeof(SkipToKurotatoLevelSelectView)
			},
			{
				ESkipName.SkipToMusicalInstrumentView,
				typeof(SkipToMusicalInstrumentView)
			},
			{
				ESkipName.SkipToQuestMultiLineView,
				typeof(SkipToQuestMultiLineView)
			}
		};
	}

	// Token: 0x06015C7A RID: 89210 RVA: 0x0060AD9A File Offset: 0x00608F9A
	public static void ResetStaticDefaultValue()
	{
		SkipInterfaceDefine.SkipClassMap = null;
	}

	// Token: 0x06015C7B RID: 89211 RVA: 0x0060ADA2 File Offset: 0x00608FA2
	[NullableContext(1)]
	public static Dictionary<ESkipName, Type> GetSkipClassMap()
	{
		return SkipInterfaceDefine.SkipClassMap;
	}

	// Token: 0x0400A738 RID: 42808
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static Dictionary<ESkipName, Type> SkipClassMap;
}
