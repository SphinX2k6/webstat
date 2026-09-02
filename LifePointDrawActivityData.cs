using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x02001346 RID: 4934
[NullableContext(1)]
[Nullable(0)]
public class LifePointDrawActivityData : ActivityBaseData
{
	// Token: 0x060086D0 RID: 34512 RVA: 0x00237EDC File Offset: 0x002360DC
	protected override void PhraseEx(ActivityData data)
	{
		LifePointChallengeActivityData lifePointChallenge = data.LifePointChallenge;
		if (lifePointChallenge != null)
		{
			foreach (LifePointChallengeData lifePointChallengeData in lifePointChallenge.Challenges)
			{
				LifePointChallengeDataInstance challengeData = this.GetChallengeData(lifePointChallengeData.ChallengeId);
				if (challengeData != null)
				{
					challengeData.Phrase(lifePointChallengeData);
				}
				else
				{
					LifePointChallengeDataInstance lifePointChallengeDataInstance = new LifePointChallengeDataInstance();
					lifePointChallengeDataInstance.Phrase(lifePointChallengeData);
					this.ChallengeMap[lifePointChallengeDataInstance.GetId()] = lifePointChallengeDataInstance;
				}
			}
			for (int i = 0; i < ConfigBase<LifePointDrawConfig>.Instance.GetLifePointEntranceById(base.Id).Value.GroupListLength; i++)
			{
				int p = ConfigBase<LifePointDrawConfig>.Instance.GetLifePointEntranceById(base.Id).Value.GroupList(i);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshLifePointDrawGroupRedDot, p);
			}
		}
	}

	// Token: 0x060086D1 RID: 34513 RVA: 0x00237FD4 File Offset: 0x002361D4
	public LifePointChallengeDataInstance GetChallengeData(int id)
	{
		LifePointChallengeDataInstance result;
		this.ChallengeMap.TryGetValue(id, out result);
		return result;
	}

	// Token: 0x060086D2 RID: 34514 RVA: 0x00237FF4 File Offset: 0x002361F4
	public void OnLifePointChallengeDataUpdate(LifePointChallengeData data)
	{
		LifePointChallengeDataInstance challengeData = this.GetChallengeData(data.ChallengeId);
		if (challengeData != null)
		{
			challengeData.Phrase(data);
			return;
		}
		LifePointChallengeDataInstance lifePointChallengeDataInstance = new LifePointChallengeDataInstance();
		lifePointChallengeDataInstance.Phrase(data);
		this.ChallengeMap[lifePointChallengeDataInstance.GetId()] = lifePointChallengeDataInstance;
	}

	// Token: 0x060086D3 RID: 34515 RVA: 0x00238038 File Offset: 0x00236238
	public int GetChallengeNumber()
	{
		return this.ChallengeMap.Count;
	}

	// Token: 0x060086D4 RID: 34516 RVA: 0x00238048 File Offset: 0x00236248
	public int GetFinishChallengeNumber()
	{
		int num = 0;
		using (Dictionary<int, LifePointChallengeDataInstance>.ValueCollection.Enumerator enumerator = this.ChallengeMap.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.GetHasGetReward())
				{
					num++;
				}
			}
		}
		return num;
	}

	// Token: 0x060086D5 RID: 34517 RVA: 0x002380A8 File Offset: 0x002362A8
	public int GetGroupChallengeNumber(int groupId)
	{
		int num = 0;
		for (int i = 0; i < ConfigBase<LifePointDrawConfig>.Instance.GetLifePointGroupByGroupId(groupId).Value.ChallengeListLength; i++)
		{
			int id = ConfigBase<LifePointDrawConfig>.Instance.GetLifePointGroupByGroupId(groupId).Value.ChallengeList(i);
			if (this.GetChallengeData(id) != null)
			{
				num++;
			}
		}
		return num;
	}

	// Token: 0x060086D6 RID: 34518 RVA: 0x0023810C File Offset: 0x0023630C
	public long GetGroupUnlockTime(int groupId)
	{
		long num = 0L;
		for (int i = 0; i < ConfigBase<LifePointDrawConfig>.Instance.GetLifePointGroupByGroupId(groupId).Value.ChallengeListLength; i++)
		{
			int id = ConfigBase<LifePointDrawConfig>.Instance.GetLifePointGroupByGroupId(groupId).Value.ChallengeList(i);
			LifePointChallengeDataInstance challengeData = this.GetChallengeData(id);
			if (challengeData != null && challengeData.GetOpenTime() > num)
			{
				num = challengeData.GetOpenTime();
			}
		}
		return num;
	}

	// Token: 0x060086D7 RID: 34519 RVA: 0x00238180 File Offset: 0x00236380
	public bool GetGroupIfOverUnlockTime(int groupId)
	{
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		long groupUnlockTime = this.GetGroupUnlockTime(groupId);
		return serverTime >= (double)groupUnlockTime;
	}

	// Token: 0x060086D8 RID: 34520 RVA: 0x002381A8 File Offset: 0x002363A8
	public bool GetGroupHasGetReward(int groupId)
	{
		for (int i = 0; i < ConfigBase<LifePointDrawConfig>.Instance.GetLifePointGroupByGroupId(groupId).Value.ChallengeListLength; i++)
		{
			int id = ConfigBase<LifePointDrawConfig>.Instance.GetLifePointGroupByGroupId(groupId).Value.ChallengeList(i);
			LifePointChallengeDataInstance challengeData = this.GetChallengeData(id);
			if (challengeData != null && !challengeData.GetHasGetReward())
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x060086D9 RID: 34521 RVA: 0x00238210 File Offset: 0x00236410
	public int GetGroupRewardProgress(int groupId)
	{
		int num = 0;
		for (int i = 0; i < ConfigBase<LifePointDrawConfig>.Instance.GetLifePointGroupByGroupId(groupId).Value.ChallengeListLength; i++)
		{
			int id = ConfigBase<LifePointDrawConfig>.Instance.GetLifePointGroupByGroupId(groupId).Value.ChallengeList(i);
			LifePointChallengeDataInstance challengeData = this.GetChallengeData(id);
			if (challengeData != null && challengeData.GetHasGetReward())
			{
				num++;
			}
		}
		return num;
	}

	// Token: 0x060086DA RID: 34522 RVA: 0x00238280 File Offset: 0x00236480
	public bool GetChallengeIfGetReward(int challengeId)
	{
		LifePointChallengeDataInstance challengeData = this.GetChallengeData(challengeId);
		return challengeData != null && challengeData.GetHasGetReward();
	}

	// Token: 0x060086DB RID: 34523 RVA: 0x002382A0 File Offset: 0x002364A0
	public bool GetChallengeRequireFinishState(int challengeId)
	{
		LifePointChallengeDataInstance challengeData = this.GetChallengeData(challengeId);
		return challengeData != null && challengeData.GetPreChallengeState();
	}

	// Token: 0x060086DC RID: 34524 RVA: 0x002382C0 File Offset: 0x002364C0
	public bool CheckIfHaveChallenge(int challengeId)
	{
		return this.ChallengeMap.ContainsKey(challengeId);
	}

	// Token: 0x060086DD RID: 34525 RVA: 0x002382D0 File Offset: 0x002364D0
	public override bool GetExDataRedPointShowState()
	{
		if (!base.GetPreGuideQuestFinishState())
		{
			return false;
		}
		foreach (LifePointChallengeDataInstance lifePointChallengeDataInstance in this.ChallengeMap.Values)
		{
			if (ModelBase<LifePointDrawModel>.Instance.GetChallengeRedDotState(lifePointChallengeDataInstance.GetId()))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x04003FA6 RID: 16294
	private Dictionary<int, LifePointChallengeDataInstance> ChallengeMap = new Dictionary<int, LifePointChallengeDataInstance>();
}
