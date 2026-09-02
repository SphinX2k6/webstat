using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001FDD RID: 8157
public class InfluenceInstance
{
	// Token: 0x17001283 RID: 4739
	// (get) Token: 0x0600F632 RID: 63026 RVA: 0x004367CC File Offset: 0x004349CC
	public EInfluenceRelation Relation
	{
		get
		{
			return this.RelationInternal;
		}
	}

	// Token: 0x0600F633 RID: 63027 RVA: 0x004367D4 File Offset: 0x004349D4
	public void SetRelation(EInfluenceRelation relation)
	{
		this.RelationInternal = relation;
	}

	// Token: 0x0600F634 RID: 63028 RVA: 0x004367DD File Offset: 0x004349DD
	public InfluenceInstance(int id, int rewardIndex, int relation)
	{
		this.Id = id;
		this.RewardIndexInternal = rewardIndex;
		this.RelationInternal = (EInfluenceRelation)relation;
	}

	// Token: 0x17001284 RID: 4740
	// (get) Token: 0x0600F635 RID: 63029 RVA: 0x004367FA File Offset: 0x004349FA
	public int RewardIndex
	{
		get
		{
			return this.RewardIndexInternal;
		}
	}

	// Token: 0x0600F636 RID: 63030 RVA: 0x00436802 File Offset: 0x00434A02
	public void SetReceiveReward(int rewardIndex)
	{
		this.RewardIndexInternal = rewardIndex;
	}

	// Token: 0x0600F637 RID: 63031 RVA: 0x0043680C File Offset: 0x00434A0C
	[return: TupleElementNames(new string[]
	{
		"IsReceived",
		"Reward"
	})]
	public ValueTuple<bool, IntPair> GetCanReceiveReward()
	{
		Influence? influenceConfig = ConfigBase<InfluenceConfig>.Instance.GetInfluenceConfig(this.Id);
		if (influenceConfig == null)
		{
			return new ValueTuple<bool, IntPair>(false, default(IntPair));
		}
		IntPair[] array = influenceConfig.Value.ReputationReward();
		if (array.Length == this.RewardIndex + 1)
		{
			return new ValueTuple<bool, IntPair>(true, array[this.RewardIndex]);
		}
		return new ValueTuple<bool, IntPair>(false, array[this.RewardIndex + 1]);
	}

	// Token: 0x0600F638 RID: 63032 RVA: 0x00436888 File Offset: 0x00434A88
	[NullableContext(1)]
	public IReadOnlyList<IntPair> GetReward()
	{
		Influence? influenceConfig = ConfigBase<InfluenceConfig>.Instance.GetInfluenceConfig(this.Id);
		if (influenceConfig != null)
		{
			List<IntPair> list = new List<IntPair>();
			foreach (IntPair item in influenceConfig.Value.ReputationReward())
			{
				list.Add(item);
			}
			return list;
		}
		return new List<IntPair>();
	}

	// Token: 0x04007706 RID: 30470
	public readonly int Id;

	// Token: 0x04007707 RID: 30471
	private int RewardIndexInternal;

	// Token: 0x04007708 RID: 30472
	private EInfluenceRelation RelationInternal;
}
