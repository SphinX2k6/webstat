using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001950 RID: 6480
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class SortConfig : ConfigBase<SortConfig>
{
	// Token: 0x0600B9DB RID: 47579 RVA: 0x00318588 File Offset: 0x00316788
	public Sort? GetSortConfig(int configId)
	{
		Sort? config = ConfigSortById.GetConfig(configId, true);
		if (config != null)
		{
			return new Sort?(config.Value);
		}
		return null;
	}

	// Token: 0x0600B9DC RID: 47580 RVA: 0x003185BC File Offset: 0x003167BC
	public string GetSortRuleName(int ruleId, ESortDataType dataType)
	{
		SortRule? config = ConfigSortRuleByIdAndDataId.GetConfig(ruleId, (int)dataType, true);
		if (config != null)
		{
			return ConfigMultiTextLang.GetLocalTextNew(config.Value.Name, null) ?? "";
		}
		return "";
	}

	// Token: 0x0600B9DD RID: 47581 RVA: 0x00318600 File Offset: 0x00316800
	public string GetSortRuleIcon(int ruleId, ESortDataType dataType)
	{
		SortRule? config = ConfigSortRuleByIdAndDataId.GetConfig(ruleId, (int)dataType, true);
		if (config != null)
		{
			return config.Value.Icon;
		}
		return "";
	}

	// Token: 0x0600B9DE RID: 47582 RVA: 0x00318634 File Offset: 0x00316834
	public int GetSortRuleAddType(int ruleId, ESortDataType dataType)
	{
		SortRule? config = ConfigSortRuleByIdAndDataId.GetConfig(ruleId, (int)dataType, true);
		if (config != null)
		{
			return config.Value.AddType;
		}
		return 0;
	}

	// Token: 0x0600B9DF RID: 47583 RVA: 0x00318664 File Offset: 0x00316864
	public int GetSortRuleAttributeId(int ruleId, ESortDataType dataType)
	{
		SortRule? config = ConfigSortRuleByIdAndDataId.GetConfig(ruleId, (int)dataType, true);
		if (config != null)
		{
			return config.Value.AttributeId;
		}
		return 0;
	}

	// Token: 0x0600B9E0 RID: 47584 RVA: 0x00318694 File Offset: 0x00316894
	public int GetSortId(EFilterSortGroupId groupId)
	{
		FilterSortGroup? config = ConfigFilterSortGroupById.GetConfig((int)groupId, true);
		if (config != null)
		{
			return config.Value.SortId;
		}
		return 0;
	}

	// Token: 0x0600B9E1 RID: 47585 RVA: 0x003186C4 File Offset: 0x003168C4
	public bool IsConfigSortSave(EFilterSortConfigId configId, int groupId)
	{
		FilterSortConfig? config = ConfigFilterSortConfigById.GetConfig((int)configId, true);
		return config != null && config.Value.SaveGroupId().Contains(groupId);
	}

	// Token: 0x0600B9E2 RID: 47586 RVA: 0x003186FC File Offset: 0x003168FC
	public string GetConfigSortFormatId(EFilterSortConfigId configId, int groupId, string extraParam = "")
	{
		int num = (int)configId;
		string text = num.ToString() + "_" + groupId.ToString();
		if (!StringUtils.IsBlank(extraParam))
		{
			text = text + "_" + extraParam;
		}
		return text;
	}

	// Token: 0x0600B9E3 RID: 47587 RVA: 0x0031873C File Offset: 0x0031693C
	public FilterSortConfig GetSortFilterConfig(EFilterSortConfigId configId)
	{
		FilterSortConfig? config = ConfigFilterSortConfigById.GetConfig((int)configId, true);
		if (config != null)
		{
			return config.Value;
		}
		return default(FilterSortConfig);
	}
}
