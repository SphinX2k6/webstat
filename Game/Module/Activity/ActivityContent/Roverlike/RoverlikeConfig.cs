using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063AA RID: 25514
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class RoverlikeConfig : ConfigBase<RoverlikeConfig>
	{
		// Token: 0x0604012F RID: 262447 RVA: 0x0106C9E1 File Offset: 0x0106ABE1
		public RoverRogueActivity? GetActivityParamConfig(int activityId)
		{
			return ConfigRoverRogueActivityById.GetConfig(activityId, true);
		}

		// Token: 0x06040130 RID: 262448 RVA: 0x0106C9EA File Offset: 0x0106ABEA
		public RoverRogueRole? GetRoleConfig(int id)
		{
			return ConfigRoverRogueRoleById.GetConfig(id, true);
		}

		// Token: 0x06040131 RID: 262449 RVA: 0x0106C9F3 File Offset: 0x0106ABF3
		public RoverRogueIns? GetInsConfig(int instId)
		{
			return ConfigRoverRogueInsByInstId.GetConfig(instId, true);
		}

		// Token: 0x06040132 RID: 262450 RVA: 0x0106C9FC File Offset: 0x0106ABFC
		public IReadOnlyList<RoverRogueIns> GetInsConfigList()
		{
			return ConfigRoverRogueInsAll.GetConfigList(true) ?? new List<RoverRogueIns>();
		}

		// Token: 0x06040133 RID: 262451 RVA: 0x0106CA0D File Offset: 0x0106AC0D
		public RoverRogueBless? GetBlessConfig(int id)
		{
			return ConfigRoverRogueBlessById.GetConfig(id, true);
		}

		// Token: 0x06040134 RID: 262452 RVA: 0x0106CA16 File Offset: 0x0106AC16
		public IReadOnlyList<RoverRogueBless> GetBlessConfigList()
		{
			return ConfigRoverRogueBlessAll.GetConfigList(true) ?? new List<RoverRogueBless>();
		}

		// Token: 0x06040135 RID: 262453 RVA: 0x0106CA27 File Offset: 0x0106AC27
		public RoverRogueBlessGroup? GetBlessGroupConfig(int id)
		{
			return ConfigRoverRogueBlessGroupById.GetConfig(id, true);
		}

		// Token: 0x06040136 RID: 262454 RVA: 0x0106CA30 File Offset: 0x0106AC30
		public RoverRogueBlessRole? GetBlessRoleConfig(int id)
		{
			return ConfigRoverRogueBlessRoleById.GetConfig(id, true);
		}

		// Token: 0x06040137 RID: 262455 RVA: 0x0106CA39 File Offset: 0x0106AC39
		public IReadOnlyList<RoverRogueBlessRole> GetBlessRoleConfigListByUnlockInsId(int unlockInsId)
		{
			return ConfigRoverRogueBlessRoleByUnlockInsId.GetConfigList(unlockInsId, true) ?? new List<RoverRogueBlessRole>();
		}

		// Token: 0x06040138 RID: 262456 RVA: 0x0106CA4B File Offset: 0x0106AC4B
		public IReadOnlyList<RoverRogueBlessRole> GetBlessRoleConfigList()
		{
			return ConfigRoverRogueBlessRoleAll.GetConfigList(true) ?? new List<RoverRogueBlessRole>();
		}

		// Token: 0x06040139 RID: 262457 RVA: 0x0106CA5C File Offset: 0x0106AC5C
		public IReadOnlyList<RoverRogueRoleType> GetRoleTypeConfigList()
		{
			List<RoverRogueRoleType> list = (ConfigRoverRogueRoleTypeAll.GetConfigList(true) ?? new List<RoverRogueRoleType>()).ToList<RoverRogueRoleType>();
			list.Sort((RoverRogueRoleType a, RoverRogueRoleType b) => a.Id - b.Id);
			return list;
		}

		// Token: 0x0604013A RID: 262458 RVA: 0x0106CA98 File Offset: 0x0106AC98
		public RoverRogueRoleType? GetRoleTypeConfig(int id)
		{
			return this.GetRoleTypeConfigList().Cast<RoverRogueRoleType?>().FirstOrDefault((RoverRogueRoleType? cfg) => cfg.Value.Id == id);
		}

		// Token: 0x0604013B RID: 262459 RVA: 0x0106CACE File Offset: 0x0106ACCE
		public RoverRogueRoleEnhance? GetRoleEnhanceConfig(int id)
		{
			return ConfigRoverRogueRoleEnhanceById.GetConfig(id, true);
		}

		// Token: 0x0604013C RID: 262460 RVA: 0x0106CAD7 File Offset: 0x0106ACD7
		public IReadOnlyList<RoverRogueRoleEnhance> GetRoleEnhanceConfigList()
		{
			return ConfigRoverRogueRoleEnhanceAll.GetConfigList(true) ?? new List<RoverRogueRoleEnhance>();
		}

		// Token: 0x0604013D RID: 262461 RVA: 0x0106CAE8 File Offset: 0x0106ACE8
		public RoverRogueTalentTree? GetTalentTreeConfig(int id)
		{
			return ConfigRoverRogueTalentTreeById.GetConfig(id, true);
		}

		// Token: 0x0604013E RID: 262462 RVA: 0x0106CAF1 File Offset: 0x0106ACF1
		public RoverRogueItem? GetItemConfig(int id)
		{
			return ConfigRoverRogueItemById.GetConfig(id, true);
		}

		// Token: 0x0604013F RID: 262463 RVA: 0x0106CAFA File Offset: 0x0106ACFA
		public IReadOnlyList<RoverRogueItem> GetItemConfigList()
		{
			return ConfigRoverRogueItemAll.GetConfigList(true) ?? new List<RoverRogueItem>();
		}

		// Token: 0x06040140 RID: 262464 RVA: 0x0106CB0B File Offset: 0x0106AD0B
		public RoverRogueLoot? GetLootConfig(int id)
		{
			return ConfigRoverRogueLootById.GetConfig(id, true);
		}

		// Token: 0x06040141 RID: 262465 RVA: 0x0106CB14 File Offset: 0x0106AD14
		public IReadOnlyList<RoverRogueLoot> GetLootConfigListByActivityId(int activityId)
		{
			return ConfigRoverRogueLootByActivityId.GetConfigList(activityId, true) ?? new List<RoverRogueLoot>();
		}

		// Token: 0x06040142 RID: 262466 RVA: 0x0106CB26 File Offset: 0x0106AD26
		public RoverRogueEffect? GetEffectConfig(int id)
		{
			return ConfigRoverRogueEffectById.GetConfig(id, true);
		}

		// Token: 0x06040143 RID: 262467 RVA: 0x0106CB2F File Offset: 0x0106AD2F
		public RoverRogueQuality? GetQualityConfig(int id)
		{
			return ConfigRoverRogueQualityById.GetConfig(id, true);
		}

		// Token: 0x06040144 RID: 262468 RVA: 0x0106CB38 File Offset: 0x0106AD38
		public IReadOnlyList<RoverRogueQuality> GetQualityConfigList()
		{
			List<RoverRogueQuality> list = (ConfigRoverRogueQualityAll.GetConfigList(true) ?? new List<RoverRogueQuality>()).ToList<RoverRogueQuality>();
			list.Sort((RoverRogueQuality a, RoverRogueQuality b) => a.Id - b.Id);
			return list;
		}

		// Token: 0x06040145 RID: 262469 RVA: 0x0106CB73 File Offset: 0x0106AD73
		public RoverRogueReward? GetRewardConfig(int id)
		{
			return ConfigRoverRogueRewardById.GetConfig(id, true);
		}

		// Token: 0x06040146 RID: 262470 RVA: 0x0106CB7C File Offset: 0x0106AD7C
		public RoverRogueEventChoice? GetEventChoiceConfig(int id)
		{
			return ConfigRoverRogueEventChoiceById.GetConfig(id, true);
		}

		// Token: 0x06040147 RID: 262471 RVA: 0x0106CB85 File Offset: 0x0106AD85
		public RoverRogueRoom? GetRoomConfig(int id)
		{
			return ConfigRoverRogueRoomById.GetConfig(id, true);
		}

		// Token: 0x06040148 RID: 262472 RVA: 0x0106CB8E File Offset: 0x0106AD8E
		public RoverRogueRoomType? GetRoomTypeConfig(int id)
		{
			return ConfigRoverRogueRoomTypeById.GetConfig(id, true);
		}

		// Token: 0x06040149 RID: 262473 RVA: 0x0106CB97 File Offset: 0x0106AD97
		public IReadOnlyList<RoverRogueTalentTree> GetTalentTreeConfigList()
		{
			return ConfigRoverRogueTalentTreeAll.GetConfigList(true) ?? new List<RoverRogueTalentTree>();
		}

		// Token: 0x0604014A RID: 262474 RVA: 0x0106CBA8 File Offset: 0x0106ADA8
		public List<RoverRogueIns> GetAllLevelById(int activityId)
		{
			List<RoverRogueIns> list = new List<RoverRogueIns>();
			IEnumerable<RoverRogueIns> enumerable = this.GetInsConfigList() ?? new List<RoverRogueIns>();
			bool flag = activityId > 0;
			foreach (RoverRogueIns item in enumerable)
			{
				if (!flag || item.ActivityId == activityId)
				{
					list.Add(item);
				}
			}
			return list;
		}

		// Token: 0x0604014B RID: 262475 RVA: 0x0106CC18 File Offset: 0x0106AE18
		public IReadOnlyList<RoverRogueRoad> GetRoadByRoadType(int roadType)
		{
			return ConfigRoverRogueRoadByRoadType.GetConfigList(roadType, true) ?? new List<RoverRogueRoad>();
		}

		// Token: 0x0604014C RID: 262476 RVA: 0x0106CC2A File Offset: 0x0106AE2A
		public RoverRogueCurrency? GetCurrencyConfig(int id)
		{
			return ConfigRoverRogueCurrencyById.GetConfig(id, true);
		}
	}
}
