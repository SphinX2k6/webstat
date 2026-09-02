using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067DB RID: 26587
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class FishingConfig : ConfigBase<FishingConfig>
	{
		// Token: 0x06042515 RID: 271637 RVA: 0x01102926 File Offset: 0x01100B26
		public FishingItem? GetFishingItemConfig(int itemId)
		{
			return ConfigFishingItemById.GetConfig(itemId, true);
		}

		// Token: 0x06042516 RID: 271638 RVA: 0x0110292F File Offset: 0x01100B2F
		public IReadOnlyList<FishingItem> GetAllFishingItemConfig()
		{
			return ConfigFishingItemAll.GetConfigList(true);
		}

		// Token: 0x06042517 RID: 271639 RVA: 0x01102937 File Offset: 0x01100B37
		public FishingTag? GetFishingTagConfig(int id)
		{
			return ConfigFishingTagById.GetConfig(id, true);
		}

		// Token: 0x06042518 RID: 271640 RVA: 0x01102940 File Offset: 0x01100B40
		public FishingQteConfig? GetFishingQteConfig(int gameplayId)
		{
			return ConfigFishingQteConfigById.GetConfig(gameplayId, true);
		}

		// Token: 0x06042519 RID: 271641 RVA: 0x01102949 File Offset: 0x01100B49
		public FishingPoint? GetFishingPointConfigById(int id)
		{
			return ConfigFishingPointById.GetConfig(id, true);
		}

		// Token: 0x0604251A RID: 271642 RVA: 0x01102952 File Offset: 0x01100B52
		public FishingPoint? GetFishingPointConfigByEntityId(int entityId)
		{
			return ConfigFishingPointByEntityConfigId.GetConfig(entityId, true);
		}

		// Token: 0x0604251B RID: 271643 RVA: 0x0110295C File Offset: 0x01100B5C
		public FishingGridItemShape GetFishingShapeConfig(int shapeId)
		{
			return ConfigFishingGridItemShapeById.GetConfig(shapeId, true).Value;
		}

		// Token: 0x0604251C RID: 271644 RVA: 0x01102978 File Offset: 0x01100B78
		public FishingPort GetFishingPortConfig(int portId)
		{
			return ConfigFishingPortById.GetConfig(portId, true).Value;
		}

		// Token: 0x0604251D RID: 271645 RVA: 0x01102994 File Offset: 0x01100B94
		public FishingShipSkin GetFishingShipSkinConfig(int skinId)
		{
			return ConfigFishingShipSkinById.GetConfig(skinId, true).Value;
		}

		// Token: 0x0604251E RID: 271646 RVA: 0x011029B0 File Offset: 0x01100BB0
		public IReadOnlyList<FishingShipSkin> GetAllFishingSkinConfig()
		{
			return ConfigFishingShipSkinAll.GetConfigList(true);
		}

		// Token: 0x0604251F RID: 271647 RVA: 0x011029B8 File Offset: 0x01100BB8
		public int GetFishingQualityRatioByQualityId(int id)
		{
			return ConfigCommonParamById.GetIntArrayConfig("FishingPriceQualityRatioNew")[id - 1];
		}

		// Token: 0x06042520 RID: 271648 RVA: 0x011029CC File Offset: 0x01100BCC
		public IReadOnlyList<FishingReputation> GetAllFishingReputation()
		{
			return ConfigFishingReputationAll.GetConfigList(true);
		}

		// Token: 0x06042521 RID: 271649 RVA: 0x011029D4 File Offset: 0x01100BD4
		public FishingReputation GetFishingReputationByLevel(int level)
		{
			return ConfigFishingReputationByLevel.GetConfig(level, true).Value;
		}

		// Token: 0x06042522 RID: 271650 RVA: 0x011029F0 File Offset: 0x01100BF0
		public FishingQuality GetFishingQualityConfig(int qualityId)
		{
			return ConfigFishingQualityById.GetConfig(qualityId, true).Value;
		}

		// Token: 0x06042523 RID: 271651 RVA: 0x01102A0C File Offset: 0x01100C0C
		public FishingEntrust? GetFishingEntrust(int id)
		{
			return ConfigFishingEntrustById.GetConfig(id, true);
		}

		// Token: 0x06042524 RID: 271652 RVA: 0x01102A18 File Offset: 0x01100C18
		public FishingPosition GetFishingPortPosition(int id)
		{
			return ConfigFishingPositionById.GetConfig(id, true).Value;
		}

		// Token: 0x06042525 RID: 271653 RVA: 0x01102A34 File Offset: 0x01100C34
		public FishingDelivery GetFishingDelivery(int id)
		{
			return ConfigFishingDeliveryById.GetConfig(id, true).Value;
		}

		// Token: 0x06042526 RID: 271654 RVA: 0x01102A50 File Offset: 0x01100C50
		public FishingTech GetFishingTechById(int techId)
		{
			return ConfigFishingTechById.GetConfig(techId, true).Value;
		}

		// Token: 0x06042527 RID: 271655 RVA: 0x01102A6C File Offset: 0x01100C6C
		public FishingTechEffect GetFishingTechEffectById(int techEffectId)
		{
			return ConfigFishingTechEffectById.GetConfig(techEffectId, true).Value;
		}

		// Token: 0x06042528 RID: 271656 RVA: 0x01102A88 File Offset: 0x01100C88
		public IReadOnlyList<FishingTechEffect> GetFishingTechEffectByType(int techEffectType)
		{
			return ConfigFishingTechEffectByType.GetConfigList(techEffectType, true);
		}

		// Token: 0x06042529 RID: 271657 RVA: 0x01102A91 File Offset: 0x01100C91
		public IReadOnlyList<FishingTech> GetFishingTechList()
		{
			return ConfigFishingTechAll.GetConfigList(true);
		}

		// Token: 0x0604252A RID: 271658 RVA: 0x01102A9C File Offset: 0x01100C9C
		public FishingNpcPerform GetFishingNpcPerform(string id)
		{
			return ConfigFishingNpcPerformById.GetConfig(id, true).Value;
		}

		// Token: 0x0604252B RID: 271659 RVA: 0x01102AB8 File Offset: 0x01100CB8
		public FishingEntrustPool GetFishingEntrustPoolById(int poolId)
		{
			return ConfigFishingEntrustPoolById.GetConfig(poolId, true).Value;
		}

		// Token: 0x0604252C RID: 271660 RVA: 0x01102AD4 File Offset: 0x01100CD4
		public IReadOnlyList<FishingEntrustPool> GetAllFishingEntrustPool()
		{
			return ConfigFishingEntrustPoolAll.GetConfigList(true);
		}

		// Token: 0x0604252D RID: 271661 RVA: 0x01102ADC File Offset: 0x01100CDC
		public FishingEntrustType GetFishingEntrustType(int type)
		{
			return ConfigFishingEntrustTypeById.GetConfig(type, true).Value;
		}

		// Token: 0x0604252E RID: 271662 RVA: 0x01102AF8 File Offset: 0x01100CF8
		public FishingManualRefresh GetFishingManualRefreshById(int refreshId)
		{
			return ConfigFishingManualRefreshById.GetConfig(refreshId, true).Value;
		}

		// Token: 0x0604252F RID: 271663 RVA: 0x01102B14 File Offset: 0x01100D14
		public IReadOnlyList<FishingManualRefresh> GetFishingManualRefreshByEntrustPoolTypeAndStar(int poolType, int star)
		{
			return ConfigFishingManualRefreshByEntrustPoolTypeAndStar.GetConfigList(poolType, star, true);
		}

		// Token: 0x06042530 RID: 271664 RVA: 0x01102B1E File Offset: 0x01100D1E
		public IReadOnlyList<FishingPoint> GetFishingPointByShowItem(int itemId)
		{
			return ConfigFishingPointByShowItem.GetConfigList(itemId, true);
		}

		// Token: 0x06042531 RID: 271665 RVA: 0x01102B27 File Offset: 0x01100D27
		public FishingActivity? GetFishingActivityConfig(int activityId)
		{
			return ConfigFishingActivityByActivityId.GetConfig(activityId, true);
		}

		// Token: 0x06042532 RID: 271666 RVA: 0x01102B30 File Offset: 0x01100D30
		public FishingActivityGroup? GetFishingActivityGroupConfig(int groupId)
		{
			return ConfigFishingActivityGroupById.GetConfig(groupId, true);
		}

		// Token: 0x06042533 RID: 271667 RVA: 0x01102B39 File Offset: 0x01100D39
		public IReadOnlyList<FishingActivityGroup> GetAllFishingActivityGroupConfig()
		{
			return ConfigFishingActivityGroupAll.GetConfigList(true) ?? Array.Empty<FishingActivityGroup>();
		}

		// Token: 0x06042534 RID: 271668 RVA: 0x01102B4A File Offset: 0x01100D4A
		public FishingActivityLimitTask? GetFishingActivityLimitTask(int taskId)
		{
			return ConfigFishingActivityLimitTaskByTaskId.GetConfig(taskId, true);
		}

		// Token: 0x06042535 RID: 271669 RVA: 0x01102B53 File Offset: 0x01100D53
		public FishingActivityMilestone? GetFishingActivityMilestone(int id)
		{
			return ConfigFishingActivityMilestoneById.GetConfig(id, true);
		}

		// Token: 0x06042536 RID: 271670 RVA: 0x01102B5C File Offset: 0x01100D5C
		public IReadOnlyList<FishingActivityMilestone> GetAllFishingActivityMilestone()
		{
			return ConfigFishingActivityMilestoneAll.GetConfigList(true) ?? Array.Empty<FishingActivityMilestone>();
		}

		// Token: 0x06042537 RID: 271671 RVA: 0x01102B70 File Offset: 0x01100D70
		public FishingIllustratedReward GetFishingIllustratedRewardById(int id)
		{
			return ConfigFishingIllustratedRewardById.GetConfig(id, true).Value;
		}

		// Token: 0x06042538 RID: 271672 RVA: 0x01102B8C File Offset: 0x01100D8C
		public FishingNotice GetFishingNotice(int id)
		{
			return ConfigFishingNoticeById.GetConfig(id, true).Value;
		}
	}
}
