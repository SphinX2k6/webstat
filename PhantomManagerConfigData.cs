using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02002451 RID: 9297
[NullableContext(1)]
[Nullable(0)]
public class PhantomManagerConfigData
{
	// Token: 0x06011FDB RID: 73691 RVA: 0x004F3574 File Offset: 0x004F1774
	public void UpdateFetterMap(List<PhBaOneSuitPlan> fetterData)
	{
		HashSet<int> hashSet = new HashSet<int>();
		foreach (PhBaOneSuitPlan phBaOneSuitPlan in fetterData)
		{
			int suitId = phBaOneSuitPlan.SuitId;
			hashSet.Add(suitId);
			if (!this.FetterMap.ContainsKey(suitId))
			{
				this.FetterMap[suitId] = new PhantomManagerConfigFetterData(suitId);
			}
			this.UpdateFetterUsing(suitId, phBaOneSuitPlan.IsOpen);
			this.FetterMap[suitId].UpdateMainPropMap(phBaOneSuitPlan.OneCostList.ToList<PhBaOneCostPlan>());
		}
		foreach (KeyValuePair<int, PhantomManagerConfigFetterData> keyValuePair in this.FetterMap)
		{
			if (!hashSet.Contains(keyValuePair.Key))
			{
				this.UpdateFetterUsing(keyValuePair.Key, false);
				keyValuePair.Value.UpdateMainPropMap(new List<PhBaOneCostPlan>());
			}
		}
	}

	// Token: 0x06011FDC RID: 73692 RVA: 0x004F3684 File Offset: 0x004F1884
	public void CacheShareFetterMap(List<PhBaOneSuitPlan> fetterData)
	{
		HashSet<int> hashSet = new HashSet<int>();
		foreach (PhBaOneSuitPlan phBaOneSuitPlan in fetterData)
		{
			int suitId = phBaOneSuitPlan.SuitId;
			hashSet.Add(suitId);
			if (!this.FetterMap.ContainsKey(suitId))
			{
				this.FetterMap[suitId] = new PhantomManagerConfigFetterData(suitId);
			}
			this.FetterMap[suitId].CacheSharePropMap(phBaOneSuitPlan.OneCostList.ToList<PhBaOneCostPlan>());
		}
		foreach (KeyValuePair<int, PhantomManagerConfigFetterData> keyValuePair in this.FetterMap)
		{
			if (!hashSet.Contains(keyValuePair.Key))
			{
				keyValuePair.Value.CacheSharePropMap(new List<PhBaOneCostPlan>());
			}
		}
	}

	// Token: 0x06011FDD RID: 73693 RVA: 0x004F377C File Offset: 0x004F197C
	public void UpdateFetterUsing(int fetterId, bool isOpen)
	{
		this.IsUsingMap[fetterId] = isOpen;
	}

	// Token: 0x06011FDE RID: 73694 RVA: 0x004F378B File Offset: 0x004F198B
	public bool CheckHasInited()
	{
		return this.FetterMap.Count > 0;
	}

	// Token: 0x06011FDF RID: 73695 RVA: 0x004F379C File Offset: 0x004F199C
	public EPhantomManagerConfigState GetPropCurrentState(IPhantomManagerConfigNewSettingDetailInfo data)
	{
		PhantomManagerConfigFetterData phantomManagerConfigFetterData;
		if (!this.FetterMap.TryGetValue(data.FetterId, out phantomManagerConfigFetterData))
		{
			return EPhantomManagerConfigState.Default;
		}
		return phantomManagerConfigFetterData.GetPropCurrentState(data);
	}

	// Token: 0x06011FE0 RID: 73696 RVA: 0x004F37C8 File Offset: 0x004F19C8
	public void SetPropCurrentState(IPhantomManagerConfigNewSettingDetailInfo data, EPhantomManagerConfigState state, bool isCache)
	{
		if (!this.FetterMap.ContainsKey(data.FetterId))
		{
			this.FetterMap[data.FetterId] = new PhantomManagerConfigFetterData(data.FetterId);
		}
		this.FetterMap[data.FetterId].SetPropState(data, state, isCache);
	}

	// Token: 0x06011FE1 RID: 73697 RVA: 0x004F3820 File Offset: 0x004F1A20
	public void DoCacheDataUpdate(bool apply)
	{
		foreach (KeyValuePair<int, PhantomManagerConfigFetterData> keyValuePair in this.FetterMap)
		{
			keyValuePair.Value.DoCacheDataUpdate(apply);
		}
	}

	// Token: 0x06011FE2 RID: 73698 RVA: 0x004F387C File Offset: 0x004F1A7C
	[NullableContext(2)]
	public PhBaOneAllSuitPlan GetCacheStateProto()
	{
		PhBaOneAllSuitPlan phBaOneAllSuitPlan = PhBaOneAllSuitPlan.Create();
		bool flag = false;
		foreach (KeyValuePair<int, PhantomManagerConfigFetterData> keyValuePair in this.FetterMap)
		{
			ValueTuple<bool, PhBaOneSuitPlan> cacheProtoData = keyValuePair.Value.GetCacheProtoData();
			bool item = cacheProtoData.Item1;
			PhBaOneSuitPlan item2 = cacheProtoData.Item2;
			flag = (flag || item);
			if (item2.OneCostList.Count != 0)
			{
				phBaOneAllSuitPlan.SuitPlanList.Add(item2);
			}
		}
		if (!flag)
		{
			return null;
		}
		return phBaOneAllSuitPlan;
	}

	// Token: 0x06011FE3 RID: 73699 RVA: 0x004F3914 File Offset: 0x004F1B14
	public void ResetFetterConfig(int fetterId)
	{
		PhantomManagerConfigFetterData phantomManagerConfigFetterData;
		if (this.FetterMap.TryGetValue(fetterId, out phantomManagerConfigFetterData))
		{
			phantomManagerConfigFetterData.ResetFetterConfig();
		}
	}

	// Token: 0x06011FE4 RID: 73700 RVA: 0x004F3937 File Offset: 0x004F1B37
	public bool CheckEditFetterConfigRecommendDirty(int fetterId)
	{
		if (!this.FetterMap.ContainsKey(fetterId))
		{
			this.FetterMap[fetterId] = new PhantomManagerConfigFetterData(fetterId);
		}
		return this.FetterMap[fetterId].GetEditFetterConfigRecommendDirty();
	}

	// Token: 0x06011FE5 RID: 73701 RVA: 0x004F396A File Offset: 0x004F1B6A
	public bool SetFetterConfigRecommend(int fetterId)
	{
		if (!this.FetterMap.ContainsKey(fetterId))
		{
			this.FetterMap[fetterId] = new PhantomManagerConfigFetterData(fetterId);
		}
		return this.FetterMap[fetterId].SetFetterConfigRecommend();
	}

	// Token: 0x06011FE6 RID: 73702 RVA: 0x004F39A0 File Offset: 0x004F1BA0
	public bool GetFetterConfigIsOpen(int fetterId)
	{
		bool flag;
		return this.IsUsingMap.TryGetValue(fetterId, out flag) && flag;
	}

	// Token: 0x06011FE7 RID: 73703 RVA: 0x004F39C0 File Offset: 0x004F1BC0
	[NullableContext(0)]
	public UniTask<bool> ResetAllFetterOpen(bool needResetConfig)
	{
		PhantomManagerConfigData.<ResetAllFetterOpen>d__22 <ResetAllFetterOpen>d__;
		<ResetAllFetterOpen>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<ResetAllFetterOpen>d__.<>4__this = this;
		<ResetAllFetterOpen>d__.needResetConfig = needResetConfig;
		<ResetAllFetterOpen>d__.<>1__state = -1;
		<ResetAllFetterOpen>d__.<>t__builder.Start<PhantomManagerConfigData.<ResetAllFetterOpen>d__22>(ref <ResetAllFetterOpen>d__);
		return <ResetAllFetterOpen>d__.<>t__builder.Task;
	}

	// Token: 0x06011FE8 RID: 73704 RVA: 0x004F3A0C File Offset: 0x004F1C0C
	public bool CheckDirty()
	{
		bool flag = false;
		foreach (KeyValuePair<int, PhantomManagerConfigFetterData> keyValuePair in this.FetterMap)
		{
			flag |= keyValuePair.Value.GetCacheProtoData().Item1;
		}
		return flag;
	}

	// Token: 0x06011FE9 RID: 73705 RVA: 0x004F3A70 File Offset: 0x004F1C70
	public IPhantomManagerApplySettingDetailInfo GetPhantomPlanMatchApplyData()
	{
		PhantomManagerApplySettingDetailInfo phantomManagerApplySettingDetailInfo = new PhantomManagerApplySettingDetailInfo();
		foreach (PhantomItemData phantomItemData in ModelBase<InventoryModel>.Instance.GetPhantomItemDataList())
		{
			int uniqueId = phantomItemData.GetUniqueId();
			PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(uniqueId);
			bool flag = this.DownFiveStarSwitch && phantomBattleData.GetQuality() < 5;
			int id = phantomItemData.GetFetterGroupConfig().Value.Id;
			bool flag2;
			if (phantomBattleData.GetVisionNoCultivated() && !flag && this.IsUsingMap.TryGetValue(id, out flag2) && flag2)
			{
				int id2 = phantomBattleData.GetMainPropShowAttributeList(CommonComponentDefine.EAttributeType.PhantomType, false)[0].Id;
				PhantomManagerConfigNewSettingDetailInfo data = new PhantomManagerConfigNewSettingDetailInfo
				{
					FetterId = id,
					Cost = phantomBattleData.GetCost(),
					MainPropId = id2,
					IsEdit = true
				};
				EPhantomManagerConfigState propCurrentState = this.GetPropCurrentState(data);
				if (propCurrentState == EPhantomManagerConfigState.Discard && !phantomItemData.GetIsDeprecated())
				{
					phantomManagerApplySettingDetailInfo.DiscardList.Add(phantomItemData);
				}
				else if (propCurrentState == EPhantomManagerConfigState.Lock && !phantomItemData.GetIsLock())
				{
					phantomManagerApplySettingDetailInfo.LockList.Add(phantomItemData);
				}
			}
		}
		return phantomManagerApplySettingDetailInfo;
	}

	// Token: 0x06011FEA RID: 73706 RVA: 0x004F3BC8 File Offset: 0x004F1DC8
	[NullableContext(0)]
	public UniTask<bool> DoApplyOpera([Nullable(1)] IPhantomManagerApplySettingDetailInfo applyData)
	{
		PhantomManagerConfigData.<DoApplyOpera>d__25 <DoApplyOpera>d__;
		<DoApplyOpera>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<DoApplyOpera>d__.applyData = applyData;
		<DoApplyOpera>d__.<>1__state = -1;
		<DoApplyOpera>d__.<>t__builder.Start<PhantomManagerConfigData.<DoApplyOpera>d__25>(ref <DoApplyOpera>d__);
		return <DoApplyOpera>d__.<>t__builder.Task;
	}

	// Token: 0x06011FEB RID: 73707 RVA: 0x004F3C0C File Offset: 0x004F1E0C
	public List<PhantomItemData> GetPhantomSmartDiscardUserPlan()
	{
		List<PhantomItemData> list = new List<PhantomItemData>();
		foreach (PhantomItemData phantomItemData in ModelBase<InventoryModel>.Instance.GetPhantomItemDataList())
		{
			if (!phantomItemData.GetIsLock())
			{
				int uniqueId = phantomItemData.GetUniqueId();
				PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(uniqueId);
				int id = phantomItemData.GetFetterGroupConfig().Value.Id;
				bool flag;
				if (this.IsUsingMap.TryGetValue(id, out flag) && flag && this.IsPhantomSmartPlanDataValid(phantomBattleData))
				{
					int id2 = phantomBattleData.GetMainPropShowAttributeList(CommonComponentDefine.EAttributeType.PhantomType, false)[0].Id;
					PhantomManagerConfigNewSettingDetailInfo data = new PhantomManagerConfigNewSettingDetailInfo
					{
						FetterId = id,
						Cost = phantomBattleData.GetCost(),
						MainPropId = id2,
						IsEdit = true
					};
					if (this.GetPropCurrentState(data) == EPhantomManagerConfigState.Discard && !phantomItemData.GetIsDeprecated())
					{
						list.Add(phantomItemData);
					}
				}
			}
		}
		return list;
	}

	// Token: 0x06011FEC RID: 73708 RVA: 0x004F3D1C File Offset: 0x004F1F1C
	public List<PhantomItemData> GetPhantomSmartDiscardRecommendPlan()
	{
		List<PhantomItemData> list = new List<PhantomItemData>();
		if (this.RecommendAllDiscardMap.Count == 0)
		{
			foreach (PhantomManagePlanV2 phantomManagePlanV in ConfigBase<PhantomBattleConfig>.Instance.GetPhantomManagerPlanAll())
			{
				if (phantomManagePlanV.DiscardGroupLength != 0)
				{
					if (!this.RecommendAllDiscardMap.ContainsKey(phantomManagePlanV.FetterId))
					{
						this.RecommendAllDiscardMap[phantomManagePlanV.FetterId] = new Dictionary<int, HashSet<int>>();
					}
					this.RecommendAllDiscardMap[phantomManagePlanV.FetterId][phantomManagePlanV.Cost] = new HashSet<int>(phantomManagePlanV.GetDiscardGroupBytes().ToArray());
				}
			}
		}
		foreach (PhantomItemData phantomItemData in ModelBase<InventoryModel>.Instance.GetPhantomItemDataList())
		{
			if (!phantomItemData.GetIsLock())
			{
				int uniqueId = phantomItemData.GetUniqueId();
				PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(uniqueId);
				int id = phantomItemData.GetFetterGroupConfig().Value.Id;
				if (this.IsPhantomSmartPlanDataValid(phantomBattleData))
				{
					int cost = phantomBattleData.GetCost();
					Dictionary<int, HashSet<int>> dictionary;
					HashSet<int> hashSet;
					if (this.RecommendAllDiscardMap.TryGetValue(id, out dictionary) && dictionary.TryGetValue(cost, out hashSet))
					{
						int id2 = phantomBattleData.GetMainPropShowAttributeList(CommonComponentDefine.EAttributeType.PhantomType, false)[0].Id;
						if (hashSet.Contains(id2))
						{
							list.Add(phantomItemData);
						}
					}
				}
			}
		}
		return list;
	}

	// Token: 0x06011FED RID: 73709 RVA: 0x004F3EC4 File Offset: 0x004F20C4
	public void DoLogReport(List<int> fetterList, bool isRecommendAll = false)
	{
		foreach (int num in fetterList)
		{
			PhantomDiscardLockPlanReport phantomDiscardLockPlanReport = new PhantomDiscardLockPlanReport();
			PhantomManagerConfigFetterData phantomManagerConfigFetterData;
			this.FetterMap.TryGetValue(num, out phantomManagerConfigFetterData);
			phantomDiscardLockPlanReport.i_suit_id = num;
			phantomDiscardLockPlanReport.i_success = ((this.GetFetterConfigIsOpen(num) > false) ? 1 : 0);
			phantomDiscardLockPlanReport.i_type = ((phantomManagerConfigFetterData != null && !phantomManagerConfigFetterData.GetEditFetterConfigRecommendDirty()) ? 1 : 0);
			phantomDiscardLockPlanReport.i_if_finish = ((isRecommendAll > false) ? 1 : 0);
			if (phantomManagerConfigFetterData != null)
			{
				phantomDiscardLockPlanReport.o_setting_plan = phantomManagerConfigFetterData.GetLogReport();
			}
			ControllerBase<LogReportController>.Instance.LogReport(phantomDiscardLockPlanReport);
		}
	}

	// Token: 0x06011FEE RID: 73710 RVA: 0x004F3F70 File Offset: 0x004F2170
	private bool IsPhantomSmartPlanDataValid(PhantomBattleData phantomBattleData)
	{
		return phantomBattleData.GetVisionNoCultivated() && !phantomBattleData.GetIsDeprecated() && !ControllerBase<PhantomBattleController>.Instance.CheckIsEquip(phantomBattleData.GetUniqueId());
	}

	// Token: 0x04008CE5 RID: 36069
	protected readonly Dictionary<int, PhantomManagerConfigFetterData> FetterMap = new Dictionary<int, PhantomManagerConfigFetterData>();

	// Token: 0x04008CE6 RID: 36070
	public Dictionary<int, bool> IsUsingMap = new Dictionary<int, bool>();

	// Token: 0x04008CE7 RID: 36071
	public string SelfPhantomConfigCode = string.Empty;

	// Token: 0x04008CE8 RID: 36072
	public bool PhantomSelfConfigNeedUpdate;

	// Token: 0x04008CE9 RID: 36073
	public bool DownFiveStarSwitch;

	// Token: 0x04008CEA RID: 36074
	public HashSet<EConfirmBoxConfigId> ConfirmBoxLoginSet = new HashSet<EConfirmBoxConfigId>();

	// Token: 0x04008CEB RID: 36075
	public EPhantomManagerEditCloseState ConfigViewEditCloseSelect;

	// Token: 0x04008CEC RID: 36076
	public EPhantomManagerEditCloseState ConfigViewShareUpdateSelect;

	// Token: 0x04008CED RID: 36077
	public long LastSharedCheckTime;

	// Token: 0x04008CEE RID: 36078
	protected readonly Dictionary<int, Dictionary<int, HashSet<int>>> RecommendAllDiscardMap = new Dictionary<int, Dictionary<int, HashSet<int>>>();
}
