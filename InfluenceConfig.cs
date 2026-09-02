using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001FD7 RID: 8151
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class InfluenceConfig : ConfigBase<InfluenceConfig>
{
	// Token: 0x0600F610 RID: 62992 RVA: 0x0043624C File Offset: 0x0043444C
	public List<Country> GetCountriesByIds(int[] ids)
	{
		if (ids.Length != 0)
		{
			List<Country> list = new List<Country>();
			for (int i = 0; i < ids.Length; i++)
			{
				list.Add(ConfigCountryById.GetConfig(ids[i], true).Value);
			}
			list.Sort((Country a, Country b) => a.Id - b.Id);
			return list;
		}
		return new List<Country>();
	}

	// Token: 0x0600F611 RID: 62993 RVA: 0x004362B4 File Offset: 0x004344B4
	public List<Country> GetCountryList()
	{
		return (from value in ConfigCountryAll.GetConfigList(true)
		where value.Id != 0 && value.Id != 9999
		select value).ToList<Country>();
	}

	// Token: 0x0600F612 RID: 62994 RVA: 0x004362E8 File Offset: 0x004344E8
	public Country? GetCountryConfig(int id)
	{
		Country? config = ConfigCountryById.GetConfig(id, true);
		if (config != null)
		{
			return new Country?(config.Value);
		}
		return null;
	}

	// Token: 0x0600F613 RID: 62995 RVA: 0x0043631C File Offset: 0x0043451C
	public State? GetStateConfig(int stateId)
	{
		State? config = ConfigStateByStateId.GetConfig(stateId, true);
		if (config != null)
		{
			return new State?(config.Value);
		}
		return null;
	}

	// Token: 0x0600F614 RID: 62996 RVA: 0x00436350 File Offset: 0x00434550
	public List<Influence> GetCountryInfluence(int id)
	{
		List<Influence> list = new List<Influence>();
		if (id == 0)
		{
			Influence? influenceConfig = this.GetInfluenceConfig(0);
			if (influenceConfig != null)
			{
				list.Add(influenceConfig.Value);
			}
		}
		else
		{
			Country? countryConfig = this.GetCountryConfig(id);
			if (countryConfig == null)
			{
				return list;
			}
			if (countryConfig.Value.Influences().Length == 0)
			{
				IReadOnlyList<Influence> configList = ConfigInfluenceAll.GetConfigList(true);
				for (int i = 0; i < configList.Count; i++)
				{
					list.Add(configList[i]);
				}
			}
			else
			{
				for (int j = 0; j < countryConfig.Value.Influences().Length; j++)
				{
					Influence? influenceConfig2 = this.GetInfluenceConfig(countryConfig.Value.Influences()[j]);
					if (influenceConfig2 != null)
					{
						list.Add(influenceConfig2.Value);
					}
				}
			}
		}
		return list;
	}

	// Token: 0x0600F615 RID: 62997 RVA: 0x00436434 File Offset: 0x00434634
	public string GetCountryTitle(int id)
	{
		Country? countryConfig = this.GetCountryConfig(id);
		if (countryConfig != null)
		{
			return ConfigMultiTextLang.GetLocalTextNew(countryConfig.Value.Title, null);
		}
		return "";
	}

	// Token: 0x0600F616 RID: 62998 RVA: 0x00436470 File Offset: 0x00434670
	public Influence? GetInfluenceConfig(int id)
	{
		Influence? config = ConfigInfluenceById.GetConfig(id, true);
		if (config != null)
		{
			return new Influence?(config.Value);
		}
		return null;
	}

	// Token: 0x0600F617 RID: 62999 RVA: 0x004364A4 File Offset: 0x004346A4
	public string GetInfluenceTitle(int id)
	{
		Influence? influenceConfig = this.GetInfluenceConfig(id);
		if (influenceConfig != null)
		{
			return ConfigMultiTextLang.GetLocalTextNew(influenceConfig.Value.Title, null);
		}
		return "";
	}

	// Token: 0x0600F618 RID: 63000 RVA: 0x004364E0 File Offset: 0x004346E0
	public bool GetInfluenceIfShowInDailyTask(int influenceId)
	{
		Influence? influenceConfig = this.GetInfluenceConfig(influenceId);
		return influenceConfig != null && influenceConfig.Value.DailyTaskShow == 1;
	}

	// Token: 0x0600F619 RID: 63001 RVA: 0x00436514 File Offset: 0x00434714
	public bool GetCountryIfShowInDailyTask(int countryId)
	{
		Country? countryConfig = this.GetCountryConfig(countryId);
		return countryConfig != null && countryConfig.Value.DailyTaskShow == 1;
	}
}
