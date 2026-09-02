using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002036 RID: 8246
[NullableContext(1)]
[Nullable(0)]
public class PhantomManageConfigData
{
	// Token: 0x0600FB20 RID: 64288 RVA: 0x0044F158 File Offset: 0x0044D358
	public PhantomManageConfigData(int index)
	{
		this.Index = index;
		this.Name = ConfigBase<TextConfig>.Instance.GetMultiText("PhantomProject_EmptyProject", Array.Empty<string>());
		int filterIdConst = ModelBase<InventoryModel>.Instance.GetFilterIdConst();
		foreach (int key in ConfigBase<FilterConfig>.Instance.GetFilterConfig(filterIdConst).Value.RuleList())
		{
			this.RuleIdMapValueList.Add(key, Array.Empty<int>());
		}
		this.Name = ConfigBase<TextConfig>.Instance.GetMultiText("PhantomProject_EmptyProject", Array.Empty<string>());
	}

	// Token: 0x0600FB21 RID: 64289 RVA: 0x0044F210 File Offset: 0x0044D410
	public void SetDisplayIndex(int displayIndex)
	{
		this.DisplayIndex = displayIndex;
	}

	// Token: 0x0600FB22 RID: 64290 RVA: 0x0044F219 File Offset: 0x0044D419
	public int GetDisplayIndex()
	{
		return this.DisplayIndex;
	}

	// Token: 0x0600FB23 RID: 64291 RVA: 0x0044F221 File Offset: 0x0044D421
	public int GetIndex()
	{
		return this.Index;
	}

	// Token: 0x0600FB24 RID: 64292 RVA: 0x0044F22C File Offset: 0x0044D42C
	public string GetIndexString()
	{
		int num = this.Index + 1;
		if (num >= 10)
		{
			return num.ToString();
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendLiteral("0");
		defaultInterpolatedStringHandler.AppendFormatted<int>(num);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0600FB25 RID: 64293 RVA: 0x0044F273 File Offset: 0x0044D473
	public bool GetIsOn()
	{
		return this.IsOn;
	}

	// Token: 0x0600FB26 RID: 64294 RVA: 0x0044F27B File Offset: 0x0044D47B
	public void SetIsOn(bool isOn)
	{
		this.IsOn = isOn;
	}

	// Token: 0x0600FB27 RID: 64295 RVA: 0x0044F284 File Offset: 0x0044D484
	public string GetName()
	{
		return this.Name;
	}

	// Token: 0x0600FB28 RID: 64296 RVA: 0x0044F28C File Offset: 0x0044D48C
	public void SetName(string name)
	{
		this.Name = name;
	}

	// Token: 0x0600FB29 RID: 64297 RVA: 0x0044F295 File Offset: 0x0044D495
	public new PhantomSettingType GetType()
	{
		return this.Type;
	}

	// Token: 0x0600FB2A RID: 64298 RVA: 0x0044F2A0 File Offset: 0x0044D4A0
	public int[] GetValueListByRuleId(int ruleId)
	{
		int[] result;
		if (this.RuleIdMapValueList.TryGetValue(ruleId, out result))
		{
			return result;
		}
		return Array.Empty<int>();
	}

	// Token: 0x0600FB2B RID: 64299 RVA: 0x0044F2C4 File Offset: 0x0044D4C4
	public Dictionary<int, int[]> GetRuleIdMapValueList()
	{
		return new Dictionary<int, int[]>(this.RuleIdMapValueList);
	}

	// Token: 0x0600FB2C RID: 64300 RVA: 0x0044F2D4 File Offset: 0x0044D4D4
	public void SetRuleIdMapValueList(Dictionary<int, int[]> map)
	{
		this.RuleIdMapValueList.Clear();
		this.RuleIdMapValueList.Clear();
		int filterIdConst = ModelBase<InventoryModel>.Instance.GetFilterIdConst();
		foreach (int key in ConfigBase<FilterConfig>.Instance.GetFilterConfig(filterIdConst).Value.RuleList())
		{
			int[] value;
			if (map.TryGetValue(key, out value))
			{
				this.RuleIdMapValueList.Add(key, value);
			}
			else
			{
				this.RuleIdMapValueList.Add(key, Array.Empty<int>());
			}
		}
	}

	// Token: 0x0600FB2D RID: 64301 RVA: 0x0044F365 File Offset: 0x0044D565
	public void SetType(PhantomSettingType type)
	{
		this.Type = type;
	}

	// Token: 0x0600FB2E RID: 64302 RVA: 0x0044F370 File Offset: 0x0044D570
	public bool IsEmpty()
	{
		if (this.RuleIdMapValueList.Count == 0)
		{
			return true;
		}
		using (Dictionary<int, int[]>.ValueCollection.Enumerator enumerator = this.RuleIdMapValueList.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Length != 0)
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x0600FB2F RID: 64303 RVA: 0x0044F3DC File Offset: 0x0044D5DC
	public bool IsEqual(bool editSwitch, [Nullable(new byte[]
	{
		2,
		1
	})] Dictionary<int, int[]> editData)
	{
		if (editData == null || editSwitch != this.IsOn)
		{
			return false;
		}
		foreach (KeyValuePair<int, int[]> keyValuePair in this.RuleIdMapValueList)
		{
			int[] array;
			if (!editData.TryGetValue(keyValuePair.Key, out array))
			{
				return false;
			}
			if (array.Length != keyValuePair.Value.Length)
			{
				return false;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != keyValuePair.Value[i])
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x0600FB30 RID: 64304 RVA: 0x0044F488 File Offset: 0x0044D688
	public void Parse(OnePhantomSetting setting)
	{
		this.Reset(true, true);
		this.IsOn = setting.On;
		this.Name = setting.Name;
		this.Index = setting.Index;
		foreach (OneItemFilterRule oneItemFilterRule in setting.RuleList)
		{
			if (this.RuleIdMapValueList.ContainsKey(oneItemFilterRule.FilterRuleId))
			{
				this.RuleIdMapValueList[oneItemFilterRule.FilterRuleId] = oneItemFilterRule.IdList.ToArray<int>();
			}
			else
			{
				this.RuleIdMapValueList.Add(oneItemFilterRule.FilterRuleId, oneItemFilterRule.IdList.ToArray<int>());
			}
		}
	}

	// Token: 0x0600FB31 RID: 64305 RVA: 0x0044F548 File Offset: 0x0044D748
	public OnePhantomSetting Integrate()
	{
		List<OneItemFilterRule> list = new List<OneItemFilterRule>();
		foreach (KeyValuePair<int, int[]> keyValuePair in this.RuleIdMapValueList)
		{
			OneItemFilterRule oneItemFilterRule = OneItemFilterRule.Create();
			oneItemFilterRule.FilterRuleId = keyValuePair.Key;
			oneItemFilterRule.IdList.AddRange(keyValuePair.Value);
			list.Add(oneItemFilterRule);
		}
		OnePhantomSetting onePhantomSetting = OnePhantomSetting.Create();
		onePhantomSetting.Index = this.Index;
		onePhantomSetting.On = this.IsOn;
		onePhantomSetting.Name = this.Name;
		onePhantomSetting.RuleList.AddRange(list);
		return onePhantomSetting;
	}

	// Token: 0x0600FB32 RID: 64306 RVA: 0x0044F5FC File Offset: 0x0044D7FC
	public void Reset(bool indexReset = false, bool nameReset = false)
	{
		this.Index = (indexReset ? -1 : this.Index);
		this.IsOn = false;
		this.Name = (nameReset ? ConfigBase<TextConfig>.Instance.GetMultiText("PhantomProject_EmptyProject", Array.Empty<string>()) : this.Name);
		this.RuleIdMapValueList.Clear();
		int filterIdConst = ModelBase<InventoryModel>.Instance.GetFilterIdConst();
		foreach (int key in ConfigBase<FilterConfig>.Instance.GetFilterConfig(filterIdConst).Value.RuleList())
		{
			this.RuleIdMapValueList.Add(key, Array.Empty<int>());
		}
	}

	// Token: 0x0600FB33 RID: 64307 RVA: 0x0044F6A4 File Offset: 0x0044D8A4
	public PhantomManageConfigData Clone()
	{
		return new PhantomManageConfigData(this.Index)
		{
			IsOn = this.IsOn,
			Name = this.Name,
			Type = this.Type,
			RuleIdMapValueList = new Dictionary<int, int[]>(this.RuleIdMapValueList)
		};
	}

	// Token: 0x040078A1 RID: 30881
	private PhantomSettingType Type;

	// Token: 0x040078A2 RID: 30882
	private int Index = -1;

	// Token: 0x040078A3 RID: 30883
	private bool IsOn;

	// Token: 0x040078A4 RID: 30884
	private string Name;

	// Token: 0x040078A5 RID: 30885
	private Dictionary<int, int[]> RuleIdMapValueList = new Dictionary<int, int[]>();

	// Token: 0x040078A6 RID: 30886
	private int DisplayIndex = -1;
}
