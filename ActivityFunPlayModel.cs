using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Activity.ActivityContent.FunPlay;

// Token: 0x0200133A RID: 4922
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class ActivityFunPlayModel : ModelBase<ActivityFunPlayModel>
{
	// Token: 0x0600866D RID: 34413 RVA: 0x00236DAC File Offset: 0x00234FAC
	public void CreateChallengeData(FunPlayChallengeInfo[] data, int activityId)
	{
		if (data == null)
		{
			return;
		}
		for (int i = 0; i < data.Length; i++)
		{
			FunPlayChallengeInfo funPlayChallengeInfo = data[i];
			ActivityFunPlayChallengeData activityFunPlayChallengeData = this.GetChallengeData(funPlayChallengeInfo.ChallengeId);
			if (activityFunPlayChallengeData != null)
			{
				activityFunPlayChallengeData.Phrase(funPlayChallengeInfo);
			}
			else
			{
				activityFunPlayChallengeData = new ActivityFunPlayChallengeData(activityId);
				activityFunPlayChallengeData.Phrase(funPlayChallengeInfo);
				activityFunPlayChallengeData.SetIndex(i);
				this.AllChallengeDataMap.Add(funPlayChallengeInfo.ChallengeId, activityFunPlayChallengeData);
				this.AllChallengeDataList.Add(activityFunPlayChallengeData);
			}
		}
	}

	// Token: 0x0600866E RID: 34414 RVA: 0x00236E1C File Offset: 0x0023501C
	[return: Nullable(2)]
	public ActivityFunPlayChallengeData UpdateChallengeData(FunPlayChallengeInfo data)
	{
		if (data == null)
		{
			return null;
		}
		ActivityFunPlayChallengeData challengeData = this.GetChallengeData(data.ChallengeId);
		if (challengeData == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ActivityFunPlay;
			ELogAuthor author = ELogAuthor.CB;
			string message = "服务器下发的更新关卡信息的id不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ChallengeId", data.ChallengeId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		challengeData.Phrase(data);
		return challengeData;
	}

	// Token: 0x0600866F RID: 34415 RVA: 0x00236E7C File Offset: 0x0023507C
	private List<ActivityFunPlayChallengeData> SortChallenges()
	{
		List<ActivityFunPlayChallengeData> list = new List<ActivityFunPlayChallengeData>(this.AllChallengeDataList);
		list.Sort(delegate(ActivityFunPlayChallengeData a, ActivityFunPlayChallengeData b)
		{
			bool flag = a.CheckRewardStatus(FunPlayChallengeRewardStatus.FunPlayCanReward);
			bool flag2 = b.CheckRewardStatus(FunPlayChallengeRewardStatus.FunPlayCanReward);
			if (flag != flag2)
			{
				if (!flag)
				{
					return 1;
				}
				return -1;
			}
			else
			{
				if (flag && flag2)
				{
					int index = a.Index;
					return b.Index - index;
				}
				bool flag3 = a.CheckRewardStatus(FunPlayChallengeRewardStatus.FunPlayRewarded);
				bool flag4 = b.CheckRewardStatus(FunPlayChallengeRewardStatus.FunPlayRewarded);
				if (flag3 != flag4)
				{
					if (!flag3)
					{
						return -1;
					}
					return 1;
				}
				else
				{
					bool isUnlock = a.GetIsUnlock();
					bool isUnlock2 = b.GetIsUnlock();
					if (isUnlock == isUnlock2)
					{
						int challengeId = a.GetChallengeId();
						int challengeId2 = b.GetChallengeId();
						return challengeId.CompareTo(challengeId2);
					}
					if (!isUnlock)
					{
						return 1;
					}
					return -1;
				}
			}
		});
		return list;
	}

	// Token: 0x06008670 RID: 34416 RVA: 0x00236EAE File Offset: 0x002350AE
	public List<ActivityFunPlayChallengeData> GetAllChallengeData()
	{
		return this.AllChallengeDataList;
	}

	// Token: 0x06008671 RID: 34417 RVA: 0x00236EB8 File Offset: 0x002350B8
	[NullableContext(2)]
	public ActivityFunPlayChallengeData GetChallengeData(int challengeId)
	{
		ActivityFunPlayChallengeData result;
		this.AllChallengeDataMap.TryGetValue(challengeId, out result);
		return result;
	}

	// Token: 0x06008672 RID: 34418 RVA: 0x00236ED5 File Offset: 0x002350D5
	public void SetCurrentChallengeData(int challengeId)
	{
		this.CurrentChallengeData = this.GetChallengeData(challengeId);
	}

	// Token: 0x06008673 RID: 34419 RVA: 0x00236EE4 File Offset: 0x002350E4
	[NullableContext(2)]
	public ActivityFunPlayChallengeData GetCurrentChallengeData()
	{
		return this.CurrentChallengeData;
	}

	// Token: 0x06008674 RID: 34420 RVA: 0x00236EEC File Offset: 0x002350EC
	public int GetDefaultSelectIndex()
	{
		List<ActivityFunPlayChallengeData> list = this.SortChallenges();
		if (list.Count > 0)
		{
			return list[0].Index;
		}
		return 0;
	}

	// Token: 0x06008675 RID: 34421 RVA: 0x00236F18 File Offset: 0x00235118
	public bool GetHasInternalRedDot()
	{
		using (Dictionary<int, ActivityFunPlayChallengeData>.ValueCollection.Enumerator enumerator = this.AllChallengeDataMap.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.GetRedPoint())
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06008676 RID: 34422 RVA: 0x00236F78 File Offset: 0x00235178
	public bool IsAllRewardClaimed()
	{
		if (this.AllChallengeDataList.Count == 0)
		{
			return false;
		}
		using (List<ActivityFunPlayChallengeData>.Enumerator enumerator = this.AllChallengeDataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (!enumerator.Current.CheckRewardStatus(FunPlayChallengeRewardStatus.FunPlayRewarded))
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x06008677 RID: 34423 RVA: 0x00236FE4 File Offset: 0x002351E4
	protected override bool OnClear()
	{
		this.AllChallengeDataMap.Clear();
		this.AllChallengeDataList.Clear();
		return true;
	}

	// Token: 0x04003F8C RID: 16268
	[Nullable(2)]
	private ActivityFunPlayChallengeData CurrentChallengeData;

	// Token: 0x04003F8D RID: 16269
	private readonly Dictionary<int, ActivityFunPlayChallengeData> AllChallengeDataMap = new Dictionary<int, ActivityFunPlayChallengeData>();

	// Token: 0x04003F8E RID: 16270
	private readonly List<ActivityFunPlayChallengeData> AllChallengeDataList = new List<ActivityFunPlayChallengeData>();
}
