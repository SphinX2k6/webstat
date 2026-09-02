using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020025F7 RID: 9719
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class PlayerInfoConfig : ConfigBase<PlayerInfoConfig>
{
	// Token: 0x060130A7 RID: 77991 RVA: 0x005476F8 File Offset: 0x005458F8
	public bool GetIsUseAccountName()
	{
		return ConfigCommonParamById.GetBoolConfig("player_use_accountname").GetValueOrDefault(true);
	}

	// Token: 0x060130A8 RID: 77992 RVA: 0x00547718 File Offset: 0x00545918
	public string GetMaleIconPath()
	{
		return ConfigCommonParamById.GetStringConfig("player_male_headicon");
	}

	// Token: 0x060130A9 RID: 77993 RVA: 0x00547724 File Offset: 0x00545924
	public string GetFemaleIconPath()
	{
		return ConfigCommonParamById.GetStringConfig("player_female_headicon");
	}

	// Token: 0x060130AA RID: 77994 RVA: 0x00547730 File Offset: 0x00545930
	public string GetMaleStandPath()
	{
		return ConfigCommonParamById.GetStringConfig("player_male_stand");
	}

	// Token: 0x060130AB RID: 77995 RVA: 0x0054773C File Offset: 0x0054593C
	public string GetFemaleStandPath()
	{
		return ConfigCommonParamById.GetStringConfig("player_female_stand");
	}

	// Token: 0x060130AC RID: 77996 RVA: 0x00547748 File Offset: 0x00545948
	[NullableContext(1)]
	public string GetPlayerBigIconPath(int iconId)
	{
		return ConfigHeadIconById.GetConfig(iconId, true).Value.BigIconPath;
	}

	// Token: 0x060130AD RID: 77997 RVA: 0x0054776C File Offset: 0x0054596C
	public string GetPlayerIconPath(int iconId)
	{
		HeadIcon? config = ConfigHeadIconById.GetConfig(iconId, true);
		if (config == null)
		{
			return null;
		}
		return config.GetValueOrDefault().IconPath;
	}
}
