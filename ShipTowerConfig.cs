using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002982 RID: 10626
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ShipTowerConfig : ConfigBase<ShipTowerConfig>
{
	// Token: 0x060152D7 RID: 86743 RVA: 0x005DD3F8 File Offset: 0x005DB5F8
	public SlashAndTowerCfg? GetStageCfgById(int id)
	{
		return new SlashAndTowerCfg?(ConfigSlashAndTowerCfgById.GetConfig(id, true).Value);
	}

	// Token: 0x060152D8 RID: 86744 RVA: 0x005DD419 File Offset: 0x005DB619
	public IReadOnlyList<SlashTowerShowStage> GetAllShowStageCfg()
	{
		return ConfigSlashTowerShowStageAll.GetConfigList(true);
	}

	// Token: 0x060152D9 RID: 86745 RVA: 0x005DD424 File Offset: 0x005DB624
	public SlashTowerStageInfo? GetStageInfoCfgByInstId(int instId)
	{
		return new SlashTowerStageInfo?(ConfigSlashTowerStageInfoByInstId.GetConfig(instId, true).Value);
	}

	// Token: 0x060152DA RID: 86746 RVA: 0x005DD445 File Offset: 0x005DB645
	public IReadOnlyList<SlashAndTowerCfg> GetStageCfgBySeason(int season)
	{
		return ConfigSlashAndTowerCfgBySeason.GetConfigList(season, true);
	}

	// Token: 0x060152DB RID: 86747 RVA: 0x005DD44E File Offset: 0x005DB64E
	public IReadOnlyList<SlashAndTowerReward> GetChallengeRewardCfgBySeason(int season)
	{
		return ConfigSlashAndTowerRewardByBelongToSeason.GetConfigList(season, true);
	}

	// Token: 0x060152DC RID: 86748 RVA: 0x005DD457 File Offset: 0x005DB657
	public IReadOnlyList<SlashBuffToItem> GetAllBuffCfg()
	{
		return ConfigSlashBuffToItemAll.GetConfigList(true);
	}

	// Token: 0x060152DD RID: 86749 RVA: 0x005DD460 File Offset: 0x005DB660
	public SlashBuffToItem? GetBuffCfgById(int id)
	{
		return new SlashBuffToItem?(ConfigSlashBuffToItemById.GetConfig(id, true).Value);
	}

	// Token: 0x060152DE RID: 86750 RVA: 0x005DD484 File Offset: 0x005DB684
	public SlashBuffToItem? GetBuffCfgByItemId(int itemId)
	{
		return new SlashBuffToItem?(ConfigSlashBuffToItemByItemId.GetConfig(itemId, true).Value);
	}

	// Token: 0x060152DF RID: 86751 RVA: 0x005DD4A5 File Offset: 0x005DB6A5
	public IReadOnlyList<SlashBuffToItem> GetBuffCfgBySeason(int season)
	{
		return ConfigSlashBuffToItemBySeason.GetConfigList(season, true);
	}

	// Token: 0x060152E0 RID: 86752 RVA: 0x005DD4B0 File Offset: 0x005DB6B0
	public SlashBuffToItem? GetBuffCfgByItemIdAndSeason(int itemId, int season)
	{
		return new SlashBuffToItem?(ConfigSlashBuffToItemByItemIdAndSeason.GetConfig(itemId, season, true).Value);
	}

	// Token: 0x060152E1 RID: 86753 RVA: 0x005DD4D2 File Offset: 0x005DB6D2
	public IReadOnlyList<SlashBuffToItem> GetBuffCfgByItemIdList(int itemId)
	{
		return ConfigSlashBuffToItemByItemIdList.GetConfigList(itemId, true);
	}

	// Token: 0x060152E2 RID: 86754 RVA: 0x005DD4DC File Offset: 0x005DB6DC
	public SlashTowerTagInfo? GetWordInfoCfgById(int id)
	{
		return new SlashTowerTagInfo?(ConfigSlashTowerTagInfoById.GetConfig(id, true).Value);
	}

	// Token: 0x060152E3 RID: 86755 RVA: 0x005DD500 File Offset: 0x005DB700
	public SlashAndTowerSeason? GetSeasonCfgById(int id)
	{
		return new SlashAndTowerSeason?(ConfigSlashAndTowerSeasonById.GetConfig(id, true).Value);
	}
}
