using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020017E9 RID: 6121
[NullableContext(1)]
[Nullable(0)]
public class CalabashDevelopRewardData
{
	// Token: 0x0600ADC2 RID: 44482 RVA: 0x002E3664 File Offset: 0x002E1864
	public CalabashDevelopRewardData(CalabashDevelopReward developReward, string skillName)
	{
		this.DevelopReward = developReward;
		this.SkillName = skillName;
		this.UnlockConditionMap = new Dictionary<int, bool>();
	}

	// Token: 0x17000E3B RID: 3643
	// (get) Token: 0x0600ADC3 RID: 44483 RVA: 0x002E3685 File Offset: 0x002E1885
	// (set) Token: 0x0600ADC4 RID: 44484 RVA: 0x002E368D File Offset: 0x002E188D
	public bool UnlockData
	{
		get
		{
			return this.Unlock;
		}
		set
		{
			this.Unlock = value;
		}
	}

	// Token: 0x17000E3C RID: 3644
	// (get) Token: 0x0600ADC5 RID: 44485 RVA: 0x002E3696 File Offset: 0x002E1896
	// (set) Token: 0x0600ADC6 RID: 44486 RVA: 0x002E369E File Offset: 0x002E189E
	public int RewardNumData
	{
		get
		{
			return this.RewardNum;
		}
		set
		{
			this.RewardNum = value;
		}
	}

	// Token: 0x17000E3D RID: 3645
	// (get) Token: 0x0600ADC7 RID: 44487 RVA: 0x002E36A7 File Offset: 0x002E18A7
	public CalabashDevelopReward DevelopRewardData
	{
		get
		{
			return this.DevelopReward;
		}
	}

	// Token: 0x17000E3E RID: 3646
	// (get) Token: 0x0600ADC8 RID: 44488 RVA: 0x002E36B0 File Offset: 0x002E18B0
	public int RewardSumNumData
	{
		get
		{
			return this.DevelopRewardData.DevelopCondition().Length;
		}
	}

	// Token: 0x0600ADC9 RID: 44489 RVA: 0x002E36D0 File Offset: 0x002E18D0
	public void SetUnlockConditionMap(List<ICalabashDevelopConditionState> list)
	{
		foreach (ICalabashDevelopConditionState calabashDevelopConditionState in list)
		{
			this.UnlockConditionMap[calabashDevelopConditionState.ConditionId] = calabashDevelopConditionState.Rewarded;
		}
	}

	// Token: 0x0600ADCA RID: 44490 RVA: 0x002E3730 File Offset: 0x002E1930
	public Dictionary<int, bool> GetUnlockConditionMap()
	{
		return this.UnlockConditionMap;
	}

	// Token: 0x17000E3F RID: 3647
	// (get) Token: 0x0600ADCB RID: 44491 RVA: 0x002E3738 File Offset: 0x002E1938
	public int UnlockSize
	{
		get
		{
			return this.UnlockConditionMap.Count;
		}
	}

	// Token: 0x0600ADCC RID: 44492 RVA: 0x002E3748 File Offset: 0x002E1948
	public bool CheckCanGetReward()
	{
		using (Dictionary<int, bool>.ValueCollection.Enumerator enumerator = this.UnlockConditionMap.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (!enumerator.Current)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0400524D RID: 21069
	private bool Unlock;

	// Token: 0x0400524E RID: 21070
	private int RewardNum;

	// Token: 0x0400524F RID: 21071
	private readonly Dictionary<int, bool> UnlockConditionMap;

	// Token: 0x04005250 RID: 21072
	public CalabashDevelopReward DevelopReward;

	// Token: 0x04005251 RID: 21073
	public readonly string SkillName;
}
