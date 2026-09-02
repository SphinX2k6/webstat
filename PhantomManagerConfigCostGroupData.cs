using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x02002453 RID: 9299
[NullableContext(1)]
[Nullable(0)]
public class PhantomManagerConfigCostGroupData
{
	// Token: 0x06011FFC RID: 73724 RVA: 0x004F4634 File Offset: 0x004F2834
	public PhantomManagerConfigCostGroupData(int fetterId, int cost)
	{
		this.FetterId = fetterId;
		this.Cost = cost;
	}

	// Token: 0x06011FFD RID: 73725 RVA: 0x004F4660 File Offset: 0x004F2860
	public void UpdateMainProp(List<PhBaPlanAttr> attrList)
	{
		HashSet<int> hashSet = new HashSet<int>();
		foreach (PhBaPlanAttr phBaPlanAttr in attrList)
		{
			hashSet.Add(phBaPlanAttr.AttrId);
			this.MainPropMap[phBaPlanAttr.AttrId] = (EPhantomManagerConfigState)phBaPlanAttr.Deal;
		}
		foreach (int num in this.MainPropMap.Keys.ToList<int>())
		{
			if (!hashSet.Contains(num))
			{
				this.MainPropMap.Remove(num);
			}
		}
	}

	// Token: 0x06011FFE RID: 73726 RVA: 0x004F4730 File Offset: 0x004F2930
	public void CacheShareProp(List<PhBaPlanAttr> attrList)
	{
		HashSet<int> hashSet = new HashSet<int>();
		foreach (PhBaPlanAttr phBaPlanAttr in attrList)
		{
			hashSet.Add(phBaPlanAttr.AttrId);
			this.CachePropMap[phBaPlanAttr.AttrId] = (EPhantomManagerConfigState)phBaPlanAttr.Deal;
		}
		foreach (int num in this.MainPropMap.Keys)
		{
			if (!hashSet.Contains(num))
			{
				this.CachePropMap[num] = EPhantomManagerConfigState.Default;
			}
		}
	}

	// Token: 0x06011FFF RID: 73727 RVA: 0x004F47FC File Offset: 0x004F29FC
	public void SetPropState(int mainProp, EPhantomManagerConfigState state, bool isCache)
	{
		if (isCache)
		{
			this.CachePropMap[mainProp] = state;
			return;
		}
		this.MainPropMap[mainProp] = state;
	}

	// Token: 0x06012000 RID: 73728 RVA: 0x004F481C File Offset: 0x004F2A1C
	public void DoCacheDataUpdate(bool apply)
	{
		if (apply)
		{
			foreach (KeyValuePair<int, EPhantomManagerConfigState> keyValuePair in this.CachePropMap)
			{
				this.MainPropMap[keyValuePair.Key] = keyValuePair.Value;
			}
		}
		this.CachePropMap.Clear();
	}

	// Token: 0x06012001 RID: 73729 RVA: 0x004F4890 File Offset: 0x004F2A90
	[return: Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public ValueTuple<bool, List<PhBaPlanAttr>> GetCacheProtoData()
	{
		List<PhBaPlanAttr> list = new List<PhBaPlanAttr>();
		bool item = false;
		foreach (KeyValuePair<int, EPhantomManagerConfigState> keyValuePair in this.MainPropMap)
		{
			if (!this.CachePropMap.ContainsKey(keyValuePair.Key) && keyValuePair.Value != EPhantomManagerConfigState.Default)
			{
				PhBaPlanAttr phBaPlanAttr = PhBaPlanAttr.Create();
				phBaPlanAttr.AttrId = keyValuePair.Key;
				phBaPlanAttr.Deal = (PhBaPlanAttrDeal)keyValuePair.Value;
				list.Add(phBaPlanAttr);
			}
		}
		foreach (KeyValuePair<int, EPhantomManagerConfigState> keyValuePair2 in this.CachePropMap)
		{
			if ((!this.MainPropMap.ContainsKey(keyValuePair2.Key) && keyValuePair2.Value != EPhantomManagerConfigState.Default) || (this.MainPropMap.ContainsKey(keyValuePair2.Key) && this.MainPropMap[keyValuePair2.Key] != keyValuePair2.Value))
			{
				item = true;
			}
			PhBaPlanAttr phBaPlanAttr2 = PhBaPlanAttr.Create();
			phBaPlanAttr2.AttrId = keyValuePair2.Key;
			phBaPlanAttr2.Deal = (PhBaPlanAttrDeal)keyValuePair2.Value;
			list.Add(phBaPlanAttr2);
		}
		return new ValueTuple<bool, List<PhBaPlanAttr>>(item, list);
	}

	// Token: 0x06012002 RID: 73730 RVA: 0x004F49F0 File Offset: 0x004F2BF0
	public void ResetConfig()
	{
		this.CachePropMap.Clear();
		foreach (KeyValuePair<int, EPhantomManagerConfigState> keyValuePair in this.MainPropMap)
		{
			if (keyValuePair.Value != EPhantomManagerConfigState.Default)
			{
				this.CachePropMap[keyValuePair.Key] = EPhantomManagerConfigState.Default;
			}
		}
	}

	// Token: 0x06012003 RID: 73731 RVA: 0x004F4A64 File Offset: 0x004F2C64
	public EPhantomManagerConfigState GetPropCurrentState(int id)
	{
		EPhantomManagerConfigState result;
		if (!this.CachePropMap.TryGetValue(id, out result))
		{
			return this.MainPropMap.GetValueOrDefault(id, EPhantomManagerConfigState.Default);
		}
		return result;
	}

	// Token: 0x06012004 RID: 73732 RVA: 0x004F4A90 File Offset: 0x004F2C90
	public bool GetRecommendDirty(PhantomManagePlanV2 config)
	{
		foreach (int id in config.DiscardGroupIter())
		{
			if (this.GetPropCurrentState(id) != EPhantomManagerConfigState.Discard)
			{
				return true;
			}
		}
		foreach (int id2 in config.LockGroupIter())
		{
			if (this.GetPropCurrentState(id2) != EPhantomManagerConfigState.Lock)
			{
				return true;
			}
		}
		foreach (KeyValuePair<int, EPhantomManagerConfigState> keyValuePair in this.MainPropMap)
		{
			if (!config.GetDiscardGroupBytes().Contains(keyValuePair.Key) && !config.GetLockGroupArray().Contains(keyValuePair.Key) && keyValuePair.Value != EPhantomManagerConfigState.Default)
			{
				return true;
			}
		}
		foreach (KeyValuePair<int, EPhantomManagerConfigState> keyValuePair2 in this.CachePropMap)
		{
			if (!config.GetDiscardGroupBytes().Contains(keyValuePair2.Key) && !config.GetLockGroupArray().Contains(keyValuePair2.Key) && keyValuePair2.Value != EPhantomManagerConfigState.Default)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06012005 RID: 73733 RVA: 0x004F4C20 File Offset: 0x004F2E20
	public bool CacheRecommend(PhantomManagePlanV2 config)
	{
		this.CachePropMap.Clear();
		foreach (KeyValuePair<int, EPhantomManagerConfigState> keyValuePair in this.MainPropMap)
		{
			if (!config.GetDiscardGroupBytes().Contains(keyValuePair.Key) && !config.GetLockGroupArray().Contains(keyValuePair.Key) && keyValuePair.Value != EPhantomManagerConfigState.Default)
			{
				this.CachePropMap[keyValuePair.Key] = EPhantomManagerConfigState.Default;
			}
		}
		foreach (int key in config.DiscardGroupIter())
		{
			if (!this.MainPropMap.ContainsKey(key) || this.MainPropMap[key] != EPhantomManagerConfigState.Discard)
			{
				this.CachePropMap[key] = EPhantomManagerConfigState.Discard;
			}
		}
		foreach (int key2 in config.LockGroupIter())
		{
			if (!this.MainPropMap.ContainsKey(key2) || this.MainPropMap[key2] != EPhantomManagerConfigState.Lock)
			{
				this.CachePropMap[key2] = EPhantomManagerConfigState.Lock;
			}
		}
		return this.CachePropMap.Count > 0;
	}

	// Token: 0x06012006 RID: 73734 RVA: 0x004F4D90 File Offset: 0x004F2F90
	public List<PhantomDiscardPlanPlanLogData> GetLogReport()
	{
		PhantomDiscardPlanPlanLogData phantomDiscardPlanPlanLogData = new PhantomDiscardPlanPlanLogData();
		PhantomDiscardPlanPlanLogData phantomDiscardPlanPlanLogData2 = new PhantomDiscardPlanPlanLogData();
		phantomDiscardPlanPlanLogData.i_cost = this.Cost;
		phantomDiscardPlanPlanLogData.i_type = 1;
		phantomDiscardPlanPlanLogData2.i_cost = this.Cost;
		phantomDiscardPlanPlanLogData2.i_type = 0;
		foreach (KeyValuePair<int, EPhantomManagerConfigState> keyValuePair in this.MainPropMap)
		{
			if (keyValuePair.Value == EPhantomManagerConfigState.Lock)
			{
				phantomDiscardPlanPlanLogData.s_setting.Add(keyValuePair.Key);
			}
			else if (keyValuePair.Value == EPhantomManagerConfigState.Discard)
			{
				phantomDiscardPlanPlanLogData2.s_setting.Add(keyValuePair.Key);
			}
		}
		List<PhantomDiscardPlanPlanLogData> list = new List<PhantomDiscardPlanPlanLogData>();
		if (phantomDiscardPlanPlanLogData.s_setting.Count > 0)
		{
			list.Add(phantomDiscardPlanPlanLogData);
		}
		if (phantomDiscardPlanPlanLogData2.s_setting.Count > 0)
		{
			list.Add(phantomDiscardPlanPlanLogData2);
		}
		return list;
	}

	// Token: 0x04008CF1 RID: 36081
	public Dictionary<int, EPhantomManagerConfigState> MainPropMap = new Dictionary<int, EPhantomManagerConfigState>();

	// Token: 0x04008CF2 RID: 36082
	public Dictionary<int, EPhantomManagerConfigState> CachePropMap = new Dictionary<int, EPhantomManagerConfigState>();

	// Token: 0x04008CF3 RID: 36083
	public int FetterId;

	// Token: 0x04008CF4 RID: 36084
	public int Cost;
}
