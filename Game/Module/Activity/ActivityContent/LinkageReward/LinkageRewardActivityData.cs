using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.Activity.ActivityContent.LinkageReward
{
	// Token: 0x02006755 RID: 26453
	[NullableContext(1)]
	[Nullable(0)]
	public class LinkageRewardActivityData : ActivityBaseData
	{
		// Token: 0x06041F2A RID: 270122 RVA: 0x010EB0A0 File Offset: 0x010E92A0
		protected override void PhraseEx(ActivityData data)
		{
			this.NormalRewardDataMap.Clear();
			this.KeepRewardDataMap.Clear();
			LinkageCheckInActivityData linkageCheckInActivityData = data.LinkageCheckInActivityData;
			if (linkageCheckInActivityData == null)
			{
				return;
			}
			int checkInDay = linkageCheckInActivityData.CheckInDay;
			this.CurrentCheckInDay = checkInDay;
			HashSet<int> hashSet = new HashSet<int>(linkageCheckInActivityData.NormalReward);
			HashSet<int> hashSet2 = new HashSet<int>(linkageCheckInActivityData.KeepReward);
			IReadOnlyList<LinkageReward> listByActivityId = ConfigBase<LinkageRewardActivityConfig>.Instance.GetListByActivityId(base.Id);
			if (listByActivityId == null || listByActivityId.Count == 0)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
				return;
			}
			List<LinkageReward> list = new List<LinkageReward>(listByActivityId);
			list.Sort((LinkageReward a, LinkageReward b) => a.Id.CompareTo(b.Id));
			for (int i = 0; i < list.Count; i++)
			{
				LinkageReward linkageReward = list[i];
				int requiredCheckInDay = LinkageRewardActivityData.GetRequiredCheckInDay(i);
				TimePointRewardData timePointRewardData = new TimePointRewardData
				{
					Id = linkageReward.Id,
					RewardTime = (long)requiredCheckInDay,
					HasClaimed = hashSet.Contains(linkageReward.Id)
				};
				timePointRewardData.HasUnlock = (!timePointRewardData.HasClaimed && checkInDay >= requiredCheckInDay);
				this.NormalRewardDataMap[linkageReward.Id] = timePointRewardData;
				if (linkageReward.KeepDropId > 0)
				{
					TimePointRewardData timePointRewardData2 = new TimePointRewardData
					{
						Id = linkageReward.Id,
						RewardTime = (long)requiredCheckInDay,
						HasClaimed = hashSet2.Contains(linkageReward.Id)
					};
					timePointRewardData2.HasUnlock = (!timePointRewardData2.HasClaimed && checkInDay >= requiredCheckInDay);
					this.KeepRewardDataMap[linkageReward.Id] = timePointRewardData2;
				}
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x06041F2B RID: 270123 RVA: 0x010EB267 File Offset: 0x010E9467
		private static int GetRequiredCheckInDay(int sortedIndex)
		{
			return sortedIndex + 1;
		}

		// Token: 0x06041F2C RID: 270124 RVA: 0x010EB26C File Offset: 0x010E946C
		public override bool GetExDataRedPointShowState()
		{
			return this.IsExitsRewardToGet();
		}

		// Token: 0x06041F2D RID: 270125 RVA: 0x010EB274 File Offset: 0x010E9474
		protected override bool GetExDataFinishShowState()
		{
			return this.IsAllRewardsClaimed();
		}

		// Token: 0x06041F2E RID: 270126 RVA: 0x010EB27C File Offset: 0x010E947C
		private bool IsAllRewardsClaimed()
		{
			if (this.NormalRewardDataMap.Count <= 0)
			{
				return false;
			}
			using (Dictionary<int, TimePointRewardData>.ValueCollection.Enumerator enumerator = this.NormalRewardDataMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.RewardState != ETimePointRewardState.UnlockAndClaimed)
					{
						return false;
					}
				}
			}
			using (Dictionary<int, TimePointRewardData>.ValueCollection.Enumerator enumerator = this.KeepRewardDataMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.RewardState != ETimePointRewardState.UnlockAndClaimed)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06041F2F RID: 270127 RVA: 0x010EB338 File Offset: 0x010E9538
		private bool IsExitsRewardToGet()
		{
			using (Dictionary<int, TimePointRewardData>.ValueCollection.Enumerator enumerator = this.NormalRewardDataMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.RewardState == ETimePointRewardState.UnlockAndUnClaimed)
					{
						return true;
					}
				}
			}
			using (Dictionary<int, TimePointRewardData>.ValueCollection.Enumerator enumerator = this.KeepRewardDataMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.RewardState == ETimePointRewardState.UnlockAndUnClaimed)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06041F30 RID: 270128 RVA: 0x010EB3E4 File Offset: 0x010E95E4
		public void SetRewardsToGotState(IReadOnlyList<int> ids, LinkageCheckInType linkageCheckInType)
		{
			bool flag = false;
			Dictionary<int, TimePointRewardData> dictionary = (linkageCheckInType == LinkageCheckInType.KeepCheckIn) ? this.KeepRewardDataMap : this.NormalRewardDataMap;
			foreach (int key in ids)
			{
				TimePointRewardData timePointRewardData;
				if (dictionary.TryGetValue(key, out timePointRewardData) && !timePointRewardData.HasClaimed)
				{
					timePointRewardData.HasClaimed = true;
					flag = true;
				}
			}
			if (!flag)
			{
				return;
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x06041F31 RID: 270129 RVA: 0x010EB474 File Offset: 0x010E9674
		public void RevertOptimisticClaimReward(IReadOnlyList<int> ids, LinkageCheckInType linkageCheckInType)
		{
			bool flag = false;
			Dictionary<int, TimePointRewardData> dictionary = (linkageCheckInType == LinkageCheckInType.KeepCheckIn) ? this.KeepRewardDataMap : this.NormalRewardDataMap;
			foreach (int key in ids)
			{
				TimePointRewardData timePointRewardData;
				if (dictionary.TryGetValue(key, out timePointRewardData) && timePointRewardData.HasClaimed)
				{
					timePointRewardData.HasClaimed = false;
					flag = true;
				}
			}
			if (!flag)
			{
				return;
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x06041F32 RID: 270130 RVA: 0x010EB504 File Offset: 0x010E9704
		public int[] GetUnlockUnclaimedRewardIds(LinkageCheckInType linkageCheckInType)
		{
			Dictionary<int, TimePointRewardData> dictionary = (linkageCheckInType == LinkageCheckInType.KeepCheckIn) ? this.KeepRewardDataMap : this.NormalRewardDataMap;
			List<int> list = new List<int>();
			foreach (TimePointRewardData timePointRewardData in dictionary.Values)
			{
				if (timePointRewardData.RewardState == ETimePointRewardState.UnlockAndUnClaimed)
				{
					list.Add(timePointRewardData.Id);
				}
			}
			return list.ToArray();
		}

		// Token: 0x06041F33 RID: 270131 RVA: 0x010EB584 File Offset: 0x010E9784
		public List<TimePointRewardData> GetRewardDataList()
		{
			List<TimePointRewardData> list = new List<TimePointRewardData>(this.NormalRewardDataMap.Values);
			list.Sort((TimePointRewardData a, TimePointRewardData b) => a.Id.CompareTo(b.Id));
			return list;
		}

		// Token: 0x06041F34 RID: 270132 RVA: 0x010EB5BB File Offset: 0x010E97BB
		public List<TimePointRewardData> GetKeepRewardDataList()
		{
			List<TimePointRewardData> list = new List<TimePointRewardData>(this.KeepRewardDataMap.Values);
			list.Sort((TimePointRewardData a, TimePointRewardData b) => a.Id.CompareTo(b.Id));
			return list;
		}

		// Token: 0x06041F35 RID: 270133 RVA: 0x010EB5F2 File Offset: 0x010E97F2
		public int GetCurrentCheckInDay()
		{
			return this.CurrentCheckInDay;
		}

		// Token: 0x04024CB3 RID: 150707
		private readonly Dictionary<int, TimePointRewardData> NormalRewardDataMap = new Dictionary<int, TimePointRewardData>();

		// Token: 0x04024CB4 RID: 150708
		private readonly Dictionary<int, TimePointRewardData> KeepRewardDataMap = new Dictionary<int, TimePointRewardData>();

		// Token: 0x04024CB5 RID: 150709
		private int CurrentCheckInDay;
	}
}
