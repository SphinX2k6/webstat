using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020027BE RID: 10174
[NullableContext(1)]
[Nullable(0)]
public class RoleResonanceData : RoleModuleDataBase
{
	// Token: 0x060141E5 RID: 82405 RVA: 0x0059E7B9 File Offset: 0x0059C9B9
	public RoleResonanceData(int roleId) : base(roleId)
	{
	}

	// Token: 0x060141E6 RID: 82406 RVA: 0x0059E7D8 File Offset: 0x0059C9D8
	public void SetResonance(ResonanceDataInfo resonance)
	{
		this.ResonanceInfoMap[resonance.ResonId] = resonance;
	}

	// Token: 0x060141E7 RID: 82407 RVA: 0x0059E7EC File Offset: 0x0059C9EC
	[NullableContext(2)]
	public ResonanceDataInfo GetResonance(int id)
	{
		ResonanceDataInfo result;
		if (!this.ResonanceInfoMap.TryGetValue(id, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x060141E8 RID: 82408 RVA: 0x0059E80C File Offset: 0x0059CA0C
	public void SetResonanceLock(int resonanceId)
	{
		this.ResonanceLockSet.Add(resonanceId);
	}

	// Token: 0x060141E9 RID: 82409 RVA: 0x0059E81B File Offset: 0x0059CA1B
	public void SetResonantChainGroupIndex(int index)
	{
		this.ResonantChainGroupIndex = index;
	}

	// Token: 0x060141EA RID: 82410 RVA: 0x0059E824 File Offset: 0x0059CA24
	public int GetResonantChainGroupIndex()
	{
		return this.ResonantChainGroupIndex;
	}

	// Token: 0x060141EB RID: 82411 RVA: 0x0059E82C File Offset: 0x0059CA2C
	public bool CheckFrontResonanceOpen(int id, int groupId)
	{
		return true;
	}

	// Token: 0x060141EC RID: 82412 RVA: 0x0059E830 File Offset: 0x0059CA30
	public bool IsEnoughResonanceActive(int resonanceId)
	{
		ResonantChain? roleResonanceById = ConfigBase<RoleResonanceConfig>.Instance.GetRoleResonanceById(resonanceId);
		if (roleResonanceById == null)
		{
			return false;
		}
		if (!this.CheckFrontResonanceOpen(roleResonanceById.Value.Id, roleResonanceById.Value.GroupId))
		{
			return false;
		}
		if (!true)
		{
			return false;
		}
		foreach (DicIntInt dicIntInt in roleResonanceById.Value.ActivateConsumeIter())
		{
			if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(dicIntInt.Key, 0) < dicIntInt.Value)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x060141ED RID: 82413 RVA: 0x0059E8EC File Offset: 0x0059CAEC
	public int GetResonanceLevel()
	{
		int num = 0;
		using (Dictionary<int, ResonanceDataInfo>.ValueCollection.Enumerator enumerator = this.ResonanceInfoMap.Values.GetEnumerator())
		{
			while (enumerator.MoveNext() && enumerator.Current.IsOpen)
			{
				num++;
			}
		}
		return num;
	}

	// Token: 0x060141EE RID: 82414 RVA: 0x0059E94C File Offset: 0x0059CB4C
	public int GetResonanceIncreaseLevel()
	{
		int num = 0;
		foreach (ResonanceDataInfo resonanceDataInfo in this.ResonanceInfoMap.Values)
		{
			if (!resonanceDataInfo.IsOpen)
			{
				break;
			}
			num += resonanceDataInfo.Increase;
		}
		return num;
	}

	// Token: 0x060141EF RID: 82415 RVA: 0x0059E9B4 File Offset: 0x0059CBB4
	public bool IsResonanceFullyUnLock()
	{
		int resonanceId = base.GetRoleConfig().ResonanceId;
		foreach (ResonantChain resonantChain in ConfigBase<RoleResonanceConfig>.Instance.GetRoleResonanceList(resonanceId))
		{
			ResonanceDataInfo resonance = this.GetResonance(resonantChain.Id);
			if (resonance == null || !resonance.IsOpen)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x060141F0 RID: 82416 RVA: 0x0059EA3C File Offset: 0x0059CC3C
	public void CopyFrom(RoleResonanceData data)
	{
		this.ResonantChainGroupIndex = data.ResonantChainGroupIndex;
		this.ResonanceInfoMap.Clear();
		foreach (KeyValuePair<int, ResonanceDataInfo> keyValuePair in data.ResonanceInfoMap)
		{
			ResonanceDataInfo value = keyValuePair.Value;
			this.ResonanceInfoMap[keyValuePair.Key] = new ResonanceDataInfo(value.ResonId, value.IsOpen, value.Increase);
		}
		this.ResonanceLockSet.Clear();
		foreach (int item in data.ResonanceLockSet)
		{
			this.ResonanceLockSet.Add(item);
		}
	}

	// Token: 0x060141F1 RID: 82417 RVA: 0x0059EB28 File Offset: 0x0059CD28
	public void Clear()
	{
		this.ResonantChainGroupIndex = 0;
		this.ResonanceInfoMap.Clear();
		this.ResonanceLockSet.Clear();
	}

	// Token: 0x04009C79 RID: 40057
	protected int ResonantChainGroupIndex;

	// Token: 0x04009C7A RID: 40058
	protected Dictionary<int, ResonanceDataInfo> ResonanceInfoMap = new Dictionary<int, ResonanceDataInfo>();

	// Token: 0x04009C7B RID: 40059
	protected HashSet<int> ResonanceLockSet = new HashSet<int>();
}
