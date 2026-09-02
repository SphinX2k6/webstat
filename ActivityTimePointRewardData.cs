using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x020015D3 RID: 5587
[NullableContext(1)]
[Nullable(0)]
public class ActivityTimePointRewardData : ActivityBaseData
{
	// Token: 0x06009D38 RID: 40248 RVA: 0x00292794 File Offset: 0x00290994
	protected override void PhraseEx(ActivityData data)
	{
		this.RewardDataMap.Clear();
		TimePointRewardActivityData timePointRewardActivityData = data.TimePointRewardActivityData;
		if (timePointRewardActivityData == null)
		{
			return;
		}
		foreach (OneTimePointRewardActivityData oneTimePointRewardActivityData in timePointRewardActivityData.Rewards)
		{
			TimePointRewardData timePointRewardData = new TimePointRewardData();
			timePointRewardData.Id = oneTimePointRewardActivityData.Id;
			timePointRewardData.RewardTime = oneTimePointRewardActivityData.RewardTime;
			timePointRewardData.HasClaimed = oneTimePointRewardActivityData.Rewarded;
			timePointRewardData.HasUnlock = oneTimePointRewardActivityData.CanGetReward;
			this.RewardDataMap[oneTimePointRewardActivityData.Id] = timePointRewardData;
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x06009D39 RID: 40249 RVA: 0x00292850 File Offset: 0x00290A50
	public bool GetClickRedDotState()
	{
		return ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 100, 0, 0) == 0;
	}

	// Token: 0x06009D3A RID: 40250 RVA: 0x0029286A File Offset: 0x00290A6A
	public void SaveClickRedDotState()
	{
		ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, 100, 0, 0, 1);
	}

	// Token: 0x06009D3B RID: 40251 RVA: 0x00292881 File Offset: 0x00290A81
	public override bool GetExDataRedPointShowState()
	{
		return this.IsExitsRewardToGet() || this.GetClickRedDotState();
	}

	// Token: 0x06009D3C RID: 40252 RVA: 0x00292894 File Offset: 0x00290A94
	protected override bool GetExDataFinishShowState()
	{
		if (this.RewardDataMap.Count <= 0)
		{
			return false;
		}
		using (Dictionary<int, TimePointRewardData>.ValueCollection.Enumerator enumerator = this.RewardDataMap.Values.GetEnumerator())
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

	// Token: 0x06009D3D RID: 40253 RVA: 0x00292904 File Offset: 0x00290B04
	private bool IsExitsRewardToGet()
	{
		using (Dictionary<int, TimePointRewardData>.ValueCollection.Enumerator enumerator = this.RewardDataMap.Values.GetEnumerator())
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

	// Token: 0x06009D3E RID: 40254 RVA: 0x00292964 File Offset: 0x00290B64
	public void SetRewardToGotState(int id)
	{
		TimePointRewardData timePointRewardData;
		if (!this.RewardDataMap.TryGetValue(id, out timePointRewardData))
		{
			return;
		}
		timePointRewardData.HasClaimed = true;
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		using (Dictionary<int, TimePointRewardData>.ValueCollection.Enumerator enumerator = this.RewardDataMap.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.RewardState != ETimePointRewardState.UnlockAndClaimed)
				{
					break;
				}
			}
		}
	}

	// Token: 0x06009D3F RID: 40255 RVA: 0x002929EC File Offset: 0x00290BEC
	public List<TimePointRewardData> GetRewardDataList()
	{
		List<TimePointRewardData> list = new List<TimePointRewardData>(this.RewardDataMap.Values);
		list.Sort((TimePointRewardData a, TimePointRewardData b) => a.Id - b.Id);
		return list;
	}

	// Token: 0x04004870 RID: 18544
	public const int CLICKKEY = 100;

	// Token: 0x04004871 RID: 18545
	private readonly Dictionary<int, TimePointRewardData> RewardDataMap = new Dictionary<int, TimePointRewardData>();
}
