using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002785 RID: 10117
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class RoguelikeConfig : ConfigBase<RoguelikeConfig>
{
	// Token: 0x06013F3B RID: 81723 RVA: 0x005901F3 File Offset: 0x0058E3F3
	public RogueBuffPool? GetRogueBuffConfig(int id)
	{
		return ConfigRogueBuffPoolById.GetConfig(id, true);
	}

	// Token: 0x06013F3C RID: 81724 RVA: 0x005901FC File Offset: 0x0058E3FC
	public RogueCharacter? GetRogueCharacterConfig(int id)
	{
		return ConfigRogueCharacterById.GetConfig(id, true);
	}

	// Token: 0x06013F3D RID: 81725 RVA: 0x00590208 File Offset: 0x0058E408
	public RoguePokemon? GetRoguePhantomConfig(int id)
	{
		if (id == 0)
		{
			return null;
		}
		return ConfigRoguePokemonById.GetConfig(id, true);
	}

	// Token: 0x06013F3E RID: 81726 RVA: 0x00590229 File Offset: 0x0058E429
	public RogueAffix? GetRogueAffixConfig(int id)
	{
		return ConfigRogueAffixById.GetConfig(id, true);
	}

	// Token: 0x06013F3F RID: 81727 RVA: 0x00590232 File Offset: 0x0058E432
	public RogueCharacterBuff? GetRogueCharacterBuffConfig(int id)
	{
		return ConfigRogueCharacterBuffById.GetConfig(id, true);
	}

	// Token: 0x06013F40 RID: 81728 RVA: 0x0059023B File Offset: 0x0058E43B
	public IReadOnlyList<RogueTalentTree> GetRogueTalentTreeConfig()
	{
		return ConfigRogueTalentTreeAll.GetConfigList(true) ?? Array.Empty<RogueTalentTree>();
	}

	// Token: 0x06013F41 RID: 81729 RVA: 0x0059024C File Offset: 0x0058E44C
	public RogueTalentTree? GetRogueTalentTreeById(int id)
	{
		return ConfigRogueTalentTreeById.GetConfig(id, true);
	}

	// Token: 0x06013F42 RID: 81730 RVA: 0x00590255 File Offset: 0x0058E455
	public RogueTalentTreeDesc? GetRogueTalentTreeDescConfig(int id)
	{
		return ConfigRogueTalentTreeDescById.GetConfig(id, true);
	}

	// Token: 0x06013F43 RID: 81731 RVA: 0x0059025E File Offset: 0x0058E45E
	public RogueParam? GetRogueParamConfig(int id = 1)
	{
		return ConfigRogueParamById.GetConfig(id, true);
	}

	// Token: 0x06013F44 RID: 81732 RVA: 0x00590267 File Offset: 0x0058E467
	public RogueCurrency? GetRogueCurrencyConfig(int id)
	{
		return ConfigRogueCurrencyById.GetConfig(id, true);
	}

	// Token: 0x06013F45 RID: 81733 RVA: 0x00590270 File Offset: 0x0058E470
	public IReadOnlyList<RogueSeasonReward> GetRogueSeasonReward(int seasonId)
	{
		return ConfigRogueSeasonRewardBySeasonId.GetConfigList(seasonId, true);
	}

	// Token: 0x06013F46 RID: 81734 RVA: 0x00590279 File Offset: 0x0058E479
	public IReadOnlyList<RogueToken> GetRogueTokenBySeasonId(int seasonId = 0)
	{
		return ConfigRogueTokenBySeasonId.GetConfigList(seasonId, true);
	}

	// Token: 0x06013F47 RID: 81735 RVA: 0x00590282 File Offset: 0x0058E482
	public RogueSeason? GetRogueSeasonConfigById(int id)
	{
		return ConfigRogueSeasonById.GetConfig(id, true);
	}

	// Token: 0x06013F48 RID: 81736 RVA: 0x0059028B File Offset: 0x0058E48B
	public IReadOnlyList<RogueSeason> GetRogueSeasonConfigList()
	{
		return ConfigRogueSeasonAll.GetConfigList(true);
	}

	// Token: 0x06013F49 RID: 81737 RVA: 0x00590293 File Offset: 0x0058E493
	public RogueEvent? GetRogueEventConfigById(int id)
	{
		return ConfigRogueEventById.GetConfig(id, true);
	}

	// Token: 0x06013F4A RID: 81738 RVA: 0x0059029C File Offset: 0x0058E49C
	public RogueQualityConfig? GetRogueQualityConfigByQualityId(int id)
	{
		return ConfigRogueQualityConfigById.GetConfig(id, true);
	}

	// Token: 0x06013F4B RID: 81739 RVA: 0x005902A5 File Offset: 0x0058E4A5
	public ElementLevel? GetElementLevelConfigById(int level)
	{
		return ConfigElementLevelByLevel.GetConfig(level, true);
	}

	// Token: 0x06013F4C RID: 81740 RVA: 0x005902AE File Offset: 0x0058E4AE
	public RogueRoomType? GetRoguelikeRoomTypeConfigById(int id)
	{
		return ConfigRogueRoomTypeById.GetConfig(id, true);
	}

	// Token: 0x06013F4D RID: 81741 RVA: 0x005902B7 File Offset: 0x0058E4B7
	public RougePopularEntrie? GetRoguelikePopularEntriesById(int id)
	{
		return ConfigRougePopularEntrieById.GetConfig(id, true);
	}

	// Token: 0x06013F4E RID: 81742 RVA: 0x005902C0 File Offset: 0x0058E4C0
	public IReadOnlyList<RougePopularEntrie> GetRoguelikePopularEntries()
	{
		return ConfigRougePopularEntrieAll.GetConfigList(true);
	}

	// Token: 0x06013F4F RID: 81743 RVA: 0x005902C8 File Offset: 0x0058E4C8
	public RougeMiraclecreation? GetRoguelikeSpecialConfig(int id)
	{
		return ConfigRougeMiraclecreationById.GetConfig(id, true);
	}

	// Token: 0x06013F50 RID: 81744 RVA: 0x005902D1 File Offset: 0x0058E4D1
	public RougeMiraclecreationColor? GetRoguelikeMiraclecreationColorConfig(int id)
	{
		return ConfigRougeMiraclecreationColorById.GetConfig(id, true);
	}

	// Token: 0x06013F51 RID: 81745 RVA: 0x005902DA File Offset: 0x0058E4DA
	public RoguePopularEntrieArg? GetRoguePopularEntrieArg(int seasonId, int instanceId)
	{
		return ConfigRoguePopularEntrieArgBySeasonIdAndInstId.GetConfig(seasonId, instanceId, true);
	}

	// Token: 0x06013F52 RID: 81746 RVA: 0x005902E4 File Offset: 0x0058E4E4
	public RogueRoomShowConfig? GetRogueRoomShowConfig(int roomId)
	{
		return ConfigRogueRoomShowConfigById.GetConfig(roomId, true);
	}

	// Token: 0x06013F53 RID: 81747 RVA: 0x005902ED File Offset: 0x0058E4ED
	public RogueRoomPool? GetRoguelikeRoomPoolConfig(int id)
	{
		return ConfigRogueRoomPoolById.GetConfig(id, true);
	}

	// Token: 0x06013F54 RID: 81748 RVA: 0x005902F6 File Offset: 0x0058E4F6
	public RogueInst? GetRogueInstConfig(int instanceId)
	{
		return ConfigRogueInstByInstId.GetConfig(instanceId, true);
	}

	// Token: 0x06013F55 RID: 81749 RVA: 0x005902FF File Offset: 0x0058E4FF
	public RogueHotEntryGroup? GetRogueHotEntryGroupConfig(int groupId)
	{
		return ConfigRogueHotEntryGroupByGroupId.GetConfig(groupId, true);
	}

	// Token: 0x06013F56 RID: 81750 RVA: 0x00590308 File Offset: 0x0058E508
	public RogueHotEntry? GetRogueHotEntryConfig(int id)
	{
		return ConfigRogueHotEntryById.GetConfig(id, true);
	}

	// Token: 0x06013F57 RID: 81751 RVA: 0x00590311 File Offset: 0x0058E511
	public RogueHotEntryOverview? GetRogueHotEntryOverviewConfig(int id)
	{
		return ConfigRogueHotEntryOverviewById.GetConfig(id, true);
	}

	// Token: 0x06013F58 RID: 81752 RVA: 0x0059031A File Offset: 0x0058E51A
	public RogueHotEntryType? GetRogueHotEntryTypeConfig(int id)
	{
		return ConfigRogueHotEntryTypeById.GetConfig(id, true);
	}

	// Token: 0x06013F59 RID: 81753 RVA: 0x00590323 File Offset: 0x0058E523
	public RogueSkill? GetRogueSkillConfig(int id)
	{
		return ConfigRogueSkillById.GetConfig(id, true);
	}

	// Token: 0x06013F5A RID: 81754 RVA: 0x0059032C File Offset: 0x0058E52C
	public RogueTower? GetRogueTowerConfig(int id)
	{
		return ConfigRogueTowerById.GetConfig(id, true);
	}

	// Token: 0x06013F5B RID: 81755 RVA: 0x00590335 File Offset: 0x0058E535
	public RogueTowerBuff? GetRogueTowerBuffConfig(int id)
	{
		return ConfigRogueTowerBuffById.GetConfig(id, true);
	}
}
