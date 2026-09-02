using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020013D0 RID: 5072
[NullableContext(1)]
[Nullable(0)]
public class DelegationData
{
	// Token: 0x06008C2C RID: 35884 RVA: 0x0024DEFB File Offset: 0x0024C0FB
	public DelegationData(int id, int bestEvaluateLevel, bool isVisible)
	{
		this.Id = id;
		this.BestEvaluateLevelInternal = bestEvaluateLevel;
		this.IsVisible = isVisible;
	}

	// Token: 0x06008C2D RID: 35885 RVA: 0x0024DF18 File Offset: 0x0024C118
	public List<IItemData> GetConsumeList()
	{
		List<IItemData> list = new List<IItemData>();
		foreach (DicIntInt dicIntInt in ConfigBase<BusinessConfig>.Instance.GetDelegationConfig(this.Id).ConsumeIter())
		{
			list.Add(new ItemData
			{
				ItemId = dicIntInt.Key,
				Count = dicIntInt.Value
			});
		}
		return list;
	}

	// Token: 0x06008C2E RID: 35886 RVA: 0x0024DF9C File Offset: 0x0024C19C
	public List<int> GetRecommendList()
	{
		List<int> list = new List<int>();
		foreach (DicIntInt dicIntInt in ConfigBase<BusinessConfig>.Instance.GetDelegationConfig(this.Id).CapacityMapIter())
		{
			list.Add(dicIntInt.Key);
		}
		return list;
	}

	// Token: 0x06008C2F RID: 35887 RVA: 0x0024E008 File Offset: 0x0024C208
	public string GetLockText()
	{
		return ConfigMultiTextLang.GetLocalTextNew(LevelGeneralCommons.GetConditionGroupHintText(ConfigBase<BusinessConfig>.Instance.GetDelegationConfig(this.Id).UnlockCondition), null);
	}

	// Token: 0x06008C30 RID: 35888 RVA: 0x0024E038 File Offset: 0x0024C238
	public bool HasBestEvaluate()
	{
		return this.BestEvaluateLevelInternal > 0;
	}

	// Token: 0x06008C31 RID: 35889 RVA: 0x0024E043 File Offset: 0x0024C243
	public void SetBestEvaluateLevel(int value)
	{
		if (this.BestEvaluateLevelInternal > value)
		{
			return;
		}
		this.BestEvaluateLevelInternal = value;
	}

	// Token: 0x17000BD4 RID: 3028
	// (get) Token: 0x06008C32 RID: 35890 RVA: 0x0024E056 File Offset: 0x0024C256
	public int BestEvaluateLevel
	{
		get
		{
			return this.BestEvaluateLevelInternal;
		}
	}

	// Token: 0x06008C33 RID: 35891 RVA: 0x0024E060 File Offset: 0x0024C260
	public int GetNotEnoughConsumeItemId()
	{
		foreach (IItemData itemData in this.GetConsumeList())
		{
			if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(itemData.ItemId, 0) < itemData.Count)
			{
				return itemData.ItemId;
			}
		}
		return -1;
	}

	// Token: 0x04004152 RID: 16722
	public readonly int Id;

	// Token: 0x04004153 RID: 16723
	private int BestEvaluateLevelInternal;

	// Token: 0x04004154 RID: 16724
	public readonly bool IsVisible;
}
