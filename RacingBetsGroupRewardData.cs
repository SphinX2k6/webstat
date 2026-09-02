using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020026E7 RID: 9959
[NullableContext(1)]
[Nullable(0)]
public class RacingBetsGroupRewardData
{
	// Token: 0x06013A6B RID: 80491 RVA: 0x0057AA2C File Offset: 0x00578C2C
	public RacingBetsGroupRewardData(int id)
	{
		this.Id = id;
	}

	// Token: 0x06013A6C RID: 80492 RVA: 0x0057AA48 File Offset: 0x00578C48
	public void AddRewardData(RacingBetsRewardData rewardData)
	{
		using (List<RacingBetsRewardData>.Enumerator enumerator = this.RewardDataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Id == rewardData.Id)
				{
					return;
				}
			}
		}
		this.RewardDataList.Add(rewardData);
	}

	// Token: 0x06013A6D RID: 80493 RVA: 0x0057AAB0 File Offset: 0x00578CB0
	public List<RacingBetsRewardData> GetRewardDataList()
	{
		List<RacingBetsRewardData> list = new List<RacingBetsRewardData>(this.RewardDataList);
		list.Sort(delegate(RacingBetsRewardData a, RacingBetsRewardData b)
		{
			int num = (!a.CanReceiveReward()) ? 1 : 0;
			int num2 = (!b.CanReceiveReward()) ? 1 : 0;
			if (num != num2)
			{
				return num.CompareTo(num2);
			}
			int num3 = (a.IsTaskReceived() > false) ? 1 : 0;
			int num4 = (b.IsTaskReceived() > false) ? 1 : 0;
			if (num3 != num4)
			{
				return num3.CompareTo(num4);
			}
			return a.Id.CompareTo(b.Id);
		});
		return list;
	}

	// Token: 0x06013A6E RID: 80494 RVA: 0x0057AAE4 File Offset: 0x00578CE4
	public bool CanReceiveRewards()
	{
		using (List<RacingBetsRewardData>.Enumerator enumerator = this.RewardDataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.CanReceiveReward())
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x040098DC RID: 39132
	public readonly int Id;

	// Token: 0x040098DD RID: 39133
	private readonly List<RacingBetsRewardData> RewardDataList = new List<RacingBetsRewardData>();
}
