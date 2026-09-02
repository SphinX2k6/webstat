using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Encircle
{
	// Token: 0x02006856 RID: 26710
	[NullableContext(1)]
	[Nullable(0)]
	public class ActivityEncircleData : ActivityBaseData
	{
		// Token: 0x06042954 RID: 272724 RVA: 0x01117664 File Offset: 0x01115864
		protected override void PhraseEx(ActivityData data)
		{
			EncircleActivityPb encircleActivityPb = data.EncircleActivityPb;
			RepeatedField<EncircleChallengePb> repeatedField = (encircleActivityPb != null) ? encircleActivityPb.Challenges : null;
			if (repeatedField == null)
			{
				return;
			}
			foreach (EncircleChallengePb encircleChallengePb in repeatedField)
			{
				this.ChallengeState[encircleChallengePb.ChallengeId] = encircleChallengePb;
			}
		}

		// Token: 0x06042955 RID: 272725 RVA: 0x011176D0 File Offset: 0x011158D0
		public bool CheckChallengeNewUnlock(int challengeId)
		{
			bool flag;
			return this.UnlockNewChallenge.TryGetValue(challengeId, out flag) && flag;
		}

		// Token: 0x06042956 RID: 272726 RVA: 0x011176F0 File Offset: 0x011158F0
		public void MarkChallengeNewUnlock(int challengeId, bool value = false)
		{
			this.UnlockNewChallenge[challengeId] = value;
		}

		// Token: 0x06042957 RID: 272727 RVA: 0x01117700 File Offset: 0x01115900
		public bool CheckChallengeComplete(int challengeId)
		{
			EncircleChallengePb encircleChallengePb;
			return this.ChallengeState.TryGetValue(challengeId, out encircleChallengePb) && encircleChallengePb.Pass;
		}

		// Token: 0x06042958 RID: 272728 RVA: 0x01117728 File Offset: 0x01115928
		public bool CheckPreChallengeComplete(int challengeId)
		{
			EncircleChallenge? encircleChallengeConfig = ConfigBase<ActivityEncircleConfig>.Instance.GetEncircleChallengeConfig(challengeId);
			return encircleChallengeConfig.Value.PreId == 0 || this.CheckChallengeComplete(encircleChallengeConfig.Value.PreId);
		}

		// Token: 0x06042959 RID: 272729 RVA: 0x0111776C File Offset: 0x0111596C
		public int GetCompleteChallengeCount()
		{
			int activityId = ControllerBase<ActivityEncircleController>.Instance.ActivityId;
			IReadOnlyList<EncircleChallengeGroup> encircleGroups = ConfigBase<ActivityEncircleConfig>.Instance.GetEncircleGroups(activityId);
			if (encircleGroups == null)
			{
				return 0;
			}
			int num = 0;
			foreach (EncircleChallengeGroup encircleChallengeGroup in encircleGroups)
			{
				if (this.CheckChallengeComplete(encircleChallengeGroup.Challenges(0)))
				{
					num++;
				}
				if (this.CheckChallengeComplete(encircleChallengeGroup.Challenges(1)))
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x0604295A RID: 272730 RVA: 0x011177F8 File Offset: 0x011159F8
		public int GetCurrentChallengeCount()
		{
			int activityId = ControllerBase<ActivityEncircleController>.Instance.ActivityId;
			IReadOnlyList<EncircleChallengeGroup> encircleGroups = ConfigBase<ActivityEncircleConfig>.Instance.GetEncircleGroups(activityId);
			if (encircleGroups == null)
			{
				return 0;
			}
			int num = 0;
			foreach (EncircleChallengeGroup encircleChallengeGroup in encircleGroups)
			{
				num += encircleChallengeGroup.Challenges().Length;
			}
			return num;
		}

		// Token: 0x0604295B RID: 272731 RVA: 0x01117868 File Offset: 0x01115A68
		public int GetCurrentChallenge()
		{
			int activityId = ControllerBase<ActivityEncircleController>.Instance.ActivityId;
			IReadOnlyList<EncircleChallengeGroup> encircleGroups = ConfigBase<ActivityEncircleConfig>.Instance.GetEncircleGroups(activityId);
			if (encircleGroups == null)
			{
				return 0;
			}
			foreach (EncircleChallengeGroup encircleChallengeGroup in encircleGroups)
			{
				foreach (int num in encircleChallengeGroup.ChallengesIter())
				{
					if (!this.CheckChallengeComplete(num))
					{
						return num;
					}
				}
			}
			return 0;
		}

		// Token: 0x0604295C RID: 272732 RVA: 0x01117918 File Offset: 0x01115B18
		public int GetCurrentGroup()
		{
			int activityId = ControllerBase<ActivityEncircleController>.Instance.ActivityId;
			IReadOnlyList<EncircleChallengeGroup> encircleGroups = ConfigBase<ActivityEncircleConfig>.Instance.GetEncircleGroups(activityId);
			if (encircleGroups == null)
			{
				return 0;
			}
			foreach (EncircleChallengeGroup encircleChallengeGroup in encircleGroups)
			{
				if (!this.CheckChallengeComplete(encircleChallengeGroup.Challenges(0)))
				{
					return encircleChallengeGroup.Id;
				}
			}
			return encircleGroups.Count;
		}

		// Token: 0x0604295D RID: 272733 RVA: 0x0111799C File Offset: 0x01115B9C
		public int GetChallengeRecord(int challengeId)
		{
			EncircleChallengePb encircleChallengePb;
			if (!this.ChallengeState.TryGetValue(challengeId, out encircleChallengePb))
			{
				return 0;
			}
			return encircleChallengePb.MinStep;
		}

		// Token: 0x0604295E RID: 272734 RVA: 0x011179C4 File Offset: 0x01115BC4
		public void UpdateChallengeInfo(EncircleChallengePb challengeInfo)
		{
			bool flag;
			if ((!this.UnlockNewChallenge.TryGetValue(challengeInfo.ChallengeId, out flag) || !flag) && !this.CheckChallengeComplete(challengeInfo.ChallengeId) && ConfigBase<ActivityEncircleConfig>.Instance.GetEncircleChallengeConfig(challengeInfo.ChallengeId).Value.Difficulty == 0)
			{
				this.UnlockNewChallenge[challengeInfo.ChallengeId] = true;
			}
			this.ChallengeState[challengeInfo.ChallengeId] = challengeInfo;
			Singleton<EventSystem>.Instance.Emit<EncircleChallengePb>(EEventName.EncircleDataUpdate, challengeInfo);
		}

		// Token: 0x0604295F RID: 272735 RVA: 0x01117A50 File Offset: 0x01115C50
		public bool CheckChallengeIsOpen(int challengeId)
		{
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			EncircleChallengePb encircleChallengePb;
			if (!this.ChallengeState.TryGetValue(challengeId, out encircleChallengePb))
			{
				return false;
			}
			long num = Singleton<MathUtils>.Instance.LongToBigInt(encircleChallengePb.OpenTime);
			return serverTime >= (double)num;
		}

		// Token: 0x06042960 RID: 272736 RVA: 0x01117A94 File Offset: 0x01115C94
		public string GetUnlockDesc(int challengeId)
		{
			long num = Singleton<MathUtils>.Instance.LongToBigInt(this.ChallengeState[challengeId].OpenTime);
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			if (serverTime >= (double)num)
			{
				return "";
			}
			string countDownText = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat3((double)num - serverTime).CountDownText;
			if (countDownText == null)
			{
				return "";
			}
			return countDownText;
		}

		// Token: 0x06042961 RID: 272737 RVA: 0x01117AF4 File Offset: 0x01115CF4
		public bool CheckGroupRedPointShow(int groupId)
		{
			EncircleChallengeGroup? encircleGroup = ConfigBase<ActivityEncircleConfig>.Instance.GetEncircleGroup(groupId);
			bool result = false;
			if (this.CheckChallengeRedPointShow(encircleGroup.Value.Challenges(0)))
			{
				result = true;
			}
			if (this.CheckChallengeRedPointShow(encircleGroup.Value.Challenges(1)))
			{
				result = true;
			}
			return result;
		}

		// Token: 0x06042962 RID: 272738 RVA: 0x01117B44 File Offset: 0x01115D44
		public bool CheckChallengeRedPointShow(int challengeId)
		{
			int activityId = ControllerBase<ActivityEncircleController>.Instance.ActivityId;
			EncircleChallenge? encircleChallengeConfig = ConfigBase<ActivityEncircleConfig>.Instance.GetEncircleChallengeConfig(challengeId);
			return !this.CheckChallengeComplete(challengeId) && this.CheckChallengeIsOpen(challengeId) && (encircleChallengeConfig.Value.PreId == 0 || this.CheckChallengeComplete(encircleChallengeConfig.Value.PreId)) && ModelBase<ActivityModel>.Instance.GetActivityCacheData(activityId, 0, 10001, challengeId, 0) == 0;
		}

		// Token: 0x06042963 RID: 272739 RVA: 0x01117BC0 File Offset: 0x01115DC0
		protected override bool GetExDataFinishShowState()
		{
			return this.GetCompleteChallengeCount() == this.GetCurrentChallengeCount();
		}

		// Token: 0x06042964 RID: 272740 RVA: 0x01117BD0 File Offset: 0x01115DD0
		public override bool GetExDataRedPointShowState()
		{
			return ControllerBase<ActivityEncircleController>.Instance.GetRedPointShow();
		}

		// Token: 0x040250F2 RID: 151794
		private readonly Dictionary<int, EncircleChallengePb> ChallengeState = new Dictionary<int, EncircleChallengePb>();

		// Token: 0x040250F3 RID: 151795
		private readonly Dictionary<int, bool> UnlockNewChallenge = new Dictionary<int, bool>();
	}
}
