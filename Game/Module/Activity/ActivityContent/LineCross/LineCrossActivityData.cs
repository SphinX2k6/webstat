using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Activity.ActivityContent.LineCross
{
	// Token: 0x02006760 RID: 26464
	[NullableContext(1)]
	[Nullable(0)]
	public class LineCrossActivityData : ActivityBaseData
	{
		// Token: 0x06041F85 RID: 270213 RVA: 0x010ED334 File Offset: 0x010EB534
		protected override void PhraseEx(ActivityData data)
		{
			LineCrossActivityData lineCrossActivityData = data.LineCrossActivityData;
			if (((lineCrossActivityData != null) ? lineCrossActivityData.Challenges : null) != null)
			{
				foreach (LineCrossChallengeData lineCrossChallengeData in lineCrossActivityData.Challenges)
				{
					LineCrossChallengeData challengeData = this.GetChallengeData(lineCrossChallengeData.ChallengeId);
					if (challengeData != null)
					{
						challengeData.Phrase(lineCrossChallengeData);
					}
					else
					{
						LineCrossChallengeData lineCrossChallengeData2 = new LineCrossChallengeData();
						lineCrossChallengeData2.Phrase(lineCrossChallengeData);
						this.ChallengeMap.Add(lineCrossChallengeData2.GetId(), lineCrossChallengeData2);
					}
				}
			}
		}

		// Token: 0x06041F86 RID: 270214 RVA: 0x010ED3CC File Offset: 0x010EB5CC
		[NullableContext(2)]
		public LineCrossChallengeData GetChallengeData(int id)
		{
			LineCrossChallengeData result;
			this.ChallengeMap.TryGetValue(id, out result);
			return result;
		}

		// Token: 0x06041F87 RID: 270215 RVA: 0x010ED3EC File Offset: 0x010EB5EC
		public void OnChallengeDataUpdate(LineCrossChallengeData data)
		{
			LineCrossChallengeData challengeData = this.GetChallengeData(data.ChallengeId);
			if (challengeData != null)
			{
				challengeData.Phrase(data);
				return;
			}
			LineCrossChallengeData lineCrossChallengeData = new LineCrossChallengeData();
			lineCrossChallengeData.Phrase(data);
			this.ChallengeMap.Add(lineCrossChallengeData.GetId(), lineCrossChallengeData);
		}

		// Token: 0x06041F88 RID: 270216 RVA: 0x010ED430 File Offset: 0x010EB630
		public int GetChallengeNumber()
		{
			return this.ChallengeMap.Count;
		}

		// Token: 0x06041F89 RID: 270217 RVA: 0x010ED440 File Offset: 0x010EB640
		public int GetFinishChallengeNumber()
		{
			int num = 0;
			using (Dictionary<int, LineCrossChallengeData>.ValueCollection.Enumerator enumerator = this.ChallengeMap.Values.GetEnumerator())
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

		// Token: 0x06041F8A RID: 270218 RVA: 0x010ED4A0 File Offset: 0x010EB6A0
		public int GetGroupChallengeNumber(int groupId)
		{
			LineCrossGroup value = ConfigBase<LineCrossConfig>.Instance.GetLineCrossGroupByGroupId(groupId).Value;
			int num = 0;
			for (int i = 0; i < value.ChallengeListLength; i++)
			{
				int id = value.ChallengeList(i);
				if (this.GetChallengeData(id) != null)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06041F8B RID: 270219 RVA: 0x010ED4F0 File Offset: 0x010EB6F0
		public int GetGroupRewardProgress(int groupId)
		{
			LineCrossGroup value = ConfigBase<LineCrossConfig>.Instance.GetLineCrossGroupByGroupId(groupId).Value;
			int num = 0;
			for (int i = 0; i < value.ChallengeListLength; i++)
			{
				int id = value.ChallengeList(i);
				LineCrossChallengeData challengeData = this.GetChallengeData(id);
				if (challengeData != null && challengeData.GetHasGetReward())
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06041F8C RID: 270220 RVA: 0x010ED54C File Offset: 0x010EB74C
		public long GetGroupUnlockTime(int groupId)
		{
			LineCrossGroup value = ConfigBase<LineCrossConfig>.Instance.GetLineCrossGroupByGroupId(groupId).Value;
			long num = 0L;
			for (int i = 0; i < value.ChallengeListLength; i++)
			{
				int id = value.ChallengeList(i);
				LineCrossChallengeData challengeData = this.GetChallengeData(id);
				if (challengeData != null && challengeData.GetOpenTime() > num)
				{
					num = challengeData.GetOpenTime();
				}
			}
			return num;
		}

		// Token: 0x06041F8D RID: 270221 RVA: 0x010ED5B0 File Offset: 0x010EB7B0
		public bool GetGroupHasGetReward(int groupId)
		{
			LineCrossGroup value = ConfigBase<LineCrossConfig>.Instance.GetLineCrossGroupByGroupId(groupId).Value;
			for (int i = 0; i < value.ChallengeListLength; i++)
			{
				int id = value.ChallengeList(i);
				LineCrossChallengeData challengeData = this.GetChallengeData(id);
				if (challengeData != null && !challengeData.GetHasGetReward())
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06041F8E RID: 270222 RVA: 0x010ED608 File Offset: 0x010EB808
		public bool GetIfHiddenGroup(int groupId)
		{
			return ConfigBase<LineCrossConfig>.Instance.GetLineCrossGroupByGroupId(groupId).Value.NeedFinishGroupLength > 0;
		}

		// Token: 0x06041F8F RID: 270223 RVA: 0x010ED633 File Offset: 0x010EB833
		public bool GetChallengeRequireFinishState(int challengeId)
		{
			LineCrossChallengeData challengeData = this.GetChallengeData(challengeId);
			return challengeData != null && challengeData.GetPreChallengeState();
		}

		// Token: 0x06041F90 RID: 270224 RVA: 0x010ED648 File Offset: 0x010EB848
		public bool IfGroupShow(int groupId)
		{
			if (this.GetIfHiddenGroup(groupId))
			{
				LineCrossGroup value = ConfigBase<LineCrossConfig>.Instance.GetLineCrossGroupByGroupId(groupId).Value;
				for (int i = 0; i < value.NeedFinishGroupLength; i++)
				{
					int groupId2 = value.NeedFinishGroup(i);
					if (!this.GetGroupHasGetReward(groupId2))
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06041F91 RID: 270225 RVA: 0x010ED69C File Offset: 0x010EB89C
		public ELineCrossGroupState GetGroupState(int groupId)
		{
			LineCrossGroup value = ConfigBase<LineCrossConfig>.Instance.GetLineCrossGroupByGroupId(groupId).Value;
			bool flag = true;
			for (int i = 0; i < value.ChallengeListLength; i++)
			{
				int id = value.ChallengeList(i);
				LineCrossChallengeData challengeData = this.GetChallengeData(id);
				if (challengeData == null || !challengeData.GetHasGetReward())
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				return ELineCrossGroupState.Passed;
			}
			if (!this.GetGroupIfOverUnlockTime(groupId))
			{
				return ELineCrossGroupState.Lock;
			}
			return ELineCrossGroupState.Normal;
		}

		// Token: 0x06041F92 RID: 270226 RVA: 0x010ED708 File Offset: 0x010EB908
		public int[] GetShowGroupList()
		{
			LineCrossEntrance value = ConfigBase<LineCrossConfig>.Instance.GetLineCrossEntranceById(base.Id).Value;
			List<int> list = new List<int>();
			for (int i = 0; i < value.GroupListLength; i++)
			{
				int num = value.GroupList(i);
				if (this.IfGroupShow(num))
				{
					list.Add(num);
				}
			}
			return list.ToArray();
		}

		// Token: 0x06041F93 RID: 270227 RVA: 0x010ED768 File Offset: 0x010EB968
		public bool GetGroupIfOverUnlockTime(int groupId)
		{
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			long groupUnlockTime = this.GetGroupUnlockTime(groupId);
			return serverTime >= (double)groupUnlockTime;
		}

		// Token: 0x06041F94 RID: 270228 RVA: 0x010ED78E File Offset: 0x010EB98E
		public bool GetChallengeIfGetReward(int challengeId)
		{
			LineCrossChallengeData challengeData = this.GetChallengeData(challengeId);
			return challengeData != null && challengeData.GetHasGetReward();
		}

		// Token: 0x06041F95 RID: 270229 RVA: 0x010ED7A4 File Offset: 0x010EB9A4
		private bool IfAllChallengeFinished()
		{
			using (Dictionary<int, LineCrossChallengeData>.ValueCollection.Enumerator enumerator = this.ChallengeMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (!enumerator.Current.GetHasGetReward())
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06041F96 RID: 270230 RVA: 0x010ED804 File Offset: 0x010EBA04
		protected override bool GetExDataFinishShowState()
		{
			return this.IfAllChallengeFinished();
		}

		// Token: 0x06041F97 RID: 270231 RVA: 0x010ED80C File Offset: 0x010EBA0C
		public override bool GetExDataRedPointShowState()
		{
			if (!base.GetPreGuideQuestFinishState())
			{
				return false;
			}
			foreach (LineCrossChallengeData lineCrossChallengeData in this.ChallengeMap.Values)
			{
				if (ModelBase<LineCrossModel>.Instance.GetChallengeRedDotState(lineCrossChallengeData.GetId()))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06041F98 RID: 270232 RVA: 0x010ED880 File Offset: 0x010EBA80
		public bool CheckIfHaveChallenge(int challengeId)
		{
			return this.ChallengeMap.ContainsKey(challengeId);
		}

		// Token: 0x04024CDA RID: 150746
		private readonly Dictionary<int, LineCrossChallengeData> ChallengeMap = new Dictionary<int, LineCrossChallengeData>();
	}
}
