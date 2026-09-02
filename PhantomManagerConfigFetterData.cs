using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x02002452 RID: 9298
[NullableContext(1)]
[Nullable(0)]
public class PhantomManagerConfigFetterData
{
	// Token: 0x06011FF0 RID: 73712 RVA: 0x004F3FDA File Offset: 0x004F21DA
	public PhantomManagerConfigFetterData(int fetterId)
	{
		this.FetterId = fetterId;
	}

	// Token: 0x06011FF1 RID: 73713 RVA: 0x004F3FF4 File Offset: 0x004F21F4
	public void UpdateMainPropMap(List<PhBaOneCostPlan> mainPropData)
	{
		HashSet<int> hashSet = new HashSet<int>();
		foreach (PhBaOneCostPlan phBaOneCostPlan in mainPropData)
		{
			hashSet.Add((int)phBaOneCostPlan.CostType);
			this.TryInitCost((int)phBaOneCostPlan.CostType);
			this.CostMap[(int)phBaOneCostPlan.CostType].UpdateMainProp(phBaOneCostPlan.AttrList.ToList<PhBaPlanAttr>());
		}
		foreach (KeyValuePair<int, PhantomManagerConfigCostGroupData> keyValuePair in this.CostMap)
		{
			if (!hashSet.Contains(keyValuePair.Key))
			{
				keyValuePair.Value.UpdateMainProp(new List<PhBaPlanAttr>());
			}
		}
	}

	// Token: 0x06011FF2 RID: 73714 RVA: 0x004F40D8 File Offset: 0x004F22D8
	public void CacheSharePropMap(List<PhBaOneCostPlan> propData)
	{
		HashSet<int> hashSet = new HashSet<int>();
		foreach (PhBaOneCostPlan phBaOneCostPlan in propData)
		{
			hashSet.Add((int)phBaOneCostPlan.CostType);
			this.TryInitCost((int)phBaOneCostPlan.CostType);
			this.CostMap[(int)phBaOneCostPlan.CostType].CacheShareProp(phBaOneCostPlan.AttrList.ToList<PhBaPlanAttr>());
		}
		foreach (KeyValuePair<int, PhantomManagerConfigCostGroupData> keyValuePair in this.CostMap)
		{
			if (!hashSet.Contains(keyValuePair.Key))
			{
				keyValuePair.Value.CacheShareProp(new List<PhBaPlanAttr>());
			}
		}
	}

	// Token: 0x06011FF3 RID: 73715 RVA: 0x004F41BC File Offset: 0x004F23BC
	public void TryInitCost(int cost)
	{
		if (!this.CostMap.ContainsKey(cost))
		{
			this.CostMap[cost] = new PhantomManagerConfigCostGroupData(this.FetterId, cost);
		}
	}

	// Token: 0x06011FF4 RID: 73716 RVA: 0x004F41E4 File Offset: 0x004F23E4
	public EPhantomManagerConfigState GetPropCurrentState(IPhantomManagerConfigNewSettingDetailInfo data)
	{
		PhantomManagerConfigCostGroupData phantomManagerConfigCostGroupData;
		if (!this.CostMap.TryGetValue(data.Cost, out phantomManagerConfigCostGroupData))
		{
			return EPhantomManagerConfigState.Default;
		}
		return phantomManagerConfigCostGroupData.GetPropCurrentState(data.MainPropId);
	}

	// Token: 0x06011FF5 RID: 73717 RVA: 0x004F4214 File Offset: 0x004F2414
	public void SetPropState(IPhantomManagerConfigNewSettingDetailInfo data, EPhantomManagerConfigState state, bool isCache)
	{
		this.TryInitCost(data.Cost);
		this.CostMap[data.Cost].SetPropState(data.MainPropId, state, isCache);
	}

	// Token: 0x06011FF6 RID: 73718 RVA: 0x004F4240 File Offset: 0x004F2440
	public void DoCacheDataUpdate(bool apply)
	{
		foreach (KeyValuePair<int, PhantomManagerConfigCostGroupData> keyValuePair in this.CostMap)
		{
			keyValuePair.Value.DoCacheDataUpdate(apply);
		}
	}

	// Token: 0x06011FF7 RID: 73719 RVA: 0x004F429C File Offset: 0x004F249C
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public ValueTuple<bool, PhBaOneSuitPlan> GetCacheProtoData()
	{
		PhBaOneSuitPlan phBaOneSuitPlan = PhBaOneSuitPlan.Create();
		phBaOneSuitPlan.SuitId = this.FetterId;
		bool flag = false;
		foreach (KeyValuePair<int, PhantomManagerConfigCostGroupData> keyValuePair in this.CostMap)
		{
			PhBaOneCostPlan phBaOneCostPlan = PhBaOneCostPlan.Create();
			phBaOneCostPlan.CostType = (PhBaCostType)keyValuePair.Key;
			ValueTuple<bool, List<PhBaPlanAttr>> cacheProtoData = keyValuePair.Value.GetCacheProtoData();
			bool item = cacheProtoData.Item1;
			List<PhBaPlanAttr> item2 = cacheProtoData.Item2;
			flag = (flag || item);
			if (item2.Count != 0)
			{
				phBaOneCostPlan.AttrList.Add(item2);
				phBaOneSuitPlan.OneCostList.Add(phBaOneCostPlan);
			}
		}
		return new ValueTuple<bool, PhBaOneSuitPlan>(flag, phBaOneSuitPlan);
	}

	// Token: 0x06011FF8 RID: 73720 RVA: 0x004F435C File Offset: 0x004F255C
	public void ResetFetterConfig()
	{
		foreach (KeyValuePair<int, PhantomManagerConfigCostGroupData> keyValuePair in this.CostMap)
		{
			keyValuePair.Value.ResetConfig();
		}
	}

	// Token: 0x06011FF9 RID: 73721 RVA: 0x004F43B4 File Offset: 0x004F25B4
	public bool GetEditFetterConfigRecommendDirty()
	{
		IReadOnlyList<PhantomManagePlanV2> phantomManagerPlanByFetterId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomManagerPlanByFetterId(this.FetterId);
		if (this.CostMap.Count != phantomManagerPlanByFetterId.Count)
		{
			return true;
		}
		HashSet<int> configCostSet = new HashSet<int>();
		foreach (PhantomManagePlanV2 config in phantomManagerPlanByFetterId)
		{
			if (!this.CostMap.ContainsKey(config.Cost))
			{
				return true;
			}
			configCostSet.Add(config.Cost);
			if (this.CostMap[config.Cost].GetRecommendDirty(config))
			{
				return true;
			}
		}
		return this.CostMap.Keys.Any((int cost) => !configCostSet.Contains(cost));
	}

	// Token: 0x06011FFA RID: 73722 RVA: 0x004F4498 File Offset: 0x004F2698
	public bool SetFetterConfigRecommend()
	{
		IEnumerable<PhantomManagePlanV2> phantomManagerPlanByFetterId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomManagerPlanByFetterId(this.FetterId);
		bool flag = false;
		HashSet<int> hashSet = new HashSet<int>();
		foreach (PhantomManagePlanV2 config in phantomManagerPlanByFetterId)
		{
			if (!this.CostMap.ContainsKey(config.Cost))
			{
				this.CostMap[config.Cost] = new PhantomManagerConfigCostGroupData(this.FetterId, config.Cost);
			}
			hashSet.Add(config.Cost);
			flag = (this.CostMap[config.Cost].CacheRecommend(config) || flag);
		}
		foreach (int num in this.CostMap.Keys.ToList<int>())
		{
			if (!hashSet.Contains(num))
			{
				this.CostMap.Remove(num);
			}
		}
		return flag;
	}

	// Token: 0x06011FFB RID: 73723 RVA: 0x004F45B4 File Offset: 0x004F27B4
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public List<PhantomDiscardPlanPlanLogData> GetLogReport()
	{
		if (this.CostMap.Count == 0)
		{
			return null;
		}
		List<PhantomDiscardPlanPlanLogData> list = new List<PhantomDiscardPlanPlanLogData>();
		foreach (KeyValuePair<int, PhantomManagerConfigCostGroupData> keyValuePair in this.CostMap)
		{
			list.AddRange(keyValuePair.Value.GetLogReport());
		}
		if (list.Count <= 0)
		{
			return null;
		}
		return list;
	}

	// Token: 0x04008CEF RID: 36079
	protected readonly Dictionary<int, PhantomManagerConfigCostGroupData> CostMap = new Dictionary<int, PhantomManagerConfigCostGroupData>();

	// Token: 0x04008CF0 RID: 36080
	public int FetterId;
}
