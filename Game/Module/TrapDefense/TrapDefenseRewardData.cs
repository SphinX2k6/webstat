using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004D96 RID: 19862
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseRewardData
	{
		// Token: 0x06033700 RID: 210688 RVA: 0x00CDD145 File Offset: 0x00CDB345
		public static TrapDefenseRewardData Create(int activityId)
		{
			TrapDefenseRewardData trapDefenseRewardData = new TrapDefenseRewardData();
			trapDefenseRewardData.ActivityId = activityId;
			trapDefenseRewardData.Init();
			return trapDefenseRewardData;
		}

		// Token: 0x06033701 RID: 210689 RVA: 0x00CDD15C File Offset: 0x00CDB35C
		public void UpdateRewardsByServerData(TrapDefenseRewardInfo[] serverDataList)
		{
			foreach (TrapDefenseRewardInfo trapDefenseRewardInfo in serverDataList)
			{
				ConditionTask taskInfo = trapDefenseRewardInfo.TaskInfo;
				int key = (taskInfo != null) ? taskInfo.Id : 0;
				TrapDefenseRewardItemData trapDefenseRewardItemData;
				if (this.RewardDataMap.TryGetValue(key, out trapDefenseRewardItemData))
				{
					trapDefenseRewardItemData.UpdateByServerData(trapDefenseRewardInfo);
				}
			}
		}

		// Token: 0x06033702 RID: 210690 RVA: 0x00CDD1A8 File Offset: 0x00CDB3A8
		public void SetLimitTime(long beginTime, long endTime)
		{
			this.LimitBeginTime = beginTime;
			this.LimitEndTime = endTime;
		}

		// Token: 0x06033703 RID: 210691 RVA: 0x00CDD1B8 File Offset: 0x00CDB3B8
		public void SetLimitTime(int beginTime, int endTime)
		{
			this.LimitBeginTime = (long)beginTime;
			this.LimitEndTime = (long)endTime;
		}

		// Token: 0x06033704 RID: 210692 RVA: 0x00CDD1CC File Offset: 0x00CDB3CC
		public List<TrapDefenseRewardItemData> GetRewardListByType(ETrapDefenseRewardType type)
		{
			List<TrapDefenseRewardItemData> list;
			if (this.RewardTypeMap.TryGetValue(type, out list))
			{
				list.Sort(new Comparison<TrapDefenseRewardItemData>(this.RewardListSortFunc));
				return list;
			}
			return new List<TrapDefenseRewardItemData>();
		}

		// Token: 0x06033705 RID: 210693 RVA: 0x00CDD204 File Offset: 0x00CDB404
		[NullableContext(0)]
		public ValueTuple<int, int> GetRewardProgressByType(ETrapDefenseRewardType type)
		{
			List<TrapDefenseRewardItemData> rewardListByType = this.GetRewardListByType(type);
			int num = 0;
			using (List<TrapDefenseRewardItemData>.Enumerator enumerator = rewardListByType.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.State == ETrapDefenseRewardState.Claimed)
					{
						num++;
					}
				}
			}
			return new ValueTuple<int, int>(num, rewardListByType.Count);
		}

		// Token: 0x06033706 RID: 210694 RVA: 0x00CDD26C File Offset: 0x00CDB46C
		[NullableContext(0)]
		public ValueTuple<int, int> GetLimitRewardTotalProgress()
		{
			int num = 0;
			int num2 = 0;
			for (int i = 1; i < 5; i++)
			{
				ETrapDefenseRewardType type = (ETrapDefenseRewardType)i;
				ValueTuple<int, int> rewardProgressByType = this.GetRewardProgressByType(type);
				int item = rewardProgressByType.Item1;
				int item2 = rewardProgressByType.Item2;
				num += item;
				num2 += item2;
			}
			num2++;
			int num3 = num;
			TrapDefenseSpecialRewardData specialRewardData = this.SpecialRewardData;
			num = num3 + (((specialRewardData != null && specialRewardData.State == ETrapDefenseRewardState.Claimed) > false) ? 1 : 0);
			return new ValueTuple<int, int>(num, num2);
		}

		// Token: 0x06033707 RID: 210695 RVA: 0x00CDD2D4 File Offset: 0x00CDB4D4
		public string GetLimitRewardRemainTimeStr()
		{
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat3((double)this.LimitEndTime * Singleton<TimeUtil>.Instance.Millisecond - serverTime);
			return ((remainTimeDataFormat != null) ? remainTimeDataFormat.CountDownText : null) ?? "";
		}

		// Token: 0x06033708 RID: 210696 RVA: 0x00CDD320 File Offset: 0x00CDB520
		public bool IsOpenLimitReward()
		{
			double startTime = (double)this.LimitBeginTime * Singleton<TimeUtil>.Instance.Millisecond;
			double endTime = (double)this.LimitEndTime * Singleton<TimeUtil>.Instance.Millisecond;
			return Singleton<TimeUtil>.Instance.IsInTimeSpan(startTime, endTime);
		}

		// Token: 0x06033709 RID: 210697 RVA: 0x00CDD360 File Offset: 0x00CDB560
		public void RequestClaimRewardByType(ETrapDefenseRewardType type)
		{
			List<int> list = new List<int>();
			foreach (TrapDefenseRewardItemData trapDefenseRewardItemData in this.GetRewardListByType(type))
			{
				if (trapDefenseRewardItemData.State == ETrapDefenseRewardState.CanClaim)
				{
					list.Add(trapDefenseRewardItemData.Id);
				}
			}
			ControllerBase<TrapDefenseController>.Instance.RequestTrapDefenseRewardClaim(list);
		}

		// Token: 0x0603370A RID: 210698 RVA: 0x00CDD3D4 File Offset: 0x00CDB5D4
		public void RequestFixedReward()
		{
			List<int> list = new List<int>();
			foreach (TrapDefenseRewardItemData trapDefenseRewardItemData in this.FixedRewardDataList)
			{
				if (trapDefenseRewardItemData.State == ETrapDefenseRewardState.CanClaim)
				{
					list.Add(trapDefenseRewardItemData.Id);
				}
			}
			ControllerBase<TrapDefenseController>.Instance.RequestTrapDefenseRewardClaim(list);
		}

		// Token: 0x0603370B RID: 210699 RVA: 0x00CDD448 File Offset: 0x00CDB648
		private void Init()
		{
			TrapDefenseConfig instance = ConfigBase<TrapDefenseConfig>.Instance;
			foreach (TrapDefenseReward config in (((instance != null) ? instance.GetRewardListByActivityId(this.ActivityId) : null) ?? Array.Empty<TrapDefenseReward>()))
			{
				ETrapDefenseRewardType type = (ETrapDefenseRewardType)config.Type;
				if (!this.RewardTypeMap.ContainsKey(type))
				{
					this.RewardTypeMap.Add(type, new List<TrapDefenseRewardItemData>());
				}
				TrapDefenseRewardItemData trapDefenseRewardItemData = TrapDefenseRewardItemData.Create(config);
				if (!config.IsPermanent)
				{
					this.RewardTypeMap[type].Add(trapDefenseRewardItemData);
				}
				this.RewardDataMap.Add(trapDefenseRewardItemData.Id, trapDefenseRewardItemData);
				if (config.IsPermanent)
				{
					this.FixedRewardDataList.Add(trapDefenseRewardItemData);
				}
			}
			foreach (List<TrapDefenseRewardItemData> list in this.RewardTypeMap.Values)
			{
				list.Sort(new Comparison<TrapDefenseRewardItemData>(this.RewardListSortFunc));
			}
			TrapDefenseConfig instance2 = ConfigBase<TrapDefenseConfig>.Instance;
			IReadOnlyList<TrapDefenseSpecialReward> readOnlyList = (instance2 != null) ? instance2.GetSpecialRewardByActivityId(this.ActivityId) : null;
			if (readOnlyList != null && readOnlyList.Count > 0)
			{
				this.SpecialRewardData = TrapDefenseSpecialRewardData.Create(readOnlyList[0]);
			}
		}

		// Token: 0x0603370C RID: 210700 RVA: 0x00CDD5A8 File Offset: 0x00CDB7A8
		private int RewardListSortFunc(TrapDefenseRewardItemData a, TrapDefenseRewardItemData b)
		{
			if (a.State != b.State)
			{
				if (a.State >= b.State)
				{
					return -1;
				}
				return 1;
			}
			else
			{
				if (a.Id <= b.Id)
				{
					return -1;
				}
				return 1;
			}
		}

		// Token: 0x0603370D RID: 210701 RVA: 0x00CDD5DB File Offset: 0x00CDB7DB
		public void SortFixedRewardList()
		{
			this.FixedRewardDataList.Sort(new Comparison<TrapDefenseRewardItemData>(this.RewardListSortFunc));
		}

		// Token: 0x0603370E RID: 210702 RVA: 0x00CDD5F4 File Offset: 0x00CDB7F4
		[NullableContext(0)]
		public ValueTuple<int, int> GetFixedRewardTotalProgress()
		{
			int num = 0;
			using (List<TrapDefenseRewardItemData>.Enumerator enumerator = this.FixedRewardDataList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.State == ETrapDefenseRewardState.Claimed)
					{
						num++;
					}
				}
			}
			int count = this.FixedRewardDataList.Count;
			return new ValueTuple<int, int>(num, count);
		}

		// Token: 0x0603370F RID: 210703 RVA: 0x00CDD660 File Offset: 0x00CDB860
		public bool IsCanClaimLimitReward()
		{
			foreach (List<TrapDefenseRewardItemData> list in this.RewardTypeMap.Values)
			{
				using (List<TrapDefenseRewardItemData>.Enumerator enumerator2 = list.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						if (enumerator2.Current.State == ETrapDefenseRewardState.CanClaim)
						{
							return true;
						}
					}
				}
			}
			TrapDefenseSpecialRewardData specialRewardData = this.SpecialRewardData;
			return specialRewardData != null && specialRewardData.State == ETrapDefenseRewardState.CanClaim;
		}

		// Token: 0x06033710 RID: 210704 RVA: 0x00CDD708 File Offset: 0x00CDB908
		public bool IsCanClaimLimitRewardByType(ETrapDefenseRewardType type)
		{
			using (List<TrapDefenseRewardItemData>.Enumerator enumerator = this.GetRewardListByType(type).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.State == ETrapDefenseRewardState.CanClaim)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06033711 RID: 210705 RVA: 0x00CDD764 File Offset: 0x00CDB964
		public bool IsCanClaimFixedReward()
		{
			using (List<TrapDefenseRewardItemData>.Enumerator enumerator = this.FixedRewardDataList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.State == ETrapDefenseRewardState.CanClaim)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06033712 RID: 210706 RVA: 0x00CDD7C0 File Offset: 0x00CDB9C0
		public bool RedDotFixedReward()
		{
			return this.IsCanClaimFixedReward();
		}

		// Token: 0x06033713 RID: 210707 RVA: 0x00CDD7C8 File Offset: 0x00CDB9C8
		public bool RedDotLimitReward()
		{
			return this.IsCanClaimLimitReward();
		}

		// Token: 0x06033714 RID: 210708 RVA: 0x00CDD7D0 File Offset: 0x00CDB9D0
		public bool IsAllRewardClaimed()
		{
			TrapDefenseSpecialRewardData specialRewardData = this.SpecialRewardData;
			if (specialRewardData == null || specialRewardData.State != ETrapDefenseRewardState.Claimed)
			{
				return false;
			}
			using (List<TrapDefenseRewardItemData>.Enumerator enumerator = this.FixedRewardDataList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.State != ETrapDefenseRewardState.Claimed)
					{
						return false;
					}
				}
			}
			foreach (List<TrapDefenseRewardItemData> list in this.RewardTypeMap.Values)
			{
				using (List<TrapDefenseRewardItemData>.Enumerator enumerator = list.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.State != ETrapDefenseRewardState.Claimed)
						{
							return false;
						}
					}
				}
			}
			return true;
		}

		// Token: 0x06033715 RID: 210709 RVA: 0x00CDD8C8 File Offset: 0x00CDBAC8
		public bool IsFixedRewardAllClaimed()
		{
			using (List<TrapDefenseRewardItemData>.Enumerator enumerator = this.FixedRewardDataList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.State != ETrapDefenseRewardState.Claimed)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x0401DCCA RID: 122058
		private int ActivityId;

		// Token: 0x0401DCCB RID: 122059
		public Dictionary<ETrapDefenseRewardType, List<TrapDefenseRewardItemData>> RewardTypeMap = new Dictionary<ETrapDefenseRewardType, List<TrapDefenseRewardItemData>>();

		// Token: 0x0401DCCC RID: 122060
		[Nullable(2)]
		public TrapDefenseSpecialRewardData SpecialRewardData;

		// Token: 0x0401DCCD RID: 122061
		public Dictionary<int, TrapDefenseRewardItemData> RewardDataMap = new Dictionary<int, TrapDefenseRewardItemData>();

		// Token: 0x0401DCCE RID: 122062
		public List<TrapDefenseRewardItemData> FixedRewardDataList = new List<TrapDefenseRewardItemData>();

		// Token: 0x0401DCCF RID: 122063
		public long LimitBeginTime;

		// Token: 0x0401DCD0 RID: 122064
		public long LimitEndTime;
	}
}
