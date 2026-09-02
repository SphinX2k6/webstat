using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.ItemReward;

// Token: 0x02001CBD RID: 7357
[NullableContext(1)]
[Nullable(0)]
public class GachaAccumulateData
{
	// Token: 0x17001144 RID: 4420
	// (get) Token: 0x0600D7DD RID: 55261 RVA: 0x0039B710 File Offset: 0x00399910
	public bool HasClaimable
	{
		get
		{
			if (this.GroupData == null)
			{
				return false;
			}
			int cyclicBaseGachaNum = this.GetCyclicBaseGachaNum();
			foreach (GachaAccumulateRewardData gachaAccumulateRewardData in this.GroupData.RewardInfos)
			{
				if (gachaAccumulateRewardData.GetIfCyclic())
				{
					if (gachaAccumulateRewardData.GetCyclicPendingClaimCount(this.CurGachaNum, cyclicBaseGachaNum) > 0)
					{
						return true;
					}
				}
				else if (gachaAccumulateRewardData.Status == EGachaAccumulateRewardStatus.CanClaim)
				{
					return true;
				}
			}
			return false;
		}
	}

	// Token: 0x0600D7DE RID: 55262 RVA: 0x0039B7A0 File Offset: 0x003999A0
	public List<int> CollectAllClaimableRewardIds()
	{
		List<int> list = new List<int>();
		if (this.GroupData == null)
		{
			return list;
		}
		int cyclicBaseGachaNum = this.GetCyclicBaseGachaNum();
		foreach (GachaAccumulateRewardData gachaAccumulateRewardData in this.GroupData.RewardInfos)
		{
			if (!gachaAccumulateRewardData.GetIfResonantGift())
			{
				if (gachaAccumulateRewardData.GetIfCyclic())
				{
					if (gachaAccumulateRewardData.GetCyclicPendingClaimCount(this.CurGachaNum, cyclicBaseGachaNum) > 0)
					{
						list.Add(gachaAccumulateRewardData.Id);
					}
				}
				else if (gachaAccumulateRewardData.Status == EGachaAccumulateRewardStatus.CanClaim)
				{
					list.Add(gachaAccumulateRewardData.Id);
				}
			}
		}
		return list;
	}

	// Token: 0x17001145 RID: 4421
	// (get) Token: 0x0600D7DF RID: 55263 RVA: 0x0039B84C File Offset: 0x00399A4C
	public int CurGachaNum
	{
		get
		{
			GachaAccumulateGroupData groupData = this.GroupData;
			if (groupData == null)
			{
				return 0;
			}
			return groupData.CurGachaNum;
		}
	}

	// Token: 0x0600D7E0 RID: 55264 RVA: 0x0039B860 File Offset: 0x00399A60
	public double GetCurrentGachaProgress()
	{
		GachaAccumulateGroupData groupData = this.GroupData;
		int num = (groupData != null && groupData.RewardInfos.Count > 0) ? this.GroupData.RewardInfos[this.GroupData.RewardInfos.Count - 1].GachaNum : 0;
		if (num == 0)
		{
			return 0.0;
		}
		return (double)this.CurGachaNum / (double)num;
	}

	// Token: 0x0600D7E1 RID: 55265 RVA: 0x0039B8CC File Offset: 0x00399ACC
	[NullableContext(0)]
	public ValueTuple<int, int> GetProgress()
	{
		int num = 0;
		GachaAccumulateGroupData groupData = this.GroupData;
		List<GachaAccumulateRewardData> list = ((groupData != null) ? groupData.RewardInfos : null) ?? new List<GachaAccumulateRewardData>();
		int cyclicBaseGachaNum = this.GetCyclicBaseGachaNum();
		foreach (GachaAccumulateRewardData gachaAccumulateRewardData in list)
		{
			if (gachaAccumulateRewardData.GetIfCyclic())
			{
				num += gachaAccumulateRewardData.GetCyclicPendingClaimCount(this.CurGachaNum, cyclicBaseGachaNum);
			}
			else if (gachaAccumulateRewardData.Status != EGachaAccumulateRewardStatus.NotReached)
			{
				num++;
			}
		}
		return new ValueTuple<int, int>(num, list.Count);
	}

	// Token: 0x0600D7E2 RID: 55266 RVA: 0x0039B970 File Offset: 0x00399B70
	[NullableContext(2)]
	public RewardItemData GetTipsShowReward()
	{
		GachaAccumulateGroupData groupData = this.GroupData;
		List<GachaAccumulateRewardData> list = ((groupData != null) ? groupData.RewardInfos : null) ?? new List<GachaAccumulateRewardData>();
		foreach (GachaAccumulateRewardData gachaAccumulateRewardData in list)
		{
			if (!gachaAccumulateRewardData.GetIfCyclic() && gachaAccumulateRewardData.Status == EGachaAccumulateRewardStatus.NotReached)
			{
				RewardItemData[] rewardItemList = gachaAccumulateRewardData.GetRewardItemList();
				return (rewardItemList.Length != 0) ? rewardItemList[0] : null;
			}
		}
		GachaAccumulateRewardData gachaAccumulateRewardData2 = list.Find((GachaAccumulateRewardData r) => r.GetIfCyclic());
		bool flag = this.CurGachaNum >= this.GetCyclicBaseGachaNum();
		if (gachaAccumulateRewardData2 != null && (gachaAccumulateRewardData2.IsPreView || flag))
		{
			RewardItemData[] rewardItemList2 = gachaAccumulateRewardData2.GetRewardItemList();
			if (rewardItemList2.Length == 0)
			{
				return null;
			}
			return rewardItemList2[0];
		}
		else
		{
			List<GachaAccumulateRewardData> list2 = (from r in list
			where !r.GetIfCyclic()
			select r).ToList<GachaAccumulateRewardData>();
			if (list2.Count == 0)
			{
				return null;
			}
			RewardItemData[] rewardItemList3 = list2[list2.Count - 1].GetRewardItemList();
			if (rewardItemList3.Length == 0)
			{
				return null;
			}
			return rewardItemList3[0];
		}
		RewardItemData result;
		return result;
	}

	// Token: 0x0600D7E3 RID: 55267 RVA: 0x0039BAB4 File Offset: 0x00399CB4
	public bool GetIfFinishAll()
	{
		GachaAccumulateGroupData groupData = this.GroupData;
		using (List<GachaAccumulateRewardData>.Enumerator enumerator = (((groupData != null) ? groupData.RewardInfos : null) ?? new List<GachaAccumulateRewardData>()).GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Status == EGachaAccumulateRewardStatus.NotReached)
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x0600D7E4 RID: 55268 RVA: 0x0039BB24 File Offset: 0x00399D24
	public int GetUnTakeRewardNum()
	{
		int num = 0;
		GachaAccumulateGroupData groupData = this.GroupData;
		using (List<GachaAccumulateRewardData>.Enumerator enumerator = (((groupData != null) ? groupData.RewardInfos : null) ?? new List<GachaAccumulateRewardData>()).GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Status == EGachaAccumulateRewardStatus.CanClaim)
				{
					num++;
				}
			}
		}
		return num;
	}

	// Token: 0x0600D7E5 RID: 55269 RVA: 0x0039BB94 File Offset: 0x00399D94
	public bool GetIfTakeAllReward()
	{
		using (List<GachaAccumulateRewardData>.Enumerator enumerator = this.GroupData.RewardInfos.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Status != EGachaAccumulateRewardStatus.Claimed)
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x0600D7E6 RID: 55270 RVA: 0x0039BBF4 File Offset: 0x00399DF4
	public int GetNextRewardNeedGachaNum()
	{
		if (this.GroupData == null)
		{
			return 0;
		}
		foreach (GachaAccumulateRewardData gachaAccumulateRewardData in this.GroupData.RewardInfos)
		{
			if (!gachaAccumulateRewardData.GetIfCyclic() && gachaAccumulateRewardData.Status == EGachaAccumulateRewardStatus.NotReached)
			{
				return gachaAccumulateRewardData.GachaNum - this.CurGachaNum;
			}
		}
		int cyclicBaseGachaNum = this.GetCyclicBaseGachaNum();
		foreach (GachaAccumulateRewardData gachaAccumulateRewardData2 in this.GroupData.RewardInfos)
		{
			if (gachaAccumulateRewardData2.GetIfCyclic() && gachaAccumulateRewardData2.GachaNum > 0 && !this.IsCyclicAchievedFull(gachaAccumulateRewardData2))
			{
				int gachaNum = gachaAccumulateRewardData2.GachaNum;
				int num = (this.CurGachaNum - cyclicBaseGachaNum) % gachaNum;
				return (num == 0) ? gachaNum : (gachaNum - num);
			}
		}
		return 0;
	}

	// Token: 0x0600D7E7 RID: 55271 RVA: 0x0039BD00 File Offset: 0x00399F00
	public int GetCyclicBaseGachaNum()
	{
		int num = 0;
		GachaAccumulateGroupData groupData = this.GroupData;
		foreach (GachaAccumulateRewardData gachaAccumulateRewardData in (((groupData != null) ? groupData.RewardInfos : null) ?? new List<GachaAccumulateRewardData>()))
		{
			if (!gachaAccumulateRewardData.GetIfCyclic() && gachaAccumulateRewardData.GachaNum > num)
			{
				num = gachaAccumulateRewardData.GachaNum;
			}
		}
		return num;
	}

	// Token: 0x0600D7E8 RID: 55272 RVA: 0x0039BD7C File Offset: 0x00399F7C
	public bool IsCyclicExhausted(GachaAccumulateRewardData reward)
	{
		return reward.GetIfCyclic() && reward.CycleCount != -1 && reward.CycleRewardedTimes >= reward.CycleCount;
	}

	// Token: 0x0600D7E9 RID: 55273 RVA: 0x0039BDA4 File Offset: 0x00399FA4
	public int GetCyclicAchievedTimes(GachaAccumulateRewardData reward)
	{
		if (!reward.GetIfCyclic() || reward.GachaNum <= 0)
		{
			return 0;
		}
		int cyclicBaseGachaNum = this.GetCyclicBaseGachaNum();
		if (this.CurGachaNum < cyclicBaseGachaNum)
		{
			return 0;
		}
		return (int)Math.Floor((double)(this.CurGachaNum - cyclicBaseGachaNum) / (double)reward.GachaNum);
	}

	// Token: 0x0600D7EA RID: 55274 RVA: 0x0039BDED File Offset: 0x00399FED
	public bool IsCyclicAchievedFull(GachaAccumulateRewardData reward)
	{
		return reward.GetIfCyclic() && reward.CycleCount != -1 && this.GetCyclicAchievedTimes(reward) >= reward.CycleCount;
	}

	// Token: 0x0600D7EB RID: 55275 RVA: 0x0039BE14 File Offset: 0x0039A014
	public bool GetIfAllRewardAchieved()
	{
		if (this.GroupData == null)
		{
			return false;
		}
		foreach (GachaAccumulateRewardData gachaAccumulateRewardData in this.GroupData.RewardInfos)
		{
			if (gachaAccumulateRewardData.GetIfCyclic())
			{
				if (gachaAccumulateRewardData.CycleCount == -1)
				{
					return false;
				}
				if (!this.IsCyclicAchievedFull(gachaAccumulateRewardData))
				{
					return false;
				}
			}
			else if (gachaAccumulateRewardData.Status == EGachaAccumulateRewardStatus.NotReached)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0600D7EC RID: 55276 RVA: 0x0039BEA0 File Offset: 0x0039A0A0
	public bool GetIfTakeAllRewardIncludingCyclic()
	{
		if (this.GroupData == null)
		{
			return false;
		}
		foreach (GachaAccumulateRewardData gachaAccumulateRewardData in this.GroupData.RewardInfos)
		{
			if (gachaAccumulateRewardData.GetIfCyclic())
			{
				if (gachaAccumulateRewardData.CycleCount == -1)
				{
					return false;
				}
				if (!this.IsCyclicExhausted(gachaAccumulateRewardData))
				{
					return false;
				}
			}
			else if (gachaAccumulateRewardData.Status != EGachaAccumulateRewardStatus.Claimed)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x040066CD RID: 26317
	public int AccumulateId;

	// Token: 0x040066CE RID: 26318
	[Nullable(2)]
	public GachaAccumulateGroupData GroupData;
}
