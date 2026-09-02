using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x0200142D RID: 5165
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class MowingTowerConfig : ConfigBase<MowingTowerConfig>
{
	// Token: 0x06008FA1 RID: 36769 RVA: 0x0025B59F File Offset: 0x0025979F
	public MowTowerLevelsRe? GetBossMowingTowerConfigById(int id)
	{
		return ConfigMowTowerLevelsReById.GetConfig(id, true);
	}

	// Token: 0x06008FA2 RID: 36770 RVA: 0x0025B5A8 File Offset: 0x002597A8
	public MowTowerRewardRe? GetMowingTowerRewardById(int id)
	{
		return ConfigMowTowerRewardReById.GetConfig(id, true);
	}

	// Token: 0x06008FA3 RID: 36771 RVA: 0x0025B5B1 File Offset: 0x002597B1
	public MowTowerBuffRe? GetMowingTowerBuffById(int id)
	{
		return ConfigMowTowerBuffReById.GetConfig(id, true);
	}
}
