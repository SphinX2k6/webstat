using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020025FA RID: 9722
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class PowerConfig : ConfigBase<PowerConfig>
{
	// Token: 0x060130DD RID: 78045 RVA: 0x00548458 File Offset: 0x00546658
	public Dictionary<int, int> GetConfSortRule()
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		string[] array = ConfigCommonParamById.GetStringConfig("energy_sort").Split(',', StringSplitOptions.None);
		for (int i = 0; i < array.Length; i++)
		{
			string[] array2 = array[i].Split(':', StringSplitOptions.None);
			int key = int.Parse(array2[0]);
			int value = int.Parse(array2[1]);
			dictionary.Add(key, value);
		}
		return dictionary;
	}

	// Token: 0x060130DE RID: 78046 RVA: 0x005484B4 File Offset: 0x005466B4
	public int GetPowerNaturalLimit()
	{
		return ConfigCommonParamById.GetIntConfig("renew_energy_limit").GetValueOrDefault();
	}

	// Token: 0x060130DF RID: 78047 RVA: 0x005484D4 File Offset: 0x005466D4
	public int GetPowerChargeLimit()
	{
		return ConfigCommonParamById.GetIntConfig("charge_energy_limit").GetValueOrDefault();
	}

	// Token: 0x060130E0 RID: 78048 RVA: 0x005484F4 File Offset: 0x005466F4
	public int GetPowerIncreaseSpan()
	{
		return ConfigCommonParamById.GetIntConfig("renew_energy_timespan").GetValueOrDefault();
	}

	// Token: 0x060130E1 RID: 78049 RVA: 0x00548514 File Offset: 0x00546714
	public int GetOverPowerLimit()
	{
		return ConfigCommonParamById.GetIntConfig("store_energy_limit").GetValueOrDefault();
	}

	// Token: 0x060130E2 RID: 78050 RVA: 0x00548534 File Offset: 0x00546734
	public int GetOverPowerRecoverTimeSpan()
	{
		return ConfigCommonParamById.GetIntConfig("store_energy_timespan").GetValueOrDefault();
	}

	// Token: 0x060130E3 RID: 78051 RVA: 0x00548554 File Offset: 0x00546754
	public int GetSingleTimeExchangePowerLimit()
	{
		return ConfigCommonParamById.GetIntConfig("single_time_get_max").GetValueOrDefault();
	}

	// Token: 0x060130E4 RID: 78052 RVA: 0x00548573 File Offset: 0x00546773
	public IReadOnlyList<int> GetPowerCurrencyIds()
	{
		return ConfigCommonParamById.GetIntArrayConfig("PowerTipsIdArray") ?? new <>z__ReadOnlySingleElementList<int>(0);
	}

	// Token: 0x060130E5 RID: 78053 RVA: 0x0054858C File Offset: 0x0054678C
	public HashSet<int> GetPowerShopIds()
	{
		if (this.PowerShopIds.Count != 0)
		{
			return this.PowerShopIds;
		}
		foreach (object obj in Enum.GetValues(typeof(EPowerShopType)))
		{
			EPowerShopType item = (EPowerShopType)obj;
			this.PowerShopIds.Add((int)item);
		}
		return this.PowerShopIds;
	}

	// Token: 0x040094AD RID: 38061
	private readonly HashSet<int> PowerShopIds = new HashSet<int>();
}
