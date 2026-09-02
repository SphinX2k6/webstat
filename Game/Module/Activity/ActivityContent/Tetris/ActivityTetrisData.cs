using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x0200628D RID: 25229
	[NullableContext(1)]
	[Nullable(0)]
	public class ActivityTetrisData : ActivityBaseData
	{
		// Token: 0x0603F832 RID: 260146 RVA: 0x01048BF8 File Offset: 0x01046DF8
		protected override void PhraseEx(ActivityData data)
		{
			TetrisActivityInfo tetrisActivityInfo = data.TetrisActivityInfo;
			RepeatedField<TetrisLevelInfo> repeatedField = (tetrisActivityInfo != null) ? tetrisActivityInfo.TetrisLevelInfos : null;
			if (repeatedField == null)
			{
				return;
			}
			foreach (TetrisLevelInfo tetrisLevelInfo in repeatedField)
			{
				this.ChallengeState[tetrisLevelInfo.Id] = tetrisLevelInfo;
			}
		}

		// Token: 0x0603F833 RID: 260147 RVA: 0x01048C64 File Offset: 0x01046E64
		public bool CheckChallengeComplete(int challengeId)
		{
			TetrisLevelInfo tetrisLevelInfo;
			return this.ChallengeState.TryGetValue(challengeId, out tetrisLevelInfo) && tetrisLevelInfo.State == TetrisState.TetrisFinished;
		}

		// Token: 0x0603F834 RID: 260148 RVA: 0x01048C8C File Offset: 0x01046E8C
		public bool CheckPreChallengeComplete(int challengeId)
		{
			Tetris levelConfig = ConfigBase<ActivityTetrisConfig>.Instance.GetLevelConfig(challengeId);
			return levelConfig.UnlockId == 0 || this.CheckChallengeComplete(levelConfig.UnlockId);
		}

		// Token: 0x0603F835 RID: 260149 RVA: 0x01048CC0 File Offset: 0x01046EC0
		public bool CheckChallengeIsOpen(int challengeId)
		{
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			if (!this.ChallengeState.ContainsKey(challengeId))
			{
				return false;
			}
			long unlockTime = this.ChallengeState[challengeId].UnlockTime;
			return serverTime >= (double)unlockTime;
		}

		// Token: 0x0603F836 RID: 260150 RVA: 0x01048D04 File Offset: 0x01046F04
		public void UpdateChallengeState(int challengeId, TetrisState state)
		{
			TetrisLevelInfo tetrisLevelInfo;
			if (!this.ChallengeState.TryGetValue(challengeId, out tetrisLevelInfo))
			{
				return;
			}
			tetrisLevelInfo.State = state;
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnTetrisChallengeStateUpdate, challengeId);
		}

		// Token: 0x0603F837 RID: 260151 RVA: 0x01048D3C File Offset: 0x01046F3C
		public bool CheckGroupRedPointShow(List<int> challengeIds)
		{
			foreach (int challengeId in challengeIds)
			{
				if (this.CheckChallengeRedPointShow(challengeId))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603F838 RID: 260152 RVA: 0x01048D94 File Offset: 0x01046F94
		public bool CheckChallengeRedPointShow(int challengeId)
		{
			int activityId = ControllerBase<ActivityTetrisController>.Instance.ActivityId;
			Tetris levelConfig = ConfigBase<ActivityTetrisConfig>.Instance.GetLevelConfig(challengeId);
			return !this.CheckChallengeComplete(challengeId) && this.CheckChallengeIsOpen(challengeId) && (levelConfig.UnlockId == 0 || this.CheckChallengeComplete(levelConfig.UnlockId)) && ModelBase<ActivityModel>.Instance.GetActivityCacheData(activityId, 0, 10001, challengeId, 0) == 0;
		}

		// Token: 0x0603F839 RID: 260153 RVA: 0x01048E00 File Offset: 0x01047000
		public string GetUnlockDesc(int challengeId)
		{
			long unlockTime = this.ChallengeState[challengeId].UnlockTime;
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			if (serverTime >= (double)unlockTime)
			{
				return "";
			}
			string countDownText = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat3((double)unlockTime - serverTime).CountDownText;
			if (countDownText == null)
			{
				return "";
			}
			return countDownText;
		}

		// Token: 0x0603F83A RID: 260154 RVA: 0x01048E54 File Offset: 0x01047054
		public int GetCompleteChallengeCount()
		{
			int num = 0;
			using (Dictionary<int, TetrisLevelInfo>.ValueCollection.Enumerator enumerator = this.ChallengeState.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.State == TetrisState.TetrisFinished)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x0603F83B RID: 260155 RVA: 0x01048EB4 File Offset: 0x010470B4
		public int GetCurrentChallengeCount()
		{
			return this.ChallengeState.Count;
		}

		// Token: 0x0603F83C RID: 260156 RVA: 0x01048EC4 File Offset: 0x010470C4
		public int GetDisplayChallengeCount()
		{
			int num = 0;
			foreach (int num2 in this.ChallengeState.Keys)
			{
				if (TetrisUtils.IsEggLevel(ConfigBase<ActivityTetrisConfig>.Instance.GetLevelConfig(num2)))
				{
					if (this.CheckPreChallengeComplete(num2))
					{
						num++;
					}
				}
				else
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x0603F83D RID: 260157 RVA: 0x01048F40 File Offset: 0x01047140
		protected override bool GetExDataFinishShowState()
		{
			return this.GetCompleteChallengeCount() == this.GetCurrentChallengeCount();
		}

		// Token: 0x0603F83E RID: 260158 RVA: 0x01048F50 File Offset: 0x01047150
		public override bool GetExDataRedPointShowState()
		{
			return base.GetPreGuideQuestFinishState() && ControllerBase<ActivityTetrisController>.Instance.GetRedPointShow();
		}

		// Token: 0x04023A68 RID: 146024
		private readonly Dictionary<int, TetrisLevelInfo> ChallengeState = new Dictionary<int, TetrisLevelInfo>();
	}
}
