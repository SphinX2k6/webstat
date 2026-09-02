using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x0200203C RID: 8252
[NullableContext(1)]
[Nullable(0)]
public class PhantomManageConfigViewModel : ViewModelBase<EPhantomManageConfigViewData>
{
	// Token: 0x0600FB5E RID: 64350 RVA: 0x00450468 File Offset: 0x0044E668
	public PhantomManageConfigViewModel()
	{
		this.DataMap.Add(EPhantomManageConfigViewData.SelectType, PhantomSettingType.AutoLock);
		this.DataMap.Add(EPhantomManageConfigViewData.SelectIndex, null);
		this.DataMap.Add(EPhantomManageConfigViewData.SelectConfig, null);
		this.DataMap.Add(EPhantomManageConfigViewData.EditState, false);
		this.DataMap.Add(EPhantomManageConfigViewData.EditData, null);
		this.DataMap.Add(EPhantomManageConfigViewData.EditSwitch, false);
	}

	// Token: 0x0600FB5F RID: 64351 RVA: 0x004504D8 File Offset: 0x0044E6D8
	public void SetSelectType(PhantomSettingType type, bool notNotify = false)
	{
		base.SetData(EPhantomManageConfigViewData.SelectType, type, new bool?(notNotify));
	}

	// Token: 0x0600FB60 RID: 64352 RVA: 0x004504ED File Offset: 0x0044E6ED
	public PhantomSettingType GetSelectType()
	{
		return (PhantomSettingType)base.GetData(EPhantomManageConfigViewData.SelectType);
	}

	// Token: 0x0600FB61 RID: 64353 RVA: 0x004504FC File Offset: 0x0044E6FC
	public void SetSelectIndex(PhantomSettingType type, int index, bool notNotify = false)
	{
		Dictionary<PhantomSettingType, int> dictionary = base.GetData(EPhantomManageConfigViewData.SelectIndex) as Dictionary<PhantomSettingType, int>;
		if (dictionary == null)
		{
			dictionary = new Dictionary<PhantomSettingType, int>();
		}
		if (dictionary.ContainsKey(type))
		{
			dictionary[type] = index;
		}
		else
		{
			dictionary.Add(type, index);
		}
		base.SetData(EPhantomManageConfigViewData.SelectIndex, dictionary, new bool?(notNotify));
	}

	// Token: 0x0600FB62 RID: 64354 RVA: 0x00450548 File Offset: 0x0044E748
	public int GetSelectIndex(PhantomSettingType type)
	{
		Dictionary<PhantomSettingType, int> dictionary = base.GetData(EPhantomManageConfigViewData.SelectIndex) as Dictionary<PhantomSettingType, int>;
		if (dictionary == null)
		{
			return 0;
		}
		int result;
		if (dictionary.TryGetValue(type, out result))
		{
			return result;
		}
		return 0;
	}

	// Token: 0x0600FB63 RID: 64355 RVA: 0x00450575 File Offset: 0x0044E775
	public void SetSelectConfig(PhantomManageConfigData config, bool notNotify = false)
	{
		base.SetData(EPhantomManageConfigViewData.SelectConfig, config, new bool?(notNotify));
	}

	// Token: 0x0600FB64 RID: 64356 RVA: 0x00450585 File Offset: 0x0044E785
	public PhantomManageConfigData GetSelectConfig()
	{
		return base.GetData(EPhantomManageConfigViewData.SelectConfig) as PhantomManageConfigData;
	}

	// Token: 0x0600FB65 RID: 64357 RVA: 0x00450593 File Offset: 0x0044E793
	public bool GetEditState()
	{
		return (bool)base.GetData(EPhantomManageConfigViewData.EditState);
	}

	// Token: 0x0600FB66 RID: 64358 RVA: 0x004505A1 File Offset: 0x0044E7A1
	public void SetEditState(bool state, bool notNotify = false)
	{
		base.SetData(EPhantomManageConfigViewData.EditState, state, new bool?(notNotify));
	}

	// Token: 0x0600FB67 RID: 64359 RVA: 0x004505B6 File Offset: 0x0044E7B6
	public void InitEditDataSwitch(PhantomManageConfigData data, bool notNotify = false)
	{
		base.SetData(EPhantomManageConfigViewData.EditSwitch, data.GetIsOn(), new bool?(notNotify));
		base.SetData(EPhantomManageConfigViewData.EditData, data.GetRuleIdMapValueList(), new bool?(notNotify));
	}

	// Token: 0x0600FB68 RID: 64360 RVA: 0x004505E3 File Offset: 0x0044E7E3
	public void SetEditSwitch(bool isOn, bool notNotify = false)
	{
		base.SetData(EPhantomManageConfigViewData.EditSwitch, isOn, new bool?(notNotify));
	}

	// Token: 0x0600FB69 RID: 64361 RVA: 0x004505F8 File Offset: 0x0044E7F8
	public bool GetEditSwitch()
	{
		return (bool)base.GetData(EPhantomManageConfigViewData.EditSwitch);
	}

	// Token: 0x0600FB6A RID: 64362 RVA: 0x00450606 File Offset: 0x0044E806
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public Dictionary<int, int[]> GetEditData()
	{
		return base.GetData(EPhantomManageConfigViewData.EditData) as Dictionary<int, int[]>;
	}

	// Token: 0x0600FB6B RID: 64363 RVA: 0x00450614 File Offset: 0x0044E814
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public Dictionary<int, int[]> GetEditDataByRuleId(int ruleId)
	{
		Dictionary<int, int[]> dictionary = base.GetData(EPhantomManageConfigViewData.EditData) as Dictionary<int, int[]>;
		if (dictionary == null)
		{
			return null;
		}
		Dictionary<int, int[]> dictionary2 = new Dictionary<int, int[]>();
		foreach (KeyValuePair<int, int[]> keyValuePair in dictionary)
		{
			if (ruleId == keyValuePair.Key)
			{
				dictionary2.Add(keyValuePair.Key, keyValuePair.Value);
				return dictionary2;
			}
		}
		return null;
	}

	// Token: 0x0600FB6C RID: 64364 RVA: 0x0045069C File Offset: 0x0044E89C
	public void SetEditDataById(int ruleId, int value, bool isAdd, bool notNotify = false)
	{
		int[] array;
		int[] array2;
		if (this.GetEditDataByRuleId(ruleId).TryGetValue(ruleId, out array))
		{
			array2 = array;
		}
		else
		{
			array2 = Array.Empty<int>();
		}
		if (!isAdd)
		{
			array2 = this.RemoveNumber(array2, value);
		}
		else
		{
			array2 = this.AddNumber(array2, value);
		}
		Dictionary<int, int[]> dictionary = base.GetData(EPhantomManageConfigViewData.EditData) as Dictionary<int, int[]>;
		foreach (KeyValuePair<int, int[]> keyValuePair in dictionary)
		{
			if (ruleId == keyValuePair.Key)
			{
				dictionary[keyValuePair.Key] = array2;
			}
		}
		if (!notNotify)
		{
			base.Notify(EPhantomManageConfigViewData.EditData);
		}
	}

	// Token: 0x0600FB6D RID: 64365 RVA: 0x00450748 File Offset: 0x0044E948
	public void SetEditDataByIdList(int ruleId, int[] valueList, bool notNotify = false)
	{
		Dictionary<int, int[]> dictionary = base.GetData(EPhantomManageConfigViewData.EditData) as Dictionary<int, int[]>;
		foreach (KeyValuePair<int, int[]> keyValuePair in dictionary)
		{
			if (ruleId == keyValuePair.Key)
			{
				dictionary[keyValuePair.Key] = valueList;
			}
		}
		if (!notNotify)
		{
			base.Notify(EPhantomManageConfigViewData.EditData);
		}
	}

	// Token: 0x0600FB6E RID: 64366 RVA: 0x004507C0 File Offset: 0x0044E9C0
	private int[] RemoveNumber(int[] arr, int value)
	{
		List<int> list = new List<int>();
		foreach (int num in arr)
		{
			if (num != value)
			{
				list.Add(num);
			}
		}
		return list.ToArray();
	}

	// Token: 0x0600FB6F RID: 64367 RVA: 0x004507F8 File Offset: 0x0044E9F8
	private int[] AddNumber(int[] arr, int value)
	{
		if (!new HashSet<int>(arr).Contains(value))
		{
			return new List<int>(arr)
			{
				value
			}.ToArray();
		}
		return arr;
	}
}
