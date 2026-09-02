using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using FilterDefine;

// Token: 0x02001900 RID: 6400
[NullableContext(1)]
[Nullable(0)]
public class FilterResultData : IStaticVariableResetter
{
	// Token: 0x0600B7A7 RID: 47015 RVA: 0x0030D998 File Offset: 0x0030BB98
	static FilterResultData()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(FilterResultData.CreateStaticDefaultValue), new Action(FilterResultData.ResetStaticDefaultValue));
	}

	// Token: 0x0600B7A8 RID: 47016 RVA: 0x0030D9B7 File Offset: 0x0030BBB7
	public static void CreateStaticDefaultValue()
	{
		FilterResultData.IncrementId = 0;
	}

	// Token: 0x0600B7A9 RID: 47017 RVA: 0x0030D9BF File Offset: 0x0030BBBF
	public static void ResetStaticDefaultValue()
	{
		FilterResultData.IncrementId = 0;
	}

	// Token: 0x17000EF9 RID: 3833
	// (get) Token: 0x0600B7AA RID: 47018 RVA: 0x0030D9C7 File Offset: 0x0030BBC7
	public int ConfigId
	{
		get
		{
			return this.ConfigIdInternal;
		}
	}

	// Token: 0x0600B7AB RID: 47019 RVA: 0x0030D9CF File Offset: 0x0030BBCF
	public FilterResultData()
	{
		this.UniqueId = ++FilterResultData.IncrementId;
	}

	// Token: 0x0600B7AC RID: 47020 RVA: 0x0030D9FC File Offset: 0x0030BBFC
	public void SetConfigId(int configId)
	{
		this.ConfigIdInternal = configId;
	}

	// Token: 0x0600B7AD RID: 47021 RVA: 0x0030DA08 File Offset: 0x0030BC08
	public void AddSingleRuleData(FilterDefine.EFilterType filterType, int key, string value)
	{
		Dictionary<int, string> dictionary;
		if (!this.SelectRuleMap.TryGetValue(filterType, out dictionary))
		{
			dictionary = new Dictionary<int, string>();
		}
		dictionary[key] = value;
		this.SelectRuleMap[filterType] = dictionary;
	}

	// Token: 0x0600B7AE RID: 47022 RVA: 0x0030DA40 File Offset: 0x0030BC40
	public void SetSelectRuleData(FilterDefine.EFilterType filterType, Dictionary<int, string> filterIdSet)
	{
		this.SelectRuleMap[filterType] = filterIdSet;
	}

	// Token: 0x0600B7AF RID: 47023 RVA: 0x0030DA4F File Offset: 0x0030BC4F
	public void SetRuleData(Dictionary<FilterDefine.EFilterType, Dictionary<int, string>> data)
	{
		this.SelectRuleMap = data;
	}

	// Token: 0x0600B7B0 RID: 47024 RVA: 0x0030DA58 File Offset: 0x0030BC58
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public Dictionary<int, string> GetSelectRuleDataById(FilterDefine.EFilterType filterType)
	{
		Dictionary<int, string> result;
		if (this.SelectRuleMap.TryGetValue(filterType, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x0600B7B1 RID: 47025 RVA: 0x0030DA78 File Offset: 0x0030BC78
	public Dictionary<FilterDefine.EFilterType, Dictionary<int, string>> GetSelectRuleData()
	{
		return this.SelectRuleMap;
	}

	// Token: 0x0600B7B2 RID: 47026 RVA: 0x0030DA80 File Offset: 0x0030BC80
	public void ClearSelectRuleData()
	{
		this.SelectRuleMap.Clear();
	}

	// Token: 0x0600B7B3 RID: 47027 RVA: 0x0030DA90 File Offset: 0x0030BC90
	public string ShowAllFilterContent()
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (Dictionary<int, string> dictionary in this.SelectRuleMap.Values)
		{
			foreach (KeyValuePair<int, string> keyValuePair in dictionary)
			{
				int key = keyValuePair.Key;
				string value = keyValuePair.Value;
				int mainAttributeCost = ModelBase<PhantomBattleModel>.Instance.GetMainAttributeCost(key);
				string value2 = value;
				if (mainAttributeCost != 0)
				{
					string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey("PhantomFilterCostSuffix");
					value2 = value + StringUtils.Format(configTextByKey, new string[]
					{
						mainAttributeCost.ToString()
					});
				}
				stringBuilder.Append(value2);
				stringBuilder.Append(',');
			}
		}
		stringBuilder.Length = ((stringBuilder.Length > 0) ? (stringBuilder.Length - 1) : 0);
		return stringBuilder.ToString();
	}

	// Token: 0x0600B7B4 RID: 47028 RVA: 0x0030DBAC File Offset: 0x0030BDAC
	public FilterStorageData ConvertToStorageData()
	{
		Dictionary<FilterDefine.EFilterType, List<int>> dictionary = new Dictionary<FilterDefine.EFilterType, List<int>>();
		foreach (KeyValuePair<FilterDefine.EFilterType, Dictionary<int, string>> keyValuePair in this.SelectRuleMap)
		{
			List<int> list = new List<int>();
			foreach (int item in keyValuePair.Value.Keys)
			{
				list.Add(item);
			}
			dictionary.Add(keyValuePair.Key, list);
		}
		return new FilterStorageData
		{
			ConfigId = this.ConfigId,
			SelectRuleMap = dictionary
		};
	}

	// Token: 0x040056A1 RID: 22177
	private static int IncrementId;

	// Token: 0x040056A2 RID: 22178
	private int ConfigIdInternal;

	// Token: 0x040056A3 RID: 22179
	private Dictionary<FilterDefine.EFilterType, Dictionary<int, string>> SelectRuleMap = new Dictionary<FilterDefine.EFilterType, Dictionary<int, string>>();

	// Token: 0x040056A4 RID: 22180
	public readonly int UniqueId = -1;
}
